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

	public static List<string> GetControlIdSuffices(string remoteClientType)
	{
		List<string> controlIdSuffices = new List<string>() { "Ip", "Port", "Username", "Password", };
		switch (remoteClientType)
		{
			case "radmin":
				break;
			case "mstsc":
				break;
			case "ttvnc":
				controlIdSuffices = new List<string>() { "AssistantMode", "Code", };
				break;
			case "teamviewer":
				controlIdSuffices = new List<string>() { "Password", "Id", "AssistantType", };
				break;
			case "remotelyanywhere":
				break;
		}
		return controlIdSuffices;
	}
	public static string GetControlIdInfix(string serverType)
	{
		string controlIdInfix = "MainServer";
		switch (serverType)
		{
			case "main_server":
				break;
			case "secondary_server":
				controlIdInfix = "SecondaryServer";
				break;
			case "cash_register_server":
				controlIdInfix = "CashRegisterServer";
				break;
			case "movie_server":
				controlIdInfix = "MovieServer";
				break;
			case "router_server":
				controlIdInfix = "RouterServer";
				break;
		}
		return controlIdInfix;
	}
}
