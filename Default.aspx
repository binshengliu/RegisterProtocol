<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="css/cuscosky.css" Type="text/css">
    <title>远程管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<asp:GridView ID="GridViewCafeInformation" runat="server" AllowPaging="True" AllowSorting="True" 
		    AutoGenerateColumns="False">
	        		<Columns>
			<asp:BoundField DataField="id" HeaderText="编号" ReadOnly="True" 
				SortExpression="id" />
			<asp:BoundField DataField="ciName" HeaderText="网吧名称" SortExpression="name" />
			<asp:BoundField DataField="ciTelephone" HeaderText="吧台电话" SortExpression="tel" />
			<asp:BoundField DataField="ciContact" HeaderText="负责人" 
				SortExpression="ciContact" />
			<asp:BoundField DataField="ciMobile" HeaderText="手机" 
				SortExpression="ciMobile" />
				
			<asp:TemplateField HeaderText="主服务器">
			<ItemTemplate>
                        <a href="<%#CreateLink(Eval("id"), "main_server")%>">远程连接</a>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
			<asp:TemplateField HeaderText="副服务器">
			<ItemTemplate>
                        <a href="<%#CreateLink(Eval("id"), "secondary_server")%>">远程连接</a>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
			<asp:TemplateField HeaderText="收银机">
			<ItemTemplate>
                        <a href="<%#CreateLink(Eval("id"), "cash_register_server")%>">远程连接</a>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
			<asp:TemplateField HeaderText="电影服务器">
			<ItemTemplate>
                        <a href="<%#CreateLink(Eval("id"), "movie_server")%>">远程连接</a>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
			<asp:TemplateField HeaderText="路由器">
			<ItemTemplate>
                        <a href="<%#CreateLink(Eval("id"), "router_server")%>" target="_blank">远程连接</a>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
			<asp:TemplateField HeaderText="操作" ShowHeader="False">
				<ItemTemplate>
					<asp:LinkButton ID="LinkButtonEdit" runat="server" CausesValidation="False" 
						Text="编辑" onclick="LinkButtonEdit_Click" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
					<asp:LinkButton ID="LinkButtonDelete" runat="server" CausesValidation="False" 
						Text="删除" CommandArgument='<%# Eval("id") %>' onclick="LinkButtonDelete_Click" 
						onclientclick="return confirm('您确认删除该记录吗?');"></asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	    </asp:GridView>
	    <asp:SqlDataSource ID="SqlDataSourceCafeInformation" runat="server" 
		    ConnectionString="<%$ ConnectionStrings:RemoteControlConnectionString %>" 
		    SelectCommand="SELECT * FROM [cafe_information]">
	    </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
