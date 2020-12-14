<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_CHEMICAL_STAFF_COMFIRM_TEXT.aspx.vb" Inherits="FDA_DRUG.FRM_CHEMICAL_STAFF_COMFIRM_TEXT" %>
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
                   <asp:Panel ID="Panel2" runat="server" GroupingText="ตรวจสอบชื่อสาร">
<table class="table">
                        <tr>
                            <td>ชื่อสาร</td>
                            <td>
                                <asp:Label ID="lbl_iowanm" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>CAS NO.</td>
                            <td>
                                <asp:Label ID="lbl_casno" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>aori</td>
                            <td>
                                <asp:Label ID="lbl_aori" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="Panel3" runat="server">
                                
                                <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="false" GridLines="None" width="100%">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="RowNumber" HeaderText="ลำดับ" UniqueName="RowNumber">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="IDA" Display="false" HeaderText="IDA" UniqueName="IDA">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FK_IDA" Display="false" HeaderText="FK_IDA" UniqueName="FK_IDA">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="iowanm" HeaderText="ชื่อสาร" UniqueName="iowanm">
                                            </telerik:GridBoundColumn>
                                            <%--   <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="del" Text="ลบข้อมูล" UniqueName="del">
                                            </telerik:GridButtonColumn>--%>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                                    </asp:Panel>
                            </td>
                        </tr>

                    </table>
                
                <table class="table">
                    <tr>
                        <td>

                            ชื่อสารที่ต้องการค้นหา</td>
                        <td>

                            <asp:TextBox ID="txt_search" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>

                        </td>
                        <td>

                            <asp:Button ID="btn_search" runat="server" Text="ค้นหา" CssClass="btn-lg" />

                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="10">
                                <MasterTableView autogeneratecolumns="False" datakeynames="IDA">
                                    <Columns>
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
                                        <telerik:GridBoundColumn DataField="REGIS_STATUS" FilterControlAltText="Filter REGIS_STATUS column"
                                            HeaderText="REGIS_STATUS" SortExpression="REGIS_STATUS" UniqueName="REGIS_STATUS">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="INN" FilterControlAltText="Filter INN column"
                                            HeaderText="INN" SortExpression="INN" UniqueName="INN">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="INN_TH" FilterControlAltText="Filter INN_TH column"
                                            HeaderText="INN_TH" SortExpression="INN_TH" UniqueName="INN_TH">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
                   </asp:Panel>
                
                <br />

                <asp:Panel ID="Panel1" runat="server" GroupingText="รายละเอียดสาร">
                    <table class="table" style="width:100%;">
                    <tr ><td>ชื่อสาร</td><td>
                        <asp:TextBox ID="txt_iowanm" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                        </td></tr>
                        <tr>
                            <td>CAS NO.</td>
                            <td>
                                <asp:TextBox ID="txt_Cas_number" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
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
                            <td>aori</td>
                            <td>
                                <asp:DropDownList ID="ddl_aori" runat="server" CssClass="input-lg" Width="150px">
                                    <asp:ListItem Value="">กรุณาเลือก</asp:ListItem>
                                    <asp:ListItem Value="A">A</asp:ListItem>
                                    <asp:ListItem Value="I">I</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>iowacd</td>
                            <td><%--<asp:TextBox ID="txt_iowacd" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>--%>
                                <asp:TextBox ID="txt_iowacd" runat="server" CssClass="input-sm" Width="300px" MaxLength="6"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Run NO.</td>
                            <td>
                                <asp:TextBox ID="txt_runno" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>salt</td>
                            <td>
                                <asp:TextBox ID="txt_salt" runat="server" CssClass="input-sm" Width="300px" MaxLength="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>syn</td>
                            <td>
                                <asp:TextBox ID="txt_syn" runat="server" CssClass="input-sm" Width="300px" MaxLength="2"></asp:TextBox>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td>iowa</td>
                            <td>
                                <asp:TextBox ID="txt_iowa" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                                <asp:DropDownList ID="ddl_iowa" runat="server" DataTextField="IOWA" DataValueField="IDA" CssClass="input-lg" Width="300px" style="display:none;">
                                </asp:DropDownList>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>dv</td>
                            <td>
                                <asp:TextBox ID="txt_dv" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>เป็นสารในทะเบียน</td>
                            <td>
                                <asp:DropDownList ID="ddl_Regis" runat="server">
                                    <asp:ListItem Value="R">เป็นสารในทะเบียนผลิต</asp:ListItem>
                                    <asp:ListItem Value="N">ไม่เป็นสารในทะเบียนผลิต</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Look Type</td>
                            <td>
                                <asp:DropDownList ID="ddl_Look" runat="server" CssClass="input-lg" Width="300px">
                                    <asp:ListItem Selected="True">Look</asp:ListItem>
                                    <asp:ListItem>No Look</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>MODERN TRADITION</td>
                            <td>
                                <asp:DropDownList ID="ddl_Modern_drug" runat="server" CssClass="input-lg" Width="150px">
                                    <asp:ListItem Value="M">Modern Only</asp:ListItem>
                                    <asp:ListItem Value="H">Traditional Only</asp:ListItem>
                                    <asp:ListItem Value="B">Both</asp:ListItem>
                                    <asp:ListItem Value="T">TEMP</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>มี ATC</td>
                            <td>
                                <asp:CheckBox ID="cb_IS_ATC" runat="server" AutoPostBack="true" />
                                &nbsp;(ถ้ามี)
                                <asp:TextBox ID="txt_ATC" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        
                        
                        
                    </table>
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
                
            </div>
            </td>
             <td style="padding-left:10%;height:50%;" valign="top">

                 <table class="table" style="width:90%"> 
                     
                     <tr><td>
                         <asp:DropDownList ID="ddl_cnsdcd" runat="server"  Width="80%" DataTextField="STATUS_NAME" DataValueField="STATUS_ID">
                         </asp:DropDownList>
                         </td></tr>
                     
                     <tr><td>
                         วันที่
                         <asp:TextBox ID="txt_app_date" runat="server"></asp:TextBox>
                         </td></tr>
                     
                     <tr><td><asp:Button ID="btn_confirm" runat="server" Text="ยืนยัน" CssClass="btn-lg"   Width="80%" /></td></tr>
                     <tr><td>  <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg"   Width="80%" /></td></tr>

                 </table>
                 


                 <uc1:UC_GRID_ATTACH ID="UC_GRID_ATTACH1" runat="server" />
                 
                 <table class="table" style="width:100%;">
                    <tr>
                        <td style="width:40%;">
                            Email</td>
                        <td>

                            <asp:Label ID="lbl_email" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:40%;">
                            เบอร์โทรศัพท์</td>
                        <td>

                            <asp:Label ID="lbl_mobile" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
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
