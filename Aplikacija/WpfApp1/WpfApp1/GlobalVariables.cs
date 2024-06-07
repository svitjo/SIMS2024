using ReservationSystem.Controller;
using ReservationSystem.Repository;
using ReservationSystem.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationSystem
{
    public static class GlobalVariables
    {
        public static string CurrentUserEmail { get; set; }

        public static HotelController HotelController { get; private set; }
        public static HotelService HotelService { get; private set; }
        public static HotelRepository HotelRepository { get; private set; }

        public static ApartmentController ApartmentController { get; private set; }
        public static ApartmentService ApartmentService { get; private set; }
        public static ApartmentRepository ApartmentRepository { get; private set; }

        public static UserController UserController { get; private set; }
        public static UserService UserService { get; private set; }
        public static UserRepository UserRepository { get; private set; }

        public static AuthController AuthController { get; private set; }
        public static AuthService AuthService { get; private set; }

        public static ReservationController ReservationController { get; private set; }
        public static ReservationService ReservationService { get; private set; }
        public static ReservationRepository ReservationRepository { get; private set; }

        static GlobalVariables()
        {
            HotelRepository = new HotelRepository(@"..\..\..\Data\hotel.json");
            HotelService = new HotelService(HotelRepository);
            HotelController = new HotelController(HotelService);

            ApartmentRepository = new ApartmentRepository(@"..\..\..\Data\apartment.json");
            ApartmentService = new ApartmentService(ApartmentRepository);
            ApartmentController = new ApartmentController(ApartmentService);

            ReservationRepository = new ReservationRepository(@"..\..\..\Data\reservation.json");
            ReservationService = new ReservationService(ReservationRepository);
            ReservationController = new ReservationController(ReservationService);

            UserRepository = new UserRepository(@"..\..\..\Data\user.json");
            UserService = new UserService(UserRepository);
            UserController = new UserController(UserService);

            AuthService = new AuthService(UserRepository);
            AuthController = new AuthController(AuthService);
        }

    }
}
