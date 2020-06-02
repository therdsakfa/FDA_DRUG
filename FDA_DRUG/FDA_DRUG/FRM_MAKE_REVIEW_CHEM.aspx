<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_MAKE_REVIEW_CHEM.aspx.vb" Inherits="FDA_DRUG.FRM_MAKE_REVIEW_CHEM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <h1>
                คัดกรองสาร

            </h1>
        </p>
        <p>
            เลขดำเนินการที่ : DR-60-19-123456
        </p>
        <table>
            <tr>
                <td>ลำดับ</td>
                <td>ชื่อสาร</td>
            </tr>
            <tr>
                <td>1.</td>
                <td>
                    COLCHICINE
                </td>
            </tr>

            <tr>
                <td>2.</td>
                <td>PROBENECID</td>
            </tr>
            <tr>
                <td>3.</td>
                <td>OROTIC ACID</td>
            </tr>
            <tr>
                <td>4.</td>
                <td>ALLOPURINOL</td>
            </tr>
        </table>

        <br />
        
        <h3>ผลการคัดกรองประเภทยาข้างต้น ยาที่ขึ้นทะเบียนตำรับยาที่อาจจัดเป็น
        </h3>
        <br />
<asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>ยาควบคุมพิเศษ(69)</asp:ListItem>
        <asp:ListItem>ยาอันตราย(80)</asp:ListItem>
        <asp:ListItem>ยายกเว้นจากการเป็นยาอันตราย (81)</asp:ListItem>
        <asp:ListItem>ยาสามัญประจำประจำบ้านแผนปัจจุบัน(1)</asp:ListItem>
        <asp:ListItem>ยาสามัญประจำบ้าน ยาแผนโบราณ(2)</asp:ListItem>
        <asp:ListItem>ยาเพิกถอนทะเบียน(7)</asp:ListItem>
        <asp:ListItem>ยาประกาศคำเตือน(99)</asp:ListItem>

    </asp:RadioButtonList>
        <br />
    <table>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="TextBox1" runat="server" Width="400px" Height="200px" TextMode="MultiLine"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td align="center">
                
                <table>
                    <tr>
                        <td><asp:Button ID="Button1" runat="server" Text="ส่งคำคัดกรอง" /></td>
                        <td><asp:Button ID="Button2" runat="server" Text="ย้อนกลับ" /></td>
                    </tr>
                </table>
            </td>
            <td>
                
            </td>
        </tr>
    </table>
    </form>
    
    

</body>
</html>
