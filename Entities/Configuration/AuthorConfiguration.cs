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
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData
                (
                    new Author
                    {
                        Id = 1,
                        FirstName = "Sanjar",
                        LastName = "Tursunov",
                        NickName = "Sancho",
                        DateOfBirth = DateTime.Today.AddYears(-26),
                        DateOfRegistration = DateTime.Today.AddDays(-2)
                    },
                    new Author
                    {
                        Id = 2,
                        FirstName = "Shokhzod",
                        LastName = "Azamatov",
                        NickName = "AshoT",
                        DateOfBirth = DateTime.Today.AddYears(-23),
                        DateOfRegistration = DateTime.Today
                    },
                    new Author
                    {
                        Id = 3,
                        FirstName = "Aziz",
                        LastName = "Kholkazakov",
                        NickName = "ICloud",
                        DateOfBirth = DateTime.Today.AddYears(-22),
                        DateOfRegistration = DateTime.Today.AddDays(-1)
                    }
                ); ;
        }
    }
}
