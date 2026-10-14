using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// <name> OrderGrid_Collection </name>
	/// <author>Syed Ali Raza</author>
	/// <date>11 Sep 07</date>
	/// <description>Responsible to hold the collection of Order Grid of frmOrderEntry on Calculate event </description>
	/// </summary>
	public class OrderGrid_Collection
	{
		#region Constructor
		public OrderGrid_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region private class variables
		
		private int mSKU_ID;
		private string mSKU_Code;
		private string mSKU_Name;
		private int mUnits;
		private int mDozens;
		private decimal mUnitPrice;
		private decimal mDozenPrice;
		private decimal mAmount;
		private decimal mGST_Rate;
		private decimal mGST_Amount;		
		private int mUOM_ID;

		private string mSkuDiv;
		private string mSKUCategory;
		private string mSKUBrand;
		private bool mIsGstOnTradePrice;
		private decimal mSchemeAmount;		

		private string mBatchNo;
		private string mBatchQty;

		private decimal mStdDiscount;
		private decimal mNetAmount;
		private decimal mRetailPrice;
		private decimal mTaxPrice;
		private char mGST_On;
		private bool mIs_Deleted;

		private long mSale_Order_Detail_Id;
		private decimal mTotalAmount;

		private decimal mStdDiscount_Rate;
		private decimal mSchemeDiscount_Rate;
		private string mSKUCompanyId;
		private string mSkuProductline;
		private string mSKUGroupId;
		
		#endregion

		#region Public Properties
		/// <summary>
		/// 
		/// </summary>
		public int SKU_ID
		{
			get
			{
				return mSKU_ID;
			}
			set
			{
				mSKU_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SKU_Code
		{
			get
			{
				return mSKU_Code;
			}
			set
			{
				mSKU_Code = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SKU_Name
		{
			get
			{
				return mSKU_Name;
			}
			set
			{
				mSKU_Name = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Units
		{
			get
			{
				return mUnits;
			}
			set
			{
				mUnits = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Dozens
		{
			get
			{
				return mDozens;
			}
			set
			{
				mDozens = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal UnitPrice
		{
			get
			{
				return mUnitPrice;
			}
			set
			{
				mUnitPrice = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal DozenPrice
		{
			get
			{
				return mDozenPrice;
			}
			set
			{
				mDozenPrice = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
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

		/// <summary>
		/// 
		/// </summary>
		public decimal GST_Rate
		{
			get
			{
				return mGST_Rate;
			}
			set
			{
				mGST_Rate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal GST_Amount
		{
			get
			{
				return mGST_Amount;
			}
			set
			{
				mGST_Amount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int UOM_ID
		{
			get
			{
				return mUOM_ID;
			}
			set
			{
				mUOM_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SkuDiv
		{
			get
			{
				return mSkuDiv;
			}
			set
			{
				mSkuDiv = value;
			}
		}

		public string SkuCompany
		{
			get
			{
				return mSKUCompanyId;
			}
			set
			{
				mSKUCompanyId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SKUCategory
		{
			get
			{
				return mSKUCategory;
			}
			set
			{
				mSKUCategory = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SKUBrand
		{
			get
			{
				return mSKUBrand;
			}
			set
			{
				mSKUBrand = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsGstOnTradePrice
		{
			get
			{
				return mIsGstOnTradePrice;
			}
			set
			{
				mIsGstOnTradePrice = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal SchemeAmount
		{
			get
			{
				return mSchemeAmount;
			}
			set
			{
				mSchemeAmount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SKUBatchNo
		{
			get
			{
				return mBatchNo ;
			}
			set
			{
				mBatchNo  = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SKUBatchQty
		{
			get
			{
				return mBatchQty ;
			}
			set
			{
				mBatchQty = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal StdDiscount
		{
			get
			{
				return mStdDiscount;
			}
			set
			{
				mStdDiscount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal NetAmount
		{
			get
			{
				return mNetAmount;
			}
			set
			{
				mNetAmount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal RetailPrice
		{
			get
			{
				return mRetailPrice;
			}
			set
			{
				mRetailPrice = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public char GST_On
		{
			get
			{
				return mGST_On;
			}
			set
			{
				mGST_On = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Is_Deleted
		{
			get
			{
				return mIs_Deleted;
			}
			set
			{
				mIs_Deleted = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal TaxPrice
		{
			get
			{
				return mTaxPrice;
			}
			set
			{
				mTaxPrice = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
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

		/// <summary>
		/// 
		/// </summary>
		public decimal TotalAmount
		{
			get
			{
				return mTotalAmount;
			}
			set
			{
				mTotalAmount = value;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public decimal StdDiscount_Rate
		{
			get
			{
				return mStdDiscount_Rate;
			}
			set
			{
				mStdDiscount_Rate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal SchemeDiscount_Rate
		{
			get
			{
				return mSchemeDiscount_Rate;
			}
			set
			{
				mSchemeDiscount_Rate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SkuProductline
		{
			get
			{
				return mSkuProductline;
			}
			set
			{
				mSkuProductline = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SKUGroupId
		{
			get
			{
				return mSKUGroupId;
			}
			set
			{
				mSKUGroupId = value;
			}
		}

		#endregion	
	}
}
