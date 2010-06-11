<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="recoveryPassword.aspx.cs" Inherits="recoveryPassword" %>

<asp:Content ContentPlaceHolderID="cntContent" runat="server">
<div>
<table style="width:100%">
<tr>
<td style="width:20%">
<asp:Label ID="lbUser" runat="server" Text="Tên đăng nhập :">
</asp:Label>
</td>
<td style="width:30%">
<asp:TextBox ID="txtUser" runat="server" Width="100%"></asp:TextBox>
</td>
<td style="width:40%">
</td>
</tr>
<tr>
<td style="width:20%">
</td>
<td style="width:30%">
<asp:Button ID="btSendPass" runat="server" Text="Khôi phục pass" 
        onclick="btSendPass_Click" />
</td>
<td>
<asp:Label ID="lbMessage" ForeColor="Blue" runat="server"></asp:Label>
</td>
</tr>
</table>
</div>
</asp:Content>
