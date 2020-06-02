<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_officer_Animal_drug.ascx.vb" Inherits="FDA_SEARCH_DRUG.officer_Animal_drug" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .auto-style2 {
        height: 28px;
    }
</style>
<%--<table style="background-color:  white; width: 1130px; height: 40px;" border="1">

        <tr>
            <td  bgcolor="Lavender" width="197px" height="28px"><asp:Label ID="Label5" runat="server" Text="ประเภทสัตว์"></asp:Label></asp:Label></td>
            <td ><asp:Label ID="lb_ampartnm" runat="server" ></asp:Label></td>  
                      
          </tr>

        
        <tr>
            <td bgcolor="Lavender" width="197px" height="28px">&nbsp<asp:Label ID="Label1" runat="server" Text="ชนิดสัตว์"></asp:Label></td>  
       <td ><asp:Label ID="lb_amltpnm" runat="server" ></asp:Label></td>          
          
 </tr>

            <tr>
           <td bgcolor="Lavender" width="197px" height="28px"><asp:Label ID="Label7" runat="server" Text="การใช้"></asp:Label></td>    
           <td>  <asp:Label ID="lb_usetpnm" runat="server" ></asp:Label></td>    
</tr>
    </table>--%>



<%--<table bgcolor="Lavender"  border="1" width: 1130px; height: 388px;>
    <tr>
        <td bgcolor="Lavender" width="100px"  height="28px" >
            <asp:Label ID="Label1" runat="server" Text="ประเภทสัตว์"></asp:Label>
        </td>

        <td bgcolor="Lavender" width="180px"  height="28px">
            <asp:Label ID="Label2" runat="server" Text="ชนิดสัตว์"></asp:Label>
        </td>
         <td bgcolor="Lavender" width="100px"  height="28px">
             <asp:Label ID="Label3" runat="server" Text="การใช้"></asp:Label>
        </td>
     <td bgcolor="Lavender" width="100px"  height="28px">
             <asp:Label ID="Label4" runat="server" Text="ส่วนบริโภค"></asp:Label>
        </td>
          <td bgcolor="Lavender" width="100px"  height="28px">
             <asp:Label ID="Label5" runat="server" Text="ระยะหยุดยา"></asp:Label>
        </td>
          <td bgcolor="Lavender" width="100px"  height="28px">
             <asp:Label ID="Label6" runat="server" Text="ขนาดและวิธีใช้"></asp:Label>
        </td>
    </tr>
    <tr>
        <td width="100px" height="28px">
            <asp:Label ID="lb_ampartnm" runat="server" ></asp:Label>
        </td>
        <td width="180px" height="28px">

        <asp:Label ID="lb_amltpnm" runat="server" ></asp:Label>
        </td>
         <td width="100px" height="28px">
            <asp:Label ID="lb_usetpnm" runat="server" ></asp:Label>
        </td>
         <td width="100px" height="28px">
            <asp:Label ID="lb_consumer" runat="server" ></asp:Label>
        </td>
          <td width="100px" height="28px">
            <asp:Label ID="lb_term" runat="server" ></asp:Label>
        </td>
            <td width="100px" height="28px">
            <asp:Label ID="lb_dosage" runat="server" ></asp:Label>
        </td>
    </tr>
    
</table>--%>

<telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="100%" PageSize="20">
                    <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="IDA" Display="false" FilterControlAltText="Filter IDA column" UniqueName="IDA" HeaderText="IDA">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="lcnno" Display="false" FilterControlAltText="Filter lcnno column" UniqueName="lcnno" HeaderText="lcnno">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="lcnsid" Display="false" FilterControlAltText="Filter lcnsid column" UniqueName="lcnsid" HeaderText="lcnsid">
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="thadrgnm" Display="false" FilterControlAltText="Filter thadrgnm column" UniqueName="thadrgnm" HeaderText="thadrgnm">
                            </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="engdrgnm" Display="false" FilterControlAltText="Filter engdrgnm column" UniqueName="engdrgnm" HeaderText="engdrgnm">
                            </telerik:GridBoundColumn>



                              <telerik:GridBoundColumn DataField="Newcode" Display="false" FilterControlAltText="Filter Newcode column" UniqueName="Newcode" HeaderText="Newcode">
                            </telerik:GridBoundColumn>

                              <telerik:GridBoundColumn DataField="drgtpcd" Display="false" FilterControlAltText="Filter drgtpcd column" UniqueName="drgtpcd" HeaderText="drgtpcd">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="rgtno" Display="false" FilterControlAltText="Filter rgtno column" UniqueName="rgtno" HeaderText="rgtno">
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="rgttpcd" Display="false" FilterControlAltText="Filter rgttpcd column" UniqueName="rgttpcd" HeaderText="rgttpcd">
                            </telerik:GridBoundColumn>

                             <telerik:GridBoundColumn DataField="dsgcd" Display="false" FilterControlAltText="Filter dsgcd column" UniqueName="dsgcd" HeaderText="dsgcd">
                            </telerik:GridBoundColumn>



                            <%-- <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="ลำดับ" UniqueName="TemplateColumn">    
    <ItemTemplate>
        <%# Container.ItemIndex + 1%>
    </ItemTemplate>
                  </telerik:GridTemplateColumn>--%>
                           <%-- <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column" HeaderText="ลำดับ"
                                SortExpression="IDA" UniqueName="IDA">
                            </telerik:GridBoundColumn>
--%>

                            
                            <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column" HeaderText="ida" Display="false">
                            </telerik:GridBoundColumn>
                            



<%--                                    <telerik:GridBoundColumn DataField="rownum" FilterControlAltText="Filter rownum column" HeaderText="ลำดับ">
                 </telerik:GridBoundColumn>--%>
                  

                            <telerik:GridBoundColumn DataField="amltpnm" FilterControlAltText="Filter amltpnm column" HeaderText="ประเภทสัตว์">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="amlsubnm" FilterControlAltText="Filter amlsubnm column" HeaderText="ชนิดสัตว์">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="usetpnm" FilterControlAltText="Filter usetpnm column" HeaderText="การใช้">
                            </telerik:GridBoundColumn>

                         <%--   <telerik:GridBoundColumn DataField="thaclassnm" FilterControlAltText="Filter thaclassnm column" HeaderText="ประเภทยา">
                            </telerik:GridBoundColumn>

                            <telerik:GridBoundColumn DataField="cncnm" FilterControlAltText="Filter cncnm column" HeaderText="สถานะ">
                            </telerik:GridBoundColumn>
                           --%>

                            <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="detail" Text="รายละเอียด" Visible="false" UniqueName="detail">
                            </telerik:GridButtonColumn>

                            <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="att" Text="ส่วนบริโภค" UniqueName="att"  >
                                <HeaderStyle Width="100px" />
                                <ItemStyle Font-Underline="True" ForeColor="#0033CC" />
                            </telerik:GridButtonColumn>
                        </Columns>

                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                        </EditFormSettings>

                        <%--<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
<PagerStyle PageSizeControlType="RadComboBox" PageSizes="10;20;50;100"></PagerStyle>--%>
                        <PagerStyle Mode="NextPrevAndNumeric" PageSizeLabelText="Page Size: " PageSizes="5,10,25,50,100" />
                    </MasterTableView>


                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                </telerik:RadGrid>
