<%@ Control Language="C#" AutoEventWireup="true" CodeFile="listticket.ascx.cs" Inherits="uwc_listcar" %>
<asp:Panel ID="pnlResults" runat="server" >
<asp:Repeater ID="rpttiket" runat="server" onitemdatabound="rpttiket_ItemDataBound">
    <HeaderTemplate>
    <table>
    <tr>
    <td style="width:100%" align="center">
    Xin Mời chọn ghế ngồi! Những ghế màu vàng là những ghế còn trống.
    </td>
    </tr>
    </table>
    </HeaderTemplate>
    <ItemTemplate>
        <div style="float: left; width: 22%; ">
       <table style="width: 100%; height: 141px;">
            <tr>
                <td align="center" style="height: 98px">
                    <img alt="hhhhjjjj" width="100px" height="100px"  src="images/<%#DataBinder.Eval(Container.DataItem, "ticketStatus")%>.jpg" /></td>
            </tr>
            <tr>
                <td>
                    Ghế số :<%#  DataBinder.Eval(Container.DataItem, "seatNo")%></td>
            </tr>
            <tr>
                <td>
                    Đặt chỗ : 
                     <asp:LinkButton ID="lbtBooking"  Enabled=<%#DataBinder.Eval(Container.DataItem, "ticketStatus")%>   runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ticketID")%>' OnCommand="addCart"> Click Here</asp:LinkButton>
    
                </td>
            

            </tr>       
        </table>
            
        </div>
        
    </ItemTemplate>
    <FooterTemplate>
    
       
    </FooterTemplate>
</asp:Repeater>
<p>
    &nbsp;</p>


<asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
<br />
<asp:LinkButton ID="lnkPreviousPage" runat="server" onclick="lnkPreviousPage_Click">Trang Trước</asp:LinkButton>
<asp:LinkButton ID="lnkNextPage" runat="server" onclick="lnkNextPage_Click">Trang Sau</asp:LinkButton>
 <asp:Label ID="lblCurrentPage" runat="server" Text=""></asp:Label>
</asp:Panel>
<asp:Panel ID="pnlNoResults" runat="server" Visible="false">
    <div>
     
    </div>
   
</asp:Panel>