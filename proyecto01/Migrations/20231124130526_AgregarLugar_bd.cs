using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto01.Migrations
{
    /// <inheritdoc />
    public partial class AgregarLugar_bd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.CreateTable(
                name: "Lugar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ubigeo_id = table.Column<int>(type: "int", nullable: false),
                    categoria_lugar_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lugar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lugar_Categoria_lugar_categoria_lugar_id",
                        column: x => x.categoria_lugar_id,
                        principalTable: "Categoria_lugar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lugar_Ubigeo_ubigeo_id",
                        column: x => x.ubigeo_id,
                        principalTable: "Ubigeo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lugar_categoria_lugar_id",
                table: "Lugar",
                column: "categoria_lugar_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lugar_ubigeo_id",
                table: "Lugar",
                column: "ubigeo_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lugar");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    abreviatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre_categoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoria_id = table.Column<int>(type: "int", nullable: false),
                    descripcion_producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre_producto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_categoria_id",
                        column: x => x.categoria_id,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_categoria_id",
                table: "Producto",
                column: "categoria_id");
        }
    }
}
