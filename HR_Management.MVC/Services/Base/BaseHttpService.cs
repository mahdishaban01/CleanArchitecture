using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace HR_Management.MVC.Services.Base;

public class BaseHttpService(IClient client, ILocalStorageService localStorage)
{
    protected readonly IClient _client = client;
    protected readonly ILocalStorageService _localStorage = localStorage;

    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException exception)
    {
        if (exception.StatusCode == 400)
        {
            return new Response<Guid>() { Message = "Validation errors have occured.", ValidationErrors = exception.Response, Success = false };
        }
        else if (exception.StatusCode == 404)
        {
            return new Response<Guid>() { Message = "Not Found ...", Success = false };
        }
        else
        {
            return new Response<Guid>() { Message = "Somthing went wrong,try again ... ", Success = false };
        }
    }

    protected void AddBearerToken()
    {
        if(_localStorage.Exists("token"))
        {
            _client.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _localStorage.GetStorageValue<string>("token"));
        }
    }

    protected IList<Claim> ParseClaims(JwtSecurityToken token)
    {
        var claims = token.Claims.ToList();
        claims.Add(new Claim(ClaimTypes.Name,token.Subject));
        return claims;
    }

}
