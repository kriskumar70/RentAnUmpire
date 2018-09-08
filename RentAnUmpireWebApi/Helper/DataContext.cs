using Microsoft.EntityFrameworkCore;
using RentAnUmpireWebApi.Entities;


namespace RentAnUmpireWebApi.Helper
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}