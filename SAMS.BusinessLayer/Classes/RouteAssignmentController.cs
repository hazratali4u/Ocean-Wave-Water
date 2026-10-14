using System;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;
using System.Data;

namespace SAMS.BusinessLayer.Classes
{
    public class RouteAssignmentController
    {
        public bool InsertRouteAssignment(int p_USER_ID ,DateTime p_TIME_STAMP,int p_DISTRIBUTOR_ID, int p_REGION_ID,int p_ZONE_ID,int p_TERRITORY_ID,int p_TOWN_ID,int p_ROUTE_ID , int p_LOCATION_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                //spInsertROLE_DETAIL ObjInsert = new spInsertROLE_DETAIL();
                spInsertROUTE_ASSIGNMENT ObjInsert = new spInsertROUTE_ASSIGNMENT();
                ObjInsert.Connection = mConnection;

                ObjInsert.USER_ID = p_USER_ID;
                ObjInsert.TIME_STAMP = p_TIME_STAMP;
                ObjInsert.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                ObjInsert.REGION_ID = p_REGION_ID;
                ObjInsert.ZONE_ID = p_ZONE_ID;
                ObjInsert.TERRITORY_ID = p_TERRITORY_ID;
                ObjInsert.TOWN_ID = p_TOWN_ID;
                ObjInsert.ROUTE_ID = p_ROUTE_ID;
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
        public bool DeleteAssignedRoute(int p_ROUTE_ASSIGNMENT_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spDeleteROUTE_ASSIGNMENT ObjDelete = new spDeleteROUTE_ASSIGNMENT();
                ObjDelete.Connection = mConnection;

                ObjDelete.ROUTE_ASSIGNMENT_ID = p_ROUTE_ASSIGNMENT_ID;

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
        public DataTable SelectAssingUnAssingRoute( int p_UserId, int p_PARENT_GEO_ID,int Selecttype)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspGetAssignedUnassignedRoute ObjSelect = new UspGetAssignedUnassignedRoute(); 
                ObjSelect.Connection = mConnection;
                ObjSelect.USER_ID = p_UserId;
                ObjSelect.TYPE_ID = p_PARENT_GEO_ID;
                ObjSelect.TYPE = Selecttype;
                DataTable dt  =  ObjSelect.ExecuteTable();
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
