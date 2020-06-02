<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_GRID_PHARMACIST.ascx.vb" Inherits="FDA_DRUG.UC_GRID_PHARMACIST" %>
<asp:GridView ID="gv" runat="server" Width="100%" DataKeyNames="IDA" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                      <AlternatingRowStyle BackColor="White" />
                      <Columns>
                
                          <asp:BoundField  HeaderText="ชื่อเภสัชกร" ItemStyle-Width="40%" DataField="FULLNAME"/>

                        <asp:BoundField  HeaderText="สถานะการยืนยันตัวตน" ItemStyle-Width="30%" DataField="STATUS_NAME"/>
                      <asp:TemplateField ItemStyle-Width="40%">
                     <ItemTemplate>
                          
                        <asp:HyperLink ID="btn_Select" runat="server"  Target="_self" CssClass="btn-control" CommandName="sel"  CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  >ดูข้อมูล</asp:HyperLink>
                     <%--<asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" CssClass="btn-link"  CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />  --%>    
                     </ItemTemplate>
                          </asp:TemplateField>
                      </Columns>
                        <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#8CB343" Font-Bold="True" ForeColor="White"  />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                 </asp:GridView>