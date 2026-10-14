using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for MerchandizingItemsController.
	/// </summary>
	public class MerchandizingItemsController
	{
		public MerchandizingItemsController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public static DataTable SelectMerchandizingItem( long p_Merchandizing_ItemID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spSelectMerchandizing_Items mspSelectMerchandizingItems = new spSelectMerchandizing_Items();
				mspSelectMerchandizingItems.Connection =  mConnection;
				mspSelectMerchandizingItems.IP_ADDRESS  = null;
				mspSelectMerchandizingItems.MI_TYPE = Constants.IntNullValue;
				mspSelectMerchandizingItems.MI_POINT  = Constants.DecimalNullValue;
                mspSelectMerchandizingItems.IS_ACTIVE  = 1;
				mspSelectMerchandizingItems.MI_CODE = null;
				mspSelectMerchandizingItems.MI_DESC = null;
				mspSelectMerchandizingItems.MI_ID = p_Merchandizing_ItemID;
                mspSelectMerchandizingItems.MI_NAME  = null;
				mspSelectMerchandizingItems.TIME_STAMP = Constants.DateNullValue;
				mspSelectMerchandizingItems.USER_ID = Constants.IntNullValue;
				DataTable dtMerchandizing_Items = mspSelectMerchandizingItems.ExecuteTable();
				return dtMerchandizing_Items;
			}
			
			catch(Exception excp)
			{
				ExceptionPublisher.PublishException( excp);
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
		public static bool  UpdateMerchandizingItemsAssignment( long p_Merchandizing_Item_AssignmentID , int p_Distributor_ID , int p_Distributor_Type_ID ,long p_Merchandizing_ItemID  ,string  p_Ip_Address, int p_Quantity  )
 		{
			IDbConnection mConnection = null;

			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			    mConnection.Open();
                spUpdateMerchandizing_Items_Assignment mspUpdateMerchandizingItemsAssignment = new spUpdateMerchandizing_Items_Assignment();
                mspUpdateMerchandizingItemsAssignment.Connection = mConnection;
                mspUpdateMerchandizingItemsAssignment.DISTRIBUTOR_ID = p_Distributor_ID;
                mspUpdateMerchandizingItemsAssignment.DISTRIBUTOR_TYPE_ID = p_Distributor_Type_ID;
                mspUpdateMerchandizingItemsAssignment.IP_ADDDRESS = p_Ip_Address;
                mspUpdateMerchandizingItemsAssignment.IS_ACTIVE = true;
                mspUpdateMerchandizingItemsAssignment.MI_ID =  p_Merchandizing_ItemID;
                mspUpdateMerchandizingItemsAssignment.MIA_ID = p_Merchandizing_Item_AssignmentID;
                mspUpdateMerchandizingItemsAssignment.QUANTITY = p_Quantity;
                mspUpdateMerchandizingItemsAssignment.TIME_STAMP = Constants.DateNullValue;
				mspUpdateMerchandizingItemsAssignment.USER_ID = Constants.IntNullValue;
                mspUpdateMerchandizingItemsAssignment.ExecuteQuery();
                return true; 
               
			}
			
			catch(Exception excp)
			{
				ExceptionPublisher.PublishException( excp);
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
		public static bool  InsertMerchandizingItemsAssignment(int p_Distributor_ID ,int  p_Distributor_Type_ID ,string  p_Ip_Address,long p_Merchandizing_ItemID , int p_Quantity      )
		{
			IDbConnection mConnection = null;

			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertMerchandizing_Items_Assignment mspInsertMerchandizingItemsAssignment = new spInsertMerchandizing_Items_Assignment();
				mspInsertMerchandizingItemsAssignment.Connection =  mConnection;
				mspInsertMerchandizingItemsAssignment.DISTRIBUTOR_ID =  p_Distributor_ID;
				mspInsertMerchandizingItemsAssignment.DISTRIBUTOR_TYPE_ID  = p_Distributor_Type_ID;
                mspInsertMerchandizingItemsAssignment.IP_ADDDRESS   =  p_Ip_Address;
				mspInsertMerchandizingItemsAssignment.IS_ACTIVE  = true;
				mspInsertMerchandizingItemsAssignment.MI_ID = p_Merchandizing_ItemID;
                mspInsertMerchandizingItemsAssignment.QUANTITY  =  p_Quantity;
                mspInsertMerchandizingItemsAssignment.TIME_STAMP = DateTime.Now;
				mspInsertMerchandizingItemsAssignment.USER_ID  = Configuration.UserID;
				mspInsertMerchandizingItemsAssignment.ExecuteQuery();
				return true;

			}
			catch(Exception excp)
			{
				ExceptionPublisher.PublishException( excp);
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
		
		public static DataTable SelectAllMerchandizingItemsAssignment()
		{
			IDbConnection mConnection = null;

			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectMerchandizing_Items_Assignment mspSelectMerchandizingItemsAssignment = new spSelectMerchandizing_Items_Assignment();
				mspSelectMerchandizingItemsAssignment.Connection =  mConnection;
				mspSelectMerchandizingItemsAssignment.DISTRIBUTOR_ID = Constants.IntNullValue;
				mspSelectMerchandizingItemsAssignment.DISTRIBUTOR_TYPE_ID  = Constants.IntNullValue;
                mspSelectMerchandizingItemsAssignment.IP_ADDDRESS  = null;
				mspSelectMerchandizingItemsAssignment.IS_ACTIVE  = 1;
				mspSelectMerchandizingItemsAssignment.MI_ID = Constants.LongNullValue;
				mspSelectMerchandizingItemsAssignment.MIA_ID = Constants.LongNullValue;
                mspSelectMerchandizingItemsAssignment.QUANTITY = Constants.IntNullValue;
                mspSelectMerchandizingItemsAssignment.TIME_STAMP = Constants.DateNullValue;
                mspSelectMerchandizingItemsAssignment.USER_ID = Constants.IntNullValue;
				DataTable  dtMerchandizing_Items_Assignment = mspSelectMerchandizingItemsAssignment.ExecuteTable();
                return dtMerchandizing_Items_Assignment;
			}
			catch(Exception excp)
			{
				ExceptionPublisher.PublishException( excp);
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
		public static bool InsertMerchandizingItems( string p_MI_Code, string p_MI_Name ,string p_MI_Desc, int p_MI_Type, decimal p_MI_Point, string p_Ip_Address)
		{
		 IDbConnection mConnection = null;

			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
			    spInsertMerchandizing_Items mspInsertMerchandizingItems = new spInsertMerchandizing_Items();
                mspInsertMerchandizingItems.Connection =  mConnection;
				mspInsertMerchandizingItems.IP_ADDRESS = p_Ip_Address;
                mspInsertMerchandizingItems.IS_ACTIVE = true;
                mspInsertMerchandizingItems.MI_CODE =p_MI_Code;
                mspInsertMerchandizingItems.MI_DESC = p_MI_Desc;
                mspInsertMerchandizingItems.MI_NAME = p_MI_Name;
				mspInsertMerchandizingItems.MI_TYPE = p_MI_Type;
				mspInsertMerchandizingItems.MI_POINT = p_MI_Point;
                mspInsertMerchandizingItems.TIME_STAMP = System.DateTime.Now;
				mspInsertMerchandizingItems.USER_ID = Configuration.UserID;
                mspInsertMerchandizingItems.ExecuteQuery();
                return true;
			}
			catch(Exception excp)
			{
				ExceptionPublisher.PublishException( excp);
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
		public static bool UpdateMerchandizingItems( string p_MI_Code, string p_MI_Name ,string p_MI_Desc,long p_MI_ID , int p_MI_Type, decimal p_MI_Point, string p_Ip_Address)
		{
			IDbConnection mConnection = null;

			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateMerchandizing_Items mspUpdateMerchandizingItems = new spUpdateMerchandizing_Items();
				mspUpdateMerchandizingItems.Connection =  mConnection;
				mspUpdateMerchandizingItems.IP_ADDRESS = p_Ip_Address;
				mspUpdateMerchandizingItems.IS_ACTIVE = true;
				mspUpdateMerchandizingItems.MI_CODE =p_MI_Code;
				mspUpdateMerchandizingItems.MI_DESC = p_MI_Desc;
				mspUpdateMerchandizingItems.MI_NAME = p_MI_Name;
				mspUpdateMerchandizingItems.MI_TYPE = p_MI_Type;
				mspUpdateMerchandizingItems.MI_POINT = p_MI_Point;
				mspUpdateMerchandizingItems.TIME_STAMP = Constants.DateNullValue;
				mspUpdateMerchandizingItems.USER_ID = Constants.IntNullValue;
				mspUpdateMerchandizingItems.MI_ID = p_MI_ID;
                mspUpdateMerchandizingItems.ExecuteQuery();
				return true;
			}
			catch(Exception excp)
			{
				ExceptionPublisher.PublishException( excp);
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
		
		public static DataTable SelectAllMerchandizingItems()
		{
		   
			IDbConnection mConnection = null;

			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			
				mConnection.Open();
    			
				spSelectMerchandizing_Items mspSelectMerchandizingItems = new spSelectMerchandizing_Items();
				mspSelectMerchandizingItems.Connection = mConnection;
				mspSelectMerchandizingItems.IP_ADDRESS = null;
				mspSelectMerchandizingItems.IS_ACTIVE = 1;
				mspSelectMerchandizingItems.MI_CODE = null;
				mspSelectMerchandizingItems.MI_DESC = null;
				mspSelectMerchandizingItems.MI_ID = Constants.LongNullValue;
				mspSelectMerchandizingItems.MI_NAME =null;
				mspSelectMerchandizingItems.MI_TYPE = Constants.IntNullValue;
				mspSelectMerchandizingItems.MI_POINT = Constants.DecimalNullValue;
				mspSelectMerchandizingItems.TIME_STAMP = Constants.DateNullValue;
				mspSelectMerchandizingItems.USER_ID = Constants.IntNullValue;
				DataTable dtMerchandizingItems = mspSelectMerchandizingItems.ExecuteTable();
				return   dtMerchandizingItems;


			} 
			catch(Exception excp)
			{
		   	 ExceptionPublisher.PublishException( excp);
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

		public static DataTable SelectAllTLPGiftItems()
		{
		   
			IDbConnection mConnection = null;

			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			
				mConnection.Open();
    			
				spSelectMerchandizing_Items mspSelectMerchandizingItems = new spSelectMerchandizing_Items();
				mspSelectMerchandizingItems.Connection = mConnection;
				mspSelectMerchandizingItems.IP_ADDRESS = null;
				mspSelectMerchandizingItems.IS_ACTIVE = 1;
				mspSelectMerchandizingItems.MI_CODE = null;
				mspSelectMerchandizingItems.MI_DESC = null;
				mspSelectMerchandizingItems.MI_ID = Constants.LongNullValue;
				mspSelectMerchandizingItems.MI_NAME =null;
				mspSelectMerchandizingItems.MI_TYPE = 1;
				mspSelectMerchandizingItems.MI_POINT = Constants.DecimalNullValue;
				mspSelectMerchandizingItems.TIME_STAMP = Constants.DateNullValue;
				mspSelectMerchandizingItems.USER_ID = Constants.IntNullValue;
				DataTable dtMerchandizingItems = mspSelectMerchandizingItems.ExecuteTable();
				return   dtMerchandizingItems;


			} 
			catch(Exception excp)
			{
				ExceptionPublisher.PublishException( excp);
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
}
