using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// <name> SKUGroup_Collection </name>
	/// <author>Syed Ali Raza</author>
	/// <date>09 Nov 07</date>
	/// <description>Responsible to hold the SKU group values </description>
	/// </summary>
	/// 
	public class SKUGroup_Collection
	{
		#region Constructor
		public SKUGroup_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Private class variables

		private int mSKUGroup_ID;
		private int mSKU_GROUP_DETAIL_ID;
		private int mSKU_ID;
		#endregion

        
		#region Private Properties
		/// <summary>
		/// 
		/// </summary>
		public int SKUGroup_ID
		{
			get
			{
				return mSKUGroup_ID;
			}
			set
			{
				mSKUGroup_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int SKU_GROUP_DETAIL_ID
		{
			get
			{
				return mSKU_GROUP_DETAIL_ID;
			}
			set
			{
				mSKU_GROUP_DETAIL_ID = value;
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

		#endregion

	}
}
