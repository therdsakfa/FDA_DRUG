<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_PRODUCT_ID.Master" CodeBehind="FRM_DRUG_IMPORT_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_DRUG_IMPORT_MAIN" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%--<%@ Register src="../UC/UC_Information.ascx" tagname="UC_Information" tagprefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="spinner" style="background-color: transparent; display: none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div>
        <div class="panel-heading panel-title" style="padding-left: 5%;">
            <%--     <h2>ทะเบียนยานำเข้า</h2>--%>


            <br />

            <table>
            </table>

            <br />
        </div>


    </div>

    <div class="panel-info" style="text-align: right; width: 100%">
        <div style="text-align: right; padding-left: 5%; height: 60px;">
            <asp:Button ID="btn_add" runat="server" Text="เพิ่มคำขอ" Width="170px" CssClass="btn-lg" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
            <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
        </div>
    </div>

    <hr />
    <div>
        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="20" style="margin-left: 3px; margin-bottom: 10px;" Width="100%">
            <MasterTableView AutoGenerateColumns="False">
                <Columns>
                    <telerik:GridBoundColumn DataField="NYM2_IDA" DataType="System.Int32" FilterControlAltText="Filter NYM2_IDA column" HeaderText="IDA"
                        SortExpression="NYM2_IDA" UniqueName="NYM2_IDA" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column" HeaderText="PROCESS_ID"
                        SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NYM2_DATE_TOP" FilterControlAltText="Filter NYM2_DATE_TOP column"
                        HeaderText="วันเวลาที่ส่งคำขอ" SortExpression="NYM2_DATE_TOP" UniqueName="NYM2_DATE_TOP">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NYM_TYPE" FilterControlAltText="Filter NYM_TYPE column"
                        HeaderText="ประเภท" SortExpression="NYM_TYPE" UniqueName="NYM_TYPE">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DL" FilterControlAltText="Filter DL column"
                        HeaderText="รหัสบัญชีรายการยา" SortExpression="DL" UniqueName="DL">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NYM2_WISH_MED" FilterControlAltText="Filter NYM2_WISH_MED column"
                        HeaderText="ชื่อยา (Th/Eng)" SortExpression="NYM2_WISH_MED" UniqueName="NYM2_WISH_MED">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NYM2_NO" FilterControlAltText="Filter NYM2_NO column"
                        HeaderText="เลขดำเนินการ" SortExpression="NYM2_NO" UniqueName="NYM2_NO">   
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_ID" FilterControlAltText="Filter STATUS_ID column"
                        HeaderText="สถานะ" SortExpression="STATUS_ID" UniqueName="STATUS_ID">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                        CommandName="sel" Text="ดูข้อมูล">
                        <HeaderStyle Width="70px" />
                    </telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_upload"
                        CommandName="upload" Text="อัพโหลดเอกสารยืนยัน">
                        <HeaderStyle Width="70px" />
                    </telerik:GridButtonColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>

        <br />

        <div style="text-align: center;">
        </div>
    </div>
                          <div class="h5" style="padding-left:87%;">  
                      <asp:HyperLink ID="hl_pay" runat="server"  target="_blank"> ชำระเงินคลิกที่นี้</asp:HyperLink>
                        </div>
    <%--<div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>ผลิตภัณฑ์ยาเพื่อโครงการวิจัย</h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>--%>
</asp:Content>
