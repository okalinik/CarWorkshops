using CarWorkshops.Domain.Models;
using System.Collections.Generic;

namespace CarWorkshops.Database
{
    public interface IDBContext
    {
        IEnumerable<User> Users { get; }
        IEnumerable<Workshop> Workshops { get; }
        IEnumerable<Brand> Brands { get; }
        IEnumerable<Appointment> Appointments { get; }
    }
}
