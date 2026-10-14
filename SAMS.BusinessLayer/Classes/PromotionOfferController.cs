using System;
using System.Data;
using SAMS.DatabaseLayer.Classes;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;


namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for PromotionOfferController.
	/// </summary>
	public class PromotionOfferController
	{
		
		#region Constructor
		public PromotionOfferController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods
		public string InsertPromotionOffer(long p_Basket_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, long p_BasketDetail_ID, int p_Quantity, decimal p_Offer_Value, float p_Discount, bool p_Is_And, int p_SKU_ID, int p_UOM_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertPROMOTION_OFFER mPromotion = new spInsertPROMOTION_OFFER();
				mPromotion.Connection = mConnection;

				mPromotion.IS_AND = p_Is_And;
				mPromotion.DISCOUNT = p_Discount;
				mPromotion.QUANTITY = p_Quantity;
				mPromotion.SKU_ID = p_SKU_ID;
				mPromotion.UOM_ID = p_UOM_ID;
				mPromotion.SCHEME_ID = p_Scheme_ID;
				mPromotion.DISTRIBUTOR_ID = p_Dist_ID;
				mPromotion.BASKET_DETAIL_ID = p_BasketDetail_ID;
				mPromotion.BASKET_ID = p_Basket_ID;
				mPromotion.PROMOTION_ID = p_Promotion_ID;
				mPromotion.OFFER_VALUE = p_Offer_Value;

				mPromotion.ExecuteQuery();
				return mPromotion.PROMOTION_OFFER_ID.ToString() ;
				
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

		public string UpdatePromotionOffer(int p_Promotion_Offer_ID, int p_Basket_ID, int p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_BasketDetail_ID, int p_Quantity, decimal p_Offer_Value, float p_Discount, bool p_Is_And, int p_SKU_ID, int p_UOM_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spUpdatePROMOTION_OFFER mPromotion = new spUpdatePROMOTION_OFFER();
				mPromotion.Connection = mConnection;

				mPromotion.IS_AND = p_Is_And;
				mPromotion.DISCOUNT = p_Discount;
				mPromotion.QUANTITY = p_Quantity;
				mPromotion.SKU_ID = p_SKU_ID;
				mPromotion.UOM_ID = p_UOM_ID;
				mPromotion.SCHEME_ID = p_Scheme_ID;
				mPromotion.DISTRIBUTOR_ID = p_Dist_ID;
				mPromotion.BASKET_DETAIL_ID = p_BasketDetail_ID;
				mPromotion.PROMOTION_OFFER_ID = p_Promotion_Offer_ID;
				mPromotion.BASKET_ID = p_Basket_ID;
				mPromotion.PROMOTION_ID = p_Promotion_ID;
				mPromotion.OFFER_VALUE = p_Offer_Value;

				mPromotion.ExecuteQuery();				
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

		public string DeletePromotionOffer()
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

		public DataTable SelectPromotionOffer(int p_Promotion_Offer_ID, int p_Basket_ID, int p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_BasketDetail_ID, int p_Quantity, decimal p_Offer_Value, float p_Discount, bool p_Is_And, int p_SKU_ID, int p_UOM_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spSelectPROMOTION_OFFER mPromotion = new spSelectPROMOTION_OFFER();
				mPromotion.Connection = mConnection;
				
				mPromotion.IS_AND = p_Is_And;
				mPromotion.DISCOUNT = p_Discount;
				mPromotion.QUANTITY = p_Quantity;
				mPromotion.SKU_ID = p_SKU_ID;
				mPromotion.UOM_ID = p_UOM_ID;
				mPromotion.SCHEME_ID = p_Scheme_ID;
				mPromotion.DISTRIBUTOR_ID = p_Dist_ID;
				mPromotion.BASKET_DETAIL_ID = p_BasketDetail_ID;
				mPromotion.PROMOTION_OFFER_ID = p_Promotion_Offer_ID;
				mPromotion.BASKET_ID = p_Basket_ID;
				mPromotion.PROMOTION_ID = p_Promotion_ID;
				mPromotion.OFFER_VALUE = p_Offer_Value;

				DataTable dt = mPromotion.ExecuteTable();
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

		public DataTable SelectPromotionOffer(int p_Promotion_Offer_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				uspSelectPROMOTION_OFFERInfo mPromotion = new uspSelectPROMOTION_OFFERInfo();
				mPromotion.Connection = mConnection;
				
				mPromotion.PROMOTION_OFFER_ID = p_Promotion_Offer_ID;

				DataTable dt = mPromotion.ExecuteTable();
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
