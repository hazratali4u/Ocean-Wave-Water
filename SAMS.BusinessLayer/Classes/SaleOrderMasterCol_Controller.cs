using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// <name> SaleOrderMasterCollection_controller </name>
	/// <author>Syed Ali Raza</author>
	/// <date>11 Sep 20</date>
	/// <description>Responsible to access to the sale order master collection class</description>
	/// </summary>
	public class SaleOrderMasterCol_Controller : System .Collections .CollectionBase
	{
		#region Constructor
		public SaleOrderMasterCol_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods
		public void Add(SaleOrderMaster_Collection  p_BCol)
		{
			List.Add (p_BCol);			
		}
		public SaleOrderMaster_Collection  Get(int p_Index)
		{
			return (SaleOrderMaster_Collection ) List[p_Index];
		}
		#endregion
	
	}
}
