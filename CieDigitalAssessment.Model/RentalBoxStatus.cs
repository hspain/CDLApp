using System;
using System.Collections.Generic;

namespace CieDigitalAssessment.API.Models
{
    public partial class RentalBoxStatus : IEntity
    {
        public RentalBoxStatus()
        {
            RentalBox = new HashSet<RentalBox>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RentalBox> RentalBox { get; set; }
    }
}
