using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for SaleInvoiceDetail_Controller.
	/// </summary>
	public class SaleInvoiceDetail_Controller : System.Collections.CollectionBase
	{

		#region Constructor
		public SaleInvoiceDetail_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		public void Add(SaleInvoiceDetail_Collection p_BCol)
		{
			List.Add (p_BCol);			
		}

		public void Insert(int p_i , SaleInvoiceDetail_Collection p_BCol)
		{
			List.Insert (p_i ,p_BCol);
		}
		public void RemoveOn(int p_i)
		{
			List.RemoveAt (p_i);
		}	
		public SaleInvoiceDetail_Collection Get(int p_Index)
		{
			return (SaleInvoiceDetail_Collection) List[p_Index];
		}

		

	}
}
