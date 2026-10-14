using System;
using System.Data;

using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;


namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// SLASHCodesController
	/// <author>Rizwan Ansari</author>
	/// <date>19-06-2007</date>
	/// </summary>
	public class SLASHCodesController
	{	
		#region Constructors
		public SLASHCodesController()
		{
			//
			// TODO: Add constructor logic here
			//
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
		public string InsertSlashCodes(string p_SlashCode, int p_Parent_Ref_ID, string p_SlashDesc, int p_Status, bool p_IsActive)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
				spInsertSLASH_CODES mSlashCodes = new spInsertSLASH_CODES();
				mSlashCodes.Connection = mConnection;
				mSlashCodes.PARENT_REF_ID = p_Parent_Ref_ID;
				mSlashCodes.SLASH_CODE = p_SlashCode;
				mSlashCodes.SLASH_DESC = p_SlashDesc;
				mSlashCodes.TIME_STAMP = DateTime.Now;
				mSlashCodes.STATUS = p_Status;
				mSlashCodes.IS_ACTIVE = p_IsActive;
				mSlashCodes.ExecuteQuery();
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

		public string UpdateSlashCodes(int p_RefID, string p_SlashCode, int p_Parent_Ref_ID, string p_SlashDesc, int p_Status, bool p_IsActive, DateTime p_Time_Stamp)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateSLASH_CODES mSlashCodes = new spUpdateSLASH_CODES();
				mSlashCodes.Connection = mConnection;
				mSlashCodes.REF_ID = p_RefID;
				mSlashCodes.PARENT_REF_ID = p_Parent_Ref_ID;
				mSlashCodes.SLASH_CODE = p_SlashCode;
				mSlashCodes.SLASH_DESC = p_SlashDesc;
				mSlashCodes.TIME_STAMP = p_Time_Stamp;
				mSlashCodes.STATUS = p_Status;
				mSlashCodes.IS_ACTIVE = p_IsActive;

				mSlashCodes.ExecuteQuery();
				
				return "Record Updated";
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

		public string DeleteSlashCodes(long p_RefID)
		{
			try
			{
				
				return "";
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

		public DataTable SelectSlashCodes(int p_RefID, string p_SlashCode, int p_Parent_Ref_ID, string p_SlashDesc, int p_Status, bool p_IsActive)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSLASH_CODES mSlashCodes = new spSelectSLASH_CODES();
				mSlashCodes.Connection = mConnection;
				mSlashCodes.PARENT_REF_ID = p_Parent_Ref_ID;
				mSlashCodes.SLASH_CODE = p_SlashCode;
				mSlashCodes.SLASH_DESC = p_SlashDesc;
				mSlashCodes.TIME_STAMP = Constants.DateNullValue;
				mSlashCodes.STATUS = p_Status;
				mSlashCodes.REF_ID = p_RefID;
				mSlashCodes.IS_ACTIVE = p_IsActive;
				DataTable dt = mSlashCodes.ExecuteTable();
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

		public DataTable SelectDTSlashCodes(int p_RefID, string p_SlashCode, int p_Parent_Ref_ID, string p_SlashDesc, int p_Status, bool p_IsActive)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSLASH_CODES mSlashCodes = new spSelectSLASH_CODES();
				mSlashCodes.Connection = mConnection;
				
				mSlashCodes.PARENT_REF_ID = p_Parent_Ref_ID;
				mSlashCodes.SLASH_CODE = p_SlashCode;
				mSlashCodes.SLASH_DESC = p_SlashDesc;
				mSlashCodes.TIME_STAMP = Constants.DateNullValue;
				mSlashCodes.STATUS = p_Status;
				mSlashCodes.REF_ID = p_RefID;
				mSlashCodes.IS_ACTIVE = p_IsActive;
				DataTable dt = mSlashCodes.ExecuteTable();
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

		public int GetRef_ID(string p_SlashCode, int p_Parent_Ref_ID)
		{
			DataTable dt=this.SelectSlashCodes(Constants.IntNullValue,p_SlashCode,p_Parent_Ref_ID,null,Constants.IntNullValue,true);
			if(dt.Rows.Count>0)
				return int.Parse(dt.Rows[0]["REF_ID"].ToString());
			return 0;
		}

		public string GetSLASH_DESC(int Ref_ID, int p_Parent_Ref_ID)
		{
			DataTable dt=this.SelectSlashCodes(Ref_ID,null,p_Parent_Ref_ID,null,Constants.IntNullValue,true);
			if(dt.Rows.Count>0)
				return (dt.Rows[0]["SLASH_DESC"].ToString());
			return null;
		}
		#endregion
	}
}
