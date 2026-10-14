using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// <name>AppliedPromoCol_Controller </name>
	/// <author>Syed Ali Raza </author>
	/// <date>03 Nov 07 </date>
	/// <description>Class Responsible to call Applied promotion collection for values</description>
	/// </summary>
	public class AppliedPromotionCol_Controller: System .Collections .CollectionBase
	{
		#region Constructor
		public AppliedPromotionCol_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods
		public void Add(AppliedPromotion_Collection p_APCol)
		{
			List.Add (p_APCol);			
		}
		public AppliedPromotion_Collection GetItem(int p_Index)
		{
			return (AppliedPromotion_Collection) List[p_Index];
		}
		#endregion
	}
}
