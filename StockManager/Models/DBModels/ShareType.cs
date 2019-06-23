using System;
using System.Collections.Generic;

namespace StockManager.Models.DBModels
{
    public partial class ShareType
    {
        public ShareType()
        {
            CompanyShareType = new HashSet<CompanyShareType>();
            StockAccount = new HashSet<StockAccount>();
        }

        public string Id { get; set; }
        public string Type { get; set; }

        public ICollection<CompanyShareType> CompanyShareType { get; set; }
        public ICollection<StockAccount> StockAccount { get; set; }
    }
}
