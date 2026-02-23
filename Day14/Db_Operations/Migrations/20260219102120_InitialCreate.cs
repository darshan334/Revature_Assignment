using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Db_Operations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dept",
                columns: table => new
                {
                    DEPTNO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dept", x => x.DEPTNO);
                });

            migrationBuilder.CreateTable(
                name: "emp",
                columns: table => new
                {
                    EMPNO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MGR = table.Column<int>(type: "int", nullable: true),
                    HIREDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    COMM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DEPTNO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emp", x => x.EMPNO);
                    table.ForeignKey(
                        name: "FK_emp_dept_DEPTNO",
                        column: x => x.DEPTNO,
                        principalTable: "dept",
                        principalColumn: "DEPTNO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_emp_DEPTNO",
                table: "emp",
                column: "DEPTNO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emp");

            migrationBuilder.DropTable(
                name: "dept");
        }
    }
}
