using DataAccessLayer.Models;

namespace DataAccessLayer.Repository.Auth
{
    public interface IAuthenticationRepository
    {
        Task Login(string email, string password);
    }
}