using System;

namespace CarWorkshops.Domain.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int CompanyId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
