Imports System.IO
Imports System.Xml.Serialization
Public Class POPUP_UPLOAD_SPC_PI_PIL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    'Private _IDA As String
    Private _rgt_ida As String
    Dim STATUS_ID As String
    Sub runQuery()
        _ProcessID = Request.QueryString("process")
        '_IDA = Request.QueryString("IDA")
        _rgt_ida = Request.QueryString("rgt_ida")
        Try
            STATUS_ID = Request.QueryString("status")
        Catch ex As Exception

        End Try
    End Sub
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
            ' _ProcessID = Request.QueryString("type")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        runQuery()
    End Sub

    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        If FileUpload1.HasFile Then
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()

            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
            TR_ID = bao_tran.insert_transection_new(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_ProcessID, 1, 0)
            Dim PDF_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
            FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"
            Dim XML_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)
            convert_PDF_To_XML(PDF_TRADER, XML_TRADER)

            Dim check As Boolean = True
            Try
                If _ProcessID = "1400091" Then
                    check = insrt_to_database_SPC(XML_TRADER, TR_ID)
                ElseIf _ProcessID = "1400093" Then
                    check = insrt_to_database_PIL(XML_TRADER, TR_ID)
                ElseIf _ProcessID = "1400092" Then
                    check = insrt_to_database_PI(XML_TRADER, TR_ID)
                End If

                If check = True Then
                    'SET_ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year))
                    alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
                Else

                End If
            Catch ex As Exception

                alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            End Try
        End If
    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Private Function insrt_to_database_SPC(ByVal FileName As String, ByVal TR_ID As Integer) As Boolean
        Dim check As Boolean = True
        Try
            Dim objStreamReader As New StreamReader(FileName)
            Dim p2 As New CLASS_DRRGT_SPC
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()

            Dim IDENTIFY As String
            Dim dao As New DAO_DRUG.TB_DRRGT_SPC
            If STATUS_ID = 8 Then
                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                dao_rg.GetDataby_IDA(_rgt_ida)
                IDENTIFY = dao_rg.fields.IDENTIFY
                Try
                    dao.fields.drgtpcd = dao_rg.fields.drgtpcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.rgtno = dao_rg.fields.rgtno
                Catch ex As Exception

                End Try
                Try
                    dao.fields.rgttpcd = dao_rg.fields.rgttpcd
                Catch ex As Exception

                End Try
            Else
                Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
                dao_rg.GetDataby_IDA(_rgt_ida)
                IDENTIFY = dao_rg.fields.IDENTIFY
                Try
                    dao.fields.drgtpcd = dao_rg.fields.drgtpcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.rgtno = dao_rg.fields.rgtno
                Catch ex As Exception

                End Try
                Try
                    dao.fields.rgttpcd = dao_rg.fields.rgttpcd
                Catch ex As Exception

                End Try
            End If
            ' Dim bao As New BAO.GenNumber

            Dim chw As String = ""
            Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            Try
                dao_cpn.GetData_by_chngwtcd(_CLS.PVCODE)
                chw = dao_cpn.fields.thacwabbr
            Catch ex As Exception

            End Try

            dao.fields = p2.DRRGT_SPCs
            'dao.fields.EDIT_DESCRIPTION = p2.DRRGT_EDIT_REQUESTs.EDIT_DESCRIPTION
            'dao.fields.CREATE_DATE = Date.Now
            dao.fields.STATUS_ID = 1
            dao.fields.TR_ID = TR_ID

            dao.fields.FK_IDA = _rgt_ida
            dao.fields.PROCESS_ID = _ProcessID
            dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
            dao.fields.CTZNO = _CLS.CITIZEN_ID
            Try
                dao.fields.STATUS_ID_RGT = STATUS_ID
            Catch ex As Exception

            End Try

            dao.insert()

        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function
    Private Function insrt_to_database_PIL(ByVal FileName As String, ByVal TR_ID As Integer) As Boolean
        Dim check As Boolean = True
        Try
            Dim objStreamReader As New StreamReader(FileName)
            Dim p2 As New CLASS_DRRGT_PIL
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()

            Dim IDENTIFY As String
            Dim dao As New DAO_DRUG.TB_DRRGT_PIL
            If STATUS_ID = 8 Then
                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                dao_rg.GetDataby_IDA(_rgt_ida)
                IDENTIFY = dao_rg.fields.IDENTIFY
                Try
                    dao.fields.drgtpcd = dao_rg.fields.drgtpcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.rgtno = dao_rg.fields.rgtno
                Catch ex As Exception

                End Try
                Try
                    dao.fields.rgttpcd = dao_rg.fields.rgttpcd
                Catch ex As Exception

                End Try
            Else
                Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
                dao_rg.GetDataby_IDA(_rgt_ida)
                IDENTIFY = dao_rg.fields.IDENTIFY
                Try
                    dao.fields.drgtpcd = dao_rg.fields.drgtpcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.rgtno = dao_rg.fields.rgtno
                Catch ex As Exception

                End Try
                Try
                    dao.fields.rgttpcd = dao_rg.fields.rgttpcd
                Catch ex As Exception

                End Try
            End If
            ' Dim bao As New BAO.GenNumber

            Dim chw As String = ""
            Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            Try
                dao_cpn.GetData_by_chngwtcd(_CLS.PVCODE)
                chw = dao_cpn.fields.thacwabbr
            Catch ex As Exception

            End Try

            dao.fields = p2.DRRGT_PILs
            'dao.fields.EDIT_DESCRIPTION = p2.DRRGT_EDIT_REQUESTs.EDIT_DESCRIPTION
            'dao.fields.CREATE_DATE = Date.Now
            dao.fields.STATUS_ID = 1
            dao.fields.TR_ID = TR_ID

            dao.fields.FK_IDA = _rgt_ida
            dao.fields.PROCESS_ID = _ProcessID
            dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
            dao.fields.CTZNO = _CLS.CITIZEN_ID
            Try
                dao.fields.STATUS_ID_RGT = STATUS_ID
            Catch ex As Exception

            End Try

            dao.insert()

        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function
    Private Function insrt_to_database_PI(ByVal FileName As String, ByVal TR_ID As Integer) As Boolean
        Dim check As Boolean = True
        Try
            Dim objStreamReader As New StreamReader(FileName)
            Dim p2 As New CLASS_DRRGT_PI
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()

            Dim IDENTIFY As String
            Dim dao As New DAO_DRUG.TB_DRRGT_PI
            If STATUS_ID = 8 Then
                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                dao_rg.GetDataby_IDA(_rgt_ida)
                IDENTIFY = dao_rg.fields.IDENTIFY
                Try
                    dao.fields.drgtpcd = dao_rg.fields.drgtpcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.rgtno = dao_rg.fields.rgtno
                Catch ex As Exception

                End Try
                Try
                    dao.fields.rgttpcd = dao_rg.fields.rgttpcd
                Catch ex As Exception

                End Try
            Else
                Dim dao_rg As New DAO_DRUG.ClsDBdrrqt
                dao_rg.GetDataby_IDA(_rgt_ida)
                IDENTIFY = dao_rg.fields.IDENTIFY
                Try
                    dao.fields.drgtpcd = dao_rg.fields.drgtpcd
                Catch ex As Exception

                End Try
                Try
                    dao.fields.rgtno = dao_rg.fields.rgtno
                Catch ex As Exception

                End Try
                Try
                    dao.fields.rgttpcd = dao_rg.fields.rgttpcd
                Catch ex As Exception

                End Try
            End If
            ' Dim bao As New BAO.GenNumber

            Dim chw As String = ""
            Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
            Try
                dao_cpn.GetData_by_chngwtcd(_CLS.PVCODE)
                chw = dao_cpn.fields.thacwabbr
            Catch ex As Exception

            End Try

            dao.fields = p2.DRRGT_PIs
            'dao.fields.EDIT_DESCRIPTION = p2.DRRGT_EDIT_REQUESTs.EDIT_DESCRIPTION
            'dao.fields.CREATE_DATE = Date.Now
            dao.fields.STATUS_ID = 1
            dao.fields.TR_ID = TR_ID

            dao.fields.FK_IDA = _rgt_ida
            dao.fields.PROCESS_ID = _ProcessID
            dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
            dao.fields.CTZNO = _CLS.CITIZEN_ID
            Try
                dao.fields.STATUS_ID_RGT = STATUS_ID
            Catch ex As Exception

            End Try

            dao.insert()

        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function
End Class