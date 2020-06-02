<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE.aspx.vb" Inherits="FDA_DRUG.POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <div class="panel-heading panel-title">
                <h1>ผลิตภัณฑ์</h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr ><td>ชื่อการค้า</td><td>
                        <asp:TextBox ID="Txt_TRADE_NAME" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                        </td></tr>
                    <tr ><td>ชื่อการค้าภาษาอังกฤษ</td><td>
                        <asp:TextBox ID="Txt_TRADE_NAME_ENG" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
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
                                <div class="panel-heading panel-title">
                                    <h4>ตัวยาสำคัญ</h4>
                                </div>
                                <table >
    
        <tr>
            <td align="right" valign="top">
                <asp:Label ID="lb_paylist" runat="server" Text="ตัวยาสำคัญ :"></asp:Label>
            </td>
            <td valign="top">
                <asp:DropDownList ID="ddl_chemecal" runat="server" DataTextField="iowanm" DataValueField="IDA" Width="200px" CssClass="input-sm">
                </asp:DropDownList>
                </td>
        </tr>
    <tr>
        <td align="right">ปริมาณ :</td>
        <td>
            <asp:TextBox ID="Txt_DOSAGE" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
        </td>
    </tr>
                                    <tr>
                                        <td align="right">ความแรง :</td>
                                        <td>
                                            <asp:TextBox ID="Txt_STRENGTH_DRUG" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td  colspan="2">
                                            <asp:Button ID="btn_add" runat="server" CssClass="btn-lg" Text="เพิ่มตัวยาสำคัญ" />
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
                            <telerik:GridBoundColumn UniqueName="iowanm" HeaderText="ตัวยาสำคัญ" DataField="iowanm" >
                            </telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn UniqueName="STRENGTH_DRUG" HeaderText="ความแรง" DataField="STRENGTH_DRUG" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="DOSAGE" HeaderText="ปริมาณ" DataField="DOSAGE" >
                            </telerik:GridBoundColumn>                          
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del" >
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                                        </telerik:RadGrid>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <div class="panel-heading panel-title">
                                    <h4>หมวดยา</h4>
                                </div>
                                        <asp:Panel ID="Panel2" runat="server">
<table width="100%">
                                            <tr>
                                                <td>
                                                    หมวดยา :
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_gr_group" runat="server" DataValueField="IDA" DataTextField="ctgthanm" CssClass="input-sm"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Button ID="btn_add2" runat="server" CssClass="btn-lg" Text="เพิ่มหมวดยา" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="false" GridLines="None" ShowFooter="true" width="100%">
                                                        <MasterTableView>
                                                            <Columns>
                                                                <telerik:GridBoundColumn DataField="RowNumber" HeaderText="ลำดับ" UniqueName="RowNumber">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="IDA" Display="false" HeaderText="IDA" UniqueName="IDA">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="FK_IDA" Display="false" HeaderText="FK_IDA" UniqueName="FK_IDA">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="ctgthanm" HeaderText="หมวดยา" UniqueName="ctgthanm">
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="del" Text="ลบข้อมูล" UniqueName="del">
                                                                </telerik:GridButtonColumn>
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

                                        </td></tr>

                    
                    </table>
            </div>
              
        </div>
</asp:Content>
