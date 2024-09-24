using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class ProjectCotext:DbContext
    {
        

        public ProjectCotext(DbContextOptions<ProjectCotext> options) : base(options)
        {

        }

     
   
        public DbSet<DonationDetail> DonationDetail { get; set; }
        public DbSet <SendEmailModel>EmailRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

         modelBuilder.Entity<DonationDetail>()
        .Property(p => p.DonationAmount)
        .IsRequired();

            modelBuilder.Entity<DonationDetail>()
          .Property(p => p.EntityName)
          .IsRequired();
            modelBuilder.Entity<DonationDetail>()
           .Property(p => p.EntityType)
          .IsRequired();
            modelBuilder.Entity<DonationDetail>()
          .Property(p => p.DonationTarget)
          .IsRequired();

            modelBuilder.Entity<DonationDetail>()
            .Property(p => p.CurrencyType)
             .IsRequired();

            modelBuilder.Entity<DonationDetail>()
            .Property(p => p.ConversionRate)
            .IsRequired();

        }








    }
}
