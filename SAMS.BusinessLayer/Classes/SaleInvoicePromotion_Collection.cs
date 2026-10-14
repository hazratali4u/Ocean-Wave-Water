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
	/// Summary description for SaleInvoicePromotion_Collection.
	/// </summary>
	public class SaleInvoicePromotion_Collection
	{

		#region Constructor
		public SaleInvoicePromotion_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion


		#region Private Variables

		long mSale_Invoice_Promotion_Id;
		int mDistributor_Id;
		int mPromotion_Offer_Id;
		int mBasket_Id;
		int mPromotion_Id;
		int mScheme_Id;
		int mBasket_Detail_Id;
		long mSale_Invoice_Detail_Id;
		decimal mUnit_Price;
		decimal mRetail_Price;
		float mGst_Rate;
		decimal mGst_Amount;
		int mQuantity;
		decimal mClaim_Amount;
		int mSale_Order_Promotion_Id;
		int mSku_Id;
		bool mIs_Scheme;
		decimal mDisc_Rate;
		decimal mDisc_Amount;
		long mSale_Invoice_Master_Id;

		#endregion


		#region Public Properties

		public long Sale_Invoice_Master_Id
		{
			get
			{
				return mSale_Invoice_Master_Id; 
			}
			set
			{
				mSale_Invoice_Master_Id = value;
			}

		}

		public decimal Disc_Amount
		{
			get
			{
				return mDisc_Amount;
			}
			set
			{
				mDisc_Amount = value;
			}
		}

		public decimal Disc_Rate
		{
			get
			{
				return mDisc_Rate;
			}
			set
			{
				mDisc_Rate = value;
			}
		}

		public bool Is_Scheme
		{
			get
			{
				return mIs_Scheme;
			}
			set
			{
				mIs_Scheme = value;
			}
		}

		public long Sale_Invoice_Promotion_Id
		{
			get
			{
				return mSale_Invoice_Promotion_Id;
			}
			set
			{
				mSale_Invoice_Promotion_Id = value;
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

		
		public int Promotion_Offer_Id
		{
			get
			{
				return mPromotion_Offer_Id;
			}
			set
			{
				mPromotion_Offer_Id = value;
			}
		}


		public int Basket_Id
		{
			get
			{
				return mBasket_Id;
			}
			set
			{
				mBasket_Id = value;
			}
		}
		 
		public int Promotion_Id
		{
			get
			{
				return mPromotion_Id;
			}
			set
			{
				mPromotion_Id = value;
			}
		}
 
		public int Scheme_Id
		{
			get
			{
				return mScheme_Id;
			}
			set
			{
				mScheme_Id = value;
			}
		}
		 
		public int Basket_Detail_Id
		{
			get
			{
				return mBasket_Detail_Id;
			}
			set
			{
				mBasket_Detail_Id = value;
			}
		} 
		 
		
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


		public decimal Gst_Amount
		{
			get
			{
				return mGst_Amount;
			}
			set
			{
				mGst_Amount = value;
			}
		}
		 

		public int Quantity
		{
			get
			{
				return mQuantity;
			}
			set
			{
				mQuantity = value;
			}
		}


		public decimal Claim_Amount
		{
			get
			{
				return mClaim_Amount;
			}
			set
			{
				mClaim_Amount = value;
			}
		}
		 
		 


		public int Sale_Order_Promotion_Id
		{
			get
			{
				return mSale_Order_Promotion_Id;
			}
			set
			{
				mSale_Order_Promotion_Id = value;
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
		 
		 

		#endregion
	}
}
