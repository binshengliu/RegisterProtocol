using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RemotelyanywhereHelper
/// </summary>
public class RemotelyanywhereHelper : RemoteClientHelper
{
	private static string tableName = "remotelyanywhere";
	private static int number = 4;
	public RemotelyanywhereHelper() { }
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
			return "http://";
		}
	}
	protected override string Catenate(ref string link, string key, string value)
	{
		switch (key)
		{
			case "ip":
				link += value;
				break;
			case "port":
				link += ":" + value;
				break;
		}
		return link;
	}
}
