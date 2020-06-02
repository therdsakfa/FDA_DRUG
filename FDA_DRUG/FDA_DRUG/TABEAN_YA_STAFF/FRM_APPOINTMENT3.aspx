<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_APPOINTMENT3.aspx.vb" Inherits="FDA_DRUG.FRM_APPOINTMENT3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table class="table" style="width:100%;">
                   <tr>
                                <td>เลขดำเนินการ</td>
                                <td>
                                    <asp:Label ID="lbl_TR_ID" runat="server" Text="-"></asp:Label>
                                    <br />
                                </td>
                            </tr>
         <tr>
                            <td>ชื่อยาภาษาไทย/ชื่อยาภาษาอังกฤษ</td>
                            <td >
                                <asp:Label ID="lbl_name_drug" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                            <tr>
                            <td>กลุ่มประเภทคำขอ</td>
                            <td >
                                <asp:Label ID="lbl_group_name" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                          <tr>
                            <td>ประเภทคำขอ</td>
                            <td >
                                <asp:Label ID="lbl_type_name" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                            
                        <tr>
                            <td>วันที่รับเรื่อง</td>
                            <td >
                                <asp:TextBox ID="txt_date" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                               
                                <asp:Label ID="text" runat="server">  (ตัวอย่าง 31/12/2559)</asp:Label>
                               
                            </td>
                        </tr>
                         <tr>
                            <td>เลขนิติบุคคล/เลขบัตรประชาชน</td>
                            <td >
                                <asp:TextBox ID="txt_company" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                                <asp:Button ID="btn_company" runat="server" Text="ตรวจสอบชื่อผู้รับอนุญาต"  CssClass="btn-lg" Width="50%"  />
                            </td>
                        </tr>
                         <tr>
                            <td>ชื่อผู้รับอนุญาต</td>
                            <td >
                                <asp:Label ID="lbl_company" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        
                    
                         <tr>
                            <td>จำนวนวันทำการ</td>
                            <td >
                                <asp:TextBox ID="txt_number" runat="server" CssClass="input-sm" Width="20%"></asp:TextBox>
                                &nbsp;<asp:Button ID="btn_day" runat="server" CssClass="btn-lg" Text="คำนวนวัน" />
                            </td>
                        </tr>
                         <tr>
                            <td>วันที่นัด</td>
                            <td >
                               
                            <asp:Label ID="lbl_number_day" runat="server" ></asp:Label>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </td>
                        </tr>
                        
                    </table>

         <div  class="col-lg-8 col-md-8">
                               <%--<p style="text-align:right;padding-right:40%;">--%>
             <center>                                   
            <asp:Button ID="btn_add" runat="server" Text="บันทึก" CssClass="btn-lg"   />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="ยกเลิก" CssClass="btn-lg"   style="display:none;"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btn_report" runat="server" Text="ดูใบนัด" CssClass="btn-lg"  style="display:none;"  />
            </center>    
                                  
                              <%-- </p>--%>
             
                          </div>
    </form>
</body>
</html>
