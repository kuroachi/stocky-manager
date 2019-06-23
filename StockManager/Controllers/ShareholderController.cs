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
    public class ShareholderController : ControllerBase
    {
        StockyManagerContext stocky = new StockyManagerContext();

        // GET api/values
        [HttpGet]
        public dynamic GetShareholder(String userID, String shareholder_Type, String companyID)
        {
            List<Shareholder> shareholder;
            List<ShareholderDto> shareholderDtos = new List<ShareholderDto>();

            if (userID != null && shareholder_Type == null && companyID == null)
            {
                shareholder = stocky.Shareholder.Where(e => e.UserId == userID).ToList();
            }
            else if (userID == null && shareholder_Type != null && companyID == null)
            {
                shareholder = stocky.Shareholder.Where(e => e.ShareholderTypeId == shareholder_Type).ToList();
            }
            else if (userID == null && shareholder_Type == null && companyID != null)
            {
                shareholder = stocky.Shareholder.Where(e => e.CompanyId == companyID).ToList();

            }

            else if (userID != null && shareholder_Type != null && companyID == null)
            {
                shareholder = stocky.Shareholder.Where(e => e.UserId == userID && e.ShareholderTypeId == shareholder_Type).ToList();

            }
            else if (userID != null && shareholder_Type == null && companyID != null)
            {
                shareholder = stocky.Shareholder.Where(e => e.UserId == userID && e.CompanyId == companyID).ToList();

            }
            else if (userID == null && shareholder_Type != null && companyID != null)
            {
                shareholder = stocky.Shareholder.Where(e => e.ShareholderTypeId == shareholder_Type && e.CompanyId == companyID).ToList();

            }

            else if (userID == null && shareholder_Type == null && companyID == null)
            {
                shareholder = stocky.Shareholder.ToList();
            }
            else
            {
                shareholder = stocky.Shareholder.Where(e => e.UserId == userID && e.ShareholderTypeId == shareholder_Type && e.CompanyId == companyID).ToList();
            } 
            foreach (Shareholder com in shareholder)
            {

                ShareholderDto dto = new ShareholderDto(
                    com.Id, com.TotalShares, com.Status, com.UserId, com.ShareholderTypeId, com.CompanyId);
                shareholderDtos.Add(dto);

            }
            return shareholderDtos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public dynamic GetShareholder(String id)
        {
            Shareholder com = stocky.Shareholder.Where(e => e.Id == id).FirstOrDefault();
            return new ShareholderDto(com.Id, com.TotalShares, com.Status, com.UserId, com.ShareholderTypeId, com.CompanyId);
        }
        //api/person/byName?firstName=a&lastName=b 

        [HttpPut("{id}")]
        public void PutShareholder(String id, [FromBody] ShareholderDto shareholderDto)
        {
            //  stocky.Company.Update(id, com); 
            Shareholder com = stocky.Shareholder.Where(e => e.Id == shareholderDto.Id).Single<Shareholder>();
            com.Id = shareholderDto.Id;
            com.TotalShares = shareholderDto.TotalShares;
            com.Status = shareholderDto.Status;
            com.UserId = shareholderDto.UserId;
            com.ShareholderTypeId = shareholderDto.ShareholderTypeId;
            com.CompanyId = shareholderDto.CompanyId; 
            stocky.Entry(com).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            stocky.SaveChanges();
        }

        [HttpPost]
        public void PostShareholder([FromBody] ShareholderDto shareholderDto)
        {
            Shareholder com = new Shareholder();
            com.Id = shareholderDto.Id;
            com.TotalShares = shareholderDto.TotalShares;
            com.Status = shareholderDto.Status;
            com.UserId = shareholderDto.UserId;
            com.ShareholderTypeId = shareholderDto.ShareholderTypeId;
            com.CompanyId = shareholderDto.CompanyId;
            stocky.Shareholder.Add(com);
            stocky.SaveChanges();
        }
    }
}