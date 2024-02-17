using CheckPoint.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckPoint.Context;

public class CheckPointContext : DbContext
{
    public CheckPointContext(DbContextOptions options) : base(options){}
    public DbSet<User> Users { get; set; }
}