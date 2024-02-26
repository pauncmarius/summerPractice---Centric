using Microsoft.EntityFrameworkCore;
using MyHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Persistance.Data.Mappings
{
    internal abstract class UserMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(s => s.Id)
                .HasColumnName("IdUser")
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(s => s.Username)
                .HasColumnName("Username")
                .HasMaxLength(25)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(s => s.Email)
                .HasColumnName("Email")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
               .Property(s => s.FirstName)
               .HasMaxLength(50)
               .HasColumnName("First_Name")
               .IsRequired();

            modelBuilder.Entity<User>()
               .Property(s => s.LastName)
               .HasColumnName("Last_Name")
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder.Entity<User>()
               .Property(s => s.Hashed_Password)
               .HasColumnName("Hashed_Password")
               .IsRequired();

            modelBuilder.Entity<User>()
               .Property(s => s.PhoneNumber)
               .HasMaxLength(20)
               .HasColumnName("Phone_Number")
               .IsRequired();

            modelBuilder.Entity<User>()
               .Property(s => s.IsAdmin)
               .HasColumnName("IsAdmin")
               .IsRequired();

        }
    }
}
