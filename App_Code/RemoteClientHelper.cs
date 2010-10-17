using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Data;

/// <summary>
/// Summary description for RemoteClientHelper
/// </summary>
public abstract class RemoteClientHelper
{
	public abstract Dictionary<string, string> Parameters { get; }
	public abstract string CreateLink(string defaultValue);
	protected virtual string Catenate(ref string link, string key, string value)
	{
		link += "&" + key + "=" + value;
		return link;
	}
	public static RemoteClientHelper GetRemoteClientHelper(string remoteClientType, string id, string serverType)
	{
		RemoteClientHelper rch = null;
		switch (remoteClientType)
		{
			case "radmin":
				rch = RadminHelper.GetRemoteClientHelper(id, serverType);
				break;
			case "mstsc":
				rch = MstscHelper.GetRemoteClientHelper(id, serverType);
				break;
			case "ttvnc":
				rch = TtvncHelper.GetRemoteClientHelper(id, serverType);
				break;
			case "teamviewer":
				rch = TeamviewerHelper.GetRemoteClientHelper(id, serverType);
				break;
			case "remotelyanywhere":
				rch = RemotelyanywhereHelper.GetRemoteClientHelper(id, serverType);
				break;
		}
		return rch;
	}
}
