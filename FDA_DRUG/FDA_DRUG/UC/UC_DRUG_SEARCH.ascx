<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DRUG_SEARCH.ascx.vb" Inherits="FDA_BOOKING.UC_DRUG_SEARCH" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
    <table style="width:100%;">
                  <tr>
                <td style="width:25%;">

                </td>
                  <td style="width:25%;">

                </td>
                  <td style="width:25%;">

                </td>
                  <td style="width:25%;">

                </td>
            </tr>
              <tr>
                <td >

                    เลข C</td>
                 <td >

                        <%--<asp:TextBox ID="Txt_schedule_date" runat="server" CssClass="input-lg" Width="80%"></asp:TextBox>--%>
                  <%--   <asp:DropDownList ID="Ddl_date" runat="server"  Width="80%" CssClass="input-lg" AutoPostBack="True" >
                     </asp:DropDownList>--%>
                        <asp:TextBox ID="txt_c_number" runat="server"  Width="80%" CssClass="input-sm"></asp:TextBox>

                        <br />
                        
                    </td>
                  <td  >

                      กระบวนการ </td>
                  <td >

                   <telerik:RadComboBox ID="rcb_doc" Runat="server" Width="100%" AutoCompleteSeparator="Contains "  Filter="Contains" AllowCustomText="false" AutoPostBack="true" style="margin-bottom: 0">
                   <Items>
                       <telerik:RadComboBoxItem runat="server" Text="ทั้งหมด" Value="0" />
                     
                   </Items>
               </telerik:RadComboBox>

                </td>
            </tr>
</table>