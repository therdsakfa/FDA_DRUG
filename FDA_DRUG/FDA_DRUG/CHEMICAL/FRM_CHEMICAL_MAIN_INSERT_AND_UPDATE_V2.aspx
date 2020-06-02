<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_CHEMICAL_MAIN_INSERT_AND_UPDATE_V2.aspx.vb" Inherits="FDA_DRUG.FRM_CHEMICAL_MAIN_INSERT_AND_UPDATE_V2" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <div class="panel-heading panel-title">
                <h1>เพิ่มสารเคมี</h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr ><td>ชื่อสาร</td><td>
                        <asp:TextBox ID="Txt_Name" runat="server" CssClass="input-lg" Width="300px"></asp:TextBox>
                        </td></tr>
                    <tr>
                        <td colspan="2">
                            <div style="text-align: center;">
                                <table >
                                    <tr>
                                        <td><asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg"  /></td>
                                        <td><asp:Button ID="btn_edit" runat="server" Text="แก้ไข" CssClass="btn-lg" /></td>
                                        <td><asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" CssClass="btn-lg" /></td>
                                    </tr>
                                </table>
                                
                                &nbsp;&nbsp;
                   &nbsp;&nbsp;

                            </div>
                        </td>
                    </tr>
                    <tr >
                        
                        
                        <td colspan="2">
                            <asp:Panel ID="Panel1" runat="server">
                                <table >
    
        <tr>
            <td align="right" valign="top">
                <asp:Label ID="lb_paylist" runat="server" Text="ชื่อสาร :"></asp:Label>
            </td>
            <td valign="top">
                <asp:DropDownList ID="ddl_chemecal" runat="server" DataTextField="iowanm" DataValueField="IDA" Width="200px">
                </asp:DropDownList>
                </td>
        </tr>
    <tr>
        <td align="right">&nbsp;</td>
        <td>
            <asp:Button ID="btn_add" runat="server" Text="เพิ่มสารย่อย" CssClass="btn-lg" />
        </td>
    </tr>
</table>


                            <table width="100%">
                                <tr>
                                    <td align="right">

                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>

                                        <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" width="100%" ShowFooter="true" AutoGenerateColumns="false">
                                            <MasterTableView>
                        <Columns>
                            
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="IDA" HeaderText="IDA" DataField="IDA" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="FK_IDA" HeaderText="FK_IDA" DataField="FK_IDA" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="iowanm" HeaderText="ชื่อสาร" DataField="iowanm" >
                            </telerik:GridBoundColumn>                           
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del" >
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                                        </telerik:RadGrid>

                                    </td>
                                </tr>

                            </table>
                            </asp:Panel>

                                        </td></tr>
                    
                    </table>
            </div>
              
        </div>
</asp:Content>
