using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;

namespace SAMS.DatabaseLayer.Classes
{
	public class spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL
	{
		#region Private Members
		private string sp_Name = " spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private DateTime m_TIME_STAMP;
		private int m_DISTRIBUTOR_SYNC_ACTIVITY_ID;
		private int m_ACTIVITY_ID;
		private int m_DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID;
		#endregion


		#region Public Properties
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


		public int DISTRIBUTOR_SYNC_ACTIVITY_ID
		{
			set
			{
				m_DISTRIBUTOR_SYNC_ACTIVITY_ID = value ;
			}
			get
			{
				return m_DISTRIBUTOR_SYNC_ACTIVITY_ID;
			}
		}


		public int ACTIVITY_ID
		{
			set
			{
				m_ACTIVITY_ID = value ;
			}
			get
			{
				return m_ACTIVITY_ID;
			}
		}


		public int DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID
		{
			get
			{
				return m_DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID;
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
		public spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL()
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
				cmd.CommandText = "spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL";
				cmd.Connection =   m_connection;
				if(m_transaction!=null)
				{
					cmd.Transaction = m_transaction;
				}
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
				m_DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID = (int)((IDataParameter)(cmd.Parameters["@DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID"])).Value;
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
				command.CommandText = "spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL";
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
				command.CommandText = "spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL";
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
				command.CommandText = "spInsertDISTRIBUTOR_SYNC_ACTIVITY_DETAIL";
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
					m_TIME_STAMP= Convert.ToDateTime(dr["TIME_STAMP"]);
					m_DISTRIBUTOR_SYNC_ACTIVITY_ID= Convert.ToInt32(dr["DISTRIBUTOR_SYNC_ACTIVITY_ID"]);
					m_ACTIVITY_ID= Convert.ToInt32(dr["ACTIVITY_ID"]);
					m_DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID= Convert.ToInt32(dr["DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID"]);
				}
			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
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
			parameter.ParameterName = "@DISTRIBUTOR_SYNC_ACTIVITY_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DISTRIBUTOR_SYNC_ACTIVITY_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DISTRIBUTOR_SYNC_ACTIVITY_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@ACTIVITY_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_ACTIVITY_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_ACTIVITY_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DISTRIBUTOR_SYNC_ACTIVITY_DETAIL_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			parameter.Direction = ParameterDirection.Output;
			pparams.Add(parameter);


		}
		#endregion
	}
}
