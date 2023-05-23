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
    /// <summary>
    /// Master and Detail of Accounts
    /// </summary>
    public class Dal_Accounts:ConnectionString
    {
        public string InsertAccountsChart(clsAccounts clsaccounts)
        {
            int count = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spInsertAccountChart";
                sqlcom.Parameters.AddWithValue("@Code", clsaccounts.AccountCode);
                sqlcom.Parameters.AddWithValue("@AcouuntTitle", clsaccounts.AccountTitle);
                sqlcom.Parameters.AddWithValue("@Nature", clsaccounts.Nature);
                sqlcom.Parameters.AddWithValue("@TypeControl", clsaccounts.TypeControl);
                sqlcom.Parameters.AddWithValue("@Parent", clsaccounts.ParentId.ToString());

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
        public string InsertSubAccountsChart(clsAccounts clsaccounts)
        {
            int count = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spInsertSubChartAccount";
                sqlcom.Parameters.AddWithValue("@SubCode", clsaccounts.AccountCode);
                sqlcom.Parameters.AddWithValue("@SubAccountTitle ", clsaccounts.AccountTitle);
                sqlcom.Parameters.AddWithValue("@subNature", clsaccounts.Nature);
                sqlcom.Parameters.AddWithValue("@subTypeControl", clsaccounts.TypeControl);
                sqlcom.Parameters.AddWithValue("@AccountId", clsaccounts.AccountId);
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

        public clsAccounts ChartAccountCode(clsAccounts clsaccounts)
        {
            int count = 0;
            clsAccounts cls = new clsAccounts();
            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            SqlDataReader sqldatareader;
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spChartAccountCode1";
                sqlcom.Parameters.AddWithValue("@accountcode", clsaccounts.AccountCode);
                
                
                
                sqldatareader = sqlcom.ExecuteReader();
                while (sqldatareader.Read())
                {
                    cls.AccountCode = sqldatareader[0].ToString();
                }

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

                return cls;

            }
            return cls;

        }



        public clsAccounts IsCheckSubAccountCode(clsAccounts clsaccounts)
        {
            int count = 0;
            clsAccounts cls = new clsAccounts();
            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            SqlDataReader sqldatareader;
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spChartAccountCode";
                sqlcom.Parameters.AddWithValue("@subaccountcode", clsaccounts);
                sqldatareader = sqlcom.ExecuteReader();
                while (sqldatareader.Read())
                {
                    cls.AccountCode = sqldatareader[0].ToString();
                }

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

                return cls;

            }
            return cls;

        }



        public string UpdateAccountsChart(clsAccounts clsaccounts)
        {
            int count = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spUpdateChartAccount";
                sqlcom.Parameters.AddWithValue("@Code", clsaccounts.AccountCode);
                sqlcom.Parameters.AddWithValue("@AccountTitle", clsaccounts.AccountTitle);
                sqlcom.Parameters.AddWithValue("@Nature", clsaccounts.Nature);
                sqlcom.Parameters.AddWithValue("@TypeControl", clsaccounts.TypeControl);
                sqlcom.Parameters.AddWithValue("@AcountId", clsaccounts.AccountId);
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

        public string UpdateSubAccountsChart(clsAccounts clsaccounts)
        {
            int count = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spUpdateSubChartAccount";
                sqlcom.Parameters.AddWithValue("@SubCode", clsaccounts.AccountCode);
                sqlcom.Parameters.AddWithValue("@SubAccountTitle", clsaccounts.SubAccountTitle);
                sqlcom.Parameters.AddWithValue("@subNature", clsaccounts.Nature);
                sqlcom.Parameters.AddWithValue("@subTypeControl", clsaccounts.TypeControl);
                sqlcom.Parameters.AddWithValue("@SubAccountId", clsaccounts.SubAccountId);
                
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


        public List<clsAccounts> SelectChartAccountForTreeView()
        {
            List<clsAccounts> list = new List<clsAccounts>();
            clsAccounts clsaccounts;
            int count = 0;
            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "SpTree";//spChartsAccount
                SqlDataReader sqlreader = sqlcom.ExecuteReader();
                while(sqlreader.Read())
                {
                    clsaccounts = new clsAccounts();
                    clsaccounts.AccountId = Convert.ToInt32(sqlreader["AcountId"].ToString());
                    clsaccounts.AccountCode = sqlreader["Code"].ToString();
                    clsaccounts.AccountTitle = sqlreader["AcouuntTitle"].ToString();
                    clsaccounts.ParentId = sqlreader["PID"].ToString() == "" ? 0 : Convert.ToInt32(sqlreader["PID"].ToString());
                    clsaccounts.TypeControl = sqlreader["TypeControl"].ToString();
                    list.Add(clsaccounts);
                }

            }
            catch (Exception ex)
            {

                
                sqlcon.Close();
                sqlcon.Dispose();
                return list;

            }
            return list;


        }

        public List<clsAccounts> SelectChartAccountForParentTreeView()
        {
            List<clsAccounts> list = new List<clsAccounts>();
            clsAccounts clsaccounts;
            int count = 0;
            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spChartsAccountWithParentChildNode";
                SqlDataReader sqlreader = sqlcom.ExecuteReader();
                while (sqlreader.Read())
                {
                    clsaccounts = new clsAccounts();
                    clsaccounts.AccountId = Convert.ToInt32(sqlreader["AcountId"].ToString());
                    clsaccounts.AccountCode = sqlreader["Code"].ToString();
                    clsaccounts.AccountTitle = sqlreader["AcouuntTitle"].ToString();
                    list.Add(clsaccounts);
                }

            }
            catch (Exception ex)
            {


                sqlcon.Close();
                sqlcon.Dispose();
                return list;

            }
            return list;


        }
        

        public List<clsAccounts> SelectSubChartAccountForTreeView()
        {
            List<clsAccounts> list = new List<clsAccounts>();
            clsAccounts clsaccounts;
            int count = 0;
            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spSubChartAccount";
                SqlDataReader sqlreader = sqlcom.ExecuteReader();
                while (sqlreader.Read())
                {
                    clsaccounts = new clsAccounts();
                    clsaccounts.SubAccountId = Convert.ToInt32(sqlreader["SubAccountId"].ToString());
                    clsaccounts.SubAccountTitle = sqlreader["SubAccountTitle"].ToString();
                    clsaccounts.AccountId = Convert.ToInt32(sqlreader["AccountId"].ToString());
                    clsaccounts.AccountCode = sqlreader["SubCode"].ToString();
                    list.Add(clsaccounts);
                }

            }
            catch (Exception ex)
            {


                sqlcon.Close();
                sqlcon.Dispose();
                return list;

            }
            return list;


        }
        public clsAccounts SelectChartAccountForTreeViewWithWhereClause(clsAccounts clsaccount)
        {
            
            clsAccounts clsaccounts = new clsAccounts();
            int count = 0;
            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spChartsAccountWithWhereClause";
                sqlcom.Parameters.AddWithValue("@AccountId", clsaccount.AccountId);
                SqlDataReader sqlreader = sqlcom.ExecuteReader();
                while (sqlreader.Read())
                {
                    clsaccounts = new clsAccounts();
                    clsaccounts.AccountId = Convert.ToInt32(sqlreader["AcountId"].ToString());
                    clsaccounts.AccountCode = sqlreader["Code"].ToString();
                    clsaccounts.AccountTitle = sqlreader["AcouuntTitle"].ToString();
                    clsaccounts.Nature = sqlreader["Nature"].ToString();
                    clsaccounts.TypeControl = sqlreader["TypeControl"].ToString();
                }

            }
            catch (Exception ex)
            {


                sqlcon.Close();
                sqlcon.Dispose();
                return clsaccounts;

            }
            return clsaccounts;


        }

        public clsAccounts SelectSubChartAccountForTreeViewWithWhereClause(clsAccounts cls)
        {

            
            clsAccounts clsaccounts = new clsAccounts();
            int count = 0;
            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spSubChartAccountWithWhereClause";
                sqlcom.Parameters.AddWithValue("@SubAccountId", cls.SubAccountId);
                SqlDataReader sqlreader = sqlcom.ExecuteReader();
                while (sqlreader.Read())
                {
                    clsaccounts = new clsAccounts();
                    clsaccounts.SubAccountId = Convert.ToInt32(sqlreader["SubAccountId"].ToString());
                    clsaccounts.AccountCode = sqlreader["SubCode"].ToString();
                    clsaccounts.SubAccountTitle = sqlreader["SubAccountTitle"].ToString();
                    clsaccounts.Nature = sqlreader["subNature"].ToString();
                    clsaccounts.TypeControl = sqlreader["subTypeControl"].ToString();
                    clsaccounts.AccountId = Convert.ToInt32(sqlreader["AccountId"].ToString());

                    
                }

            }
            catch (Exception ex)
            {


                sqlcon.Close();
                sqlcon.Dispose();
                return clsaccounts ;

            }
            return clsaccounts;

        
        }

        public string DeleteChartAccount(clsAccounts cls)
        { 
               int count = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spDeleteChartAccount";
                sqlcom.Parameters.AddWithValue("@AccountId", cls.AccountId);
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

        public DataTable DDLControlTransaction()
        {
            List<clsAccounts> list = new List<clsAccounts>();
            DataTable dt = new DataTable();
            
            int count = 0;
            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spChartControlTransaction";
                SqlDataReader sqlreader = sqlcom.ExecuteReader();
                dt.Load(sqlreader);

            }
            catch (Exception ex)
            {


                sqlcon.Close();
                sqlcon.Dispose();
                return dt;

            }
            return dt;


        }
        
    }
}
