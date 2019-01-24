using System;
using System.Collections.Generic;

namespace CieDigitalAssessment.API.Models
{
    public partial class MovieCopy
    {
        public MovieCopy()
        {
            CustomerMovieCopy = new HashSet<CustomerMovieCopy>();
            TransactionMovieCopy = new HashSet<TransactionMovieCopy>();
        }

        public int Id { get; set; }
        public int RentalBoxId { get; set; }
        public int MovieId { get; set; }
        public int MovieCopyStatus { get; set; }

        public Movie Movie { get; set; }
        public MovieCopyStatus MovieCopyStatusNavigation { get; set; }
        public RentalBox RentalBox { get; set; }
        public ICollection<CustomerMovieCopy> CustomerMovieCopy { get; set; }
        public ICollection<TransactionMovieCopy> TransactionMovieCopy { get; set; }
    }
}
