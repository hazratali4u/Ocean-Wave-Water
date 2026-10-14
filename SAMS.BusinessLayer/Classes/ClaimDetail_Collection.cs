using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for ClaimDetail_Collection.
	/// </summary>
	public class ClaimDetail_Collection
	{
		public ClaimDetail_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Private variables
		private long mClaim_Detail_ID;
		private long mClaim_ID;
		private int mDistributor_ID;
		private int mSKU_ID;
		private int mQuantity;
		private int mFree_Quantity;		
		private decimal mClaim_Amount;
		private decimal mAmount;
		private int mPromotion_ID;
		private int mScheme_ID;
		private int mUser_ID;
		private int mIncentive_Offer_ID;
		#endregion

		#region public Properties
		/// <summary>
		/// 
		/// </summary>
		public long Claim_Detail_ID
		{
			get
			{
				return mClaim_Detail_ID;
			}
			set
			{
				mClaim_Detail_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long Claim_ID
		{
			get
			{
				return mClaim_ID;
			}
			set
			{
				mClaim_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Distributor_ID
		{
			get
			{
				return mDistributor_ID;
			}
			set
			{
				mDistributor_ID = value;
			}
		}

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

		/// <summary>
		/// 
		/// </summary>
		public int Free_Quantity
		{
			get
			{
				return mFree_Quantity;
			}
			set
			{
				mFree_Quantity = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
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
		public int Promotion_ID
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
		public int User_ID
		{
			get
			{
				return mUser_ID;
			}
			set
			{
				mUser_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Incentive_Offer_ID
		{
			get
			{
				return mIncentive_Offer_ID;
			}
			set
			{
				mIncentive_Offer_ID = value;
			}
		}

		#endregion
	}
}
