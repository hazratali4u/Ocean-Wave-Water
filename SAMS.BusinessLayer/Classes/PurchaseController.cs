using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
    public class PurchaseController
    {
        #region variables
        IDbTransaction mTransaction;
        IDbConnection mConnection;
        SAMS.Common.Classes.Configuration ConfigClass;
        #endregion
        public bool InsertPurchaseDocument(int p_DISTRIBUTOR_ID,string p_ORDER_NUMBER,int p_TYPE_ID,DateTime p_DOCUMENT_DATE,int p_SOLD_TO,int p_SOLD_FROM,decimal p_TOTAL_AMOUNT,bool p_IS_DELETE,DataTable dtPurchaseDetail,int p_Posting,string p_BuiltyNo,int p_UserId,int p_PrincipalId) 
		{
			try
			{                 
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spInsertPURCHASE_MASTER mPurchaseMaster = new spInsertPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;  
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;
                mPurchaseMaster.TIME_STAMP = DateTime.Now;
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;   
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;  
                mPurchaseMaster.ExecuteQuery();

                #region Account Posting

                //LedgerController LController = new LedgerController();
                //Configuration.GetAccountHead();
                //string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID);
                //if (p_TYPE_ID == Constants.Document_Purchase)
                //{
                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Stock In Defualt (From Principal)", DateTime.Now, p_SOLD_FROM, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferInAccount), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Transfer In Default", DateTime.Now, p_SOLD_FROM, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}
                //else if (p_TYPE_ID == Constants.Document_Transfer_Out)
                //{

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferOutAccount), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Transfer Out Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Stock Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}
                //else if (p_TYPE_ID == Constants.Document_Transfer_In)
                //{
                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Delivery Chenal", DateTime.Now, p_SOLD_FROM, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferInAccount), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Transfer In Default", DateTime.Now, p_SOLD_FROM, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}
                //else if (p_TYPE_ID == Constants.Document_Purchase_Return)
                //{

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferOutAccount), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Stock Out Default (From Principal)", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Stock Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}
                //else if (p_TYPE_ID == Constants.Document_Opening)
                //{

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Stock Out Default (From Principal)", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferOutAccount), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Stock Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}
                //else if (p_TYPE_ID == Constants.Document_Short)
                //{

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferOutAccount), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Stock Short Adjustment Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Stock Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}
                //else if (p_TYPE_ID == Constants.Document_Acess)
                //{

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Stock Excess Adjustment Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferOutAccount), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Stock Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}
                //else if (p_TYPE_ID == Constants.Document_Damaged)
                //{

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferOutAccount), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Damaged Stock Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Stock Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}
                #endregion

                spInsertPURCHASE_DETAIL mPurchaseDetail = new spInsertPURCHASE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;
                
                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["QUANTITY"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;  
                    mPurchaseDetail.ExecuteQuery();
                    
                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_PrincipalId; 
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;   
                    mStockUpdate.ExecuteQuery();   
                }
                mTransaction.Commit();
                return true; 
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();  
				return false;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}
        public bool UpdatePurchaseDocument(long p_PURCHASE_MASTER_ID, int p_DISTRIBUTOR_ID, string p_ORDER_NUMBER, int p_TYPE_ID, DateTime p_DOCUMENT_DATE, int p_SOLD_TO, int p_SOLD_FROM, decimal p_TOTAL_AMOUNT, bool p_IS_DELETE, DataTable dtPurchaseDetail, int p_Posting, string p_BuiltyNo, int p_UserId,int p_Principal)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spUpdatePURCHASE_MASTER mPurchaseMaster = new spUpdatePURCHASE_MASTER(); 
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.Transaction = mTransaction;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;  
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.ORDER_NUMBER = p_ORDER_NUMBER;
                mPurchaseMaster.SOLD_FROM = p_SOLD_FROM;
                mPurchaseMaster.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;
                mPurchaseMaster.TOTAL_AMOUNT = p_TOTAL_AMOUNT;
                mPurchaseMaster.USER_ID = p_UserId;   
                mPurchaseMaster.LAST_UPDATE = DateTime.Now;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.BUILTY_NO = p_BuiltyNo;  
                mPurchaseMaster.ExecuteQuery();
               
                //Get Privouse Update Purchase Detail and Rollback
                //LedgerController LController = new LedgerController();

                //string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_DISTRIBUTOR_ID);

                DataTable dt = SelectPrivousePurchaseDetail(p_DISTRIBUTOR_ID, p_PURCHASE_MASTER_ID,mConnection,mTransaction);
                
                foreach (DataRow dr in dt.Rows)
                {
                    UspUpdatePurchaseDetailStock mPurchaseStock = new UspUpdatePurchaseDetailStock();
                    mPurchaseStock.Connection = mConnection;
                    mPurchaseStock.Transaction = mTransaction;
                    mPurchaseStock.TYPEID = p_TYPE_ID;
                    mPurchaseStock.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseStock.PURCHASE_DETAIL_ID = long.Parse(dr["PURCHASE_DETAIL_ID"].ToString());
                    mPurchaseStock.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID; 
                    mPurchaseStock.BATCH_NO = dr["BATCH_NO"].ToString().Trim();
                    mPurchaseStock.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseStock.ExecuteQuery();
                }
                      

                #region Account Posting


                //Configuration.GetAccountHead();


                //if (p_TYPE_ID == Constants.Document_Purchase)
                //{
                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Stock In Defualt (From Principal)", DateTime.Now, p_SOLD_FROM, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferInAccount), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Transfer In Default", DateTime.Now, p_SOLD_FROM, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}
                //else if (p_TYPE_ID == Constants.Document_Transfer_Out)
                //{

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferOutAccount), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Transfer Out Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Stock Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //}
                //else if (p_TYPE_ID == Constants.Document_Transfer_In)
                //{
                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Stock In Defualt (From Principal)", DateTime.Now, p_SOLD_FROM, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferInAccount), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Transfer In Default", DateTime.Now, p_SOLD_FROM, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}

                //else if (p_TYPE_ID == Constants.Document_Purchase_Return)
                //{

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferOutAccount), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Stock Out Default (to Principal)", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Stock Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}
                //else if (p_TYPE_ID == Constants.Document_Opening)
                //{

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Opening Stock Defualt", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferOutAccount), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Stock Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}
                //else if (p_TYPE_ID == Constants.Document_Short)
                //{

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferOutAccount), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Stock Short Adjustment Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Stock Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}
                //else if (p_TYPE_ID == Constants.Document_Acess)
                //{

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Stock Excess Adjustment Defualt", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferOutAccount), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Stock Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}
                //else if (p_TYPE_ID == Constants.Document_Damaged)
                //{

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.TransferOutAccount), p_DISTRIBUTOR_ID, p_TOTAL_AMOUNT, 0, p_DOCUMENT_DATE, "Stock Excess Adjustment Defualt", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);

                //    LController.PostingPurchasAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.StockInHand), p_DISTRIBUTOR_ID, 0, p_TOTAL_AMOUNT, p_DOCUMENT_DATE, "Stock Default", DateTime.Now, Constants.IntNullValue, mPurchaseMaster.PURCHASE_MASTER_ID, p_TYPE_ID, p_UserId, mTransaction, mConnection);
                //}
                #endregion
                
                spInsertPURCHASE_DETAIL mPurchaseDetail = new spInsertPURCHASE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.Transaction = mTransaction;

                foreach (DataRow dr in dtPurchaseDetail.Rows)
                {
                    
                   //update stock;
                    mPurchaseDetail.PURCHASE_MASTER_ID = mPurchaseMaster.PURCHASE_MASTER_ID;
                    mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                    mPurchaseDetail.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mPurchaseDetail.BATCH_NO = dr["BATCH_NO"].ToString();
                    mPurchaseDetail.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    mPurchaseDetail.QUANTITY = int.Parse(dr["QUANTITY"].ToString());
                    mPurchaseDetail.FREE_SKU = int.Parse(dr["FREE_SKU"].ToString());
                    mPurchaseDetail.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    mPurchaseDetail.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mPurchaseDetail.TIME_STAMP = p_DOCUMENT_DATE;  
                    mPurchaseDetail.ExecuteQuery();

                    UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                    mStockUpdate.Connection = mConnection;
                    mStockUpdate.Transaction = mTransaction;
                    mStockUpdate.PRINCIPAL_ID = p_Principal; 
                    mStockUpdate.TYPE_ID = mPurchaseMaster.TYPE_ID;
                    mStockUpdate.DISTRIBUTOR_ID = mPurchaseMaster.DISTRIBUTOR_ID;
                    mStockUpdate.STOCK_DATE = mPurchaseMaster.DOCUMENT_DATE;
                    mStockUpdate.SKU_ID = mPurchaseDetail.SKU_ID;
                    mStockUpdate.STOCK_QTY = mPurchaseDetail.QUANTITY;
                    mStockUpdate.FREE_QTY = mPurchaseDetail.FREE_SKU;
                    mStockUpdate.BATCHNO = mPurchaseDetail.BATCH_NO;
                    mStockUpdate.ExecuteQuery();
                }
                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
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
        public bool PostPendingDocument(long p_PURCHASE_MASTER_ID,int p_Type_Id,int p_Distributor_Id,int p_Posting)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdatePURCHASE_MASTER mPurchaseMaster = new spUpdatePURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.DISTRIBUTOR_ID = p_Distributor_Id;
                mPurchaseMaster.TYPE_ID = p_Type_Id;  
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.ExecuteQuery();
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
        public DataTable SelectPurchaseDocumentNo(int p_TYPE_ID,int p_DISTRIBUTOR_ID,long p_PURCHASE_MASTER_ID,int p_User_Id,int p_Posting)       
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_MASTER mPurchaseMaster = new spSelectPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID; 
                mPurchaseMaster.USER_ID = p_User_Id;
                mPurchaseMaster.POSTING = p_Posting; 
                DataTable dt = mPurchaseMaster.ExecuteTable();
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
        public DataTable SelectPurchaseDocumentNo(int p_TYPE_ID, int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID, int p_User_Id, int p_Posting,int p_SOLD_TO)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_MASTER mPurchaseMaster = new spSelectPURCHASE_MASTER();
                mPurchaseMaster.Connection = mConnection;
                mPurchaseMaster.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseMaster.TYPE_ID = p_TYPE_ID;
                mPurchaseMaster.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                mPurchaseMaster.USER_ID = p_User_Id;
                mPurchaseMaster.POSTING = p_Posting;
                mPurchaseMaster.SOLD_TO = p_SOLD_TO;  
                DataTable dt = mPurchaseMaster.ExecuteTable();
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
        public DataTable SelectPurchaseDetail(int p_DISTRIBUTOR_ID,long p_PURCHASE_MASTER_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectPURCHASE_DETAIL mPurchaseDetail = new spSelectPURCHASE_DETAIL();
                mPurchaseDetail.Connection = mConnection;
                mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseDetail.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                DataTable dt = mPurchaseDetail.ExecuteTable();
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
        public DataTable SelectPrivousePurchaseDetail(int p_DISTRIBUTOR_ID, long p_PURCHASE_MASTER_ID, IDbConnection PConnection, IDbTransaction PTransaction)
        {
            try
            {
                spSelectPURCHASE_DETAIL mPurchaseDetail = new spSelectPURCHASE_DETAIL();
                mPurchaseDetail.Connection = PConnection;
                mPurchaseDetail.Transaction = PTransaction;  
                mPurchaseDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPurchaseDetail.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                DataTable dt = mPurchaseDetail.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            
        }
        public DataTable SelectSKUClosingStock(int p_DISTRIBUTOR_ID,int p_SKU_ID,string p_BatchNo)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspProcessStockRegister mStockUpdate = new UspProcessStockRegister();
                mStockUpdate.Connection = mConnection;
                mStockUpdate.TYPE_ID = 12;
                mStockUpdate.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID; 
                mStockUpdate.SKU_ID = p_SKU_ID;
                mStockUpdate.BATCHNO = "N/A";
                DataTable dt = mStockUpdate.ExecuteTable();
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
        public DataTable SelectTransferOut(long  p_PURCHASE_MASTER_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectUnPostTransferOut mTransferOut = new UspSelectUnPostTransferOut();
                mTransferOut.Connection = mConnection;
                mTransferOut.PURCHASE_MASTER_ID = p_PURCHASE_MASTER_ID;
                DataTable dt = mTransferOut.ExecuteTable();
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
    }
}
