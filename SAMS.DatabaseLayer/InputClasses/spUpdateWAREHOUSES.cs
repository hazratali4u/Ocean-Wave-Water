using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;



namespace SAMS.DatabaseLayer.Classes
{
	public class spUpdateWAREHOUSES
	{
		#region Private Members
		private string sp_Name = " spUpdateWAREHOUSES" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private long m_WAREHOUSE_ID;
		private bool m_ISDELETED;
		private int m_IS_VIRTUAL;
		private DateTime m_TIME_STAMP;
		private DateTime m_LASTUPDATE_DATE;
		private int m_USER_ID;
		private string m_CONTACT_PERSON;
		private string m_CONTACT_PHONE;
		private string m_IPAddress;
		private string m_WAREHOUSE_CODE;
		private string m_WAREHOUSE_NAME;
		private string m_WHAREHOUSE_ADDRESS;
		#endregion


		#region Public Properties
		public long WAREHOUSE_ID
		{
			set
			{
				m_WAREHOUSE_ID = value ;
			}
			get
			{
				return m_WAREHOUSE_ID;
			}
		}


		public bool ISDELETED
		{
			set
			{
				m_ISDELETED = value ;
			}
			get
			{
				return m_ISDELETED;
			}
		}


		public int IS_VIRTUAL
		{
			set
			{
				m_IS_VIRTUAL = value ;
			}
			get
			{
				return m_IS_VIRTUAL;
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


		public DateTime LASTUPDATE_DATE
		{
			set
			{
				m_LASTUPDATE_DATE = value ;
			}
			get
			{
				return m_LASTUPDATE_DATE;
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


		public  string CONTACT_PERSON
		{
			set
			{
				m_CONTACT_PERSON = value ;
			}
			get
			{
				return m_CONTACT_PERSON;
			}
		}


		public  string CONTACT_PHONE
		{
			set
			{
				m_CONTACT_PHONE = value ;
			}
			get
			{
				return m_CONTACT_PHONE;
			}
		}


		public  string IPAddress
		{
			set
			{
				m_IPAddress = value ;
			}
			get
			{
				return m_IPAddress;
			}
		}


		public  string WAREHOUSE_CODE
		{
			set
			{
				m_WAREHOUSE_CODE = value ;
			}
			get
			{
				return m_WAREHOUSE_CODE;
			}
		}


		public  string WAREHOUSE_NAME
		{
			set
			{
				m_WAREHOUSE_NAME = value ;
			}
			get
			{
				return m_WAREHOUSE_NAME;
			}
		}


		public  string WHAREHOUSE_ADDRESS
		{
			set
			{
				m_WHAREHOUSE_ADDRESS = value ;
			}
			get
			{
				return m_WHAREHOUSE_ADDRESS;
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
		public spUpdateWAREHOUSES()
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
				cmd.CommandText = "spUpdateWAREHOUSES";
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
				command.CommandText = "spUpdateWAREHOUSES";
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
				command.CommandText = "spUpdateWAREHOUSES";
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
				command.CommandText = "spUpdateWAREHOUSES";
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
					m_WAREHOUSE_ID=Convert.ToInt64(dr["WAREHOUSE_ID"]);
					m_ISDELETED=Convert.ToBoolean(dr["ISDELETED"]);
					m_IS_VIRTUAL=Convert.ToInt32(dr["IS_VIRTUAL"]);
					m_TIME_STAMP= Convert.ToDateTime(dr["TIME_STAMP"]);
					m_LASTUPDATE_DATE= Convert.ToDateTime(dr["LASTUPDATE_DATE"]);
					m_USER_ID= Convert.ToInt32(dr["USER_ID"]);
					m_CONTACT_PERSON= Convert.ToString(dr["CONTACT_PERSON"]);
					m_CONTACT_PHONE= Convert.ToString(dr["CONTACT_PHONE"]);
					m_IPAddress= Convert.ToString(dr["IPAddress"]);
					m_WAREHOUSE_CODE= Convert.ToString(dr["WAREHOUSE_CODE"]);
					m_WAREHOUSE_NAME= Convert.ToString(dr["WAREHOUSE_NAME"]);
					m_WHAREHOUSE_ADDRESS= Convert.ToString(dr["WHAREHOUSE_ADDRESS"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@WAREHOUSE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.BigInt);
			if(m_WAREHOUSE_ID==Constants.LongNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_WAREHOUSE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ISDELETED" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_ISDELETED;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IS_VIRTUAL" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
				parameter.Value = m_IS_VIRTUAL;
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
			parameter.ParameterName = "@LASTUPDATE_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_LASTUPDATE_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LASTUPDATE_DATE;
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
			parameter.ParameterName = "@CONTACT_PERSON" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_CONTACT_PERSON== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CONTACT_PERSON;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CONTACT_PHONE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_CONTACT_PHONE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CONTACT_PHONE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IPAddress" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_IPAddress== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_IPAddress;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@WAREHOUSE_CODE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_WAREHOUSE_CODE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_WAREHOUSE_CODE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@WAREHOUSE_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_WAREHOUSE_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_WAREHOUSE_NAME;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@WHAREHOUSE_ADDRESS" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_WHAREHOUSE_ADDRESS== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_WHAREHOUSE_ADDRESS;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
