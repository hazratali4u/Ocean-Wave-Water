using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for ModuleController.
	/// </summary>
	public class ModuleController
	{
		#region Constructor
		public ModuleController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		
		#region Public Methods


		public DataTable SelectModule(int p_Module_Id,string p_Module_Name, int p_Module_Type_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectMODULES mModule = new spSelectMODULES();
				mModule.Connection = mConnection;							

				mModule.MODULE_ID=p_Module_Id;
				mModule.MODULE_NAME=p_Module_Name;
				mModule.MODULE_TYPE_ID=p_Module_Type_Id;
							                
				DataTable dt = mModule.ExecuteTable();
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

		public DataTable SelectModule(int p_Module_Id_From, int p_Module_Id_To, int p_Module_Type_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectMODULES mModule = new uspSelectMODULES();
				mModule.Connection = mConnection;							

				mModule.MODULE_ID_FROM=p_Module_Id_From;
				mModule.MODULE_ID_TO=p_Module_Id_To;
				mModule.MODULE_TYPE_ID=p_Module_Type_Id;
							                
				DataTable dt = mModule.ExecuteTable();
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

		public int GetModuleId(int p_Module_Id_From, int p_Module_Id_To, int p_Module_Type_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspGETMODULE_ID mModule = new uspGETMODULE_ID();
				mModule.Connection = mConnection;							

				mModule.MODULE_ID_FROM=p_Module_Id_From;
				mModule.MODULE_ID_TO=p_Module_Id_To;
				mModule.MODULE_TYPE_ID=p_Module_Type_Id;
							                
				mModule.ExecuteQuery();

				return mModule.MODULE_ID;
				
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

	
		public string InsertModule(int p_Module_Id,string p_Module_Name, int p_Module_Type_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertMODULES mModule = new spInsertMODULES();
				mModule.Connection = mConnection;
				
				mModule.MODULE_ID=p_Module_Id;
				mModule.MODULE_NAME=p_Module_Name;
				mModule.MODULE_TYPE_ID=p_Module_Type_Id;
			
								                
				mModule.ExecuteQuery();
				return mModule.MODULE_ID.ToString();
				
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


		public string UpdateModule(int p_Module_Id,string p_Module_Name, int p_Module_Type_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateMODULES mModule = new spUpdateMODULES();
				mModule.Connection = mConnection;
				
				mModule.MODULE_ID=p_Module_Id;
				mModule.MODULE_NAME=p_Module_Name;
				mModule.MODULE_TYPE_ID=p_Module_Type_Id;
						
				                
				mModule.ExecuteQuery();
				return mModule.MODULE_ID.ToString();
				
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


		public DataTable SelectModules(int p_Module_Type_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spSelectMODULES mModule = new spSelectMODULES();
				mModule.Connection = mConnection;
				
				mModule.MODULE_ID=Constants.IntNullValue;
				mModule.MODULE_NAME = null;
				mModule.MODULE_TYPE_ID=p_Module_Type_Id;
								                
				DataTable dt = mModule.ExecuteTable();
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
