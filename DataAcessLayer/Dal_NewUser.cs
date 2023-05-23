/*
 *  
 *  CEO :  Aurangzeb Ali 
 *  Created By : Senior Software Engineer : Aurangzeb Ali
 *  Company Name : 57Technologies
 *
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessAccessLayer;
using DataAcessLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAcessLayer
{
    public class Dal_NewUser: ConnectionString
    {


        public string InsertUser(clsUser cls)
        {
            int count = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spInsertUser";
                sqlcom.Parameters.AddWithValue("@UserName", cls.UserName);
                sqlcom.Parameters.AddWithValue("@Password", cls.Password);
                sqlcom.Parameters.AddWithValue("@Email", cls.Email);
                sqlcom.Parameters.AddWithValue("@PhoneNo", cls.PhoneNo);
                    
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
        public string UpdateUser(clsUser cls)
        {
            int count = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spUpdateUser";
                sqlcom.Parameters.AddWithValue("@UserName", cls.UserName);
                sqlcom.Parameters.AddWithValue("@Password", cls.Password);
                sqlcom.Parameters.AddWithValue("@Email", cls.Email);
                sqlcom.Parameters.AddWithValue("@PhoneNo", cls.PhoneNo);
                sqlcom.Parameters.AddWithValue("@UserId", cls.UserId);

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

        public string DeleteUser(clsUser cls)
        {
            int count = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spDeleteUser";
                sqlcom.Parameters.AddWithValue("@UserId", cls.UserId);

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

        public DataTable SelectAllUser()
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
                sqlcom.CommandText = "spSelectAllUser";
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
        public DataTable SelectUserWithWhereClause(clsUser cls)
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
                sqlcom.CommandText = "spSelectUserWithWhereClause";
                sqlcom.Parameters.AddWithValue("@Username", cls.UserName);
                sqlcom.Parameters.AddWithValue("@password", cls.Password);
                SqlDataReader sqlreader = sqlcom.ExecuteReader();
                dt.Load(sqlreader);

            }
            catch (Exception ex)
            {

                
                sqlcon.Close();
                sqlcon.Dispose();
                throw ex;

            }
            return dt;


        }


    }
}
