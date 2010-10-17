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
		if (!this.IsPostBack)
		{
		}
		string id = Request["id"];
		if (id != null && id.Length > 0)
		{
			FillCafeInformationControls(id);
			DisplayPageControls(id);
		}
	}

	private void DisplayPageControls(string id)
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
			switch (remoteClientTableName)
			{
				case "radmin":
					DisplayRadminControls(serverType);
					break;
				case "mstsc":
					DisplayMstscControls(serverType);
					break;
				case "ttvnc":
					DisplayTtvncControls(serverType);
					break;
				case "teamviewer":
					DisplayTeamviewerControls(serverType);
					break;
				case "remotelyanywhere":
					DisplayRemotelyanywhereControls(serverType);
					break;
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

	private void DisplayControls(string serverType, List<string> controlIdSuffices)
	{
		string controlIdInfix = "MainServer";
		switch (serverType)
		{
			case "main_server":
				break;
			case "secondary_server":
				controlIdInfix = "SecondaryServer";
				break;
			case "cash_register_server":
				controlIdInfix = "CashRegisterServer";
				break;
			case "movie_server":
				controlIdInfix = "MovieServer";
				break;
			case "router_server":
				controlIdInfix = "RouterServer";
				break;
		}
		List<string> controlIdPrefices = new List<string>()
		{
			"Label", "TextBox",
		};
		foreach (string p in controlIdPrefices)
		{
			foreach (string s in controlIdSuffices)
			{
				string controlId = p + controlIdInfix + s;
				FindControl(controlId).Visible = true;
			}
		}
	}

	private void DisplayRadminControls(string serverType)
	{
		List<string> controlIdSuffices = new List<string>()
		{
			"Ip", "Port", "Username", "Password",
		};
		DisplayControls(serverType, controlIdSuffices);
	}

	private void DisplayMstscControls(string serverType)
	{
		List<string> controlIdSuffices = new List<string>()
		{
			"Ip", "Port", "Username", "Password",
		};
		DisplayControls(serverType, controlIdSuffices);
	}

	private void DisplayTtvncControls(string serverType)
	{
		List<string> controlIdSuffices = new List<string>()
		{
			"AssistantMode", "Code",
		};
		DisplayControls(serverType, controlIdSuffices);
	}

	private void DisplayTeamviewerControls(string serverType)
	{
		List<string> controlIdSuffices = new List<string>()
		{
			"Password",
			"Id", "AssistantType",
		};
		DisplayControls(serverType, controlIdSuffices);
	}

	private void DisplayRemotelyanywhereControls(string serverType)
	{
		List<string> controlIdSuffices = new List<string>()
		{
			"Ip", "Port", "Username", "Password",
		};
		DisplayControls(serverType, controlIdSuffices);
	}

	protected void RadioButtonListMainServerRemoteType_SelectedIndexChanged(object sender, EventArgs e)
	{
		RadioButtonList rbl = (RadioButtonList)sender;
		string remoteType = rbl.SelectedValue;
	}

	protected void RadioButtonListSecondaryServerRemoteType_SelectedIndexChanged(object sender, EventArgs e)
	{
		string remoteType = this.RadioButtonListSecondaryServerRemoteType.SelectedValue;
	}

	protected void RadioButtonListCashRegisterServerRemoteType_SelectedIndexChanged(object sender, EventArgs e)
	{
		string remoteType = this.RadioButtonListCashRegisterServerRemoteType.SelectedValue;
	}

	protected void RadioButtonListMovieServerRemoteType_SelectedIndexChanged(object sender, EventArgs e)
	{
		string remoteType = this.RadioButtonListMovieServerRemoteType.SelectedValue;
	}

	protected void RadioButtonListRouterServerRemoteType_SelectedIndexChanged(object sender, EventArgs e)
	{
		string remoteType = this.RadioButtonListRouterServerRemoteType.SelectedValue;
	}
}
