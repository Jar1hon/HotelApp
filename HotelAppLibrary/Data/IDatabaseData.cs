using HotelAppLibrary.Models;
using System;
using System.Collections.Generic;

namespace HotelAppLibrary.Data
{
    public interface IDatabaseData
    {
        void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId);
        void CheckInGuest(int bookingId);
        List<RoomTypeModels> GetAvailableRoomTypes(DateTime startDate, DateTime endDate);
        RoomTypeModels GetRoomTypeById(int id);
        List<BookingFullModels> SearchBookings(string lastName);
    }
}