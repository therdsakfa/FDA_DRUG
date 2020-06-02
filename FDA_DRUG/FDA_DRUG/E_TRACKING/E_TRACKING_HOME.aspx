<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="E_TRACKING_HOME.aspx.vb" Inherits="FDA_DRUG.E_TRACKING_HOME" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width:100%;">
             <tr>
               
                  <td colspan="3" >
                      <h2 style="text-align:center;">ค้นหาผู้ประกอบการ</h2>
                </td>
            </tr>
            <tr >
        
                <td style="width:40%; height:39px;padding-left:32%">
                    เลขนิติบุคคล :</td>
                 <td style="width:33%; height: 39px; text-align:center">

                     <asp:TextBox ID="Txt_taxno" runat="server"  Width="75%" CssClass="form-control"></asp:TextBox>

                </td>
                <td style="width:25%; height: 70px;">

                    <asp:Button ID="Button1" runat="server" Text="ค้นหา" CssClass="btn btn-primary" />
                </td>
              </tr>
            </table>

             </div>
    <br />
    <br />
    <div style="width:100%; clip: rect(auto, auto, auto, 40%); padding-left: inherit;" ; class="text-danger" >

               

                <asp:GridView ID="gvDataMember" DataKeyNames="lcnsid,thanm" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="Vertical" CssClass="panel panel-default" Width="50%" ForeColor="Black" BackColor="White" BorderColor="#DEDFDE" BorderStyle="Groove" BorderWidth="2px" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White"  />
                    <Columns>

                      <asp:BoundField DataField="lcnsid" HeaderText="รหัสผู้ประกอบการ " SortExpression="lcnsid"    />
                            

                        <asp:BoundField DataField="thanm" HeaderText="ชื่อผู้ประกอบการ" SortExpression="name"/>
                        <asp:BoundField DataField="lcnscd" HeaderText="lcnscd" SortExpression="lcnscd" Visible="false" />

                           
                          <asp:TemplateField HeaderText=" ">
                        <ItemTemplate>
                            
                        <asp:LinkButton  id="lbtView" runat="server"  CommandName="Select"  Font-Underline="false">ยืนยัน</asp:LinkButton>
                        </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                    <FooterStyle BackColor="#CCCC99" Width="20%"  HorizontalAlign="Center"/>
                    <HeaderStyle BackColor="#6B696B" Width="30%" Font-Bold="True" ForeColor="White"  HorizontalAlign="Center"/>
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE"  Width="40%"/>
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />

                </asp:GridView>
                       </div>
</asp:Content>
