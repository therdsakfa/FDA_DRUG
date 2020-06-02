<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_PIC.ascx.vb" Inherits="FDA_DRUG.UC_PIC" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<h2>
    แบบกรอกรายละเอียดใบรับรองสถานที่ผลิตในต่างประเทศ
</h2>
<table width="100%">
    <tr>
        <td width="30%">
            1. ชื่อสถานที่ผลิตในต่างประเทศ (Manufacturer)<font color="red">*</font> :</td>
        <td>
            <asp:Label ID="lbl_NAME_ADDRESS" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            2. ที่อยู่ (Address) :</td>
        <td>
            <asp:Label ID="lbl_ADDRESS_NUMBER" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            3. เมือง (City / Province/ State)<font color="red">*</font> :</td>
        <td>
            <asp:Label ID="lbl_ADDRESS_CITY" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            4. ประเทศ (Country)<font color="red">*</font> :</td>
        <td>
            <asp:Label ID="lbl_country" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            รหัสไปรษณีย์ (Post code/Zip code) :</td>
        <td>
            <asp:Label ID="lbl_zipcode" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            5. สถานที่ผลิตได้มาตรฐาน GMP ตาม (โปรดระบุ<font color="red">*</font>) :</td>
        <td>
            <asp:Label ID="lbl_MANUFACTURER_LICENCE_NUMBER" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Global Location Number (GLN)<font color="red">*</font> :</td>
        <td>
            <asp:Label ID="lbl_GLN" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            6. วันเดือนปีการขายที่ระบุในหลักฐานการขาย<font color="red">*</font> :</td>
        <td>
            <asp:Label ID="lbl_DOCUMENT_DATE" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    </table>
<br />
<h2>
    รายละเอียดชื่อประเทศปลายทางที่มีการส่งของไปขาย</h2>
<table>
    <tr>
        <td>
            7. ชื่อผู้ซื้อ (Purchaser)<font color="red">*</font></td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            8. ประเทศผู้ซื้อ (Purchaser&#39;s Country)<font color="red">*</font></td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            9. มาตราฐานสถานที่ผลิตยาสำเร็จรูปของประเทศผู้ซื้อได้GMPตาม (โปรดระบุ)<font color="red">*</font>
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
<br />

<telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
    <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="CAS_ID" FilterControlAltText="Filter CAS_ID column"
                           HeaderText="รหัสสาร" SortExpression="CAS_ID" UniqueName="CAS_ID">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="CAS_NAME" FilterControlAltText="Filter CAS_NAME column"
                           HeaderText="ชื่อสาร" SortExpression="CAS_NAME" UniqueName="CAS_NAME">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="INN_NAME" FilterControlAltText="Filter INN_NAME column"
                           HeaderText="(Inn Name)" SortExpression="INN_NAME" UniqueName="INN_NAME">
                       </telerik:GridBoundColumn>
                    </Columns>
    </MasterTableView>

</telerik:RadGrid>