using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CurrencyLoader
{
    public class QueryManager
    {
        public Database Database { get; set; }

        public QueryManager(Database database)
        {
            Database = database;
        }

        public int InsertToGAV(string sourceCurrency, string date, double CAD,
            double HKD, double ISK, double PHP, double DKK, double HUF,
            double CZK, double GBP, double RON, double SEK, double INR,
            double BRL, double RUB, double HRK, double JPY, double THB,
            double CHF, double EUR, double MYR, double BGN, double TRY,
            double CNY, double NOK, double NZD, double ZAR, double USD,
            double MXN, double SGD, double AUD, double ILS, double KRW,
            double PLN)
        {
            MySqlCommand comm = Database.dbConnection.CreateCommand();
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO `currencies_gav` SET currency = @curr, date = @date, CAD = @CAD, HKD = @HKD, ISK = @ISK, PHP = @PHP, DKK = @DKK, HUF = @HUF, CZK = @CZK, GBP = @GBP, RON = @RON, SEK = @SEK, ");
            query.Append("INR = @INR, BRL = @BRL, RUB = @RUB, HRK = @HRK, JPY = @JPY, THB = @THB, CHF = @CHF, EUR = @EUR, MYR = @MYR, BGN = @BGN, TRY = @TRY, CNY = @CNY, NOK = @NOK, NZD = @NZD, ZAR = @ZAR,");
            query.Append("USD = @USD, MXN = @MXN, SGD = @SGD, AUD = @AUD, ILS = @ILS, KRW = @KRW, PLN = @PLN");
            comm.CommandText = query.ToString();

            comm.Parameters.AddWithValue("@curr", sourceCurrency);
            comm.Parameters.AddWithValue("@date", date);
            comm.Parameters.AddWithValue("@CAD", CAD);
            comm.Parameters.AddWithValue("@HKD", HKD);
            comm.Parameters.AddWithValue("@ISK", ISK);
            comm.Parameters.AddWithValue("@PHP", PHP);
            comm.Parameters.AddWithValue("@DKK", DKK);
            comm.Parameters.AddWithValue("@HUF", HUF);
            comm.Parameters.AddWithValue("@CZK", CZK);
            comm.Parameters.AddWithValue("@GBP", GBP);
            comm.Parameters.AddWithValue("@RON", RON);
            comm.Parameters.AddWithValue("@SEK", SEK);
            comm.Parameters.AddWithValue("@INR", INR);
            comm.Parameters.AddWithValue("@BRL", BRL);
            comm.Parameters.AddWithValue("@RUB", RUB);
            comm.Parameters.AddWithValue("@HRK", HRK);
            comm.Parameters.AddWithValue("@JPY", JPY);
            comm.Parameters.AddWithValue("@THB", THB);
            comm.Parameters.AddWithValue("@CHF", CHF);
            comm.Parameters.AddWithValue("@EUR", EUR);
            comm.Parameters.AddWithValue("@MYR", MYR);
            comm.Parameters.AddWithValue("@BGN", BGN);
            comm.Parameters.AddWithValue("@TRY", TRY);
            comm.Parameters.AddWithValue("@CNY", CNY);
            comm.Parameters.AddWithValue("@NOK", NOK);
            comm.Parameters.AddWithValue("@NZD", NZD);
            comm.Parameters.AddWithValue("@ZAR", ZAR);
            comm.Parameters.AddWithValue("@USD", USD);
            comm.Parameters.AddWithValue("@MXN", MXN);
            comm.Parameters.AddWithValue("@SGD", SGD);
            comm.Parameters.AddWithValue("@AUD", AUD);
            comm.Parameters.AddWithValue("@ILS", ILS);
            comm.Parameters.AddWithValue("@KRW", KRW);
            comm.Parameters.AddWithValue("@PLN", PLN);

            int id = -1;
            var ret = comm.ExecuteScalar();
            return id;
        }
    }
}
