using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CieDigitalAssessment.API.Models
{
    public partial class Movie : IEntity
    {
        public Movie()
        {
            MovieCopy = new HashSet<MovieCopy>();
        }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateMade { get; set; }
        public string Director { get; set; }
        public string BoxArtUrl { get; set; }

        public ICollection<MovieCopy> MovieCopy { get; set; }
    }
}
