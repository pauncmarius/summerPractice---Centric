using Microsoft.EntityFrameworkCore;
using MyHotel.Domain.Entities;
using StudentSurvey.Persistance.Data.Mappings;
using System.Collections.Generic;


namespace StudentSurvey.Persistance.Data
{
    public class StudentSurveyDbContext : DbContext
    {
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Consent> Consents { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Question_Type> Question_Types { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Survey_Answers> Survey_Answers { get; set; }
        public DbSet<Survey_Questions> Survey_Questions { get; set; }
        public DbSet<Topics> Topics { get; set; }
        public DbSet<User> Users { get; set; }

        public StudentSurveyDbContext(DbContextOptions<StudentSurveyDbContext> options)
              : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=StudentSurvey;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(@connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AnswersMapping.Map(modelBuilder);
            ConsentMapping.Map(modelBuilder);
            QuestionsMapping.Map(modelBuilder);
            Question_TypeMapping.Map(modelBuilder);
            Survey_AnswersMapping.Map(modelBuilder);
            SurveyMapping.Map(modelBuilder);
            Survey_QuestionsMapping.Map(modelBuilder);
            TopicsMapping.Map(modelBuilder);
            UserMapping.Map(modelBuilder);
            SeedDatabase(modelBuilder);
        }
        private static void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new List<User>()
            {
                /*new User()
                {
                    Id = 20,
                    Username = "User",
                    Email = "user@yahoo.com",
                    FirstName = "First",
                    LastName = "User",
                    Hashed_Password = "123456",
                    PhoneNumber = "0712345678",
                    IsAdmin = false
                },
                new User()
                {
                    Id = 21,
                    Username = "UserNou",
                    Email = "usernou@yahoo.com",
                    FirstName = "FirstUser",
                    LastName = "LastUser",
                    Hashed_Password = "123456",
                    PhoneNumber = "0712345671",
                    IsAdmin = true
                }
                */


            });
            modelBuilder.Entity<Question_Type>().HasData(new List<Question_Type>()
            {
                /*new Question_Type()
                {
                    Id=1,
                    QuestionType= "Selector"
                }*/



            });
        }
    }
}
