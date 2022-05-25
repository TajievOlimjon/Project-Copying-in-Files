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
            this.quoteService = quoteService;
           
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
        public int InsertQuote([FromForm]Quote quote)
        {
            return quoteService.InsertQuote(quote);
        }

        

        //[HttpPost("InsertQuoteFormFile")]
        //public async Task<int> InsertQuoteFormFile([FromForm] Quote quote)
        //{
        //    return await quoteService.InsertQuoteFormFile(quote);
        //}
        //[HttpPost("InsertFile")]
        //public string InsertFile(List<IFormFile> formFile)
        //{
        //   if(formFile.Count != 0)
        //    {
        //        foreach (var file in formFile)
        //        {
        //            var root = hostEnvironment.ContentRootPath;
        //            var path = Path.Combine(root, "Uploads", file.FileName);
        //            using (var fileStream = new FileStream(path, FileMode.Create))
        //            {
        //                file.CopyTo(fileStream);
        //            }

        //        }

        //        return "Saved!!!";
        //    }
        //    return "Not Saved!";
        //}


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
