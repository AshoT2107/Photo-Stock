using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entities.Configuration
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasData
                (
                    new Photo
                    {
                        Id = 1,
                        Name = "Antaliya",
                        Link = @"C:\Users\ashot\source\repos\PhotoStockSolution\PhotoStock.API\Images\Furniture\Furniture1.png",
                        OriginalSize = Size(@"C:\Users\ashot\source\repos\PhotoStockSolution\PhotoStock.API\Images\Furniture\Furniture1.png"),
                        DateOfCreation = DateTime.Today,
                        Cost= 100,
                        NumberOfSales =5,
                        Rating = Models.Enum.Degree.Middle,
                        AuthorId = 2
                    },
                    new Photo
                    {
                        Id = 2,
                        Name = "Monaliza",
                        Link = @"C:\Users\ashot\source\repos\PhotoStockSolution\PhotoStock.API\Images\Furniture\Furniture2.png",
                        OriginalSize = Size(@"C:\Users\ashot\source\repos\PhotoStockSolution\PhotoStock.API\Images\Furniture\Furniture2.png"),
                        DateOfCreation = DateTime.Today.AddDays(-1),
                        Cost = 120,
                        NumberOfSales = 10,
                        Rating = Models.Enum.Degree.High,
                        AuthorId = 3
                    },
                    new Photo
                    {
                        Id = 3,
                        Name = "Madonna",
                        Link = @"C:\Users\ashot\source\repos\PhotoStockSolution\PhotoStock.API\Images\Furniture\Furniture3.png",
                        OriginalSize = Size(@"C:\Users\ashot\source\repos\PhotoStockSolution\PhotoStock.API\Images\Furniture\Furniture3.png"),
                        DateOfCreation = DateTime.Today.AddDays(-2),
                        Cost = 95,
                        NumberOfSales = 3,
                        Rating = Models.Enum.Degree.Low,
                        AuthorId = 1
                    }

                );
        }
        public string Size(string url)
        {
            Bitmap bitmap = new Bitmap(url);

            string originalSize = $"{bitmap.Width} x {bitmap.Height}";
            return originalSize;
        }
    }
}
