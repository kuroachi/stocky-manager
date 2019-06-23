using System;
using System.Collections.Generic;

namespace StockManager.Models.DBModels
{
    public partial class Company
    {
        public Company()
        {
            CompanyShareType = new HashSet<CompanyShareType>();
            Series = new HashSet<Series>();
            Shareholder = new HashSet<Shareholder>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public float? ShareValue { get; set; }
        public string CurrentSeries { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string IconImage { get; set; }

        public ICollection<CompanyShareType> CompanyShareType { get; set; }
        public ICollection<Series> Series { get; set; }
        public ICollection<Shareholder> Shareholder { get; set; }
    }
}
