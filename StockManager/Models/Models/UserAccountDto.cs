using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Models.Models
{
    public class UserAccountDto
    {
        public string Id { get; set; }
        public string Avatar { get; set; }
        public string Fullname { get; set; }
        public string IdentifyCardNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }

        public UserAccountDto(string id, string avatar, string fullname, string identifyCardNumber, string address, string phone, string email, string status, string role, string description)
        {
            Id = id;
            Avatar = avatar;
            Fullname = fullname;
            IdentifyCardNumber = identifyCardNumber;
            Address = address;
            Phone = phone;
            Email = email;
            Status = status;
            Role = role;
            Description = description;
        }

        public UserAccountDto()
        {
        }
    }
}
