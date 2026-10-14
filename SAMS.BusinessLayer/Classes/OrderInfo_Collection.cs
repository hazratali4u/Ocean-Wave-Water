using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// <name> OrderGrid_Collection </name>
	/// <author>Syed Ali Raza</author>
	/// <date>11 Sep 07</date>
	/// <description>Responsible to hold the collection of Order information of frmOrderEntry on Calculate event </description>
	/// </summary>
	public class OrderInfo_Collection
	{
		#region constructor
		public OrderInfo_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Private Variables
		private int m_OrderStatusId;
		private string m_SelectedCustomerId;
		private int m_CustomerTypeByWork;
		private bool m_IsNewOrder;
		private long m_AreaID;

		#endregion

		#region Private Properties
		/// <summary>
		/// 
		/// </summary>
		public int OrderStatusId
		{
			get
			{
				return m_OrderStatusId;
			}
			set
			{
				m_OrderStatusId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SelectedCustomerId
		{
			get
			{
				return m_SelectedCustomerId;
			}
			set
			{
				m_SelectedCustomerId = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int CustomerTypeByWork
		{
			get
			{
				return m_CustomerTypeByWork;
			}
			set
			{
				m_CustomerTypeByWork = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool IsNewOrder
		{
			get
			{
				return m_IsNewOrder;
			}
			set
			{
				m_IsNewOrder = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public long  Area_ID
		{
			get
			{
				return m_AreaID ;
			}
			set
			{
				m_AreaID  = value;
			}
		}

		#endregion

	}
}
