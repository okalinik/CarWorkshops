using System;

namespace CarWorkshops.Domain.Models.ViewModels
{
    public class AppoinmentViewModel
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string UsersCarTrademark { get; set; }
        public DateTime DateTime { get; set; }
    }
}