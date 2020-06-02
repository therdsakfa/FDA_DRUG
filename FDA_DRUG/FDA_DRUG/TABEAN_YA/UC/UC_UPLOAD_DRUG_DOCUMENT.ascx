<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_UPLOAD_DRUG_DOCUMENT.ascx.vb" Inherits="FDA_DRUG.UC_UPLOAD_DRUG_DOCUMENT" %>
<%--<p>
    <h2>เอกสารกำกับยา</h2>
</p>--%>

<table>
    <tr>
        <td width="50%">เอกสารกำกับยาสำหรับบุคลากรทางการแพทย์ (SPC)</td>
        <td>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </td>
        
    </tr>
    <tr>
        <td>
        <asp:HyperLink ID="hp_file_name" runat="server" Style="display: none;" Target="_blank"></asp:HyperLink>
    </td>

    <td>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/file_delete.png" Width="28px" Height="28px"
            ToolTip="ลบข้อมูล" Style="display: none;" OnClientClick="return confirm('ต้องการลบหรือไม่');" />
    </td>
    </tr>
    
</table>
<br />
<table>
    <tr>
        <td width="50%">เอกสารกำกับยาสำหรับประชาชน (PIL)</td>
        <td>
            <asp:FileUpload ID="FileUpload2" runat="server" />
        </td>
        
    </tr>
    <tr>
        <td>
        <asp:HyperLink ID="hp_file_name2" runat="server" Style="display: none;" Target="_blank"></asp:HyperLink>
    </td>

    <td>
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/file_delete.png" Width="28px" Height="28px"
            ToolTip="ลบข้อมูล" Style="display: none;" OnClientClick="return confirm('ต้องการลบหรือไม่');" />
    </td>
    </tr>
    
</table>
<br />
<table>
    <tr>
        <td width="50%">เอกสารกำกับยาแบบ PI (Package Insert)</td>
        <td>
            <asp:FileUpload ID="FileUpload3" runat="server" />
        </td>
        
    </tr>
    <tr>
        <td>
        <asp:HyperLink ID="hp_file_name3" runat="server" Style="display: none;" Target="_blank"></asp:HyperLink>
    </td>

    <td>
        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/file_delete.png" Width="28px" Height="28px"
            ToolTip="ลบข้อมูล" Style="display: none;" OnClientClick="return confirm('ต้องการลบหรือไม่');" />
    </td>
    </tr>
    
</table>
<asp:Button ID="btn_upload" runat="server" Text="Upload" />
