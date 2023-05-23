using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BuisnessAccessLayer;

namespace DataAcessLayer
{
    public class Dal_VoucherType:ConnectionString
    {

        public string InsertVoucherType(clsVoucherType clsVouchertype)
        {
            int count = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spInsertVoucherType";
                sqlcom.Parameters.AddWithValue("@Type", clsVouchertype.Type);
                sqlcom.Parameters.AddWithValue("@Description", clsVouchertype.Description);
                count = sqlcom.ExecuteNonQuery();
                if (count >0)
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
            return count + "";

        }
        public string UpdateVoucherType(clsVoucherType clsVouchertype)
        {
            int count = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spUpdateVoucherType";
                sqlcom.Parameters.AddWithValue("@TypeId", clsVouchertype.TypeId);
                sqlcom.Parameters.AddWithValue("@Type", clsVouchertype.Type);
                sqlcom.Parameters.AddWithValue("@Description", clsVouchertype.Description);
                count = sqlcom.ExecuteNonQuery();
                if (count > 0)
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
            return count + "";

        }

        public string DeleteVoucherType(clsVoucherType clsVouchertype)
        {
            int count = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spDeleteVoucherType";
                sqlcom.Parameters.AddWithValue("@TypeId", clsVouchertype.TypeId);
                count = sqlcom.ExecuteNonQuery();
                if (count > 0)
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
            return count + "";

        }
        public DataTable SelectVoucherType()
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
                sqlcom.CommandText = "spSelectVoucherType";
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
        public DataTable SelectVoucherTypeWithWhereClause(int voucherid)
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
                sqlcom.CommandText = "spSelectVoucherTypeWhereClause";
                sqlcom.Parameters.AddWithValue("@WHEREClause", voucherid);
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
