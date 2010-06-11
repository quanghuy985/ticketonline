<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Default3" %>
<%@ Register Src="~/UAC/listNews.ascx" TagName="ListNews" TagPrefix="uc" %>
<asp:content ContentPlaceHolderID="cntContent" ID="cnt" runat="server">
    <uc:ListNews ID="ListNews1" runat="server" />
</asp:content>