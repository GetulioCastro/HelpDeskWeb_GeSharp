using Hweb.data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;

namespace Hweb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly hwebDBcontext DBC;

        public IndexModel(hwebDBcontext dbC)
        {
            this.DBC = dbC;
        }

        public void OnGet()
        {

        }
        [BindProperty]public string username { get; set; }
        [BindProperty]public string password { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = DBC.Login_Credentials.Where(u => u.username == username && u.user_password == password).FirstOrDefault();
            if (user != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, user.user_role),
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                if (user.user_role == "Admin")
                {
                    return RedirectToPage("Request/RequestsList");
                }
                else if (user.user_role == "User")
                {
                    return RedirectToPage("Request/MyRequests");
                }
            }

            // Display error message for invalid credentials
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

    }
}