using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ccse_cw1.Pages
{
	[Authorize(Roles = "manager,admin")]
	public class ManagerDashboardModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
