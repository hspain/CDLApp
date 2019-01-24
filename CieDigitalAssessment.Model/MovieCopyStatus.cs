using System;
using System.Collections.Generic;

namespace CieDigitalAssessment.API.Models
{
    public partial class MovieCopyStatus : IEntity
    {
        public MovieCopyStatus()
        {
            MovieCopy = new HashSet<MovieCopy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MovieCopy> MovieCopy { get; set; }
    }
}
