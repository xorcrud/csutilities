<%@ Page Language="C#" %>
<%@ Import Namespace="Microsoft.CommerceServer.Runtime" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 
<html>
  <head>
    <title>Commerce Server Status Monitor</title>
  </head>
  <body>
	
    <dl>
        <dt>CommerceContext</dt>
        <dd><%= CommerceContext.Current != null %></dd>
        
        <% if (CommerceContext.Current != null) { %>
        
        <dt>Authentication Module</dt>
        <dd><%=CommerceContext.Current.AuthenticationInfo != null%></dd>
        
        <dt>CatalogSystem</dt>
        <dd><%=CommerceContext.Current.CatalogSystem != null%></dd>        
        
        <dt>Inventory System</dt>
        <dd><%=CommerceContext.Current.CatalogSystem != null && CommerceContext.Current.CatalogSystem.InventorySystemExists%></dd>
        
        <dt>OrderSystem</dt>
        <dd><%=CommerceContext.Current.OrderSystem != null%></dd>
        
        <dt>ProfileSystem</dt>
        <dd><%=CommerceContext.Current.ProfileSystem != null%></dd>        
        
        <dt>TargetingSystem</dt>
        <dd><%=CommerceContext.Current.TargetingSystem != null%></dd>                
        
        <dt>Is Debug</dt>
        <dd><%=CommerceContext.Current.DebugContext.IsDebugMode%></dd>                        
        
        <% }%>
    </dl>
  </body>
</html>
