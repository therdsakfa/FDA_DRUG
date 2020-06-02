<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm23.aspx.vb" Inherits="FDA_DRUG.WebForm23" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="../../js/jquery-1.8.3.js"></script>

    <link href="../../assets/prettify/prettify.css" rel="stylesheet" />
    <script src="../../Charts/FusionCharts.js"></script>
    <script src="../../assets/prettify/prettify.js"></script>
    <script src="../../assets/ui/js/json2.js"></script>
    <script src="../../assets/ui/js/lib.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="chartdiv" align="center">Chart will load here</div>
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
    </form>
</body>
</html>
