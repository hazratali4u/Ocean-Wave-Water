using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for DistributorAreaController.
	/// </summary>
	public class DistributorAreaController
	{
		public DistributorAreaController()
		{
			//
			// TODO: Add constructor logic here
			//
		}


        public DataTable SelectDist_Area(long p_Area_Id, DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Distributor_Id, int p_Territory_Id, string p_Area_Name, string p_Area_Code)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR_AREA mDistArea = new spSelectDISTRIBUTOR_AREA();
				mDistArea.Connection = mConnection;
                mDistArea.AREA_CODE=p_Area_Code;
				mDistArea.AREA_ID=p_Area_Id;
				mDistArea.AREA_NAME=p_Area_Name;
				mDistArea.DISTRIBUTOR_ID=p_Distributor_Id;
				mDistArea.LASTUPDATE_DATE=p_LastUpdate_Date;
				mDistArea.TOWN_ID=p_Territory_Id;
						
				DataTable dt = mDistArea.ExecuteTable();
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
        public DataTable SelectDistALL_Area(long p_Area_Id, DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Distributor_Id, int p_Territory_Id, string p_Area_Name, string p_Area_Code)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectAllDISTRIBUTOR_AREA mDistArea = new spSelectAllDISTRIBUTOR_AREA();
                mDistArea.Connection = mConnection;
                mDistArea.AREA_CODE = p_Area_Code;
                mDistArea.AREA_ID = p_Area_Id;
                mDistArea.AREA_NAME = p_Area_Name;
                mDistArea.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistArea.LASTUPDATE_DATE = p_LastUpdate_Date;
                mDistArea.TOWN_ID = p_Territory_Id;

                DataTable dt = mDistArea.ExecuteTable();
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
        public bool insertDisct_Area(long p_Area_Id,bool p_IsActive,int p_Distributor_Id, int p_Territory_Id, string p_Area_Name, string p_Area_Code)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertDISTRIBUTOR_AREA mDistArea = new spInsertDISTRIBUTOR_AREA();
                mDistArea.Connection = mConnection;
                mDistArea.AREA_ID = p_Area_Id;
                mDistArea.AREA_CODE = p_Area_Code;
                mDistArea.AREA_NAME = p_Area_Name;
                mDistArea.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistArea.LASTUPDATE_DATE = System.DateTime.Today;
                mDistArea.TIME_STAMP = System.DateTime.Today; 
                mDistArea.TOWN_ID = p_Territory_Id;
                mDistArea.IS_ACTIVE = p_IsActive;
                bool BValue  = mDistArea.ExecuteQuery();
                return BValue;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        public bool UpdateDisct_Area(long p_Area_Id, bool p_IsActive, DateTime p_Time_Stamp, DateTime p_LastUpdate_Date, int p_Distributor_Id, int p_Territory_Id, string p_Area_Name, string p_Area_Code)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateDISTRIBUTOR_AREA mDistArea = new spUpdateDISTRIBUTOR_AREA();
                mDistArea.Connection = mConnection;
                mDistArea.AREA_ID = p_Area_Id;
                mDistArea.AREA_CODE = p_Area_Code;
                mDistArea.AREA_NAME = p_Area_Name;
                mDistArea.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistArea.LASTUPDATE_DATE = p_LastUpdate_Date;
                mDistArea.TOWN_ID = p_Territory_Id;
                mDistArea.IS_ACTIVE = p_IsActive;
                bool BValue = mDistArea.ExecuteQuery();
                return BValue;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
		public DataTable SelectCust_Area(long p_Area_Id,int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectCustAreaProximity mCustArea = new uspSelectCustAreaProximity();
				mCustArea.Connection = mConnection;

				mCustArea.AREA_ID=p_Area_Id;
				mCustArea.DISTRIBUTOR_ID=p_Distributor_Id;
								
				DataTable dt = mCustArea.ExecuteTable();
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
        public DataTable SelectCust_By_Type_Area(long p_Area_Id,int p_Distributor_Id,string strCustomerTypes)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectCustByTypeArea mCustArea = new uspSelectCustByTypeArea();
				mCustArea.Connection = mConnection;

				mCustArea.AREA_ID=p_Area_Id;
				mCustArea.DISTRIBUTOR_ID=p_Distributor_Id;
				mCustArea.CUSTOMER_TYPES = strCustomerTypes;
				DataTable dt = mCustArea.ExecuteTable();
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

		public DataTable SelectCust_By_Type_Area(string strAreas, int p_Distributor_Id,string strCustomerTypes)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectCustomerByTypeArea mCustArea = new uspSelectCustomerByTypeArea();
				mCustArea.Connection = mConnection;

				mCustArea.AREA_ID=strAreas;
				mCustArea.DISTRIBUTOR_ID=p_Distributor_Id;
				mCustArea.CUSTOMER_TYPES = strCustomerTypes;
				DataTable dt = mCustArea.ExecuteTable();
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

		public DataTable SelectAreaByTown(string strTown, int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectTownArea mArea = new uspSelectTownArea();
				mArea.Connection = mConnection;

				mArea.TERRITORIES=strTown;
				mArea.DISTRIBUTOR_ID=p_Distributor_Id;
				DataTable dt = mArea.ExecuteTable();
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

	    public DataTable SelectDistributorArea(int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR_AREA mDistArea = new spSelectDISTRIBUTOR_AREA();
				mDistArea.Connection = mConnection;

				mDistArea.AREA_CODE= null;
				mDistArea.AREA_ID= Constants.LongNullValue ;
				mDistArea.AREA_NAME= null ;
				mDistArea.DISTRIBUTOR_ID=p_Distributor_Id;
				mDistArea.LASTUPDATE_DATE = Constants.DateNullValue ;
											
				DataTable dt = mDistArea.ExecuteTable();
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
		public long GetAreaID(int p_Distributor_Id,string p_Area_Code)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectDISTRIBUTOR_AREA mDistArea = new spSelectDISTRIBUTOR_AREA();
				mDistArea.Connection = mConnection;

				mDistArea.AREA_CODE=p_Area_Code;
				mDistArea.AREA_ID=Constants.LongNullValue;
				mDistArea.AREA_NAME=null;
				mDistArea.DISTRIBUTOR_ID=p_Distributor_Id;
				mDistArea.LASTUPDATE_DATE=Constants.DateNullValue;
				mDistArea.TIME_STAMP=Constants.DateNullValue;
				
				DataTable dt = mDistArea.ExecuteTable();
				if(dt.Rows.Count>0)
					return long.Parse(dt.Rows[0]["AREA_ID"].ToString());
				return 0;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return 0;
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
