<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_EXPERT_ASSIGN.aspx.vb" Inherits="FDA_DRUG.FRM_EXPERT_ASSIGN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../css/css_radgrid.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table">
        <tr>
            <td align="right" style="width:10%;">ชื่อผลิตภัณฑ์ :
            </td>
            <td style="width:20%;">
                <asp:Label ID="lbl_product_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
             <td align="right" style="width:10%;">เลขทะเบียน :
            </td>
            <td style="width:20%;">
                <asp:Label ID="lbl_lcnno_display" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:10%;">rgttpcd :
            </td>
            <td style="width:10%;">
                <asp:Label ID="lbl_rgttpcd" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:10%;">วงเล็บ :
            </td>
            <td style="width:10%;">
                <asp:Label ID="lbl_engdrgtpnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:10%;">สถานะปัจจุบัน :
            </td>
            <td style="width:20%;">
                <asp:Label ID="lbl_stat" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
    </table>

    <table class="table">
        <tr>
            <td style="width:20%;">ชื่อ-นามสกุล ผู้เชี่ยวชาญ</td>
            <td style="width:30%;">
                <asp:DropDownList ID="ddl_expert" runat="server"></asp:DropDownList>

                <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                </telerik:RadScriptManager>

            </td>
            <td style="width:20%;">ด้าน :</td>
            <td>
                <asp:DropDownList ID="ddl_skill" runat="server"></asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btn_add" runat="server" Text="เพิ่มผู้เชี่ยวชาญ" CssClass="btn-bg" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" 
                    AllowPaging="true" PageSize="10" MasterTableView-AllowFilteringByColumn="true">
                        <%--<ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true">

                        </ClientSettings>
                        <ClientSettings EnableRowHoverStyle="true">
                            <Selecting AllowRowSelect="true" />
                        </ClientSettings>--%>
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                    SortExpression="IDA" UniqueName="IDA" Display="false">
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="FULLNAME" FilterControlAltText="Filter FULLNAME column" HeaderText="ชื่อ-นามสกุล ผู้เชี่ยวชาญ"
                                    SortExpression="FULLNAME" UniqueName="FULLNAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EXPERT_SKILL" FilterControlAltText="Filter EXPERT_SKILL column" HeaderText="ประเมินด้าน"
                                    SortExpression="EXPERT_SKILL" UniqueName="EXPERT_SKILL">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
            </td>
        </tr>
        </table>
</asp:Content>
