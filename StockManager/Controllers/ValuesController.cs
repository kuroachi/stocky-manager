using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockManager.Models.DBModels;
using StockManager.Models.Models;

namespace StockManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        StockyManagerContext stocky = new StockyManagerContext(); 
 
        // GET api/values
        [HttpGet]
        public dynamic Get()
        {
            List<Company> company = stocky.Company.ToList();
            List<CompanyDto> companyDtos = new List<CompanyDto>();
            foreach( Company com in company)
            {

                CompanyDto dto = new CompanyDto(com.Id,com.Name,com.Phone, com.Email, com.Address, com.ShareValue, com.CurrentSeries, com.Status, com.Description, com.IconImage);
                companyDtos.Add(dto);

            }
            return companyDtos;
        } 
        // GET api/values/5
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public ActionResult<string> Get(int id,String fieldName)
        {
           // Company com = stocky.Company.Where<id>;
           // CompanyDto dto = new CompanyDto(com.Id, com.Name, com.Phone, com.Email, com.Address, com.ShareValue, com.CurrentSeries, com.Status, com.Description, com.IconImage);

            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
