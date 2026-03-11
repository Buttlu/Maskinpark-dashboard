using Maskinpark.Models;
using Microsoft.EntityFrameworkCore;

namespace Maskinpark.Persistance;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Machine> Machines { get; set; }
}
