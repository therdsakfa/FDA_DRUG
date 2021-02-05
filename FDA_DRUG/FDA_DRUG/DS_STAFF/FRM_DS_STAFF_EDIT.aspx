<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_DS_STAFF_EDIT.aspx.vb" Inherits="FDA_DRUG.FRM_DS_STAFF_EDIT" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
    <style type="text/css">
        .auto-style1 {
            font-size: 12px;
            line-height: 1.5;
            border-radius: 3px;
            padding: 5px 10px;
        }
        .auto-style2 {
            width: 478px;
        }
        .auto-style3 {
            width: 160px;
        }
    </style>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <center><h1>หมายเหตุการแก้ไข</h1></center>
            </div>
            <div class="panel-body">

            </div>
        
                <table class="table">
                    <tr >
                        <td align="right" class="auto-style3"><h4>หมายเหตุ :</h4></td>
                        <td class="auto-style2"><asp:TextBox ID="Txt_EDIT" runat="server" CssClass="auto-style1" Width="454px" Height="245px"></asp:TextBox></td>
                        <td><h4>ไฟล์แนบ(รายละเอียดเพิ่มเติม)</h4>
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-default" /><br />
                            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="btn-default" />
                            <br />
                            <h5>กำหนดส่งเอกสาร</h5>
                            <telerik:RadDatePicker ID="rdp_cncdate" Runat="server"></telerik:RadDatePicker>
                            <br />
                            <br />
                            <asp:Button ID="btn_Upload" runat="server" Text="อัพโหลด"   CssClass=" btn-lg" />
<%--                            <p style="color:red">* ให้ส่งเอกสารในะบบก่อนเวลา 23.59 น. ของวันที่ระบุข้างต้น</p>--%>
                        </td>
                    </tr>

                    <%--<tr ><td>วันที่</td><td>
                        <asp:TextBox ID="txt_lmdfdate" runat="server" class="input-sm" Width="154px"></asp:TextBox></td></tr>--%>

                </table>
        
        </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" OnClientClick="return confirm('คุณต้องการบันทึกข้อมูลหรือไม่')"/>
                  &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ยกเลิก"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>

