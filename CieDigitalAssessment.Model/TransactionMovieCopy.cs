using System;
using System.Collections.Generic;

namespace CieDigitalAssessment.API.Models
{
    public partial class TransactionMovieCopy : IEntity
    {
        public int Id { get; set; }
        public int MovieCopyId { get; set; }
        public int TransactionId { get; set; }
        public decimal MovieAmount { get; set; }
        public decimal TaxAmount { get; set; }

        public MovieCopy MovieCopy { get; set; }
        public Transaction Transaction { get; set; }
    }
}
