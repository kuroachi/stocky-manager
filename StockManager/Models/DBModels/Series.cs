using System;
using System.Collections.Generic;

namespace StockManager.Models.DBModels
{
    public partial class Series
    {
        public Series()
        {
            Transaction = new HashSet<Transaction>();
        }

        public string Id { get; set; }
        public DateTime? OpenTime { get; set; }
        public DateTime? CloseTime { get; set; }
        public float? PreMoney { get; set; }
        public float? PostMoney { get; set; }
        public string CompanyId { get; set; }

        public Company Company { get; set; }
        public ICollection<Transaction> Transaction { get; set; }
    }
}
