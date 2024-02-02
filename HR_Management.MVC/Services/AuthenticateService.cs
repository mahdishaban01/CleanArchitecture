using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HR_Management.MVC.Services
{
    public class AuthenticateService(IClient client, ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor) : BaseHttpService(client, localStorage), IAuthenticateService
    {
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthRequest authenticateRequest = new()
                {
                    Email = email,
                    Password = password 
                };
                var authenticateResponse = await _client.LoginAsync(authenticateRequest);
                if (authenticateResponse.Token != string.Empty)
                {
                    var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(authenticateResponse.Token);
                    var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme));
                    var login = httpContextAccessor.HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, user);

                    _localStorage.SetStorageValue("token",authenticateResponse.Token);

                    return true;
                }

                return false;
            }
            catch
            {
               
               return false;
            }
        }

        public async Task Logout()
        {
           _localStorage.ClearStorage(new List<string>(){ "token" });
           await httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> Register(RegisterVM register)
        {
            RegisterationRequest registrationRequest = new()
            {
                Email =    register.Email,
                FirstName= register.FirstName,
                LastName = register.LastName,
                UserName = register.UserName,
                Password = register.Password,
            };
            var response = await _client.RegisterAsync(registrationRequest);
            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }

            return false;
        }

        private IList<Claim> ParseClaims(JwtSecurityToken token)
        {
            var claims = token.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name,token.Subject));
            return claims;
        }
    }
}
