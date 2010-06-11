<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListNewsFooter.ascx.cs" Inherits="UAC_ListNewsFooter" %>
<asp:Repeater ID="rptNewsFooter" runat="server">
    <HeaderTemplate>
    <table style="width:100%">
   <hr />
   <tr>
   <td style="width:15%"></td>
   <td align="left" style="width:50%">
   Các tin đã đưa :
   </td>
   <td></td>
   </tr>
    </table>
    </HeaderTemplate>
    <ItemTemplate>
        <div style="float:left; width: 100% ">
       <table style="width: 100%">
            <tr>
            <td style="width:15%"></td>
                <td align="left"  valign="middle" style="width:50%; font-style:italic;font-family:Times New Roman;"><li>
                   <asp:LinkButton ID="lbtMore2" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "newsID")%>' OnCommand="More" Font-Bold="True" Font-Overline="false" Font-Underline="false" ForeColor="Brown"> <%# DataBinder.Eval(Container.DataItem, "newsTitle")%></asp:LinkButton></li>  </td>
          <td></td>
          </tr>
        </table>
        </div>
        
    </ItemTemplate>
    <FooterTemplate>
    
       
    </FooterTemplate>
</asp:Repeater>