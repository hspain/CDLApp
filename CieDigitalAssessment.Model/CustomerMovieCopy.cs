using System;
using System.Collections.Generic;

namespace CieDigitalAssessment.API.Models
{
    public partial class CustomerMovieCopy : IEntity
    {
        public int Id { get; set; }
        public int MovieCopyId { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public MovieCopy MovieCopy { get; set; }
    }
}
