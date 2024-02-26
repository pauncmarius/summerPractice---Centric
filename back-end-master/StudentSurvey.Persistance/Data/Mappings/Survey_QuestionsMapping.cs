using Microsoft.EntityFrameworkCore;
using MyHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Persistance.Data.Mappings
{
    class Survey_QuestionsMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey_Questions>()
                 .Property(s => s.Id)
                 .HasColumnName("ID_SurveyQuestion")
                 .IsRequired();
            modelBuilder.Entity<Survey_Questions>()
                .Property(s => s.SurveyID)
                .HasColumnName("IDSurvey")
                .IsRequired();
            modelBuilder.Entity<Survey_Questions>()
                .Property(s => s.QuestionsID)
                .HasColumnName("IDQuestion")
                .IsRequired();

        }
    }
}

