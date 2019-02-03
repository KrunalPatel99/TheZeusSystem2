namespace EmployeeManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ZeusDB : DbContext
    {
        public ZeusDB()
            : base("name=ZeusDB")
        {
        }

        public virtual DbSet<EmplyeeInfo> EmplyeeInfoes { get; set; }
        public virtual DbSet<PayInfo> PayInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmplyeeInfo>()
                .Property(e => e.EmployeeName)
                .IsUnicode(false);

            modelBuilder.Entity<EmplyeeInfo>()
                .Property(e => e.EmployeeID)
                .IsUnicode(false);

            modelBuilder.Entity<EmplyeeInfo>()
                .Property(e => e.EmployeeAddress)
                .IsUnicode(false);

            modelBuilder.Entity<EmplyeeInfo>()
                .Property(e => e.EmployeeEmailID)
                .IsUnicode(false);

            modelBuilder.Entity<EmplyeeInfo>()
                .HasMany(e => e.PayInfoes)
                .WithRequired(e => e.EmplyeeInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PayInfo>()
                .Property(e => e.EmployeeID)
                .IsUnicode(false);

            modelBuilder.Entity<PayInfo>()
                .Property(e => e.Pay)
                .HasPrecision(10, 2);
        }
    }
}
