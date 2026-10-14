using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for LedgerController.
	/// </summary>
	public class LedgerController
	{
		public LedgerController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		public void PostingPurchasAccount(int p_VoucherType,long p_Voucher_no,long p_ACCOUNT_HEAD_ID, int p_Distributor_Id , decimal p_Debit ,decimal  p_Credit,DateTime p_Ledger_Date, string p_Remarks , DateTime p_TimeStamp , int p_PRINCIPAL_ID ,long p_DOCUMENT_NO,int p_DOCUMENT_TYPE_ID,int p_UserId,IDbTransaction mTransaction,IDbConnection mConnection)
		{
		
		   	try
			{
                spInsertLEDGER mspInsertLedger = new spInsertLEDGER();
                mspInsertLedger.Connection = mConnection;
                mspInsertLedger.Transaction = mTransaction;
                mspInsertLedger.VOUCHER_TYPE_ID = p_VoucherType;
                mspInsertLedger.VOUCHER_NO = p_Voucher_no;  
                mspInsertLedger.ACCOUNT_HEAD_ID = p_ACCOUNT_HEAD_ID;
                mspInsertLedger.DISTRIBUTOR_ID = p_Distributor_Id;
				mspInsertLedger.DEBIT =  p_Debit;
                mspInsertLedger.CREDIT = p_Credit;
				mspInsertLedger.LEDGER_DATE = p_Ledger_Date;
				mspInsertLedger.REMARKS = p_Remarks;
                mspInsertLedger.TIME_STAMP  = p_TimeStamp;
                mspInsertLedger.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mspInsertLedger.DOCUMENT_TYPE_ID = p_DOCUMENT_TYPE_ID;
                mspInsertLedger.DOCUMENT_NO = p_DOCUMENT_NO;
                mspInsertLedger.USER_ID = p_UserId;
                mspInsertLedger.POSTING = 0; 
                mspInsertLedger.IS_DELETED = 0; 
                mspInsertLedger.ExecuteQuery();
		    }
			
			catch(Exception excp)
			{
				ExceptionPublisher.PublishException(excp);				
				//return null;
			
			}
			            			
		}
        public void PostingInvoiceAccount(int p_VoucherType,long p_VoucherNo,long p_ACCOUNT_HEAD_ID, int p_Distributor_Id, decimal p_Debit, decimal p_Credit, DateTime p_Ledger_Date, string p_Remarks, DateTime p_TimeStamp, int p_PRINCIPAL_ID,int p_CUSTOMER_ID, long p_DOCUMENT_NO, int p_DOCUMENT_TYPE_ID, int p_UserId, IDbTransaction mTransaction, IDbConnection mConnection,int p_Paymode,string p_PayeesName)
        {

            try
            {
                spInsertLEDGER mspInsertLedger = new spInsertLEDGER();
                mspInsertLedger.Connection = mConnection;
                mspInsertLedger.Transaction = mTransaction;
                mspInsertLedger.VOUCHER_TYPE_ID = p_VoucherType;
                mspInsertLedger.VOUCHER_NO = p_VoucherNo;  
                mspInsertLedger.ACCOUNT_HEAD_ID = p_ACCOUNT_HEAD_ID;
                mspInsertLedger.DISTRIBUTOR_ID = p_Distributor_Id;
                mspInsertLedger.DEBIT = p_Debit;
                mspInsertLedger.CREDIT = p_Credit;
                mspInsertLedger.LEDGER_DATE = p_Ledger_Date;
                mspInsertLedger.REMARKS = p_Remarks;
                mspInsertLedger.TIME_STAMP = p_TimeStamp;
                mspInsertLedger.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mspInsertLedger.CUSTOMER_ID = p_CUSTOMER_ID;
                mspInsertLedger.DOCUMENT_TYPE_ID = p_DOCUMENT_TYPE_ID;
                mspInsertLedger.DOCUMENT_NO = p_DOCUMENT_NO;
                mspInsertLedger.USER_ID = p_UserId;
                mspInsertLedger.PAYMENT_MODE = p_Paymode; 
                mspInsertLedger.PAYEE_NAME = p_PayeesName;
                mspInsertLedger.IS_DELETED = 0; 
                mspInsertLedger.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
                //return null;

            }

        }
        public void PostingCash_Bank_Account(long p_LedgerId,int p_VOUCHER_TYPE_ID,long p_VOUCHER_NO,long p_ACCOUNT_HEAD_ID, int p_Distributor_Id, decimal p_Debit, decimal p_Credit, DateTime p_Ledger_Date, string p_Remarks, DateTime p_TimeStamp, int p_Customer_ID,int p_Principal,string p_Cheque_NO,int p_UserId,long p_Document_Id,int p_DocumentTypeId,string SlipNo,DateTime p_ChequeDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                spInsertLEDGER mspInsertLedger = new spInsertLEDGER();
                mspInsertLedger.Connection = mConnection;
                //mspInsertLedger.LEDGER_ID = p_LedgerId; 
                mspInsertLedger.ACCOUNT_HEAD_ID = p_ACCOUNT_HEAD_ID;
                mspInsertLedger.DISTRIBUTOR_ID = p_Distributor_Id;
                mspInsertLedger.VOUCHER_NO = p_VOUCHER_NO;
                mspInsertLedger.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID; 
                mspInsertLedger.DEBIT = p_Debit;
                mspInsertLedger.CREDIT = p_Credit;
                mspInsertLedger.LEDGER_DATE = p_Ledger_Date;
                mspInsertLedger.DOCUMENT_NO = p_Document_Id;
                mspInsertLedger.DOCUMENT_TYPE_ID = p_DocumentTypeId;  
                mspInsertLedger.REMARKS = p_Remarks;
                mspInsertLedger.TIME_STAMP = p_TimeStamp;
                mspInsertLedger.CUSTOMER_ID = p_Customer_ID;
                mspInsertLedger.PRINCIPAL_ID = p_Principal;  
                mspInsertLedger.CHEQUE_NO = p_Cheque_NO.ToString();  
                mspInsertLedger.USER_ID = p_UserId;
                mspInsertLedger.SLIP_NO = SlipNo;
                mspInsertLedger.CHQUE_DATE = p_ChequeDate;
                mspInsertLedger.POSTING = 0;
                mspInsertLedger.IS_DELETED = 0; 
                mspInsertLedger.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
                //return null;

            }

        }
        public void DeleteVoucher(int p_VOUCHER_TYPE_ID, long p_VOUCHER_NO,int p_Distributor_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spDeleteLEDGER mspInsertLedger = new spDeleteLEDGER();
                mspInsertLedger.Connection = mConnection;
                mspInsertLedger.DISTRIBUTOR_ID = p_Distributor_Id;
                mspInsertLedger.VOUCHER_NO = p_VOUCHER_NO;
                mspInsertLedger.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                mspInsertLedger.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
                //return null;

            }

        }
        public void PostingCash_Bank_Account(int p_VOUCHER_TYPE_ID, long p_VOUCHER_NO, long p_ACCOUNT_HEAD_ID, int p_Distributor_Id, decimal p_Debit, decimal p_Credit, DateTime p_Ledger_Date, string p_Remarks, DateTime p_TimeStamp, int p_Customer_ID, int p_Principal, string p_Cheque_NO, int p_UserId, long p_Document_Id, int p_DocumentTypeId, string SlipNo, DateTime p_ChequeDate,int p_PaymentMode,string p_PayeesName)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertLEDGER mspInsertLedger = new spInsertLEDGER();
                mspInsertLedger.Connection = mConnection;
                mspInsertLedger.ACCOUNT_HEAD_ID = p_ACCOUNT_HEAD_ID;
                mspInsertLedger.DISTRIBUTOR_ID = p_Distributor_Id;
                mspInsertLedger.VOUCHER_NO = p_VOUCHER_NO;
                mspInsertLedger.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                mspInsertLedger.DEBIT = p_Debit;
                mspInsertLedger.CREDIT = p_Credit;
                mspInsertLedger.LEDGER_DATE = p_Ledger_Date;
                mspInsertLedger.DOCUMENT_NO = p_Document_Id;
                mspInsertLedger.DOCUMENT_TYPE_ID = p_DocumentTypeId;
                mspInsertLedger.REMARKS = p_Remarks;
                mspInsertLedger.TIME_STAMP = p_TimeStamp;
                mspInsertLedger.CUSTOMER_ID = p_Customer_ID;
                mspInsertLedger.PRINCIPAL_ID = p_Principal;
                mspInsertLedger.CHEQUE_NO = p_Cheque_NO;
                mspInsertLedger.USER_ID = p_UserId;
                mspInsertLedger.SLIP_NO = SlipNo;
                mspInsertLedger.CHQUE_DATE = p_ChequeDate;
                mspInsertLedger.PAYMENT_MODE = p_PaymentMode;
                mspInsertLedger.PAYEE_NAME = p_PayeesName;  
                mspInsertLedger.POSTING = 0;
                mspInsertLedger.IS_DELETED = 0; 
                mspInsertLedger.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
                //return null;

            }

        }
        public DataTable SelectLedgerView(DateTime p_Fromdate,DateTime  p_ToDate,int p_Distributor_id,int p_Account_Type_id,long p_Account_Head_id,int p_Principal_Id,int p_Customer_id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspLedgerView objSelect = new UspLedgerView(); 
                objSelect.Connection = mConnection;
                objSelect.fromdate = p_Fromdate;
                objSelect.todate = p_ToDate;
                objSelect.Distributor_id = p_Distributor_id;
                objSelect.Account_type = p_Account_Type_id;
                objSelect.Account_head_id = p_Account_Head_id;
                objSelect.CustomerId = p_Customer_id;
                objSelect.Principal = p_Principal_Id;
                DataTable dt = objSelect.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        public DataTable SelectVoucherNo(DateTime p_Voucherdate, int p_Distributor_id,int p_VoucherTypeId,int p_UserId,string p_VoucherNo)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectGL_MASTER objSelect = new spSelectGL_MASTER();
                objSelect.Connection = mConnection;  
                objSelect.VOUCHER_DATE = p_Voucherdate;
                objSelect.DISTRIBUTOR_ID = p_Distributor_id;
                objSelect.USER_ID = p_UserId;
                objSelect.VOUCHER_TYPE_ID = p_VoucherTypeId;
                objSelect.VOUCHER_NO = p_VoucherNo;  
                objSelect.IS_POSTED = true;
                objSelect.IS_DELETED = false;  
                DataTable dt = objSelect.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        public DataTable SelectVoucherDetail( int p_Distributor_id,string p_VoucherNo,int p_VoucherTypeId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectGL_DETAIL objSelect = new spSelectGL_DETAIL();
                objSelect.Connection = mConnection;
                objSelect.DISTRIBUTOR_ID = p_Distributor_id;
                objSelect.VOUCHER_NO = p_VoucherNo;
                objSelect.VOUCHER_TYPE_ID = p_VoucherTypeId;  
                objSelect.IS_DELETED = false;
                DataTable dt = objSelect.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        public string SelectLedgerMaxDocumentId(int p_Document_id,int p_DistributorId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectMaxDocumentNo mMaxDNo = new UspSelectMaxDocumentNo();
                mMaxDNo.Connection = mConnection;
                mMaxDNo.Document_TypeId = p_Document_id;
                mMaxDNo.Distributor_id = p_DistributorId;
                DataTable MaxId = mMaxDNo.ExecuteTable(); 
                return MaxId.Rows[0][0].ToString(); 
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        public string SelectMaxVoucherId(int p_Document_id, int p_DistributorId,DateTime mDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectMaxVoucherNo mMaxDNo = new UspSelectMaxVoucherNo();
                mMaxDNo.Connection = mConnection;
                mMaxDNo.Document_TypeId = p_Document_id;
                mMaxDNo.Distributor_id = p_DistributorId;
                mMaxDNo.Month = mDate;
                DataTable MaxId = mMaxDNo.ExecuteTable(); 
                string MaxVoucherId =  MaxId.Rows[0][0].ToString();

                if (MaxVoucherId.Length == 1)
                {
                    if (mDate.Month.ToString().Length == 1)
                    {
                        MaxVoucherId = "0" + mDate.Month.ToString()  + mDate.Year.ToString().Substring(2, 2) + "-000" + MaxVoucherId;
                    }
                    else
                    {
                        MaxVoucherId = mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-000" + MaxVoucherId;
                    }

                }
                else if (MaxVoucherId.Length == 2)
                {
                    if (mDate.Month.ToString().Length == 1)
                    {
                        MaxVoucherId = MaxVoucherId = "0" + mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-00" + MaxVoucherId;
                    }
                    else
                    {
                        MaxVoucherId = mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-00" + MaxVoucherId;
                    }

                }
                else if (MaxVoucherId.Length == 3)
                {
                    if (mDate.Month.ToString().Length == 1)
                    {
                        MaxVoucherId = "0" + mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-0" + MaxVoucherId;
                    }
                    else
                    {
                        MaxVoucherId = mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-0" + MaxVoucherId;
                    }

                }
                else
                {
                    if (mDate.Month.ToString().Length == 1)
                    {
                        MaxVoucherId = "0" + mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-" + MaxVoucherId;
                    }
                    else
                    {
                        MaxVoucherId = mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) +  "-" + MaxVoucherId;
                    }
                }
                return MaxVoucherId;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        public void UpdateSaleInvoice(long p_SaleInvoice_ID, int p_Distributor_Id,decimal p_Current_Amount)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateSALE_INVOICE_MASTER mSaleMaster = new spUpdateSALE_INVOICE_MASTER();
                mSaleMaster.Connection = mConnection;
                mSaleMaster.DISTRIBUTOR_ID = p_Distributor_Id;
                mSaleMaster.SALE_INVOICE_ID = p_SaleInvoice_ID;
                mSaleMaster.CURRENT_CREDIT_AMOUNT = p_Current_Amount;
                mSaleMaster.IS_DELETED = false; 
                mSaleMaster.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
                //return null;

            }

        }
        public DataTable SelectBankCashTransction(int p_Distributor_Id, int p_Account_Head_Id, int p_DocumentType_id, DateTime FDate, DateTime TDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectBankCashDetail mAccountHead = new UspSelectBankCashDetail();
                mAccountHead.Connection = mConnection;
                mAccountHead.Distributor_id = p_Distributor_Id;
                mAccountHead.Account_Head_id = p_Account_Head_Id;
                mAccountHead.Document_Type_Id = p_DocumentType_id;
                mAccountHead.From_Date = DateTime.Parse(FDate.ToShortDateString() + " 00:00:00");
                mAccountHead.To_Date = DateTime.Parse(TDate.ToShortDateString() + " 23:59:59");

                DataTable dt = mAccountHead.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        public DataTable SelectClaimDetail(int p_Distributor_Id, int p_ClaimType_id, DateTime FDate, DateTime TDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectClaimDetail mAccountHead = new UspSelectClaimDetail();
                mAccountHead.Connection = mConnection;
                mAccountHead.Distributor_id = p_Distributor_Id;
                mAccountHead.Claim_Type_Id = p_ClaimType_id;
                mAccountHead.From_Date = DateTime.Parse(FDate.ToShortDateString() + " 00:00:00");
                mAccountHead.To_Date = DateTime.Parse(TDate.ToShortDateString() + " 23:59:59");

                DataTable dt = mAccountHead.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        public void DeleteCashBankTransction(int p_DistributorId,int p_Document_Type,long p_Voucher_no,long Document_no,decimal TotalAmount)
        {

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspDELETEBankCashDetail mSaleMaster = new UspDELETEBankCashDetail();
                mSaleMaster.Connection = mConnection;
                mSaleMaster.Distributor_id = p_DistributorId;
                mSaleMaster.Document_Type_Id = p_Document_Type;
                mSaleMaster.VOUCHER_NO = p_Voucher_no;
                mSaleMaster.DOCUMENT_NO = Document_no;
                mSaleMaster.AMOUNT = TotalAmount;  
                mSaleMaster.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
            }

        }
        public void DeleteWareHouseLedger(int p_DistributorId, int p_Document_Type, long p_Voucher_no, long Document_no, decimal TotalAmount)
        {

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspDELETEwareHouseLedger mSaleMaster = new UspDELETEwareHouseLedger();
                mSaleMaster.Connection = mConnection;
                mSaleMaster.Distributor_id = p_DistributorId;
                mSaleMaster.Document_Type_Id = p_Document_Type;
                mSaleMaster.VOUCHER_NO = p_Voucher_no;
                mSaleMaster.AMOUNT = TotalAmount;
                mSaleMaster.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
            }

        }
        public DataTable  SelectPendingInvoice(int p_DistributorId,int Principal_id,DateTime  From_Date,DateTime To_date,long p_Account_Head_Id)
        {

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectLedgerDetail mpInvoice = new UspSelectLedgerDetail();
                mpInvoice.Connection = mConnection;
                mpInvoice.DISTRIBUTOR_ID  = p_DistributorId;
                mpInvoice.PRINCIPAL_ID  = Principal_id;
                mpInvoice.FROM_DATE = From_Date;
                mpInvoice.TO_DATE = To_date;
                mpInvoice.ACCOUNT_HEAD_ID = p_Account_Head_Id;
                DataTable dt = mpInvoice.ExecuteTable();
                return dt;
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
                return null;
            }

        }
        public void PostSelectVoucher(int p_DistributorId,string p_Voucher_no,int p_Voucher_type_Id,int p_TypeId,DateTime p_VoucherDate)
        {

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspPostSelectVoucher mPostVoucher = new UspPostSelectVoucher();
                mPostVoucher.Connection = mConnection;
                mPostVoucher.DISTRIBUTOR_ID  = p_DistributorId;
                mPostVoucher.VOUCHER_NO = p_Voucher_no;
                mPostVoucher.VOUCHER_TYPE_ID = p_Voucher_type_Id;
                mPostVoucher.VOUCHER_DATE = p_VoucherDate;
                mPostVoucher.TYPE_ID = p_TypeId;  
                mPostVoucher.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
            }

        }
        public DataTable  SelectUnPostVoucherNo(int p_VoucherType_id,int p_DistributorId,bool p_IS_POST,DateTime p_FROM_DATE,DateTime p_TO_DATE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectVoucherNo mMaxDNo = new UspSelectVoucherNo();
                mMaxDNo.Connection = mConnection;
                mMaxDNo.VOUCHER_TYPE_ID = p_VoucherType_id;
                mMaxDNo.DISTRIBUTOR_ID = p_DistributorId;
                mMaxDNo.IS_POST = p_IS_POST;
                mMaxDNo.FROM_DATE = p_FROM_DATE;
                mMaxDNo.TO_DATE = p_TO_DATE;  
                                
                DataTable VouhcerId = mMaxDNo.ExecuteTable();
                return VouhcerId;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        public DataTable SelectUnPostLedger(string p_Voucher_id, int p_DistributorId,int p_VoucherType)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectVoucher ObjLedger = new spSelectVoucher();
                ObjLedger.Connection = mConnection;
                ObjLedger.VOUCHER_NO = p_Voucher_id;
                ObjLedger.DISTRIBUTOR_ID = p_DistributorId;
                ObjLedger.VOUCHER_TYPE_ID = p_VoucherType; 

                DataTable dt = ObjLedger.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        public bool Add_Voucher(int p_Distributor_id, int p_PRINCIPAL_ID, string  p_VOUCHER_NO, int p_VOUCHER_TYPE_ID,DateTime p_VOUCHER_DATE,int p_PAYMENT_MODE,string p_PayeesName,string p_Remarks,DateTime ChequeDate,string  ChequeNo, DataTable dtVoucherDetail,int p_UserId)
        {

            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
               // mTransaction = ProviderFactory.GetTransaction(mConnection);
                spDeleteGL_MASTER mDelete = new spDeleteGL_MASTER();
                
                mDelete.Connection = mConnection;
                //mDelete.Transaction = mTransaction;
                mDelete.DISTRIBUTOR_ID = p_Distributor_id;
                mDelete.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                mDelete.VOUCHER_NO = p_VOUCHER_NO;
                mDelete.ExecuteQuery();

                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spInsertGL_MASTER mISom = new spInsertGL_MASTER();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into Sale Order Master----------

                if (dtVoucherDetail.Rows.Count > 0)
                {
                    mISom.DISTRIBUTOR_ID = p_Distributor_id;
                    mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    mISom.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                    mISom.VOUCHER_NO = p_VOUCHER_NO;
                    mISom.VOUCHER_DATE = p_VOUCHER_DATE;
                    mISom.PAYMENT_MODE = p_PAYMENT_MODE;
                    mISom.CHEQUE_DATE = ChequeDate;
                    mISom.CHEQUE_NO = ChequeNo;  
                    mISom.PAYEES_NAME = p_PayeesName;
                    mISom.REMARKS = p_Remarks;
                    mISom.TIME_STAMP = DateTime.Now;
                    mISom.USER_ID = p_UserId;
                    mISom.IS_POSTED = false;
                    mISom.IS_DELETED = false;  
                    mISom.ExecuteQuery();


                    //----------------Insert into sale order detail-------------
                    spInsertGL_DETAIL mVoucherDetail = new spInsertGL_DETAIL();
                    mVoucherDetail.Connection = mConnection;
                    mVoucherDetail.Transaction = mTransaction;

                    foreach (DataRow dr in dtVoucherDetail.Rows)
                    {
                        mVoucherDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mVoucherDetail.PRINCIPAL_ID = p_PRINCIPAL_ID;
                        mVoucherDetail.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                        mVoucherDetail.VOUCHER_NO = p_VOUCHER_NO;
                        mVoucherDetail.ACCOUNT_HEAD_ID = long.Parse(dr["ACCOUNT_HEAD_ID"].ToString());
                        mVoucherDetail.DEBIT = decimal.Parse(dr["DEBIT"].ToString());
                        mVoucherDetail.CREDIT = decimal.Parse(dr["CREDIT"].ToString());
                        mVoucherDetail.GL_REMARKS = dr["REMARKS"].ToString();
                        mVoucherDetail.IS_DELETED = false;
                        mVoucherDetail.ExecuteQuery();



                    }
                    mTransaction.Commit();
                    return true;
                }
            }
            catch (Exception exp)
            {
                mTransaction.Rollback(); 
                ExceptionPublisher.PublishException(exp);
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return true;
        }
        public bool Add_VoucherSalePersonWise(int p_Distributor_id, int p_PRINCIPAL_ID, string p_VOUCHER_NO, int p_VOUCHER_TYPE_ID, DateTime p_VOUCHER_DATE, int p_PAYMENT_MODE, string p_PayeesName, string p_Remarks, DateTime ChequeDate, string ChequeNo, DataTable dtVoucherDetail, int p_UserId, int p_SALE_PERSON_ID)
        {

            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                

                spDeleteGL_MASTER mDelete = new spDeleteGL_MASTER();
                mDelete.Connection = mConnection;
               // mDelete.Transaction = mTransaction;
                mDelete.DISTRIBUTOR_ID = p_Distributor_id;
                mDelete.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                mDelete.VOUCHER_NO = p_VOUCHER_NO;
                mDelete.ExecuteQuery();

                mTransaction = ProviderFactory.GetTransaction(mConnection);
                uspDeleteExpenseSalePerson mDeleteSale = new uspDeleteExpenseSalePerson();
                mDeleteSale.Connection = mConnection;
                mDeleteSale.Transaction = mTransaction;
                mDeleteSale.VOUCHER_NO = p_VOUCHER_NO;
                mDeleteSale.DISTRIBUTOR_ID = p_Distributor_id;
                mDeleteSale.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mDeleteSale.SALE_PERSON_ID = p_SALE_PERSON_ID;
                mDeleteSale.ExecuteQuery();


                spInsertGL_MASTER mISom = new spInsertGL_MASTER();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into Sale Order Master----------

                if (dtVoucherDetail.Rows.Count > 0)
                {
                    mISom.DISTRIBUTOR_ID = p_Distributor_id;
                    mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    mISom.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                    mISom.VOUCHER_NO = p_VOUCHER_NO;
                    mISom.VOUCHER_DATE = p_VOUCHER_DATE;
                    mISom.PAYMENT_MODE = p_PAYMENT_MODE;
                    mISom.CHEQUE_DATE = ChequeDate;
                    mISom.CHEQUE_NO = ChequeNo;
                    mISom.PAYEES_NAME = p_PayeesName;
                    mISom.REMARKS = p_Remarks;
                    mISom.TIME_STAMP = DateTime.Now;
                    mISom.USER_ID = p_UserId;
                    mISom.IS_POSTED = false;
                    mISom.IS_DELETED = false;
                    mISom.ExecuteQuery();


                    //----------------Insert into sale order detail-------------
                    spInsertGL_DETAIL mVoucherDetail = new spInsertGL_DETAIL();
                    mVoucherDetail.Connection = mConnection;
                    mVoucherDetail.Transaction = mTransaction;

                    //----------------Insert into Expense Sale Person-------------
                    uspInsertExpenseSalePerson mInsertSalePerson = new uspInsertExpenseSalePerson();
                    mInsertSalePerson.Connection = mConnection;
                    mInsertSalePerson.Transaction = mTransaction;


                    foreach (DataRow dr in dtVoucherDetail.Rows)
                    {
                        mVoucherDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mVoucherDetail.PRINCIPAL_ID = p_PRINCIPAL_ID;
                        mVoucherDetail.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                        mVoucherDetail.VOUCHER_NO = p_VOUCHER_NO;
                        mVoucherDetail.ACCOUNT_HEAD_ID = long.Parse(dr["ACCOUNT_HEAD_ID"].ToString());
                        mVoucherDetail.DEBIT = decimal.Parse(dr["DEBIT"].ToString());
                        mVoucherDetail.CREDIT = decimal.Parse(dr["CREDIT"].ToString());
                        mVoucherDetail.GL_REMARKS = dr["REMARKS"].ToString();
                        mVoucherDetail.IS_DELETED = false;
                        mVoucherDetail.ExecuteQuery();

                        if (decimal.Parse(dr["DEBIT"].ToString()) > 0)
                        {
                            mInsertSalePerson.VOUCHER_NO = p_VOUCHER_NO;
                            mInsertSalePerson.DISTRIBUTOR_ID = p_Distributor_id;
                            mInsertSalePerson.PRINCIPAL_ID = p_PRINCIPAL_ID;
                            mInsertSalePerson.DOCUMENT_DATE = p_VOUCHER_DATE;
                            mInsertSalePerson.ACCOUNT_HEAD_ID = Convert.ToInt32(dr["ACCOUNT_HEAD_ID"]);
                            mInsertSalePerson.SALE_PERSON_ID = p_SALE_PERSON_ID;
                            mInsertSalePerson.REMARKS = dr["REMARKS"].ToString();
                            mInsertSalePerson.AMOUNT = decimal.Parse(dr["DEBIT"].ToString());
                            mInsertSalePerson.USER_ID = p_UserId;

                            mInsertSalePerson.ExecuteQuery();
                        }


                    }
                    mTransaction.Commit();
                    return true;
                }
            }
            catch (Exception exp)
            {
                mTransaction.Rollback();
                ExceptionPublisher.PublishException(exp);
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return true;
        }

        public bool DeleteOpeningCredit(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, int p_LEGEND_ID, DateTime p_DOCUMENT_DATE, int p_CUSTOMER_ID, long p_SALE_INVOICE_ID, int p_USER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspDeleteOpeningCredit mOpening = new uspDeleteOpeningCredit();
                mOpening.Connection = mConnection;
                mOpening.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mOpening.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mOpening.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mOpening.CUSTOMER_ID = p_CUSTOMER_ID;
                mOpening.SALE_INVOICE_ID = p_SALE_INVOICE_ID;
                mOpening.LEGEND_ID = p_LEGEND_ID;
                mOpening.USER_ID = p_USER_ID;
                mOpening.ExecuteQuery();
                return true;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
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
