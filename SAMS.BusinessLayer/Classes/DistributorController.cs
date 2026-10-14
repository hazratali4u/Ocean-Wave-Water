using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// DistributorController
	/// <author>Rizwan Ansari</author>
	/// <date></date>
	/// </summary>
	public class DistributorController
	{	
		#region Constructors
		public DistributorController()
		{
			//
			// TODO: Add constructor logic here
			//
			 
		}
		#endregion
				
		#region Private Variables
		
		#endregion

		#region public Properties
		
		#endregion
		
		#region public static Methods
		#endregion

		#region Private Methods
		#endregion
		
		#region public Methods


        public DataTable SelectDistributorInfo(int p_Distributor_ID, int p_User_Id, int Companyid)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDistributorInfo mDistributorInfo = new uspSelectDistributorInfo();
				mDistributorInfo.Connection = mConnection;
				mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_ID;
                mDistributorInfo.USER_ID = p_User_Id;
                mDistributorInfo.COMPANY_ID = Companyid;   
                
				DataTable dt = mDistributorInfo.ExecuteTable();
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

        public DataTable SelectDayOf_Weak()
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectDayOfWeak mDistributorInfo = new uspSelectDayOfWeak();
                mDistributorInfo.Connection = mConnection;
                DataTable dt = mDistributorInfo.ExecuteTable();
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


        public DataTable SelectDistributorInfo(int p_Distributor_ID, int p_User_Id, int p_DistributorType, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectDistributorInfo mDistributorInfo = new uspSelectDistributorInfo();
                mDistributorInfo.Connection = mConnection;
                mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_ID;
                mDistributorInfo.USER_ID = p_User_Id;
                mDistributorInfo.DISTRIBUTOR_TYPE = p_DistributorType;
                mDistributorInfo.COMPANY_ID = Companyid;
                DataTable dt = mDistributorInfo.ExecuteTable();
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
		public DataTable SelectDistributorTypeInfo(int  p_DistributorType_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR_TYPE mDistributorType = new spSelectDISTRIBUTOR_TYPE();
				mDistributorType.Connection = mConnection;
				
				mDistributorType.DISTRIBUTOR_TYPE_ID = p_DistributorType_ID;
				DataTable dt = mDistributorType.ExecuteTable();
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
		public DataTable SelectDistributorWithType(int p_Dist_Class_Id, int p_IsDeleted, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, int p_Distributor_Id, string p_Distributor_Code, string p_Distributor_Name, int p_Is_Registered)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTORWITHTYPE  mDistributorInfo = new spSelectDISTRIBUTORWITHTYPE();
				mDistributorInfo.Connection = mConnection;
				
				mDistributorInfo.DIST_CLASS_ID = p_Dist_Class_Id;
				mDistributorInfo.ISDELETED = false ;
				mDistributorInfo.TIME_STAMP = Constants.DateNullValue;
				mDistributorInfo.LASTUPDATE_DATE = Constants.DateNullValue;;
				mDistributorInfo.DIVISION_ID = p_Division_Id;
				mDistributorInfo.USER_ID = p_User_Id;
				mDistributorInfo.REGION_ID = p_Region_Id;
				mDistributorInfo.ZONE_ID = p_Zone_Id;
				mDistributorInfo.SUBZONE_ID = p_SubZone_Id;
				mDistributorInfo.CONTACT_PERSON = p_Contact_Person;
				mDistributorInfo.CONTACT_NUMBER = p_Contact_Number;
				mDistributorInfo.GST_NUMBER = p_Gst_Number;
				mDistributorInfo.PASSWORD = p_Password;
				mDistributorInfo.ADDRESS1 = p_Address1;
				mDistributorInfo.ADDRESS2 = p_Address2;
				mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributorInfo.DISTRIBUTOR_CODE = p_Distributor_Code;
				mDistributorInfo.DISTRIBUTOR_NAME = p_Distributor_Name;
				mDistributorInfo.IP_ADDRESS = null;
				mDistributorInfo.IS_REGISTERED = p_Is_Registered;
                
				DataTable dt = mDistributorInfo.ExecuteTable();
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
        	
		public DataTable SelectDistributor(int p_Dist_Class_Id, int p_IsDeleted, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, int p_Distributor_Id, string p_Distributor_Code, string p_Distributor_Name, int p_Is_Registered)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR mDistributorInfo = new spSelectDISTRIBUTOR();
				mDistributorInfo.Connection = mConnection;
				
				mDistributorInfo.DIST_CLASS_ID = p_Dist_Class_Id;
				mDistributorInfo.ISDELETED = p_IsDeleted ;
				mDistributorInfo.TIME_STAMP = Constants.DateNullValue;
				mDistributorInfo.LASTUPDATE_DATE = Constants.DateNullValue;;
				mDistributorInfo.DIVISION_ID = p_Division_Id;
				mDistributorInfo.USER_ID = p_User_Id;
				mDistributorInfo.REGION_ID = p_Region_Id;
				mDistributorInfo.ZONE_ID = p_Zone_Id;
				mDistributorInfo.CREDIT_LEVEL = Constants.IntNullValue; 
				mDistributorInfo.SUBZONE_ID = p_SubZone_Id;
				mDistributorInfo.CONTACT_PERSON = p_Contact_Person;
				mDistributorInfo.CONTACT_NUMBER = p_Contact_Number;
				mDistributorInfo.GST_NUMBER = p_Gst_Number;
				mDistributorInfo.PASSWORD = p_Password;
				mDistributorInfo.ADDRESS1 = p_Address1;
				mDistributorInfo.ADDRESS2 = p_Address2;
				mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributorInfo.DISTRIBUTOR_CODE = p_Distributor_Code;
				mDistributorInfo.DISTRIBUTOR_NAME = p_Distributor_Name;
				mDistributorInfo.IP_ADDRESS = null;
				mDistributorInfo.CREDIT_LEVEL = Constants.IntNullValue; 
				mDistributorInfo.IS_REGISTERED = p_Is_Registered;
                
				DataTable dt = mDistributorInfo.ExecuteTable();
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
        
		public DataTable SelectDistributor(int p_Dist_Class_Id, int p_IsDeleted, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, int p_Distributor_Id, string p_Distributor_Code, string p_Distributor_Name)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDISTRIBUTOR mDistributorInfo = new uspSelectDISTRIBUTOR();
				mDistributorInfo.Connection = mConnection;
				
				mDistributorInfo.DIST_CLASS_ID = p_Dist_Class_Id;
				mDistributorInfo.ISDELETED = true  ;
				mDistributorInfo.TIME_STAMP = Constants.DateNullValue;
				mDistributorInfo.LASTUPDATE_DATE = Constants.DateNullValue;;
				mDistributorInfo.DIVISION_ID = p_Division_Id;
				mDistributorInfo.USER_ID = p_User_Id;
				mDistributorInfo.REGION_ID = p_Region_Id;
				mDistributorInfo.ZONE_ID = p_Zone_Id;
				mDistributorInfo.SUBZONE_ID = p_SubZone_Id;
				mDistributorInfo.CONTACT_PERSON = p_Contact_Person;
				mDistributorInfo.CONTACT_NUMBER = p_Contact_Number;
				mDistributorInfo.GST_NUMBER = p_Gst_Number;
				mDistributorInfo.PASSWORD = p_Password;
				mDistributorInfo.ADDRESS1 = p_Address1;
				mDistributorInfo.ADDRESS2 = p_Address2;
				mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributorInfo.DISTRIBUTOR_CODE = p_Distributor_Code;
				mDistributorInfo.DISTRIBUTOR_NAME = p_Distributor_Name;
				mDistributorInfo.IP_ADDRESS = null;
				mDistributorInfo.CREDIT_LEVEL = Constants.IntNullValue; 
				mDistributorInfo.IS_REGISTERED = true;
                
				DataTable dt = mDistributorInfo.ExecuteTable();
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

		public DataTable SelectDistributor(int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDISTRIBUTOR mDistributorInfo = new uspSelectDISTRIBUTOR();
				mDistributorInfo.Connection = mConnection;
				mDistributorInfo.DIST_CLASS_ID = Constants.IntNullValue;
				mDistributorInfo.ISDELETED = false;
				mDistributorInfo.TIME_STAMP = Constants.DateNullValue;
				mDistributorInfo.LASTUPDATE_DATE = Constants.DateNullValue;
				mDistributorInfo.DIVISION_ID = Constants.IntNullValue;
				mDistributorInfo.USER_ID = Constants.IntNullValue;
				mDistributorInfo.REGION_ID = Constants.IntNullValue;
				mDistributorInfo.ZONE_ID = Constants.IntNullValue;
				mDistributorInfo.SUBZONE_ID = Constants.IntNullValue;
				mDistributorInfo.CONTACT_PERSON = null;
				mDistributorInfo.CONTACT_NUMBER = null;
				mDistributorInfo.GST_NUMBER = null;
				mDistributorInfo.PASSWORD = null;
				mDistributorInfo.ADDRESS1 = null;
				mDistributorInfo.ADDRESS2 = null;
				mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributorInfo.DISTRIBUTOR_CODE = null;
				mDistributorInfo.DISTRIBUTOR_NAME = null;
				mDistributorInfo.IP_ADDRESS = null;
                //mDistributorInfo.IS_REGISTERED = Constants.IntNullValue;
				DataTable dt = mDistributorInfo.ExecuteTable();
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
        
		public DataTable SelectDistributor(int p_Distributor_Id,int p_distributor_type,int p_Company_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDISTRIBUTOR mDistributorInfo = new uspSelectDISTRIBUTOR();
				mDistributorInfo.Connection = mConnection;
				
				 
				mDistributorInfo.DIST_CLASS_ID = Constants.IntNullValue;
				mDistributorInfo.ISDELETED = false;
				mDistributorInfo.TIME_STAMP = Constants.DateNullValue;
				mDistributorInfo.LASTUPDATE_DATE = Constants.DateNullValue;
				mDistributorInfo.DIVISION_ID = Constants.IntNullValue;
				mDistributorInfo.USER_ID = Constants.IntNullValue;
				mDistributorInfo.REGION_ID = Constants.IntNullValue;
				mDistributorInfo.ZONE_ID = Constants.IntNullValue;
				mDistributorInfo.SUBZONE_ID = p_distributor_type;
				mDistributorInfo.CONTACT_PERSON = null;
				mDistributorInfo.CONTACT_NUMBER = null;
				mDistributorInfo.GST_NUMBER = null;
				mDistributorInfo.PASSWORD = null;
				mDistributorInfo.ADDRESS1 = null;
				mDistributorInfo.ADDRESS2 = null;
				mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributorInfo.DISTRIBUTOR_CODE = null;
				mDistributorInfo.DISTRIBUTOR_NAME = null;
				mDistributorInfo.IP_ADDRESS = null;
				mDistributorInfo.IS_REGISTERED = true;
                mDistributorInfo.COMPANY_ID = p_Company_Id; 
				DataTable dt = mDistributorInfo.ExecuteTable();
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
        
        public string InsertDistributor(int p_Company, int p_Dist_Class_Id, bool p_IsDeleted, DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, string p_Distributor_Code, string p_Distributor_Name, string p_Ip_Address, bool p_Is_Registered, int p_CREDIT_LEVEL, int p_UserId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDISTRIBUTOR mDistributorInfo = new spInsertDISTRIBUTOR();
				mDistributorInfo.Connection = mConnection;
                mDistributorInfo.COMPANY_ID = p_Company;
                mDistributorInfo.USER_ID = p_UserId;   
				mDistributorInfo.DIST_CLASS_ID = p_Dist_Class_Id;
                mDistributorInfo.TIME_STAMP = p_Time_Stamp;
				mDistributorInfo.LASTUPDATE_DATE = p_LastUpdate_Date;
				mDistributorInfo.DIVISION_ID = p_Division_Id;
				mDistributorInfo.USER_ID = p_User_Id;
				mDistributorInfo.REGION_ID = p_Region_Id;
				mDistributorInfo.ZONE_ID = p_Zone_Id;
				mDistributorInfo.SUBZONE_ID = p_SubZone_Id;
				mDistributorInfo.CREDIT_LEVEL = p_CREDIT_LEVEL;
				mDistributorInfo.CONTACT_PERSON = p_Contact_Person;
				mDistributorInfo.CONTACT_NUMBER = p_Contact_Number;
				mDistributorInfo.GST_NUMBER = p_Gst_Number;
				mDistributorInfo.PASSWORD = p_Password;
				mDistributorInfo.ADDRESS1 = p_Address1;
				mDistributorInfo.ADDRESS2 = p_Address2;
				mDistributorInfo.DISTRIBUTOR_CODE = p_Distributor_Code;
				mDistributorInfo.DISTRIBUTOR_NAME = p_Distributor_Name;
                mDistributorInfo.USER_ID = p_UserId;   
				mDistributorInfo.IP_ADDRESS = p_Ip_Address;
                mDistributorInfo.ISDELETED = p_IsDeleted;
                mDistributorInfo.IS_REGISTERED = p_Is_Registered;  
                mDistributorInfo.ExecuteQuery();
				
				return mDistributorInfo.DISTRIBUTOR_ID.ToString();
				
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
	
		public string UpdateDistributor(int p_CompanyId,int p_Dist_Class_Id, bool p_IsDeleted, DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, int p_Distributor_Id, string p_Distributor_Code, string p_Distributor_Name, string p_Ip_Address, bool p_Is_Registered,int p_CREDIT_LEVEL,int p_UserId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateDISTRIBUTOR mDistributorInfo = new spUpdateDISTRIBUTOR();
				mDistributorInfo.Connection = mConnection;
                mDistributorInfo.COMPANY_ID = p_CompanyId; 
				mDistributorInfo.DIST_CLASS_ID = p_Dist_Class_Id;
				mDistributorInfo.TIME_STAMP = p_Time_Stamp;
				mDistributorInfo.LASTUPDATE_DATE = p_LastUpdate_Date;
				mDistributorInfo.DIVISION_ID = p_Division_Id;
				mDistributorInfo.USER_ID = p_User_Id;
				mDistributorInfo.REGION_ID = p_Region_Id;
				mDistributorInfo.ZONE_ID = p_Zone_Id;
				mDistributorInfo.SUBZONE_ID = p_SubZone_Id;
				mDistributorInfo.CREDIT_LEVEL = p_CREDIT_LEVEL;
				mDistributorInfo.CONTACT_PERSON = p_Contact_Person;
				mDistributorInfo.CONTACT_NUMBER = p_Contact_Number;
				mDistributorInfo.GST_NUMBER = p_Gst_Number;
				mDistributorInfo.PASSWORD = p_Password;
				mDistributorInfo.ADDRESS1 = p_Address1;
				mDistributorInfo.ADDRESS2 = p_Address2;
				mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributorInfo.DISTRIBUTOR_CODE = p_Distributor_Code;
				mDistributorInfo.DISTRIBUTOR_NAME = p_Distributor_Name;
				mDistributorInfo.IP_ADDRESS = p_Ip_Address;
                mDistributorInfo.IS_REGISTERED = p_Is_Registered;
                mDistributorInfo.USER_ID = p_UserId;
                mDistributorInfo.ISDELETED = p_IsDeleted;
                mDistributorInfo.ExecuteQuery();
				return "Record Updated.";
				
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
	
		public string DeletedDistributor(int p_Distributor_Id)
		{			
			IDbConnection mConnection = null;
			try
			{
				return "";
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
        		
		public string InsertDistributor_User(bool p_Is_Deleted,bool p_Is_Distributor_Login,bool p_Is_Ppc_Login,bool p_Is_Active,DateTime p_Time_Stamp,DateTime p_Lastupdate_Date,int p_User_Type_Id,long p_Town_Id,int p_C_User_Id,int p_Region_Id,
											 int p_Zone_Id,int p_Subzone_Id,int p_Distributor_Id,int p_Division_Id,int p_Role_Id,string p_Email_Address,string p_Address1,string p_Address2,string p_Login_Id,string p_Password,string p_Fax,
											 string p_Mobile,string p_User_Code,string p_User_Name,string p_Phone,long p_Route_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDISTRIBUTOR_USER mDistributorUser = new spInsertDISTRIBUTOR_USER();
				mDistributorUser.Connection = mConnection;
				
				mDistributorUser.ADDRESS1 = p_Address1;
				mDistributorUser.ADDRESS2 = p_Address2;
				mDistributorUser.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistributorUser.EMAIL = p_Email_Address; 
				mDistributorUser.IS_ACTIVE = p_Is_Active;
				mDistributorUser.LASTUPDATE_DATE = p_Lastupdate_Date;
				mDistributorUser.LOGIN_ID = p_Login_Id;
				mDistributorUser.MOBILE = p_Mobile;
				mDistributorUser.PASSWORD = p_Password;
				mDistributorUser.PHONE = p_Phone;
				mDistributorUser.ROLE_ID = p_Role_Id;
				mDistributorUser.TIME_STAMP = p_Time_Stamp;
                mDistributorUser.USER_CODE = p_User_Code;
				mDistributorUser.USER_NAME = p_User_Name;
				mDistributorUser.USER_TYPE_ID = p_User_Type_Id;
				
				mDistributorUser.ExecuteQuery();
				
				return mDistributorUser.USER_ID.ToString();
				
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
        
		public DataTable SelectDistributor_User(bool p_Is_Deleted,bool p_Is_Active,DateTime p_Time_Stamp,DateTime p_Lastupdate_Date,int p_User_Type_Id,long p_Town_Id,int p_C_User_Id,int p_Region_Id,
												int p_Zone_Id,int p_Subzone_Id,int p_Distributor_Id,int p_Division_Id,int p_Role_Id,string p_Email_Address,string p_Address1,string p_Address2,string p_Login_Id,string p_Password,string p_Fax,
												string p_Mobile,string p_User_Code,string p_User_Name,string p_Phone,int p_User_Id,long p_Route_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR_USER mDistributorUser = new spSelectDISTRIBUTOR_USER();
				mDistributorUser.Connection = mConnection;
				
				mDistributorUser.ADDRESS1 = p_Address1;
				mDistributorUser.ADDRESS2 = p_Address2;
				mDistributorUser.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributorUser.EMAIL = p_Email_Address;
				mDistributorUser.IS_ACTIVE = p_Is_Active;
				mDistributorUser.LASTUPDATE_DATE = p_Lastupdate_Date;
				mDistributorUser.LOGIN_ID = p_Login_Id;
				mDistributorUser.MOBILE = p_Mobile;
				mDistributorUser.PASSWORD = p_Password;
				mDistributorUser.PHONE = p_Phone;
				mDistributorUser.ROLE_ID = p_Role_Id;
				mDistributorUser.TIME_STAMP = p_Time_Stamp;
				mDistributorUser.USER_CODE = p_User_Code;
				mDistributorUser.USER_ID = p_User_Id;
				mDistributorUser.USER_NAME = p_User_Name;
				mDistributorUser.USER_TYPE_ID = p_User_Type_Id;
				
				DataTable dt = new DataTable();
					dt = mDistributorUser.ExecuteTable();
				
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

		public string UpdateSalesForceType(int p_SalesForceId,int p_SalesForceTypeId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspUpdateSALES_FORCE_TYPE mSalesForceType = new uspUpdateSALES_FORCE_TYPE();
				mSalesForceType.Connection = mConnection;
				
				mSalesForceType.SALES_FORCE_ID = p_SalesForceId;
				mSalesForceType.SALES_FORCE_TYPE = p_SalesForceTypeId;		
                
				mSalesForceType.ExecuteQuery();
				
				return "Record Updated";
				
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
        
		public string InsertDistributorUserTerritory(DateTime p_Time_Stamp,DateTime p_Lastupdate_Date,int p_User_Id,int p_Territory_Id,int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDISTRIBUTOR_USER_TERRITORY mDistributorUserTerritory = new spInsertDISTRIBUTOR_USER_TERRITORY();
				mDistributorUserTerritory.Connection = mConnection;
				
				mDistributorUserTerritory.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributorUserTerritory.LASTUPDATE_DATE = p_Lastupdate_Date;
				mDistributorUserTerritory.TERRITORY_ID = p_Territory_Id;
				mDistributorUserTerritory.USER_ID = p_User_Id;
				mDistributorUserTerritory.TIME_STAMP = p_Time_Stamp;
				
                
				mDistributorUserTerritory.ExecuteQuery();
				
				return "Record Inserted";
				
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
        
		public string UpdateDistributor_User(bool p_Is_Ppc_Login,bool p_Is_Distributor_Login,bool p_Is_Active,bool p_Is_Deleted,DateTime p_Time_Stamp,DateTime p_Lastupdate_Date,int p_User_Type_Id,long p_Town_Id,int p_C_User_Id,int p_Region_Id,
											int p_Zone_Id,int p_Subzone_Id,int p_Distributor_Id,int p_Division_Id,int p_Role_Id,string p_Email_Address,string p_Address1,string p_Address2,string p_Login_Id,string p_Password,string p_Fax,
											string p_Mobile,string p_User_Code,string p_User_Name,string p_Phone,int p_User_Id,long p_Route_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateDISTRIBUTOR_USER mDistributorUser = new spUpdateDISTRIBUTOR_USER();
				mDistributorUser.Connection = mConnection;
				
				mDistributorUser.ADDRESS1 = p_Address1;
				mDistributorUser.ADDRESS2 = p_Address2;
				mDistributorUser.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributorUser.EMAIL  = p_Email_Address;
				mDistributorUser.IS_ACTIVE = p_Is_Active;
				mDistributorUser.LASTUPDATE_DATE = p_Lastupdate_Date;
				mDistributorUser.LOGIN_ID = p_Login_Id;
				mDistributorUser.MOBILE = p_Mobile;
				mDistributorUser.PASSWORD = p_Password;
				mDistributorUser.PHONE = p_Phone;
				mDistributorUser.ROLE_ID = p_Role_Id;
				mDistributorUser.TIME_STAMP = p_Time_Stamp;
				mDistributorUser.USER_CODE = p_User_Code;
				mDistributorUser.USER_ID = p_User_Id;
				mDistributorUser.USER_NAME = p_User_Name;
				mDistributorUser.USER_TYPE_ID = p_User_Type_Id;
				
				mDistributorUser.ExecuteQuery();
				
				return p_User_Id.ToString();
				
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
        		
		public DataTable SelectDistributor_User_Territory(DateTime p_Time_Stamp,DateTime p_Lastupdate_Date,int p_User_Id,int p_Territory_Id,int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR_USER_TERRITORY mDistributorUser = new spSelectDISTRIBUTOR_USER_TERRITORY();
				mDistributorUser.Connection = mConnection;
				
				
				mDistributorUser.DISTRIBUTOR_ID=p_Distributor_Id;
				mDistributorUser.LASTUPDATE_DATE=p_Lastupdate_Date;
				mDistributorUser.TERRITORY_ID=p_Territory_Id;
				mDistributorUser.TIME_STAMP=p_Time_Stamp;
				mDistributorUser.USER_ID=p_User_Id;

				DataTable dt = new DataTable();
				dt = mDistributorUser.ExecuteTable();
				
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
        
		public string UpdateDistributor_User_Territory(DateTime p_Time_Stamp,DateTime p_Lastupdate_Date,int p_User_Id,int p_Territory_Id,int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateDISTRIBUTOR_USER_TERRITORY mDistributorUser = new spUpdateDISTRIBUTOR_USER_TERRITORY();
				mDistributorUser.Connection = mConnection;
				
				
				mDistributorUser.DISTRIBUTOR_ID=p_Distributor_Id;
				mDistributorUser.LASTUPDATE_DATE=p_Lastupdate_Date;
				mDistributorUser.TERRITORY_ID=p_Territory_Id;
				mDistributorUser.TIME_STAMP=p_Time_Stamp;
				mDistributorUser.USER_ID=p_User_Id;

				
				mDistributorUser.ExecuteQuery();
				
				return p_User_Id.ToString();
				
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
        
		public DataTable SelectRole_Master(DateTime p_Time_Stamp,DateTime p_Lastupdate_Date,int p_Role_Id,string p_Role_Name,string p_Ip_Address)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectROLE_MASTER mRoleMaster = new spSelectROLE_MASTER();
				mRoleMaster.Connection = mConnection;
				mRoleMaster.LASTUPDATE_DATE=p_Lastupdate_Date;
				mRoleMaster.ROLE_ID=p_Role_Id;
				mRoleMaster.TIME_STAMP=p_Time_Stamp;
				mRoleMaster.ROLE_NAME=p_Role_Name;

				DataTable dt = new DataTable();
				dt = mRoleMaster.ExecuteTable();
				
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
        
		public DataTable SelectUser_Role_Info(int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectUserRoleInfo mUserRoleInfo = new uspSelectUserRoleInfo();
				mUserRoleInfo.Connection = mConnection;
				
				mUserRoleInfo.DISTRIBUTOR_ID=p_Distributor_Id;
				

				DataTable dt = new DataTable();
				dt = mUserRoleInfo.ExecuteTable();
				
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
        
		public string DeleteDistributor_User(int p_Distributor_Id,int p_User_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spDeleteDISTRIBUTOR_USER mDistUser = new spDeleteDISTRIBUTOR_USER();
				mDistUser.Connection = mConnection;
				
				mDistUser.DISTRIBUTOR_ID=p_Distributor_Id;
				mDistUser.USER_ID=p_User_Id;

				mDistUser.ExecuteQuery();
				
				return p_User_Id.ToString();
				
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

		public DataTable SelectDTDistributor(int p_Dist_Class_Id, int p_IsDeleted, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, int p_Distributor_Id, string p_Distributor_Code, string p_Distributor_Name, string p_Ip_Address)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDISTRIBUTOR mDistributorInfo = new uspSelectDISTRIBUTOR();
				mDistributorInfo.Connection = mConnection;
				
				mDistributorInfo.DIST_CLASS_ID = p_Dist_Class_Id;
				//mDistributorInfo.ISDELETED = p_IsDeleted ;
				mDistributorInfo.TIME_STAMP = Constants.DateNullValue;
				mDistributorInfo.LASTUPDATE_DATE = Constants.DateNullValue;;
				mDistributorInfo.DIVISION_ID = p_Division_Id;
				mDistributorInfo.USER_ID = p_User_Id;
				mDistributorInfo.REGION_ID = p_Region_Id;
				mDistributorInfo.ZONE_ID = p_Zone_Id;
				mDistributorInfo.SUBZONE_ID = p_SubZone_Id;
				mDistributorInfo.CONTACT_PERSON = p_Contact_Person;
				mDistributorInfo.CONTACT_NUMBER = p_Contact_Number;
				mDistributorInfo.GST_NUMBER = p_Gst_Number;
				mDistributorInfo.PASSWORD = p_Password;
				mDistributorInfo.ADDRESS1 = p_Address1;
				mDistributorInfo.ADDRESS2 = p_Address2;
				mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributorInfo.DISTRIBUTOR_CODE = p_Distributor_Code;
				mDistributorInfo.DISTRIBUTOR_NAME = p_Distributor_Name;
				mDistributorInfo.IP_ADDRESS = p_Ip_Address;
				//mDistributorInfo.IS_REGISTERED = Constants.IntNullValue;
                mDistributorInfo.CREDIT_LEVEL = Constants.IntNullValue;

				DataTable dt = mDistributorInfo.ExecuteTable();
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
        
		public static DataTable SelectDistributorCode ()
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDistributor_Code mspDistCode = new uspSelectDistributor_Code();
				mspDistCode.Connection = mConnection;
				DataTable dt = mspDistCode.ExecuteTable();
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

        public static DataTable SelectTranspoter()
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectTRANSPOTER mTranspoter = new spSelectTRANSPOTER();
                mTranspoter.Connection = mConnection;
                DataTable dt = mTranspoter.ExecuteTable();
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
		public static DataTable SelectDistributorCode( string p_Address1,string p_Address2,string p_ContactNumber , string p_ContactPerson ,int p_Distributor_Class_Id,string p_Distributor_Code, int p_Distributor_Id, string p_Distributor_Name,int p_Division_Id, string p_gst_Number,string p_ip_Address , int p_Is_Registered , int p_IsDeleted , DateTime p_LastUpdateDate, string p_password,  int p_Region_Id  , int p_SubZoneId , DateTime p_time_Stamp , int p_User_id , int p_ZoneId    )
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDistributor_Code mspDistCode = new uspSelectDistributor_Code();
				mspDistCode.Connection = mConnection;
				mspDistCode.ADDRESS1 = p_Address1;
				mspDistCode.ADDRESS2 = p_Address2;
				mspDistCode.CONTACT_NUMBER = p_ContactNumber;
				mspDistCode.CONTACT_PERSON = p_ContactPerson;
				mspDistCode.DIST_CLASS_ID = p_Distributor_Class_Id ;
				mspDistCode.DISTRIBUTOR_CODE = p_Distributor_Code;
				mspDistCode.DISTRIBUTOR_ID = p_Distributor_Id;
				mspDistCode.DISTRIBUTOR_NAME = p_Distributor_Name;
				mspDistCode.DIVISION_ID = p_Division_Id;
				mspDistCode.GST_NUMBER = p_gst_Number;
				mspDistCode.IP_ADDRESS = p_ip_Address;
				mspDistCode.ISDELETED = p_IsDeleted;
				mspDistCode.LASTUPDATE_DATE = p_LastUpdateDate;
				mspDistCode.PASSWORD = p_password;
				mspDistCode.REGION_ID = p_Region_Id;
				mspDistCode.SUBZONE_ID = p_SubZoneId ; 
				mspDistCode.TIME_STAMP = p_time_Stamp;
				mspDistCode.USER_ID = p_User_id;
				mspDistCode.ZONE_ID =  p_ZoneId;
				mspDistCode.IS_REGISTERED = p_Is_Registered ;
			
				DataTable dt   =  mspDistCode.ExecuteTable();
				
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
		public DataTable InsertDTDistributor(int p_Dist_Class_Id, bool p_IsDeleted, int p_Division_Id, int p_User_Id, int p_Region_Id, int p_Zone_Id, int p_SubZone_Id, string p_Contact_Person, string p_Contact_Number, string p_Gst_Number, string p_Password, string p_Address1, string p_Address2, int p_Distributor_Id, string p_Distributor_Code, string p_Distributor_Name, string p_Ip_Address, bool p_Is_Registered)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDTDISTRIBUTOR mDistributorInfo = new spInsertDTDISTRIBUTOR();
				mDistributorInfo.Connection = mConnection;
				
				mDistributorInfo.DIST_CLASS_ID = p_Dist_Class_Id;
				mDistributorInfo.ISDELETED = p_IsDeleted ;
				mDistributorInfo.TIME_STAMP = Constants.DateNullValue;
				mDistributorInfo.LASTUPDATE_DATE = Constants.DateNullValue;;
				mDistributorInfo.DIVISION_ID = p_Division_Id;
				mDistributorInfo.USER_ID = p_User_Id;
				mDistributorInfo.REGION_ID = p_Region_Id;
				mDistributorInfo.ZONE_ID = p_Zone_Id;
				mDistributorInfo.SUBZONE_ID = p_SubZone_Id;
				mDistributorInfo.CONTACT_PERSON = p_Contact_Person;
				mDistributorInfo.CONTACT_NUMBER = p_Contact_Number;
				mDistributorInfo.GST_NUMBER = p_Gst_Number;
				mDistributorInfo.PASSWORD = p_Password;
				mDistributorInfo.ADDRESS1 = p_Address1;
				mDistributorInfo.ADDRESS2 = p_Address2;
				mDistributorInfo.DISTRIBUTOR_ID = p_Distributor_Id;
				mDistributorInfo.DISTRIBUTOR_CODE = p_Distributor_Code;
				mDistributorInfo.DISTRIBUTOR_NAME = p_Distributor_Name;
				mDistributorInfo.IP_ADDRESS = p_Ip_Address;
				mDistributorInfo.IS_REGISTERED = p_Is_Registered;
                
				DataTable dt = mDistributorInfo.ExecuteTable();
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
		
	    public int GetDist_ID(string p_Distributor_Code)
		{
			int Dist_Id=0;
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDISTRIBUTOR mDistributorInfo = new uspSelectDISTRIBUTOR();
				mDistributorInfo.Connection = mConnection;
				
				mDistributorInfo.DIST_CLASS_ID = Constants.IntNullValue;
				//mDistributorInfo.ISDELETED = 0 ;
				mDistributorInfo.TIME_STAMP = Constants.DateNullValue;
				mDistributorInfo.LASTUPDATE_DATE = Constants.DateNullValue;;
				mDistributorInfo.DIVISION_ID = Constants.IntNullValue;
				mDistributorInfo.USER_ID = Constants.IntNullValue;
				mDistributorInfo.REGION_ID = Constants.IntNullValue;
				mDistributorInfo.ZONE_ID = Constants.IntNullValue;
				mDistributorInfo.SUBZONE_ID = Constants.IntNullValue;
				mDistributorInfo.CONTACT_PERSON = null;
				mDistributorInfo.CONTACT_NUMBER = null;
				mDistributorInfo.GST_NUMBER = null;
				mDistributorInfo.PASSWORD = null;
				mDistributorInfo.ADDRESS1 = null;
				mDistributorInfo.ADDRESS2 = null;
				mDistributorInfo.DISTRIBUTOR_ID = Constants.IntNullValue;
				mDistributorInfo.DISTRIBUTOR_CODE = p_Distributor_Code;
				mDistributorInfo.DISTRIBUTOR_NAME = null;
				mDistributorInfo.IP_ADDRESS = null;
				//mDistributorInfo.IS_REGISTERED = Constants.IntNullValue; 
                
				DataTable dt = mDistributorInfo.ExecuteTable();
				if(dt.Rows.Count>0)
					Dist_Id= int.Parse(dt.Rows[0]["Distributor_ID"].ToString());
				return Dist_Id;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return 0;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}
        
		/// <summary>
		///  using USP to get Distributor ID .... to generate Distributor File
		/// </summary>
		/// <param name="DistributorCode"></param>
		/// <returns></returns>
		public static int GetDistributorID (string DistributorCode)
		{
			int Dist_Id=0;
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDistributor_ID mspDistID = new uspSelectDistributor_ID();
				mspDistID.Connection = mConnection;
				mspDistID.DISTRIBUTOR_CODE = DistributorCode;
                
				DataTable dt = mspDistID.ExecuteTable();
				if(dt.Rows.Count>0)
					Dist_Id= int.Parse(dt.Rows[0][0].ToString());
				return Dist_Id;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return 0;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		}
        		
		public string InsertDistributorUserCompany(int p_Distributor_Id,int p_SALESFORCE_TYPE,int p_SALESFORCE_ID,int
			p_COMPANY_ID,DateTime p_TIME_STAMP,bool p_IS_ACTIVE)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertSALESFORCE_COMPANY mSaleForceCompany = new spInsertSALESFORCE_COMPANY();

				mSaleForceCompany.Connection = mConnection;
				
				mSaleForceCompany.DISTRIBUTOR_ID = p_Distributor_Id;
				mSaleForceCompany.SALESFORCE_TYPE = p_SALESFORCE_TYPE;
				mSaleForceCompany.SALESFORCE_ID = p_SALESFORCE_ID;
				mSaleForceCompany.COMPANY_ID = p_COMPANY_ID;
				mSaleForceCompany.TIME_STAMP = p_TIME_STAMP;
				mSaleForceCompany.IS_ACTIVE = p_IS_ACTIVE;
             	mSaleForceCompany.ExecuteQuery();
				
				return "Record Inserted";
				
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
        
		public DataTable SelectDistributorUserCompany(int p_type,int p_Distributor_Id,int p_SALESFORCE_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSALESFORCE_COMPANY mSaleForceCompany = new spSelectSALESFORCE_COMPANY();

				mSaleForceCompany.Connection = mConnection;
				mSaleForceCompany.type = p_type;
				mSaleForceCompany.DISTRIBUTOR_ID = p_Distributor_Id;
				mSaleForceCompany.SALESFORCE_ID = p_SALESFORCE_ID;
				
				DataTable dt = mSaleForceCompany.ExecuteTable();
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

		public DataTable  GetDistributors( int p_distributorType, int p_RegionId, int p_ZoneId)
		{
			DataTable dt = new DataTable();

			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				uspGetDistributor ObjDistributor   = new uspGetDistributor();
                ObjDistributor.Connection = mConnection;
                ObjDistributor.DistributorType = p_distributorType;
                ObjDistributor.RegionId = p_RegionId;
                ObjDistributor.ZoneId = p_ZoneId;
                dt =ObjDistributor.ExecuteTable();
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
		public DataTable  GetDistributors( string p_distributorType, int p_RegionId, int p_ZoneId)
		{
			DataTable dt = new DataTable();

			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				uspGetDistributor01 ObjDistributor   = new uspGetDistributor01();
				ObjDistributor.Connection = mConnection;
				ObjDistributor.DistributorType = p_distributorType;
				ObjDistributor.RegionId = p_RegionId;
				ObjDistributor.ZoneId = p_ZoneId;
				dt =ObjDistributor.ExecuteTable();
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

		public DataTable  GetDistributorsTown( int p_distributorType, int p_RegionId, int p_TownId)
		{
			DataTable dt = new DataTable();

			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				uspGetDistributorTwonWise  ObjDistributor   = new uspGetDistributorTwonWise();
				ObjDistributor.Connection = mConnection;
				ObjDistributor.DistributorType = p_distributorType;
				ObjDistributor.RegionId = p_RegionId;
				ObjDistributor.ZoneId = p_TownId;
				dt =ObjDistributor.ExecuteTable();
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
        
        public DataTable getAssignedDistributor(int p_USER_ID)
        {
            DataTable dt = new DataTable();

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspSelectDistributorData obj = new UspSelectDistributorData();
                obj.Connection = mConnection;
                obj.USER_ID = p_USER_ID;
                dt = obj.ExecuteTable();
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

        public DataTable MaxDayClose(int p_Distributor_ID)
        {
            DataTable dt = new DataTable();

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectMaxDayCloseDistributor obj = new UspSelectMaxDayCloseDistributor();
                obj.Connection = mConnection;
                obj.DISTRIBUTOR_ID = p_Distributor_ID;
                dt = obj.ExecuteTable();
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

        public DataTable GetUserRole(int p_UserID)
        {
            DataTable dt = new DataTable();

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectSAMS_USER obj = new spSelectSAMS_USER();
                obj.Connection = mConnection;
                obj.USER_ID = p_UserID;
                dt = obj.ExecuteTable();
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

        /// <summary>
        /// Gets Menu Hierarchy For Bread Crumb
        /// </summary>
        /// <param name="p_MODULE_ID">ModuleID</param>
        /// <returns>Menu Hierarchy as Datatable</returns>
        public DataTable GetBreadCrumb(int p_MODULE_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spGetBreadCrumb mBreadCrumb = new spGetBreadCrumb();
                mBreadCrumb.Connection = mConnection;


                mBreadCrumb.MODULE_ID = p_MODULE_ID;

                DataTable dt = mBreadCrumb.ExecuteTable();
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

        public DataTable GetLicenseData()
        {
            DataTable dt = new DataTable();

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                uspGetLicenseData obj = new uspGetLicenseData();
                obj.Connection = mConnection;                
                dt = obj.ExecuteTable();
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

        public string InsertLicense(int p_DAYS, string p_LICENSE, DateTime p_TRANSACTION_DATE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspInsertLicense mLicense = new uspInsertLicense();
                mLicense.Connection = mConnection;
                mLicense.DAYS = p_DAYS;
                mLicense.LICENSE = p_LICENSE;
                mLicense.TRANSACTION_DATE = p_TRANSACTION_DATE;

                mLicense.ExecuteQuery();

                return "Record Inserted";

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

		#endregion		

	}
}
