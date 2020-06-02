<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_NYM1.aspx.vb" Inherits="FDA_DRUG.POPUP_NYM1" %>

<%@ Register Src="~/UC/UC_ATTACH_DRUG.ascx" TagPrefix="uc1" TagName="UC_ATTACH_DRUG" %>


<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 265px;
        }

        .box {
            border-top: 3px solid #8CB340;
            /*border-bottom: 3px solid #8CB340;*/
            margin: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(window).load(function () {
                $.ajax({
                    type: 'POST',
                    data: { submit: true },
                    success: function (result) {
                        // $('#spinner').fadeOut('slow');
                    }
                });
            });

            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            $('#ContentPlaceHolder1_btn_upload').click(function () {

                $('#spinner').toggle('slow');
                Popups('POPUP_LCN_UPLOAD.aspx');
                return false;
            });

            $('#ContentPlaceHolder1_btn_download').click(function () {
                $('#spinner').fadeIn('slow');
                Popups('POPUP_LCN_DOWNLOAD.aspx');
                return false;
            });

            function Popups(url) { // สำหรับทำ Div Popup
                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }

            function close_modal() { // คำสั่งสั่งปิด PopUp
                $('#myModal').modal('hide');
                $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
            }
        });

        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

        }
    </script>
    <script type="text/javascript">
        function closespinner() {
            $('#spinner').fadeOut('slow');
            alert('Download Success');
            $('#ContentPlaceHolder1_Button1').click();

        }

    </script>
    <div id="spinner" style="background-color: transparent; display: none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div style="width: 100%; text-align: left">
        <div style="width: auto; float: left; text-align: center; display: none">
            <h4>ยื่นข้อมูลที่&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbtn_bangkok" runat="server" Checked="True" GroupName="pvn" Text="ศูนย์ อย." />
                &nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:RadioButton ID="rbtn_other" runat="server" GroupName="pvn" Text="ต่างจังหวัด" />
            </h4>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                 </asp:ScriptManager>
        <asp:Label ID="hidden_times" runat="server" Visible="False"></asp:Label>
        <center>
             <center><h3>
                 
                 ข้อมูลใบอนุญาต</h3></center>
<div class="box">
<table class="table">
    <tr>
            <td class="auto-style1">
                เลขที่ใบอนุญาต :</td>
            <td>
                <asp:Label ID="lbl_lcnno2" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                คำขออนุญาตนำหรือสั่งยาฯ ณ สถานที่ชื่อ :</td>
            <td>
                <asp:Label ID="lbl_place_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
         <tr>
        <td class="auto-style1">
            ชื่อผู้ดำเนินกิจการ :</td>
        <td>
            <asp:Label ID="lbl_bsn_prefixed" runat="server" Text="-"></asp:Label>
        </td>
        </tr>
        <tr>
            <td class="auto-style1">
               ที่อยู่ :</td>
            <td>
                <asp:Label ID="lbl_number" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                ซอย :</td>
            <td>
                <asp:Label ID="lbl_lane" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
               ถนน :</td>
            <td>
                <asp:Label ID="lbl_road" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
               หมู่ :</td>
            <td>
                <asp:Label ID="lbl_village_no" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                ตำบล :</td>
            <td>
                <asp:Label ID="lbl_sub_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                อำเภอ :</td>
            <td>
                <asp:Label ID="lbl_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                จังหวัด :</td>
            <td>
                <asp:Label ID="lbl_province" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
             โทรศัพท์ :</td>
            <td>
                <asp:Label ID="lbl_tel" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
</table>
</div>

            <%--<div class="hide" runat="server" style="display:none";>
                <h3>ประวัติคำขอ</h3>
                <div>

                </div>
            </div>--%>

            <h3>จำนวนนำเข้า นยม1</h3>

        <div class="box">
            <br />

                   <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" Width="50%" ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="tradenm" HeaderText="ชื่อการค้า" DataField="tradenm" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="commonnm" HeaderText="ชื่อสามัญ" DataField="commonnm" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="imp_amount" HeaderText="โควต้านำเข้า" DataField="imp_amount" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="quota_left" HeaderText="จำนวนโควต้าที่เหลือ" DataField="quota_left" >
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    </telerik:RadGrid>

                                    <br />

            <div id="imp" runat="server">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
            </asp:DropDownList>

            &nbsp;

            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox>

        &nbsp;
            <asp:Label ID="Label1" runat="server"></asp:Label>
&nbsp;
            <asp:Button ID="Button1" CssClass="btn-lg" runat="server" Text="บันทึก" />

            </div>
            <asp:Label ID="cal_q" runat="server"></asp:Label>

            <br />
            <br />
            <asp:Button ID="Button2" CssClass="btn-lg" runat="server" Text="ยื่นคำขอ นยม1" />

            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            <br />

        </div>
         </center>
    </div>
</asp:Content>
