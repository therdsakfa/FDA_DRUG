Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO

Imports System.Data
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf

Public Class UC_TABLE_DRUG_GROUP_CHANGE
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        'bind_table()
        'End If
    End Sub
    Sub bind_table()
        'Table1.BorderStyle = BorderStyle.Solid
        'Table1.BorderWidth = 1
        bind_head()
        Dim dao As New DAO_DRUG.TB_MAS_DRUG_GROUP
        dao.GetDataALL()
        Dim dao_ih As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL1
        dao_ih.GetDataby_FKIDA(Request.QueryString("ida"))
        Try
            'rdl_drug_type.DataBind()
            'rdl_drug_type.SelectedValue = dao_ih.fields.DRUG_TYPE
            If dao_ih.fields.DRUG_TYPE IsNot Nothing Then
                cb_drug_type1.Checked = True
            End If

        Catch ex As Exception

        End Try
        Try
            'rdl_drug_type.DataBind()
            'rdl_drug_type.SelectedValue = dao_ih.fields.DRUG_TYPE
            If dao_ih.fields.DRUG_TYPE2 IsNot Nothing Then
                cb_drug_type2.Checked = True
            End If

        Catch ex As Exception

        End Try
        Try
            'rdl_drug_type.DataBind()
            'rdl_drug_type.SelectedValue = dao_ih.fields.DRUG_TYPE
            If dao_ih.fields.DRUG_TYPE23 IsNot Nothing Then
                cb_drug_type3.Checked = True
            End If

        Catch ex As Exception

        End Try
        For Each dao.fields In dao.datas
            If dao.fields.TYPE_SHOW = 1 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                Dim dc6 As New TableCell
                Dim dc7 As New TableCell
                Dim dc8 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                dc6.BorderStyle = BorderStyle.Solid
                dc6.BorderWidth = 1
                dc7.BorderStyle = BorderStyle.Solid
                dc7.BorderWidth = 1
                dc8.BorderStyle = BorderStyle.Solid
                dc8.BorderWidth = 1
                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center
                dc6.HorizontalAlign = HorizontalAlign.Center
                dc7.HorizontalAlign = HorizontalAlign.Center
                dc8.HorizontalAlign = HorizontalAlign.Center

                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim cb1 As New CheckBox
                Dim cb2 As New CheckBox
                Dim cb3 As New CheckBox
                Dim cb4 As New CheckBox
                Dim cb5 As New CheckBox
                Dim cb6 As New CheckBox
                Dim txt_6 As New HtmlTextArea
                cb1.ID = "cb1_" & dao.fields.IDA
                cb2.ID = "cb2_" & dao.fields.IDA
                cb3.ID = "cb3_" & dao.fields.IDA
                cb4.ID = "cb4_" & dao.fields.IDA
                cb5.ID = "cb5_" & dao.fields.IDA
                cb6.ID = "cb6_" & dao.fields.IDA
                txt_6.ID = "txt6_" & dao.fields.IDA
                Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL2
                Try
                    dao_det.GetDataby_FKLCN_AND_FK_IDA(Request.QueryString("ida"), dao.fields.IDA)
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL1 <> 0 Then
                        cb1.Checked = True
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL2 <> 0 Then
                        cb2.Checked = True
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL3 <> 0 Then
                        cb3.Checked = True
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL4 <> 0 Then
                        cb4.Checked = True
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL5 <> 0 Then
                        cb5.Checked = True
                    End If
                Catch ex As Exception

                End Try
                'Try
                '    If dao_det.fields.COL6 <> 0 Then
                '        cb6.Checked = True
                '    End If
                'Catch ex As Exception

                'End Try
                Try
                    If dao_det.fields.COL6 IsNot Nothing Then
                        txt_6.Value = dao_det.fields.COL6
                    End If
                Catch ex As Exception
                   
                End Try
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                dc3.Controls.Add(cb1)
                dc4.Controls.Add(cb2)
                dc5.Controls.Add(cb3)
                dc6.Controls.Add(cb4)
                dc7.Controls.Add(cb5)
                dc8.Controls.Add(txt_6)
                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                dr.Cells.Add(dc4)
                dr.Cells.Add(dc5)
                dr.Cells.Add(dc6)
                dr.Cells.Add(dc7)
                dr.Cells.Add(dc8)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            ElseIf dao.fields.TYPE_SHOW = 2 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dr As New TableRow

                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")

                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc3.ColumnSpan = 6
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim txt1 As New HtmlTextArea
                Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL2
                Try
                    dao_det.GetDataby_FKLCN_AND_FK_IDA(Request.QueryString("ida"), dao.fields.IDA)
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL1 IsNot Nothing Then
                        txt1.Value = dao_det.fields.COL1
                    End If
                Catch ex As Exception

                End Try
                txt1.ID = "txt_" & dao.fields.IDA
                txt1.Style.Add("width", "99%")
                txt1.Style.Add("Height", "100px")
                'txt1.Attributes.Add("TextMode", "MultiLine")
                dc3.Controls.Add(txt1)
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            ElseIf dao.fields.TYPE_SHOW = 0 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1

                dc3.HorizontalAlign = HorizontalAlign.Center

                dc3.ColumnSpan = 6
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            End If
        Next
    End Sub
    
    Sub bind_table_export()
        bind_head()
        Dim dao As New DAO_DRUG.TB_MAS_DRUG_GROUP
        dao.GetDataALL()
        Dim dao_ih As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL1
        dao_ih.GetDataby_FKIDA(Request.QueryString("ida"))
        Try
            'rdl_drug_type.DataBind()
            'rdl_drug_type.SelectedValue = dao_ih.fields.DRUG_TYPE
            If dao_ih.fields.DRUG_TYPE IsNot Nothing Then
                cb_drug_type1.Checked = True
            End If

        Catch ex As Exception

        End Try
        Try
            'rdl_drug_type.DataBind()
            'rdl_drug_type.SelectedValue = dao_ih.fields.DRUG_TYPE
            If dao_ih.fields.DRUG_TYPE2 IsNot Nothing Then
                cb_drug_type2.Checked = True
            End If

        Catch ex As Exception

        End Try
        Try
            'rdl_drug_type.DataBind()
            'rdl_drug_type.SelectedValue = dao_ih.fields.DRUG_TYPE
            If dao_ih.fields.DRUG_TYPE23 IsNot Nothing Then
                cb_drug_type3.Checked = True
            End If

        Catch ex As Exception

        End Try
        For Each dao.fields In dao.datas
            If dao.fields.TYPE_SHOW = 1 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                Dim dc6 As New TableCell
                Dim dc7 As New TableCell
                Dim dc8 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                'style="margin-left:50px;"
                'dc1.Style.Add("margin-left", "50px")
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                'dc2.Style.Add("margin-left", "50px")
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                dc6.BorderStyle = BorderStyle.Solid
                dc6.BorderWidth = 1
                dc7.BorderStyle = BorderStyle.Solid
                dc7.BorderWidth = 1
                dc8.BorderStyle = BorderStyle.Solid
                dc8.BorderWidth = 1
                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center
                dc6.HorizontalAlign = HorizontalAlign.Center
                dc7.HorizontalAlign = HorizontalAlign.Center
                dc8.HorizontalAlign = HorizontalAlign.Center

                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL2
                Try
                    dao_det.GetDataby_FKLCN_AND_FK_IDA(Request.QueryString("ida"), dao.fields.IDA)
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL1 <> 0 Then
                        'cb1.Checked = True
                        dc3.Text = "&#10003;"
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL2 <> 0 Then
                        'cb2.Checked = True
                        dc4.Text = "&#10003;"
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL3 <> 0 Then
                        'cb3.Checked = True
                        dc5.Text = "&#10003;"
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL4 <> 0 Then
                        'cb4.Checked = True
                        dc6.Text = "&#10003;"
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL5 <> 0 Then
                        'cb5.Checked = True
                        dc7.Text = "&#10003;"
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL6 <> 0 Then
                        'cb6.Checked = True
                        dc8.Text = "&#10003;"
                    End If
                Catch ex As Exception

                End Try
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                'dc3.Controls.Add(cb1)
                'dc4.Controls.Add(cb2)
                'dc5.Controls.Add(cb3)
                'dc6.Controls.Add(cb4)
                'dc7.Controls.Add(cb5)
                'dc8.Controls.Add(cb6)
                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                dr.Cells.Add(dc4)
                dr.Cells.Add(dc5)
                dr.Cells.Add(dc6)
                dr.Cells.Add(dc7)
                dr.Cells.Add(dc8)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            ElseIf dao.fields.TYPE_SHOW = 2 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dr As New TableRow

                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")

                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc3.ColumnSpan = 6
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim txt1 As New TextBox
                Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL2
                Try
                    dao_det.GetDataby_FKLCN_AND_FK_IDA(Request.QueryString("ida"), dao.fields.IDA)
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL1 IsNot Nothing Then
                        txt1.Text = dao_det.fields.COL1
                        dc3.Text = dao_det.fields.COL1
                    End If
                Catch ex As Exception

                End Try
                txt1.ID = "txt_" & dao.fields.IDA
                'txt1.Style.Add("text-decoration-style", "dotted")
                txt1.Style.Add("width", "99%")

                'dc3.Controls.Add(txt1)
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            ElseIf dao.fields.TYPE_SHOW = 0 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1

                dc3.HorizontalAlign = HorizontalAlign.Center

                dc3.ColumnSpan = 6
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            End If
        Next
    End Sub
    Sub bind_table_edit()
        'Table1.BorderStyle = BorderStyle.Solid
        'Table1.BorderWidth = 1
        bind_head()
        Dim dao As New DAO_DRUG.TB_MAS_DRUG_GROUP
        dao.GetDataALL()
        For Each dao.fields In dao.datas
            If dao.fields.TYPE_SHOW = 1 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                Dim dc6 As New TableCell
                Dim dc7 As New TableCell
                Dim dc8 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                dc6.BorderStyle = BorderStyle.Solid
                dc6.BorderWidth = 1
                dc7.BorderStyle = BorderStyle.Solid
                dc7.BorderWidth = 1
                dc8.BorderStyle = BorderStyle.Solid
                dc8.BorderWidth = 1
                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center
                dc6.HorizontalAlign = HorizontalAlign.Center
                dc7.HorizontalAlign = HorizontalAlign.Center
                dc8.HorizontalAlign = HorizontalAlign.Center

                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim cb1 As New CheckBox
                Dim cb2 As New CheckBox
                Dim cb3 As New CheckBox
                Dim cb4 As New CheckBox
                Dim cb5 As New CheckBox
                Dim cb6 As New CheckBox
                cb1.ID = "cb1_" & dao.fields.IDA
                cb2.ID = "cb2_" & dao.fields.IDA
                cb3.ID = "cb3_" & dao.fields.IDA
                cb4.ID = "cb4_" & dao.fields.IDA
                cb5.ID = "cb5_" & dao.fields.IDA
                cb6.ID = "cb6_" & dao.fields.IDA
                Dim dao_det As New DAO_DRUG.TB_DALCN_PRODUCTION_DRUG_TYPE_DETAIL2
                Try
                    dao_det.GetDataby_FKLCN_AND_FK_IDA(Request.QueryString("ida"), dao.fields.IDA)
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL1 <> 0 Then
                        cb1.Checked = True
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL2 <> 0 Then
                        cb2.Checked = True
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL3 <> 0 Then
                        cb3.Checked = True
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL4 <> 0 Then
                        cb4.Checked = True
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL5 <> 0 Then
                        cb5.Checked = True
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL6 <> 0 Then
                        cb6.Checked = True
                    End If
                Catch ex As Exception

                End Try
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                dc3.Controls.Add(cb1)
                dc4.Controls.Add(cb2)
                dc5.Controls.Add(cb3)
                dc6.Controls.Add(cb4)
                dc7.Controls.Add(cb5)
                dc8.Controls.Add(cb6)
                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                dr.Cells.Add(dc4)
                dr.Cells.Add(dc5)
                dr.Cells.Add(dc6)
                dr.Cells.Add(dc7)
                dr.Cells.Add(dc8)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            ElseIf dao.fields.TYPE_SHOW = 2 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dr As New TableRow

                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")

                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc3.ColumnSpan = 6
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim txt1 As New TextBox
                Dim dao_det As New DAO_DRUG.TB_DALCN_PRODUCTION_DRUG_TYPE_DETAIL2
                Try
                    dao_det.GetDataby_FKLCN_AND_FK_IDA(Request.QueryString("ida"), dao.fields.IDA)
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL1 IsNot Nothing Then
                        txt1.Text = dao_det.fields.COL1
                    End If
                Catch ex As Exception

                End Try
                txt1.ID = "txt_" & dao.fields.IDA
                txt1.Style.Add("width", "99%")
                dc3.Controls.Add(txt1)
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            ElseIf dao.fields.TYPE_SHOW = 0 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1

                dc3.HorizontalAlign = HorizontalAlign.Center

                dc3.ColumnSpan = 6
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            End If
        Next
    End Sub
    Sub bind_head()
        Dim dc1 As New TableCell
        Dim dc2 As New TableCell
        Dim dc3 As New TableCell
        Dim dc4 As New TableCell
        Dim dc5 As New TableCell
        Dim dc6 As New TableCell
        Dim dc7 As New TableCell
        Dim dc8 As New TableCell
        Dim dc9 As New TableCell
        Dim dc10 As New TableCell
        Dim dr As New TableRow
        dc1.BorderStyle = BorderStyle.Solid
        dc1.BorderWidth = 1
        dc1.Width = 20
        dc2.BorderStyle = BorderStyle.Solid
        dc2.BorderWidth = 1
        dc2.Width = 300
        dc3.BorderStyle = BorderStyle.Solid
        dc3.BorderWidth = 1
        dc3.HorizontalAlign = HorizontalAlign.Center
        dc4.BorderStyle = BorderStyle.Solid
        dc4.BorderWidth = 1
        dc4.HorizontalAlign = HorizontalAlign.Center
        dc5.BorderStyle = BorderStyle.Solid
        dc5.BorderWidth = 1
        dc5.HorizontalAlign = HorizontalAlign.Center
        dc6.BorderStyle = BorderStyle.Solid
        dc6.BorderWidth = 1
        dc6.HorizontalAlign = HorizontalAlign.Center
        dc7.BorderStyle = BorderStyle.Solid
        dc7.BorderWidth = 1
        dc7.HorizontalAlign = HorizontalAlign.Center
        dc8.BorderStyle = BorderStyle.Solid
        dc8.BorderWidth = 1
        dc8.HorizontalAlign = HorizontalAlign.Center
        dc9.Style.Add("display", "none")
        dc10.Style.Add("display", "none")
        dc2.Text = "รายการ"
        dc3.Text = "ยาทั่วไป"
        dc4.Text = "เพนนิซิลลิน"
        dc5.Text = "เซฟาโลสปอริน"
        dc6.Text = "คาร์บาพิแนม"
        dc7.Text = "ฮอร์โมนเพศ"
        dc8.Text = "อื่น ๆ"
        dc2.Style.Add("font-weight", "bold")
        dc3.Style.Add("font-weight", "bold")
        dc4.Style.Add("font-weight", "bold")
        dc5.Style.Add("font-weight", "bold")
        dc6.Style.Add("font-weight", "bold")
        dc7.Style.Add("font-weight", "bold")
        dc8.Style.Add("font-weight", "bold")
        dr.Cells.Add(dc1)
        dr.Cells.Add(dc2)
        dr.Cells.Add(dc3)
        dr.Cells.Add(dc4)
        dr.Cells.Add(dc5)
        dr.Cells.Add(dc6)
        dr.Cells.Add(dc7)
        dr.Cells.Add(dc8)
        dr.Cells.Add(dc9)
        dr.Cells.Add(dc10)
        Table1.Rows.Add(dr)


    End Sub
    Sub save_data()
        Dim dao_t As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL1
        dao_t.GetDataby_FKIDA(Request.QueryString("ida"))
        Try
            For Each dao_t.fields In dao_t.datas
                dao_t.delete()
            Next
        Catch ex As Exception

        End Try

        dao_t = New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL1
        dao_t.fields.FK_IDA = Request.QueryString("ida")
        Try
            If cb_drug_type1.Checked Then
                dao_t.fields.DRUG_TYPE = 1
            End If
            'dao_t.fields.DRUG_TYPE = rdl_drug_type.SelectedValue
        Catch ex As Exception

        End Try
        Try
            If cb_drug_type2.Checked Then
                dao_t.fields.DRUG_TYPE2 = 1
            End If
            'dao_t.fields.DRUG_TYPE = rdl_drug_type.SelectedValue
        Catch ex As Exception

        End Try
        Try
            If cb_drug_type3.Checked Then
                dao_t.fields.DRUG_TYPE23 = 1
            End If
            'dao_t.fields.DRUG_TYPE = rdl_drug_type.SelectedValue
        Catch ex As Exception

        End Try
        dao_t.insert()


        Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL2
        dao_det.GetDataby_LCN_IDA(Request.QueryString("ida"))
        For Each dao_det.fields In dao_det.datas
            dao_det.delete()
        Next
        Dim i As Integer = 0
        For Each tr As TableRow In Table1.Rows
            If i > 0 Then


                Dim FK_IDA As Integer = tr.Cells(tr.Cells.Count - 2).Text
                Dim TYPE_SHOW As Integer = tr.Cells(tr.Cells.Count - 1).Text
                Dim dao As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL2
                dao.fields.LCN_IDA = Request.QueryString("ida")
                dao.fields.FK_IDA = FK_IDA

                If TYPE_SHOW = 1 Then
                    Dim col_all As String = ""
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim txt6 As New HtmlTextArea
                    Try
                        txt6 = tr.Cells(8).FindControl("txt6_" & FK_IDA)
                    Catch ex As Exception

                    End Try
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA)
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA)
                        cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If
                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                            If col_all = "" Then
                                col_all = "ยาทั่วไป"

                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1

                            If col_all = "" Then
                                col_all = "เพนนิซิลลิน"
                            Else
                                col_all &= ", เพนนิซิลลิน"
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1

                            If col_all = "" Then
                                col_all = "เซฟาโลสปอริน"
                            Else
                                col_all &= ", เซฟาโลสปอริน"
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1

                            If col_all = "" Then
                                col_all = "คาร์บาพิแนม"
                            Else
                                col_all &= ", คาร์บาพิแนม"
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1

                            If col_all = "" Then
                                col_all = "ฮอร์โมนเพศ"
                            Else
                                col_all &= ", ฮอร์โมนเพศ"
                            End If
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = txt6.Value
                            jj += 1

                            If col_all = "" Then
                                col_all = txt6.Value
                            Else
                                col_all &= ", " & txt6.Value
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    If jj > 0 Then
                        dao.fields.COL_ALLS = col_all
                        dao.insert()
                    End If

                ElseIf TYPE_SHOW = 2 Then
                    Dim txt As New HtmlTextArea 'TextBox
                    txt = tr.Cells(2).FindControl("txt_" & FK_IDA)
                    'dao.fields.COL1 = txt.Text
                    dao.fields.COL1 = txt.Value
                    If txt.Value <> "" Then
                        dao.insert()
                    End If

                End If
            End If
            i += 1
        Next
    End Sub
    Sub save_data_edit()
        Dim dao_t As New DAO_DRUG.TB_DALCN_PRODUCTION_DRUG_TYPE_DETAIL
        dao_t.GetDataby_FKIDA_AND_EDT_ID(Request.QueryString("ida"), Request.QueryString("ida_c"))
        Try
            For Each dao_t.fields In dao_t.datas
                dao_t.delete()
            Next
        Catch ex As Exception

        End Try

        dao_t = New DAO_DRUG.TB_DALCN_PRODUCTION_DRUG_TYPE_DETAIL
        dao_t.fields.FK_IDA = Request.QueryString("ida")
        dao_t.fields.DRUG_TYPE = rdl_drug_type.SelectedValue
        dao_t.fields.FK_EDIT_COUNT = Request.QueryString("ida_c")
        dao_t.fields.EDIT_TYPE = 13
        dao_t.insert()


        Dim dao_det As New DAO_DRUG.TB_DALCN_PRODUCTION_DRUG_TYPE_DETAIL2
        dao_det.GetDataby_FKIDA_AND_EDT_ID(Request.QueryString("ida"), Request.QueryString("ida_c"))
        For Each dao_det.fields In dao_det.datas
            dao_det.delete()
        Next
        Dim i As Integer = 0
        For Each tr As TableRow In Table1.Rows
            If i > 0 Then


                Dim FK_IDA As Integer = tr.Cells(tr.Cells.Count - 2).Text
                Dim TYPE_SHOW As Integer = tr.Cells(tr.Cells.Count - 1).Text
                Dim dao As New DAO_DRUG.TB_DALCN_PRODUCTION_DRUG_TYPE_DETAIL2
                dao.fields.LCN_IDA = Request.QueryString("ida")
                dao.fields.FK_IDA = FK_IDA
                dao.fields.FK_EDIT_COUNT = Request.QueryString("ida_c")
                dao.fields.EDIT_TYPE = 13
                If TYPE_SHOW = 1 Then
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim txt6 As New HtmlTextArea
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA)
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA)
                        cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If


                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    If jj > 0 Then
                        dao.insert()
                    End If
                ElseIf TYPE_SHOW = 2 Then
                    Dim txt As New HtmlTextArea 'TextBox
                    txt = tr.Cells(2).FindControl("txt_" & FK_IDA)
                    dao.fields.COL1 = txt.Value 'txt.Text

                    If txt.Value <> "" Then
                        dao.insert()
                    End If

                End If
            End If
            i += 1
        Next
    End Sub
    'Private Sub btn_SAVE_Click(sender As Object, e As EventArgs) Handles btn_SAVE.Click
    '    save_date()
    '    bind_table()
    '    Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');</script> ")

    'End Sub
    Sub render_pdf()
        Dim tbl As New cls_itextsharp.TableToPdf
        Dim prn As New cls_itextsharp.TableToPdf
        prn.TableToPdf(Table1, "test")
    End Sub
    'Public Sub DownloadAsPDF()
    '    Try
    '        Dim strHtml As String = String.Empty
    '        Dim pdfFileName As String = Request.PhysicalApplicationPath + "\files\" + "GenerateHTMLTOPDF.pdf"

    '        Dim sw As New StringWriter()
    '        Dim hw As New HtmlTextWriter(sw)
    '        Panel1.RenderControl(hw)
    '        Dim sr As New StringReader(sw.ToString())
    '        strHtml = sr.ReadToEnd()
    '        sr.Close()

    '        CreatePDFFromHTMLFile(strHtml, pdfFileName)

    '        Response.ContentType = "application/x-download"
    '        Response.AddHeader("Content-Disposition", String.Format("attachment; filename=""{0}""", "GenerateHTMLTOPDF.pdf"))
    '        Response.WriteFile(pdfFileName)
    '        Response.Flush()
    '        Response.[End]()
    '    Catch ex As Exception
    '        Response.Write(ex.Message)
    '    End Try

    'End Sub
    'Public Sub CreatePDFFromHTMLFile(HtmlStream As String, FileName As String)
    '    Try
    '        Dim TargetFile As Object = FileName
    '        Dim ModifiedFileName As String = String.Empty
    '        Dim FinalFileName As String = String.Empty


    '        Dim builder As New HTMLtoPDF.GeneratePDF.HtmlToPdfBuilder(iTextSharp.text.PageSize.A4)
    '        Dim first As HTMLtoPDF.GeneratePDF.HtmlPdfPage = builder.AddPage()
    '        first.AppendHtml(HtmlStream)
    '        Dim file__1 As Byte() = builder.RenderPdf()
    '        File.WriteAllBytes(TargetFile.ToString(), file__1)

    '        Dim reader As New iTextSharp.text.pdf.PdfReader(TargetFile.ToString())
    '        ModifiedFileName = TargetFile.ToString()
    '        ModifiedFileName = ModifiedFileName.Insert(ModifiedFileName.Length - 4, "1")

    '        iTextSharp.text.pdf.PdfEncryptor.Encrypt(reader, New FileStream(ModifiedFileName, FileMode.Append), iTextSharp.text.pdf.PdfWriter.STRENGTH128BITS, "", "", iTextSharp.text.pdf.PdfWriter.AllowPrinting)
    '        reader.Close()
    '        If File.Exists(TargetFile.ToString()) Then
    '            File.Delete(TargetFile.ToString())
    '        End If
    '        FinalFileName = ModifiedFileName.Remove(ModifiedFileName.Length - 5, 1)
    '        File.Copy(ModifiedFileName, FinalFileName)
    '        If File.Exists(ModifiedFileName) Then
    '            File.Delete(ModifiedFileName)

    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

End Class