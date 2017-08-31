using System;
using Microsoft.EntityFrameworkCore;

namespace hhClientWebApp.Models
{
	public class HhContext : DbContext
	{
		public DbSet<Salary> Salaries { get; set; }

		public DbSet<Vacancy> Vacancies { get; set; }

		

	}

}
