using System;
using System.Collections.Generic;

namespace StockManager.Models.DBModels
{
    public partial class Transaction
    {
        public Transaction()
        {
            StockAccountTransaction = new HashSet<StockAccountTransaction>();
        }

        public string Id { get; set; }
        public DateTime? TransactionTime { get; set; }
        public string Status { get; set; }
        public float? SharesQuantity { get; set; }
        public DateTime? TimeApprove { get; set; }
        public string SeriesId { get; set; }
        public string TransactionTypeId { get; set; }

        public Series Series { get; set; }
        public TransactionType TransactionType { get; set; }
        public ICollection<StockAccountTransaction> StockAccountTransaction { get; set; }
    }
}
