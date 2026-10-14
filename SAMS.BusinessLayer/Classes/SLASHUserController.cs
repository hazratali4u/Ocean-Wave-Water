using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;


namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// SLASHUserController
	/// <author></author>
	/// <date>27-07-2007</date>
	/// </summary>
	public class SAMSUserController
	{
		
		#region Constructors
        public SAMSUserController()
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
		
		public string InsertSlashUser(int User_Id,int p_CompanyId,int p_DistributorId,string p_LoginId , string p_Password, int p_RoleId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertSAMS_USER mSlashUser = new spInsertSAMS_USER();
				mSlashUser.Connection = mConnection;
                mSlashUser.USER_ID = User_Id;  
				mSlashUser.DISTRIBUTOR_ID = p_DistributorId;
                mSlashUser.COMPANY_ID = p_CompanyId;  
				mSlashUser.LOGIN_ID = p_LoginId;
				mSlashUser.PASSWORD = p_Password;
                mSlashUser.ROLE_ID = p_RoleId;
				mSlashUser.LASTUPDATE_DATE =  System.DateTime.Today;
                mSlashUser.ExecuteQuery();
				return mSlashUser.USER_ID.ToString ();
				
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


		public string UpdateSlashUser(int p_UserId,int p_CompanyId,string p_LoginId , string p_Password, int p_RoleId, bool p_IsActive, int p_DistributorID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spUpdateSAMS_USER mSlashUser = new spUpdateSAMS_USER();
				mSlashUser.Connection = mConnection;
				
                mSlashUser.USER_ID = p_UserId;  
                mSlashUser.DISTRIBUTOR_ID = p_DistributorID;
                mSlashUser.COMPANY_ID = p_CompanyId;
                mSlashUser.LOGIN_ID = p_LoginId;
				mSlashUser.PASSWORD = p_Password;
				mSlashUser.ROLE_ID = p_RoleId;
				mSlashUser.IS_ACTIVE = p_IsActive;
                mSlashUser.LASTUPDATE_DATE =  System.DateTime.Today;
                mSlashUser.ExecuteQuery();
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
     
          		 
	    public DataTable SelectSlashUser(string p_LoginId , string p_Password)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                spSelectSAMS_USER mSlashUser = new spSelectSAMS_USER();
				mSlashUser .Connection = mConnection;
                mSlashUser.LOGIN_ID = p_LoginId;
                mSlashUser.PASSWORD = p_Password;
                mSlashUser.IS_ACTIVE = true;  
				
				DataTable dt = mSlashUser.ExecuteTable();
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
        public DataTable SelectSlashUser(int p_User_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSAMS_USER mSlashUser = new spSelectSAMS_USER();
                mSlashUser.Connection = mConnection;
                mSlashUser.USER_ID = p_User_ID;
                mSlashUser.IS_ACTIVE = true;

                DataTable dt = mSlashUser.ExecuteTable();
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

        public DataTable SelectSlashUser2(int p_User_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelect_USER2 mSlashUser = new spSelect_USER2();
                mSlashUser.Connection = mConnection;
                mSlashUser.USER_ID = p_User_ID;
                mSlashUser.IS_ACTIVE = true;

                DataTable dt = mSlashUser.ExecuteTable();
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

        //For selection of user assign brand

        public DataTable SelectUserPrincipal(int p_User_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelect_USERPrincipal mSlashUser = new spSelect_USERPrincipal();
                mSlashUser.Connection = mConnection;
                mSlashUser.USER_ID = p_User_ID;
                //mSlashUser.IS_ACTIVE = true;

                DataTable dt = mSlashUser.ExecuteTable();
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
        public DataTable SelectUserAssignment(int UserId, int DistributorTypeid, int TypeiD, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectUnAssignDistributor mUserAssing = new UspSelectUnAssignDistributor();
                mUserAssing.Connection = mConnection;
                mUserAssing.USER_ID = UserId;
                mUserAssing.DISTRIBUTOR_TYPE = DistributorTypeid;
                mUserAssing.TYPE_ID = TypeiD;
                mUserAssing.COMPANY_ID = Companyid;   
                DataTable dt = mUserAssing.ExecuteTable();
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

        public bool InsertUserAssignment(int UserId, int DistributorTypeid, int DistributorId, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertDISTRIBUTOR_ASSIGNMENT mUserAssing = new spInsertDISTRIBUTOR_ASSIGNMENT();
                mUserAssing.Connection = mConnection;
                mUserAssing.USER_ID = UserId;
                mUserAssing.DISTRIBUTOR_TYPE = DistributorTypeid;
                mUserAssing.DISTRIBUTOR_ID = DistributorId;
                mUserAssing.COMPANY_ID = Companyid;   
                bool dt = mUserAssing.ExecuteQuery(); 
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        public bool DeleteUserAssignment(int UserId, int DistributorTypeid, int DistributorId, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spDeleteDISTRIBUTOR_ASSIGNMENT mUserAssing = new spDeleteDISTRIBUTOR_ASSIGNMENT();
                mUserAssing.Connection = mConnection;
                mUserAssing.USER_ID = UserId;
                mUserAssing.DISTRIBUTOR_TYPE = DistributorTypeid;
                mUserAssing.DISTRIBUTOR_ID = DistributorId;
                mUserAssing.COMPANY_ID = Companyid;   
                bool dt = mUserAssing.ExecuteQuery();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        public DataTable SelectMaxDayClose(int UserId,int Distributor_id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectMaxDayClose mMaxClose = new uspSelectMaxDayClose();
                mMaxClose.Connection = mConnection;
                mMaxClose.USER_ID  = UserId;
                mMaxClose.DISTRIBUTOR_ID = Distributor_id; 
                DataTable mLastClose = mMaxClose.ExecuteTable(); 
                return mLastClose;
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

        public bool UspDayClose(DateTime p_DayClose, int Distributor_id,int UserId)
        {
            IDbConnection mConnection = null;
             IDbTransaction mTransaction = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                UspDayClosing mMaxClose = new UspDayClosing();
                mMaxClose.Connection = mConnection;
                mMaxClose.Transaction = mTransaction; 
                mMaxClose.DAYCLOSE = p_DayClose;
                mMaxClose.DISTRIBUTOR_ID = Distributor_id;
                mMaxClose.USER_ID = UserId; 
                bool mLastClose = mMaxClose.ExecuteQuery();
                if (mLastClose == true)
                {
                    mTransaction.Commit();
                }
                else
                {
                    mTransaction.Rollback();
                }
                return mLastClose;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
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
