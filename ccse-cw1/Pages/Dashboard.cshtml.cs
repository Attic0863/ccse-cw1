using ccse_cw1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ccse_cw1.Pages
{
    [Authorize]
    public class DashboardModel : PageModel
    {
		private readonly UserManager<ApplicationUser> _userManager;
		public ApplicationUser? appUser;
		public DashboardModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
            var task = _userManager.GetUserAsync(User);
            task.Wait();
            appUser = task.Result;
        }
    }
}
