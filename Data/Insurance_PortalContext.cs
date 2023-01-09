using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InsurancePortal.Models;

namespace InsurancePortal.Data
{
    public partial class Insurance_PortalContext : DbContext
    {
        public Insurance_PortalContext()
        {
        }

        public Insurance_PortalContext(DbContextOptions<Insurance_PortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthDetail> AuthDetails { get; set; } = null!;
        public virtual DbSet<Policy> Policies { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;
        public virtual DbSet<UserPolicy> UserPolicies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<AuthDetail>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PRIMARY");

                entity.Property(e => e.Password).IsFixedLength();
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<UserPolicy>(entity =>
            {
                entity.HasKey(e => e.RecordId)
                    .HasName("PRIMARY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
