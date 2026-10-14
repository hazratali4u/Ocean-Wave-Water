using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DatabaseLayer.Classes;
using SAMS.DataAccessLayer.Classes;
using System.Collections;
 
namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for TransferDocumentControl.
	/// </summary>
	public class TransferDocumentControl
	{
        #region Variables 

		public static ArrayList sale_transfer = new ArrayList();
        public static ArrayList sale_transfer_details = new ArrayList();
		long SaleTransferID;
 
		public static IDbConnection mConnection ;
		#endregion
		
		public TransferDocumentControl()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	
		#region Static Methods  
		 
		#region to check either SaleInvoiceID and BatchNO and skuID Already Existed from the table and from the Collection

		public static bool Is_SaleInvoiceID_And_BatchNoExists(long SaleInvoiceID , string BatchNo,int skuID  )
		{
			
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
    			
			}
			catch(Exception exp)
			{
				throw exp;
			} 
			finally
			{
			}

	
			uspSelectSALE_TRANSFER_DETAIL objSaleTransferDetail = new uspSelectSALE_TRANSFER_DETAIL();
            objSaleTransferDetail.Connection = mConnection;
            objSaleTransferDetail.SALE_INVOICE_ID = SaleInvoiceID;
			objSaleTransferDetail.BATCH_NO = BatchNo;
			objSaleTransferDetail.SKU_ID = skuID;

			DataTable objResult = objSaleTransferDetail.ExecuteTable();
			if(mConnection != null && mConnection.State == ConnectionState.Open)
			{
				mConnection.Close();
			}
			mConnection = null;
		
			if(objResult.Rows.Count > 0)
			{
			   return true;

			}
			else
	   		{
			if(sale_transfer.Count  > 0 && sale_transfer_details.Count > 0)
			{
				for(int count = 0;count<sale_transfer.Count && count < sale_transfer_details.Count;count ++)
				{
					if(((spInsertSALE_TRANSFER)sale_transfer[count]).SALE_INVOICE_ID == SaleInvoiceID && ((spInsertSALE_TRANSFER_DETAIL)sale_transfer_details[count]).BATCH_NO == BatchNo)
					{
						return true; 
					}
				}
				return false; 
			}
			return false;
		}
		}
   
		#endregion

		#region Save Sale_Transfer Record to the Collection
  

		public static void Save_SaleTransfer(long SaleInvoiceID , long CustomerID)
		{
			int TerritoryID = 0;
			int DeliveryManID = 0;
			int OrderbookerID = 0;
			
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
    			
			}
			catch(Exception exp)
			{
				throw exp;
			} 
			finally
			{
			}

			spSelectSALE_INVOICE_MASTER objSale_Invoice_Master = new spSelectSALE_INVOICE_MASTER();
			objSale_Invoice_Master.Connection = mConnection;
			
			objSale_Invoice_Master.SALE_INVOICE_ID = SaleInvoiceID;
			objSale_Invoice_Master.SALE_ORDER_ID = Constants.LongNullValue;
			objSale_Invoice_Master.SHIP_TO= Constants.LongNullValue;
			objSale_Invoice_Master.SHIPMENT_DATE = Constants.DateNullValue;
			objSale_Invoice_Master.SOLD_TO    = Constants.LongNullValue;
			objSale_Invoice_Master.STANDARD_DISCOUNT_AMOUNT =  Constants.DecimalNullValue;
			objSale_Invoice_Master.TERRITORY_ID = Constants.IntNullValue;
			objSale_Invoice_Master.TIME_STAMP = Constants.DateNullValue;
			objSale_Invoice_Master.TOTAL_AMOUNT = Constants.DecimalNullValue;
			objSale_Invoice_Master.TOTAL_CLAIM_AMOUNT = Constants.DecimalNullValue;
			objSale_Invoice_Master.TOTAL_NET_AMOUNT = Constants.DecimalNullValue;
			objSale_Invoice_Master.ORDERBOOKER_ID = Constants.IntNullValue;
			objSale_Invoice_Master.DELIVERYMAN_ID = Constants.IntNullValue;
            objSale_Invoice_Master.LASTUPDATE_DATE = Constants.DateNullValue;
            objSale_Invoice_Master.GST_AMOUNT = Constants.DecimalNullValue;
			objSale_Invoice_Master.AREA_ID = Constants.LongNullValue;
            objSale_Invoice_Master.EXTRA_DISCOUNT_AMOUNT = Constants.DecimalNullValue;
        	objSale_Invoice_Master.DOCUMENT_DATE = Constants.DateNullValue;
			objSale_Invoice_Master.DISTRIBUTOR_ID = Constants.IntNullValue;
			DataTable objResult = objSale_Invoice_Master.ExecuteTable();
			if(objResult.Rows.Count > 0)
			{
				TerritoryID =  int.Parse(objResult.Rows[0]["TERRITORY_ID"].ToString());
				OrderbookerID = int.Parse(objResult.Rows[0]["ORDERBOOKER_ID"].ToString());
				DeliveryManID = int.Parse(objResult.Rows[0]["DELIVERYMAN_ID"].ToString());
			}
			//			
		 
			if(mConnection != null && mConnection.State == ConnectionState.Open)
			{
				mConnection.Close();
			}
			mConnection = null;
			

			spInsertSALE_TRANSFER objSale_Transfer = new spInsertSALE_TRANSFER();
            objSale_Transfer.CUSTOMER_ID = CustomerID;
            objSale_Transfer.DELIVERYMAN_ID = DeliveryManID;
            objSale_Transfer.DOCUMENT_DATE = DateTime.Now;
            objSale_Transfer.ORDERBOOKER_ID = OrderbookerID;
            objSale_Transfer.SALE_INVOICE_ID = SaleInvoiceID;
            objSale_Transfer.TERRITORY_ID = TerritoryID;
			objSale_Transfer.TIME_STAMP = DateTime.Now;
	        sale_transfer.Add (objSale_Transfer);

			
		}
 
		#endregion

		#region Save Sale Transfer Detail Record to the Collection
 

		public static void Save_SaleTransferDetail(long SaleInvoiceDetailID,int SKU,int ReplacedSKU,int quantity,string batch_no,string replaced_batch_no)
		{
			spInsertSALE_TRANSFER_DETAIL objSaleTransferDetail = new spInsertSALE_TRANSFER_DETAIL();
			objSaleTransferDetail.SKU_ID =  SKU;
			objSaleTransferDetail.SALE_INVOICE_DETAIL_ID = SaleInvoiceDetailID;
			objSaleTransferDetail.REPLACED_SKU_ID = ReplacedSKU;
			objSaleTransferDetail.QUANTITY_UNIT = quantity;
			objSaleTransferDetail.BATCH_NO = batch_no;
			objSaleTransferDetail.REPLACED_BATCH_NO = replaced_batch_no;
			sale_transfer_details.Add( objSaleTransferDetail);
		}
     #endregion

		#region Get Sale Invoice ID and Sale Order ID by the CustomerID

 

		public static DataTable GetCustomerSALE_ORDER_And_INVOICE(long CustomerID)
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
    			
			}
			catch(Exception exp)
			{
				throw exp;
			} 
			finally
			{
			}

				uspSelectSALE_INVOICE_MASTERS objSaleInvoiceMaster = new uspSelectSALE_INVOICE_MASTERS();
				objSaleInvoiceMaster.Connection = mConnection;
				objSaleInvoiceMaster.SOLD_TO = CustomerID;
            	DataTable objResultSaleInvoiceMaster =  objSaleInvoiceMaster.ExecuteTable();
			
			    if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
				mConnection = null;
			
				return objResultSaleInvoiceMaster;

			
		}
# endregion
		 
		#region Get Skus against DistributorID

		public static DataTable GetAllSKUS(int DistributorID)
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
    			
			}
			catch(Exception exp)
			{
				throw exp;
			} 
			finally
			{
			}
		    uspSelect_SKU_Dist_Wise1 objSelectSKUDistWise1 = new uspSelect_SKU_Dist_Wise1();
            objSelectSKUDistWise1.Connection = mConnection;
			objSelectSKUDistWise1.Dist_ID = DistributorID;
			DataTable objResult = objSelectSKUDistWise1.ExecuteTable();
			if(mConnection != null && mConnection.State == ConnectionState.Open)
			{
				mConnection.Close();
			}
			mConnection = null;
		
			return objResult;


		}
		#endregion

		#region Get SKUS against Sale Invoice ID and DistributorID

		public static DataTable GetSKUS(long SALE_INVOICE_ID,int DistributorID)
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
    			
			}
			catch(Exception exp)
			{
				throw exp;
			} 
			finally
			{
			}
		    uspSelectSALE_INVOICE_DETAILS objSaleInvoiceDetails = new  uspSelectSALE_INVOICE_DETAILS();
			objSaleInvoiceDetails.Connection = mConnection;
            objSaleInvoiceDetails.SALE_INVOICE_ID = SALE_INVOICE_ID;
           	objSaleInvoiceDetails.DISTRIBUTOR_ID = DistributorID;
            DataTable objResultSaleInvoiceDetail = objSaleInvoiceDetails.ExecuteTable();
        	
			if(mConnection != null && mConnection.State == ConnectionState.Open)
			{
				mConnection.Close();
			}
			mConnection = null;
		
			return objResultSaleInvoiceDetail;

//			return null;
		}
       #endregion
 
		#region  Get Batches Against Sale Invoice ID  
		public  static DataTable GetBatches(long SaleInvoiceID )
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
    			
			}
			catch(Exception exp)
			{
				throw exp;
			} 
			finally
			{
			}
	      	uspSelectSALE_INVOICE_DETAILS1 objSaleInvoiceDetail = new uspSelectSALE_INVOICE_DETAILS1();
            objSaleInvoiceDetail.Connection = mConnection;
			objSaleInvoiceDetail.SALE_INVOICE_ID = SaleInvoiceID;
            DataTable objResult = objSaleInvoiceDetail.ExecuteTable();
            
			
			
			if(mConnection != null && mConnection.State == ConnectionState.Open)
			{
				mConnection.Close();
			}
			mConnection = null;
			return objResult;
   
		}
		#endregion

		#region Get Sale Invoice Detail ID and Quantity Unit against Sale Invoice ID and  Batch No and skuID
  

		public static DataTable GetSaleInvoiceDetailInfo(long SaleInvoiceID,string batch_no,int skuID)
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
			}
			catch(Exception exp)
			{
				throw exp;
			} 
			finally
			{
			
			}
	      	uspSelectSALE_INVOICE_DETAIL2 objSaleInvoiceDetail2 = new uspSelectSALE_INVOICE_DETAIL2();
            objSaleInvoiceDetail2.Connection = mConnection;
            objSaleInvoiceDetail2.SALE_INVOICE_ID = SaleInvoiceID;
			objSaleInvoiceDetail2.BATCH_NO = batch_no;
            objSaleInvoiceDetail2.SKU_ID = skuID;
			DataTable objResult = objSaleInvoiceDetail2.ExecuteTable();
			if(mConnection != null && mConnection.State == ConnectionState.Open)
			{
				mConnection.Close();
			}
			mConnection = null;
		
			return  objResult;

		}
		#endregion

		#region Save Records in the database table exist in the Collection 
   
		public static void Save()
		{
			mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			try
			{
				mConnection.Open();
			}
			catch(Exception exp)
			{
				throw exp;
			} 
			finally
			{
			
			}
	      	
			for(int count = 0;count < sale_transfer.Count && count < sale_transfer_details.Count ;count ++)
			{
			   ((spInsertSALE_TRANSFER)sale_transfer[count]).Connection = mConnection;
               long  Sale_Transfer_Id =   ((spInsertSALE_TRANSFER)sale_transfer[count]).ExecuteQuery();
                ((spInsertSALE_TRANSFER_DETAIL)sale_transfer_details[count]).Connection = mConnection;
                 ((spInsertSALE_TRANSFER_DETAIL)sale_transfer_details[count]).SALE_TRANSFER_ID = Sale_Transfer_Id;
                ((spInsertSALE_TRANSFER_DETAIL)sale_transfer_details[count]).ExecuteQuery();
			}
		
			if(mConnection != null && mConnection.State == ConnectionState.Open)
			{
				mConnection.Close();
			}
			mConnection = null;
		
            sale_transfer = null;
		    sale_transfer = new ArrayList();
            sale_transfer_details = null;
            sale_transfer_details = new ArrayList();
		} 
        #endregion
        
		#endregion


	}
}
