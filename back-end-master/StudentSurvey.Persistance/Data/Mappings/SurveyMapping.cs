using Microsoft.EntityFrameworkCore;
using MyHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Persistance.Data.Mappings
{
    class SurveyMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                 .Property(s => s.Id)
                 .HasColumnName("IDSurvey")
                 .IsRequired();
            modelBuilder.Entity<Survey>()
                 .Property(s => s.IDTopic)
                 .HasColumnName("IDTopic")
                 .IsRequired();
            modelBuilder.Entity<Survey>()
                 .Property(s => s.Name)
                 .HasColumnName("Name")
                 .IsRequired();
            modelBuilder.Entity<Survey>()
                 .Property(s => s.Description)
                 .HasColumnName("Description")
                 .IsRequired();
            modelBuilder.Entity<Survey>()
                 .Property(s => s.Opening_Time)
                 .HasColumnName("Opening_Time")
                 .IsRequired();
            modelBuilder.Entity<Survey>()
                 .Property(s => s.Closing_Time)
                 .HasColumnName("Closing_Time")
                 .IsRequired();
            modelBuilder.Entity<Survey>()
                 .Property(s => s.Created_By)
                 .HasColumnName("Created_By")                
                 .IsRequired();
            modelBuilder.Entity<Survey>()
                 .Property(s => s.Modified_By)
                 .HasColumnName("Modified_By")
                 .IsRequired();
            

        }
    }
}
