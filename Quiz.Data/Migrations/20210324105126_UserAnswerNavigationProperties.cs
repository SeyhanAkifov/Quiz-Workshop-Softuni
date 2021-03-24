using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.Data.Migrations
{
    public partial class UserAnswerNavigationProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_UserAnswer_Answers_AnswerId",
            //    table: "UserAnswer");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_UserAnswer_AspNetUsers_IdentityUserId",
            //    table: "UserAnswer");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_UserAnswer_Questions_QuestionId",
            //    table: "UserAnswer");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_UserAnswer_Quizzes_QuizId",
            //    table: "UserAnswer");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_UserAnswer",
            //    table: "UserAnswer");

            //migrationBuilder.DropIndex(
            //    name: "IX_UserAnswer_QuizId",
            //    table: "UserAnswer");

            //migrationBuilder.RenameTable(
            //    name: "UserAnswer",
            //    newName: "UserAnswers");

            //migrationBuilder.RenameIndex(
            //    name: "IX_UserAnswer_QuestionId",
            //    table: "UserAnswers",
            //    newName: "IX_UserAnswers_QuestionId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_UserAnswer_IdentityUserId",
            //    table: "UserAnswers",
            //    newName: "IX_UserAnswers_IdentityUserId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_UserAnswer_AnswerId",
            //    table: "UserAnswers",
            //    newName: "IX_UserAnswers_AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers",
                columns: new[] { "QuizId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Answers_AnswerId",
                table: "UserAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_AspNetUsers_UserId",
                table: "UserAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Questions_QuestionId",
                table: "UserAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Quizzes_QuizId",
                table: "UserAnswers",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Answers_AnswerId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_AspNetUsers_UserId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Questions_QuestionId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Quizzes_QuizId",
                table: "UserAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers");

            migrationBuilder.RenameTable(
                name: "UserAnswers",
                newName: "UserAnswer");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_QuestionId",
                table: "UserAnswer",
                newName: "IX_UserAnswer_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_UserId",
                table: "UserAnswer",
                newName: "IX_UserAnswer_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnswers_AnswerId",
                table: "UserAnswer",
                newName: "IX_UserAnswer_AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnswer",
                table: "UserAnswer",
                columns: new[] { "UserId", "QuizId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_QuizId",
                table: "UserAnswer",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_Answers_AnswerId",
                table: "UserAnswer",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_AspNetUsers_UserId",
                table: "UserAnswer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_Questions_QuestionId",
                table: "UserAnswer",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_Quizzes_QuizId",
                table: "UserAnswer",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
