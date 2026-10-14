using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// DistributorSettingsController
	/// <author></author>
	/// <date>09/07/07</date>
	/// </summary>
	public class DistributorTerritoryController
	{
		

		#region Constructors
		public DistributorTerritoryController()
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


		
		public DataTable SelectDistributorTerritory(int p_Distributor_Id, int p_Territory_Id, bool p_Is_Active, int p_User_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR_TERRITORY  mDistributor = new spSelectDISTRIBUTOR_TERRITORY();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributor.TERRITORY_ID = p_Territory_Id;
				mDistributor.IS_ACTIVE = p_Is_Active;
				mDistributor.USER_ID = p_User_Id;
				mDistributor.TIME_STAMP = Constants.DateNullValue;
				mDistributor.LASTUPDATE_DATE = Constants.DateNullValue;
				mDistributor.IP_ADDRESS = null;
				                
				DataTable dt = mDistributor.ExecuteTable();
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
	
		public string InsertDistributorTerritory(int p_Distributor_Id, int p_Territory_Id, bool p_Is_Active, int p_User_Id, string p_Ip_Address) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDISTRIBUTOR_TERRITORY  mDistributor = new spInsertDISTRIBUTOR_TERRITORY();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributor.TERRITORY_ID = p_Territory_Id;
				mDistributor.IS_ACTIVE = p_Is_Active;
				mDistributor.USER_ID = p_User_Id;
				mDistributor.TIME_STAMP = System.DateTime.Now;
				mDistributor.LASTUPDATE_DATE = System.DateTime.Now;
				mDistributor.IP_ADDRESS = p_Ip_Address;
                
				mDistributor.ExecuteQuery();
				return "Record Inserted";
				
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
	
		public string UpdateDistributorTerritory(int p_Distributor_Id, int p_Territory_Id, bool p_Is_Active, int p_User_Id, string p_Ip_Address) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateDISTRIBUTOR_TERRITORY  mDistributor = new spUpdateDISTRIBUTOR_TERRITORY();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributor.TERRITORY_ID = p_Territory_Id;
				mDistributor.IS_ACTIVE = p_Is_Active;
				mDistributor.USER_ID = p_User_Id;
				mDistributor.TIME_STAMP = System.DateTime.Now;
				mDistributor.LASTUPDATE_DATE = System.DateTime.Now;
				mDistributor.IP_ADDRESS = p_Ip_Address;
                
				mDistributor.ExecuteQuery();
				return "Record Updated.";
				
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
	
		public string DeletedDistributorTerritory(int p_Distributor_Id, int p_Territory_Id)
		{			
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spDeleteDISTRIBUTOR_TERRITORY mDistributor = new spDeleteDISTRIBUTOR_TERRITORY();
				mDistributor.Connection = mConnection;

				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributor.TERRITORY_ID = p_Territory_Id;

				mDistributor.ExecuteQuery();
				return "Record Deleted.";
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
	
		public DataTable SelectDistributorTerritory(int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDistTerritory mDistributor = new uspSelectDistTerritory();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				
				                
				DataTable dt = mDistributor.ExecuteTable();
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
		#endregion
	}
}
