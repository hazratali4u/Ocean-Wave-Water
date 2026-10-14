using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// SAMSCodesController
	/// <author></author>
	/// <date>02-08-2007</date>
	/// </summary>
	public class SlabsController
	{
		
		#region Constructors
		public SlabsController()
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
		public string InsertSlabs(int p_DesignatioinId, string p_SlabName , decimal p_LCA, decimal p_LOS, decimal p_OS, decimal p_FARE, decimal p_Maintenence, decimal p_Holiday)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertTA_DA_SLABS  mSlabs = new spInsertTA_DA_SLABS();
				mSlabs.Connection = mConnection;
				
				mSlabs.DESIGNATION_ID = p_DesignatioinId;
				mSlabs.SLAB_NAME = p_SlabName;
				mSlabs.LCA = p_LCA;
				mSlabs.LOS = p_LOS;
				mSlabs.OS = p_OS;
				mSlabs.FARE = p_FARE;
				mSlabs.MAINTENENCE = p_Maintenence;
				mSlabs.HOLIDAY = p_Holiday;
                
				mSlabs.ExecuteQuery();
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

		public string UpdateSlabs(int p_TADASlabsId, int p_DesignatioinId, string p_SlabName , decimal p_LCA, decimal p_LOS, decimal p_OS, decimal p_FARE, decimal p_Maintenence, decimal p_Holiday)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spUpdateTA_DA_SLABS mSlabs = new spUpdateTA_DA_SLABS();
				mSlabs.Connection = mConnection;

				mSlabs.TA_DA_SLAB_ID = p_TADASlabsId;
				mSlabs.DESIGNATION_ID = p_DesignatioinId;
				mSlabs.SLAB_NAME = p_SlabName;
				mSlabs.LCA = p_LCA;
				mSlabs.LOS = p_LOS;
				mSlabs.OS = p_OS;
				mSlabs.FARE = p_FARE;
				mSlabs.MAINTENENCE = p_Maintenence;
				mSlabs.HOLIDAY = p_Holiday;
				
				mSlabs.ExecuteQuery();				
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

		public string DeleteSlabs(int p_TADASlabsId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spDeleteTA_DA_SLABS mSlabs = new spDeleteTA_DA_SLABS();
				mSlabs.Connection = mConnection;

				mSlabs.TA_DA_SLAB_ID = p_TADASlabsId;
				
				
				mSlabs.ExecuteQuery();				
				return "Record Deleted";
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
		public DataTable SelectSlabs(int p_TADASlabsId, int p_DesignatioinId, string p_SlabName , decimal p_LCA, decimal p_LOS, decimal p_OS, decimal p_FARE, decimal p_Maintenence, decimal p_Holiday)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spSelectTA_DA_SLABS mSlabs = new spSelectTA_DA_SLABS();
				mSlabs.Connection = mConnection;

				mSlabs.TA_DA_SLAB_ID = p_TADASlabsId;
				mSlabs.DESIGNATION_ID = p_DesignatioinId;
				mSlabs.SLAB_NAME = p_SlabName;
				mSlabs.LCA  = p_LCA;
				mSlabs.LOS = p_LOS;
				mSlabs.OS = p_OS;
				mSlabs.FARE = p_FARE;
				mSlabs.MAINTENENCE = p_Maintenence;
				mSlabs.HOLIDAY = p_Holiday;
				
				DataTable dt = mSlabs.ExecuteTable();
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

		public DataTable SelectSlabsInfo(int p_TADASlabsId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				uspSelectTADASlabInfo mSlabs = new uspSelectTADASlabInfo();
				mSlabs.Connection = mConnection;

				mSlabs.TA_DA_SLAB_ID = p_TADASlabsId;
				
				DataTable dt = mSlabs.ExecuteTable();
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
