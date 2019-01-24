using System;
using System.Collections.Generic;

namespace CieDigitalAssessment.API.Models
{
    public partial class Location
    {
        public Location()
        {
            RentalBox = new HashSet<RentalBox>();
        }

        public int Id { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressZip { get; set; }
        public string AddressName { get; set; }
        public string Nickname { get; set; }
        public string AddressState { get; set; }

        public ICollection<RentalBox> RentalBox { get; set; }
    }
}
