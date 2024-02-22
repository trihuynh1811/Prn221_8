
using DataAccessLayer.DAO;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repository.Auth
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public Task Login(string email, string password)
        {
          throw new Exception("Method not implemented");
        }
    }
}
