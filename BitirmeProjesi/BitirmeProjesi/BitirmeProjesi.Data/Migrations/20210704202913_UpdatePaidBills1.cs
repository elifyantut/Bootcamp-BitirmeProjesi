using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitirmeProjesi.Data.Migrations
{
    public partial class UpdatePaidBills1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Dues",
                table: "PaidBills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ElectricityBill",
                table: "PaidBills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GasBill",
                table: "PaidBills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "PaidBills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidDate",
                table: "PaidBills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "WaterBill",
                table: "PaidBills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dues",
                table: "PaidBills");

            migrationBuilder.DropColumn(
                name: "ElectricityBill",
                table: "PaidBills");

            migrationBuilder.DropColumn(
                name: "GasBill",
                table: "PaidBills");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "PaidBills");

            migrationBuilder.DropColumn(
                name: "PaidDate",
                table: "PaidBills");

            migrationBuilder.DropColumn(
                name: "WaterBill",
                table: "PaidBills");
        }
    }
}
