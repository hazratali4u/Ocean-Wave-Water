using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;


namespace SAMS.DatabaseLayer.Classes
{
	public class spSelectLOCATION
	{
		#region Private Members
		private string sp_Name = " spSelectLOCATION" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private int m_LOCATION_ID;
		private int m_TOWN_ID;
		private int m_LOCATION_TYPE_ID;
		private DateTime m_OPENING_DATE;
		private DateTime m_CLOSING_DATE;
		private bool m_INPUT_ACTIVE;
		private bool m_OUTPUT_ACTIVE;
		private string m_LOCATION_NAME;
		private string m_LOCATION_SHORT_NAME;
		private string m_PHONE_NO;
		private string m_MOBILE_NO;
		private string m_FAX_NO;
		private string m_EMAIL;
		private string m_REGISTRATION_NO;
		private string m_ADDRESS;
		private string m_CONTACT_PERSON;
		#endregion

		#region Public Properties
		public int LOCATION_ID
		{
			set
			{
				m_LOCATION_ID = value ;
			}
			get
			{
				return m_LOCATION_ID;
			}
		}


		public int TOWN_ID
		{
			set
			{
				m_TOWN_ID = value ;
			}
			get
			{
				return m_TOWN_ID;
			}
		}


		public int LOCATION_TYPE_ID
		{
			set
			{
				m_LOCATION_TYPE_ID = value ;
			}
			get
			{
				return m_LOCATION_TYPE_ID;
			}
		}


		public DateTime OPENING_DATE
		{
			set
			{
				m_OPENING_DATE = value ;
			}
			get
			{
				return m_OPENING_DATE;
			}
		}


		public DateTime CLOSING_DATE
		{
			set
			{
				m_CLOSING_DATE = value ;
			}
			get
			{
				return m_CLOSING_DATE;
			}
		}


		public bool INPUT_ACTIVE
		{
			set
			{
				m_INPUT_ACTIVE = value ;
			}
			get
			{
				return m_INPUT_ACTIVE;
			}
		}


		public bool OUTPUT_ACTIVE
		{
			set
			{
				m_OUTPUT_ACTIVE = value ;
			}
			get
			{
				return m_OUTPUT_ACTIVE;
			}
		}


		public  string LOCATION_NAME
		{
			set
			{
				m_LOCATION_NAME = value ;
			}
			get
			{
				return m_LOCATION_NAME;
			}
		}


		public  string LOCATION_SHORT_NAME
		{
			set
			{
				m_LOCATION_SHORT_NAME = value ;
			}
			get
			{
				return m_LOCATION_SHORT_NAME;
			}
		}


		public  string PHONE_NO
		{
			set
			{
				m_PHONE_NO = value ;
			}
			get
			{
				return m_PHONE_NO;
			}
		}


		public  string MOBILE_NO
		{
			set
			{
				m_MOBILE_NO = value ;
			}
			get
			{
				return m_MOBILE_NO;
			}
		}


		public  string FAX_NO
		{
			set
			{
				m_FAX_NO = value ;
			}
			get
			{
				return m_FAX_NO;
			}
		}


		public  string EMAIL
		{
			set
			{
				m_EMAIL = value ;
			}
			get
			{
				return m_EMAIL;
			}
		}


		public  string REGISTRATION_NO
		{
			set
			{
				m_REGISTRATION_NO = value ;
			}
			get
			{
				return m_REGISTRATION_NO;
			}
		}


		public  string ADDRESS
		{
			set
			{
				m_ADDRESS = value ;
			}
			get
			{
				return m_ADDRESS;
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
		public spSelectLOCATION()
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
				cmd.CommandText = "spSelectLOCATION";
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
				command.CommandText = "spSelectLOCATION";
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
				command.CommandText = "spSelectLOCATION";
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
				command.CommandText = "spSelectLOCATION";
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
					m_LOCATION_ID= Convert.ToInt32(dr["LOCATION_ID"]);
					m_TOWN_ID= Convert.ToInt32(dr["TOWN_ID"]);
					m_LOCATION_TYPE_ID= Convert.ToInt32(dr["LOCATION_TYPE_ID"]);
					m_OPENING_DATE= Convert.ToDateTime(dr["OPENING_DATE"]);
					m_CLOSING_DATE= Convert.ToDateTime(dr["CLOSING_DATE"]);
					m_INPUT_ACTIVE=Convert.ToBoolean(dr["INPUT_ACTIVE"]);
					m_OUTPUT_ACTIVE=Convert.ToBoolean(dr["OUTPUT_ACTIVE"]);
					m_LOCATION_NAME= Convert.ToString(dr["LOCATION_NAME"]);
					m_LOCATION_SHORT_NAME= Convert.ToString(dr["LOCATION_SHORT_NAME"]);
					m_PHONE_NO= Convert.ToString(dr["PHONE_NO"]);
					m_MOBILE_NO= Convert.ToString(dr["MOBILE_NO"]);
					m_FAX_NO= Convert.ToString(dr["FAX_NO"]);
					m_EMAIL= Convert.ToString(dr["EMAIL"]);
					m_REGISTRATION_NO= Convert.ToString(dr["REGISTRATION_NO"]);
					m_ADDRESS= Convert.ToString(dr["ADDRESS"]);
					m_CONTACT_PERSON= Convert.ToString(dr["CONTACT_PERSON"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@LOCATION_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_LOCATION_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LOCATION_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TOWN_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_TOWN_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TOWN_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@LOCATION_TYPE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_LOCATION_TYPE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LOCATION_TYPE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@OPENING_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_OPENING_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_OPENING_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CLOSING_DATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_CLOSING_DATE==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CLOSING_DATE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@INPUT_ACTIVE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_INPUT_ACTIVE;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@OUTPUT_ACTIVE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_OUTPUT_ACTIVE;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@LOCATION_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_LOCATION_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LOCATION_NAME;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@LOCATION_SHORT_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_LOCATION_SHORT_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LOCATION_SHORT_NAME;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@PHONE_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_PHONE_NO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_PHONE_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@MOBILE_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_MOBILE_NO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_MOBILE_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FAX_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_FAX_NO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FAX_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@EMAIL" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_EMAIL== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_EMAIL;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@REGISTRATION_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_REGISTRATION_NO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_REGISTRATION_NO;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ADDRESS" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_ADDRESS== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ADDRESS;
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


		}
		#endregion
	}
}
