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
		if (!IsPostBack)
		{
			Bind();
		}
	}

	private void Bind()
	{
		ICafeInformationManager cafeInformationManager = GetCafeInformationManager();
		IList<CafeInformation> list = cafeInformationManager.GetAll();
		this.GridViewCafeInformation.DataSource = list;
		this.GridViewCafeInformation.DataBind();
	}
	protected string CreateLink(object id, string serverType)
	{
		string defaultLink = "ConfigurationPrompt.aspx";
		string link = defaultLink;
		ICafeInformationManager ciManager = GetCafeInformationManager();
		CafeInformation ci = ciManager.GetById(id.ToString());
		string serverColumnName = NameHelper.GetServerTypeColumnName(serverType);

		string remoteClientTableName = null;
		switch (serverType)
		{
			case "main_server":
				remoteClientTableName = ci.CiMainServerType;
				break;
			case "secondary_server":
				remoteClientTableName = ci.CiSecondaryServerType;
				break;
			case "cash_register_server":
				remoteClientTableName = ci.CiCashRegisterServerType;
				break;
			case "movie_server":
				remoteClientTableName = ci.CiMovieServerType;
				break;
			case "router_server":
				remoteClientTableName = ci.CiRouterServerType;
				break;
		} 
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
	private ICafeInformationManager GetCafeInformationManager()
	{
		ICafeInformationManager cafeInformationManager = null;
		if (Session["cafeInformationManager"] == null)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			cafeInformationManager = managerFactory.GetCafeInformationManager();
			Session["cafeInformationManager"] = cafeInformationManager;
		}
		else
			cafeInformationManager = (ICafeInformationManager)Session["cafeInformationManager"];
		return cafeInformationManager;
	}
	private IRadminManager GetRadminManager()
	{
		IRadminManager radminManager = null;
		if (Session["radminManager"] == null)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			radminManager = managerFactory.GetRadminManager();
			Session["radminManager"] = radminManager;
		}
		else
			radminManager = (IRadminManager)Session["radminManager"];
		return radminManager;
	}

	private IMstscManager GetMstscManager()
	{
		IMstscManager mstscManager = null;
		if (Session["mstscManager"] == null)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			mstscManager = managerFactory.GetMstscManager();
			Session["mstscManager"] = mstscManager;
		}
		else
			mstscManager = (IMstscManager)Session["mstscManager"];
		return mstscManager;
	}
	private ITtvncManager GetTtvncManager()
	{
		ITtvncManager ttvncManager = null;
		if (Session["ttvncManager"] == null)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			ttvncManager = managerFactory.GetTtvncManager();
			Session["ttvncManager"] = ttvncManager;
		}
		else
			ttvncManager = (ITtvncManager)Session["ttvncManager"];
		return ttvncManager;
	}
	private ITeamviewerManager GetTeamviewerManager()
	{
		ITeamviewerManager teamviewerManager = null;
		if (Session["teamviewerManager"] == null)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			teamviewerManager = managerFactory.GetTeamviewerManager();
			Session["teamviewerManager"] = teamviewerManager;
		}
		else
			teamviewerManager = (ITeamviewerManager)Session["teamviewerManager"];
		return teamviewerManager;
	}
	private IRemotelyanywhereManager GetRemotelyanywhereManager()
	{
		IRemotelyanywhereManager remotelyanywhereManager = null;
		if (Session["remotelyanywhereManager"] == null)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			remotelyanywhereManager = managerFactory.GetRemotelyanywhereManager();
			Session["remotelyanywhereManager"] = remotelyanywhereManager;
		}
		else
			remotelyanywhereManager = (IRemotelyanywhereManager)Session["remotelyanywhereManager"];
		return remotelyanywhereManager;
	}

}
