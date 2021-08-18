using Microsoft.EntityFrameworkCore.Migrations;

namespace StreetWorkoutApp.Data.Migrations
{
    public partial class addRolesSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7942e80f-1f4d-4da4-8fb0-66616a9d7966",
                column: "ConcurrencyStamp",
                value: "41d71539-cb66-43f6-a1a7-e7a6c8588119");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3b35b36-e0ad-479b-9855-35a6a785173c",
                column: "ConcurrencyStamp",
                value: "cf98932f-798d-46d6-8d86-72b66460949d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7ff7003-9468-49f5-979a-8138bcf8d480",
                column: "ConcurrencyStamp",
                value: "7200be1e-b63d-4fc0-ab40-9edf913c5e47");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f7ff7003-9468-49f5-979a-8138bcf8d480", "b2b201e9-8c95-4d19-89c3-28184f48b1d5" },
                    { "7942e80f-1f4d-4da4-8fb0-66616a9d7966", "b2b201e9-8c95-4d19-89c3-28184f48b1d5" },
                    { "f3b35b36-e0ad-479b-9855-35a6a785173c", "b2b201e9-8c95-4d19-89c3-28184f48b1d5" },
                    { "7942e80f-1f4d-4da4-8fb0-66616a9d7966", "5a1b8332-873e-4c5f-af06-2ccdf04616dc" },
                    { "f3b35b36-e0ad-479b-9855-35a6a785173c", "5a1b8332-873e-4c5f-af06-2ccdf04616dc" },
                    { "f3b35b36-e0ad-479b-9855-35a6a785173c", "f8406549-4a2e-4401-9fb8-d06992ef6afd" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a1b8332-873e-4c5f-af06-2ccdf04616dc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26372303-e8d7-47e1-951d-e6dc72a17177", "AQAAAAEAACcQAAAAEMDXvCkV2UwIk5YSWGrrzz+cFK4LnXWZiSR4QpPdliQxhluoKgBXDpYyAcvB92LTBg==", "61a488fb-42ff-4076-bba7-c0f89a252985" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2b201e9-8c95-4d19-89c3-28184f48b1d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fce071a4-802c-4eab-bbe0-51e6e0d80f38", "AQAAAAEAACcQAAAAEBXhhxBMFb7Cj4eZoP5xAuZaoBKgZM43Q0Kru/MhsXzVc/YFylJGu7vx8IcMpUarEQ==", "1fabafbf-97ad-4e6e-ab3a-8ecda9d75ad8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8406549-4a2e-4401-9fb8-d06992ef6afd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5fb3f86-56eb-435d-a1c8-8f71210ef533", "AQAAAAEAACcQAAAAEDVgPr+dChejdAe/rRClWZpji6wYNzwKYQJSRVPLVklJg2oL/vquA4iwicYmsXytCw==", "5a1ef75e-be5a-483d-bb3a-e755dfbc11a3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7942e80f-1f4d-4da4-8fb0-66616a9d7966", "5a1b8332-873e-4c5f-af06-2ccdf04616dc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f3b35b36-e0ad-479b-9855-35a6a785173c", "5a1b8332-873e-4c5f-af06-2ccdf04616dc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7942e80f-1f4d-4da4-8fb0-66616a9d7966", "b2b201e9-8c95-4d19-89c3-28184f48b1d5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f3b35b36-e0ad-479b-9855-35a6a785173c", "b2b201e9-8c95-4d19-89c3-28184f48b1d5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f7ff7003-9468-49f5-979a-8138bcf8d480", "b2b201e9-8c95-4d19-89c3-28184f48b1d5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f3b35b36-e0ad-479b-9855-35a6a785173c", "f8406549-4a2e-4401-9fb8-d06992ef6afd" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7942e80f-1f4d-4da4-8fb0-66616a9d7966",
                column: "ConcurrencyStamp",
                value: "deac80e4-ddac-4abb-a028-72df8be16af4");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a1b8332-873e-4c5f-af06-2ccdf04616dc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7611d7a-3cba-45c5-be81-c0680a1c0ee6", "AQAAAAEAACcQAAAAEITMYBRO2JX+vyloXhDptOOpbK4VAVAvw8aBmQVcSRf5WDyZh60Q9rUK2SBgAccLrQ==", "21908bf4-6ce5-4f10-9bb6-2b394a649c9e" });

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
        }
    }
}
