<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_officer_in_country.ascx.vb" Inherits="FDA_DRUG.officer_in_country" %>

      <table style="background-color: white;display:none;" border="1">

    <tr>
        <td bgcolor="Lavender" width="197px" height="28px">ผู้ผลิตในประเทศ</td>
        <td ><asp:Label ID="Lb_in_frgn" runat="server" Text ="-"></asp:Label></td>
    </tr>
    <tr>
        <td bgcolor="Lavender" width="197px" height="28px">ผู้ผลิตต่างประเทศ : </td>
        <td> <asp:Label ID="Lb_frgn" runat="server"></asp:Label></td>
    </tr>
           <tr>
        <td bgcolor="Lavender" width="197px" height="28px">ผู้รับอนุญาต : </td>
        <td> <asp:Label ID="lb_licen" runat="server"></asp:Label></td>
    </tr>
    </table>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
    

    <table class="table" style="width:100%;">
          <tr>
            <td style="width:25%;"></td>
            <td style="width:25%;">เลขใบอนุญาต</td>
            <td style="width:25%;">
                <asp:TextBox ID="txt_NUM" runat="server"  CssClass="input-lg" ></asp:TextBox></td>
            <td style="width:25%;">
                </td>
        </tr>
          <tr>
            <td  colspan="4" style="text-align:center;">
                 <asp:Button ID="btn_SEARCH" runat="server" Text="ค้นหา" CssClass="input-lg" />

            </td>
          
        </tr>
          <tr>
            <td colspan="4">
                

                 <br />
                 <p class="h3">ใบอนุญาต</p>
                <hr />
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridClientSelectColumn UniqueName="chk" HeaderText="เลือก">
                        </telerik:GridClientSelectColumn>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="lcnno_no" FilterControlAltText="Filter lcnno_no column"
                           HeaderText="เลขที่ใบอนุญาต" SortExpression="lcnno_no" UniqueName="lcnno_no">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="lcntpcd" FilterControlAltText="Filter lcntpcd column"
                           HeaderText="ประเภท" SortExpression="lcntpcd" UniqueName="lcntpcd">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="thanm_addr" FilterControlAltText="Filter thanm_addr column"
                           HeaderText="ที่อยู่" SortExpression="thanm_addr" UniqueName="thanm_addr">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="lcnsid" FilterControlAltText="Filter lcnsid column"
                           HeaderText="รหัสผู้ประกอบการ" SortExpression="lcnsid" UniqueName="lcnsid">
                       </telerik:GridBoundColumn>
                   </Columns>
               </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="true" >
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
           </telerik:RadGrid>
<table style="width:100%;" class="table">
    <tr>
        <td align="center">
            <asp:Button ID="btn_select" runat="server" Text="เลือก" CssClass="input-lg" />
        </td>
    </tr>
    <tr>
        <td>
            รายการผู้ผลิตที่เลือก</td>
    </tr>
    <tr>
        <td align="center">
                <telerik:RadGrid ID="RadGrid2" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="LCNNO_MANUAL" FilterControlAltText="Filter LCNNO_MANUAL column"
                           HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO_MANUAL" UniqueName="LCNNO_MANUAL">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="lcntpcd" FilterControlAltText="Filter lcntpcd column"
                           HeaderText="ประเภท" SortExpression="lcntpcd" UniqueName="lcntpcd">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column"
                           HeaderText="ที่อยู่" SortExpression="fulladdr" UniqueName="fulladdr">
                       </telerik:GridBoundColumn>
                       <%--<telerik:GridBoundColumn DataField="PRODUCER_WORK_NAME" FilterControlAltText="Filter PRODUCER_WORK_NAME column"
                           HeaderText="หน้าที่" SortExpression="PRODUCER_WORK_NAME" UniqueName="PRODUCER_WORK_NAME">
                       </telerik:GridBoundColumn>--%>
                       <telerik:GridTemplateColumn UniqueName="work_type" HeaderText="หน้าที่">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="rcb_work_type" runat="server" Filter="Contains" Label="กรุณาเลือก" Width="200px">
                                            <Items>
                                                <telerik:RadComboBoxItem runat="server" Text="ผลิตยาสำเร็จรูป" Value="1" />
                                                <telerik:RadComboBoxItem runat="server" Text="แบ่งบรรจุ" Value="2" />
                                                <telerik:RadComboBoxItem runat="server" Text="ตรวจปล่อยหรือผ่านเพื่อจำหน่าย" Value="3" />
                                                <telerik:RadComboBoxItem runat="server" Text="อื่นๆ" Value="9" />
                                                <telerik:RadComboBoxItem runat="server" Text="แบ่งบรรจุผลิตภัณฑ์ยาที่ไม่สัมผัสยา" Value="10" />
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
    </table>