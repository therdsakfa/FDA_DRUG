Imports System.IO
Imports System.Xml.Serialization

Public Class UC_LABEL_DETAIL
    Inherits System.Web.UI.UserControl

    Private _IDA As Integer = 0
    Private _DTL_IDA As Integer
    Dim STATUS_ID As Integer = 0
    Sub RunQuery()
        Try
            _IDA = Request.QueryString("IDA")
        Catch ex As Exception
            _IDA = 0
        End Try
        Try
            _DTL_IDA = Request.QueryString("dtl")
        Catch ex As Exception

        End Try
        Try
            If Request.QueryString("STATUS_ID") <> "" Then
                STATUS_ID = Request.QueryString("STATUS_ID")
            Else
                STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("tr_id"))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()

        If Not IsPostBack Then
            If STATUS_ID = 8 Then
                Dim dao_re As New DAO_DRUG.ClsDBdrrgt
                dao_re.GetDataby_IDA(_IDA)
                Dim dao_dtl As New DAO_DRUG.TB_DRRGT_LABEL
                Try
                    'dao_dtl.GetData(dao_re.fields.pvncd, dao_re.fields.drgtpcd, dao_re.fields.rgttpcd, dao_re.fields.rgtno)
                    dao_dtl.GetDataby_FK_IDA(_IDA)
                    txt_label_detail.Text = dao_dtl.fields.LABEL_DETAIL
                Catch ex As Exception

                End Try
                'dao_re.fields.lmdfdate = Date.Now
                'dao_re.update()
            Else
                Dim dao_re As New DAO_DRUG.ClsDBdrrqt
                dao_re.GetDataby_IDA(_IDA)
                'dao_re.fields.lmdfdate = Date.Now
                Dim dao_dtl As New DAO_DRUG.TB_DRRQT_LABEL
                Try
                    'dao_dtl.GetData(dao_re.fields.pvncd, dao_re.fields.drgtpcd, dao_re.fields.rgttpcd, dao_re.fields.rcvno)
                    dao_dtl.GetDataby_FK_IDA(_IDA)
                    txt_label_detail.Text = dao_dtl.fields.LABEL_DETAIL
                Catch ex As Exception

                End Try
                ' dao_re.update()
            End If

        End If

    End Sub

    Protected Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click
        If STATUS_ID = 8 Then
            Dim dao As New DAO_DRUG.TB_DRRGT_DTL_TEXT
            Dim dao_re As New DAO_DRUG.ClsDBdrrgt
            dao_re.GetDataby_IDA(_IDA)
            dao_re.fields.lmdfdate = Date.Now
            dao_re.update()
            Dim IDA_C As Integer = 0
            Try
                Dim c As Integer = 0
                c = dao.count_fk_ida(_IDA)
                If c = 0 Then
                    Dim dao_dtl As New DAO_DRUG.TB_DRRGT_LABEL
                    setdata(dao_dtl)
                    dao_dtl.fields.FK_IDA = _IDA
                    dao_dtl.insert()
                    IDA_C = dao_dtl.fields.IDA
                Else
                    Dim dao_dtl As New DAO_DRUG.TB_DRRGT_LABEL
                    dao_dtl.GetDataby_FK_IDA(_IDA)
                    setdata(dao_dtl)
                    dao_dtl.update()
                    IDA_C = dao_dtl.fields.IDA
                End If

                Dim dao_la As New DAO_DRUG.TB_DRRGT_LABEL
                dao_la.GetDataby_FK_IDA(_IDA)
                Dim max_no As Integer = 0
                Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
                dao_edt.GET_MAX_NO("DRRGT_LABEL", dao.fields.IDA)
                Try
                    max_no = dao_edt.fields.COUNT_EDIT
                Catch ex As Exception

                End Try
                'Dim filename As String = ""
                'filename = "DRRGT_LABEL_" & max_no + 1 & ".xml"
                'Dim bao_app As New BAO.AppSettings                                          'บอกที่อยู่ของไฟล์
                'bao_app.RunAppSettings()
                'Dim path As String = bao_app._PATH_EDIT & filename
                'Dim objStreamWriter As New StreamWriter(path)                                                   'ประกาศตัวแปร
                'Dim x As New XmlSerializer(dao_la.fields.GetType)                                                     'ประกาศ
                'x.Serialize(objStreamWriter, dao_la.fields)
                'objStreamWriter.Close()

                'Dim dao_index As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
                'With dao_index.fields
                '    .COUNT_EDIT = max_no + 1
                '    .CREATE_DATE = Date.Now
                '    .FILE_NAME = filename
                '    .FK_DRRGT_IDA = Request.QueryString("IDA")
                '    .FK_IDA = dao.fields.IDA
                '    .TABLE_NAME = "DRRGT_LABEL"
                'End With
                'dao_index.insert()
                alert("บันทึกเรียบร้อยแล้ว")
            Catch ex As Exception

            End Try

        Else
            Dim dao As New DAO_DRUG.TB_DRRQT_DTL_TEXT
            Dim dao_re As New DAO_DRUG.ClsDBdrrqt
            dao_re.GetDataby_IDA(_IDA)
            dao_re.fields.lmdfdate = Date.Now
            dao_re.update()
            Try
                Dim c As Integer = 0
                c = dao.count_fk_ida(_IDA)
                If c = 0 Then
                    Dim dao_dtl As New DAO_DRUG.TB_DRRQT_LABEL
                    setdata2(dao_dtl)
                    dao_dtl.fields.FK_IDA = _IDA
                    dao_dtl.insert()
                Else
                    Dim dao_dtl As New DAO_DRUG.TB_DRRQT_LABEL
                    dao_dtl.GetDataby_FK_IDA(_IDA)
                    setdata2(dao_dtl)
                    dao_dtl.update()
                End If
                alert("บันทึกเรียบร้อยแล้ว")
            Catch ex As Exception

            End Try

        End If

    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Sub setdata(ByRef dao As DAO_DRUG.TB_DRRGT_LABEL)
        dao.fields.LABEL_DETAIL = txt_label_detail.Text
    End Sub
    Sub setdata2(ByRef dao As DAO_DRUG.TB_DRRQT_LABEL)
        dao.fields.LABEL_DETAIL = txt_label_detail.Text
    End Sub
End Class