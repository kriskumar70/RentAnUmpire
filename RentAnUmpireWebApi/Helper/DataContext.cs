using Microsoft.EntityFrameworkCore;
using RentAnUmpireWebApi.Entities;

namespace RentAnUmpireWebApi.Helper
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentGroup> TournamentGroups { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleStatus> ScheduleStatuses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<Refund> Refunds { get; set; }
        public DbSet<RefundStatus> RefundStatuses { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalStatus> RentalStatuses { get; set; }

    }
}