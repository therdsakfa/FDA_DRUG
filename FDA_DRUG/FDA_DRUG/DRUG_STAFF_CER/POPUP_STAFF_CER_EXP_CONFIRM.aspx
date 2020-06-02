<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_STAFF_CER_EXP_CONFIRM.aspx.vb" Inherits="FDA_DRUG.POPUP_STAFF_CER_EXP_CONFIRM" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="../UC/UC_GRID_ATTACH.ascx" tagname="UC_GRID_ATTACH" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
<%--    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>เพิ่มสาร
                </h1>
            </div>
            
        </div>--%>
    <table style="width:100%;height:500px;">
        <tr>
            <td rowspan="2" style="width:70%;">

               <div class="panel-body">
                   <table class="table" width="100%">
        <tr>
            <td align="right">
                เลขที่ใบรับรอง (Certificate Number) :</td>
            <td>
               <asp:TextBox ID="txt_Cernumber" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                วันที่ cer :</td>
            <td>
               <asp:TextBox ID="txt_cer_DATE" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                วันที่หมดอายุ :</td>
            <td>
               <asp:TextBox ID="txt_cer_exp_date" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="right">
                ปีที่ต่ออายุ :&nbsp;</td>
            <td>
               <asp:TextBox ID="txt_Year_extend" runat="server" CssClass="input-sm" Width="200px" Enabled="false"></asp:TextBox>
            </td>
        </tr>

 
        </table>
                <br />
                   <table width="80%">
                 <tr>
                     <td>

                         <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="false">
                             <MasterTableView>
                                   <Columns>
                                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                           SortExpression="IDA" UniqueName="IDA" Display="false">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="CER_NUMBER" FilterControlAltText="Filter CER_NUMBER column"
                                           HeaderText="เลขในระบบ" SortExpression="CER_NUMBER" UniqueName="CER_NUMBER">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="CERTIFICATION_NUMBER_ALL" FilterControlAltText="Filter CERTIFICATION_NUMBER_ALL column"
                                           HeaderText="เลขที่ใบรับรอง" SortExpression="CERTIFICATION_NUMBER_ALL" UniqueName="CERTIFICATION_NUMBER_ALL">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="EXP_DATE_EXTEND" FilterControlAltText="Filter EXP_DATE_EXTEND column"
                                           HeaderText="ใช้ได้ถึง" SortExpression="EXP_DATE_EXTEND" UniqueName="EXP_DATE_EXTEND" DataFormatString="{0:dd/MM/yyyy}">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridButtonColumn ButtonType="LinkButton" Text="ลบ" ConfirmText="คุณต้องการลบข้อมูล?" UniqueName="btn_del" CommandName="del">
                                       </telerik:GridButtonColumn>
                                   </Columns>
                               </MasterTableView>
                         </telerik:RadGrid>

                     </td>
                 </tr>
             </table>
            </div>
            </td>
             <td style="padding-left:10%;height:50%;">

                 <table class="table" style="width:90%"> 
                     
                     <tr><td>
                         <asp:DropDownList ID="ddl_cnsdcd" runat="server"  Width="80%" DataTextField="STATUS_NAME" DataValueField="STATUS_ID">
                         </asp:DropDownList>
                         </td></tr>
                     
                     <tr><td>
                         วันที่
                         <asp:TextBox ID="txt_app_date" runat="server"></asp:TextBox>
                         </td></tr>
                     
                     <tr><td><asp:Button ID="btn_confirm" runat="server" Text="ยืนยัน" CssClass="btn-lg" OnClientClick="return ('ต้องการยืนยันข้อมูลหรือไม่');"   Width="80%" /></td></tr>
                     <tr><td>  <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg"   Width="80%" /></td></tr>

                 </table>
                 


             </td>
        </tr>
        <tr>
             <td style="width:30%;height:50%;padding-left:10%">

                 <br />
           
                 <uc1:UC_GRID_ATTACH ID="UC_GRID_ATTACH1" runat="server" />
           
             </td>
        </tr>
        </table>
</asp:Content>
