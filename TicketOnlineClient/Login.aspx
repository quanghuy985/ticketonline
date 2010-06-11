<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntContent" runat="server">
  
    <div style="background-color:White">
    <h5> -Chào mừng bạn đến với Ticket Online- Vui lòng đăng nhập</h5>
    <hr />
      
            <table style=" width : 100%" >
                <tr id="Tr1" align ="center" runat="server">
                    <td align ="center" style="width:30%" >
                        <asp:Label ID = "lbUserName" runat ="server" Text="Tên Tài Khoản :" ></asp:Label>
                    </td>
                    <td align ="center" style="width:30%">
                        <asp:TextBox ID="txtUserName" runat="server" Width="100%" 
                            style="margin-left: 2px" ></asp:TextBox>
                    </td>
                    <td style="width:40%">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtUserName" ValidationGroup="vg" 
                            ErrorMessage="Tài khoản không &#273;&#432;&#417;&#803;c &#273;ê&#777; trô&#769;ng"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr align ="center">
                    <td>
                        <asp:Label ID="lbPassword" runat="server" Text="Mật Khẩu:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
                    </td>
                    <td>
                    <asp:LinkButton Text="Quên mật khẩu?" runat="server" ID="lbtPassword" 
                            BorderColor="Red" ForeColor="#FF5050" onclick="lbtPassword_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                <td>
                   
                </td>
                    <td>
                     <asp:Button ID="btSubmit" runat="server" onclick="btSubmit_Click" Text="Submit" 
                        ValidationGroup="vg" />
                        <asp:Button ID="btCancel" runat="server" onclick="btCancel_Click" 
                            Text="Cancel" />
                    </td>
                    <td>
                        <asp:Button ID="btRegister" runat="server" onclick="btRegister_Click" 
                            Text="Register" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <asp:Label ID="lbError" runat="server" ForeColor="Red"></asp:Label>
      </div>
    
</asp:Content>