using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for ClaimDetailCol_Controller.
	/// </summary>
	public class ClaimDetailCol_Controller : System .Collections .CollectionBase
	{
		public ClaimDetailCol_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region Public Methods
		public void Add(ClaimDetail_Collection p_PForCol)
		{
			List.Add (p_PForCol);			
		}
		public ClaimDetail_Collection Get(int p_Index)
		{
			return (ClaimDetail_Collection) List[p_Index];
		}
		#endregion
	}
}
