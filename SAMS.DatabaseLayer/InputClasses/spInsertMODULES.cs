using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;


namespace SAMS.DatabaseLayer.Classes
{
	public class spInsertMODULES
	{
		#region Private Members
		private string sp_Name = " spInsertMODULES" ;
		private IDbConnection m_Connection;
		private IDbTransaction m_transaction;


		private int m_MODULE_TYPE_ID;
		private int m_MODULE_ID;
		private string m_MODULE_NAME;
		#endregion


		#region Public Properties
		public int MODULE_TYPE_ID
		{
			set
			{
				m_MODULE_TYPE_ID = value ;
			}
			get
			{
				return m_MODULE_TYPE_ID;
			}
		}


		public int MODULE_ID
		{
			set
			{
				m_MODULE_ID = value ;
			}

			get
			{
				return m_MODULE_ID;
			}
		}


		public  string MODULE_NAME
		{
			set
			{
				m_MODULE_NAME = value ;
			}
			get
			{
				return m_MODULE_NAME;
			}
		}




		public IDbConnection  Connection
		{
			set
			{
				m_Connection = value;
			}
			get
			{
				return m_Connection;
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
		public spInsertMODULES()
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
				cmd.CommandText = "spInsertMODULES";
				cmd.Connection =   m_Connection;
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();				
				return true;
			}
			catch(Exception e)
			{
				return false;
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
				command.CommandText = "spInsertMODULES";
				command.Connection = m_Connection;
				GetParameterCollection(ref command);
				IDataReader dr = command.ExecuteReader();
				return dr;
			}
			catch(Exception exp)
			{
				return null;
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
				command.CommandText = "spInsertMODULES";
				command.Connection = m_Connection;
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
				command.CommandText = "spInsertMODULES";
				command.Connection = m_Connection;
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


//			public void FirstReader(IDataReader dr)
//			{
//				if(dr.HasRows == true)
//				{
//					DataRow first_row = dr[0];
//					m_MODULE_TYPE_ID= Convert.ToInt32(first_row["MODULE_TYPE_ID"]);
//					m_MODULE_ID= Convert.ToInt32(first_row["MODULE_ID"]);
//					m_MODULE_NAME= Convert.ToString(first_row["MODULE_NAME"]);
//				}
//			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@MODULE_TYPE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_MODULE_TYPE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_MODULE_TYPE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@MODULE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_MODULE_TYPE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_MODULE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@MODULE_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_MODULE_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_MODULE_NAME;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
