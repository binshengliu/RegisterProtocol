using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NameHelper
/// </summary>
public class NameHelper
{
	public static string GetServerTypeColumnName(string serverName)
	{
		return serverName + "_type";
	}

	public static string GetRemoteClientTableName(string serverColumnName, string id)
	{
		CafeInformationHelper helper = CafeInformationHelper.GetCafeInformationHelper(id);
		string remoteType = helper.Parameters[serverColumnName];
		return remoteType;
	}
}
