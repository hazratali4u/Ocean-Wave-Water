using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for SETTINGS_TABLE_Controller.
	/// </summary>
	public class SETTINGS_TABLE_Controller
	{
		#region Constructor
		public SETTINGS_TABLE_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public methods
		public DataTable Select_SETTINGS_TABLE(string p_TableName,string FeildName,int DistributorId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectSETTINGS_TABLE selectdata = new uspSelectSETTINGS_TABLE();
				selectdata.Connection = mConnection;
                selectdata.TableName = p_TableName;
                selectdata.FieldName = FeildName;
                selectdata.DistributorId = DistributorId;  
				DataTable dtSAMStransfermaster = selectdata.ExecuteTable();
				return dtSAMStransfermaster;
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


		public bool Update_SETTINGS_TABLE(string code,string desc,int id,long val)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateSETTINGS_TABLE selectdata = new spUpdateSETTINGS_TABLE();
				selectdata.Connection = mConnection;
				selectdata.CODE = code;
				selectdata.DESC = desc;
				selectdata.SETTING_ID = id;
				selectdata.VALUE = val;

				bool b = selectdata.ExecuteQuery();
				return b;
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

		public long GetAutoNumber(string p_code,int p_type,long p_value)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectSETTINGS_TABLE01 selectdata = new uspSelectSETTINGS_TABLE01();
				selectdata.Connection = mConnection;
				selectdata.Code = p_code;
				selectdata.type = p_type;
				selectdata.value =  p_value;
				DataTable dtSAMStransfermaster = selectdata.ExecuteTable();

				int Current  = int.Parse(dtSAMStransfermaster.Rows[0]["VALUE"].ToString()) + 1;
				
				return Current;
				
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

		public string GetAutoCode(string p_code,int p_type,long p_value)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectSETTINGS_TABLE01 selectdata = new uspSelectSETTINGS_TABLE01();
				selectdata.Connection = mConnection;
				selectdata.Code = p_code;
				selectdata.type = p_type;
				selectdata.value =  p_value;
				DataTable dtSAMStransfermaster = selectdata.ExecuteTable();

				long Current  = long.Parse(dtSAMStransfermaster.Rows[0]["VALUE"].ToString()) + 1;
				string Code  = Current.ToString(); 
				
				if(Code.Length == 1)
				{
					Code   = "00" + Code;
				}
				else if(Code.Length == 2) 
				{
					Code   = "0" + Code;
				}
				else 
				{
					Code   =  Code;
				}
				return p_code + Code;	
				
				
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

        public string GetAutoAccountCode(string p_code, int p_type, long p_value)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectSETTINGS_TABLE01 selectdata = new uspSelectSETTINGS_TABLE01();
                selectdata.Connection = mConnection;
                selectdata.Code = p_code;
                selectdata.type = p_type;
                selectdata.value = p_value;
                DataTable dtSAMStransfermaster = selectdata.ExecuteTable();

                long Current = long.Parse(dtSAMStransfermaster.Rows[0]["VALUE"].ToString()) + 1;
                string Code = Current.ToString();

                if (Code.Length == 1)
                {
                    Code = "000" + Code;
                }
                else if (Code.Length == 2)
                {
                    Code = "00" + Code;
                }
                else if (Code.Length == 1)
                {
                    Code = "0" + Code;
                }
                return Code;


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
		public string GetAutoOrderNo(string p_code,int p_type,long p_value)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectSETTINGS_TABLE01 selectdata = new uspSelectSETTINGS_TABLE01();
				selectdata.Connection = mConnection;
				selectdata.Code = p_code;
				selectdata.type = p_type;
				selectdata.value =  p_value;
				DataTable dtSAMStransfermaster = selectdata.ExecuteTable();

				long Current  = long.Parse(dtSAMStransfermaster.Rows[0]["VALUE"].ToString()) + 1;
				string Code  = Current.ToString(); 
						
				return p_code + "-" +  Code;	
				
				
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
        public long GetAutoCustomerCode(string p_code, int p_type, long p_value)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectSETTINGS_TABLE01 selectdata = new uspSelectSETTINGS_TABLE01();
                selectdata.Connection = mConnection;
                selectdata.Code = p_code;
                selectdata.type = p_type;
                selectdata.value = p_value;
                DataTable dtSAMStransfermaster = selectdata.ExecuteTable();

                return long.Parse(dtSAMStransfermaster.Rows[0]["VALUE"].ToString()) + 1;
                 
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return -1;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
		public string InsertTmpData(int SoldTo,int sku_id,decimal Amount,int qty)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertTmpPromotion selectdata = new spInsertTmpPromotion();
				selectdata.Connection = mConnection;
				selectdata.SoldToId = SoldTo; 
				selectdata.SKU_ID = sku_id;
				selectdata.Amount = Amount;
				selectdata.Qty = qty;
				selectdata.ExecuteQuery(); 
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


		#endregion
	}
}
