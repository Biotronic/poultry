using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biotronic.Poultry.Data.Migrations
{
    public partial class Revision_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hatcheries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hatcheries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hybrids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hybrids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veterinarians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Farms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FarmAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Access = table.Column<int>(type: "int", nullable: false),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmAccess_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmAccess_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FarmId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Houses_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Broods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    BroodNumber = table.Column<int>(type: "int", nullable: false),
                    Received = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ended = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VeterinarianId = table.Column<int>(type: "int", nullable: true),
                    HatcheryId = table.Column<int>(type: "int", nullable: true),
                    MaleCount = table.Column<int>(type: "int", nullable: true),
                    FemaleCount = table.Column<int>(type: "int", nullable: true),
                    HybridId = table.Column<int>(type: "int", nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Broods_Hatcheries_HatcheryId",
                        column: x => x.HatcheryId,
                        principalTable: "Hatcheries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Broods_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Broods_Hybrids_HybridId",
                        column: x => x.HybridId,
                        principalTable: "Hybrids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Broods_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Broods_Veterinarians_VeterinarianId",
                        column: x => x.VeterinarianId,
                        principalTable: "Veterinarians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Silos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Silos_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BroodComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BroodId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BroodComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BroodComments_Broods_BroodId",
                        column: x => x.BroodId,
                        principalTable: "Broods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BroodComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BroodDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BroodId = table.Column<int>(type: "int", nullable: true),
                    FecesSampleSent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SelfReportSent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalFeedStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FeedEmpty = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnimalsDelivered = table.Column<int>(type: "int", nullable: true),
                    WeightDeliveredKg = table.Column<double>(type: "float", nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BroodDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BroodDeliveries_Broods_BroodId",
                        column: x => x.BroodId,
                        principalTable: "Broods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BroodDisinfections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BroodId = table.Column<int>(type: "int", nullable: true),
                    Treatment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BroodDisinfections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BroodDisinfections_Broods_BroodId",
                        column: x => x.BroodId,
                        principalTable: "Broods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BroodTreatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BroodId = table.Column<int>(type: "int", nullable: true),
                    Treatment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Illness = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BroodTreatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BroodTreatments_Broods_BroodId",
                        column: x => x.BroodId,
                        principalTable: "Broods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BroodId = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DeadMales = table.Column<int>(type: "int", nullable: true),
                    DeadFemales = table.Column<int>(type: "int", nullable: true),
                    WeightMalesKg = table.Column<double>(type: "float", nullable: true),
                    WeightFemalesKg = table.Column<double>(type: "float", nullable: true),
                    FeedUsageKg = table.Column<double>(type: "float", nullable: true),
                    WaterUsageLiters = table.Column<double>(type: "float", nullable: true),
                    Temperature = table.Column<double>(type: "float", nullable: true),
                    HumidityPct = table.Column<double>(type: "float", nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Days_Broods_BroodId",
                        column: x => x.BroodId,
                        principalTable: "Broods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BroodFeeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BroodId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AmountKg = table.Column<double>(type: "float", nullable: true),
                    CostTotal = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SiloId = table.Column<int>(type: "int", nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BroodFeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BroodFeeds_Broods_BroodId",
                        column: x => x.BroodId,
                        principalTable: "Broods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BroodFeeds_Silos_SiloId",
                        column: x => x.SiloId,
                        principalTable: "Silos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryComments_BroodDeliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "BroodDeliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DbChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DbCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayComments_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BroodComments_BroodId",
                table: "BroodComments",
                column: "BroodId");

            migrationBuilder.CreateIndex(
                name: "IX_BroodComments_UserId",
                table: "BroodComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BroodDeliveries_BroodId",
                table: "BroodDeliveries",
                column: "BroodId");

            migrationBuilder.CreateIndex(
                name: "IX_BroodDisinfections_BroodId",
                table: "BroodDisinfections",
                column: "BroodId");

            migrationBuilder.CreateIndex(
                name: "IX_BroodFeeds_BroodId",
                table: "BroodFeeds",
                column: "BroodId");

            migrationBuilder.CreateIndex(
                name: "IX_BroodFeeds_SiloId",
                table: "BroodFeeds",
                column: "SiloId");

            migrationBuilder.CreateIndex(
                name: "IX_Broods_HatcheryId",
                table: "Broods",
                column: "HatcheryId");

            migrationBuilder.CreateIndex(
                name: "IX_Broods_HouseId",
                table: "Broods",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Broods_HybridId",
                table: "Broods",
                column: "HybridId");

            migrationBuilder.CreateIndex(
                name: "IX_Broods_OwnerId",
                table: "Broods",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Broods_VeterinarianId",
                table: "Broods",
                column: "VeterinarianId");

            migrationBuilder.CreateIndex(
                name: "IX_BroodTreatments_BroodId",
                table: "BroodTreatments",
                column: "BroodId");

            migrationBuilder.CreateIndex(
                name: "IX_DayComments_DayId",
                table: "DayComments",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_DayComments_UserId",
                table: "DayComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_BroodId",
                table: "Days",
                column: "BroodId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryComments_DeliveryId",
                table: "DeliveryComments",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryComments_UserId",
                table: "DeliveryComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmAccess_FarmId",
                table: "FarmAccess",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmAccess_UserId",
                table: "FarmAccess",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_UserId",
                table: "Farms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_FarmId",
                table: "Houses",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_OwnerId",
                table: "Houses",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Silos_HouseId",
                table: "Silos",
                column: "HouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BroodComments");

            migrationBuilder.DropTable(
                name: "BroodDisinfections");

            migrationBuilder.DropTable(
                name: "BroodFeeds");

            migrationBuilder.DropTable(
                name: "BroodTreatments");

            migrationBuilder.DropTable(
                name: "DayComments");

            migrationBuilder.DropTable(
                name: "DeliveryComments");

            migrationBuilder.DropTable(
                name: "FarmAccess");

            migrationBuilder.DropTable(
                name: "Silos");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "BroodDeliveries");

            migrationBuilder.DropTable(
                name: "Broods");

            migrationBuilder.DropTable(
                name: "Hatcheries");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Hybrids");

            migrationBuilder.DropTable(
                name: "Veterinarians");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
