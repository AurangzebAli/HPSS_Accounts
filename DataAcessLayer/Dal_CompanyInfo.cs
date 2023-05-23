using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessAccessLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAcessLayer
{
    public class Dal_CompanyInfo : ConnectionString
    {

        public string UpdateCompanyInfo(clsCompanyInfo clsCompanyInfo)
        {
            int UpdateCInfo = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spUpdateCompanyInfo";
                sqlcom.Parameters.AddWithValue("@Code", clsCompanyInfo.Code);
                sqlcom.Parameters.AddWithValue("@Name", clsCompanyInfo.Name);
                sqlcom.Parameters.AddWithValue("@Address", clsCompanyInfo.Address);
                sqlcom.Parameters.AddWithValue("@Phone", clsCompanyInfo.Phone);
                sqlcom.Parameters.AddWithValue("@Email", clsCompanyInfo.Email);
                UpdateCInfo = sqlcom.ExecuteNonQuery();
                if (UpdateCInfo > 0)
                {
                    sqlcon.Close();
                    sqlcon.Dispose();
                }

            }
            catch (Exception ex)
            {


                sqlcon.Close();
                sqlcon.Dispose();

                return ex.Message;

            }
            return UpdateCInfo + "";

        }


        public DataTable SelectCompanyInfo()
        {

            DataTable dt = new DataTable();
            int count = 0;
            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spCompanyInfo";
                
                SqlDataReader sqlreader = sqlcom.ExecuteReader();
                dt.Load(sqlreader);

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


    }
}
