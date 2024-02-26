using Microsoft.EntityFrameworkCore;
using MyHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Persistance.Data.Mappings
{
    class QuestionsMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questions>()
                 .Property(s => s.Id)
                 .HasColumnName("IDQuestion")
                 .IsRequired();
            modelBuilder.Entity<Questions>()
                 .Property(s => s.Question_TypeID)
                 .HasColumnName("ID_QuestionType")
                 .IsRequired();
            modelBuilder.Entity<Questions>()
                 .Property(s => s.Question)
                 .HasColumnName("Question")
                 .IsRequired();
        }
    }
}
