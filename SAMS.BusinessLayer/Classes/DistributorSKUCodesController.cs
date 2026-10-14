using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;


namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for DistributorSKUCodesController.
	/// </summary>
	public class DistributorSKUCodesController
	{

		#region Constructor
		public DistributorSKUCodesController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		public DataTable uspSelectDistSKUCodes(int p_Category_Id,int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				uspSelectDistSKUCode mDistSkuCode = new uspSelectDistSKUCode();
				mDistSkuCode.Connection = mConnection;
				mDistSkuCode.CATEGORY_ID=p_Category_Id;
				mDistSkuCode.DISTRIBUTOR_ID=p_Distributor_Id;
				DataTable dt = mDistSkuCode.ExecuteTable();
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


		public DataTable SelectDistributorSKU(int p_DistributorId, int p_SkuId, int p_MinStockLevel)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR_SKU mDistSku = new spSelectDISTRIBUTOR_SKU();
				mDistSku.Connection = mConnection;
                
				mDistSku.DISTRIBUTOR_ID = p_DistributorId ;
				mDistSku.SKU_ID = p_SkuId;
				mDistSku.MIN_STOCK_LEVEL = p_MinStockLevel;

				DataTable dt = mDistSku.ExecuteTable();
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


		public string InsertDistributorSKU(int p_DistributorId, int p_SkuId, int p_MinStockLevel)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDISTRIBUTOR_SKU mDistSku = new spInsertDISTRIBUTOR_SKU();
				mDistSku.Connection = mConnection;

				mDistSku.DISTRIBUTOR_ID = p_DistributorId ;
				mDistSku.SKU_ID = p_SkuId;
				mDistSku.MIN_STOCK_LEVEL = p_MinStockLevel;

				mDistSku.ExecuteQuery();
				return "Record Inserted";

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

		
		public string UpdateDistributorSKU(int p_DistributorId, int p_SkuId, int p_MinStockLevel)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateDISTRIBUTOR_SKU mDistSku = new spUpdateDISTRIBUTOR_SKU();
				mDistSku.Connection = mConnection;
				
				mDistSku.DISTRIBUTOR_ID = p_DistributorId ;
				mDistSku.SKU_ID = p_SkuId;
				mDistSku.MIN_STOCK_LEVEL = p_MinStockLevel;
                
				mDistSku.ExecuteQuery();
				return "Record Updated";
				
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


		public string DeleteDistributorSKU(int p_DistributorId, int p_SkuId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spDeleteDISTRIBUTOR_SKU mDistSku = new spDeleteDISTRIBUTOR_SKU();
				mDistSku.Connection = mConnection;

				mDistSku.DISTRIBUTOR_ID = p_DistributorId ;
				mDistSku.SKU_ID = p_SkuId;
								
				mDistSku.ExecuteQuery();
				return "Record Deleted" ;
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

		

	}
}
