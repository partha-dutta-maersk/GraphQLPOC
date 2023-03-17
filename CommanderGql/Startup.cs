using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommanderGql.Data;
using CommanderGql.GraphQL;
using HotChocolate.AspNetCore;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CommanderGql
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                _configuration.GetConnectionString("CommandConnectionString")));

            services
                .AddGraphQLServer()
                .AddQueryType<Query>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL().WithOptions(new GraphQLServerOptions
                {
                    EnableSchemaRequests = true,
                    
                    Tool = {
                        Enable = env.IsDevelopment()
                    }
                });
            });
        }
    }
}
