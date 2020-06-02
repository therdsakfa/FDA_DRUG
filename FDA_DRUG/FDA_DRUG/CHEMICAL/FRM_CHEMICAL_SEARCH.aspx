<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_CHEMICAL_SEARCH.aspx.vb" Inherits="FDA_DRUG.FRM_CHEMICAL_SEARCH" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            font-family: inherit;
            font-weight: 500;
            line-height: 1.1;
            color: inherit;
            font-size: 30px;
            width: 7%;
            margin-top: 20px;
            margin-bottom: 10px;
            height: 47px;
        }
        .auto-style3 {
            width: 17%;
        }
        .auto-style4 {
            font-family: inherit;
            font-weight: 500;
            line-height: 1.1;
            color: inherit;
            font-size: 30px;
            width: 22%;
            margin-top: 20px;
            margin-bottom: 10px;
            height: 47px;
        }
        .auto-style5 {
            width: 22%;
        }
        .auto-style6 {
            width: 7%;
        }
        .auto-style7 {
            width: 17%;
            height: 47px;
        }
        .auto-style8 {
            width: 25%;
            height: 47px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="h1">
        ค้นหาเลขสาร
    </div>
    <hr />

    <table  style="width:100%;">
        <tr>
            <td class="auto-style4" style="text-align:right">
              
                 cas no. :&nbsp; </td>
            
             <td class="auto-style7"  >
                   <asp:TextBox ID="txt_casno" runat="server" CssClass="h4"></asp:TextBox >
            </td>
             
                  <td style="text-align:left;" class="auto-style2">
                ชื่อสาร :</td>
             <td class="auto-style8">
                 <asp:TextBox ID="txt_casname" runat="server" CssClass="h4"></asp:TextBox>
            </td>
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
            <td colspan="4" style="text-align:center;">
  <asp:GridView ID="GV_data" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
           <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="IDA" HeaderText="รหัสประจำสาร" ItemStyle-Width="0%" ></asp:BoundField>
                         <asp:BoundField DataField="iowacd" HeaderText="เลขประจำสาร" ItemStyle-Width="0%"   Visible="false"></asp:BoundField>
                         <asp:BoundField DataField="iowanm" HeaderText="ชื่อสาร" ItemStyle-Width="0%" ></asp:BoundField>
                         <asp:BoundField DataField="cas_number" HeaderText="เลขสาร" ItemStyle-Width="0%"  Visible="false" ></asp:BoundField>
                         <asp:BoundField DataField="aori" HeaderText="AORI" ItemStyle-Width="0%"  Visible="false" ></asp:BoundField>
                    </Columns>
       <EditRowStyle BackColor="#2461BF" />
           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#8CB343" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
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
