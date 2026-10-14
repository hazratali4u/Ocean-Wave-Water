using System;
using System.Data;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for ControllerCustomerCreditLimit.
	/// </summary>
	public class ControllerCustomerCreditLimit
	{
		public ControllerCustomerCreditLimit()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	
		public DataTable GetCreditLimit( long p_Customer_Id  )

		{
		  	IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		     	mConnection.Open();
				uspSelectCompany_Credit_Limit mspSelectCompanyCreditLimit = new uspSelectCompany_Credit_Limit();
        		mspSelectCompanyCreditLimit.Connection = mConnection;
                mspSelectCompanyCreditLimit.CUSTOMER_ID  =	p_Customer_Id;  
	 	        DataTable dt =  mspSelectCompanyCreditLimit.ExecuteTable();
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
	
		public DataTable GetCategorycreditLimit( long p_Customer_Id ,int p_Company_Id )

		{
		  
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectCategory_Credit_Limit mspSelectCategoryCrdtLimit = new uspSelectCategory_Credit_Limit();
				mspSelectCategoryCrdtLimit.COMPANY_ID  = p_Company_Id;
				mspSelectCategoryCrdtLimit.CUSTOMER_ID =p_Customer_Id;
				mspSelectCategoryCrdtLimit.Connection = mConnection;
				DataTable dt = mspSelectCategoryCrdtLimit.ExecuteTable();
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
		public void UpdateCompanyCreditLimit (long p_Sku_Company_Credit_Limit_Id ,  long p_Customer_Id ,decimal p_Allowed_Credit_Limit,int p_days)

		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
			
			
				spUpdateSKU_COMPANY_CREDIT_LIMIT  mspUpdateSku_Company_Credit_Limit = new spUpdateSKU_COMPANY_CREDIT_LIMIT();
				mspUpdateSku_Company_Credit_Limit.SKU_COMPANY_CREDIT_LIMIT_ID  = p_Sku_Company_Credit_Limit_Id;
                mspUpdateSku_Company_Credit_Limit.ALLOWED_CREDIT_LIMIT = p_Allowed_Credit_Limit;
				mspUpdateSku_Company_Credit_Limit.Connection = mConnection;
				mspUpdateSku_Company_Credit_Limit.CUSTOMER_ID = p_Customer_Id;
				mspUpdateSku_Company_Credit_Limit.IS_ACTIVE = true;
				mspUpdateSku_Company_Credit_Limit.SKU_COMPANY_ID = Constants.LongNullValue;
				mspUpdateSku_Company_Credit_Limit.TIME_STAMP = Constants.DateNullValue;
				mspUpdateSku_Company_Credit_Limit.USED_LIMIT  = Constants.DecimalNullValue;
				mspUpdateSku_Company_Credit_Limit.CREDITFORDAYS = p_days;
    			mspUpdateSku_Company_Credit_Limit.ExecuteQuery();
 
                
			}

			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				//return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
	
   
		
		}
		
		public void InsertCompanyCreditLimit ( long p_Customer_Id ,long  p_Sku_Company_Id , decimal p_Allowed_Credit_Limit , decimal p_Used_Limit,int p_days)
		{
            IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
			
			
				spInsertSKU_COMPANY_CREDIT_LIMIT mspInsertSku_Company_Credit_Limit = new spInsertSKU_COMPANY_CREDIT_LIMIT();
				mspInsertSku_Company_Credit_Limit.ALLOWED_CREDIT_LIMIT = p_Allowed_Credit_Limit;
			    mspInsertSku_Company_Credit_Limit.Connection = mConnection;
                mspInsertSku_Company_Credit_Limit.CUSTOMER_ID = p_Customer_Id;
                mspInsertSku_Company_Credit_Limit.IS_ACTIVE = true;
                mspInsertSku_Company_Credit_Limit.SKU_COMPANY_ID = p_Sku_Company_Id;
                mspInsertSku_Company_Credit_Limit.TIME_STAMP = DateTime.Now;
                mspInsertSku_Company_Credit_Limit.USED_LIMIT =  p_Used_Limit;
				mspInsertSku_Company_Credit_Limit.CREDITFORDAYS = p_days;
                mspInsertSku_Company_Credit_Limit.ExecuteQuery();
 
                
			}

			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				//return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
	
   
		
		}
		public void UpdateCategoryCreditLimit(long p_Sku_Category_Credit_Limit_Id,  decimal p_Allowed_Limit , long p_Customer_Id   )

		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
			
				spUpdateSKU_CATEGORY_CREDIT_LIMIT mspUpdateSku_Category_Credit_Limit = new spUpdateSKU_CATEGORY_CREDIT_LIMIT();
				mspUpdateSku_Category_Credit_Limit.Connection  =  mConnection;
				mspUpdateSku_Category_Credit_Limit.SKU_CATEGORY_CREDIT_LIMIT_ID = p_Sku_Category_Credit_Limit_Id;
                mspUpdateSku_Category_Credit_Limit.ALLOWED_LIMIT = p_Allowed_Limit;
                mspUpdateSku_Category_Credit_Limit.CUSTOMER_ID =  p_Customer_Id;
				mspUpdateSku_Category_Credit_Limit.IS_ACTIVE = true;
				mspUpdateSku_Category_Credit_Limit.SKU_CATEGORY_ID = Constants.LongNullValue;
				mspUpdateSku_Category_Credit_Limit.SKU_COMPANY_ID = Constants.LongNullValue;
				mspUpdateSku_Category_Credit_Limit.TIME_STAMP = Constants.DateNullValue;
                mspUpdateSku_Category_Credit_Limit.USED_LIMIT =  Constants.DecimalNullValue;
				mspUpdateSku_Category_Credit_Limit.ExecuteQuery();


			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				//return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}
		public void InsertCategoryCreditLimit(decimal p_Allowed_Limit , long p_Customer_Id , long p_Sku_Category_Id , long p_Sku_Company_Id , decimal p_Used_Limit   )
		{
		    IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
			
			    spInsertSKU_CATEGORY_CREDIT_LIMIT mspInsertSku_Category_Credit_Limit = new spInsertSKU_CATEGORY_CREDIT_LIMIT();
				mspInsertSku_Category_Credit_Limit.Connection  =  mConnection;
                mspInsertSku_Category_Credit_Limit.ALLOWED_LIMIT = p_Allowed_Limit;
                mspInsertSku_Category_Credit_Limit.CUSTOMER_ID =  p_Customer_Id;
                mspInsertSku_Category_Credit_Limit.IS_ACTIVE = true;
                mspInsertSku_Category_Credit_Limit.SKU_CATEGORY_ID =   p_Sku_Category_Id;
                mspInsertSku_Category_Credit_Limit.SKU_COMPANY_ID = p_Sku_Company_Id;
                mspInsertSku_Category_Credit_Limit.TIME_STAMP = DateTime.Now;
                mspInsertSku_Category_Credit_Limit.USED_LIMIT =  p_Used_Limit;
                mspInsertSku_Category_Credit_Limit.ExecuteQuery();

 			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				//return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
			}

		public void UpdateCategoryCreditLimit(long p_Sku_Category_Credit_Limit_Id,  decimal p_Allowed_Limit , long p_Customer_Id,decimal p_Used_Limit)

		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
			
				spUpdateSKU_CATEGORY_CREDIT_LIMIT mspUpdateSku_Category_Credit_Limit = new spUpdateSKU_CATEGORY_CREDIT_LIMIT();
				mspUpdateSku_Category_Credit_Limit.Connection  =  mConnection;
				mspUpdateSku_Category_Credit_Limit.SKU_CATEGORY_CREDIT_LIMIT_ID = p_Sku_Category_Credit_Limit_Id;
				mspUpdateSku_Category_Credit_Limit.ALLOWED_LIMIT = p_Allowed_Limit;
				mspUpdateSku_Category_Credit_Limit.CUSTOMER_ID =  p_Customer_Id;
				mspUpdateSku_Category_Credit_Limit.IS_ACTIVE = true;
				mspUpdateSku_Category_Credit_Limit.SKU_CATEGORY_ID = Constants.LongNullValue;
				mspUpdateSku_Category_Credit_Limit.SKU_COMPANY_ID = Constants.LongNullValue;
				mspUpdateSku_Category_Credit_Limit.TIME_STAMP = Constants.DateNullValue;
				mspUpdateSku_Category_Credit_Limit.USED_LIMIT =  p_Used_Limit;
				mspUpdateSku_Category_Credit_Limit.ExecuteQuery();


			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				//return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}
		public void UpdateCompanyCreditLimit (long p_Sku_Company_Credit_Limit_Id ,  long p_Customer_Id ,decimal p_Allowed_Credit_Limit,decimal p_Used_Limit )

		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
			
			
				spUpdateSKU_COMPANY_CREDIT_LIMIT  mspUpdateSku_Company_Credit_Limit = new spUpdateSKU_COMPANY_CREDIT_LIMIT();
				mspUpdateSku_Company_Credit_Limit.SKU_COMPANY_CREDIT_LIMIT_ID  = p_Sku_Company_Credit_Limit_Id;
				mspUpdateSku_Company_Credit_Limit.ALLOWED_CREDIT_LIMIT = p_Allowed_Credit_Limit;
				mspUpdateSku_Company_Credit_Limit.Connection = mConnection;
				mspUpdateSku_Company_Credit_Limit.CUSTOMER_ID = p_Customer_Id;
				mspUpdateSku_Company_Credit_Limit.IS_ACTIVE = true;
				mspUpdateSku_Company_Credit_Limit.SKU_COMPANY_ID = Constants.LongNullValue;
				mspUpdateSku_Company_Credit_Limit.TIME_STAMP = Constants.DateNullValue;
				mspUpdateSku_Company_Credit_Limit.USED_LIMIT  = p_Used_Limit;
				mspUpdateSku_Company_Credit_Limit.ExecuteQuery();
 
                
			}

			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				//return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
	
   
		
		}
		public DataTable GetCreditLimitOfCustomers(int Credit_level)
		{
			IDbConnection mConnection = null;
			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString,EnumProviders.SQLClient);
				mConnection.Open();
				uspGetCreditInfoOfCustomers GCC = new uspGetCreditInfoOfCustomers();
				GCC.Connection = mConnection;
				GCC.CREDIT_LEVEL = Credit_level;
				DataTable dt  =  new DataTable(); 
				dt = GCC.ExecuteTable();
				return dt;

			}
			catch(Exception ex)
			{
				ExceptionPublisher.PublishException(ex);
				return null;
			}
			finally
			{
				if(mConnection!=null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

		}

		public void AdjustCreditLimitWithCashReceived(decimal Adjusted_amount,long Customer_id,int level_id,long Sku_level_id)
		{
			IDbConnection mConnection = null;
			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString,EnumProviders.SQLClient);
				mConnection.Open();
				uspAdjustCreditLimit GCC = new uspAdjustCreditLimit();
				GCC.Connection = mConnection;
				GCC.ADJUSTED_AMOUNT = Adjusted_amount;
				GCC.CUSTOMER_ID = Customer_id;
				GCC.LEVEL_ID = level_id;
				GCC.SKU_LEVEL_ID = Sku_level_id;
				
				GCC.ExecuteQuery();
				

			}
			catch(Exception ex)
			{
				ExceptionPublisher.PublishException(ex);
				
			}
			finally
			{
				if(mConnection!=null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		}
	}


}
