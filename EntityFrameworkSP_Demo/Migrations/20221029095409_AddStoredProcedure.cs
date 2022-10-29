using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkSP_Demo.Migrations
{
    public partial class AddStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //GetPrductList
            migrationBuilder.Sql(@"
				CREATE OR ALTER PROCEDURE [dbo].[GetPrductList]
					AS
					BEGIN
						SELECT * FROM dbo.Product
					END
			 ");
            //GetPrductByID
            migrationBuilder.Sql(@"
				CREATE OR ALTER PROCEDURE [dbo].[GetPrductByID]
					@ProductId int
					AS
					BEGIN
						SELECT
							ProductId,
							ProductName,
							ProductDescription,
							ProductPrice,
							ProductStock
						FROM dbo.Product where ProductId = @ProductId
					END
			");
            // AddNewProduct
            migrationBuilder.Sql(@"
				CREATE OR ALTER PROCEDURE [dbo].[AddNewProduct]
					@ProductName [nvarchar](max),
					@ProductDescription [nvarchar](max),
					@ProductPrice int,
					@ProductStock int
					AS
					BEGIN
						INSERT INTO dbo.Product
							(
								ProductName,
								ProductDescription,
								ProductPrice,
								ProductStock
							)
						VALUES
							(
								@ProductName,
								@ProductDescription,
								@ProductPrice,
								@ProductStock
							)
					END
			");
            //UpdateProduct
            migrationBuilder.Sql(@"
				CREATE OR ALTER PROCEDURE [dbo].[UpdateProduct]
					@ProductId int,
					@ProductName [nvarchar](max),
					@ProductDescription [nvarchar](max),
					@ProductPrice int,
					@ProductStock int
					AS
					BEGIN
						UPDATE dbo.Product
						SET
							ProductName = @ProductName,
							ProductDescription = @ProductDescription,
							ProductPrice = @ProductPrice,
							ProductStock = @ProductStock
						WHERE ProductId = @ProductId
					END
			");
            //DeletePrductByID
            migrationBuilder.Sql(@"
				CREATE OR ALTER PROCEDURE [dbo].[DeletePrductByID]
					@ProductId int
					AS
					BEGIN
						DELETE FROM dbo.Product where ProductId = @ProductId
					END
			");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetPrductList]");
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetPrductByID]");
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[AddNewProduct]");
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[UpdateProduct]");
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[DeletePrductByID]");
        }
    }
}
