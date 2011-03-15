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

    <asp:Panel runat="server">
        <h3>Full Text Search</h3>
        <asp:Button runat="server" Text="Execute" OnClick="FullTextSearch_Execute" />
    </asp:Panel>

    <asp:Panel runat="server">
        <h3>Query that throws</h3>
        <asp:Button runat="server" Text="Execute" OnClick="QueryThatThrows_Execute" />
        <asp:CheckBox runat="server" ID="QueryThatThrowsCatchException" Text="Catch exception?" />
    </asp:Panel>
</asp:Content>
