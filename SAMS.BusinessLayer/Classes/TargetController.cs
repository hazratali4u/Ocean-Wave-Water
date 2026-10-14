using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for TargetController.
	/// </summary>
	public class TargetController
	{
		public TargetController()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public DataTable SelectTarget(DateTime p_TargetMonth, int p_Target_For_Type_Id, int p_Target_For_Id, int p_Distributor_Id, int p_PrincipalId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectTARGETInfo mTarget = new uspSelectTARGETInfo();
				mTarget.Connection = mConnection;

				mTarget.TARGET_MONTH = p_TargetMonth;
				mTarget.TARGET_FOR_TYPE_ID = p_Target_For_Type_Id;
				mTarget.TARGET_FOR_ID = p_Target_For_Id;
				mTarget.DISTRIBUTOR_ID = p_Distributor_Id;
                mTarget.PRINCIPAL_ID = p_PrincipalId; 
				
				DataTable dt = mTarget.ExecuteTable();
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

        public string UpdateTarget(long p_TargetId, int p_Distributor, decimal p_SKUUnitPrice, int p_Qty, bool p_IS_ACTIVE)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                spUpdateTARGET mTarget = new spUpdateTARGET();
                mTarget.Connection = mConnection;
                mTarget.TARGET_ID = p_TargetId;
                mTarget.DISTRIBUTOR_ID = p_Distributor;
                mTarget.TARGET_MONTH = Constants.DateNullValue;
                mTarget.TARGET_FOR_TYPE_ID = Constants.IntNullValue;
                mTarget.TARGET_FOR_ID = Constants.LongNullValue;
                mTarget.SKU_ID = Constants.LongNullValue;
                mTarget.UNIT_PRICE = p_SKUUnitPrice;
                mTarget.QUANTITY = p_Qty;
                mTarget.IS_ACTIVE = p_IS_ACTIVE; 
                mTarget.ExecuteQuery();

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


        public string InsertTarget(int p_DistributorId, DateTime p_TargetMonth, int p_TargetForTypeId, int p_TargetForId, int p_SKUId, decimal p_SKUUnitPrice, int p_Qty, int p_PrincipalId, int p_UserId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                spInsertTARGET mTarget = new spInsertTARGET();
                mTarget.Connection = mConnection;
                mTarget.DISTRIBUTOR_ID = p_DistributorId;
                mTarget.TARGET_MONTH = p_TargetMonth;
                mTarget.TARGET_FOR_TYPE_ID = p_TargetForTypeId;
                mTarget.TARGET_FOR_ID = p_TargetForId;
                mTarget.SKU_ID = p_SKUId;
                mTarget.UNIT_PRICE = p_SKUUnitPrice;
                mTarget.QUANTITY = p_Qty;
                mTarget.USER_ID = p_UserId;
                mTarget.PRINCIPAL_ID = p_PrincipalId;
                mTarget.IS_ACTIVE = true;  
                mTarget.ExecuteQuery();
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

		

		public bool CalculateTargetsAchieved(DateTime p_TargetMonth, DateTime p_Today, int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspCalculateTargetsAchieved mTarget = new uspCalculateTargetsAchieved();
				mTarget.Connection = mConnection;

				mTarget.TARGET_MONTH = p_TargetMonth;
				mTarget.TODAY = p_Today;
				mTarget.DISTRIBUTOR_ID = p_Distributor_Id;
				
				mTarget.ExecuteQuery();								

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
	}
}
