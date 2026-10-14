using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;



namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for CustomerDataController.
	/// </summary>
	public class CustomerDataController
	{
		#region variables
		IDbTransaction mTransaction;
		IDbConnection mConnection;
		#endregion
		#region properties
		public IDbTransaction Transaction
		{
			get{return mTransaction;}
			set{mTransaction = value;}
		}
		public IDbConnection Connection
		{
			get{return mConnection;}
			set{mConnection = value;}
		}
		#endregion
		#region public methods
		public bool OpenTransaction()
		{
			try
			{
				Connection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				Connection.Open();
				Transaction = ProviderFactory.GetTransaction(Connection);
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}
		}
		public bool RollbackTransaction()
		{
			if(this.Transaction!=null)
			{
				Transaction.Rollback();
				Connection.Close();
				return true;
			}
			return false;
		}
		public bool CommitTransaction()
		{
			if(this.Transaction!=null)
			{
				Transaction.Commit();
				Connection.Close();
				return true;
			}
			return false;
		}
		#endregion
		public CustomerDataController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public DataTable SelectCreditPendingInvoice(int p_Distributor_Id, int p_PRINCIPAL, long p_CUSTOMER_ID, int P_AREA_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectPendingCreditInvoice mCust = new UspSelectPendingCreditInvoice();
                mCust.Connection = mConnection;
                mCust.PRINCIPAL_ID = p_PRINCIPAL; 
                mCust.DISTRIBUTOR_ID = p_Distributor_Id;
                mCust.CUSTOMER_ID = p_CUSTOMER_ID;
                mCust.AREA_ID = P_AREA_ID; 
                DataTable dt = mCust.ExecuteTable();
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
		public DataTable SelectDistGeoTown(int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDIST_GEO_TOWN mDistGeoTown = new uspSelectDIST_GEO_TOWN();
				mDistGeoTown.Connection = mConnection;

				mDistGeoTown.DISTRIBUTOR_ID=p_Distributor_Id;
				
				DataTable dt = mDistGeoTown.ExecuteTable();
				return dt;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}
        public DataTable SelectCustomerCreditLimit(int p_Distributor_Id,long p_CustomerId,int p_Principal_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectCUSTOMER_PRINCIPAL_CREDITLIMIT mCustomer = new spSelectCUSTOMER_PRINCIPAL_CREDITLIMIT();
                mCustomer.Connection = mConnection;
                mCustomer.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustomer.CUSTOMER_ID = p_CustomerId;
                mCustomer.PRINCIPAL_ID = p_Principal_Id;
                DataTable dt = mCustomer.ExecuteTable();  
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
        public bool CustomerShifting(int p_fromDistributor_Id,int p_toDistributor,int p_fromArea_Id,int p_to_area_id,int p_Rout_id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspCustomerShifting mCustomerShift = new UspCustomerShifting();
                mCustomerShift.Connection = mConnection;
                mCustomerShift.FROM_DISTRIBUTOR_ID = p_fromDistributor_Id;
                mCustomerShift.FROM_AREA_ID = p_fromArea_Id;
                mCustomerShift.TO_DISTRIBUTOR_ID = p_toDistributor;
                mCustomerShift.TO_AREA_ID = p_to_area_id;
                mCustomerShift.ROUTE_ID = p_Rout_id;
                mCustomerShift.ExecuteQuery();
                return true;
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
		public DataTable SelectDistGeoArea(int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR_AREA mDistGeoArea = new spSelectDISTRIBUTOR_AREA();
				mDistGeoArea.Connection = mConnection;

				mDistGeoArea.DISTRIBUTOR_ID=p_Distributor_Id;
				
				DataTable dt = mDistGeoArea.ExecuteTable();
				return dt;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}
        public DataTable SelectOpeningCredit(int p_Distributor_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectOpCredit mDistGeoArea = new UspSelectOpCredit();
                mDistGeoArea.Connection = mConnection;
                mDistGeoArea.DISTRIBUTOR_ID = p_Distributor_Id;

                DataTable dt = mDistGeoArea.ExecuteTable();
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
		public DataTable SelectCustomerByRoute(string strRoutes, string strCustomerTypes, int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectRouteCustomer mCustomer = new uspSelectRouteCustomer();
				mCustomer.Connection = mConnection;

				mCustomer.ROUTES=strRoutes;
				mCustomer.CUSTOMER_TYPES = strCustomerTypes;
				mCustomer.DISTRIBUTOR_ID=p_Distributor_Id;
				DataTable dt = mCustomer.ExecuteTable();
				return dt;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}
		public DataTable SelectDistGeoArea(int p_Distributor_Id,int p_Town_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR_AREA mDistGeoArea = new spSelectDISTRIBUTOR_AREA();
				mDistGeoArea.Connection = mConnection;

				mDistGeoArea.DISTRIBUTOR_ID=p_Distributor_Id;
				mDistGeoArea.TOWN_ID=p_Town_ID;
				DataTable dt = mDistGeoArea.ExecuteTable();
				return dt;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}
		public DataTable SelectCustomerInfo(int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectCustomerDataInfo mCustData = new uspSelectCustomerDataInfo();
				mCustData.Connection = mConnection;

				mCustData.DISTRIBUTOR_ID=p_Distributor_Id;
				
				DataTable dt = mCustData.ExecuteTable();
				return dt;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}
		public DataTable SelectPrincipalCustomer(int p_Distributor_Id,int p_Area,int p_Route,int p_PrincipalId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                UspSelectPRINCIPALCUSTOMER mCustData = new UspSelectPRINCIPALCUSTOMER();
				mCustData.Connection = mConnection;

				mCustData.DISTRIBUTOR_ID=p_Distributor_Id;
				mCustData.AREA_ID = p_Area;
				mCustData.ROUTE_ID = p_Route;
                mCustData.PRINCIPAL_ID = p_PrincipalId;  
                DataTable dt = mCustData.ExecuteTable();
                DataView dv = new DataView(dt);
                dv.Sort = "CUSTOMER_NAME";
                dt = dv.ToTable();
				return dt;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}



        public DataTable SelectPrincipalCustomer(int p_Distributor_Id, int p_Area, int p_Route, int p_PrincipalId,int p_DayID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectPRINCIPALCUSTOMER mCustData = new UspSelectPRINCIPALCUSTOMER();
                mCustData.Connection = mConnection;

                mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustData.AREA_ID = p_Area;
                mCustData.ROUTE_ID = p_Route;
                mCustData.TOWN_ID = p_DayID;
                mCustData.Type = 1;

                mCustData.PRINCIPAL_ID = p_PrincipalId;
                DataTable dt = mCustData.ExecuteTable();
                DataView dv = new DataView(dt);
                dv.Sort = "CUSTOMER_NAME";
                dt = dv.ToTable();
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
        public DataTable SelectAllCustomer(int p_Distributor_Id, int p_Area, int p_Route)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectCUSTOMER mCustData = new spSelectCUSTOMER();
                mCustData.Connection = mConnection;

                mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustData.AREA_ID = p_Area;
                mCustData.ROUTE_ID = p_Route;
                DataTable dt = mCustData.ExecuteTable();
                DataView dv = new DataView(dt);
                dv.Sort = "CUSTOMER_NAME";
                dt = dv.ToTable();
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
        public DataTable SelectPrincipalCustomerOpBalance(int p_Distributor_Id, int p_CustomerId, DateTime  p_fromDate, int p_PrincipalId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspCustomerOpBalance mCustData = new UspCustomerOpBalance();
                mCustData.Connection = mConnection;

                mCustData.Distributor_id = p_Distributor_Id;
                mCustData.principal_id = p_PrincipalId;
                mCustData.From_Date = p_fromDate;
                mCustData.customer_id = p_CustomerId;
                DataTable dt = mCustData.ExecuteTable();
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
        public DataTable SelectPrincipalCustomer(int p_Distributor_Id,int p_PrincipalId,DateTime p_document_date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectInvoiceBuiltyInfo mCustData = new UspSelectInvoiceBuiltyInfo();
                mCustData.Connection = mConnection;

                mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustData.PRINCIPAL_ID = p_PrincipalId;
                mCustData.Document_date = p_document_date;
                mCustData.CUSTOMER_ID = Constants.LongNullValue;
                mCustData.PRINCIPAL_ID = p_PrincipalId;  
                DataTable dt = mCustData.ExecuteTable();
                DataView dv = new DataView(dt);
                dv.Sort = "CUSTOMER_NAME";
                dt = dv.ToTable();
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
        public DataTable SelectAllPrincipalCustomer(int p_Distributor_Id, int p_Area, int p_Route, int p_PrincipalId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectAllPRINCIPALCUSTOMER mCustData = new UspSelectAllPRINCIPALCUSTOMER();
                mCustData.Connection = mConnection;

                mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustData.AREA_ID = p_Area;
                mCustData.ROUTE_ID = p_Route;
                mCustData.PRINCIPAL_ID = p_PrincipalId;
                DataTable dt = mCustData.ExecuteTable();
                DataView dv = new DataView(dt);
                dv.Sort = "CUSTOMER_NAME";
                dt = dv.ToTable();
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
        public bool InsertCustomerCreditLimit(int p_Distributor_Id, long p_Customer_Id, int p_Principal, decimal p_CreditLimit,int p_CreditDays)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertCUSTOMER_PRINCIPAL_CREDITLIMIT mCustData = new spInsertCUSTOMER_PRINCIPAL_CREDITLIMIT();

                mCustData.Connection = mConnection;

                mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustData.CUSTOMER_ID = p_Customer_Id;
                mCustData.PRINCIPAL_ID = p_Principal;
                mCustData.CREDITLIMIT_VALUE = p_CreditLimit;
                mCustData.TIME_STAMP = DateTime.Today;
                mCustData.CREDIT_DAYS = p_CreditDays;
                mCustData.ExecuteQuery();
                return true;
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
        public bool UpdateCustomerCreditLimit(int p_Distributor_Id, long p_Customer_Id, int p_Principal, decimal p_CreditLimit)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateCUSTOMER_PRINCIPAL_CREDITLIMIT mCustData = new spUpdateCUSTOMER_PRINCIPAL_CREDITLIMIT();

                mCustData.Connection = mConnection;
                mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustData.CUSTOMER_ID = p_Customer_Id;
                mCustData.PRINCIPAL_ID = p_Principal;
                mCustData.CREDITLIMIT_VALUE = p_CreditLimit;
                mCustData.ExecuteQuery();
                return true;
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
        public string InsertCustomer(long p_Customer_Id, bool p_Is_Gst_Registered, bool p_Is_Active,
                                            int p_Channel_Type_Id, int p_Volume_Class_Id, int p_Business_Type_Id,
                                            int p_Area_Id, int p_Route_Id, int p_Town_Id, int p_Distributor_Id,
                                            string p_Gst_Number, string p_Contact_Person, string p_Contact_Number, string p_Email_Address,
                                            string p_Customer_Code, string p_Customer_Name, string p_Address, DateTime p_RegDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertCUSTOMER mCustomer = new spInsertCUSTOMER();
                mCustomer.Connection = mConnection;

                mCustomer.CUSTOMER_ID = p_Customer_Id;
                mCustomer.ADDRESS = p_Address;
                mCustomer.AREA_ID = p_Area_Id;
                mCustomer.BUSINESS_TYPE_ID = p_Business_Type_Id;
                mCustomer.CHANNEL_TYPE_ID = p_Channel_Type_Id;
                mCustomer.CONTACT_NUMBER = p_Contact_Number;
                mCustomer.CONTACT_PERSON = p_Contact_Person;
                mCustomer.CUSTOMER_CODE = p_Customer_Code;
                mCustomer.CUSTOMER_NAME = p_Customer_Name;
                mCustomer.EMAIL_ADDRESS = p_Email_Address;
                mCustomer.GST_NUMBER = p_Gst_Number;
                mCustomer.IS_GST_REGISTERED = p_Is_Gst_Registered;
                mCustomer.TOWN_ID = p_Town_Id;
                mCustomer.PROMOTION_CLASS  = p_Volume_Class_Id;
                mCustomer.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustomer.TOWN_ID = p_Town_Id;
                mCustomer.ROUTE_ID = p_Route_Id;
                mCustomer.IS_ACTIVE = p_Is_Active;
                mCustomer.TIME_STAMP = System.DateTime.Now;
                mCustomer.LASTUPDATE_DATE = System.DateTime.Now;
                mCustomer.REGDATE = p_RegDate;
                mCustomer.ExecuteQuery();
                return "Record Updated Customer Code " + p_Customer_Code;

             

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return "Some Error Update Record";
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        public string InsertCustomer(long p_Customer_Id, bool p_Is_Gst_Registered, bool p_Is_Active,
                                         int p_Channel_Type_Id, int p_Volume_Class_Id, int p_Business_Type_Id,
                                         int p_Area_Id, int p_Route_Id, int p_Town_Id, int p_Distributor_Id,
                                         string p_Gst_Number, string p_Contact_Person, string p_Contact_Number, string p_Email_Address,
                                         string p_Customer_Code, string p_Customer_Name, string p_Address, DateTime p_RegDate, int p_Customer_Type_ID, string p_Reffered_By)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertCUSTOMER mCustomer = new spInsertCUSTOMER();
                mCustomer.Connection = mConnection;

                mCustomer.CUSTOMER_ID = p_Customer_Id;
                mCustomer.ADDRESS = p_Address;
                mCustomer.AREA_ID = p_Area_Id;
                mCustomer.BUSINESS_TYPE_ID = p_Business_Type_Id;
                mCustomer.CHANNEL_TYPE_ID = p_Channel_Type_Id;
                mCustomer.CONTACT_NUMBER = p_Contact_Number;
                mCustomer.CONTACT_PERSON = p_Contact_Person;
                mCustomer.CUSTOMER_CODE = p_Customer_Code;
                mCustomer.CUSTOMER_NAME = p_Customer_Name;
                mCustomer.EMAIL_ADDRESS = p_Email_Address;
                mCustomer.GST_NUMBER = p_Gst_Number;
                mCustomer.IS_GST_REGISTERED = p_Is_Gst_Registered;
                mCustomer.TOWN_ID = p_Town_Id;
                mCustomer.PROMOTION_CLASS = p_Volume_Class_Id;
                mCustomer.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustomer.TOWN_ID = p_Town_Id;
                mCustomer.ROUTE_ID = p_Route_Id;
                mCustomer.IS_ACTIVE = p_Is_Active;
                mCustomer.TIME_STAMP = System.DateTime.Now;
                mCustomer.LASTUPDATE_DATE = System.DateTime.Now;
                mCustomer.REGDATE = p_RegDate;
                mCustomer.CUSTOMER_TYPE_ID = p_Customer_Type_ID;
                mCustomer.REFFERED_BY = p_Reffered_By;
                mCustomer.ExecuteQuery();
                return "Record Updated Customer Code " + p_Customer_Code;



            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return "Some Error Update Record";
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
	
        
        
        
        
        
        
        public DataTable SelectCustomerData(int p_Distributor_Id,int p_Town_id,int p_Area_Id,int p_Route_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectCUSTOMER mCustData = new spSelectCUSTOMER();
				mCustData.Connection = mConnection;

				mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
				mCustData.AREA_ID = p_Area_Id;
                mCustData.ROUTE_ID = p_Route_Id;
                mCustData.TOWN_ID = p_Town_id;  
				DataTable dt = mCustData.ExecuteTable();
				return dt;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}
        public DataTable UspSelectCustomer(int p_Distributor_Id,string p_FIELDNAME, string  p_PARAMETERNAME)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                var mCustData = new UspSelectCUSTOMER();
                mCustData.Connection = mConnection;
                mCustData.FEILDNAME = p_FIELDNAME;
                mCustData.PARAMETER = p_PARAMETERNAME;
                mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
                DataTable dt = mCustData.ExecuteTable();
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
        public DataTable RptSelectCustomer(int p_User_Id,int p_DistributorId, string p_FIELDNAME, string p_PARAMETERNAME)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspRptSelectCUSTOMER mCustData = new UspRptSelectCUSTOMER();
                mCustData.Connection = mConnection;
                mCustData.FEILDNAME = p_FIELDNAME;
                mCustData.PARAMETER = p_PARAMETERNAME;
                mCustData.USER_ID = p_User_Id;
                mCustData.DISTRIBUTOR_ID = p_DistributorId;  
                DataTable dt = mCustData.ExecuteTable();
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
        public DataTable SelectCustomerCreditBalance(long p_Customer_Id,int p_Principal_Id,int p_Distributor_id)
        {
            IDbConnection mConnection = null;
            try
            {
                Configuration.GetAccountHead();
  
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectCustomerBalance mCustData = new UspSelectCustomerBalance(); 
                mCustData.Connection = mConnection;
                mCustData.CUSTOMER_ID = p_Customer_Id;
                mCustData.PRINCIPAL_ID = p_Principal_Id;
                mCustData.DISTRIBUTOR_ID = p_Distributor_id;
                mCustData.ACCOUNT_HEAD_ID = long.Parse(Configuration.AccountReceivable);   

                DataTable dt = mCustData.ExecuteTable();
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
		public DataTable SelectCustomerByCode(string p_Customer_Code)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectCUSTOMER mCustData = new spSelectCUSTOMER();
				mCustData.Connection = mConnection;

				mCustData.CUSTOMER_CODE= p_Customer_Code;
				
				DataTable dt = mCustData.ExecuteTable();
				return dt;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}	
		public bool IsUniqueCode(string p_Customer_Code)
		{
			
			IDbConnection mConnection = null;
			try
			{
				spSelectCUSTOMER mCustData = new spSelectCUSTOMER();
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				mCustData.Connection = mConnection;
				mCustData.CUSTOMER_CODE=p_Customer_Code;
				
				DataTable dt = mCustData.ExecuteTable();
				if(dt.Rows.Count>0)
					return false;
				else
					return true;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return false;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}
        public string UpdateCustomer(long p_Customer_Id, bool p_Is_Gst_Registered, bool p_Is_Active,
                                         int p_Channel_Type_Id, int p_Volume_Class_Id, int p_Business_Type_Id,
                                         int p_Area_Id, int p_Route_Id, int p_Town_Id, int p_Distributor_Id,
                                         string p_Gst_Number, string p_Contact_Person, string p_Contact_Number, string p_Email_Address,
                                         string p_Customer_Code, string p_Customer_Name, string p_Address, DateTime p_RegDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateCUSTOMER mCustomer = new spUpdateCUSTOMER();
                mCustomer.Connection = mConnection;

                mCustomer.CUSTOMER_ID = p_Customer_Id;
                mCustomer.ADDRESS = p_Address;
                mCustomer.AREA_ID = p_Area_Id;
                mCustomer.BUSINESS_TYPE_ID  = p_Business_Type_Id;
                mCustomer.CHANNEL_TYPE_ID = p_Channel_Type_Id;
                mCustomer.CONTACT_NUMBER = p_Contact_Number;
                mCustomer.CONTACT_PERSON = p_Contact_Person;
                mCustomer.CUSTOMER_CODE = p_Customer_Code;
                mCustomer.CUSTOMER_NAME = p_Customer_Name;
                mCustomer.EMAIL_ADDRESS = p_Email_Address;
                mCustomer.GST_NUMBER = p_Gst_Number;
                mCustomer.REGDATE = p_RegDate;
                mCustomer.IS_GST_REGISTERED = p_Is_Gst_Registered;
                mCustomer.TOWN_ID = p_Town_Id;
                mCustomer.AREA_ID = p_Area_Id;
                mCustomer.ROUTE_ID = p_Route_Id;
                mCustomer.PROMOTION_CLASS = p_Volume_Class_Id;
                mCustomer.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustomer.IS_ACTIVE = p_Is_Active;
                mCustomer.TIME_STAMP = System.DateTime.Now;
                mCustomer.LASTUPDATE_DATE = System.DateTime.Now;
                mCustomer.ExecuteQuery();
                return "Record Updated Customer Code " + p_Customer_Code;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return "Some error Update Record";
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        public string UpdateCustomer(long p_Customer_Id, bool p_Is_Gst_Registered, bool p_Is_Active,
                                       int p_Channel_Type_Id, int p_Volume_Class_Id, int p_Business_Type_Id,
                                       int p_Area_Id, int p_Route_Id, int p_Town_Id, int p_Distributor_Id,
                                       string p_Gst_Number, string p_Contact_Person, string p_Contact_Number, string p_Email_Address,
                                       string p_Customer_Code, string p_Customer_Name, string p_Address, DateTime p_RegDate, int p_customer_type_ID, string P_REFFERED_BY)
        {
 
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateCUSTOMER mCustomer = new spUpdateCUSTOMER();
                mCustomer.Connection = mConnection;

                mCustomer.CUSTOMER_ID = p_Customer_Id;
                mCustomer.ADDRESS = p_Address;
                mCustomer.AREA_ID = p_Area_Id;
                mCustomer.BUSINESS_TYPE_ID = p_Business_Type_Id;
                mCustomer.CHANNEL_TYPE_ID = p_Channel_Type_Id;
                mCustomer.CONTACT_NUMBER = p_Contact_Number;
                mCustomer.CONTACT_PERSON = p_Contact_Person;
                mCustomer.CUSTOMER_CODE = p_Customer_Code;
                mCustomer.CUSTOMER_NAME = p_Customer_Name;
                mCustomer.EMAIL_ADDRESS = p_Email_Address;
                mCustomer.GST_NUMBER = p_Gst_Number;
                mCustomer.REGDATE = p_RegDate;
                mCustomer.IS_GST_REGISTERED = p_Is_Gst_Registered;
                mCustomer.TOWN_ID = p_Town_Id;
                mCustomer.AREA_ID = p_Area_Id;
                mCustomer.ROUTE_ID = p_Route_Id;
                mCustomer.PROMOTION_CLASS = p_Volume_Class_Id;
                mCustomer.DISTRIBUTOR_ID = p_Distributor_Id;
                mCustomer.IS_ACTIVE = p_Is_Active;
                mCustomer.TIME_STAMP = System.DateTime.Now;
                mCustomer.LASTUPDATE_DATE = System.DateTime.Now;
                mCustomer.CUSTOMER_TYPE_ID = p_customer_type_ID;
                mCustomer.REFFERED_BY = P_REFFERED_BY;
                mCustomer.ExecuteQuery();
                return "Record Updated Customer Code " + p_Customer_Code;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return "Some error Update Record";
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
     
		public DataTable SelectCustomersData(int AreaId)
		{
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
			
				spSelectCUSTOMER mspSelectCustomer= new spSelectCUSTOMER();
				mspSelectCustomer.Connection = mConnection;
                mspSelectCustomer.AREA_ID = AreaId;
				mspSelectCustomer.IS_ACTIVE = true;
				return(mspSelectCustomer.ExecuteTable());
			}
	  		catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
 		 
		}
        public bool ImportRoute(int p_TownId, int p_DistributorId, string pFileName, int p_UserId)
        {
            IDbConnection mConnection = null;
            FileStream Sourcefile = null;
            StreamReader ReadSourceFile = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();


                Sourcefile = new FileStream(pFileName, FileMode.Open);
                ReadSourceFile = new StreamReader(Sourcefile);
                string FileContents = "";

                while ((FileContents = ReadSourceFile.ReadLine()) != null)
                {

                    string[] ParametersArr = FileContents.Split(Constants.File_Delimiter);

                    spInsertDISTRIBUTOR_AREA mDistRoute = new spInsertDISTRIBUTOR_AREA(); 

                    mDistRoute.Connection = mConnection;
                    mDistRoute.DISTRIBUTOR_ID = p_DistributorId;
                    mDistRoute.AREA_ID = int.Parse(ParametersArr[0].ToString()); 
                    mDistRoute.AREA_CODE = ParametersArr[1].ToString(); 
                    mDistRoute.AREA_NAME = ParametersArr[2].ToString();
                    mDistRoute.TOWN_ID = p_TownId ;
                    mDistRoute.TIME_STAMP = DateTime.Now;
                    mDistRoute.LASTUPDATE_DATE = DateTime.Now;
                    mDistRoute.IS_ACTIVE = true;  
                    mDistRoute.ExecuteQuery();
                }
                return true;

            }

            catch (Exception excp)
            {
                ReadSourceFile.Close();
                mConnection.Close();
                ExceptionPublisher.PublishException(excp);
                return false;

            }
            finally
            {
                ReadSourceFile.Close();
                mConnection.Close();

            }

        }
        public bool ImportMarket(int p_TownId, int p_DistributorId, string pFileName,int p_UserId)
        {
            IDbConnection mConnection = null;
            FileStream Sourcefile = null;
            StreamReader ReadSourceFile = null;
            IDbTransaction mTransaction = null; 
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                Sourcefile = new FileStream(pFileName, FileMode.Open);
                ReadSourceFile = new StreamReader(Sourcefile);
                string FileContents = "";

                while ((FileContents = ReadSourceFile.ReadLine()) != null)
                {

                    string[] ParametersArr = FileContents.Split(Constants.File_Delimiter);

                    spInsertDISTRIBUTOR_ROUTE mDistRoute = new spInsertDISTRIBUTOR_ROUTE();
                    mDistRoute.Transaction = mTransaction; 
                    mDistRoute.Connection = mConnection;
                    mDistRoute.DISTRIBUTOR_ID = p_DistributorId;
                    mDistRoute.AREA_ID = int.Parse(ParametersArr[0].ToString());
                    mDistRoute.ROUTE_ID = long.Parse(ParametersArr[1].ToString());  
                    mDistRoute.ROUTE_CODE  = ParametersArr[2].ToString();
                    mDistRoute.ROUTE_NAME = ParametersArr[3].ToString();
                    mDistRoute.TOWN_ID = p_TownId;  
                    mDistRoute.LASTUPDATE_DATE = System.DateTime.Now;
                    mDistRoute.TIME_STAMP = System.DateTime.Now;
                    mDistRoute.IS_ACTIVE = true; 
                    mDistRoute.ExecuteQuery();
                }
                mTransaction.Commit(); 
                return true;
                
            }

            catch (Exception excp)
            {
                mTransaction.Rollback();  
                ReadSourceFile.Close();
                mConnection.Close();
                ExceptionPublisher.PublishException(excp);
                return false;

            }
            finally
            {
                ReadSourceFile.Close();
                mConnection.Close();

            }

        }
        public DataSet SelectPivateTableExcelFile(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID,DateTime P_FromDate,DateTime p_ToDate,int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspfinalsaleDetailView mCustData = new UspfinalsaleDetailView();
                mCustData.Connection = mConnection;

                mCustData.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mCustData.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mCustData.FROM_DATE = P_FromDate;
                mCustData.TO_DATE = p_ToDate;
                mCustData.TOWN_ID = p_UserId;  
                DataSet dt = mCustData.ExecuteTable(); 
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
        //public  void ExportToExcel()//to excel
        //{
            
            
            

            //Excel.Worksheet worksheet = null;
            //Excel.ApplicationClass excel = null;

            //try
            //{

            //    excel = new Excel.ApplicationClass();

            //    excel.Application.Workbooks.Add(true);
            //    DataTable table = ds.Tables[0].Copy();
            //    int ColumnIndex = 0;
            //    foreach (DataColumn col in table.Columns)
            //    {
            //        ColumnIndex++;
            //        excel.Cells[1, ColumnIndex] = col.ColumnName;
            //    }
            //    int rowIndex = 0;
            //    foreach (DataRow row in table.Rows)
            //    {
            //        rowIndex++;
            //        ColumnIndex = 0;
            //        foreach (DataColumn col in table.Columns)
            //        {
            //            ColumnIndex++;
            //            excel.Cells[rowIndex + 1, ColumnIndex] = row[col.ColumnName].ToString();
            //        }
            //    }
                
            //    excel.Visible = true;
            //    worksheet = (Excel.Worksheet)excel.ActiveSheet;
            //    string mstrAppPath = Configuration.GetAppInstallationPath();
            //    worksheet.SaveAs(mstrAppPath +"ExcelReports.xls","xls",null,null,true,null,null,null,false,false);

                // Need all following code to clean up and remove all references!!!
                //worksheet.Close(null,null,null);
                //worksheet.SaveAs("CustomerFinaldata.xls",  
                //worksheet.Activate();

                //MessageBox.Show("Record Exported Succesfully", "SLASH", MessageBoxButtons.OK, MessageBoxIcon.Information);


        //    }
        //    catch (Exception excp)
        //    {
        //        ExceptionPublisher.PublishException(excp);
        //       // return null;
        //    }
        //    finally
        //    {
        //        if (worksheet != null) Marshal.ReleaseComObject(worksheet);
        //        if (excel != null) Marshal.ReleaseComObject(excel);
        //        worksheet = null;
        //        excel = null;
        //    }


        //}

	
        public bool ImportCustomer(int p_TownId, int p_DistributorId, string pFileName)
        {
            IDbConnection mConnection = null;
            FileStream Sourcefile = null;
            StreamReader ReadSourceFile = null;
            IDbTransaction mTransaction = null;
           
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                Sourcefile = new FileStream(pFileName, FileMode.Open);
                ReadSourceFile = new StreamReader(Sourcefile);
                string FileContents = "";
                try
                {   
                    while ((FileContents = ReadSourceFile.ReadLine()) != null)
                    {

                    string[] ParametersArr = FileContents.Split(Constants.File_Delimiter);
                    spInsertCUSTOMER mDistRoute = new spInsertCUSTOMER();
                    mDistRoute.Connection = mConnection;
                    mDistRoute.Transaction = mTransaction;
                    mDistRoute.CUSTOMER_ID = long.Parse(ParametersArr[0].ToString());
                    mDistRoute.DISTRIBUTOR_ID  = p_DistributorId;
                    mDistRoute.CUSTOMER_CODE = ParametersArr[1].ToString();
                    mDistRoute.CUSTOMER_NAME = ParametersArr[2].ToString();
                    mDistRoute.ADDRESS = ParametersArr[3].ToString();
                    mDistRoute.CONTACT_PERSON = ParametersArr[4].ToString();
                    mDistRoute.CONTACT_NUMBER  = ParametersArr[5].ToString();
                    mDistRoute.IS_GST_REGISTERED = false;
                    mDistRoute.GST_NUMBER = null;
                    mDistRoute.IS_ACTIVE = true;
                    mDistRoute.REGDATE = System.DateTime.Now;
                    mDistRoute.TIME_STAMP = System.DateTime.Now;
                    mDistRoute.LASTUPDATE_DATE = System.DateTime.Now;
                    mDistRoute.TOWN_ID = p_TownId;
                    mDistRoute.AREA_ID = int.Parse(ParametersArr[6].ToString());
                    mDistRoute.ROUTE_ID = int.Parse(ParametersArr[7].ToString());
                    mDistRoute.CHANNEL_TYPE_ID = int.Parse(ParametersArr[8].ToString());
                    mDistRoute.BUSINESS_TYPE_ID = int.Parse(ParametersArr[9].ToString());
                    mDistRoute.PROMOTION_CLASS = int.Parse(ParametersArr[10].ToString());  
                    mDistRoute.ExecuteQuery();
               }
               mTransaction.Commit();  
               return true;
               

            }

            catch (Exception excp)
            {
                mTransaction.Rollback();  
                ReadSourceFile.Close();
                mConnection.Close();
                ExceptionPublisher.PublishException(excp);
                return false;

            }
            finally
            {
                ReadSourceFile.Close();
                mConnection.Close();

            }

        }
        public bool ImportCustomerAssignment(int p_TownId, int p_DistributorId, string pFileName,int p_Principal_Id)
        {
            IDbConnection mConnection = null;
            FileStream Sourcefile = null;
            StreamReader ReadSourceFile = null;
            IDbTransaction mTransaction = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                Sourcefile = new FileStream(pFileName, FileMode.Open);
                ReadSourceFile = new StreamReader(Sourcefile);
                string FileContents = "";
                while ((FileContents = ReadSourceFile.ReadLine()) != null)
                {

                    string[] ParametersArr = FileContents.Split(Constants.File_Delimiter);
                    spSelectCUSTOMER mCustomer = new spSelectCUSTOMER();
                    mCustomer.Connection = mConnection;
                    mCustomer.Transaction = mTransaction;  
                    mCustomer.CUSTOMER_CODE = ParametersArr[0].ToString();
                    mCustomer.IS_ACTIVE = true;
                    DataTable dt = mCustomer.ExecuteTable();
                    if (dt.Rows.Count > 0)
                    {
                        spInsertCUSTOMER_PRINCIPAL_CREDITLIMIT mCustomerAssign = new spInsertCUSTOMER_PRINCIPAL_CREDITLIMIT();
                        mCustomerAssign.Connection = mConnection;
                        mCustomerAssign.Transaction = mTransaction;  
                        mCustomerAssign.CUSTOMER_ID = long.Parse(dt.Rows[0]["Customer_Id"].ToString());
                        mCustomerAssign.DISTRIBUTOR_ID = p_DistributorId;
                        mCustomerAssign.PRINCIPAL_ID = p_Principal_Id;
                        mCustomerAssign.TIME_STAMP = DateTime.Now;
                        mCustomerAssign.ExecuteQuery();  

                    }

                    
                }
                mTransaction.Commit();  
                return true;

            }

            catch (Exception excp)
            {
                mTransaction.Rollback();
                ReadSourceFile.Close();
                mConnection.Close();
                ExceptionPublisher.PublishException(excp);
                return false;

            }
            finally
            {
                ReadSourceFile.Close();
                mConnection.Close();

            }

        }
        public bool ImportSKUPrices(int p_DistributorId, string pFileName, int p_Principal_Id)
        {
            IDbConnection mConnection = null;
            FileStream Sourcefile = null;
            StreamReader ReadSourceFile = null;
            IDbTransaction mTransaction = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                Sourcefile = new FileStream(pFileName, FileMode.Open);
                ReadSourceFile = new StreamReader(Sourcefile);
                string FileContents = "";
                while ((FileContents = ReadSourceFile.ReadLine()) != null)
                {

                    string[] ParametersArr = FileContents.Split(Constants.File_Delimiter);
                    spSelectSKUS mSKUS = new spSelectSKUS();
                    mSKUS.Connection = mConnection;
                    mSKUS.Transaction = mTransaction;
                    mSKUS.SKU_CODE = ParametersArr[0].ToString();
                    mSKUS.ISACTIVE  = true;
                    DataTable dt = mSKUS.ExecuteTable();
                    if (dt.Rows.Count > 0)
                    {
                        UspProcessSKU_Prices mSKUPrice = new UspProcessSKU_Prices();
                        mSKUPrice.Connection = mConnection;
                        mSKUPrice.Transaction = mTransaction;
                        mSKUPrice.SKU_ID  = int.Parse(dt.Rows[0]["SKU_Id"].ToString());
                        mSKUPrice.DISTRIBUTOR_ID = p_DistributorId;
                        mSKUPrice.DISTRIBUTOR_PRICE = decimal.Parse(ParametersArr[1].ToString());
                        mSKUPrice.TRADE_PRICE = decimal.Parse(ParametersArr[2].ToString());
                        mSKUPrice.RETAIL_PRICE = decimal.Parse(ParametersArr[3].ToString());
                        mSKUPrice.DISTRIBUTOR_DISCOUNT  = decimal.Parse(ParametersArr[4].ToString());
                        mSKUPrice.TAX_PRICE = decimal.Parse(ParametersArr[5].ToString());
                        mSKUPrice.SED_TAX = decimal.Parse(ParametersArr[6].ToString());
                        mSKUPrice.DATE_EFFECTED = DateTime.Parse(ParametersArr[7].ToString());
                        mSKUPrice.LASTUPDATE_DATE = DateTime.Now;
                        mSKUPrice.TIME_STAMP = DateTime.Now;   
                        mSKUPrice.ExecuteQuery();

                    }


                }
                mTransaction.Commit();
                return true;

            }

            catch (Exception excp)
            {
                mTransaction.Rollback();
                ReadSourceFile.Close();
                mConnection.Close();
                ExceptionPublisher.PublishException(excp);
                return false;

            }
            finally
            {
                ReadSourceFile.Close();
                mConnection.Close();

            }

        }

        public bool InsertCustomerSecurity(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, DateTime p_DOCUMENT_DATE, long p_AREA_ID, long p_CUSTOMER_ID, int p_DELIVERYMAN_ID, int p_NoOfBottles, decimal p_SECURITY_AMOUNT, int p_SKU_ID, string p_REMARKS, int p_TYPE_ID, int p_USER_ID, decimal p_RATE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspInsertAdvanceSecurity mCustData = new uspInsertAdvanceSecurity();

                mCustData.Connection = mConnection;

                mCustData.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mCustData.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mCustData.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mCustData.AREA_ID = p_AREA_ID;
                mCustData.CUSTOMER_ID = p_CUSTOMER_ID;
                mCustData.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mCustData.NoOfBottles = p_NoOfBottles;
                mCustData.SECURITY_AMOUNT = p_SECURITY_AMOUNT;
                mCustData.SKU_ID = p_SKU_ID;
                mCustData.REMARKS = p_REMARKS;
                mCustData.TYPE_ID = p_TYPE_ID;
                mCustData.USER_ID = p_USER_ID;
                mCustData.RATE = p_RATE;
               
                mCustData.ExecuteQuery();
                return true;
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
        public bool InsertCustomerSecurity(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, DateTime p_DOCUMENT_DATE, long p_AREA_ID, long p_CUSTOMER_ID, int p_DELIVERYMAN_ID, int p_NoOfBottles, decimal p_SECURITY_AMOUNT, int p_SKU_ID, string p_REMARKS, int p_TYPE_ID, int p_USER_ID, decimal p_RATE, bool p_Is_permanent, string p_DocumentNo)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspInsertAdvanceSecurity mCustData = new uspInsertAdvanceSecurity();

                mCustData.Connection = mConnection;

                mCustData.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mCustData.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mCustData.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mCustData.AREA_ID = p_AREA_ID;
                mCustData.CUSTOMER_ID = p_CUSTOMER_ID;
                mCustData.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mCustData.NoOfBottles = p_NoOfBottles;
                mCustData.SECURITY_AMOUNT = p_SECURITY_AMOUNT;
                mCustData.SKU_ID = p_SKU_ID;
                mCustData.REMARKS = p_REMARKS;
                mCustData.TYPE_ID = p_TYPE_ID;
                mCustData.USER_ID = p_USER_ID;
                mCustData.RATE = p_RATE;
                mCustData.IS_PERMANENT = p_Is_permanent;
                mCustData.DOCUMENT_NO = p_DocumentNo;
                mCustData.ExecuteQuery();
                return true;
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

        public DataTable GetCustomerSecurity(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, DateTime p_DOCUMENT_DATE, long p_AREA_ID, long p_CUSTOMER_ID, int p_DELIVERYMAN_ID, int p_TYPE_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                uspGetAdvanceSecurity mspSelectCustomer = new uspGetAdvanceSecurity();
                mspSelectCustomer.Connection = mConnection;

                mspSelectCustomer.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mspSelectCustomer.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mspSelectCustomer.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mspSelectCustomer.AREA_ID = p_AREA_ID;
                mspSelectCustomer.CUSTOMER_ID = p_CUSTOMER_ID;
                mspSelectCustomer.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mspSelectCustomer.TYPE_ID = p_TYPE_ID;

                return (mspSelectCustomer.ExecuteTable());
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
        public DataTable GetCustomerSecurity2(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, DateTime p_DOCUMENT_DATE, long p_AREA_ID, long p_CUSTOMER_ID, int p_DELIVERYMAN_ID, int p_TYPE_ID, int p_SKU_ID)
        {
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                uspGetAdvanceSecurity2 mspSelectCustomer = new uspGetAdvanceSecurity2();
                mspSelectCustomer.Connection = mConnection;

                mspSelectCustomer.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mspSelectCustomer.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mspSelectCustomer.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mspSelectCustomer.AREA_ID = p_AREA_ID;
                mspSelectCustomer.CUSTOMER_ID = p_CUSTOMER_ID;
                mspSelectCustomer.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mspSelectCustomer.TYPE_ID = p_TYPE_ID;
                mspSelectCustomer.SKU_ID = p_SKU_ID;

                return (mspSelectCustomer.ExecuteTable());
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

        public bool UpdateCustomerSecurity(long p_CUSTOMER_SECURITY_ID, int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, long p_AREA_ID, long p_CUSTOMER_ID, int p_DELIVERYMAN_ID, int p_NoOfBottles, decimal p_SECURITY_AMOUNT, int p_SKU_ID, string p_REMARKS, int p_TYPE_ID, int p_USER_ID, bool p_IS_ACTIVE, decimal p_RATE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspUpdateAdvanceSecurity mCustData = new uspUpdateAdvanceSecurity();

                mCustData.Connection = mConnection;
                mCustData.CUSTOMER_SECURITY_ID = p_CUSTOMER_SECURITY_ID;
                mCustData.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mCustData.PRINCIPAL_ID = p_PRINCIPAL_ID;                
                mCustData.AREA_ID = p_AREA_ID;
                mCustData.CUSTOMER_ID = p_CUSTOMER_ID;
                mCustData.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mCustData.NoOfBottles = p_NoOfBottles;
                mCustData.SECURITY_AMOUNT = p_SECURITY_AMOUNT;
                mCustData.SKU_ID = p_SKU_ID;
                mCustData.REMARKS = p_REMARKS;
                mCustData.TYPE_ID = p_TYPE_ID;
                mCustData.USER_ID = p_USER_ID;
                mCustData.IS_ACTIVE = p_IS_ACTIVE;
                mCustData.RATE = p_RATE;
               
                mCustData.ExecuteQuery();
                return true;
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
        public bool UpdateCustomerSecurity(long p_CUSTOMER_SECURITY_ID, int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, long p_AREA_ID, long p_CUSTOMER_ID, int p_DELIVERYMAN_ID, int p_NoOfBottles, decimal p_SECURITY_AMOUNT, int p_SKU_ID, string p_REMARKS, int p_TYPE_ID, int p_USER_ID, bool p_IS_ACTIVE, decimal p_RATE, bool p_IS_Permanent, string p_Document_No)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspUpdateAdvanceSecurity mCustData = new uspUpdateAdvanceSecurity();

                mCustData.Connection = mConnection;
                mCustData.CUSTOMER_SECURITY_ID = p_CUSTOMER_SECURITY_ID;
                mCustData.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mCustData.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mCustData.AREA_ID = p_AREA_ID;
                mCustData.CUSTOMER_ID = p_CUSTOMER_ID;
                mCustData.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mCustData.NoOfBottles = p_NoOfBottles;
                mCustData.SECURITY_AMOUNT = p_SECURITY_AMOUNT;
                mCustData.SKU_ID = p_SKU_ID;
                mCustData.REMARKS = p_REMARKS;
                mCustData.TYPE_ID = p_TYPE_ID;
                mCustData.USER_ID = p_USER_ID;
                mCustData.IS_ACTIVE = p_IS_ACTIVE;
                mCustData.RATE = p_RATE;
                mCustData.IS_PERMANENT = p_IS_Permanent;
                mCustData.DOCUMENT_NO = p_Document_No;
                mCustData.ExecuteQuery();
                return true;
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
