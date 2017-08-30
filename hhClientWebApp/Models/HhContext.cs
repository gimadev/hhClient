using System;
using Microsoft.EntityFrameworkCore;

namespace hhClientWebApp.Models
{
	public class HhContext : DbContext
	{
		public DbSet<Salary> Salaries { get; set; }

		public DbSet<Vacancy> Vacancies { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connection = "User ID=gima;Password=;Host=localhost;Port=5432;Database=hhData2";
			optionsBuilder.UseNpgsql(connection);
            Database.EnsureCreated();
		}

	}

}
