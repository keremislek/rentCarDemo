using aracKiralama.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace aracKiralama.Migration
{
    public sealed class Configuration : DbMigrationsConfiguration<AracKiralaModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }
    }

}