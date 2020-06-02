<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm20.aspx.vb" Inherits="FDA_DRUG.WebForm20" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script type="text/javascript">
        function alert_a() {
            
            var k = $(a);
            var aa = k.context.cell[0].textContent;
            alert(aa);
       }
    </script>
    <style type="text/css">
        .RadComboBox_Default .rcbInput { font-size:20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <asp:Button ID="Button3" runat="server" Text="คำนวณเดือน" />
        <asp:Button ID="QRQQQQ" runat="server" Text="Button" />
        <asp:Button ID="btn_gen_xml" runat="server" Text="XML" />
    <table id="tbl" style="width:100%">
        <tr>
            <td>aa<asp:TextBox ID="txt_url" runat="server"></asp:TextBox>
                <telerik:RadMaskedTextBox ID="RadMaskedTextBox1" runat="server" LabelWidth="64px" Mask="###,###.##" Width="160px">
                </telerik:RadMaskedTextBox>
                <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                </telerik:RadScriptManager>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>bb
                <telerik:RadBarcode runat="server" ID="RadBarcode1" Type="QRCode" Width="400px" Height="405px"
                OnPreRender="RadBarcode1_PreRender">
                <QRCodeSettings AutoIncreaseVersion="true" />
            </telerik:RadBarcode>
            </td>
        </tr>
    </table>
    </div>
        <telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" />
                 
        <telerik:RadBinaryImage ID="RadBinaryImage2" runat="server" Width ="114px" Height="152px"/>
                 
        <br />
        <asp:TextBox ID="txt_dh_id" runat="server"></asp:TextBox>
        <asp:Button ID="btn_gendh" runat="server" Text="gen_dh" style="height: 26px" />
                 
        <asp:FileUpload ID="FileUpload1" runat="server"  />
        <asp:Button ID="btn_upload" runat="server" Text="upload" />
        <telerik:RadComboBox ID="RadComboBox1" Runat="server">
            <Items>
                <telerik:RadComboBoxItem runat="server" Text="RadComboBoxItem1" Value="RadComboBoxItem1" />
                <telerik:RadComboBoxItem runat="server" Text="RadComboBoxItem2" Value="RadComboBoxItem2" />
                <telerik:RadComboBoxItem runat="server" Text="RadComboBoxItem3" Value="RadComboBoxItem3" />
            </Items>
        </telerik:RadComboBox>
        <br />
            <telerik:RadComboBox ID="rcb_shape" runat="server" filter="Contains"></telerik:RadComboBox>
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Button ID="btn_check_date" runat="server" Text="check_date" />
        <br />
                 
        <table width="50%">
            <tr>
                            <td>วันที่รับเรื่อง</td>
                            <td >
                                <asp:TextBox ID="txt_date" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                            </td>
                        </tr>
            <tr>
                            <td>จำนวนวันทำการ</td>
                            <td >
                                <asp:TextBox ID="txt_number" runat="server" CssClass="input-sm" Width="20%"></asp:TextBox>
                             
                                <asp:DropDownList ID="DropDownList2" runat="server" DataTextField="IOWA" DataValueField="IDA" CssClass="input-lg" Width="300px" style="display:none;">
                                </asp:DropDownList>
                                &nbsp;<asp:Button ID="btn_day" runat="server" CssClass="btn-lg" Text="คำนวนวัน" />
                            </td>
                        </tr>
            <tr>
                            <td>วันที่</td>
                            <td >
                               
                            <asp:Label ID="lbl_number_day" runat="server" ></asp:Label>
                                <asp:DropDownList ID="DropDownList3" runat="server" DataTextField="IOWA" DataValueField="IDA" CssClass="input-lg" Width="300px" style="display:none;">
                                </asp:DropDownList>
                            </td>
                        </tr>
        </table>
    </form>
</body>
</html>
