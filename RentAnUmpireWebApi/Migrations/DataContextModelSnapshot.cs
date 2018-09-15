﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RentAnUmpireWebApi.Helper;
using System;

namespace RentAnUmpireWebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<string>("ConfirmationNumber");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<int?>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.PaymentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("PaymentStatuses");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.Refund", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<string>("ConfirmationNumber");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<int?>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Refunds");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.RefundStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("RefundStatuses");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("RentalPaymentId");

                    b.Property<int?>("RentalRefundId");

                    b.Property<int?>("RentalScheduleId");

                    b.Property<int?>("StatusId");

                    b.Property<int?>("Umpire1Id");

                    b.Property<int?>("Umpire2Id");

                    b.HasKey("Id");

                    b.HasIndex("RentalPaymentId");

                    b.HasIndex("RentalRefundId");

                    b.HasIndex("RentalScheduleId");

                    b.HasIndex("StatusId");

                    b.HasIndex("Umpire1Id");

                    b.HasIndex("Umpire2Id");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.RentalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("RentalStatuses");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DateStart");

                    b.Property<string>("Description");

                    b.Property<string>("Format");

                    b.Property<string>("Name");

                    b.Property<int>("RefId");

                    b.Property<int?>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.ScheduleStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("ScheduleStatuses");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("TournamentGroupId");

                    b.HasKey("Id");

                    b.HasIndex("TournamentGroupId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.TournamentGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TournamentGroups");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Certified");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<int>("Phone");

                    b.Property<int?>("RoleId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.Payment", b =>
                {
                    b.HasOne("RentAnUmpireWebApi.Entities.PaymentStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.Refund", b =>
                {
                    b.HasOne("RentAnUmpireWebApi.Entities.RefundStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.Rental", b =>
                {
                    b.HasOne("RentAnUmpireWebApi.Entities.Payment", "RentalPayment")
                        .WithMany()
                        .HasForeignKey("RentalPaymentId");

                    b.HasOne("RentAnUmpireWebApi.Entities.Refund", "RentalRefund")
                        .WithMany()
                        .HasForeignKey("RentalRefundId");

                    b.HasOne("RentAnUmpireWebApi.Entities.Schedule", "RentalSchedule")
                        .WithMany()
                        .HasForeignKey("RentalScheduleId");

                    b.HasOne("RentAnUmpireWebApi.Entities.RentalStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("RentAnUmpireWebApi.Entities.User", "Umpire1")
                        .WithMany()
                        .HasForeignKey("Umpire1Id");

                    b.HasOne("RentAnUmpireWebApi.Entities.User", "Umpire2")
                        .WithMany()
                        .HasForeignKey("Umpire2Id");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.Schedule", b =>
                {
                    b.HasOne("RentAnUmpireWebApi.Entities.ScheduleStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.Tournament", b =>
                {
                    b.HasOne("RentAnUmpireWebApi.Entities.TournamentGroup")
                        .WithMany("Tournaments")
                        .HasForeignKey("TournamentGroupId");
                });

            modelBuilder.Entity("RentAnUmpireWebApi.Entities.User", b =>
                {
                    b.HasOne("RentAnUmpireWebApi.Entities.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
