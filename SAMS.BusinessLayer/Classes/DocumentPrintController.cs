using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
    public class DocumentPrintController
    {
        public DataSet SelectRptGrossProfit(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspGrossProfitReport ObjPrint = new UspGrossProfitReport();
                SAMS.BusinessLayer.Reports.DsReport2 ds = new SAMS.BusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["GrossPrifitReport"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectDocumentforPrint(int p_Distributor_ID, int p_Areaid, int p_Principal_Id, DateTime FromDocNo, DateTime ToDocNo, int DocumentTypeId, long p_DOCUMENT_ID, int p_PRINTTYPE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspDocumentPrinting ObjPrint = new UspDocumentPrinting();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();     
                ObjPrint.Connection = mConnection;  
                ObjPrint.DISTRIBTOR_ID = p_Distributor_ID;
                ObjPrint.AREA_ID = p_Areaid;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE  = FromDocNo;
                ObjPrint.TO_DATE  = ToDocNo;
                ObjPrint.TYPE_ID = DocumentTypeId;
                ObjPrint.DOCUMENT_ID = p_DOCUMENT_ID;
                ObjPrint.PRINTTYPE = p_PRINTTYPE;
                DataTable  dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["SALE_DOCUMENTPRINT"].ImportRow(dr);
                }
                
                uspPrintSALE_ORDER_PROMOTION Promotion = new uspPrintSALE_ORDER_PROMOTION();

                Promotion.Connection = mConnection;
                Promotion.DISTRIBTOR_ID   = p_Distributor_ID;
                Promotion.AREA_ID = p_Areaid;
                Promotion.PRINCIPAL_ID = p_Principal_Id;
                Promotion.FROM_DATE = FromDocNo;
                Promotion.TO_DATE = ToDocNo;
                Promotion.TYPE_ID = DocumentTypeId;
                DataTable dtPro = Promotion.ExecuteTable();

                foreach (DataRow dr in dtPro.Rows)
                {
                    ds.Tables["SALE_PROMOTIONPRINT"].ImportRow(dr);
                }
                return ds;
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
        public DataTable SelectDocumentforView(int p_Distributor_ID, int p_Areaid, int p_Principal_Id, DateTime FromDocNo, DateTime ToDocNo, int DocumentTypeId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspDocumentView ObjPrint = new UspDocumentView();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBTOR_ID = p_Distributor_ID;
                ObjPrint.AREA_ID = p_Areaid;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = FromDocNo;
                ObjPrint.TO_DATE = ToDocNo;
                ObjPrint.TYPE_ID = DocumentTypeId;
                DataTable dt = ObjPrint.ExecuteTable();

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
        public DataSet SelectDelManWise(int p_Distributor_ID, int p_Type_Id, int p_RType_Id, int p_Principal_Id, DateTime FromDocNo, DateTime ToDocNo)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                RptDelManWise ObjPrint = new RptDelManWise();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBTOR_ID = p_Distributor_ID;
                ObjPrint.TYPE_ID = p_Type_Id;
                ObjPrint.RTYPE_ID = p_RType_Id;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = FromDocNo;
                ObjPrint.TO_DATE = ToDocNo;

                DataTable dt = ObjPrint.ExecuteTable();

                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["rptDelManWise"].ImportRow(dr);
                }

                return ds;
              
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

        public DataSet SelectCashSaleRecovery(int p_Distributor_ID, int p_Principal_Id, DateTime FromDocNo, DateTime ToDocNo)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                RptCashSaleRecovery ObjPrint = new RptCashSaleRecovery();
                SAMS.BusinessLayer.Reports.DsReport2 ds = new SAMS.BusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBTOR_ID = p_Distributor_ID;
               
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = FromDocNo;
                ObjPrint.TO_DATE = ToDocNo;

                DataTable dt = ObjPrint.ExecuteTable();

                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCashSale-Recovery"].ImportRow(dr);
                }

                return ds;

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
        public DataSet SelectCustomerRealization(int p_Distributor_ID, int p_RType_Id, int p_Principal_Id, DateTime FromDocNo, DateTime ToDocNo)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                RptCustomerRealization ObjPrint = new RptCustomerRealization();
                SAMS.BusinessLayer.Reports.DsReport2 ds = new SAMS.BusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBTOR_ID = p_Distributor_ID;
                ObjPrint.RTYPE_ID = p_RType_Id;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = FromDocNo;
                ObjPrint.TO_DATE = ToDocNo;

                DataTable dt = ObjPrint.ExecuteTable();

                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCustomerRealization"].ImportRow(dr);
                }

                return ds;

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

        public DataTable SelectReportTitle(int p_Distributor_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectReportTitile ObjPrint = new UspSelectReportTitile();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID  = p_Distributor_ID;
                DataTable dt = ObjPrint.ExecuteTable();
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
        public DataSet SelectPrincipalWiseCustomer(int p_Distributor_ID, int p_Areaid, int p_ChannelType_Id,int p_TownId,bool IsRegister)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectPrincipalWiseCustomer ObjPrint = new UspSelectPrincipalWiseCustomer(); 
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID  = p_Distributor_ID;
                ObjPrint.AREA_ID  = p_Areaid;
                ObjPrint.TOWN_ID = p_TownId;
                ObjPrint.CHANNEL_TYPE_ID = p_ChannelType_Id;
                if (IsRegister)
                {ObjPrint.ROUTE_ID = 1;}
                else
                {ObjPrint.ROUTE_ID = 0;}
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["ViewPrincipalWise_Customer"].ImportRow(dr);
                }
                             
                return ds;
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
        public DataSet SelectValueReconcilation(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date,int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspRptValueReconcilation ObjPrint = new UspRptValueReconcilation();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = p_UserId;  
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptRegionWise_Reconciliation"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectPurchaseDocument(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_TypeId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                GetPurchasedocument ObjPrint = new GetPurchasedocument();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.TYPE_ID = p_TypeId;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptPurchaseDocument"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectPrincipalStockReconcilation(int p_Distributor_ID,int p_Principal_Id, DateTime p_FromDate,DateTime p_To_Date,int p_USER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspRptSelectStockRegister ObjPrint = new uspRptSelectStockRegister();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.distributor_id   = p_Distributor_ID;
                ObjPrint.Company_Id  = p_Principal_Id;
                ObjPrint.DateFrom  = p_FromDate;
                ObjPrint.dateto  = p_To_Date;
                ObjPrint.USER_ID = p_USER_ID;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["StockRegister"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectPetyCashStatment(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_USER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                RptPetyCashStatment ObjPrint = new RptPetyCashStatment();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID  = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID  = p_Principal_Id;
                ObjPrint.FROM_DATE  = p_FromDate;
                ObjPrint.TO_DATE  = p_To_Date;
                ObjPrint.USER_ID = p_USER_ID;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["dbo_PetyCashSummary"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectPetyCashSummary(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_USER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspRptPettyCashSummery ObjPrint = new UspRptPettyCashSummery();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DistributorId = p_Distributor_ID;
                ObjPrint.FromDate  = p_FromDate;
                ObjPrint.ToDate = p_To_Date;
                ObjPrint.USER_ID = p_USER_ID;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["PettyCashSummery"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectPrincipalCreditDetail(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date,int p_USER_ID,int p_SortType,int p_OrderBookerId,int p_SalePersonId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspRptCreditSummary ObjPrint = new UspRptCreditSummary();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID  = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE  = p_FromDate;
                ObjPrint.TO_DATE  = p_To_Date;
                ObjPrint.USER_ID = p_USER_ID;
                ObjPrint.ORDERBOOKER_ID = p_OrderBookerId;
                ObjPrint.SALE_PERSON = p_SalePersonId;  
                DataTable dt = ObjPrint.ExecuteTable();
                DataView dv = new DataView(dt);
                if (p_SortType == 0)
                {
                    dv.Sort = "CUSTOMER_NAME";
                }
                else
                {
                    dv.Sort = "LEDGER_DATE";
                }
                dt = dv.ToTable();  
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCreditSummary"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectOrderBookerCreditAging(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, int p_USER_ID, int p_OrderBookerId, int p_Days, int p_Option)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspOrderBookerCreditAging ObjPrint = new UspOrderBookerCreditAging();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.Credit_date = p_FromDate;
                ObjPrint.USER_ID = p_USER_ID;
                ObjPrint.ORDERBOOKER_ID = p_OrderBookerId;
                ObjPrint.DAYS = p_Days;
                ObjPrint.TYPE_ID = p_Option;
                DataTable dt = ObjPrint.ExecuteTable();

                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCreditAgingOrderbooker"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectCustomerCreditCeiling(int p_Distributor_ID, int p_Principal_Id, int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspCreditLimitReport ObjPrint = new UspCreditLimitReport();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.userid = p_UserId;  
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCustomerWiseCreditSelling"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectBusinessAnalysis(int p_Distributor_ID, DateTime  p_FromDate,DateTime p_ToDate, int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspBusinessAnalysisReport ObjPrint = new UspBusinessAnalysisReport();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_ToDate;
                ObjPrint.UserId = p_UserId;
  
                DataTable dt = ObjPrint.ExecuteTable();
                
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptBusiness_Anaysis Report"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectSalePersonDSR(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date,int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspPrintSaleForceDSR ObjPrint = new UspPrintSaleForceDSR();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID  = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID  = p_Principal_Id;
                ObjPrint.FROM_DATE  = p_FromDate;
                ObjPrint.TO_DATE  = p_To_Date;
                ObjPrint.USER_ID = p_UserId;  
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["SALEPERSON_TRANSCTIONDETAIL"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectCustomerCreditReport(int p_Distributor_ID, int p_Principal_Id, int p_Area_id,int p_CustomerId,int p_ChannelType_Id,int p_Status_id,DateTime p_FromDate, DateTime p_To_Date, int p_UserId,int p_ReportFilter)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspChequeDetailReport ObjPrint = new UspChequeDetailReport();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.AREA_ID = p_Area_id;
                ObjPrint.CHANNEL_TYPE_ID = p_ChannelType_Id;
                ObjPrint.CUSTOMER_ID = p_CustomerId;
                ObjPrint.STATUS_ID = p_Status_id;
                ObjPrint.ReportType = p_ReportFilter; 
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptChequeDetail"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectOrderBookerDSR(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspPrintOrderBookerDSR ObjPrint = new UspPrintOrderBookerDSR();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = p_UserId;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["SALEPERSON_TRANSCTIONDETAIL"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectSalePersonDSRProDuctWise(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date,int User_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                RptSalePersonDSRProductWise ObjPrint = new RptSalePersonDSRProductWise();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = User_Id;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptSaleReportProductWise"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectOrderBookerDSRProDuctWise(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int User_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                RptOrderBookerDSRProductWise ObjPrint = new RptOrderBookerDSRProductWise();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = User_Id;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptSaleReportProductWise"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectCustomerDSRProDuctWise(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int User_Id,int p_AreaId,int ChannelTypeId,int TypeId,int p_SalesForce_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                RptCustomerDSRProductWise ObjPrint = new RptCustomerDSRProductWise();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = User_Id;
                ObjPrint.AREA_ID = p_AreaId;
                ObjPrint.CHANNEL_TYPE_ID = ChannelTypeId;
                ObjPrint.TYPE_ID = TypeId;
                ObjPrint.DELIVERYMAN_ID = p_SalesForce_Id; 
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCustomerProductDSR"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectTradeChannelSale(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int User_Id, int p_AreaId,int p_SalesForce_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspTradeChannelSale ObjPrint = new UspTradeChannelSale();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.UserId = User_Id;
                ObjPrint.AreaId = p_AreaId;
                ObjPrint.DeliveryManId = p_SalesForce_Id;
                ObjPrint.OrderBookerId = Constants.IntNullValue;
   
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptTradeChannelSaleDetail"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectCustomerDSRValueWise(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int User_Id, int p_AreaId, int ChannelTypeId, bool p_IS_REGISTERED,int p_SaleForceId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                

                UspPrintCustomerDSR ObjPrint = new UspPrintCustomerDSR();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = User_Id;
                ObjPrint.AREA_ID = p_AreaId;
                ObjPrint.DELIVERYMAN_ID = p_SaleForceId;  
                if (p_IS_REGISTERED == true)
                {
                    ObjPrint.IS_REGISTERED = 1;
                }
                else
                {
                    ObjPrint.IS_REGISTERED = Constants.IntNullValue;
                }
                ObjPrint.CHANNEL_TYPE_ID = ChannelTypeId;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["CUSTOMER_TRANSCTIONDETAIL"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectVolumeSale(int p_Principal_ID, int p_Distributor_ID, DateTime p_dateTime, int p_OrderBooker_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                uspSaleVolmeRpt mSaleVolume = new uspSaleVolmeRpt();
                mSaleVolume.Connection = mConnection;

                mSaleVolume.PRINCIPAL_ID = p_Principal_ID;
                mSaleVolume.DISTRIBUTOR_ID = p_Distributor_ID;
                mSaleVolume.TODAY_DATE = p_dateTime;
                mSaleVolume.ORDERBOOKER_ID = p_OrderBooker_ID;

                DataTable DT = mSaleVolume.ExecuteTable();
                DT.Columns.Add("Avg%");
                DT.Columns.Add("Balance Target");
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    decimal Avg_PercentAge = 0;
                    int BalanceTarget = 0;
                    if (Convert.ToInt32(DT.Rows[i]["Monthly Target"]) == 0)
                    {
                        Avg_PercentAge = 0;
                    }
                    else
                    {
                        Avg_PercentAge = (Convert.ToDecimal(DT.Rows[i]["Cumm Sales"]) / Convert.ToDecimal(DT.Rows[i]["Monthly Target"])) * 100;
                    }
                    DT.Rows[i]["Avg%"] = Convert.ToString(Avg_PercentAge);
                    BalanceTarget = Convert.ToInt32(DT.Rows[i]["Monthly Target"]) - Convert.ToInt32(DT.Rows[i]["Cumm Sales"]);
                    DT.Rows[i]["Balance Target"] = Convert.ToString(BalanceTarget);
                }

                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["VolumeSale"].ImportRow(dr);

                    //ds.Tables["VolumeSale"].Rows.Add(dr);
                }

                return ds;
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
        public DataSet SelectDailyBankDeposit(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date,int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspDailyBankDeposit ObjPrint = new UspDailyBankDeposit();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = p_UserId; 
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptDailyBankDeposit"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectPaymentReceived(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectPartyStatment ObjPrint = new UspSelectPartyStatment();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptPaymentReceied"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectPartystatment(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspPartyStatement ObjPrint = new UspPartyStatement();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;

                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCustomerStatment"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectTownWiseSales(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, int p_SKU_ID, int p_AREA_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspTownWiseSaleReport ObjPrint = new UspTownWiseSaleReport();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                ObjPrint.PRINCIPAL_ID = p_PRINCIPAL_ID;
                ObjPrint.SKU_ID = p_SKU_ID;
                ObjPrint.AREA_ID = p_AREA_ID;
                
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptTownSalesReport"].ImportRow(dr);
                }

                return ds;
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


        public DataTable SelectTownWiseSales2(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, int p_SKU_ID, int p_AREA_ID,int p_CUSTOMER_ID)
        {
            // by safdar
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                USPADVANCESECURITYINFO ObjPrint = new USPADVANCESECURITYINFO();
               // SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                ObjPrint.PRINCIPAL_ID = p_PRINCIPAL_ID;
                ObjPrint.SKU_ID = p_SKU_ID;
              //  ObjPrint.AREA_ID = p_AREA_ID;
                ObjPrint.CUSTOMER_ID = p_CUSTOMER_ID;
                
                DataTable dt = ObjPrint.ExecuteTable();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    ds.Tables["RptTownSalesReport"].ImportRow(dr);
                //}

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
        public DataSet SelectOrderVSExcusion(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_Type)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectOrderVSExceusion ObjPrint = new UspSelectOrderVSExceusion();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.REPORTTYPE  = p_Type;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptOrderExcustionSummary"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectPurchaseTransferStock(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_TypeId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspDailyPurchaseTransfer ObjPrint = new UspDailyPurchaseTransfer();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.TYPEID = p_TypeId;  
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["DailyPurchaseTransferReport"].ImportRow(dr);
                }

                return ds;
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
        public DataSet SelectUnpostVoucherForPrint(int p_Distributor_ID,string p_VoucherNo,int p_Voucher_Type)
        {
            IDbConnection mConnection = null;
            try
            {
                LedgerController LControler = new LedgerController();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                DataTable dt = LControler.SelectUnPostLedger(p_VoucherNo, p_Distributor_ID, p_Voucher_Type);    
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptVoucherView"].ImportRow(dr);
                }

                return ds;
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
        public DataSet GetRegionSaleDetail(int P_DistributorType, int P_PrincipalId, int P_ZoneId, int P_DistributorId, DateTime P_frmDate, DateTime P_toDate, int P_Category, int P_Type, int P_ReportType,int p_UserId)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                uspRegionWiseSales obj_regionwise = new uspRegionWiseSales();
                obj_regionwise.Connection = mConnection;
                obj_regionwise.CATEGORY_ID = P_Category;
                obj_regionwise.distributor_id = P_DistributorId;
                obj_regionwise.Distributor_type = P_DistributorType;
                obj_regionwise.Zone_id = P_ZoneId;
                obj_regionwise.FROM_DATE = P_frmDate;
                obj_regionwise.TO_DATE = P_toDate;
                obj_regionwise.Type = P_Type;
                obj_regionwise.ReportType = P_ReportType;
                obj_regionwise.PrincipalId = P_PrincipalId;
                obj_regionwise.user_id = p_UserId; 
                DataTable DT = obj_regionwise.ExecuteTable();
                
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RegionWiseSales"].ImportRow(dr);
                }
                return ds;
            }
            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
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
        public DataSet GetCreditAgingReport(int P_DistributorType, int P_PrincipalId,int P_DistributorId,int p_UserId,int p_Type,DateTime p_Document_Date)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                UspCreditAgintReport obj_regionwise = new UspCreditAgintReport();
                obj_regionwise.Connection = mConnection;
                obj_regionwise.DISTRIBUTOR_ID = P_DistributorId;
                obj_regionwise.DISTRIBUTOR_TYPE_ID = P_DistributorType;
                obj_regionwise.TYPE_ID = p_Type;
                obj_regionwise.PRINCIPAL_ID  = P_PrincipalId;
                obj_regionwise.USER_ID = p_UserId;
                obj_regionwise.DOCUMENT_DATE = p_Document_Date; 
                DataTable DT = obj_regionwise.ExecuteTable();

                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptCreditAgingReport"].ImportRow(dr);
                }
                return ds;
            }
            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
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
        public DataSet GetCustomerClassfication(int P_PrincipalId, int P_DistributorId,DateTime p_FromDate,DateTime p_ToDate,string p_QueryAnalysis,int p_ChannelType_id,int p_devision_id,int p_Category_id,int p_Brand_Id, int p_SKU_id)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                UspShowCustomerClassificationReport obj_regionwise = new UspShowCustomerClassificationReport();
                obj_regionwise.Connection = mConnection;
                obj_regionwise.DISTRIBUTOR_ID = P_DistributorId;
                obj_regionwise.PRINCIPAL_ID = P_PrincipalId;
                obj_regionwise.FROM_DATE = p_FromDate;
                obj_regionwise.TO_DATE = p_ToDate;
                obj_regionwise.String = p_QueryAnalysis;
                obj_regionwise.CHANNEL_TYPE_ID = p_ChannelType_id;
                obj_regionwise.Division = p_devision_id;
                obj_regionwise.Category = p_Category_id;
                obj_regionwise.Brand = p_Brand_Id;
                obj_regionwise.SKU_ID = p_SKU_id;  
                DataTable DT = obj_regionwise.ExecuteTable();

                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptCustomerClassfication"].ImportRow(dr);
                }
                return ds;
            }
            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
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
        public DataSet GetCustomerClassficationDetail(int P_PrincipalId, int P_DistributorId, DateTime p_FromDate, DateTime p_ToDate, string p_QueryAnalysis, int p_ChannelType_id, int p_devision_id, int p_Category_id, int p_Brand_Id, int p_SKU_id)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                UspShowCustomerClassificationReport obj_regionwise = new UspShowCustomerClassificationReport();
                obj_regionwise.Connection = mConnection;
                obj_regionwise.DISTRIBUTOR_ID = P_DistributorId;
                obj_regionwise.PRINCIPAL_ID = P_PrincipalId;
                obj_regionwise.FROM_DATE = p_FromDate;
                obj_regionwise.TO_DATE = p_ToDate;
                obj_regionwise.String = p_QueryAnalysis;
                obj_regionwise.CHANNEL_TYPE_ID = p_ChannelType_id;
                obj_regionwise.Division = p_devision_id;
                obj_regionwise.Category = p_Category_id;
                obj_regionwise.Brand = p_Brand_Id;
                obj_regionwise.SKU_ID = p_SKU_id;
                DataTable DT = obj_regionwise.ExecuteTable();

                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptCustomerClassificationDetail"].ImportRow(dr);
                }
                return ds;
            }
            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
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
        public DataSet BankDepositSlipDetail(int p_Principal_ID, int p_Distributor_ID, DateTime p_Fromdate, DateTime p_ToDate, int p_Account_Head_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                UspRptBankDepositSlip mBankDeposit = new UspRptBankDepositSlip();
                mBankDeposit.Connection = mConnection;

                mBankDeposit.PRINCIPAL_ID = p_Principal_ID;
                mBankDeposit.DISTRIBUTOR_ID = p_Distributor_ID;
                mBankDeposit.FromDate = p_Fromdate;
                mBankDeposit.ToDate = p_ToDate;
                mBankDeposit.ACCOUNT_HEAD_ID = p_Account_Head_Id;

                DataTable DT = mBankDeposit.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["BankDepositSlipDetail"].ImportRow(dr);
                }
                return ds;
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
        public DataSet TransferIn(int p_Principal_ID, int p_Distributor_ID, DateTime p_FromTime, DateTime p_ToDate, string p_TransferType,int p_type)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                UspTransferInrpt mTransferIn = new UspTransferInrpt();
                mTransferIn.Connection = mConnection;

                mTransferIn.PRINCIPAL_ID = p_Principal_ID;
                mTransferIn.DISTRIBUTOR_ID = p_Distributor_ID;
                mTransferIn.FromDate = p_FromTime;
                mTransferIn.ToDate = p_ToDate;
                mTransferIn.TransferType = p_TransferType;
                mTransferIn.ReportType = p_type; 
                DataTable DT = mTransferIn.ExecuteTable();
              
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["TransferIn"].ImportRow(dr);
                }
                return ds;
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
        public DataSet TransferInOutValue(int p_Principal_ID, int p_Distributor_ID, DateTime p_FromTime, DateTime p_ToDate, string p_TransferType, int p_type)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                UspTransferInOutValue mTransferIn = new UspTransferInOutValue();
                mTransferIn.Connection = mConnection;

                mTransferIn.PRINCIPAL_ID = p_Principal_ID;
                mTransferIn.DISTRIBUTOR_ID = p_Distributor_ID;
                mTransferIn.FromDate = p_FromTime;
                mTransferIn.ToDate = p_ToDate;
                mTransferIn.TransferType = p_TransferType;
                mTransferIn.ReportType = p_type;
                DataTable DT = mTransferIn.ExecuteTable();

                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptTransferInOutValueWise"].ImportRow(dr);
                }
                return ds;
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
        public DataSet GetDistributorReconcilation(int P_DistributorType, int P_PrincipalId,int P_DistributorId, DateTime P_frmDate, DateTime P_toDate, int p_UserId)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                UspSelectDistributorWiseSale obj_regionwise = new UspSelectDistributorWiseSale();
                obj_regionwise.Connection = mConnection;
                obj_regionwise.LocationType = P_DistributorType;
                obj_regionwise.DistributorId = P_DistributorId;
                obj_regionwise.PrincipalId = P_PrincipalId;
                obj_regionwise.FROM_DATE = P_frmDate;
                obj_regionwise.TO_DATE = P_toDate;
                obj_regionwise.USER_ID  = p_UserId;
                DataTable DT = obj_regionwise.ExecuteTable();

                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["DistributorReconcilation"].ImportRow(dr);
                }
                return ds;
            }
            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
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
        public DataSet BookingSupplyMonitoring(int p_Principal_ID, int p_Distributor_ID, int p_OrderBookerID, DateTime p_Fromdate, DateTime p_ToDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                RptBookingSupplyMonitoringOrder mOrder = new RptBookingSupplyMonitoringOrder();

                mOrder.Connection = mConnection;
                mOrder.PRINCIPAL_ID = p_Principal_ID;
                mOrder.DISTRIBUTOR_ID = p_Distributor_ID;
                mOrder.ORDERBOOKER_ID = p_OrderBookerID;
                mOrder.FROM_DATE = p_Fromdate;
                mOrder.TO_DATE = p_ToDate;
                DataTable Dt_Order = mOrder.ExecuteTable();

                RptBookingSupplyMonitoringInvoice mInvoice = new RptBookingSupplyMonitoringInvoice();
                mInvoice.Connection = mConnection;
                mInvoice.PRINCIPAL_ID = p_Principal_ID;
                mInvoice.DISTRIBUTOR_ID = p_Distributor_ID;
                mInvoice.ORDERBOOKER_ID = p_OrderBookerID;
                mInvoice.FROM_DATE = p_Fromdate;
                mInvoice.TO_DATE = p_ToDate;

                DataTable Dt_Invoice = mInvoice.ExecuteTable();
                foreach (DataRow dr in Dt_Order.Rows)
                {
                    ds.Tables["BookingSupplyMonitoring"].ImportRow(dr);
                }
                int loopCounter = 0;
                int count_orders = Dt_Order.Rows.Count;
                int count_invoice = Dt_Invoice.Rows.Count;
                if (count_orders > count_invoice)
                {
                    loopCounter = count_invoice;
                }
                else { loopCounter = count_orders; }

                for (int i = 0; i < loopCounter; i++)
                {
                    ds.Tables["BookingSupplyMonitoring"].Rows[i]["SupplyValue"] = Convert.ToDecimal(Dt_Invoice.Rows[i]["SupplyValue"].ToString());
                    ds.Tables["BookingSupplyMonitoring"].Rows[i]["ExecutedOrders"] = Convert.ToInt32(Dt_Invoice.Rows[i]["ExecutedOrders"].ToString());
                }
                return ds;
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
        public DataSet LoadPass(int p_Principal_ID, DateTime p_Fromdate,int p_OrderBookerId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport2 ds = new SAMS.BusinessLayer.Reports.DsReport2();

                UspPrintDSR mLoadPass = new UspPrintDSR();
                mLoadPass.Connection = mConnection;
                mLoadPass.PRINCIPAL_ID = p_Principal_ID;
                mLoadPass.DATE  = p_Fromdate;
                mLoadPass.SALEMAN_ID = p_OrderBookerId;
                mLoadPass.DISTRIBUTOR_ID = 0; 
                DataTable DT = mLoadPass.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptPrintDSR"].ImportRow(dr);
                }
                return ds;
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
        public DataSet LoadPassCredit(int p_Principal_ID, DateTime p_Fromdate, int p_OrderBookerId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport2 ds = new SAMS.BusinessLayer.Reports.DsReport2();

                RptLoadPassCredit mLoadPass = new RptLoadPassCredit();
                mLoadPass.Connection = mConnection;
                mLoadPass.PRINCIPAL_ID = p_Principal_ID;
                mLoadPass.RECEIVED_DATE = p_Fromdate;
                mLoadPass.SALEMAN_ID = p_OrderBookerId;
                DataTable DT = mLoadPass.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptLoadCreditDetail"].ImportRow(dr);
                }
                return ds;
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
        public DataTable  LoadPassSummary(int p_Principal_ID, DateTime p_Fromdate, int p_OrderBookerId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport2 ds = new SAMS.BusinessLayer.Reports.DsReport2();

                UspGetCurrentLoadSum mLoadPass = new UspGetCurrentLoadSum();
                mLoadPass.Connection = mConnection;
                mLoadPass.PRINCIPAL_ID = p_Principal_ID;
                mLoadPass.RECEIVED_DATE = p_Fromdate;
                mLoadPass.SALEMAN_ID = p_OrderBookerId;
                DataTable DT = mLoadPass.ExecuteTable();
                return DT;
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
        public DataSet OrderBookerSheet(int p_Principal_ID, int p_Distributor_ID, DateTime p_Fromdate, DateTime p_ToDate, int p_OrderBookerId,int p_User_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                UspOrderBookerSheet mLoadPass = new UspOrderBookerSheet();
                mLoadPass.Connection = mConnection;
                mLoadPass.PRINCIPAL_ID = p_Principal_ID;
                mLoadPass.DISTRIBUTOR_ID = p_Distributor_ID;
                mLoadPass.FROM_DATE = p_Fromdate;
                mLoadPass.TO_DATE = p_ToDate;
                mLoadPass.ORDERBOOKER_ID = p_OrderBookerId;
                mLoadPass.USER_ID = p_User_Id; 
                DataTable DT = mLoadPass.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptOrderBookerSheet"].ImportRow(dr);
                }
                return ds;
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
        public DataSet PhysicalStockTaking(int p_Principal_ID, int p_Distributor_ID, DateTime p_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                RptPhysicalStockTaking mStockTaking = new RptPhysicalStockTaking();

                mStockTaking.Connection = mConnection;
                mStockTaking.PRINCIPAL_ID = p_Principal_ID;
                mStockTaking.DISTRIBUTOR_ID = p_Distributor_ID;
                mStockTaking.Date = p_Date;

                DataTable DT = mStockTaking.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["PhysicalStockTaking"].ImportRow(dr);
                }
                return ds;
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
        public DataSet PhysicalStockTakingValueWise(int p_Principal_ID, int p_Distributor_ID, DateTime p_Date,int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                RptPhysicalStockTakingSummary mStockTaking = new RptPhysicalStockTakingSummary();

                mStockTaking.Connection = mConnection;
                mStockTaking.PRINCIPAL_ID = p_Principal_ID;
                mStockTaking.DISTRIBUTOR_ID = p_Distributor_ID;
                mStockTaking.Date = p_Date;
                mStockTaking.USER_ID = p_UserId;

                DataTable DT = mStockTaking.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptPhysicalStockValue"].ImportRow(dr);
                }
                return ds;
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
        public DataSet PriceList(int p_Principal_ID, int p_Catagory_ID,int p_DistributorId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                rptPriceList mPriceList = new rptPriceList();

                mPriceList.Connection = mConnection;
                mPriceList.PRINCIPAL_ID = p_Principal_ID;
                mPriceList.CATEGORY_ID = p_Catagory_ID;
                mPriceList.DISTRIBUTOR_ID = p_DistributorId; 


                DataTable DT = mPriceList.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["PriceList"].ImportRow(dr);
                }
                return ds;
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
        public DataSet GeneralLedger_View(int p_Principal_ID, long  p_Account_Head_ID, int p_DistributorId,DateTime p_From_Date,DateTime p_ToDate,int p_Posted)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                UspLedgerReport mLedger = new UspLedgerReport();

                mLedger.Connection = mConnection;
                mLedger.PRINCIPAL_ID = p_Principal_ID;
                mLedger.DISTRIBUTOR_ID = p_DistributorId;
                mLedger.ACCOUNT_HEAD_ID = p_Account_Head_ID;
                mLedger.FROM_DATE = p_From_Date;
                mLedger.TO_DATE = p_ToDate;
                mLedger.POSTED = p_Posted;  
                DataTable DT = mLedger.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptLedgerView"].ImportRow(dr);
                }
                return ds;
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
        public DataSet SelectClaimReport(int p_Principal_ID, int p_DistributorId, DateTime p_From_Date, DateTime p_ToDate,int ClaimType)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                UspClaimDetailReport mLedger = new UspClaimDetailReport();

                mLedger.Connection = mConnection;
                mLedger.PRINCIPAL_ID = p_Principal_ID;
                mLedger.DISTRIBUTOR_ID = p_DistributorId;
                mLedger.CLAIM_TYPE = ClaimType; 
                mLedger.FROM_DATE = p_From_Date;
                mLedger.TO_DATE = p_ToDate;

                DataTable DT = mLedger.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptClaimManagmentReport"].ImportRow(dr);
                }
                return ds;
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
        public DataSet CustomerLedger_View(int p_Principal_ID,int p_DistributorId,int  p_CustomerId, DateTime p_From_Date, DateTime p_ToDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                UspCustomerLedger mLedger = new UspCustomerLedger();

                mLedger.Connection = mConnection;
                mLedger.principal_id = p_Principal_ID;
                mLedger.Distributor_id = p_DistributorId;
                mLedger.customer_id = p_CustomerId;
                mLedger.From_Date = p_From_Date;
                mLedger.To_Date  = p_ToDate;

                DataTable DT = mLedger.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptCustomerLedgerView"].ImportRow(dr);
                }
                return ds;
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

        public DataSet CustomerDailyRecoveryReport(int p_Principal_ID, int p_DistributorId, int p_CustomerId, DateTime p_From_Date, DateTime p_ToDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport2 ds = new SAMS.BusinessLayer.Reports.DsReport2();

                UspCustomerDailyRecovery mLedger = new UspCustomerDailyRecovery();

                mLedger.Connection = mConnection;
                mLedger.principal_id = p_Principal_ID;
                mLedger.Distributor_id = p_DistributorId;
                mLedger.customer_id = p_CustomerId;
                mLedger.From_Date = p_From_Date;
                mLedger.To_Date = p_ToDate;

                DataTable DT = mLedger.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["UspCustomerDailyRecovery"].ImportRow(dr);
                }
                return ds;
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

        public DataSet MonthlyFinancialReport(int p_Principal_ID, int p_DistributorId, DateTime p_From_Date, DateTime p_ToDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport2 ds = new SAMS.BusinessLayer.Reports.DsReport2();

                UspMonthlyFinancialReport mLedger = new UspMonthlyFinancialReport();

                mLedger.Connection = mConnection;
                mLedger.principal_id = p_Principal_ID;
                mLedger.Distributor_id = p_DistributorId;
             
                mLedger.From_Date = p_From_Date;
                mLedger.To_Date = p_ToDate;

                DataTable DT = mLedger.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["UspMonthlyFinancialReport"].ImportRow(dr);
                }
                return ds;
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
   
        
        public DataSet SelectBillCustomerDetail(int p_Principal_ID, string  p_Customer_Id,int p_SKU_ID, string  p_DistributorId, DateTime p_From_Date, DateTime p_ToDate,Byte p_showAll)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                UspBillWiseCustomerReport mLedger = new UspBillWiseCustomerReport();

                mLedger.Connection = mConnection;
                mLedger.PRINCIPAL_ID = p_Principal_ID;
                mLedger.DISTRIBUTOR_ID = p_DistributorId;
                mLedger.CUSTOMER_ID = p_Customer_Id;
                mLedger.SKU_ID = p_SKU_ID;
                mLedger.FROM_DATE = p_From_Date;
                mLedger.TO_DATE = p_ToDate;
                mLedger.ShowAll = p_showAll;  

                DataTable DT = mLedger.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptBillCustomerReport"].ImportRow(dr);
                }
                return ds;
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

        public DataSet SelectBillCustomerDetailNew(int p_Principal_ID, string p_Customer_Id, int p_SKU_ID, string p_DistributorId, Byte p_showAll)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                UspBillWiseCustomerReportNew mLedger = new UspBillWiseCustomerReportNew();

                mLedger.Connection = mConnection;
                mLedger.PRINCIPAL_ID = p_Principal_ID;
                mLedger.DISTRIBUTOR_ID = p_DistributorId;
                mLedger.CUSTOMER_ID = p_Customer_Id;
                mLedger.SKU_ID = p_SKU_ID;
                mLedger.ShowAll = p_showAll;

                DataTable DT = mLedger.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptBillCustomerReport"].ImportRow(dr);
                }
                return ds;
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
        public DataSet SelectCustomerMonthlySales(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int Category_Id, int p_AreaId, int ChannelTypeId, int TypeId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspCustomerMonthlySales ObjPrint = new UspCustomerMonthlySales();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.Distributor_id = p_Distributor_ID;
                ObjPrint.Principal_id = p_Principal_Id;
                ObjPrint.From_date = p_FromDate;
                ObjPrint.To_Date  = p_To_Date;
                ObjPrint.Area_id = p_AreaId;
                ObjPrint.ChanneltypeId  = ChannelTypeId;
                ObjPrint.Type_Id = TypeId;
                ObjPrint.Category_id = Category_Id;
 
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["CustomerMonthlySales"].ImportRow(dr);
                }

                return ds;
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
        public DataSet OutletWiseSale(int p_Principal_ID, int p_Distributor_ID, DateTime p_StartDate, DateTime p_EndDate, string p_CatagoryIDS)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                RptOutletWiseSale mOutletwiseSale = new RptOutletWiseSale();
                mOutletwiseSale.Connection = mConnection;

                mOutletwiseSale.Principal_ID = p_Principal_ID;
                mOutletwiseSale.Distributor_ID = p_Distributor_ID;
                mOutletwiseSale.FromDate = p_StartDate;
                mOutletwiseSale.ToDate = p_EndDate;
                mOutletwiseSale.Catagory_IDs = p_CatagoryIDS;

                DataTable DT = mOutletwiseSale.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["OutletWiseSale"].ImportRow(dr);
                }
                return ds;
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
        public DataSet PrincipalWiseSale(int p_Principal_ID, int p_Distributor_ID, DateTime p_StartDate, DateTime p_EndDate, string p_CatagoryIDS,int p_ReportType)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                UspPrincipalWiseExp mOutletwiseSale = new UspPrincipalWiseExp();
                mOutletwiseSale.Connection = mConnection;

                mOutletwiseSale.PRINCIPAL_ID = p_Principal_ID;
                mOutletwiseSale.DISTRIBUTOR_ID = p_Distributor_ID;
                mOutletwiseSale.FROM_DATE = p_StartDate;
                mOutletwiseSale.TO_DATE  = p_EndDate;
                mOutletwiseSale.ACCOUNT_IDs = p_CatagoryIDS;
                mOutletwiseSale.TYPE_ID = p_ReportType;  

                DataTable DT = mOutletwiseSale.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptPrincipalWiseExp"].ImportRow(dr);
                }
                return ds;
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
        public DataSet PromotionDetail(int p_Principal_ID, int p_Distributor_ID, DateTime p_StartDate, DateTime p_EndDate, int p_PromotionType)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                RptPromotionReport mPromotionReport = new RptPromotionReport();

                mPromotionReport.Connection = mConnection;
                mPromotionReport.Principal_ID = p_Principal_ID;
                mPromotionReport.Distributor_ID = p_Distributor_ID;
                mPromotionReport.START_DATE = p_StartDate;
                mPromotionReport.END_DATE = p_EndDate;
                mPromotionReport.ISACTIVE = Convert.ToBoolean(p_PromotionType);
                DataTable DT = mPromotionReport.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["PromotionReport"].ImportRow(dr);
                }
                return ds;
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
        public DataSet SelectDailyUpdateSales(int p_Principal_ID, int p_Distributor_ID, DateTime p_dateTime, int p_Region, int p_Zone, int p_Territory_Id, int p_Type)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();
                UspDailySaleUpdate mSaleVolume = new UspDailySaleUpdate();
                mSaleVolume.Connection = mConnection;
                mSaleVolume.PRINCIPAL_ID = p_Principal_ID;
                mSaleVolume.DISTRIBUTOR_ID = p_Distributor_ID;
                mSaleVolume.TARGET_DATE = p_dateTime;
                mSaleVolume.Region_Id = p_Region;
                mSaleVolume.Zone_Id = p_Zone;
                mSaleVolume.Territory_Id = p_Territory_Id;
                mSaleVolume.TYPE_ID = p_Type;
                DataTable DT = mSaleVolume.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptDailySalesUpdated"].ImportRow(dr);
                }
                return  ds;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return  null;
            }
            finally
            {
                if ((mConnection != null) && (mConnection.State == ConnectionState.Open))
                {
                    mConnection.Close();
                }
            }
        }
        public DataSet CustomerClaim_Slip(int p_Principal_ID, int p_DistributorId, int p_CustomerId, DateTime p_From_Date, DateTime p_ToDate,int p_PaymentMode)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                UspPrintClaimSlip mLedger = new UspPrintClaimSlip();

                mLedger.Connection = mConnection;
                mLedger.principal_id = p_Principal_ID;
                mLedger.Distributor_id = p_DistributorId;
                mLedger.customer_id = p_CustomerId;
                mLedger.From_Date = p_From_Date;
                mLedger.To_Date = p_ToDate;
                mLedger.Payment_Mode = p_PaymentMode;  

                DataTable DT = mLedger.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptClaimSlipDetail"].ImportRow(dr);
                }
                return ds;
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

        public DataSet SelectSALEFORCE_AREA_ROOT_CUSTOMER_ASSIGNMENT(int p_Distributor_ID,  int p_SaleForce_Id,int p_Area_ID, int p_Days)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                var objPrint = new uspRptSALEFORCE_AREA_ROOT_CUSTOMER_ASSIGNMENT();
                var ds = new Reports.dsSaleForce();
                objPrint.Connection = mConnection;
                objPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                objPrint.AREA_ID = p_Area_ID ;
                objPrint.DAY_ID  = p_Days ;
                objPrint.SALEFORCE_ID  = p_SaleForce_Id ;
           
                DataTable dt = objPrint.ExecuteTable();

                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["uspRptSALEFORCE_AREA_ROOT_CUSTOMER_ASSIGNMENT"].ImportRow(dr);
                }

                return ds;
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


        public DataSet SALEFORCE_AREA_Sale_report(int p_Distributor_ID, int p_SaleForce_Id, long p_Area_ID, int p_Days,int p_Sku_ID, DateTime p_working_date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspRptSALEFORCE_AREA_SALE_REPORT ObjPrint = new uspRptSALEFORCE_AREA_SALE_REPORT();
                Reports.dsSaleForce ds = new Reports.dsSaleForce();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.AREA_ID = p_Area_ID;
                ObjPrint.DAY_ID = p_Days;
                ObjPrint.SALEFORCE_ID = p_SaleForce_Id;
                ObjPrint.TIME_STAMP = p_working_date;
                ObjPrint.SKU_ID = p_Sku_ID;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["uspRptSALEFORCE_AREA_SALE_REPORT"].ImportRow(dr);
                }

                return ds;
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
       







        #region Added By Hazrat Ali

        /// <summary>
        /// Gets Data For Customer Sale Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="User_Id">User</param>
        /// <param name="p_AreaId">Route</param>
        /// <param name="ChannelTypeId">ChannelType</param>
        /// <param name="p_IS_REGISTERED">IsRegistered</param>
        /// <param name="p_SaleForceId">SaleForce</param>
        /// <returns>DataTypes</returns>
        public DataSet SelectCustomerSaleReport(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int User_Id, int p_AreaId, int ChannelTypeId, bool p_IS_REGISTERED, int p_SaleForceId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspCustomerSaleReport ObjPrint = new UspCustomerSaleReport();
                SAMS.BusinessLayer.Reports.DsReport2 ds = new SAMS.BusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.AREA_ID = p_AreaId;
                ObjPrint.CHANNEL_TYPE_ID = ChannelTypeId;
                ObjPrint.SALEFORCE_ID = p_SaleForceId;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCustomerSaleReport"].ImportRow(dr);
                }

                return ds;
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

        /// <summary>
        /// Gets Data For Booking vs Execution Report (Date Wise)
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_OrderBookerID">OrderBooker</param>
        /// <param name="p_DELIVERYMAN_ID">Deliveryman</param>
        /// <param name="p_Fromdate">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <returns>DataSet</returns>
        public DataSet BookingVsExecution(int p_Principal_ID, int p_Distributor_ID, int p_OrderBookerID, int p_DELIVERYMAN_ID, DateTime p_Fromdate, DateTime p_ToDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport ds = new SAMS.BusinessLayer.Reports.DsReport();

                RptOrderVsExecution mOrder = new RptOrderVsExecution();

                mOrder.Connection = mConnection;
                mOrder.PRINCIPAL_ID = p_Principal_ID;
                mOrder.DISTRIBUTOR_ID = p_Distributor_ID;
                mOrder.ORDERBOOKER_ID = p_OrderBookerID;
                mOrder.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mOrder.FROM_DATE = p_Fromdate;
                mOrder.TO_DATE = p_ToDate;
                DataTable Dt_Order = mOrder.ExecuteTable();

                foreach (DataRow dr in Dt_Order.Rows)
                {
                    ds.Tables["BookingSupplyMonitoring"].ImportRow(dr);
                }

                return ds;
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

        /// <summary>
        /// Gets Data For Booking vs Execution Report (SKU Wise)
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_OrderBookerID">OrderBooker</param>
        /// <param name="p_DELIVERYMAN_ID">Deliveryman</param>
        /// <param name="p_Fromdate">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <param name="p_REPORT_TYPE">ReportType</param>
        /// <returns>DataSet</returns>
        public DataSet SKUWiseBookingVsExecution(int p_Principal_ID, int p_Distributor_ID, int p_OrderBookerID, int p_DELIVERYMAN_ID, DateTime p_Fromdate, DateTime p_ToDate, int p_REPORT_TYPE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMS.BusinessLayer.Reports.DsReport2 ds = new SAMS.BusinessLayer.Reports.DsReport2();

                RptSKUWiseBookingVsExecution mOrder = new RptSKUWiseBookingVsExecution();

                mOrder.Connection = mConnection;
                mOrder.PRINCIPAL_ID = p_Principal_ID;
                mOrder.DISTRIBUTOR_ID = p_Distributor_ID;
                mOrder.ORDERBOOKER_ID = p_OrderBookerID;
                mOrder.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mOrder.FROM_DATE = p_Fromdate;
                mOrder.TO_DATE = p_ToDate;
                mOrder.REPORT_TYPE = p_REPORT_TYPE;
                DataTable Dt_Order = mOrder.ExecuteTable();

                foreach (DataRow dr in Dt_Order.Rows)
                {
                    ds.Tables["RptSKUWiseBookingVsExecution"].ImportRow(dr);
                }

                return ds;
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

        #endregion
    }
}
