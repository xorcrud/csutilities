<%@ Page Language="C#" %>
<%@ Import Namespace="CSUtilities" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Example</title>
    <script runat="server">
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            DataBind();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater runat="server" DataSource="<%# MetadataDefinitions.Address.Properties.All %>">
            <HeaderTemplate>
                <h1><%# MetadataDefinitions.Address.EntityName %> properties</h1>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                    <li><%# Container.DataItem.ToString() %></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
