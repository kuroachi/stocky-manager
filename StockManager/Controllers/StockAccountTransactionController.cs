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
    public class StockAccountTransactionController : ControllerBase
    {
        StockyManagerContext stocky = new StockyManagerContext();

        // GET api/values
        [HttpGet]
        public dynamic GetStockAccountTransaction(string stockAccountId, string transactionId)
        {
            List<StockAccountTransaction> stockAccountTransaction;
            List<StockAccountTransactionDto> stockAccountTransactionDtos = new List<StockAccountTransactionDto>();

            stockAccountTransaction = stocky.StockAccountTransaction.ToList();

            if (stockAccountId == null && transactionId != null)
            {
                stockAccountTransaction = stocky.StockAccountTransaction.Where(e => e.StockAccountId == stockAccountId).ToList();
            }
            else if (stockAccountId == null && transactionId != null)
            {
                stockAccountTransaction = stocky.StockAccountTransaction.Where(e => e.TransactionId == transactionId).ToList();
            }
            else if (stockAccountId == null && transactionId == null)
            {
                stockAccountTransaction = stocky.StockAccountTransaction.ToList();
            }
            else
            {
                stockAccountTransaction = stocky.StockAccountTransaction.Where(e => e.StockAccountId == stockAccountId && e.TransactionId == transactionId).ToList();
            }


            foreach (StockAccountTransaction com in stockAccountTransaction)
            {

                StockAccountTransactionDto dto = new StockAccountTransactionDto(
                    com.Id, com.StockAccountId, com.TransactionId);
                stockAccountTransactionDtos.Add(dto);

            }
            return stockAccountTransactionDtos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public dynamic GetStockAccountTransaction(String id)
        {
            StockAccountTransaction com = stocky.StockAccountTransaction.Where(e => e.Id == id).FirstOrDefault();
            return new StockAccountTransactionDto(com.Id, com.StockAccountId, com.TransactionId);

        }
        //api/person/byName?firstName=a&lastName=b 

        [HttpPut("{id}")]
        public void PutStockAccountTransaction(String id, [FromBody] StockAccountTransactionDto stockAccountTransactionDto)
        {
            //  stocky.Company.Update(id, com); 
            StockAccountTransaction com = stocky.StockAccountTransaction.Where(e => e.Id == stockAccountTransactionDto.Id).Single<StockAccountTransaction>();
            com.Id = stockAccountTransactionDto.Id;
            com.StockAccountId = stockAccountTransactionDto.StockAccountId;
            com.TransactionId = stockAccountTransactionDto.TransactionId;
            stocky.Entry(com).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            stocky.SaveChanges();
        }

        [HttpPost]
        public void PostStockAccountTransaction([FromBody] StockAccountTransactionDto stockAccountTransactionDto)
        {
            StockAccountTransaction com = new StockAccountTransaction();
            com.Id = stockAccountTransactionDto.Id;
            com.StockAccountId = stockAccountTransactionDto.StockAccountId;
            com.TransactionId = stockAccountTransactionDto.TransactionId;
            stocky.StockAccountTransaction.Add(com);
            stocky.SaveChanges();
        }
    }
}