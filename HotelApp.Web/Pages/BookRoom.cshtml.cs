using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel;

namespace HotelApp.Web.Pages
{
    public class BookRoomModel : PageModel
    {
        private readonly IDatabaseData _db;

        [BindProperty(SupportsGet = true)]
        public int RoomTypeId { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }

        [BindProperty]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [BindProperty]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        public RoomTypeModels RoomType { get; set; }

        public BookRoomModel(IDatabaseData db)
        {
            _db = db;
        }



        public void OnGet()
        {
            if(RoomTypeId > 0)
            {
                RoomType = _db.GetRoomTypeById(RoomTypeId);
            }
            
        }

        public IActionResult OnPost()
        {
            _db.BookGuest(FirstName, LastName, StartDate, EndDate, RoomTypeId);
            return RedirectToPage("/Index");
        }
    }
}
