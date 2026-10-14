using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMSBusinessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
    /// <summary>
    /// Class For Company Related Tasks
    /// <remarks>
    /// <list type="bullet">
    /// <item>Insert Company</item>
    /// <item>Get Company</item>
    /// </list>
    /// </remarks>
    /// </summary>
	public class CompanyConfigrationController
	{

        /// <summary>
        /// Constructor for CompanyController Class
        /// </summary>
		public CompanyConfigrationController()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        /// <summary>
        /// Gets Employee Data
        /// </summary>
       
        public DataTable SelectAllowances(int pallowanceId, int pTypeId,int pCompanyId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectAllowances mdtCompany = new spSelectAllowances();
                mdtCompany.Connection = mConnection;
                mdtCompany.CompanyID = pCompanyId;
                mdtCompany.AllowanceID = pallowanceId;
                mdtCompany.RatioType = pTypeId;

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
        public DataTable SelectDeductions(int pDeductionId, int pTypeId, int pCompanyId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectDeductions mdtCompany = new spSelectDeductions();
                mdtCompany.Connection = mConnection;
                mdtCompany.CompanyID = pCompanyId;
                mdtCompany.DeductionID = pDeductionId;
                mdtCompany.RatioType = pTypeId;

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
     
        public DataTable SelectEmployeeSalary(int pDistributionId, int pCustomerId,DateTime pSalaryMonth)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectEMPLOYEE_SALARY mdtCompany = new spSelectEMPLOYEE_SALARY();
                mdtCompany.Connection = mConnection;
                mdtCompany.DISTRIBUTOR_ID = pDistributionId;
                mdtCompany.EMPLOYEE_ID = pCustomerId;
                mdtCompany.SALARY_MONTH = pSalaryMonth;
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
        public DataTable SelectEmployeeAllowances(int pSalaryId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectEMPLOYEE_SALARY_ALLOWANCE mdtCompany = new spSelectEMPLOYEE_SALARY_ALLOWANCE();
                mdtCompany.Connection = mConnection;
                mdtCompany.SALARY_ID = pSalaryId;
             
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
        public DataTable SelectEmployeeDeductions(int pSalaryId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectEMPLOYEE_SALARY_DEDUCTION mdtCompany = new spSelectEMPLOYEE_SALARY_DEDUCTION();
                mdtCompany.Connection = mConnection;
                mdtCompany.SALARY_ID = pSalaryId;

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
       
        public int InsertAllowances(int pCompanyId ,string pAllowanceDescription,decimal pAllowanceRatio,int pRatioType,int pUserId ,DateTime pDocumentDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertAllowances mAccountHead = new spInsertAllowances();
                mAccountHead.Connection = mConnection;
                mAccountHead.CompanyID = pCompanyId;
                mAccountHead.AllowanceDescription = pAllowanceDescription;
                mAccountHead.AllowanceRatio = pAllowanceRatio;
                mAccountHead.DocumentDate = pDocumentDate;
                mAccountHead.RatioType = pRatioType;
                mAccountHead.User_ID = pUserId;
                return mAccountHead.ExecuteQuery();
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                throw exp;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        public bool UpdateAllowances(int pAllowanceId ,int pCompanyId, string pAllowanceDescription,decimal pAllowanceRatio,int pRatioType,bool pIsDeleted,bool pIsActive,int pUserId )
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateAllowances mAccountHead = new spUpdateAllowances();
                mAccountHead.Connection = mConnection;
                mAccountHead.CompanyID = pCompanyId;
                mAccountHead.AllowanceDescription = pAllowanceDescription;
                mAccountHead.AllowanceID = pAllowanceId;
                mAccountHead.AllowanceRatio = pAllowanceRatio;
                mAccountHead.IS_ACTIVE = pIsActive;
                mAccountHead.IS_DELETED = pIsDeleted;
                mAccountHead.RatioType = pRatioType;
                mAccountHead.User_ID = pUserId;
                return mAccountHead.ExecuteQuery();
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                throw exp;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        public int InsertDeductions(int pCompanyId, string pDeductionDescription, decimal pDeductionRatio, int pRatioType, int pUserId, DateTime pDocumentDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertDeductions mAccountHead = new spInsertDeductions();
                mAccountHead.Connection = mConnection;
                mAccountHead.CompanyID = pCompanyId;
                mAccountHead.DeductionDescription = pDeductionDescription;
                mAccountHead.DeductionRatio = pDeductionRatio;
                mAccountHead.Document_Date = pDocumentDate;
                mAccountHead.RatioType = pRatioType;
                mAccountHead.User_ID = pUserId;
                return mAccountHead.ExecuteQuery();
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                throw exp;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        public bool UpdateDeductions(int pDeductionId, int pCompanyId, string pDeductionDescription, decimal pDeductionRatio, int pRatioType, bool pIsDeleted, bool pIsActive, int pUserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateDeductions mAccountHead = new spUpdateDeductions();
                mAccountHead.Connection = mConnection;
                mAccountHead.CompanyID = pCompanyId;
                mAccountHead.DeductionDescription = pDeductionDescription;
                mAccountHead.DeductionID =pDeductionId;
                mAccountHead.DeductionRatio = pDeductionRatio;
                mAccountHead.IS_ACTIVE = pIsActive;
                mAccountHead.IS_DELETED = pIsDeleted;
                mAccountHead.RatioType = pRatioType;
                mAccountHead.User_ID = pUserId;
                return mAccountHead.ExecuteQuery();
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                throw exp;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
     }
}