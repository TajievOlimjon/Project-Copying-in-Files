



namespace Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string? Author { get; set; }
        public string? QuoteText { get; set; }
        public int CategoryId { get; set; }
       

    }

   

    public class Quotes
    {
        public int QuoteId { get; set; }
        public string? QuoteAuthor { get; set; }
        public string? QuoteText { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}