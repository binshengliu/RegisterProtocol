using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for TtvncHelper
/// </summary>
public class TtvncHelper : RemoteClientHelper
{
	private static string tableName = "ttvnc";
	private const string initialLink = "wbr://type=2&progname=ttvnc.exe";
	private static int number = 2;
	public const string columnCode = "code";
	public const string columnAssistantMode = "assistant_mode";
	//private string code = "";
	public string Code
	{
		get { return Parameters[columnCode]; }
		set { Parameters[columnCode] = value; }
	}
	//private string assistantMode = "";
	public string AssistantMode
	{
		get { return Parameters[columnAssistantMode]; }
		set { Parameters[columnAssistantMode] = value; }
	}
	private Dictionary<string, string> parameters = new Dictionary<string, string>()
	{
	        {columnCode, ""},
	        {columnAssistantMode, ""},
	};
	public override Dictionary<string, string> Parameters
	{
		get { return parameters; }
	}
	public static RemoteClientHelper GetRemoteClientHelper(string id, string serverType)
	{
		TtvncHelper helper = new TtvncHelper();
		string sql = "select ";
		foreach (string field in helper.Parameters.Keys)
		{
			sql += field;
			sql += ",";
		}
		sql = sql.Substring(0, sql.Length - 1);
		sql += " from " + TtvncHelper.tableName;
		sql += " where cafe_id=" + id;
		sql += " and server_type='" + serverType + "'";
		DataSet ds = DBAccess.GetDataSet(sql, TtvncHelper.tableName);
		if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
		{
			DataTable dt = ds.Tables[TtvncHelper.tableName];
			foreach (string field in new List<string>(helper.Parameters.Keys))
			{
				//kvp.Value = dt.Rows[0][kvp.Key].ToString();
				helper.Parameters[field] = dt.Rows[0][field].ToString();
			}
		}
		return helper;
	}
	private TtvncHelper() { }

	public override string CreateLink(string defaultValue)
	{
		string link = defaultValue;
		if (Code.Length > 0)
		{
			link = initialLink;
			Catenate(ref link, columnCode, Code);
			if (AssistantMode.Length > 0)
				Catenate(ref link, columnAssistantMode, AssistantMode);
		}
		return link;
	}
}
