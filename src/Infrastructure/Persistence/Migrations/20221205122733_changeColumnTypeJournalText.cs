using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class changeColumnTypeJournalText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("0e69de60-bd83-4c77-a4e1-b53c17cbe62a"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("37ad5fb7-0b86-46ec-9608-9cbf5e70d4aa"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("54cf59e2-6992-4f65-875d-f47ffa02274a"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("56ea1ef4-046d-4fd4-bfe5-93f725f2a852"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("64605f9e-e649-44bc-8250-3061045572c3"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("96f241b5-ccc9-4935-b263-69395ea0a167"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("99a33c0a-5599-4fd0-bf1f-8d37636984a5"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("cb4e6fcc-e14f-4e1b-a459-cf01a5413b2e"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("e410bb04-9f99-499c-9bde-159e08df77dc"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("f2788720-2652-46e5-9928-a73c4ea3f08b"));

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Journals",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Strenghts",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "InactivatedBy", "InactivatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("103a482e-6e62-49e1-b2c9-c251e3955ed2"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8631), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8633), "Futuristic" },
                    { new Guid("2a308e97-5314-4104-a0c6-77c6d56121f1"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8635), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8636), "Connectedness" },
                    { new Guid("3a19987b-2eda-4645-91b5-b285b9113972"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8613), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8614), "Individualization" },
                    { new Guid("6c9eb440-49de-4db5-9b4e-fa21f261d20e"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8639), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8640), "Relator" },
                    { new Guid("7c172324-0b15-4db8-b77f-c9ff75b72218"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8627), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8629), "Activator" },
                    { new Guid("ac23b6c8-8368-4f14-a11b-f0bc24caf864"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8565), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8597), "Responsibility" },
                    { new Guid("cf52fcfb-df40-44da-869f-bcac271194d5"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8601), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8603), "Achiever" },
                    { new Guid("d33453c3-c880-4c5d-a4e9-bc3c6cc2c9a5"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8605), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8607), "Focus" },
                    { new Guid("d571a099-78a6-4a3a-9128-c24d1df7745a"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8617), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8618), "Self-Assurance" },
                    { new Guid("e4013a75-6d0c-40aa-bb38-b6fb69c95d20"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8609), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8611), "Learner" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8869), new DateTime(2022, 12, 5, 13, 27, 33, 24, DateTimeKind.Local).AddTicks(8873) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("103a482e-6e62-49e1-b2c9-c251e3955ed2"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("2a308e97-5314-4104-a0c6-77c6d56121f1"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("3a19987b-2eda-4645-91b5-b285b9113972"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("6c9eb440-49de-4db5-9b4e-fa21f261d20e"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("7c172324-0b15-4db8-b77f-c9ff75b72218"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("ac23b6c8-8368-4f14-a11b-f0bc24caf864"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("cf52fcfb-df40-44da-869f-bcac271194d5"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("d33453c3-c880-4c5d-a4e9-bc3c6cc2c9a5"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("d571a099-78a6-4a3a-9128-c24d1df7745a"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("e4013a75-6d0c-40aa-bb38-b6fb69c95d20"));

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Journals",
                type: "nvarchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5493), new DateTime(2022, 11, 29, 11, 20, 15, 954, DateTimeKind.Local).AddTicks(5498) });
        }
    }
}
