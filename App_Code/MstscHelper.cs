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
}
