using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;

public partial class _Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected string CreateLink(object id, string serverType)
	{
		string defaultLink = "ConfigurationPrompt.aspx";
		string link = defaultLink;
		string connStr = ConfigurationManager.ConnectionStrings["RemoteControlConnectionString"].ConnectionString;
		string serverColumnName = GetServerTypeColumnName(serverType);
		string remoteClientTableName = GetRemoteClientTableName(serverColumnName, (string)id);
		RemoteClientHelper rch = null;
		switch (remoteClientTableName)
		{
			case "radmin":
				rch = RadminHelper.GetRemoteClientHelper(id.ToString(), serverType);
				break;
			case "mstsc":
				rch = MstscHelper.GetRemoteClientHelper(id.ToString(), serverType);
				break;
			case "ttvnc":
				rch = TtvncHelper.GetRemoteClientHelper(id.ToString(), serverType);
				break;
			case "teamviewer":
				rch = TeamviewerHelper.GetRemoteClientHelper(id.ToString(), serverType);
				break;
			case "remotelyanywhere":
				rch = RemotelyanywhereHelper.GetRemoteClientHelper(id.ToString(), serverType);
				break;
		}
		if (rch != null)
		{
			link = rch.CreateLink(defaultLink);
		}
		return link;
	}

	protected string GetServerTypeColumnName(string serverName)
	{
		return serverName + "_type";
	}

	protected string GetRemoteClientTableName(string serverColumnName, string id)
	{
		CafeInformationHelper helper = CafeInformationHelper.GetCafeInformationHelper(id);
		string remoteType = helper.Parameters[serverColumnName];
		//string selectString = "select " + serverColumnName + " from cafe_information";
		//selectString += " where id=" + id;
		//DataSet ds = DBAccess.GetDataSet(selectString, serverColumnName);
		//if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count != 0)
		//{
		//        DataTable dt = ds.Tables[serverColumnName];
		//        remoteType = dt.Rows[0][serverColumnName].ToString();
		//}
		return remoteType;
	}

	protected void LinkButtonEdit_Click(object sender, EventArgs e)
	{
		string id = ((LinkButton)sender).CommandArgument.ToString();
		Response.Redirect("./EditRemoteServer.aspx?id=" + id);
	}

	protected void LinkButtonDelete_Click(object sender, EventArgs e)
	{
		string id = ((LinkButton)sender).CommandArgument.ToString();
	}
}
