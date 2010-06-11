<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content id="content" ContentPlaceHolderID="cntContent" runat="server">
    <div style="background-color:White">
    
        <table style="width: 100%; height: 196px;">
            <tr>
                <td align="center" colspan="3">
                    Welcome to Ticket Online Website! Thanks for use our services</td>
            </tr>
            <tr>
                <td style="width: 30%">
                    UserName :</td>
                <td style="width :50%">
                    <asp:TextBox ID="txtCustomerID" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width:10%">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="User Không được để trống" ControlToValidate="txtCustomerID">*</asp:RequiredFieldValidator>
                                    </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Customer Password :</td>
                <td>
                    <asp:TextBox ID="txtCustomerPassword" runat="server" TextMode="Password" 
                        Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtCustomerPassword" 
                        ErrorMessage="Bạn phải nhập mật khẩu">*</asp:RequiredFieldValidator>
                                    </td>
            </tr>
            <tr>
            <td style="width: 25%">
                Confirm Password :
            </td>
            <td>
            <asp:TextBox ID="txtConfirmPassword" runat="server" Width="100%" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtCustomerPassword" ControlToValidate="txtConfirmPassword" 
                    ErrorMessage="Xác nhận mật khẩu phải trùng với mật khẩu" 
                    ValueToCompare="==">*</asp:CompareValidator>
            </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Address :</td>
                <td>
                    <asp:TextBox ID="txCustomerAddress" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txCustomerAddress" 
                        ErrorMessage="Địa chỉ không được để trống">*</asp:RequiredFieldValidator>
                                    </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Account Bank :     
                </td>
                <td>
                     <asp:TextBox ID="txtCustomerAccountBank" runat="server" Width="100%"></asp:TextBox>
                
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ErrorMessage="Tài khoản không được để trống" 
                            ControlToValidate="txtCustomerAccountBank">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="txtCustomerAccountBank" 
                            ErrorMessage="Bạn phải nhập đúng tài khoản có 9 số " 
                            ValidationExpression="^[0-9]{9}$">*</asp:RegularExpressionValidator>
                    </td>
            </tr>
            <tr>
                <td style="width: 25%">
                Email :
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ErrorMessage="Email không được để trống" 
                         ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="Bạn phải nhập đúng email" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        >*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 155px">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btSubmit" runat="server" onclick="btSubmit_Click" 
                        Text="Submit" />
                    <asp:Button ID="btReset" runat="server" onclick="btReset_Click" Text="Reset" />
                </td>
                <td>
                    <asp:Button ID="btBack" runat="server" onclick="btBack_Click" Text="Back" />
                </td>
            </tr>
            <tr>
                <td align="left" colspan="3">
                    <asp:Label ID="lbError" runat="server" ForeColor="Red"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Lỗi :" 
                        />
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>
