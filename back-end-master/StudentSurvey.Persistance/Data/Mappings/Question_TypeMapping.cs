using Microsoft.EntityFrameworkCore;
using MyHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Persistance.Data.Mappings
{
    class Question_TypeMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question_Type>()
                 .Property(s => s.Id)
                 .HasColumnName("IDQuestionType")
                 .IsRequired();
            modelBuilder.Entity<Question_Type>()
                .Property(s => s.QuestionType)
                .HasColumnName("Question_Type")
                .IsRequired();
        }
    }
}
