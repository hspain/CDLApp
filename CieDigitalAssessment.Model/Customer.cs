using System;
using System.Collections.Generic;

namespace CieDigitalAssessment.API.Models
{
    public partial class Customer : IEntity
    {
        public Customer()
        {
            CustomerMovieCopy = new HashSet<CustomerMovieCopy>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
        public string AddressStreet { get; set; }

        public ICollection<CustomerMovieCopy> CustomerMovieCopy { get; set; }
        public ICollection<User> User { get; set; }
    }
}
