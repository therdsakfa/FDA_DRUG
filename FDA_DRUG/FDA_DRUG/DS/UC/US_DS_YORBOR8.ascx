<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="US_DS_YORBOR8.ascx.vb" Inherits="FDA_DRUG.US_DS_YORBOR8" %>
<style type="text/css">
    .auto-style1 {
        height: 21px;
    }
    .auto-style3 {
        height: 24px;
    }
    .auto-style4 {
        height: 26px;
    }
</style>

<table class="table" style="width:100%;">
    <tr>
        <td align="right">
            เขียนที่ :</td>
        <td>
            <asp:TextBox ID="txt_WRITE_AT" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td align="right">
           วันที่ :</td>
        <td>
            <asp:TextBox ID="txt_WRITE_DATE" runat="server"></asp:TextBox>
            <asp:Label ID="lbl_date" runat="server" Text="(ตัวอย่าง 31/12/2560)"></asp:Label>
        </td>
        </tr>
        <tr>
            <td align="right">
                ข้าพเจ้า (ชื่อผู้ขออนุญาต) :</td>
            <td>
                <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                 ได้รับอนุญาตให้ :</td>
            <td>
                <asp:RadioButton  ID="RadioButton3" runat="server" GroupName="for" Text="ผลิตยาโบราณ"></asp:RadioButton>
                <asp:RadioButton ID="RadioButton4" runat="server" GroupName="for"  Text="นำหรือสั่งยาโบราณเข้ามาในราชอาณาจักรตาม"></asp:RadioButton>
            </td>
         </tr>
        <tr>
            <td align="right">
                ผู้ดำเนินกิจการชื่อ :</td>
            <td>
                <asp:Label ID="lbl_bsn_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                ได้รับอนุญาตนำหรือสั่งเลขที่ :</td>
            <td>
                <asp:Label ID="lbl_lcnno" runat="server" Text=""></asp:Label>
                <asp:Label ID="lbl_lcnno2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                สถานที่ผลิตยาชื่อ :</td>
            <td class="auto-style3">
                <asp:Label ID="lbl_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style1">
                เลขที่ :</td>
            <td class="auto-style1">
                <asp:Label ID="lbl_number" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                ซอย :</td>
            <td>
                <asp:Label ID="lbl_lane" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
               ถนน :</td>
            <td>
                <asp:Label ID="lbl_road" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
               หมู่ :</td>
            <td>
                <asp:Label ID="lbl_village_no" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                ตำบล :</td>
            <td>
                <asp:Label ID="lbl_sub_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                อำเภอ :</td>
            <td>
                <asp:Label ID="lbl_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                จังหวัด :</td>
            <td>
                <asp:Label ID="lbl_province" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
             โทรศัพท์ :</td>
            <td>
                <asp:Label ID="lbl_tel" runat="server" Text="-"></asp:Label>
            </td>      
        <tr>
            <td align="right" class="auto-style4">
                 ขออนุญาต :</td>
            <td class="auto-style4">
                <asp:RadioButton  ID="RadioButton1" runat="server" GroupName="for" Text="ผลิตยาตัวอย่าง"></asp:RadioButton>
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="for"  Text="นำหรือสั่งยาตัวอย่างเข้ามาในราชอาณาจักรเพื่อขอขึ้นทะเบียน"></asp:RadioButton>
            </td>
         </tr>
        
            <tr>
            <td align="right">
             ตำรับยาชื่อ :</td>
            <td>
                <asp:TextBox ID="txt_formularies" runat="server" Text=""></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                 รายละเอียดของ :</td>
            <td>
                <asp:RadioButton  ID="chk_description1" runat="server" GroupName="for" Text="ยาที่ผลิต"></asp:RadioButton>
                <asp:RadioButton ID="chk_description2" runat="server" GroupName="for"  Text="ยาที่นำหรือสั่งเข้ามาในราชอาณาจักร"></asp:RadioButton>
            </td>
        </tr>
        <tr>
            <td align="right">
                ขนาดบบรจุ :</td>
            <td>
                <asp:TextBox ID="txt_size" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                แนบเอกสารเพิ่มเติม </td>
        </tr>
        <tr>
            <td>
                (1) ฉลากยา</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:HyperLink ID="hp_file_name1" runat="server" Style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                (2) เอกสารกำกับยา</td>
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <asp:HyperLink ID="hp_file_name2" runat="server" Style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
     <tr>
            <td>
                (3) เอกสารอืนๆ</td>
            <td>
                <asp:FileUpload ID="FileUpload3" runat="server" />
                <asp:HyperLink ID="hp_file_name3" runat="server" Style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="right">
              </td>
            <td>
                <asp:Button ID="btn_save" runat="server" Text="บันทึก"></asp:Button>
                <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก"></asp:Button>
            </td>
        </tr>
    </table>