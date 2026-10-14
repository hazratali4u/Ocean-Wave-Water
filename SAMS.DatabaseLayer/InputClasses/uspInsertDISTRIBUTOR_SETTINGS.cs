using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;


namespace SAMS.DatabaseLayer.Classes
{
	public class uspInsertDISTRIBUTOR_SETTINGS
	{
		#region Private Members
		private string sp_Name = " uspInsertDISTRIBUTOR_SETTINGS" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private bool m_ISTAXPRICE_UPDATE;
		private bool m_CAN_ADD_NEW_TO;
		private bool m_CAN_DISABLE_SERVER_TO;
		private bool m_ISGST_PAID_BY_DIST;
		private bool m_ISTP_UPDATE;
		private bool m_ISRP_UPDATE;
		private int m_DISTRIBUTOR_ID;
		private int m_DISTRIBUTOR_SETTINGS_ID;
		private short m_TRANSFER_TIME;
		#endregion


		#region Public Properties
		public bool ISTAXPRICE_UPDATE
		{
			set
			{
				m_ISTAXPRICE_UPDATE = value ;
			}
			get
			{
				return m_ISTAXPRICE_UPDATE;
			}
		}


		public bool CAN_ADD_NEW_TO
		{
			set
			{
				m_CAN_ADD_NEW_TO = value ;
			}
			get
			{
				return m_CAN_ADD_NEW_TO;
			}
		}


		public bool CAN_DISABLE_SERVER_TO
		{
			set
			{
				m_CAN_DISABLE_SERVER_TO = value ;
			}
			get
			{
				return m_CAN_DISABLE_SERVER_TO;
			}
		}


		public bool ISGST_PAID_BY_DIST
		{
			set
			{
				m_ISGST_PAID_BY_DIST = value ;
			}
			get
			{
				return m_ISGST_PAID_BY_DIST;
			}
		}


		public bool ISTP_UPDATE
		{
			set
			{
				m_ISTP_UPDATE = value ;
			}
			get
			{
				return m_ISTP_UPDATE;
			}
		}


		public bool ISRP_UPDATE
		{
			set
			{
				m_ISRP_UPDATE = value ;
			}
			get
			{
				return m_ISRP_UPDATE;
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


		public int DISTRIBUTOR_SETTINGS_ID
		{
			get
			{
				return m_DISTRIBUTOR_SETTINGS_ID;
			}
		}


		public short TRANSFER_TIME
		{
			set
			{
				m_TRANSFER_TIME = value ;
			}
			get
			{
				return m_TRANSFER_TIME;
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
		public uspInsertDISTRIBUTOR_SETTINGS()
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
				cmd.CommandText = "uspInsertDISTRIBUTOR_SETTINGS";
				cmd.Connection =   m_connection;
				if(m_transaction!=null)
				{
					cmd.Transaction = m_transaction;
				}
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
				m_DISTRIBUTOR_SETTINGS_ID = (int)((IDataParameter)(cmd.Parameters["@DISTRIBUTOR_SETTINGS_ID"])).Value;
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
				command.CommandText = "uspInsertDISTRIBUTOR_SETTINGS";
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
				command.CommandText = "uspInsertDISTRIBUTOR_SETTINGS";
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
				command.CommandText = "uspInsertDISTRIBUTOR_SETTINGS";
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
					m_ISTAXPRICE_UPDATE=Convert.ToBoolean(dr["ISTAXPRICE_UPDATE"]);
					m_CAN_ADD_NEW_TO=Convert.ToBoolean(dr["CAN_ADD_NEW_TO"]);
					m_CAN_DISABLE_SERVER_TO=Convert.ToBoolean(dr["CAN_DISABLE_SERVER_TO"]);
					m_ISGST_PAID_BY_DIST=Convert.ToBoolean(dr["ISGST_PAID_BY_DIST"]);
					m_ISTP_UPDATE=Convert.ToBoolean(dr["ISTP_UPDATE"]);
					m_ISRP_UPDATE=Convert.ToBoolean(dr["ISRP_UPDATE"]);
					m_DISTRIBUTOR_ID= Convert.ToInt32(dr["DISTRIBUTOR_ID"]);
					m_DISTRIBUTOR_SETTINGS_ID= Convert.ToInt32(dr["DISTRIBUTOR_SETTINGS_ID"]);
					m_TRANSFER_TIME= Convert.ToInt16(dr["TRANSFER_TIME"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ISTAXPRICE_UPDATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_ISTAXPRICE_UPDATE;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CAN_ADD_NEW_TO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_CAN_ADD_NEW_TO;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@CAN_DISABLE_SERVER_TO" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_CAN_DISABLE_SERVER_TO;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ISGST_PAID_BY_DIST" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_ISGST_PAID_BY_DIST;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ISTP_UPDATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_ISTP_UPDATE;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ISRP_UPDATE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Bit);
				parameter.Value = m_ISRP_UPDATE;
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
			parameter.ParameterName = "@DISTRIBUTOR_SETTINGS_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			parameter.Direction = ParameterDirection.Output;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TRANSFER_TIME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.SmallInt);
			if(m_TRANSFER_TIME==Constants.ShortNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TRANSFER_TIME;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
