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
    public class TransactionTypeController : ControllerBase
    {
        StockyManagerContext stocky = new StockyManagerContext();

        // GET api/values
        [HttpGet]
        public dynamic GetTransactionType()
        {
            List<TransactionType> transactionType;
            List<TransactionTypeDto> transactionTypeDtos = new List<TransactionTypeDto>();

            transactionType = stocky.TransactionType.ToList();

            foreach (TransactionType com in transactionType)
            {

                TransactionTypeDto dto = new TransactionTypeDto(
                    com.Id, com.Type);
                transactionTypeDtos.Add(dto);

            }
            return transactionTypeDtos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public dynamic GetTransactionType(String id)
        {
            TransactionType com = stocky.TransactionType.Where(e => e.Id == id).FirstOrDefault();
            return new TransactionTypeDto(com.Id, com.Type);

        }
        //api/person/byName?firstName=a&lastName=b 

        [HttpPut("{id}")]
        public void PutTransactionType(String id, [FromBody] TransactionTypeDto transactionTypeDto)
        {
            //  stocky.Company.Update(id, com); 
            TransactionType com = stocky.TransactionType.Where(e => e.Id == transactionTypeDto.Id).Single<TransactionType>();
            com.Id = transactionTypeDto.Id;
            com.Type = transactionTypeDto.Type;
            stocky.Entry(com).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            stocky.SaveChanges();
        }

        [HttpPost]
        public void PostTransactionType([FromBody] TransactionTypeDto transactionTypeDto)
        {
            TransactionType com = new TransactionType();
            com.Id = transactionTypeDto.Id;
            com.Type = transactionTypeDto.Type;
            stocky.TransactionType.Add(com);
            stocky.SaveChanges();
        }
    }
}