namespace phymarcyManagement.Models.DTOs
{
    public class PharmacyRegisterRequest
    {
        public string Pharmacy_name { get; set; }
        
        public string location { get; set; }
        
        public string password { get; set; }
        public string pharmacy_email { get; set; }
    }
}
