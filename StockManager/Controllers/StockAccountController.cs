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
    public class StockAccountController : ControllerBase
    {

        StockyManagerContext stocky = new StockyManagerContext();

        // GET api/values
        [HttpGet]
        public dynamic GetCompanies(String shares_Type, String beneficiary, String shareholderID)
        {
            List<StockAccount> stockAccount;
            List<StockAccountDto> stockAccountDtos = new List<StockAccountDto>();


            if (shares_Type != null && beneficiary == null && shareholderID == null)
            {
                stockAccount = stocky.StockAccount.Where(e => e.ShareTypeId == shares_Type).ToList();
            }
            else if (shares_Type == null && beneficiary != null && shareholderID == null)
            {
                stockAccount = stocky.StockAccount.Where(e => e.Beneficiary == beneficiary).ToList();
            }
            else if (shares_Type == null && beneficiary == null && shareholderID != null)
            {
                stockAccount = stocky.StockAccount.Where(e => e.ShareholderId == shareholderID).ToList();

            }

            else if (shares_Type != null && beneficiary != null && shareholderID == null)
            {
                stockAccount = stocky.StockAccount.Where(e => e.ShareTypeId == shares_Type && e.Beneficiary == beneficiary).ToList();

            }
            else if (shares_Type != null && beneficiary == null && shareholderID != null)
            {
                stockAccount = stocky.StockAccount.Where(e => e.ShareTypeId == shares_Type && e.ShareholderId == shareholderID).ToList();

            }
            else if (shares_Type == null && beneficiary != null && shareholderID != null)
            {
                stockAccount = stocky.StockAccount.Where(e => e.Beneficiary == beneficiary && e.ShareholderId == shareholderID).ToList();

            }

            else if (shares_Type == null && beneficiary == null && shareholderID == null)
            {
                stockAccount = stocky.StockAccount.ToList();
            }
            else
            {
                stockAccount = stocky.StockAccount.Where(e => e.Beneficiary == beneficiary && e.ShareholderId == shareholderID && e.ShareTypeId == shares_Type).ToList();
            }

            foreach (StockAccount com in stockAccount)
            {

                StockAccountDto dto = new StockAccountDto(
                    com.Id, com.Status, com.SharesType, com.CurrentAmount, com.Beneficiary, com.ExpiredDate, com.ShareholderId, com.ShareTypeId);
                stockAccountDtos.Add(dto);

            }
            return stockAccountDtos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public dynamic GetStockAccount(String id)
        {
            StockAccount com = stocky.StockAccount.Where(e => e.Id == id).FirstOrDefault();
            return new StockAccountDto(com.Id, com.Status, com.SharesType, com.CurrentAmount, com.Beneficiary, com.ExpiredDate, com.ShareholderId, com.ShareTypeId);

        }
        //api/person/byName?firstName=a&lastName=b 

        [HttpPut("{id}")]
        public void PutStockAccount(String id, [FromBody] StockAccountDto stockAccountDto)
        {
            //  stocky.Company.Update(id, com); 
            StockAccount com = stocky.StockAccount.Where(e => e.Id == stockAccountDto.Id).Single<StockAccount>();
            com.Id = stockAccountDto.Id;
            com.Status = stockAccountDto.Status;
            com.SharesType = stockAccountDto.SharesType;
            com.CurrentAmount = stockAccountDto.CurrentAmount;
            com.Beneficiary = stockAccountDto.Beneficiary;
            com.ExpiredDate = stockAccountDto.ExpiredDate;
            com.ShareholderId = stockAccountDto.ShareholderId;
            com.ShareTypeId = stockAccountDto.ShareTypeId; 
            stocky.Entry(com).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            stocky.SaveChanges();
        }

        [HttpPost]
        public void PostCompany([FromBody] StockAccountDto stockAccountDto)
        {
            StockAccount com = new StockAccount();
            com.Id = stockAccountDto.Id;
            com.Status = stockAccountDto.Status;
            com.SharesType = stockAccountDto.SharesType;
            com.CurrentAmount = stockAccountDto.CurrentAmount;
            com.Beneficiary = stockAccountDto.Beneficiary;
            com.ExpiredDate = stockAccountDto.ExpiredDate;
            com.ShareholderId = stockAccountDto.ShareholderId;
            com.ShareTypeId = stockAccountDto.ShareTypeId;
            stocky.StockAccount.Add(com);
            stocky.SaveChanges();
        }
    }
}