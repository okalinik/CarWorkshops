using CarWorkshops.Domain.Models;
using System;
using System.Collections.Generic;

namespace CarWorkshops.Database
{
    public class ObjectDBContext : ICurrentDBContext
    {
        public IEnumerable<User> Users => _users;
        public IEnumerable<Workshop> Workshops => _workshops;
        public IEnumerable<Brand> Brands => _brands;
        public IEnumerable<Appointment> Appointments => _appoinments;


        private List<Workshop> _workshops = new List<Workshop>
        {
            new Workshop
            {
                Id =1,
                PostalCode = "66900",
                Country = "UK",
                City = "Lonb",
                CarTrademarksSpecializes = "BMW, Mercedes, Audi",
                CompanyName ="Buy a car BRO"
            }
        };

        private List<Brand> _brands = new List<Brand>
        {
            new Brand
            {
                Id =1,
                Name = "BMW"
            },
             new Brand
            {
                Id =1,
                Name = "Audi"
            },
              new Brand
            {
                Id =1,
                Name = "Mercedes"
            },
        };


        private List<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                City="San",
                Country = "Mexico",
                Email = "dev@test.com",
                PostalCode = "2345",
                Username = "dev 1",

            }
        };

        private List<Appointment> _appoinments = new List<Appointment>
        {
            new Appointment
            {
                Id =1,
                UserID = 1,
                CompanyId = 1,
                DateTime = DateTime.UtcNow
             }
        };
    }
}
