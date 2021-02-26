using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAPI.Migrations
{
    public partial class AdminRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Insert into AspNetRoles (Id,[Name],[NormalizedName])
values('1999b735-75d4-427f-9db2-b63fbd57b2db','Admin','Admin')"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"delete AspNetRoles
where id='1999b735-75d4-427f-9db2-b63fbd57b2db'
");
        }
    }
}