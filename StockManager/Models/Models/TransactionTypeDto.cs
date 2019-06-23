using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Models.Models
{
    public class TransactionTypeDto
    {
        public string Id { get; set; }
        public string Type { get; set; }

        public TransactionTypeDto(string id, string type)
        {
            Id = id;
            Type = type;
        }

        public TransactionTypeDto()
        {
        }
    }
}
