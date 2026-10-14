using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// <name>BasketDetailCollection_Controller </name>
	/// <author>Syed Ali Raza </author>
	/// <date>24 Aug 07 </date>
	/// <description>Class Responsible to call Basket Detail collection for values</description>
	/// </summary>
	public class BasketDetailCollection_Controller : System .Collections .CollectionBase
	{
		#region Constructor
		public BasketDetailCollection_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion
				
		#region Public Methods
		public void Add(Basket_Detail_Collection p_BDetCol)
		{
			List.Add (p_BDetCol);			
		}

		public void Insert(int p_i , Basket_Detail_Collection p_BDetCol)
		{
			List.Insert (p_i ,p_BDetCol);
		}
		public void RemoveOn(int p_i)
		{
			List.RemoveAt (p_i);
		}	
		public Basket_Detail_Collection Get(int p_Index)
		{
			return (Basket_Detail_Collection) List[p_Index];
		}
		#endregion
	}
}
