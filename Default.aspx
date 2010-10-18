<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>远程管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<asp:GridView ID="GridViewCafeInformation" runat="server" AllowPaging="True" AllowSorting="True" 
		    AutoGenerateColumns="False" DataKeyNames="cafe_id" DataSourceID="SqlDataSourceCafeInformation" 
		    CellPadding="4" ForeColor="#333333" GridLines="None">
		<RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
		<Columns>
			<asp:BoundField DataField="cafe_id" HeaderText="编号" ReadOnly="True" 
				SortExpression="cafe_id" />
			<asp:BoundField DataField="name" HeaderText="网吧名称" SortExpression="name" />
			<asp:BoundField DataField="telephone" HeaderText="吧台电话" SortExpression="tel" />
			<asp:BoundField DataField="contact" HeaderText="负责人" 
				SortExpression="contact" />
			<asp:BoundField DataField="mobile" HeaderText="手机" 
				SortExpression="mobile" />
				
			<asp:TemplateField HeaderText="主服务器">
			<ItemTemplate>
                        <a href="<%#CreateLink(Eval("cafe_id"), "main_server")%>">远程连接</a>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
			<asp:TemplateField HeaderText="副服务器">
			<ItemTemplate>
                        <a href="<%#CreateLink(Eval("cafe_id"), "secondary_server")%>">远程连接</a>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
			<asp:TemplateField HeaderText="收银机">
			<ItemTemplate>
                        <a href="<%#CreateLink(Eval("cafe_id"), "cash_register_server")%>">远程连接</a>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
			<asp:TemplateField HeaderText="电影服务器">
			<ItemTemplate>
                        <a href="<%#CreateLink(Eval("cafe_id"), "movie_server")%>">远程连接</a>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
			<asp:TemplateField HeaderText="路由器">
			<ItemTemplate>
                        <a href="<%#CreateLink(Eval("cafe_id"), "router_server")%>" target="_blank">远程连接</a>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
			<asp:TemplateField HeaderText="操作" ShowHeader="False">
				<ItemTemplate>
					<asp:LinkButton ID="LinkButtonEdit" runat="server" CausesValidation="False" 
						Text="编辑" onclick="LinkButtonEdit_Click" CommandArgument='<%# Eval("cafe_id") %>'></asp:LinkButton>
					<asp:LinkButton ID="LinkButtonDelete" runat="server" CausesValidation="False" 
						Text="删除" CommandArgument='<%# Eval("cafe_id") %>' onclick="LinkButtonDelete_Click" 
						onclientclick="return confirm('您确认删除该记录吗?');"></asp:LinkButton>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
		<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
		<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
		<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
		<EditRowStyle BackColor="#999999" />
		<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
	    </asp:GridView>
	    <asp:SqlDataSource ID="SqlDataSourceCafeInformation" runat="server" 
		    ConnectionString="<%$ ConnectionStrings:RemoteControlConnectionString %>" 
		    SelectCommand="SELECT * FROM [cafe_information]">
	    </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
