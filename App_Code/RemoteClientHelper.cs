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
	protected abstract Dictionary<string, string> GetParameters();
	protected abstract bool IsNeeded(string field);
	protected abstract string InitialLink
	{
		get;
	}
	protected virtual string Catenate(ref string link, string key, string value)
	{
		link += "&" + key + "=" + value;
		return link;
	}
	public string CreateLink(string remoteClientTable, string id, string serverType, string defaultValue)
	{
		string link = defaultValue;
		Dictionary<string, string> parameters = GetParameters();
		this.QueryParameters(remoteClientTable, id, serverType, parameters);

		foreach (string field in parameters.Keys)
		{
			string value;
			if (parameters.TryGetValue(field, out value) && value.Length > 0)
			{
				if (IsNeeded(field))
				{
					link = this.InitialLink;
				}
				Catenate(ref link, field, value);
			}
		}
		return link;
	}
	protected void QueryParameters(string remoteClientTable, string id, string serverType, Dictionary<string, string> parameters)
	{
		string sql = "select ";
		foreach (string field in parameters.Keys)
		{
			sql += field;
			sql += ",";
		}
		sql = sql.Substring(0, sql.Length - 1);
		sql += " from " + remoteClientTable;
		sql += " where id=" + id;
		sql += " and server_type='" + serverType + "'";
		DataSet ds = DBAccess.GetDataSet(sql, remoteClientTable);
		if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
		{
			DataTable dt = ds.Tables[remoteClientTable];
			foreach (string field in new List<string>(parameters.Keys))
			{
				//kvp.Value = dt.Rows[0][kvp.Key].ToString();
				parameters[field] = dt.Rows[0][field].ToString();
			}
		}
	}

}
