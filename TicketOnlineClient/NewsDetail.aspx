<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewsDetail.aspx.cs" Inherits="NewsDetail" %>
<%@ Register Src="~/UAC/viewNewsDetail.ascx" TagName="ListNewsDetail" TagPrefix="uc" %>
<%@ Register Src="~/UAC/ListNewsFooter.ascx" TagName="ListNewsFooter" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="cntContent" ID="cnt" runat="server">
<div>
<uc:ListNewsDetail ID="lbHome" runat="server"></uc:ListNewsDetail>
<uc1:ListNewsFooter ID="ucNewsFooter" runat="server" />
</div>

</asp:Content>
