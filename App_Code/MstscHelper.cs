using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MstscHelper
/// </summary>
public class MstscHelper : RemoteClientHelper
{
	private static string tableName = "mstsc";
	private static int number = 1;
	private string ip;
	private string port;
	private string username;
	private string password;
	public MstscHelper() { }
	protected override Dictionary<string, string> GetParameters()
	{
		Dictionary<string, string> parameters = new Dictionary<string, string>();
		parameters.Add("ip", "");
		parameters.Add("port", "");
		parameters.Add("username", "");
		parameters.Add("password", "");
		return parameters;
	}
	protected override bool IsNeeded(string field)
	{
		if (field == "ip")
		{
			return true;
		}
		return false;
	}
	protected override string InitialLink
	{
		get
		{
			return "wbr://type=1&progname=mstsc.exe";
		}
	}
	protected override void InitFields(Dictionary<string, string> parameters)
	{
		parameters.TryGetValue("ip", out ip);
		parameters.TryGetValue("port", out port);
		parameters.TryGetValue("username", out username);
		parameters.TryGetValue("password", out password);
	}
	protected override string MadeLink(string defaultValue)
	{
		string link = defaultValue;
		if (ip.Length > 0)
		{
			link = InitialLink;
			Catenate(ref link, "ip", ip);
			if (port.Length > 0)
				Catenate(ref link, "port", port);
			if (username.Length > 0)
				Catenate(ref link, "username", username);
			if (password.Length > 0)
				Catenate(ref link, "password", password);
		}
		return link;
	}
}
