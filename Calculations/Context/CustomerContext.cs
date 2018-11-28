using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Calculations.Model;
namespace Calculations.Context
{
    public class CustomerContext: DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options): base(options)
        {
        }

        public virtual DbSet<CustomerModel> CustomerModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=127.0.0.1;port=3333;database=feedback;user=root;pwd=mypassword;Convert Zero Datetime=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerModel>(entity =>
            {
                entity.ToTable("feedback_entry");

                entity.Property(e => e.Id)                     .HasColumnName("id")                     .HasColumnType("int(11)");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(255)");

            });
        }
    }
}