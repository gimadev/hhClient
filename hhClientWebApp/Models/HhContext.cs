using System;
using Microsoft.EntityFrameworkCore;

namespace hhClientWebApp.Models
{
	public class HhContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server=tcp:hhdemo.database.windows.net,1433;Initial Catalog=hhLocal;Persist Security Info=False;User ID=gima;Password=xREzFBhd55;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connection);
            
        }

        public DbSet<Salary> Salaries { get; set; }

        public DbSet<Vacancy> Vacancies { get; set; }

    }

}
