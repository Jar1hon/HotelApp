using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Web.Pages
{
    public class RoomSearchModel : PageModel
    {
        private readonly IDatabaseData _db;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        [DisplayName("От")]
        public DateTime StartDate { get; set; } = DateTime.Now.AddDays(1);
        //public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        [DisplayName("До")]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(2);
        //public DateTime EndDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool SearchEnabled { get; set; } = false;

        public List<RoomTypeModels> AvailableRoomTypes { get; set; }

        public RoomSearchModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            if(SearchEnabled == true)
            {
                AvailableRoomTypes = _db.GetAvailableRoomTypes(StartDate, EndDate);
            }
        }

        public IActionResult OnPost()
        {


            return RedirectToPage(new 
            {
                SearchEnabled = true,
                StartDate = StartDate.ToString("yyyy-MM-dd"),
                EndDate = EndDate.ToString("yyyy-MM-dd")
                //StartDate = "12.02.2023",
                //EndDate = "13.02.2023"

                //StartDate = StartDate.ToString("dd-MM-yyyy"),
                //EndDate = EndDate.ToString("dd-MM-yyyy")
                //EndDate = EndDate.ToString("yyyy-MM-dd"),
            });
        }
    }
}
