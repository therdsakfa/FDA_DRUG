<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_EXPERT_ASSIGN_V3.aspx.vb" Inherits="FDA_DRUG.FRM_EXPERT_ASSIGN_V3" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../../css/css_radgrid.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table">
        <tr>
            <td align="right" style="width:10%;">ชื่อผลิตภัณฑ์ :
            </td>
            <td style="width:20%;">
                <asp:Label ID="lbl_product_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
             <td align="right" style="width:10%;">เลขทะเบียน :
            </td>
            <td style="width:20%;">
                <asp:Label ID="lbl_lcnno_display" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:10%;">ชื่อผู้อนุญาต :
            </td>
            <td style="width:10%;">
                <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:10%;">สถานะปัจจุบัน :
            </td>
            <td style="width:20%;">
                <asp:Label ID="lbl_stat" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
    </table>

    <table class="table">
        <tr>
            <td style="width:20%;">&nbsp;</td>
            <td style="width:30%;">

                <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                </telerik:RadScriptManager>

                ครั้งที่
                
                <telerik:RadNumericTextBox ID="rnt_count" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="80px">
                    <NumberFormat GroupSeparator="" DecimalDigits="0" AllowRounding="true"   KeepNotRoundedValue="false"  /> 
                    <EnabledStyle HorizontalAlign="Right" />
                </telerik:RadNumericTextBox>

            </td>
            <td style="width:20%;">
                
                <telerik:RadNumericTextBox ID="rm_amount" Runat="server" Culture="th-TH" DbValueFactor="1" LabelWidth="64px" Value="0" Width="80px">
                    <NumberFormat GroupSeparator="" DecimalDigits="0" AllowRounding="true"   KeepNotRoundedValue="false"  /> 
                    <EnabledStyle HorizontalAlign="Right" />
                </telerik:RadNumericTextBox>
                คน
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_add" runat="server" Text="เพิ่มจำนวนผชช." CssClass="btn-bg" />
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" OnClientClick="return confirm('ต้องการบันทึกหรือไม่');" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" 
                    AllowPaging="true" PageSize="10">
 
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                    SortExpression="IDA" UniqueName="IDA" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FK_EXPERT" DataType="System.Int32" FilterControlAltText="Filter FK_EXPERT column" HeaderText="FK_EXPERT"
                                    SortExpression="FK_EXPERT" UniqueName="FK_EXPERT" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FK_EXPERT_SKILL" DataType="System.Int32" FilterControlAltText="Filter FK_EXPERT_SKILL column" HeaderText="FK_EXPERT_SKILL"
                                    SortExpression="FK_EXPERT_SKILL" UniqueName="FK_EXPERT_SKILL" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FK_COMMENT" DataType="System.Int32" FilterControlAltText="Filter FK_COMMENT column" HeaderText="FK_COMMENT"
                                    SortExpression="FK_COMMENT" UniqueName="FK_COMMENT" Display="false">
                                </telerik:GridBoundColumn>
                                
                                <%--<telerik:GridBoundColumn DataField="FULLNAME" FilterControlAltText="Filter FULLNAME column" HeaderText="ชื่อ-นามสกุล ผู้เชี่ยวชาญ"
                                    SortExpression="FULLNAME" UniqueName="FULLNAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EXPERT_SKILL" FilterControlAltText="Filter EXPERT_SKILL column" HeaderText="ประเมินด้าน"
                                    SortExpression="EXPERT_SKILL" UniqueName="EXPERT_SKILL">
                                </telerik:GridBoundColumn>--%>
                                <telerik:GridBoundColumn DataField="COUNT_P" DataType="System.Int32" FilterControlAltText="Filter COUNT_P column" HeaderText="ครั้งที่"
                                    SortExpression="COUNT_P" UniqueName="COUNT_P">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TIME_START_DATE" DataType="System.DateTime" FilterControlAltText="Filter TIME_START_DATE column" HeaderText="วันเริ่มต้นประเมิน"
                                    SortExpression="TIME_START_DATE" UniqueName="TIME_START_DATE" DataFormatString="{0:d}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TIME_STOP_DATE" DataType="System.DateTime" FilterControlAltText="Filter TIME_STOP_DATE column" HeaderText="วันสิ้นสุดประเมิน"
                                    SortExpression="TIME_STOP_DATE" UniqueName="TIME_STOP_DATE" DataFormatString="{0:d}">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn UniqueName="name" HeaderText="ชื่อ-นามสกุล ผู้เชี่ยวชาญ">
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="rcb_name" runat="server" filter="Contains"></telerik:RadComboBox>
                                    <asp:Label ID="lbl_name" runat="server" Text="" style="display:none;"></asp:Label>
                                </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="skill" HeaderText="ประเมินด้าน">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="rcb_skill" runat="server" filter="Contains"></telerik:RadComboBox>
                                        <asp:Label ID="lbl_skill" runat="server" Text="" style="display:none;"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="comment" HeaderText="ผลประเมิน">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="rcb_comment" runat="server" filter="Contains"></telerik:RadComboBox>
                                        <asp:Label ID="lbl_comment" runat="server" Text="" style="display:none;"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <%--<telerik:GridTemplateColumn UniqueName="name" HeaderText="ช่วงเวลา">
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="rcb_period" runat="server" filter="Contains"></telerik:RadComboBox>
   
                                </ItemTemplate>
                                </telerik:GridTemplateColumn>--%>
                                <%--<telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_sel" Text="เพิ่มสถานะ">
                                </telerik:GridButtonColumn>--%>
                                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_date" Text="เพิ่มวันที่" CommandName="_date">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
            </td>
        </tr>
        </table>
    <div style="text-align:center;"> 
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="ย้อนกลับ"  CssClass="btn-lg btn-info"  /> 
              </div>
</asp:Content>
