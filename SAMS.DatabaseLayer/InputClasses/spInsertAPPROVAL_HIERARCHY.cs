using System;
using System.Data;
using SAMS.Common.Classes;
using SAMS.DataAccessLayer.Classes;


namespace SAMS.DatabaseLayer.Classes
{
	public class spInsertAPPROVAL_HIERARCHY
	{
		#region Private Members
		private string sp_Name = " spInsertAPPROVAL_HIERARCHY" ;
		private IDbConnection m_connection;
		private IDbTransaction m_transaction;


		private DateTime m_LASTUPDATE_DATE;
		private DateTime m_TIME_STAMP;
		private int m_DISTRIBUTOR_ID;
		private int m_APPROVAL_HIERARCHY_ID;
		private int m_THIRD_APPROVAL;
		private int m_FOURTH_APPROVAL;
		private int m_USER_ID;
		private int m_CLAIM_TYPE_ID;
		private int m_FIRST_APPROVAL;
		private int m_SECOND_APPROVAL;
		private string m_IP_ADDRESS;
		#endregion


		#region Public Properties
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


		public int APPROVAL_HIERARCHY_ID
		{
			get
			{
				return m_APPROVAL_HIERARCHY_ID;
			}
		}


		public int THIRD_APPROVAL
		{
			set
			{
				m_THIRD_APPROVAL = value ;
			}
			get
			{
				return m_THIRD_APPROVAL;
			}
		}


		public int FOURTH_APPROVAL
		{
			set
			{
				m_FOURTH_APPROVAL = value ;
			}
			get
			{
				return m_FOURTH_APPROVAL;
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


		public int CLAIM_TYPE_ID
		{
			set
			{
				m_CLAIM_TYPE_ID = value ;
			}
			get
			{
				return m_CLAIM_TYPE_ID;
			}
		}


		public int FIRST_APPROVAL
		{
			set
			{
				m_FIRST_APPROVAL = value ;
			}
			get
			{
				return m_FIRST_APPROVAL;
			}
		}


		public int SECOND_APPROVAL
		{
			set
			{
				m_SECOND_APPROVAL = value ;
			}
			get
			{
				return m_SECOND_APPROVAL;
			}
		}


		public  string IP_ADDRESS
		{
			set
			{
				m_IP_ADDRESS = value ;
			}
			get
			{
				return m_IP_ADDRESS;
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
		public spInsertAPPROVAL_HIERARCHY()
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
				cmd.CommandText = "spInsertAPPROVAL_HIERARCHY";
				cmd.Connection =   m_connection;
				GetParameterCollection(ref cmd);
				cmd.ExecuteNonQuery();
				m_APPROVAL_HIERARCHY_ID = (int)((IDataParameter)(cmd.Parameters["@APPROVAL_HIERARCHY_ID"])).Value;
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
				command.CommandText = "spInsertAPPROVAL_HIERARCHY";
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
				command.CommandText = "spInsertAPPROVAL_HIERARCHY";
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
				command.CommandText = "spInsertAPPROVAL_HIERARCHY";
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
//					m_LASTUPDATE_DATE= Convert.ToDateTime(first_row["LASTUPDATE_DATE"]);
//					m_TIME_STAMP= Convert.ToDateTime(first_row["TIME_STAMP"]);
//					m_DISTRIBUTOR_ID= Convert.ToInt32(first_row["DISTRIBUTOR_ID"]);
//					m_APPROVAL_HIERARCHY_ID= Convert.ToInt32(first_row["APPROVAL_HIERARCHY_ID"]);
//					m_THIRD_APPROVAL= Convert.ToInt32(first_row["THIRD_APPROVAL"]);
//					m_FOURTH_APPROVAL= Convert.ToInt32(first_row["FOURTH_APPROVAL"]);
//					m_USER_ID= Convert.ToInt32(first_row["USER_ID"]);
//					m_CLAIM_TYPE_ID= Convert.ToInt32(first_row["CLAIM_TYPE_ID"]);
//					m_FIRST_APPROVAL= Convert.ToInt32(first_row["FIRST_APPROVAL"]);
//					m_SECOND_APPROVAL= Convert.ToInt32(first_row["SECOND_APPROVAL"]);
//					m_IP_ADDRESS= Convert.ToString(first_row["IP_ADDRESS"]);
//				}
//			}


		    public void GetParameterCollection(ref IDbCommand cmd)
		{
			IDataParameterCollection pparams = cmd.Parameters;
			IDataParameter parameter ;
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
			parameter.ParameterName = "@APPROVAL_HIERARCHY_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			parameter.Direction = ParameterDirection.Output;
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@THIRD_APPROVAL" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_THIRD_APPROVAL==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_THIRD_APPROVAL;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FOURTH_APPROVAL" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_FOURTH_APPROVAL==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FOURTH_APPROVAL;
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
			parameter.ParameterName = "@CLAIM_TYPE_ID" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_CLAIM_TYPE_ID==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_CLAIM_TYPE_ID;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@FIRST_APPROVAL" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_FIRST_APPROVAL==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_FIRST_APPROVAL;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@SECOND_APPROVAL" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.Int);
			if(m_SECOND_APPROVAL==Constants.IntNullValue)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_SECOND_APPROVAL;
			}
			pparams.Add(parameter);


			parameter = ProviderFactory.GetParameter(EnumProviders.SQLClient);
			parameter.ParameterName = "@IP_ADDRESS" ; 
			parameter.DbType = ProviderFactory.GetDBType(EnumProviders.SQLClient, EnumDBTypes.VarChar);
			if(m_IP_ADDRESS== null)
			{
				parameter.Value = DBNull.Value;
			}
			else
			{
				parameter.Value = m_IP_ADDRESS;
			}
			pparams.Add(parameter);


		}
		#endregion
	}
}
