<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="trandetail.aspx.cs" Inherits="trandetail" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntContent" Runat="Server">
    <table style="width: 100%; height: 161px;">
        <tr>
            <td style="width: 138px">
                <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="Chuyến"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="lavbledi"></asp:Label>
                --&gt;&gt;<asp:Label ID="Label5" runat="server" Font-Size="Large" Text="lavblden"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 138px">
                <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="Giờ Khởi Hành"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="154px">
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 138px">
                <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="Ngày Xuất Phát"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="157px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 138px">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    Text="Chọn Vé" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

