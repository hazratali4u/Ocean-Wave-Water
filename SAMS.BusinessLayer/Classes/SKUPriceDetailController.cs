using System;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;
using System.Data;

namespace SAMS.BusinessLayer.Classes
{
   public class SKUPriceDetailController
    {
       public bool InsertSKUPriceDetail(int p_CUSTOMER_ID ,int p_SKUNAME_ID ,decimal p_TRADE_PRICE ,decimal p_RETAIL_PRICE ,decimal p_PURCHASE_PRICE)
       {
           IDbConnection mConnection = null;
           try
           {
               mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
               mConnection.Open();

               spInsertSKU_PRICE_DETAIL ObjInsert = new spInsertSKU_PRICE_DETAIL();
               ObjInsert.Connection = mConnection;
               ObjInsert.CUSTOMER_ID = p_CUSTOMER_ID;
               ObjInsert.SKUNAME_ID = p_SKUNAME_ID;
               ObjInsert.TRADE_PRICE = p_TRADE_PRICE;
               ObjInsert.RETAIL_PRICE = p_RETAIL_PRICE;
               ObjInsert.PURCHASE_PRICE = p_PURCHASE_PRICE;
              
              
               bool Bvalue = ObjInsert.ExecuteQuery();
               return Bvalue;

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
       public DataTable SelectDataPrice(int p_Principal_Id, int p_Division_ID, int p_Category_ID, int p_Brand_id, int p_Var_Id, int p_User_Id,int p_sku_id,int p_Type_id,DateTime p_ClosedDate)
       {
           IDbConnection mConnection = null;
           try
           {
               mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
               mConnection.Open();

               UspSelectSKUPriceList  ObjSelect = new UspSelectSKUPriceList();
               ObjSelect.Connection = mConnection;
               ObjSelect.COMPANY_ID = p_Principal_Id;
               ObjSelect.DIVISION_ID = p_Division_ID;
               ObjSelect.CATEGORY_ID = p_Category_ID;
               ObjSelect.BRAND_ID = p_Brand_id;
               ObjSelect.VAR_ID = p_Var_Id;
               ObjSelect.SKU_ID = p_sku_id;
               ObjSelect.TYPEID = p_Type_id;
               ObjSelect.USER_ID = p_User_Id;
               ObjSelect.DAYCLOSED = p_ClosedDate; 
               DataTable dt = ObjSelect.ExecuteTable();
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



       // by SAFDAR
       public DataTable SelectDataPrice2(int p_Principal_Id, int p_Division_ID, int p_Category_ID, int p_Brand_id, int p_Var_Id, int p_User_Id, int p_sku_id, int p_Type_id, DateTime p_ClosedDate, int p_Customer_id)
       {
           IDbConnection mConnection = null;
           try
           {
               mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
               mConnection.Open();

               UspSelectSKUPriceListCustomer ObjSelect = new UspSelectSKUPriceListCustomer();
               ObjSelect.Connection = mConnection;
               ObjSelect.COMPANY_ID = p_Principal_Id;
               ObjSelect.DIVISION_ID = p_Division_ID;
               ObjSelect.CATEGORY_ID = p_Category_ID;
               ObjSelect.BRAND_ID = p_Brand_id;
               ObjSelect.VAR_ID = p_Var_Id;
               ObjSelect.SKU_ID = p_sku_id;
               ObjSelect.TYPEID = p_Type_id;
               ObjSelect.USER_ID = p_User_Id;
               ObjSelect.DAYCLOSED = p_ClosedDate;
               ObjSelect.CUSTOMER_ID = p_Customer_id;
               DataTable dt = ObjSelect.ExecuteTable();
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





       public DataTable SelectDataPrice2(int p_Principal_Id, int p_Division_ID, int p_Category_ID, int p_Brand_id, int p_Var_Id, int p_User_Id, int p_sku_id, int p_Type_id, DateTime p_ClosedDate)
       {
           IDbConnection mConnection = null;
           try
           {
               mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
               mConnection.Open();

               UspSelectSKUPriceList2 ObjSelect = new UspSelectSKUPriceList2();
               ObjSelect.Connection = mConnection;
               ObjSelect.COMPANY_ID = p_Principal_Id;
               ObjSelect.DIVISION_ID = p_Division_ID;
               ObjSelect.CATEGORY_ID = p_Category_ID;
               ObjSelect.BRAND_ID = p_Brand_id;
               ObjSelect.VAR_ID = p_Var_Id;
               ObjSelect.SKU_ID = p_sku_id;
               ObjSelect.TYPEID = p_Type_id;
               ObjSelect.USER_ID = p_User_Id;
               ObjSelect.DAYCLOSED = p_ClosedDate;
               DataTable dt = ObjSelect.ExecuteTable();
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
       public DataTable SelectData(int p_SKU_PRICEDETAIL_ID,int p_CUSTOMER_ID ,int p_SKUNAME_ID ,decimal p_TRADE_PRICE ,decimal p_RETAIL_PRICE ,decimal p_PURCHASE_PRICE)
       {
           IDbConnection mConnection = null;
           try
           {
               mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
               mConnection.Open();

               spSelectSKU_PRICE_DETAIL ObjSelect = new spSelectSKU_PRICE_DETAIL();
               ObjSelect.Connection = mConnection;
               ObjSelect.SKU_PRICEDETAIL_ID= p_SKU_PRICEDETAIL_ID;
               ObjSelect.CUSTOMER_ID = p_CUSTOMER_ID;
               ObjSelect.SKUNAME_ID = p_SKUNAME_ID;
               ObjSelect.TRADE_PRICE = p_TRADE_PRICE;
               ObjSelect.RETAIL_PRICE = p_RETAIL_PRICE;
               ObjSelect.PURCHASE_PRICE = p_PURCHASE_PRICE;
               DataTable dt = ObjSelect.ExecuteTable();
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
       public bool UpdateSKUPriceDetail(int p_SKU_PRICEDETAIL_ID,int p_CUSTOMER_ID, int p_SKUNAME_ID, decimal p_TRADE_PRICE, decimal p_RETAIL_PRICE, decimal p_PURCHASE_PRICE)
       {
           IDbConnection mConnection = null;
           try
           {
               mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
               mConnection.Open();

               spUpdateSKU_PRICE_DETAIL ObjUpdate = new spUpdateSKU_PRICE_DETAIL();
               ObjUpdate.Connection = mConnection;

               ObjUpdate.SKU_PRICEDETAIL_ID = p_SKU_PRICEDETAIL_ID;
               ObjUpdate.CUSTOMER_ID = p_CUSTOMER_ID;
               ObjUpdate.SKUNAME_ID = p_SKUNAME_ID;
               ObjUpdate.TRADE_PRICE = p_TRADE_PRICE;
               ObjUpdate.RETAIL_PRICE = p_RETAIL_PRICE;
               ObjUpdate.PURCHASE_PRICE = p_PURCHASE_PRICE;

               bool Bvalue = ObjUpdate.ExecuteQuery();
               return Bvalue;
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
       public DataTable LoadGrid()
       {
           IDbConnection mConnection = null;
           try
           {
               mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
               mConnection.Open();

               UspSKU_PRICE_DETAIL_GridData ObjSelect = new UspSKU_PRICE_DETAIL_GridData(); 
               ObjSelect.Connection = mConnection;
               DataTable dt = ObjSelect.ExecuteTable();
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
    }
}
