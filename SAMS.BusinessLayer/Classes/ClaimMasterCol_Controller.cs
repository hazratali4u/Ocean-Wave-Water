using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for ClaimMasterCol_Controller.
	/// </summary>
	public class ClaimMasterCol_Controller : System .Collections .CollectionBase
	{
		public ClaimMasterCol_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Public Methods
		public void Add(ClaimMaster_Collection  p_PForCol)
		{
			List.Add (p_PForCol);			
		}
		public ClaimMaster_Collection Get(int p_Index)
		{
			return (ClaimMaster_Collection) List[p_Index];
		}
		#endregion

	}
}
