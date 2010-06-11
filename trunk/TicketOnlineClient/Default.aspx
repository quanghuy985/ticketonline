<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntContent" runat="server">
    <div style="height: 100%; width: 100%;">
     <asp:Repeater runat="server" ID="rptViewOrder" EnableViewState="False">
        <HeaderTemplate>
            <table id="tb" border="1" cellpadding="2" width="100%" align="center">
                <tr align="center">
                    
                    <th style="color: Black">TiketID</th>
                    <th style="color:Black">Ghế số</th>
                    <th style="color:Black">Giờ</th>
                    <th style="color:Black">Ngày đi</th>
                    <th style="color:Black">Ngày đến</th>
                    <th style="color: Black">Nơi đi</th>
                    <th style="color: Black">Nơi đến</th>
                    <th style="color: Black">Giá</th>
                </tr>
        </HeaderTemplate>
        
        <ItemTemplate>
            <tr>
              
                <td style="color: Black"><%# DataBinder.Eval(Container.DataItem, "ticketID")%></td>
                <td style="color: Black"><%# DataBinder.Eval(Container.DataItem, "seatNo")%></td>
                <td style="color: Black"><%# DataBinder.Eval(Container.DataItem, "startHours")%></td>
                <td style="color: Black"><%# DataBinder.Eval(Container.DataItem, "startTime")%></td>
                <td style="color: Black"><%# DataBinder.Eval(Container.DataItem, "endTime")%></td>
                <td style="color: Black"><%# DataBinder.Eval(Container.DataItem, "transPlaceStart")%></td>
               <td style="color: Black"><%# DataBinder.Eval(Container.DataItem, "transPlaceDestination")%></td>
                  <td style="color: Black"><%# DataBinder.Eval(Container.DataItem, "transFee")%></td>
            </tr>
        </ItemTemplate>
        
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <p>
    </p>
    <p>
    </p>
    <asp:Label ID="lbOutPut"  runat="server" ForeColor="#0099FF"></asp:Label>
</div>
</asp:Content>
