using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAnUmpireWebApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public UserRole Role { get; set; }
        public bool Certified { get; set; }
    }

    public class UserRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       // public TournamentGroup Group { get; set; }
    }

    public class TournamentGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tournament> Tournaments { get; set; }
    }
    public class Schedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RefId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd{ get; set; }
        public DateTime CreatedDate { get; set; }
        public string Format { get; set; }
        public ScheduleStatus Status { get; set; }
    }

    public class ScheduleStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public string ConfirmationNumber { get; set; }
        public DateTime PaymentDate { get; set; }
    }
    public class PaymentStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
    public class Refund
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public RefundStatus Status { get; set; }
        public string ConfirmationNumber { get; set; }
        public DateTime PaymentDate { get; set; }
    }
    public class RefundStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }

    public class Rental
    {
        public int Id { get; set; }
        public User Umpire1 { get; set; }
        public User Umpire2 { get; set; }
        public Schedule RentalSchedule { get; set; }
        public RentalStatus Status { get; set; }
        public Payment RentalPayment { get; set; }
        public Refund RentalRefund { get; set; }
    }
    public class RentalStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }

}