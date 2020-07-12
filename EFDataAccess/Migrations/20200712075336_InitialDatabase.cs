using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccess.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankServiceCatalogues",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankServiceCatalogues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceVerifyMethods",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceVerifyMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankServices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    BankServiceCatalogueId = table.Column<long>(nullable: true),
                    ServiceVerifyMethodId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankServices_BankServiceCatalogues_BankServiceCatalogueId",
                        column: x => x.BankServiceCatalogueId,
                        principalTable: "BankServiceCatalogues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankServices_ServiceVerifyMethods_ServiceVerifyMethodId",
                        column: x => x.ServiceVerifyMethodId,
                        principalTable: "ServiceVerifyMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceVerifies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ServiceVerifyMethodId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceVerifies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceVerifies_ServiceVerifyMethods_ServiceVerifyMethodId",
                        column: x => x.ServiceVerifyMethodId,
                        principalTable: "ServiceVerifyMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankServices_BankServiceCatalogueId",
                table: "BankServices",
                column: "BankServiceCatalogueId");

            migrationBuilder.CreateIndex(
                name: "IX_BankServices_ServiceVerifyMethodId",
                table: "BankServices",
                column: "ServiceVerifyMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceVerifies_ServiceVerifyMethodId",
                table: "ServiceVerifies",
                column: "ServiceVerifyMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankServices");

            migrationBuilder.DropTable(
                name: "ServiceVerifies");

            migrationBuilder.DropTable(
                name: "BankServiceCatalogues");

            migrationBuilder.DropTable(
                name: "ServiceVerifyMethods");
        }
    }
}
