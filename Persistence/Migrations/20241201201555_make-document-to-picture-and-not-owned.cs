using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class makedocumenttopictureandnotowned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(5735),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 728, DateTimeKind.Local).AddTicks(190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(5101),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 727, DateTimeKind.Local).AddTicks(9535));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(5527),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 728, DateTimeKind.Local).AddTicks(7));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(2187),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(1829),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(5978),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(5614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Transaction",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 354, DateTimeKind.Local).AddTicks(2962),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Transaction",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 354, DateTimeKind.Local).AddTicks(2589),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(3688),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 725, DateTimeKind.Local).AddTicks(8049));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(3291),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 725, DateTimeKind.Local).AddTicks(7610));

            migrationBuilder.AddColumn<Guid>(
                name: "PictureId",
                table: "Models.Entities.Bank",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BankAccount",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 352, DateTimeKind.Local).AddTicks(9621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccount",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 352, DateTimeKind.Local).AddTicks(9227),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileAddress = table.Column<string>(name: "File Address", type: "VarChar(256)", maxLength: 256, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(8922)),
                    DateUpdated = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(9414))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PictureTransaction",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureTransaction", x => new { x.PictureId, x.TransactionId });
                    table.ForeignKey(
                        name: "FK_PictureTransaction_Picture_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Picture",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PictureTransaction_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models.Entities.Bank_PictureId",
                table: "Models.Entities.Bank",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureTransaction_TransactionId",
                table: "PictureTransaction",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models.Entities.Bank_Picture_PictureId",
                table: "Models.Entities.Bank",
                column: "PictureId",
                principalTable: "Picture",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models.Entities.Bank_Picture_PictureId",
                table: "Models.Entities.Bank");

            migrationBuilder.DropTable(
                name: "PictureTransaction");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Models.Entities.Bank_PictureId",
                table: "Models.Entities.Bank");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Models.Entities.Bank");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 728, DateTimeKind.Local).AddTicks(190),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(5735));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 727, DateTimeKind.Local).AddTicks(9535),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(5101));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 728, DateTimeKind.Local).AddTicks(7),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(5527));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionPlan",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionPlan",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionCategory",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(5978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionCategory",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Transaction",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 354, DateTimeKind.Local).AddTicks(2962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Transaction",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 354, DateTimeKind.Local).AddTicks(2589));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 725, DateTimeKind.Local).AddTicks(8049),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(3688));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 25, 23, 30, 39, 725, DateTimeKind.Local).AddTicks(7610),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(3291));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BankAccount",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 352, DateTimeKind.Local).AddTicks(9621));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccount",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 352, DateTimeKind.Local).AddTicks(9227));

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileAddress = table.Column<string>(name: "File Address", type: "VarChar(256)", maxLength: 256, nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_TransactionId",
                table: "Document",
                column: "TransactionId");
        }
    }
}
