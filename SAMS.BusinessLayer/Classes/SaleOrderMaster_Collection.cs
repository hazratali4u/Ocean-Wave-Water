using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// <name> SaleOrderMaster_Collection </name>
	/// <author>Syed Ali Raza</author>
	/// <date>11 Sep 20</date>
	/// <description>Responsible to hold the collection of Sale order master of frmOrderEntry </description>
	/// </summary>
	public class SaleOrderMaster_Collection
	{
		public SaleOrderMaster_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region private class variables
		private long mSale_Order_Id;
		private int mDistributor_ID;
		private int mTerritory_ID;
		private long mArea_ID;
		private long mSold_To;
		private long mShip_To;
		private int mOrderBooker_ID;
		private int mDeliveryMan_ID;
		private int mStatus_ID;
		private DateTime mDocument_Date;
		private DateTime mShipment_Date;
		private decimal mTotal_Amount;
		private decimal mTotal_Net_Amount;
		private decimal mExtra_Discount_Amount;
		private decimal mStandard_Discount_Amount;
		private string mTotal_Claim_Amount;
		private decimal mGST_Amount;
		private DateTime mTime_Stamp;
		private DateTime mLastUpdate_Date;
		private decimal mCash_Received;
		private int mLegend_ID;
		private int mOrderType_ID;

		#endregion

		#region Objects
		private SaleOrderDetailCol_Controller  mobjSaleOrderDtlCol_Cntrlr;
		#endregion

		#region Public Properties
		/// <summary>
		/// 
		/// </summary>
		public long Sale_Order_Id
		{
			get
			{
				return mSale_Order_Id;
			}
			set
			{
				mSale_Order_Id = value;
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
		public int Territory_ID
		{
			get
			{
				return mTerritory_ID;
			}
			set
			{
				mTerritory_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Legend_ID
		{
			get
			{
				return mLegend_ID;
			}
			set
			{
				mLegend_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int OrderType_ID
		{
			get
			{
				return mOrderType_ID;
			}
			set
			{
				mOrderType_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long Area_ID
		{
			get
			{
				return mArea_ID;
			}
			set
			{
				mArea_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long Sold_To
		{
			get
			{
				return mSold_To;
			}
			set
			{
				mSold_To = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long Ship_To
		{
			get
			{
				return mShip_To;
			}
			set
			{
				mShip_To = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int OrderBooker_ID
		{
			get
			{
				return mOrderBooker_ID;
			}
			set
			{
				mOrderBooker_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int DeliveryMan_ID
		{
			get
			{
				return mDeliveryMan_ID;
			}
			set
			{
				mDeliveryMan_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Status_ID
		{
			get
			{
				return mStatus_ID;
			}
			set
			{
				mStatus_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime Document_Date
		{
			get
			{
				return mDocument_Date;
			}
			set
			{
				mDocument_Date = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime Shipment_Date
		{
			get
			{
				return mShipment_Date;
			}
			set
			{
				mShipment_Date = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Total_Amount
		{
			get
			{
				return mTotal_Amount;
			}
			set
			{
				mTotal_Amount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Total_Net_Amount
		{
			get
			{
				return mTotal_Net_Amount;
			}
			set
			{
				mTotal_Net_Amount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Extra_Discount_Amount
		{
			get
			{
				return mExtra_Discount_Amount;
			}
			set
			{
				mExtra_Discount_Amount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Standard_Discount_Amount
		{
			get
			{
				return mStandard_Discount_Amount;
			}
			set
			{
				mStandard_Discount_Amount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Total_Claim_Amount
		{
			get
			{
				return mTotal_Claim_Amount;
			}
			set
			{
				mTotal_Claim_Amount = value;
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
		public SaleOrderDetailCol_Controller  objSaleOrderDtlCol_Cntrlr
		{
			get
			{
				return mobjSaleOrderDtlCol_Cntrlr;
			}
			set
			{
				mobjSaleOrderDtlCol_Cntrlr = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal CashReceived
		{
			get
			{
				return mCash_Received ;
			}
			set
			{
				mCash_Received  = value;
			}
		}

		#endregion
	}
}
