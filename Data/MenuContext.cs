using MenuGraph.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuGraph.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Category>? Categories { get; set; }
}