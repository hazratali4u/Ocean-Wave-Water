using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for AccountHeadController.
	/// </summary>
	public class AccountHeadController
	{
		#region Constructor
		public AccountHeadController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		
		#region Public Methods


		public DataTable SelectAccountHeadInfo(long p_Account_Head_Id,long p_Customer_Id,bool p_Is_Active,DateTime p_Time_Stamp,DateTime p_Lastupdate_Date,int p_Distributor_Id,int p_Account_Type_Id,decimal p_Balance,string p_Account_Name) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectACCOUNT_HEAD mAccountHead = new uspSelectACCOUNT_HEAD();
				mAccountHead.Connection = mConnection;
				
				mAccountHead.ACCOUNT_HEAD_ID=p_Account_Head_Id;
				mAccountHead.ACCOUNT_NAME=p_Account_Name;
				mAccountHead.ACCOUNT_TYPE_ID=p_Account_Type_Id;
				mAccountHead.BALANCE=p_Balance;
				mAccountHead.CUSTOMER_ID=p_Customer_Id;
				mAccountHead.DISTRIBUTOR_ID=p_Distributor_Id;
				mAccountHead.IS_ACTIVE = p_Is_Active;
				mAccountHead.TIME_STAMP = Constants.DateNullValue;
				mAccountHead.LASTUPDATE_DATE = Constants.DateNullValue;
				
				                
				DataTable dt = mAccountHead.ExecuteTable();
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


		


		public string InsertAccountHead(int p_Company_id,bool p_Is_Active,DateTime p_Time_Stamp,int p_Distributor_Id,int p_Account_Type_Id,long p_Account_Parent_id,string p_Account_Name,string p_Account_Code) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertACCOUNT_HEAD mAccountHead = new spInsertACCOUNT_HEAD();
				mAccountHead.Connection = mConnection;
                mAccountHead.COMPANY_ID = p_Company_id;
                mAccountHead.DISTRIBUTOR_ID = p_Distributor_Id;
                mAccountHead.ACCOUNT_TYPE_ID = p_Account_Type_Id;
                mAccountHead.ACCOUNT_PARENT_ID = p_Account_Parent_id;
                mAccountHead.ACCOUNT_NAME = p_Account_Name;
                mAccountHead.ACCOUNT_CODE = p_Account_Code; 
                mAccountHead.IS_ACTIVE = p_Is_Active;
				mAccountHead.TIME_STAMP = p_Time_Stamp;
				mAccountHead.ExecuteQuery();
				return mAccountHead.ACCOUNT_HEAD_ID.ToString();
				
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


		public string UpdateAccountHead(long p_Account_Head_Id,long p_Company_Id,bool p_Is_Active,DateTime p_Time_Stamp,int p_Distributor_Id,int p_Account_Type_Id,long p_Account_ParentId,string p_Account_Name,string p_Account_Code) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateACCOUNT_HEAD mAccountHead = new spUpdateACCOUNT_HEAD();
				mAccountHead.Connection = mConnection;
				mAccountHead.ACCOUNT_HEAD_ID=p_Account_Head_Id;
				mAccountHead.ACCOUNT_NAME=p_Account_Name;
                mAccountHead.ACCOUNT_CODE = p_Account_Code;  
				mAccountHead.ACCOUNT_TYPE_ID=p_Account_Type_Id;
				mAccountHead.DISTRIBUTOR_ID=p_Distributor_Id;
                mAccountHead.COMPANY_ID = p_Company_Id;
                mAccountHead.ACCOUNT_PARENT_ID = p_Account_ParentId;
                mAccountHead.IS_ACTIVE = p_Is_Active;
				mAccountHead.TIME_STAMP = p_Time_Stamp;
                mAccountHead.LASTUPDATE_DATE = p_Time_Stamp;
				mAccountHead.ExecuteQuery();
				return mAccountHead.ACCOUNT_HEAD_ID.ToString();
				
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
        
		public DataTable SelectAccountHead(int p_Account_Type_Id,long p_Account_ParentId) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectACCOUNT_HEAD mAccountHead = new spSelectACCOUNT_HEAD();
				mAccountHead.Connection = mConnection;
                mAccountHead.DISTRIBUTOR_ID = Constants.IntNullValue;  
				mAccountHead.ACCOUNT_HEAD_ID=Constants.LongNullValue;
                mAccountHead.ACCOUNT_PARENT_ID = p_Account_ParentId;
                mAccountHead.COMPANY_ID = Constants.LongNullValue;   
                mAccountHead.ACCOUNT_TYPE_ID=p_Account_Type_Id;
				mAccountHead.IS_ACTIVE = true;
				mAccountHead.TIME_STAMP = Constants.DateNullValue;
				mAccountHead.LASTUPDATE_DATE = Constants.DateNullValue;
				           
				DataTable dt = mAccountHead.ExecuteTable();
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
        public DataTable SelectClaimHead(int p_Account_Type_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                GetClaimHead mAccountHead = new GetClaimHead();
                mAccountHead.Connection = mConnection;
                mAccountHead.SUB_TYPE_ID = p_Account_Type_Id;

                DataTable dt = mAccountHead.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        public DataTable SelectAccountHead(int p_CompnayId,int p_Account_Head,int p_Account_Type_Id,int p_Account_ParentId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectAccountHead mAccountHead = new UspSelectAccountHead();
                mAccountHead.Connection = mConnection;
                mAccountHead.COMPANY_ID = p_CompnayId;
                mAccountHead.ACCOUNT_TYPE_ID = p_Account_Type_Id;
                mAccountHead.ACCOUNT_PARENT_ID = p_Account_ParentId;
                mAccountHead.ACCOUNT_HEAD_ID = p_Account_Head;  
                DataTable dt = mAccountHead.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        #endregion

	}
}
