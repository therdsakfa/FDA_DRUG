<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_E_Tracking.Master" CodeBehind="FRM_E_TRACKING_PANEL.aspx.vb" Inherits="FDA_DRUG.FRM_E_TRACKING_PANEL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td align="center">
                <table class="table" style="width:100%;display:none;">
                    <tr>
                        <td align="center">

                            <asp:Button ID="btn_e_tracking" runat="server" Text="E-Tracking" CssClass="btn-lg" Width="500px" Height="70px" />

                        </td>
                    </tr>
                    <tr>
                        <td align="center">

                            <asp:Button ID="btn_etc" runat="server" Text="จองคิว" CssClass="btn-lg" Width="500px" Height="70px" />

                        </td>
                    </tr>
                    <tr>
                        <td align="center">

                            <asp:Button ID="btn_e_citizen" runat="server" Text="เพิ่มหน้าที่" CssClass="btn-lg" Width="500px" Height="70px" />

                        </td>
                    </tr>
                    
                </table>
                <table class="table" style="width:100%;">
                     <tr>
                        <td align="center">

                           <asp:Button ID="btn_report_chemi" runat="server" Text="E-Tracking ทบ. ยาเคมี" CssClass="btn-lg" Width="500px" Height="70px" /></td>
                    </tr>
                    <%--<tr>
                        <td align="center">

                            <asp:Button ID="btn_report" runat="server" Text="รายงานเจ้าหน้าที่รายคน" CssClass="btn-lg" Width="500px" Height="70px" />

                        </td>
                    </tr>
                    <tr>
                        <td align="center">

                           <asp:Button ID="Button1" runat="server" Text="รายงานเจ้าหน้าที่ทุกคน" CssClass="btn-lg" Width="500px" Height="70px" /></td>
                    </tr>--%>
                     <tr>
                        <td align="center">

                            <asp:Button ID="btn_report_live" runat="server" CssClass="btn-lg" Height="70px" Text="E-Tracking ทบ. ยาชีววัตถุ" Width="500px" />
                         </td>
                    </tr>
                     <tr>
                        <td align="center">

                            <asp:Button ID="btn_report_Old" runat="server" CssClass="btn-lg" Height="70px" Text="E-Tracking ทบ. ยาโบราณ" Width="500px" />
                         </td>
                    </tr>
                     <tr>
                        <td align="center">

                            <asp:Button ID="btn_report_main_drug" runat="server" CssClass="btn-lg" Height="70px" Text="E-Tracking ยากำพร้า" Width="500px" />
                         </td>
                    </tr>
                     <tr>
                        <td align="center">

                            <asp:Button ID="btn_report_adv" runat="server" CssClass="btn-lg" Height="70px" Text="E-Tracking โฆษณายา" Width="500px" />
                         </td>
                    </tr>
                     <tr>
                        <td align="center">

                            <asp:Button ID="btn_report_lcn" runat="server" CssClass="btn-lg" Height="70px" Text="E-Tracking ใบอนุญาตสถานที่" Width="500px" />
                         </td>
                    </tr>
                    
                     <tr>
                        <td align="center">

                           <asp:Button ID="Button3" runat="server" Text="รายงานคำขอรอพิจารณารายบุคคล ตามกลุ่มงาน" CssClass="btn-lg" Width="500px" Height="70px" />
                         </td>
                    </tr>
                    <tr>
                        <td align="center">

                           <asp:Button ID="Button2" runat="server" Text="รายงาน 5 อันดับเจ้าหน้าที่ที่เหลือคำขอมากที่สุด" CssClass="btn-lg" Width="500px" Height="70px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
</asp:Content>
