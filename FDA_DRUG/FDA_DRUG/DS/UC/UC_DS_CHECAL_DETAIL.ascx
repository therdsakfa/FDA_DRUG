<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DS_CHECAL_DETAIL.ascx.vb" Inherits="FDA_DRUG.UC_DS_CHECAL_DETAIL" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<table width="100%">

                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:Label ID="lb_paylist" runat="server" Text="ตัวยาสำคัญ :"></asp:Label>
                                        </td>
                                        <td valign="top">
                                            <asp:DropDownList ID="ddl_chemecal" runat="server" DataTextField="iowanm" DataValueField="IDA" Width="200px" CssClass="input-sm">
                                            </asp:DropDownList>
                                            <%--<telerik:RadComboBox ID="rcb_chemecal" runat="server" Height="300px" Width="305" DataValueField="IDA" DataTextField="iowanm"
                                                EmptyMessage="กรุณาเลือกตัวยาสำคัญ" MarkFirstMatch="true">
                                            </telerik:RadComboBox>--%>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align="right">ปริมาณ :</td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
<asp:TextBox ID="Txt_DOSAGE" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td>
<asp:DropDownList ID="ddl_unit" runat="server">
                                            </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                            
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align="right">e.q to ตัวยาสำคัญ (ถ้ามี) :</td>
                                        <td>
                                            <asp:DropDownList ID="ddl_chemecal2" runat="server" DataTextField="iowanm" DataValueField="IDA" Width="200px" CssClass="input-sm">
                                            </asp:DropDownList>
                                            
                                            
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td align="right">ปริมาณ :</td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
<asp:TextBox ID="Txt_DOSAGE2" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                                                    </td>
                                                    <td>
<asp:DropDownList ID="ddl_unit2" runat="server">
                                            </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        
                                    </tr>
                                    </table>
<table width="100%">
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="btn_add" runat="server" CssClass="btn-lg" Text="เพิ่มวัตถุส่วนประกอบยา" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" Width="100%" AutoGenerateColumns="false">
                                                <MasterTableView>
                                                    <Columns>

                                                        <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="IDA" HeaderText="IDA" DataField="IDA" Display="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="FK_IDA" HeaderText="FK_IDA" DataField="FK_IDA" Display="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="iowanm" HeaderText="ตัวยาสำคัญ" DataField="iowanm">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="DOSAGE" HeaderText="ปริมาณ" DataField="DOSAGE">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="sunitengnm" HeaderText="หน่วย" DataField="sunitengnm">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del">
                                                        </telerik:GridButtonColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>

                                        </td>
                                    </tr>
                                    </table>