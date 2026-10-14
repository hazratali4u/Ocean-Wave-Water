using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// <name> SKU_Collection_Controller </name>
	/// <author>Syed Ali Raza</author>
	/// <date>20 Aug 07</date>
	/// <description>Class Responsible to call sku collection for values </description>
	/// </summary>
	public class SKU_Collection_Controller : System .Collections .CollectionBase
	{
		#region Constructor
		public SKU_Collection_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public methods
		public void Add(SKU_Collection p_SKUC)
		{
            List.Add (p_SKUC );
		}		

		public void Insert(int p_i,SKU_Collection p_SKUC)
		{
			List.Insert (p_i ,p_SKUC);
		}		

		public SKU_Collection GetItem(int p_Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Collection's type, then returned to the 
			// caller.
			return (SKU_Collection) List[p_Index];
		}
		#endregion
	}
}
