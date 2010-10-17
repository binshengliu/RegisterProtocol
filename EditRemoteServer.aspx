<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditRemoteServer.aspx.cs" Inherits="EditRemoteServer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑</title>
	<style type="text/css">
		.style1
		{
			width: 81px;
		}
		.style2
		{
			width: 660px;
		}
		.style3
		{
			width: 118px;
		}
		</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    网吧信息：
    	    <br />
	    <table style="width:100%;">
		    <tr>
			    <td class="style3">
				    编号：</td>
			    <td>
				    <asp:TextBox ID="TextBoxCafeId" runat="server"></asp:TextBox>
			    </td>
		    </tr>
		    <tr>
			    <td class="style3">
				    网吧名称：</td>
			    <td>
				    <asp:TextBox ID="TextBoxCafeName" runat="server"></asp:TextBox>
			    </td>
		    </tr>
		    <tr>
			    <td class="style3">
				    吧台电话：</td>
			    <td>
				    <asp:TextBox ID="TextBoxTelephone" runat="server"></asp:TextBox>
			    </td>
		    </tr>
		    <tr>
			    <td class="style3">
				    联系人：</td>
			    <td>
				    <asp:TextBox ID="TextBoxContact" runat="server"></asp:TextBox>
			    </td>
		    </tr>
		    <tr>
			    <td class="style3">
				    手机号码：</td>
			    <td>
				    <asp:TextBox ID="TextBoxMobile" runat="server"></asp:TextBox>
			    </td>
		    </tr>
	    </table>
    
    
    	<table style="width:100%;" align="center">
		<tr>
			<td class="style1">
				主服务器</td>
			<td class="style2">
				<asp:Panel ID="PanelMainServer" runat="server">
					<asp:Label ID="LabelMainServerIp" runat="server" Text="IP：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMainServerIp" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelMainServerPort" runat="server" Text="端口：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMainServerPort" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelMainServerUsername" runat="server" Text="用户名：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMainServerUsername" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelMainServerId" runat="server" Text="ID：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMainServerId" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelMainServerPassword" runat="server" Text="密码：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMainServerPassword" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelMainServerAssistantType" runat="server" Text="辅助类型：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMainServerAssistantType" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelMainServerCode" runat="server" Text="验证码：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMainServerCode" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelMainServerAssistantMode" runat="server" Text="辅助模式：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMainServerAssistantMode" runat="server" Visible="False"></asp:TextBox>
					<asp:RadioButtonList ID="RadioButtonListMainServerRemoteType" runat="server" 
						AutoPostBack="True" 
						RepeatDirection="Horizontal">
						<asp:ListItem Value="radmin">Radmin</asp:ListItem>
						<asp:ListItem Value="mstsc">3389</asp:ListItem>
						<asp:ListItem Value="ttvnc">ttvnc</asp:ListItem>
						<asp:ListItem Value="teamviewer">TeamViewer</asp:ListItem>
						<asp:ListItem Value="remotelyanywhere">RemotelyAnywhere</asp:ListItem>
					</asp:RadioButtonList>
				</asp:Panel>
			</td>
		</tr>
		<tr>
			<td class="style1">
				次服务器</td>
			<td class="style2">
				<asp:Panel ID="PanelSecondaryServer" runat="server">
					<asp:Label ID="LabelSecondaryServerIp" runat="server" Text="IP：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxSecondaryServerIp" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelSecondaryServerPort" runat="server" Text="端口：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxSecondaryServerPort" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelSecondaryServerUsername" runat="server" Text="用户名：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxSecondaryServerUsername" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelSecondaryServerId" runat="server" Text="ID：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxSecondaryServerId" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelSecondaryServerPassword" runat="server" Text="密码：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxSecondaryServerPassword" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelSecondaryServerAssistantType" runat="server" Text="辅助类型：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxSecondaryServerAssistantType" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelSecondaryServerCode" runat="server" Text="验证码：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxSecondaryServerCode" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelSecondaryServerAssistantMode" runat="server" Text="辅助模式：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxSecondaryServerAssistantMode" runat="server" Visible="False"></asp:TextBox>
					<asp:RadioButtonList ID="RadioButtonListSecondaryServerRemoteType" 
						runat="server" AutoPostBack="True" 
						RepeatDirection="Horizontal">
						<asp:ListItem Value="radmin">Radmin</asp:ListItem>
						<asp:ListItem Value="mstsc">3389</asp:ListItem>
						<asp:ListItem Value="ttvnc">ttvnc</asp:ListItem>
						<asp:ListItem Value="teamviewer">TeamViewer</asp:ListItem>
						<asp:ListItem Value="remotelyanywhere">RemotelyAnywhere</asp:ListItem>
					</asp:RadioButtonList>
				</asp:Panel>
			</td>
		</tr>
		<tr>
			<td class="style1">
				收银机</td>
			<td class="style2">
				<asp:Panel ID="PanelCashRegisterServer" runat="server">
					<asp:Label ID="LabelCashRegisterServerIp" runat="server" Text="IP：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxCashRegisterServerIp" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelCashRegisterServerPort" runat="server" Text="端口：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxCashRegisterServerPort" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelCashRegisterServerUsername" runat="server" Text="用户名：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxCashRegisterServerUsername" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelCashRegisterServerId" runat="server" Text="ID：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxCashRegisterServerId" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelCashRegisterServerPassword" runat="server" Text="密码：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxCashRegisterServerPassword" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelCashRegisterServerAssistantType" runat="server" Text="辅助类型：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxCashRegisterServerAssistantType" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelCashRegisterServerCode" runat="server" Text="验证码：" Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxCashRegisterServerCode" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelCashRegisterServerAssistantMode" runat="server" Text="辅助模式：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxCashRegisterServerAssistantMode" runat="server" Visible="False"></asp:TextBox>
					<asp:RadioButtonList ID="RadioButtonListCashRegisterServerRemoteType" 
						runat="server" AutoPostBack="True" 
						RepeatDirection="Horizontal">
						<asp:ListItem Value="radmin">Radmin</asp:ListItem>
						<asp:ListItem Value="mstsc">3389</asp:ListItem>
						<asp:ListItem Value="ttvnc">ttvnc</asp:ListItem>
						<asp:ListItem Value="teamviewer">TeamViewer</asp:ListItem>
						<asp:ListItem Value="remotelyanywhere">RemotelyAnywhere</asp:ListItem>
					</asp:RadioButtonList>
				</asp:Panel>
			</td>
		</tr>
		<tr>
			<td class="style1">
				电影服务器</td>
			<td class="style2">
				<asp:Panel ID="PanelMovieServer" runat="server">
					<asp:Label ID="LabelMovieServerIp" runat="server" Text="IP：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMovieServerIp" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelMovieServerPort" runat="server" Text="端口：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMovieServerPort" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelMovieServerUsername" runat="server" Text="用户名：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMovieServerUsername" runat="server" 
						Visible="False"></asp:TextBox>
					<asp:Label ID="LabelMovieServerId" runat="server" Text="ID：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMovieServerId" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelMovieServerPassword" runat="server" Text="密码：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMovieServerPassword" runat="server" 
						Visible="False"></asp:TextBox>
					<asp:Label ID="LabelMovieServerAssistantType" runat="server" Text="辅助类型：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMovieServerAssistantType" runat="server" 
						Visible="False"></asp:TextBox>
					<asp:Label ID="LabelMovieServerCode" runat="server" Text="验证码：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMovieServerCode" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelMovieServerAssistantMode" runat="server" Text="辅助模式：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxMovieServerAssistantMode" runat="server" 
						Visible="False"></asp:TextBox>
					<asp:RadioButtonList ID="RadioButtonListMovieServerRemoteType" runat="server" 
						AutoPostBack="True" 
						RepeatDirection="Horizontal">
						<asp:ListItem Value="radmin">Radmin</asp:ListItem>
						<asp:ListItem Value="mstsc">3389</asp:ListItem>
						<asp:ListItem Value="ttvnc">ttvnc</asp:ListItem>
						<asp:ListItem Value="teamviewer">TeamViewer</asp:ListItem>
						<asp:ListItem Value="remotelyanywhere">RemotelyAnywhere</asp:ListItem>
					</asp:RadioButtonList>
				</asp:Panel>
			</td>
		</tr>
		<tr>
			<td class="style1">
				路由器</td>
			<td class="style2">
				<asp:Panel ID="PanelRouterServer" runat="server">
					<asp:Label ID="LabelRouterServerIp" runat="server" Text="IP：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxRouterServerIp" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelRouterServerPort" runat="server" Text="端口：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxRouterServerPort" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelRouterServerUsername" runat="server" Text="用户名：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxRouterServerUsername" runat="server" 
						Visible="False"></asp:TextBox>
					<asp:Label ID="LabelRouterServerId" runat="server" Text="ID：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxRouterServerId" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelRouterServerPassword" runat="server" Text="密码：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxRouterServerPassword" runat="server" 
						Visible="False"></asp:TextBox>
					<asp:Label ID="LabelRouterServerAssistantType" runat="server" Text="辅助类型：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxRouterServerAssistantType" runat="server" 
						Visible="False"></asp:TextBox>
					<asp:Label ID="LabelRouterServerCode" runat="server" Text="验证码：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxRouterServerCode" runat="server" Visible="False"></asp:TextBox>
					<asp:Label ID="LabelRouterServerAssistantMode" runat="server" Text="辅助模式：" 
						Visible="False"></asp:Label>
					<asp:TextBox ID="TextBoxRouterServerAssistantMode" runat="server" 
						Visible="False"></asp:TextBox>
					<asp:RadioButtonList ID="RadioButtonListRouterServerRemoteType" runat="server" 
						AutoPostBack="True" 
						RepeatDirection="Horizontal">
						<asp:ListItem Value="radmin">Radmin</asp:ListItem>
						<asp:ListItem Value="mstsc">3389</asp:ListItem>
						<asp:ListItem Value="ttvnc">ttvnc</asp:ListItem>
						<asp:ListItem Value="teamviewer">TeamViewer</asp:ListItem>
						<asp:ListItem Value="remotelyanywhere">RemotelyAnywhere</asp:ListItem>
					</asp:RadioButtonList>
				</asp:Panel>
			</td>
		</tr>
	    </table>
    
    </div>
    </form>
</body>
</html>
