using System;
using System.Data;
using SAMS.DatabaseLayer.Classes;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for PromotionForAllController.
	/// </summary>
	public class PromotionForAllController
	{
		
		#region Constructor
		public PromotionForAllController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods
		public string InsertPromotionDist(long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_Assigned_Dist_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertPROMOTION_FOR mPromotion = new spInsertPROMOTION_FOR();
				mPromotion.Connection = mConnection;

				mPromotion.PROMOTION_ID = p_Promotion_ID;
				mPromotion.DISTRIBUTOR_ID = p_Dist_ID;
				mPromotion.SCHEME_ID = p_Scheme_ID;
				mPromotion.ASSIGNED_DISTRIBUTOR_ID = p_Assigned_Dist_ID;

				mPromotion.ExecuteQuery();
				return mPromotion.PROMOTION_FOR_ID.ToString() ;
				
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

		public string UpdatePromotionDist(long p_Promotion_For_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_Assigned_Dist_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spUpdatePROMOTION_FOR mPromotion = new spUpdatePROMOTION_FOR();
				mPromotion.Connection = mConnection;

				mPromotion.PROMOTION_FOR_ID = p_Promotion_For_ID;
				mPromotion.PROMOTION_ID = p_Promotion_ID;
				mPromotion.DISTRIBUTOR_ID = p_Dist_ID;
				mPromotion.SCHEME_ID = p_Scheme_ID;
				mPromotion.ASSIGNED_DISTRIBUTOR_ID = p_Assigned_Dist_ID;

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

		public string DeletePromotionDist()
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

		public DataTable SelectPromotionDist(long p_Promotion_For_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_Assigned_Dist_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spSelectPROMOTION_FOR mPromotion = new spSelectPROMOTION_FOR();
				mPromotion.Connection = mConnection;
				
				mPromotion.PROMOTION_FOR_ID = p_Promotion_For_ID;
				mPromotion.PROMOTION_ID = p_Promotion_ID;
				mPromotion.DISTRIBUTOR_ID = p_Dist_ID;
				mPromotion.SCHEME_ID = p_Scheme_ID;
				mPromotion.ASSIGNED_DISTRIBUTOR_ID = p_Assigned_Dist_ID;
				
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


		public string InsertPromotionVolClass(long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_Customer_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertPROMOTION_CUSTOMER_VOLUMECLASS mPromotion = new spInsertPROMOTION_CUSTOMER_VOLUMECLASS();
                mPromotion.Connection = mConnection;

                mPromotion.SCHEME_ID = p_Scheme_ID;
                mPromotion.PROMOTION_ID = p_Promotion_ID;
                mPromotion.DISTRIBUTOR_ID = p_Dist_ID;
                mPromotion.CUSTOMER_VOLUMECLASS_ID = p_Customer_ID; 
                mPromotion.ExecuteQuery();
                return mPromotion.PROMOTION_VOLUMECLASS_ID.ToString(); 

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

		public string UpdatePromotionCust(long p_Promotion_For_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_Customer_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spUpdatePROMOTION_FOR_CUSTOMER mPromotion = new spUpdatePROMOTION_FOR_CUSTOMER();
				mPromotion.Connection = mConnection;

				mPromotion.PROMOTION_FOR_ID = p_Promotion_For_ID;
				mPromotion.PROMOTION_ID = p_Promotion_ID;
				mPromotion.DISTRIBUTOR_ID = p_Dist_ID;
				mPromotion.SCHEME_ID = p_Scheme_ID;
				mPromotion.CUSTOMER_ID = p_Customer_ID;


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

		public string DeletePromotionCust()
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

		public DataTable SelectPromotionCust(long p_Promotion_For_ID, long p_Promotion_ID, int p_Scheme_ID, int p_Dist_ID, int p_Customer_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spSelectPROMOTION_FOR_CUSTOMER mPromotion = new spSelectPROMOTION_FOR_CUSTOMER();
				mPromotion.Connection = mConnection;
				
				mPromotion.PROMOTION_FOR_ID = p_Promotion_For_ID;
				mPromotion.PROMOTION_ID = p_Promotion_ID;
				mPromotion.DISTRIBUTOR_ID = p_Dist_ID;
				mPromotion.SCHEME_ID = p_Scheme_ID;
				mPromotion.CUSTOMER_ID = p_Customer_ID;

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

		
		public string InsertPromotionCustType(long p_PROMOTION_ID, int p_DISTRIBUTOR_ID, int p_SCHEME_ID, int p_CUSTOMER_TYPE_ID )
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertPROMOTION_CUSTOMER_TYPE mPromotion = new spInsertPROMOTION_CUSTOMER_TYPE();
				mPromotion.Connection = mConnection;

				mPromotion.PROMOTION_ID = p_PROMOTION_ID;
				mPromotion.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mPromotion.SCHEME_ID = p_SCHEME_ID;
				mPromotion.CUSTOMER_TYPE_ID = p_CUSTOMER_TYPE_ID;

				mPromotion.ExecuteQuery();
				return mPromotion.PROMOTION_CUSTOMER_TYPE_ID.ToString() ;
				
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

		public string UpdatePromotionCustType(long p_PROMOTION_CUSTOMER_TYPE_ID ,long p_PROMOTION_ID, int p_DISTRIBUTOR_ID, int p_SCHEME_ID, int p_CUSTOMER_TYPE_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spUpdatePROMOTION_CUSTOMER_TYPE mPromotion = new spUpdatePROMOTION_CUSTOMER_TYPE();
				mPromotion.Connection = mConnection;

				mPromotion.PROMOTION_CUSTOMER_TYPE_ID  = p_PROMOTION_CUSTOMER_TYPE_ID;
				mPromotion.PROMOTION_ID = p_PROMOTION_ID;
				mPromotion.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mPromotion.SCHEME_ID = p_SCHEME_ID;
				mPromotion.CUSTOMER_TYPE_ID = p_CUSTOMER_TYPE_ID;


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

		public string DeletePromotionCustType()
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

		public DataTable SelectPromotionCustType(long p_PROMOTION_CUSTOMER_TYPE_ID ,long p_PROMOTION_ID, int p_DISTRIBUTOR_ID, int p_SCHEME_ID, int p_CUSTOMER_TYPE_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spSelectPROMOTION_CUSTOMER_TYPE mPromotion = new spSelectPROMOTION_CUSTOMER_TYPE();
				mPromotion.Connection = mConnection;
				
				mPromotion.PROMOTION_CUSTOMER_TYPE_ID  = p_PROMOTION_CUSTOMER_TYPE_ID;
				mPromotion.PROMOTION_ID = p_PROMOTION_ID;
				mPromotion.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mPromotion.SCHEME_ID = p_SCHEME_ID;
				mPromotion.CUSTOMER_TYPE_ID = p_CUSTOMER_TYPE_ID;


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
