<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_CHEMICAL_STAFF_EDIT.aspx.vb" Inherits="FDA_DRUG.FRM_CHEMICAL_STAFF_EDIT" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <div class="panel-heading panel-title">
                <h1>สาร
                </h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr ><td>ชื่อสาร</td><td>
                        <asp:TextBox ID="Txt_Name" runat="server" CssClass="input-lg" Width="300px"></asp:TextBox>
                        </td></tr>
                    <tr ><td>CAS NUMBER</td><td>
                        <asp:TextBox ID="txt_cas" runat="server" CssClass="input-lg" Width="300px"></asp:TextBox>
                        </td></tr>
                    <tr>
                            <td>INN</td>
                            <td>
                                <asp:TextBox ID="txt_INN" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                    <tr>
                            <td>INN TH</td>
                            <td>
                                <asp:TextBox ID="txt_INN_TH" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                    <tr>
                            <td>Version Update</td>
                            <td>
                                <asp:TextBox ID="txt_version_update" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                    <tr>
                            <td>aori</td>
                            <td>
                                <asp:DropDownList ID="ddl_aori" runat="server" CssClass="input-lg" Width="150px">
                                    <asp:ListItem Value="">กรุณาเลือก</asp:ListItem>
                                    <asp:ListItem Value="A">A</asp:ListItem>
                                    <asp:ListItem Value="I">I</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>iowacd</td>
                            <td><%--<asp:TextBox ID="txt_iowacd" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>--%>
                                <asp:TextBox ID="txt_iowacd" runat="server" CssClass="input-sm" Width="300px" MaxLength="6"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Run NO.</td>
                            <td>
                                <asp:TextBox ID="txt_runno" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>salt</td>
                            <td>
                                <asp:TextBox ID="txt_salt" runat="server" CssClass="input-sm" Width="300px" MaxLength="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>syn</td>
                            <td>
                                <asp:TextBox ID="txt_syn" runat="server" CssClass="input-sm" Width="300px" MaxLength="2"></asp:TextBox>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td>iowa</td>
                            <td>
                                <asp:TextBox ID="txt_iowa" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                                <asp:DropDownList ID="ddl_iowa" runat="server" DataTextField="IOWA" DataValueField="IDA" CssClass="input-lg" Width="300px" style="display:none;">
                                </asp:DropDownList>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>เป็นสารในทะเบียน</td>
                            <td>
                                <asp:DropDownList ID="ddl_Regis" runat="server">
                                    <asp:ListItem Value="R">เป็นสารในทะเบียนผลิต</asp:ListItem>
                                    <asp:ListItem Value="N">ไม่เป็นสารในทะเบียนผลิต</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Look Type (Active or No)</td>
                            <td>
                                <asp:DropDownList ID="ddl_Look" runat="server" CssClass="input-lg" Width="300px">
                                    <asp:ListItem Selected="True">Look</asp:ListItem>
                                    <asp:ListItem>No Look</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>MODERN TRADITION</td>
                            <td>
                                <asp:DropDownList ID="ddl_Modern_drug" runat="server" CssClass="input-lg" Width="150px">
                                    <asp:ListItem Value="M">Modern Only</asp:ListItem>
                                    <asp:ListItem Value="H">Traditional Only</asp:ListItem>
                                    <asp:ListItem Value="B">Both</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>


                    <tr>
                        <td colspan="2">
                            <div style="text-align: center;">
                                <asp:Button ID="btn_edit" runat="server" Text="แก้ไข" CssClass="btn-lg" />
                            </div>
                        </td>
                    </tr>
                    
                    </table>
            </div>
              
        </div>
</asp:Content>
