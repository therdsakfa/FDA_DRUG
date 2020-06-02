<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_ATTACH.ascx.vb" Inherits="FDA_DRUG.UC_ATTACH" %>
<div class="row">
<div class="col-lg-4">&nbsp;&nbsp; <asp:Label ID="Label1" Font-Size="16px" runat="server" Text="Label"></asp:Label></div><div class="col-lg-4"><asp:FileUpload ID="FileUpload1"  CssClass="btn-upload" runat="server" /></div>
<asp:HiddenField ID="HiddenField1" runat="server" />
<asp:HiddenField ID="HiddenField2" runat="server" />
<asp:HiddenField ID="H_TYPE" runat="server" />
</div>
