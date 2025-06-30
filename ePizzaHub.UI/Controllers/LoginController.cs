using ePizzaHub.UI.Models.ApiModels.Response;
using ePizzaHub.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ePizzaHub.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory= httpClientFactory;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel request)
        {
            var client = _httpClientFactory.CreateClient("ePizzaAPI");
            var userDetails = await client.GetFromJsonAsync<ValidateUserResponse>($"Auth?username={request.EmailAddress}&password={request.Password}");
            
            if(userDetails is not null)
            {
                // add hard coded claim
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name,"Sample@123"));

               await  GenerateTicket(claims);
                return RedirectToAction("Dashboard", "Index");
            }
            
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
        private async Task GenerateTicket(List<Claim> claims)
        {
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, 
                new AuthenticationProperties() { 
                IsPersistent=false,
                ExpiresUtc=DateTime.UtcNow.AddMinutes(60)
                });

        }
    }
}
