using ccse_cw1.Models;
using ccse_cw1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccse_cw1.Pages
{
    [Authorize]
    public class BookModel : PageModel
    {
        public BookModel()
        {
        }

        [Required]
        [BindProperty]
        public required InputModel Input { get; set; }

        public class InputModel
        {
            public required DateTime CheckInDate { get; set; }

            public required DateTime CheckOutDate { get; set; }

            public required int HotelId { get; set; }

            public required string RoomType { get; set; }

            public required int Amount { get; set; }
        }

        public void OnPost()
        {


        }
    }
}
