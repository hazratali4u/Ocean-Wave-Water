using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for CustomerProximityController.
	/// </summary>
	public class CustomerProximityController
	{
		public CustomerProximityController()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string InsertCustomerProximity(long p_Customer_Id,int p_Distributor_Id,int p_Sequence_Number)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertCUSTOMER_PROXIMITY mCustomerProx = new spInsertCUSTOMER_PROXIMITY();
				mCustomerProx.Connection = mConnection;
				
				mCustomerProx.CUSTOMER_ID=p_Customer_Id;
				mCustomerProx.DISTRIBUTOR_ID=p_Distributor_Id;
				//mCustomerProx.PROXIMITY_ID=p_Proximity_Id;
				mCustomerProx.SEQUENCE_NUMBER=p_Sequence_Number;

                
				mCustomerProx.ExecuteQuery();
				
				return mCustomerProx.PROXIMITY_ID.ToString();
				
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

		public DataTable SelectCustomerProximity(long p_Customer_Id,long p_Proximity_Id,int p_Distributor_Id,int p_Sequence_Number)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectCUSTOMER_PROXIMITY mCustomerProx = new spSelectCUSTOMER_PROXIMITY();
				mCustomerProx.Connection = mConnection;
				
				mCustomerProx.CUSTOMER_ID=p_Customer_Id;
				mCustomerProx.DISTRIBUTOR_ID=p_Distributor_Id;
				mCustomerProx.PROXIMITY_ID=p_Proximity_Id;
				mCustomerProx.SEQUENCE_NUMBER=p_Sequence_Number;
                
				
				
				return mCustomerProx.ExecuteTable();
				
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

		public string UpdateCustomerProximity(long p_Customer_Id,long p_Proximity_Id,int p_Distributor_Id,int p_Sequence_Number)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateCUSTOMER_PROXIMITY mCustomerProx = new spUpdateCUSTOMER_PROXIMITY();
				mCustomerProx.Connection = mConnection;
				
				mCustomerProx.CUSTOMER_ID=p_Customer_Id;
				mCustomerProx.DISTRIBUTOR_ID=p_Distributor_Id;
				mCustomerProx.PROXIMITY_ID=p_Proximity_Id;
				mCustomerProx.SEQUENCE_NUMBER=p_Sequence_Number;
                
				mCustomerProx.ExecuteQuery();
				
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

		public DataTable SelectCustomerProxRoute(int p_Distributor_Id,int p_Route_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectCUSTOMER_PROX_ROUTE mCustomerProx = new uspSelectCUSTOMER_PROX_ROUTE();
				mCustomerProx.Connection = mConnection;
				
				
				mCustomerProx.DISTRIBUTOR_ID=p_Distributor_Id;
				mCustomerProx.ROUTE_ID=p_Route_Id;
                
				
				
				return mCustomerProx.ExecuteTable();
				
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
