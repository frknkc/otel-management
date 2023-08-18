using Microsoft.EntityFrameworkCore;
using otel_management.Entities;

namespace otel_management.Data
{
    public class DatabaseCntx : DbContext
    {
        public DatabaseCntx(DbContextOptions<DatabaseCntx> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Service> Services { get; set; }
    }
}
