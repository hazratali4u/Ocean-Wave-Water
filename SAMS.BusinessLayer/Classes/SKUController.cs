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
	public class SkuController
	{	
		#region Constructors
		public SkuController()
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


        public DataTable SelectSkuInfo(int p_company_id, int p_division_id, int p_category_id, int p_brand_id, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectSkuInfo mspSelectSkuInfo = new uspSelectSkuInfo();
                mspSelectSkuInfo.brand_id = p_brand_id;
                mspSelectSkuInfo.category_id = p_category_id;
                mspSelectSkuInfo.Principal_id = p_company_id;
                mspSelectSkuInfo.Connection = mConnection;
                mspSelectSkuInfo.division_id = p_division_id;
                mspSelectSkuInfo.Company_id = Companyid;  

                DataTable dt = mspSelectSkuInfo.ExecuteTable();

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
        public DataTable SelectSkuInfo(int Companyid)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectSkuInfo mSkuInfo = new uspSelectSkuInfo();
				mSkuInfo.Connection = mConnection;
                mSkuInfo.Company_id = Companyid;   
				DataTable dt = mSkuInfo.ExecuteTable();
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
        public DataTable SelectSkuData(int p_SKU_Id, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSKUS mSkuInfo = new spSelectSKUS(); 
                mSkuInfo.Connection = mConnection;
                mSkuInfo.SKU_ID = p_SKU_Id;
                mSkuInfo.COMPANY_ID = Companyid;  
                DataTable dt = mSkuInfo.ExecuteTable();
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
        public DataTable SelectSKuCurrentPrice(int p_Uom_id ,int p_Company_id,int p_Division_Id,int p_Brand_Id,int p_Category_Id,int variant_Id,int p_Iscurrent,int p_sku_id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectskuPriceInfo mSkuInfo = new spSelectskuPriceInfo(); 
				mSkuInfo.Connection = mConnection;

				mSkuInfo.UOM_ID  = p_Uom_id;
				mSkuInfo.COMPANY_ID = p_Company_id;
				mSkuInfo.DIVISION_ID = p_Division_Id;
				mSkuInfo.BRAND_ID = p_Brand_Id;
				mSkuInfo.CATEGORY_ID = p_Category_Id;
				mSkuInfo.VARIANT_ID = variant_Id;
				mSkuInfo.ISACTIVE = true;
				mSkuInfo.ISCURRENT = p_Iscurrent;
				mSkuInfo.SKU_Id = p_sku_id;
				 
				DataTable dt = mSkuInfo.ExecuteTable();
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
		public DataTable SelectSKU_Prices(int p_Sku_Price_Id,int p_Uom_Id,decimal p_Tax_Price,decimal p_Distributor_Price,decimal p_Trade_Price,decimal p_Retail_Price,int p_Sku_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spSelectSKU_PRICES mSkuPrices = new spSelectSKU_PRICES();
				mSkuPrices.Connection = mConnection;
                
				mSkuPrices.SKU_PRICE_ID = p_Sku_Price_Id;
				mSkuPrices.UOM_ID = p_Uom_Id;
				mSkuPrices.TAX_PRICE = p_Tax_Price;
				mSkuPrices.DISTRIBUTOR_PRICE = p_Distributor_Price;
				mSkuPrices.TRADE_PRICE = p_Trade_Price;
				mSkuPrices.RETAIL_PRICE = p_Retail_Price;
				mSkuPrices.SKU_ID = p_Sku_Id;
				mSkuPrices.LASTUPDATE_DATE = Constants.DateNullValue ;
				mSkuPrices.TIME_STAMP = Constants.DateNullValue ;
				mSkuPrices.IP_ADDRESS = null ;
				
				DataTable dt = mSkuPrices.ExecuteTable();
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
        public DataTable SearchProduct(string p_Search_Text, int p_TYPE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSearchProduct mspSelectSkuInfo = new uspSearchProduct();
                mspSelectSkuInfo.Connection = mConnection;
                mspSelectSkuInfo.SEARCH_TEXT = p_Search_Text;
                mspSelectSkuInfo.TYPE = p_TYPE;
                DataTable dt = mspSelectSkuInfo.ExecuteTable();

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

        public string UpdateSKU_PRICES_Status()
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				usp_UpdateSKUPrices_Status mSkuPrices = new usp_UpdateSKUPrices_Status();
				mSkuPrices.Connection = mConnection;
				mSkuPrices.ExecuteQuery(); 
                return  "Record Inserted" ;
				
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
		public string UpdateSKU_PRICES_Status(IDbTransaction mTransaction )
		{
			try
			{
				usp_UpdateSKUPrices_Status mSkuPrices = new usp_UpdateSKUPrices_Status();
				mSkuPrices.Connection = mTransaction.Connection;
				mSkuPrices.Transaction = mTransaction;
                mSkuPrices.ExecuteQuery(); 
				return  "Record Inserted" ;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				
			}
		}

        public string InsertSKU_PRICES(int p_Distributor_Id, int p_Sku_Id, int p_Uom_Id, decimal p_Distributor_Discount, decimal p_Tax_Price, decimal p_Distributor_Price, decimal p_Trade_Price, decimal p_Retail_Price, DateTime p_date_effected,decimal p_SED_Tax)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                UspProcessSKU_Prices mSkuPrices = new UspProcessSKU_Prices();
				mSkuPrices.Connection = mConnection;
                mSkuPrices.DISTRIBUTOR_ID  = p_Distributor_Id; 
				mSkuPrices.DISTRIBUTOR_PRICE = p_Distributor_Price;
				mSkuPrices.SKU_ID = p_Sku_Id;
				mSkuPrices.RETAIL_PRICE = p_Retail_Price;
				mSkuPrices.TAX_PRICE=p_Tax_Price;
				mSkuPrices.TRADE_PRICE=p_Trade_Price;
				mSkuPrices.DISTRIBUTOR_DISCOUNT = p_Distributor_Discount;  
				mSkuPrices.TIME_STAMP = System.DateTime.Now;
				mSkuPrices.LASTUPDATE_DATE = System.DateTime.Now;
				mSkuPrices.DATE_EFFECTED =  p_date_effected;
                mSkuPrices.SED_TAX = p_SED_Tax;  
                mSkuPrices.ExecuteQuery();
				return  "Record Inserted" ;
				
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

		public string UpdateSKU_PRICES(DateTime p_Time_Stamp,DateTime p_LastUpdate_Date,int p_Sku_Price_Id,int p_Sku_Id,int p_Uom_Id,decimal p_Tax_Price,decimal p_Distributor_Price,decimal p_Trade_Price,decimal p_Retail_Price,string p_Ip_Address)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateSKU_PRICES mSkuPrices = new spUpdateSKU_PRICES();
				mSkuPrices.Connection = mConnection;
                
				mSkuPrices.DISTRIBUTOR_PRICE = p_Distributor_Price;
				mSkuPrices.LASTUPDATE_DATE = p_LastUpdate_Date;
				mSkuPrices.SKU_ID = p_Sku_Id;
				mSkuPrices.SKU_PRICE_ID = p_Sku_Price_Id;
				mSkuPrices.TIME_STAMP = p_Time_Stamp;
				mSkuPrices.RETAIL_PRICE=p_Retail_Price;
				mSkuPrices.TAX_PRICE=p_Tax_Price;
				mSkuPrices.TRADE_PRICE=p_Trade_Price;
				mSkuPrices.UOM_ID=p_Uom_Id;
				mSkuPrices.IP_ADDRESS = p_Ip_Address;
				

				mSkuPrices.ExecuteQuery();
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

		public DataTable SelectSKU_PRICES(DateTime p_Time_Stamp,DateTime p_LastUpdate_Date, int p_Sku_Price_Id, int p_Sku_Id,int p_Uom_Id,decimal p_Tax_Price,decimal p_Distributor_Price,decimal p_Trade_Price,decimal p_Retail_Price)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_PRICES mSkuPrices = new spSelectSKU_PRICES();
				mSkuPrices.Connection = mConnection;
                
				mSkuPrices.DISTRIBUTOR_PRICE = p_Distributor_Price;
				mSkuPrices.LASTUPDATE_DATE = p_LastUpdate_Date;
				mSkuPrices.SKU_ID = p_Sku_Id;
				mSkuPrices.SKU_PRICE_ID = p_Sku_Price_Id;
				mSkuPrices.TIME_STAMP = p_Time_Stamp;
				mSkuPrices.RETAIL_PRICE=p_Retail_Price;
				mSkuPrices.TAX_PRICE=p_Tax_Price;
				mSkuPrices.TRADE_PRICE=p_Trade_Price;
				mSkuPrices.UOM_ID=p_Uom_Id;
				mSkuPrices.IP_ADDRESS = null;
				

				DataTable dt = mSkuPrices.ExecuteTable();
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

        public DataTable SelectUOMs(int p_UOM_Id, string p_UOM_Desc)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spSelectUOMS mUOMs = new spSelectUOMS();
				mUOMs.Connection = mConnection;
				
				mUOMs.UOM_ID = p_UOM_Id;
				mUOMs.UOM_DESC = p_UOM_Desc;
				mUOMs.TIME_STAMP = Constants.DateNullValue;
				mUOMs.STATUS = Constants.IntNullValue;

				DataTable dt = mUOMs.ExecuteTable();
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

		
	    public static void UpdateSKU_Prices (int p_Sku_Price_Id , int p_Sku_Id,decimal p_Distributor_Price , decimal p_Trade_Price , decimal p_Retail_Price,decimal p_Tax_Price, int p_UomId,DateTime p_Time_Stamp , DateTime p_LastUpdateDate ,string p_Ip_Address, int p_IsCurrent,DateTime p_Date_Effected , DateTime p_Date_Expire)
		{
		 IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
			    
				SAMS.DatabaseLayer.Classes.spUpdateSKU_PRICES mspUpdateSku_Prices = new SAMS.DatabaseLayer.Classes.spUpdateSKU_PRICES();
                mspUpdateSku_Prices.Connection = mConnection;

				mspUpdateSku_Prices.Connection = mConnection;
				mspUpdateSku_Prices.UOM_ID = p_UomId;
				mspUpdateSku_Prices.TRADE_PRICE = p_Trade_Price;
				mspUpdateSku_Prices.TIME_STAMP = p_Time_Stamp;
				mspUpdateSku_Prices.TAX_PRICE = p_Tax_Price;
				mspUpdateSku_Prices.SKU_PRICE_ID = p_Sku_Price_Id;
				mspUpdateSku_Prices.SKU_ID = p_Sku_Id;
				mspUpdateSku_Prices.RETAIL_PRICE = p_Retail_Price;
				mspUpdateSku_Prices.LASTUPDATE_DATE = p_LastUpdateDate;
				mspUpdateSku_Prices.ISCURRENT = p_IsCurrent;
				mspUpdateSku_Prices.IP_ADDRESS = p_Ip_Address;
				mspUpdateSku_Prices.DISTRIBUTOR_PRICE = p_Distributor_Price;
				mspUpdateSku_Prices.DATE_EXPIRE = p_Date_Expire;
				mspUpdateSku_Prices.DATE_EFFECTED = p_Date_Effected;
                
                mspUpdateSku_Prices.ExecuteQuery();
				
			     
			}
		
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
	
		
		}
		
		
		public static DataTable SelectSKU_Prices(int p_Sku_Price_Id , int p_Sku_Id,decimal p_Distributor_Price , decimal p_Trade_Price , decimal p_Retail_Price,decimal p_Tax_Price, int p_UomId,DateTime p_Time_Stamp , DateTime p_LastUpdateDate ,string p_Ip_Address, int p_IsCurrent,DateTime p_Date_Effected , DateTime p_Date_Expire)
		{
		   IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
			
				SAMS.DatabaseLayer.Classes.spSelectSKU_PRICES mspSelectSku_Prices = new SAMS.DatabaseLayer.Classes.spSelectSKU_PRICES();
				mspSelectSku_Prices.Connection = mConnection;
			    mspSelectSku_Prices.UOM_ID = p_UomId;
                mspSelectSku_Prices.TRADE_PRICE = p_Trade_Price;
                mspSelectSku_Prices.TIME_STAMP = p_Time_Stamp;
                mspSelectSku_Prices.TAX_PRICE = p_Tax_Price;
                mspSelectSku_Prices.SKU_PRICE_ID = p_Sku_Price_Id;
                mspSelectSku_Prices.SKU_ID = p_Sku_Id;
                mspSelectSku_Prices.RETAIL_PRICE = p_Retail_Price;
                mspSelectSku_Prices.LASTUPDATE_DATE = p_LastUpdateDate;
                mspSelectSku_Prices.ISCURRENT = p_IsCurrent;
                mspSelectSku_Prices.IP_ADDRESS = p_Ip_Address;
                mspSelectSku_Prices.DISTRIBUTOR_PRICE = p_Distributor_Price;
                mspSelectSku_Prices.DATE_EXPIRE = p_Date_Expire;
                mspSelectSku_Prices.DATE_EFFECTED = p_Date_Effected;
                
				return(mspSelectSku_Prices.ExecuteTable());
                
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
   

		#endregion
	}
}
