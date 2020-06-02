<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master"  CodeBehind="FRM_CHECK_TOKEN.aspx.vb" Inherits="FDA_DRUG.FRM_CHECK_TOKEN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-control"  style="height:500px;">
         <h3>  <asp:Label ID="lbl_lcnsnm" runat="server" Text="" Visible="false"></asp:Label></h3>
         <h3 style="text-align:center;">  ประกาศ</h3>
        <div style="margin: 20px; border: 2px double #000000;height:400px;">

            <asp:Label ID="lbl_news" runat="server" Text=""></asp:Label>

        </div>


    </div>
    
</asp:Content>