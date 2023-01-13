using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class addColumnDateIntoMostWinDuringTheDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "WinDate",
                table: "MostWins",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Strenghts",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "InactivatedBy", "InactivatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("1c1abd48-244e-4308-aa50-5a58156791ee"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9609), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9611), "Connectedness" },
                    { new Guid("1feffb16-65b9-4b79-8439-e7ab4093370d"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9583), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9585), "Individualization" },
                    { new Guid("2c2395a8-1991-4d23-bab4-6747566d59ce"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9601), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9603), "Activator" },
                    { new Guid("4ed23dc9-1d6f-4be2-b80b-ff9993fccba5"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9588), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9589), "Self-Assurance" },
                    { new Guid("63046af5-b5cb-4a47-90b6-0e0077ebae62"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9500), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9533), "Responsibility" },
                    { new Guid("8178eb3c-1370-4d56-92a4-3bafec7f8ff3"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9537), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9538), "Achiever" },
                    { new Guid("878e3ceb-6b7e-4a7a-900d-336296fbe4bb"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9613), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9615), "Relator" },
                    { new Guid("b4dcb7c5-9b77-4ffb-89f8-39f814f5030b"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9541), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9542), "Focus" },
                    { new Guid("e460205b-083e-4b2c-9e66-9bf6adc4680b"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9605), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9607), "Futuristic" },
                    { new Guid("f22b00b8-ca74-46b1-bff3-f3f87c148a5a"), new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9545), null, null, new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9546), "Learner" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31"),
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9882), new DateTime(2023, 1, 13, 14, 29, 18, 315, DateTimeKind.Local).AddTicks(9886) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("1c1abd48-244e-4308-aa50-5a58156791ee"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("1feffb16-65b9-4b79-8439-e7ab4093370d"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("2c2395a8-1991-4d23-bab4-6747566d59ce"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("4ed23dc9-1d6f-4be2-b80b-ff9993fccba5"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("63046af5-b5cb-4a47-90b6-0e0077ebae62"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("8178eb3c-1370-4d56-92a4-3bafec7f8ff3"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("878e3ceb-6b7e-4a7a-900d-336296fbe4bb"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("b4dcb7c5-9b77-4ffb-89f8-39f814f5030b"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("e460205b-083e-4b2c-9e66-9bf6adc4680b"));

            migrationBuilder.DeleteData(
                table: "Strenghts",
                keyColumn: "Id",
                keyValue: new Guid("f22b00b8-ca74-46b1-bff3-f3f87c148a5a"));

            migrationBuilder.DropColumn(
                name: "WinDate",
                table: "MostWins");

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
    }
}
