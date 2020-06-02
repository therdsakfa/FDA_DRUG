<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF_DRUG_POPUP.Master" CodeBehind="FRM_REPLACEMENT_DRUG_BOOKING_STATUS.aspx.vb" Inherits="FDA_DRUG.FRM_REPLACEMENT_DRUG_BOOKING_STATUS" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register src="../UC/UC_CONFIRM.ascx" tagname="UC_CONFIRM" tagprefix="uc1" %>
<%@ Register Src="~/UC/UC_NCT_INFORMATION.ascx" TagPrefix="uc1" TagName="UC_NCT_INFORMATION" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 20%;
            height: 53px;
        }
        .auto-style2 {
            height: 53px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%--<asp:HyperLink ID="HyperLink1" runat="server" CssClass="badge">8.30 - 9.30</asp:HyperLink>--%>
     <%--<asp:Table ID="tb_booking" runat="server"  Width="100%" CssClass="table-bordered">
     </asp:Table>--%>
         
    <uc1:UC_NCT_INFORMATION runat="server" id="UC_NCT_INFORMATION" />
          <br />
   <%--   <div >
         <table style="width:100%" class="table">
             <tr>
                 <td style="width:40%;text-align:right">
                     สถานะ:
                 </td>
                  <td style="width:60%;text-align:left">
<asp:DropDownList ID="ddl_status" runat="server" Width="40%" AutoPostBack="true">
    <asp:ListItem Value="0" Text="กรุณาเลือกสถานะ"></asp:ListItem>
    <asp:ListItem Value="3" Text="อยู่ระหว่างตรวจเอกสาร"></asp:ListItem>
    <asp:ListItem Value="7" Text="ขอเอกสารเพิ่ม"></asp:ListItem>
    <asp:ListItem Value="6" Text="รับคำขอ"></asp:ListItem>
    <asp:ListItem Value="8" Text="รับใบอนุญาต"></asp:ListItem>
                      </asp:DropDownList>
                 </td>
             </tr>
             <tr>
                 <td style="text-align:right" class="auto-style1">
                     หมายเหตุ:
                 </td>
                  <td class="auto-style2">
                        <asp:TextBox ID="txt_remark" runat="server" TextMode="MultiLine"  Width="70%"></asp:TextBox>
                 </td>
             </tr>
                <tr>
                 <td style="text-align:right" class="auto-style1">
                     วันที่บันทึกผลการพิจารณา:
                 </td>
                  <td class="auto-style2">
                          <telerik:raddatepicker ID="rdp_date"  Width="80%"
    runat="server"  Culture="th-TH"  Calendar-DayCellToolTipFormat="dd/MM/yyyy" 
     AutoPostBack="True" DateInput-DisplayDateFormat="dd/MM/yyyy"  DateInput-DateFormat="dd/MM/yyyy">
    <DateInput ID="DateInput3" runat="server" DateFormat="dd/MM/yyyy" Width="80%"
        AutoPostBack="false">
    </DateInput>
    <Calendar ID="Calendar3" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
        ViewSelectorText="x">
    </Calendar>
</telerik:raddatepicker>&nbsp;</td>
             </tr>
          
         </table>
 

      </div> --%>
    <table style="width:100%" class="table">
             <tr>
                 <td style="width:40%;text-align:right">
                     สถานะ:
                 </td>
                  <td style="width:60%;text-align:left">
<asp:DropDownList ID="ddl_status" runat="server" Width="40%"></asp:DropDownList>
                 </td>
             </tr>
             <tr>
                 <td style="text-align:right" class="auto-style1">
                     หมายเหตุ:
                 </td>
                  <td class="auto-style2">
                        <asp:TextBox ID="txt_remark" runat="server" TextMode="MultiLine"  Width="70%"></asp:TextBox>
                 </td>
             </tr>
                <tr>
                 <td style="text-align:right" class="auto-style1">
                     วันที่บันทึกผลการพิจารณา:
                 </td>
                  <td class="auto-style2">
                        <telerik:raddatepicker ID="rdp_date"  Width="20%"
    runat="server"  Culture="th-TH"  Calendar-DayCellToolTipFormat="dd/MM/yyyy" 
     AutoPostBack="True" DateInput-DisplayDateFormat="dd/MM/yyyy"  DateInput-DateFormat="dd/MM/yyyy">
    <DateInput ID="DateInput3" runat="server" DateFormat="dd/MM/yyyy" Width="80%"
        AutoPostBack="false">
    </DateInput>
    <Calendar ID="Calendar3" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
        ViewSelectorText="x">
    </Calendar>
</telerik:raddatepicker>&nbsp;</td>
             </tr>
              <tr>
                 <td style="width:20%;text-align:right">
                     แนบไฟล์ 1:
                 </td>
                  <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="253px" />
                      
                 </td>
                  
             </tr>
              <tr>
                 <td style="width:20%;text-align:right">
                     ระบุชื่อย่อของไฟล์ที่แนบ 1:
                 </td>
                  <td>
                       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td style="width:20%;text-align:right">
                     แนบไฟล์&nbsp; 2:
                 </td>
                  <td>
                        <asp:FileUpload ID="FileUpload2" runat="server" Width="253px" />
                      
                 </td>
                  
             </tr>
              <tr>
                 <td style="width:20%;text-align:right">
                     ระบุชื่อย่อของไฟล์ที่แนบ 2:
                 </td>
                  <td>
                       <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td style="width:20%;text-align:right">
                     แนบไฟล์ 3:
                 </td>
                  <td>
                        <asp:FileUpload ID="FileUpload3" runat="server" Width="253px" />
                      
                 </td>
                  
             </tr>
              <tr>
                 <td style="width:20%;text-align:right">
                     ระบุชื่อย่อของไฟล์ที่แนบ 3:
                 </td>
                  <td>
                       <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                 </td>
             </tr>
         </table>
    <div style="text-align:center;">
<asp:Button ID="Btn_confirm" runat="server"  CssClass="btn-success btn-lg" Text="ยืนยัน" Width="20%" />
    &nbsp;&nbsp;
    </div> 
        <br />
        <br />
</asp:Content>
