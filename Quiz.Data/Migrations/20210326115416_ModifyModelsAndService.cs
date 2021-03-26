using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.Data.Migrations
{
    public partial class ModifyModelsAndService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizes_QuizId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quizes",
                table: "Quizes");

            migrationBuilder.RenameTable(
                name: "Quizes",
                newName: "Quizzes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes");

            migrationBuilder.RenameTable(
                name: "Quizzes",
                newName: "Quizes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quizes",
                table: "Quizes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizes_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
