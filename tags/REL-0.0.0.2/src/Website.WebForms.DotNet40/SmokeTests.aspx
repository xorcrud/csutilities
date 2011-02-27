<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="SmokeTests.aspx.cs" Inherits="Website.WebForms.DotNet40.SmokeTests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Smoke Tests
    </h2>

    <asp:Panel runat="server">
        <h3>Pipeline Execution</h3>
        <asp:Button runat="server" Text="Execute" OnClick="Pipeline_Execute" />
    </asp:Panel>
</asp:Content>
