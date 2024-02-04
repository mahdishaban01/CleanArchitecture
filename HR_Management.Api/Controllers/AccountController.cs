using HR_Management.Application.Contracts.Identity;
using HR_Management.Application.Models.Identity;

namespace HR_Management.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        return Ok(await authService.Login(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterationResponse>> Register(RegisterationRequest request)
    {
        return Ok(await authService.Register(request));
    }
}
