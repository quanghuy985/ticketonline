<%@ Control Language="C#" AutoEventWireup="true" CodeFile="listcar.ascx.cs" Inherits="uwc_listcar" %>
<asp:Repeater ID="rpttiket" runat="server">
    <HeaderTemplate>
    </HeaderTemplate>
    <ItemTemplate>
        <div style="float: left; width: 20%; ">
       <table style="width: 10%; height: 141px;">
            <tr>
                <td align="center" style="height: 98px">
                    <img alt="hhhhjjjj"  src="images/<%#DataBinder.Eval(Container.DataItem, "ticketStatus")%>.jpg" /></td>
            </tr>
            <tr>
                <td>
                    Ghế số :<%# DataBinder.Eval(Container.DataItem, "seatNo")%></td>
            </tr>
            <tr>
                <td>
                   <asp:LinkButton ID="LinkButton1" Text="Đặt vé" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ticketID")%>' OnCommand="addCart" runat="server" />
                </td>
            </tr>       
        </table>
            <div>&nbsp;</div>
        </div>
        
    </ItemTemplate>
    <FooterTemplate>
       
    </FooterTemplate>
</asp:Repeater>