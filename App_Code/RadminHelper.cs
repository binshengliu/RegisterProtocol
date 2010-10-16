using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for RadminHelper
/// </summary>
public class RadminHelper : RemoteClientHelper
{
	private static string tableName = "radmin";
	private static int number = 0;
	public RadminHelper() { }
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
			return "wbr://type=0&progname=radmin.exe";
		}
	}
}
