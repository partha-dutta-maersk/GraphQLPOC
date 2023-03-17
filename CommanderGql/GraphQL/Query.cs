using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommanderGql.Data;
using CommanderGql.Models;
using HotChocolate;

namespace CommanderGql.GraphQL
{
    public class Query
    {
        public IQueryable<Platform> GetPlatforms([Service] AppDbContext context)
        {
            return context.Platforms;
        }
    }
}
