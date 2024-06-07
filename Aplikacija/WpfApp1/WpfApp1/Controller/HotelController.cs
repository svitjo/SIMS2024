using ReservationSystem.Model;
using ReservationSystem.Service;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Controller
{
    public class HotelController
    {
        private HotelService hotelService;
        public HotelController(HotelService hotelService)
        {
            this.hotelService = hotelService;
        }
        public List<Hotel> GetAll()
        {
            return this.hotelService.GetAll();
        }
        public bool Create(String id, String name, int constructionYear, int starRating, String ownerJMBG, HotelStatus hotelStatus)
        {
            var hotel = new Hotel
            {
                Id = id,
                Name = name,
                ConstructionYear = constructionYear,
                StarRating = starRating,
                OwnerJMBG = ownerJMBG,
                HotelStatus = hotelStatus
            };

            return this.hotelService.Save(hotel);
        }
        public Hotel GetById(String id)
        {
            return this.hotelService.GetById(id);
        }
        public List<Hotel> GetAllByManager(String managerJMBG)
        {
            return this.hotelService.GetAllByManager(managerJMBG);
        }
        public void AcceptHotel(string hoteId)
        {
            var hotel = hotelService.GetById(hoteId);
            if (hotel != null)
            {
                hotel.HotelStatus = HotelStatus.Accepted;
                hotelService.Approve(hotel);
            }
            else
            {
                throw new Exception("hotel not found.");
            }
        }
        public void RejectHotel(string hoteId)
        {
            var hotel = hotelService.GetById(hoteId);
            if (hotel != null)
            {
                hotel.HotelStatus = HotelStatus.Accepted;
                hotelService.Reject(hotel);
            }
            else
            {
                throw new Exception("Hotel not found.");
            }
        }
    }
}