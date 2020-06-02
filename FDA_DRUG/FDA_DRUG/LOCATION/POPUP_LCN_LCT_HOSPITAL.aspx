<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_LCT_HOSPITAL.aspx.vb" Inherits="FDA_DRUG.POPUP_LCN_LCT_HOSPITAL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">  
    <p class="h3">รายละเอียด</p>
    <hr />
      <table class="table" style="width:100%;">
          <tr>
              <td  style="width:20%;"></td>
               <td style="width:20%;"></td>
               <td style="width:20%;"></td>
               <td style="width:20%;"></td>
               <td style="width:20%;"></td>
          </tr>
         <tr>

             <td>

            </td>
            <td style="text-align:right">ชนิดของสถานที่ :</td>
            <td style="text-align:right">
                <asp:RadioButton ID="rbn_TREATMENT" runat="server" Text="เป็นสถานบำบัด"  GroupName="TREATMENT"/>
                </td>
            <td style="text-align:right" >
            <asp:RadioButton ID="rbn_NO_TREATMENT" runat="server" Text="ไม่เป็นสถานบำบัด" GroupName="TREATMENT" />
            </td>
              <td>

            </td>
             </tr>

        <tr>
              <td>

            </td>
            <td style="text-align:right">จำนวนเตียง :</td>
            <td style="text-align:right">
                <asp:TextBox ID="txt_bed" runat="server"></asp:TextBox> &nbsp</td>
            <td>
               &nbsp  เตียง
            </td>
            <td>

            </td>
        </tr>
        <tr>

            <td style="text-align:center" colspan="5">
                <asp:Button ID="btn_save" runat="server" Text="ยืนยัน" CssClass="btn-lg" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_back" runat="server" Text="กลับ" CssClass="btn-lg" />
            
            </td>
        </tr>
    </table>


</asp:Panel>
  
</asp:Content>
