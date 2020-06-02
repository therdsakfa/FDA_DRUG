<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm37.aspx.vb" Inherits="FDA_DRUG.WebForm37" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server">

        </asp:GridView>


        <br />
        <asp:Button ID="Button2" runat="server" Text="Button2222" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />


    </div>
        <asp:Button ID="btn_get_cas" runat="server" Text="ดึงสารในตำรับ" />
        <asp:Button ID="btn_get_pcksize" runat="server" Text="ดึงขนาดบรรจุ" />
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" Text="Button" />

            <asp:DropDownList ID="ddl_remark1" runat="server">
                            <asp:ListItem Value="0">กรุณาเลือก</asp:ListItem>
                            <asp:ListItem Value="1">&lt;=</asp:ListItem>
                            <asp:ListItem Value="2">&lt;</asp:ListItem>
                            <asp:ListItem Value="3">=</asp:ListItem>
                            <asp:ListItem Value="4">&gt;=</asp:ListItem>
                            <asp:ListItem Value="5">&gt;</asp:ListItem>
                        </asp:DropDownList>
            <asp:DropDownList ID="ddl_status" runat="server" Width="80%">
            </asp:DropDownList>
        </p>
    </form>
</body>
</html>
