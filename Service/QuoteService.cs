using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service
{
    public class QuoteService
    {
        private string connectionString = "Server=localhost;Port=5432;Database=Quote;User Id=postgres;Password=0711;";



        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        public List<Quotes> GetQuotes()
        {
            using (var con = GetConnection())
            {
                var sql = " select Q.Id  as  QuoteId , Q.Author as QuoteAuthor , Q.QuoteText, C.Id as CategoryId, C.Name as CategoryName " +
                          " from Quote as Q " +
                          " join Category as C on C.Id=Q.CategoryId ";
                var list = con.Query<Quotes>(sql);
                return list.ToList();
            }
        }

        public List<Quotes> GetQuotesByCategoryId(int Id)
        {
            using (var con = GetConnection())
            {
                var sql = $" select Q.Id as  QuoteId ,Q.Author as QuoteAuthor ,Q.QuoteText,C.Id as CategoryId,C.Name as CategoryName " +
                          $" from Quote as Q " +
                          $" join Category as C on C.Id=Q.CategoryId  Where C.Id={Id}";
                var list = con.Query<Quotes>(sql);
                return list.ToList();
            }
        }


        public int InsertQuote(Quote quote)
        {
            using (var con=GetConnection())
            {
                var sql = $" Insert into Quote(Author,QuoteText,CategoryId) " +
                          $" values('{quote.Author}','{quote.QuoteText}',{quote.CategoryId}) ";
                var insert = con.Execute(sql);
                return insert;

            }
        }

        public int UpdateQuote(Quote quote,int Id)
        {
            using (var con=GetConnection())
            {
                var sql = $" Update Quote  " +
                          $" Set  " +
                          $" Author='{quote.Author}' ,  " +
                          $" QuoteText='{quote.QuoteText}' , " +
                          $" CategoryId={quote.CategoryId}  " +
                          $" Where Id={Id} ";
                var update = con.Execute(sql);
                return update;
            }
        }

        public int DeleteQuote(int Id)
        {
            using (var con=GetConnection())
            {
                var sql = $" Delete from Quote where Id={Id} ";
                var delete=con.Execute(sql);
                return delete;

            }
        }

        public Quote GetQuoteRandom()
        {
            using (var con =GetConnection())
            {
                var sql = " select * from Quote ORDER BY RANDOM() ";
                var rnd = con.QueryFirstOrDefault<Quote>(sql);
                return rnd;

            }
        }
       
       

    }
}
