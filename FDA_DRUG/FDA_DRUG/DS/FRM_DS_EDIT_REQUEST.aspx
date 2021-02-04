<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_DS_EDIT_REQUEST.aspx.vb" Inherits="FDA_DRUG.FRM_DS_EDIT_REQUEST" %>
<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 552px;
            height: 264px;
        }
        .auto-style3 {
            width: 201px;
            height: 264px;
        }
        .auto-style4 {
            width: 30%;
            height: 264px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center><h1>รายละเอียดการแก้ไข</h1></center>
        </div>
    </form>
    <div>
        <table class="table">
            <tr>
                <td align="right" class="auto-style3"><h4>รายละเอียดการแก้ไข : </h4></td>
                <td class="auto-style2"><asp:Label ID="lbl_EDIT" runat="server"></asp:Label></td>
                <td style="padding-left:10%" class="auto-style4"><uc1:UC_GRID_ATTACH runat="server" ID="UC_GRID_ATTACH" /></td>
                <br />
                <br />
            </tr>
        </table>
    </div>
    <br />
        * กำหนดส่งเอกสารในะบบวันที่ <asp:Label ID="lbl_DATE" runat="server"></asp:Label> ก่อนเวลา 23.59 น. ของวันที่ระบุข้างต้น
    <br />
    <br />
    <div>
        <center><asp:Button ID="Button_DL" runat="server" Text="แก้ไขข้อมูลส่วนที่ 2"  CssClass="btn-lg" Height="45px"/></center>
    </div>
</body>
</html>
