using Microsoft.EntityFrameworkCore.Migrations;

namespace OdeToFood.Data.Migrations
{
    public partial class TestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT[dbo].[Restaurants] ON
                INSERT INTO[dbo].[Restaurants]([Id], [Name], [Location], [Cuisine]) VALUES(1, N'Taco Joe', N'Brunswick', 1)
                INSERT INTO[dbo].[Restaurants] ([Id], [Name], [Location], [Cuisine]) VALUES(2, N'Taj Mahal', N'Cleveland Hts', 3)
                INSERT INTO[dbo].[Restaurants] ([Id], [Name], [Location], [Cuisine]) VALUES(3, N'Roma Love', N'Mayfied Hts', 2)
                SET IDENTITY_INSERT[dbo].[Restaurants] OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM [dbo].[Restaurants] WHERE [Id] IN (1,2,3)");
        }
    }
}
