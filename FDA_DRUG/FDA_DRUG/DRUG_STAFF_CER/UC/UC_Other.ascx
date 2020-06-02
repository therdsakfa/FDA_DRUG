<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Other.ascx.vb" Inherits="FDA_DRUG.UC_Other" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">
    .auto-style1 {
        height: 23px;
    }
</style>
<h2 style="font-family:'TH SarabunPSK';font-size:24px;">
    แบบกรอกรายละเอียดใบรับรองสถานที่ผลิตในต่างประเทศ
</h2>
<table width="100%" style="font-family:'TH SarabunPSK';font-size:20px;">
    <tr>
        <td style="height:25px;width:35%;">
            1. Reference Number<font color="red">*</font> :
        </td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_CERTIFICATION_NUMBER_ALL" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            2. ชื่อสถานที่ผลิตในต่างประเทศ (Manufacturer)<font color="red">*</font> :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_NAME_ADDRESS" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            3. ที่อยู่ (Address)<font color="red">*</font> :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_ADDRESS_NUMBER" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            4. เมือง (City / Province/ State)<font color="red">*</font> :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_ADDRESS_CITY" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            5. ประเทศ (Country)<font color="red">*</font> :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_country" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            รหัสไปรษณีย์ (Post code/Zip code) :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_zipcode" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            6. Manufactur&#39;s License Number<font color="red">*</font> :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_MANUFACTURER_LICENCE_NUMBER" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            Global Location Number (GLN) :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_GLN" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            7. หน่วยงานที่ออกเอกสาร<font color="red">*</font> :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_DEPARTMENT_REGIST_CER_NAME" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            ประเทศ (Country)<font color="red">*</font> :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_COUNTRY_OF_DEPARTMENT" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            8. เลขหนังสือให้ความเห็นชอบ<font color="red">*</font> : </td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="Label3" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            9. วันเดือนปีที่ออกหนังสือ (Issue Date)<font color="red">*</font> :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_DOCUMENT_DATE" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            วันเดือนปีที่หมดอายุ (Expiry Date)<font color="red">*</font> : </td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_EXP_DOCUMENT_DATE" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            ประเทศของหน่วยงานที่ออกใบรับรอง : </td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_country2" runat="server" Text="-"></asp:Label>
            
        </td>
    </tr>
    </table>
<br />
<h2 style="font-family:'TH SarabunPSK';font-size:24px;">
    รายละเอียดผลิตภัณฑ์
</h2>
<table>
    <tr>
        <td style="height:25px">
            10. ขอบข่าย
        </td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_CER_SCOPE" runat="server" Text="-"></asp:Label>
        </td>
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