using Microsoft.Data.Entity;
using System;
using ProposalDomain.Model;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace ProposalPostgresProvider
{
	public class PostgreSqlContext : DbContext
	{
		public DbSet<Proposal> Proposals { get; set; } 

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ActivityType>().HasKey(m => m.ActivityTypeId);
			builder.Entity<ProposalType>().HasKey(m => m.TypeId);
			builder.Entity<ProposalState>().HasKey(m => m.StateId);
			builder.Entity<Proposal>().HasKey(m => m.ProposalId);

			// shadow properties
			builder.Entity<Proposal>().Property<DateTime>("Created");
			builder.Entity<Proposal>().Property<DateTime>("Updated");

			base.OnModelCreating(builder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder().AddJsonFile("../../config.json").AddEnvironmentVariables();
			var configuration = builder.Build();
			var sqlConnectionString = configuration["DataAccessPostgreSqlProvider:ConnectionString"];

			optionsBuilder.UseNpgsql(sqlConnectionString);
		}

		public override int SaveChanges()
		{
			this.ChangeTracker.DetectChanges();
			this.UpdateUpdatedProperty<Proposal>();

			return base.SaveChanges();
		}

		private void UpdateUpdatedProperty<T>() where T : class
		{
			var modifiedSourceInfo =
				this.ChangeTracker.Entries<T>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

			foreach (var entry in modifiedSourceInfo)
			{
				entry.Property("Created").CurrentValue = DateTime.UtcNow;
				entry.Property("Updated").CurrentValue = DateTime.UtcNow;
			}
		}
	}
}