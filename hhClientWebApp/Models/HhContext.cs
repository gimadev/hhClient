using System;
using Microsoft.EntityFrameworkCore;

namespace hhClientWebApp.Models
{
	public class HhContext : DbContext
	{
		public HhContext(DbContextOptions<HhContext> options)
			: base(options)
		{ 
            Database.EnsureCreated();
        }

		public DbSet<Salary> Salaries { get; set; }

		public DbSet<Vacancy> Vacancies { get; set; }

	}

}
