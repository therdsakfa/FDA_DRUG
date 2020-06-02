<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/POPUP.Master" CodeBehind="POPUP_LCN_TYPE_1.aspx.vb" Inherits="FDA_DRUG.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="width:100% ; text-align:left"  >

        <h3>
            กรุณาเลือกไฟล์ที่อยู่ของpdf
        </h3>
    <div style="width:auto ; float:left ;text-align:center">

    
         <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-default" />    
      
    </div>

        <div style="width:auto ; float:left">
    
      <asp:Button ID="btn_Upload" runat="server" Text="อัพโหลด"  CssClass="btn-danger" />
             </div>
        
    </div>

    <h4>
        หมายเหตุ : กรุณาจดเลขที่ได้หลังจากทำการอัพโหลดเรียบร้อยแล้ว
    </h4>
</asp:Content>
