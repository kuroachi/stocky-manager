using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Models.Models
{
    public class ShareholderDto
    {
        public string Id { get; set; }
        public float? TotalShares { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public string ShareholderTypeId { get; set; }
        public string CompanyId { get; set; }

        public ShareholderDto(string id, float? totalShares, string status, string userId, string shareholderTypeId, string companyId)
        {
            Id = id;
            TotalShares = totalShares;
            Status = status;
            UserId = userId;
            ShareholderTypeId = shareholderTypeId;
            CompanyId = companyId;
        }

        public ShareholderDto()
        {
        }
    }
}
