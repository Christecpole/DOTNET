using Microsoft.EntityFrameworkCore;
using TravelLogMicroService.Models;

namespace TravelLogMicroService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<TravelLogs> TravelLogs { get; set; }
}