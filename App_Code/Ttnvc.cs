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
}
