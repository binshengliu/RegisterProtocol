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
		string serverColumnName = NameHelper.GetServerTypeColumnName(serverType);
		if (Session["cafe_information_" + id.ToString()] == null)
		{
			Session["cafe_information_" + id.ToString()] = CafeInformationHelper.GetCafeInformationHelper(id.ToString());
		}
		CafeInformationHelper helper = (CafeInformationHelper)Session["cafe_information_" + id.ToString()];
		string remoteClientTableName = helper.Parameters[serverColumnName];
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
			Session[remoteClientTableName + id.ToString() + serverType] = rch;
			link = rch.CreateLink(defaultLink);
		}
		return link;
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
