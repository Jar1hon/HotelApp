using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAppLibrary.Models
{
    public class BookingModels
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CheckedId { get; set; }
        public decimal TotalCost {  get; set; }
    }
}
