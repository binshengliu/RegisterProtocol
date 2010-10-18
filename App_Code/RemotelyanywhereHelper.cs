using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using RemoteControl.Data.Base;
using RemoteControl.Data.BusinessObjects;
using RemoteControl.Data.ManagerObjects;

/// <summary>
/// Summary description for RemotelyanywhereHelper
/// </summary>
public class RemotelyanywhereHelper : RemoteClientHelper
{
	private const string tableName = "remotelyanywhere";
	private const string initialLink = "http://";
	private const int number = 4;
	private const string columnIp = "ip";
	private const string columnPort = "port";
	private const string columnUsername = "username";
	private const string columnPassword = "password";

	//private string ip = "";
	public string Ip
	{
		get { return Parameters[columnIp]; }
		set { Parameters[columnIp] = value; }
	}
	//private string port = "";
	public string Port
	{
		get { return Parameters[columnPort]; }
		set { Parameters[columnPort] = value; }
	}
	//private string username = "";
	public string Username
	{
		get { return Parameters[columnUsername]; }
		set { Parameters[columnUsername] = value; }
	}
	//private string password = "";
	public string Password
	{
		get { return Parameters[columnPassword]; }
		set { Parameters[columnPassword] = value; }
	}
	private Dictionary<string, string> parameters = new Dictionary<string, string>()
	{
	        {columnIp, ""},
	        {columnPort, ""},
	        {columnUsername, ""},
	        {columnPassword, ""},
	};
	public override Dictionary<string, string> Parameters
	{
		get { return parameters; }
	}
	public static RemoteClientHelper GetRemoteClientHelper(string id, string serverType)
	{
		RemotelyanywhereHelper helper = new RemotelyanywhereHelper();
		string sql = "select ";
		foreach (string field in helper.Parameters.Keys)
		{
			sql += field;
			sql += ",";
		}
		sql = sql.Substring(0, sql.Length - 1);
		sql += " from " + RemotelyanywhereHelper.tableName;
		sql += " where ci_id=" + id;
		sql += " and server_type='" + serverType + "'";
		DataSet ds = DBAccess.GetDataSet(sql, RemotelyanywhereHelper.tableName);
		if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
		{
			DataTable dt = ds.Tables[RemotelyanywhereHelper.tableName];
			foreach (string field in new List<string>(helper.Parameters.Keys))
			{
				helper.Parameters[field] = dt.Rows[0][field].ToString();
			}
		}
		return helper;
	}
	private RemotelyanywhereHelper() { }

	protected static string Catenate(ref string link, string key, string value)
	{
		switch (key)
		{
			case columnIp:
				link += value;
				break;
			case columnPort:
				link += ":" + value;
				break;
		}
		return link;
	}

	public static string CreateLink(Remotelyanywhere remotelyanywhere, string defaultValue)
	{
		string link = defaultValue;
		if (remotelyanywhere.rIp != null && remotelyanywhere.rIp.Length > 0)
		{
			link = initialLink;
			Catenate(ref link, columnIp, remotelyanywhere.rIp);
			if (remotelyanywhere.rPort != null && remotelyanywhere.rPort.Length > 0)
				Catenate(ref link, columnPort, remotelyanywhere.rPort);
		}
		return link;
	}
}
