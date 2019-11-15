using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface IContactRepository<TEntity>
    {
        IEnumerable<TEntity> Get(int userId);
        TEntity Get(int userId, int id);
        TEntity Insert(TEntity entity);
        bool Update(int UserId, int id, TEntity entity);
        bool Delete(int UserId, int id);
    }
}
