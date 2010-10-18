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
		else
		{
			string controlIdInfix = NameHelper.GetControlIdInfix(serverType);
			List<string> controlIdSuffices = NameHelper.GetControlIdSuffices(remoteClientType);
			switch (remoteClientType)
			{
				case "radmin":
					Radmin radmin = new Radmin();
					BindRadminValue(radmin, controlIdInfix);
					break;
				case "mstsc":
					Mstsc mstsc = new Mstsc();
					BindMstscValue(mstsc, controlIdInfix);
					break;
				case "ttvnc":
					Ttvnc ttvnc = new Ttvnc();
					BindTtvncValue(ttvnc, controlIdInfix);
					break;
				case "teamviewer":
					Teamviewer teamviewer = new Teamviewer();
					BindTeamviewerValue(teamviewer, controlIdInfix);
					break;
				case "remotelyanywhere":
					Remotelyanywhere remotelyanywhere = new Remotelyanywhere();
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
		else
			tbIp.Text = "";

		string tbPortId = controlIdPrefix + controlIdInfix + "Port";
		TextBox tbPort = (TextBox)FindControl(tbPortId);
		if (radmin.rPort != null)
			tbPort.Text = radmin.rPort;
		else
			tbPort.Text = "";

		string tbUsernameId = controlIdPrefix + controlIdInfix + "Username";
		TextBox tbUsername = (TextBox)FindControl(tbUsernameId);
		if (radmin.rUsername != null)
			tbUsername.Text = radmin.rUsername;
		else
			tbUsername.Text = "";

		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);
		if (radmin.rPassword != null)
			tbPassword.Text = radmin.rPassword;
		else
			tbPassword.Text = "";
	}
	private void BindMstscValue(Mstsc mstsc, string controlIdInfix)
	{
		string controlIdPrefix = "TextBox";

		string tbIpId = controlIdPrefix + controlIdInfix + "Ip";
		TextBox tbIp = (TextBox)FindControl(tbIpId);
		if (mstsc.mIp != null)
			tbIp.Text = mstsc.mIp;
		else
			tbIp.Text = "";

		string tbPortId = controlIdPrefix + controlIdInfix + "Port";
		TextBox tbPort = (TextBox)FindControl(tbPortId);
		if (mstsc.mPort != null)
			tbPort.Text = mstsc.mPort;
		else
			tbPort.Text = "";

		string tbUsernameId = controlIdPrefix + controlIdInfix + "Username";
		TextBox tbUsername = (TextBox)FindControl(tbUsernameId);
		if (mstsc.mUsername != null)
			tbUsername.Text = mstsc.mUsername;
		else
			tbUsername.Text = "";

		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);
		if (mstsc.mPassword != null)
			tbPassword.Text = mstsc.mPassword;
		else
			tbPassword.Text = "";
	}
	private void BindTtvncValue(Ttvnc ttvnc, string controlIdInfix)
	{
		string controlIdPrefix = "TextBox";

		string tbCodeId = controlIdPrefix + controlIdInfix + "Code";
		TextBox tbCode = (TextBox)FindControl(tbCodeId);
		string tbAssistantModeId = controlIdPrefix + controlIdInfix + "AssistantMode";
		TextBox tbAssistantMode = (TextBox)FindControl(tbAssistantModeId);
		if (ttvnc.tCode != null)
		{
			tbCode.Text = ttvnc.tCode;
			tbAssistantMode.Text = ttvnc.tAssistantMode.ToString();
		}
		else
		{
			tbCode.Text = "";
			tbAssistantMode.Text = "";
		}
	}
	private void BindTeamviewerValue(Teamviewer teamviewer, string controlIdInfix)
	{
		string controlIdPrefix = "TextBox";

		string tbIdId = controlIdPrefix + controlIdInfix + "Id";
		TextBox tbId = (TextBox)FindControl(tbIdId);
		string tbAssistantTypeId = controlIdPrefix + controlIdInfix + "AssistantType";
		TextBox tbAssistantType = (TextBox)FindControl(tbAssistantTypeId);
		if (teamviewer.tTeamviewerId != null)
		{
			tbId.Text = teamviewer.tTeamviewerId;
			tbAssistantType.Text = teamviewer.tAssistantType.ToString();
		}
		else
		{	
			tbId.Text = "";
			tbAssistantType.Text = "";
		}
		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);
		if (teamviewer.tPassword != null)
			tbPassword.Text = teamviewer.tPassword;
		else
			tbPassword.Text = "";
	}
	private void BindRemotelyanywhereValue(Remotelyanywhere remotelyanywhere, string controlIdInfix)
	{
		string controlIdPrefix = "TextBox";

		string tbIpId = controlIdPrefix + controlIdInfix + "Ip";
		TextBox tbIp = (TextBox)FindControl(tbIpId);
		if (remotelyanywhere.rIp != null)
			tbIp.Text = remotelyanywhere.rIp;
		else
			tbIp.Text = "";

		string tbPortId = controlIdPrefix + controlIdInfix + "Port";
		TextBox tbPort = (TextBox)FindControl(tbPortId);
		if (remotelyanywhere.rPort != null)
			tbPort.Text = remotelyanywhere.rPort;
		else
			tbPort.Text = "";

		string tbUsernameId = controlIdPrefix + controlIdInfix + "Username";
		TextBox tbUsername = (TextBox)FindControl(tbUsernameId);
		if (remotelyanywhere.rUsername != null)
			tbUsername.Text = remotelyanywhere.rUsername;
		else
			tbUsername.Text = "";

		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);
		if (remotelyanywhere.rPassword != null)
			tbPassword.Text = remotelyanywhere.rPassword;
		else
			tbPassword.Text = "";
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
		string remoteClientType = this.RadioButtonListMainServerRemoteType.SelectedValue;
	}

	private void SaveRemoteClient(string serverType, string remoteClientType)
	{
		switch (remoteClientType)
		{
			case "radmin":
				break;
			case "mstsc":
				break;
			case "ttvnc":
				break;
			case "teamviewer":
				break;
			case "remotelyanywhere":
				break;
		}
	}

	private void SaveRadmin(string id, string serverType)
	{
		string controlIdInfix = NameHelper.GetControlIdInfix(serverType);
		string controlIdPrefix = "TextBox";
		string tbIpId = controlIdPrefix + controlIdInfix + "Ip";
		TextBox tbIp = (TextBox)FindControl(tbIpId);
		if (tbIp.Text.Length == 0)
			return;
		string tbPortId = controlIdPrefix + controlIdInfix + "Port";
		TextBox tbPort = (TextBox)FindControl(tbPortId);

		string tbUsernameId = controlIdPrefix + controlIdInfix + "Username";
		TextBox tbUsername = (TextBox)FindControl(tbUsernameId);

		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);

		IRadminManager rm = GetRadminManager();
		Radmin radmin = new Radmin();
		radmin.CiId = id;
		radmin.CiServerType = serverType;
		radmin.rIp = tbIp.Text;
		radmin.rPort = tbPort.Text;
		radmin.rUsername = tbUsername.Text;
		radmin.rPassword = tbPassword.Text;
		rm.SaveOrUpdate(radmin);
	}

	private void SaveMstsc(string id, string serverType)
	{
		string controlIdInfix = NameHelper.GetControlIdInfix(serverType);
		string controlIdPrefix = "TextBox";
		string tbIpId = controlIdPrefix + controlIdInfix + "Ip";
		TextBox tbIp = (TextBox)FindControl(tbIpId);
		if (tbIp.Text.Length == 0)
			return;
		string tbPortId = controlIdPrefix + controlIdInfix + "Port";
		TextBox tbPort = (TextBox)FindControl(tbPortId);

		string tbUsernameId = controlIdPrefix + controlIdInfix + "Username";
		TextBox tbUsername = (TextBox)FindControl(tbUsernameId);

		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);

		IMstscManager mm = GetMstscManager();
		Mstsc mstsc = new Mstsc();
		mstsc.CiId = id;
		mstsc.CiServerType = serverType;
		mstsc.mIp = tbIp.Text;
		mstsc.mPort = tbPort.Text;
		mstsc.mUsername = tbUsername.Text;
		mstsc.mPassword = tbPassword.Text;
		mm.SaveOrUpdate(mstsc);
	}
	private void SaveTtvnc(string id, string serverType)
	{
		string controlIdInfix = NameHelper.GetControlIdInfix(serverType);
		string controlIdPrefix = "TextBox";
		string tbCodeId = controlIdPrefix + controlIdInfix + "Code";
		TextBox tbCode = (TextBox)FindControl(tbCodeId);
		string tbAssistantModeId = controlIdPrefix + controlIdInfix + "AssistantMode";
		TextBox tbAssistantMode = (TextBox)FindControl(tbAssistantModeId);
		if (tbCode.Text.Length == 0 || tbAssistantMode.Text.Length == 0)
			return;

		ITtvncManager tm = GetTtvncManager();
		Ttvnc ttvnc = new Ttvnc();
		ttvnc.CiId = id;
		ttvnc.CiServerType = serverType;
		ttvnc.tCode = tbCode.Text;
		ttvnc.tAssistantMode = Convert.ToByte(tbAssistantMode.Text);
		tm.SaveOrUpdate(ttvnc);
	}

	private void SaveTeamviewer(string id, string serverType)
	{
		string controlIdInfix = NameHelper.GetControlIdInfix(serverType);
		string controlIdPrefix = "TextBox";
	
		string tbIdId = controlIdPrefix + controlIdInfix + "Id";
		TextBox tbId = (TextBox)FindControl(tbIdId);
		if (tbId.Text.Length == 0)
			return;
		
		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);
		if (tbPassword.Text.Length == 0)
			return;

		string tbAssistantTypeId = controlIdPrefix + controlIdInfix + "AssistantType";
		TextBox tbAssistantType = (TextBox)FindControl(tbAssistantTypeId);
		if (tbAssistantTypeId.Text.Length == 0)
			return;

		ITeamviewerManager tm = GetTeamviewerManager();
		Teamviewer teamviewer = new Teamviewer();
		teamviewer.CiId = id;
		teamviewer.CiServerType = serverType;
		teamviewer.tTeamviewerId = tbId.Text;
		teamviewer.tPassword = tbPassword.Text;
		teamviewer.tAssistantType = Convert.ToInt32(tbAssistantType.Text);
		tm.SaveOrUpdate(teamviewer);
	}

	private void SaveRemotelyanywhere(string id, string serverType)
	{
		string controlIdInfix = NameHelper.GetControlIdInfix(serverType);
		string controlIdPrefix = "TextBox";
		string tbIpId = controlIdPrefix + controlIdInfix + "Ip";
		TextBox tbIp = (TextBox)FindControl(tbIpId);
		if (tbIp.Text.Length == 0)
			return;
		string tbPortId = controlIdPrefix + controlIdInfix + "Port";
		TextBox tbPort = (TextBox)FindControl(tbPortId);

		string tbUsernameId = controlIdPrefix + controlIdInfix + "Username";
		TextBox tbUsername = (TextBox)FindControl(tbUsernameId);

		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);

		IRemotelyanywhereManager rm = GetRemotelyanywhereManager();
		Remotelyanywhere remotelyanywhere = new Remotelyanywhere();
		remotelyanywhere.CiId = id;
		remotelyanywhere.CiServerType = serverType;
		remotelyanywhere.rIp = tbIp.Text;
		remotelyanywhere.rPort = tbPort.Text;
		remotelyanywhere.rUsername = tbUsername.Text;
		remotelyanywhere.rPassword = tbPassword.Text;
		rm.SaveOrUpdate(remotelyanywhere);
	}
}
