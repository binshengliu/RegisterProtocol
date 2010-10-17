using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TeamviewerHelper
/// </summary>
public class TeamviewerHelper : RemoteClientHelper
{
	private static string tableName = "teamviewer";
	private static int number = 3;
	private string teamviewerId;
	private string password;
	private string assistantType;
	public TeamviewerHelper() { }
	protected override Dictionary<string, string> GetParameters()
	{
		Dictionary<string, string> parameters = new Dictionary<string, string>();
		parameters.Add("teamviewer_id", "");
		parameters.Add("password", "");
		parameters.Add("assistant_type", "");
		return parameters;
	}
	protected override bool IsNeeded(string field)
	{
		if (field == "teamviewer_id")
		{
			return true;
		}
		return false;
	}
	protected override string InitialLink
	{
		get
		{
			return "wbr://type=3&progname=teamviewer.exe";
		}
	}
	protected override string Catenate(ref string link, string key, string value)
	{
		switch (key)
		{
			case "teamviewer_id":
				base.Catenate(ref link, "id", value);
				break;
			default:
				base.Catenate(ref link, key, value);
				break;
		}
		return link;
	}
	protected override void InitFields(Dictionary<string, string> parameters)
	{
		parameters.TryGetValue("teamviewer_id", out teamviewerId);
		parameters.TryGetValue("password", out password);
		parameters.TryGetValue("assistant_type", out assistantType);
	}
	protected override string MadeLink(string defaultValue)
	{
		string link = defaultValue;
		if (teamviewerId.Length > 0 && password.Length > 0)
		{
			link = InitialLink;
			Catenate(ref link, "teamviewer_id", teamviewerId);
			Catenate(ref link, "password", password);
			if (assistantType.Length > 0)
				Catenate(ref link, "assistant_type", assistantType);
		}
		return link;
	}
}
