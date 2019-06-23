using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Models.Models
{
    public class TransactionDto
    {
        public string Id { get; set; }
        public DateTime? TransactionTime { get; set; }
        public string Status { get; set; }
        public float? SharesQuantity { get; set; }
        public DateTime? TimeApprove { get; set; }
        public string SeriesId { get; set; }
        public string TransactionTypeId { get; set; }

        public TransactionDto(string id, DateTime? transactionTime, string status, float? sharesQuantity, DateTime? timeApprove, string seriesId, string transactionTypeId)
        {
            Id = id;
            TransactionTime = transactionTime;
            Status = status;
            SharesQuantity = sharesQuantity;
            TimeApprove = timeApprove;
            SeriesId = seriesId;
            TransactionTypeId = transactionTypeId;
        }

        public TransactionDto()
        {
        }
    }
}
