<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_REQUESTS_INSERT_AND_PRINT.aspx.vb" Inherits="FDA_DRUG.FRM_REQUESTS_INSERT_AND_PRINT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table" style="width:100%;">
                   

                          <tr>
                            <td>ชื่อผู้จัดส่งเอกสาร</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txt_SENT_DOCUMENT_NAME" runat="server" CssClass="input-sm" Width="347px"></asp:TextBox>
                               
                            </td>
                        </tr>
                       

                          <tr>
                            <td>ครั้งที่ส่งเอกสาร</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txt_print_count" runat="server" CssClass="input-sm" Width="347px"></asp:TextBox>
                               
                            </td>
                        </tr>
                       
                        <tr>
                            <td>วันที่เริ่มต้น</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txt_startdate" runat="server" CssClass="input-sm" Width="347px"></asp:TextBox>
                               
                                <asp:Label ID="text" runat="server" Text="(ตัวอย่าง 31/12/2559)"></asp:Label>
                               
                            </td>
                        </tr>
                         <tr>
                            <td>วันที่สิ้นสุด</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txt_enddate" runat="server" CssClass="input-sm" Width="350px"></asp:TextBox>
                                (ตัวอย่าง 31/12/2559)
                               
                            </td>
                        </tr>
                         <tr>
                            <td>กลุ่มงาน</td>
                            <td class="auto-style1">
                               
                                <asp:DropDownList ID="ddl_work_group" runat="server" Width="200px" CssClass="input-lg" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style1">
                               
                                <asp:DropDownList ID="ddl_advertise" runat="server" CssClass="input-lg" Width="200px" style="display:none;">
                                    <asp:ListItem Value="1">คำขอโฆษณายาโรคศิลป์</asp:ListItem>
                                    <asp:ListItem Value="2">คำขอโฆษณายาทั่วไป</asp:ListItem>
                                </asp:DropDownList>
                                
                                </td>
                        </tr>
                         <tr>
                            <td><asp:Label ID="Label1" runat="server" Text="กลุ่มงานย่อย" style="display:none;" ></asp:Label></td>
                            <td class="auto-style1">
                               
                                <asp:Button ID="btn_save" runat="server" Text="บันทึกและพิมพ์รายงาน" CssClass="btn-lg" />
                            </td>
                        </tr>
                    </table>
</asp:Content>
