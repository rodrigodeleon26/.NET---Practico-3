using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixVehiculoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES ('Chevrolet', 'Aveo', 'ABC123', 1)");
            migrationBuilder.Sql("INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES ('Toyota', 'Corolla', 'DEF456', 2)");
            migrationBuilder.Sql("INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES ('Ford', 'Fiesta', 'GHI789', 3)");
            migrationBuilder.Sql("INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES ('Nissan', 'Sentra', 'JKL012', 4)");
            migrationBuilder.Sql("INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES ('Hyundai', 'Accent', 'MNO345', 5)");
            migrationBuilder.Sql("INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES ('Kia', 'Rio', 'PQR678', 6)");
            migrationBuilder.Sql("INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES ('Mazda', 'CX-30', 'STU901', 5)");
            migrationBuilder.Sql("INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES ('Chevrolet', 'Spark', 'VWX234', 1)");
            migrationBuilder.Sql("INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES ('Toyota', 'Yaris', 'YZA567', 2)");
            migrationBuilder.Sql("INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES ('Ford', 'Focus', 'BCD890', 3)");
            migrationBuilder.Sql("INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES ('Nissan', 'Versa', 'EFG123', 4)");
            migrationBuilder.Sql("INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES ('Hyundai', 'Elantra', 'HIJ456', 5)");
            migrationBuilder.Sql("INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES ('Kia', 'Soul', 'KLM789', 6)");
            migrationBuilder.Sql("INSERT INTO Vehiculos (Marca, Modelo, Matricula, PersonaId) VALUES ('Mazda', 'CX-80', 'NOP012', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
