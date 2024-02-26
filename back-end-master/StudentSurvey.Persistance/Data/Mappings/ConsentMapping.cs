using Microsoft.EntityFrameworkCore;
using MyHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Persistance.Data.Mappings
{
    class ConsentMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consent>()
                 .Property(s => s.Id)
                 .HasColumnName("IDConsent")   
                 .IsRequired();
            modelBuilder.Entity<Consent>()
                  .Property(s => s.UserID)
                  .HasColumnName("IDUser")
                  .IsRequired();
            modelBuilder.Entity<Consent>()
                 .Property(s => s.SurveyID)
                 .HasColumnName("IDSurvey")
                 .IsRequired();
            modelBuilder.Entity<Consent>()
                 .Property(s => s.ExpirationDate)
                 .HasColumnName("Expiration_Date")
                 .IsRequired();
            modelBuilder.Entity<Consent>()
                 .Property(s => s.Agree)
                 .HasColumnName("Agree")
                 .IsRequired();



        }
    }
}
