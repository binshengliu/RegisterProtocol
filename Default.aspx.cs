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
using RemoteControl.Data.Base;
using RemoteControl.Data.BusinessObjects;
using RemoteControl.Data.ManagerObjects;
public partial class _Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["cafeInformationManager"] == null)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			ICafeInformationManager cafeInformationManager = managerFactory.GetCafeInformationManager();
			Session["cafeInformationManager"] = cafeInformationManager;
		}
		if (Session["mstscManager"] == null)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			IMstscManager mstscManager = managerFactory.GetMstscManager();
			Session["mstscManager"] = mstscManager;
		}
		if (Session["ttvncManager"] == null)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			ITtvncManager ttvncManager = managerFactory.GetTtvncManager();
			Session["ttvncManager"] = ttvncManager;
		}
		if (Session["teamviewerManager"] == null)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			ITeamviewerManager teamviewerManager = managerFactory.GetTeamviewerManager();
			Session["teamviewerManager"] = teamviewerManager;
		}
		if (Session["remotelyanywhereManager"] == null)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			IRemotelyanywhereManager remotelyanywhereManager = managerFactory.GetRemotelyanywhereManager();
			Session["remotelyanywhereManager"] = remotelyanywhereManager;
		}
		if (!IsPostBack)
		{
			Bind();
		}
	}
	private void Bind()
	{
		ICafeInformationManager cafeInformationManager = (ICafeInformationManager)Session["cafeInformationManager"];
		IList<CafeInformation> list = cafeInformationManager.GetAll();
		this.GridViewCafeInformation.DataSource = list;
		this.GridViewCafeInformation.DataBind();
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
