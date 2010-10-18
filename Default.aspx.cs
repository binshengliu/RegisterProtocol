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
		ICafeInformationManager cafeInformationManager = GetCafeInformationManager(true);
		IList<CafeInformation> list = cafeInformationManager.GetAll();
		this.GridViewCafeInformation.DataSource = list;
		this.GridViewCafeInformation.DataBind();
	}
	protected string CreateLink(object id, string serverType)
	{
		string defaultLink = "ConfigurationPrompt.aspx";
		string link = defaultLink;
		ICafeInformationManager ciManager = GetCafeInformationManager(true);
		CafeInformation ci;
		try
		{
			ci = ciManager.GetById(id.ToString());
		}
		catch (System.Exception ex)
		{
			return link;
		}
		string serverColumnName = NameHelper.GetServerTypeColumnName(serverType);

		string remoteClientTableName = GetRemoteClientName(ci, serverType);

		switch (remoteClientTableName)
		{
			case "radmin":
				try
				{
					Radmin radmin = GetRadminManager(true).GetById(id.ToString(), serverType);
					link = RadminHelper.CreateLink(radmin, defaultLink);
				}
				catch (System.Exception ex) { }
				break;
			case "mstsc":
				try
				{
					Mstsc mstsc = GetMstscManager(true).GetById(id.ToString(), serverType);
					link = MstscHelper.CreateLink(mstsc, defaultLink);	
				}
				catch (System.Exception ex) { }
				break;
			case "ttvnc":
				try
				{
					Ttvnc ttvnc = GetTtvncManager(true).GetById(id.ToString(), serverType);
					link = TtvncHelper.CreateLink(ttvnc, defaultLink);	
				}
				catch (System.Exception ex) { }
				break;
			case "teamviewer":
				try
				{
					Teamviewer teamviewer = GetTeamviewerManager(true).GetById(id.ToString(), serverType);
					link = TeamviewerHelper.CreateLink(teamviewer, defaultLink);	
				}
				catch (System.Exception ex) { }
				break;
			case "remotelyanywhere":
				try
				{
					Remotelyanywhere remotelyanywhere = GetRemotelyanywhereManager(true).GetById(id.ToString(), serverType);
					link = RemotelyanywhereHelper.CreateLink(remotelyanywhere, defaultLink);	
				}
				catch (System.Exception ex) { }
				break;
		}
		return link;
	}

	private string GetRemoteClientName(CafeInformation ci, string serverType)
	{
		string remoteClientName = null;
		switch (serverType)
		{
			case "main_server":
				remoteClientName = ci.CiMainServerType;
				break;
			case "secondary_server":
				remoteClientName = ci.CiSecondaryServerType;
				break;
			case "cash_register_server":
				remoteClientName = ci.CiCashRegisterServerType;
				break;
			case "movie_server":
				remoteClientName = ci.CiMovieServerType;
				break;
			case "router_server":
				remoteClientName = ci.CiRouterServerType;
				break;
		}
		return remoteClientName;
	}

	protected void LinkButtonEdit_Click(object sender, EventArgs e)
	{
		string id = ((LinkButton)sender).CommandArgument.ToString();
		Response.Redirect("./EditRemoteServer.aspx?id=" + id);
	}

	protected void LinkButtonDelete_Click(object sender, EventArgs e)
	{
		string id = ((LinkButton)sender).CommandArgument.ToString();
		ICafeInformationManager cim = GetCafeInformationManager(true);
		try
		{
			CafeInformation ci = cim.GetById(id);
			cim.Delete(ci);
			cim.Session.CommitChanges();
		}
		catch (System.Exception ex) { }
		finally
		{
			cim.Dispose();
		}
		Response.Redirect("Default.aspx");
	}
	private ICafeInformationManager GetCafeInformationManager(bool invalidate)
	{
		ICafeInformationManager cafeInformationManager = null;
		if (Session["cafeInformationManager"] == null || invalidate)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			cafeInformationManager = managerFactory.GetCafeInformationManager();
			Session["cafeInformationManager"] = cafeInformationManager;
		}
		else
			cafeInformationManager = (ICafeInformationManager)Session["cafeInformationManager"];
		return cafeInformationManager;
	}
	private IRadminManager GetRadminManager(bool invalidate)
	{
		IRadminManager radminManager = null;
		if (Session["radminManager"] == null || invalidate)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			radminManager = managerFactory.GetRadminManager();
			Session["radminManager"] = radminManager;
		}
		else
			radminManager = (IRadminManager)Session["radminManager"];
		return radminManager;
	}

	private IMstscManager GetMstscManager(bool invalidate)
	{
		IMstscManager mstscManager = null;
		if (Session["mstscManager"] == null || invalidate)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			mstscManager = managerFactory.GetMstscManager();
			Session["mstscManager"] = mstscManager;
		}
		else
			mstscManager = (IMstscManager)Session["mstscManager"];
		return mstscManager;
	}
	private ITtvncManager GetTtvncManager(bool invalidate)
	{
		ITtvncManager ttvncManager = null;
		if (Session["ttvncManager"] == null || invalidate)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			ttvncManager = managerFactory.GetTtvncManager();
			Session["ttvncManager"] = ttvncManager;
		}
		else
			ttvncManager = (ITtvncManager)Session["ttvncManager"];
		return ttvncManager;
	}
	private ITeamviewerManager GetTeamviewerManager(bool invalidate)
	{
		ITeamviewerManager teamviewerManager = null;
		if (Session["teamviewerManager"] == null || invalidate)
		{
			IManagerFactory managerFactory = new ManagerFactory();
			teamviewerManager = managerFactory.GetTeamviewerManager();
			Session["teamviewerManager"] = teamviewerManager;
		}
		else
			teamviewerManager = (ITeamviewerManager)Session["teamviewerManager"];
		return teamviewerManager;
	}
	private IRemotelyanywhereManager GetRemotelyanywhereManager(bool invalidate)
	{
		IRemotelyanywhereManager remotelyanywhereManager = null;
		if (Session["remotelyanywhereManager"] == null || invalidate)
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
