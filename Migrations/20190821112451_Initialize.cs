using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppOperators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    DialingNumber = table.Column<int>(maxLength: 20, nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOperators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOperators_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(maxLength: 10, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Currency = table.Column<string>(maxLength: 10, nullable: false),
                    FullPriceWithTax = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    PhoneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Phones_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneOperators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sim = table.Column<string>(nullable: true),
                    AppOperatorId = table.Column<int>(nullable: false),
                    PhoneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneOperators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneOperators_AppOperators_AppOperatorId",
                        column: x => x.AppOperatorId,
                        principalTable: "AppOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneOperators_Phones_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Croatia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "USA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Germany" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Mraclin" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 2, 2, "New York" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 3, 3, "Berlin" });

            migrationBuilder.InsertData(
                table: "AppOperators",
                columns: new[] { "Id", "DialingNumber", "LocationId", "Name" },
                values: new object[,]
                {
                    { 6, 968630778, 1, "vip" },
                    { 5, 968640778, 2, "A1" },
                    { 4, 968610778, 3, "Telekom" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "LastName", "LocationId" },
                values: new object[,]
                {
                    { 1, new DateTime(1879, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "albein@hotmail.com", "Albert", "Einstein", 1 },
                    { 10, new DateTime(1996, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "tin_stuban@hotmail.com", "Valentin", "Štuban", 2 },
                    { 9, new DateTime(1999, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marko_stuban@hotmail.com", "Marko", "Štuban", 3 }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "ClientId", "RegistrationDate" },
                values: new object[] { 1, 1, new DateTime(2018, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "ClientId", "RegistrationDate" },
                values: new object[] { 3, 10, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "ClientId", "RegistrationDate" },
                values: new object[] { 2, 9, new DateTime(2019, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "Amount", "Currency", "Date", "FullPriceWithTax", "PhoneId", "Tax" },
                values: new object[,]
                {
                    { 1, 1000m, "HRK", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1250m, 1, 25m },
                    { 3, 1000m, "HRK", new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200m, 1, 20m },
                    { 2, 100m, "HRK", new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 125m, 2, 25m }
                });

            migrationBuilder.InsertData(
                table: "PhoneOperators",
                columns: new[] { "Id", "AppOperatorId", "PhoneId", "Sim" },
                values: new object[,]
                {
                    { 1, 6, 1, "nano" },
                    { 3, 4, 3, "regular" },
                    { 2, 5, 2, "micro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppOperators_LocationId",
                table: "AppOperators",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PhoneId",
                table: "Bills",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_LocationId",
                table: "Clients",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CountryId",
                table: "Locations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneOperators_AppOperatorId",
                table: "PhoneOperators",
                column: "AppOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneOperators_PhoneId",
                table: "PhoneOperators",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ClientId",
                table: "Phones",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "PhoneOperators");

            migrationBuilder.DropTable(
                name: "AppOperators");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
