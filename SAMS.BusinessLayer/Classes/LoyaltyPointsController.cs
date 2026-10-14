using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for LoyaltyPointsController.
	/// </summary>
	public class LoyaltyPointsController
	{
		public static IDbConnection mConnection ;

		public LoyaltyPointsController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public static void DeleteLoyaltyPoint(long loyalty_point_id)
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
				spUpdateLOYALTY_POINTS  delloyalty_points = new spUpdateLOYALTY_POINTS();
				delloyalty_points.Connection = mConnection;
				delloyalty_points.AMOUNT  = Constants.DecimalNullValue; 
				delloyalty_points.START_DATE = Constants.DateNullValue;
				delloyalty_points.END_DATE = Constants.DateNullValue;
				delloyalty_points.IS_ACTIVE = false;
				delloyalty_points.LASTUPDATE_DATE = Constants.DateNullValue;
				delloyalty_points.LOYALTY_POINT_ID = loyalty_point_id;
				delloyalty_points.REDEMPTION_PERIOD = Constants.IntNullValue;
				delloyalty_points.REDEMPTION_TIME = Constants.IntNullValue;
				delloyalty_points.SKU_ID = Constants.IntNullValue;
				delloyalty_points.TIME_STAMP = Constants.DateNullValue;
				delloyalty_points.ExecuteQuery();
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
		public DataTable GetAllLoyalty_Points()
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
				spSelectLOYALTY_POINTS loyalty_points = new spSelectLOYALTY_POINTS();
				loyalty_points.Connection = mConnection;
				loyalty_points.TLPCODE = null;
				loyalty_points.TLPNAME = null;
				loyalty_points.START_DATE  = Constants.DateNullValue;
				loyalty_points.END_DATE  = Constants.DateNullValue;
				loyalty_points.IS_ACTIVE = true;
				loyalty_points.LASTUPDATE_DATE = Constants.DateNullValue;
				loyalty_points.LOYALTY_POINT_ID = Constants.LongNullValue;
				loyalty_points.AMOUNT = Constants.DecimalNullValue; 
				loyalty_points.REDEMPTION_PERIOD = Constants.IntNullValue;
				loyalty_points.REDEMPTION_TIME = Constants.IntNullValue;
				loyalty_points.SKU_ID = Constants.IntNullValue;
				loyalty_points.TIME_STAMP = Constants.DateNullValue;
				DataTable tblloyalty_points =   loyalty_points.ExecuteTable();
				return (tblloyalty_points);
  
			
    			
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
		public static void  UpdateLoyalty_Points(long lpoint_id,int sku_id,int Amount,int redemption_time , int redemption_period , DateTime start_date,DateTime end_date,bool IsBouns)
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
				spUpdateLOYALTY_POINTS update_loyalty_points =new spUpdateLOYALTY_POINTS();
				update_loyalty_points.Connection = mConnection;
				update_loyalty_points.START_DATE = start_date;
				update_loyalty_points.END_DATE = end_date; 
				update_loyalty_points.LASTUPDATE_DATE = DateTime.Now;
				update_loyalty_points.LOYALTY_POINT_ID = lpoint_id;
				update_loyalty_points.AMOUNT = Amount;
				update_loyalty_points.REDEMPTION_PERIOD = redemption_period;
				update_loyalty_points.REDEMPTION_TIME = redemption_time ;
				update_loyalty_points.SKU_ID = sku_id;
				update_loyalty_points.ISBOUNS  = IsBouns;
				update_loyalty_points.TIME_STAMP = Constants.DateNullValue;
				update_loyalty_points.IS_ACTIVE = true;
				update_loyalty_points.ExecuteQuery();
    			
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
		public static long InsertLoyalty_Points(string p_TLPCODE,string p_TLPNAME,int sku_id ,int customer_type_id ,int Amount , int redemption_time , int redemption_period , DateTime start_date,DateTime end_date,bool IsBouns )  
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
				spInsertLOYALTY_POINTS loyalty_points = new spInsertLOYALTY_POINTS();
				loyalty_points.Connection = mConnection;
				loyalty_points.TLPCODE = p_TLPCODE;
				loyalty_points.TLPNAME  = p_TLPNAME;
				loyalty_points.START_DATE = start_date; 
				loyalty_points.END_DATE = end_date;
				loyalty_points.IS_ACTIVE = true;
				loyalty_points.LASTUPDATE_DATE = DateTime.Now;
				loyalty_points.AMOUNT  = Amount;
				loyalty_points.REDEMPTION_PERIOD = redemption_period;
				loyalty_points.REDEMPTION_TIME = redemption_time;
				loyalty_points.SKU_ID = sku_id;
				loyalty_points.TIME_STAMP = DateTime.Now;
				loyalty_points.ISBOUNS  = IsBouns; 
				loyalty_points.ExecuteQuery();
				return(loyalty_points.LOYALTY_POINT_ID) ;
	 			
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
	 

		public static long InsertDistributor(int LoyalpointId,int  Distributorid)  
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
				spInsertLOYALTYPOINT_DISTRIBUTOR Insertdata = new spInsertLOYALTYPOINT_DISTRIBUTOR();
				Insertdata.Connection = mConnection;
				Insertdata.LOYALTYPOINT_ID = LoyalpointId;
				Insertdata.DISTRIBUTOR_ID = Distributorid; 
				Insertdata.TIME_STAMP = System.DateTime.Now.Date;    
				Insertdata.ExecuteQuery();
				return(Insertdata.LOYALTYPOINT_DISTRIBUTOR_ID);

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
	 
	
		public static long InsertTlpPerson(string p_code,string p_name,DateTime p_date,string p_nic,decimal p_balance_point)
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
				spInsertTLP_PERSON  Insertdata = new spInsertTLP_PERSON();

				Insertdata.Connection = mConnection;
				Insertdata.TLP_PERSON_CODE = p_code;
				Insertdata.TLP_PERSON_NAME = p_name;
				Insertdata.DATE_OF_REGISTRATION = p_date;
				Insertdata.NIC = p_nic;
				Insertdata.TOTAL_POINT = p_balance_point;
				Insertdata.USED_POINT = 0;
				Insertdata.REDEMPTED_POINT = 0;
				Insertdata.BALANCE_POINT = p_balance_point ;
				Insertdata.IS_ACTIVE = true;
				Insertdata.TIME_STAMP = DateTime.Now.Date;
				Insertdata.USER_ID = Configuration.UserID;
				Insertdata.LASTUPDATE_DATE = DateTime.Now.Date;
				Insertdata.ExecuteQuery();
		
				return(Insertdata.TLP_PERSON_ID);  
				
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
	 

		public static long UpdateTlpPerson(long p_id,string p_code,string p_name,DateTime p_date,string p_nic,bool p_Active)
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
				spUpdateTLP_PERSON UpdateData = new spUpdateTLP_PERSON(); 

				UpdateData.Connection = mConnection;
				UpdateData.TLP_PERSON_ID = p_id;
				UpdateData.TLP_PERSON_CODE = p_code;
				UpdateData.TLP_PERSON_NAME = p_name;
				UpdateData.DATE_OF_REGISTRATION = p_date;
				UpdateData.NIC = p_nic;
				UpdateData.TOTAL_POINT = Constants.DecimalNullValue; 
				UpdateData.USED_POINT = Constants.DecimalNullValue;
				UpdateData.REDEMPTED_POINT = Constants.DecimalNullValue;
				UpdateData.BALANCE_POINT = Constants.DecimalNullValue;
				UpdateData.IS_ACTIVE = p_Active;
				UpdateData.TIME_STAMP = DateTime.Now.Date;
				UpdateData.USER_ID = Configuration.UserID;
				UpdateData.LASTUPDATE_DATE = DateTime.Now.Date;
				UpdateData.ExecuteQuery();
				return(UpdateData.TLP_PERSON_ID);  
			
    			
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
	 

		public static long InsertTlpPersonCustomer(int p_CustomerId,long p_TlpPersonId)
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
				spInsertCUSTOMER_TLP_PERSON insertdata = new spInsertCUSTOMER_TLP_PERSON(); 
				insertdata.Connection = mConnection;
			
				insertdata.CUSTOMER_ID = p_CustomerId;
				insertdata.TLP_PERSON_ID = p_TlpPersonId;
				insertdata.USER_ID = Configuration.UserID;
				insertdata.IS_ACTIVE = true;
				insertdata.LASTUPDATE_DATE = DateTime.Now.Date;
				insertdata.TIME_STAMP = DateTime.Now.Date;
				insertdata.ExecuteQuery();
				return(insertdata.CUSTOMER_TLP_PERSON_ID); 
	
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
	 

		public DataTable GetAllLTlpPerson()
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{

				mConnection.Open();
				uspSelectTLP_PERSONInfo TlpPerson = new uspSelectTLP_PERSONInfo();
 
				TlpPerson.Connection = mConnection;
			
				TlpPerson.IS_ACTIVE = true;
						
				DataTable tblloyalty_points =   TlpPerson.ExecuteTable();
			
			
				return (tblloyalty_points);
  
    			
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


		#region Loyalty Points for Customer

		public DataTable SelectTownByLoyaltyPoints(int p_LoyaltyPointId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectTownByLoyaltyPoint mTown = new uspSelectTownByLoyaltyPoint();
				mTown.Connection = mConnection;							

				mTown.LOYALTY_POINT_ID=p_LoyaltyPointId;
									            
				DataTable dt = mTown.ExecuteTable();
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

		public DataTable SelectAreaByLoyaltyPoints(int p_LoyaltyPointId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectAreaByLoyaltyPoint mArea = new uspSelectAreaByLoyaltyPoint();
				mArea.Connection = mConnection;							

				mArea.LOYALTY_POINT_ID=p_LoyaltyPointId;
									            
				DataTable dt = mArea.ExecuteTable();
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

		public DataTable SelectRouteByLoyaltyPoints(int p_LoyaltyPointId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectRouteByLoyaltyPoint mRoute = new uspSelectRouteByLoyaltyPoint();
				mRoute.Connection = mConnection;							

				mRoute.LOYALTY_POINT_ID=p_LoyaltyPointId;
									            
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

		public DataTable SelectCustomerByLoyaltyPoints(int p_LoyaltyPointId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectCustomerByLoyaltyPoint mCustomer = new uspSelectCustomerByLoyaltyPoint();
				mCustomer.Connection = mConnection;							

				mCustomer.LOYALTY_POINT_ID=p_LoyaltyPointId;
									            
				DataTable dt = mCustomer.ExecuteTable();
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


		public static bool InsertLoyaltyPointsForCustomer(long p_LoyaltyPointId, int p_DistributorId, long p_TownId, long p_AreaId, long p_RouteId, long p_CustomerId)
		{
			IDbConnection mConnection = null;
			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertLOYALTY_FOR_CUSTOMER mInsertLPForCustomer = new spInsertLOYALTY_FOR_CUSTOMER();
				mInsertLPForCustomer.Connection =  mConnection;
				mInsertLPForCustomer.DISTRIBUTOR_ID =  p_DistributorId;
				mInsertLPForCustomer.LOYALTY_POINT_ID =  p_LoyaltyPointId;
				mInsertLPForCustomer.TOWN_ID  = p_TownId;
				mInsertLPForCustomer.AREA_ID   =  p_AreaId;
				mInsertLPForCustomer.ROUTE_ID  = p_RouteId;
				mInsertLPForCustomer.CUSTOMER_ID = p_CustomerId;
				mInsertLPForCustomer.ExecuteQuery();
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

		public static bool DeleteLPForCustomerByLPId(int p_LoyaltyPointId)
		{
			IDbConnection mConnection = null;
			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspDeleteLOYALTY_FOR_CUSTOMER_By_LPId mDeleteLPForCustomer = new uspDeleteLOYALTY_FOR_CUSTOMER_By_LPId();
				mDeleteLPForCustomer.Connection =  mConnection;
				mDeleteLPForCustomer.LOYALTY_POINT_ID =  p_LoyaltyPointId;
				mDeleteLPForCustomer.ExecuteQuery();
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

		#endregion
	}
}
