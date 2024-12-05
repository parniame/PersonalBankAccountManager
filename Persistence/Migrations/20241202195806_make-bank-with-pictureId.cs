using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class makebankwithpictureId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 153, DateTimeKind.Local).AddTicks(1521),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(5735));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 153, DateTimeKind.Local).AddTicks(915),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(5101));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 153, DateTimeKind.Local).AddTicks(1324),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(5527));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 152, DateTimeKind.Local).AddTicks(8275),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 152, DateTimeKind.Local).AddTicks(7906),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(2092),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(5978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(1763),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Transaction",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(8816),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 354, DateTimeKind.Local).AddTicks(2962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Transaction",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(8455),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 354, DateTimeKind.Local).AddTicks(2589));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Picture",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(5452),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(9414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Picture",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(5128),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(8922));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(83),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(3688));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 148, DateTimeKind.Local).AddTicks(9678),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(3291));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BankAccount",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 148, DateTimeKind.Local).AddTicks(6200),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 352, DateTimeKind.Local).AddTicks(9621));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccount",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 148, DateTimeKind.Local).AddTicks(5752),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 352, DateTimeKind.Local).AddTicks(9227));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(5735),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 153, DateTimeKind.Local).AddTicks(1521));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(5101),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 153, DateTimeKind.Local).AddTicks(915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                type: "datetime",
                nullable: true,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(5527),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 153, DateTimeKind.Local).AddTicks(1324));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(2187),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 152, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionPlan",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 357, DateTimeKind.Local).AddTicks(1829),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 152, DateTimeKind.Local).AddTicks(7906));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(5978),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(2092));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TransactionCategory",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(5614),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Transaction",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 354, DateTimeKind.Local).AddTicks(2962),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(8816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Transaction",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 354, DateTimeKind.Local).AddTicks(2589),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(8455));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Picture",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(9414),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(5452));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Picture",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(8922),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(5128));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(3688),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 149, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Models.Entities.Bank",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 353, DateTimeKind.Local).AddTicks(3291),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 148, DateTimeKind.Local).AddTicks(9678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BankAccount",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 352, DateTimeKind.Local).AddTicks(9621),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 148, DateTimeKind.Local).AddTicks(6200));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccount",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 23, 45, 55, 352, DateTimeKind.Local).AddTicks(9227),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2024, 12, 2, 23, 28, 6, 148, DateTimeKind.Local).AddTicks(5752));
        }
    }
}
