<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DRUG_PRODUCT_ID_STAFF.aspx.vb" Inherits="FDA_DRUG.POPUP_DRUG_PRODUCT_ID_STAFF" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
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
                
                <br />

                   <table class="table" style="width:100%;height:500px;">
                       <tr>
                           <td>ชื่อการค้า</td>
                           <td>
                               <asp:TextBox ID="Txt_TRADE_NAME" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                           </td>
                       </tr>
                       <tr>
                           <td>ชื่อการค้าภาษาอังกฤษ</td>
                           <td>
                               <asp:TextBox ID="Txt_TRADE_NAME_ENG" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                           </td>
                       </tr>
                       <tr>
                           <td colspan="2">
                               <asp:Panel ID="Panel1" runat="server">
                                   <table width="100%">
                                       <tr>
                                           <td>ตัวยาสำคัญ</td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" GridLines="None" ShowFooter="true" width="100%">
                                                   <MasterTableView>
                                                       <Columns>
                                            
                                                           <telerik:GridBoundColumn DataField="IDA" Display="false" HeaderText="IDA" UniqueName="IDA">
                                                           </telerik:GridBoundColumn>
                                                           <telerik:GridBoundColumn DataField="FK_IDA" Display="false" HeaderText="FK_IDA" UniqueName="FK_IDA">
                                                           </telerik:GridBoundColumn>
                                                           <telerik:GridBoundColumn DataField="iowanm" HeaderText="ตัวยาสำคัญ" UniqueName="iowanm">
                                                           </telerik:GridBoundColumn>
                                                           <telerik:GridBoundColumn DataField="STRENGTH_DRUG" HeaderText="ความแรง" UniqueName="STRENGTH_DRUG">
                                                           </telerik:GridBoundColumn>
                                                           <telerik:GridBoundColumn DataField="DOSAGE" HeaderText="ปริมาณ" UniqueName="DOSAGE">
                                                           </telerik:GridBoundColumn>
              
                                                       </Columns>
                                                   </MasterTableView>
                                               </telerik:RadGrid>
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <br />
                                               <asp:Panel ID="Panel2" runat="server">
                                                   <table width="100%">
                                                       <tr>
                                                           <td>หมวดยา</td>
                                                       </tr>
                                                       <tr>
                                                           <td>
                                                               <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="false" GridLines="None" ShowFooter="true" width="100%">
                                                                   <MasterTableView>
                                                                       <Columns>
                                                                 
                                                                           <telerik:GridBoundColumn DataField="IDA" Display="false" HeaderText="IDA" UniqueName="IDA">
                                                                           </telerik:GridBoundColumn>
                                                                           <telerik:GridBoundColumn DataField="FK_IDA" Display="false" HeaderText="FK_IDA" UniqueName="FK_IDA">
                                                                           </telerik:GridBoundColumn>
                                                                           <telerik:GridBoundColumn DataField="ctgthanm" HeaderText="หมวดยา" UniqueName="ctgthanm">
                                                                           </telerik:GridBoundColumn>
                                                                       
                                                                       </Columns>
                                                                   </MasterTableView>
                                                               </telerik:RadGrid>
                                                           </td>
                                                       </tr>
                                                   </table>
                                               </asp:Panel>
                                           </td>
                                       </tr>
                                   </table>
                               </asp:Panel>
                           </td>
                       </tr>
                   </table>
                
            </div>
            </td>
             <td style="padding-left:10%;height:50%;">

                 <table class="table" style="width:90%"> 
                     
                     <tr><td>
                         <asp:DropDownList ID="ddl_status" runat="server"  Width="80%" >
                         </asp:DropDownList>
                         </td></tr>
                     
                     <tr><td>
                         วันที่
                         <asp:TextBox ID="txt_app_date" runat="server"></asp:TextBox>
                         </td></tr>
                     
                     <tr><td><asp:Button ID="btn_confirm" runat="server" Text="ยืนยัน" CssClass="btn-lg"   Width="80%" /></td></tr>
                     <tr><td>  <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg"   Width="80%" /></td></tr>

                 </table>
                 


             </td>
        </tr>
        <tr>
             <td style="width:30%;height:50%;padding-left:10%">

                 <br />
           
             </td>
        </tr>
        </table>
</asp:Content>
