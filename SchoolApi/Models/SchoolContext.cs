using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolApi.Models
{
	public class SchoolContext : DbContext
	{
		public DbSet<Major> Majors { get; set; }
		public DbSet<Student> Students { get; set; }

		public SchoolContext() : base() { }
	}
}