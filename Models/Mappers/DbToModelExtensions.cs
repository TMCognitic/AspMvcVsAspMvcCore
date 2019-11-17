using Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models.Mappers
{
    static class DbToModelExtensions
    {
        internal static Contact ToContact(this IDataRecord dataRecord)
        {
            return new Contact() { Id = (int)dataRecord["Id"], LastName = (string)dataRecord["LastName"], FirstName = (string)dataRecord["FirstName"], Email = (dataRecord["Email"] is DBNull) ? null : (string)dataRecord["Email"], Phone = (dataRecord["Phone"] is DBNull) ? null : (string)dataRecord["Phone"] };
        }
    }
}
