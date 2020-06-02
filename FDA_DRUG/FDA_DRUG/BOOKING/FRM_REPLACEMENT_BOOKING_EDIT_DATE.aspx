<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF_DRUG_POPUP.Master" CodeBehind="FRM_REPLACEMENT_BOOKING_EDIT_DATE.aspx.vb" Inherits="FDA_DRUG.FRM_REPLACEMENT_BOOKING_EDIT_DATE" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>

   
        <table style="width:100%" class="table">
              
       
      <tr>
         
             <td style="width:25%;" >

            </td>
             <td >
                 <asp:Label ID="Label1" runat="server" Text="วันที่ :"></asp:Label>
                
             </td>
           <td >
                        <telerik:raddatepicker ID="rdp_date"  Width="80%"
    runat="server"  Culture="th-TH"  Calendar-DayCellToolTipFormat="dd/MM/yyyy" DateInput-DisplayDateFormat="dd/MM/yyyy"  DateInput-DateFormat="dd/MM/yyyy">
    <DateInput ID="DateInput3" runat="server" DateFormat="dd/MM/yyyy" Width="80%"
        AutoPostBack="false">
    </DateInput>
    <Calendar ID="Calendar3" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
        ViewSelectorText="x">
    </Calendar>
</telerik:raddatepicker>
               <%--<asp:TextBox ID="txt_date" runat="server" Width="80%"></asp:TextBox>--%>
           </td>
             <td style="width:25%;" >

                 </td>
        </tr>
     
    </table>
    <div style="text-align:center;width:100%">

                 <asp:Button ID="Btn_confirm" runat="server" Text="ยืนยัน"  Width="25%" CssClass="btn-success btn-lg"/>

                 &nbsp;<asp:Button ID="Btn_back" runat="server" Text="ยกเลิก" Width="25%" CssClass="btn-danger btn-lg"  />
    </div>
</asp:Content>



