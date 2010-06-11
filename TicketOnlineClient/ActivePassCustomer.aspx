<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ActivePassCustomer.aspx.cs" Inherits="ActivePassCustomer" %>

<asp:Content ContentPlaceHolderID="cntContent" runat="server" ID="cnt">
    <div>
    <table>
    <tr>
    <td>
    Cám ơn :
    </td>
    <td>
        <asp:Label ID="LbCusID" runat="server" Text=""></asp:Label>
        </td>
        <td>
        ! Bạn vừa kích hoạt tài khoản thành công
        </td>
        </tr>
        </table>
    </div>
 
</asp:Content>