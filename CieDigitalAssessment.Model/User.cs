using System;
using System.Collections.Generic;

namespace CieDigitalAssessment.API.Models
{
    public partial class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLoggedIn { get; set; }
        public string StripeToken { get; set; }
        public int CustomerId { get; set; }
        public string Token { get; set; }

        public Customer Customer { get; set; }
    }
}
