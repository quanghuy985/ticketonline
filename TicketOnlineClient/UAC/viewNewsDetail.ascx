<%@ Control Language="C#" AutoEventWireup="true" CodeFile="viewNewsDetail.ascx.cs" Inherits="UAC_viewNewsDetail" %>
<asp:Repeater ID="rptNewsDetail" runat="server">
    <HeaderTemplate>
    <table>
    <tr>
    
    <td style="width:100%" align="center">
    Tin tức và Sự Kiện >>.
    </td>
    <hr />
    </tr>
    </table>
    </HeaderTemplate>
    <ItemTemplate>
        <div style="float:left; width: 100% ">
       <table style="width: 100%; height: 141px;">
            <tr>
            <td align="left" style="font-style:italic;font-family:Times New Roman;">
                   Tiêu đề : <%# DataBinder.Eval(Container.DataItem, "newsTitle")%> </td>
                
            </tr>
            <tr>
                
                 <td align="left"> <%# DataBinder.Eval(Container.DataItem, "newsBrief")%>...<p></p></td>
            </tr>
            <tr>
             
             <td align="center"> <img alt="Không có ảnh" width="50%"  src="images/<%#DataBinder.Eval(Container.DataItem, "newsImage")%>" /></td>
            </tr>
           <tr>
           <td>
           
           <%#DataBinder.Eval(Container.DataItem, "newsContent")%>
           
           </td>
           </tr>
            <hr />       
        </table>
            
        </div>
        
    </ItemTemplate>
    <FooterTemplate>
    
       
    </FooterTemplate>
</asp:Repeater>