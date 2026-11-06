using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_CORE04Assignment.Migrations
{
    /// <inheritdoc />
    public partial class initialBank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    dateOfbirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nationalld = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "managers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Hirdate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_managers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    managerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.code);
                    table.ForeignKey(
                        name: "FK_Branches_managers_managerid",
                        column: x => x.managerid,
                        principalTable: "managers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    accountNumber = table.Column<int>(type: "int", nullable: false),
                    accountType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    openingDate = table.Column<DateTime>(type: "date", nullable: false),
                    branchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.accountNumber);
                    table.ForeignKey(
                        name: "FK_accounts_Branches_branchId",
                        column: x => x.branchId,
                        principalTable: "Branches",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountCustomers",
                columns: table => new
                {
                    accountsId = table.Column<int>(type: "int", nullable: false),
                    customersId = table.Column<int>(type: "int", nullable: false),
                    ownerShipType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AccountStuats = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ownerShipStartDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCustomers", x => new { x.accountsId, x.customersId });
                    table.ForeignKey(
                        name: "FK_AccountCustomers_accounts_accountsId",
                        column: x => x.accountsId,
                        principalTable: "accounts",
                        principalColumn: "accountNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountCustomers_customers_customersId",
                        column: x => x.customersId,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    transactionNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transactionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    transactionType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    accountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.transactionNumber);
                    table.ForeignKey(
                        name: "FK_transactions_accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "accounts",
                        principalColumn: "accountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "managers",
                columns: new[] { "id", "Email", "FullName", "Hirdate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John Doe", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123-456-7890" },
                    { 2, "jane.doe@example.com", "Jane Smith", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "133-336-7890" },
                    { 3, "bob.johnson@example.com", "Bob Johnson", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "144-447-8901" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "code", "address", "managerid", "name", "phoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St, City", 1, "Main Branch", "123-456-7890" },
                    { 2, "456 Elm St, City", 2, "Branch 2", "987-654-3210" },
                    { 3, "789 Oak St, City", 3, "Branch 3", "555-123-4567" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountCustomers_customersId",
                table: "AccountCustomers",
                column: "customersId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_branchId",
                table: "accounts",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_managerid",
                table: "Branches",
                column: "managerid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_transactions_accountId",
                table: "transactions",
                column: "accountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountCustomers");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "managers");
        }
    }
}
