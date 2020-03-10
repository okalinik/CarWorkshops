using CarWorkshops.Domain.Models;
using System.Collections.Generic;

namespace CarWorkshops.Database
{
    public class SQLDBContext : IDBContext
    {
        public IEnumerable<User> Users { get; set; } // read from database

        public IEnumerable<Workshop> Workshops => throw new System.NotImplementedException();

        public IEnumerable<Brand> Brands => throw new System.NotImplementedException();

        IEnumerable<User> IDBContext.Users => throw new System.NotImplementedException();

        IEnumerable<Workshop> IDBContext.Workshops => throw new System.NotImplementedException();

        IEnumerable<Brand> IDBContext.Brands => throw new System.NotImplementedException();

        IEnumerable<Appointment> IDBContext.Appointments => throw new System.NotImplementedException();
    }
}
