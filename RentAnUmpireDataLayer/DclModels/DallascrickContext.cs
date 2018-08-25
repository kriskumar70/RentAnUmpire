using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RentAnUmpireDataLayer.DclModels
{
    public partial class DallascrickContext : DbContext
    {
        public virtual DbSet<MatchStats> MatchStats { get; set; }
        public virtual DbSet<Migration> Migration { get; set; }
        public virtual DbSet<MigrationRelation> MigrationRelation { get; set; }

        // Unable to generate entity type for table 'dbo.address'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.award_types'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.dtproperties'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ground'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.match'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.match_batting'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.match_bowling'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PaymentDetails'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.penalty'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.phone'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.player'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.player_batting'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.player_bowling'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.role'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.rules'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.team'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.team_registration'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tournament'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tournament_awards'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tournament_team'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.user_role'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.users'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.announcement'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.log'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.team_division'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ground_reservations'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.bis_dcl'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tempDups2'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.match1'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.FloodLight2016'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.floodlight'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.email'. Please see the warning messages.

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Server=tcp:sql2k802.discountasp.net;Initial Catalog=SQL2008_739130_dallascrick;User ID=SQL2008_739130_dallascrick_user;Password=dcl650;");
        //            }
        //        }
        public DallascrickContext(DbContextOptions<DallascrickContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchStats>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.TeamId });

                entity.ToTable("match_stats");

                entity.Property(e => e.MatchId).HasColumnName("match_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.Byes).HasColumnName("byes");

                entity.Property(e => e.Extras).HasColumnName("extras");

                entity.Property(e => e.InningSw).HasColumnName("inning_sw");

                entity.Property(e => e.LegByes).HasColumnName("leg_byes");

                entity.Property(e => e.Nos).HasColumnName("nos");

                entity.Property(e => e.OverThrow).HasColumnName("over_throw");

                entity.Property(e => e.Overs).HasColumnName("overs");

                entity.Property(e => e.RunsScored).HasColumnName("runs_scored");

                entity.Property(e => e.TotalRuns).HasColumnName("total_runs");

                entity.Property(e => e.Wickets).HasColumnName("wickets");

                entity.Property(e => e.Wides).HasColumnName("wides");
            });

            modelBuilder.Entity<Migration>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.SqlId, e.SecondaryKey });

                entity.Property(e => e.Key)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MongoId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MigrationRelation>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.SqlId, e.SecondaryKey });

                entity.ToTable("Migration_Relation");

                entity.Property(e => e.Key)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
