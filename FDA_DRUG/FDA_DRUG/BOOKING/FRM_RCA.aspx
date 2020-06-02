<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF_DRUG_POPUP.Master" CodeBehind="FRM_RCA.aspx.vb" Inherits="FDA_DRUG.FRM_RCA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="width:25%;">

            </td>
              <td style="width:50%;">
                   
                  &nbsp; &nbsp;</td>
              <td style="width:25%;">

            </td>
        </tr>
         <tr>
            <td>

            </td>
              <td style="border:solid 1px black;background-color:white;" >
  เลขอ้างอิง <asp:TextBox ID="txt_ref" runat="server"></asp:TextBox> 
    <br />
    <asp:Button ID="btn_rca" runat="server" Text="ค้นหา RCA" />
    <br />
    <hr />
    ผลการค้นหา
    <br />
    เลขอ้างอิง : <asp:Label ID="lbl_ref" runat="server" Text=""></asp:Label>
    <br />
    R : <asp:Label ID="lbl_r" runat="server" Text=""></asp:Label>
    <br />
    C : <asp:Label ID="lbl_c" runat="server" Text=""></asp:Label>
    <br />
    A : <asp:Label ID="lbl_a" runat="server" Text=""></asp:Label>
            </td>
              <td>

            </td>
        </tr>

    </table>
  
</asp:Content>
