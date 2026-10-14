using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for SKUBatches_Collection.
	/// </summary>
	public class SKUBatches_Collection
	{
		#region Constructor
		public SKUBatches_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Private Variables

		private	long mSKU_ID;
		private long mDist_ID;
		private string mBatch_No;
        private long mBatch_Units;
		private DateTime mBatch_Expiry;		
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

		/// <summary>
		/// 
		/// </summary>
		public long Batch_Units
		{
			get
			{
				return mBatch_Units;
			}
			set
			{
				mBatch_Units = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime Batch_Expiry
		{
			get
			{
				return mBatch_Expiry;
			}
			set
			{
				mBatch_Expiry = value;
			}
		}

		#endregion
	}
}
