using System;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// <name> BasketCollection_Controller </name>
	/// <author>Syed Ali Raza</author>
	/// <date>20 Aug 07</date>
	/// <description>Class Responsible to call Basket collection for values </description>
	/// </summary>
	public class BasketCollection_Controller : System .Collections .CollectionBase
	{
		#region Constructor
		public BasketCollection_Controller()
		{
			
		}
		#endregion

		#region Public Methods
		public void Add(Basket_Collection p_BCol)
		{
			List.Add (p_BCol);			
		}

		public void Insert(int p_i , Basket_Collection p_BCol)
		{
			List.Insert (p_i ,p_BCol);
		}
		public void RemoveOn(int p_i)
		{
			List.RemoveAt (p_i);
		}	
		public Basket_Collection Get(int p_Index)
		{
			return (Basket_Collection) List[p_Index];
		}
		#endregion
	}
}
