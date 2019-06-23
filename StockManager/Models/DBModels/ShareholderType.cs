using System;
using System.Collections.Generic;

namespace StockManager.Models.DBModels
{
    public partial class ShareholderType
    {
        public ShareholderType()
        {
            Shareholder = new HashSet<Shareholder>();
        }

        public string Id { get; set; }
        public string Type { get; set; }

        public ICollection<Shareholder> Shareholder { get; set; }
    }
}
