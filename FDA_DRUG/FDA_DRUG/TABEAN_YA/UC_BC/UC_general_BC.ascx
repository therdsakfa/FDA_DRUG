<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_general_BC.ascx.vb" Inherits="FDA_DRUG.UC_general_BC" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<style type="text/css">
    .auto-style1 {
        height: 28px;
    }
</style>

<table>
   


   <tr>
        <td bgcolor="Lavender" width="197px" height="28px" align="right">ชื่อการค้า (ภาษาไทย):</td>
        <td >
            &nbsp;</td>
        <td >
            &nbsp;</td>
        <td >
            <asp:Label ID="lbl_drgname" runat="server" Text="-"></asp:Label>
        </td>
    </tr>



   <tr>
        <td bgcolor="Lavender" width="197px" height="28px" align="right">ชื่อการค้า (ภาษาอังกฤษ):</td>
        <td >
            &nbsp;</td>
        <td >
            &nbsp;</td>
        <td >
            <asp:Label ID="lbl_drgname_eng" runat="server" Text="-"></asp:Label>
        </td>
    </tr>



   <tr>
        <td bgcolor="Lavender" width="197px" align="right" class="auto-style1">หมวดยา : </td>
       <td style="padding:0px 0px 0px 50px;" class="auto-style1" >
            <asp:Label ID="lbl_dactg" runat="server" Text=""></asp:Label>
        </td>
        <td style="padding:0px 0px 0px 50px;" class="auto-style1" >
            แก้ไขเป็น</td>
        <td class="auto-style1" >
            <telerik:RadComboBox ID="rcb_dactg" runat="server" filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>



    <tr>
        <td  bgcolor="Lavender"  align="right">รูปแบบยา : </td>
        <td style="padding:0px 0px 0px 50px;">
            <asp:Label ID="lbl_drdosage" runat="server" Text=""></asp:Label>

        </td>
        <td style="padding:0px 0px 0px 50px;">
            แก้ไขเป็น</td>
        <td >
            <telerik:RadComboBox ID="rcb_drdosage" runat="server" filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>




   <tr>
        <td  bgcolor="Lavender" bgcolor="Wheat" align="right" >ประเภทของยา :</td>
        <td style="padding:0px 0px 0px 50px;" >
            <asp:Label ID="lbl_drclass" runat="server" Text=""></asp:Label>

        </td>
        <td style="padding:0px 0px 0px 50px;" >
            แก้ไขเป็น</td>
        <td >
            <telerik:RadComboBox ID="rcb_drclass" runat="server" filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>

 <%--   <tr>
        <td  bgcolor="Wheat">ชื่อผู้รับอนุญาต :</td>
        <td class="auto-style13">
            <asp:Label ID="lb_usernm_pop" runat="server"></asp:Label></td>
    </tr>--%>




<%--    <tr>
        <td bgcolor="Lavender" >เหตุผลที่ยกเลิกคำขอ:</td>
        <td >
            <asp:Label ID="lb_Reason" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td  bgcolor="Lavender" >วันที่ยกเลิก:</td>
        <td >
            <asp:Label ID="lb_cancel_day" runat="server"></asp:Label></td>
    </tr>--%>
   



   <tr>
        <td  bgcolor="Lavender" bgcolor="Wheat" align="right" >ชนิดยา :</td>
         <td style="padding:0px 0px 0px 50px;">
            <asp:Label ID="lbl_drug_type" runat="server" Text=""></asp:Label>

        </td>
        <td style="padding:0px 0px 0px 50px;">
            แก้ไขเป็น</td>
        <td >
            <telerik:RadComboBox ID="rcb_drug_type" Runat="server" filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>




   <%--<tr>
        <td  bgcolor="Lavender" bgcolor="Wheat" align="right" >รูปทรง :</td>
        <td style="padding:0px 0px 0px 50px;">
            <asp:Label ID="lbl_shape" runat="server" Text=""></asp:Label>

        </td>
        <td style="padding:0px 0px 0px 50px;">
            แก้ไขเป็น</td>
        <td >
            <telerik:RadComboBox ID="rcb_shape" runat="server" filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>--%>
<%--    <tr>
        <td bgcolor="Lavender" bgcolor="Wheat" align="right" >
            หน่วยนับตามรูปของแบบยา :</td>
        <td style="padding:0px 0px 0px 50px;">
            <asp:Label ID="lbl_small_unit" runat="server" Text=""></asp:Label>

        </td>
        <td style="padding:0px 0px 0px 50px;">
            แก้ไขเป็น</td>
        <td >
            <telerik:RadComboBox ID="rcb_small_unit" runat="server" filter="Contains"></telerik:RadComboBox>

  

        </td>
    </tr>--%>



    <%--<tr>
        <td bgcolor="Lavender" bgcolor="Wheat" align="right" >
            หน่วยนับทางชีวภาพ :</td>
        <td style="padding:0px 0px 0px 50px;">
            <asp:Label ID="lbl_bio_pack" runat="server" Text=""></asp:Label>

        </td>
        <td style="padding:0px 0px 0px 50px;">
            แก้ไขเป็น</td>
        <td >
            <telerik:RadComboBox ID="rcb_bio_pack" runat="server" filter="Contains"></telerik:RadComboBox>

        </td>
    </tr>--%>



   <%-- <tr>
        <td bgcolor="Lavender" bgcolor="Wheat"  align="right">
            หน่วยนับตามบรรจุภัณฑ์ :</td>
         <td style="padding:0px 0px 0px 50px;">
            <asp:Label ID="lbl_packaging" runat="server" Text=""></asp:Label>


        </td>
        <td style="padding:0px 0px 0px 50px;">
            แก้ไขเป็น</td>
        <td >
            <telerik:RadComboBox ID="rcb_packaging" runat="server" filter="Contains"></telerik:RadComboBox>

        </td>
    </tr>--%>


 </table>