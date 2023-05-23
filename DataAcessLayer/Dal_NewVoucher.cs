using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BuisnessAccessLayer;
using Microsoft.SqlServer.Server;
namespace DataAcessLayer
{
    public class Dal_NewVoucher:ConnectionString
    {

        public DataTable NewVoucherNo()
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
                sqlcom.CommandText = "spNewVocuherNo";
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



        public string InsertVoucher(clsVoucher clsvoucher)
        {
            int InsertVoucher = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spVoucher";
                sqlcom.Parameters.AddWithValue("@VoucherDescription", clsvoucher.VoucherDescription);
                sqlcom.Parameters.AddWithValue("@VDate", clsvoucher.VDate);
                sqlcom.Parameters.AddWithValue("@VoucherTypeId", clsvoucher.VoucherTypeId);
                sqlcom.Parameters.AddWithValue("@VNature","");
                InsertVoucher = Convert.ToInt32(sqlcom.ExecuteScalar());
                if (InsertVoucher > 0)
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
            return InsertVoucher + "";

        }
        public string UpdateVoucher(clsVoucher clsvoucher)
        {
            int UpdateVoucher = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spUpdateVoucher";
                sqlcom.Parameters.AddWithValue("@VoucherDescription", clsvoucher.VoucherDescription);
                sqlcom.Parameters.AddWithValue("@VDate", clsvoucher.VDate);
                sqlcom.Parameters.AddWithValue("@VoucherTypeId", clsvoucher.VoucherTypeId);
                sqlcom.Parameters.AddWithValue("@VNature", "");
                sqlcom.Parameters.AddWithValue("@VoucherNo", clsvoucher.VoucherNo);
                UpdateVoucher = sqlcom.ExecuteNonQuery();
                if (UpdateVoucher > 0)
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
            return UpdateVoucher + "";

        }
        
        /// <summary>
        /// Updating Post Status In Voucher 
        /// </summary>
        /// <param name="lstclsVoucher"></param>
        /// <returns></returns>
        public string PostedAndUnPostedVoucher(List<clsVoucher> lstclsVoucher)
        {
            int InsertVoucher = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                for (int i = 0; i < lstclsVoucher.Count; i++)
                {
                    
                    sqlcom = sqlcon.CreateCommand();
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.CommandText = "HPSS_Accounts.dbo.spPostingVoucher";
                    sqlcom.Parameters.AddWithValue("@VoucherNo", lstclsVoucher[i].VoucherNo);
                    sqlcom.Parameters.AddWithValue("@PostStatus", lstclsVoucher[i].Post);
                    sqlcom.Parameters.AddWithValue("@PostDate",DateTime.Now);
                    InsertVoucher = Convert.ToInt32(sqlcom.ExecuteNonQuery());   
                }
                if (InsertVoucher > 0)
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
            return InsertVoucher + "";

        }
        public string InsertSubVoucher(List<clsSubVoucher> clssubvoucher)
        {
            int InsertVoucher = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                for (int i = 0; i < clssubvoucher.Count; i++)
                {

                    sqlcom = sqlcon.CreateCommand();
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.CommandText = "spInsertSubVoucher";
                

                    sqlcom.Parameters.AddWithValue("@VNo", clssubvoucher[i].VoucherNo);
                    sqlcom.Parameters.AddWithValue("@CACode", clssubvoucher[i].CACode);
                    sqlcom.Parameters.AddWithValue("@ACName", clssubvoucher[i].ACName);
                    sqlcom.Parameters.AddWithValue("@ACType", clssubvoucher[i].ACType);
                    sqlcom.Parameters.AddWithValue("@Amount", clssubvoucher[i].Amount);
                    sqlcom.Parameters.AddWithValue("@ChecqueNo", clssubvoucher[i].ChequeNo);
                    sqlcom.Parameters.AddWithValue("@Balance", clssubvoucher[i].Balance);
                    sqlcom.Parameters.AddWithValue("@accountid", clssubvoucher[i].SubAccountId);

                    InsertVoucher = sqlcom.ExecuteNonQuery();
                   

                }
                if (InsertVoucher > 0)
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
            return InsertVoucher + "";

        }
        public string UpdateSubVoucher(List<clsSubVoucher> clssubvoucher)
        {
            int UpdateSubvoucher = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                for (int i = 0; i < clssubvoucher.Count; i++)
                {

                    sqlcom = sqlcon.CreateCommand();
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.CommandText = "spUpdateSubVoucher";


                    sqlcom.Parameters.AddWithValue("@VNo", clssubvoucher[i].VoucherNo);
                    sqlcom.Parameters.AddWithValue("@CACode", clssubvoucher[i].CACode);
                    sqlcom.Parameters.AddWithValue("@ACName", clssubvoucher[i].ACName);
                    sqlcom.Parameters.AddWithValue("@ACType", clssubvoucher[i].ACType);
                    sqlcom.Parameters.AddWithValue("@Amount", clssubvoucher[i].Amount);
                    sqlcom.Parameters.AddWithValue("@ChecqueNo", clssubvoucher[i].ChequeNo);
                    sqlcom.Parameters.AddWithValue("@Balance", clssubvoucher[i].Balance);
                    sqlcom.Parameters.AddWithValue("@SubAccountId", clssubvoucher[i].SubAccountId);
                    sqlcom.Parameters.AddWithValue("@SubVoucherNo", clssubvoucher[i].SubVoucherNo);

                    UpdateSubvoucher = sqlcom.ExecuteNonQuery();


                }
                if (UpdateSubvoucher > 0)
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
            return UpdateSubvoucher + "";

        }

        public DataTable FillDDLVoucherType()
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

        public DataTable FillAccountView()
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
                sqlcom.CommandText = "spFillAccountView";
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

        /// <summary>
        /// All Vouchers Are Getting to Edit and Delete
        /// </summary>
        /// <returns></returns>
        /// 
        public string DeleteVoucherAndRelatedSubVouchers(DataTable  dt)
        {
            int DeleteVoucher = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{

                //    sqlcom = sqlcon.CreateCommand();
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.CommandText = "spDelete";

                    sqlcom.Parameters.AddWithValue("@ids", dt).SqlDbType = SqlDbType.Structured;

                    
                    
                    DeleteVoucher = sqlcom.ExecuteNonQuery();


                //}
                
                    sqlcon.Close();
                    sqlcon.Dispose();
                

            }
            catch (Exception ex)
            {


                sqlcon.Close();
                sqlcon.Dispose();

                return ex.Message;

            }
            return DeleteVoucher + "";

        }


        /// <summary>
        /// Get Voucher For Delete
        /// </summary>
        /// <returns></returns>
        public DataTable GetVouchers()
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
                sqlcom.CommandText = "spGetVoucher";
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

        public DataTable GetVoucherWithWhereClause(clsVoucher cls)
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
                sqlcom.CommandText = "spGetVoucherWithWhereClause";
                sqlcom.Parameters.AddWithValue("@VoucherNO", cls.VoucherNo);
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


        public DataTable GetAmountWithDatatable(Object cls)
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
                sqlcom.CommandText = "spDebitAndCredit";
                sqlcom.Parameters.AddWithValue("@SubAccountId", cls.ToString());
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


        public DataTable GetAmount(clsSubVoucher cls)
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
                sqlcom.CommandText = "spDebitAndCredit";
                sqlcom.Parameters.AddWithValue("@SubAccountId",cls.SubAccountId);
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

        public DataTable GetAmountWhenUnPost(clsSubVoucher cls)
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
                sqlcom.CommandText = "spDebitAndCreditWhenUnpost";
                sqlcom.Parameters.AddWithValue("@SubAccountId", cls.SubAccountId);
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



        public DataTable GetSubVoucherWithWhereClause(clsVoucher cls)
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
                sqlcom.CommandText = "spGetSubVoucherWithWhereClause";
                sqlcom.Parameters.AddWithValue("@VoucherNo", cls.VoucherNo);
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


        /// <summary>
        /// Vouchers which status is zero
        /// </summary>
        /// <returns></returns>
        public DataTable UnPostVouchers()
        {
            List<clsVoucher> listvoucher = new List<clsVoucher>();
            clsVoucher cls = new clsVoucher();
            
            DataTable dt = new DataTable();
            int count = 0;
            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spUnpostVoucher";
                SqlDataReader sqlreader = sqlcom.ExecuteReader();
                dt.Load(sqlreader);

                //while (sqlreader.Read())
                //{
                //    cls = new clsVoucher();
                //    cls.VoucherNo = Convert.ToInt32(sqlreader["VoucherNo"]);
                //    cls.VoucherDescription = Convert.ToString(sqlreader["VoucherDescription"]);
                //    cls.VDate = Convert.ToDateTime(sqlreader["VDate"]);
                //    listvoucher.Add(cls);


                    
                //}


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

        /// <summary>
        /// Vouchers which status is one
        /// </summary>
        /// <returns></returns>
        public DataTable PostedVouchers()
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
                sqlcom.CommandText = "spPostVoucher";
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


        /// <summary>
        /// Get Debit and Credit SubVoucher 
        /// </summary>
        /// <returns></returns>
        public List<clsSubVoucher> GetPostedSubVoucherForDebitAndCredit(DataTable Dtvoucherno)
        {


            DataTable dtable = new DataTable();
            
            List<clsSubVoucher> listsubvoucher = new List<clsSubVoucher>();
            clsSubVoucher subvoucher = new clsSubVoucher();

            int count = 0;
            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spGetSubVoucherForDebitAndCredit";

                sqlcom.Parameters.AddWithValue("@ids", Dtvoucherno).SqlDbType = SqlDbType.Structured;

                SqlDataReader sqlreader = sqlcom.ExecuteReader();
                while (sqlreader.Read())
                {

                    subvoucher = new clsSubVoucher();
                    subvoucher.VoucherNo = Convert.ToInt32(sqlreader["VNo"].ToString());

                    subvoucher.CACode = Convert.ToString(sqlreader["CACode"]); //Convert.ToString(row.Cells["txtAcountCode"].Value);
                    subvoucher.ACName = Convert.ToString(sqlreader["ACName"]);
                    subvoucher.ACType = Convert.ToString(sqlreader["ACType"]);
                    subvoucher.Amount = Convert.ToString(sqlreader["Amount"]);
                    subvoucher.ChequeNo = Convert.ToString(sqlreader["ChecqueNo"]);
                    subvoucher.Balance = Convert.ToString(sqlreader["Balance"]);
                    subvoucher.SubAccountId = Convert.ToInt32(sqlreader["AccountId"].ToString());


                    if (subvoucher.CACode != "")
                    {
                        listsubvoucher.Add(subvoucher);
                    }
                }

            }
            catch (Exception ex)
            {

                
                sqlcon.Close();
                sqlcon.Dispose();
                return listsubvoucher = new List<clsSubVoucher>(); ;

            }
            return listsubvoucher;


        }

        /// <summary>
        /// NOt In use
        /// </summary>
        /// <param name="clssubvoucher"></param>
        /// <returns></returns>
        public string InsertPostedVoucher(List<clsSubVoucher> clssubvoucher)
        {
            int InsertVoucher = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                for (int i = 0; i < clssubvoucher.Count; i++)
                {

                    sqlcom = sqlcon.CreateCommand();
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.CommandText = "spInsertPostAndUnpostVoucher";


                    sqlcom.Parameters.AddWithValue("@VNo", clssubvoucher[i].VoucherNo);
                    sqlcom.Parameters.AddWithValue("@CACode", clssubvoucher[i].CACode);
                    sqlcom.Parameters.AddWithValue("@ACName", clssubvoucher[i].ACName);
                    sqlcom.Parameters.AddWithValue("@ACType", clssubvoucher[i].ACType);
                    sqlcom.Parameters.AddWithValue("@Amount", clssubvoucher[i].Amount);
                    sqlcom.Parameters.AddWithValue("@ChecqueNo", clssubvoucher[i].ChequeNo);
                    sqlcom.Parameters.AddWithValue("@Balance", clssubvoucher[i].Balance);
                    sqlcom.Parameters.AddWithValue("@SubAccountId", clssubvoucher[i].SubAccountId);

                    InsertVoucher = sqlcom.ExecuteNonQuery();


                }
                if (InsertVoucher > 0)
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
            return InsertVoucher + "";

        }




        #region unpost voucher

        public string DeleteAndUpdatePostedVoucherBalanceWhenUnpost(List<clsSubVoucher> clssubvoucher, DataTable dt)
        {
            int Update = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                for (int i = 0; i < clssubvoucher.Count; i++)
                {

                    sqlcom = sqlcon.CreateCommand();
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.CommandText = "spDeleteAndUpdateFromPostAndUnpostVoucher";
                    sqlcom.Parameters.AddWithValue("@VoucherId ", clssubvoucher[i].VoucherNo);
                    sqlcom.Parameters.AddWithValue("@CACode", clssubvoucher[i].CACode);
                    sqlcom.Parameters.AddWithValue("@Balance", clssubvoucher[i].Balance);
                    sqlcom.Parameters.AddWithValue("@ids", dt).SqlDbType = SqlDbType.Structured;

                    Update = sqlcom.ExecuteNonQuery();


                }
                if (Update > 0)
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
            return Update + "";

        }

        public string UpdatePostedVoucherBalanceWhenUnpost(List<clsSubVoucher> clssubvoucher)
        {
            int Update = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                for (int i = 0; i < clssubvoucher.Count; i++)
                {

                    sqlcom = sqlcon.CreateCommand();
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.CommandText = "spUpdatePostAndUnpostVouchers";
                    sqlcom.Parameters.AddWithValue("@CACode", clssubvoucher[i].CACode);
                    sqlcom.Parameters.AddWithValue("@Balance", clssubvoucher[i].Balance);
                    
                    Update = sqlcom.ExecuteNonQuery();


                }
                if (Update > 0)
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
            return Update + "";

        }


        public string DeletePostAndUnpostVoucher(DataTable dt)
        {
            int DeleteVoucher = 0;

            SqlConnection sqlcon = new SqlConnection(ConnString);
            SqlCommand sqlcom = new SqlCommand();
            try
            {
                sqlcom.Connection = sqlcon;
                sqlcon.Open();
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{

                //    sqlcom = sqlcon.CreateCommand();
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.CommandText = "spDeleteFromPostAndUnpostVoucher";

                sqlcom.Parameters.AddWithValue("@ids", dt).SqlDbType = SqlDbType.Structured;



                DeleteVoucher = sqlcom.ExecuteNonQuery();


                //}

                sqlcon.Close();
                sqlcon.Dispose();


            }
            catch (Exception ex)
            {


                sqlcon.Close();
                sqlcon.Dispose();

                return ex.Message;

            }
            return DeleteVoucher + "";

        }

        #endregion



        #region Account Activity Report Sp

        public DataTable AccountActivity(DataTable dtaccountid, clsReports rpt)
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
                sqlcom.CommandText = "sprptAccountActivity";
                sqlcom.Parameters.AddWithValue("@SubaccountId", dtaccountid);
                sqlcom.Parameters.AddWithValue("@DateFrom", rpt.DateFrom);
                sqlcom.Parameters.AddWithValue("@DateTo", rpt.DateTo);
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


        public DataTable AccountActivityrdlc(clsReports rpt)
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
                sqlcom.CommandText = "sprptAccountActivity";
                sqlcom.Parameters.AddWithValue("@SubAccountId", rpt.Id);
                sqlcom.Parameters.AddWithValue("@DateFrom", rpt.DateFrom);
                sqlcom.Parameters.AddWithValue("@DateTo", rpt.DateTo);
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


       
        

        #endregion



    }

}

