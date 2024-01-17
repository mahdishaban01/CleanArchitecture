namespace HR_Management.MVC.Contracts
{
    public interface IAuthenticateService
    {
        Task<bool> Authenticate(string email,string password);
        Task<bool> Register(string firstName,string lastName,string username,string password);
        Task Logout(); 
    }
}
