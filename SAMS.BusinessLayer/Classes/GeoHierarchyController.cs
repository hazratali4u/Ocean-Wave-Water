using System;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;
using System.Data;
using SAMS.BusinessLayer.Classes;    

namespace SAMS.BusinessLayer.Classes
{
    public class GeoHierarchyController
    {
        public DataTable SelectGeoHierarchy(int p_geo_id, int p_DISTRIBUTOR_ID, int p_PARENT_GEO_ID, string p_GEO_CODE, string p_GEO_NAME, bool p_Is_Deleted, int p_STATUS, int p_GEO_TYPE_ID, int p_USER_ID, DateTime p_TIME_STAMP, DateTime p_LASTUPDATE_DATE, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectGEO_HIERARCHY mGeoHierarchy = new spSelectGEO_HIERARCHY();
                mGeoHierarchy.Connection = mConnection;
                mGeoHierarchy.GEO_ID = p_geo_id;
                mGeoHierarchy.PARENT_GEO_ID = p_PARENT_GEO_ID;
                mGeoHierarchy.GEO_CODE = p_GEO_CODE;
                mGeoHierarchy.GEO_NAME = p_GEO_NAME;
                mGeoHierarchy.COMPANY_ID = Companyid;   
                mGeoHierarchy.ISCURRENT = Constants.IntNullValue; 
                if (p_Is_Deleted == true)
                {
                    mGeoHierarchy.ISDELETED = 1;

                }
                else
                {
                  mGeoHierarchy.ISDELETED = 0;

                }
                mGeoHierarchy.STATUS = p_STATUS;
                mGeoHierarchy.COMPANY_ID = Companyid; 
                mGeoHierarchy.GEO_TYPE_ID = p_GEO_TYPE_ID;
                mGeoHierarchy.USER_ID = Constants.IntNullValue; 
                mGeoHierarchy.TIME_STAMP = Constants.DateNullValue;
                mGeoHierarchy.LASTUPDATE_DATE = Constants.DateNullValue;
                mGeoHierarchy.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mGeoHierarchy.IP_ADDRESS = null;

                DataTable dt = mGeoHierarchy.ExecuteTable();
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
        public DataTable SelectGeoHierarchy(int p_DISTRIBUTOR_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectDistributor_TOWN mGeoHierarchy = new spSelectDistributor_TOWN();
                mGeoHierarchy.Connection = mConnection;
                mGeoHierarchy.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;  
                DataTable dt = mGeoHierarchy.ExecuteTable();
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
        public string InsertHierarchy(int p_Parent_Geo_Id, string p_Geo_Code, string p_Geo_Name, bool p_Is_Current, bool p_Is_Deleted, int p_Status, int p_Company_Id, int p_Geo_Type_Id, int p_User_Id, int p_Distributor_Id, string p_Ip_Address)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertGEO_HIERARCHY mGeoHierarchy = new spInsertGEO_HIERARCHY();
                mGeoHierarchy.Connection = mConnection;

                mGeoHierarchy.PARENT_GEO_ID = p_Parent_Geo_Id;
                mGeoHierarchy.GEO_CODE = p_Geo_Code;
                mGeoHierarchy.GEO_NAME = p_Geo_Name;
                mGeoHierarchy.ISCURRENT = p_Is_Current;
                mGeoHierarchy.ISDELETED = p_Is_Deleted;
                mGeoHierarchy.STATUS = p_Status;
                mGeoHierarchy.COMPANY_ID = p_Company_Id;
                mGeoHierarchy.GEO_TYPE_ID = p_Geo_Type_Id;
                mGeoHierarchy.USER_ID = p_User_Id;
                mGeoHierarchy.TIME_STAMP = System.DateTime.Now;
                mGeoHierarchy.LASTUPDATE_DATE = System.DateTime.Now;
                mGeoHierarchy.DISTRIBUTOR_ID = p_Distributor_Id;
                mGeoHierarchy.IP_ADDRESS = p_Ip_Address;

                bool a = mGeoHierarchy.ExecuteQuery();
                if (a)
                {
                    return "Record Inserted";
                }
                else
                {
                    return "Record Inserted";
                }
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        public DataTable SelectGeoHierarchyData(int p_Brand_id , int p_sku_type_id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                //spSelectGEO_HIERARCHY ObjSelect = new spSelectGEO_HIERARCHY();

                UspGetDataGeohierarchy ObjSelect = new UspGetDataGeohierarchy();
                ObjSelect.Connection = mConnection;  
                ObjSelect.Brand_id = p_Brand_id;
                ObjSelect.SKU_Hie_type_id = p_sku_type_id;

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
        public string UpdateHierarchy(int p_Geo_Id, int p_Parent_Geo_Id, string p_Geo_Code, string p_Geo_Name, bool p_Is_Current, bool p_Is_Deleted, int p_Status, int p_Company_Id, int p_Geo_Type_Id, int p_User_Id, int p_Distributor_Id, string p_Ip_Address)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateGEO_HIERARCHY mGeoHierarchy = new spUpdateGEO_HIERARCHY();
                mGeoHierarchy.Connection = mConnection;

                mGeoHierarchy.GEO_ID = p_Geo_Id;
                mGeoHierarchy.PARENT_GEO_ID = p_Parent_Geo_Id;
                mGeoHierarchy.GEO_CODE = p_Geo_Code;
                mGeoHierarchy.GEO_NAME = p_Geo_Name;
                mGeoHierarchy.ISCURRENT = p_Is_Current;
                mGeoHierarchy.ISDELETED = p_Is_Deleted;
                mGeoHierarchy.STATUS = p_Status;
                mGeoHierarchy.COMPANY_ID = p_Company_Id;
                mGeoHierarchy.GEO_TYPE_ID = p_Geo_Type_Id;
                mGeoHierarchy.USER_ID = p_User_Id;
                mGeoHierarchy.TIME_STAMP = System.DateTime.Now;
                mGeoHierarchy.LASTUPDATE_DATE = System.DateTime.Now;
                mGeoHierarchy.DISTRIBUTOR_ID = p_Distributor_Id;
                mGeoHierarchy.IP_ADDRESS = p_Ip_Address;

                mGeoHierarchy.ExecuteQuery();
                return "Record Updated";
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return "Record Updated"; 
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        public DataTable SelectAssignTown(int p_PARAENT_ID,int  p_DISTRIBUTOR_ID,int TypeId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspGetAssignTown mGeoHierarchy = new UspGetAssignTown(); 
                mGeoHierarchy.Connection = mConnection;
                mGeoHierarchy.PARENT_ID = p_PARAENT_ID; 
                mGeoHierarchy.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mGeoHierarchy.TYPE = TypeId;        
                DataTable dt = mGeoHierarchy.ExecuteTable();
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
        public DataTable SelectDistributorHierachyWithType(int typeid, int Locationtype, string TownId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectView_GeoHIERARCHY Selectdata = new UspSelectView_GeoHIERARCHY();
                Selectdata.Connection = mConnection;
                Selectdata.type = typeid;
                Selectdata.Paraid = Locationtype;
                Selectdata.ZoneId = Constants.IntNullValue;
                Selectdata.TerritoryId = Constants.IntNullValue;
                Selectdata.TownId = TownId;
                DataTable dt = Selectdata.ExecuteTable();
                return dt;

            }
            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
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
