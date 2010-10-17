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
	private const string initialLink = "wbr://type=2&progname=ttvnc.exe";
	private static int number = 2;
	private const string columnCode = "code";
	private const string columnAssistantMode = "assistant_mode";
	private string code = "";
	private string assistantMode = "";

	private Dictionary<string, string> parameters = new Dictionary<string, string>();
	public override Dictionary<string, string> Parameters
	{
		get { return parameters; }
	}

	public TtvncHelper()
	{
		parameters.Add(columnCode, code);
		parameters.Add(columnAssistantMode, assistantMode);
	}

	protected override string MadeLink(string defaultValue)
	{
		string link = defaultValue;
		if (code.Length > 0)
		{
			link = initialLink;
			Catenate(ref link, columnCode, code);
			if (assistantMode.Length > 0)
				Catenate(ref link, columnAssistantMode, assistantMode);
		}
		return link;
	}
}
