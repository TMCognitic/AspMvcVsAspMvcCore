using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Data
{
    public class Contact
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
    }
}
