using System;
using System.Data;
using SAMS.DatabaseLayer.Classes;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;


namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for PromotionController.
	/// </summary>
	public class PromotionController
	{
		#region Initialization
		//added by Ali Raza
		#endregion

		#region Constructor
		public PromotionController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods
		public DataTable SelectSchemeID()
		{
          IDbConnection mconnection = null;
			try
			{
				mconnection = ProviderFactory.GetConnection(Configuration.ConnectionString,EnumProviders.SQLClient);
				mconnection.Open();

				uspSelectSchemeID sSID = new uspSelectSchemeID();
				sSID.Connection = mconnection;

				DataTable tb = sSID.ExecuteTable();
				return tb;
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);
				return null;
			}
			finally
			{
				if( mconnection != null && mconnection.State == ConnectionState.Open)
				{
					mconnection.Close();
				}
			}

		}
		public DataTable GetBasketMaster(long PromotionId)
		{
			IDbConnection mconnection = null;
			try
			{
				mconnection = ProviderFactory.GetConnection(Configuration.ConnectionString,EnumProviders.SQLClient);
				mconnection.Open();

				spSelectBASKET_MASTER01 BasMaster  = new spSelectBASKET_MASTER01();  
				BasMaster.Connection = mconnection;
				
				BasMaster.BASKET_ID = Constants.LongNullValue;
				BasMaster.SCHEME_ID = Constants.IntNullValue; 
				BasMaster.DISTRIBUTOR_ID = Configuration.DistributorId;
				BasMaster.PROMOTION_ID = PromotionId;

				DataTable dt = BasMaster.ExecuteTable();
				return dt;
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);
				return null;
			}
			finally
			{
				if( mconnection != null && mconnection.State == ConnectionState.Open)
				{
					mconnection.Close();
				}
			}

		}

		public DataTable GetBasketDetailForBasket( int Basket_ID)
		{
		IDbConnection mconnection = null;
			try
			{
				mconnection = ProviderFactory.GetConnection(Configuration.ConnectionString,EnumProviders.SQLClient);
				mconnection.Open();
				
				uspGetBasketPromotion01  mBasktDetail = new uspGetBasketPromotion01();
				mBasktDetail.BasketId = Basket_ID;
				mBasktDetail.Connection = mconnection;
				DataTable DT = mBasktDetail.ExecuteTable();
				return DT;
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);
				return null;
			}
			finally
			{
				if( mconnection != null && mconnection.State == ConnectionState.Open)
				{
					mconnection.Close();
				}
			}


		}
		public DataTable GetBasketDetailForSlab(int Basket_ID)
		{
			IDbConnection mconnection = null;
			try
			{
				mconnection = ProviderFactory.GetConnection(Configuration.ConnectionString,EnumProviders.SQLClient);
				mconnection.Open();
				USPGETSLABPROMOTION BasketDetail  = new USPGETSLABPROMOTION(); 
				BasketDetail.Connection = mconnection;
				
				BasketDetail.BasketId_ID = Basket_ID;

				DataTable dt = BasketDetail.ExecuteTable();
				return dt;
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);
				return null;
			}
			finally
			{
				if( mconnection != null && mconnection.State == ConnectionState.Open)
				{
					mconnection.Close();
				}
			}

		}

		public DataTable GetDistributorHierarchy( int pDistributorId)
		{
			IDbConnection mconnection = null;
			DataTable mDistHierarchy =new DataTable();

			try
			{
				mconnection = ProviderFactory.GetConnection(Configuration.ConnectionString,EnumProviders.SQLClient);
				mconnection.Open();

				usp_GetDistributorHierarchy mGetDistHierarchy = new usp_GetDistributorHierarchy();
				mGetDistHierarchy.Connection = mconnection;
				mGetDistHierarchy.DistributorId = pDistributorId;
				mGetDistHierarchy.ExecuteTable();
				mDistHierarchy =  mGetDistHierarchy.ExecuteTable();
				return mDistHierarchy;
			}
			catch(Exception ex)
			{
				ExceptionPublisher.PublishException(ex);
				return null;
			}
			finally
			{
				if( mconnection != null && mconnection.State == ConnectionState.Open)
				{
					mconnection.Close();
				}
			}
		}
		public DataTable SelectTerrAreaID(int pTerritoryID)
		{
			IDbConnection mconnection = null;
			try
			{
				mconnection = ProviderFactory.GetConnection(Configuration.ConnectionString,EnumProviders.SQLClient);
				mconnection.Open();

				uspSelectTerrArea sTA = new uspSelectTerrArea();
				DataTable dt = new DataTable();
				sTA.Connection = mconnection;
				sTA.TERRITORY_ID = pTerritoryID;
				
				
				dt = sTA.ExecuteTable();
				return dt;
			}
			catch(Exception ex)
			{
				ExceptionPublisher.PublishException(ex);
				return null;
			}
			finally
			{
				if( mconnection != null && mconnection.State == ConnectionState.Open)
				{
					mconnection.Close();
				}
			}
		}

		public DataTable SelectAreaCusID(int pAreaID)
		{
			IDbConnection mconnection = null;
			try
			{
				mconnection = ProviderFactory.GetConnection(Configuration.ConnectionString,EnumProviders.SQLClient);
				mconnection.Open();

				SAMS.DatabaseLayer.uspSelectAreaCus sAC = new SAMS.DatabaseLayer.uspSelectAreaCus(); 
				DataTable dt = new DataTable();
				sAC.Connection = mconnection;
				sAC.AREA_ID = pAreaID;
				
				
				dt = sAC.ExecuteTable();
				return dt;
			}
			catch(Exception ex)
			{
				ExceptionPublisher.PublishException(ex);
				return null;
			}
			finally
			{
				if( mconnection != null && mconnection.State == ConnectionState.Open)
				{
					mconnection.Close();
				}
			}

		}
        public string InsertPromotion(int p_Scheme_Id, int p_Distributor_Id, string p_Pro_Code, string p_Pro_Description, DateTime p_Promo_Date, bool p_Claimable, DateTime p_Start_Date, DateTime p_End_Date, bool p_Is_Active, int p_Promotion_Type, int p_Promotion_Selection, bool p_Is_Scheme, bool p_Promotion_For, int p_UserId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertPROMOTION mPromotion = new spInsertPROMOTION();
				mPromotion.Connection = mConnection;

				mPromotion.SCHEME_ID = p_Scheme_Id;
				mPromotion.DISTRIBUTOR_ID = p_Distributor_Id;
				mPromotion.PROMOTION_CODE = p_Pro_Code;
				mPromotion.PROMOTION_DESCRIPTION = p_Pro_Description;
				mPromotion.PROMO_DATE = p_Promo_Date;
				mPromotion.CLAIMABLE = p_Claimable;
				mPromotion.START_DATE = DateTime.Parse(p_Start_Date.ToShortDateString() + " 00:00:00");
				mPromotion.END_DATE = DateTime.Parse(p_End_Date.ToShortDateString() + " 23:59:59");
				mPromotion.IS_ACTIVE = p_Is_Active;
				mPromotion.PROMOTION_TYPE = p_Promotion_Type;
				mPromotion.PROMOTION_SELECTION = p_Promotion_Selection;
				mPromotion.IS_SCHEME = p_Is_Scheme;
				mPromotion.PROMOTION_FOR = p_Promotion_For;
                mPromotion.USER_ID = p_UserId;  

				mPromotion.ExecuteQuery();
				return mPromotion.PROMOTION_ID.ToString() ;
				
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

		public string InsertPromotion(int p_Scheme_Id, int p_Distributor_Id, string p_Pro_Code, string p_Pro_Description, DateTime p_Promo_Date, bool p_Claimable, DateTime p_Start_Date, DateTime p_End_Date, bool p_Is_Active, int p_Promotion_Type, int p_Promotion_Selection,bool p_Is_Scheme/*,bool p_Promotion_For*/)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertPROMOTION mPromotion = new spInsertPROMOTION();
				mPromotion.Connection = mConnection;

				mPromotion.SCHEME_ID = p_Scheme_Id;
				mPromotion.DISTRIBUTOR_ID = p_Distributor_Id;
				mPromotion.PROMOTION_CODE = p_Pro_Code;
				mPromotion.PROMOTION_DESCRIPTION = p_Pro_Description;
				mPromotion.PROMO_DATE = p_Promo_Date;
				mPromotion.CLAIMABLE = p_Claimable;
				mPromotion.START_DATE = p_Start_Date;
				mPromotion.END_DATE = p_End_Date;
				mPromotion.IS_ACTIVE = p_Is_Active;
				mPromotion.PROMOTION_TYPE = p_Promotion_Type;
				mPromotion.PROMOTION_SELECTION = p_Promotion_Selection;
				mPromotion.IS_SCHEME = p_Is_Scheme;
				//mPromotion.PROMOTION_FOR = p_Promotion_For; 

				mPromotion.ExecuteQuery();
				return mPromotion.PROMOTION_ID.ToString() ;
				
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

		public string UpdatePromotion(long p_Promotion_Id, int p_Scheme_Id, int p_Distributor_Id, string p_Pro_Code, string p_Pro_Description, DateTime p_Promo_Date, bool p_Claimable, DateTime p_Start_Date, DateTime p_End_Date, bool p_Is_Active, int p_Promotion_Type, int p_Promotion_Selection)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spUpdatePROMOTION mPromotion = new spUpdatePROMOTION();
				mPromotion.Connection = mConnection;

				mPromotion.PROMOTION_ID = p_Promotion_Id;
				mPromotion.SCHEME_ID = p_Scheme_Id;
				mPromotion.DISTRIBUTOR_ID = p_Distributor_Id;
				mPromotion.PROMOTION_CODE = p_Pro_Code;
				mPromotion.PROMOTION_DESCRIPTION = p_Pro_Description;
				mPromotion.PROMO_DATE = p_Promo_Date;
				mPromotion.CLAIMABLE = p_Claimable;
				mPromotion.START_DATE = p_Start_Date;
				mPromotion.END_DATE = p_End_Date;
				mPromotion.IS_ACTIVE = p_Is_Active;
				mPromotion.PROMOTION_TYPE = p_Promotion_Type;
				mPromotion.PROMOTION_SELECTION = p_Promotion_Selection;

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

		public string DeletePromotion()
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

		public DataTable SelectPromotion(long p_Promotion_Id, int p_Scheme_Id, int p_Distributor_Id, string p_Pro_Code, string p_Pro_Description, DateTime p_Promo_Date, bool p_Claimable, DateTime p_Start_Date, DateTime p_End_Date, bool p_Is_Active, int p_Promotion_Type, int p_Promotion_Selection)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spSelectPROMOTION mPromotion = new spSelectPROMOTION();
				mPromotion.Connection = mConnection;
				
				mPromotion.PROMOTION_ID = p_Promotion_Id;
				mPromotion.SCHEME_ID = p_Scheme_Id;
				mPromotion.DISTRIBUTOR_ID = p_Distributor_Id;
				mPromotion.PROMOTION_CODE = p_Pro_Code;
				mPromotion.PROMOTION_DESCRIPTION = p_Pro_Description;
				mPromotion.PROMO_DATE = p_Promo_Date;
				mPromotion.CLAIMABLE = p_Claimable;
				mPromotion.START_DATE = p_Start_Date;
				mPromotion.END_DATE = p_End_Date;
				mPromotion.IS_ACTIVE = p_Is_Active;
				mPromotion.PROMOTION_TYPE = p_Promotion_Type;
				mPromotion.PROMOTION_SELECTION = p_Promotion_Selection;

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

		public DataTable SelectPromotionWithSchemeInfo(int p_Distributor_Id, int p_Promotion_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				uspSelectPromotionWithSchemes mPromotion = new uspSelectPromotionWithSchemes();
				mPromotion.Connection = mConnection;
				
				mPromotion.PROMOTION_ID = p_Promotion_Id;
				mPromotion.DISTRIBUTOR_ID = p_Distributor_Id;
				
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

		public DataTable SelectAllActivePromotions(int p_Distributor_Id, int p_Scheme_Id, DateTime StartDate,DateTime EndDate, bool IsActive)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				uspSelectPROMOTIONS mPromotion= new uspSelectPROMOTIONS();
				mPromotion.Connection = mConnection;
				mPromotion.DISTRIBUTOR_ID = p_Distributor_Id;
				mPromotion.SCHEME_ID = p_Scheme_Id;
				mPromotion.START_DATE = StartDate;
				mPromotion.END_DATE=EndDate;
				mPromotion.IS_ACTIVE=IsActive;
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

		public DataTable SelectAllPromotions(int p_type,long p_Promtion_Id,bool p_Is_Active)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				uspSelectPROMOTIONS01 mPromotion= new uspSelectPROMOTIONS01();
				mPromotion.Connection = mConnection;
				mPromotion.type = p_type;
				mPromotion.PROMOTION_ID = p_Promtion_Id;
				mPromotion.IS_ACTIVE = p_Is_Active; 
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

		public string Active_UnActivePromotion(int p_type,long p_Promtion_Id,bool p_Is_Active)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				uspSelectPROMOTIONS01 mPromotion= new uspSelectPROMOTIONS01();
				mPromotion.Connection = mConnection;
				mPromotion.type = p_type;
				mPromotion.PROMOTION_ID = p_Promtion_Id;
				mPromotion.IS_ACTIVE = p_Is_Active; 
				mPromotion.ExecuteTable();
				return "Record Save";
				
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
		public DataTable GetPromotionDistributors( long p_promotionId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
			
				spSelectPROMOTION_FOR mSelectPromotionFor = new spSelectPROMOTION_FOR();
				mSelectPromotionFor.ASSIGNED_DISTRIBUTOR_ID = Constants.IntNullValue;
				mSelectPromotionFor.Connection = mConnection;
				mSelectPromotionFor.DISTRIBUTOR_ID = Configuration.DistributorId; 
				mSelectPromotionFor.PROMOTION_FOR_ID = Constants.LongNullValue;
				mSelectPromotionFor.PROMOTION_ID = p_promotionId;
				mSelectPromotionFor.SCHEME_ID = Constants.IntNullValue;
				DataTable dt = mSelectPromotionFor.ExecuteTable();
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

		public DataTable GetPromotionCustomerType( long p_promotionId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spSelectPROMOTION_CUSTOMER_TYPE mPromotionCustomerType = new spSelectPROMOTION_CUSTOMER_TYPE();
				mPromotionCustomerType.Connection = mConnection;
				mPromotionCustomerType.CUSTOMER_TYPE_ID = Constants.IntNullValue;
                mPromotionCustomerType.DISTRIBUTOR_ID = Configuration.DistributorId;
				mPromotionCustomerType.PROMOTION_CUSTOMER_TYPE_ID = Constants.LongNullValue;
				mPromotionCustomerType.PROMOTION_ID = p_promotionId;
				mPromotionCustomerType.SCHEME_ID = Constants.IntNullValue;
				DataTable dt = mPromotionCustomerType.ExecuteTable();
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
        public DataTable GetPromotionCustomerVolumeClass(long p_promotionId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectPROMOTION_CUSTOMER_VOLUMECLASS mPromotionCustomerType = new spSelectPROMOTION_CUSTOMER_VOLUMECLASS(); 
                mPromotionCustomerType.Connection = mConnection;
                mPromotionCustomerType.PROMOTION_ID = p_promotionId;
                DataTable dt = mPromotionCustomerType.ExecuteTable();
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
		
        #endregion
	}
}
