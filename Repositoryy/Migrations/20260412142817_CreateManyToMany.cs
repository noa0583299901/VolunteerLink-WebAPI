using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositoryy.Migrations
{
    /// <inheritdoc />
    public partial class CreateManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volunteers_Skills_SkillId",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_SkillId",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Volunteers");

            migrationBuilder.CreateTable(
                name: "MyVolunteerSkill",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                    VolunteersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyVolunteerSkill", x => new { x.SkillsId, x.VolunteersId });
                    table.ForeignKey(
                        name: "FK_MyVolunteerSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyVolunteerSkill_Volunteers_VolunteersId",
                        column: x => x.VolunteersId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyVolunteerSkill_VolunteersId",
                table: "MyVolunteerSkill",
                column: "VolunteersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyVolunteerSkill");

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "Volunteers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_SkillId",
                table: "Volunteers",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteers_Skills_SkillId",
                table: "Volunteers",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");
        }
    }
}
