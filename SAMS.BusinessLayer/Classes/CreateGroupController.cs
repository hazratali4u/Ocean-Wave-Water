using System;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;
using System.Data;

namespace SAMS.BusinessLayer.Classes
{
    public class CreateGroupController
    {
        public string Insert_SKUGroup(string p_GROUP_NAME, DateTime p_TIMESTAMP, bool p_ISACTIVE, int p_UserId, int p_PrincipalId, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertSKU_GROUP ObjInsert = new spInsertSKU_GROUP();
                ObjInsert.Connection = mConnection;
                ObjInsert.GROUP_NAME = p_GROUP_NAME;
                ObjInsert.TIME_STAMP = p_TIMESTAMP;
                ObjInsert.COMPANY_ID = Companyid;
                ObjInsert.USER_ID = p_UserId;
                ObjInsert.LASTUPDATE_DATE = System.DateTime.Now;
                ObjInsert.PRINCIPAL_ID = p_PrincipalId;  
                ObjInsert.ExecuteQuery() ;
                return ObjInsert.SKU_GROUP_ID.ToString();
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
        public bool Insert_SKU_GroupDetail(int p_SKU_GROUP_ID ,int p_SKU_ID )
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertSKU_GROUP_DETAIL ObjInsert = new spInsertSKU_GROUP_DETAIL();

                ObjInsert.Connection = mConnection;
                ObjInsert.SKU_GROUP_ID = p_SKU_GROUP_ID;
                ObjInsert.SKU_ID = p_SKU_ID;

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
        public DataTable GET_SKUGroupDetail(int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspGetGroup_Detail ObjSelect = new UspGetGroup_Detail();
                ObjSelect.Connection = mConnection;
                ObjSelect.COMPANY_ID = Companyid;   
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
        public DataTable GET_Group_ID(int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspGetGroup_ID ObjSelect = new UspGetGroup_ID(); 
                ObjSelect.Connection = mConnection;
                ObjSelect.COMPANY_ID = Companyid;  
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
        public bool Update_SKU_GroupandGroupDetail( int p_SKU_GROUP_ID ,int p_SKU_GROUP_DETAIL_ID , int p_SKU_ID ,string p_GROUP_NAME ,DateTime p_TIMESTAMP ,bool p_ISACTIVE )
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspUpdateGroupandGroupDetail ObjUpdate = new UspUpdateGroupandGroupDetail();

                ObjUpdate.Connection = mConnection;
                ObjUpdate.SKU_GROUP_ID = p_SKU_GROUP_ID;
                ObjUpdate.SKU_GROUP_DETAIL_ID = p_SKU_GROUP_DETAIL_ID;
                ObjUpdate.SKU_ID = p_SKU_ID;
                ObjUpdate.GROUP_NAME = p_GROUP_NAME;
                ObjUpdate.TIMESTAMP = p_TIMESTAMP;
                ObjUpdate.ISACTIVE = p_ISACTIVE;

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
        public DataTable GET_GroupIDviaGroupName(string p_GROUP_NAME)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspGetGroup_IDviaGroupName ObjSelect = new UspGetGroup_IDviaGroupName();
                ObjSelect.Connection = mConnection;
                ObjSelect.GROUP_NAME = p_GROUP_NAME;
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
        public bool UpdateSKUinGroup(int p_SKU_GROUP_ID, int p_SKU_ID, string p_GROUP_NAME, bool p_ISACTIVE,int p_PrincipalId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspUpdateSKUinGroup ObjInsert = new UspUpdateSKUinGroup();

                ObjInsert.Connection = mConnection;
                ObjInsert.SKU_GROUP_ID = p_SKU_GROUP_ID;
                ObjInsert.SKU_ID = p_SKU_ID;
                ObjInsert.GROUP_NAME = p_GROUP_NAME;
                ObjInsert.ISACTIVE = p_ISACTIVE;
                ObjInsert.PRINCIPAL_ID = p_PrincipalId;
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
        public DataTable GET_UniqueGroupName(int p_SKU_GROUP_ID, string p_GROUP_NAME, DateTime p_TIMESTAMP, bool p_ISACTIVE, int p_UserId, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSKU_GROUP ObjSelect = new spSelectSKU_GROUP();
                ObjSelect.Connection = mConnection;
                ObjSelect.SKU_GROUP_ID = p_SKU_GROUP_ID;
                ObjSelect.GROUP_NAME = p_GROUP_NAME;
                ObjSelect.COMPANY_ID = p_UserId;
                ObjSelect.USER_ID = Companyid;   
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
