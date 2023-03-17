using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CommanderGql.Models
{
    public class Platform
    {
        public Platform()
        { 
            Commands = new HashSet<Command>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LicenseKey { get; set; }
        public HashSet<Command> Commands { get; set; }
    }
}
