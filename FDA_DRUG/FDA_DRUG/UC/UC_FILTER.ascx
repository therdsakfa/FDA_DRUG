<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_FILTER.ascx.vb" Inherits="FDA_DRUG.UC_FILTER" %>
<table class=" table" style="width:100%;">
    <tr>
        <td>สถานะ </td>
        <td>
            <asp:DropDownList ID="ddl_status" runat="server" AutoPostBack="True" class="form-control">
            </asp:DropDownList>
        </td>
        <td>
                   <%--<asp:DropDownList ID="ddl_name" runat="server" CssClass="dropdown-tasks" AutoPostBack="True"></asp:DropDownList>--%>
            ชื่อผลิตภัณฑ์ </td>
        <td>
            <asp:TextBox ID="txt_name" runat="server" class="form-control"></asp:TextBox>
        </td>
        <td>
                   <%--<asp:DropDownList ID="ddl_number" runat="server" CssClass="dropdown-tasks" AutoPostBack="True"></asp:DropDownList>--%>
                 เลขจดแจ้ง </td>
        <td>
            <asp:TextBox ID="txt_number" runat="server" class="form-control"></asp:TextBox>
        </td>
       
    </tr>
</table>

