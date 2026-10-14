using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for ClaimMaster_Collection.
	/// </summary>
	public class ClaimMaster_Collection
	{
		#region Construtor
		public ClaimMaster_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion
		
		#region Private Variables
		private long mClaim_ID;
		private int mDistributor_ID;
		private int mClaim_Type_ID;
		private decimal mClaim_Amount;
		private int mClaim_Status_ID;
		private DateTime mDate_From;
		private DateTime mDate_To;
		private string mRemarks;
        private DateTime mTime_Stamp;
		private DateTime mLastUpdate_Date;
		private int mClaim_SubType;
		#endregion

		#region Class Objects
		private ClaimDetailCol_Controller mobjClaimDetailCol_Cntrlr;
		#endregion

		#region Public Properties
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
		public int Claim_Type_ID
		{
			get
			{
				return mClaim_Type_ID;
			}
			set
			{
				mClaim_Type_ID = value;
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
		public int Claim_Status_ID
		{
			get
			{
				return mClaim_Status_ID;
			}
			set
			{
				mClaim_Status_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime Date_From
		{
			get
			{
				return mDate_From;
			}
			set
			{
				mDate_From = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime Date_To
		{
			get
			{
				return mDate_To;
			}
			set
			{
				mDate_To = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Remarks
		{
			get
			{
				return mRemarks;
			}
			set
			{
				mRemarks = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime Time_Stamp
		{
			get
			{
				return mTime_Stamp;
			}
			set
			{
				mTime_Stamp = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime LastUpdate_Date
		{
			get
			{
				return mLastUpdate_Date;
			}
			set
			{
				mLastUpdate_Date = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Claim_SubType
		{
			get
			{
				return mClaim_SubType;
			}
			set
			{
				mClaim_SubType = value;
			}
		}

		
		/// <summary>
		/// 
		/// </summary>
		public ClaimDetailCol_Controller ObjClaimDetailCol_Cntrlr
		{
			get
			{
				return mobjClaimDetailCol_Cntrlr;
			}
			set
			{
				mobjClaimDetailCol_Cntrlr = value;
			}
		}

		#endregion
	}
}
