using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessAccessLayer;

namespace DataAcessLayer
{
    public class Dal_Reports:ConnectionString
    {
        public DataTable GetTrialBalanceReport(clsReports cls)
         {

             int count = 0;
             DataTable dt = new DataTable();

             SqlConnection sqlcon = new SqlConnection(ConnString);
             SqlCommand sqlcom = new SqlCommand();
             try
             {
                 sqlcom.Connection = sqlcon;
                 sqlcon.Open();
                 sqlcom.CommandType = CommandType.StoredProcedure;
                 sqlcom.CommandText = "spGetTrailFromSubAccounts2";
                 sqlcom.Parameters.AddWithValue("@DateFrom", cls.DateFrom); //"SELECT CAST ("+ cls.DateFrom + ")  AS DATETIME");
                 sqlcom.Parameters.AddWithValue("@DateTo ", cls.DateTo); //"SELECT CAST (" + cls.DateTo+ ")  AS DATETIME");

                 SqlDataReader sqlreader = sqlcom.ExecuteReader();
                 if (sqlreader.HasRows)
                 {
                     dt.Load(sqlreader);
                 }

             }
             catch (Exception ex)
             {
                 dt = new DataTable();

                 sqlcon.Close();
                 sqlcon.Dispose();
                 return dt;

             }
             return dt;


         }

        public DataTable GetTrialBalanceReportrdlc(clsReports cls)
        {

            int count = 0;
            DataTable dt = new DataTable();

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spGetTrailFromSubAccountsrdlc";
                sqlcom.Parameters.AddWithValue("@DateFrom", cls.DateFrom); //"SELECT CAST ("+ cls.DateFrom + ")  AS DATETIME");
                sqlcom.Parameters.AddWithValue("@DateTo ", cls.DateTo); //"SELECT CAST (" + cls.DateTo+ ")  AS DATETIME");

                SqlDataReader sqlreader = sqlcom.ExecuteReader();
                if (sqlreader.HasRows)
                {
                    dt.Load(sqlreader);
                }

            }
            catch (Exception ex)
            {
                dt = new DataTable();

                sqlcon.Close();
                sqlcon.Dispose();
                return dt;

            }
            return dt;


        }

  

        public DataTable GetIncomeStatementRevenueReport(clsReports cls)
        {

            int count = 0;
            DataTable dt = new DataTable();

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spIncomeStatementRevenue4";
                sqlcom.Parameters.AddWithValue("@DateFrom", cls.DateFrom);
                sqlcom.Parameters.AddWithValue("@DateTo ", cls.DateTo);

                SqlDataReader sqlreader = sqlcom.ExecuteReader();
                if (sqlreader.HasRows)
                {
                    dt.Load(sqlreader);
                }

            }
            catch (Exception ex)
            {
                dt = new DataTable();

                sqlcon.Close();
                sqlcon.Dispose();
                return dt;

            }
            return dt;


        }

        public DataTable GetIncomeStatementExpenseReport(clsReports cls)
        {

            int count = 0;
            DataTable dt = new DataTable();

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spIncomeStatementExpense5";
                sqlcom.Parameters.AddWithValue("@DateFrom", cls.DateFrom);
                sqlcom.Parameters.AddWithValue("@DateTo ", cls.DateTo);

                SqlDataReader sqlreader = sqlcom.ExecuteReader();
                if (sqlreader.HasRows)
                {
                    dt.Load(sqlreader);
                }

            }
            catch (Exception ex)
            {
                dt = new DataTable();

                sqlcon.Close();
                sqlcon.Dispose();
                return dt;

            }
            return dt;


        }

        public DataSet GetBalanceSheet(clsReports cls)
        {

            int count = 0;
            
            DataSet ds = new DataSet();

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spGetBalanceSheet";
                sqlcom.Parameters.AddWithValue("@DateFrom", cls.DateFrom);
                sqlcom.Parameters.AddWithValue("@DateTo ", cls.DateTo);
                SqlDataAdapter sqldataadapter = new SqlDataAdapter(sqlcom);
                sqldataadapter.Fill(ds);

            }
            catch (Exception ex)
            {
                ds = new DataSet();

                sqlcon.Close();
                sqlcon.Dispose();
                return ds;

            }
            return ds;


        }


    }
}
