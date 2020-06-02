<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DRUG_DOCUMENT_UPLOAD.ascx.vb" Inherits="FDA_DRUG.UC_DRUG_DOCUMENT_UPLOAD" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table class="table" style="width: 100%;">
    <tr>
        <td>
            <table style="width: 100%;">
               <tr>
                   <td style="width: 55%;">
                       <h2>เอกสารกำกับยาสำหรับบุคลากรทางการแพทย์ (SPC)
                       </h2>
                       </td>
                   <td valign="center">
                       <div style="text-align: right; padding-left: 0%; height: 60px;">
                           <asp:Button ID="btn_download_t" runat="server" Text="ดาวน์โหลดคำขอ" CssClass="btn-lg" />
                           &nbsp;&nbsp;
                           &nbsp;&nbsp;
       <asp:Button ID="btn_upload_t" runat="server" Text="อัพโหลดคำขอ" CssClass="btn-lg" />
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
                           <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
                       </div>
                   </td>
               </tr>
           </table>
            <telerik:RadGrid ID="rg_spc" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
                <MasterTableView AutoGenerateColumns="False">
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                        </telerik:GridBoundColumn>             
                        <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column" HeaderText="TR_ID"
                            SortExpression="TR_ID" UniqueName="TR_ID" Display="false" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="trans_code" FilterControlAltText="Filter trans_code column"
                            HeaderText="รหัสการดำเนินการ" SortExpression="trans_code" UniqueName="trans_code">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="UPLOAD_DATE" DataFormatString="{0:d}" FilterControlAltText="Filter UPLOAD_DATE column"
                           HeaderText="วันที่ยื่นคำขอ" SortExpression="UPLOAD_DATE" UniqueName="UPLOAD_DATE">
                       </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="stat" FilterControlAltText="Filter stat column"
                           HeaderText="สถานะ" SortExpression="stat" UniqueName="stat">
                       </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                            CommandName="sel" Text="ดูข้อมูล">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </td>
    </tr>

</table>

<br />
<br />

<table class="table" style="width: 100%;">
    <tr>
        <td>
            <table style="width: 100%;">
               <tr>
                   <td style="width: 55%;">
                       <h2>เอกสารกำกับยาสำหรับประชาชน (PIL)
                       </h2>
                       </td>
                   <td valign="center">
                       <div style="text-align: right; padding-left: 0%; height: 60px;">
                           <asp:Button ID="btn_download_PIL" runat="server" Text="ดาวน์โหลดคำขอ" CssClass="btn-lg" />
                           &nbsp;&nbsp;
                           &nbsp;&nbsp;
       <asp:Button ID="btn_upload_PIL" runat="server" Text="อัพโหลดคำขอ" CssClass="btn-lg" />
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       </div>
                   </td>
               </tr>
           </table>
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
                <MasterTableView AutoGenerateColumns="False">
                    <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                        </telerik:GridBoundColumn>             
                        <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column" HeaderText="TR_ID"
                            SortExpression="TR_ID" UniqueName="TR_ID" Display="false" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="trans_code" FilterControlAltText="Filter trans_code column"
                            HeaderText="รหัสการดำเนินการ" SortExpression="trans_code" UniqueName="trans_code">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="UPLOAD_DATE" DataFormatString="{0:d}" FilterControlAltText="Filter UPLOAD_DATE column"
                           HeaderText="วันที่ยื่นคำขอ" SortExpression="UPLOAD_DATE" UniqueName="UPLOAD_DATE">
                       </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="stat" FilterControlAltText="Filter stat column"
                           HeaderText="สถานะ" SortExpression="stat" UniqueName="stat">
                       </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                            CommandName="sel" Text="ดูข้อมูล">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </td>
    </tr>

</table>

<br />
<br />

<table class="table" style="width: 100%;">
    <tr>
        <td>
            <table style="width: 100%;">
               <tr>
                   <td style="width: 55%;">
                       <h2>เอกสารกำกับยาแบบ PI (Package Insert)
                       </h2>
                       </td>
                   <td valign="center">
                       <div style="text-align: right; padding-left: 0%; height: 60px;">
                           <asp:Button ID="btn_download_PI" runat="server" Text="ดาวน์โหลดคำขอ" CssClass="btn-lg" />
                           &nbsp;&nbsp;
                           &nbsp;&nbsp;
       <asp:Button ID="btn_upload_PI" runat="server" Text="อัพโหลดคำขอ" CssClass="btn-lg" />
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       </div>
                   </td>
               </tr>
           </table>
            <telerik:RadGrid ID="RadGrid2" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
                <MasterTableView AutoGenerateColumns="False">
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                        </telerik:GridBoundColumn>             
                        <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column" HeaderText="TR_ID"
                            SortExpression="TR_ID" UniqueName="TR_ID" Display="false" AllowFiltering="true">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="trans_code" FilterControlAltText="Filter trans_code column"
                            HeaderText="รหัสการดำเนินการ" SortExpression="trans_code" UniqueName="trans_code">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="UPLOAD_DATE" DataFormatString="{0:d}" FilterControlAltText="Filter UPLOAD_DATE column"
                           HeaderText="วันที่ยื่นคำขอ" SortExpression="UPLOAD_DATE" UniqueName="UPLOAD_DATE">
                       </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="stat" FilterControlAltText="Filter stat column"
                           HeaderText="สถานะ" SortExpression="stat" UniqueName="stat">
                       </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                            CommandName="sel" Text="ดูข้อมูล">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </td>
    </tr>

</table>