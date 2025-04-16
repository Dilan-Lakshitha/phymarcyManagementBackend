using System;

namespace phymarcyManagement.Domain.Entities
{
    public class PharmacyUser
    {
        public int pharmacy_id { get; set; }
        public string pharmacy_name { get; set; }
        public string pharmacy_email { get; set; }
        public string location { get; set; }
        public string password { get; set; }
    }
}
