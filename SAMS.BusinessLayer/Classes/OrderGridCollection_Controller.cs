using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// <name>OrderGridCollection_Controller </name>
	/// <author>Syed Ali Raza </author>
	/// <date>11 Sep 07 </date>
	/// <description>Class Responsible to call OrderGrid_Collection for values</description>
	/// </summary>
	public class OrderGridCollection_Controller : System .Collections .CollectionBase
	{
		#region Constructor
		public OrderGridCollection_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods
		public void Add(OrderGrid_Collection  p_OGCol)
		{
			List.Add (p_OGCol);			
		}

		public OrderGrid_Collection Get(int p_Index)
		{
			return (OrderGrid_Collection) List[p_Index];
		}
		#endregion
	}
}
