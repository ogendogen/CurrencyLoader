using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using CurrencyLoader.Models;

namespace CurrencyLoader
{
    public class QueryManager
    {
        public Database Database { get; set; }

        public QueryManager(Database database)
        {
            Database = database;
        }

        public int InsertToLAV(API api, APIV4 apiv4)
        {
            MySqlCommand comm = Database.dbConnection.CreateCommand();
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO `currencies_lav` SET currency1 = @curr1, date1 = @date1, CAD1 = @CAD1, HKD1 = @HKD1, ISK1 = @ISK1, PHP1 = @PHP1, DKK1 = @DKK1, HUF1 = @HUF1, CZK1 = @CZK1, GBP1 = @GBP1, RON1 = @RON1, SEK1 = @SEK1, ");
            query.Append("INR1 = @INR1, BRL1 = @BRL1, RUB1 = @RUB1, HRK1 = @HRK1, JPY1 = @JPY1, THB1 = @THB1, CHF1 = @CHF1, EUR1 = @EUR1, MYR1 = @MYR1, BGN1 = @BGN1, TRY1 = @TRY1, CNY1 = @CNY1, NOK1 = @NOK1, NZD1 = @NZD1, ZAR1 = @ZAR1,");
            query.Append("USD1 = @USD1, MXN1 = @MXN1, SGD1 = @SGD1, AUD1 = @AUD1, ILS1 = @ILS1, KRW1 = @KRW1, PLN1 = @PLN1,");

            query.Append("currency2 = @curr2, date2 = @date2, CAD2 = @CAD2, HKD2 = @HKD2, ISK2 = @ISK2, PHP2 = @PHP2, DKK2 = @DKK2, HUF2 = @HUF2, CZK2 = @CZK2, GBP2 = @GBP2, RON2 = @RON2, SEK2 = @SEK2, ");
            query.Append("INR2 = @INR2, BRL2 = @BRL2, RUB2 = @RUB2, HRK2 = @HRK2, JPY2 = @JPY2, THB2 = @THB2, CHF2 = @CHF2, EUR2 = @EUR2, MYR2 = @MYR2, BGN2 = @BGN2, TRY2 = @TRY2, CNY2 = @CNY2, NOK2 = @NOK2, NZD2 = @NZD2, ZAR2 = @ZAR2,");
            query.Append("USD2 = @USD2, MXN2 = @MXN2, SGD2 = @SGD2, AUD2 = @AUD2, ILS2 = @ILS2, KRW2 = @KRW2, PLN2 = @PLN2");

            comm.CommandText = query.ToString();

            comm.Parameters.AddWithValue("@curr1", api.@base);
            comm.Parameters.AddWithValue("@date1", api.date);
            comm.Parameters.AddWithValue("@CAD1", api.rates.CAD);
            comm.Parameters.AddWithValue("@HKD1", api.rates.HKD);
            comm.Parameters.AddWithValue("@ISK1", api.rates.ISK);
            comm.Parameters.AddWithValue("@PHP1", api.rates.PHP);
            comm.Parameters.AddWithValue("@DKK1", api.rates.DKK);
            comm.Parameters.AddWithValue("@HUF1", api.rates.HUF);
            comm.Parameters.AddWithValue("@CZK1", api.rates.CZK);
            comm.Parameters.AddWithValue("@GBP1", api.rates.GBP);
            comm.Parameters.AddWithValue("@RON1", api.rates.RON);
            comm.Parameters.AddWithValue("@SEK1", api.rates.SEK);
            comm.Parameters.AddWithValue("@INR1", api.rates.INR);
            comm.Parameters.AddWithValue("@BRL1", api.rates.BRL);
            comm.Parameters.AddWithValue("@RUB1", api.rates.RUB);
            comm.Parameters.AddWithValue("@HRK1", api.rates.HRK);
            comm.Parameters.AddWithValue("@JPY1", api.rates.JPY);
            comm.Parameters.AddWithValue("@THB1", api.rates.THB);
            comm.Parameters.AddWithValue("@CHF1", api.rates.CHF);
            comm.Parameters.AddWithValue("@EUR1", api.rates.EUR);
            comm.Parameters.AddWithValue("@MYR1", api.rates.MYR);
            comm.Parameters.AddWithValue("@BGN1", api.rates.BGN);
            comm.Parameters.AddWithValue("@TRY1", api.rates.TRY);
            comm.Parameters.AddWithValue("@CNY1", api.rates.CNY);
            comm.Parameters.AddWithValue("@NOK1", api.rates.NOK);
            comm.Parameters.AddWithValue("@NZD1", api.rates.NZD);
            comm.Parameters.AddWithValue("@ZAR1", api.rates.ZAR);
            comm.Parameters.AddWithValue("@USD1", api.rates.USD);
            comm.Parameters.AddWithValue("@MXN1", api.rates.MXN);
            comm.Parameters.AddWithValue("@SGD1", api.rates.SGD);
            comm.Parameters.AddWithValue("@AUD1", api.rates.AUD);
            comm.Parameters.AddWithValue("@ILS1", api.rates.ILS);
            comm.Parameters.AddWithValue("@KRW1", api.rates.KRW);
            comm.Parameters.AddWithValue("@PLN1", api.rates.PLN);

            comm.Parameters.AddWithValue("@curr2", apiv4.@base);
            comm.Parameters.AddWithValue("@date2", apiv4.date);
            comm.Parameters.AddWithValue("@CAD2", apiv4.rates.CAD);
            comm.Parameters.AddWithValue("@HKD2", apiv4.rates.HKD);
            comm.Parameters.AddWithValue("@ISK2", apiv4.rates.ISK);
            comm.Parameters.AddWithValue("@PHP2", apiv4.rates.PHP);
            comm.Parameters.AddWithValue("@DKK2", apiv4.rates.DKK);
            comm.Parameters.AddWithValue("@HUF2", apiv4.rates.HUF);
            comm.Parameters.AddWithValue("@CZK2", apiv4.rates.CZK);
            comm.Parameters.AddWithValue("@GBP2", apiv4.rates.GBP);
            comm.Parameters.AddWithValue("@RON2", apiv4.rates.RON);
            comm.Parameters.AddWithValue("@SEK2", apiv4.rates.SEK);
            comm.Parameters.AddWithValue("@INR2", apiv4.rates.INR);
            comm.Parameters.AddWithValue("@BRL2", apiv4.rates.BRL);
            comm.Parameters.AddWithValue("@RUB2", apiv4.rates.RUB);
            comm.Parameters.AddWithValue("@HRK2", apiv4.rates.HRK);
            comm.Parameters.AddWithValue("@JPY2", apiv4.rates.JPY);
            comm.Parameters.AddWithValue("@THB2", apiv4.rates.THB);
            comm.Parameters.AddWithValue("@CHF2", apiv4.rates.CHF);
            comm.Parameters.AddWithValue("@EUR2", apiv4.rates.EUR);
            comm.Parameters.AddWithValue("@MYR2", apiv4.rates.MYR);
            comm.Parameters.AddWithValue("@BGN2", apiv4.rates.BGN);
            comm.Parameters.AddWithValue("@TRY2", apiv4.rates.TRY);
            comm.Parameters.AddWithValue("@CNY2", apiv4.rates.CNY);
            comm.Parameters.AddWithValue("@NOK2", apiv4.rates.NOK);
            comm.Parameters.AddWithValue("@NZD2", apiv4.rates.NZD);
            comm.Parameters.AddWithValue("@ZAR2", apiv4.rates.ZAR);
            comm.Parameters.AddWithValue("@USD2", apiv4.rates.USD);
            comm.Parameters.AddWithValue("@MXN2", apiv4.rates.MXN);
            comm.Parameters.AddWithValue("@SGD2", apiv4.rates.SGD);
            comm.Parameters.AddWithValue("@AUD2", apiv4.rates.AUD);
            comm.Parameters.AddWithValue("@ILS2", apiv4.rates.ILS);
            comm.Parameters.AddWithValue("@KRW2", apiv4.rates.KRW);
            comm.Parameters.AddWithValue("@PLN2", apiv4.rates.PLN);

            int id = -1;
            var ret = comm.ExecuteScalar();
            return id;
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
