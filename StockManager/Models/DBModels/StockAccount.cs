using System;
using System.Collections.Generic;

namespace StockManager.Models.DBModels
{
    public partial class StockAccount
    {
        public StockAccount()
        {
            StockAccountTransaction = new HashSet<StockAccountTransaction>();
        }

        public string Id { get; set; }
        public string Status { get; set; }
        public string SharesType { get; set; }
        public float? CurrentAmount { get; set; }
        public string Beneficiary { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string ShareholderId { get; set; }
        public string ShareTypeId { get; set; }

        public ShareType ShareType { get; set; }
        public Shareholder Shareholder { get; set; }
        public ICollection<StockAccountTransaction> StockAccountTransaction { get; set; }
    }
}
