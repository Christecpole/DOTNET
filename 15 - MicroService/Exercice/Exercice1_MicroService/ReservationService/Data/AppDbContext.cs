using Microsoft.EntityFrameworkCore;
using ReservationService.Models;

namespace ReservationService.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext (DbContextOptions<AppDbContext> option) : base(option) { }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
