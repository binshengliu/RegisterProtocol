using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
		CafeInformationHelper cih;
		if (Session["cafe_information_" + id] != null)
			cih = (CafeInformationHelper)Session["cafe_information_" + id];
		else
		{
			cih = CafeInformationHelper.GetCafeInformationHelper(id);
			Session["cafe_information_" + id] = cih;
		}
		string remoteClientType = cih.Parameters[serverColumnName];

		RadioButtonList rbl = GetRadioButtonList(serverType); 
		if (rbl.SelectedValue == remoteClientType)
		{
			RemoteClientHelper rch = null;
			if (Session[remoteClientType + id + serverType] != null)
			{
				rch = (RemoteClientHelper)Session[remoteClientType + id.ToString() + serverType];
			}
			else
			{
				rch = RemoteClientHelper.GetRemoteClientHelper(remoteClientType, id, serverType);
				Session[remoteClientType + id + serverType] = rch;
			}
			string controlIdInfix = NameHelper.GetControlIdInfix(serverType);
			List<string> controlIdSuffices = NameHelper.GetControlIdSuffices(remoteClientType);
			switch (remoteClientType)
			{
				case "radmin":
					BindRadminValue(rch, controlIdInfix);
					break;
				case "mstsc":
					BindMstscValue(rch, controlIdInfix);
					break;
				case "ttvnc":
					BindTtvncValue(rch, controlIdInfix);
					break;
				case "teamviewer":
					BindTeamviewerValue(rch, controlIdInfix);
					break;
				case "remotelyanywhere":
					BindRemotelyanywhereValue(rch, controlIdInfix);
					break;
			}
		}
	}

	private void BindRadminValue(RemoteClientHelper rch, string controlIdInfix)
	{
		RadminHelper rh = (RadminHelper)rch;
		string controlIdPrefix = "TextBox";

		string tbIpId = controlIdPrefix + controlIdInfix + "Ip";
		TextBox tbIp = (TextBox)FindControl(tbIpId);
		tbIp.Text = rh.Parameters[RadminHelper.columnIp];

		string tbPortId = controlIdPrefix + controlIdInfix + "Port";
		TextBox tbPort = (TextBox)FindControl(tbPortId);
		tbPort.Text = rh.Parameters[RadminHelper.columnPort];

		string tbUsernameId = controlIdPrefix + controlIdInfix + "Username";
		TextBox tbUsername = (TextBox)FindControl(tbUsernameId);
		tbUsername.Text = rh.Parameters[RadminHelper.columnUsername];

		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);
		tbPassword.Text = rh.Parameters[RadminHelper.columnPassword];
	}
	private void BindMstscValue(RemoteClientHelper rch, string controlIdInfix)
	{
		MstscHelper mh = (MstscHelper)rch;
		string controlIdPrefix = "TextBox";

		string tbIpId = controlIdPrefix + controlIdInfix + "Ip";
		TextBox tbIp = (TextBox)FindControl(tbIpId);
		tbIp.Text = mh.Parameters[MstscHelper.columnIp];

		string tbPortId = controlIdPrefix + controlIdInfix + "Port";
		TextBox tbPort = (TextBox)FindControl(tbPortId);
		tbPort.Text = mh.Parameters[RadminHelper.columnPort];

		string tbUsernameId = controlIdPrefix + controlIdInfix + "Username";
		TextBox tbUsername = (TextBox)FindControl(tbUsernameId);
		tbUsername.Text = mh.Parameters[RadminHelper.columnUsername];

		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);
		tbPassword.Text = mh.Parameters[RadminHelper.columnPassword];
	}
	private void BindTtvncValue(RemoteClientHelper rch, string controlIdInfix)
	{
		TtvncHelper th = (TtvncHelper)rch;
		string controlIdPrefix = "TextBox";

		string tbCodeId = controlIdPrefix + controlIdInfix + "Code";
		TextBox tbCode = (TextBox)FindControl(tbCodeId);
		tbCode.Text = th.Parameters[TtvncHelper.columnCode];

		string tbAssistantModeId = controlIdPrefix + controlIdInfix + "AssistantMode";
		TextBox tbAssistantMode = (TextBox)FindControl(tbAssistantModeId);
		tbAssistantMode.Text = th.Parameters[TtvncHelper.columnAssistantMode];
	}
	private void BindTeamviewerValue(RemoteClientHelper rch, string controlIdInfix)
	{
		TeamviewerHelper th = (TeamviewerHelper)rch;
		string controlIdPrefix = "TextBox";

		string tbIdId = controlIdPrefix + controlIdInfix + "Id";
		TextBox tbId = (TextBox)FindControl(tbIdId);
		tbId.Text = th.Parameters[TeamviewerHelper.columnTeamviewerId];

		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);
		tbPassword.Text = th.Parameters[TeamviewerHelper.columnPassword];

		string tbAssistantTypeId = controlIdPrefix + controlIdInfix + "AssistantType";
		TextBox tbAssistantType = (TextBox)FindControl(tbAssistantTypeId);
		tbAssistantType.Text = th.Parameters[TeamviewerHelper.columnAssistantType];
	}
	private void BindRemotelyanywhereValue(RemoteClientHelper rch, string controlIdInfix)
	{
		RemotelyanywhereHelper rh = (RemotelyanywhereHelper)rch;
		string controlIdPrefix = "TextBox";

		string tbIpId = controlIdPrefix + controlIdInfix + "Ip";
		TextBox tbIp = (TextBox)FindControl(tbIpId);
		tbIp.Text = rh.Parameters[MstscHelper.columnIp];

		string tbPortId = controlIdPrefix + controlIdInfix + "Port";
		TextBox tbPort = (TextBox)FindControl(tbPortId);
		tbPort.Text = rh.Parameters[RadminHelper.columnPort];

		string tbUsernameId = controlIdPrefix + controlIdInfix + "Username";
		TextBox tbUsername = (TextBox)FindControl(tbUsernameId);
		tbUsername.Text = rh.Parameters[RadminHelper.columnUsername];

		string tbPasswordId = controlIdPrefix + controlIdInfix + "Password";
		TextBox tbPassword = (TextBox)FindControl(tbPasswordId);
		tbPassword.Text = rh.Parameters[RadminHelper.columnPassword];
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
			if (Session["cafe_information_" + id] == null)
			{
				Session["cafe_information_" + id] = CafeInformationHelper.GetCafeInformationHelper(id.ToString());
			}
			CafeInformationHelper cih = (CafeInformationHelper)Session["cafe_information_" + id.ToString()];
			string remoteClientTableName = cih.Parameters[serverColumnName];
			RadioButtonList rbl = GetRadioButtonList(serverType);
			rbl.SelectedValue = remoteClientTableName;
		}
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
		if (Session["cafe_information_" + id] == null)
		{
			Session["cafe_information_" + id] = CafeInformationHelper.GetCafeInformationHelper(id.ToString());
		}
		CafeInformationHelper cih = (CafeInformationHelper)Session["cafe_information_" + id.ToString()];

		this.TextBoxCafeId.Text = cih.Parameters[CafeInformationHelper.columnId];
		this.TextBoxCafeName.Text = cih.Parameters[CafeInformationHelper.columnName];
		this.TextBoxTelephone.Text = cih.Parameters[CafeInformationHelper.columnTelephone];
		this.TextBoxContact.Text = cih.Parameters[CafeInformationHelper.columnContact];
		this.TextBoxMobile.Text = cih.Parameters[CafeInformationHelper.columnMobile];
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

	protected void RadioButtonListMainServerRemoteType_SelectedIndexChanged(object sender, EventArgs e)
	{
		RadioButtonList rbl = (RadioButtonList)sender;
		string remoteType = rbl.SelectedValue;
	}
}
