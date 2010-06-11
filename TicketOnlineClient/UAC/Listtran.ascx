<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Listtran.ascx.cs" Inherits="UAC_Listtran" %>
<asp:Repeater ID="rpttran" runat="server">
    <HeaderTemplate>
    </HeaderTemplate>
    <ItemTemplate>
        <div style="float: left; width: 22%; ">
       <table style="width: 20%; height: 141px;">
            <tr>
                <td align="center" style="height: 98px">
                    <img alt="hhhhjjjj"  src="Images/r.jpg" height=100px width=100px /></td>
            </tr>
            <tr style="width:200px">
                <td>
                    Nơi Đi:<h3><%# DataBinder.Eval(Container.DataItem, "transPlaceStart")%></h3></td>
                    
            </tr>
            <tr><td> Nơi Đến:<h3><%# DataBinder.Eval(Container.DataItem, "transPlaceDestination")%></h3></td></tr>
            <tr>
                <td>
                   <asp:LinkButton ID="LinkButton1" Text="Đặt vé" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "transID")%>' OnCommand="datve" runat="server" />
                </td>
            </tr>       
        </table>
            <div>&nbsp;</div>
        </div>
        
    </ItemTemplate>
    <FooterTemplate>
       
    </FooterTemplate>
</asp:Repeater>