#pragma warning disable 1591
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sber
{
    public class MyServicesTasksContext : DbContext
    {
        public DbSet<MyServicesTasks> ServicesTasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyServicesTasks.db");
        }

    }
}
#pragma warning restore 1591
