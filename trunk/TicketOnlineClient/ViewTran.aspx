<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewTran.aspx.cs" Inherits="ViewTran" Title="Untitled Page" %>

<%@ Register src="UAC/Listtran.ascx" tagname="Listtran" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntContent" Runat="Server">
    <uc1:Listtran ID="Listtran1" runat="server" />
</asp:Content>

