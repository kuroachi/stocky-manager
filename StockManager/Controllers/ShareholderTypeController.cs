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
    public class ShareholderTypeController : ControllerBase
    {
        StockyManagerContext stocky = new StockyManagerContext();

        // GET api/values
        [HttpGet]
        public dynamic GetShareholderType()
        {
            List<ShareholderType> ShareholderType;
            List<ShareholderTypeDto> shareholderDtos = new List<ShareholderTypeDto>();

            ShareholderType = stocky.ShareholderType.ToList();
             
            foreach (ShareholderType com in ShareholderType)
            {

                ShareholderTypeDto dto = new ShareholderTypeDto(
                    com.Id, com.Type);
                shareholderDtos.Add(dto);

            }
            return shareholderDtos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public dynamic GetShareholderType(String id)
        {
            ShareholderType com = stocky.ShareholderType.Where(e => e.Id == id).FirstOrDefault();
            return new ShareholderTypeDto(com.Id, com.Type);

        }
        //api/person/byName?firstName=a&lastName=b 

        [HttpPut("{id}")]
        public void PutShareholderType(String id, [FromBody] ShareholderTypeDto shareholderTypeDto)
        {
            //  stocky.Company.Update(id, com); 
            ShareholderType com = stocky.ShareholderType.Where(e => e.Id == shareholderTypeDto.Id).Single<ShareholderType>();
            com.Id = shareholderTypeDto.Id;
            com.Type = shareholderTypeDto.Type; 
            stocky.Entry(com).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            stocky.SaveChanges();
        }

        [HttpPost]
        public void PostShareholderType([FromBody] ShareholderTypeDto shareholderTypeDto)
        {
            ShareholderType com = new ShareholderType();
            com.Id = shareholderTypeDto.Id;
            com.Type = shareholderTypeDto.Type; 
            stocky.ShareholderType.Add(com);
            stocky.SaveChanges();
        }
    }
}