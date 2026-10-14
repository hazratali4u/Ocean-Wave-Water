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
	/// <date></date>
	/// </summary>
	public class DistributorSettingsController
	{
		#region Constructors
		public DistributorSettingsController()
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


		
		public DataTable SelectDistributorSettings(int p_Distributor_Settings_Id, int p_Distributor_Id, short p_Transfer_Time, bool p_Is_GST_Paid_By_Dist, bool p_Is_TP_Update, bool p_Is_RP_Update, bool p_Is_TaxPrice_Update, bool p_Can_Add_New, bool p_Can_Disable_Server_To) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR_SETTINGS mDistributor = new spSelectDISTRIBUTOR_SETTINGS();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_SETTINGS_ID = p_Distributor_Settings_Id;
				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributor.TRANSFER_TIME = p_Transfer_Time;
				mDistributor.ISGST_PAID_BY_DIST = p_Is_GST_Paid_By_Dist;
				mDistributor.ISTP_UPDATE = p_Is_TP_Update;
				mDistributor.ISRP_UPDATE = p_Is_RP_Update;
				mDistributor.ISTAXPRICE_UPDATE = p_Is_TaxPrice_Update;
				mDistributor.CAN_ADD_NEW_TO = p_Can_Add_New;
				mDistributor.CAN_DISABLE_SERVER_TO = p_Can_Disable_Server_To;
                
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

		public DataTable SelectDTDistributorSettings(int p_Distributor_Settings_Id, int p_Distributor_Id, short p_Transfer_Time, bool p_Is_GST_Paid_By_Dist, bool p_Is_TP_Update, bool p_Is_RP_Update, bool p_Is_TaxPrice_Update, bool p_Can_Add_New, bool p_Can_Disable_Server_To) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDTDISTRIBUTOR_SETTINGS mDistributor = new spSelectDTDISTRIBUTOR_SETTINGS();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_SETTINGS_ID = p_Distributor_Settings_Id;
				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributor.TRANSFER_TIME = p_Transfer_Time;
				mDistributor.ISGST_PAID_BY_DIST = p_Is_GST_Paid_By_Dist;
				mDistributor.ISTP_UPDATE = p_Is_TP_Update;
				mDistributor.ISRP_UPDATE = p_Is_RP_Update;
				mDistributor.ISTAXPRICE_UPDATE = p_Is_TaxPrice_Update;
				mDistributor.CAN_ADD_NEW_TO = p_Can_Add_New;
				mDistributor.CAN_DISABLE_SERVER_TO = p_Can_Disable_Server_To;
                
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
	
		public DataTable SelectDistributorSettings(int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDISTRIBUTOR_SETTINGS mDistributor = new uspSelectDISTRIBUTOR_SETTINGS();
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
	
		

		public string InsertDistributorSettings(int p_Distributor_Id, short p_Transfer_Time, bool p_Is_GST_Paid_By_Dist, bool p_Is_TP_Update, bool p_Is_RP_Update, bool p_Is_TaxPrice_Update, bool p_Can_Add_New, bool p_Can_Disable_Server_To) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDISTRIBUTOR_SETTINGS mDistributor = new spInsertDISTRIBUTOR_SETTINGS();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributor.TRANSFER_TIME = p_Transfer_Time;
				mDistributor.ISGST_PAID_BY_DIST = p_Is_GST_Paid_By_Dist;
				mDistributor.ISTP_UPDATE = p_Is_TP_Update;
				mDistributor.ISRP_UPDATE = p_Is_RP_Update;
				mDistributor.ISTAXPRICE_UPDATE = p_Is_TaxPrice_Update;
				mDistributor.CAN_ADD_NEW_TO = p_Can_Add_New;
				mDistributor.CAN_DISABLE_SERVER_TO = p_Can_Disable_Server_To;
                
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
	
		public string UpdateDistributorSettings(int p_Distributor_Settings_Id, int p_Distributor_Id, short p_Transfer_Time, bool p_Is_GST_Paid_By_Dist, bool p_Is_TP_Update, bool p_Is_RP_Update, bool p_Is_TaxPrice_Update, bool p_Can_Add_New, bool p_Can_Disable_Server_To) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateDISTRIBUTOR_SETTINGS mDistributor = new spUpdateDISTRIBUTOR_SETTINGS();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_SETTINGS_ID = p_Distributor_Settings_Id;
				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributor.TRANSFER_TIME = p_Transfer_Time;
				mDistributor.ISGST_PAID_BY_DIST = p_Is_GST_Paid_By_Dist;
				mDistributor.ISTP_UPDATE = p_Is_TP_Update;
				mDistributor.ISRP_UPDATE = p_Is_RP_Update;
				mDistributor.ISTAXPRICE_UPDATE = p_Is_TaxPrice_Update;
				mDistributor.CAN_ADD_NEW_TO = p_Can_Add_New;
				mDistributor.CAN_DISABLE_SERVER_TO = p_Can_Disable_Server_To;
                
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
	
		public string DeletedDistributorSettings(string p_Distributor_Id)
		{			
			IDbConnection mConnection = null;
			try
			{
				return "";
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


		public string InsertDTDistributorSettings(int p_Distributor_Id, short p_Transfer_Time, bool p_Is_GST_Paid_By_Dist, bool p_Is_TP_Update, bool p_Is_RP_Update, bool p_Is_TaxPrice_Update, bool p_Can_Add_New, bool p_Can_Disable_Server_To,int p_Distributor_Settings_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDTDISTRIBUTOR_SETTINGS mDistributor = new spInsertDTDISTRIBUTOR_SETTINGS();
				mDistributor.Connection = mConnection;
				
				mDistributor.DISTRIBUTOR_SETTINGS_ID = p_Distributor_Settings_Id;
				mDistributor.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributor.TRANSFER_TIME = p_Transfer_Time;
				mDistributor.ISGST_PAID_BY_DIST = p_Is_GST_Paid_By_Dist;
				mDistributor.ISTP_UPDATE = p_Is_TP_Update;
				mDistributor.ISRP_UPDATE = p_Is_RP_Update;
				mDistributor.ISTAXPRICE_UPDATE = p_Is_TaxPrice_Update;
				mDistributor.CAN_ADD_NEW_TO = p_Can_Add_New;
				mDistributor.CAN_DISABLE_SERVER_TO = p_Can_Disable_Server_To;
                
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
		public string InsertDistributor_Settings( int p_Distributor_Id, short p_Transfer_Time , bool IsGstPaid_By_Dist , bool IsTp_Update , bool IsRp_Update , bool IsTaxPrice_Update , bool p_Can_Add_New_To , bool Can_Disable_Server_To )
		{
			IDbConnection mConnection = null;
			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
			
				uspInsertDISTRIBUTOR_SETTINGS uspInsertDist_Settings = new uspInsertDISTRIBUTOR_SETTINGS();
                uspInsertDist_Settings.Connection =  mConnection;
                uspInsertDist_Settings.CAN_ADD_NEW_TO = p_Can_Add_New_To;
                uspInsertDist_Settings.CAN_DISABLE_SERVER_TO = Can_Disable_Server_To;
                uspInsertDist_Settings.DISTRIBUTOR_ID = p_Distributor_Id;
                uspInsertDist_Settings.ISGST_PAID_BY_DIST = IsGstPaid_By_Dist;
                uspInsertDist_Settings.ISRP_UPDATE = IsRp_Update;
                uspInsertDist_Settings.ISTAXPRICE_UPDATE =IsTaxPrice_Update;
                uspInsertDist_Settings.ISTP_UPDATE = IsTp_Update;
                uspInsertDist_Settings.TRANSFER_TIME = p_Transfer_Time;
                uspInsertDist_Settings.ExecuteQuery();
                return uspInsertDist_Settings.DISTRIBUTOR_SETTINGS_ID.ToString();

			}
			catch(Exception excp)
			{
				ExceptionPublisher.PublishException(excp);				
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
