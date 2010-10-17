using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for TeamviewerHelper
/// </summary>
public class TeamviewerHelper : RemoteClientHelper
{
	private const string tableName = "teamviewer";
	private const string initialLink = "wbr://type=3&progname=teamviewer.exe";
	private const int number = 3;
	public const string columnTeamviewerId = "teamviewer_id";
	public const string columnPassword = "password";
	public const string columnAssistantType = "assistant_type";

	//private string teamviewerId = "";
	public string TeamviewerId
	{
		get { return Parameters[columnTeamviewerId]; }
		set { Parameters[columnTeamviewerId] = value; }
	}
	//private string password = "";
	public string Password
	{
		get { return Parameters[columnPassword]; }
		set { Parameters[columnPassword] = value; }
	}
	//private string assistantType = "";
	public string AssistantType
	{
		get { return Parameters[columnAssistantType]; }
		set { Parameters[columnAssistantType] = value; }
	}
	private Dictionary<string, string> parameters = new Dictionary<string, string>()
	{
	        {columnTeamviewerId, ""},
	        {columnPassword, ""},
	        {columnAssistantType, ""},
	};
	public override Dictionary<string, string> Parameters
	{
		get { return parameters; }
	}

	public static RemoteClientHelper GetRemoteClientHelper(string id, string serverType)
	{
		TeamviewerHelper helper = new TeamviewerHelper();
		string sql = "select ";
		foreach (string field in helper.Parameters.Keys)
		{
			sql += field;
			sql += ",";
		}
		sql = sql.Substring(0, sql.Length - 1);
		sql += " from " + TeamviewerHelper.tableName;
		sql += " where id=" + id;
		sql += " and server_type='" + serverType + "'";
		DataSet ds = DBAccess.GetDataSet(sql, TeamviewerHelper.tableName);
		if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
		{
			DataTable dt = ds.Tables[TeamviewerHelper.tableName];
			foreach (string field in new List<string>(helper.Parameters.Keys))
			{
				//kvp.Value = dt.Rows[0][kvp.Key].ToString();
				helper.Parameters[field] = dt.Rows[0][field].ToString();
			}
		}
		return helper;
	}
	private TeamviewerHelper() { }

	protected override string Catenate(ref string link, string key, string value)
	{
		switch (key)
		{
			case columnTeamviewerId:
				base.Catenate(ref link, "id", value);
				break;
			default:
				base.Catenate(ref link, key, value);
				break;
		}
		return link;
	}

	public override string CreateLink(string defaultValue)
	{
		string link = defaultValue;
		if (TeamviewerId.Length > 0 && Password.Length > 0)
		{
			link = initialLink;
			Catenate(ref link, columnTeamviewerId, TeamviewerId);
			Catenate(ref link, columnPassword, Password);
			if (AssistantType.Length > 0)
				Catenate(ref link, columnAssistantType, AssistantType);
		}
		return link;
	}
}
