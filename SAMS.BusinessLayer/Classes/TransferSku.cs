using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;


namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for TransferSku.
	/// </summary>
	public class TransferSku
	{
		public TransferSku()
		{

			
		}

		#region public Methods
		public DataTable Select_TransferMaster(int SKU_Received,int SKU_Issue,long fromWarehouse,long towarehouse)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				spSelectTRANSFER_MASTER selectdata = new spSelectTRANSFER_MASTER();
				selectdata.Connection = mConnection;
				selectdata.TRANSFER_MASTER_ID 	=  Constants.LongNullValue; 
				selectdata.DOCUMENT_NO = Constants.LongNullValue; 
				selectdata.TRANSFER_DATE   = Constants.DateNullValue;
				selectdata.TRANSFER_FROM = fromWarehouse ;
				selectdata.TRANSFER_FROMNAME = null;
				selectdata.TRANSFER_TO = towarehouse;  
				selectdata.TRANSFER_TONAME = null;
				selectdata.USER_ID = Constants.IntNullValue;
				selectdata.IS_RECEIVED = SKU_Received;
				selectdata.IS_ISSUE = SKU_Issue; 
				selectdata.IS_ACTIVE = true; 
				selectdata.ISSUE_DATE = Constants.DateNullValue;
				selectdata.RECEVID_DATE = Constants.DateNullValue;
				selectdata.TIME_STAMP = Constants.DateNullValue;
				DataTable dtSAMStransfermaster = selectdata.ExecuteTable();
				return dtSAMStransfermaster;
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

		}

		
		
		public DataTable Select_PurchaseMaster(int p_type,int p_Warehouse,int P_PURCHASE_MASTER_ID,Decimal p_qty )
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				UspPROCESSReturnPickSlipMaster selectdata = new UspPROCESSReturnPickSlipMaster(); 
				selectdata.Connection = mConnection;
				selectdata.type = p_type ;
				selectdata.Warehouse_id = p_Warehouse;
				selectdata.PURCHASE_MASTER_ID = P_PURCHASE_MASTER_ID;
				//selectdata.Qty = p_qty;
				DataTable dt = selectdata.ExecuteTable();
				return dt;
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

		}

		
		public DataTable Select_TransferDetail(long transfer_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				spSelectTRANSFER_DETAIL  selectdata = new spSelectTRANSFER_DETAIL();
				
				selectdata.Connection = mConnection;
				selectdata.TRANSCTION_DETAIL_ID   =  Constants.LongNullValue; 
				selectdata.TRANSFER_MASTER_ID   = transfer_Id; 
				selectdata.BATCH_NO = null; 
				selectdata.SKU_ID   = Constants.IntNullValue;
				selectdata.SKU_Code  = null;
				selectdata.SKU_NAME  = null;
                selectdata.QUANTITY  = Constants.DecimalNullValue; 
				selectdata.ISS_QTY =  Constants.DecimalNullValue; 
				selectdata.RCV_QTY = Constants.DecimalNullValue;  
				DataTable dtSAMStransferDetail = selectdata.ExecuteTable();
				return dtSAMStransferDetail;
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

		}


		public string InsertTransferDetail(long I_TRANSFER_ID,string p_BATCH_NO,int I_SKU_ID,string I_SKU_Code,string I_SKU_NAME,Decimal I_QUANTITY)

		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				spInsertTRANSFER_DETAIL  insertdata = new spInsertTRANSFER_DETAIL();
				insertdata.Connection = mConnection;
				mConnection.Open();
				insertdata.TRANSFER_MASTER_ID = I_TRANSFER_ID;
				insertdata.BATCH_NO = p_BATCH_NO;
				insertdata.SKU_ID = I_SKU_ID;
				insertdata.SKU_Code = I_SKU_Code;
				insertdata.SKU_NAME = I_SKU_NAME;
				insertdata.QUANTITY = I_QUANTITY;
				insertdata.RCV_QTY = Constants.DecimalNullValue;
				insertdata.ISS_QTY = Constants.DecimalNullValue;  
                insertdata.ExecuteQuery();
 				return insertdata.TRANSCTION_DETAIL_ID.ToString();  
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

		}


		public string updateTrnasferDetail(long I_TRANSFER_ID,Decimal I_IssQty,Decimal I_RcvQty)

		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				spUpdateTRANSFER_DETAIL   insertdata = new spUpdateTRANSFER_DETAIL();
				insertdata.Connection = mConnection;
				mConnection.Open();
				insertdata.TRANSCTION_DETAIL_ID = I_TRANSFER_ID;
 				insertdata.TRANSFER_MASTER_ID = Constants.LongNullValue; 
				insertdata.BATCH_NO = null;
				insertdata.SKU_ID = Constants.IntNullValue; 
				insertdata.SKU_Code = null;
				insertdata.SKU_NAME = null;
				insertdata.QUANTITY = Constants.DecimalNullValue; 
				insertdata.RCV_QTY =  I_RcvQty;
				insertdata.ISS_QTY = I_IssQty;
				insertdata.ExecuteQuery();
				return "Update Record"; 
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

		}


		public string InsertTransMaster(long I_TRANSFER_FROM,string I_TRANSFER_FROMNAME,long I_TRANSFER_TO,string I_TRANSFER_TONAME,int I_USER_ID,DateTime p_TransferDate,long p_documentno)

		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				spInsertTRANSFER_MASTER   insertdata = new spInsertTRANSFER_MASTER();
				insertdata.Connection = mConnection;
				mConnection.Open();
				insertdata.TRANSFER_DATE = System.DateTime.Now.Date;
				insertdata.TRANSFER_FROM = I_TRANSFER_FROM; 
				insertdata.TRANSFER_FROMNAME = I_TRANSFER_FROMNAME;
                insertdata.TRANSFER_TO = I_TRANSFER_TO; 
				insertdata.TRANSFER_TONAME = I_TRANSFER_TONAME; 
				insertdata.USER_ID = I_USER_ID;
				insertdata.IS_ISSUE = 0;
				insertdata.IS_RECEIVED = 0;
				insertdata.IS_ACTIVE   = true;
				insertdata.DOCUMENT_NO = p_documentno; 
				insertdata.TIME_STAMP = System.DateTime.Now.Date;  
				insertdata.RECEVID_DATE = System.DateTime.Now.Date;  
				insertdata.ISSUE_DATE = System.DateTime.Now.Date;  
				insertdata.ExecuteQuery();
				return insertdata.TRANSFER_MASTER_ID.ToString();  
			}
			catch(Exception exp)
			{
				//ExceptionPublisher.PublishException(exp);				
				return "Record Update";
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

		}

		
		
		public string updateTransferMaster(long TransferId,int Is_Issue,int Is_received)
		{
			IDbConnection mConnection = null;

			try
			{
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateTRANSFER_MASTER insertdata  = new spUpdateTRANSFER_MASTER();  
				insertdata.Connection = mConnection;
				insertdata.TRANSFER_MASTER_ID = TransferId;
				insertdata.TRANSFER_DATE = Constants.DateNullValue ;
				insertdata.TRANSFER_FROM = Constants.LongNullValue;
				insertdata.TRANSFER_FROMNAME = null;
				insertdata.TRANSFER_TO = Constants.LongNullValue; 
				insertdata.TRANSFER_TONAME = null;
				insertdata.USER_ID = Constants.IntNullValue; 
				insertdata.IS_ISSUE = Is_Issue;
				insertdata.IS_RECEIVED = Is_received;
				insertdata.IS_ACTIVE   = true;
				insertdata.DOCUMENT_NO = Constants.LongNullValue; 
				insertdata.TIME_STAMP = System.DateTime.Now.Date;  
				insertdata.RECEVID_DATE = Constants.DateNullValue ;
				insertdata.ISSUE_DATE = System.DateTime.Now.Date;  
				insertdata.ExecuteQuery();
				return "Stock Update for Transfer No. " + TransferId.ToString() ; 
	
			}

			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
                
			}
			finally 
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		

		}
		

		
		public string UpdateWarehouseStock(int type,long Warehouse_Id,int Sku_Id,Decimal Qty)
		{
			IDbConnection mConnection = null;

			try
			{
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				 
				spUpdateWAREHOUSE_STOCK ConfirmTransfer  = new spUpdateWAREHOUSE_STOCK(); 
				ConfirmTransfer.Connection = mConnection;
				ConfirmTransfer.type = type;
				ConfirmTransfer.Warehouse_Id = Warehouse_Id;
				ConfirmTransfer.Sku_ID = Sku_Id;
				ConfirmTransfer.qty = Qty;
				ConfirmTransfer.ExecuteQuery();
				return "Record Update"; 
			}

			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
                
			}
			finally 
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		
		}
		

		public string UpdateWarehouseStockNew(int type,long Warehouse_Id,string  Batchno,int Sku_Id,Decimal Qty)
		{
			IDbConnection mConnection = null;

			try
			{
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				 
				UspUpdateWAREHOUSE_STOCK01  ConfirmTransfer  = new UspUpdateWAREHOUSE_STOCK01();
				ConfirmTransfer.Connection = mConnection;
				ConfirmTransfer.type = type;
				ConfirmTransfer.Warehouse_Id = Warehouse_Id;
				ConfirmTransfer.Batchno =  Batchno;
				ConfirmTransfer.Sku_ID = Sku_Id;
                ConfirmTransfer.qty = Qty;
                ConfirmTransfer.ExecuteQuery();
				return "Record Update"; 
			}

			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
                
			}
			finally 
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		
		}
		

		public DataTable Select_WareHouseStockDetail(int Warehouse_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				
				UspSelectWarehouseStock_Detail selectdata = new UspSelectWarehouseStock_Detail(); 
				selectdata.Connection = mConnection;
				selectdata.WarehouseID  = Warehouse_Id;
				DataTable dtWarehouseStockDetail = selectdata.ExecuteTable();
				return dtWarehouseStockDetail;
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

		}

		

		public DataTable Select_WareHouseStockQty(int Warehouse_Id,int Sku_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				
				UspSelectWarehouseStock_Qty selectdata = new UspSelectWarehouseStock_Qty(); 
				selectdata.Connection = mConnection;
				selectdata.WarehouseID  = Warehouse_Id;
				selectdata.sku_id = Sku_Id;
				DataTable dtWarehouseStockDetail = selectdata.ExecuteTable();
				return dtWarehouseStockDetail;
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

		}

		public DataTable Select_BatchStockQty(int Warehouse_Id,int Sku_Id,string p_batchno)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				
				UspSelectWarehouseStock_Qty01  selectdata = new UspSelectWarehouseStock_Qty01(); 
				selectdata.Connection = mConnection;
				selectdata.Batchno = p_batchno;
				selectdata.WarehouseID  = Warehouse_Id;
				selectdata.sku_id = Sku_Id;
				DataTable dtWarehouseStockDetail = selectdata.ExecuteTable();
				return dtWarehouseStockDetail;
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

		}


	}

		
		#endregion
	
}
