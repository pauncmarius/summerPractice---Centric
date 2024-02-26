using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSurvey.Persistance.Data.Migrations
{
    public partial class AddUserAndQuestionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question_Types",
                columns: table => new
                {
                    IDQuestionType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question_Types", x => x.IDQuestionType);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    IDTopic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.IDTopic);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Hashed_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    IDSurvey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDTopic = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opening_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Closing_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    TopicsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.IDSurvey);
                    table.ForeignKey(
                        name: "FK_Surveys_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "IDTopic",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Surveys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consents",
                columns: table => new
                {
                    IDConsent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    IDSurvey = table.Column<int>(type: "int", nullable: false),
                    Expiration_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Agree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consents", x => x.IDConsent);
                    table.ForeignKey(
                        name: "FK_Consents_Surveys_IDSurvey",
                        column: x => x.IDSurvey,
                        principalTable: "Surveys",
                        principalColumn: "IDSurvey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consents_Users_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    IDQuestion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_QuestionType = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.IDQuestion);
                    table.ForeignKey(
                        name: "FK_Questions_Question_Types_ID_QuestionType",
                        column: x => x.ID_QuestionType,
                        principalTable: "Question_Types",
                        principalColumn: "IDQuestionType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "IDSurvey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    IDAnswer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdQuestion = table.Column<int>(type: "int", nullable: false),
                    Option1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.IDAnswer);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_IdQuestion",
                        column: x => x.IdQuestion,
                        principalTable: "Questions",
                        principalColumn: "IDQuestion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survey_Questions",
                columns: table => new
                {
                    ID_SurveyQuestion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSurvey = table.Column<int>(type: "int", nullable: false),
                    IDQuestion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey_Questions", x => x.ID_SurveyQuestion);
                    table.ForeignKey(
                        name: "FK_Survey_Questions_Questions_IDQuestion",
                        column: x => x.IDQuestion,
                        principalTable: "Questions",
                        principalColumn: "IDQuestion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Survey_Questions_Surveys_IDSurvey",
                        column: x => x.IDSurvey,
                        principalTable: "Surveys",
                        principalColumn: "IDSurvey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survey_Answers",
                columns: table => new
                {
                    ID_SurveyAnswer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_SurveyQuestion = table.Column<int>(type: "int", nullable: false),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Survey_QuestionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey_Answers", x => x.ID_SurveyAnswer);
                    table.ForeignKey(
                        name: "FK_Survey_Answers_Survey_Questions_Survey_QuestionsId",
                        column: x => x.Survey_QuestionsId,
                        principalTable: "Survey_Questions",
                        principalColumn: "ID_SurveyQuestion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Survey_Answers_Users_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Question_Types",
                columns: new[] { "IDQuestionType", "Question_Type" },
                values: new object[] { 1, "Selector" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "Email", "First_Name", "Hashed_Password", "IsAdmin", "Last_Name", "Phone_Number", "Username" },
                values: new object[] { 20, "user@yahoo.com", "First", "123456", false, "User", "0712345678", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "IdUser", "Email", "First_Name", "Hashed_Password", "IsAdmin", "Last_Name", "Phone_Number", "Username" },
                values: new object[] { 21, "usernou@yahoo.com", "FirstUser", "123456", true, "LastUser", "0712345671", "UserNou" });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_IdQuestion",
                table: "Answers",
                column: "IdQuestion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consents_IDSurvey",
                table: "Consents",
                column: "IDSurvey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consents_IDUser",
                table: "Consents",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ID_QuestionType",
                table: "Questions",
                column: "ID_QuestionType");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_Answers_IDUser",
                table: "Survey_Answers",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_Answers_Survey_QuestionsId",
                table: "Survey_Answers",
                column: "Survey_QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_Questions_IDQuestion",
                table: "Survey_Questions",
                column: "IDQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_Questions_IDSurvey",
                table: "Survey_Questions",
                column: "IDSurvey");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_TopicsId",
                table: "Surveys",
                column: "TopicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_UserId",
                table: "Surveys",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Consents");

            migrationBuilder.DropTable(
                name: "Survey_Answers");

            migrationBuilder.DropTable(
                name: "Survey_Questions");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Question_Types");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
