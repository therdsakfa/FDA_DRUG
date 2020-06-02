<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF_DRUG_POPUP.Master" CodeBehind="FRM_REPLACEMENT_DRUG_BOOKING_ADDRESS.aspx.vb" Inherits="FDA_DRUG.FRM_REPLACEMENT_DRUG_BOOKING_ADDRESS" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="../UC/UC_SEARCH_thanameplace.ascx" tagname="UC_SEARCH_thanameplace" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="h3">สถานที่ตั้ง</p>
                  <uc1:UC_SEARCH_thanameplace ID="UC_SEARCH_thanameplace1" runat="server" />
              <div style="text-align:center;">  <asp:Button ID="btn_thanameplace" runat="server" Text="ค้นหาสถานที่" /></div> 
                <hr />
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" CellSpacing="0" GridLines="None">
<MasterTableView autogeneratecolumns="False" datakeynames="IDA">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="lcnsid" DataType="System.Int32" FilterControlAltText="Filter lcnsid column" HeaderText="lcnsid" 
            SortExpression="lcnsid" UniqueName="lcnsid" Display="false">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="rcvno" DataType="System.Int32" FilterControlAltText="Filter rcvno column" 
                          HeaderText="เลขรับ" SortExpression="rcvno" UniqueName="rcvno"  Display="false">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="rcvdate"  DataFormatString="{0:d}" DataType="System.DateTime" FilterControlAltText="Filter rcvdate column" HeaderText="วันที่รับ" SortExpression="rcvdate" UniqueName="rcvdate"  Display="false">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        
                 <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                      HeaderText="ชื่อสถานที่" SortExpression="thanameplace" UniqueName="thanameplace">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="tel" FilterControlAltText="Filter tel column" HeaderText="เบอร์โทรศัพท์" ReadOnly="True" SortExpression="tel" UniqueName="tel">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
               <telerik:GridBoundColumn DataField="fax" FilterControlAltText="Filter fax column" HeaderText="เบอร์โทรสาร" ReadOnly="True" SortExpression="fax" UniqueName="fax">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="XMLNAME" FilterControlAltText="Filter XMLNAME column" HeaderText="TranscestionID" SortExpression="XMLNAME" UniqueName="XMLNAME"  Display="false">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>


        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
             HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
             HeaderText="FK_IDA" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
             HeaderText="TR_ID" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DOWN_ID" DataType="System.Int32" FilterControlAltText="Filter DOWN_ID column" 
            HeaderText="DOWN_ID" SortExpression="DOWN_ID" UniqueName="DOWN_ID" Display="false">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CITIZEN_ID" FilterControlAltText="Filter CITIZEN_ID column" HeaderText="CITIZEN_ID"
             SortExpression="CITIZEN_ID" UniqueName="CITIZEN_ID" Display="false">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CITIZEN_ID_UPLOAD" FilterControlAltText="Filter CITIZEN_ID_UPLOAD column" 
            HeaderText="CITIZEN_ID_UPLOAD" SortExpression="CITIZEN_ID_UPLOAD" UniqueName="CITIZEN_ID_UPLOAD" Display="false">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>

 
                <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column" 
            HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME"  Display="false">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>

        <telerik:GridBoundColumn DataField="lctcd" DataType="System.Int32" FilterControlAltText="Filter lctcd column" HeaderText="lctcd" 
            SortExpression="lctcd" UniqueName="lctcd" Display="false">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
      
             <telerik:GridTemplateColumn>
            <ItemTemplate>
                  <asp:Button ID="btn_SELECT" runat="server" Text="เลือกข้อมูล" CommandName="sel" />
            </ItemTemplate>
        </telerik:GridTemplateColumn>

    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
</MasterTableView>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
           </telerik:RadGrid>

            </td>
        </tr>
          <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
        </div>
</asp:Content>

