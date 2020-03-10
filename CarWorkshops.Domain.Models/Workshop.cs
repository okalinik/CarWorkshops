namespace CarWorkshops.Domain.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CarTrademarksSpecializes { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
