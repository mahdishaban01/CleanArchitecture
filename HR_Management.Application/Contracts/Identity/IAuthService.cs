using HR_Management.Application.Models.Identity;

namespace HR_Management.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegisteraitonResponse> Register(RegisterationRequest request);
    }
}
