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
}
