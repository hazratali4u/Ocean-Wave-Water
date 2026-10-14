using System;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;
using System.Data;

namespace SAMS.BusinessLayer.Classes
{
    public  class CreateLoginIDController
    {
        public bool InsertLoginID( string p_LOGIN_ID ,string p_PASSWORD ,int p_ROLE_ID ,bool p_IS_ACTIVE ,int p_USER_ID )
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertCREATE_LOGIN ObjInsert = new spInsertCREATE_LOGIN();

                ObjInsert.Connection = mConnection;
                ObjInsert.LOGIN_ID = p_LOGIN_ID;
                ObjInsert.PASSWORD = p_PASSWORD;
                ObjInsert.ROLE_ID = p_ROLE_ID;
                ObjInsert.IS_ACTIVE = p_IS_ACTIVE;
                ObjInsert.USER_ID = p_USER_ID;
              
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
        public bool UpdateLoginID(int p_CREATE_LOGIN_ID, string p_LOGIN_ID, string p_PASSWORD, int p_ROLE_ID, bool p_IS_ACTIVE, int p_USER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateCREATE_LOGIN ObjUpdate = new spUpdateCREATE_LOGIN();
                
                ObjUpdate.Connection = mConnection;
                ObjUpdate.CREATE_LOGIN_ID = p_CREATE_LOGIN_ID;
                ObjUpdate.LOGIN_ID = p_LOGIN_ID;
                ObjUpdate.PASSWORD = p_PASSWORD;
                ObjUpdate.ROLE_ID = p_ROLE_ID;
                ObjUpdate.IS_ACTIVE = p_IS_ACTIVE;
                ObjUpdate.USER_ID = p_USER_ID;

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

        public DataTable GetUser(int p_USER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspGetUserName ObjSelect = new UspGetUserName();
                ObjSelect.Connection = mConnection;
                ObjSelect.USER_ID = p_USER_ID;
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

        public DataTable GetLogin_DIstributorID(int p_USER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectLogin_DistributorID ObjSelect = new spSelectLogin_DistributorID();
                ObjSelect.Connection = mConnection;
                ObjSelect.USER_ID = p_USER_ID;
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
    }
}
