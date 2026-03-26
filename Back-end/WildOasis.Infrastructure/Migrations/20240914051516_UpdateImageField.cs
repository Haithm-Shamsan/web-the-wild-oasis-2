using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WildOasis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cabins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    maxCapacity = table.Column<byte>(type: "tinyint", nullable: false),
                    regularPrice = table.Column<double>(type: "float", nullable: false),
                    discount = table.Column<short>(type: "smallint", nullable: false),
                    description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    image = table.Column<string>(type: "VARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cabins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    nationalID = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    nationality = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    countryFlag = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    minBookingLength = table.Column<short>(type: "smallint", nullable: false),
                    maxBookingLength = table.Column<short>(type: "smallint", nullable: false),
                    maxGuestsPerBooking = table.Column<short>(type: "smallint", nullable: false),
                    breakfastPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    numNights = table.Column<short>(type: "smallint", nullable: false),
                    numGuests = table.Column<short>(type: "smallint", nullable: false),
                    cabinPrice = table.Column<double>(type: "float", nullable: false),
                    extrasPrice = table.Column<double>(type: "float", nullable: false),
                    totalPrice = table.Column<double>(type: "float", nullable: false),
                    status = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: false),
                    hasBreakfast = table.Column<bool>(type: "bit", nullable: false),
                    isPaid = table.Column<bool>(type: "bit", nullable: false),
                    observations = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    cabinId = table.Column<int>(type: "int", nullable: false),
                    personId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_People_personId",
                        column: x => x.personId,
                        principalTable: "People",
                        principalColumn: "PersonId");
                    table.ForeignKey(
                        name: "FK_Bookings_cabins_cabinId",
                        column: x => x.cabinId,
                        principalTable: "cabins",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_cabinId",
                table: "Bookings",
                column: "cabinId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_personId",
                table: "Bookings",
                column: "personId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "cabins");
        }
    }
}
