<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_CHEMICAL_MAIN_INSERT_AND_UPDATE.aspx.vb" Inherits="FDA_DRUG.FRM_CHEMICAL_MAIN_INSERT_AND_UPDATE" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <div class="panel-heading panel-title">
                <h1>เพิ่มสาร
                </h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr ><td>วันที่</td><td>
                        <asp:Label ID="lbl_date" runat="server" Text="-"></asp:Label>
                        </td></tr>
                    <tr ><td>ชื่อสาร</td><td>
                        <asp:TextBox ID="Txt_Name" runat="server" CssClass="input-lg" Width="300px"></asp:TextBox>
                        </td></tr>
                    <tr ><td>รายละเอียดเพิ่มเติม</td><td>
                        <asp:TextBox ID="txt_description" runat="server" CssClass="input-lg" Width="300px" TextMode="MultiLine" Height="80px"></asp:TextBox>
                        </td></tr>
                    <tr ><td>CAS NUMBER</td><td>
                        <asp:TextBox ID="txt_cas" runat="server" CssClass="input-lg" Width="300px"></asp:TextBox>
                        </td></tr>
                    <tr>
                            <td>INN</td>
                            <td>
                                <asp:TextBox ID="txt_INN" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                    <tr>
                            <td>INN TH</td>
                            <td>
                                <asp:TextBox ID="txt_INN_TH" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                    <tr>
                            <td>Email สำหรับติดต่อ</td>
                            <td>
                                <asp:TextBox ID="txt_EMAIL" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                    <tr>
                            <td>เบอร์โทรศัพท์ติดต่อ</td>
                            <td>
                                <asp:TextBox ID="txt_TEL" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                    <tr>
                            <td>แนบเอกสารเพิ่มเติม</td>
                            <td>
                                <table style="width:100%;">
                                    <tr>
                                        <td colspan="2"><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                                       
                                    </tr>
                                    <tr>
                                        <td>
                                            <%--<asp:LinkButton ID="hp_file_name" runat="server" style="display:none;" />--%>
                                            <asp:HyperLink ID="hp_file_name" runat="server" style="display:none;" Target="_blank"></asp:HyperLink>
                                        </td>
                                      
                                        <td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/file_delete.png" Width="28px" Height="28px"
                                                 ToolTip="ลบข้อมูล" style="display:none;" OnClientClick="return confirm('ต้องการลบหรือไม่');" />
                                        </td>
                                      
                                    </tr>
                                </table>
                                
                            </td>
                        </tr>
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
                            <br />
                            <asp:Panel ID="Panel2" runat="server">
<table class="table" style="width:100%;">
                    <tr>
                        <td>

                            สารอยู่ในประกาศกระทรวงพาณิชย์ 16 รายการ</td>
                        <td>

                            <asp:DropDownList ID="ddl_chem16" runat="server" CssClass="input-lg" Width="300px">
                            </asp:DropDownList>

                        </td>
                        <td>

                            <asp:Button ID="btn_add_statndard" runat="server" Text="เพิ่มข้อมูล" CssClass="btn-lg" />

                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <telerik:RadGrid ID="RadGrid3" runat="server" AllowPaging="true" PageSize="10">
                                <MasterTableView autogeneratecolumns="False" datakeynames="IDA">
                                    <Columns>
                                         <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                            HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                                        </telerik:GridBoundColumn>
                                        
                                        <telerik:GridBoundColumn DataField="CHEM_NAME" FilterControlAltText="Filter CHEM_NAME column"
                                            HeaderText="ชื่อสาร" SortExpression="CHEM_NAME" UniqueName="iowanm">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="del" UniqueName="del" Text="ลบ">

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
                    <tr >
                        
                        
                        <td colspan="2">
                            <asp:Panel ID="Panel1" runat="server">

                                <table class="table" style="width:100%;">
                                    <tr>
                                        <td>พิมพ์ชื่อสารที่ต้องการค้นหา</td>
                                        <td>

                                            <asp:TextBox ID="txt_search" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>

                                        </td>
                                        <td>

                                            <asp:Button ID="btn_search" runat="server" Text="ค้นหา" CssClass="btn-lg" />

                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <telerik:RadGrid ID="RadGrid2" runat="server" AllowPaging="true" PageSize="10" AllowMultiRowSelection="true">
                                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                                                    <Columns>
                                                        <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn1">
                                                        </telerik:GridClientSelectColumn>
                                                        <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                                            HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                                                        </telerik:GridBoundColumn>
                                                         <telerik:GridBoundColumn DataField="iowa" FilterControlAltText="Filter iowa column"
                                                            HeaderText="iowa" SortExpression="iowa" UniqueName="iowa">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="cas_number" FilterControlAltText="Filter cas_number column"
                                                            HeaderText="CAS NO." SortExpression="cas_number" UniqueName="cas_number">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridBoundColumn DataField="iowanm" FilterControlAltText="Filter iowanm column"
                                                            HeaderText="ชื่อสาร" SortExpression="iowanm" UniqueName="iowanm">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="iowacd" FilterControlAltText="Filter iowacd column"
                                                            HeaderText="iowacd" SortExpression="iowacd" UniqueName="iowacd">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="runno" FilterControlAltText="Filter runno column"
                                                            HeaderText="runno" SortExpression="runno" UniqueName="runno">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="salt" FilterControlAltText="Filter salt column"
                                                            HeaderText="salt" SortExpression="salt" UniqueName="salt">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="syn" FilterControlAltText="Filter syn column"
                                                            HeaderText="syn" SortExpression="syn" UniqueName="syn">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="aori" FilterControlAltText="Filter aori column"
                                                            HeaderText="aori" SortExpression="aori" UniqueName="aori">
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                </MasterTableView>
                                                <ClientSettings>
                                                    <Selecting AllowRowSelect="true"></Selecting>
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>

                                <%--<table>

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
                                            &nbsp;</td>
                                    </tr>
                                </table>--%>


                            <table width="100%">
                                <tr>
                                    <td align="right">

                                        <asp:Button ID="btn_add" runat="server" CssClass="btn-lg" Text="เพิ่มสารย่อย" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                        <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" width="100%" ShowFooter="true" AutoGenerateColumns="false">
                                            <MasterTableView>
                        <Columns>
                            
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="IDA_MAIN" HeaderText="IDA_MAIN" DataField="IDA_MAIN" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="FK_IDA" HeaderText="FK_IDA" DataField="FK_IDA" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="iowanm" HeaderText="ชื่อสาร" DataField="iowanm" >
                            </telerik:GridBoundColumn>                           
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" ConfirmText="คุณต้องการลบหรือไม่" CommandName="del" >
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
