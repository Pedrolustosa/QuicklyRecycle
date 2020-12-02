using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using QuicklyRecycle.Models;

namespace QuicklyRecycle.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<QuicklyRecycle.Models.Company> Company { get; set; }
		public DbSet<QuicklyRecycle.Models.Manager> Manager { get; set; }
		public DbSet<QuicklyRecycle.Models.Collector> Collector { get; set; }
	}
}
