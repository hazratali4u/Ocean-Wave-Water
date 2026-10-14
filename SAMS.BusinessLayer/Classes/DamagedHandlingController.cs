using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for DamagedHandlingController.
	/// </summary>
	public class DamagedHandlingController
	{
		#region private variables
		private int mSKU_ID;		
		private int mDISTRIBUTOR_ID	;
		private string mBATCH_NO	;
		private int mUNITS_IN_STOCK	;
		private DateTime mEXPIRY_DATE	;
		IDbTransaction mTransaction;
		IDbConnection mConnection;
		#endregion
		#region public Properties
		public int SKU_ID
		{
			get{return mSKU_ID;}
			set{mSKU_ID = value;}
		}
		public int DISTRIBUTOR_ID
		{
			get{return mDISTRIBUTOR_ID;}
			set{ mDISTRIBUTOR_ID= value;}
		}
		public string BATCH_NO
		{
			get{return mBATCH_NO;}
			set{ mBATCH_NO= value;}
		}
		public int UNITS_IN_STOCK
		{
			get{return mUNITS_IN_STOCK;}
			set{ mUNITS_IN_STOCK= value;}
		}
		public DateTime EXPIRY_DATE
		{
			get{return mEXPIRY_DATE ;}
			set{ mEXPIRY_DATE= value;}
		}
		public IDbTransaction Transaction
		{
			get{return mTransaction;}
			set{mTransaction = value;}
		}
		public IDbConnection Connection
		{
			get{return mConnection;}
			set{mConnection = value;}
		}
		#endregion
		#region constructor
		public DamagedHandlingController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Private Methods
		public bool OpenTransaction()
		{
			try
			{
				Connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				Connection.Open();
				Transaction = ProviderFactory.GetTransaction(Connection);
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}
		}
		public bool RollbackTransaction()
		{
			if(this.Transaction!=null)
			{
				Transaction.Rollback();
				Connection.Close();
				return true;
			}
			return false;
		}
		public bool CommitTransaction()
		{
			if(this.Transaction!=null)
			{
				Transaction.Commit();
				Connection.Close();
				return true;
			}
			return false;
		}
		

		public DataTable SelectDamagedStock(int p_SKU_ID,int p_DISTRIBUTOR_ID,string p_Batch)
		{	
			IDbConnection mConnection;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDamagedStock mSelectDamaged = new uspSelectDamagedStock();
				mSelectDamaged.Connection = mConnection;
				
				mSelectDamaged.SKU_ID = p_SKU_ID;
				mSelectDamaged.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mSelectDamaged.BATCH_NO = p_Batch;

				return mSelectDamaged.ExecuteTable();
			}
			catch(Exception exp)
			{
				throw exp;
				return null;
			}
			finally
			{				
				
			}
		}


		public bool ChangeStockPositionOnly(int p_SKUID,int Units_in_stock, int p_Qty_to_Mov, int p_DistributorID,string p_BatchNo,DateTime p_BatchExpiry)

		{
			try
			{
				DataTable dt ;

				#region Select in damaged stock
		
				spSelectDAMAGED_STOCK mSelectDamaged = new spSelectDAMAGED_STOCK();
				mSelectDamaged.Connection = Connection;
				mSelectDamaged.Transaction = Transaction;
				mSelectDamaged.SKU_ID =p_SKUID;
				mSelectDamaged.EXPIRY_DATE=Constants.DateNullValue;
				mSelectDamaged.BATCH_NO=p_BatchNo;
				mSelectDamaged.DISTRIBUTOR_ID=p_DistributorID;
				mSelectDamaged.UNITS_IN_STOCK= Constants.IntNullValue;
				mSelectDamaged.DISPOSED_STOCK = Constants.IntNullValue;
				dt = mSelectDamaged.ExecuteTable();

		
				#endregion
				if(dt.Rows.Count != 0)
				{

					#region update in damaged stock
			
					spUpdateDAMAGED_STOCK mUpdateDamaged = new spUpdateDAMAGED_STOCK();
					mUpdateDamaged.Connection = Connection;
					mUpdateDamaged.Transaction = Transaction;
					mUpdateDamaged.SKU_ID =p_SKUID;
					mUpdateDamaged.EXPIRY_DATE=Constants.DateNullValue;
					mUpdateDamaged.BATCH_NO=p_BatchNo;
					mUpdateDamaged.DISTRIBUTOR_ID=p_DistributorID;
					mUpdateDamaged.UNITS_IN_STOCK=Units_in_stock - p_Qty_to_Mov;
					mUpdateDamaged.DISPOSED_STOCK = int.Parse(DataControl.chkNull_Zero(dt.Rows[0]["DISPOSED_STOCK"].ToString())) + p_Qty_to_Mov;
					mUpdateDamaged.ExecuteQuery();

			
					#endregion				
				}
			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{
			}
			return true;
		}
		public bool ChangeStockPosition(int p_SKUID,int Units_in_stock, int p_Qty_to_Mov, int p_DistributorID,string p_BatchNo,DateTime p_BatchExpiry)

		{
			try
			{
				DataTable dt ;
				#region Select in damaged stock
		
				spSelectDAMAGED_STOCK mSelectDamaged = new spSelectDAMAGED_STOCK();
				mSelectDamaged.Connection = Connection;
				mSelectDamaged.Transaction = Transaction;
				mSelectDamaged.SKU_ID =p_SKUID;
				mSelectDamaged.EXPIRY_DATE=Constants.DateNullValue;
				mSelectDamaged.BATCH_NO=p_BatchNo;
				mSelectDamaged.DISTRIBUTOR_ID=p_DistributorID;
				mSelectDamaged.UNITS_IN_STOCK= Constants.IntNullValue;
				mSelectDamaged.DISPOSED_STOCK = Constants.IntNullValue;
				dt = mSelectDamaged.ExecuteTable();

		
				#endregion
				if(dt.Rows.Count != 0)
				{
					#region update in damaged stock
		
					spUpdateDAMAGED_STOCK mUpdateDamaged = new spUpdateDAMAGED_STOCK();
					mUpdateDamaged.Connection = Connection;
					mUpdateDamaged.Transaction = Transaction;
					mUpdateDamaged.SKU_ID =p_SKUID;
					mUpdateDamaged.EXPIRY_DATE=Constants.DateNullValue;
					mUpdateDamaged.BATCH_NO=p_BatchNo;
					mUpdateDamaged.DISTRIBUTOR_ID=p_DistributorID;
					mUpdateDamaged.UNITS_IN_STOCK= Units_in_stock - p_Qty_to_Mov;
					mUpdateDamaged.DISPOSED_STOCK = int.Parse(DataControl.chkNull_Zero(dt.Rows[0]["DISPOSED_STOCK"].ToString())) ;
					mUpdateDamaged.ExecuteQuery();

		
					#endregion
				}
				#region select and update sku stock
				//select sku stock 
				spSelectSKU_STOCK mSelectStock = new spSelectSKU_STOCK();
				mSelectStock.Connection = Connection;
				mSelectStock.Transaction = Transaction;
				mSelectStock.SKU_ID =p_SKUID;
				mSelectStock.UNITS_IN_STOCK = Constants.IntNullValue;
				mSelectStock.BATCH_NO=p_BatchNo;
				mSelectStock.DISTRIBUTOR_ID=p_DistributorID;
				mSelectStock.EXPIRY_DATE = Constants.DateNullValue;
				dt = mSelectStock.ExecuteTable();
				//update sku stock
				spUpdateSKU_STOCK mUpdateSkuStock = new spUpdateSKU_STOCK();
				mUpdateSkuStock.Connection = Connection;
				mUpdateSkuStock.Transaction = Transaction;
				mUpdateSkuStock.SKU_ID =p_SKUID;
				mUpdateSkuStock.BATCH_NO=p_BatchNo;
				mUpdateSkuStock.DISTRIBUTOR_ID=p_DistributorID;
				mUpdateSkuStock.UNITS_IN_STOCK=int.Parse(dt.Rows[0]["UNITS_IN_STOCK"].ToString()) + p_Qty_to_Mov ;
				mUpdateSkuStock.EXPIRY_DATE = Constants.DateNullValue;
				mUpdateSkuStock.ExecuteQuery();
				#endregion
				#region select and update sku stock register
				//select sku stock register 
				uspSelectSKU_STOCK_REGISTER mSelectStockRegister = new uspSelectSKU_STOCK_REGISTER();
				mSelectStockRegister.Connection = Connection;
				mSelectStockRegister.Transaction = Transaction;
				mSelectStockRegister.SKU_ID =p_SKUID;
				mSelectStockRegister.DISTRIBUTOR_ID=p_DistributorID;
				dt = mSelectStockRegister.ExecuteTable();
				//get sku stock register 
					
				//update sale_return in sku stock register
				spUpdateSKU_STOCK_REGISTER mUpdateStockReg = new spUpdateSKU_STOCK_REGISTER();
				mUpdateStockReg.Connection = Connection;
				mUpdateStockReg.Transaction = Transaction;
				mUpdateStockReg.SKU_ID =p_SKUID;
				mUpdateStockReg.CLOSING_STOCK = int.Parse(dt.Rows[0]["CLOSING_STOCK"].ToString()) + p_Qty_to_Mov;
				mUpdateStockReg.DAMAGED_STOCK_RETURN = int.Parse(dt.Rows[0]["DAMAGED_STOCK_RETURN"].ToString())+ p_Qty_to_Mov ;
				mUpdateStockReg.FREE_STOCK = int.Parse(dt.Rows[0]["FREE_STOCK"].ToString()) ;
				mUpdateStockReg.OPENING_STOCK = int.Parse(dt.Rows[0]["OPENING_STOCK"].ToString()) ;
				mUpdateStockReg.PURCHASE_RETURN = int.Parse(dt.Rows[0]["PURCHASE_RETURN"].ToString()) ;
				mUpdateStockReg.PURCHASED = int.Parse(dt.Rows[0]["PURCHASED"].ToString()) ;
				mUpdateStockReg.SALE_RETURN = int.Parse(dt.Rows[0]["SALE_RETURN"].ToString()) ;
				mUpdateStockReg.SALED = int.Parse(dt.Rows[0]["SALED"].ToString()) ;
				mUpdateStockReg.STOCK_DATE = DateTime.Parse(dt.Rows[0]["STOCK_DATE"].ToString());
				mUpdateStockReg.DAMAGED_STOCK = int.Parse(dt.Rows[0]["DAMAGED_STOCK"].ToString());
				mUpdateStockReg.DISTRIBUTOR_ID=p_DistributorID;

				mUpdateStockReg.DISPOSED = Constants.IntNullValue;
				mUpdateStockReg.SHORT = Constants.IntNullValue;
				mUpdateStockReg.EXCESS = Constants.IntNullValue;
				mUpdateStockReg.INITIAL = Constants.IntNullValue;

				mUpdateStockReg.TRADE_PRICE  = Constants.DecimalNullValue;
				mUpdateStockReg.RETAIL_PRICE  = Constants.DecimalNullValue;
				mUpdateStockReg.TAX_PRICE  = Constants.DecimalNullValue;
				
				mUpdateStockReg.ExecuteQuery();
			


				#endregion
			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{
			}
			return true;
		}
		
		
		public bool ChangeStockPosition_Disposed(int p_SKUID,int Units_in_stock, int p_Qty_to_Diposed, int p_DistributorID,string p_BatchNo,DateTime p_BatchExpiry)

		{
			try
			{
				DataTable dt ;
				#region Select in damaged stock
		
				spSelectDAMAGED_STOCK mSelectDamaged = new spSelectDAMAGED_STOCK();
				mSelectDamaged.Connection = Connection;
				mSelectDamaged.Transaction = Transaction;
				mSelectDamaged.SKU_ID =p_SKUID;
				mSelectDamaged.EXPIRY_DATE=Constants.DateNullValue;
				mSelectDamaged.BATCH_NO=p_BatchNo;
				mSelectDamaged.DISTRIBUTOR_ID=p_DistributorID;
				mSelectDamaged.UNITS_IN_STOCK= Constants.IntNullValue;
				mSelectDamaged.DISPOSED_STOCK = Constants.IntNullValue;
				dt = mSelectDamaged.ExecuteTable();

		
				#endregion
				if(dt.Rows.Count != 0)
				{
					#region update in damaged stock
		
					spUpdateDAMAGED_STOCK mUpdateDamaged = new spUpdateDAMAGED_STOCK();
					mUpdateDamaged.Connection = Connection;
					mUpdateDamaged.Transaction = Transaction;
					mUpdateDamaged.SKU_ID =p_SKUID;
					mUpdateDamaged.EXPIRY_DATE=Constants.DateNullValue;
					mUpdateDamaged.BATCH_NO=p_BatchNo;
					mUpdateDamaged.DISTRIBUTOR_ID=p_DistributorID;
					mUpdateDamaged.UNITS_IN_STOCK= Units_in_stock - p_Qty_to_Diposed;
					mUpdateDamaged.DISPOSED_STOCK = int.Parse(DataControl.chkNull_Zero(dt.Rows[0]["DISPOSED_STOCK"].ToString())) + p_Qty_to_Diposed ;
					mUpdateDamaged.ExecuteQuery();

		
					#endregion
				}
		
				
				#region select and update sku stock register
				//select sku stock register 
				uspSelectSKU_STOCK_REGISTER mSelectStockRegister = new uspSelectSKU_STOCK_REGISTER();
				mSelectStockRegister.Connection = Connection;
				mSelectStockRegister.Transaction = Transaction;
				mSelectStockRegister.SKU_ID =p_SKUID;
				mSelectStockRegister.DISTRIBUTOR_ID=p_DistributorID;
				dt = mSelectStockRegister.ExecuteTable();
				//get sku stock register 
					
				//update sale_return in sku stock register
				spUpdateSKU_STOCK_REGISTER mUpdateStockReg = new spUpdateSKU_STOCK_REGISTER();
				mUpdateStockReg.Connection = Connection;
				mUpdateStockReg.Transaction = Transaction;
				mUpdateStockReg.SKU_ID =p_SKUID;
				mUpdateStockReg.CLOSING_STOCK = int.Parse(dt.Rows[0]["CLOSING_STOCK"].ToString()) ;
				mUpdateStockReg.DAMAGED_STOCK_RETURN = int.Parse(dt.Rows[0]["DAMAGED_STOCK_RETURN"].ToString());
				mUpdateStockReg.FREE_STOCK = int.Parse(dt.Rows[0]["FREE_STOCK"].ToString()) ;
				mUpdateStockReg.OPENING_STOCK = int.Parse(dt.Rows[0]["OPENING_STOCK"].ToString()) ;
				mUpdateStockReg.PURCHASE_RETURN = int.Parse(dt.Rows[0]["PURCHASE_RETURN"].ToString()) ;
				mUpdateStockReg.PURCHASED = int.Parse(dt.Rows[0]["PURCHASED"].ToString()) ;
				mUpdateStockReg.SALE_RETURN = int.Parse(dt.Rows[0]["SALE_RETURN"].ToString()) ;
				mUpdateStockReg.SALED = int.Parse(dt.Rows[0]["SALED"].ToString()) ;
				mUpdateStockReg.STOCK_DATE = DateTime.Parse(dt.Rows[0]["STOCK_DATE"].ToString());
				mUpdateStockReg.DAMAGED_STOCK = int.Parse(dt.Rows[0]["DAMAGED_STOCK"].ToString());
				mUpdateStockReg.DISTRIBUTOR_ID=p_DistributorID;

				mUpdateStockReg.DISPOSED = int.Parse(dt.Rows[0]["DISPOSED"].ToString()) + p_Qty_to_Diposed ;
				mUpdateStockReg.SHORT = Constants.IntNullValue;
				mUpdateStockReg.EXCESS = Constants.IntNullValue;
				mUpdateStockReg.INITIAL = Constants.IntNullValue;

				mUpdateStockReg.TRADE_PRICE  = Constants.DecimalNullValue;
				mUpdateStockReg.RETAIL_PRICE  = Constants.DecimalNullValue;
				mUpdateStockReg.TAX_PRICE  = Constants.DecimalNullValue;
				
				mUpdateStockReg.ExecuteQuery();
			


				#endregion
			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{
			}
			return true;
		}

		public bool MoveLiveStockToDamage(int p_SKUID,int Units_in_stock, int p_Qty_to_Mov, int p_DistributorID,string p_BatchNo,DateTime p_BatchExpiry)

		{
			try
			{
				DataTable dt ;

				#region Select in damaged stock
		
				spSelectDAMAGED_STOCK mSelectDamaged = new spSelectDAMAGED_STOCK();
				mSelectDamaged.Connection = Connection;
				mSelectDamaged.Transaction = Transaction;
				mSelectDamaged.SKU_ID =p_SKUID;
				mSelectDamaged.EXPIRY_DATE=Constants.DateNullValue;
				mSelectDamaged.BATCH_NO=p_BatchNo;
				mSelectDamaged.DISTRIBUTOR_ID=p_DistributorID;
				mSelectDamaged.UNITS_IN_STOCK= Constants.IntNullValue;
				mSelectDamaged.DISPOSED_STOCK = Constants.IntNullValue;
				dt = mSelectDamaged.ExecuteTable();

		
				#endregion
				if(dt.Rows.Count != 0)
				{

					#region update in damaged stock
			
					spUpdateDAMAGED_STOCK mUpdateDamaged = new spUpdateDAMAGED_STOCK();
					mUpdateDamaged.Connection = Connection;
					mUpdateDamaged.Transaction = Transaction;
					mUpdateDamaged.SKU_ID =p_SKUID;
					mUpdateDamaged.EXPIRY_DATE=Constants.DateNullValue;
					mUpdateDamaged.BATCH_NO=p_BatchNo;
					mUpdateDamaged.DISTRIBUTOR_ID=p_DistributorID;
					mUpdateDamaged.UNITS_IN_STOCK=Units_in_stock +p_Qty_to_Mov;
					mUpdateDamaged.DISPOSED_STOCK = int.Parse(DataControl.chkNull_Zero(dt.Rows[0]["DISPOSED_STOCK"].ToString()));
					mUpdateDamaged.UNITS_IN_STOCK = int.Parse(DataControl.chkNull_Zero(dt.Rows[0]["UNITS_IN_STOCK"].ToString())) + p_Qty_to_Mov;

					mUpdateDamaged.ExecuteQuery();

			
					#endregion				
				}
				else
				{
					spInsertDAMAGED_STOCK mInsertDamaged  = new spInsertDAMAGED_STOCK();
					mInsertDamaged.Connection = Connection;
					mInsertDamaged.Transaction = Transaction;
					mInsertDamaged.SKU_ID =p_SKUID;
					mInsertDamaged.EXPIRY_DATE=Constants.DateNullValue;
					mInsertDamaged.BATCH_NO=p_BatchNo;
					mInsertDamaged.DISTRIBUTOR_ID=p_DistributorID;
					mInsertDamaged.UNITS_IN_STOCK= p_Qty_to_Mov;
					
					mInsertDamaged.ExecuteQuery();
				}
				#region select and update sku stock
				//select sku stock 
				spSelectSKU_STOCK mSelectStock = new spSelectSKU_STOCK();
				mSelectStock.Connection = Connection;
				mSelectStock.Transaction = Transaction;
				mSelectStock.SKU_ID =p_SKUID;
				mSelectStock.UNITS_IN_STOCK = Constants.IntNullValue;
				mSelectStock.BATCH_NO=p_BatchNo;
				mSelectStock.DISTRIBUTOR_ID=p_DistributorID;
				mSelectStock.EXPIRY_DATE = Constants.DateNullValue;
				dt = mSelectStock.ExecuteTable();
				//update sku stock
				spUpdateSKU_STOCK mUpdateSkuStock = new spUpdateSKU_STOCK();
				mUpdateSkuStock.Connection = Connection;
				mUpdateSkuStock.Transaction = Transaction;
				mUpdateSkuStock.SKU_ID =p_SKUID;
				mUpdateSkuStock.BATCH_NO=p_BatchNo;
				mUpdateSkuStock.DISTRIBUTOR_ID=p_DistributorID;
				mUpdateSkuStock.UNITS_IN_STOCK=int.Parse(dt.Rows[0]["UNITS_IN_STOCK"].ToString()) - p_Qty_to_Mov;
				mUpdateSkuStock.EXPIRY_DATE = Constants.DateNullValue;
				mUpdateSkuStock.ExecuteQuery();
				#endregion
				#region select and update sku stock register
				//select sku stock register 
				uspSelectSKU_STOCK_REGISTER mSelectStockRegister = new uspSelectSKU_STOCK_REGISTER();
				mSelectStockRegister.Connection = Connection;
				mSelectStockRegister.Transaction = Transaction;
				mSelectStockRegister.SKU_ID =p_SKUID;
				mSelectStockRegister.DISTRIBUTOR_ID=p_DistributorID;
				dt = mSelectStockRegister.ExecuteTable();
				//get sku stock register 
					
				//update sale_return in sku stock register
				if (dt.Rows.Count > 0)
				{
					spUpdateSKU_STOCK_REGISTER mUpdateStockReg = new spUpdateSKU_STOCK_REGISTER();
					mUpdateStockReg.Connection = Connection;
					mUpdateStockReg.Transaction = Transaction;
					mUpdateStockReg.SKU_ID =p_SKUID;
					mUpdateStockReg.CLOSING_STOCK = int.Parse(dt.Rows[0]["CLOSING_STOCK"].ToString()) - p_Qty_to_Mov;
					mUpdateStockReg.DAMAGED_STOCK_RETURN = int.Parse(dt.Rows[0]["DAMAGED_STOCK_RETURN"].ToString()) ;
					mUpdateStockReg.FREE_STOCK = int.Parse(dt.Rows[0]["FREE_STOCK"].ToString()) ;
					mUpdateStockReg.OPENING_STOCK = int.Parse(dt.Rows[0]["OPENING_STOCK"].ToString()) ;
					mUpdateStockReg.PURCHASE_RETURN = int.Parse(dt.Rows[0]["PURCHASE_RETURN"].ToString()) ;
					mUpdateStockReg.PURCHASED = int.Parse(dt.Rows[0]["PURCHASED"].ToString()) ;
					mUpdateStockReg.SALE_RETURN = int.Parse(dt.Rows[0]["SALE_RETURN"].ToString()) ;
					mUpdateStockReg.SALED = int.Parse(dt.Rows[0]["SALED"].ToString()) ;
					mUpdateStockReg.STOCK_DATE = DateTime.Parse(dt.Rows[0]["STOCK_DATE"].ToString());
					mUpdateStockReg.DAMAGED_STOCK = int.Parse(dt.Rows[0]["DAMAGED_STOCK"].ToString())+ p_Qty_to_Mov;
					mUpdateStockReg.DISTRIBUTOR_ID=p_DistributorID;

					mUpdateStockReg.DISPOSED = Constants.IntNullValue;
					mUpdateStockReg.SHORT = Constants.IntNullValue;
					mUpdateStockReg.EXCESS = Constants.IntNullValue;
					mUpdateStockReg.INITIAL = Constants.IntNullValue;

					mUpdateStockReg.TRADE_PRICE  = Constants.DecimalNullValue;
					mUpdateStockReg.RETAIL_PRICE  = Constants.DecimalNullValue;
					mUpdateStockReg.TAX_PRICE  = Constants.DecimalNullValue;
				

					mUpdateStockReg.ExecuteQuery();
					
				}
				#endregion

			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{
			}
			return true;
		}
		#endregion
	}
}
