using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for DBBackupController.
	/// </summary>
	public class DBBackupController
	{
		#region Constructor
		public DBBackupController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		
		#region Public Methods


		public DataTable SelectDBBackup(int p_DBBackup_Id, string p_DBBackupFileName, DateTime p_ClosingDate, bool p_IsDeleted) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDB_BACKUP mDBBackup = new spSelectDB_BACKUP();
				mDBBackup.Connection = mConnection;							

				mDBBackup.DB_BACKUP_ID=p_DBBackup_Id;
				mDBBackup.BACKUP_FILENAME =p_DBBackupFileName;
				mDBBackup.CLOSING_DATE = p_ClosingDate;
				mDBBackup.IS_DELETED = p_IsDeleted;
				mDBBackup.IS_ACTIVE = true;
				mDBBackup.TIME_STAMP = Constants.DateNullValue;
				mDBBackup.USER_ID = Constants.IntNullValue;
				mDBBackup.LASTUPDATE_DATE = Constants.DateNullValue;
							                
				DataTable dt = mDBBackup.ExecuteTable();
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

	
		public string InsertDBBackup(string p_DBBackupFileName, DateTime p_ClosingDate) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDB_BACKUP mDBBackup = new spInsertDB_BACKUP();
				mDBBackup.Connection = mConnection;
				
				mDBBackup.BACKUP_FILENAME =p_DBBackupFileName;
				mDBBackup.CLOSING_DATE = p_ClosingDate;
				mDBBackup.IS_DELETED = false;
				mDBBackup.IS_ACTIVE = true;
				mDBBackup.TIME_STAMP = DateTime.Now;
				mDBBackup.USER_ID = Configuration.UserID;
				mDBBackup.LASTUPDATE_DATE = Constants.DateNullValue;		
								                
				mDBBackup.ExecuteQuery();
				return mDBBackup.DB_BACKUP_ID.ToString();
				
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


		public string UpdateDBBackup(int p_DBBackup_Id, string p_DBBackupFileName, DateTime p_ClosingDate, bool p_IsDeleted) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateDB_BACKUP mDBBackup = new spUpdateDB_BACKUP();
				mDBBackup.Connection = mConnection;
				
				mDBBackup.DB_BACKUP_ID = p_DBBackup_Id;
				mDBBackup.BACKUP_FILENAME =p_DBBackupFileName;
				mDBBackup.CLOSING_DATE = p_ClosingDate;
				mDBBackup.IS_DELETED = p_IsDeleted;
				mDBBackup.IS_ACTIVE = true;
				mDBBackup.TIME_STAMP = Constants.DateNullValue;
				mDBBackup.USER_ID = Configuration.UserID;
				mDBBackup.LASTUPDATE_DATE = DateTime.Now;		
										                
				mDBBackup.ExecuteQuery();				
				return mDBBackup.DB_BACKUP_ID.ToString();
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

		public bool DeleteDBBackup(int p_DBBackup_Id, bool IsDeleteRecord) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				if(IsDeleteRecord)
				{
					spDeleteDB_BACKUP mDBBackup = new spDeleteDB_BACKUP();
					mDBBackup.Connection = mConnection;
				
					mDBBackup.DB_BACKUP_ID = p_DBBackup_Id;								                
					mDBBackup.ExecuteQuery();
				}
				else
				{
					spUpdateDB_BACKUP mDBBackup = new spUpdateDB_BACKUP();
					mDBBackup.Connection = mConnection;
				
					mDBBackup.DB_BACKUP_ID = p_DBBackup_Id;
					mDBBackup.BACKUP_FILENAME =null;
					mDBBackup.CLOSING_DATE = Constants.DateNullValue;
					mDBBackup.IS_DELETED = true;
					mDBBackup.IS_ACTIVE = true;
					mDBBackup.TIME_STAMP = Constants.DateNullValue;
					mDBBackup.USER_ID = Configuration.UserID;
					mDBBackup.LASTUPDATE_DATE = DateTime.Now;
										                
					mDBBackup.ExecuteQuery();
				}
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



		#endregion

	}
}
