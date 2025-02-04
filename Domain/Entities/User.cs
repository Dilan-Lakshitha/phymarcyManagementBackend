using System;

namespace phymarcyManagement.Domain.Entities
{
    public class PharmacyUser
    {
        public int Id { get; set; }
        public string PharmacyName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
