using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// SchemeController
	/// <author></author>
	/// <date>07-Sept-2007</date>
	/// </summary>
	public class BasketController
	{
		
		#region Constructors
		public BasketController()
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
		public string InsertBasket(long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, bool p_Is_Basket, bool p_Is_And, bool p_Is_Multiple, int p_Basket_On, int p_Basket_Selection)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertBASKET_MASTER mBasket = new spInsertBASKET_MASTER();
				mBasket.Connection = mConnection;

				mBasket.PROMOTION_ID = p_Promotion_ID;
				mBasket.SCHEME_ID = p_Scheme_ID;
				mBasket.DISTRIBUTOR_ID = p_Dist_ID;
				mBasket.IS_BASKET = p_Is_Basket;
				mBasket.IS_AND = p_Is_And;
				mBasket.IS_MULTIPLE = p_Is_Multiple;
				mBasket.BASKET_ON = p_Basket_On;
				mBasket.BASKET_SELECTION = p_Basket_Selection;

				mBasket.ExecuteQuery();
				return mBasket.BASKET_ID.ToString() ;
				
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

		public string UpdateBasket(long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, bool p_Is_Basket, bool p_Is_And, bool p_Is_Multiple, int p_Basket_On, int p_Basket_Selection)
		{
			IDbConnection mConnection = null;
			try
			{
				spUpdateBASKET_MASTER mBasket = new spUpdateBASKET_MASTER();
				mBasket.Connection = mConnection;

				mBasket.BASKET_ID = p_Basket_ID;
				mBasket.PROMOTION_ID = p_Promotion_ID;
				mBasket.SCHEME_ID = p_Scheme_ID;
				mBasket.DISTRIBUTOR_ID = p_Dist_ID;
				mBasket.IS_BASKET = p_Is_Basket;
				mBasket.IS_AND = p_Is_And;
				mBasket.IS_MULTIPLE = p_Is_Multiple;
				mBasket.BASKET_ON = p_Basket_On;
				mBasket.BASKET_SELECTION = p_Basket_Selection;
							
				mBasket.ExecuteQuery();
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

		public string DeleteBasket()
		{
			try
			{
				
				return "";
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

		public DataTable SelectBasket(long p_Basket_ID, long p_Promotion_ID,int  p_Scheme_ID, int p_Dist_ID, bool p_Is_Basket, bool p_Is_And, bool p_Is_Multiple, int p_Basket_On, int p_Basket_Selection)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spSelectBASKET_MASTER mBasket = new spSelectBASKET_MASTER();
				mBasket.Connection = mConnection;

				mBasket.BASKET_ID = p_Basket_ID;
				mBasket.PROMOTION_ID = p_Promotion_ID;
				mBasket.SCHEME_ID = p_Scheme_ID;
				mBasket.DISTRIBUTOR_ID = p_Dist_ID;
				mBasket.IS_BASKET = p_Is_Basket;
				mBasket.IS_AND = p_Is_And;
				mBasket.IS_MULTIPLE = p_Is_Multiple;
				mBasket.BASKET_ON = p_Basket_On;
				mBasket.BASKET_SELECTION = p_Basket_Selection;
				
				DataTable dt = mBasket.ExecuteTable();
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
        

		public string InsertBasketDetail(long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, decimal p_Min_Val, decimal p_Max_Val, int p_Multiple_Of, int p_SKU_ID, int p_SKUBrand_ID, int p_SKUDiv_ID, int p_SKUCatg_ID, int p_SKUVariant_ID, int p_SKUGroup_ID, int p_UOM_ID, int p_CompanyID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertBASKET_DETAIL mBasket = new spInsertBASKET_DETAIL();
				mBasket.Connection = mConnection;
                
				mBasket.DISTRIBUTOR_ID = p_Dist_ID;
				mBasket.BASKET_ID = p_Basket_ID;
				mBasket.PROMOTION_ID = p_Promotion_ID;
				mBasket.CATEGORY_ID = p_SKUCatg_ID ;
				mBasket.SKU_GROUP_ID = p_SKUGroup_ID;
				mBasket.UOM_ID = p_UOM_ID;
				mBasket.DIVISION_ID = p_SKUDiv_ID;
				mBasket.VARIANT_ID = p_SKUVariant_ID;
				mBasket.COMPANY_ID = p_CompanyID;
				mBasket.BRAND_ID = p_SKUBrand_ID;
				mBasket.SCHEME_ID = p_Scheme_ID;
				mBasket.MULTIPLE_OF = p_Multiple_Of;
				mBasket.SKU_ID = p_SKU_ID;
				mBasket.MIN_VAL = p_Min_Val;
				mBasket.MAX_VAL = p_Max_Val;				

				mBasket.ExecuteQuery();
				return mBasket.BASKET_DETAIL_ID.ToString() ;
				
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

		public string UpdateBasketDetail(long p_BasketDetail_ID, long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, decimal p_Min_Val, decimal p_Max_Val, int p_Multiple_Of, int p_SKU_ID, int p_SKUBrand_ID, int p_SKUDiv_ID, int p_SKUCatg_ID, int p_SKUVariant_ID, int p_SKUGroup_ID, int p_UOM_ID , int p_SKUCompany_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				spUpdateBASKET_DETAIL mBasket = new spUpdateBASKET_DETAIL();
				mBasket.Connection = mConnection;

				mBasket.BASKET_DETAIL_ID = p_BasketDetail_ID;
				mBasket.DISTRIBUTOR_ID = p_Dist_ID;
				mBasket.BASKET_ID = p_Basket_ID;
				mBasket.PROMOTION_ID = p_Promotion_ID;
				mBasket.CATEGORY_ID = p_SKUCatg_ID ;
				mBasket.SKU_GROUP_ID = p_SKUGroup_ID;
				mBasket.UOM_ID = p_UOM_ID;
				mBasket.DIVISION_ID = p_SKUDiv_ID;
				mBasket.BRAND_ID = p_SKUBrand_ID;
				mBasket.SCHEME_ID = p_Scheme_ID;
				mBasket.MULTIPLE_OF = p_Multiple_Of;
				mBasket.SKU_ID = p_SKU_ID;
				mBasket.VARIANT_ID = p_SKUVariant_ID;  
				mBasket.MIN_VAL = p_Min_Val;
				mBasket.MAX_VAL = p_Max_Val;
				mBasket.COMPANY_ID = p_SKUCompany_ID;

			
				mBasket.ExecuteQuery();
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

		public string DeleteBasketDetail()
		{
			try
			{
				
				return "";
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

		public DataTable SelectBasketDetail(long p_BasketDetail_ID, long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, decimal p_Min_Val, decimal p_Max_Val, int p_Multiple_Of, int p_SKU_ID, int p_SKUBrand_ID, int p_SKUDiv_ID, int p_SKUCatg_ID, int p_SKUVariant_ID, int p_SKUGroup_ID, int p_UOM_ID , int p_SKUCompany_ID )
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spUpdateBASKET_DETAIL mBasket = new spUpdateBASKET_DETAIL();
				mBasket.Connection = mConnection;

				mBasket.BASKET_DETAIL_ID = p_BasketDetail_ID;
				mBasket.DISTRIBUTOR_ID = p_Dist_ID;
				mBasket.BASKET_ID = p_Basket_ID;
				mBasket.PROMOTION_ID = p_Promotion_ID;
				mBasket.CATEGORY_ID = p_SKUCatg_ID ;
				mBasket.SKU_GROUP_ID = p_SKUGroup_ID;
				mBasket.UOM_ID = p_UOM_ID;
				mBasket.DIVISION_ID = p_SKUDiv_ID;
				mBasket.VARIANT_ID = p_SKUVariant_ID;
				mBasket.BRAND_ID = p_SKUBrand_ID;
				mBasket.SCHEME_ID = p_Scheme_ID;
				mBasket.MULTIPLE_OF = p_Multiple_Of;
				mBasket.SKU_ID = p_SKU_ID;
				mBasket.MIN_VAL = p_Min_Val;
				mBasket.MAX_VAL = p_Max_Val;
			    mBasket.COMPANY_ID = p_SKUCompany_ID;
 		 		DataTable dt = mBasket.ExecuteTable();
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

		
		
		#endregion
	}
}
