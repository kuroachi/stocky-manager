using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Models.Models
{
    public class StockAccountDto
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string SharesType { get; set; }
        public float? CurrentAmount { get; set; }
        public string Beneficiary { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string ShareholderId { get; set; }
        public string ShareTypeId { get; set; }

        public StockAccountDto(string id, string status, string sharesType, float? currentAmount, string beneficiary, DateTime? expiredDate, string shareholderId, string shareTypeId)
        {
            Id = id;
            Status = status;
            SharesType = sharesType;
            CurrentAmount = currentAmount;
            Beneficiary = beneficiary;
            ExpiredDate = expiredDate;
            ShareholderId = shareholderId;
            ShareTypeId = shareTypeId;
        }

        public StockAccountDto()
        {
        }
    }
}
