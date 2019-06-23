using System;
using System.Collections.Generic;

namespace StockManager.Models.DBModels
{
    public partial class Shareholder
    {
        public Shareholder()
        {
            StockAccount = new HashSet<StockAccount>();
        }

        public string Id { get; set; }
        public float? TotalShares { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public string ShareholderTypeId { get; set; }
        public string CompanyId { get; set; }

        public Company Company { get; set; }
        public ShareholderType ShareholderType { get; set; }
        public UserAccount User { get; set; }
        public ICollection<StockAccount> StockAccount { get; set; }
    }
}
