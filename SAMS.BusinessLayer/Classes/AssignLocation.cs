using System;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;
using System.Data;

namespace SAMS.BusinessLayer.Classes
{
    public class AssignLocation
    {
        public bool InsertLocation(int p_USER_ID, int p_LOCATION_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertAssignLocation ObjInsert = new spInsertAssignLocation();
                
                ObjInsert.Connection = mConnection;
                ObjInsert.USER_ID = p_USER_ID;
                ObjInsert.LOCATION_ID = p_LOCATION_ID;
               
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
        public DataTable GetAssignedLocation( int p_ID ,int p_USER_ID , int p_LOCATION_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectAssignLocation ObjSelect = new spSelectAssignLocation();
                ObjSelect.Connection = mConnection;
                ObjSelect.ID = p_ID;
                ObjSelect.USER_ID = p_USER_ID;
                ObjSelect.LOCATION_ID = p_LOCATION_ID;
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
        public DataTable GetUnassignedLocation(int p_USER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspUnassignedLocation ObjSelect = new UspUnassignedLocation(); 
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
        public bool DeleteAssignedLocation(int p_USER_ID ,int p_LOCATION_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspDeleteLOCATION_ASSIGNMENT ObjDelete = new UspDeleteLOCATION_ASSIGNMENT();
                ObjDelete.Connection = mConnection;

                ObjDelete.USER_ID = p_USER_ID;
                ObjDelete.LOCATION_ID = p_LOCATION_ID;

                bool Bvalue = ObjDelete.ExecuteQuery();
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
