using System;
using SAMS.BusinessLayer .Classes ;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// <name>OrderInfoCollection_Controller </name>
	/// <author>Syed Ali Raza </author>
	/// <date>11 Sep 07 </date>
	/// <description>Class Responsible to call OrderInfoCollection for values</description>
	/// </summary>
	public class OrderInfoCollection_Controller : System .Collections .CollectionBase
	{
		public OrderInfoCollection_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region Public Methods
		public void Add(OrderInfo_Collection  p_OGColCntrlr)
		{
			List.Add (p_OGColCntrlr);			
		}
		public OrderInfo_Collection Get(int p_Index)
		{
			return (OrderInfo_Collection) List[p_Index];
		}
		#endregion
	}
}
