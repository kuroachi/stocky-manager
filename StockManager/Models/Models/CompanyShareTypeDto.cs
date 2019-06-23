using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Models.Models
{
    public class CompanyShareTypeDto
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string ShareTypeId { get; set; }

        public CompanyShareTypeDto(string id, string companyId, string shareTypeId)
        {
            Id = id;
            CompanyId = companyId;
            ShareTypeId = shareTypeId;
        }

        public CompanyShareTypeDto()
        {
        }
    }
}
