using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using RemoteControl.Data.Base;
using RemoteControl.Data.BusinessObjects;
using RemoteControl.Data.ManagerObjects;

/// <summary>
/// Summary description for MstscHelper
/// </summary>
public class MstscHelper : RemoteClientHelper
{
	private const string tableName = "mstsc";
	private const string initialLink = "wbr://type=1&progname=mstsc.exe";
	private const int number = 1;
	public const string columnIp = "ip";
	public const string columnPort = "port";
	public const string columnUsername = "username";
	public const string columnPassword = "password";

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
		MstscHelper helper = new MstscHelper();
		string sql = "select ";
		foreach (string field in helper.Parameters.Keys)
		{
			sql += field;
			sql += ",";
		}
		sql = sql.Substring(0, sql.Length - 1);
		sql += " from " + MstscHelper.tableName;
		sql += " where ci_id=" + id;
		sql += " and server_type='" + serverType + "'";
		DataSet ds = DBAccess.GetDataSet(sql, MstscHelper.tableName);
		if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
		{
			DataTable dt = ds.Tables[MstscHelper.tableName];
			foreach (string field in new List<string>(helper.Parameters.Keys))
			{
				//kvp.Value = dt.Rows[0][kvp.Key].ToString();
				helper.Parameters[field] = dt.Rows[0][field].ToString();
			}
		}
		return helper;
	}
	private MstscHelper() { }

	public static string CreateLink(Mstsc mstsc, string defaultValue)
	{
		if (mstsc == null)
			return defaultValue;
		string link = defaultValue;
		if (mstsc.mIp != null && mstsc.mIp.Length > 0)
		{
			link = initialLink;
			Catenate(ref link, columnIp, mstsc.mIp);
			if (mstsc.mPort != null && mstsc.mPort.Length > 0)
				Catenate(ref link, columnPort, mstsc.mPort);
			if (mstsc.mUsername != null && mstsc.mUsername.Length > 0)
				Catenate(ref link, columnUsername, mstsc.mUsername);
			if (mstsc.mPassword != null && mstsc.mPassword.Length > 0)
				Catenate(ref link, columnPassword, mstsc.mPassword);
		}
		return link;
	}
}
