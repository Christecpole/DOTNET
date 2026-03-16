using Microsoft.EntityFrameworkCore;
using ObservationService.Models;

namespace ObservationService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Observation> Observations { get; set; }
}