using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for LegendController.
	/// </summary>
	public class LegendController
	{
		#region Constructor
		public LegendController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		
		#region Public Methods


		public DataTable SelectLegend(int p_Legend_Id,bool p_Is_Active,DateTime p_Time_Stamp,DateTime p_Lastupdate_Date,int p_User_Id,int p_Legend_Type_Id,string p_Legend_Description,string p_Legend_Name) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectLEGEND mLegend = new spSelectLEGEND();
				mLegend.Connection = mConnection;							

				mLegend.LEGEND_ID=p_Legend_Id;
				mLegend.LEGEND_NAME=p_Legend_Name;
				mLegend.LEGEND_TYPE_ID=p_Legend_Type_Id;
				mLegend.LEGEND_DESCRIPTION=p_Legend_Description;
				mLegend.USER_ID=p_User_Id;
				mLegend.IS_ACTIVE = p_Is_Active;
				mLegend.TIMESTAMP = Constants.DateNullValue;
				mLegend.LAST_UPDATE_DATE = Constants.DateNullValue;
							                
				DataTable dt = mLegend.ExecuteTable();
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


		public DataTable SelectLegendInfo(int p_Legend_Id,bool p_Is_Active,DateTime p_Time_Stamp,DateTime p_Lastupdate_Date,int p_User_Id,int p_Legend_Type_Id,string p_Legend_Description,string p_Legend_Name) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectLEGENDInfo mLegend = new uspSelectLEGENDInfo();
				mLegend.Connection = mConnection;							

				mLegend.LEGEND_ID=p_Legend_Id;
				mLegend.LEGEND_NAME=p_Legend_Name;
				mLegend.LEGEND_TYPE_ID=p_Legend_Type_Id;
				mLegend.LEGEND_DESCRIPTION=p_Legend_Description;
				mLegend.USER_ID=p_User_Id;
				mLegend.IS_ACTIVE = p_Is_Active;
				mLegend.TIMESTAMP = Constants.DateNullValue;
				mLegend.LAST_UPDATE_DATE = Constants.DateNullValue;
							                
				DataTable dt = mLegend.ExecuteTable();
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


		public string InsertLegend(bool p_Is_Active,DateTime p_Time_Stamp,int p_User_Id,int p_Legend_Type_Id,string p_Legend_Description,string p_Legend_Name) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertLEGEND mLegend = new spInsertLEGEND();
				mLegend.Connection = mConnection;
				
				mLegend.LEGEND_NAME=p_Legend_Name;
				mLegend.LEGEND_TYPE_ID=p_Legend_Type_Id;
				mLegend.LEGEND_DESCRIPTION=p_Legend_Description;
				mLegend.USER_ID=p_User_Id;
				mLegend.IS_ACTIVE = p_Is_Active;
				mLegend.TIMESTAMP = p_Time_Stamp;
				mLegend.LAST_UPDATE_DATE = Constants.DateNullValue;
			
								                
				mLegend.ExecuteQuery();
				return mLegend.LEGEND_ID.ToString();
				
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


		public string UpdateLegend(int p_Legend_Id,bool p_Is_Active,DateTime p_Time_Stamp,int p_User_Id,int p_Legend_Type_Id,DateTime p_Lastupdate_Date,string p_Legend_Description,string p_Legend_Name) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateLEGEND mLegend = new spUpdateLEGEND();
				mLegend.Connection = mConnection;
				
				mLegend.LEGEND_ID=p_Legend_Id;
				mLegend.LEGEND_NAME=p_Legend_Name;
				mLegend.LEGEND_TYPE_ID=p_Legend_Type_Id;
				mLegend.LEGEND_DESCRIPTION=p_Legend_Description;
				mLegend.USER_ID=p_User_Id;
				mLegend.IS_ACTIVE = p_Is_Active;
				mLegend.TIMESTAMP = p_Time_Stamp;
				mLegend.LAST_UPDATE_DATE = p_Lastupdate_Date;
				
				
				                
				mLegend.ExecuteQuery();
				return mLegend.LEGEND_ID.ToString();
				
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


		public string DeleteLegend(int p_Legend_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spDeleteLEGEND mLegend = new spDeleteLEGEND();
				mLegend.Connection = mConnection;
				
				mLegend.LEGEND_ID=p_Legend_Id;
				                
				mLegend.ExecuteQuery();
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

		public DataTable SelectLegends(int p_Legend_Type_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectLEGEND mLegend = new spSelectLEGEND();
				mLegend.Connection = mConnection;
				
				mLegend.LEGEND_ID=Constants.IntNullValue;
				mLegend.LEGEND_TYPE_ID=p_Legend_Type_Id;
				mLegend.USER_ID=Constants.IntNullValue;
				mLegend.IS_ACTIVE = true;
				mLegend.TIMESTAMP = Constants.DateNullValue;
				mLegend.LAST_UPDATE_DATE = Constants.DateNullValue;
								                
				DataTable dt = mLegend.ExecuteTable();
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
