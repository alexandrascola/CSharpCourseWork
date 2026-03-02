using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingManager
{
    public sealed class BookingManager
    {
        private readonly List<Booking> _bookings = new();

        public IReadOnlyList<Booking> All() => _bookings.OrderBy(b => b.CheckIn).ToList();

        public void Add(Booking b)
        {
            //Call EnsureNoOverlap. If it passes, add the booking
        }

        public bool Cancel(string roomNumber, string guestName)
        {
            //Example on how to crawl the list for a booking based on name and room number:
			var toRemove = _bookings.FirstOrDefault(b =>
                b.RoomNumber.Equals(roomNumber, StringComparison.OrdinalIgnoreCase) &&
                b.GuestName .Equals(guestName,  StringComparison.OrdinalIgnoreCase));

			//if the var is null, return false, otherwise remove the booking and return true
            
			
        }

        public bool TryFind(string roomNumber, string guestName, out Booking? booking)
        {
            //check the entire list for that booking based on room number and guest name.
			//if the reservation exists, return the booking != null		
			
        }

		//Create a public bool IsAvailable() pass in roomNumber and DateTime for checkIn and checkOut
		//Use a try catch block run EnsureNoOverlap. Return true if successful, catch and return false if not


		//!!! Helper method for you to check if a room has an overlapping visit. Do not modify
        private void EnsureNoOverlap(string roomNumber, DateTime checkIn, DateTime checkOut, Booking? except)
        {
            bool Overlaps(Booking a) => a.CheckIn < checkOut && checkIn < a.CheckOut;

            foreach (var existing in _bookings)
            {
                if (except != null && ReferenceEquals(existing, except)) continue;
                if (!existing.RoomNumber.Equals(roomNumber, StringComparison.OrdinalIgnoreCase)) continue;

                if (Overlaps(existing))
                {
                    throw new InvalidOperationException(
                        $"Room {roomNumber} already booked {existing.CheckIn:MM/dd HH:mm}–{existing.CheckOut:MM/dd HH:mm}.");
                }
            }
        }
    }
}
