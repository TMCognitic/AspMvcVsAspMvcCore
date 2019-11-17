using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcCore.Models.Forms
{
    public class UpdateContactForm
    {
        [HiddenInput]
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [EmailAddress]
        [MaxLength(384)]
        public string Email { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
    }
}
