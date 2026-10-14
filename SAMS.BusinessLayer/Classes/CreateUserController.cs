using System;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;
using System.Data;

namespace SAMS.BusinessLayer.Classes
{
    public class CreateUserController
    {
        public bool Distributor_User(int p_DISTRIBUTOR_ID,string p_NICK_NAME, string p_USER_NAME, string p_PHONE, string p_FAX, string p_MOBILE, string p_EMAIL, string p_ADDRESS1, string p_ADDRESS2, string p_LOGIN_ID, string p_PASSWORD, int p_DESIGNATION_ID, bool p_IsActive, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, int p_ROLE_ID, int p_UserType_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertDISTRIBUTOR_USER ObjInsert = new spInsertDISTRIBUTOR_USER();
                ObjInsert.Connection = mConnection;
                ObjInsert.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                ObjInsert.USER_NAME = p_USER_NAME;
                ObjInsert.PHONE = p_PHONE;
                ObjInsert.USER_TYPE_ID = p_UserType_ID;
                ObjInsert.EMAIL = p_EMAIL;  
                //ObjInsert.DATE_JOIN =   
                ObjInsert.ADDRESS1 = p_ADDRESS1;
                ObjInsert.ADDRESS2 = p_ADDRESS2;
                ObjInsert.LOGIN_ID = p_LOGIN_ID;
                ObjInsert.PASSWORD = p_PASSWORD;
                ObjInsert.TIME_STAMP = p_TIME_STAMP;
                ObjInsert.LASTUPDATE_DATE = p_LASTUPDATE_DATE;
                ObjInsert.ROLE_ID = p_ROLE_ID;
                bool Bvalue = ObjInsert.ExecuteQuery();
                return Bvalue;
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
        //public DataTable SelectModule(int p_DESIGNATION_ID,string p_DESCRIPTION, DateTime p_LASTUPDATE, bool p_IS_ACTIVE)
        //{
        //    IDbConnection mConnection = null;
        //    try
        //    {
        //        mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);

        //        //mConnection = ProviderFactory.GetConnection("Data Source=./SQLEXPRESS;Integrated Security=True;Connect Timeout=30;User Instance=True", EnumProviders.SQLClient);

        //        mConnection.Open();
        //        spSelectDESIGNATION ObjSelect = new spSelectDESIGNATION();
        //        //spSelectMODULE ObjSelect = new spSelectMODULE();
        //        ObjSelect.Connection = mConnection;
        //        ObjSelect.DESIGNATION_ID =p_DESIGNATION_ID ;
        //        ObjSelect.DESCRIPTION = p_DESCRIPTION;
        //        ObjSelect.LASTUPDATE = p_LASTUPDATE;
        //        ObjSelect.IS_ACTIVE = p_IS_ACTIVE;
        //        DataTable dt = ObjSelect.ExecuteTable();
        //        return dt;

        //    }
        //    catch (Exception exp)
        //    {
        //        ExceptionPublisher.PublishException(exp);
        //        return null;

        //    }
        //    finally
        //    {
        //        if (mConnection != null && mConnection.State == ConnectionState.Open)
        //        {
        //            mConnection.Close();
        //        }
        //    }
        //}
        public bool UpdateDistributor_User(int p_USER_ID, int p_DISTRIBUTOR_ID, string p_NICK_NAME, string p_USER_NAME, string p_PHONE, string p_FAX, string p_MOBILE, string p_EMAIL, string p_ADDRESS1, string p_ADDRESS2, string p_LOGIN_ID, string p_PASSWORD, int p_DESIGNATION_ID, bool p_IS_ACTIVE, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, int p_ROLE_ID, int p_USERTYPE_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateDISTRIBUTOR_USER ObjUpdate = new spUpdateDISTRIBUTOR_USER();

                ObjUpdate.Connection = mConnection;
                ObjUpdate.USER_ID = p_USER_ID;
                ObjUpdate.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                //ObjUpdate.NICK_NAME = p_NICK_NAME;
                ObjUpdate.USER_NAME = p_USER_NAME;
                ObjUpdate.PHONE = p_PHONE;
                //ObjUpdate.FAX = p_FAX;
                ObjUpdate.MOBILE = p_MOBILE;
                ObjUpdate.ADDRESS1 = p_ADDRESS1;
                ObjUpdate.ADDRESS2 = p_ADDRESS2;
                //ObjUpdate.LOGIN_ID = p_LOGIN_ID;
                //ObjUpdate.PASSWORD = p_PASSWORD;
              //  ObjUpdate.DESIGNATION_ID = p_DESIGNATION_ID;
                ObjUpdate.IS_ACTIVE = p_IS_ACTIVE;
                ObjUpdate.TIME_STAMP = p_TIME_STAMP;
                ObjUpdate.LASTUPDATE_DATE = p_LASTUPDATE_DATE;
              //  ObjUpdate.USERTYPE_ID = p_USERTYPE_ID;
                bool Bvalue = ObjUpdate.ExecuteQuery();
                return Bvalue;
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
        public DataTable SelectDistributor_User_Login(int p_USER_ID, int p_DISTRIBUTOR_ID, string p_NICK_NAME, string p_USER_NAME, string p_PHONE, string p_FAX, string p_MOBILE, string p_EMAIL, string p_ADDRESS1, string p_ADDRESS2, string p_LOGIN_ID, string p_PASSWORD, int p_DESIGNATION_ID, bool p_IsActive, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, int p_ROLE_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectDISTRIBUTOR_USER ObjSelect = new spSelectDISTRIBUTOR_USER();
                ObjSelect.Connection = mConnection;
                ObjSelect.USER_ID = p_USER_ID;
                ObjSelect.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                ObjSelect.USER_NAME = p_USER_NAME;
                ObjSelect.PHONE = p_PHONE;
                ObjSelect.MOBILE = p_MOBILE;
                ObjSelect.EMAIL = p_EMAIL;
                ObjSelect.ADDRESS1 = p_ADDRESS1;
                ObjSelect.ADDRESS2 = p_ADDRESS2;
                ObjSelect.LOGIN_ID = p_LOGIN_ID;
                ObjSelect.PASSWORD = p_PASSWORD;
                ObjSelect.IS_ACTIVE = p_IsActive;
                ObjSelect.TIME_STAMP = p_TIME_STAMP;
                ObjSelect.LASTUPDATE_DATE = p_LASTUPDATE_DATE;
                ObjSelect.ROLE_ID = p_ROLE_ID;
                DataTable dt = ObjSelect.ExecuteTable();
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
        public bool ChangePassword(int p_USER_ID,string p_PASSWORD , bool p_IS_ACTIVE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspChangePassword ObjUpdate = new UspChangePassword(); 

                ObjUpdate.Connection = mConnection;
                ObjUpdate.USER_ID = p_USER_ID;
                ObjUpdate.PASSWORD = p_PASSWORD;
                ObjUpdate.IS_ACTIVE = p_IS_ACTIVE;

                bool Bvalue = ObjUpdate.ExecuteQuery();
                return Bvalue;
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
    }
}
