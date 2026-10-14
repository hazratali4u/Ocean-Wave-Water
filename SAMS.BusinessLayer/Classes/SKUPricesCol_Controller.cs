using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for SKUPricesCol_Controller.
	/// </summary>
	public class SKUPricesCol_Controller : System .Collections .CollectionBase
	{
		#region Constructor
		public SKUPricesCol_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region public methods
		public void Add(SKUPrices_Collection p_SKUC)
		{
			List.Add (p_SKUC );
		}

		public SKUPrices_Collection GetItems(int p_Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Collection's type, then returned to the 
			// caller.
			return (SKUPrices_Collection) List[p_Index];
		}
		#endregion
	}
}
