using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;

namespace SAMS.DatabaseLayer.Classes
{
	public class spInsertCREATE_CUSTOMER
	{
		#region Private Members
		private string sp_Name = " spInsertCREATE_CUSTOMER" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private int m_LOCATION_ID;
		private int m_BUSSINESS_TYPE_ID;
		private int m_CUSTOMER_TYPE_ID;
		private int m_CHANNEL_TYPE_ID;
		private int m_VOLUME_CLASS_ID;
		private int m_CUSTOMER_ID;
		private DateTime m_TIMESTAMP;
		private string m_CUSTOMER_NAME;
		private string m_CUSTOMER_SHORTNAME;
		private string m_CONTACT_PERSON;
		private string m_PHONE_NO;
		private string m_MOBILE_NO;
		private string m_EMAIL;
		private string m_GST_NO;
		private string m_ADDRESS;
		private string m_MARKET;
		private string m_ROUTE;
		private string m_HOME_TOWN;
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


		public int BUSSINESS_TYPE_ID
		{
			set
			{
				m_BUSSINESS_TYPE_ID = value ;
			}
			get
			{
				return m_BUSSINESS_TYPE_ID;
			}
		}


		public int CUSTOMER_TYPE_ID
		{
			set
			{
				m_CUSTOMER_TYPE_ID = value ;
			}
			get
			{
				return m_CUSTOMER_TYPE_ID;
			}
		}


		public int CHANNEL_TYPE_ID
		{
			set
			{
				m_CHANNEL_TYPE_ID = value ;
			}
			get
			{
				return m_CHANNEL_TYPE_ID;
			}
		}


		public int VOLUME_CLASS_ID
		{
			set
			{
				m_VOLUME_CLASS_ID = value ;
			}
			get
			{
				return m_VOLUME_CLASS_ID;
			}
		}


		public int CUSTOMER_ID
		{
			get
			{
				return m_CUSTOMER_ID;
			}
		}


		public DateTime TIMESTAMP
		{
			set
			{
				m_TIMESTAMP = value ;
			}
			get
			{
				return m_TIMESTAMP;
			}
		}


		public  string CUSTOMER_NAME
		{
			set
			{
				m_CUSTOMER_NAME = value ;
			}
			get
			{
				return m_CUSTOMER_NAME;
			}
		}


		public  string CUSTOMER_SHORTNAME
		{
			set
			{
				m_CUSTOMER_SHORTNAME = value ;
			}
			get
			{
				return m_CUSTOMER_SHORTNAME;
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


		public  string GST_NO
		{
			set
			{
				m_GST_NO = value ;
			}
			get
			{
				return m_GST_NO;
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


		public  string MARKET
		{
			set
			{
				m_MARKET = value ;
			}
			get
			{
				return m_MARKET;
			}
		}


		public  string ROUTE
		{
			set
			{
				m_ROUTE = value ;
			}
			get
			{
				return m_ROUTE;
			}
		}


		public  string HOME_TOWN
		{
			set
			{
				m_HOME_TOWN = value ;
			}
			get
			{
				return m_HOME_TOWN;
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
		public spInsertCREATE_CUSTOMER()
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
				cmd.CommandText = "spInsertCREATE_CUSTOMER";
				cmd.Connection =   m_connection;
				if(m_transaction!=null)
				{
					cmd.Transaction = m_transaction;
				}
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
				m_CUSTOMER_ID = (int)((IDataParameter)(cmd.Parameters["@CUSTOMER_ID"])).Value;
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
				command.CommandText = "spInsertCREATE_CUSTOMER";
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
				command.CommandText = "spInsertCREATE_CUSTOMER";
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
				command.CommandText = "spInsertCREATE_CUSTOMER";
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
					m_BUSSINESS_TYPE_ID= Convert.ToInt32(dr["BUSSINESS_TYPE_ID"]);
					m_CUSTOMER_TYPE_ID= Convert.ToInt32(dr["CUSTOMER_TYPE_ID"]);
					m_CHANNEL_TYPE_ID= Convert.ToInt32(dr["CHANNEL_TYPE_ID"]);
					m_VOLUME_CLASS_ID= Convert.ToInt32(dr["VOLUME_CLASS_ID"]);
					m_CUSTOMER_ID= Convert.ToInt32(dr["CUSTOMER_ID"]);
					m_TIMESTAMP= Convert.ToDateTime(dr["TIMESTAMP"]);
					m_CUSTOMER_NAME= Convert.ToString(dr["CUSTOMER_NAME"]);
					m_CUSTOMER_SHORTNAME= Convert.ToString(dr["CUSTOMER_SHORTNAME"]);
					m_CONTACT_PERSON= Convert.ToString(dr["CONTACT_PERSON"]);
					m_PHONE_NO= Convert.ToString(dr["PHONE_NO"]);
					m_MOBILE_NO= Convert.ToString(dr["MOBILE_NO"]);
					m_EMAIL= Convert.ToString(dr["EMAIL"]);
					m_GST_NO= Convert.ToString(dr["GST_NO"]);
					m_ADDRESS= Convert.ToString(dr["ADDRESS"]);
					m_MARKET= Convert.ToString(dr["MARKET"]);
					m_ROUTE= Convert.ToString(dr["ROUTE"]);
					m_HOME_TOWN= Convert.ToString(dr["HOME_TOWN"]);
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
			parameter.ParameterName = "@BUSSINESS_TYPE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_BUSSINESS_TYPE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_BUSSINESS_TYPE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CUSTOMER_TYPE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_CUSTOMER_TYPE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CUSTOMER_TYPE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CHANNEL_TYPE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_CHANNEL_TYPE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CHANNEL_TYPE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@VOLUME_CLASS_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_VOLUME_CLASS_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_VOLUME_CLASS_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CUSTOMER_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			parameter.Direction = ParameterDirection.Output;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TIMESTAMP" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.DateTime);
			if(m_TIMESTAMP==Constants.DateNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TIMESTAMP;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CUSTOMER_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_CUSTOMER_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CUSTOMER_NAME;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CUSTOMER_SHORTNAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_CUSTOMER_SHORTNAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CUSTOMER_SHORTNAME;
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
			parameter.ParameterName = "@GST_NO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_GST_NO== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_GST_NO;
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
			parameter.ParameterName = "@MARKET" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_MARKET== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_MARKET;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ROUTE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_ROUTE== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ROUTE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@HOME_TOWN" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_HOME_TOWN== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_HOME_TOWN;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
