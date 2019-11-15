using System;

namespace Repositories
{
    public interface IAuthRepository<T>
    {
        void Register(T entity);
        T Login(T entity);
    }
}
