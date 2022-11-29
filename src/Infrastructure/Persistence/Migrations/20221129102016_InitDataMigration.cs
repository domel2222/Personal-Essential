using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class InitDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Strenghts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InactivatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InactivatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strenghts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InactivatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InactivatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar", nullable: true),
                    DiaryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InactivatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InactivatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MostWins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    JournalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StrenghtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InactivatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InactivatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MostWins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MostWins_Journals_JournalId",
                        column: x => x.JournalId,
                        principalTable: "Journals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MostWins_Strenghts_StrenghtId",
                        column: x => x.StrenghtId,
                        principalTable: "Strenghts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelfAssessmentValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeepWorkResult = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    AffirmationResult = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    UsePhoneResult = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    LearningResult = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    StepsResult = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    TrainingResult = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    CaloriesResult = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    EnglishTimeResult = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    AudiobookReadingResult = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    DailyResult = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    AssesmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InactivatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InactivatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelfAssessmentValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelfAssessmentValues_Journals_JournalId",
                        column: x => x.JournalId,
                        principalTable: "Journals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SelfAssessmentValues_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Strenghts",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "InactivatedBy", "InactivatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("0e69de60-bd83-4c77-a4e1-b53c17cbe62a"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5149), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5151), "Achiever" },
                    { new Guid("37ad5fb7-0b86-46ec-9608-9cbf5e70d4aa"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5112), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5144), "Responsibility" },
                    { new Guid("54cf59e2-6992-4f65-875d-f47ffa02274a"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5234), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5236), "Futuristic" },
                    { new Guid("56ea1ef4-046d-4fd4-bfe5-93f725f2a852"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5179), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5181), "Activator" },
                    { new Guid("64605f9e-e649-44bc-8250-3061045572c3"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5171), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5172), "Individualization" },
                    { new Guid("96f241b5-ccc9-4935-b263-69395ea0a167"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5243), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5245), "Relator" },
                    { new Guid("99a33c0a-5599-4fd0-bf1f-8d37636984a5"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5153), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5155), "Focus" },
                    { new Guid("cb4e6fcc-e14f-4e1b-a459-cf01a5413b2e"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5157), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5159), "Learner" },
                    { new Guid("e410bb04-9f99-499c-9bde-159e08df77dc"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5175), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5176), "Self-Assurance" },
                    { new Guid("f2788720-2652-46e5-9928-a73c4ea3f08b"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5239), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5241), "Connectedness" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "InactivatedBy", "InactivatedDate", "LastName", "ModifiedBy", "ModifiedDate" },
                values: new object[] { new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5493), "domel2222@gmail.com", "Dominik", null, null, "Wikliński", new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5498) });

            migrationBuilder.CreateIndex(
                name: "IX_Journals_UserId",
                table: "Journals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MostWins_JournalId",
                table: "MostWins",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_MostWins_StrenghtId",
                table: "MostWins",
                column: "StrenghtId");

            migrationBuilder.CreateIndex(
                name: "IX_SelfAssessmentValues_JournalId",
                table: "SelfAssessmentValues",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_SelfAssessmentValues_UserId",
                table: "SelfAssessmentValues",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MostWins");

            migrationBuilder.DropTable(
                name: "SelfAssessmentValues");

            migrationBuilder.DropTable(
                name: "Strenghts");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
