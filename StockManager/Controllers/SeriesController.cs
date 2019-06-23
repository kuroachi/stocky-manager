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
    public class SeriesController : ControllerBase
    {
        StockyManagerContext stocky = new StockyManagerContext();

        // GET api/values
        [HttpGet]
        public dynamic GetSeries(String companyID)
        {
            List<Series> series;
            List<SeriesDto> seriesDtos = new List<SeriesDto>();

            if (companyID != null)
            {
                series = stocky.Series.Where(e => e.CompanyId == companyID).ToList();
            } 
            else
            {
                series = stocky.Series.ToList();
            }

            foreach (Series seri in series)
            { 
                SeriesDto dto = new SeriesDto(
            seri.Id, seri.OpenTime, seri.CloseTime, seri.PreMoney, seri.PostMoney, seri.CompanyId);
                seriesDtos.Add(dto);

            }
            return seriesDtos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public dynamic GetSeri(String id)
        {
            Series seri = stocky.Series.Where(e => e.Id == id).FirstOrDefault();
            return new SeriesDto(
            seri.Id, seri.OpenTime, seri.CloseTime, seri.PreMoney, seri.PostMoney, seri.CompanyId);
        }
        //api/person/byName?firstName=a&lastName=b 

        [HttpPut("{id}")]
        public void PutSeries(String id, [FromBody] SeriesDto seriesDto)
        {
            //  stocky.Company.Update(id, com); 
            Series com = stocky.Series.Where(e => e.Id == seriesDto.Id).Single<Series>();
            com.Id = seriesDto.Id;
            com.OpenTime = seriesDto.OpenTime;
            com.CloseTime = seriesDto.CloseTime;
            com.PreMoney = seriesDto.PreMoney;
            com.PostMoney = seriesDto.PostMoney;
            com.CompanyId = seriesDto.CompanyId;  
            stocky.Entry(com).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            stocky.SaveChanges();
        }

        [HttpPost]
        public void PostSeries([FromBody] SeriesDto seriesDto)
        {
            Series com = new Series();
            com.Id = seriesDto.Id;
            com.OpenTime = seriesDto.OpenTime;
            com.CloseTime = seriesDto.CloseTime;
            com.PreMoney = seriesDto.PreMoney;
            com.PostMoney = seriesDto.PostMoney;
            com.CompanyId = seriesDto.CompanyId;
            stocky.Series.Add(com);
            stocky.SaveChanges();
        }

    }
}