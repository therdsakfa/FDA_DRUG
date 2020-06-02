<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_NEWS.ascx.vb" Inherits="FDA_DRUG.UC_NEWS" %>
  <div class="form-control" style="height:500px;">
    <h3>
        &nbsp;</h3>
    <div class="panel-heading panel-title" style="text-align:center;color:black;">ประกาศ</div>
    <div style="margin: 20px; height:400px;">
        <asp:Label ID="lbl_news" runat="server" Text=""></asp:Label> <br />
        โปรดเลือกประเภทใบอนุญาตหรือประเภทคำขอจากเมนูทางด้านซ้ายมือ
        <br />
        &nbsp;<br />
        <asp:Label ID="lb_news" runat="server" Text="" style="color:red;"></asp:Label>
        &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/new_ico.gif" />
        <br />
        <br />
&nbsp;<div style="color:black;"> 
            รองรับการทำงานบนเบราเซอร์ Mozilla Firefox&nbsp;ดาวน์โหลด <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FILE_DOWNLOAD/Firefox_Setup_42.0.zip" >ที่นี้</asp:HyperLink>
            <br />
            รองรับการทำงานบนโปรแกรม Adobe Acrobat Reader DC&nbsp;ดาวน์โหลด <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/FILE_DOWNLOAD/AcroRdrDC_MUI.zip" >ที่นี้</asp:HyperLink>
            <br />
            รองรับการทำงานด้วย FontPack ดาวน์โหลด <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/FILE_DOWNLOAD/FontPack_DC.zip" >ที่นี้</asp:HyperLink>
        </div>
       
        <br />
&nbsp;
        <%--- อ่านวิธีตั้งค่าเพื่อรองรับการเปิดไฟล์ PDF บนเว็บเบราเซอร์ <asp:HyperLink ID="HyperLink2" runat="server">ที่นี้</asp:HyperLink>--%>

    </div>
         
</div>