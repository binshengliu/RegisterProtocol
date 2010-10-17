using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MstscHelper
/// </summary>
public class MstscHelper : RemoteClientHelper
{
	private const string tableName = "mstsc";
	private const string initialLink = "wbr://type=1&progname=mstsc.exe";
	private const int number = 1;
	private const string columnIp = "ip";
	private const string columnPort = "port";
	private const string columnUsername = "username";
	private const string columnPassword = "password";

	private string ip = "";
	private string port = "";
	private string username = "";
	private string password = "";

	private Dictionary<string, string> parameters = new Dictionary<string, string>();
	public override Dictionary<string, string> Parameters
	{
		get { return parameters; }
	}
	
	public MstscHelper()
	{
		parameters.Add(columnIp, ip);
		parameters.Add(columnPort, port);
		parameters.Add(columnUsername, username);
		parameters.Add(columnPassword, password);
	}

	protected override string MadeLink(string defaultValue)
	{
		string link = defaultValue;
		if (ip.Length > 0)
		{
			link = initialLink;
			Catenate(ref link, columnIp, ip);
			if (port.Length > 0)
				Catenate(ref link, columnPort, port);
			if (username.Length > 0)
				Catenate(ref link, columnUsername, username);
			if (password.Length > 0)
				Catenate(ref link, columnPassword, password);
		}
		return link;
	}
}
