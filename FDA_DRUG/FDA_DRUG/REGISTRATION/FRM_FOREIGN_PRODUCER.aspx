<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_FOREIGN_PRODUCER.aspx.vb" Inherits="FDA_DRUG.FRM_FOREIGN_PRODUCER" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="h1">
         ค้นหาผู้ผลิตต่างประเทศ
    </div>
    <hr />

    <table  style="width:100%;">
        <tr>
            <td class="auto-style4" style="text-align:right;width:40%;">
              
                 ชื่อผู้ผลิต :</td>
            
             <td class="auto-style7"  >
                   <asp:TextBox ID="txt_name" runat="server" CssClass="input-sm" Width="50%"></asp:TextBox >
            </td>
             
                  <td style="text-align:left;" class="auto-style2">
                      &nbsp;</td>
             <td class="auto-style8">
                 &nbsp;</td>
        </tr>
            <tr>
 
             <td class="auto-style5" >
               </td>
             <td class="auto-style3">
               
            </td>
                           <td class="auto-style6" >
            </td>
             <td>
                 &nbsp;</td>
        </tr>
            <tr>
            <td colspan="4" style="text-align:center;" class="auto-style9">
                <asp:Button ID="btn_search" runat="server" Text="ค้นหา" CssClass="btn-lg" Width="20%" />
                    
                <asp:Button ID="btn_export" runat="server" Text="Export All" CssClass="btn-lg" Style="margin-left:5%" Width="20%" />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="4">
  <asp:GridView ID="GV_data" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
           <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="IDA" HeaderText="รหัสสถานที่" ItemStyle-Width="5%" ></asp:BoundField>
                         <asp:BoundField DataField="engfrgnnm" HeaderText="ชื่อผู้ผลิต" ItemStyle-Width="45%"  ></asp:BoundField>
                         <asp:BoundField DataField="fulladdr" HeaderText="ที่อยู่" ItemStyle-Width="50%"  ></asp:BoundField>
                    </Columns>
       <EditRowStyle BackColor="#2461BF" />
           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#8CB343" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#2461BF" ForeColor="White"/>
           <RowStyle BackColor="#EFF3FB" />
           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
           <SortedAscendingCellStyle BackColor="#F5F7FB" />
           <SortedAscendingHeaderStyle BackColor="#6D95E1" />
           <SortedDescendingCellStyle BackColor="#E9EBEF" />
           <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>



                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            </td>
        </tr>
    </table>
</asp:Content>
