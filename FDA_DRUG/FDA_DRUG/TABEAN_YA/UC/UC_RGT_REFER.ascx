<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_RGT_REFER.ascx.vb" Inherits="FDA_DRUG.UC_RGT_REFER" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
.RadGrid_Default{border:1px solid #828282;background-color:white;color:#333;font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid_Default .rgMasterTable{font-family:"Segoe UI",Arial,Helvetica,sans-serif;font-size:12px;line-height:16px}.RadGrid .rgMasterTable{border-collapse:separate;border-spacing:0}.RadGrid table.rgMasterTable tr .rgExpandCol{padding-left:0;padding-right:0;text-align:center}.RadGrid_Default .rgHeader{color:#333}.RadGrid_Default .rgHeader{border:0;border-bottom:1px solid #828282;background:#eaeaea 0 -2300px repeat-x url('mvwres://Telerik.Web.UI, Version=2013.2.717.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Grid.sprite.gif')}.RadGrid .rgHeader{padding-top:5px;padding-bottom:4px;text-align:left;font-weight:normal}.RadGrid .rgHeader{padding-left:7px;padding-right:7px}.RadGrid .rgHeader{cursor:default}
    </style>


<table width="100%">
    <tr>
        <td>
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="10">
                <MasterTableView AutoGenerateColumns="False">
                    <Columns>
                        <telerik:GridBoundColumn DataField="full_rgtno" FilterControlAltText="Filter full_rgtno column" HeaderText="เลขทะเบียน" SortExpression="full_rgtno" UniqueName="full_rgtno">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column" HeaderText="ชื่อยา (ภาษาไทย)" SortExpression="thadrgnm" UniqueName="thadrgnm">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column" HeaderText="ชื่อยา (ภาษาอังกฤษ)" SortExpression="engdrgnm" UniqueName="engdrgnm">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </td>
    </tr>
</table>


<table style="display: none;">

    <tr>
        <td>เลขทะเบียน</td>
        <td>
            <asp:TextBox ID="txt_search" runat="server"></asp:TextBox>
            <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
        </td>
    </tr>
    <tr>
        <td colspan="2">

            <telerik:RadGrid ID="rg_search" runat="server" AllowPaging="true" PageSize="10">
                <MasterTableView AutoGenerateColumns="False">
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="chk" HeaderText="เลือก">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="iowacd" FilterControlAltText="Filter iowacd column" HeaderText="iowacd" SortExpression="iowacd" UniqueName="iowacd">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="iowanm" FilterControlAltText="Filter iowanm column" HeaderText="ชื่อสาร" SortExpression="iowanm" UniqueName="iowanm">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                    <Selecting AllowRowSelect="true" />
                </ClientSettings>
            </telerik:RadGrid>

        </td>
    </tr>
    <tr>
        <td>ประเภทการอ้างอิง :</td>
        <td>
            <asp:RadioButtonList ID="rdl_ref_type" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">Refered</asp:ListItem>
                <asp:ListItem Value="2">Transfered</asp:ListItem>
                <asp:ListItem Value="3">Copied</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>ขอที่</td>
        <td>
            <asp:TextBox ID="txt_request_at" runat="server"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" />
        </td>
    </tr>

    <tr>
        <td>ชื่อยาไทย :</td>
        <td>
            <asp:Label ID="lbl_drugname_th" runat="server" Text="-"></asp:Label>
        </td>
    </tr>

    <tr>
        <td>ชื่อยาอังกฤษ :</td>
        <td>
            <asp:Label ID="lbl_drugname_eng" runat="server" Text="-"></asp:Label>
        </td>
    </tr>

</table>