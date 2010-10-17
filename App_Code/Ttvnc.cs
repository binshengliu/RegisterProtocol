using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TtvncHelper
/// </summary>
public class TtvncHelper : RemoteClientHelper
{
	private static string tableName = "ttvnc";
	private static int number = 2;
	private string code;
	private string assistantMode;
	public TtvncHelper() { }
	protected override Dictionary<string, string> GetParameters()
	{
		Dictionary<string, string> parameters = new Dictionary<string, string>();
		parameters.Add("code", "");
		parameters.Add("assistant_mode", "");
		return parameters;
	}
	protected override bool IsNeeded(string field)
	{
		if (field == "code")
		{
			return true;
		}
		return false;
	}
	protected override string InitialLink
	{
		get
		{
			return "wbr://type=2&progname=ttvnc.exe";
		}
	}
	protected override void InitFields(Dictionary<string, string> parameters)
	{
		parameters.TryGetValue("code", out code);
		parameters.TryGetValue("assistant_mode", out assistantMode);
	}
	protected override string MadeLink(string defaultValue)
	{
		string link = defaultValue;
		if (code.Length > 0)
		{
			link = InitialLink;
			Catenate(ref link, "code", code);
			if (assistantMode.Length > 0)
				Catenate(ref link, "assistant_mode", assistantMode);
		}
		return link;
	}
}
