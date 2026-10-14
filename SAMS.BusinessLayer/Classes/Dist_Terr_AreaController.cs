using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;

namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for Dist_Terr_AreaController.
	/// </summary>
	public class Dist_Terr_AreaController
	{

		#region Constructor
		public Dist_Terr_AreaController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion


		#region Public Methods

		public DataTable SelectDist_Terr_Area(int p_Distributor_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectDist_Terr_Area mDistTerrArea = new uspSelectDist_Terr_Area();
				mDistTerrArea.Connection = mConnection;
				mDistTerrArea.DISTRIBUTOR_ID = p_Distributor_Id;
				DataTable dt = mDistTerrArea.ExecuteTable();
				return dt;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
			
		}


		#endregion

	}
}
