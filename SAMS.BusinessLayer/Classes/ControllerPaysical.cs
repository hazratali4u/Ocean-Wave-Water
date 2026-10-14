using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
    public class ControllerPaysical
    {

        #region Constructors
        public ControllerPaysical()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

        #region PaysicalStock

        public string InsertPysicalStock(int p_DISTRIBUTOR_ID, DateTime p_STOCK_DATE, int p_SKU_ID, int p_SQUANTITY,int p_UQUANTITY, decimal p_UNIT_RATE, int p_POST, int PRINCIPAL_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertPAYSICAL_STOCK mPaysical = new spInsertPAYSICAL_STOCK();
                mPaysical.Connection = mConnection;
                mPaysical.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPaysical.STOCK_DATE = p_STOCK_DATE;
                mPaysical.SKU_ID = p_SKU_ID;
                mPaysical.SALEABLE_QUANTITY  = p_SQUANTITY;
                mPaysical.UNSALEABLE_QUANTITY = p_UQUANTITY;  
                mPaysical.UNIT_RATE = p_UNIT_RATE;
                mPaysical.PRINCIPAL_ID = PRINCIPAL_ID;
                mPaysical.POST = 0;
                mPaysical.ExecuteQuery();
                return null;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        public DataTable  SelectPysicalStock(int p_DISTRIBUTOR_ID,int p_POST, int PRINCIPAL_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spSelectPAYSICAL_STOCK mPaysical = new spSelectPAYSICAL_STOCK();
                mPaysical.Connection = mConnection;
                mPaysical.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPaysical.PRINCIPAL_ID = PRINCIPAL_ID;
                mPaysical.POST = 0;
                DataTable dt = mPaysical.ExecuteTable();
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
        public string UpdatePysicalStock(int p_DISTRIBUTOR_ID, DateTime p_STOCK_DATE, int p_SKU_ID, int p_SQUANTITY,int p_UQUANTITY, decimal p_UNIT_RATE, int p_POST, int PRINCIPAL_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spUpdatePAYSICAL_STOCK mPaysical = new spUpdatePAYSICAL_STOCK();
                mPaysical.Connection = mConnection;
                mPaysical.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPaysical.STOCK_DATE = p_STOCK_DATE;
                mPaysical.SKU_ID = p_SKU_ID;
                mPaysical.SALEABLE_QUANTITY  = p_SQUANTITY;
                mPaysical.UNSALEABLE_QUANTITY = p_UQUANTITY;  
                mPaysical.UNIT_RATE = p_UNIT_RATE;
                mPaysical.PRINCIPAL_ID = PRINCIPAL_ID;
                mPaysical.POST = 0;
                mPaysical.ExecuteQuery();
                return null;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        public bool  DELETEPysicalStock(int p_DISTRIBUTOR_ID, DateTime  p_STOCK_DATE, int SKU_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spDeletePAYSICAL_STOCK mPaysical = new spDeletePAYSICAL_STOCK();
                mPaysical.Connection = mConnection;
                mPaysical.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mPaysical.SKU_ID = SKU_ID;
                mPaysical.STOCK_DATE  = p_STOCK_DATE;
                mPaysical.ExecuteQuery();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
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

        public void UpdatePysicalStock(int p, DateTime dateTime, int p_3, int p_4, decimal p_5, int p_6, int p_7)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
