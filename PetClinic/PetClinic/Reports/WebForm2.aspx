<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="PetClinic.Reports.WebForm2" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>รายงาน</title>
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {}
        .auto-style1 {}
    </style>
</head>
<body>
    <div class="container">

        <form id="form1" runat="server">
            <div class="form-group">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" OnTextChanged="TextBox1_TextChanged" Format="dd/MM/yyyy"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="ค้นหา"  OnClick="Button1_Click"  />
                <asp:Button ID="Button2" runat="server" Text="คืนค่า"  OnClick="Button2_Click" />
            </div>
            
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="626px" Width="726px" CssClass="auto-style1"></rsweb:ReportViewer>
            </div>
        </form>
    </div>

</body>
</html>
