using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// <name> SKUGroup_Collection controller </name>
	/// <author>Syed Ali Raza</author>
	/// <date>09 Nov 07</date>
	/// <description>Responsible to hold the SKU group values </description>
	/// </summary>
	/// 
	public class SKUGroupCol_Cntrlr : System .Collections .CollectionBase
	{
		public SKUGroupCol_Cntrlr()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Public methods
		public void Add(SKUGroup_Collection p_SKUC)
		{
			List.Add (p_SKUC );
		}

		public void Insert(int p_i,SKUGroup_Collection p_SKUC)
		{
			List.Insert (p_i ,p_SKUC);
		}

		public SKUGroup_Collection  GetItem(int p_Index)
		{
			// The appropriate item is retrieved from the List object and
			// explicitly cast to the Collection's type, then returned to the 
			// caller.
			return (SKUGroup_Collection ) List[p_Index];
		}
		#endregion
	}
}
