using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// SKUGroupController
	/// <author></author>
	/// <date></date>
	/// </summary>
	public class SKUGroupController
	{
		
		#region Constructors
		public SKUGroupController()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion
				
		#region Private Variables
		private string m_IP_ADDRESS = "192.168.40.1";
		#endregion

		#region public Properties
		public string IP_ADDRESS
		{
			get
			{
				return m_IP_ADDRESS;
			}
		}
		#endregion
		
		#region public static Methods
		#endregion

		#region Private Methods
		#endregion
		
		#region Public Methods
		public DataTable SelectSKUGroupInfo(int p_Sku_Group_Detail_Id, int p_Sku_Group_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectSKU_GROUP_DETAIL_INFO mSkus = new uspSelectSKU_GROUP_DETAIL_INFO();
					
				mSkus.Connection = mConnection;
				mSkus.SKU_GROUP_DETAIL_ID = p_Sku_Group_Detail_Id;
				mSkus.SKU_GROUP_ID = p_Sku_Group_Id;
                
				DataTable dt = mSkus.ExecuteTable();
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


        public DataTable SelectSKUGroup(int p_Sku_Group_Id, string p_Sku_Group_Name, int Companyid)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_GROUP mSkus = new spSelectSKU_GROUP();
					
				mSkus.Connection = mConnection;   
				mSkus.SKU_GROUP_ID = p_Sku_Group_Id;
				mSkus.GROUP_NAME = p_Sku_Group_Name ;
                mSkus.COMPANY_ID = Companyid;   
                DataTable dt = mSkus.ExecuteTable();
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


		public DataTable SelectSKUGroupDetail(int p_Sku_Grp_Detail_Id, int p_Sku_Grp_Id, int p_Sku_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectSKU_GROUP_DETAIL  mSkus = new spSelectSKU_GROUP_DETAIL();
					
				mSkus.Connection = mConnection;
				mSkus.SKU_GROUP_DETAIL_ID = p_Sku_Grp_Detail_Id ;
				mSkus.SKU_GROUP_ID = p_Sku_Grp_Id ;
				mSkus.SKU_ID = p_Sku_Id;
                
				DataTable dt = mSkus.ExecuteTable();
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

		
		public string InsertSKUGroup(string p_Sku_Group_Name)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertSKU_GROUP mSkus = new spInsertSKU_GROUP();
					
				mSkus.Connection = mConnection;
				mSkus.GROUP_NAME = p_Sku_Group_Name;
                
				mSkus.ExecuteQuery();

				return mSkus.SKU_GROUP_ID.ToString();

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

		
		public string InsertSKUGroupDetail(int p_Sku_Grp_Id, int p_Sku_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertSKU_GROUP_DETAIL mSkus = new spInsertSKU_GROUP_DETAIL();
					
				mSkus.Connection = mConnection;
				mSkus.SKU_GROUP_ID = p_Sku_Grp_Id;
				mSkus.SKU_ID = p_Sku_Id;
                
				mSkus.ExecuteQuery();

				return "Inserted Record";

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


		public string UpdateSKUGroup(int p_Sku_Grp_Id, string p_Sku_Grp_Name)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateSKU_GROUP mSkus = new spUpdateSKU_GROUP();
					
				mSkus.Connection = mConnection;
				mSkus.SKU_GROUP_ID = p_Sku_Grp_Id;
				mSkus.GROUP_NAME = p_Sku_Grp_Name;
                
				mSkus.ExecuteQuery();
				return "Record Updated";
				
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


		public string UpdateSKUGroupDetail()
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateSKU_GROUP_DETAIL mSkus = new spUpdateSKU_GROUP_DETAIL();
					
				mSkus.Connection = mConnection;
            
				mSkus.ExecuteQuery();
				return "Record Updated";
				
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


		public string DeleteSKUGroup(int p_Group_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spDeleteSKU_GROUP mSkus = new spDeleteSKU_GROUP();
					
				mSkus.Connection = mConnection;
				mSkus.SKU_GROUP_ID = p_Group_Id;
            
				mSkus.ExecuteQuery();
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


		public string DeleteSKUGroupDetail(int p_Group__Detail_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spDeleteSKU_GROUP_DETAIL mSkus = new spDeleteSKU_GROUP_DETAIL();
					
				mSkus.Connection = mConnection;
				mSkus.SKU_GROUP_DETAIL_ID = p_Group__Detail_Id;

            
				mSkus.ExecuteQuery();
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

	
		#endregion
	}
}
