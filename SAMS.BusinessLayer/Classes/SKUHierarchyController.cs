using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// HierarchyController
	/// <author></author>
	/// <date>06-07-2007</date>
	/// </summary>
	public class SkuHierarchyController
	{
		
		#region Contructors
		public SkuHierarchyController()
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


		#region Public Method

        public DataTable SelectSkuHierarchy(int p_Sku_Type_Id, int p_Sku_Hie_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, bool p_Is_Active, int Companyid)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_HIERARCHY mSkuHierarchy = new spSelectSKU_HIERARCHY();
				mSkuHierarchy.Connection = mConnection;
                
				mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;
				mSkuHierarchy.SKU_HIE_ID = p_Sku_Hie_Id;
				mSkuHierarchy.PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id;
				mSkuHierarchy.SKU_HIE_CODE = p_Sku_Hie_Code;
				mSkuHierarchy.SKU_HIE_NAME = p_Sku_Hie_Name;
				mSkuHierarchy.TIME_STAMP = Constants.DateNullValue ;
				mSkuHierarchy.LASTUPDATE_DATE = Constants .DateNullValue ;
				mSkuHierarchy.IP_ADDRESS = null ;
				mSkuHierarchy.IS_ACTIVE = p_Is_Active;
                mSkuHierarchy.COMPANY_ID = Companyid;   
				

				DataTable dt = mSkuHierarchy.ExecuteTable();
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


        public DataTable SelectSkuHierarchy(int p_Sku_Type_Hie_Id, int Companyid)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_HIERARCHY mSkuHierarchy = new spSelectSKU_HIERARCHY();
				mSkuHierarchy.Connection = mConnection;
                mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Hie_Id;
                mSkuHierarchy.COMPANY_ID  = Companyid;   
				DataTable dt = mSkuHierarchy.ExecuteTable();
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


        public DataTable SelectSkuHierarchy(int p_Sku_Type_Id, int p_Parent_Sku_Hie_Id, int Companyid)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_HIERARCHY mSkuHierarchy = new spSelectSKU_HIERARCHY();
				mSkuHierarchy.Connection = mConnection;
                
				mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;
				mSkuHierarchy.PARENT_SKU_HIE_ID=p_Parent_Sku_Hie_Id;
                mSkuHierarchy.COMPANY_ID = Companyid;    
				
				

				DataTable dt = mSkuHierarchy.ExecuteTable();
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


		public DataTable SelectDTSkuHierarchy(int p_Sku_Type_Id,int p_Parent_Sku_Hie_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_HIERARCHY mSkuHierarchy = new spSelectSKU_HIERARCHY();
				mSkuHierarchy.Connection = mConnection;
                
				mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;
				mSkuHierarchy.PARENT_SKU_HIE_ID=p_Parent_Sku_Hie_Id;
				
				

				DataTable dt = mSkuHierarchy.ExecuteTable();
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

		
		public DataTable SelectSkuHierarchyView(int p_type,int CompanyId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				UspSelectView_SKUHIERARCHY mSkuHierarchyInfo = new UspSelectView_SKUHIERARCHY();
				mSkuHierarchyInfo.Connection = mConnection;
                mSkuHierarchyInfo.MCompany_id = CompanyId;   
				mSkuHierarchyInfo.type = p_type;
				
				DataTable dt = mSkuHierarchyInfo.ExecuteTable();
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

        public DataTable SelectSkuHierarchyInfo(int p_Sku_Hie_Id, int p_Sku_Type_Id, int Companyid)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectSKU_HIERARCHY_INFO mSkuHierarchyInfo = new uspSelectSKU_HIERARCHY_INFO();
				mSkuHierarchyInfo.Connection = mConnection;
                
				mSkuHierarchyInfo.SKU_HIE_ID = p_Sku_Hie_Id;
				mSkuHierarchyInfo.SKU_HIE_TYPE_ID = p_Sku_Type_Id ;
                mSkuHierarchyInfo.COMPANY_ID = Companyid;   

				DataTable dt = mSkuHierarchyInfo.ExecuteTable();
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


        public DataTable SelectSkuHierarchy(string p_Sku_Hie_Id, int p_Sku_Type_Id, int Companyid)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_HIERARCHY mSkuHierarchy = new spSelectSKU_HIERARCHY();
				mSkuHierarchy.Connection = mConnection;
                
				mSkuHierarchy.SKU_HIE_TYPE_ID=p_Sku_Type_Id;
				mSkuHierarchy.SKU_HIE_ID=Int32.Parse(p_Sku_Hie_Id);
                mSkuHierarchy.COMPANY_ID = Companyid;   
				
				

				DataTable dt = mSkuHierarchy.ExecuteTable();

				return dt;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
		}

        public int GetHieID(string p_Sku_Hie_Code, int Companyid)
		{
			int HieID=0;
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_HIERARCHY mSkuHierarchy = new spSelectSKU_HIERARCHY();
				mSkuHierarchy.Connection = mConnection;
            	mSkuHierarchy.SKU_HIE_TYPE_ID = Constants.IntNullValue;
				mSkuHierarchy.SKU_HIE_ID = Constants.IntNullValue;
				mSkuHierarchy.PARENT_SKU_HIE_ID = Constants.IntNullValue;
				mSkuHierarchy.SKU_HIE_CODE = p_Sku_Hie_Code;
				mSkuHierarchy.SKU_HIE_NAME = null;
				mSkuHierarchy.TIME_STAMP = Constants.DateNullValue ;
				mSkuHierarchy.LASTUPDATE_DATE = Constants .DateNullValue ;
				mSkuHierarchy.IP_ADDRESS = null ;
                mSkuHierarchy.COMPANY_ID = Companyid;   
				DataTable dt = mSkuHierarchy.ExecuteTable();
				if(dt.Rows.Count>0)
					 HieID = int.Parse(dt.Rows[0]["SKU_HIE_ID"].ToString());
				
				return HieID;
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


        public string InsertHierarchy(int p_Sku_Type_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, string p_Ip_Address, bool p_Is_Active, int Companyid,bool p_IsManualDiscount)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertSKU_HIERARCHY  mSkuHierarchy = new spInsertSKU_HIERARCHY ();
				mSkuHierarchy.Connection = mConnection;

				mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;
				
				mSkuHierarchy.PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id;
				mSkuHierarchy.SKU_HIE_CODE = p_Sku_Hie_Code;
				mSkuHierarchy.SKU_HIE_NAME = p_Sku_Hie_Name;
				mSkuHierarchy.TIME_STAMP = System.DateTime.Now; ;
				mSkuHierarchy.LASTUPDATE_DATE = System.DateTime.Now;;
				mSkuHierarchy.IP_ADDRESS = p_Ip_Address ;
				mSkuHierarchy.IS_ACTIVE = p_Is_Active;
                mSkuHierarchy.COMPANY_ID = Companyid;
                mSkuHierarchy.IS_MANUALDISCOUNT = p_IsManualDiscount;  
				mSkuHierarchy.ExecuteQuery();
				return "Record Inserted";

			}			
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		}
        public string InsertHierarchy(int p_Sku_Type_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, string p_Ip_Address, bool p_Is_Active, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertSKU_HIERARCHY mSkuHierarchy = new spInsertSKU_HIERARCHY();
                mSkuHierarchy.Connection = mConnection;

                mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;

                mSkuHierarchy.PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id;
                mSkuHierarchy.SKU_HIE_CODE = p_Sku_Hie_Code;
                mSkuHierarchy.SKU_HIE_NAME = p_Sku_Hie_Name;
                mSkuHierarchy.TIME_STAMP = System.DateTime.Now; ;
                mSkuHierarchy.LASTUPDATE_DATE = System.DateTime.Now; ;
                mSkuHierarchy.IP_ADDRESS = p_Ip_Address;
                mSkuHierarchy.IS_ACTIVE = p_Is_Active;
                mSkuHierarchy.COMPANY_ID = Companyid;
                mSkuHierarchy.IS_MANUALDISCOUNT = false;
                mSkuHierarchy.ExecuteQuery();
                return "Record Inserted";

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
        public string UpdateHierarchy(int p_Sku_Type_Id, int p_Sku_Hie_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, string p_Ip_Address, bool p_Is_Active, int Companyid,bool p_IsManualDiscount)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateSKU_HIERARCHY  mSkuHierarchy = new spUpdateSKU_HIERARCHY ();
				mSkuHierarchy.Connection = mConnection;
				
				mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;
				mSkuHierarchy.SKU_HIE_ID = p_Sku_Hie_Id;
				mSkuHierarchy.PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id;
				mSkuHierarchy.SKU_HIE_CODE = p_Sku_Hie_Code;
				mSkuHierarchy.SKU_HIE_NAME = p_Sku_Hie_Name;	
				mSkuHierarchy.TIME_STAMP = System.DateTime.Now; ;
				mSkuHierarchy.LASTUPDATE_DATE = System.DateTime.Now;;
				mSkuHierarchy.IP_ADDRESS = p_Ip_Address  ;
				mSkuHierarchy.IS_ACTIVE = p_Is_Active;
                mSkuHierarchy.COMPANY_ID = Companyid;
                mSkuHierarchy.IS_MANUALDISCOUNT = p_IsManualDiscount;  
                mSkuHierarchy.ExecuteQuery();
				return "Record Updated";

			}			
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		}
        public string UpdateHierarchy(int p_Sku_Type_Id, int p_Sku_Hie_Id, int p_Parent_Sku_Hie_Id, string p_Sku_Hie_Code, string p_Sku_Hie_Name, string p_Ip_Address, bool p_Is_Active, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateSKU_HIERARCHY mSkuHierarchy = new spUpdateSKU_HIERARCHY();
                mSkuHierarchy.Connection = mConnection;

                mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;
                mSkuHierarchy.SKU_HIE_ID = p_Sku_Hie_Id;
                mSkuHierarchy.PARENT_SKU_HIE_ID = p_Parent_Sku_Hie_Id;
                mSkuHierarchy.SKU_HIE_CODE = p_Sku_Hie_Code;
                mSkuHierarchy.SKU_HIE_NAME = p_Sku_Hie_Name;
                mSkuHierarchy.TIME_STAMP = System.DateTime.Now; ;
                mSkuHierarchy.LASTUPDATE_DATE = System.DateTime.Now; ;
                mSkuHierarchy.IP_ADDRESS = p_Ip_Address;
                mSkuHierarchy.IS_ACTIVE = p_Is_Active;
                mSkuHierarchy.COMPANY_ID = Companyid;
                mSkuHierarchy.IS_MANUALDISCOUNT = false;
                mSkuHierarchy.ExecuteQuery();
                return "Record Updated";

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
		
		public string DeleteHierarchy(int p_Sku_Hie_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spDeleteSKU_HIERARCHY  mSkuHierarchy = new spDeleteSKU_HIERARCHY();
				mSkuHierarchy.Connection = mConnection;

				mSkuHierarchy.SKU_HIE_ID = p_Sku_Hie_Id;

				mSkuHierarchy.ExecuteQuery();
				return "Record Deleted" ;
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
			}
			finally
			{
			}
		}

		public DataTable SelectDTSkuHierarchy(int p_Sku_Type_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_HIERARCHY mSkuHierarchy = new spSelectSKU_HIERARCHY();
				mSkuHierarchy.Connection = mConnection;
                
				mSkuHierarchy.SKU_HIE_TYPE_ID = p_Sku_Type_Id;
				
				DataTable dt = new DataTable();

				dt = mSkuHierarchy.ExecuteTable();

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


        public DataTable SelectDTSkuHierarchy01(int p_type, int p_company, int p_division, int p_category, int p_brand, int Companyid)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				UspSelectView_SKUHIERARCHY mSkuHierarchy = new UspSelectView_SKUHIERARCHY(); 
				mSkuHierarchy.Connection = mConnection;
                
				mSkuHierarchy.type = p_type;
				mSkuHierarchy.Company_id = p_company;
				mSkuHierarchy.Division_id = p_division;
				mSkuHierarchy.Category_Id = p_category;
				mSkuHierarchy.Brand_Id = p_brand;
                mSkuHierarchy.MCompany_id = Companyid;   
				DataTable dt = new DataTable();
				dt = mSkuHierarchy.ExecuteTable();
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
        public DataTable SelectBrandAssignment(int p_type, int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspGetBrandAssignment mSkuHierarchy = new UspGetBrandAssignment();
                mSkuHierarchy.Connection = mConnection;

                mSkuHierarchy.TYPE_ID = p_type; 
                mSkuHierarchy.USER_ID = p_UserId;
                DataTable dt = new DataTable();
                dt = mSkuHierarchy.ExecuteTable();
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
        public void DeleteAssignBrand(int p_companyId,int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spDeleteBRAND_ASSIGNMENT mDeleteBrand = new spDeleteBRAND_ASSIGNMENT();
                mDeleteBrand.Connection = mConnection;
                mDeleteBrand.PRINCIPAL_ID = p_companyId;
                mDeleteBrand.USER_ID = p_UserId;
                mDeleteBrand.ExecuteQuery();
                
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                
            }
            finally
            {
            }
        }
        public void InsertAssignBrand(int p_companyId,int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertBRAND_ASSIGNMENT mInsertBrand = new spInsertBRAND_ASSIGNMENT();
                mInsertBrand.Connection = mConnection;
                mInsertBrand.PRINCIPAL_ID = p_companyId;
                mInsertBrand.USER_ID = p_UserId;
                mInsertBrand.ExecuteQuery();

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);

            }
            finally
            {
            }
        }




		#endregion

	}
}
