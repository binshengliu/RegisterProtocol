using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RemoteControl.Data.Base;
using RemoteControl.Data.BusinessObjects;
using RemoteControl.Data.ManagerObjects;

public partial class EditRemoteServer : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string id = Request["id"];
		if (id != null && id.Length > 0)
		{
			FillCafeInformationControls(id);
			if (!this.IsPostBack)
			{
				SetRadioButtonSelected(id);
			}
		}
		DisplayPageControls(true);
		if (id != null && id.Length > 0)
		{
			BindServersValue(id);
		}
	}

	private void BindServersValue(string id)
	{
		List<string> serverTypes = new List<string>()
	        {
	                "main_server", "secondary_server", "cash_register_server", "movie_server", "router_server", 
	        };

		foreach (string serverType in serverTypes)
		{
			BindServerValue(id, serverType);
		}
	}

	/// <summary>
	/// 绑定具体某个ID下的其中一个服务器的配置信息
	/// 在PostBack的情况下，如果用户选择的RadioButton与服务器中的不一样
	/// 说明用户可能要改变该服务器的配置
	/// </summary>
	/// <param name="id"></param>
	/// <param name="serverType"></param>
	private void BindServerValue(string id, string serverType)
	{
		string serverColumnName = NameHelper.GetServerTypeColumnName(serverType);
		CafeInformation ci = GetCafeInformationManager().GetById(id);
		string remoteClientType = GetRemoteClientName(ci, serverType);

		RadioButtonList rbl = GetRadioButtonList(serverType); 
		if (rbl.SelectedValue == remoteClientType)
		{
			string controlIdInfix = NameHelper.GetControlIdInfix(serverType);
			List<string> controlIdSuffices = NameHelper.GetControlIdSuffices(remoteClientType);
			switch (remoteClientType)
			{
				case "radmin":
					Radmin radmin = GetRadminManager().GetById(id, serverType);
					BindRadminValue(radmin, controlIdInfix);
					break;
				case "mstsc":
					Mstsc mstsc = GetMstscManager().GetById(id, serverType);
					BindMstscValue(mstsc, controlIdInfix);
					break;
				case "ttvnc":
					Ttvnc ttvnc = GetTtvncManager().GetById(id, serverType);
					BindTtvncValue(ttvnc, controlIdInfix);
					break;
				case "teamviewer":
					Teamviewer teamviewer = GetTeamviewerManager().GetById(id, serverType);
					BindTeamviewerValue(teamviewer, controlIdInfix);
					break;
				case "remotelyanywhere":
					Remotelyanywhere remotelyanywhere = GetRemotelyanywhereManager().GetById(id, serverType);
					BindRemotelyanywhereValue(remotelyanywhere, controlIdInfix);
					break;
			}
		}
	}

	private void BindRadminValue(Radmin radmin, string controlIdInfix)
	{
		string controlIdPrefix = "TextBox";

		string tbIpId = controlIdPrefix + controlIdInfix + "Ip";
		TextBox tbIp = (TextBox)FindControl(tbIpId);
		if (radmin.rIp != null)
			tbIp.Text = radmin.rIp;

		string tbPortId = controlIdPrefix + controlIdInfix + "Port";
		TextBox tbPort = (TextBox)FindControl(tbPortId);
		if (radmin.rPort != null)
			tbPort.Text = radmin.rPort;

		string tbUsernameId = controlIdPrefix + controlIdInfix + "Username";
		TextBox tbUsername = (TextBox)FindControl(tbUsernameId);
		if (radmin.rUsername != null)
			tbUsername.Text = radmin.rUsername;

		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);
		if (radmin.rPassword != null)
			tbPassword.Text = radmin.rPassword;
	}
	private void BindMstscValue(Mstsc mstsc, string controlIdInfix)
	{
		string controlIdPrefix = "TextBox";

		string tbIpId = controlIdPrefix + controlIdInfix + "Ip";
		TextBox tbIp = (TextBox)FindControl(tbIpId);
		if (mstsc.mIp != null)
			tbIp.Text = mstsc.mIp;

		string tbPortId = controlIdPrefix + controlIdInfix + "Port";
		TextBox tbPort = (TextBox)FindControl(tbPortId);
		if (mstsc.mPort != null)
			tbPort.Text = mstsc.mPort;

		string tbUsernameId = controlIdPrefix + controlIdInfix + "Username";
		TextBox tbUsername = (TextBox)FindControl(tbUsernameId);
		if (mstsc.mUsername != null)
			tbUsername.Text = mstsc.mUsername;

		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);
		if (mstsc.mPassword != null)
			tbPassword.Text = mstsc.mPassword;
	}
	private void BindTtvncValue(Ttvnc ttvnc, string controlIdInfix)
	{
		string controlIdPrefix = "TextBox";

		string tbCodeId = controlIdPrefix + controlIdInfix + "Code";
		TextBox tbCode = (TextBox)FindControl(tbCodeId);
		if (ttvnc.tCode != null)
			tbCode.Text = ttvnc.tCode;

		string tbAssistantModeId = controlIdPrefix + controlIdInfix + "AssistantMode";
		TextBox tbAssistantMode = (TextBox)FindControl(tbAssistantModeId);
		tbAssistantMode.Text = ttvnc.tAssistantMode.ToString();
	}
	private void BindTeamviewerValue(Teamviewer teamviewer, string controlIdInfix)
	{
		string controlIdPrefix = "TextBox";

		string tbIdId = controlIdPrefix + controlIdInfix + "Id";
		TextBox tbId = (TextBox)FindControl(tbIdId);
		if (teamviewer.tTeamviewerId != null)
			tbId.Text = teamviewer.tTeamviewerId;

		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);
		if (teamviewer.tPassword != null)
			tbPassword.Text = teamviewer.tPassword;

		string tbAssistantTypeId = controlIdPrefix + controlIdInfix + "AssistantType";
		TextBox tbAssistantType = (TextBox)FindControl(tbAssistantTypeId);
		if (teamviewer.tAssistantType != null)
			tbAssistantType.Text = teamviewer.tAssistantType.ToString();
	}
	private void BindRemotelyanywhereValue(Remotelyanywhere remotelyanywhere, string controlIdInfix)
	{
		string controlIdPrefix = "TextBox";

		string tbIpId = controlIdPrefix + controlIdInfix + "Ip";
		TextBox tbIp = (TextBox)FindControl(tbIpId);
		if (remotelyanywhere.rIp != null)
			tbIp.Text = remotelyanywhere.rIp;

		string tbPortId = controlIdPrefix + controlIdInfix + "Port";
		TextBox tbPort = (TextBox)FindControl(tbPortId);
		if (remotelyanywhere.rPort != null)
			tbPort.Text = remotelyanywhere.rPort;

		string tbUsernameId = controlIdPrefix + controlIdInfix + "Username";
		TextBox tbUsername = (TextBox)FindControl(tbUsernameId);
		if (remotelyanywhere.rUsername != null)
			tbUsername.Text = remotelyanywhere.rUsername;

		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);
		if (remotelyanywhere.rPassword != null)
			tbPassword.Text = remotelyanywhere.rPassword;
	}

	private void SetRadioButtonSelected(string id)
	{
		List<string> serverTypes = new List<string>()
	        {
	                "main_server", "secondary_server", "cash_register_server", "movie_server", "router_server", 
	        };

		foreach (string serverType in serverTypes)
		{
			string serverColumnName = NameHelper.GetServerTypeColumnName(serverType);

			CafeInformation ci = GetCafeInformationManager().GetById(id);

			string remoteClientName = GetRemoteClientName(ci, serverType);
			RadioButtonList rbl = GetRadioButtonList(serverType);
			rbl.SelectedValue = remoteClientName;
		}
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
	private void DisplayPageControls(bool visible)
	{
		List<string> serverTypes = new List<string>()
		{
			"main_server", "secondary_server", "cash_register_server", "movie_server", "router_server", 
		};
		foreach (string serverType in serverTypes)
		{
			string radioButtonListId = "RadioButtonList" + NameHelper.GetControlIdInfix(serverType) + "RemoteType";
			RadioButtonList rbl = (RadioButtonList)FindControl(radioButtonListId);
			string remoteClientType = rbl.SelectedValue;
			if (remoteClientType.Length > 0)
			{
				DisplayControls(serverType, NameHelper.GetControlIdSuffices(remoteClientType), true);
			}
		}
	}

	private void FillCafeInformationControls(string id)
	{
		ICafeInformationManager ciManager = GetCafeInformationManager();
		CafeInformation ci = ciManager.GetById(id);

		if (ci.Id != null)
			this.TextBoxCafeId.Text = ci.Id;
		if (ci.CiName != null)
			this.TextBoxCafeName.Text = ci.CiName;
		if (ci.CiTelephone != null)
			this.TextBoxTelephone.Text = ci.CiTelephone;
		if (ci.CiContact != null)
			this.TextBoxContact.Text = ci.CiContact;
		if (ci.CiMobile != null)
			this.TextBoxMobile.Text = ci.CiMobile;
	}

	private RadioButtonList GetRadioButtonList(string serverType)
	{
		RadioButtonList rbl = null;
		switch (serverType)
		{
			case "main_server":
				rbl = this.RadioButtonListMainServerRemoteType;
				break;
			case "secondary_server": 
				rbl = this.RadioButtonListSecondaryServerRemoteType;
				break;
			case "cash_register_server":
				rbl = this.RadioButtonListCashRegisterServerRemoteType;
				break;
			case "movie_server":
				rbl = this.RadioButtonListMovieServerRemoteType;
				break;
			case "router_server":
				rbl = this.RadioButtonListRouterServerRemoteType;
				break;
		}
		return rbl;
	}

	private void DisplayControls(string serverType, List<string> controlIdSuffices, bool visible)
	{
		List<string> allControlIdSuffices = new List<string>()
		{
			"Ip", "Port", "Username", "Password",
			"AssistantMode", "Code",
			"Id", "AssistantType",
		};
		string controlIdInfix = NameHelper.GetControlIdInfix(serverType);
		List<string> controlIdPrefices = new List<string>()
		{
			"Label", "TextBox",
		};
		foreach (string p in controlIdPrefices)
		{
			foreach (string s in allControlIdSuffices)
			{
				string controlId = p + controlIdInfix + s;
				if (controlIdSuffices.Contains(s))
				{
					FindControl(controlId).Visible = visible;
				}
				else
				{
					FindControl(controlId).Visible = !visible;
				}
			}
		}
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

	protected void ButtonSave_Click(object sender, EventArgs e)
	{
		string id = this.TextBoxCafeId.Text;
		//string 
	}
}
