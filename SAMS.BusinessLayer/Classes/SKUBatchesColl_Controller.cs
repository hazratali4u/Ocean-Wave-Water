using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for SKUBatchesColl_Controller.
	/// </summary>
	public class SKUBatchesColl_Controller : System .Collections .CollectionBase
	{
		#region Constructor
		public SKUBatchesColl_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public methods
		public void Add(SKUBatches_Collection  p_SKUC)
		{
			List.Add (p_SKUC );
		}

		public void Insert(int p_i,SKUBatches_Collection  p_SKUC)
		{
			List.Insert (p_i ,p_SKUC);
		}

		public SKUBatches_Collection  GetItem(int p_Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Collection's type, then returned to the 
			// caller.
			return (SKUBatches_Collection ) List[p_Index];
		}
		#endregion
	}
}
