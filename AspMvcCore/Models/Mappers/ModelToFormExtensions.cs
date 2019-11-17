using AspMvcCore.Models.Forms;
using Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcCore.Models.Mappers
{
    public static class ModelToFormExtensions
    {
        public static DetailContactForm ToDetail(this Contact entity)
        {
            return new DetailContactForm()
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                Phone = entity.Phone
            };
        }

        public static UpdateContactForm ToUpdate(this Contact entity)
        {
            return new UpdateContactForm()
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                Phone = entity.Phone
            };
        }
    }
}
