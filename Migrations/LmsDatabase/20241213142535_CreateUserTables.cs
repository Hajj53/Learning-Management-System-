using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Migrations.LmsDatabase
{
    /// <inheritdoc />
    public partial class CreateUserTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    A_id = table.Column<int>(type: "int", nullable: false),
                    A_password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__admin__71AD61D9A6676F2D", x => x.A_id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    d_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    d_Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departme__D95F582BFCC824F2", x => x.d_id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    S_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    S_Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    phonenumber = table.Column<long>(name: "phone number", type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student__A3DCCCA53FD2BE1B", x => x.S_id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    t_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    t_Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    t_Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    phonenumber = table.Column<long>(name: "phone number", type: "bigint", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teacher__E579775F5A5C513F", x => x.t_id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    c_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Deptment_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__213EE774772D5404", x => x.c_id);
                    table.UniqueConstraint("AK_Courses_C_Name", x => x.C_Name);
                    table.ForeignKey(
                        name: "FK__Courses__Deptmen__5BE2A6F2",
                        column: x => x.Deptment_id,
                        principalTable: "Department",
                        principalColumn: "d_id");
                });

            migrationBuilder.CreateTable(
                name: "course_reg",
                columns: table => new
                {
                    r_id = table.Column<int>(type: "int", nullable: false),
                    r_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    r_dept = table.Column<int>(type: "int", nullable: false),
                    r_teacher = table.Column<int>(type: "int", nullable: true),
                    r_teacher_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    no_of_regs_stds = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__course_re__r_dep__0D7A0286",
                        column: x => x.r_dept,
                        principalTable: "Department",
                        principalColumn: "d_id");
                    table.ForeignKey(
                        name: "FK__course_re__r_nam__0C85DE4D",
                        column: x => x.r_name,
                        principalTable: "Courses",
                        principalColumn: "C_Name");
                    table.ForeignKey(
                        name: "FK__course_re__r_tea__0E6E26BF",
                        column: x => x.r_teacher,
                        principalTable: "Teacher",
                        principalColumn: "t_id");
                    table.ForeignKey(
                        name: "FK__course_reg__r_id__0B91BA14",
                        column: x => x.r_id,
                        principalTable: "Courses",
                        principalColumn: "c_id");
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    E_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_date = table.Column<DateOnly>(type: "date", nullable: false),
                    Course_id = table.Column<int>(type: "int", nullable: true),
                    Course_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    R_number = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    E_time = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Exam__D7E94DACC4839A5B", x => x.E_id);
                    table.ForeignKey(
                        name: "FK__Exam__Course_id__02FC7413",
                        column: x => x.Course_id,
                        principalTable: "Courses",
                        principalColumn: "c_id");
                    table.ForeignKey(
                        name: "FK__Exam__Course_nam__03F0984C",
                        column: x => x.Course_name,
                        principalTable: "Courses",
                        principalColumn: "C_Name");
                });

            migrationBuilder.CreateTable(
                name: "schedule",
                columns: table => new
                {
                    E_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_date = table.Column<DateOnly>(type: "date", nullable: false),
                    Course_id = table.Column<int>(type: "int", nullable: true),
                    Deptment_id = table.Column<int>(type: "int", nullable: true),
                    Teacher_id = table.Column<int>(type: "int", nullable: true),
                    Course_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    R_number = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    E_time = table.Column<TimeOnly>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__schedule__D7E94DAC21FCD7FA", x => x.E_id);
                    table.ForeignKey(
                        name: "FK__schedule__Course__06CD04F7",
                        column: x => x.Course_id,
                        principalTable: "Courses",
                        principalColumn: "c_id");
                    table.ForeignKey(
                        name: "FK__schedule__Course__09A971A2",
                        column: x => x.Course_name,
                        principalTable: "Courses",
                        principalColumn: "C_Name");
                    table.ForeignKey(
                        name: "FK__schedule__Deptme__07C12930",
                        column: x => x.Deptment_id,
                        principalTable: "Department",
                        principalColumn: "d_id");
                    table.ForeignKey(
                        name: "FK__schedule__Teache__08B54D69",
                        column: x => x.Teacher_id,
                        principalTable: "Teacher",
                        principalColumn: "t_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_course_reg_r_dept",
                table: "course_reg",
                column: "r_dept");

            migrationBuilder.CreateIndex(
                name: "IX_course_reg_r_id",
                table: "course_reg",
                column: "r_id");

            migrationBuilder.CreateIndex(
                name: "IX_course_reg_r_name",
                table: "course_reg",
                column: "r_name");

            migrationBuilder.CreateIndex(
                name: "IX_course_reg_r_teacher",
                table: "course_reg",
                column: "r_teacher");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Deptment_id",
                table: "Courses",
                column: "Deptment_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Courses__3006C73626A6B1CE",
                table: "Courses",
                column: "C_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Departme__024E29D685276768",
                table: "Department",
                column: "d_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Course_id",
                table: "Exam",
                column: "Course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_Course_name",
                table: "Exam",
                column: "Course_name");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_Course_id",
                table: "schedule",
                column: "Course_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_Course_name",
                table: "schedule",
                column: "Course_name");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_Deptment_id",
                table: "schedule",
                column: "Deptment_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_Teacher_id",
                table: "schedule",
                column: "Teacher_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Student__A9D105341B69794D",
                table: "Student",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Teacher__A9D10534F7A8D3C7",
                table: "Teacher",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "course_reg");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "schedule");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
