using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for DistributorUserController.
	/// </summary>
	public class DistributorUserController
	{
		public DistributorUserController()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public string InsertDistributor_User(string p_NIC, bool p_Is_Active, DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_User_Type_Id,int p_Distributor_Id,
            int p_Role_Id, string p_Email_Address, string p_Address1, string p_Address2, string p_Login_Id, string p_Password,string p_Mobile, string p_User_Code, string p_User_Name, string p_Phone)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertDISTRIBUTOR_USER mDistributorUser = new spInsertDISTRIBUTOR_USER();
                mDistributorUser.Connection = mConnection;
                mDistributorUser.USER_CODE = p_User_Code;
                mDistributorUser.USER_NAME = p_User_Name;
                mDistributorUser.NIC_NO = p_NIC;
                mDistributorUser.ADDRESS1 = p_Address1;
                mDistributorUser.ADDRESS2 = p_Address2;
                mDistributorUser.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistributorUser.EMAIL = p_Email_Address;
                mDistributorUser.LASTUPDATE_DATE = p_Lastupdate_Date;
                mDistributorUser.LOGIN_ID = p_Login_Id;
                mDistributorUser.MOBILE = p_Mobile;
                mDistributorUser.PASSWORD = p_Password;
                mDistributorUser.PHONE = p_Phone;
                mDistributorUser.ROLE_ID = p_Role_Id;
                mDistributorUser.TIME_STAMP = p_Time_Stamp;
                mDistributorUser.USER_CODE = p_User_Code;
                mDistributorUser.USER_NAME = p_User_Name;
                mDistributorUser.USER_TYPE_ID = p_User_Type_Id;
                mDistributorUser.IS_ACTIVE = p_Is_Active;
                mDistributorUser.ExecuteQuery();

                return mDistributorUser.USER_ID.ToString();

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

		public DataTable SelectDistributorUser(int p_Type, int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDISTRIBUTOR_USERInfo mDistUser = new uspSelectDISTRIBUTOR_USERInfo();
				mDistUser.Connection = mConnection;

				mDistUser.TYPE = p_Type;
				mDistUser.DISTRIBUTOR_ID = p_Distributor_Id;					
				
				DataTable dt = mDistUser.ExecuteTable();
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

		public DataTable SelectDistributorSalesForce(int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDISTRIBUTORSalesForce mDistUser = new uspSelectDISTRIBUTORSalesForce();
				mDistUser.Connection = mConnection;

				mDistUser.DISTRIBUTOR_ID = p_Distributor_Id;					
				
				DataTable dt = mDistUser.ExecuteTable();
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

	}
}
