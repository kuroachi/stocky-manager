using System;
using System.Collections.Generic;

namespace StockManager.Models.DBModels
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            Shareholder = new HashSet<Shareholder>();
        }

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

        public ICollection<Shareholder> Shareholder { get; set; }
    }
}
