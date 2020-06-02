<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_REGISTRATION_ANIMAL_DETAIL_OTHER.aspx.vb" Inherits="FDA_DRUG.FRM_REGISTRATION_ANIMAL_DETAIL_OTHER" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="UC/UC_PRODUCCER.ascx" tagname="UC_PRODUCCER" tagprefix="uc1" %>
<%@ Register Src="~/REGISTRATION/UC/UC_CHEM.ascx" TagPrefix="uc1" TagName="UC_CHEM" %>

<%@ Register src="UC/UC_DRUG_ATC.ascx" tagname="UC_DRUG_ATC" tagprefix="uc2" %>
<%@ Register Src="~/REGISTRATION/UC/UC_DRUG_USE.ascx" TagPrefix="uc1" TagName="UC_DRUG_USE" %>
<%@ Register Src="~/REGISTRATION/UC/UC_OTHER_DATA.ascx" TagPrefix="uc1" TagName="UC_OTHER_DATA" %>



<%@ Register src="UC/UC_PRODUCCER_IN.ascx" tagname="UC_PRODUCCER_IN" tagprefix="uc3" %>
<%@ Register Src="~/REGISTRATION/UC/UC_REGIST_DETAIL.ascx" TagPrefix="uc1" TagName="UC_REGIST_DETAIL" %>




<%@ Register src="UC/UC_PACKAGING_DETAIL.ascx" tagname="UC_PACKAGING_DETAIL" tagprefix="uc4" %>




<%@ Register src="UC/UC_DRUG_COLOR.ascx" tagname="UC_DRUG_COLOR" tagprefix="uc5" %>




<%@ Register src="UC/UC_PACKAGING_DETAIL_V2.ascx" tagname="UC_PACKAGING_DETAIL_V2" tagprefix="uc6" %>




<%@ Register src="UC/UC_ANIMAL.ascx" tagname="UC_ANIMAL" tagprefix="uc7" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />

    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_UC_REGIST_DETAIL_ddl_dactg"));
        });

        </script>--%>
      <script type="text/javascript" >
          function click_btn1() { // คำสั่งสั่งปิด PopUp
              $('#ContentPlaceHolder1_Button1').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
          }
          </script>
    <style type="text/css">
        .RadComboBox_Default { font-size:16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" SelectedIndex="0" MultiPageID="RadMultiPage1" Orientation="HorizontalTop">
        <Tabs>
            <telerik:RadTab runat="server" Text="1.ข้อมูลทั่วไป" Selected="True" Value="1">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="2.ขนาดบรรจุ" Value="2">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="3.1 ผู้ผลิตต่างประเทศ" Value="3">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="3.2 ผู้ผลิตในประเทศ" Value="4">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="4.สูตรสาร" Value="5">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="5.การเก็บรักษา" Value="6">
            </telerik:RadTab>     
            <telerik:RadTab runat="server" Text="6.กลุ่มตำรับ" Value="7">
            </telerik:RadTab>       
            <telerik:RadTab runat="server" Text="7.ข้อบ่งใช้" Value="9">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="8.สีของยา" Value="10">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="9.ข้อมูลยาสัตว์" Value="11">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
 <table class="table" width="80%">

        <tr>
            <td colspan="2">
                <h2>ข้อมูลส่วนที่ 2 ของบัญชีรายการยา</h2>
            </td>
        </tr>
    </table>
    <br />
    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" CssClass="fa left">

        <telerik:RadPageView ID="RadPageView1" runat="server" TabIndex="1">
            <table class="table" width="100%">
                <tr>
                    <td colspan="2">
                        <uc1:UC_REGIST_DETAIL ID="UC_REGIST_DETAIL" runat="server" />
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server" TabIndex="2">
            <table class="table" width="100%">
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="Panel1" runat="server" Style="display: none;">
                            <uc4:UC_PACKAGING_DETAIL ID="UC_PACKAGING_DETAIL1" runat="server" />
                        </asp:Panel>
                        <table width="100%">
                            <tr>
                                <td>คำบรรยายขนาดบรรจุ</td>
                                <td width="70%">
                                    <asp:TextBox ID="txt_package" runat="server" TextMode="MultiLine" Height="300px" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td width="70%">
                                    <asp:Button ID="btn_save_pack" runat="server" Text="บันทึก" />
                                </td>
                            </tr>
                        </table>
                        <uc6:UC_PACKAGING_DETAIL_V2 ID="UC_PACKAGING_DETAIL_V21" runat="server" />

                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView3" runat="server" TabIndex="3">
            <table class="table" width="100%">
                <tr>
                    <td>ผู้ผลิต
                         <uc1:UC_PRODUCCER ID="UC_PRODUCCER1" runat="server" />
                        <%--<asp:Panel ID="Panel1" runat="server" Style="display: none;"></asp:Panel>
                         <asp:Panel ID="Panel2" runat="server" Style="display: none;"></asp:Panel>--%>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView9" runat="server" TabIndex="4">
            <table class="table" width="100%">
                <tr>
                    <td>
                        <uc3:UC_PRODUCCER_IN ID="UC_PRODUCCER_IN1" runat="server" />
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView4" runat="server" TabIndex="5">
            <table class="table" width="100%">
                <tr>
                    <td>ส่วนประกอบของตำรับ<uc1:UC_CHEM ID="UC_CHEM" runat="server" />
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView5" runat="server" TabIndex="6">
            <table class="table" width="100%">
                <tr>
                    <td>
                        <uc1:UC_OTHER_DATA ID="UC_OTHER_DATA" runat="server" />
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView6" runat="server" TabIndex="7">
            <table class="table" width="100%">
                <tr>
                    <td>กลุ่มตำรับ (ATC Code)
                    <uc2:UC_DRUG_ATC ID="UC_DRUG_ATC1" runat="server" />
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView7" runat="server" TabIndex="8">
            <table class="table" width="100%">
                <tr>
                    <td>
                        <uc1:UC_DRUG_USE ID="UC_DRUG_USE" runat="server" />
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView8" runat="server" TabIndex="9">
            <table class="table" width="100%">
                <tr>
                    <td>
                        <uc5:UC_DRUG_COLOR ID="UC_DRUG_COLOR1" runat="server" />
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>

        <telerik:RadPageView ID="RadPageView10" runat="server" TabIndex="11">
            <table class="table" width="100%">
                <tr>
                    <td>
                        
                        <uc7:UC_ANIMAL ID="UC_ANIMAL1" runat="server" />
                        
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</asp:Content>