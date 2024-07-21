using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFood.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscountToFood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.AddColumn<long>(
                name: "Discount",
                table: "Food",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Food");
        }
    }
}
