using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TeamviewerHelper
/// </summary>
public class TeamviewerHelper : RemoteClientHelper
{
	private const string tableName = "teamviewer";
	private const string initialLink = "wbr://type=3&progname=teamviewer.exe";
	private const int number = 3;
	private const string columnTeamviewerId = "teamviewer_id";
	private const string columnPassword = "password";
	private const string columnAssistantType = "assistant_type";

	private string teamviewerId = "";
	private string password = "";
	private string assistantType = "";

	private Dictionary<string, string> parameters = new Dictionary<string, string>();
	public override Dictionary<string, string> Parameters
	{
		get { return parameters; }
	}

	public TeamviewerHelper()
	{
		parameters.Add(columnTeamviewerId, teamviewerId);
		parameters.Add(columnPassword, password);
		parameters.Add(columnAssistantType, assistantType);
	}

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

	protected override string MadeLink(string defaultValue)
	{
		string link = defaultValue;
		if (teamviewerId.Length > 0 && password.Length > 0)
		{
			link = initialLink;
			Catenate(ref link, columnTeamviewerId, teamviewerId);
			Catenate(ref link, columnPassword, password);
			if (assistantType.Length > 0)
				Catenate(ref link, columnAssistantType, assistantType);
		}
		return link;
	}
}
