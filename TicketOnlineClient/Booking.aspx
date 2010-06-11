<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Booking.aspx.cs" Inherits="Default2" %>
<%@ Register Src="~/UAC/listticket.ascx" TagName="ListTicket" TagPrefix="uc1"  %>

      
<asp:Content ID="Content1" ContentPlaceHolderID="cntContent" runat="server">
    <div style="width:100%; height: 711px;">
    <table>
      <tr> 
      <td>Chuyến đi : </td> 
      <td><asp:Label ID="lbTransID" runat="server" Text=""></asp:Label>
      </td>
      <td>
          Ngày khởi hành :
      </td>
      <td>
      <asp:Label ID="lbStartTime"
            runat="server" Text=""></asp:Label></td>
            <td>
                Thời gian khởi hành :
            </td>
        <td>
        <asp:Label ID="lbStartHours" runat="server" Text=""></asp:Label>
        </td>
          </tr>
            </table>
    <uc1:ListTicket ID="lbHome" runat="server" /> 
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <br />
      <asp:Repeater runat="server" ID="rpttikets" EnableViewState="False">
        <HeaderTemplate>
            <table id="tb" border="1" cellpadding="2" width="100%" align="center">
                <tr align="center">
                    
                    <th style="color: Black">TiketID</th>
                    <th style="color: Black">Gia</th>
                    <th style="color: Black">Noi di</th>
                    <th style="color: Black">Noi den</th>
                </tr>
        </HeaderTemplate>
        
        <ItemTemplate>
            <tr>
              
                <td style="color: Black"><%# DataBinder.Eval(Container.DataItem, "tiketids")%></td>
                <td style="color: Black"><%# DataBinder.Eval(Container.DataItem, "tranfees")%></td>
                <td style="color: Black"><%# DataBinder.Eval(Container.DataItem, "tranplacestarts")%></td>
               <td style="color: Black"><%# DataBinder.Eval(Container.DataItem, "trandestination")%></td>

            </tr>
        </ItemTemplate>
        
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
</asp:Content>