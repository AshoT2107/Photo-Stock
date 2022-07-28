using Entities.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class TextForCreationDto
    {
        [Required(ErrorMessage = "The Name is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Note is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Note is 60 characters.")]
        public string Note { get; set; }

        [Required(ErrorMessage = "The Creation date is a required field")]
        [DataType(DataType.DateTime, ErrorMessage = "The Creation date must be given type")]
        public DateTime DateOfCreation { get; set; }

        [Required(ErrorMessage = "The Cost is a required field")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "The Sales number is a required field")]
        public int NumberOfSales { get; set; }

        [Required(ErrorMessage = "The Rating is a required field")]
        public Degree Rating { get; set; }
    }
}
