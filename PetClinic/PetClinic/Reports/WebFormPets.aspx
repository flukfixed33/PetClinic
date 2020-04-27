<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormPets.aspx.cs" Inherits="PetClinic.Reports.WebFormPets" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            width: 950px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 0px" Width="109px" ></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 17px" Text="ค้นหา" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="คืนค่า" />
        </div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="764px" Width="726px" CssClass="auto-style1"></rsweb:ReportViewer>
    </form>
</body>
</html>
