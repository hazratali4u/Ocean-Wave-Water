using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;


namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for ControllerAssignLocations.
	/// </summary>
	public class ControllerAssignLocations
	{
		public ControllerAssignLocations()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region public Methods
		public DataTable Select_UnAssignLocation(int p_Type,int p_Assig_to)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				UspSelectUnAssignLocation selectdata  = new UspSelectUnAssignLocation(); 
				selectdata.Connection = mConnection;
				
				selectdata.type = p_Type;
				selectdata.Assign = p_Assig_to;
				DataTable dtAssign = selectdata.ExecuteTable();
				return dtAssign;
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

		
		public string InsertAssignLocation(int p_ASSIGN_TO_ID, int p_ASSIGN_LOCATION_ID ,string p_ASSIGN_LOCATION_CODE, 
			string p_ASSIGN_LOCATION_NAME,string p_ASSIGN_TYPE,string I_IPAddress)
		{
			IDbConnection mConnection = null;
			try
			{
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertWAREHOUSES mwarehouse  =  new spInsertWAREHOUSES();
				spInsertASSIGNMENTS mAssign  = new spInsertASSIGNMENTS();  
				mAssign.Connection = mConnection;
				mAssign.ASSIGN_TO_ID = p_ASSIGN_TO_ID;
                mAssign.ASSIGN_LOCATION_ID = p_ASSIGN_LOCATION_ID;
				mAssign.ASSIGN_LOCATION_CODE = p_ASSIGN_LOCATION_CODE;
 				mAssign.ASSIGN_LOCATION_NAME = p_ASSIGN_LOCATION_NAME;
				mAssign.ASSIGN_TYPE = p_ASSIGN_TYPE; 
                mAssign.IP_ADDRESS = I_IPAddress;
				mAssign.USER_ID = Configuration.UserID;
				mAssign.IS_ACCTIVE = true;
				mAssign.ASSIGN_DATE = System.DateTime.Now ;
				mAssign.ExecuteQuery();
				return mAssign.ASSIGN_LOCATION_ID.ToString();  
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

		
		public string UpdateAssignLocation(int AssignLocationId)
		{
			IDbConnection mConnection = null;
			try
			{
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateASSIGNMENTS mAssign  = new spUpdateASSIGNMENTS(); 
				mAssign.Connection = mConnection;
				mAssign.ASSIGNMENTS_ID = AssignLocationId;
				mAssign.ASSIGN_TO_ID = Constants.IntNullValue;
				mAssign.ASSIGN_LOCATION_ID = Constants.IntNullValue;
				mAssign.ASSIGN_LOCATION_CODE = null;
				mAssign.ASSIGN_LOCATION_NAME = null;
				mAssign.ASSIGN_TYPE = null; 
				mAssign.IP_ADDRESS = null;
				mAssign.USER_ID = Configuration.UserID;
				mAssign.IS_ACCTIVE = false;
				mAssign.ASSIGN_DATE = System.DateTime.Now ;
				mAssign.ExecuteQuery();
				return mAssign.ASSIGN_LOCATION_ID.ToString();  
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


		public DataTable SelectAssignedCustomer(int p_TLPPersonId)
		{
			return Select_AssignLocationCustomer(1,p_TLPPersonId,Constants.IntNullValue,Constants.IntNullValue);
		}


		public DataTable Select_AssignLocationCustomer(int p_Type,int p_Assig_to,int Areaid,int RouteId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				UspSelectUnAssignLocationCustomer selectdata  = new UspSelectUnAssignLocationCustomer(); 
				selectdata.Connection = mConnection;
				
				selectdata.type = p_Type;
				selectdata.Assign = p_Assig_to;
				selectdata.AreaId = Areaid;
				selectdata.Route = RouteId;
				DataTable dtAssign = selectdata.ExecuteTable();
				return dtAssign;
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
