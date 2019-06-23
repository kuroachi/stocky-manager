using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Models.Models
{
    public class StockAccountTransactionDto
    {
        public string Id { get; set; }
        public string StockAccountId { get; set; }
        public string TransactionId { get; set; }

        public StockAccountTransactionDto(string id, string stockAccountId, string transactionId)
        {
            Id = id;
            StockAccountId = stockAccountId;
            TransactionId = transactionId;
        }

        public StockAccountTransactionDto()
        {
        }
    }
}
