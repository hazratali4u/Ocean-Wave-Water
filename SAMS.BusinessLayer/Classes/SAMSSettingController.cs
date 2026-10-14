using System;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;
using System.Data;

namespace SAMS.BusinessLayer.Classes
{
     public class SAMSSettingController
     {
         public bool InsertBusinessType(string p_SHORT_NAME ,string p_DESCRIPTION ,int p_PARENT_REF_ID ,bool p_IS_ACTIVE ,DateTime p_TIME_STAMP )
         {
             IDbConnection mConnection = null;
             try
             {
                 mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                 mConnection.Open();

                 spInsertSAMS_SETTING ObjInsert = new spInsertSAMS_SETTING();
                 ObjInsert.Connection = mConnection;

                 ObjInsert.SHORT_NAME = p_SHORT_NAME;
                 ObjInsert.DESCRIPTION = p_DESCRIPTION;
                 ObjInsert.PARENT_REF_ID = p_PARENT_REF_ID;
                 ObjInsert.IS_ACTIVE = p_IS_ACTIVE;
                 ObjInsert.TIME_STAMP = p_TIME_STAMP;

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
         public DataTable SelectBusinessType(int p_REF_ID ,string p_SHORT_NAME ,string p_DESCRIPTION ,int p_PARENT_REF_ID ,bool p_IS_ACTIVE ,DateTime p_TIME_STAMP)
         {
             IDbConnection mConnection = null;
             try
             {
                 mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                 mConnection.Open();

                 spSelectSAMS_SETTING ObjSelect = new spSelectSAMS_SETTING();
                 ObjSelect.Connection = mConnection;

                 ObjSelect.REF_ID = p_REF_ID;
                 ObjSelect.SHORT_NAME = p_SHORT_NAME;
                 ObjSelect.DESCRIPTION = p_DESCRIPTION;
                 ObjSelect.PARENT_REF_ID = p_PARENT_REF_ID;
                 ObjSelect.IS_ACTIVE = p_IS_ACTIVE;
                 ObjSelect.TIME_STAMP = p_TIME_STAMP;

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
         public bool UpdateBusinessType( int p_REF_ID ,string p_SHORT_NAME ,string p_DESCRIPTION ,int p_PARENT_REF_ID ,bool p_IS_ACTIVE ,DateTime p_TIME_STAMP )
         {
             IDbConnection mConnection = null;
             try
             {
                 mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                 mConnection.Open();

                 spUpdateSAMS_SETTING ObjUpdate = new spUpdateSAMS_SETTING();
                 ObjUpdate.Connection = mConnection;

                 ObjUpdate.REF_ID = p_REF_ID;
                 ObjUpdate.SHORT_NAME = p_SHORT_NAME;
                 ObjUpdate.DESCRIPTION = p_DESCRIPTION;
                 ObjUpdate.PARENT_REF_ID = p_PARENT_REF_ID;
                 ObjUpdate.IS_ACTIVE = p_IS_ACTIVE;
                 ObjUpdate.TIME_STAMP = p_TIME_STAMP;

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
