using FireBird.API.Models;

using Microsoft.EntityFrameworkCore;

namespace FireBird.API.Data
{
	public class DataContext : DbContext
	{
		public DbSet<PersonModel> Persons { get; set; }

		public DbSet<CarModel> Cars { get; set; }

		public DataContext()
		{
		}

		public DataContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<PersonModel>().HasIndex(prop => prop.CPF).IsUnique();
		}
	}
}