using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Models.Models
{
    public class ShareholderTypeDto
    {
        public string Id { get; set; }
        public string Type { get; set; }

        public ShareholderTypeDto(string id, string type)
        {
            Id = id;
            Type = type;
        }

        public ShareholderTypeDto()
        {
        }
    }
}
