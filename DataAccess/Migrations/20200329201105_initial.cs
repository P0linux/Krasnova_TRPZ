using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryPlaceModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DistanceToShop = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPlaceModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Speed = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MaxWeight = table.Column<int>(nullable: false),
                    MaxSize = table.Column<int>(nullable: false),
                    JamImpact = table.Column<bool>(nullable: false),
                    TimeReturnToShop = table.Column<TimeSpan>(nullable: false),
                    IsBusy = table.Column<bool>(nullable: false),
                    ProductModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportModels_ProductModels_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "ProductModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryOrderModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    DeliveryPlaceId = table.Column<int>(nullable: true),
                    OrderTime = table.Column<DateTime>(nullable: false),
                    TimeToReady = table.Column<TimeSpan>(nullable: false),
                    TransportReturnTime = table.Column<TimeSpan>(nullable: false),
                    TransportId = table.Column<int>(nullable: true),
                    IsDelivering = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrderModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOrderModels_DeliveryPlaceModels_DeliveryPlaceId",
                        column: x => x.DeliveryPlaceId,
                        principalTable: "DeliveryPlaceModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryOrderModels_ProductModels_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryOrderModels_TransportModels_TransportId",
                        column: x => x.TransportId,
                        principalTable: "TransportModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriorityModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductModelId = table.Column<int>(nullable: false),
                    TransportModelId = table.Column<int>(nullable: false),
                    PriorityNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriorityModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriorityModels_ProductModels_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "ProductModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriorityModels_TransportModels_TransportModelId",
                        column: x => x.TransportModelId,
                        principalTable: "TransportModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaitingOrderModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    DeliveryPlaceId = table.Column<int>(nullable: true),
                    OrderTime = table.Column<DateTime>(nullable: false),
                    TimeToReady = table.Column<TimeSpan>(nullable: false),
                    TransportReturnTime = table.Column<TimeSpan>(nullable: false),
                    TransportId = table.Column<int>(nullable: true),
                    IsDelivering = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitingOrderModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaitingOrderModel_DeliveryPlaceModels_DeliveryPlaceId",
                        column: x => x.DeliveryPlaceId,
                        principalTable: "DeliveryPlaceModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WaitingOrderModel_ProductModels_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WaitingOrderModel_TransportModels_TransportId",
                        column: x => x.TransportId,
                        principalTable: "TransportModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderModels_DeliveryPlaceId",
                table: "DeliveryOrderModels",
                column: "DeliveryPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderModels_ProductId",
                table: "DeliveryOrderModels",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderModels_TransportId",
                table: "DeliveryOrderModels",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_PriorityModels_ProductModelId",
                table: "PriorityModels",
                column: "ProductModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PriorityModels_TransportModelId",
                table: "PriorityModels",
                column: "TransportModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportModels_ProductModelId",
                table: "TransportModels",
                column: "ProductModelId");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingOrderModel_DeliveryPlaceId",
                table: "WaitingOrderModel",
                column: "DeliveryPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingOrderModel_ProductId",
                table: "WaitingOrderModel",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingOrderModel_TransportId",
                table: "WaitingOrderModel",
                column: "TransportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryOrderModels");

            migrationBuilder.DropTable(
                name: "PriorityModels");

            migrationBuilder.DropTable(
                name: "WaitingOrderModel");

            migrationBuilder.DropTable(
                name: "DeliveryPlaceModels");

            migrationBuilder.DropTable(
                name: "TransportModels");

            migrationBuilder.DropTable(
                name: "ProductModels");
        }
    }
}
