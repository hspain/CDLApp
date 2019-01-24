using System;
using System.Collections.Generic;

namespace CieDigitalAssessment.API.Models
{
    public partial class RentalBox : IEntity
    {
        public RentalBox()
        {
            MovieCopy = new HashSet<MovieCopy>();
        }

        public int Id { get; set; }
        public int StatusId { get; set; }
        public int LocationId { get; set; }
        public DateTime DateAdded { get; set; }

        public Location Location { get; set; }
        public RentalBoxStatus Status { get; set; }
        public ICollection<MovieCopy> MovieCopy { get; set; }
    }
}
