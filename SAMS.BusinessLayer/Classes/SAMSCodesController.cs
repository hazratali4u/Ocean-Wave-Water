using System;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;
using System.Data;

namespace SAMS.BusinessLayer.Classes
{
   public  class SAMSCodesController
    {
       #region Constructors
       public SAMSCodesController()
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
        //public string InsertSAMSCodes(string p_SAMSCode, int p_Parent_Ref_ID, string p_SAMSDesc, int p_Status, bool p_IsActive)
        //{
        //    IDbConnection mConnection = null;
        //    try
        //    {
        //        mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
        //        mConnection.Open();
        //        spInsertSAMS_CODES mSAMSCodes = new spInsertSAMS_CODES();
        //        mSAMSCodes.Connection = mConnection;
        //        mSAMSCodes.PARENT_REF_ID = p_Parent_Ref_ID;
        //        mSAMSCodes.SAMS_CODE = p_SAMSCode;
        //        mSAMSCodes.SAMS_DESC = p_SAMSDesc;
        //        mSAMSCodes.TIME_STAMP = DateTime.Now;
        //        mSAMSCodes.STATUS = p_Status;
        //        mSAMSCodes.IS_ACTIVE = p_IsActive;
        //        mSAMSCodes.ExecuteQuery();
        //        return "Record Inserted";
				
        //    }			
        //    catch(Exception exp)
        //    {
        //        ExceptionPublisher.PublishException(exp);				
        //        return exp.Message;
        //    }
        //    finally
        //    {
        //        if(mConnection != null && mConnection.State == ConnectionState.Open)
        //        {
        //            mConnection.Close();
        //        }
        //    }
        //}

        //public string UpdateSAMSCodes(int p_RefID, string p_SAMSCode, int p_Parent_Ref_ID, string p_SAMSDesc, int p_Status, bool p_IsActive, DateTime p_Time_Stamp)
        //{
        //    IDbConnection mConnection = null;
        //    try
        //    {
        //        mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
        //        mConnection.Open();
        //        spUpdateSAMS_CODES mSAMSCodes = new spUpdateSAMS_CODES();
        //        mSAMSCodes.Connection = mConnection;
        //        mSAMSCodes.REF_ID = p_RefID;
        //        mSAMSCodes.PARENT_REF_ID = p_Parent_Ref_ID;
        //        mSAMSCodes.SAMS_CODE = p_SAMSCode;
        //        mSAMSCodes.SAMS_DESC = p_SAMSDesc;
        //        mSAMSCodes.TIME_STAMP = p_Time_Stamp;
        //        mSAMSCodes.STATUS = p_Status;
        //        mSAMSCodes.IS_ACTIVE = p_IsActive;

        //        mSAMSCodes.ExecuteQuery();
				
        //        return "Record Updated";
        //    }
        //    catch(Exception exp)
        //    {
        //        ExceptionPublisher.PublishException(exp);				
        //        return exp.Message;
        //    }
        //    finally
        //    {
        //        if(mConnection != null && mConnection.State == ConnectionState.Open)
        //        {
        //            mConnection.Close();
        //        }
        //    }
        //}

        //public string DeleteSAMSCodes(long p_RefID)
        //{
        //    try
        //    {
				
        //        return "";
        //    }
        //    catch(Exception exp)
        //    {
        //        ExceptionPublisher.PublishException(exp);				
        //        return exp.Message;
        //    }
        //    finally
        //    {
        //    }
        //}

        //public DataTable SelectSAMSCodes(int p_RefID, string p_SAMSCode, int p_Parent_Ref_ID, string p_SAMSDesc, int p_Status, bool p_IsActive)
        //{
        //    IDbConnection mConnection = null;
        //    try
        //    {
        //        mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
        //        mConnection.Open();
        //        spSelectSAMS_CODES mSAMSCodes = new spSelectSAMS_CODES();
        //        mSAMSCodes.Connection = mConnection;
				
        //        mSAMSCodes.PARENT_REF_ID = p_Parent_Ref_ID;
        //        mSAMSCodes.SAMS_CODE = p_SAMSCode;
        //        mSAMSCodes.SAMS_DESC = p_SAMSDesc;
        //        mSAMSCodes.TIME_STAMP = Constants.DateNullValue;
        //        mSAMSCodes.STATUS = p_Status;
        //        mSAMSCodes.REF_ID = p_RefID;
        //        mSAMSCodes.IS_ACTIVE = p_IsActive;
        //        DataTable dt = mSAMSCodes.ExecuteTable();
        //        return dt;
				
        //    }
        //    catch(Exception exp)
        //    {
        //        ExceptionPublisher.PublishException(exp);				
        //        return null;
        //    }
        //    finally
        //    {
        //        if(mConnection != null && mConnection.State == ConnectionState.Open)
        //        {
        //            mConnection.Close();
        //        }
        //    }

			
        //}

        //public DataTable SelectDTSAMSCodes(int p_RefID, string p_SAMSCode, int p_Parent_Ref_ID, string p_SAMSDesc, int p_Status, bool p_IsActive)
        //{
        //    IDbConnection mConnection = null;
        //    try
        //    {
        //        mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
        //        mConnection.Open();
        //        spSelectSAMS_CODES mSAMSCodes = new spSelectSAMS_CODES();
        //        mSAMSCodes.Connection = mConnection;
				
        //        mSAMSCodes.PARENT_REF_ID = p_Parent_Ref_ID;
        //        mSAMSCodes.SAMS_CODE = p_SAMSCode;
        //        mSAMSCodes.SAMS_DESC = p_SAMSDesc;
        //        mSAMSCodes.TIME_STAMP = Constants.DateNullValue;
        //        mSAMSCodes.STATUS = p_Status;
        //        mSAMSCodes.REF_ID = p_RefID;
        //        mSAMSCodes.IS_ACTIVE = p_IsActive;
        //        DataTable dt = mSAMSCodes.ExecuteTable();
        //        return dt;
				
        //    }
        //    catch(Exception exp)
        //    {
        //        ExceptionPublisher.PublishException(exp);				
        //        return null;
        //    }
        //    finally
        //    {
        //        if(mConnection != null && mConnection.State == ConnectionState.Open)
        //        {
        //            mConnection.Close();
        //        }
        //    }

			
        //}

        //public int GetRef_ID(string p_SAMSCode, int p_Parent_Ref_ID)
        //{
        //    DataTable dt=this.SelectSAMSCodes(Constants.IntNullValue,p_SAMSCode,p_Parent_Ref_ID,null,Constants.IntNullValue,true);
        //    if(dt.Rows.Count>0)
        //        return int.Parse(dt.Rows[0]["REF_ID"].ToString());
        //    return 0;
        //}

        //public string GetSAMS_DESC(int Ref_ID, int p_Parent_Ref_ID)
        //{
        //    DataTable dt=this.SelectSAMSCodes(Ref_ID,null,p_Parent_Ref_ID,null,Constants.IntNullValue,true);
        //    if(dt.Rows.Count>0)
        //        return (dt.Rows[0]["SAMS_DESC"].ToString());
        //    return null;
        //}
		#endregion
    }
}
