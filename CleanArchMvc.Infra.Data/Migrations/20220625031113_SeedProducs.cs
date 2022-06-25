using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProducs : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name,Description,Price,Size,Color,Stock,Image,CategoryId) " +
            "VALUES('Nike SB Grey', 'Limited edition.', 300.00, 'Large', 'Grey', 3, 'hoodieN.jpg', 1)");

            mb.Sql("INSERT INTO Products(Name,Description,Price,Size,Color,Stock,Image,CategoryId) " +
            "VALUES('Hoodie Puma Black', 'Confortable and relliable', 280.00, 'Medium', 'Black', 2, 'hoodieP.jpg', 1)");

            mb.Sql("INSERT INTO Products(Name,Description,Price,Size,Color,Stock,Image,CategoryId) " +
            "VALUES('Nike SB Janoski 10US', 'Nice to skateboarding', 420.00, '10US 42BR', 'Multicolor', 5, 'sneakerN.jpg', 3)");

            mb.Sql("INSERT INTO Products(Name,Description,Price,Size,Color,Stock,Image,CategoryId) " +
            "VALUES('Adidas Superstar 9.5US', 'A classic model from Adidas', 450.00, '9.5US 41BR', 'White', 2, 'sneakerA.jpg', 3)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
