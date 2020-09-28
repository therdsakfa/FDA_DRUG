<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_XML.aspx.vb" Inherits="FDA_DRUG.FRM_XML" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <div>
    
        <asp:Panel ID="Panel1" runat="server" GroupingText ="ใบอนุญาต">
            lcnsid<asp:TextBox ID="txt_lcnsid" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btn_lcn" runat="server" Text="GEN" />
            &nbsp;<asp:Button ID="btn_UPLOAD" runat="server" Text="UPLOAD" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_UPLOAD1" runat="server" Text="เทสวันทำการ" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </asp:Panel>
    
    </div>
     
        <asp:Panel ID="Panel2" runat="server" GroupingText ="ใบอนุญาต">
            lcnsid<asp:TextBox ID="txt_lcnsid0" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btn_lcn0" runat="server" Text="GEN" />
            &nbsp;<asp:Button ID="btn_UPLOAD0" runat="server" Text="UPLOAD" />
        </asp:Panel>
        <asp:Button ID="btn_dalcn" runat="server" Text="dalcn" />&nbsp;<asp:Button ID="btn_dalcn_UPLOAD" runat="server" Text="dalcn_UPLOAD" /><br />
        <asp:Button ID="btn_DS" runat="server" Text="DS" />&nbsp;<asp:Button ID="btn_DS_UPLOAD" runat="server" Text="DS_UPLOAD" />
         <asp:Button ID="btn_ds_new" runat="server" Text="DS_NEW" />
         <br />
        <asp:Button ID="btn_DR" runat="server" Text="DR" />&nbsp;<asp:Button ID="btn_DR_UPLOAD" runat="server" Text="DR_UPLOAD" /><br />
        <asp:Button ID="btn_CER" runat="server" Text="CER" />
         &nbsp;<asp:Button ID="btn_CER_UPLOAD" runat="server" Text="CER_UPLOAD" />
         <asp:Button ID="NYM3" runat="server" Text="NYM3" />
         <br />
        <asp:Button ID="btn_EDIT" runat="server" Text="EDIT" />
         &nbsp;<asp:Button ID="btn_EDIT_UPLOAD" runat="server" Text="EDIT_UPLOAD" />
         <br />
        <asp:Button ID="btn_REGIS" runat="server" Text="REGIS" />
         &nbsp;<asp:Button ID="btn_REGIS_UPLOAD" runat="server" Text="REGIS_UPLOAD" />
         <asp:Button ID="btn_REGIS_CONFIRM" runat="server" Text="REGIS CONFIRM" />
         <br />
        <asp:Button ID="btn_DH" runat="server" Text="DH" />&nbsp;<asp:Button ID="btn_DH_UPLOAD" runat="server" Text="DH_UPLOAD" /><br />
        <asp:Button ID="btn_DI" runat="server" Text="DI" />
         &nbsp;<asp:Button ID="btn_DI_UPLOAD" runat="server" Text="DI_UPLOAD" />
         <br />
        <asp:Button ID="btn_DP" runat="server" Text="DP" />
         &nbsp;<asp:Button ID="btn_DP_UPLOAD" runat="server" Text="DP_UPLOAD" />
         <br />
        <asp:Button ID="btn_DRUG_PROJECT" runat="server" Text="DRUG_PROJECT" />
         &nbsp;<asp:Button ID="btn_DRUG_PROJECT_UPLOAD" runat="server" Text="DRUG_PROJECT_UPLOAD" />
         <br />
        <asp:Button ID="btn_PHARMACIST" runat="server" Text="PHARMACIST" />
         &nbsp;<asp:Button ID="btn_PHARMACIST_UPLOAD" runat="server" Text="PHARMACIST_UPLOAD" />
         <br />
        <asp:Button ID="btn_CHEMICAL" runat="server" Text="CHEMICAL" />
         &nbsp;<asp:Button ID="btn_CHEMICAL_UPLOAD" runat="server" Text="CHEMICAL_UPLOAD" />
         <br />
          <asp:Button ID="btn_TRANFER_LOCATION" runat="server" Text="TRANFER_LOCATION" />
         &nbsp;<asp:Button ID="btn_TRANFER_LOCATION_UPLOAD" runat="server" Text="TRANFER_LOCATION_UPLOAD" />
         <br />
        <asp:Button ID="btn_flabel" runat="server" Text="" />
         <asp:Button ID="btn_location" runat="server" Text="LOCATION" />
         <br />
         <asp:Button ID="btn_DRUG_CONSIDER_REQUESTS" runat="server" Text="ใบรอนัด" />
         <asp:Button ID="btn_cer_for" runat="server" Text="Cer_For" />
         <br />
         <asp:Button ID="btn_LCN_DRUG" runat="server" Text= "LCN_DRUG" />
&nbsp;<asp:Button ID="btn_LCN_UP" runat="server" Text="LCN_UP" />
         <asp:Button ID="btn_edit_lcn" runat="server" Text="EDIT LCN" />
         <asp:Button ID="btn_unit" runat="server" Text="DR UNIT" />
         <br />
         <asp:Button ID="btn_phr_cancel" runat="server" Text="PHR CANCEL" />
         <asp:Button ID="btn_drrgt_req" runat="server" Text="DRRGT_EDIT_REQ" />
         <asp:Button ID="btn_drrgt_sub" runat="server" Text="drrgt_sub" />
         
         <br />
        <asp:Button ID="btn_spc" runat="server" Text="SPC" />
         <asp:Button ID="btn_pi" runat="server" Text="PI" />
         <asp:Button ID="btn_pil" runat="server" Text="PIL" />
         <asp:Button ID="Button1" runat="server" Text="GEN_DRRGT_ORI" />
         <asp:Button ID="Button2" runat="server" Text="gen_drrgt_edit_rqt" />
         <asp:Button ID="Button3" runat="server" Text="gen_drrqt_all" />
         <asp:Button ID="Button4" runat="server" Text="วจ" Width="100px" />
         <asp:Button ID="Button5" runat="server" Text="วจ Temp" />
         <asp:Button ID="Button6" runat="server" Text="dalcn edit rqt" />
         <asp:Button ID="Button7" runat="server" Text="dalcn_sub" />
        </div>
    </form>
</body>
</html>
