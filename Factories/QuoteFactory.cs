
using System.Collections.Generic;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using quotingDojo.Models;


namespace quotingDojo.Factory{
    public class QuoteFactory : IFactory<Quote>{
        private string connectionString;

        public QuoteFactory(){
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=asp-quotes;SslMode=None";
        }

        internal IDbConnection Connection{
            get{
                return new MySqlConnection(connectionString);
            }
        }












        public IEnumerable<Quote> GetAll(){
            using(IDbConnection dbConnection = Connection){
                dbConnection.Open();
                return dbConnection.Query<Quote>("SELECT * FROM quotes");
            }
        }



        public void AddQuote(Quote Item){
            using(IDbConnection dbConnection = Connection){
                string Query = "INSERT into quotes (Name, Content) VALUES (@Name, @Content)";
                dbConnection.Open();
                dbConnection.Execute(Query, Item);
            }
        }




    }
}