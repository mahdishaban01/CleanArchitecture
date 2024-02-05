namespace HR_Management.MVC.Controllers;

public class UsersController(IAuthenticateService authenticateService) : Controller
{

    #region Register

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM register)
    {
        if (!ModelState.IsValid)
        {

            return View(register);
        }

        var isCreated = await authenticateService.Register(register);
        if (isCreated)
        {
            return LocalRedirect("/");
        }
        ModelState.AddModelError("", "Registration Failed.");
        return View(register);
    }

    #endregion

    #region Login

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM login, string returnUrl)
    {
        returnUrl ??= Url.Content("~/");
        var isLoggedIn = await authenticateService.Authenticate(login.Email, login.Passsword);
        if (isLoggedIn)
        {
            return LocalRedirect(returnUrl);
        }

        ModelState.AddModelError("","Login Failed. Please Try again.");
        return View(login);
    }

    #endregion

    #region Logout

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await authenticateService.Logout();
        return LocalRedirect("/Users/Login");
    }

    #endregion
}
