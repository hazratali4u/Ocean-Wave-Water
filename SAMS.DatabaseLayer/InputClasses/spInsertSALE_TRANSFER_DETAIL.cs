using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;


namespace SAMS.DatabaseLayer.Classes
{
	public class spInsertSALE_TRANSFER_DETAIL
	{
		#region Private Members
		private string sp_Name = " spInsertSALE_TRANSFER_DETAIL" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private long m_SALE_TRANSFER_ID;
		private long m_SALE_INVOICE_DETAIL_ID;
		private long m_SALE_TRANSFER_DETAIL_ID;
		private int m_SKU_ID;
		private int m_REPLACED_SKU_ID;
		private int m_QUANTITY_UNIT;
		private string m_BATCH_NO;
		private string m_REPLACED_BATCH_NO;
		#endregion


		#region Public Properties
		public long SALE_TRANSFER_ID
		{
			set
			{
				m_SALE_TRANSFER_ID = value ;
			}
			get
			{
				return m_SALE_TRANSFER_ID;
			}
		}


		public long SALE_INVOICE_DETAIL_ID
		{
			set
			{
				m_SALE_INVOICE_DETAIL_ID = value ;
			}
			get
			{
				return m_SALE_INVOICE_DETAIL_ID;
			}
		}


		public long SALE_TRANSFER_DETAIL_ID
		{
			get
			{
				return m_SALE_TRANSFER_DETAIL_ID;
			}
		}


		public int SKU_ID
		{
			set
			{
				m_SKU_ID = value ;
			}
			get
			{
				return m_SKU_ID;
			}
		}


		public int REPLACED_SKU_ID
		{
			set
			{
				m_REPLACED_SKU_ID = value ;
			}
			get
			{
				return m_REPLACED_SKU_ID;
			}
		}


		public int QUANTITY_UNIT
		{
			set
			{
				m_QUANTITY_UNIT = value ;
			}
			get
			{
				return m_QUANTITY_UNIT;
			}
		}


		public  string BATCH_NO
		{
			set
			{
				m_BATCH_NO = value ;
			}
			get
			{
				return m_BATCH_NO;
			}
		}


		public  string REPLACED_BATCH_NO
		{
			set
			{
				m_REPLACED_BATCH_NO = value ;
			}
			get
			{
				return m_REPLACED_BATCH_NO;
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
		public spInsertSALE_TRANSFER_DETAIL()
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
				cmd.CommandText = "spInsertSALE_TRANSFER_DETAIL";
				cmd.Connection =   m_connection;
				if(m_transaction!=null)
				{
					cmd.Transaction = m_transaction;
				}
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
				m_SALE_TRANSFER_DETAIL_ID = (long)((IDataParameter)(cmd.Parameters["@SALE_TRANSFER_DETAIL_ID"])).Value;
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
				command.CommandText = "spInsertSALE_TRANSFER_DETAIL";
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
				command.CommandText = "spInsertSALE_TRANSFER_DETAIL";
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
				command.CommandText = "spInsertSALE_TRANSFER_DETAIL";
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
					m_SALE_TRANSFER_ID=Convert.ToInt64(dr["SALE_TRANSFER_ID"]);
					m_SALE_INVOICE_DETAIL_ID=Convert.ToInt64(dr["SALE_INVOICE_DETAIL_ID"]);
					m_SALE_TRANSFER_DETAIL_ID=Convert.ToInt64(dr["SALE_TRANSFER_DETAIL_ID"]);
					m_SKU_ID= Convert.ToInt32(dr["SKU_ID"]);
					m_REPLACED_SKU_ID= Convert.ToInt32(dr["REPLACED_SKU_ID"]);
					m_QUANTITY_UNIT= Convert.ToInt32(dr["QUANTITY_UNIT"]);
					m_BATCH_NO= Convert.ToString(dr["BATCH_NO"]);
					m_REPLACED_BATCH_NO= Convert.ToString(dr["REPLACED_BATCH_NO"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SALE_TRANSFER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_SALE_TRANSFER_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SALE_TRANSFER_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SALE_INVOICE_DETAIL_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_SALE_INVOICE_DETAIL_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SALE_INVOICE_DETAIL_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SALE_TRANSFER_DETAIL_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			parameter.Direction = ParameterDirection.Output;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SKU_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_SKU_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SKU_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@REPLACED_SKU_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_REPLACED_SKU_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_REPLACED_SKU_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@QUANTITY_UNIT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_QUANTITY_UNIT==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_QUANTITY_UNIT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@BATCH_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_BATCH_NO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_BATCH_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@REPLACED_BATCH_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_REPLACED_BATCH_NO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_REPLACED_BATCH_NO;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
