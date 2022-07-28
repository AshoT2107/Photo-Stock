using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class AuthorDto
    {
        [Column("AuthorId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the FirstName is 60 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "NickName is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "Birthday is a required field.")]
        [DataType(DataType.DateTime, ErrorMessage = "Birthday must be given type")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Registration date is a required field.")]
        [DataType(DataType.DateTime, ErrorMessage = "Birthday must be given type")]
        public DateTime DateOfRegistration { get; set; }
    }
}
