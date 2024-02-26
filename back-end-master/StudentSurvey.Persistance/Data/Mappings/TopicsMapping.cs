using Microsoft.EntityFrameworkCore;
using MyHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSurvey.Persistance.Data.Mappings
{
    class TopicsMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topics>()
                .Property(s => s.Id)
                .HasColumnName("IDTopic")
                .IsRequired();
            modelBuilder.Entity<Topics>()
                .Property(s => s.Topic)
                .HasColumnName("Topic")
                .IsRequired();

        }
    }
}
