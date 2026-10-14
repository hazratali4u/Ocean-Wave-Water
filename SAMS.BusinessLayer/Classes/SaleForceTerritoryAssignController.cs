using System;
using SAMS.DatabaseLayer.Classes;
using System.Data;
using System.Data.SqlClient;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;
namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for SaleForceTerritoryAssignController.
	/// </summary>
	public class SaleForceTerritoryAssignController
	{
	   static IDbConnection mConnection;
 
		public SaleForceTerritoryAssignController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region SAVE TERRITORY

		public static void SaveTerritory(int USER_ID,int TERRITORY_ID,int DISTRIBUTOR_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				uspUpdateDistributor_User_Territory  save_territory = new uspUpdateDistributor_User_Territory();

				save_territory.Connection = mConnection;
				save_territory.DISTRIBUTOR_ID = DISTRIBUTOR_ID;
				save_territory.USER_ID = USER_ID;
				save_territory.TERRITORY_ID = TERRITORY_ID;
				string mResult = save_territory.ExecuteScalar();
				if(mResult == "0")
				{
					throw new Exception ("0");
				}
			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
				mConnection = null;
			}

           
		   
    
	       
		   
		}
		
		#endregion

		#region SELECT TERRITORY

		public static int SelectTerritory(int USER_ID,int DISTRIBUTOR_ID)
		{
			int TerritoryID= -1;
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
    			
			}
			catch(Exception exp)
			{
				throw exp;
			} 
			finally
			{
			}
        
			uspSelectDistributor_User_Territory select_territory = new uspSelectDistributor_User_Territory();
			select_territory.Connection = mConnection;
			select_territory.USER_ID = USER_ID;
			select_territory.DISTRIBUTOR_ID = DISTRIBUTOR_ID;
            
			if (select_territory.ExecuteScalar()!=null)
			{
				TerritoryID = int.Parse(select_territory.ExecuteScalar());
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
				mConnection = null;
				return TerritoryID;
	
			}
			else
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
				mConnection = null;
			
				return -1;
 
			}
		}
		
		#endregion

		#region  GET SAMS AND DISTRIBUTOR USERS
 
		public static DataTable GetSAMS_OR_DISTRIBUTOR_USERS(string SalesForceType)
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
    			
			}
			catch(Exception exp)
			{
				throw exp;
			} 
			finally
			{
			}

			if(SalesForceType  == "OB")
			{
	            uspSelectSAMS_USERS SAMS_users = new uspSelectSAMS_USERS();
				SAMS_users.Connection = mConnection;
                SAMS_users.USER_TYPE_ID = 50;
                DataTable objtblSAMSUser =   SAMS_users.ExecuteTable();
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
				mConnection = null;
			
				return objtblSAMSUser;

			}
			else if(SalesForceType == "DM")
 			{
    		
				uspSelectDISTRIBUTOR_USER  distributor_users = new uspSelectDISTRIBUTOR_USER();
				distributor_users.Connection = mConnection;
                distributor_users.USER_TYPE_ID = 50;
				DataTable objtblDistributorUser =  distributor_users.ExecuteTable();
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
				mConnection = null;
			
				return objtblDistributorUser;
			}
		return null;

		}

		public static DataTable SelectTerritoryWiseSalesForce(int p_Territory_ID,int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectTerritoryWiseSalesForce mController = new uspSelectTerritoryWiseSalesForce();
				mController.Connection = mConnection;
				mController.TERRITORY_ID = p_Territory_ID;
				mController.DISTRIBUTOR_ID = p_Distributor_Id;
				DataTable dt =mController.ExecuteTable();
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

        #region GET TERRITORY DATA
		public static DataTable GETTerritoryData()
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
    			
			}
			catch(Exception exp)
			{
				throw exp;
			} 
			finally
			{
			}
           uspSelectDistributor_Terri_Geo_Hierarchy territorys = new uspSelectDistributor_Terri_Geo_Hierarchy();
           territorys.Connection = mConnection;
 		   DataTable territory_data =  territorys.ExecuteTable();
			if(mConnection != null && mConnection.State == ConnectionState.Open)
			{
				mConnection.Close();
			}
			mConnection = null;
		return territory_data;
 
		}
		#endregion

	}
}
