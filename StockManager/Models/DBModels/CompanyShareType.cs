using System;
using System.Collections.Generic;

namespace StockManager.Models.DBModels
{
    public partial class CompanyShareType
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string ShareTypeId { get; set; }

        public Company Company { get; set; }
        public ShareType ShareType { get; set; }
    }
}
