using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// <name> SKU_Collection </name>
	/// <author>Syed Ali Raza</author>
	/// <date>20 Aug 07</date>
	/// <description>Responsible to hold the SKU values </description>
	/// </summary>
	public class SKU_Collection 
	{
		#region Constructor
		public SKU_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Private class variable
		private long mSKU_ID;
		private long mSKU_Mapping_ID;
		private string mSKU_Mapping_Code;

		private string mSKUCode;
		private long mDist_ID;
		private string mSKUName;
		//private string SKU_Hie_Name;
		private decimal mDist_PriceUnit;
		private decimal mDist_PriceDozen;
		private decimal mDist_PriceCase;

		private decimal mTrade_PriceUnit;
		private decimal mTrade_PriceDozen;
		private decimal mTrade_PriceCase;

		private decimal mRetail_PriceUnit;
		private decimal mRetail_PriceDozen;
		private decimal mRetail_PriceCase;

		private decimal mTax_PriceUnit;
		private decimal mTax_PriceDozen;
		private decimal mTax_PriceCase;
		
		private long mSKUBrand_ID;
		private long mSKUDiv_ID;
		private long mSKUCatg_ID;
		private long mSKUProductLine_ID;
		private long mSKUCompany_ID;
		private long [] mSKUGroup;
		// added to accomodate UOM specific entry
		private int mUOM_ID;
		
		private long mSKUCase_Units;
		private decimal mSKU_Unit_Price;
		private decimal mDozen_Price;
		private decimal mCase_Price;

		private decimal mGSTRate;
		private decimal mGSTRate_Reg;
		private decimal mGSTRate_UnReg;
		private string mGST_On;
		private bool mIs_Exempted;

		#endregion

		#region Objects
		private SKUPricesCol_Controller objSKUPricesCol_Cntrl=new SKUPricesCol_Controller();		
		#endregion		
		
		#region Public Properties
		/// <summary>
		/// 
		/// </summary>
		public long SKU_ID
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
		public long SKU_Mapping_ID
		{
			get
			{
				return mSKU_Mapping_ID;
			}
			set
			{
				mSKU_Mapping_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SKU_Mapping_Code
		{
			get
			{
				return mSKU_Mapping_Code ;
			}
			set
			{
				mSKU_Mapping_Code  = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SKUCode
		{
			get
			{
				return mSKUCode;
			}
			set
			{
				mSKUCode = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long Dist_ID
		{
			get
			{
				return mDist_ID;
			}
			set
			{
				mDist_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SKUName
		{
			get
			{
				return mSKUName;
			}
			set
			{
				mSKUName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Dist_Price_Unit
		{
			get
			{
				return mDist_PriceUnit;
			}
			set
			{
				mDist_PriceUnit = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Dist_Price_Dozen
		{
			get
			{
				return mDist_PriceDozen;
			}
			set
			{
				mDist_PriceDozen = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Dist_Price_Case
		{
			get
			{
				return mDist_PriceCase;
			}
			set
			{
				mDist_PriceCase = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Trade_Price_Unit
		{
			get
			{
				return mTrade_PriceUnit;
			}
			set
			{
				mTrade_PriceUnit = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Trade_Price_Dozen
		{
			get
			{
				return mTrade_PriceDozen;
			}
			set
			{
				mTrade_PriceDozen = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Trade_Price_Case
		{
			get
			{
				return mTrade_PriceCase;
			}
			set
			{
				mTrade_PriceCase = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Retail_Price_Unit
		{
			get
			{
				return mRetail_PriceUnit;
			}
			set
			{
				mRetail_PriceUnit = value;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public decimal Retail_Price_Dozen
		{
			get
			{
				return mRetail_PriceDozen;
			}
			set
			{
				mRetail_PriceDozen = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Retail_Price_Case
		{
			get
			{
				return mRetail_PriceCase;
			}
			set
			{
				mRetail_PriceCase = value;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public decimal Tax_Price_Unit
		{
			get
			{
				return mTax_PriceUnit;
			}
			set
			{
				mTax_PriceUnit = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Tax_Price_Dozen
		{
			get
			{
				return mTax_PriceDozen;
			}
			set
			{
				mTax_PriceDozen = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Tax_Price_Case
		{
			get
			{
				return mTax_PriceCase;
			}
			set
			{
				mTax_PriceCase = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long SKUBrand_ID
		{
			get
			{
				return mSKUBrand_ID;
			}
			set
			{
				mSKUBrand_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long SKUComapny_ID
		{
			get
			{
				return mSKUCompany_ID;
			}
			set
			{
				mSKUCompany_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long SKUDiv_ID
		{
			get
			{
				return mSKUDiv_ID;
			}
			set
			{
				mSKUDiv_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long SKUCatg_ID
		{
			get
			{
				return mSKUCatg_ID;
			}
			set
			{
				mSKUCatg_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long SKUProductLine_ID
		{
			get
			{
				return mSKUProductLine_ID;
			}
			set
			{
				mSKUProductLine_ID = value;
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
		public decimal Dozen_Price
		{
			get
			{
				return mDozen_Price;
			}
			set
			{
				mDozen_Price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long SKUCase_Units
		{
			get
			{
				return mSKUCase_Units;
			}
			set
			{
				mSKUCase_Units = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal SKU_Unit_Price
		{
			get
			{
				return mSKU_Unit_Price;
			}
			set
			{
				mSKU_Unit_Price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Case_Price
		{
			get
			{
				return mCase_Price;
			}
			set
			{
				mCase_Price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public SKUPricesCol_Controller ObjSKUPricesCol_Cntrl
		{
			get
			{
				return objSKUPricesCol_Cntrl;
			}
			set
			{
				objSKUPricesCol_Cntrl= value;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public decimal GSTRate
		{
			get
			{
				return mGSTRate;
			}
			set
			{
				mGSTRate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal GSTRate_Reg
		{
			get
			{
				return mGSTRate_Reg;
			}
			set
			{
				mGSTRate_Reg = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal GSTRate_UnReg
		{
			get
			{
				return mGSTRate_UnReg;
			}
			set
			{
				mGSTRate_UnReg = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string GST_On
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
		public bool Is_Exempted
		{
			get
			{
				return mIs_Exempted;
			}
			set
			{
				mIs_Exempted = value;
			}
		}

		
		#endregion

	}
}
