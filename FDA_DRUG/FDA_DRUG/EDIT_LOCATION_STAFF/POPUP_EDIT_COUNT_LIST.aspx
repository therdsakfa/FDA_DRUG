<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_EDIT_COUNT_LIST.aspx.vb" Inherits="FDA_DRUG.POPUP_EDIT_COUNT_LIST" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-heading panel-title" style="padding-left: 5%;">
            <h2> รายการแก้ไข&nbsp;</h2>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        </div>

   <hr />
   <div>
       <br />
       <table width="100%">
           <tr>
               <td>
                   <telerik:RadGrid ID="RadGrid1" runat="server">
                       <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                           <Columns>
                               <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                   HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                               </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EDIT_TYPE" FilterControlAltText="Filter EDIT_TYPE column"
                                   HeaderText="EDIT_TYPE" SortExpression="EDIT_TYPE" UniqueName="EDIT_TYPE" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="edit_type_txt" FilterControlAltText="Filter edit_type_txt column"
                                   HeaderText="ประเภทที่แก้ไข" SortExpression="edit_type_txt" UniqueName="edit_type_txt">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="before_edit" FilterControlAltText="Filter before_edit column"
                                   HeaderText="แก้ไขจาก" SortExpression="before_edit" UniqueName="before_edit">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="after_edit" FilterControlAltText="Filter after_edit column"
                                   HeaderText="แก้ไขเป็น" SortExpression="after_edit" UniqueName="after_edit">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="INSERT_DATE" FilterControlAltText="Filter INSERT_DATE column"
                                   HeaderText="วันที่เพิ่มข้อมูล" SortExpression="INSERT_DATE" UniqueName="INSERT_DATE" DataFormatString="{0:dd/MM/yyyy}">
                               </telerik:GridBoundColumn>
                               <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="del"
                                   CommandName="del" Text="ลบ">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>
                           </Columns>
                       </MasterTableView>
                   </telerik:RadGrid>
              
                   
               </td>
           </tr>
       </table>
        </div>
</asp:Content>
