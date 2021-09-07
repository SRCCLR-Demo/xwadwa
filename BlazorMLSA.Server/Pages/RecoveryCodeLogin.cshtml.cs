using System.Threading.Tasks;
using BlazorMLSA.Server.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorMLSA.Server.Pages
{
    [AllowAnonymous]
    public class RecoveryCodeLoginModel : PageModel
    {
        private SignInManager<ApplicationUser> signInManager;
        public RecoveryCodeLoginModel(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [BindProperty]
        public string recoveryCode { get; set; }
        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPost()
        {
            ApplicationUser user = await signInManager.GetTwoFactorAuthenticationUserAsync();
            var resutl = await signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);
            return Redirect("/");
        }
    }
}