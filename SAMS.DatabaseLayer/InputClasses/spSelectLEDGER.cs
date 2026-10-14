using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;



namespace SAMS.DatabaseLayer.Classes
{
	public class spSelectLEDGER
	{
		#region Private Members
		private string sp_Name = " spSelectLEDGER" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private byte m_POSTING;
		private int m_DISTRIBUTOR_ID;
		private int m_VOUCHER_TYPE_ID;
		private int m_PRINCIPAL_ID;
		private int m_CUSTOMER_ID;
		private int m_DOCUMENT_TYPE_ID;
		private int m_USER_ID;
		private decimal m_DEBIT;
		private decimal m_CREDIT;
		private DateTime m_LEDGER_DATE;
		private DateTime m_TIME_STAMP;
		private DateTime m_CHQUE_DATE;
		private long m_LEDGER_ID;
		private long m_ACCOUNT_HEAD_ID;
		private long m_VOUCHER_NO;
		private long m_DOCUMENT_NO;
		private string m_REMARKS;
		private string m_CHEQUE_NO;
		private string m_SLIP_NO;
		#endregion


		#region Public Properties
		public byte POSTING
		{
			set
			{
				m_POSTING = value ;
			}
			get
			{
				return m_POSTING;
			}
		}


		public int DISTRIBUTOR_ID
		{
			set
			{
				m_DISTRIBUTOR_ID = value ;
			}
			get
			{
				return m_DISTRIBUTOR_ID;
			}
		}


		public int VOUCHER_TYPE_ID
		{
			set
			{
				m_VOUCHER_TYPE_ID = value ;
			}
			get
			{
				return m_VOUCHER_TYPE_ID;
			}
		}


		public int PRINCIPAL_ID
		{
			set
			{
				m_PRINCIPAL_ID = value ;
			}
			get
			{
				return m_PRINCIPAL_ID;
			}
		}


		public int CUSTOMER_ID
		{
			set
			{
				m_CUSTOMER_ID = value ;
			}
			get
			{
				return m_CUSTOMER_ID;
			}
		}


		public int DOCUMENT_TYPE_ID
		{
			set
			{
				m_DOCUMENT_TYPE_ID = value ;
			}
			get
			{
				return m_DOCUMENT_TYPE_ID;
			}
		}


		public int USER_ID
		{
			set
			{
				m_USER_ID = value ;
			}
			get
			{
				return m_USER_ID;
			}
		}


		public decimal  DEBIT
		{
			set
			{
				m_DEBIT = value ;
			}
			get
			{
				return m_DEBIT;
			}
		}


		public decimal  CREDIT
		{
			set
			{
				m_CREDIT = value ;
			}
			get
			{
				return m_CREDIT;
			}
		}


		public DateTime LEDGER_DATE
		{
			set
			{
				m_LEDGER_DATE = value ;
			}
			get
			{
				return m_LEDGER_DATE;
			}
		}


		public DateTime TIME_STAMP
		{
			set
			{
				m_TIME_STAMP = value ;
			}
			get
			{
				return m_TIME_STAMP;
			}
		}


		public DateTime CHQUE_DATE
		{
			set
			{
				m_CHQUE_DATE = value ;
			}
			get
			{
				return m_CHQUE_DATE;
			}
		}


		public long LEDGER_ID
		{
			set
			{
				m_LEDGER_ID = value ;
			}
			get
			{
				return m_LEDGER_ID;
			}
		}


		public long ACCOUNT_HEAD_ID
		{
			set
			{
				m_ACCOUNT_HEAD_ID = value ;
			}
			get
			{
				return m_ACCOUNT_HEAD_ID;
			}
		}


		public long VOUCHER_NO
		{
			set
			{
				m_VOUCHER_NO = value ;
			}
			get
			{
				return m_VOUCHER_NO;
			}
		}


		public long DOCUMENT_NO
		{
			set
			{
				m_DOCUMENT_NO = value ;
			}
			get
			{
				return m_DOCUMENT_NO;
			}
		}


		public  string REMARKS
		{
			set
			{
				m_REMARKS = value ;
			}
			get
			{
				return m_REMARKS;
			}
		}


		public  string CHEQUE_NO
		{
			set
			{
				m_CHEQUE_NO = value ;
			}
			get
			{
				return m_CHEQUE_NO;
			}
		}


		public  string SLIP_NO
		{
			set
			{
				m_SLIP_NO = value ;
			}
			get
			{
				return m_SLIP_NO;
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
		public spSelectLEDGER()
		{
		m_DISTRIBUTOR_ID = Constants.IntNullValue;
		m_VOUCHER_TYPE_ID = Constants.IntNullValue;
		m_PRINCIPAL_ID = Constants.IntNullValue;
		m_CUSTOMER_ID = Constants.IntNullValue;
		m_DOCUMENT_TYPE_ID = Constants.IntNullValue;
		m_USER_ID = Constants.IntNullValue;
		DEBIT = Constants.DecimalNullValue;
		CREDIT = Constants.DecimalNullValue;
		m_LEDGER_DATE = Constants.DateNullValue;
		m_TIME_STAMP = Constants.DateNullValue;
		m_CHQUE_DATE = Constants.DateNullValue;
		m_LEDGER_ID =  Constants.LongNullValue;
		m_ACCOUNT_HEAD_ID =  Constants.LongNullValue;
		m_VOUCHER_NO =  Constants.LongNullValue;
		m_DOCUMENT_NO =  Constants.LongNullValue;
		m_REMARKS = null;
		m_CHEQUE_NO = null;
		m_SLIP_NO = null;
		}
		#endregion

		#region public Methods
		public bool  ExecuteQuery()
		{
			try
			{
			    IDbCommand cmd = ProviderFactory.GetCommand(EnumProviders.SQLClient);
				cmd.CommandType =  CommandType.StoredProcedure;
				cmd.CommandText = "spSelectLEDGER";
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
				command.CommandText = "spSelectLEDGER";
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
				command.CommandText = "spSelectLEDGER";
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
				command.CommandText = "spSelectLEDGER";
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
					m_POSTING= Convert.ToByte(dr["POSTING"]);
					m_DISTRIBUTOR_ID= Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
					m_VOUCHER_TYPE_ID= Convert.ToInt32(dr["VOUCHER_TYPE_ID"]);
					m_PRINCIPAL_ID= Convert.ToInt32(dr["PRINCIPAL_ID"]);
					m_CUSTOMER_ID= Convert.ToInt32(dr["CUSTOMER_ID"]);
					m_DOCUMENT_TYPE_ID= Convert.ToInt32(dr["DOCUMENT_TYPE_ID"]);
					m_USER_ID= Convert.ToInt32(dr["USER_ID"]);
					m_DEBIT= Convert.ToDecimal(dr["DEBIT"]);
					m_CREDIT= Convert.ToDecimal(dr["CREDIT"]);
					m_LEDGER_DATE= Convert.ToDateTime(dr["LEDGER_DATE"]);
					m_TIME_STAMP= Convert.ToDateTime(dr["TIME_STAMP"]);
					m_CHQUE_DATE= Convert.ToDateTime(dr["CHQUE_DATE"]);
					m_LEDGER_ID=Convert.ToInt64(dr["LEDGER_ID"]);
					m_ACCOUNT_HEAD_ID=Convert.ToInt64(dr["ACCOUNT_HEAD_ID"]);
					m_VOUCHER_NO=Convert.ToInt64(dr["VOUCHER_NO"]);
					m_DOCUMENT_NO=Convert.ToInt64(dr["DOCUMENT_NO"]);
					m_REMARKS= Convert.ToString(dr["REMARKS"]);
					m_CHEQUE_NO= Convert.ToString(dr["CHEQUE_NO"]);
					m_SLIP_NO= Convert.ToString(dr["SLIP_NO"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@POSTING" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.TinyInt);
			if(m_POSTING==Constants.ByteNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_POSTING;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DISTRIBUTOR_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DISTRIBUTOR_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DISTRIBUTOR_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@VOUCHER_TYPE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_VOUCHER_TYPE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_VOUCHER_TYPE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@PRINCIPAL_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_PRINCIPAL_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PRINCIPAL_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CUSTOMER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_CUSTOMER_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CUSTOMER_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DOCUMENT_TYPE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DOCUMENT_TYPE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DOCUMENT_TYPE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@USER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_USER_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_USER_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DEBIT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_DEBIT==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DEBIT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CREDIT" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_CREDIT==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CREDIT;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@LEDGER_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_LEDGER_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LEDGER_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TIME_STAMP" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_TIME_STAMP==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TIME_STAMP;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CHQUE_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_CHQUE_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CHQUE_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@LEDGER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_LEDGER_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LEDGER_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ACCOUNT_HEAD_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_ACCOUNT_HEAD_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ACCOUNT_HEAD_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@VOUCHER_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_VOUCHER_NO==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_VOUCHER_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DOCUMENT_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_DOCUMENT_NO==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DOCUMENT_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@REMARKS" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_REMARKS== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_REMARKS;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CHEQUE_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_CHEQUE_NO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CHEQUE_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SLIP_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_SLIP_NO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SLIP_NO;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
