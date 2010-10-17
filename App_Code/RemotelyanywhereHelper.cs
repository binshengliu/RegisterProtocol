using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RemotelyanywhereHelper
/// </summary>
public class RemotelyanywhereHelper : RemoteClientHelper
{
	private const string tableName = "remotelyanywhere";
	private const string initialLink = "http://";
	private const int number = 4;
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
	public RemotelyanywhereHelper()
	{
		parameters.Add(columnIp, ip);
		parameters.Add(columnPort, port);
		parameters.Add(columnUsername, username);
		parameters.Add(columnPassword, password);
	}

	protected override string Catenate(ref string link, string key, string value)
	{
		switch (key)
		{
			case columnIp:
				link += value;
				break;
			case columnPort:
				link += ":" + value;
				break;
		}
		return link;
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
		}
		return link;
	}
}
