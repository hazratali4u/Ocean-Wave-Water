using System;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;
using System.Data;

namespace SAMS.BusinessLayer.Classes
{
    public class RoleManagementController
    {
        public bool InsertRoleMaster(string p_ROLE_NAME, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, bool p_IS_ACTIVE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertROLE_MASTER ObjInsert = new spInsertROLE_MASTER();
                ObjInsert.Connection = mConnection;
                ObjInsert.ROLE_NAME = p_ROLE_NAME;
                ObjInsert.TIME_STAMP = p_TIME_STAMP;
                ObjInsert.LASTUPDATE_DATE = p_LASTUPDATE_DATE;
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
        public DataTable SelectRoleMaster(int p_Role_ID,string p_ROLE_NAME, DateTime p_TIME_STAMP, DateTime  p_LASTUPDATE_DATE, bool p_IS_ACTIVE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectROLE_MASTER  ObjSelect = new spSelectROLE_MASTER();
                ObjSelect.Connection = mConnection;
                ObjSelect.ROLE_ID = p_Role_ID; 
                ObjSelect.ROLE_NAME = p_ROLE_NAME;
                ObjSelect.TIME_STAMP = p_TIME_STAMP;
                ObjSelect.LASTUPDATE_DATE = p_LASTUPDATE_DATE;
                
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
        public DataTable SelectModule(int p_MODULE_ID, string p_MODULE_DESCRIPTION, int p_MODULE_PARENT_ID, int p_MODULE_TYPE_ID, DateTime p_TIME_STAMP, bool p_IS_ACTIVE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectMODULE ObjSelect = new spSelectMODULE(); 
                ObjSelect.Connection = mConnection;
                ObjSelect.MODULE_ID = p_MODULE_ID;
                ObjSelect.MODULE_PARENT_ID = p_MODULE_PARENT_ID;
                ObjSelect.MODULE_TYPE_ID = p_MODULE_TYPE_ID;
                ObjSelect.MODULE_DESCRIPTION = p_MODULE_DESCRIPTION;
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
        public DataTable GetAssignUnAssignModule(int p_ROLE_ID, int p_MODULE_PARENT_ID, int p_MODULE_ID, int p_TYPE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspGetModules ObjSelect = new UspGetModules();
                ObjSelect.Connection = mConnection;  
                ObjSelect.MODULE_ID = p_MODULE_ID;
                ObjSelect.MODULE_PARENT_ID = p_MODULE_PARENT_ID;
                ObjSelect.ROLE_ID = p_ROLE_ID;
                ObjSelect.TYPE = p_TYPE;  
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
        public bool InsertRoleDetail(int p_ROLE_ID, int p_MODULE_ID, int p_Unassign)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertROLE_DETAIL ObjInsert = new spInsertROLE_DETAIL(); 
                ObjInsert.Connection = mConnection;
                ObjInsert.ROLE_ID = p_ROLE_ID;
                ObjInsert.MODULE_ID = p_MODULE_ID;
                ObjInsert.Unassign = p_Unassign;
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
        public DataTable SelectRoleWiseModule(int p_Role_id, int p_typeId, int p_LayerTypeId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                GetAssingUserModule ObjSelect = new GetAssingUserModule();
                ObjSelect.Connection = mConnection;
                ObjSelect.RoleId = p_Role_id;
                ObjSelect.typeId = p_typeId;
                ObjSelect.LayerTypeId = p_LayerTypeId;

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