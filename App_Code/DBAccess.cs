using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for DBAccess
/// </summary>
public class DBAccess
{
	public DBAccess()
	{
	}

	public static DataSet GetDataSet(string selectString, string tableName)
	{
		string connStr = ConfigurationManager.ConnectionStrings["RemoteControlConnectionString"].ConnectionString;
		DataSet ds = new DataSet();
		using (SqlConnection conn = new SqlConnection(connStr))
		{
			SqlDataAdapter adapter = new SqlDataAdapter(selectString, conn);
			adapter.Fill(ds, tableName);
		}
		return ds;
	}
}
