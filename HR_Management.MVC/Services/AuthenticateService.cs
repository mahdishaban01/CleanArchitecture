using HR_Management.MVC.Contracts;

namespace HR_Management.MVC.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        public Task<bool> Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(string firstName, string lastName, string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
