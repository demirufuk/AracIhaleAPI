using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Layer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<DCAUye> DCAUye { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}