using System;
using System.Collections;
using System.Data;
using System.Net;
using System.Net.Sockets;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;


namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for RightsController.
	/// </summary>
	public class RightsController
	{
		public DataTable SelectAccessRights(int p_Role_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspAccessRightsInfo mRightsInfo = new uspAccessRightsInfo();
				mRightsInfo.Connection = mConnection;
                
				mRightsInfo.ROLE_ID = p_Role_Id;
				
			
				DataTable dt = mRightsInfo.ExecuteTable();
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
		public DataTable SelectSAMSUserAccessRights(int p_Role_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSAMSUserAccessRightsInfo mRightsInfo = new uspSAMSUserAccessRightsInfo();
				mRightsInfo.Connection = mConnection;
                
				mRightsInfo.ROLE_ID = p_Role_Id;
				
			
				DataTable dt = mRightsInfo.ExecuteTable();
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
	}


	public class Rights
	{

		#region Constructors

		public Rights()
		{
			//TODO Add Constructor logic here
		}

		public Rights(int RID,string RName,bool CView,bool CAdd,bool CUpdate,bool CDelete,int MID,string MName)
		{
			this.m_RoleID=RID;
			this.m_RoleName=RName;
			this.m_CanView=CView;
			this.m_CanAdd=CAdd;
			this.m_CanUpdate=CUpdate;
			this.m_CanDelete=CDelete;
			this.m_ModuleID=MID;
			this.m_ModuleName=MName;
		}
		#endregion
		
		#region Private Variables

		private int m_RoleID;
		private int m_ModuleID;
		private string m_RoleName;
		private string m_ModuleName;
		private bool m_CanView;
		private bool m_CanAdd;
		private bool m_CanUpdate;
		private bool m_CanDelete;

		#endregion

		#region Properties

		public int RoleID
		{
			//set{m_RoleID=value;}
			get{return m_RoleID;}
		}

		public int ModuleID
		{
			//set{m_ModuleID=value;}
			get{return m_ModuleID;}
		}

		public string RoleName
		{
			//set{m_RoleName=value;}
			get{return m_RoleName;}
		}

		public string ModuleName
		{
			//set{m_ModuleName=value;}
			get{return m_ModuleName;}
		}

		public bool CanView
		{
			//set{m_CanView=value;}
			get{return m_CanView;}
		}

		public bool CanAdd
		{
			//set{m_CanAdd=value;}
			get{return m_CanAdd;}
		}

		public bool CanUpdate
		{
			//set{m_CanUpdate=value;}
			get{return m_CanUpdate;}
		}

		public bool CanDelete
		{
			//set{m_CanDelete=value;}
			get{return m_CanDelete;}
		}

		#endregion
		

	}

	public class RightsCollection : CollectionBase
	{
		public int Add(Rights accessRights)
		{
			return List.Add(accessRights);
		}

		public void Insert(int index,Rights accessRights)
		{
			List.Insert(index,accessRights);
		}

		public void Remove(Rights accessRights)
		{
			List.Remove(accessRights);
		}

		public bool Contains(Rights accessRights)
		{
			return List.Contains(accessRights);
		}

		public int IndexOf(Rights accessRights)
		{
			return List.IndexOf(accessRights);
		}

		public void CopyTo(Rights[] array, int index)
		{
			List.CopyTo(array, index);
		}
	
//		public Rights this[int index]
//		{
//			get { return (Rights)List[index]; }
//			//set { List[index] = value; }
//		}

		public Rights this[int id]
		{
			get
			{
				int i;
				for(i=0;i<List.Count;i++)
				{
					if (((Rights)List[i]).ModuleID == id)
					{
						return (Rights)List[i];
					}
				}
				
				return null;								
			}
		} 

		public Rights this[string key]
		{
			get
			{		int i;
					for(i=0;i<List.Count;i++)
					{
						if (((Rights)List[i]).ModuleName.Equals(key))
							break;					
					}
				
				if(List.Count == 0)
				{
					return new Rights(-1, "", true, true, true, true, -1, "");
				}

					return (Rights)List[i];
				
			}
		} 
		
	}

	
}
