<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_BSN_ADD_NEW.ascx.vb" Inherits="FDA_DRUG.UC_BSN_ADD_NEW" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="ข้อมูลผู้ดำเนินกิจการ">
<table>
    <tr>
        <td align="right">เลขบัตรประชาชน/เลขPassport/เลขต่างด้าว</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_IDENTIFY" runat="server" CssClass="input-sm"></asp:TextBox>             
            <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
        
        </td>
    </tr>
    <tr>
        <td align="right">คำนำหน้าชื่อ (ภาษาไทย)</td>
        <td style="padding-left:1%;">
           <asp:DropDownList ID="ddl_prefix" runat="server" AutoPostBack="True" DataTextField ="thanm" DataValueField="prefixcd"></asp:DropDownList></td>
    </tr>
    <tr>
        <td align="right">คำนำหน้าชื่อ (ภาษาอังกฤษ)</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_engprefixnm" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อผู้ดำเนินกิจการ (ภาษาไทย)</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_THAINAME" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">นามสกุลผู้ดำเนินกิจการ (ภาษาไทย)</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_THAILASTNAME" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อผู้ดำเนินกิจการ (ภาษาอังกฤษ)</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_ENGNAME" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">นามสกุลผู้ดำเนินกิจการ (ภาษาอังกฤษ)</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_ENGLASTNAME" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
   
</table>
</asp:Panel>
<br />
<asp:Panel ID="Panel3" runat="server" GroupingText="ที่อยู่ตามทะเบียนบ้านของผู้ดำเนินกิจการ (ภาษาไทย)">
    <table>
        <tr>
            <td align="right">รหัสประจำบ้าน</td>
            <td style="padding-left:1%;">
                <asp:TextBox ID="txt_BSN_HOUSENO" runat="server" CssClass="input-sm"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">เลขที่</td>
            <td style="padding-left:1%;">
                <asp:TextBox ID="txt_BSN_ENGADDR" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">หมู่</td>
            <td style="padding-left:1%;">
                <asp:TextBox ID="txt_BSN_MOO" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">ซอย</td>
            <td style="padding-left:1%;">
                <asp:TextBox ID="txt_BSN_SOI" runat="server" CssClass="input-sm"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">ถนน</td>
            <td style="padding-left:1%;">
                <asp:TextBox ID="txt_BSN_ROAD" runat="server" CssClass="input-sm"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">จังหวัด</td>
            <td style="padding-left:1%;">
                <asp:DropDownList ID="ddl_Province" runat="server" AutoPostBack="True" DataTextField="thachngwtnm" DataValueField="chngwtcd">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">เขต/อำเภอ</td>
            <td style="padding-left:1%;">
                <asp:DropDownList ID="ddl_amphor" runat="server" AutoPostBack="True" DataTextField="thaamphrnm" DataValueField="amphrcd">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">แขวง/ตำบล</td>
            <td style="padding-left:1%;">
                <asp:DropDownList ID="ddl_tambol" runat="server" AutoPostBack="True" DataTextField="thathmblnm" DataValueField="thmblcd">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">รหัสไปรษณีย์</td>
            <td style="padding-left:1%;">
                <asp:TextBox ID="txt_BSN_ZIPCODE" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">โทรศัพท์</td>
            <td style="padding-left:1%;">
                <asp:TextBox ID="txt_BSN_TELEPHONE" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">โทรสาร</td>
            <td style="padding-left:1%;">
                <asp:TextBox ID="txt_BSN_FAX" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<asp:Panel ID="Panel2" runat="server" GroupingText="ที่อยู่ตามทะเบียนบ้านของผู้ดำเนินกิจการ (ภาษาอังกฤษ)">
    <table>
        <tr>
            <td align="right">Address No. :</td>
            <td style="padding-left:1%;">
                <asp:Label ID="lbl_BSN_ENGADDR" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Mu :</td>
            <td style="padding-left:1%;">
                <asp:Label ID="lbl_BSN_ENGMU" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Soi :</td>
            <td style="padding-left:1%;">
                <asp:TextBox ID="txt_BSN_ENGSOI" runat="server" CssClass="input-sm"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">Road :</td>
            <td style="padding-left:1%;">
                <asp:TextBox ID="txt_BSN_ENGROAD" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">Province :</td>
            <td style="padding-left:1%;">
                <asp:Label ID="lbl_BSN_CHWNG_ENGNAME" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Subdivision of a Province :</td>
            <td style="padding-left:1%;">
                <asp:Label ID="lbl_BSN_AMPHR_ENGNAME" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">District :</td>
            <td style="padding-left:1%;">
                <asp:Label ID="lbl_BSN_THMBL_ENGNAME" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Postal Code :</td>
            <td style="padding-left:1%;">
                <asp:Label ID="lbl_BSN_ZIPCODE" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Telephone :</td>
            <td style="padding-left:1%;">
                <asp:Label ID="lbl_BSN_TELEPHONE" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">Fax No :</td>
            <td style="padding-left:1%;">
                <asp:Label ID="lbl_BSN_FAX" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />


