using Microsoft.EntityFrameworkCore.Migrations;

namespace BitirmeProjesi.Data.Migrations
{
    public partial class updateInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Circle_Invoice_InvoiceId",
                table: "Circle");

            migrationBuilder.DropIndex(
                name: "IX_Circle_InvoiceId",
                table: "Circle");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Circle");

            migrationBuilder.AddColumn<int>(
                name: "CircleId",
                table: "Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CircleId",
                table: "Invoice",
                column: "CircleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Circle_CircleId",
                table: "Invoice",
                column: "CircleId",
                principalTable: "Circle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Circle_CircleId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_CircleId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CircleId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Invoice");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Circle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Circle_InvoiceId",
                table: "Circle",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Circle_Invoice_InvoiceId",
                table: "Circle",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
