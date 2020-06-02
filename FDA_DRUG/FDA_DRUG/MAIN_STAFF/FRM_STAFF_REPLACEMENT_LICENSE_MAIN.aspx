<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_STAFF_REPLACEMENT_LICENSE_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_REPLACEMENT_LICENSE_MAIN" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   


</asp:Content>

  
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h4>ใบรับเรื่องแทนผู้ประกอบการ</h4> </div>
                          <div  class="col-lg-8 col-md-8">
                               <p style="text-align:right;padding-right:5%;"></p>
                          </div>

         </div>
    </div>
    

    <table class="table" style="width:100%;">
        <tr>
            <td style="width:25%;"></td>
            <td style="width:25%;">ชื่อผู้ประกอบการ</td>
            <td style="width:25%;">
                <asp:TextBox ID="txt_SEARCH" runat="server"  CssClass="input-lg" ></asp:TextBox></td>
            <td style="width:25%;"> </td>
               
        </tr>
          <tr>
            <td style="width:25%;"></td>
            <td style="width:25%;">เลขนิติบุคคล/เลขบัตรประชาชน</td>
            <td style="width:25%;">
                <asp:TextBox ID="txt_NUM" runat="server"  CssClass="input-lg" ></asp:TextBox></td>
            <td style="width:25%;">
                </td>
        </tr>
          <tr>
            <td  colspan="4" style="text-align:center;">
                 <asp:Button ID="btn_SEARCH" runat="server" Text="ค้นหา" CssClass="input-lg" />

            </td>
          
        </tr>
          <tr>
            <td colspan="4">
    <p class="h3">ชื่อผู้ประกอบการ</p>
                <hr />
    <telerik:RadGrid ID="rg_name" runat="server" AllowPaging="true" PageSize="15">
<MasterTableView autogeneratecolumns="False" datakeynames="ID">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="lcnsid" DataType="System.Int32" FilterControlAltText="Filter lcnsid column" HeaderText="lcnsid" 
            SortExpression="lcnsid" UniqueName="lcnsid" Display="false">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
                  
         <telerik:GridBoundColumn DataField="fullname" FilterControlAltText="Filter fullname column" HeaderText="ชื่อผู้ประกอบการ" ReadOnly="True" SortExpression="fullname" UniqueName="fullname">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
               


        <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column"
             HeaderText="ID" ReadOnly="True" SortExpression="ID" UniqueName="ID" Display="false">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
     
        <telerik:GridBoundColumn DataField="IDENTIFY" FilterControlAltText="Filter IDENTIFY column" 
            HeaderText="IDENTIFY" SortExpression="IDENTIFY" UniqueName="IDENTIFY" Display="true">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>

 
              
        <telerik:GridTemplateColumn>
            <ItemTemplate>
                <asp:Button ID="HL_SELECT" runat="server" Text="เลือกข้อมูล" CommandName="sel" />
                <%--<asp:HyperLink ID="HL_SELECT"  runat="server">เลือกข้อมูล</asp:HyperLink>--%>
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
                 <p class="h3">สถานที่ตั้ง</p>
                <hr />
                <telerik:RadGrid ID="RadGrid1" runat="server">
<MasterTableView autogeneratecolumns="False" datakeynames="IDA">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="lcnsid" DataType="System.Int32" FilterControlAltText="Filter lcnsid column" HeaderText="lcnsid" 
            SortExpression="lcnsid" UniqueName="lcnsid" Display="false">

        </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="rcvno" DataType="System.Int32" FilterControlAltText="Filter rcvno column" 
                          HeaderText="เลขรับ" SortExpression="rcvno" UniqueName="rcvno">
   
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="rcvdate"  DataFormatString="{0:d}" DataType="System.DateTime" FilterControlAltText="Filter rcvdate column" HeaderText="วันที่รับ" SortExpression="rcvdate" UniqueName="rcvdate">
      
        </telerik:GridBoundColumn>
        
                 <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                      HeaderText="ชื่อสถานที่" SortExpression="thanameplace" UniqueName="thanameplace">
        
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
        
        </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="XMLNAME" FilterControlAltText="Filter XMLNAME column" HeaderText="TranscestionID" SortExpression="XMLNAME" UniqueName="XMLNAME">
          
        </telerik:GridBoundColumn>


        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
             HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
        
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
             HeaderText="FK_IDA" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
         
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
             HeaderText="TR_ID" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
         
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DOWN_ID" DataType="System.Int32" FilterControlAltText="Filter DOWN_ID column" 
            HeaderText="DOWN_ID" SortExpression="DOWN_ID" UniqueName="DOWN_ID" Display="false">
           
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CITIZEN_ID" FilterControlAltText="Filter CITIZEN_ID column" HeaderText="CITIZEN_ID"
             SortExpression="CITIZEN_ID" UniqueName="CITIZEN_ID" Display="false">
           
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CITIZEN_ID_UPLOAD" FilterControlAltText="Filter CITIZEN_ID_UPLOAD column" 
            HeaderText="CITIZEN_ID_UPLOAD" SortExpression="CITIZEN_ID_UPLOAD" UniqueName="CITIZEN_ID_UPLOAD" Display="false">
           
        </telerik:GridBoundColumn>

 
                <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column" 
            HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME" >
    
        </telerik:GridBoundColumn>

        <telerik:GridBoundColumn DataField="lctcd" DataType="System.Int32" FilterControlAltText="Filter lctcd column" HeaderText="lctcd" 
            SortExpression="lctcd" UniqueName="lctcd" Display="false">
      
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn>
            <ItemTemplate>
                <asp:HyperLink ID="HL_SELECT"  runat="server">เลือกข้อมูล</asp:HyperLink>
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

            </td>
        </tr>
          <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
</asp:Content>