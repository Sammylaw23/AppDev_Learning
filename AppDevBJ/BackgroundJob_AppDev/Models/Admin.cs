using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJob_AppDev.Models
{
    public class Admin
    {
        public string AdminEmail { get; set; } = ConfigurationManager.AppSettings["AdminEmail"];
        public string AdminPassword { get; set; } = ConfigurationManager.AppSettings["AdminPassword"];


    }
}
