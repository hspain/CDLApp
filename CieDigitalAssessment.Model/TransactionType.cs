using System;
using System.Collections.Generic;

namespace CieDigitalAssessment.API.Models
{
    public partial class TransactionType : IEntity
    {
        public TransactionType()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Transaction> Transaction { get; set; }
    }
}
