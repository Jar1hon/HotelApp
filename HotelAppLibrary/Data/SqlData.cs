using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelAppLibrary.Data
{
    public class SqlData : IDatabaseData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }
        public List<RoomTypeModels> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
        {
            return _db.LoadData<RoomTypeModels, dynamic>("dbo.spRoomTypes_GetAvailableTypes",
                                                  new { startDate, endDate },
                                                  connectionStringName, true);
        }

        public void BookGuest(string firstName,
                              string lastName,
                              DateTime startDate,
                              DateTime endDate,
                              int roomTypeId)
        {
            GuestModels guest = _db.LoadData<GuestModels, dynamic>("dbo.spGuests_Insert",
                                                                   new { firstName, lastName },
                                                                   connectionStringName,
                                                                   true).First();

            RoomTypeModels roomType = _db.LoadData<RoomTypeModels, dynamic>("select * from dbo.RoomTypes where Id = @Id",
                                                                             new { Id = roomTypeId },
                                                                             connectionStringName,
                                                                             false).First();
            
            TimeSpan timeStaying = endDate.Date.Subtract(startDate.Date);






            List<RoomModels> availableRooms = _db.LoadData<RoomModels, dynamic>("dbo.spRooms_GetAvailableRooms",
                                                                               new { startDate, endDate, roomTypeId },
                                                                               connectionStringName,
                                                                               true);

            _db.SaveData("dbo.spBookings_Insert",
                          new
                          {
                              roomId = availableRooms.First().Id,
                              guestId = guest.Id,
                              startDate = startDate,
                              endDate = endDate,
                              totalCost = roomType.Price * timeStaying.Days
                          },
                          connectionStringName,
                          true);
        }
        public List<BookingFullModels> SearchBookings(string lastName)
        {

            return _db.LoadData<BookingFullModels, dynamic>("dbo.spBookings_Search",
                                                     new { lastName, startDate = DateTime.Now.Date },
                                                     connectionStringName,
                                                     true);

        }

        public void CheckInGuest(int bookingId)
        {
            _db.SaveData("spBookings_CheckIn",
                                new { id = bookingId },
                                connectionStringName,
                                true);
        }

        public RoomTypeModels GetRoomTypeById(int id)
        {
            return _db.LoadData<RoomTypeModels, dynamic>("dbo.spRoomTypes_GetById", 
                                                        new { id = id},
                                                        connectionStringName, true).FirstOrDefault();
        }


    }
}
