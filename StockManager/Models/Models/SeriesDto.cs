using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Models.Models
{
    public class SeriesDto
    {
        public string Id { get; set; }
        public DateTime? OpenTime { get; set; }
        public DateTime? CloseTime { get; set; }
        public float? PreMoney { get; set; }
        public float? PostMoney { get; set; }
        public string CompanyId { get; set; }

        public SeriesDto(string id, DateTime? openTime, DateTime? closeTime, float? preMoney, float? postMoney, string companyId)
        {
            Id = id;
            OpenTime = openTime;
            CloseTime = closeTime;
            PreMoney = preMoney;
            PostMoney = postMoney;
            CompanyId = companyId;
        }

        public SeriesDto()
        {
        }
    }
}
