<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm25.aspx.vb" Inherits="FDA_DRUG.WebForm25" %>

<%@ Register Src="~/DS/UC/UC_DS_PORYOR8.ascx" TagPrefix="uc1" TagName="UC_DS_PORYOR8" %>
<%@ Register Src="~/DS/UC/UC_DS_CHECAL_DETAIL.ascx" TagPrefix="uc1" TagName="UC_DS_CHECAL_DETAIL" %>



<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

* {
  -webkit-box-sizing: border-box;
     -moz-box-sizing: border-box;
          box-sizing: border-box;
}
  * {
    color: #000 !important;
    text-shadow: none !important;
    background: transparent !important;
    -webkit-box-shadow: none !important;
            box-shadow: none !important;
  }
  *{-webkit-box-sizing:border-box;-moz-box-sizing:border-box;box-sizing:border-box}*{color:#000!important;text-shadow:none!important;background:transparent!important;-webkit-box-shadow:none!important;box-shadow:none!important}
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" AllowMultiRowSelection="true">
            <MasterTableView>
                <Columns>
                    <%--<telerik:GridCheckBoxColumn UniqueName="chk" DataField="chk">

                    </telerik:GridCheckBoxColumn>--%>

                   <%-- <telerik:GridClientSelectColumn UniqueName="chk" ></telerik:GridClientSelectColumn>--%>
                    <telerik:GridTemplateColumn DataField="chk" UniqueName="chk">
                        <ItemTemplate>
                            <asp:CheckBox ID="cb_chk" runat="server" />
                        </ItemTemplate>

                    </telerik:GridTemplateColumn>

                    <telerik:GridBoundColumn DataField="IDA" Display="false" UniqueName="IDA"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="P_ID" Display="false" UniqueName="P_ID"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="S_ID" Display="false" UniqueName="S_ID"></telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn UniqueName="name">
                        <ItemTemplate>
                            <telerik:RadComboBox ID="rcb_name" runat="server" filter="Contains"></telerik:RadComboBox>
                            <asp:Label ID="lbl_name" runat="server" Text="" style="display:none;"></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn UniqueName="skill">
                        <ItemTemplate>
                            <telerik:RadComboBox ID="rcb_skill" runat="server" filter="Contains"></telerik:RadComboBox>
                            <asp:Label ID="lbl_skill" runat="server" Text="" style="display:none;"></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true">
                            <Selecting AllowRowSelect="true" />
                        </ClientSettings>
        </telerik:RadGrid>
       <%-- <a href="DRUG_PRODUCT_ID/POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2.aspx">DRUG_PRODUCT_ID/POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2.aspx</a>--%>

    </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Panel ID="Panel4" runat="server">
            <asp:CheckBoxList ID="cbl_change" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">เปลี่ยนผู้รับอนุญาต</asp:ListItem>
                <asp:ListItem Value="2">เปลี่ยนสถานที่ตั้ง</asp:ListItem>
                <asp:ListItem Value="3">เปลี่ยนผู้ดำเนินกิจการ</asp:ListItem>
            </asp:CheckBoxList>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" GroupingText="เปลี่ยนผู้รับอนุญาต" style="display:none;">
            <table width="100%">
                <tr>
                    <td width="30%">ชื่อผู้รับอนุญาต (เดิม)</td>
                    <td>
                        <asp:Label ID="lbl_lcnsnm_old" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>ชื่อผู้รับอนุญาต (ใหม่)</td>
                    <td>
                        <asp:TextBox ID="txt_ctzid_lcn" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_search_lcn" runat="server" Text="ค้นหา" />
                        <asp:HiddenField ID="hf_lcn" runat="server" />
                        <asp:Label ID="lbl_lcnname_new" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel2" runat="server" GroupingText="เปลี่ยนสถานที่" style="display:none;">
            <table width="100%">
                <tr>
                    <td width="30%">ชื่อสถานที่ (เดิม)</td>
                    <td>
                        <asp:Label ID="lbl_thanameplace_old" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>ชื่อสถานที่ (ใหม่)</td>
                    <td>
                        <asp:DropDownList ID="ddl_placename" runat="server" AutoPostBack="True" Width="300px">
                        </asp:DropDownList>
                        <asp:HiddenField ID="hf_place" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>ที่ตั้ง (เดิม)</td>
                    <td>
                        <asp:Label ID="lbl_location_old" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>ที่ตั้ง (ใหม่)</td>
                    <td>
                        <asp:Label ID="lbl_location_new" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <br />
        <asp:Panel ID="Panel3" runat="server" GroupingText="ผู้ดำเนินกิจการ" style="display:none;">
            <table width="100%">
                <tr>
                    <td colspan="2">หากยังไม่ได้เพิ่มผู้ดำเนินรายใหม่กรุณา
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/EDIT_LOCATION_STAFF/FRM_ADD_NEW_BSN.aspx" Target="_blank">คลิกที่นี่</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="30%">ชื่อผู้ดำเนินกิจการเดิม : </td>
                    <td>
                        <asp:Label ID="lbl_old_bsn" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">กรอกเลข 13 หลัก เพื่อดึงข้อมูลผู้ดำเนิน :</td>
                    <td>
                        <asp:TextBox ID="txt_ctzid" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
                        <asp:HiddenField ID="hf_bsn" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">ชื่อผู้ดำเนินใหม่ :</td>
                    <td>
                        <asp:Label ID="lbl_new_bsn" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
                                                  <asp:DropDownList ID="ddl_cnsdcd" runat="server" DataTextField="STATUS_NAME" DataValueField="STATUS_ID">
                         </asp:DropDownList>
                         
        <asp:Button ID="Button3" runat="server" Text="Button" />
                         
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" Text="รันข้อมูล bsn" />
                         
        <asp:Button ID="Button5" runat="server" Text="Button" />
                         
        <br />
        <br />
        <br />
        <asp:TextBox ID="txt_rc_no" runat="server"></asp:TextBox>
        <asp:Button ID="btn_run_R" runat="server" Text="ส่งค่าเลข RC" />
        <br />
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <asp:Button ID="Button6" runat="server" Text="Button" />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
                         
    </form>
</body>
</html>
