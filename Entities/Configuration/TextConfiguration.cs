using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class TextConfiguration : IEntityTypeConfiguration<Text>
    {
        public void Configure(EntityTypeBuilder<Text> builder)
        {
            builder.HasData
                (
                    new Text
                    {
                        Id = 1,
                        Name = "MY5 Chanel",
                        Note = "This is a great chanel",
                        DateOfCreation = DateTime.Today,
                        Cost = 50,
                        NumberOfSales = 3,
                        Rating = Models.Enum.Degree.Middle,
                        AuthorId = 2
                    },
                    new Text
                    {
                        Id = 2,
                        Name = "FCB",
                        Note = "professional football club",
                        DateOfCreation = DateTime.Today.AddDays(-1),
                        Cost = 200,
                        NumberOfSales = 18,
                        Rating = Models.Enum.Degree.Top,
                        AuthorId = 3
                    }
                );
        }
    }
}
