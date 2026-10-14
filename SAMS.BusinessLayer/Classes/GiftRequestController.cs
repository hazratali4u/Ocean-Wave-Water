using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for GiftRequestController.
	/// </summary>
	public class GiftRequestController
	{
		#region Constructor
		public GiftRequestController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		
		#region Public Methods


		

		public double CalculateLoyaltyPoints(int p_TLP_PERSON_ID, DateTime p_DATE_FROM, DateTime p_DATE_TO) 
		{
			IDbConnection mConnection = null;

			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				uspLoyatyPointsCalculateFromTo  mLoyaltyPoints = new uspLoyatyPointsCalculateFromTo();
				mLoyaltyPoints.Connection = mConnection;
			
				mLoyaltyPoints.TLP_PERSON_ID = p_TLP_PERSON_ID;
				mLoyaltyPoints.DATE_FROM = p_DATE_FROM;
				mLoyaltyPoints.DATE_TO = p_DATE_TO;
								            
				mLoyaltyPoints.ExecuteQuery();

				return Convert.ToDouble(mLoyaltyPoints.TOTAL_POINTS);

			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return -1;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		
		}


		public DataTable SelectAllGiftRequest()
		{
			return SelectGiftRequest(Constants.IntNullValue,Configuration.DistributorId,Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, Constants.DecimalNullValue, Constants.DecimalNullValue, Constants.DecimalNullValue, Constants.IntNullValue, false);
		}

		public DataTable SelectGiftRequestByTLPPersonId(int p_TLP_PERSON_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectGIFT_REQUESTByTLPPersonId mGiftRequest = new uspSelectGIFT_REQUESTByTLPPersonId();
				mGiftRequest.Connection = mConnection;							

				mGiftRequest.TLP_PERSON_ID = p_TLP_PERSON_ID;
							                
				DataTable dt = mGiftRequest.ExecuteTable();
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

		public DataTable SelectGiftRequestById(int p_GIFT_REQUEST_ID)
		{
			return SelectGiftRequest(p_GIFT_REQUEST_ID,Configuration.DistributorId,Constants.IntNullValue, Constants.DateNullValue, Constants.DateNullValue, Constants.DecimalNullValue, Constants.DecimalNullValue, Constants.DecimalNullValue, Constants.IntNullValue, false);
		}

		public DataTable SelectGiftRequest(int p_GIFT_REQUEST_ID, int p_DISTRIBUTOR_ID, int p_TLP_PERSON_ID, DateTime p_REQUEST_DATE, DateTime p_UPTO_DATE, decimal p_UPTO_DATE_POINTS, decimal p_GIFT_POINTS, decimal p_BALANCE_POINTS, int p_REQUEST_STATUS, bool p_IS_DELETED) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectGIFT_REQUEST mGiftRequest = new spSelectGIFT_REQUEST();
				mGiftRequest.Connection = mConnection;							

				mGiftRequest.GIFT_REQUEST_ID = p_GIFT_REQUEST_ID;
				mGiftRequest.TLP_PERSON_ID = p_TLP_PERSON_ID;
				mGiftRequest.REQUEST_DATE = p_REQUEST_DATE;
				mGiftRequest.UPTO_DATE = p_UPTO_DATE;
				mGiftRequest.UPTO_DATE_POINTS = p_UPTO_DATE_POINTS;
				mGiftRequest.GIFT_POINTS  = p_GIFT_POINTS;
				mGiftRequest.BALANCE_POINTS  = p_BALANCE_POINTS;
				mGiftRequest.REQUEST_STATUS  = p_REQUEST_STATUS;
				mGiftRequest.IS_DELETED = p_IS_DELETED;
				mGiftRequest.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mGiftRequest.USER_ID = Constants.IntNullValue;
				mGiftRequest.IS_ACTIVE = true;
				mGiftRequest.TIME_STAMP = Constants.DateNullValue;
				mGiftRequest.LASTUPDATE_DATE = Constants.DateNullValue;
							                
				DataTable dt = mGiftRequest.ExecuteTable();
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

		public int InsertGiftRequest(int p_DISTRIBUTOR_ID, int p_TLP_PERSON_ID, DateTime p_REQUEST_DATE, DateTime p_UPTO_DATE, decimal p_UPTO_DATE_POINTS, decimal p_GIFT_POINTS, decimal p_BALANCE_POINTS, int p_REQUEST_STATUS, bool p_IS_DELETED, DataTable dtGiftRequestDetail) 
		{
			IDbConnection mConnection = null;
			IDbTransaction mTransaction = null;

			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				mTransaction = ProviderFactory.GetTransaction(mConnection);

				spInsertGIFT_REQUEST mGiftRequest = new spInsertGIFT_REQUEST();
				mGiftRequest.Connection = mConnection;
				mGiftRequest.Transaction = mTransaction;
				
				mGiftRequest.TLP_PERSON_ID = p_TLP_PERSON_ID;
				mGiftRequest.REQUEST_DATE = p_REQUEST_DATE;
				mGiftRequest.UPTO_DATE = p_UPTO_DATE;
				mGiftRequest.UPTO_DATE_POINTS = p_UPTO_DATE_POINTS;
				mGiftRequest.GIFT_POINTS  = p_GIFT_POINTS;
				mGiftRequest.BALANCE_POINTS  = p_BALANCE_POINTS;
				mGiftRequest.REQUEST_STATUS  = p_REQUEST_STATUS;
				mGiftRequest.IS_DELETED = p_IS_DELETED;
				mGiftRequest.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mGiftRequest.USER_ID = Configuration.UserID;
				mGiftRequest.IS_ACTIVE = true;
				mGiftRequest.TIME_STAMP = DateTime.Now;
				mGiftRequest.LASTUPDATE_DATE = DateTime.Now;
								                
				mGiftRequest.ExecuteQuery();

				spInsertGIFT_REQUEST_DETAIL mGiftRequestDetail = new spInsertGIFT_REQUEST_DETAIL();
				mGiftRequestDetail.Connection = mConnection;
				mGiftRequestDetail.Transaction = mTransaction;

				foreach(DataRow dr in dtGiftRequestDetail.Rows)
				{
					mGiftRequestDetail.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
					mGiftRequestDetail.GIFT_REQUEST_ID = mGiftRequest.GIFT_REQUEST_ID;
					mGiftRequestDetail.GIFT_ID = Convert.ToInt32(dr["GIFT_ID"]);
					mGiftRequestDetail.GIFT_POINTS = Convert.ToDecimal(dr["GIFT_POINTS"]);
					mGiftRequestDetail.GIFT_STATUS = Convert.ToInt32(dr["GIFT_STATUS"]);
					mGiftRequestDetail.QUANTITY = Convert.ToInt32(dr["QUANTITY"]);
					mGiftRequestDetail.TOTAL_GIFT_POINTS = Convert.ToInt32(dr["TOTAL_GIFT_POINTS"]);

					mGiftRequestDetail.ExecuteQuery();
				}

				uspUpdateTLPPersonPoints mUpdPoints = new uspUpdateTLPPersonPoints();
				mUpdPoints.Connection = mConnection;
				mUpdPoints.Transaction = mTransaction;

				mUpdPoints.TLP_PERSON_ID = p_TLP_PERSON_ID;
				mUpdPoints.BALANCE_POINTS  = p_BALANCE_POINTS;
				mUpdPoints.USED_POINTS = p_GIFT_POINTS;

				mUpdPoints.ExecuteQuery();	
		
				mTransaction.Commit();

				return mGiftRequest.GIFT_REQUEST_ID;

			}
			catch(Exception exp)
			{
				mTransaction.Rollback();
				ExceptionPublisher.PublishException(exp);				
				return -1;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}

		public void UpdateGiftRequest(int p_GIFT_REQUEST_ID, int p_DISTRIBUTOR_ID, int p_TLP_PERSON_ID, DateTime p_REQUEST_DATE, DateTime p_UPTO_DATE, decimal p_UPTO_DATE_POINTS, decimal p_GIFT_POINTS, decimal p_BALANCE_POINTS, int p_REQUEST_STATUS, bool p_IS_DELETED) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateGIFT_REQUEST mGiftRequest = new spUpdateGIFT_REQUEST();
				mGiftRequest.Connection = mConnection;
				
				mGiftRequest.GIFT_REQUEST_ID = p_GIFT_REQUEST_ID;
				mGiftRequest.TLP_PERSON_ID = p_TLP_PERSON_ID;
				mGiftRequest.REQUEST_DATE = p_REQUEST_DATE;
				mGiftRequest.UPTO_DATE = p_UPTO_DATE;
				mGiftRequest.UPTO_DATE_POINTS = p_UPTO_DATE_POINTS;
				mGiftRequest.GIFT_POINTS  = p_GIFT_POINTS;
				mGiftRequest.BALANCE_POINTS  = p_BALANCE_POINTS;
				mGiftRequest.REQUEST_STATUS  = p_REQUEST_STATUS;
				mGiftRequest.IS_DELETED = p_IS_DELETED;
				mGiftRequest.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mGiftRequest.USER_ID = Configuration.UserID;
				mGiftRequest.IS_ACTIVE = true;
				mGiftRequest.TIME_STAMP = DateTime.Now;
				mGiftRequest.LASTUPDATE_DATE = DateTime.Now;
									                
				mGiftRequest.ExecuteQuery();				
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

		public bool UpdateGiftRequestStatus(int p_GIFT_REQUEST_ID, int p_REQUEST_STATUS, DataTable dtGiftRequestDetail) 
		{
			IDbConnection mConnection = null;
			IDbTransaction mTransaction = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				mTransaction = ProviderFactory.GetTransaction(mConnection);

				uspUpdateGIFT_REQUEST_STATUS mGiftRequest = new uspUpdateGIFT_REQUEST_STATUS();
				mGiftRequest.Connection = mConnection;
				mGiftRequest.Transaction = mTransaction;
							
				mGiftRequest.GIFT_REQUEST_ID = p_GIFT_REQUEST_ID;
				mGiftRequest.REQUEST_STATUS  = p_REQUEST_STATUS;
				mGiftRequest.DISTRIBUTOR_ID = Configuration.DistributorId;
				mGiftRequest.USER_ID = Configuration.UserID;
				mGiftRequest.LASTUPDATE_DATE = DateTime.Now;
									                
				mGiftRequest.ExecuteQuery();				

				uspUpdateGIFT_REQUEST_DETAIL_STATUS mGiftRequestDetail = new uspUpdateGIFT_REQUEST_DETAIL_STATUS();
				mGiftRequestDetail.Connection = mConnection;
				mGiftRequestDetail.Transaction = mTransaction;
				
				mGiftRequestDetail.GIFT_REQUEST_ID = p_GIFT_REQUEST_ID;
				mGiftRequestDetail.DISTRIBUTOR_ID = Configuration.DistributorId;


				if(p_REQUEST_STATUS == 2)
				{
					mGiftRequestDetail.REQUEST_STATUS  = p_REQUEST_STATUS;
					mGiftRequestDetail.GIFT_REQUEST_DETAIL_ID = Constants.IntNullValue;
					mGiftRequestDetail.ExecuteQuery();
				}
				else
				{
					foreach(DataRow dr in dtGiftRequestDetail.Rows)
					{
						mGiftRequestDetail.GIFT_REQUEST_DETAIL_ID = Convert.ToInt32(dr["GIFT_REQUEST_DETAIL_ID"]);
						if(Convert.ToBoolean(dr["SELECTED"]) == true)
						{
							mGiftRequestDetail.REQUEST_STATUS  = p_REQUEST_STATUS;							
						}
						else
						{
							mGiftRequestDetail.REQUEST_STATUS  = 2;
						}
						mGiftRequestDetail.ExecuteQuery();
					}
				}

				mTransaction.Commit();

				return true;
			}
			catch(Exception exp)
			{
				mTransaction.Rollback();
				ExceptionPublisher.PublishException(exp);				
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

			return false;
			
		}

		public string DeleteGiftRequest(int p_GiftRequest_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spDeleteGIFT_REQUEST mGiftRequest = new spDeleteGIFT_REQUEST();
				mGiftRequest.Connection = mConnection;
				
				mGiftRequest.GIFT_REQUEST_ID=p_GiftRequest_Id;
				                
				mGiftRequest.ExecuteQuery();
				return "Record Deleted";
				
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

		public DataTable SelectGiftDetailRequestById(int p_DISTRIBUTOR_ID, int p_GIFT_REQUEST_ID)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				uspSelectGIFT_REQUEST_DETAILInfo mGiftRequest = new uspSelectGIFT_REQUEST_DETAILInfo();
				mGiftRequest.Connection = mConnection;							

				mGiftRequest.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mGiftRequest.GIFT_REQUEST_ID = p_GIFT_REQUEST_ID;
							                
				DataTable dt = mGiftRequest.ExecuteTable();
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

		public DataTable SelectGiftRequestDetail(int p_GIFT_REQUEST_DETAIL_ID, int p_DISTRIBUTOR_ID, int p_GIFT_REQUEST_ID, int p_GIFT_ID, decimal p_GIFT_POINTS, int p_GIFT_STATUS, int p_QUANTITY) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectGIFT_REQUEST_DETAIL mGiftRequest = new spSelectGIFT_REQUEST_DETAIL();
				mGiftRequest.Connection = mConnection;							

				mGiftRequest.GIFT_REQUEST_DETAIL_ID = p_GIFT_REQUEST_DETAIL_ID;
				mGiftRequest.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
				mGiftRequest.GIFT_REQUEST_ID = p_GIFT_REQUEST_ID;
				mGiftRequest.GIFT_ID = p_GIFT_ID;
				mGiftRequest.GIFT_POINTS = p_GIFT_POINTS;
				mGiftRequest.GIFT_STATUS = p_GIFT_STATUS;
				mGiftRequest.QUANTITY = p_QUANTITY;
							                
				DataTable dt = mGiftRequest.ExecuteTable();
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
