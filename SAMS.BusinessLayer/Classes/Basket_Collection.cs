using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// <name> Basket_Collection </name>
	/// <author>Syed Ali Raza</author>
	/// <date>22 Aug 07</date>
	/// <description>Responsible to hold the collection of Basket_Master values </description>
	/// </summary>
	public class Basket_Collection
	{
		#region Constructor
		public Basket_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region private class variables
		private long mBasket_ID;
		private long mPromotion_ID;
		private int mScheme_ID;
		private int mDist_ID;
		private bool mIs_Basket;
		private bool mIs_And;
		private bool mIs_Multiple;
		private bool mIs_IsBundled;
		private int mBasket_On;
		private int mBasket_Selection;
		#endregion

		#region Class Objects
		private BasketDetailCollection_Controller objBasketDtlCol_Cntrlr;
        private PromotionOfferColl_Controller objPromotionOfferCol_Cntrl;
		#endregion
		
		#region Public Properties
		/// <summary>
		/// 
		/// </summary>
		public long Basket_ID
		{
			get
			{
				return mBasket_ID;
			}
			set
			{
				mBasket_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long Promotion_ID
		{
			get
			{
				return mPromotion_ID;
			}
			set
			{
				mPromotion_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Scheme_ID
		{
			get
			{
				return mScheme_ID;
			}
			set
			{
				mScheme_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Dist_ID
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
		public bool Is_Basket
		{
			get
			{
				return mIs_Basket;
			}
			set
			{
				mIs_Basket = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Is_And
		{
			get
			{
				return mIs_And;
			}
			set
			{
				mIs_And = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Is_Multiple
		{
			get
			{
				return mIs_Multiple;
			}
			set
			{
				mIs_Multiple = value;
			}
		}
		public bool Is_Bundled
		{
			get
			{
				return mIs_IsBundled;
			}
			set
			{
				mIs_IsBundled = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Basket_On
		{
			get
			{
				return mBasket_On;
			}
			set
			{
				mBasket_On = value;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		
		public int Basket_Selection
		{
			get
			{
				return mBasket_Selection;
			}
			set
			{
				mBasket_Selection = value;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public BasketDetailCollection_Controller ObjBasketDtlCol_Cntrlr
		{
			get
			{
				return objBasketDtlCol_Cntrlr;
			}
			set
			{
				objBasketDtlCol_Cntrlr = value;
			}
		}
        public PromotionOfferColl_Controller ObjPromotionOfferCol_Cntrl
        {
            get
            {
                return objPromotionOfferCol_Cntrl;
            }
            set
            {
                objPromotionOfferCol_Cntrl = value;
            }
        }
		/// <summary>
		/// 
		/// </summary>
	

		#endregion
	}
}
