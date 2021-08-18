using Microsoft.EntityFrameworkCore.Migrations;

namespace StreetWorkoutApp.Data.Migrations
{
    public partial class addTrainerSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3b35b36-e0ad-479b-9855-35a6a785173c",
                column: "ConcurrencyStamp",
                value: "504da085-c560-4cfe-93ad-ed38af0769a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7ff7003-9468-49f5-979a-8138bcf8d480",
                column: "ConcurrencyStamp",
                value: "5143d913-5dd7-4ad5-8a32-f21f7ea2c516");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7942e80f-1f4d-4da4-8fb0-66616a9d7966", "deac80e4-ddac-4abb-a028-72df8be16af4", "Trainer", "TRAINER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2b201e9-8c95-4d19-89c3-28184f48b1d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f4a8614-98c8-4f6f-a949-a32a650d9681", "AQAAAAEAACcQAAAAEFzkfsgwCpHq/SQCU+N0aHFcohxNNSQj7uSKjcNshFMVQnPR3SU7PbFu+cdvVCHnMg==", "62ac7351-61d5-4477-9927-72c505b1dceb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8406549-4a2e-4401-9fb8-d06992ef6afd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c4297eb-ef2e-49d8-9749-927ca12bae37", "AQAAAAEAACcQAAAAEKstjlKOYUDqRgCTRa3Pdth42tS1nn7U50qGJy5ObVUCCBjpiTuFe2irdggfpBEInA==", "1a8f00cd-a278-4f0d-94f5-09f791813dfd" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5a1b8332-873e-4c5f-af06-2ccdf04616dc", 0, "d7611d7a-3cba-45c5-be81-c0680a1c0ee6", "trainer@trainer.com", false, false, null, "TRAINER@TRAINER.COM", "TRAINER", "AQAAAAEAACcQAAAAEITMYBRO2JX+vyloXhDptOOpbK4VAVAvw8aBmQVcSRf5WDyZh60Q9rUK2SBgAccLrQ==", null, false, "21908bf4-6ce5-4f10-9bb6-2b394a649c9e", false, "trainer" });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "UserId", "UserName" },
                values: new object[] { 2, "5a1b8332-873e-4c5f-af06-2ccdf04616dc", "trainer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7942e80f-1f4d-4da4-8fb0-66616a9d7966");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a1b8332-873e-4c5f-af06-2ccdf04616dc");

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3b35b36-e0ad-479b-9855-35a6a785173c",
                column: "ConcurrencyStamp",
                value: "40a4d759-a0fd-4742-ac08-91c24d18a77c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7ff7003-9468-49f5-979a-8138bcf8d480",
                column: "ConcurrencyStamp",
                value: "aa0c05f0-ebf6-4ba8-b5f0-e05b798e1e6a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2b201e9-8c95-4d19-89c3-28184f48b1d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52a1d00c-4f03-4749-b437-41c98047908e", "AQAAAAEAACcQAAAAEEuWZTciHQ1QuJtE5LM7R+vLtetWSuowW8b3VpZ0MdYq53ighqcuyompPWbrU9fdAQ==", "9254b2c1-ebff-4cab-af09-30047df56720" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8406549-4a2e-4401-9fb8-d06992ef6afd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9c0ed80-3817-4cc2-a005-d09e3790ec39", "AQAAAAEAACcQAAAAEJpubPuauAQj7Y5Y2ln4qMJHNXJGDumtCrMahiP8/i1meqBH4v8Sn5pG7tE6Ccb2Ig==", "425298d9-2de6-4af1-afe2-6092cfb6681c" });
        }
    }
}
