using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSurvey.Persistance.Data.Migrations
{
    public partial class DBModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "Question_Types",
                keyColumn: "IDQuestionType",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "IdUser",
                keyValue: 21);

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "Questions",
                type: "int",
                nullable: true);

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
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "IDSurvey",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
