using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ccse_cw1.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class Panel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
