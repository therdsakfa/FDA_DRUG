<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_officer_che.ascx.vb" Inherits="FDA_DRUG.UC_officer_che" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table width="70%">
    <%--<tr>
        <td>
            ส่วนประกอบของยาในตำรับยานี้(ปริมาณ/หน่วย) :
            <asp:TextBox ID="txt_quantity" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddl_unit_head" runat="server">
            </asp:DropDownList>
        </td>
    </tr>--%>
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
                      <asp:DropDownList ID="ddl_unit_each" runat="server"></asp:DropDownList>
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
            <%--ปริมาณต่อหน่วย(ในแต่ละ) &nbsp;<asp:TextBox ID="txt_drg_perunit" runat="server"></asp:TextBox>
&nbsp;<asp:DropDownList ID="ddl_unit1" runat="server"></asp:DropDownList>
        &nbsp;<asp:Button ID="btn_drg_per_unit" runat="server" Text="บันทึกปริมาณต่อหน่วย" />--%>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
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
<%--                        <telerik:GridBoundColumn DataField="aori" FilterControlAltText="Filter aori column" HeaderText="aori" SortExpression="aori" UniqueName="aori">
                        </telerik:GridBoundColumn>--%>
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
                    <td>ปริมาณยา/ปริมาณชีววัตถุ</td>
                    <td>
                        <asp:DropDownList ID="ddl_CAS_TYPE" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="1">ปริมาณยา</asp:ListItem>
                            <asp:ListItem Value="2">ปริมาณชีววัตถุ</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    
                    
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
                    <td>ปริมาณสาร (ตั้งต้น) : </td>
                    <td>
                        <asp:TextBox ID="txt_QTY" runat="server" Width="100px"></asp:TextBox>
                    </td>
                    <td>หน่วย :</td>
                    <td>
                        <asp:DropDownList ID="ddl_unit" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>ปริมาณสาร (สุดท้าย) :</td>
                    <td>
                        <asp:TextBox ID="txt_QTY2" runat="server" Width="100px"></asp:TextBox>
                    </td>
                    <td>หน่วย :</td>
                    <td>
                        <asp:DropDownList ID="ddl_unit4" runat="server"></asp:DropDownList>
                    </td>
                    
                    
                </tr>
                
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>ปริมาณชีววัตถุ</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td></td>
                </tr>
                <tr>
                    <td>ปริมาณตั้งต้น</td>
                    <td>
                        <asp:TextBox ID="txt_sbioqty" runat="server" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        หน่วยตั้งต้น :</td>
                    <td>
                        <asp:DropDownList ID="ddl_unit2" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>เลขยกกำลัง(ตั้งต้น)</td>
                    <td>
                        <asp:TextBox ID="txt_sbiosqno" runat="server" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>ปริมาณสุดท้าย</td>
                    <td>
                        <asp:TextBox ID="txt_ebioqty" runat="server" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        หน่วยสุดท้าย :</td>
                    <td>
                        <asp:DropDownList ID="ddl_unit3" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>เลขยกกำลัง(สุดท้าย)</td>
                    <td>
                        <asp:TextBox ID="txt_ebiosqno" runat="server" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>เอกสารอ้างอิง</td>
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
                    <td >&nbsp;</td>
                    <td >
                        &nbsp;</td>
                    <td >
                        &nbsp;</td>
                    <td >&nbsp;</td>
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
                        &nbsp;</td>
                    <td>&nbsp;</td>
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
                    <td>ลำดับสาร</td>
                    <td>
                        <asp:TextBox ID="txt_ROWS" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btn_select" runat="server" Text="เพิ่มสาร" CssClass="input-lg"/>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

            

        </td>
    </tr>
    <tr>
        <%--<td  bgcolor="Lavender" width="197px" height="28px">สารสำคัญ : </td>--%>
        <td colspan="4">
            <asp:Label ID="lbl_each" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
    <tr>
        <%--<td  bgcolor="Lavender" width="197px" height="28px">สารสำคัญ : </td>--%>
        <td colspan="4">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_up" runat="server" Text="ขึ้น" style="display:none;"  />
                    </td>
                    <td>
                        <asp:Button ID="btn_down" runat="server" Text="ลง" style="display:none;" />
                       <%-- <asp:Button ID="btn_reset_order" runat="server" Text="Reset ลำดับ" />--%>
                    </td>
                    <td>
                        <asp:Button ID="btn_reset" runat="server" Text="รีเซ็ตลำดับ" style="display:none;" />
                    </td>
                </tr>
            </table>

            <telerik:RadGrid ID="rg_chem" runat="server" Width="100%">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                    <Columns>
                         <telerik:GridClientSelectColumn UniqueName="chk" HeaderText="เลือก">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FK_SET" FilterControlAltText="Filter FK_SET column" HeaderText="สูตรที่"
                            SortExpression="FK_SET" UniqueName="FK_SET" >
                        </telerik:GridBoundColumn>
                        <%--<telerik:GridBoundColumn DataField="ROWS" FilterControlAltText="Filter ROWS column" HeaderText="ลำดับ"
                            SortExpression="ROWS" UniqueName="ROWS" >
                        </telerik:GridBoundColumn>--%>
                          <telerik:GridTemplateColumn UniqueName="ROWS" HeaderText="ลำดับ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_rows" runat="server" Width="20px"></asp:TextBox>
                                        <asp:Label ID="lbl_rows" runat="server" Text="" style="display:none;"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                        <telerik:GridBoundColumn DataField="iowanm" FilterControlAltText="Filter iowanm column"
                            HeaderText="ชื่อสาร" SortExpression="iowanm" UniqueName="iowanm">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QTY" FilterControlAltText="Filter QTY column" HeaderText="ปริมาณ" SortExpression="QTY" UniqueName="QTY">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="sunitthanm" FilterControlAltText="Filter sunitthanm column" HeaderText="หน่วย" SortExpression="sunitthanm" UniqueName="sunitthanm">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="REF" FilterControlAltText="Filter REF column" HeaderText="เอกสารอ้างอิง" SortExpression="REF" UniqueName="REF">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="AORI" FilterControlAltText="Filter AORI column" HeaderText="A/I" SortExpression="AORI" UniqueName="AORI">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="REMARK" FilterControlAltText="Filter REMARK column" HeaderText="หมายเหตุ" SortExpression="REMARK" UniqueName="REMARK">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_eqto" HeaderText="EQTO" 
                            CommandName="_eqto" Text="EQTO">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_del" HeaderText="ลบรายการ"  ConfirmText="ต้องการลบหรือไม่?"
                            CommandName="_del" Text="ลบ">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true" >
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
            </telerik:RadGrid>
        </td>
    </tr>
    <tr>
        <td colspan="4" align="center">

            <asp:Button ID="btn_rows_save" runat="server" Text="บันทึกลำดับ" />

        </td>
    </tr>
    <%-- <tr>
        <td bgcolor="Lavender" width="197px" height="28px">สารย่อย : </td>
        <td  ><asp:Label ID="lb_NoReport_pop" runat="server"  Width="438px" Height="30px"></asp:Label></td>
    </tr>--%>
</table>