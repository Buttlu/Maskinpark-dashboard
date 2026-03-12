using MaskinPark.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaskinPark.Infrastructure.Persistance;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Machine> Machines { get; set; }
}
