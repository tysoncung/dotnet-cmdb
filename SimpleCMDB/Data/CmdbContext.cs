using Microsoft.EntityFrameworkCore;
using SimpleCMDB.Models;

namespace SimpleCMDB.Data
{
    public class CmdbContext : DbContext
    {
        public CmdbContext(DbContextOptions<CmdbContext> options)
            : base(options)
        {
        }

        public DbSet<Server> Servers { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Dependency> Dependencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Server entity
            modelBuilder.Entity<Server>(entity =>
            {
                entity.HasIndex(e => e.Hostname).IsUnique();
                entity.Property(e => e.Environment).HasDefaultValue("production");
                entity.Property(e => e.Status).HasDefaultValue("active");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("datetime('now')");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("datetime('now')");
            });

            // Configure Application entity
            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Criticality).HasDefaultValue("medium");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("datetime('now')");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("datetime('now')");
            });

            // Configure Service entity
            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Protocol).HasDefaultValue("tcp");
                entity.Property(e => e.Status).HasDefaultValue("running");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("datetime('now')");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("datetime('now')");

                entity.HasOne(s => s.Server)
                    .WithMany(srv => srv.Services)
                    .HasForeignKey(s => s.ServerId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.Application)
                    .WithMany(a => a.Services)
                    .HasForeignKey(s => s.ApplicationId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configure Dependency entity
            modelBuilder.Entity<Dependency>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("datetime('now')");

                entity.HasOne(d => d.SourceService)
                    .WithMany(s => s.SourceDependencies)
                    .HasForeignKey(d => d.SourceServiceId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.TargetService)
                    .WithMany(s => s.TargetDependencies)
                    .HasForeignKey(d => d.TargetServiceId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => new { e.SourceServiceId, e.TargetServiceId }).IsUnique();
            });
        }
    }
}