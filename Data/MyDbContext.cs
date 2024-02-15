using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using todos.Models;

namespace todos.Data
{
    public class MyDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        // public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        // {
        // }

        public MyDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        /// <summary>
        /// DbSet for Task entities.
        /// </summary>
        public DbSet<Models.Task> Tasks { get; set; }

        /// <summary>
        /// Configures entity mappings and relationships for database context.
        /// </summary>
        /// <param name="modelBuilder">Model builder used to construct the model for the context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>().HasKey(t => t.Id);
            modelBuilder.Entity<Models.Task>().ToTable("Tasks");
        }
    }
}

