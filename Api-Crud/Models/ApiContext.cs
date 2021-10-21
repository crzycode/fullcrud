using Api_Crud.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Api_Crud.Models
{
    public class ApiContext: DbContext
    {
        public DbSet<user> users { get; set; }
        public DbSet<userdata> userdatas { get; set; }
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApiContext, Configuration>());
        }
    }
}