using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;


namespace SAMS.DatabaseLayer.Classes
{
	public class spUpdateTA_DA_SLABS
	{
		#region Private Members
		private string sp_Name = " spUpdateTA_DA_SLABS" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private int m_TA_DA_SLAB_ID;
		private int m_DESIGNATION_ID;
		private decimal m_FARE;
		private decimal m_MAINTENENCE;
		private decimal m_HOLIDAY;
		private decimal m_LCA;
		private decimal m_LOS;
		private decimal m_OS;
		private string m_SLAB_NAME;
		#endregion


		#region Public Properties
		public int TA_DA_SLAB_ID
		{
			set
			{
				m_TA_DA_SLAB_ID = value ;
			}
			get
			{
				return m_TA_DA_SLAB_ID;
			}
		}


		public int DESIGNATION_ID
		{
			set
			{
				m_DESIGNATION_ID = value ;
			}
			get
			{
				return m_DESIGNATION_ID;
			}
		}


		public decimal  FARE
		{
			set
			{
				m_FARE = value ;
			}
			get
			{
				return m_FARE;
			}
		}


		public decimal  MAINTENENCE
		{
			set
			{
				m_MAINTENENCE = value ;
			}
			get
			{
				return m_MAINTENENCE;
			}
		}


		public decimal  HOLIDAY
		{
			set
			{
				m_HOLIDAY = value ;
			}
			get
			{
				return m_HOLIDAY;
			}
		}


		public decimal  LCA
		{
			set
			{
				m_LCA = value ;
			}
			get
			{
				return m_LCA;
			}
		}


		public decimal  LOS
		{
			set
			{
				m_LOS = value ;
			}
			get
			{
				return m_LOS;
			}
		}


		public decimal  OS
		{
			set
			{
				m_OS = value ;
			}
			get
			{
				return m_OS;
			}
		}


		public  string SLAB_NAME
		{
			set
			{
				m_SLAB_NAME = value ;
			}
			get
			{
				return m_SLAB_NAME;
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
		public spUpdateTA_DA_SLABS()
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
				cmd.CommandText = "spUpdateTA_DA_SLABS";
				cmd.Connection =   m_connection;
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
				command.CommandText = "spUpdateTA_DA_SLABS";
				command.Connection = m_connection;
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
				command.CommandText = "spUpdateTA_DA_SLABS";
				command.Connection = m_connection;
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
				command.CommandText = "spUpdateTA_DA_SLABS";
				command.Connection = m_connection;
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
//					m_TA_DA_SLAB_ID= Convert.ToInt32(first_row["TA_DA_SLAB_ID"]);
//					m_DESIGNATION_ID= Convert.ToInt32(first_row["DESIGNATION_ID"]);
//					m_FARE= Convert.ToDecimal(first_row["FARE"]);
//					m_MAINTENENCE= Convert.ToDecimal(first_row["MAINTENENCE"]);
//					m_HOLIDAY= Convert.ToDecimal(first_row["HOLIDAY"]);
//					m_LCA= Convert.ToDecimal(first_row["LCA"]);
//					m_LOS= Convert.ToDecimal(first_row["LOS"]);
//					m_OS= Convert.ToDecimal(first_row["OS"]);
//					m_SLAB_NAME= Convert.ToString(first_row["SLAB_NAME"]);
//				}
//			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@TA_DA_SLAB_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_TA_DA_SLAB_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_TA_DA_SLAB_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@DESIGNATION_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_DESIGNATION_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_DESIGNATION_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FARE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_FARE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FARE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@MAINTENENCE" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_MAINTENENCE==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_MAINTENENCE;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@HOLIDAY" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_HOLIDAY==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_HOLIDAY;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@LCA" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_LCA==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LCA;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@LOS" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_LOS==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_LOS;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@OS" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Money);
			if(m_OS==Constants.DecimalNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_OS;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SLAB_NAME" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_SLAB_NAME== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SLAB_NAME;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
