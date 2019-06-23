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
    public class CompanyController : ControllerBase
    {

        StockyManagerContext stocky = new StockyManagerContext();

        // GET api/values
        [HttpGet]
        public dynamic GetCompanies(String name, String currentSeries)
        {
            List<Company> company;
            List<CompanyDto> companyDtos = new List<CompanyDto>();

            if (name == null && currentSeries != null)
            {
                company = stocky.Company.Where(e => e.CurrentSeries == currentSeries).ToList();
            }
            else if (currentSeries == null && name != null)
            {
                company = stocky.Company.Where(e => e.Name == name).ToList();
            } 
            else if (currentSeries == null && name == null)
            {
                company = stocky.Company.ToList();
            }
            else
            {
                company = stocky.Company.Where(e => e.CurrentSeries == currentSeries && e.Name == name).ToList();
            }

            foreach (Company com in company)
            {

                CompanyDto dto = new CompanyDto(com.Id, com.Name, com.Phone, com.Email, com.Address, com.ShareValue, com.CurrentSeries, com.Status, com.Description, com.IconImage);
                companyDtos.Add(dto);

            }
            return companyDtos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public dynamic GetCompany(String id)
        {  
                Company com = stocky.Company.Where(e => e.Id == id).FirstOrDefault();
                return new CompanyDto(com.Id, com.Name, com.Phone, com.Email, com.Address, com.ShareValue, com.CurrentSeries, com.Status, com.Description, com.IconImage);
          
        }
        //api/person/byName?firstName=a&lastName=b 

        [HttpPut("{id}")]
        public void PutCompany(String id, [FromBody] CompanyDto companyDto)
        { 
          //  stocky.Company.Update(id, com); 
            Company com = stocky.Company.Where(e => e.Id == companyDto.Id).Single<Company>();
            com.Id = companyDto.Id;
            com.Name = companyDto.Name;
            com.Phone = companyDto.Phone;
            com.Email = companyDto.Email;
            com.Address = companyDto.Address;
            com.ShareValue = companyDto.ShareValue;
            com.CurrentSeries = companyDto.CurrentSeries;
            com.Status = companyDto.Status;
            com.Description = companyDto.Description;
            com.IconImage = companyDto.IconImage;
            stocky.Entry(com).State =  Microsoft.EntityFrameworkCore.EntityState.Modified;
            stocky.SaveChanges();
        }

        [HttpPost]
        public void PostCompany([FromBody] CompanyDto companyDto)
        {
            Company com = new Company();
            com.Id = companyDto.Id;
            com.Name = companyDto.Name;
            com.Phone = companyDto.Phone;
            com.Email = companyDto.Email;
            com.Address = companyDto.Address;
            com.ShareValue = companyDto.ShareValue;
            com.CurrentSeries = companyDto.CurrentSeries;
            com.Status = companyDto.Status;
            com.Description = companyDto.Description;
            com.IconImage = companyDto.IconImage; 
            stocky.Company.Add(com);
            stocky.SaveChanges();
        }  


    }
}