using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for DistributorRouteController.
	/// </summary>
	public class DistributorRouteController
	{
		#region Constructor
		public DistributorRouteController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		public DataTable SelectDistributorRoute(long p_ROUTE_ID,int p_DISTRIBUTOR_ID,int p_TOWN_ID,long p_AREA_ID) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR_ROUTE mDistributor = new spSelectDISTRIBUTOR_ROUTE();
				mDistributor.Connection = mConnection;
				mDistributor.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mDistributor.AREA_ID = p_AREA_ID;
                mDistributor.TOWN_ID = p_TOWN_ID;  
				mDistributor.ROUTE_ID = p_ROUTE_ID;
                mDistributor.IS_ACTIVE = true;                 
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
	
		public string InsertDistributorRoute(long p_ROUTE_ID,int p_DISTRIBUTOR_ID,int p_TOWN_ID,long p_AREA_ID,string p_ROUTE_CODE,string p_ROUTE_NAME,bool P_IS_ACTIVE) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDISTRIBUTOR_ROUTE mDistributor = new spInsertDISTRIBUTOR_ROUTE();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mDistributor.AREA_ID = p_AREA_ID;
                mDistributor.ROUTE_ID = p_ROUTE_ID;
                mDistributor.TOWN_ID = p_TOWN_ID;
                mDistributor.ROUTE_CODE = p_ROUTE_CODE;
				mDistributor.ROUTE_NAME = p_ROUTE_NAME;
                mDistributor.IS_ACTIVE = P_IS_ACTIVE;
                mDistributor.TIME_STAMP = System.DateTime.Today;
                mDistributor.LASTUPDATE_DATE = System.DateTime.Today;                   
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
	
		public string UpdateDistributorRoute(long p_ROUTE_ID,int p_DISTRIBUTOR_ID,int p_TOWNID,long p_AREA_ID,string p_ROUTE_CODE,string p_ROUTE_NAME,bool p_IsActive) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateDISTRIBUTOR_ROUTE mDistributor = new spUpdateDISTRIBUTOR_ROUTE();
				mDistributor.Connection = mConnection;

                mDistributor.ROUTE_ID = p_ROUTE_ID;
				mDistributor.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mDistributor.AREA_ID = p_AREA_ID;
                mDistributor.TOWN_ID = p_TOWNID;
                mDistributor.LASTUPDATE_DATE = System.DateTime.Today;   
				mDistributor.ROUTE_CODE = p_ROUTE_CODE;
				mDistributor.ROUTE_NAME = p_ROUTE_NAME;
                mDistributor.IS_ACTIVE = p_IsActive;  
               
				mDistributor.ExecuteQuery();
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
	
		public string DeleteDistributorRoute(long p_ROUTE_ID,int p_DISTRIBUTOR_ID) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spDeleteDISTRIBUTOR_ROUTE mDistributor = new spDeleteDISTRIBUTOR_ROUTE();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
//				mDistributor.AREA_ID = p_AREA_ID;
//				mDistributor.TIME_STAMP = p_TIME_STAMP;
//				mDistributor.LASTUPDATE_DATE = p_LASTUPDATE_DATE;
//				mDistributor.ROUTE_CODE = p_ROUTE_CODE;
//				mDistributor.ROUTE_NAME = p_ROUTE_NAME;
				mDistributor.ROUTE_ID = p_ROUTE_ID;
				                
				mDistributor.ExecuteQuery();
				return "Record Deleted";
				
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


		public DataTable SelectRouteByArea(string strArea, int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectAreaRoute	mRoute = new uspSelectAreaRoute();
				mRoute.Connection = mConnection;

				mRoute.AREAS=strArea;
				mRoute.DISTRIBUTOR_ID=p_Distributor_Id;
				DataTable dt = mRoute.ExecuteTable();
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

		public DataTable SelectDistributorRouteInfo(int p_Distributor_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDISTRIBUTOR_ROUTE_INFO mDistributor = new uspSelectDISTRIBUTOR_ROUTE_INFO();
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
	}
}
