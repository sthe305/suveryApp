using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyApp.Migrations
{
    /// <inheritdoc />
    public partial class updatedUsertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteFoods_Users_UserID",
                table: "FavouriteFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Questions_SurveyID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SurveyID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SurveyID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "surveyQuestion",
                table: "Questions",
                newName: "SurveyQuestion");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "FavouriteFoods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserID",
                table: "Questions",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteFoods_Users_UserID",
                table: "FavouriteFoods",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserID",
                table: "Questions",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteFoods_Users_UserID",
                table: "FavouriteFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserID",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UserID",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "SurveyQuestion",
                table: "Questions",
                newName: "surveyQuestion");

            migrationBuilder.AddColumn<int>(
                name: "SurveyID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "FavouriteFoods",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SurveyID",
                table: "Users",
                column: "SurveyID");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteFoods_Users_UserID",
                table: "FavouriteFoods",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Questions_SurveyID",
                table: "Users",
                column: "SurveyID",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
