<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_recipe.ascx.vb" Inherits="FDA_DRUG.UC_recipe" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

  <table>
      <tr>
          <td>กลุ่มตำรับ</td>
          <td>
              <telerik:RadComboBox ID="rcb_atc" runat="server" Height="300px" Width="305" DataValueField="atc_code" DataTextField="atcnm"
                  EmptyMessage="กรุณาเลือกกลุ่มตำรับ"  Filter="Contains">
              </telerik:RadComboBox>
          </td>
          <td>
              <asp:Button ID="btn_atc" runat="server" Text="เพิ่มกลุ่มตำรับ" />
          </td>
      </tr>
      <tr>
          <td colspan="3">
              <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="false" GridLines="None" ShowFooter="true" Width="100%">
                  <MasterTableView>
                      <Columns>
                          <telerik:GridBoundColumn DataField="RowNumber" HeaderText="ลำดับ" UniqueName="RowNumber" Display="false">
                          </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="IDA" Display="false" HeaderText="IDA" UniqueName="IDA">
                          </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="FK_IDA" Display="false" HeaderText="FK_IDA" UniqueName="FK_IDA">
                          </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="atccd" HeaderText="รหัส" UniqueName="atccd">
                          </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="atcnm" HeaderText="กลุ่มตำรับ" UniqueName="atcnm">
                          </telerik:GridBoundColumn>
                          <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="del" Text="ลบข้อมูล" UniqueName="del" ConfirmText="ต้องการลบข้อมูลหรือไม่?">
                          </telerik:GridButtonColumn>
                      </Columns>
                  </MasterTableView>
              </telerik:RadGrid>
          </td>
      </tr>
  </table>