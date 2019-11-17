using Models.Data;

namespace AspMvcCore.Infrastructure
{
    public interface ISessionManager
    {
        User User { get; set; }
        void Abandon();
    }
}