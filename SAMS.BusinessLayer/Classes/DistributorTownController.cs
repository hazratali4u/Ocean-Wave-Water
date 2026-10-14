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
	public class DistributorTownController
	{
		
		#region Constructors
		public DistributorTownController()
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



        public string InsertDistributorTown(int p_Distributor_Id, int p_Town_Id, bool p_Is_Active, int p_AREA_Id, string p_Ip_Address, int p_UserId) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDISTRIBUTOR_TOWN mDistributor = new spInsertDISTRIBUTOR_TOWN();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributor.TOWN_ID = p_Town_Id;
				mDistributor.IS_ACTIVE = p_Is_Active;
				mDistributor.USER_ID = p_UserId;
                mDistributor.TIME_STAMP = System.DateTime.Now ;
				mDistributor.LASTUPDATE_DATE = System.DateTime.Now ;
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
	
		public string UpdateDistributorTown(int p_Distributor_Id, int p_Town_Id, bool p_Is_Active, int p_User_Id, string p_Ip_Address) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateDISTRIBUTOR_TOWN mDistributor = new spUpdateDISTRIBUTOR_TOWN();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributor.TOWN_ID = p_Town_Id;
				mDistributor.IS_ACTIVE = p_Is_Active;
				mDistributor.USER_ID = p_User_Id;
				mDistributor.TIME_STAMP = System.DateTime.Now ;
				mDistributor.LASTUPDATE_DATE = System.DateTime.Now ;
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
	
		public string DeletedDistributorTown(int p_Distributor_Id, int p_Town_Id)
		{			
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spDeleteDISTRIBUTOR_TOWN mDistributor = new spDeleteDISTRIBUTOR_TOWN ();
				mDistributor.Connection = mConnection;

				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributor.TOWN_ID = p_Town_Id;
                
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

		public DataTable SelectDistributorTownInfo(int p_Distributor_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDistTown mDistributor = new uspSelectDistTown();
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
