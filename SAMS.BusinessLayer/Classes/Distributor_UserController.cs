using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
    /// <summary>
    /// Summary description for DistributorUserController.
    /// </summary>
    public class Distributor_UserController
    {
        public Distributor_UserController()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string InsertDistributor_User(int p_CompanyId,string p_NIC, bool p_Is_Active, DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_User_Type_Id, int p_Distributor_Id,
            int p_Role_Id, string p_Email_Address, string p_Address1, string p_Address2, string p_Login_Id, string p_Password, string p_Mobile, string p_User_Code, string p_User_Name, string p_Phone)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertDISTRIBUTOR_USER mDistributorUser = new spInsertDISTRIBUTOR_USER();
                mDistributorUser.Connection = mConnection;
                mDistributorUser.COMPANY_ID = p_CompanyId;  
                mDistributorUser.USER_CODE = p_User_Code;
                mDistributorUser.USER_NAME = p_User_Name;
                mDistributorUser.NIC_NO = p_NIC;
                mDistributorUser.ADDRESS1 = p_Address1;
                mDistributorUser.ADDRESS2 = p_Address2;
                mDistributorUser.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistributorUser.EMAIL = p_Email_Address;
                mDistributorUser.LASTUPDATE_DATE = p_Lastupdate_Date;
                mDistributorUser.LOGIN_ID = p_Login_Id;
                mDistributorUser.MOBILE = p_Mobile;
                mDistributorUser.PASSWORD = p_Password;
                mDistributorUser.PHONE = p_Phone;
                mDistributorUser.ROLE_ID = p_Role_Id;
                mDistributorUser.TIME_STAMP = p_Time_Stamp;
                mDistributorUser.DATE_JOIN = p_Time_Stamp;
                mDistributorUser.LASTUPDATE_DATE = p_Lastupdate_Date;
                mDistributorUser.USER_CODE = p_User_Code;
                mDistributorUser.USER_NAME = p_User_Name;
                mDistributorUser.USER_TYPE_ID = p_User_Type_Id;
                mDistributorUser.IS_ACTIVE = p_Is_Active;
                mDistributorUser.ExecuteQuery();

                return mDistributorUser.USER_ID.ToString();

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
        public string UpdateDistributor_User(int UserId,int p_CompanyId,string p_NIC, bool p_Is_Active, DateTime p_Time_Stamp, DateTime p_Lastupdate_Date, int p_User_Type_Id, int p_Distributor_Id,
              int p_Role_Id, string p_Email_Address, string p_Address1, string p_Address2, string p_Login_Id, string p_Password, string p_Mobile, string p_User_Code, string p_User_Name, string p_Phone)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateDISTRIBUTOR_USER mDistributorUser = new spUpdateDISTRIBUTOR_USER();
                mDistributorUser.USER_ID = UserId;  
                mDistributorUser.Connection = mConnection;
                mDistributorUser.COMPANY_ID = p_CompanyId;  
                mDistributorUser.USER_CODE = p_User_Code;
                mDistributorUser.USER_NAME = p_User_Name;
                mDistributorUser.NIC_NO = p_NIC;
                mDistributorUser.ADDRESS1 = p_Address1;
                mDistributorUser.ADDRESS2 = p_Address2;
                mDistributorUser.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistributorUser.EMAIL = p_Email_Address;
                mDistributorUser.LASTUPDATE_DATE = p_Lastupdate_Date;
                mDistributorUser.LOGIN_ID = p_Login_Id;
                mDistributorUser.MOBILE = p_Mobile;
                mDistributorUser.PASSWORD = p_Password;
                mDistributorUser.PHONE = p_Phone;
                mDistributorUser.ROLE_ID = p_Role_Id;
                mDistributorUser.DATE_JOIN = p_Time_Stamp;
                mDistributorUser.TIME_STAMP = p_Time_Stamp;
                mDistributorUser.LASTUPDATE_DATE = p_Lastupdate_Date;  
                mDistributorUser.USER_CODE = p_User_Code;
                mDistributorUser.USER_NAME = p_User_Name;
                mDistributorUser.USER_TYPE_ID = p_User_Type_Id;
                mDistributorUser.IS_ACTIVE = p_Is_Active;
                mDistributorUser.ExecuteQuery();

                return mDistributorUser.USER_ID.ToString();

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
        public DataTable SelectRollBackInvoiceSaleForce(int p_Type, int p_Principal,int p_Distributor)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectRolebackSaleForce mDistUser = new uspSelectRolebackSaleForce(); 
                mDistUser.Connection = mConnection;
                mDistUser.DISTRIBUTOR_ID = p_Distributor;
                mDistUser.PRINCIPAL_ID = p_Principal;
                mDistUser.DOCUMENT_TYPE = p_Type; 
                DataTable dt = mDistUser.ExecuteTable();
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
        public DataTable SelectDistributorUser(int p_Type, int p_Distributor_Id, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectDISTRIBUTOR_USERInfo mDistUser = new uspSelectDISTRIBUTOR_USERInfo();
                mDistUser.Connection = mConnection;

                mDistUser.TYPE = p_Type;
                mDistUser.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistUser.COMPANY_ID = Companyid;  

                DataTable dt = mDistUser.ExecuteTable();
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
        public DataTable SelectSaleForceAssignedArea(int p_Type, int p_Distributor_Id, int Area_Id, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectSaleForce_AssignAreaInfo mDistUser = new uspSelectSaleForce_AssignAreaInfo(); 
                mDistUser.Connection = mConnection;
                mDistUser.TYPE = p_Type;
                mDistUser.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistUser.COMPANY_ID = Companyid;
                mDistUser.AREA_ID = Area_Id;  
                DataTable dt = mDistUser.ExecuteTable();
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

        public DataTable SelectSaleForceAssignedAreaCustomer(int p_Type, int p_Distributor_Id, int Area_Id, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectSaleForce_AssignAreaCustomerInfo mDistUser = new uspSelectSaleForce_AssignAreaCustomerInfo();
                mDistUser.Connection = mConnection;
                mDistUser.TYPE = p_Type;
                mDistUser.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistUser.COMPANY_ID = Companyid;
                mDistUser.AREA_ID = Area_Id;
                DataTable dt = mDistUser.ExecuteTable();
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
     
        public DataTable SelectDistributorUser(string LOGIN_ID, string PASSWORD)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectDISTRIBUTOR_USER mDistUser = new spSelectDISTRIBUTOR_USER();
                mDistUser.Connection = mConnection;
                mDistUser.LOGIN_ID = LOGIN_ID;
                mDistUser.PASSWORD = PASSWORD;
                DataTable dt = mDistUser.ExecuteTable();
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
        public DataTable SelectDistributorSalesForce(int p_Distributor_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectDISTRIBUTORSalesForce mDistUser = new uspSelectDISTRIBUTORSalesForce();
                mDistUser.Connection = mConnection;

                mDistUser.DISTRIBUTOR_ID = p_Distributor_Id;

                DataTable dt = mDistUser.ExecuteTable();
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
        public bool UpdateSalesForceArea(int p_Distributor_Id,int p_SaleForce_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateSALEFORCE_AREA_ASSIGNMENT MArea = new spUpdateSALEFORCE_AREA_ASSIGNMENT();  
                MArea.Connection = mConnection;
                MArea.DISTRIBUTOR_ID = p_Distributor_Id;
                MArea.SALEFORCE_ID = p_SaleForce_Id;
                bool Bvalue  = MArea.ExecuteQuery();
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
        public bool UpdateSalesForceAreaCustomer(int p_Distributor_Id, int p_SaleForce_Id, long p_area_Id, int p_DAY_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateSALEFORCE_AREA_CUSTOMER_ASSIGNMENT MArea = new spUpdateSALEFORCE_AREA_CUSTOMER_ASSIGNMENT();
                MArea.Connection = mConnection;
                MArea.DISTRIBUTOR_ID = p_Distributor_Id;
                MArea.SALEFORCE_ID = p_SaleForce_Id;
                MArea.AREA_ID = p_area_Id;
                bool Bvalue = MArea.ExecuteQuery();
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
        public bool UpdateSalesForceAreaRootCustomer(int p_Distributor_Id, int p_SaleForce_Id, long p_area_Id, long p_customer_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateSALEFORCE_AREA_ROOT_CUSTOMER_ASSIGNMENT MArea = new spUpdateSALEFORCE_AREA_ROOT_CUSTOMER_ASSIGNMENT();
                MArea.Connection = mConnection;
                MArea.DISTRIBUTOR_ID = p_Distributor_Id;
                MArea.SALEFORCE_ID = p_SaleForce_Id;
                MArea.AREA_ID = p_area_Id;
                MArea.CUSTOMER_ID = p_customer_Id;
                bool Bvalue = MArea.ExecuteQuery();
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



        public bool InsertSalesForceArea(int p_Distributor_Id, int p_SaleForce_Id,int p_Area_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertSALEFORCE_AREA_ASSIGNMENT MArea = new spInsertSALEFORCE_AREA_ASSIGNMENT();
                MArea.Connection = mConnection;
                MArea.DISTRIBUTOR_ID = p_Distributor_Id;
                MArea.SALEFORCE_ID = p_SaleForce_Id;
                MArea.AREA_ID = p_Area_Id;
                MArea.TIME_STAMP = DateTime.Now;   
                bool Bvalue = MArea.ExecuteQuery();
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
        public bool InsertSalesForceAreaCustomer(int p_Distributor_Id, int p_SaleForce_Id, long p_Area_Id,int p_Day_ID, long customer_Id )
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertSALEFORCE_AREA_CUSTOMER_ASSIGNMENT MArea = new spInsertSALEFORCE_AREA_CUSTOMER_ASSIGNMENT();
                MArea.Connection = mConnection;
                MArea.DISTRIBUTOR_ID = p_Distributor_Id;
                MArea.SALEFORCE_ID = p_SaleForce_Id;
                MArea.AREA_ID = p_Area_Id;
                MArea.CUSTOMER_ID = customer_Id;
                MArea.DAY_ID = p_Day_ID;
                MArea.TIME_STAMP = DateTime.Now;
                bool Bvalue = MArea.ExecuteQuery();
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
        public bool InsertSalesForceAreaRootCustomer(int p_Distributor_Id, int p_SaleForce_Id, long p_Area_Id, int p_Day_ID, long customer_Id)
        {

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertSALEFORCE_AREA_ROOT_CUSTOMER_ASSIGNMENT MArea = new spInsertSALEFORCE_AREA_ROOT_CUSTOMER_ASSIGNMENT();
                MArea.Connection = mConnection;
                MArea.DISTRIBUTOR_ID = p_Distributor_Id;
                MArea.SALEFORCE_ID = p_SaleForce_Id;
                MArea.AREA_ID = p_Area_Id;
                MArea.CUSTOMER_ID = customer_Id;
                MArea.DAY_ID = p_Day_ID;
                MArea.TIME_STAMP = DateTime.Now;
                bool Bvalue = MArea.ExecuteQuery();
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



        public DataTable SelectSalesForceArea(int p_Distributor_Id,int p_SaleForce_Id,long p_Area_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSALEFORCE_AREA_ASSIGNMENT mArea = new spSelectSALEFORCE_AREA_ASSIGNMENT();
                mArea.Connection = mConnection;
                mArea.DISTRIBUTOR_ID = p_Distributor_Id;
                mArea.SALEFORCE_ID = p_SaleForce_Id;
                mArea.AREA_ID = p_Area_Id;  
                DataTable dt = mArea.ExecuteTable();
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



        public DataTable SelectSalesForceAreaCustomer(int p_Distributor_Id, int p_SaleForce_Id, long p_Area_Id, int p_DAY_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSALEFORCE_AREA_CUSTOMER_ASSIGNMENT mArea = new spSelectSALEFORCE_AREA_CUSTOMER_ASSIGNMENT();
                mArea.Connection = mConnection;
                mArea.DISTRIBUTOR_ID = p_Distributor_Id;
                mArea.SALEFORCE_ID = p_SaleForce_Id;
                mArea.AREA_ID = p_Area_Id;
                mArea.DAY = p_DAY_ID;
                DataTable dt = mArea.ExecuteTable();
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

        public DataTable SelectSalesForceAreaRootCustomer(int p_Distributor_Id, int p_SaleForce_Id, long p_Area_Id,int p_Day_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSALEFORCE_AREA_ROOT_CUSTOMER_ASSIGNMENT mArea = new spSelectSALEFORCE_AREA_ROOT_CUSTOMER_ASSIGNMENT();
                mArea.Connection = mConnection;
                mArea.DISTRIBUTOR_ID = p_Distributor_Id;
                mArea.SALEFORCE_ID = p_SaleForce_Id;
                mArea.AREA_ID = p_Area_Id;
                mArea.DAY_ID = p_Day_Id;
                DataTable dt = mArea.ExecuteTable();
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

        public DataTable SelectSaleForceAssignedArea(int p_Distributor_Id, int Area_Id, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectSP_DM_AssignAreaInfo mDistUser = new uspSelectSP_DM_AssignAreaInfo();
                mDistUser.Connection = mConnection;
                mDistUser.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistUser.COMPANY_ID = Companyid;
                mDistUser.AREA_ID = Area_Id;
                DataTable dt = mDistUser.ExecuteTable();
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

        public DataTable SelectSaleForceAssignedAreaCustomer2(int p_Distributor_Id, int Area_Id, int Companyid,int p_DayID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectSP_DM_AssignAreaCustomerInfo mDistUser = new uspSelectSP_DM_AssignAreaCustomerInfo();
                mDistUser.Connection = mConnection;
                mDistUser.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistUser.COMPANY_ID = Companyid;
                mDistUser.AREA_ID = Area_Id;
                mDistUser.DayID = p_DayID;
                DataTable dt = mDistUser.ExecuteTable();
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
        public void InsertSalesForceShortage(int p_Distributor_Id,int p_Principal_id,int p_SaleForce_Id, decimal  p_Amount,DateTime  p_DocumentDate,string p_Remarks)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertSALE_FORCE_SHORTAGE mArea = new spInsertSALE_FORCE_SHORTAGE();
                mArea.Connection = mConnection;
                mArea.LOCATION_ID  = p_Distributor_Id;
                mArea.SALE_FORCE_ID  = p_SaleForce_Id;
                mArea.PRINCIPAL_ID = p_Principal_id;
                mArea.DOCUMENT_DATE = p_DocumentDate;
                mArea.AMOUNT = p_Amount;  
                mArea.TIME_STAMP = DateTime.Now;
                mArea.REMARKS = p_Remarks;  
                mArea.ExecuteQuery();  
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
               
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        public void UpdateSalesForceShortage(int p_ShortId,int p_Distributor_Id, int p_Principal_id, int p_SaleForce_Id, decimal p_Amount, DateTime p_DocumentDate, string p_Remarks)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateSALE_FORCE_SHORTAGE mArea = new spUpdateSALE_FORCE_SHORTAGE();
                mArea.Connection = mConnection;
                mArea.SALE_FORCE_SHORT_ID = p_ShortId;  
                mArea.LOCATION_ID = p_Distributor_Id;
                mArea.SALE_FORCE_ID = p_SaleForce_Id;
                mArea.PRINCIPAL_ID = p_Principal_id;
                mArea.DOCUMENT_DATE = p_DocumentDate;
                mArea.TIME_STAMP = DateTime.Now;
                mArea.REMARKS = p_Remarks;
                mArea.AMOUNT = p_Amount;  
                mArea.ExecuteQuery();
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        public DataTable SelectSalesForceShortage(int p_Distributor_Id, int p_SaleForce_Id, int p_Principal_Id, DateTime p_DocumentDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSALE_FORCE_SHORTAGE mArea = new spSelectSALE_FORCE_SHORTAGE();
                mArea.Connection = mConnection;
                mArea.LOCATION_ID = p_Distributor_Id;
                mArea.SALE_FORCE_ID = p_SaleForce_Id;
                mArea.PRINCIPAL_ID  = p_Principal_Id;
                mArea.DOCUMENT_DATE = p_DocumentDate;
                mArea.TIME_STAMP = Constants.DateNullValue;
                mArea.SALE_FORCE_SHORT_ID = Constants.IntNullValue;
                mArea.REMARKS = null; 
                DataTable dt = mArea.ExecuteTable();
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
        public bool UpdateSalesForcePrincipal(int p_Distributor_Id, int p_SaleForce_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateSALEFORCE_PRINCIPAL_ASSIGNMENT MPrincipal = new spUpdateSALEFORCE_PRINCIPAL_ASSIGNMENT();
                MPrincipal.Connection = mConnection;
                MPrincipal.DISTRIBUTOR_ID = p_Distributor_Id;
                MPrincipal.SALEFORCE_ID = p_SaleForce_Id;
                bool Bvalue = MPrincipal.ExecuteQuery();
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
        public bool InsertSalesForcePrincipal(int p_Distributor_Id, int p_SaleForce_Id, int p_Principal_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertSALEFORCE_PRINCIPAL_ASSIGNMENT MPrincipal = new spInsertSALEFORCE_PRINCIPAL_ASSIGNMENT();
                MPrincipal.Connection = mConnection;
                MPrincipal.DISTRIBUTOR_ID = p_Distributor_Id;
                MPrincipal.SALEFORCE_ID = p_SaleForce_Id;
                MPrincipal.PRINCIPAL_ID = p_Principal_Id;
                MPrincipal.TIME_STAMP = DateTime.Now;
                bool Bvalue = MPrincipal.ExecuteQuery();
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
        public DataTable SelectSalesForcePrincipal(int p_Distributor_Id, int p_SaleForce_Id, int p_Principal_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSALEFORCE_PRINCIPAL_ASSIGNMENT mPrincipal = new spSelectSALEFORCE_PRINCIPAL_ASSIGNMENT();
                mPrincipal.Connection = mConnection;
                mPrincipal.DISTRIBUTOR_ID = p_Distributor_Id;
                mPrincipal.SALEFORCE_ID = p_SaleForce_Id;
                mPrincipal.PRINCIPAL_ID = p_Principal_Id;
                DataTable dt = mPrincipal.ExecuteTable();
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
        public DataTable SelectDistributorSalesForceType(int p_Distributor_ID, int p_USER_TYPE_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectDISTRIBUTOR_USER mDistUser = new spSelectDISTRIBUTOR_USER();
                mDistUser.Connection = mConnection;
                mDistUser.DISTRIBUTOR_ID = p_Distributor_ID;
                mDistUser.USER_TYPE_ID = p_USER_TYPE_ID;
                DataTable dt = mDistUser.ExecuteTable();
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
