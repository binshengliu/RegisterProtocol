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
	}
	protected void RadioButtonListRemoteType_SelectedIndexChanged(object sender, EventArgs e)
	{
		string selectedValue = this.RadioButtonListRemoteType.SelectedValue;
		switch (selectedValue)
		{
			case "radmin":
				AddRadminControls(this.PlaceHolderMainServer);
				break;
			case "mstsc":
				AddMstscControls(this.PlaceHolderMainServer);
				break;
			case "ttvnc":
				AddTtvncControls(this.PlaceHolderMainServer);
				break;
			case "teamviewer":
				AddTeamviewerControls(this.PlaceHolderMainServer);
				break;
			case "remotelyanywhere":
				break;
		}
	}

	private void AddRadminControls(PlaceHolder ph)
	{
		Label ipLabel = new Label();
		ipLabel.Text = "IP：";
		TextBox ipTextBox = new TextBox();
		ph.Controls.Add(ipLabel);
		ph.Controls.Add(ipTextBox);

		Label portLabel = new Label();
		portLabel.Text = "端口：";
		TextBox portTextBox = new TextBox();
		portTextBox.TextMode = TextBoxMode.Password;
		ph.Controls.Add(portLabel);
		ph.Controls.Add(portTextBox);

		Label usernameLabel = new Label();
		usernameLabel.Text = "用户名：";
		TextBox usernameTextBox = new TextBox();
		ph.Controls.Add(usernameLabel);
		ph.Controls.Add(usernameTextBox);

		Label passwordLabel = new Label();
		passwordLabel.Text = "密码：";
		TextBox passwordTextBox = new TextBox();
		passwordTextBox.TextMode = TextBoxMode.Password;
		ph.Controls.Add(passwordLabel);
		ph.Controls.Add(passwordTextBox);
	}

	private void AddMstscControls(PlaceHolder ph)
	{
		Label ipLabel = new Label();
		ipLabel.Text = "IP：";
		TextBox ipTextBox = new TextBox();
		ph.Controls.Add(ipLabel);
		ph.Controls.Add(ipTextBox);

		Label portLabel = new Label();
		portLabel.Text = "端口：";
		TextBox portTextBox = new TextBox();
		portTextBox.TextMode = TextBoxMode.Password;
		ph.Controls.Add(portLabel);
		ph.Controls.Add(portTextBox);
	}

	private void AddTtvncControls(PlaceHolder ph)
	{
		Label codeLabel = new Label();
		codeLabel.Text = "验证码：";
		TextBox codeTextBox = new TextBox();
		ph.Controls.Add(codeLabel);
		ph.Controls.Add(codeTextBox);

		Label assistantModeLabel = new Label();
		assistantModeLabel.Text = "辅助模式：";
		TextBox assistantModeTextBox = new TextBox();
		ph.Controls.Add(assistantModeLabel);
		ph.Controls.Add(assistantModeTextBox);
	}

	private void AddTeamviewerControls(PlaceHolder ph)
	{
		Label idLabel = new Label();
		idLabel.Text = "ID：";
		TextBox idTextBox = new TextBox();
		ph.Controls.Add(idLabel);
		ph.Controls.Add(idTextBox);

		Label passwordLabel = new Label();
		passwordLabel.Text = "密码：";
		TextBox passwordTextBox = new TextBox();
		passwordTextBox.TextMode = TextBoxMode.Password;
		ph.Controls.Add(passwordLabel);
		ph.Controls.Add(passwordTextBox);

		Label assistantTypeLabel = new Label();
		assistantTypeLabel.Text = "辅助类型：";
		assistantTypeLabel.Visible = false;
		TextBox assistantTypeTextBox = new TextBox();
		assistantTypeTextBox.Visible = false;
		ph.Controls.Add(assistantTypeLabel);
		ph.Controls.Add(assistantTypeTextBox);
	}
}
