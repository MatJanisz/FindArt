using Microsoft.EntityFrameworkCore.Migrations;

namespace FindArt.DataAccess.Migrations
{
    public partial class AssignAdminRoleToAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2886e9e4-359f-49b2-a89e-b0e493b9d795");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da919e90-4651-4f55-bfc8-400a41bc57b0", "1d437cbe-e344-4447-9d5b-da6e0022f761", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.Sql(@"SET NOCOUNT ON
            DECLARE @TransactionName VarChar(MAX) = 'Add Admin User And Assign Admin Role'

            SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
            BEGIN TRAN @TransactionName


                DECLARE @Email VARCHAR(20) = 'admin@email.com'

                DECLARE @UserID VARCHAR(100)

                DECLARE @RoleName VARCHAR(20) = 'Administrator'

                DECLARE @RoleID VARCHAR(100)


                SELECT @UserID = ID FROM[FindArt].[dbo].[AspNetUsers] WHERE Email = @Email

                SELECT @RoleID = ID FROM[FindArt].[dbo].[AspNetRoles] WHERE Name = @RoleName


                IF @UserID IS NOT NULL AND @RoleID IS NOT NULL AND NOT EXISTS(SELECT 1 FROM[FindArt].[dbo].[AspNetUserRoles] WHERE UserId = @UserID AND RoleId = @RoleID)

                BEGIN

                    INSERT INTO[FindArt].[dbo].[AspNetUserRoles](UserId, RoleId) SELECT @UserID, @RoleID

                END

            COMMIT TRAN @TransactionName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da919e90-4651-4f55-bfc8-400a41bc57b0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2886e9e4-359f-49b2-a89e-b0e493b9d795", "569f4123-cbfc-4dda-8684-d5e210d526cd", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.Sql(@"SET NOCOUNT ON
            DECLARE @TransactionName VarChar(MAX) = 'Add Admin User And Assign Admin Role'

            SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
            BEGIN TRAN @TransactionName


                DECLARE @Email VARCHAR(20) = 'admin@email.com'

                DECLARE @UserID VARCHAR(100)

                DECLARE @RoleName VARCHAR(20) = 'Administrator'

                DECLARE @RoleID VARCHAR(100)


                SELECT @UserID = ID FROM[FindArt].[dbo].[AspNetUsers] WHERE Email = @Email

                SELECT @RoleID = ID FROM[FindArt].[dbo].[AspNetRoles] WHERE Name = @RoleName


                IF @UserID IS NOT NULL AND @RoleID IS NOT NULL AND EXISTS(SELECT 1 FROM[FindArt].[dbo].[AspNetUserRoles] WHERE UserId = @UserID AND RoleId = @RoleID)

                BEGIN

                    DELETE FROM[FindArt].[dbo].[AspNetUserRoles](UserId, RoleId) WHERE UserId = @UserID AND RoleId = @RoleID

                END

            COMMIT TRAN @TransactionName");
        }
    }
}
