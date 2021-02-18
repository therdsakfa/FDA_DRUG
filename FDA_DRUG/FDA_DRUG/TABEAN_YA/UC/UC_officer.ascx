<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_officer.ascx.vb" Inherits="FDA_DRUG.UC_officer" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table style="width:100%;" class="table">
        <tr>
            <td>
               ชื่อผู้ผลิตต่างประเทศ :  <asp:TextBox ID="txt_search" runat="server" CssClass="input-lg" Width="300px"></asp:TextBox> 
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ประเทศ
                <telerik:RadComboBox ID="rcb_national" Runat="server" Filter="Contains" Height="16px">
                </telerik:RadComboBox> &nbsp;
                <asp:Button ID="btn_search" runat="server" Text="ค้นหา" CssClass="input-lg" />
            </td>
        </tr>
        <tr>
            <td>
             <telerik:RadGrid ID="rg_search_fore" runat="server" AllowPaging="true" PageSize="10">
                <MasterTableView autogeneratecolumns="False" >
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="chk" HeaderText="เลือก">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column" HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="engfrgnnm" FilterControlAltText="Filter engfrgnnm column" HeaderText="ชื่อผู้ผลิต" SortExpression="engfrgnnm" UniqueName="engfrgnnm">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fulladdr2" FilterControlAltText="Filter fulladdr2 column" HeaderText="ที่อยู่" SortExpression="fulladdr2" UniqueName="fulladdr2">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="frgnlctcd" FilterControlAltText="Filter frgnlctcd column" HeaderText="frgnlctcd" SortExpression="frgnlctcd" UniqueName="frgnlctcd" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="frgncd" FilterControlAltText="Filter frgncd column" HeaderText="frgncd" SortExpression="frgncd" UniqueName="frgncd" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="addr_ida" FilterControlAltText="Filter addr_ida column" HeaderText="addr_ida" SortExpression="addr_ida" UniqueName="addr_ida" Display="false">
                        </telerik:GridBoundColumn>
                         
                        <telerik:GridBoundColumn DataField="fulladdr2" FilterControlAltText="Filter fulladdr2 column" HeaderText="ที่อยู่" SortExpression="fulladdr2" UniqueName="fulladdr2" Display="false">
                        </telerik:GridBoundColumn>
                       

                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true" >
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
            </telerik:RadGrid>
            </td>
        </tr>
</table>

<table style="width:100%;" class="table">
    <tr>
        <td align="center">
 
            <asp:Button ID="btn_select" runat="server" Text="เลือก" />
        </td>
    </tr>
</table>

<table style="width:100%;" class="table">
        <tr>
            <td>
                <telerik:RadGrid ID="rg_produccer" runat="server" Width="100%">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                    <Columns>
                       <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column" HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="P_IDA" FilterControlAltText="Filter P_IDA column" HeaderText="P_IDA" SortExpression="P_IDA" UniqueName="P_IDA" Display="false">
                        </telerik:GridBoundColumn>
                        
                        <telerik:GridBoundColumn DataField="engfrgnnm" FilterControlAltText="Filter engfrgnnm column" HeaderText="ชื่อผู้ผลิต" SortExpression="engfrgnnm" UniqueName="engfrgnnm">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="frgnlctcd" FilterControlAltText="Filter frgnlctcd column" HeaderText="frgnlctcd" SortExpression="frgnlctcd" UniqueName="frgnlctcd" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="addr_ida" FilterControlAltText="Filter addr_ida column" HeaderText="addr_ida" SortExpression="addr_ida" UniqueName="addr_ida" Display="false">
                        </telerik:GridBoundColumn>
                         
                        <telerik:GridBoundColumn DataField="fulladdr2" FilterControlAltText="Filter fulladdr2 column" HeaderText="ที่อยู่" SortExpression="fulladdr2" UniqueName="fulladdr2">
                        </telerik:GridBoundColumn>
                       <telerik:GridTemplateColumn UniqueName="work_type" HeaderText="หน้าที่">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="rcb_work_type" runat="server" Filter="Contains" Label="กรุณาเลือก" Width="200px">
                                            <Items>
                                                <telerik:RadComboBoxItem runat="server" Text="ผลิตยาสำเร็จรูป" Value="1" />
                                                <telerik:RadComboBoxItem runat="server" Text="แบ่งบรรจุ" Value="2" />
                                                <telerik:RadComboBoxItem runat="server" Text="ตรวจปล่อยหรือผ่านเพื่อจำหน่าย" Value="3" />
                                                <telerik:RadComboBoxItem runat="server" Text="อื่นๆ" Value="9" />
                                                <telerik:RadComboBoxItem runat="server" Text="ผู้แบ่งบรรจุผลิตภัณฑ์ยาที่ไม่สัมผัสยา" Value="10" />
                                                <telerik:RadComboBoxItem runat="server" Text="ผลิตยาสำเร็จรูป (แห่งที่ 2)" Value="11" />
                                                <telerik:RadComboBoxItem runat="server" Text="แบ่งบรรจุผลิตภัณฑ์ยาที่ไม่สัมผัสยา (แห่งที่ 2)" Value="12" />
                                                <telerik:RadComboBoxItem runat="server" Text="แบ่งบรรจุ (แห่งที่ 2)" Value="13" />
                                                <telerik:RadComboBoxItem runat="server" Text="ตรวจปล่อยหรือผ่านเพื่อจำหน่าย (แห่งที่ 2)" Value="14" />
                                            </Items>
                                        </telerik:RadComboBox>
                                        <asp:Label ID="lbl_work_type" runat="server" Text="" style="display:none;"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_del" HeaderText="ลบรายการ"  ConfirmText="ต้องการลบหรือไม่?"
                            CommandName="_del" Text="ลบ">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            </td>
        </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btn_save_work_type" runat="server" Text="บันทึกหน้าที่ในตาราง" />
        </td>
    </tr>
        </table>