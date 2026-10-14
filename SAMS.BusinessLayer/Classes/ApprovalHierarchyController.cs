using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// HierarchyController
	/// <author></author>
	/// <date>09-08-07</date>
	/// </summary>
	public class ApprovalHierarchyController
	{
		
		#region Contructors
		public ApprovalHierarchyController()
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

		#region Public Method
		public DataTable SelectApprovalHierarchy(int p_Approval_Hierarchy_Id , int p_Claim_Type_Id, int p_First_Approval, int p_Second_Approval, int p_Third_Approval, int p_Forth_Approval, string p_Ip_Address, int p_User_Id, int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spSelectAPPROVAL_HIERARCHY mAppHierarchy = new spSelectAPPROVAL_HIERARCHY();
				mAppHierarchy.Connection = mConnection;

				mAppHierarchy.APPROVAL_HIERARCHY_ID = p_Approval_Hierarchy_Id;
				mAppHierarchy.CLAIM_TYPE_ID = p_Claim_Type_Id;
				mAppHierarchy.FIRST_APPROVAL = p_First_Approval;
				mAppHierarchy.SECOND_APPROVAL = p_Second_Approval;
				mAppHierarchy.THIRD_APPROVAL = p_Third_Approval;
				mAppHierarchy.FOURTH_APPROVAL = p_Forth_Approval;
				mAppHierarchy.LASTUPDATE_DATE = Constants.DateNullValue ;
				mAppHierarchy.TIME_STAMP = Constants.DateNullValue ;
				mAppHierarchy.IP_ADDRESS = p_Ip_Address;
				mAppHierarchy.USER_ID = p_User_Id;
				mAppHierarchy.DISTRIBUTOR_ID = p_Distributor_Id;

				
				DataTable dt = mAppHierarchy.ExecuteTable();
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
		public DataTable UspSelectApprovalHierarchyInfo(int p_Approval_Hierarchy_Id )
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				uspSelectAPPROVAL_HIERARCHY_INFO mAppHierarchy = new uspSelectAPPROVAL_HIERARCHY_INFO();
				mAppHierarchy.Connection = mConnection;

				mAppHierarchy.APPROVAL_HIERARCHY_ID = p_Approval_Hierarchy_Id;
								
				DataTable dt = mAppHierarchy.ExecuteTable();
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
		public string InsertApprovalHierarchy(int p_Claim_Type_Id, int p_First_Approval, int p_Second_Approval, int p_Third_Approval, int p_Forth_Approval, string p_Ip_Address, int p_User_Id, int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();

				spInsertAPPROVAL_HIERARCHY mAppHierarchy = new spInsertAPPROVAL_HIERARCHY();
				mAppHierarchy.Connection = mConnection;

				mAppHierarchy.CLAIM_TYPE_ID = p_Claim_Type_Id;
				mAppHierarchy.FIRST_APPROVAL = p_First_Approval;
				mAppHierarchy.SECOND_APPROVAL = p_Second_Approval;
				mAppHierarchy.THIRD_APPROVAL = p_Third_Approval;
				mAppHierarchy.FOURTH_APPROVAL = p_Forth_Approval;
				mAppHierarchy.LASTUPDATE_DATE = System.DateTime.Now;
				mAppHierarchy.TIME_STAMP = System.DateTime.Now; 
				mAppHierarchy.IP_ADDRESS = p_Ip_Address;
				mAppHierarchy.USER_ID = p_User_Id;
				mAppHierarchy.DISTRIBUTOR_ID = p_Distributor_Id;

				mAppHierarchy.ExecuteQuery();
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
		public string UpdateApprovalHierarchy(int p_Approval_Hierarchy_Id , int p_Claim_Type_Id, int p_First_Approval, int p_Second_Approval, int p_Third_Approval, int p_Forth_Approval, string p_Ip_Address, int p_User_Id, int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				spUpdateAPPROVAL_HIERARCHY  mAppHierarchy = new spUpdateAPPROVAL_HIERARCHY();
				mAppHierarchy.Connection = mConnection;

				mAppHierarchy.APPROVAL_HIERARCHY_ID = p_Approval_Hierarchy_Id;
				mAppHierarchy.CLAIM_TYPE_ID = p_Claim_Type_Id;
				mAppHierarchy.FIRST_APPROVAL = p_First_Approval;
				mAppHierarchy.SECOND_APPROVAL = p_Second_Approval;
				mAppHierarchy.THIRD_APPROVAL = p_Third_Approval;
				mAppHierarchy.FOURTH_APPROVAL = p_Forth_Approval;
				mAppHierarchy.LASTUPDATE_DATE = System.DateTime.Now;
				mAppHierarchy.TIME_STAMP = System.DateTime.Now;
				mAppHierarchy.IP_ADDRESS = p_Ip_Address;
				mAppHierarchy.USER_ID = p_User_Id;
				mAppHierarchy.DISTRIBUTOR_ID = p_Distributor_Id;

				mAppHierarchy.ExecuteQuery();
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
		
		public string UspUpdateApprovalHierarchy(int p_Approval_Hierarchy_Id , int p_Claim_Type_Id, int p_First_Approval, int p_Second_Approval, int p_Third_Approval, int p_Forth_Approval, string p_Ip_Address, int p_User_Id, int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
				uspUpdateAPPROVAL_HIERARCHY  mAppHierarchy = new uspUpdateAPPROVAL_HIERARCHY();
				mAppHierarchy.Connection = mConnection;

				mAppHierarchy.APPROVAL_HIERARCHY_ID = p_Approval_Hierarchy_Id;
				mAppHierarchy.CLAIM_TYPE_ID = p_Claim_Type_Id;
				mAppHierarchy.FIRST_APPROVAL = p_First_Approval;
				mAppHierarchy.SECOND_APPROVAL = p_Second_Approval;
				mAppHierarchy.THIRD_APPROVAL = p_Third_Approval;
				mAppHierarchy.FOURTH_APPROVAL = p_Forth_Approval;
				mAppHierarchy.LASTUPDATE_DATE = System.DateTime.Now;
				mAppHierarchy.TIME_STAMP = System.DateTime.Now;
				mAppHierarchy.IP_ADDRESS = p_Ip_Address;
				mAppHierarchy.USER_ID = p_User_Id;
				mAppHierarchy.DISTRIBUTOR_ID = p_Distributor_Id;

				mAppHierarchy.ExecuteQuery();
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
		


		#endregion
	}
}
