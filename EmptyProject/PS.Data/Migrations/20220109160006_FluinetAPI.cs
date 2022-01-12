using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class FluinetAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTS_CATEGORIE_CategoryId",
                table: "PRODUCTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CATEGORIE",
                table: "CATEGORIE");

            migrationBuilder.RenameTable(
                name: "CATEGORIE",
                newName: "Mycategory");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "PRODUCTS",
                newName: "adresse_StreetAddress");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "PRODUCTS",
                newName: "MyCity");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Mycategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mycategory",
                table: "Mycategory",
                column: "CategoryId");

            migrationBuilder.CreateTable(
                name: "Providings",
                columns: table => new
                {
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    ProvidersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providings", x => new { x.ProductsProductId, x.ProvidersId });
                    table.ForeignKey(
                        name: "FK_Providings_PRODUCTS_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Providings_PROVIDER_ProvidersId",
                        column: x => x.ProvidersId,
                        principalTable: "PROVIDER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Providings_ProvidersId",
                table: "Providings",
                column: "ProvidersId");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTS_Mycategory_CategoryId",
                table: "PRODUCTS",
                column: "CategoryId",
                principalTable: "Mycategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTS_Mycategory_CategoryId",
                table: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "Providings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mycategory",
                table: "Mycategory");

            migrationBuilder.RenameTable(
                name: "Mycategory",
                newName: "CATEGORIE");

            migrationBuilder.RenameColumn(
                name: "adresse_StreetAddress",
                table: "PRODUCTS",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "MyCity",
                table: "PRODUCTS",
                newName: "City");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CATEGORIE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CATEGORIE",
                table: "CATEGORIE",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTS_CATEGORIE_CategoryId",
                table: "PRODUCTS",
                column: "CategoryId",
                principalTable: "CATEGORIE",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
