using System;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;
using System.Data;

namespace SAMS.BusinessLayer.Classes
{
   public class LocationController
    {
       public bool InsertLocation(string p_LOCATION_NAME, string p_LOCATION_SHORT_NAME, string p_PHONE_NO, string p_MOBILE_NO, string p_FAX_NO, string p_EMAIL, DateTime p_OPENING_DATE, DateTime p_CLOSING_DATE, string p_REGISTRATION_NO, string p_ADDRESS, int p_TOWN_ID, bool p_INPUT_ACTIVE, bool p_OUTPUT_ACTIVE, int p_LOCATION_TYPE_ID, string p_CONTACT_PERSON)
       {
           IDbConnection mConnection = null;
           try
           {
               mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
               mConnection.Open();

               spInsertLOCATION ObjInsert = new spInsertLOCATION();

               ObjInsert.Connection = mConnection;
               ObjInsert.LOCATION_NAME = p_LOCATION_NAME;
               ObjInsert.LOCATION_SHORT_NAME = p_LOCATION_SHORT_NAME;
               ObjInsert.PHONE_NO = p_PHONE_NO;
               ObjInsert.MOBILE_NO = p_MOBILE_NO;
               ObjInsert.FAX_NO = p_FAX_NO;
               ObjInsert.EMAIL = p_EMAIL;
               ObjInsert.OPENING_DATE = p_OPENING_DATE;
               ObjInsert.CLOSING_DATE = p_CLOSING_DATE;
               ObjInsert.REGISTRATION_NO = p_REGISTRATION_NO;
               ObjInsert.ADDRESS = p_ADDRESS;
               ObjInsert.TOWN_ID = p_TOWN_ID;
               ObjInsert.INPUT_ACTIVE = p_INPUT_ACTIVE;
               ObjInsert.OUTPUT_ACTIVE = p_OUTPUT_ACTIVE;
               ObjInsert.LOCATION_TYPE_ID = p_LOCATION_TYPE_ID;
               ObjInsert.CONTACT_PERSON = p_CONTACT_PERSON;


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

       public DataTable Select_Location(int p_LOCATION_ID ,string p_LOCATION_NAME ,string p_LOCATION_SHORT_NAME ,string p_PHONE_NO ,string p_MOBILE_NO ,string p_FAX_NO ,string p_EMAIL ,DateTime p_OPENING_DATE ,DateTime p_CLOSING_DATE ,string p_REGISTRATION_NO ,string p_ADDRESS ,int p_TOWN_ID ,bool p_INPUT_ACTIVE ,bool p_OUTPUT_ACTIVE ,int p_LOCATION_TYPE_ID ,string p_CONTACT_PERSON )
       {
           IDbConnection mConnection = null;
           try
           {
               mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
               mConnection.Open();

               spSelectLOCATION ObjSelect = new spSelectLOCATION();
               
               ObjSelect.Connection = mConnection;
               ObjSelect.LOCATION_ID = p_LOCATION_ID;
               ObjSelect.LOCATION_NAME = p_LOCATION_NAME;
               ObjSelect.LOCATION_SHORT_NAME = p_LOCATION_SHORT_NAME;
               ObjSelect.PHONE_NO = p_PHONE_NO;
               ObjSelect.MOBILE_NO = p_MOBILE_NO;
               ObjSelect.FAX_NO = p_FAX_NO;
               ObjSelect.EMAIL = p_EMAIL;
               ObjSelect.OPENING_DATE = p_OPENING_DATE;
               ObjSelect.CLOSING_DATE = p_CLOSING_DATE;
               ObjSelect.REGISTRATION_NO = p_REGISTRATION_NO;
               ObjSelect.ADDRESS = p_ADDRESS;
               ObjSelect.TOWN_ID = p_TOWN_ID;
               ObjSelect.INPUT_ACTIVE = p_INPUT_ACTIVE;
               ObjSelect.OUTPUT_ACTIVE = p_OUTPUT_ACTIVE;
               ObjSelect.LOCATION_TYPE_ID = p_LOCATION_TYPE_ID;
               ObjSelect.CONTACT_PERSON = p_CONTACT_PERSON;

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

       public bool UpdateLocation(int p_LOCATION_ID, string p_LOCATION_NAME, string p_LOCATION_SHORT_NAME, string p_PHONE_NO, string p_MOBILE_NO, string p_FAX_NO, string p_EMAIL, DateTime p_OPENING_DATE, DateTime p_CLOSING_DATE, string p_REGISTRATION_NO, string p_ADDRESS, int p_TOWN_ID, bool p_INPUT_ACTIVE, bool p_OUTPUT_ACTIVE, int p_LOCATION_TYPE_ID, string p_CONTACT_PERSON)
       {
           IDbConnection mConnection = null;
           try
           {
               mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
               mConnection.Open();

               spUpdateLOCATION ObjUpdate = new spUpdateLOCATION();

               ObjUpdate.Connection = mConnection;
               ObjUpdate.LOCATION_ID = p_LOCATION_ID;
               ObjUpdate.LOCATION_NAME = p_LOCATION_NAME;
               ObjUpdate.LOCATION_SHORT_NAME = p_LOCATION_SHORT_NAME;
               ObjUpdate.PHONE_NO = p_PHONE_NO;
               ObjUpdate.MOBILE_NO = p_MOBILE_NO;
               ObjUpdate.FAX_NO = p_FAX_NO;
               ObjUpdate.EMAIL = p_EMAIL;
               ObjUpdate.OPENING_DATE = p_OPENING_DATE;
               ObjUpdate.CLOSING_DATE = p_CLOSING_DATE;
               ObjUpdate.REGISTRATION_NO = p_REGISTRATION_NO;
               ObjUpdate.ADDRESS = p_ADDRESS;
               ObjUpdate.TOWN_ID = p_TOWN_ID;
               ObjUpdate.INPUT_ACTIVE = p_INPUT_ACTIVE;
               ObjUpdate.OUTPUT_ACTIVE = p_OUTPUT_ACTIVE;
               ObjUpdate.LOCATION_TYPE_ID = p_LOCATION_TYPE_ID;
               ObjUpdate.CONTACT_PERSON = p_CONTACT_PERSON;

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
