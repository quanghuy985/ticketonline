<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Viewticketcarrt.aspx.cs" Inherits="Default4" %>

<asp:Content ContentPlaceHolderID=cntContent runat=server>
    <asp:Label ID="Label1" runat="server" Text="" Font-Size="Large" 
        ForeColor="#CC0000"></asp:Label>
    <asp:Repeater runat="server" ID="rpttikets">
        <HeaderTemplate>
            <table id="tb" border="1" cellpadding="2" width="100%" align="center">
                <tr >
                <th></th>
                <th></th>
                <th style="color:Black">
                    List vé đã đặt mua
                </th></tr>
                <tr align="center">
                    <th style="color: Black">
                        TiketID</th>
                    <th style="color: Black">
                        Gia</th>
                    <th style="color: Black">
                        Noi di</th>
                    <th style="color: Black">
                        Noi den</th>
                        <th style="color: Black">
                            Thao tác</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="color: Black">
                    <%# DataBinder.Eval(Container.DataItem, "tiketids")%></td>
                <td style="color: Black">
                    <%# DataBinder.Eval(Container.DataItem, "tranfees")%></td>
                <td style="color: Black">
                    <%# DataBinder.Eval(Container.DataItem, "tranplacestarts")%></td>
                <td style="color: Black">
                    <%# DataBinder.Eval(Container.DataItem, "trandestination")%></td>
                    <td style="color:Black">
                    <asp:Button ID="btnDelete" runat="server" Text="Xóa" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "tiketids")%>' OnCommand="deleteCart" />
                    </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
 <table align="right" cellpadding="3" style="color: Black">
        <tr>
            <td>Tổng số tiền (chưa có VAT): </td>
            <th align="right"><asp:Label ID="lblSum" runat="server" /></th>
        </tr>
        
        <tr>
            <td><asp:Button ID="btnCheckOut" runat="server" Text="Thanh toán" OnClick="btnCheckOut_Click" /></td>
        </tr>
    </table>
</asp:Content>
