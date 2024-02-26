using Microsoft.EntityFrameworkCore;
using MyHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Persistance.Data.Mappings
{
    class AnswersMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answers>()
                 .Property(s => s.Id)
                 .HasColumnName("IDAnswer")
                 .IsRequired();
            modelBuilder.Entity<Answers>()
                 .Property(s => s.QuestionID)
                 .HasColumnName("IdQuestion")
                 .IsRequired();
            modelBuilder.Entity<Answers>()
                 .Property(s => s.Option1)
                 .HasColumnName("Option1")
                 .IsRequired();
            modelBuilder.Entity<Answers>()
                 .Property(s => s.Option2)
                 .HasColumnName("Option2")
                 .IsRequired();
            modelBuilder.Entity<Answers>()
                 .Property(s => s.Option3)
                 .HasColumnName("Option3")
                 .IsRequired();
            modelBuilder.Entity<Answers>()
                 .Property(s => s.Option4)
                 .HasColumnName("Option4")
                 .IsRequired();



        }
    }
}
