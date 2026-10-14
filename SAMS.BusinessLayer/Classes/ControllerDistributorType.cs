using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;
using SAMS.DatabaseLayer.Classes;


namespace SAMS.BusinessLayer.Classes
{
	/// <summary>
	/// Summary description for ControllerDistributorType.
	/// </summary>
	public class ControllerDistributorType
	{
		public ControllerDistributorType()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region public Methods
		public DataTable SelectDistributorType( int p_Distributor_Type_ID)
		{
		   IDbConnection mConnection = null;
			try
			{
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				
			    spSelectDISTRIBUTOR_TYPE mDistributorType = new spSelectDISTRIBUTOR_TYPE();
				mDistributorType.Connection = mConnection;
                mDistributorType.DISTRIBUTOR_TYPE_ID = p_Distributor_Type_ID;
                mDistributorType.ISDELETED = 0;
				mDistributorType.TYPECODE = null;
				mDistributorType.TYPENAME = null;
				DataTable dtDistributor_Type=  mDistributorType.ExecuteTable();
                return dtDistributor_Type;
 
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
		public string InsertDistributorType(string I_TYPECODE, string I_TYPENAME,bool I_ISDELETED)
		{
			IDbConnection mConnection = null;
			try
			{
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spInsertDISTRIBUTOR_TYPE insertdata  = new spInsertDISTRIBUTOR_TYPE();   
				insertdata.Connection = mConnection;
				insertdata.TYPECODE = I_TYPECODE;
				insertdata.TYPENAME = I_TYPENAME;
				insertdata.ISDELETED = false;
                insertdata.ExecuteQuery();
				return insertdata.DISTRIBUTOR_TYPE_ID.ToString();  
			}

			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
                
			}
			finally 
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		
		}

		public string UpdateDistributorType(int U_typeId,string U_TYPECODE, string U_TYPENAME,bool U_ISDELETED)
		{
			IDbConnection mConnection = null;
			try
			{
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				spUpdateDISTRIBUTOR_TYPE  updatedata  = new spUpdateDISTRIBUTOR_TYPE();   
				updatedata.Connection = mConnection;
				updatedata.DISTRIBUTOR_TYPE_ID  = U_typeId;
				updatedata.TYPECODE = U_TYPECODE;
				updatedata.TYPENAME = U_TYPENAME;
				updatedata.ISDELETED = U_ISDELETED;
				updatedata.ExecuteQuery();
				return updatedata.DISTRIBUTOR_TYPE_ID.ToString();  
			}

			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
                
			}
			finally 
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		
		}

		public DataTable SelectDistributorType(string DTypeCode)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				
				spSelectDISTRIBUTOR_TYPE selectdata = new spSelectDISTRIBUTOR_TYPE();  
				
				selectdata.Connection = mConnection;
				selectdata.DISTRIBUTOR_TYPE_ID  = Constants.IntNullValue;  
				selectdata.TYPECODE = DTypeCode;
				selectdata.TYPENAME = null;
				selectdata.ISDELETED = 0;
				DataTable dtdistributor = selectdata.ExecuteTable();
				return dtdistributor;
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

		public string InsertSkuPrice_PS(int typeid,int distributor_type_Id,int Sku_id,Decimal SkuPrice,string p_packsize,string p_articaleno) 
		{
			IDbConnection mConnection = null;
			try
			{
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				UspUpdateSku_Price_PS updatePrice = new UspUpdateSku_Price_PS(); 
				updatePrice.Connection = mConnection;
				updatePrice.type =  typeid;
				updatePrice.Distributor_type_Id = distributor_type_Id; 
				updatePrice.Sku_ID = Sku_id;
				updatePrice.Price = SkuPrice;
 				updatePrice.packSize = p_packsize;
				updatePrice.articaleno = p_articaleno;
 				updatePrice.ExecuteQuery();
				return "Record Update";
			}

			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
                
			}
			finally 
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		
		}


		public string updateSkuPrice_PS(int typeid,int distributor_type_Id,int Sku_id,Decimal SkuPrice,string p_packsize,string p_articaleno,int p_SKUPRICE_PS_ID) 
		{
			IDbConnection mConnection = null;
			try
			{
				
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				UspUpdateSku_Price_PS updatePrice = new UspUpdateSku_Price_PS(); 
				updatePrice.Connection = mConnection;
				updatePrice.type =  typeid;
				updatePrice.Distributor_type_Id = distributor_type_Id; 
				updatePrice.Sku_ID = Sku_id;
				updatePrice.Price = SkuPrice;
				updatePrice.packSize = p_packsize;
				updatePrice.articaleno = p_articaleno;
				updatePrice.SKUPRICE_PS_ID = p_SKUPRICE_PS_ID;
				updatePrice.ExecuteQuery();
				return "Record Update";
			}

			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
                
			}
			finally 
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		
		}

		public DataTable SelectDistributorPSPrice(int Distributortype_Id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				UspSelectDistributor_SkuPrice selectdata = new UspSelectDistributor_SkuPrice(); 
								
				selectdata.Connection = mConnection;
				selectdata.DISTRIBUTOR_TYPE_ID = Distributortype_Id; 
				selectdata.SKU_ID = Constants.IntNullValue; 
				selectdata.ISCURRETN = 1;
				DataTable dtdistributorPrice = selectdata.ExecuteTable();
				return dtdistributorPrice;
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


		public DataTable SelectDistributorPSPrice(int Distributortype_Id,int p_Iscurrent,int p_sku_id)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
		
				UspSelectDistributor_SkuPrice selectdata = new UspSelectDistributor_SkuPrice(); 
								
				selectdata.Connection = mConnection;
				selectdata.DISTRIBUTOR_TYPE_ID = Distributortype_Id; 
				selectdata.ISCURRETN = p_Iscurrent;
				selectdata.SKU_ID = p_sku_id;
				DataTable dtdistributorPrice = selectdata.ExecuteTable();
				return dtdistributorPrice;
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
