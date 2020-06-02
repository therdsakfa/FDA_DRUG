<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm22.aspx.vb" Inherits="FDA_DRUG.WebForm22" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jquery-1.8.3.js"></script>
    <link href="../assets/prettify/prettify.css" rel="stylesheet" />
    <script src="../Charts/FusionCharts.js"></script>
    <script src="../assets/prettify/prettify.js"></script>
    <script src="../assets/ui/js/json2.js"></script>
    <script src="../assets/ui/js/lib.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Button ID="trim" runat="server" Text="btn_trim" />
        <table style="height:500px;">
            <tr>
                <td>
                    <div id="chartdiv" align="center">Chart will load here
                    </div>
           <asp:HiddenField ID="HiddenField1" runat="server" Value="1234" />
                    <script type="text/javascript">
                        var targetobject = $("#<%=HiddenField1.ClientID%>").val();
                        var myChart = new FusionCharts({
                            type: 'MSColumn3D',
                            renderAt: 'chart-container',
                            dataFormat: 'json',
                            dataSource: targetobject,
                            width: '100%',
                            height: '100%',
                        });

                        myChart.render("chartdiv");
		</script>
                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="2"></asp:TextBox>
                </td>
            </tr>
        </table>
        
    <div id="dvInfo" runat="server">
        <table>
            <tr>
                <td>ทดสอบ</td>
                <td>นะจ๊ะ</td>
                <td>นะจ๊ะ</td>
                <td>นะจ๊ะ</td>
                <td>นะจ๊ะ</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
