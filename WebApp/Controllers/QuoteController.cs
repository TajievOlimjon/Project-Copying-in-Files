using Microsoft.AspNetCore.Mvc;
using Service;
using Domain;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController : ControllerBase
    {
        private QuoteService quoteService;

        public QuoteController(QuoteService quoteService)
        {
            this.quoteService= quoteService;
        }


        [HttpGet("GetQuotes")]
        public List<Quotes> GetQuotes()
        {
            return quoteService.GetQuotes();
        }


        [HttpGet("GetQuotesByCategoryId")]
        public List<Quotes> GetQuotesByCategoryId(int Id)
        {
            return quoteService.GetQuotesByCategoryId(Id);
        }

        [HttpPost("InsertQuote")]
        public int InsertQuote(Quote quote)
        {
            return quoteService.InsertQuote(quote);
        }

        [HttpPut("UpdateQuote")]
        public int UpdateQuote(Quote quote, int Id)
        {
            return quoteService.UpdateQuote(quote,Id);
        }


        [HttpDelete("DeleteQuote")]
        public int DeleteQuote(int Id)
        {
            return quoteService.DeleteQuote(Id);
        }

        [HttpGet("GetQuoteRandom")]
        public Quote GetQuoteRandom()
        {
            return quoteService.GetQuoteRandom();
        }
    }
}
