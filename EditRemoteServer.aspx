<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditRemoteServer.aspx.cs" Inherits="EditRemoteServer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
				<asp:PlaceHolder ID="PlaceHolderMainServer" runat="server"></asp:PlaceHolder>
				<asp:RadioButtonList ID="RadioButtonListRemoteType" runat="server" 
					onselectedindexchanged="RadioButtonListRemoteType_SelectedIndexChanged" 
					RepeatDirection="Horizontal">
					<asp:ListItem Value="0">Radmin</asp:ListItem>
					<asp:ListItem Value="1">3389</asp:ListItem>
					<asp:ListItem Value="2">ttvnc</asp:ListItem>
					<asp:ListItem Value="3">TeamViewer</asp:ListItem>
					<asp:ListItem Value="4">RemotelyAnywhere</asp:ListItem>
				</asp:RadioButtonList>
			</td>
		</tr>
		<tr>
			<td class="style1">
				次服务器</td>
			<td class="style2">
				IP：<asp:TextBox ID="TextBoxIP0" runat="server"></asp:TextBox>
&nbsp;&nbsp; 端口：<asp:TextBox ID="TextBoxPort0" runat="server"></asp:TextBox>
			&nbsp;&nbsp; 密码：<asp:TextBox ID="TextBoxPassword0" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td class="style1">
				收银机</td>
			<td class="style2">
				IP：<asp:TextBox ID="TextBoxIP1" runat="server"></asp:TextBox>
&nbsp;&nbsp; 端口：<asp:TextBox ID="TextBoxPort1" runat="server"></asp:TextBox>
			&nbsp;&nbsp; 密码：<asp:TextBox ID="TextBoxPassword1" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td class="style1">
				电影服务器</td>
			<td class="style2">
				IP：<asp:TextBox ID="TextBoxIP2" runat="server"></asp:TextBox>
&nbsp;&nbsp; 端口：<asp:TextBox ID="TextBoxPort2" runat="server"></asp:TextBox>
			&nbsp;&nbsp; 密码：<asp:TextBox ID="TextBoxPassword2" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td class="style1">
				路由器</td>
			<td class="style2">
				IP：<asp:TextBox ID="TextBoxIP3" runat="server"></asp:TextBox>
&nbsp;&nbsp; 端口：<asp:TextBox ID="TextBoxPort3" runat="server"></asp:TextBox>
			&nbsp;&nbsp; 密码：<asp:TextBox ID="TextBoxPassword3" runat="server"></asp:TextBox>
			</td>
		</tr>
	    </table>
    
    </div>
    </form>
</body>
</html>
