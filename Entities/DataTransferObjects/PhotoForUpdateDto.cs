using Entities.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class PhotoForUpdateDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Link is a required field")]
        public string Link { get; set; }

        [Required(ErrorMessage = "Size is a required field")]
        public string OriginalSize { get; set; }

        [Required(ErrorMessage = "Date is a required field")]
        [DataType(DataType.DateTime, ErrorMessage = "Date must be given type")]
        public DateTime DateOfCreation { get; set; }

        [Required(ErrorMessage = "Cost is a required field")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Sales number is a required field")]
        public int NumberOfSales { get; set; }

        [Required(ErrorMessage = "The Rating is a required field")]
        public Degree Rating { get; set; }
    }
}
