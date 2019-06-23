using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Models.Models
{
    public class CompanyDto
    {
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

        public CompanyDto(string id, string name, string phone, string email, string address, float? shareValue, string currentSeries, string status, string description, string iconImage)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
            ShareValue = shareValue;
            CurrentSeries = currentSeries;
            Status = status;
            Description = description;
            IconImage = iconImage;
        }

        public CompanyDto()
        {
        }
    }
}
