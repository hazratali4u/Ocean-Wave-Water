using System;
using System.Data;
using SAMS.DataAccessLayer.Classes;
using SAMS.Common.Classes;



namespace SAMS.DatabaseLayer.Classes
{
	public class UspUpdateSku_Price_PS
	{
		#region Private Members
		private string sp_Name = " UspUpdateSku_Price_PS" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private decimal m_Price;
		private int m_SKUPRICE_PS_ID;
		private int m_type;
		private int m_Distributor_type_Id;
		private int m_Sku_ID;
		private string m_articaleno;
		private string m_packSize;
		#endregion


		#region Public Properties
		public decimal Price
		{
			set
			{
				m_Price = value ;
			}
			get
			{
				return m_Price;
			}
		}


		public string packSize
		{
			set
			{
				m_packSize = value ;
			}
			get
			{
				return m_packSize;
			}
		}


		public int SKUPRICE_PS_ID
		{
			set
			{
				m_SKUPRICE_PS_ID = value ;
			}
			get
			{
				return m_SKUPRICE_PS_ID;
			}
		}


		public int type
		{
			set
			{
				m_type = value ;
			}
			get
			{
				return m_type;
			}
		}


		public int Distributor_type_Id
		{
			set
			{
				m_Distributor_type_Id = value ;
			}
			get
			{
				return m_Distributor_type_Id;
			}
		}


		public int Sku_ID
		{
			set
			{
				m_Sku_ID = value ;
			}
			get
			{
				return m_Sku_ID;
			}
		}


		public  string articaleno
		{
			set
			{
				m_articaleno = value ;
			}
			get
			{
				return m_articaleno;
			}
		}




		public IDbConnection  Connection
		{
			set
			{
				m_connection = value;
			}
			get
			{
				return m_connection;
			}
		}
		public IDbTransaction  Transaction
		{
			set
			{
				m_transaction = value;
			}
			get
			{
				return m_transaction;
			}
		}
		#endregion


		#region Constructor
		public UspUpdateSku_Price_PS()
		{


		}
		#endregion

		#region public Methods
		public bool  ExecuteQuery()
		{
			try
			{
			    IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				cmd.CommandType =  CommandType.StoredProcedure;
				cmd.CommandText = "UspUpdateSku_Price_PS";
				cmd.Connection =   m_connection;
				if(m_transaction!=null)
				{
					cmd.Transaction = m_transaction;
				}
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch(Exception e)
			{
				throw e;
			}
			finally
			{


			}
		}


		public IDataReader ExecuteReader()
		{
			try
			{
				IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "UspUpdateSku_Price_PS";
				command.Connection = m_connection;
				if(m_transaction!=null)
				{
					command.Transaction = m_transaction;
				}
				GetParameterCollection(ref command);
				IDataReader dr = command.ExecuteReader();
				return dr;
			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{
			}
		}


		public DataTable ExecuteTable()
		{
			try
			{
				IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "UspUpdateSku_Price_PS";
				command.Connection = m_connection;
				if(m_transaction!=null)
				{
					command.Transaction = m_transaction;
				}
				GetParameterCollection(ref command);
				IDbDataAdapter da = ProviderFactory.GetAdapter(EnumProviders.SQLClient);
				da.SelectCommand = command;
				DataSet ds = new DataSet();
				da.Fill(ds);
				return ds.Tables[0];
			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{


			}
		}


		public string ExecuteScalar()
		{
			try
			{
				IDbCommand command = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "UspUpdateSku_Price_PS";
				command.Connection = m_connection;
				if(m_transaction!=null)
				{
					command.Transaction = m_transaction;
				}
				GetParameterCollection(ref command);
				object o;
				o = command.ExecuteScalar();


				return o.ToString();
			}
			catch(Exception exp)
			{
				throw exp;
			}
			finally
			{
			}
		}


			public void FirstReader(IDataReader dr)
			{
				if(dr.Read())
				{
					m_Price= Convert.ToDecimal(dr["Price"]);
					m_packSize= Convert.ToString(dr["packSize"]);
					m_SKUPRICE_PS_ID= Convert.ToInt32(dr["SKUPRICE_PS_ID"]);
					m_type= Convert.ToInt32(dr["type"]);
					m_Distributor_type_Id= Convert.ToInt32(dr["Distributor_type_Id"]);
					m_Sku_ID= Convert.ToInt32(dr["Sku_ID"]);
					m_articaleno= Convert.ToString(dr["articaleno"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@Price" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Decimal);
			if(m_Price==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_Price;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@packSize" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_packSize==null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_packSize;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SKUPRICE_PS_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_SKUPRICE_PS_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SKUPRICE_PS_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@type" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_type==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_type;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@Distributor_type_Id" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_Distributor_type_Id==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_Distributor_type_Id;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@Sku_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_Sku_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_Sku_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@articaleno" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_articaleno== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_articaleno;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
