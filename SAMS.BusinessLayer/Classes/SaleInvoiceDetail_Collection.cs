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
	/// Summary description for SaleInvoiceDetail_Collection.
	/// </summary>
	public class SaleInvoiceDetail_Collection
	{


		#region Constructor
		public SaleInvoiceDetail_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Private Variables

		long mSale_Invoice_Detail_Id;
		int mDistributor_Id;
		long mSale_Invoice_Id;
		int mSku_Id;
		int mQuantity_Unit;
		decimal mUnit_Price;
		decimal mRetail_Price;
		decimal mTax_Price;
		float mGst_Rate;
		decimal mAmount;
		decimal mNet_Amount;
		decimal mStandard_Discount;
		decimal mExtra_Discount;
		char mGst_On;
		string mBatch_No;
		long mSale_Order_Detail_Id;


		#endregion

		#region Objects

		SaleInvoicePromotion_Controller SaleInvPromo_ctrl = new SaleInvoicePromotion_Controller();

		#endregion

		#region Public Properties

		public long Sale_Invoice_Detail_Id
		{
			get
			{
				return mSale_Invoice_Detail_Id;
			}
			set
			{
				mSale_Invoice_Detail_Id = value;
			}
		}


		public int Distributor_Id
		{
			get
			{
				return mDistributor_Id;
			}
			set
			{
				mDistributor_Id = value;
			}
		}

		public long Sale_Invoice_Id
		{
			get
			{
				return mSale_Invoice_Id;
			}
			set
			{
				mSale_Invoice_Id = value;
			}
		}


		public int Sku_Id
		{
			get
			{
				return mSku_Id;
			}
			set
			{
				mSku_Id = value;
			}
		}


		public int Quantity_Unit
		{
			get
			{
				return mQuantity_Unit;
			}
			set
			{
				mQuantity_Unit = value;
			}
		}

		public decimal Unit_Price
		{
			get
			{
				return mUnit_Price;
			}
			set
			{
				mUnit_Price = value;
			}
		}

		public decimal Retail_Price
		{
			get
			{
				return mRetail_Price;
			}
			set
			{
				mRetail_Price = value;
			}
		}

		public decimal Tax_Price
		{
			get
			{
				return mTax_Price;
			}
			set
			{
				mTax_Price = value;
			}
		}

		public float Gst_Rate
		{
			get
			{
				return mGst_Rate;
			}
			set
			{
				mGst_Rate = value;
			}
		}

		public decimal Amount
		{
			get
			{
				return mAmount;
			}
			set
			{
				mAmount = value;
			}
		}

		public decimal Net_Amount
		{
			get
			{
				return mNet_Amount;
			}
			set
			{
				mNet_Amount = value;
			}
		}

		public decimal Standard_Discount
		{
			get
			{
				return mStandard_Discount;
			}
			set
			{
				mStandard_Discount = value;
			}
		}

		public decimal Extra_Discount
		{
			get
			{
				return mExtra_Discount;
			}
			set
			{
				mExtra_Discount = value;
			}
		}
		 

		public char Gst_On
		{
			get
			{
				return mGst_On;
			}
			set
			{
				mGst_On = value;
			}
		}

		public string Batch_No
		{
			get
			{
				return mBatch_No;
			}
			set
			{
				mBatch_No = value;
			}
		}

		public long Sale_Order_Detail_Id
		{
			get
			{
				return mSale_Order_Detail_Id;
			}
			set
			{
				mSale_Order_Detail_Id = value;
			}
		}

		public SaleInvoicePromotion_Controller Sale_Invoice_Prmotion_Ctrl
		{
			get
			{
				return SaleInvPromo_ctrl;
			}
			set
			{
				SaleInvPromo_ctrl = value;
			}
		}

		#endregion

	}
}
