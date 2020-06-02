<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_LCN_CANCEL_INSERT_AND_UPDATE.aspx.vb" Inherits="FDA_DRUG.FRM_LCN_CANCEL_INSERT_AND_UPDATE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel" style="width:100%">
          <div class="panel-heading panel-title">
                <h1>คำขอยกเลิก</h1>
            </div>

    <table class="table" width="100%">
        <tr>
            <td align="right">
                เขียนที่ :</td>
            <td>
               <asp:TextBox ID="txt_WRITE_AT" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                วันที่ :</td>
            <td>
               <asp:TextBox ID="txt_WRITE_DATE" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                วันที่อนุญาต :</td>
            <td>
               <asp:TextBox ID="txt_app_date" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                เลขที่ใบอนุญาตที่จะยกเลิก :</td>
            <td>
                <%--<asp:DropDownList ID="ddl_lcnno" runat="server" CssClass="input-sm" Width="200px" style="display:none;">
                </asp:DropDownList>--%>
                <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
            </td>
        </tr>

        <tr>
            <td align="right">
                ประเภทการยกเลิก :</td>
            <td>
                <asp:DropDownList ID="ddl_cancel_type" runat="server" CssClass="input-sm" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td align="right">
                เหตุผลการยกเลิก :</td>
            <td>
                <asp:DropDownList ID="ddl_purpose" runat="server" CssClass="input-sm" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
                            <td>แนบสำเนาบัตรประจำตัวประชาชน</td>
                            <td>
                                <table style="width:100%;">
                                    <tr>
                                        <td colspan="2"><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                                       
                                    </tr>
                                    <tr>
                                        <td>
                                            <%--<asp:LinkButton ID="hp_file_name" runat="server" style="display:none;" />--%>
                                            <asp:HyperLink ID="hp_file_name" runat="server" style="display:none;" Target="_blank"></asp:HyperLink>
                                        </td>
                                      
                                        <td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/file_delete.png" Width="28px" Height="28px"
                                                 ToolTip="ลบข้อมูล" style="display:none;" OnClientClick="return confirm('ต้องการลบหรือไม่');" />
                                        </td>
                                      
                                    </tr>
                                </table>
                                
                            </td>
                        </tr>
        <tr>
                            <td>แนบหนังสือรับรองหรือหนังสือมอบอำนาจ (กรณีนิติบุคคล)</td>
                            <td>
                                <table style="width:100%;">
                                    <tr>
                                        <td colspan="2"><asp:FileUpload ID="FileUpload2" runat="server" /></td>
                                       
                                    </tr>
                                    <tr>
                                        <td>
                                            <%--<asp:LinkButton ID="hp_file_name" runat="server" style="display:none;" />--%>
                                            <asp:HyperLink ID="hp_file_name2" runat="server" style="display:none;" Target="_blank"></asp:HyperLink>
                                        </td>
                                      
                                        <td><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/file_delete.png" Width="28px" Height="28px"
                                                 ToolTip="ลบข้อมูล" style="display:none;" OnClientClick="return confirm('ต้องการลบหรือไม่');" />
                                        </td>
                                      
                                    </tr>
                                </table>
                                
                            </td>
                        </tr>

    </table>

    <div class="panel-footer " style="text-align:center;">
        <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" OnClientClick="return confirm('ต้องการยกเลิกหรือไม่');" />
        </div>

       </div>  
</asp:Content>