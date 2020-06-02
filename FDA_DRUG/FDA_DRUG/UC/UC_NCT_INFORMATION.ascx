<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_NCT_INFORMATION.ascx.vb" Inherits="FDA_BOOKING.UC_NCT_INFORMATION" %>

    <table style="width:100%; margin-bottom: 0px;" class="table">
          
        
            <tr>
                <td style="width:25%;text-align:right;padding-right:5%;" >

                    วันที่ยื่นคำขอ : </td>
                 <td  style="width:25%;">

                        <%--<asp:TextBox ID="Txt_schedule_date" runat="server" CssClass="input-lg" Width="80%"></asp:TextBox>--%>
                     <%--<asp:DropDownList ID="Ddl_date" runat="server"  Width="80%" CssClass="input-lg" AutoPostBack="True" >
                     </asp:DropDownList>--%>
                        <asp:Label ID="lbl_DATE" runat="server" Text=""></asp:Label>  

                    </td>
                   <td  style="width:25%;text-align:right;padding-right:5%;">

                       สถานะ :</td>
                  <td style="width:25%;">

                        <asp:Label ID="lbl_STATUS_NAME" runat="server" Text=""></asp:Label>  

                    </td>
            </tr>
              <tr>
                <td  style="width:25%;text-align:right;padding-right:5%;">

                    ชื่อผู้รับนุญาต :</td>
                 <td >

                        <%--<asp:TextBox ID="Txt_schedule_date" runat="server" CssClass="input-lg" Width="80%"></asp:TextBox>--%>
                     <%--<asp:DropDownList ID="Ddl_date" runat="server"  Width="80%" CssClass="input-lg" AutoPostBack="True" >
                     </asp:DropDownList>--%>

                        <asp:Label ID="lbl_NAME" runat="server" Text=""></asp:Label>  

                    </td>
                   <td   style="width:25%;text-align:right;padding-right:5%;">

                       ชื่อสถานที่ :</td>
                  <td >

                        <asp:Label ID="lbl_LOCATION_NAME" runat="server" Text=""></asp:Label>  

                    </td>
            </tr>
              <tr>
                <td style="width:25%;text-align:right;padding-right:5%;">

                    ประเภทคำขอ :</td>
                 <td  >

                        <%--<asp:TextBox ID="Txt_schedule_date" runat="server" CssClass="input-lg" Width="80%"></asp:TextBox>--%>
                     <%--<asp:DropDownList ID="Ddl_date" runat="server"  Width="80%" CssClass="input-lg" AutoPostBack="True" >
                     </asp:DropDownList>--%>

                        <asp:Label ID="lbl_DOCUMENT_TYPE_NAME" runat="server" Text=""></asp:Label>  

                    </td>
                   <td  style="width:25%;text-align:right;padding-right:5%;" >

                       ฝ่าย :</td>
                  <td  >

                        <asp:Label ID="lbl_WORK_GROUP_NAME" runat="server" Text=""></asp:Label>  

                    </td>
            </tr>
      
        </table>

