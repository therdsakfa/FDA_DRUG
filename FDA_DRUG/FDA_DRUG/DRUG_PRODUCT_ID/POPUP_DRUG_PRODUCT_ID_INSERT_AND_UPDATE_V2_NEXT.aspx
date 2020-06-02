<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2_NEXT.aspx.vb" Inherits="FDA_DRUG.POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2_NEXT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script type="text/javascript">
        //$(document).ready(function () {
        //    $("#ContentPlaceHolder1_ddl_nat").searchable();

        //});

        $(document).ready(function () {
            $("select").searchable({
                maxListSize: 50, // if list size are less than maxListSize, show them all
                maxMultiMatch: 300, // how many matching entries should be displayed
                exactMatch: false, // Exact matching on search
                wildcards: true, // Support for wildcard characters (*, ?)
                ignoreCase: true, // Ignore case sensitivity
                latency: 200, // how many millis to wait until starting search
                warnMultiMatch: 'top {0} matches ...',
                warnNoMatch: 'no matches ...',
                zIndex: 'auto'
            });
        });
        </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">

        <div class="panel-heading panel-title">
                <h1>ที่อยู่</h1>
            </div>

        <div class="panel-heading panel-title">
                                    <h4>ผู้ผลิตในประเทศ/นำสั่ง</h4>
                                </div>
    <table style="width:100%;" class="table">
        <tr>
            <td align="right" style="width:200px">
                ชื่อสถานที่ผลิต :</td>
            <td colspan="3">
                <asp:TextBox ID="txt_thanameplace" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <%--<tr>
            <td align="right">
                ที่ตั้ง :</td>
            <td colspan="3">
                <asp:TextBox ID="txt_fulladdr" runat="server" CssClass="input-sm" Width="600px"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td align="right">บ้านเลขที่</td>
            <td style="width:300px"><asp:TextBox ID="txt_addr" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right" style="width:200px">ถนน</td>
            <td ><asp:TextBox ID="txt_road" runat="server"  CssClass="input-sm"  Width="80%"></asp:TextBox></td>
        </tr> 
        <tr>
            <td align="right">หมู่</td>
            <td style="width:300px"><asp:TextBox ID="txt_mu" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right" style="width:200px">ซอย</td>
            <td ><asp:TextBox ID="txt_soi" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
        </tr> 
         <tr>
            <td align="right">จังหวัด</td>
            <td >
      
                  <asp:DropDownList ID="ddl_bsn_jungwat"  CssClass="input-sm"  Width="80%" runat="server" AutoPostBack="True"></asp:DropDownList>
             </td>
            <td align="right">&nbsp;</td>
            <td >
      
                  &nbsp;</td>
        </tr> 
             <tr>
            <td align="right">อำเภอ</td>
            <td >

                  <asp:DropDownList ID="ddl_bsn_amper"  CssClass="input-sm"  Width="80%" runat="server" AutoPostBack="True"></asp:DropDownList>
            </td>
            <td align="right">ตำบล</td>
            <td >
                  <asp:DropDownList ID="ddl_bsn_tumbol"  CssClass="input-sm"  Width="80%" runat="server"></asp:DropDownList>
            </td>
        </tr> 
             <tr>
            <td align="right">รหัสไปรษณีย์</td>
            <td ><asp:TextBox ID="txt_zipcode" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right">เบอร์โทรศัพท์</td>
            <td ><asp:TextBox ID="txt_tel" runat="server"  CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
                 </tr>
      </table>
    
 <div class="panel-heading panel-title">
                                    <h4>ผู้ผลิตต่างในประเทศ</h4>
                                </div>
    <table style="width:100%;" class="table">
        <tr>
            <td align="right" style="width:200px">
                ชื่อสถานที่ผลิตในต่างประเทศ :</td>
            <td colspan="3">
                <asp:TextBox ID="txt_FRGN_NAME" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="right" style="width:200px">
                ที่อยู่</td>
            <td colspan="3">
                <asp:TextBox ID="txt_FRGN_FULLADDR" runat="server" CssClass="input-sm" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">เมือง</td>
            <td style="width:300px"><asp:TextBox ID="txt_FRGN_CITY_NAME" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right" style="width:200px">รหัสไปรษณีย์&nbsp;</td>
            <td ><asp:TextBox ID="txt_FRGN_ZIPCODE" runat="server"  CssClass="input-sm"  Width="80%"></asp:TextBox></td>
        </tr>
        <%--<tr>
            <td align="right">บ้านเลขที่</td>
            <td style="width:300px"><asp:TextBox ID="txt_addr2" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right" style="width:200px">ถนน</td>
            <td ><asp:TextBox ID="txt_road2" runat="server"  CssClass="input-sm"  Width="80%"></asp:TextBox></td>
        </tr> 

        <tr>
            <td align="right">หมู่</td>
            <td style="width:300px"><asp:TextBox ID="txt_mu2" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right" style="width:200px">ซอย</td>
            <td ><asp:TextBox ID="txt_soi2" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
        </tr> 
         <tr>
            <td align="right">จังหวัด</td>
            <td >
      
                  <asp:DropDownList ID="ddl_bsn_jungwat2"  CssClass="input-sm"  Width="80%" runat="server" AutoPostBack="True"></asp:DropDownList>
             </td>
            <td align="right">&nbsp;</td>
            <td >
      
                  &nbsp;</td>
        </tr> 
             <tr>
            <td align="right">อำเภอ</td>
            <td >

                  <asp:DropDownList ID="ddl_bsn_amper2"  CssClass="input-sm"  Width="80%" runat="server" AutoPostBack="True"></asp:DropDownList>
            </td>
            <td align="right">ตำบล</td>
            <td >
                  <asp:DropDownList ID="ddl_bsn_tumbol2"  CssClass="input-sm"  Width="80%" runat="server"></asp:DropDownList>
            </td>
        </tr> 
             <tr>
            <td align="right">รหัสไปรษณีย์</td>
            <td ><asp:TextBox ID="txt_zipcode2" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right">เบอร์โทรศัพท์</td>
            <td ><asp:TextBox ID="txt_tel2" runat="server"  CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
                 </tr>--%>
        <tr>
            <td align="right">ประเทศ</td>
            <td style="width:300px">
                <asp:DropDownList ID="ddl_nat" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
            <td align="right" style="width:200px">&nbsp;</td>
            <td >&nbsp;</td>
        </tr>
        </table>         <div class="panel-heading panel-title">
                                    <h4>ผู้แทนจำหน่าย</h4>
                                </div>
    <table style="width:100%;" class="table">
        <tr>
            <td align="right" style="width:200px">
                ชื่อผู้รับอนุญาตขาย :</td>
            <td colspan="3">
                <asp:TextBox ID="txt_thanameplace3" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="right">บ้านเลขที่</td>
            <td style="width:300px"><asp:TextBox ID="txt_addr3" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right" style="width:200px">ถนน</td>
            <td ><asp:TextBox ID="txt_road3" runat="server"  CssClass="input-sm"  Width="80%"></asp:TextBox></td>
        </tr> 

        <tr>
            <td align="right">หมู่</td>
            <td style="width:300px"><asp:TextBox ID="txt_mu3" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right" style="width:200px">ซอย</td>
            <td ><asp:TextBox ID="txt_soi3" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
        </tr> 
         <tr>
            <td align="right">จังหวัด</td>
            <td >
      
                  <asp:DropDownList ID="ddl_bsn_jungwat3"  CssClass="input-sm"  Width="80%" runat="server" AutoPostBack="True"></asp:DropDownList>
             </td>
            <td align="right">&nbsp;</td>
            <td >
      
                  &nbsp;</td>
        </tr> 
             <tr>
            <td align="right">อำเภอ</td>
            <td >

                  <asp:DropDownList ID="ddl_bsn_amper3"  CssClass="input-sm"  Width="80%" runat="server" AutoPostBack="True"></asp:DropDownList>
            </td>
            <td align="right">ตำบล</td>
            <td >
                  <asp:DropDownList ID="ddl_bsn_tumbol3"  CssClass="input-sm"  Width="80%" runat="server"></asp:DropDownList>
            </td>
        </tr> 
             <tr>
            <td align="right">รหัสไปรษณีย์</td>
            <td ><asp:TextBox ID="txt_zipcode3" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right">เบอร์โทรศัพท์</td>
            <td ><asp:TextBox ID="txt_tel3" runat="server"  CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
                 </tr>
      </table>
        <div class="panel-footer " style="text-align:center;">
       <asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" CssClass="btn-lg" Width="120px" />
            <asp:Button ID="btn_save" runat="server" Text="บันทึกทั้งหมด" CssClass="btn-lg" Width="150px" />
                <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" CssClass="btn-lg" Width="120px"/>
        </div>
</asp:Content>
