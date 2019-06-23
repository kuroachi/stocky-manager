using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManager.Models.DBModels;
using StockManager.Models.Models;

namespace StockManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        StockyManagerContext stocky = new StockyManagerContext();

        // GET api/values
        [HttpGet]
        public dynamic GetCompanies(String role, String email)
        {
            List<UserAccount> userAccount;
            List<UserAccountDto> userAccountDtos = new List<UserAccountDto>();

            if (role == null && email != null)
            {
                userAccount = stocky.UserAccount.Where(e => e.Email == email).ToList();
            }
            else if (email == null && role != null)
            {
                userAccount = stocky.UserAccount.Where(e => e.Role == role).ToList();
            }
            else if (email == null && role == null)
            {
                userAccount = stocky.UserAccount.ToList();
            }
            else
            {
                userAccount = stocky.UserAccount.Where(e => e.Email == email && e.Role == role).ToList();
            }

             foreach (UserAccount com in userAccount)
            {

                UserAccountDto dto = new UserAccountDto(com.Id, com.Avatar,com.Fullname, com.IdentifyCardNumber, com.Address, com.Phone, com.Email, com.Status, com.Role, com.Description);
                userAccountDtos.Add(dto);

            }
            return userAccountDtos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public dynamic GetUserAccount(String id)
        {
            UserAccount com = stocky.UserAccount.Where(e => e.Id == id).FirstOrDefault();
            return new UserAccountDto(com.Id, com.Avatar, com.Fullname, com.IdentifyCardNumber, com.Address, com.Phone, com.Email, com.Status, com.Role, com.Description);

        }
        //api/person/byName?firstName=a&lastName=b 

        [HttpPut("{id}")]
        public void PutUserAccount(String id, [FromBody] UserAccountDto userAccountDto)
        {
            //  stocky.Company.Update(id, com); 
            UserAccount com = stocky.UserAccount.Where(e => e.Id == userAccountDto.Id).Single<UserAccount>();
            com.Id = userAccountDto.Id;
            com.Avatar = userAccountDto.Avatar;
            com.Phone = userAccountDto.Phone;
            com.Email = userAccountDto.Email;
            com.Address = userAccountDto.Address;
            com.IdentifyCardNumber = userAccountDto.IdentifyCardNumber;
            com.Role = userAccountDto.Role;
            com.Status = userAccountDto.Status;
            com.Description = userAccountDto.Description;
            com.Fullname = userAccountDto.Fullname;
            stocky.Entry(com).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            stocky.SaveChanges();
        }

        [HttpPost]
        public void PostUserAccount([FromBody] UserAccountDto userAccountDto)
        {
            UserAccount com = new UserAccount();
            com.Id = userAccountDto.Id;
            com.Avatar = userAccountDto.Avatar;
            com.Phone = userAccountDto.Phone;
            com.Email = userAccountDto.Email;
            com.Address = userAccountDto.Address;
            com.IdentifyCardNumber = userAccountDto.IdentifyCardNumber;
            com.Role = userAccountDto.Role;
            com.Status = userAccountDto.Status;
            com.Description = userAccountDto.Description;
            com.Fullname = userAccountDto.Fullname;
            stocky.UserAccount.Add(com);
            stocky.SaveChanges();
        }

    }
}