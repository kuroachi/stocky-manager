using System;
using System.Collections.Generic;

namespace StockManager.Models.DBModels
{
    public partial class StockAccountTransaction
    {
        public string Id { get; set; }
        public string StockAccountId { get; set; }
        public string TransactionId { get; set; }

        public StockAccount StockAccount { get; set; }
        public Transaction Transaction { get; set; }
    }
}
