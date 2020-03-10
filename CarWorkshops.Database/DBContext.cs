using CarWorkshops.Domain.Models;
using System.Collections.Generic;

namespace CarWorkshops.Database
{
    public class DBContext : IDBContext
    {
        private ICurrentDBContext _context;
        public DBContext(ICurrentDBContext context)
        {
            _context = context;
        }

        public IEnumerable<User> Users => _context.Users;
        public IEnumerable<Workshop> Workshops => _context.Workshops;
        public IEnumerable<Brand> Brands => _context.Brands;
        public IEnumerable<Appointment> Appointments => _context.Appointments;
    }
}
