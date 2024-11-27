using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class initFive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bid = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    Ask = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    LastTraded = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ReSeed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradingChart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChartCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingChart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradingTargets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Epic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChartCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    Profit = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    RiskPercent = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TargetPercent = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    InitialDeposit = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    Expiry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScalingFactor = table.Column<int>(type: "int", nullable: true),
                    MovingAverageLength = table.Column<int>(type: "int", nullable: true),
                    TradingLevel = table.Column<int>(type: "int", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingTargets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpenPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClosePriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HighPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LowPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MovingAverage = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TradingChartEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Price_ClosePriceId",
                        column: x => x.ClosePriceId,
                        principalTable: "Price",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_Price_HighPriceId",
                        column: x => x.HighPriceId,
                        principalTable: "Price",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_Price_LowPriceId",
                        column: x => x.LowPriceId,
                        principalTable: "Price",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_Price_OpenPriceId",
                        column: x => x.OpenPriceId,
                        principalTable: "Price",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prices_TradingChart_TradingChartEntityId",
                        column: x => x.TradingChartEntityId,
                        principalTable: "TradingChart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepositBand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Margin = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    Max = table.Column<int>(type: "int", nullable: true),
                    Min = table.Column<int>(type: "int", nullable: true),
                    TradingTargetEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositBand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositBand_TradingTargets_TradingTargetEntityId",
                        column: x => x.TradingTargetEntityId,
                        principalTable: "TradingTargets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accepted = table.Column<bool>(type: "bit", nullable: false),
                    ContractSize = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    Deposit = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    RiskAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TargetAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TransactionReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profit = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TradingTargetEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_TradingTargets_TradingTargetEntityId",
                        column: x => x.TradingTargetEntityId,
                        principalTable: "TradingTargets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepositBand_TradingTargetEntityId",
                table: "DepositBand",
                column: "TradingTargetEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TradingTargetEntityId",
                table: "Orders",
                column: "TradingTargetEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ClosePriceId",
                table: "Prices",
                column: "ClosePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_HighPriceId",
                table: "Prices",
                column: "HighPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_LowPriceId",
                table: "Prices",
                column: "LowPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_OpenPriceId",
                table: "Prices",
                column: "OpenPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_TradingChartEntityId",
                table: "Prices",
                column: "TradingChartEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositBand");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "TradingTargets");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "TradingChart");
        }
    }
}
