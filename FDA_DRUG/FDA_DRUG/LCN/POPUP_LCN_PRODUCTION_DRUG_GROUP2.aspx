<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="POPUP_LCN_PRODUCTION_DRUG_GROUP2.aspx.vb" Inherits="FDA_DRUG.POPUP_LCN_PRODUCTION_DRUG_GROUP2" EnableEventValidation="false" %>
<%@ Register src="../EDIT_LOCATION_STAFF/UC/UC_TABLE_DRUG_GROUP_CHANGE.ascx" tagname="UC_TABLE_DRUG_GROUP_CHANGE" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <%--<style type="text/css">
        body { font-family:'Angsana New';
               font-size:20px;
        }
    </style>--%>
    <title></title>
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
</head>
<body>
    <form id="form1" runat="server">
        <div id="ss2s" runat="server">
            <asp:Panel ID="pnlPerson" runat="server">
                <div style="width: 900px" id="main">
                    <h3>รายการหมวดยาแผนปัจจุบันที่ขออนุญาตผลิต
                    </h3>
                    <table class="table" style="width: 100%;">
                        <tr>
                            <td>
                                <uc1:UC_TABLE_DRUG_GROUP_CHANGE ID="UC_TABLE_DRUG_GROUP_CHANGE1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    <div class="panel-footer">
        <center>
            <asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" CssClass="btn-lg"/>
          <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg"/>
            <asp:Button ID="btn_goto" runat="server" Text="หน้าสำหรับพิมพ์" CssClass="btn-lg"/>
            <asp:Button ID="btn_Export" runat="server" Text="Export" CssClass="btn-lg"/>
        </center>
        
    </div>
    </form>
</body>
</html>
