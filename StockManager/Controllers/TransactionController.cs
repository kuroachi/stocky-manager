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
    public class TransactionController : ControllerBase
    {
        StockyManagerContext stocky = new StockyManagerContext();

        // GET api/values
        [HttpGet]
        public dynamic GetTransaction(String seriesID, String transaction_TypeID)
        {
            List<Transaction> transaction;
            List<TransactionDto> transactionDtos = new List<TransactionDto>();

            if (seriesID == null && transaction_TypeID != null)
            {
                transaction = stocky.Transaction.Where(e => e.TransactionTypeId == transaction_TypeID).ToList();
            }
            else if (transaction_TypeID == null && seriesID != null)
            {
                transaction = stocky.Transaction.Where(e => e.SeriesId == seriesID).ToList();
            }
            else if (seriesID == null && transaction_TypeID == null)
            {
                transaction = stocky.Transaction.ToList();
            }
            else
            {
                transaction = stocky.Transaction.Where(e => e.SeriesId == seriesID && e.TransactionTypeId == transaction_TypeID).ToList();
            }
             
            foreach (Transaction com in transaction)
            {

                TransactionDto dto = new TransactionDto(
                   com.Id, com.TransactionTime, com.Status, com.SharesQuantity, com.TimeApprove, com.SeriesId,com.TransactionTypeId);
                transactionDtos.Add(dto);

            }
            return transactionDtos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public dynamic GetTransaction(String id)
        {
            Transaction com = stocky.Transaction.Where(e => e.Id == id).FirstOrDefault();
            return new TransactionDto(com.Id, com.TransactionTime, com.Status, com.SharesQuantity, com.TimeApprove, com.SeriesId, com.TransactionTypeId);

        }
        //api/person/byName?firstName=a&lastName=b 

        [HttpPut("{id}")]
        public void PutTransaction(String id, [FromBody] TransactionDto transactionDto)
        {
            //  stocky.Company.Update(id, com); 
            Transaction com = stocky.Transaction.Where(e => e.Id == transactionDto.Id).Single<Transaction>();
            com.Id = transactionDto.Id;
            com.TransactionTime = transactionDto.TransactionTime;
            com.SharesQuantity = transactionDto.SharesQuantity;
            com.TimeApprove = transactionDto.TimeApprove;
            com.SeriesId = transactionDto.SeriesId;
            com.TransactionTypeId = transactionDto.TransactionTypeId; 
            com.Status = transactionDto.Status; 
            stocky.Entry(com).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            stocky.SaveChanges();
        }

        [HttpPost]
        public void PostTransaction([FromBody] TransactionDto transactionDto)
        {
            Transaction com = new Transaction();
            com.Id = transactionDto.Id;
            com.TransactionTime = transactionDto.TransactionTime;
            com.SharesQuantity = transactionDto.SharesQuantity;
            com.TimeApprove = transactionDto.TimeApprove;
            com.SeriesId = transactionDto.SeriesId;
            com.TransactionTypeId = transactionDto.TransactionTypeId;
            com.Status = transactionDto.Status;
            stocky.Transaction.Add(com);
            stocky.SaveChanges();
        }

    }
}