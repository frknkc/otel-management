using Microsoft.EntityFrameworkCore;
using otel_management.Entities;
using System;

namespace otel_management.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Odalar> Odalar { get; set; }
        public virtual DbSet<Rezervasyonlar> Rezervasyonlar { get; set; }
        public virtual DbSet<Hizmetler> Hizmetler { get; set; }

    }
}