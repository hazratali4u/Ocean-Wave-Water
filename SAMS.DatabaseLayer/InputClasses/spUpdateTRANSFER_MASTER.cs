using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;


namespace SAMS.BusinessLayer.Classes
{
	public class spUpdateTRANSFER_MASTER
	{
		#region Private Members
		private string sp_Name = " spUpdateTRANSFER_MASTER" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private long m_TRANSFER_TO;
		private long m_TRANSFER_MASTER_ID;
		private long m_DOCUMENT_NO;
		private long m_TRANSFER_FROM;
		private bool m_IS_ACTIVE;
		private DateTime m_TIME_STAMP;
		private DateTime m_TRANSFER_DATE;
		private DateTime m_ISSUE_DATE;
		private DateTime m_RECEVID_DATE;
		private int m_USER_ID;
		private int m_IS_ISSUE;
		private int m_IS_RECEIVED;
		private string m_TRANSFER_FROMNAME;
		private string m_TRANSFER_TONAME;
		#endregion


		#region Public Properties
		public long TRANSFER_TO
		{
			set
			{
				m_TRANSFER_TO = value ;
			}
			get
			{
				return m_TRANSFER_TO;
			}
		}


		public long TRANSFER_MASTER_ID
		{
			set
			{
				m_TRANSFER_MASTER_ID = value ;
			}
			get
			{
				return m_TRANSFER_MASTER_ID;
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


		public long TRANSFER_FROM
		{
			set
			{
				m_TRANSFER_FROM = value ;
			}
			get
			{
				return m_TRANSFER_FROM;
			}
		}


		public bool IS_ACTIVE
		{
			set
			{
				m_IS_ACTIVE = value ;
			}
			get
			{
				return m_IS_ACTIVE;
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


		public DateTime TRANSFER_DATE
		{
			set
			{
				m_TRANSFER_DATE = value ;
			}
			get
			{
				return m_TRANSFER_DATE;
			}
		}


		public DateTime ISSUE_DATE
		{
			set
			{
				m_ISSUE_DATE = value ;
			}
			get
			{
				return m_ISSUE_DATE;
			}
		}


		public DateTime RECEVID_DATE
		{
			set
			{
				m_RECEVID_DATE = value ;
			}
			get
			{
				return m_RECEVID_DATE;
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


		public int IS_ISSUE
		{
			set
			{
				m_IS_ISSUE = value ;
			}
			get
			{
				return m_IS_ISSUE;
			}
		}


		public int IS_RECEIVED
		{
			set
			{
				m_IS_RECEIVED = value ;
			}
			get
			{
				return m_IS_RECEIVED;
			}
		}


		public  string TRANSFER_FROMNAME
		{
			set
			{
				m_TRANSFER_FROMNAME = value ;
			}
			get
			{
				return m_TRANSFER_FROMNAME;
			}
		}


		public  string TRANSFER_TONAME
		{
			set
			{
				m_TRANSFER_TONAME = value ;
			}
			get
			{
				return m_TRANSFER_TONAME;
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
		public spUpdateTRANSFER_MASTER()
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
				cmd.CommandText = "spUpdateTRANSFER_MASTER";
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
				command.CommandText = "spUpdateTRANSFER_MASTER";
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
				command.CommandText = "spUpdateTRANSFER_MASTER";
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
				command.CommandText = "spUpdateTRANSFER_MASTER";
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
					m_TRANSFER_TO=Convert.ToInt64(dr["TRANSFER_TO"]);
					m_TRANSFER_MASTER_ID=Convert.ToInt64(dr["TRANSFER_MASTER_ID"]);
					m_DOCUMENT_NO=Convert.ToInt64(dr["DOCUMENT_NO"]);
					m_TRANSFER_FROM=Convert.ToInt64(dr["TRANSFER_FROM"]);
					m_IS_ACTIVE=Convert.ToBoolean(dr["IS_ACTIVE"]);
					m_TIME_STAMP= Convert.ToDateTime(dr["TIME_STAMP"]);
					m_TRANSFER_DATE= Convert.ToDateTime(dr["TRANSFER_DATE"]);
					m_ISSUE_DATE= Convert.ToDateTime(dr["ISSUE_DATE"]);
					m_RECEVID_DATE= Convert.ToDateTime(dr["RECEVID_DATE"]);
					m_USER_ID= Convert.ToInt32(dr["USER_ID"]);
					m_IS_ISSUE= Convert.ToInt32(dr["IS_ISSUE"]);
					m_IS_RECEIVED= Convert.ToInt32(dr["IS_RECEIVED"]);
					m_TRANSFER_FROMNAME= Convert.ToString(dr["TRANSFER_FROMNAME"]);
					m_TRANSFER_TONAME= Convert.ToString(dr["TRANSFER_TONAME"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TRANSFER_TO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_TRANSFER_TO==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TRANSFER_TO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TRANSFER_MASTER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_TRANSFER_MASTER_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TRANSFER_MASTER_ID;
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
			parameter.ParameterName = "@TRANSFER_FROM" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_TRANSFER_FROM==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TRANSFER_FROM;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_ACTIVE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_IS_ACTIVE;
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
			parameter.ParameterName = "@TRANSFER_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_TRANSFER_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TRANSFER_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ISSUE_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_ISSUE_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ISSUE_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@RECEVID_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_RECEVID_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_RECEVID_DATE;
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
			parameter.ParameterName = "@IS_ISSUE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_IS_ISSUE==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_IS_ISSUE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_RECEIVED" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_IS_RECEIVED==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_IS_RECEIVED;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TRANSFER_FROMNAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_TRANSFER_FROMNAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TRANSFER_FROMNAME;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TRANSFER_TONAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_TRANSFER_TONAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TRANSFER_TONAME;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
