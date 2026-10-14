using System;
using System.Data;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for ChequeEntryController.
	/// </summary>
	public class ChequeEntryController
	{
		public ChequeEntryController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public string InsertChequeEntry(int p_distributorId, int p_Principal_id, long p_Customer_Id, string p_Cheque_No, string p_Bank_Name, DateTime p_Cheque_Date, DateTime p_Received_Date, DateTime p_Deposit_Date, DateTime p_Realization_Date, decimal p_Cheque_Amount, int p_Status_Id, DateTime p_Time_Stamp, int p_User_Id, string p_SlipNo, string p_Remarks,long p_AccountHead,int p_SaleManId)
		{
			IDbConnection mConnection = null;
			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			  	mConnection.Open();
                spInsertCHEQUE_PROCESS mspInsertCheque_Entry = new spInsertCHEQUE_PROCESS();
                mspInsertCheque_Entry.Connection = mConnection;
                mspInsertCheque_Entry.DISTRIBUTOR_ID = p_distributorId;
                mspInsertCheque_Entry.PRINCIPAL_ID = p_Principal_id;  
                mspInsertCheque_Entry.CUSTOMER_ID = p_Customer_Id;
                mspInsertCheque_Entry.CHEQUE_NO = p_Cheque_No;
			    mspInsertCheque_Entry.BANK_NAME  = p_Bank_Name;
                mspInsertCheque_Entry.CHEQUE_DATE = p_Cheque_Date;
                mspInsertCheque_Entry.RECEIVED_DATE = p_Received_Date;
                mspInsertCheque_Entry.DEPOSIT_DATE = p_Deposit_Date;
                mspInsertCheque_Entry.PROCESS_DATE  = p_Realization_Date;
                mspInsertCheque_Entry.CHEQUE_AMOUNT = p_Cheque_Amount;
                mspInsertCheque_Entry.STATUS_ID = p_Status_Id;
                mspInsertCheque_Entry.TIME_STAMP = p_Time_Stamp;
                mspInsertCheque_Entry.USER_ID = p_User_Id; 
                mspInsertCheque_Entry.LAST_UPDATED = DateTime.Now;
                mspInsertCheque_Entry.SlipNo = p_SlipNo;
                mspInsertCheque_Entry.Remarks = p_Remarks;
                mspInsertCheque_Entry.ACCOUNT_HEAD_ID = p_AccountHead;
                mspInsertCheque_Entry.SALEMAN_ID = p_SaleManId; 
                String ChequeProceId =  mspInsertCheque_Entry.ExecuteQuery();
                return ChequeProceId;
                   
			 }
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return "0";
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		
		
		}
        public void UpdateChequeEntry(long p_CHEQUE_PROCESS_ID, int p_distributorId, int p_PrincipalId, long p_Customer_Id, string p_Cheque_No, string p_Bank_Name, DateTime p_Cheque_Date, DateTime p_Received_Date, DateTime p_Deposit_Date, DateTime p_Realization_Date, decimal p_Cheque_Amount, int p_Status_Id, DateTime p_Time_Stamp, string p_SlipNo, int p_UserId, string p_Remarks,long p_AccountHead,int p_SalemanId)
		{
			IDbConnection mConnection = null;
			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                spUpdateCHEQUE_PROCESS mspUpdateCheque_Entry = new spUpdateCHEQUE_PROCESS();
				mspUpdateCheque_Entry.Connection = mConnection;
                mspUpdateCheque_Entry.CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID;
                mspUpdateCheque_Entry.DISTRIBUTOR_ID = p_distributorId;
                mspUpdateCheque_Entry.CUSTOMER_ID = p_Customer_Id;
                mspUpdateCheque_Entry.PRINCIPAL_ID = p_PrincipalId; 
                mspUpdateCheque_Entry.CHEQUE_NO = p_Cheque_No;
                mspUpdateCheque_Entry.BANK_NAME = p_Bank_Name;
                mspUpdateCheque_Entry.CHEQUE_DATE = p_Cheque_Date;
                mspUpdateCheque_Entry.RECEIVED_DATE = p_Received_Date;
                mspUpdateCheque_Entry.DEPOSIT_DATE = p_Deposit_Date;
                mspUpdateCheque_Entry.PROCESS_DATE = p_Realization_Date;
                mspUpdateCheque_Entry.CHEQUE_AMOUNT = p_Cheque_Amount;
                mspUpdateCheque_Entry.STATUS_ID = p_Status_Id;
                mspUpdateCheque_Entry.TIME_STAMP = p_Time_Stamp;
                mspUpdateCheque_Entry.LAST_UPDATED = DateTime.Now;
                mspUpdateCheque_Entry.SlipNo = p_SlipNo;
                mspUpdateCheque_Entry.USER_ID = p_UserId;
                mspUpdateCheque_Entry.Remarks = p_Remarks;
                mspUpdateCheque_Entry.ACCOUNT_HEAD_ID = p_AccountHead;
                mspUpdateCheque_Entry.SALEMAN_ID = p_SalemanId; 
                mspUpdateCheque_Entry.ExecuteQuery();
				
				                   
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				//return exp.Message;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		
		
		}
        public DataTable SelectChequeEntry(string p_FromDate , string p_ToDate , int p_Status_Id)
		{
		
			IDbConnection mConnection = null;
			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
	
				uspSelectCHEQUE_ENTRY mspSelectChequeEntry = new uspSelectCHEQUE_ENTRY();
                mspSelectChequeEntry.Connection = mConnection;
                mspSelectChequeEntry.FROMDATE = Convert.ToDateTime(p_FromDate);
                mspSelectChequeEntry.TODATE = Convert.ToDateTime(p_ToDate) ;
				mspSelectChequeEntry.STATUS_ID = p_Status_Id;
				DataTable dt = mspSelectChequeEntry.ExecuteTable();
				return dt;
			               	
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
				//return exp.Message;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		
		 
		}
        public DataTable SelectChequeEntryInvoice(long p_CHEQUE_PROCESS_ID, int p_Type_id)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspChequeInvoice mspSelectChequeEntry = new UspChequeInvoice();
                mspSelectChequeEntry.Connection = mConnection;
                mspSelectChequeEntry.CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID;
                mspSelectChequeEntry.TYEP_ID = p_Type_id; 
                DataTable dt = mspSelectChequeEntry.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
                //return exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }


        }
        public DataTable InsertChequeEntryInvoice(long p_CHEQUE_PROCESS_ID, long  p_Sale_Invoice_id)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertCHEQUE_PROCESS_DETAIL mspSelectChequeEntry = new spInsertCHEQUE_PROCESS_DETAIL();
                mspSelectChequeEntry.Connection = mConnection;
                mspSelectChequeEntry.CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID;
                mspSelectChequeEntry.SALE_INVOICE_ID = p_Sale_Invoice_id;
                DataTable dt = mspSelectChequeEntry.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
                //return exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }


        }
        public DataTable SelectChequeEntry(int p_Status_Id,DateTime p_ReceivedDate,int p_DISTRIBUTOR_ID,int p_PRINCIPAL_ID,int p_USER_ID)
		{
		
			IDbConnection mConnection = null;
			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

                spSelectCHEQUE_PROCESS mspSelectChequeEntry = new spSelectCHEQUE_PROCESS();
				mspSelectChequeEntry.Connection = mConnection;
               	mspSelectChequeEntry.STATUS_ID = p_Status_Id;
                mspSelectChequeEntry.RECEIVED_DATE = p_ReceivedDate;
                mspSelectChequeEntry.USER_ID = p_USER_ID;
                mspSelectChequeEntry.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mspSelectChequeEntry.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                DataTable dt = mspSelectChequeEntry.ExecuteTable();
				return dt;
			               	
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
				//return exp.Message;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		
		 
		}
        public void  RollbackChequeEntry(int p_PRINCIPAL_ID, int p_DISTRIBUTOR_ID, string p_CHEQUE_NO, long p_CHEQUE_PROCESS_ID,long p_VoucherNo)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspRollbackChequeTran mspSelectChequeEntry = new UspRollbackChequeTran();
                mspSelectChequeEntry.Connection = mConnection;
                mspSelectChequeEntry.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mspSelectChequeEntry.CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID;
                mspSelectChequeEntry.CHEQUE_NO = p_CHEQUE_NO;
                mspSelectChequeEntry.VOUCHER_NO = p_VoucherNo;
                mspSelectChequeEntry.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mspSelectChequeEntry.ExecuteQuery();
                
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                //return null;
                //return exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }


        }
		public void ProcessCustmerCreditLevel(long p_Customerid,int p_invoiceNo,Decimal p_Amount)
		{
		
			IDbConnection mConnection = null;
			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
	
				UspProcessUsedCreditLimit mUpdateCLevel = new UspProcessUsedCreditLimit();  
				mUpdateCLevel.Connection = mConnection;
				mUpdateCLevel.typeId = Configuration.DistributorCreditLevel; 
				mUpdateCLevel.CustomerId  = p_Customerid;
				mUpdateCLevel.InvoiceNo = p_invoiceNo;
				mUpdateCLevel.amount = p_Amount;
				mUpdateCLevel.ExecuteQuery(); 
				
			               	
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				
				
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		
		 
		}
        public void DeleteChequeEntry(long p_ChequeProcessId)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspDeleteCheque_Process mUpdateCLevel = new UspDeleteCheque_Process();
                mUpdateCLevel.Connection = mConnection;
                mUpdateCLevel.CHEQUE_PROCESS_ID = p_ChequeProcessId;
                mUpdateCLevel.ExecuteQuery();


            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);


            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }


        }
        
    }
}