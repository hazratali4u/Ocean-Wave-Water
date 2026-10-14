using System;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;
using System.Data;

namespace SAMS.BusinessLayer.Classes
{
    public class BrandAssignmentController
    {
        public bool InsertBrandAssignment(int p_USER_ID, int p_PRINCIPAL_ID, int p_DIVISION_ID, int p_CATAGORY_ID, int p_BRAND_ID, int p_DISTRIBUTOR_ID, int p_UPDATE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
               

                UspInsertandUpdateBrand_Assignment ObjInsert = new UspInsertandUpdateBrand_Assignment();
                ObjInsert.Connection = mConnection;
                ObjInsert.USER_ID = p_USER_ID;
                ObjInsert.PRINCIPAL_ID = p_PRINCIPAL_ID;
                ObjInsert.DIVISION_ID = p_DIVISION_ID;
                ObjInsert.CATAGORY_ID = p_CATAGORY_ID;
                ObjInsert.BRAND_ID = p_BRAND_ID;
                ObjInsert.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                ObjInsert.UPDATE = p_UPDATE;
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
        public DataTable GetAssignedUnassigned(int p_USER_ID,int p_BRAND_ID, int p_PRINCIPAL_ID, int p_TYPE )
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspGetAssignedUnassignedBrand ObjSelect = new UspGetAssignedUnassignedBrand();
                ObjSelect.Connection = mConnection;
                ObjSelect.USER_ID = p_USER_ID;
                ObjSelect.BRAND_ID = p_BRAND_ID;
                ObjSelect.PRINCIPAL_ID = p_PRINCIPAL_ID;
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
    }
}
