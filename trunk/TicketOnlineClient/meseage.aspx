<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="meseage.aspx.cs" Inherits="meseage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntContent" Runat="Server">
<div>
    <asp:Label ID="Label1" runat="server" Text="Label"  
        ForeColor="#FF0066"></asp:Label>
    <br />
    <asp:Label ID="lbClick" runat="server" Text="Click "></asp:Label>
    <asp:LinkButton ID="lbtSolution" runat="server" PostBackUrl="~/Login.aspx">Here</asp:LinkButton>
    &nbsp;
    <asp:Label ID="lbSolution" runat="server" Text="để đăng nhập"></asp:Label>
    </div>
</asp:Content>

