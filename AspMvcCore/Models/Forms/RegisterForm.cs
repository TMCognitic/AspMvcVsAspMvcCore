using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcCore.Models.Forms
{
    public class RegisterForm
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-=]).{8,20}$")]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }
        [Compare(nameof(Passwd))]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }
    }
}
