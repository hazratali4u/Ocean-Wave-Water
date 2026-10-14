using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for SKULevelCreditLimitController.
	/// </summary>
	public class SKULevelCreditLimitController : System.Collections.CollectionBase
	{
		#region Constructor
		public SKULevelCreditLimitController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods
		public void Add(SKULevelCreditLimit_Collection p_SKUC)
		{
			List.Add (p_SKUC );
		}		

		public void Insert(int p_i,SKULevelCreditLimit_Collection p_SKUC)
		{
			List.Insert (p_i ,p_SKUC);
		}		

		public SKULevelCreditLimit_Collection Get(int p_Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Collection's type, then returned to the 
			// caller.
			return (SKULevelCreditLimit_Collection) List[p_Index];
		}
		#endregion
		
	}


	public class SKULevelCreditLimit_Collection
	{

		#region Constructor
		public SKULevelCreditLimit_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion


		#region Private Variables
		long mSku_level_credit_limit_id;
		long mCustomer_id;
		long mSku_level_id;
		decimal mAllowed_credit_limit;
		decimal mUsed_limit;
		decimal mOrdered_Amount;
		string mSku_level_name;
		#endregion


		#region Public Properties

		public long SKU_LEVEL_CREDIT_LIMIT_ID
		{
			set
			{
				mSku_level_credit_limit_id = value;
			}
			get
			{
				return mSku_level_credit_limit_id;
			}
		}

		public long CUSTOMER_ID
		{
			set
			{
				mCustomer_id = value;
			}
			get
			{
				return mCustomer_id;
			}
		}

		public long SKU_LEVEL_ID
		{
			set
			{
				mSku_level_id = value;
			}
			get
			{
				return mSku_level_id;
			}
		}

		public string SKU_LEVEL_NAME
		{
			set
			{
				mSku_level_name = value;
			}
			get
			{
				return mSku_level_name;
			}
		}

		public decimal ALLOWED_CREDIT_LIMIT
		{
			set
			{
				mAllowed_credit_limit = value;
			}
			get
			{
				return mAllowed_credit_limit;
			}
		}

		public decimal USED_LIMIT
		{
			set
			{
				mUsed_limit = value;
			}
			get
			{
				return mUsed_limit;
			}
		}

		public decimal ORDERED_AMOUNT
		{
			set
			{
				mOrdered_Amount = value;
			}
			get
			{
				return mOrdered_Amount;
			}
		}


		#endregion

	}
}
