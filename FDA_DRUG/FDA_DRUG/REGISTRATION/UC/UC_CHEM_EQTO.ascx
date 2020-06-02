<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_CHEM_EQTO.ascx.vb" Inherits="FDA_DRUG.UC_CHEM_EQTO" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .p {
    border: 1px solid;
}
    </style>
<table width="70%">

    <tr>
        <td>
            สูตร :
            <asp:Label ID="lbl_cas" runat="server" Text="-"></asp:Label>
        </td>
    </tr>

    <tr>
        <td>
            <asp:TextBox ID="txt_search" runat="server"></asp:TextBox><asp:Button ID="btn_search" runat="server" Text="ค้นหาสาร" />
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadGrid ID="rg_search_iowa" runat="server" AllowPaging="true" PageSize="10">
                <MasterTableView autogeneratecolumns="False" >
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="chk" HeaderText="เลือก">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="iowacd" FilterControlAltText="Filter iowacd column" HeaderText="iowacd" SortExpression="iowacd" UniqueName="iowacd">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iowanm" FilterControlAltText="Filter iowanm column" HeaderText="ชื่อสาร" SortExpression="iowanm" UniqueName="iowanm">
                        </telerik:GridBoundColumn>

                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true" >
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
            </telerik:RadGrid>

        </td>
    </tr>

    <tr>
        <td align="center">
            <table width="800px">
                <tr>
                    <td colspan="4" align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" align="left">กรุณาเลือกสารจากตารางด้านบนก่อนคลิกปุ่มเพิ่มสาร</td>
                </tr>
                 <tr>
                    <td>เงื่อนไข</td>
                    <td colspan="3" align="left">
                        <asp:DropDownList ID="ddl_remark1" runat="server">
                            <asp:ListItem Value="0">กรุณาเลือก</asp:ListItem>
                            <asp:ListItem Value="1">&lt;=</asp:ListItem>
                            <asp:ListItem Value="2">&lt;</asp:ListItem>
                            <asp:ListItem Value="3">=</asp:ListItem>
                            <asp:ListItem Value="4">&gt;=</asp:ListItem>
                            <asp:ListItem Value="5">&gt;</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>ปริมาณสาร: </td>
                    <td>
                        <asp:TextBox ID="txt_QTY" runat="server" Width="100px"></asp:TextBox>
                    </td>
                    <td>หน่วย :</td>
                    <td>
                        <%--<asp:DropDownList ID="ddl_unit" runat="server" Height="16px"></asp:DropDownList>--%>
                        <telerik:RadComboBox ID="rcb_unit" Runat="server" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                    
                    
                </tr>
                <tr>
                    <td>ประเภทสาร A/I :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_aori" runat="server">
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>I</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btn_select" runat="server" Text="เพิ่มสาร" CssClass="input-lg"/>
                        <asp:Button ID="btn_edit" runat="server" Text="บันทึกการแก้ไข" Style="display:none;"  />
                        <asp:Button ID="btn_close_edit" runat="server" Text="ปิดการแก้ไข"  Style="display:none;"/>
                    </td>
                </tr>
            </table>

            

        </td>
    </tr>

    <tr>
 
        <td>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <telerik:RadGrid ID="rg_chem" runat="server" Width="100%">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ROWS" FilterControlAltText="Filter ROWS column" HeaderText="ลำดับ"
                            SortExpression="ROWS" UniqueName="ROWS" Display="false">
                        </telerik:GridBoundColumn>
                        <%--<telerik:GridBoundColumn DataField="iowacd" FilterControlAltText="Filter iowacd column" HeaderText="iowacd"
                            SortExpression="iowacd" UniqueName="iowacd" Display="false">
                        </telerik:GridBoundColumn>--%>
                        <telerik:GridBoundColumn DataField="iowanm" FilterControlAltText="Filter iowanm column"
                            HeaderText="ชื่อสาร" SortExpression="iowanm" UniqueName="iowanm" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn UniqueName="iowanm2" HeaderText="ชื่อสาร">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="rcb_iowanm" runat="server" filter="Contains"></telerik:RadComboBox>
                                        <asp:Label ID="lbl_iowanm" runat="server" Text="" style="display:none;"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                       <%-- <telerik:GridBoundColumn DataField="QTY" FilterControlAltText="Filter QTY column" HeaderText="ปริมาณ" DataType="System.Decimal" SortExpression="QTY" UniqueName="QTY">
                        </telerik:GridBoundColumn>--%>
                         <telerik:GridTemplateColumn UniqueName="QTY" HeaderText="ปริมาณ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_QTY2" runat="server" Width="90px"></asp:TextBox>
                                        <asp:Label ID="lbl_QTY" runat="server" Text="" style="display:none;"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                        <telerik:GridBoundColumn DataField="sunitengnm" FilterControlAltText="Filter sunitengnm column" HeaderText="หน่วย" SortExpression="sunitengnm" UniqueName="sunitengnm">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="AORI" FilterControlAltText="Filter AORI column" HeaderText="A/I ตัวยา (Base Form)" SortExpression="AORI" UniqueName="AORI">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CONDITION_ALL" FilterControlAltText="Filter CONDITION_ALL column" HeaderText="เงื่อนไข" SortExpression="CONDITION_ALL" UniqueName="CONDITION_ALL">
                        </telerik:GridBoundColumn>
                         <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_edit"  CommandName="_edit" HeaderText="แก้ไข"  Text="แก้ไข" Visible="false">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
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
            <table width="100%">
                <tr>
                    <td><asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" /></td>
                    <td><asp:Button ID="btn_save_cas" runat="server" Text="บันทึกสารที่เลือก" Style="display:none;" /></td>
                    <td><asp:Button ID="btn_save_qty" runat="server" Text="บันทึกปริมาณสาร"  /></td>
                </tr>
            </table>
            
            
             
        </td>
    </tr>
</table>