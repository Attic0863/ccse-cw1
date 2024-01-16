using ccse_cw1.Models;
using ccse_cw1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ccse_cw1.Pages
{
    [Authorize]
    public class BookModel : PageModel
    {
        public List<Hotel>? Hotels { get; set; }

        public BookModel()
        {
        }


        [BindProperty]
        public InputModel? Input { get; set; }

        public class InputModel
        {
            public required Booking booking { get; set; }
        }

        public async Task OnGetAsync()
        {


        }
    }
}
