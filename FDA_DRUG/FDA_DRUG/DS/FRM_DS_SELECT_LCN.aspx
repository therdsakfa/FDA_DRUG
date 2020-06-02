<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="../MasterPage/MAIN_PRODUCT_ID.Master" CodeBehind="FRM_DS_SELECT_LCN.aspx.vb" Inherits="FDA_DRUG.FRM_DS_SELECT_LCN" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="panel-heading panel-title" style="height: 70px">
            <p class="h3">
                รายการใบอนุญาต
            </p>
        </div>
            <hr />
            <telerik:RadGrid ID="rg_name" runat="server" AllowPaging="true" PageSize="5" AllowFilteringByColumn="true">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>

                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>

                    <Columns>

                        <telerik:GridBoundColumn DataField="LCNNO_MANUAL" FilterControlAltText="Filter LCNNO_MANUAL column" HeaderText="เลขที่ใบอนุญาต" ReadOnly="True" SortExpression="LCNNO_MANUAL" UniqueName="LCNNO_MANUAL">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column" HeaderText="ชื่อสถานที่" ReadOnly="True" SortExpression="thanameplace" UniqueName="thanameplace">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                            HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn>
                            <ItemTemplate>
                                <asp:Button ID="HL_SELECT" runat="server" Text="เลือกข้อมูล" CommandName="sel" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>

                    </Columns>

                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>

                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                </MasterTableView>

                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                <FilterMenu EnableImageSprites="False"></FilterMenu>


            </telerik:RadGrid>

            <br />
    <div class="panel-heading panel-title" style="height: 70px">
<p class="h3">Product ID</p>
        </div>
            
            <hr />
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="10">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LCN_IDA" FilterControlAltText="Filter LCN_IDA column" HeaderText="LCN_IDA"
                            SortExpression="LCN_IDA" UniqueName="LCN_IDA" Display="false">
                        </telerik:GridBoundColumn>
                        
                        <telerik:GridBoundColumn DataField="stat_name" FilterControlAltText="Filter stat_name column"
                            HeaderText="สถานะ" SortExpression="stat_name" UniqueName="stat_name">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LCNNO_DISPLAY" FilterControlAltText="Filter LCNNO_DISPLAY column"
                            HeaderText="เลขที่ผลิตภัณฑ์" SortExpression="LCNNO_DISPLAY" UniqueName="LCNNO_DISPLAY">
                        </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn DataField="TRADE_NAME" FilterControlAltText="Filter TRADE_NAME column"
                            HeaderText="ชื่อผลิตภัณฑ์" SortExpression="TRADE_NAME" UniqueName="TRADE_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="sel" UniqueName="btn_sel" Text="เลือกข้อมูล">

                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
</asp:Content>
