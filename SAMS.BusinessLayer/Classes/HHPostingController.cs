using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
    public class HHPostingController
    {

        public DataTable SelectDistributorSalesForce(int p_Distributor_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                uspSelectDISTRIBUTORSalesForce mDistUser = new uspSelectDISTRIBUTORSalesForce();
                mDistUser.Connection = mConnection;
                mDistUser.DISTRIBUTOR_ID = p_Distributor_Id;

                DataTable dt = mDistUser.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                //ExceptionPublisher.PublishException(exp);		
                exp.ToString();
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

        public DataTable GetOrders(int p_OrderBookerID, int p_AreaID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspGetSaleOrderforPosting mGetOrder = new UspGetSaleOrderforPosting();

                mGetOrder.Connection = mConnection;
                mGetOrder.AREA_ID = p_AreaID;
                mGetOrder.ORDERBOOKER_ID = p_OrderBookerID;

                DataTable dt = mGetOrder.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                //ExceptionPublisher.PublishException(exp);		
                exp.ToString();
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

     

        public bool InsertSaleOrderMaster(int p_HHSaleOrderId,int p_OrderBookerID, int p_DELIVERYMAN_ID, int p_Order_Type_ID, int p_UserID)
        {
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                UspPostingHHOrder pInsert = new UspPostingHHOrder();
                pInsert.Connection = mConnection;
                pInsert.Transaction = mTransaction;
                pInsert.HHSaleOrderId = p_HHSaleOrderId;
                pInsert.ORDERBOOKER_ID = p_OrderBookerID;
                pInsert.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                pInsert.ORDER_TYPE_ID  = p_Order_Type_ID;
                pInsert.UserID = p_UserID;
               
                bool Bvalue1 = pInsert.ExecuteQuery();
                if (Bvalue1 == true)
                {
                    mTransaction.Commit();
                    return true;
                }
                else
                {
                    mTransaction.Rollback();
                    return false; 
                }
                
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);		
                mTransaction.Rollback();  
                exp.ToString();
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
        //public bool InsertSaleOrderDetail(int p_HHSaleOrderlId, int p_SALE_ORDER_ID)
        //{
        //    IDbConnection mConnection = null;
        //    try
        //    {
        //        mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
        //        mConnection.Open();

        //        UspInsertPostingSaleOrderDetail pInsert = new UspInsertPostingSaleOrderDetail();

        //        pInsert.Connection = mConnection;
        //        pInsert.HHSaleOrderId = p_HHSaleOrderlId;
        //        pInsert.SALE_ORDER_ID = p_SALE_ORDER_ID;

        //        bool Bvalue = pInsert.ExecuteQuery();
        //        return Bvalue;
        //        //return dt;
        //    }
        //    catch (Exception exp)
        //    {
        //        //ExceptionPublisher.PublishException(exp);	
        //        exp.ToString();
        //        return false;
        //    }
        //    finally
        //    {
        //        if (mConnection != null && mConnection.State == ConnectionState.Open)
        //        {
        //            mConnection.Close();
        //        }
        //    }
        //}

        //public bool InsertSaleOrderPromotion(int p_HHSaleOrderlId, int p_SALE_ORDER_ID)
        //{
        //    IDbConnection mConnection = null;
        //    try
        //    {
        //        mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
        //        mConnection.Open();

        //        UspInsertPostingSaleOrderPromotion pInsert = new UspInsertPostingSaleOrderPromotion();
        //        pInsert.Connection = mConnection;
        //        pInsert.HHSaleOrderId = p_HHSaleOrderlId;
        //        pInsert.SALE_ORDER_ID = p_SALE_ORDER_ID;

        //        bool Bvalue = pInsert.ExecuteQuery();
        //        return Bvalue;
        //    }
        //    catch (Exception exp)
        //    {
        //        //ExceptionPublisher.PublishException(exp);	
        //        exp.ToString();
        //        return false;
        //    }
        //    finally
        //    {
        //        if (mConnection != null && mConnection.State == ConnectionState.Open)
        //        {
        //            mConnection.Close();
        //        }
        //    }
        //}
    }
}
