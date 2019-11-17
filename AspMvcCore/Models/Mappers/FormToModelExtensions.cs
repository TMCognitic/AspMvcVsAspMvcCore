using AspMvcCore.Models.Forms;
using Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcCore.Models.Mappers
{
    public static class FormToModelExtensions
    {
        public static Contact ToContact(this AddContactForm entity)
        {
            return new Contact() { LastName = entity.LastName, FirstName = entity.FirstName, Email = entity.Email, Phone = entity.Phone };
        }

        public static Contact ToContact(this UpdateContactForm entity)
        {
            return new Contact() { Id = entity.Id, LastName = entity.LastName, FirstName = entity.FirstName, Email = entity.Email, Phone = entity.Phone };
        }
    }
}
