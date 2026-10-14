using System;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;
using System.Data;

namespace SAMS.BusinessLayer.Classes
{
    public class CreateCustomerController
    {
        public bool InsertCustomer(string p_CUSTOMER_NAME, string p_CUSTOMER_SHORTNAME, string p_CONTACT_PERSON, string p_PHONE_NO, string p_MOBILE_NO, string p_EMAIL, int p_LOCATION_ID, string p_GST_NO, string p_ADDRESS, string p_MARKET, string p_ROUTE, string p_HOME_TOWN, int p_BUSSINESS_TYPE_ID, int p_CUSTOMER_TYPE_ID, int p_CHANNEL_TYPE_ID, int p_VOLUME_CLASS_ID, DateTime p_TIMESTAMP)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertCREATE_CUSTOMER ObjInsert = new spInsertCREATE_CUSTOMER();

                ObjInsert.Connection = mConnection;
                ObjInsert.CUSTOMER_NAME = p_CUSTOMER_NAME;
                ObjInsert.CUSTOMER_SHORTNAME = p_CUSTOMER_SHORTNAME;
                ObjInsert.CONTACT_PERSON = p_CONTACT_PERSON;
                ObjInsert.PHONE_NO = p_PHONE_NO;
                ObjInsert.MOBILE_NO = p_MOBILE_NO;
                ObjInsert.EMAIL = p_EMAIL;
                ObjInsert.LOCATION_ID = p_LOCATION_ID;
                ObjInsert.GST_NO = p_GST_NO;
                ObjInsert.ADDRESS = p_ADDRESS;
                ObjInsert.MARKET = p_MARKET;
                ObjInsert.ROUTE = p_ROUTE;
                ObjInsert.HOME_TOWN = p_HOME_TOWN;
                ObjInsert.BUSSINESS_TYPE_ID = p_BUSSINESS_TYPE_ID;
                ObjInsert.CUSTOMER_TYPE_ID = p_CUSTOMER_TYPE_ID;
                ObjInsert.CHANNEL_TYPE_ID = p_CHANNEL_TYPE_ID;
                ObjInsert.VOLUME_CLASS_ID = p_VOLUME_CLASS_ID;
                ObjInsert.TIMESTAMP = p_TIMESTAMP;

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
        public DataTable SelectCustomer(int p_CUSTOMER_ID,string p_CUSTOMER_NAME, string p_CUSTOMER_SHORTNAME, string p_CONTACT_PERSON, string p_PHONE_NO, string p_MOBILE_NO, string p_EMAIL, int p_LOCATION_ID, string p_GST_NO, string p_ADDRESS, string p_MARKET, string p_ROUTE, string p_HOME_TOWN, int p_BUSSINESS_TYPE_ID, int p_CUSTOMER_TYPE_ID, int p_CHANNEL_TYPE_ID, int p_VOLUME_CLASS_ID, DateTime p_TIMESTAMP)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectCREATE_CUSTOMER ObjSelect = new spSelectCREATE_CUSTOMER();
                ObjSelect.Connection = mConnection;

                ObjSelect.CUSTOMER_ID = p_CUSTOMER_ID;
                ObjSelect.CUSTOMER_NAME = p_CUSTOMER_NAME;
                ObjSelect.CUSTOMER_SHORTNAME = p_CUSTOMER_SHORTNAME;
                ObjSelect.CONTACT_PERSON = p_CONTACT_PERSON;
                ObjSelect.PHONE_NO = p_PHONE_NO;
                ObjSelect.MOBILE_NO = p_MOBILE_NO;
                ObjSelect.EMAIL = p_EMAIL;
                ObjSelect.LOCATION_ID = p_LOCATION_ID;
                ObjSelect.GST_NO = p_GST_NO;
                ObjSelect.ADDRESS = p_ADDRESS;
                ObjSelect.MARKET = p_MARKET;
                ObjSelect.ROUTE = p_ROUTE;
                ObjSelect.HOME_TOWN = p_HOME_TOWN;
                ObjSelect.BUSSINESS_TYPE_ID = p_BUSSINESS_TYPE_ID;
                ObjSelect.CUSTOMER_TYPE_ID = p_CUSTOMER_TYPE_ID;
                ObjSelect.CHANNEL_TYPE_ID = p_CHANNEL_TYPE_ID;
                ObjSelect.VOLUME_CLASS_ID = p_VOLUME_CLASS_ID;
                ObjSelect.TIMESTAMP = p_TIMESTAMP;

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
        public bool UpdateCustomer(int p_CUSTOMER_ID, string p_CUSTOMER_NAME, string p_CUSTOMER_SHORTNAME, string p_CONTACT_PERSON, string p_PHONE_NO, string p_MOBILE_NO, string p_EMAIL, int p_LOCATION_ID, string p_GST_NO, string p_ADDRESS, string p_MARKET, string p_ROUTE, string p_HOME_TOWN, int p_BUSSINESS_TYPE_ID, int p_CUSTOMER_TYPE_ID, int p_CHANNEL_TYPE_ID, int p_VOLUME_CLASS_ID, DateTime p_TIMESTAMP)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spUpdateCREATE_CUSTOMER ObjUpdate = new spUpdateCREATE_CUSTOMER();

                ObjUpdate.Connection = mConnection;
                ObjUpdate.CUSTOMER_ID = p_CUSTOMER_ID;
                ObjUpdate.CUSTOMER_NAME = p_CUSTOMER_NAME;
                ObjUpdate.CUSTOMER_SHORTNAME = p_CUSTOMER_SHORTNAME;
                ObjUpdate.CONTACT_PERSON = p_CONTACT_PERSON;
                ObjUpdate.PHONE_NO = p_PHONE_NO;
                ObjUpdate.MOBILE_NO = p_MOBILE_NO;
                ObjUpdate.EMAIL = p_EMAIL;
                ObjUpdate.LOCATION_ID = p_LOCATION_ID;
                ObjUpdate.GST_NO = p_GST_NO;
                ObjUpdate.ADDRESS = p_ADDRESS;
                ObjUpdate.MARKET = p_MARKET;
                ObjUpdate.ROUTE = p_ROUTE;
                ObjUpdate.HOME_TOWN = p_HOME_TOWN;
                ObjUpdate.BUSSINESS_TYPE_ID = p_BUSSINESS_TYPE_ID;
                ObjUpdate.CUSTOMER_TYPE_ID = p_CUSTOMER_TYPE_ID;
                ObjUpdate.CHANNEL_TYPE_ID = p_CHANNEL_TYPE_ID;
                ObjUpdate.VOLUME_CLASS_ID = p_VOLUME_CLASS_ID;
                ObjUpdate.TIMESTAMP = p_TIMESTAMP;

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
