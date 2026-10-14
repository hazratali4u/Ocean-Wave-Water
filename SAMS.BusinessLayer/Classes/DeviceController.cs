using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for DeviceController.
	/// </summary>
	public class DeviceController
	{
		#region Constructor
		public DeviceController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		
		#region Public Methods


		public DataTable SelectAllDevice() 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDEVICEInfo mDevice = new uspSelectDEVICEInfo();
				mDevice.Connection = mConnection;							

				mDevice.DEVICE_ID = Constants.IntNullValue;
				mDevice.DEVICE_CODE = null;
				mDevice.DEVICE_NAME = null;
				mDevice.MACHINE_NO = null;
				mDevice.REGISTERED_ON = Constants.DateNullValue;
				mDevice.DISTRIBUTOR_ID = Configuration.DistributorId;
							                
				DataTable dt = mDevice.ExecuteTable();
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


		public DataTable SelectDevice(int p_Device_Id, string p_Device_Code, string p_Device_Name , string p_Machine_No, DateTime p_Registered_On, int p_Distributor_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDEVICEInfo mDevice = new uspSelectDEVICEInfo();
				mDevice.Connection = mConnection;							

				mDevice.DEVICE_ID=p_Device_Id;
				mDevice.DEVICE_CODE = p_Device_Code;
				mDevice.DEVICE_NAME = p_Device_Name;
				mDevice.MACHINE_NO = p_Machine_No;
				mDevice.REGISTERED_ON = p_Registered_On;
				mDevice.DISTRIBUTOR_ID = p_Distributor_Id;
							                
				DataTable dt = mDevice.ExecuteTable();
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

		public DataTable SelectDeviceAllocation(int p_Device_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDEVICEALLOCATIONInfo mDevice = new uspSelectDEVICEALLOCATIONInfo();
				mDevice.Connection = mConnection;							

				mDevice.DEVICE_ID=p_Device_Id;
							                
				DataTable dt = mDevice.ExecuteTable();
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
	
		public DataTable SelectCurrentDeviceAllocation(int p_Device_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDEVICEALLOCATIONCurrentInfo mDevice = new uspSelectDEVICEALLOCATIONCurrentInfo();
				mDevice.Connection = mConnection;							

				mDevice.DEVICE_ID = p_Device_Id;
							                
				DataTable dt = mDevice.ExecuteTable();
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

		public int InsertDevice(string p_Device_Code, string p_Device_Prefix, string p_Device_Name , string p_Machine_No, DateTime p_Registered_On, int p_Distributor_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDEVICE mDevice = new spInsertDEVICE();
				mDevice.Connection = mConnection;
				
				mDevice.DEVICE_CODE = p_Device_Code;
				mDevice.DEVICE_NAME = p_Device_Name;
				mDevice.DEVICE_PREFIX = p_Device_Prefix;
				mDevice.MACHINE_NO = p_Machine_No;
				mDevice.REGISTERED_ON = p_Registered_On;
				mDevice.DISTRIBUTOR_ID = p_Distributor_Id;
				mDevice.SEQUENCE_ID = 0;
				mDevice.USER_ID = Configuration.UserID;
				mDevice.IS_ACTIVE = true;
				mDevice.TIME_STAMP = DateTime.Now;
				mDevice.LASTUPDATE_DATE = DateTime.Now;
								                
				mDevice.ExecuteQuery();
				return mDevice.DEVICE_ID;
				
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


		public void UpdateDevice(int p_Device_Id, string p_Device_Prefix, string p_Device_Name) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateDEVICE mDevice = new spUpdateDEVICE();
				mDevice.Connection = mConnection;
				
				mDevice.DEVICE_ID=p_Device_Id;
				mDevice.DEVICE_CODE = null;
				mDevice.DEVICE_PREFIX = p_Device_Prefix;
				mDevice.DEVICE_NAME = p_Device_Name;
				mDevice.MACHINE_NO = null;
				mDevice.REGISTERED_ON = Constants.DateNullValue;
				mDevice.SEQUENCE_ID = Constants.IntNullValue;
				mDevice.DISTRIBUTOR_ID = Constants.IntNullValue;			
				mDevice.USER_ID = Configuration.UserID;
				mDevice.IS_ACTIVE = true;
				mDevice.TIME_STAMP = Constants.DateNullValue;
				mDevice.LASTUPDATE_DATE = DateTime.Now;
									                
				mDevice.ExecuteQuery();
				
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

		public void UpdateDeviceSequenceId(int p_Device_Id, int p_SequenceId) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateDEVICE mDevice = new spUpdateDEVICE();
				mDevice.Connection = mConnection;
				
				mDevice.DEVICE_ID=p_Device_Id;
				mDevice.DEVICE_CODE = null;
				mDevice.DEVICE_PREFIX = null;
				mDevice.DEVICE_NAME = null;
				mDevice.MACHINE_NO = null;
				mDevice.REGISTERED_ON = Constants.DateNullValue;
				mDevice.SEQUENCE_ID = p_SequenceId;
				mDevice.DISTRIBUTOR_ID = Constants.IntNullValue;			
				mDevice.USER_ID = Configuration.UserID;
				mDevice.IS_ACTIVE = true;
				mDevice.TIME_STAMP = Constants.DateNullValue;
				mDevice.LASTUPDATE_DATE = DateTime.Now;
									                
				mDevice.ExecuteQuery();
				
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


		public string DeleteDevice(int p_Device_Id) 
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spDeleteDEVICE mDevice = new spDeleteDEVICE();
				mDevice.Connection = mConnection;
				
				mDevice.DEVICE_ID=p_Device_Id;
				                
				mDevice.ExecuteQuery();
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

		public void AllocateDevice(int p_DeviceId, int p_SalesForceId, int p_SequenceId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				DataTable dtAllocation = SelectCurrentDeviceAllocation(p_DeviceId);

				if(dtAllocation != null && dtAllocation.Rows.Count > 0)
				{
					int iDeviceAllocationId = Convert.ToInt32(dtAllocation.Rows[0]["DEVICE_ALLOCATION_ID"]);

					spUpdateDEVICE_ALLOCATION mDeviceUpdate = new spUpdateDEVICE_ALLOCATION();
					mDeviceUpdate.Connection = mConnection;
				
					mDeviceUpdate.DEVICE_ALLOCATION_ID = iDeviceAllocationId;

					mDeviceUpdate.DEVICE_ID = Constants.IntNullValue;
					mDeviceUpdate.ORDERBOOKER_ID = Constants.IntNullValue;
					mDeviceUpdate.ALLOC_FROM = Constants.DateNullValue;
					mDeviceUpdate.ALLOC_TO = DateTime.Now.Date;
					mDeviceUpdate.SEQUENCE_ID = p_SequenceId;
					mDeviceUpdate.IS_CURRENT = false;
					mDeviceUpdate.DISTRIBUTOR_ID = Constants.IntNullValue;
					mDeviceUpdate.USER_ID  = Configuration.UserID;
					mDeviceUpdate.TIME_STAMP = Constants.DateNullValue;
					mDeviceUpdate.LASTUPDATE_DATE = DateTime.Now;
					mDeviceUpdate.IS_ACTIVE = true;
				                
					mDeviceUpdate.ExecuteQuery();
				}

				spInsertDEVICE_ALLOCATION mInsertDevice = new spInsertDEVICE_ALLOCATION();
				mInsertDevice.Connection = mConnection;
				
				mInsertDevice.DEVICE_ID = p_DeviceId;
				mInsertDevice.ORDERBOOKER_ID = p_SalesForceId;
				mInsertDevice.ALLOC_FROM = DateTime.Now.Date;
				mInsertDevice.ALLOC_TO = Constants.DateNullValue;
				mInsertDevice.SEQUENCE_ID = p_SequenceId;
				mInsertDevice.IS_CURRENT = true;
				mInsertDevice.DISTRIBUTOR_ID = Configuration.DistributorId;
				mInsertDevice.USER_ID  = Configuration.UserID;
				mInsertDevice.TIME_STAMP = DateTime.Now;
				mInsertDevice.LASTUPDATE_DATE = DateTime.Now;
				mInsertDevice.IS_ACTIVE = true;
				                
				mInsertDevice.ExecuteQuery();
				
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

		#endregion

	}
}
