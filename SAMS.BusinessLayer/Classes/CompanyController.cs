using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for CompanyController.
	/// </summary>
	public class CompanyController
	{
		public CompanyController()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public DataTable SelectCompany(int p_COMPANY_ID, int p_STATUS)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectCOMPANY mdtCompany = new spSelectCOMPANY();
                mdtCompany.Connection = mConnection;
                mdtCompany.STATUS = p_STATUS;
                mdtCompany.COMPANY_ID = p_COMPANY_ID;
                mdtCompany.ISCURRENT = true;
                mdtCompany.ISDELETED = false;  
                DataTable dt = mdtCompany.ExecuteTable();
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
		public string InsertDTCompany(bool p_ISCURRENT,bool p_ISDELETED,int p_COMPANY_ID,int p_STATUS,string p_EMAIL_ADDRESS,string p_PHONE,string p_FAX,string p_WEBSITE,string p_COMPANY_NAME,string p_ADDRESS1,string p_ADDRESS2)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDTCOMPANY mdtCompany = new spInsertDTCOMPANY();
				mdtCompany.Connection = mConnection;
				
				mdtCompany.ISCURRENT = p_ISCURRENT;
				mdtCompany.ISDELETED = p_ISDELETED ;
				mdtCompany.COMPANY_ID = p_COMPANY_ID;
				mdtCompany.STATUS = p_STATUS;
				mdtCompany.EMAIL_ADDRESS = p_EMAIL_ADDRESS;
				mdtCompany.PHONE = p_PHONE;
				mdtCompany.FAX = p_FAX;
				mdtCompany.WEBSITE = p_WEBSITE;
				mdtCompany.COMPANY_NAME = p_COMPANY_NAME;
				mdtCompany.ADDRESS1 = p_ADDRESS1;
				mdtCompany.ADDRESS2 = p_ADDRESS2;
				mdtCompany.ExecuteQuery();
				
				return mdtCompany.COMPANY_ID.ToString();
				
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
}
