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
	/// <date>23-Aug-2007</date>
	/// </summary>
	public class SchemeController
	{
		#region Constructors
		public SchemeController()
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
		public string InsertScheme(int p_Distributor_Id,string p_Scheme_Code,string p_Scheme_Desc,DateTime p_Scheme_Date)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertSCHEME mScheme = new spInsertSCHEME();
				mScheme.Connection = mConnection;

				mScheme.DISTRIBUTOR_ID = p_Distributor_Id;
				mScheme.SCHEME_CODE = p_Scheme_Code;
				mScheme.SCHEME_DESC = p_Scheme_Desc;
				mScheme.SCHEME_DATE = p_Scheme_Date;

				mScheme.ExecuteQuery();
				return mScheme.SCHEME_ID.ToString() ;
				
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

		public string UpdateScheme(int p_Scheme_Id, int p_Distributor_Id,string p_Scheme_Code,string p_Scheme_Desc,DateTime p_Scheme_Date)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spUpdateSCHEME mScheme = new spUpdateSCHEME();
				mScheme.Connection = mConnection;

				mScheme.SCHEME_ID = p_Scheme_Id;
				mScheme.DISTRIBUTOR_ID = p_Distributor_Id;
				mScheme.SCHEME_CODE = p_Scheme_Code;
				mScheme.SCHEME_DESC = p_Scheme_Desc;
				mScheme.SCHEME_DATE = p_Scheme_Date;

				mScheme.ExecuteQuery();
				
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

		public string DeleteScheme()
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

		public DataTable SelectScheme(int p_Scheme_Id, int p_Distributor_Id,string p_Scheme_Code,string p_Scheme_Desc,DateTime p_Scheme_Date)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spSelectSCHEME mScheme = new spSelectSCHEME();
				mScheme.Connection = mConnection;

				mScheme.SCHEME_ID = p_Scheme_Id;
				mScheme.DISTRIBUTOR_ID = p_Distributor_Id;
				mScheme.SCHEME_CODE = p_Scheme_Code;
				mScheme.SCHEME_DESC = p_Scheme_Desc;
				mScheme.SCHEME_DATE = p_Scheme_Date;
				
				DataTable dt = mScheme.ExecuteTable();
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

        public DataTable SelectPromotion(string P_start, string P_end, int  P_UserId,bool p_PActive)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                uspSelectPromotionsScheme mspscheme = new uspSelectPromotionsScheme();
                mspscheme.Connection = mConnection;
                mspscheme.FromDate = DateTime.Parse(P_start);
                mspscheme.To_Date = DateTime.Parse(P_end);
                mspscheme.USER_ID = P_UserId;
                mspscheme.IS_ACTIVE = p_PActive;  
                DataTable dt = mspscheme.ExecuteTable();
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
