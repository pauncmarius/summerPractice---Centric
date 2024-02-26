using Microsoft.EntityFrameworkCore;
using MyHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Persistance.Data.Mappings
{
    class Survey_AnswersMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey_Answers>()
                 .Property(s => s.Id)
                 .HasColumnName("ID_SurveyAnswer")
                 .IsRequired();
            modelBuilder.Entity<Survey_Answers>()
                .Property(s => s.Survey_QuestionID)
                .HasColumnName("ID_SurveyQuestion")
                .IsRequired();
            modelBuilder.Entity<Survey_Answers>()
                 .Property(s => s.UserID)
                 .HasColumnName("IDUser")
                 .IsRequired();
            modelBuilder.Entity<Survey_Answers>()
                 .Property(s => s.Answer)
                 .HasColumnName("Answer")
                 .IsRequired();
        }
    }
}
