using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{	
	/// <summary>
	/// Summary description for SYNC_LOGController.
	/// </summary>
	public class SYNC_LOGController
	{
		# region Variable
		public static int Dist_Sync_Act_ID;
		#endregion
		#region Constructor
		public SYNC_LOGController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods

		public string InsertSYNC_LOG(int p_Sync_Log_Id, bool p_Is_Closed,DateTime p_Log_Date,int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertSYNC_LOG mSyncLog = new spInsertSYNC_LOG();
				mSyncLog.Connection = mConnection;
				
				mSyncLog.SYNC_LOG_ID = p_Sync_Log_Id;
				mSyncLog.IS_CLOSED = p_Is_Closed;
				mSyncLog.LOG_DATE  = p_Log_Date;
				mSyncLog.DISTRIBUTOR_ID = p_Distributor_Id;
				

				mSyncLog.ExecuteQuery();
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


		public string UpdateSYNC_LOG(bool p_Is_Closed,DateTime p_Log_Date,int p_Distributor_Id,int p_Sync_Log_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				return UpdateSYNC_LOG(p_Is_Closed, p_Log_Date, p_Distributor_Id, p_Sync_Log_Id, mConnection, null);
				
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

		public string UpdateSYNC_LOG(bool p_Is_Closed,DateTime p_Log_Date,int p_Distributor_Id,int p_Sync_Log_Id, IDbConnection p_Connection, IDbTransaction p_Transaction )
		{
			try
			{
				spUpdateSYNC_LOG mSyncLog = new spUpdateSYNC_LOG();
				mSyncLog.Connection = p_Connection;
				mSyncLog.Transaction = p_Transaction;
				
				mSyncLog.IS_CLOSED = p_Is_Closed;
				mSyncLog.LOG_DATE = p_Log_Date;
				mSyncLog.DISTRIBUTOR_ID = p_Distributor_Id;
				mSyncLog.SYNC_LOG_ID = p_Sync_Log_Id;

				mSyncLog.ExecuteQuery();
				return mSyncLog.SYNC_LOG_ID.ToString ();
				
			}			
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
			}
			finally
			{
			}
		}

		public int GetSync_Log_Id(int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spSelectSYNC_LOG mSyncLog = new spSelectSYNC_LOG();
				mSyncLog.Connection = mConnection;
								
				mSyncLog.SYNC_LOG_ID = Constants.IntNullValue;
				mSyncLog.DISTRIBUTOR_ID = p_Distributor_Id;
				mSyncLog.LOG_DATE = Constants.DateNullValue;
				mSyncLog.IS_CLOSED = false;

				DataTable dt = mSyncLog.ExecuteTable();
				DataRow dr = dt.Rows[0];
				return int.Parse(dr[0].ToString());
			}			
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				throw exp;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
				
			}
		}

		public DateTime GetSync_UnClosedDate(int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spSelectSYNC_LOG mSyncLog = new spSelectSYNC_LOG();
				mSyncLog.Connection = mConnection;
								
				mSyncLog.SYNC_LOG_ID = Constants.IntNullValue;
				mSyncLog.DISTRIBUTOR_ID = p_Distributor_Id;
				mSyncLog.LOG_DATE = Constants.DateNullValue;
				mSyncLog.IS_CLOSED = false;

				DataTable dt = mSyncLog.ExecuteTable();
				DataRow dr = dt.Rows[0];
				return DateTime.Parse(dr[2].ToString());
			}			
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				throw exp;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
				
			}
		}


		public DataTable SelectSYNC_LOG_ForClosing(DateTime p_Log_Date,int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectSync_LogForClosing mSyncLog = new uspSelectSync_LogForClosing();
				mSyncLog.Connection = mConnection;
				
				mSyncLog.LOG_DATE = p_Log_Date;
				mSyncLog.DISTRIBUTOR_ID = p_Distributor_Id;
				
				DataTable dt = new DataTable();
				dt = mSyncLog.ExecuteTable();
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

		#region Public Static Methods

		public static bool InsertDistSyncActivity(int p_DistributorID, bool p_Is_Successful)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertDISTRIBUTOR_SYNC_ACTIVITY spInsDistSyncAct = new spInsertDISTRIBUTOR_SYNC_ACTIVITY();
				spInsDistSyncAct.Connection = mConnection;
				spInsDistSyncAct.DISTRIBUTOR_ID = p_DistributorID;
				spInsDistSyncAct.IS_SUCCESSFUL = p_Is_Successful;
				spInsDistSyncAct.TIME_STAMP = DateTime.Now;
				spInsDistSyncAct.ExecuteQuery();
				Dist_Sync_Act_ID = spInsDistSyncAct.DISTRIBUTOR_SYNC_ACTIVITY_ID; 
				return true;
			}
			catch(Exception ex)
			{
				ExceptionPublisher.PublishException(ex);				
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
		public static bool InsertDistSyncActivityDetail(int Dist_Sync_Act_ID,int p_Activity_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL spInsDistSyncActDet = new spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL();
				spInsDistSyncActDet.Connection = mConnection;

				spInsDistSyncActDet.ACTIVITY_ID = p_Activity_Id;
				spInsDistSyncActDet.DISTRIBUTOR_SYNC_ACTIVITY_ID = Dist_Sync_Act_ID;
				spInsDistSyncActDet.TIME_STAMP = DateTime.Now;
				
				spInsDistSyncActDet.ExecuteQuery();
				return true;
			}
			catch(Exception ex)
			{
				ExceptionPublisher.PublishException(ex);				
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
		public static bool UpdateDistSyncActivity(int p_Dist_Sync_Act_ID, int p_DistributorID, bool p_Is_Successful)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spUpdateDISTRIBUTOR_SYNC_ACTIVITY spUpdDistSyncAct = new spUpdateDISTRIBUTOR_SYNC_ACTIVITY();
				spUpdDistSyncAct.Connection = mConnection;
				spUpdDistSyncAct.DISTRIBUTOR_ID = p_DistributorID;
				spUpdDistSyncAct.IS_SUCCESSFUL = p_Is_Successful;
				spUpdDistSyncAct.DISTRIBUTOR_SYNC_ACTIVITY_ID = p_Dist_Sync_Act_ID;
				spUpdDistSyncAct.TIME_STAMP = DateTime.Now;
				spUpdDistSyncAct.ExecuteQuery();
				return true;
			}
			catch(Exception ex)
			{
				ExceptionPublisher.PublishException(ex);				
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
		
		
		/// using Sync_Log table from SAMS_DB, set identity off for this table
		/// on insertion of any distributor id .. get the max synlogid against that distributor from table
		/// increment 1 and insert that value in synlogid column ... for that distributor ....
		
		public static int GetMaxSynLogID(int p_DistributorID)
		{
			int SynLogID =0;
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				uspMaxSyncLogID mspMaxSyncLogID = new uspMaxSyncLogID();
				mspMaxSyncLogID.Connection = mConnection;
				mspMaxSyncLogID.DISTRIBUTOR_ID = p_DistributorID;
				
				DataTable dt = mspMaxSyncLogID.ExecuteTable();
				if(dt.Rows.Count>0)
					SynLogID = int.Parse(dt.Rows[0][0].ToString());
				// incrementing SyncLogID for distributor
				return SynLogID;
			}
			catch(Exception ex)
			{
				ExceptionPublisher.PublishException(ex);				
				return 0;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		}
		public static int GetMaxSynLogID(int p_DistributorID, bool p_Is_Successful)
		{
			int SynLogID =0;
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				uspSelectSERVER_SYNC_LOG mspMaxSyncLogID = new uspSelectSERVER_SYNC_LOG();
				mspMaxSyncLogID.Connection = mConnection;
				mspMaxSyncLogID.DISTRIBUTOR_ID = p_DistributorID;
				mspMaxSyncLogID.IS_SUCCESSFUL = p_Is_Successful;
				
				DataTable dt = mspMaxSyncLogID.ExecuteTable();
				if(dt.Rows.Count>0)
				{
					SynLogID = int.Parse(dt.Rows[0][0].ToString());
				}
				else
				{
					SynLogID = -1;
				}

				
				return SynLogID;
			}
			catch(Exception ex)
			{
				ExceptionPublisher.PublishException(ex);				
				return 0;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		}

		public string InsertServer_Sync_Log(int p_Log_Id, int p_Dist_Id, bool p_Is_Successful)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertSERVER_SYNC_LOG mLog = new spInsertSERVER_SYNC_LOG();
					
				mLog.Connection = mConnection;

				mLog.IS_SUCCESSFUL = p_Is_Successful;
				mLog.LOG_ID = p_Log_Id;
                mLog.DISTRIBUTOR_ID = p_Dist_Id;
				mLog.LOG_DATE = System.DateTime.Now;
                				
				mLog.ExecuteQuery();
				
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

		public string InsertTrans_Sync_Log(int p_Trans_Log_Id, long p_Log_Detail_Id, int p_Dist_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertTRANS_SYNC_LOG mLog = new spInsertTRANS_SYNC_LOG();
					
				mLog.Connection = mConnection;

				mLog.TRANS_LOG_ID = p_Trans_Log_Id;
				mLog.LOG_DETAIL_ID = p_Log_Detail_Id;
				mLog.DISTRIBUTOR_ID = p_Dist_Id;				
                					
				mLog.ExecuteQuery();
				
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


		#region For Activity Log
		public int GetExistsMaxId(int Distributor_id,int ActivityID)
		{
			IDbConnection mConnection = null;
			int ExistsId = 0;
			try
			{
				
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spProcessDistLog_Activity ActivityProcess = new spProcessDistLog_Activity();
				
				ActivityProcess.Connection = mConnection;

				ActivityProcess.Type = 3;
				ActivityProcess.DIST_ACTIVITYID = Constants.IntNullValue;
				ActivityProcess.DIST_ACT_ID = Distributor_id;
				ActivityProcess.ACTIVITY_ID = ActivityID;
				DataTable dt = ActivityProcess.ExecuteTable();

				if (dt.Rows.Count > 0 )
				{
					ExistsId  = int.Parse(dt.Rows[0][0].ToString());  
				}
  				return ExistsId;
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return ExistsId;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

		}

		public bool CheckBeforeExists(int Dis_ActivityID,int ActivityID)
		{
			IDbConnection mConnection = null;
			try
			{
				
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spProcessDistLog_Activity ActivityProcess = new spProcessDistLog_Activity();
				
				ActivityProcess.Connection = mConnection;

				ActivityProcess.Type = 1;
				ActivityProcess.DIST_ACTIVITYID = Constants.IntNullValue;
				ActivityProcess.DIST_ACT_ID = Dis_ActivityID;
				ActivityProcess.ACTIVITY_ID = ActivityID;
				DataTable dt = ActivityProcess.ExecuteTable();
				if (dt.Rows.Count> 0)return false;
				else return true;
  		
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
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

		public bool UpdateDisActivityMaster(int DIST_ACTIVITYID)
		{
			IDbConnection mConnection = null;
			try
			{
			
				
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spProcessDistLog_Activity ActivityProcess = new spProcessDistLog_Activity();
				
				ActivityProcess.Connection = mConnection;
				
				ActivityProcess.Type = 2;
				ActivityProcess.DIST_ACTIVITYID = DIST_ACTIVITYID;
				ActivityProcess.DIST_ACT_ID = Constants.IntNullValue;
				ActivityProcess.ACTIVITY_ID = Constants.IntNullValue;
				ActivityProcess.ExecuteQuery(); 
								
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return false;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
			return true;
		}

		public bool SetDisActivityDetail(long Dis_ActivityID,long ActivityID)
		{
			IDbConnection mConnection = null;
			try
			{
				
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spDISTACTIVIESDETAIL spDisAct = new spDISTACTIVIESDETAIL();
				spDisAct.Connection = mConnection;
				spDisAct.DIST_ACT_ID = Dis_ActivityID;
				spDisAct.ACTIVITY_ID = ActivityID;
				spDisAct.DATE_TIME =  System.DateTime.Now.ToString();
				spDisAct.ExecuteQuery(); 
							
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return false;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

			return true;
		}

		public int SetDistActivityMaster(string DistributorID,long Activity)
		{
			int Dis_ActivityID=-1;
			IDbConnection mConnection = null;
			//if(clsConstants.START_REQUEST!=ActivityID)return -1;
			try
			{
											
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spDISTACTIVIES spDisAct = new spDISTACTIVIES();

				spDisAct.Connection = mConnection;
				spDisAct.DISTRIBUTOR_ID = DistributorID; 
				spDisAct.ACTIVITY =  Activity;
				spDisAct.DATE_TIME = System.DateTime.Now;   
				DataTable dt  = spDisAct.ExecuteTable();
				Dis_ActivityID = Int16.Parse(dt.Rows[0][0].ToString());
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return 0;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

		return Dis_ActivityID;
		}

		#endregion 

		#endregion
	}
}
