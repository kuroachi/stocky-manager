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
    public class CompanyShareTypeController : ControllerBase
    {
        StockyManagerContext stocky = new StockyManagerContext();
        [HttpGet]
        public dynamic GetCompanyShareType(String companyId, String shareTypeId)
        {
            List<CompanyShareType> companyShareType;
            List<CompanyShareTypeDto> companyShareTypeDtos = new List<CompanyShareTypeDto>();

            if (companyId == null && shareTypeId != null)
            {
                companyShareType = stocky.CompanyShareType.Where(e => e.ShareTypeId == shareTypeId).ToList();
            }
            else if (shareTypeId == null && companyId != null)
            {
                companyShareType = stocky.CompanyShareType.Where(e => e.CompanyId == companyId).ToList();
            }
            else if (shareTypeId == null && companyId == null)
            {
                companyShareType = stocky.CompanyShareType.ToList();
            }
            else
            {
                companyShareType = stocky.CompanyShareType.Where(e => e.ShareTypeId == shareTypeId && e.CompanyId == companyId).ToList();
            }

            foreach (CompanyShareType companyShareTypeentity in companyShareType)
            { 
                CompanyShareTypeDto dto = new CompanyShareTypeDto(companyShareTypeentity.Id, companyShareTypeentity.CompanyId, companyShareTypeentity.ShareTypeId);
                companyShareTypeDtos.Add(dto);

            }
            return companyShareTypeDtos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public dynamic GetCompanyShareType(String id)
        {
            CompanyShareType com = stocky.CompanyShareType.Where(e => e.Id == id).FirstOrDefault();
            return new CompanyShareTypeDto(com.Id, com.CompanyId, com.ShareTypeId);

        }
        //api/person/byName?firstName=a&lastName=b 

        [HttpPut("{id}")]
        public void PutCompanyShareType(String id, [FromBody] CompanyShareTypeDto dto)
        {
            //  stocky.Company.Update(id, com); 
            CompanyShareType com = stocky.CompanyShareType.Where(e => e.Id == dto.Id).Single<CompanyShareType>();
            com.Id = dto.Id;
            com.CompanyId = dto.CompanyId;
            com.ShareTypeId = dto.ShareTypeId;  
            stocky.Entry(com).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            stocky.SaveChanges();
        }

        [HttpPost]
        public void PostCompanyShareType([FromBody] CompanyShareTypeDto dto)
        {
            CompanyShareType com = new CompanyShareType();
            com.Id = dto.Id;
            com.CompanyId = dto.CompanyId;
            com.ShareTypeId = dto.ShareTypeId;
            stocky.CompanyShareType.Add(com);
            stocky.SaveChanges();
        }
    }
}