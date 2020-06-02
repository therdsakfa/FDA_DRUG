<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_GMP.ascx.vb" Inherits="FDA_DRUG.UC_GMP" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<h2 style="font-family:'TH SarabunPSK';font-size:24px;">
  <b> แบบกรอกรายละเอียดใบรับรองสถานที่ผลิตในต่างประเทศ</b>
</h2>
<table width="100%" style="font-family:'TH SarabunPSK';font-size:20px;">
    <tr >
        <td style="height:25px;width:35%;">
            1. เลขที่ใบรับรอง (Certificate Number)<font color="red">*</font>  :
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
            5. ประเทศ (Country<font color="red">*</font> :</td>
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
            6. Manufacturer&quot;s License Number :</td>
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
            7. วันเดือนปีที่ออกหนังสือ GMP (Issue Date)<font color="red">*</font> :</td>
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
            8. หน่วยงานที่ออกใบรับรอง<font color="red">*</font> </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="height:25px">
            <asp:CheckBox ID="cb_DEPARTMENT_REGIST_CER_TYPE" runat="server" Text="ชื่อหน่วยงานรัฐของประเทศผู้ผลิต" />
        </td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_DEPARTMENT_REGIST_CER_NAME" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            <asp:CheckBox ID="cb_DEPARTMENT_REGIST_CER_TYPE2" runat="server" Text="ชื่อหน่วยงานอื่นที่ได้รับการรับรองจากหน่วยงานรัฐของประเทศผู้ผลิต" />
        </td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_DEPARTMENT_REGIST_CER_NAME2" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            9. สถานที่ผลิตได้มาตรฐาน GMP ตาม<font color="red">*</font> :
           
        </td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <table>
                <tr>
                    <td style="height:25px">
<asp:RadioButtonList ID="rdl_gmp" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">PIC / S GMP</asp:ListItem>
                <asp:ListItem Value="2">WHO GMP</asp:ListItem>
                <asp:ListItem Value="3">National GMP</asp:ListItem>
            </asp:RadioButtonList>
                    </td>
                    <td >
                       &nbsp; ประเทศ<font color="red">*</font> 
                    </td>
                    <td >
&nbsp;
                    <asp:Label ID="lbl_iso_gmp" runat="server" Text="-"></asp:Label> &nbsp;
                    </td>
                </tr>
            </table>
            

        </td>
    </tr>
</table>
<br />
<h2 style="font-family:'TH SarabunPSK';font-size:24px;">
   <b> รายละเอียดผลิตภัณฑ์ที่ได้รับการรับรอง </b>
</h2>
<table style="font-family:'TH SarabunPSK';font-size:20px;">
    <tr>
        <td style="height:25px">
            10. ขอบเขตของประเภทยาที่รับรอง
        </td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_CER_SCOPE" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
</table>
<br />

<telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" Font-Names="TH SarabunPSK" Font-Size="20px">
    <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="CAS_ID" FilterControlAltText="Filter CAS_ID column" HeaderStyle-Font-Names="TH SarabunPSK" HeaderStyle-Font-Size="20px"
                           HeaderText="รหัสสาร" SortExpression="CAS_ID" UniqueName="CAS_ID">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="CAS_NAME" FilterControlAltText="Filter CAS_NAME column" HeaderStyle-Font-Names="TH SarabunPSK" HeaderStyle-Font-Size="20px"
                           HeaderText="ชื่อสาร" SortExpression="CAS_NAME" UniqueName="CAS_NAME">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="INN_NAME" FilterControlAltText="Filter INN_NAME column" HeaderStyle-Font-Names="TH SarabunPSK" HeaderStyle-Font-Size="20px"
                           HeaderText="(Inn Name)" SortExpression="INN_NAME" UniqueName="INN_NAME">
                       </telerik:GridBoundColumn>
                    </Columns>
    </MasterTableView>

</telerik:RadGrid>

