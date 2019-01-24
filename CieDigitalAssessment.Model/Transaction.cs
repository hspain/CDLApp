using System;
using System.Collections.Generic;

namespace CieDigitalAssessment.API.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            TransactionMovieCopy = new HashSet<TransactionMovieCopy>();
        }

        public int Id { get; set; }
        public DateTime DateTransacted { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public int TransactionStatusId { get; set; }
        public int TransactionTypeId { get; set; }

        public TransactionStatus TransactionStatus { get; set; }
        public TransactionType TransactionType { get; set; }
        public ICollection<TransactionMovieCopy> TransactionMovieCopy { get; set; }
    }
}
