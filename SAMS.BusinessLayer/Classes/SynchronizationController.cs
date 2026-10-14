using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using System.Net;
using System.IO;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for SynchronizationController.
	/// </summary>
	public class SynchronizationController
	{
		# region Constructor
		public SynchronizationController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		# region public Method

 		public int GetLOGID(int p_DISTRIBUTOR_ID, int p_IS_SUCCESSFUL)
		{
			int LogID =0;
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				uspSelectSERVER_SYNC_LOG mSelectServerSyncLog = new uspSelectSERVER_SYNC_LOG();
				mSelectServerSyncLog.Connection = mConnection;
				mSelectServerSyncLog.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mSelectServerSyncLog.IS_SUCCESSFUL = Convert.ToBoolean(p_IS_SUCCESSFUL);
			
				DataTable dt = mSelectServerSyncLog.ExecuteTable();
				if(dt.Rows.Count>0)
					LogID = int.Parse(dt.Rows[0][0].ToString());
				return LogID;
				
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
		}

		public bool UpdateServerSyncLog(int p_Log_ID, int p_DISTRIBUTOR_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspUpdateSERVER_SYNC_LOG mUpdateServerSyncLog = new uspUpdateSERVER_SYNC_LOG();
				mUpdateServerSyncLog.Connection = mConnection;

				mUpdateServerSyncLog.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mUpdateServerSyncLog.LOG_ID = p_Log_ID;
				mUpdateServerSyncLog.IS_SUCCESSFUL = true;
				Convert.ToInt16(mUpdateServerSyncLog.IS_SUCCESSFUL);
				mUpdateServerSyncLog.LOG_DATE = DateTime.Now;

				mUpdateServerSyncLog.ExecuteQuery();
				return true;

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
		public bool InsertServerSyncLog(int p_Log_ID, int p_DISTRIBUTOR_ID, DateTime p_Log_Date, int p_IS_Successful)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspInsertSERVER_SYNC_LOG mInsertServerSyncLog = new uspInsertSERVER_SYNC_LOG();
				mInsertServerSyncLog.Connection = mConnection;

				mInsertServerSyncLog.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mInsertServerSyncLog.LOG_ID = p_Log_ID;
				mInsertServerSyncLog.IS_SUCCESSFUL = true;
				Convert.ToInt16(mInsertServerSyncLog.IS_SUCCESSFUL);
				mInsertServerSyncLog.LOG_DATE = DateTime.Now;

				mInsertServerSyncLog.ExecuteQuery();
				return true;

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

		public DataTable SelectTransSyncLog(int p_Dist_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectTRANSSYNCLOG mSelectTransSyncLog = new uspSelectTRANSSYNCLOG();
				mSelectTransSyncLog.Connection = mConnection;
                mSelectTransSyncLog.DISTRIBUTOR_ID = p_Dist_Id;
				DataTable dt = mSelectTransSyncLog.ExecuteTable();
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

		public bool UpdateTransSyncLog(int p_DISTRIBUTOR_ID,int p_Trans_log_Id , int p_Log_Detail_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspUpdateTRANS_SYNC_LOG mUpdateTransSyncLog = new uspUpdateTRANS_SYNC_LOG();
				mUpdateTransSyncLog.Connection = mConnection;

				mUpdateTransSyncLog.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mUpdateTransSyncLog.TRANS_LOG_ID = p_Trans_log_Id;
				mUpdateTransSyncLog.LOG_DETAIL_ID = p_Log_Detail_Id;

				mUpdateTransSyncLog.ExecuteQuery();
				return true;

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

		public static long GetLastLogID(string p_DISTRIBUTOR_ID, string p_HTTPIP)
		{
			
			// requests server for last log id wrt to dist id
			
			HttpWebRequest    Req;     // The Request.
			HttpWebResponse   Resp;    // The response.
			Stream            Data;    // Response data stream.
			StreamReader      DatRead; // Obtains the data stream.
			String            Output;  // The response as a string.
			Int32             Posit1;  // Beginning position within the string.
			Int32             Posit2;  // End position within the string.

			// Create the initial request.

			
			string mReqString = "http://" + p_HTTPIP + "/IISHelp/SAMSServer/Extra/frmMaxLogID.aspx?distributorid=" + p_DISTRIBUTOR_ID;
			Req = (HttpWebRequest)WebRequest.Create(mReqString);

			try
			{
				// Get the response.
				Resp = (HttpWebResponse)Req.GetResponse();

				// Read the data from the response.
				Data = Resp.GetResponseStream();
				DatRead = new StreamReader(Data);

				// Get the data as a string.
				Output = DatRead.ReadToEnd();

				// Always close the data stream.
				DatRead.Close();
				
				string Row = Output.ToString();
				string delimStr ="\r";		//Delimiter is tilt
				char [] delimiter = delimStr.ToCharArray();
				string[] array= Row.Split(delimiter);

				if(!array[0].Equals(""))
				{
					return long.Parse(array[0]);
				}
				else
				{
					return -1;
				}
			}
			catch (WebException WE)
			{
				// Display an error message and exit.
				return -1;
			}
			/////////////////////////////////////
			
			
			
			
			
		}
		
		public static void SendLogFileId(string p_FileName, string p_HTTPIP)
		{
					
			HttpWebRequest    Req;     // The Request.
			HttpWebResponse   Resp;
			Stream            Data;    // Response data stream.
			StreamReader      DatRead; // Obtains the data stream.
			String            Output;  // The response as a string.
			Int32             Posit1;  // Beginning position within the string.
			Int32             Posit2;  // End position within the string.

			string fileName  = p_FileName.Substring(p_FileName.LastIndexOf(@"\") + 1);

			string mReqString = "http://" + p_HTTPIP + "/IISHelp/SAMSServer/Extra/frm_ReqToDel.aspx?FileName=" + fileName;
			Req = (HttpWebRequest)WebRequest.Create(mReqString);
			Resp = (HttpWebResponse)Req.GetResponse();

			try
			{
				// Get the response.
				Resp = (HttpWebResponse)Req.GetResponse();

				// Read the data from the response.
				Data = Resp.GetResponseStream();
				DatRead = new StreamReader(Data);

				// Get the data as a string.
				Output = DatRead.ReadToEnd();

				// Always close the data stream.
				DatRead.Close();
				
				string Row = Output.ToString();
				string delimStr ="\r";		//Delimiter is tilt
				char [] delimiter = delimStr.ToCharArray();
				string[] array= Row.Split(delimiter);

				//if(!array[0].Equals(""))
				//{
				//	return long.Parse(array[0]);
				//}
				//else
				//{
				//	return -1;
				//}
			}
			catch (WebException WE)
			{
				 
				// Display an error message and exit.
				//return -1;
			}
		}
		

		public static string Distributor_Activity(string p_DISTRIBUTOR_ID,string p_Activity_ID,string Dis_ActivityID, string p_HTTPIP)
		{
			
			// requests server for last log id wrt to dist id
			
			HttpWebRequest    Req;     // The Request.
			HttpWebResponse   Resp;    // The response.
			Stream            Data;    // Response data stream.
			StreamReader      DatRead; // Obtains the data stream.
			String            Output;  // The response as a string.
			Int32             Posit1;  // Beginning position within the string.
			Int32             Posit2;  // End position within the string.
			
			// Create the initial request.
			
			string mReqString = "http://" + p_HTTPIP + "/IISHelp/SAMSServer/extra/DistActivityLog.aspx?DistributorID="+ p_DISTRIBUTOR_ID + "&Activity=" + p_Activity_ID + "&Dis_ActivityID=" + Dis_ActivityID;
				
			Req = (HttpWebRequest)WebRequest.Create(mReqString);
			
			
			try
			{
				// Get the response.
				
				Resp = (HttpWebResponse)Req.GetResponse();

				// Read the data from the response.
				Data = Resp.GetResponseStream();
				DatRead = new StreamReader(Data);

				// Get the data as a string.
				Output = DatRead.ReadToEnd();

				// Always close the data stream.
				DatRead.Close();
				
				string Row = Output.ToString();
				if ((Row ==null) || (Row==""))
				{
					return "-2";	// it will cauz an exception n sync will be aborted.
				}
				string delimStr ="\r";		//Delimiter is tilt
				char [] delimiter = delimStr.ToCharArray();
				string[] array= Row.Split(delimiter);

				if (int.Parse (Dis_ActivityID)>=0)
				{
					if(!array[0].Equals(""))
					{
						int index=array [0].IndexOf ("Login ID");
						if (index >=0)
						{
							string id=array [0].Substring (0,index);
							return id.Trim ();
						}					
					}
					else
					{
						return "-1";
					}
				}
				else
				{
					return Dis_ActivityID;
				}
				return "-1";
			}
			catch (Exception ex)
			{
				ExceptionPublisher.PublishException(ex);	
				// Display an error message and exit.
				return "-2";	// recorded an error.
			}
			/////////////////////////////////////
		}
		
		#endregion
	}
}
