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
    public class ShareTypeController : ControllerBase
    {
        StockyManagerContext stocky = new StockyManagerContext();

        // GET api/values
        [HttpGet]
        public dynamic GetShareType()
        {
            List<ShareType> shareType;
            List<ShareTypeDto> shareTypeDtos = new List<ShareTypeDto>();

            shareType = stocky.ShareType.ToList();

            foreach (ShareType com in shareType)
            {

                ShareTypeDto dto = new ShareTypeDto(
                    com.Id, com.Type);
                shareTypeDtos.Add(dto);

            }
            return shareTypeDtos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public dynamic GetShareType(String id)
        {
            ShareType com = stocky.ShareType.Where(e => e.Id == id).FirstOrDefault();
            return new ShareTypeDto(com.Id, com.Type);

        }
        //api/person/byName?firstName=a&lastName=b 

        [HttpPut("{id}")]
        public void PutShareType(String id, [FromBody] ShareTypeDto shareTypeDto)
        {
            //  stocky.Company.Update(id, com); 
            ShareType com = stocky.ShareType.Where(e => e.Id == shareTypeDto.Id).Single<ShareType>();
            com.Id = shareTypeDto.Id;
            com.Type = shareTypeDto.Type;
            stocky.Entry(com).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            stocky.SaveChanges();
        }

        [HttpPost]
        public void PostShareType([FromBody] ShareTypeDto shareTypeDto)
        {
            ShareType com = new ShareType();
            com.Id = shareTypeDto.Id;
            com.Type = shareTypeDto.Type;
            stocky.ShareType.Add(com);
            stocky.SaveChanges();
        }
    }
}