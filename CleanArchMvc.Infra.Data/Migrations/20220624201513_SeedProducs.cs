using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProducs : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
            "VALUES('Nike SB Medium Grey', 'Color grey, size medium, brand Nike', 300.00, 3, 'hoodieN.jpg', 1)");
            
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
            "VALUES('Puma Medium Black', 'Color black, size medium, brand Puma', 280.00, 2, 'hoodieP.jpg', 1)");
            
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
            "VALUES('Nike SB Janoski 10US', 'Color multicolor, size 10US 42BR, brand Nike', 420.00, 5, 'sneakerN.jpg', 3)");
            
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
            "VALUES('Adidas Superstar 9.5US', 'Color white, size 9.5US 41BR, brand Adidas', 450.00, 2, 'sneakerA.jpg', 3)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
