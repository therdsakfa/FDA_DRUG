<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_IMPORT_GPP.aspx.vb" Inherits="FDA_DRUG.POPUP_IMPORT_GPP" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>นำเข้าข้อมูล GPP (ขย1)</h1>
            </div>
            <div class="panel-body">
                <p>
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:FileUpload ID="FileUpload3" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btn_upload" runat="server" Text="Upload" />
                            </td>
                        </tr>
                    </table>
            
            
                    <telerik:RadGrid ID="RadGrid1" runat="server"></telerik:RadGrid>
        </p>
                
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="Import ข้อมูล" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  </div>
        </div>
</asp:Content>
