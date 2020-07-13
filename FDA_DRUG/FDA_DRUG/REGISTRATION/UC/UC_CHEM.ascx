<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_CHEM.ascx.vb" Inherits="FDA_DRUG.UC_CHEM" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .p {
    border: 1px solid;
}
    .auto-style1 {
        height: 30px;
    }
    </style>
<table width="70%">

    <tr>
        <td>
            ระบุปริมาณที่ใช้เป็น 1 หน่วย</td>
    </tr>

    <tr>
        <td>
          <table>
              <tr>
                  <td>
                      Each
                  </td>
                  <td>
                      <asp:TextBox ID="txt_each" runat="server"></asp:TextBox>
                  </td>
                  <td>
                      <asp:DropDownList ID="ddl_unit" runat="server"></asp:DropDownList>
                  </td>
                  <td>Contains;</td>
                  <td>ของสูตรที่</td>
                  <td>
                        <asp:DropDownList ID="ddl_set_each" runat="server" AutoPostBack="True" Width="90px">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                  <td>
                      <asp:Button ID="btn_save" runat="server" Text="บันทึก" />
                  </td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td>
                      <asp:TextBox ID="txt_each_txt" runat="server"></asp:TextBox>
                  </td>
                  <td>
                      (คำบรรยาย)</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>
                        &nbsp;</td>
                  <td>
                      &nbsp;</td>
              </tr>
          </table>
        </td>
    </tr>

    <tr>
        <td>
            &nbsp;</td>
    </tr>

    <tr>
        <td>
            ระบุส่วนประกอบของตำรับ</td>
    </tr>

    <tr>
        <td>
            <asp:TextBox ID="txt_search" runat="server"></asp:TextBox><asp:Button ID="btn_search" runat="server" Text="ค้นหาสาร" />
            <asp:Button ID="btn_rqt" runat="server" OnClientClick="alert('ส่งเมลไปที่ drug-smarthelp@fda.moph.go.th หรือ แนบ cpp');" Text="การขอเพิ่มสาร" />
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
                    <td>ปริมาณสาร: </td>
                    <td>
                        <asp:TextBox ID="txt_QTY" runat="server" Width="100px" ></asp:TextBox>
                    </td>
                    <td>หน่วย :</td>
                    <td>
                        <%--<asp:DropDownList ID="ddl_unit" runat="server" Height="16px"></asp:DropDownList>--%>
                        <telerik:RadComboBox ID="rcb_unit" Runat="server" Filter="Contains">
                        </telerik:RadComboBox>
                    </td>
                    
                    
                </tr>
                <tr>
                    <td align="left">เอกสารอ้างอิง</td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txt_ref" runat="server" Width="100%"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td >หมายเหตุ</td>
                    <td align="left"  colspan="3">
                        <asp:TextBox ID="txt_remark" runat="server" Width="100%"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>สูตรที่</td>
                    <td>
                        <asp:DropDownList ID="ddl_set" runat="server" AutoPostBack="True" Width="90px">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
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
                    </td>
                </tr>
            </table>

            

        </td>
    </tr>
    <tr>
        <td>

        </td>
    </tr>
    <tr>
        <td>

            รายละเอียดสูตร/ส่วนประกอบที่บันทึกข้อมูล</td>
    </tr>
    <tr>
        <td>

            <asp:Label ID="lbl_each" runat="server" Text="-"></asp:Label>

        </td>
    </tr>
    <tr>
 
        <td>
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
                        <telerik:GridBoundColumn DataField="REF" FilterControlAltText="Filter REF column" HeaderText="เอกสารอ้างอิง" SortExpression="REF" UniqueName="REF">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="REMARK" FilterControlAltText="Filter REMARK column" HeaderText="หมายเหตุ" SortExpression="REMARK" UniqueName="REMARK">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_eqto" HeaderText="EQ TO" 
                            CommandName="_eqto" Text="EQTO">
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
        <td align="center" class="auto-style1">
            <table width="100%">
                <tr>
                    <td><asp:Button ID="btn_save_cas" runat="server" Text="บันทึกสารที่เลือก" Style="display:none;" /></td>
                    <td> <asp:Button ID="btn_save_qty" runat="server" Text="บันทึกปริมาณสาร" /></td>
                </tr>
            </table>
            
            

        </td>
    </tr>
</table>