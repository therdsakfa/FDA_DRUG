<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_PRODUCTION_DRUG_GROUP.aspx.vb" Inherits="FDA_DRUG.POPUP_LCN_PRODUCTION_DRUG_GROUP" EnableEventValidation="false" %>
<%@ Register src="../EDIT_LOCATION_STAFF/UC/UC_TABLE_DRUG_GROUP_CHANGE.ascx" tagname="UC_TABLE_DRUG_GROUP_CHANGE" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.9.1.js"></script>
    <script type ="text/javascript" >


        function CallPrint() {
            var prtContent = document.getElementById('main');
            var WinPrint = window.open('', '', 'width=800,height=650,scrollbars=1,menuBar=1');
            var str = prtContent.innerHTML;
            debugger;
            WinPrint.document.write(str);
            WinPrint.document.close();
            WinPrint.print();
            return false;
        }

        jQuery.fn.highlight = function (str, className) {
            var regex = new RegExp(str, "gi");
            return this.each(function () {
                $(this).contents().filter(function () {
                    return this.nodeType == 3;
                }).replaceWith(function () {

                    return (this.nodeValue || "").replace(regex, function (match) {

                        return "<span class=\"" + className + "\">" + match + "</span>";
                    });
                });
            });
        };
        $(document).ready(function () {
            $('#Submit2').click(function (e) {
                e.preventDefault();


                //   $('#Button2').click();

                ClearHighlight();
                var txt = $("#TextBox1").val();
                //var txt = 'ล้าน';
                $("#body *").highlight(txt, "highlightWord");


                $('html, body').animate({
                    scrollTop: $('.highlightWord').offset().top

                }, 2000);

            });

            function ClearHighlight() {
                $(".highlightWord").replaceWith(function () { return $(this).contents(); });
                //$(this).toggle();
                //$('#hl').toggle();

            }

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlPerson" runat="server">
    <div style="width:900px" id="main">
         <h3>
            รายการหมวดยาแผนปัจจุบันที่ขออนุญาตผลิต
        </h3>
        <table class="table" style="width:100%;">
            <tr>
                <td>
                    <uc1:UC_TABLE_DRUG_GROUP_CHANGE ID="UC_TABLE_DRUG_GROUP_CHANGE1" runat="server" />
                </td>
            </tr>
        </table>
        </div>
        </asp:Panel>
    <div class="panel-footer">
        <center>
          <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg"/>
            <asp:Button ID="Button1" runat="server" Text="Button"/>
        </center>
        
    </div>

</asp:Content>
