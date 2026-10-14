using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;


namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for ControllerWarehouse.
	/// </summary>
	/// 
	#region Constructors
	public class ControllerWarehouse
	{
		public ControllerWarehouse()
		{

		}
		#endregion

		#region Private Variables
		#endregion
		
		#region public Properties
		#endregion

		#region public static Methods
		#endregion
		
		#region Private Methods
		#endregion
		
		
		#region public Methods
		public string InsertWarehouse(string I_Warehouse_code, string I_Warehouse_name ,string I_Warehouse_Address, 
			string I_Contact_Person,string I_Contact_Phone,int I_User_Id,string I_IPAddress,bool I_Isdeleted,int I_virtual)
		{
			IDbConnection mConnection = null;
			try
			{
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertWAREHOUSES mwarehouse  =  new spInsertWAREHOUSES();
				mwarehouse.Connection = mConnection;
				mwarehouse.WAREHOUSE_CODE = I_Warehouse_code;
				mwarehouse.WAREHOUSE_NAME = I_Warehouse_name ;
				mwarehouse.WHAREHOUSE_ADDRESS =  I_Warehouse_Address;
				mwarehouse.CONTACT_PERSON = I_Contact_Person;
				mwarehouse.CONTACT_PHONE = I_Contact_Phone; 
				mwarehouse.TIME_STAMP = System.DateTime.Now ;
				mwarehouse.LASTUPDATE_DATE = System.DateTime.Now;
				mwarehouse.USER_ID   = I_User_Id;
				mwarehouse.IPAddress = I_IPAddress; 
				mwarehouse.ISDELETED = I_Isdeleted;
				mwarehouse.IS_VIRTUAL = I_virtual;
				mwarehouse.ExecuteQuery();
				return mwarehouse.WAREHOUSE_ID.ToString();  
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

		
		
		
		public DataTable Select_Warehouse(string WarehouseCode)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				spSelectWAREHOUSES selectdata = new spSelectWAREHOUSES();
				
				selectdata.Connection = mConnection;
				selectdata.WAREHOUSE_ID  =  Constants.LongNullValue; 
				selectdata.WAREHOUSE_CODE  = WarehouseCode;
				selectdata.WAREHOUSE_NAME = null;
				selectdata.WHAREHOUSE_ADDRESS = null;
				selectdata.CONTACT_PERSON = null;
				selectdata.CONTACT_PHONE = null;
				selectdata.ISDELETED = false;
				selectdata.IS_VIRTUAL = Constants.IntNullValue;
				selectdata.USER_ID  = Constants.IntNullValue;  
                selectdata.TIME_STAMP = Constants.DateNullValue;
				selectdata.LASTUPDATE_DATE = Constants.DateNullValue;
				selectdata.IPAddress = null;
				DataTable dtSAMSWarehouse = selectdata.ExecuteTable();
				return dtSAMSWarehouse;
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


		public string updateWarehouse(long I_WareHouse_Id,string I_Warehouse_code, string I_Warehouse_name ,string I_Warehouse_Address, 
			string I_Contact_Person,string I_Contact_Phone,int I_User_Id,string I_IPAddress,bool I_Isdeleted,int I_virtual)
		{
			IDbConnection mConnection = null;

			try
			{
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateWAREHOUSES mwarehouse = new spUpdateWAREHOUSES(); 
                mwarehouse.Connection = mConnection;
				mwarehouse.WAREHOUSE_ID = I_WareHouse_Id; 
				mwarehouse.WAREHOUSE_CODE = I_Warehouse_code;
				mwarehouse.WAREHOUSE_NAME = I_Warehouse_name ;
				mwarehouse.WHAREHOUSE_ADDRESS =  I_Warehouse_Address;
				mwarehouse.CONTACT_PERSON = I_Contact_Person;
				mwarehouse.CONTACT_PHONE = I_Contact_Phone; 
				mwarehouse.TIME_STAMP = System.DateTime.Now ;
				mwarehouse.LASTUPDATE_DATE = System.DateTime.Now;
				mwarehouse.USER_ID   = I_User_Id;
				mwarehouse.IPAddress = I_IPAddress; 
				mwarehouse.ISDELETED = I_Isdeleted;
				mwarehouse.IS_VIRTUAL = I_virtual;
				mwarehouse.ExecuteQuery();
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
		public DataTable SelectRegion()
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				spSelecttmpRegion selectdata  = new spSelecttmpRegion(); 
				
				selectdata.Connection = mConnection;
				selectdata.RegionCode = null;
				selectdata.RegionName = null;
				selectdata.CheckDistributor = false;
				DataTable dtSAMSWarehouse = selectdata.ExecuteTable();
				return dtSAMSWarehouse;
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

		#endregion
	}
}