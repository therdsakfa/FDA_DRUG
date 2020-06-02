<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Information_edit.ascx.vb" Inherits="FDA_DRUG.UC_Information_edit" %>
            <table width="100%" class="table">
                <tr>
                    <td> เลขอนุญาต :</td>
                    <td colspan="3">  <asp:Label ID="lbl_lcnno" runat="server" Text=""></asp:Label></td>
                  
                </tr>
                <%--<tr>
                    <td>เลขรับ :</td>
                    <td> <asp:Label ID="lbl_rcvno" runat="server"></asp:Label></td>
                    <td>วันที่รับ :</td>
                    <td> <asp:Label ID="lbl_rcvdate" runat="server"></asp:Label></td>
                </tr>--%>
                 <tr>
                    <td>ชื่อสถานที่ :</td>
                    <td> <asp:Label ID="lbl_thanameplace" runat="server"></asp:Label></td>
                    <td>ชื่อผู้ดำเนินการ :</td>
                    <td> <asp:Label ID="lbl_nameOperator" runat="server"></asp:Label></td>
                </tr>
            </table>
