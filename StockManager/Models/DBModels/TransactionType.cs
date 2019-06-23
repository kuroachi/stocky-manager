using System;
using System.Collections.Generic;

namespace StockManager.Models.DBModels
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            Transaction = new HashSet<Transaction>();
        }

        public string Id { get; set; }
        public string Type { get; set; }

        public ICollection<Transaction> Transaction { get; set; }
    }
}
