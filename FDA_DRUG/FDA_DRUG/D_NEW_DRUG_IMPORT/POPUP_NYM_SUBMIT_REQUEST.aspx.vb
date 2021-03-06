﻿Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports FDA_DRUG.XML_CENTER

Public Class POPUP_NYM_SUBMIT_REQUEST
    Inherits System.Web.UI.Page

    Private _IDA As String
    Private _TR_ID As String
    Private _CLS As New CLS_SESSION
    Private _process As String
    Private _DL As String
    Private _YEARS As String
    Private b64 As String
    Sub RunQuery()
        Try
            _IDA = Request.QueryString("IDA")
        Catch ex As Exception

        End Try
        Try
            _process = Request.QueryString("process")

            '_TR_ID = Request.QueryString("TR_ID")
            _DL = Request.QueryString("DL")
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        'If Session("b64") IsNot Nothing Then
        '    b64 = Session("b64")
        'End If
        Dim type As Integer
        If _process = 1027 Then
            type = 2
        ElseIf _process = 1028 Then
            type = 3
        ElseIf _process = 1029 Then
            type = 4
        ElseIf _process = 1031 Then
            type = 7
        End If

        If Not IsPostBack Then
            BindData_PDF()
            show_btn(_IDA)
            set_hide(_IDA)
            ' UC_GRID_PHARMACIST.load_gv(_IDA)
            UC_GRID_ATTACH.load_gv_V2(Request.QueryString("TR_ID"), Request.QueryString("Process"))
            UC_GRID_ATTACH_IMPORT1.loadatteachfromdrugimportupload(_IDA, type)
            If Request.QueryString("identify") <> "" Then
                If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
        End If
    End Sub
    Function load_STATUS()
        Dim dao2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        Dim dao4_2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
        If _process = 1027 Then
            dao2.GetDataby_IDA(_IDA)
            Return dao2.fields.STATUS_ID.ToString()
        ElseIf _process = 1028 Then
            dao3.GetDataby_IDA(_IDA)
            Return dao3.fields.STATUS_ID.ToString()
        ElseIf _process = 1029 Then
            dao4.GetDataby_IDA(_IDA)
            Return dao4.fields.STATUS_ID.ToString()
        ElseIf _process = 1031 Then
            dao4_2.GetDataby_IDA(_IDA)
            Return dao4.fields.STATUS_ID.ToString()
        End If

    End Function
    Sub show_btn(ByVal ID As String)
        Dim dao2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        Dim dao4_2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
        dao2.GetDataby_IDA(ID)
        dao3.GetDataby_IDA(ID)
        dao4.GetDataby_IDA(ID)
        dao4_2.GetDataby_IDA(ID)
        If dao2.fields.STATUS_ID <> 1 And _process = 1027 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        ElseIf dao3.fields.STATUS_ID <> 1 And _process = 1028 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        ElseIf dao4.fields.STATUS_ID <> 1 And _process = 1029 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        ElseIf dao4_2.fields.STATUS_ID <> 1 And _process = 1031 Then
            btn_confirm.Enabled = False
            btn_cancel.Enabled = False
            btn_confirm.CssClass = "btn-danger btn-lg"
            btn_cancel.CssClass = "btn-danger btn-lg"
        End If
    End Sub
    Public Sub set_hide(ByVal IDA As String)
        Dim dao2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        Dim dao4_2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
        dao2.GetDataby_IDA(IDA)
        dao3.GetDataby_IDA(IDA)
        dao4.GetDataby_IDA(IDA)
        dao4_2.GetDataby_IDA(IDA)
        If _process = 1027 Then
            If dao2.fields.STATUS_ID = 5 Then
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                txt_title.Style.Add("display", "block")
                txt_edit_remark.Style.Add("display", "block")
                txt_edit_remark.Text = dao2.fields.REMARK_EDIT
            ElseIf dao2.fields.STATUS_ID = 7 Then
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                txt_title.Style.Add("display", "block")
                txt_edit_remark.Style.Add("display", "block")
                txt_edit_remark.Text = dao2.fields.REMARK
            End If
        ElseIf _process = 1028 Then
            If dao3.fields.STATUS_ID = 5 Then
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                txt_title.Style.Add("display", "block")
                txt_edit_remark.Style.Add("display", "block")
                txt_edit_remark.Text = dao3.fields.REMARK_EDIT
            ElseIf dao3.fields.STATUS_ID = 7 Then
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                txt_title.Style.Add("display", "block")
                txt_edit_remark.Style.Add("display", "block")
                txt_edit_remark.Text = dao3.fields.REMARK          'อย่าลืม เพิ่มตารางใน base 
            End If
        ElseIf _process = 1029 Then
            If dao4.fields.STATUS_ID = 5 Then
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                txt_title.Style.Add("display", "block")
                txt_edit_remark.Style.Add("display", "block")
                txt_edit_remark.Text = dao4.fields.REMARK_EDIT
            ElseIf dao4.fields.STATUS_ID = 7 Then
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                txt_title.Style.Add("display", "block")
                txt_edit_remark.Style.Add("display", "block")
                txt_edit_remark.Text = dao4.fields.REMARK           'อย่าลืม เพิ่มตารางใน base 
            End If
        ElseIf _process = 1031 Then
            If dao4_2.fields.STATUS_ID = 5 Then
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                txt_title.Style.Add("display", "block")
                txt_edit_remark.Style.Add("display", "block")
                txt_edit_remark.Text = dao4_2.fields.REMARK_EDIT
            ElseIf dao4_2.fields.STATUS_ID = 7 Then
                btn_confirm.Enabled = False
                btn_cancel.Enabled = False
                btn_confirm.CssClass = "btn-danger btn-lg"
                btn_cancel.CssClass = "btn-danger btn-lg"

                txt_title.Style.Add("display", "block")
                txt_edit_remark.Style.Add("display", "block")
                txt_edit_remark.Text = dao4_2.fields.REMARK           'อย่าลืม เพิ่มตารางใน base 
            End If
        Else
            txt_title.Style.Add("display", "none")
            txt_edit_remark.Style.Add("display", "none")
        End If
    End Sub
    Private Function chk_pha() As Boolean                             'เอาไว้ทำอะไร
        Dim chk As Boolean = True
        Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
        dao.GetDataby_FK_IDA(_IDA)
        For Each row In dao.datas
            If row.PHR_STATUS_UPLOAD = "1" Then
                chk = False
            End If
        Next
        Return chk
    End Function
    Function run_rcvno() As Integer                                    'เอาไว้ทำอะไร
        Dim rcvno As Integer
        Dim bao As New BAO.ClsDBSqlcommand
        bao.FAGenID("rcvno", "dalcn")

        rcvno = Integer.Parse(bao.dt.Rows(0)(0).ToString()) + 1

        Return rcvno
    End Function
    Protected Sub btn_confirm_Click(sender As Object, e As EventArgs) Handles btn_confirm.Click        ' ปรับสภาณะ
        Dim dao2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        Dim dao4_2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
        Dim bao As New BAO.ClsDBSqlcommand
        Dim TR_ID As String = ""
        If _process = 1027 Then                                   'เช็ค Status เป็น nym อะไร และการกดปุ่มในแต่ละอันจะอัพเดท ststus_id ใน base TB_FDA_DRUG_IMPORT_NYM_ ของ NYM นั้นๆ
            dao2.GetDataby_IDA(Integer.Parse(_IDA))
            If Request.QueryString("staff") <> "" Then
                dao2.fields.STATUS_ID = 2                       'ถ้าเป็น staff ทำแทน เข้าอันนี้ 
                dao2.fields.NYM2_DATE_TOP = Date.Now
                'Dim bao_tran As New BAO_TRANSECTION
                'bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                'bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                'TR_ID = bao_tran.insert_transection_new(_process)
                'dao2.fields.FK_IDA = TR_ID
            Else
                dao2.fields.STATUS_ID = 2                       'ถ้าเป็นอันนี้คือผู้ประกอบการยื่นเอง      ตรงนี้ตามจริงต้องเป็น 2 เหมือนกันไหม
                dao2.fields.NYM2_DATE_TOP = Date.Now
                'Dim bao_tran As New BAO_TRANSECTION
                'bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                'bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                'TR_ID = bao_tran.insert_transection_new(_process)
                'dao2.fields.FK_IDA = TR_ID
            End If
            dao2.update()
        ElseIf _process = 1028 Then
            dao3.GetDataby_IDA(Integer.Parse(_IDA))
            If Request.QueryString("staff") <> "" Then
                dao3.fields.STATUS_ID = 2                       'ถ้าเป็น staff ทำแทน เข้าอันนี้ 
                dao3.fields.NYM3_DATE_TOP = Date.Now
                'Dim bao_tran As New BAO_TRANSECTION
                'bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                'bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                'TR_ID = bao_tran.insert_transection_new(_process)
                'dao3.fields.FK_IDA = TR_ID
            Else
                dao3.fields.STATUS_ID = 2                        'ถ้าเป็นอันนี้คือผู้ประกอบการยื่นเอง
                dao3.fields.NYM3_DATE_TOP = Date.Now
                'Dim bao_tran As New BAO_TRANSECTION
                'bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                'bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                'TR_ID = bao_tran.insert_transection_new(_process)
                'dao3.fields.FK_IDA = TR_ID
            End If
            dao3.update()
        ElseIf _process = 1029 Then
            dao4.GetDataby_IDA(Integer.Parse(_IDA))
            If Request.QueryString("staff") <> "" Then
                dao4.fields.STATUS_ID = 2                       'ถ้าเป็น staff ทำแทน เข้าอันนี้ 
                dao4.fields.NYM4_DATE_TOP = Date.Now
                'Dim bao_tran As New BAO_TRANSECTION
                'bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                'bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                'TR_ID = bao_tran.insert_transection_new(_process)
                'dao4.fields.FK_IDA = TR_ID
            Else
                dao4.fields.STATUS_ID = 2                        'ถ้าเป็นอันนี้คือผู้ประกอบการยื่นเอง
                dao4.fields.NYM4_DATE_TOP = Date.Now
                'Dim bao_tran As New BAO_TRANSECTION
                'bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                'bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                'TR_ID = bao_tran.insert_transection_new(_process)
                'dao4.fields.FK_IDA = TR_ID
            End If
            dao4.update()
        ElseIf _process = 1031 Then
            dao4_2.GetDataby_IDA(Integer.Parse(_IDA))
            If Request.QueryString("staff") <> "" Then
                dao4_2.fields.STATUS_ID = 2                       'ถ้าเป็น staff ทำแทน เข้าอันนี้ 
                dao4_2.fields.NYM4_COMPANY_DATE_TOP = Date.Now
                'Dim bao_tran As New BAO_TRANSECTION
                'bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                'bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                'TR_ID = bao_tran.insert_transection_new(_process)
                'dao4.fields.FK_IDA = TR_ID
            Else
                dao4_2.fields.STATUS_ID = 2                        'ถ้าเป็นอันนี้คือผู้ประกอบการยื่นเอง
                dao4_2.fields.NYM4_COMPANY_DATE_TOP = Date.Now
                'Dim bao_tran As New BAO_TRANSECTION
                'bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                'bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                'TR_ID = bao_tran.insert_transection_new(_process)
                'dao4.fields.FK_IDA = TR_ID
            End If
            dao4_2.update()
        End If
        Dim years As String = ""

        AddLogStatusnymimport(2, _process, _CLS.CITIZEN_ID, _IDA)            'LOG STATUS เก็บการ log ไว้ แล้วอัพเข้า base นี้ 



        alert("ยื่นเรื่องเรียบร้อยแล้วรหัสการดำเนินการ คือ DA-" & _process & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)

    End Sub
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
    Protected Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim dao2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        Dim dao4_2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
        If _process = 1027 Then
            dao2.GetDataby_IDA(Integer.Parse(_IDA))
            dao2.fields.STATUS_ID = 7                                                                            'status ยกเลิกคำขอ ยังไม่มี
            dao2.update()
            AddLogStatusnymimport(7, _process, _CLS.CITIZEN_ID, _IDA)                              'น่าจะเอาไว้เก็บการอัพเดท สเตตัส
        ElseIf _process = 1028 Then
            dao3.GetDataby_IDA(Integer.Parse(_IDA))
            dao3.fields.STATUS_ID = 7                                                                            'status ยกเลิกคำขอ ยังไม่มี
            dao3.update()
            AddLogStatusnymimport(7, _process, _CLS.CITIZEN_ID, _IDA)
        ElseIf _process = 1029 Then
            dao4.GetDataby_IDA(Integer.Parse(_IDA))
            dao4.fields.STATUS_ID = 7                                                                            'status ยกเลิกคำขอ ยังไม่มี
            dao4.update()
            AddLogStatusnymimport(7, _process, _CLS.CITIZEN_ID, _IDA)
        ElseIf _process = 1031 Then
            dao4_2.GetDataby_IDA(Integer.Parse(_IDA))
            dao4_2.fields.STATUS_ID = 7                                                                            'status ยกเลิกคำขอ ยังไม่มี
            dao4_2.update()
            AddLogStatusnymimport(7, _process, _CLS.CITIZEN_ID, _IDA)
        End If
        Response.Write("<script type='text/javascript'>parent.close_modal(); </script> ")
    End Sub

    Protected Sub btn_load_Click(sender As Object, e As EventArgs) Handles btn_load.Click
        load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)                                                            'คำสั่งโหลด OFD ดขาเครื่งอ
    End Sub

    '    ''' <summary>
    '    '''  ดึงค่า XML มาแสดง
    '    ''' </summary>
    '    ''' <remarks></remarks>
    Private Sub load_xml(ByVal FileName As String)                                                                       'ไม่จำเป็นต้องใช้ไหมอะอันนี้ 
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_NYM_2
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Dim dao As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
    End Sub
    Function get_p2(ByVal FileName As String) As CLASS_NYM_2
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim objStreamReader As New StreamReader(bao._PATH_XML_TRADER & FileName & ".xml") '"C:\path\XML_TRADER\"
        Dim p2 As New CLASS_NYM_2
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
    End Function
    ''' <summary>
    ''' โหลดPDF
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub load_PDF(ByVal path As String, ByVal fileName As String)
        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
        Response.BinaryWrite(clsds.UpLoadImageByte(path)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub


    Private Sub BindData_PDF()
        Dim bao As New BAO.AppSettings

        Dim dao_up As New DAO_DRUG_IMPORT.ClsDBDRUG_IMPORT_UPLOAD
        dao_up.GetDataby_IDA(_IDA)                                      ' 
        ' Dim dao As New DAO_DRUG_IMPORT
        Dim dao2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        Dim dao4_2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY

        'Dim status_id As Integer = 0

        Dim dao_rg As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        Dim NYM_STATUS As Integer = 0
        Try
            dao_rg.GetDataby_IDA(_DL)
        Catch ex As Exception

        End Try
        Dim drug_name_th As String = ""
        Dim drug_name_eng As String = ""
        Dim drug_name As String = ""
        Try
            drug_name_th = dao_rg.fields.DRUG_NAME_THAI
        Catch ex As Exception

        End Try
        Try
            drug_name_eng = dao_rg.fields.DRUG_NAME_OTHER
        Catch ex As Exception

        End Try
        If (Trim(drug_name_th) = "-" Or Trim(drug_name_th) = "") And Trim(drug_name_eng) <> "" Then
            drug_name = drug_name_eng
        ElseIf (Trim(drug_name_eng) = "-" Or Trim(drug_name_eng) = "") And Trim(drug_name_th) <> "" Then
            drug_name = drug_name_th
        Else
            drug_name = drug_name_th & " / " & drug_name_eng
        End If

        If Trim(drug_name) = "/" Then
            drug_name = ""
        End If

        dao2.GetDataby_IDA(_IDA)
        dao3.getdata_ida(_IDA)
        dao4.getdata_ida(_IDA)
        dao4_2.getdata_ida(_IDA)
        Dim class_xml21 As New CLASS_NYM_2
        'Dim class_xml22 As New CLASS_NYM_2
        Dim class_xml3 As New CLASS_NYM_3_SM
        Dim class_xml4 As New CLASS_NYM_4_SM
        Dim class_xml4_2 As New CLASS_NYM_4_COMPANY

        Try
            class_xml21.NYM_2s = dao2.fields
        Catch ex As Exception

        End Try
        Try
            class_xml3.NYM_3s = dao3.fields
        Catch ex As Exception

        End Try
        Try
            class_xml4.NYM_4s = dao4.fields
        Catch ex As Exception

        End Try
        Try
            class_xml4_2.NYM_4_COMPANYs = dao4_2.fields
        Catch ex As Exception

        End Try
        'class_xml21.NYM_2s = dao2.fields
        'class_xml22.NYM_2s = dao2.fields



        'Dim p_noryormor2 As New CLASS_NYM_2
        'p_noryormor2 = p_nym2
        'p_dalcn2.DT_MASTER = Nothing

        'Dim cls_sop1 As New CLS_SOP
        'Session("b64") = cls_sop1.CLASS_TO_BASE64(p_noryormor2)
        'b64 = cls_sop1.CLASS_TO_BASE64(p_noryormor2)

        Dim bao_show As New BAO_SHOW
        'class_xml2.DT_SHOW.DT26 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM2(_IDA)



        'แก้ตรงนี้

        Dim bao_n As New BAO.ClsDBSqlcommand
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        Try
            dao_lcn.GetDataby_IDA(dao_rg.fields.FK_IDA)

        Catch ex As Exception

        End Try
        If _process = 1027 Then
            Try
                NYM_STATUS = dao2.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Try
                Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT
                dao_unit.GetDataby_sunitcd(dao_rg.fields.UNIT_NORMAL)
                class_xml21.SMALL_UNIT = CStr(dao2.fields.NYM2_COUNT_MED) & " " & dao_unit.fields.unit_name
            Catch ex As Exception

            End Try
            Try
                class_xml21.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
            Catch ex As Exception

            End Try
            class_xml21.DT_SHOW.DT26 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM2_ONLY1(_IDA)
            class_xml21.DT_SHOW.DT28 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM2(_IDA) '76 66
            class_xml21.DT_SHOW.DT7 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(_DL) 'ดึงตัวยาสำคัญ
            class_xml21.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
            class_xml21.DT_SHOW.DT11 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_ALL_BY_FK_IDA(_DL)
            Try
                class_xml21.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_rg.fields.CITIZEN_ID_AUTHORIZE, 0)
            Catch ex As Exception

            End Try
            class_xml21.DT_SHOW.DT6 = bao_n.SP_regis(_DL)
            Try
                class_xml21.REMARK = dao2.fields.REMARK
            Catch ex As Exception

            End Try
            Try
                class_xml21.DRUG_COLOR = dao_rg.fields.DRUG_COLOR
            Catch ex As Exception

            End Try
            Try

                class_xml21.PACK_SIZE = dao_rg.fields.PACKAGE_DETAIL
            Catch ex As Exception
                class_xml21.PACK_SIZE = "-"
            End Try
            Try
                class_xml21.LONG_APPDATE = CDate(dao2.fields.APPROVE_DATE).ToLongDateString()
            Catch ex As Exception

            End Try
            Try
                class_xml21.DRUG_NAME = drug_name
            Catch ex As Exception

            End Try
            Try
                'Dim dao_st As New DAO_DRUG.TB_MAS_STAFF_OFFER
                'dao_st.GetDataby_IDA(dao2.fields.NYM2_IDENTIFY_STAFF)
                class_xml21.APPROVE_NAME = dao2.fields.STAFF_NAME  'dao_st.fields.STAFF_OFFER_NAME
            Catch ex As Exception

            End Try
            Try
                class_xml21.RECEIVER_NAME = set_name_company(dao2.fields.STAFF_RECEIVE_IDEN)
            Catch ex As Exception

            End Try
            Dim rcvno_format As String = ""
            Try
                Try

                    If Len(dao2.fields.NYM2_NO) > 0 Then
                        rcvno_format = CStr(CInt(Right(dao2.fields.NYM2_NO, 5))) & "/" & Left(dao2.fields.NYM2_NO, 2)
                        class_xml21.RCVNO_FORMAT = rcvno_format
                    End If
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                class_xml21.LONG_RCVDATE = CDate(dao2.fields.rcvdate).ToLongDateString()
            Catch ex As Exception

            End Try


            Try
                If dao_lcn.fields.PROCESS_ID = "201" Or dao_lcn.fields.PROCESS_ID = "202" Or dao_lcn.fields.PROCESS_ID = "203" Or
                    dao_lcn.fields.PROCESS_ID = "204" Or dao_lcn.fields.PROCESS_ID = "205" Or dao_lcn.fields.PROCESS_ID = "206" Then
                    Dim val As String = ""
                    val = dao_lcn.fields.Co_name
                    If val = "1" Or val = "2" Or val = "3" Or val = "4" Or val = "5" Or val = "9" Or val = "10" Then
                        class_xml21.CHK_TYPE_LCN = val
                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml21.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml21.CHK_TYPE_LCN = "5"
                        End If
                    ElseIf val = "9" Or val = "10" Then
                        If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                            class_xml21.CHK_TYPE_LCN = "6"
                        ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                            class_xml21.CHK_TYPE_LCN = "7"
                        End If

                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml21.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml21.CHK_TYPE_LCN = "5"
                        End If

                    End If
                Else
                    If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                        class_xml21.CHK_TYPE_LCN = "6"
                    ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                        class_xml21.CHK_TYPE_LCN = "7"
                    End If
                    If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                        class_xml21.CHK_TYPE_LCN = "4"
                    ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                        class_xml21.CHK_TYPE_LCN = "5"
                    End If
                End If

            Catch ex As Exception

            End Try
        ElseIf _process = 1028 Then
            Try
                NYM_STATUS = dao2.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Try

                class_xml3.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
            Catch ex As Exception

            End Try
            Try
                Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT
                dao_unit.GetDataby_sunitcd(dao_rg.fields.UNIT_NORMAL)
                class_xml3.SMALL_UNIT = CStr(dao3.fields.NYM3_COUNT_MED) & " " & dao_unit.fields.unit_name
            Catch ex As Exception

            End Try
            class_xml3.DT_SHOW.DT26 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM3_ONLY1(_IDA)
            class_xml3.DT_SHOW.DT28 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM3(_IDA)                        'แก้ตรงนี้ 
            class_xml3.DT_SHOW.DT7 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(_DL) 'ดึงตัวยาสำคัญ
            class_xml3.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
            class_xml3.DT_SHOW.DT11 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_ALL_BY_FK_IDA(_DL)
            class_xml3.DT_SHOW.DT6 = bao_n.SP_regis(_DL)
            Try
                class_xml3.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_rg.fields.CITIZEN_ID_AUTHORIZE, 0)
            Catch ex As Exception

            End Try
            Try
                class_xml3.REMARK = dao3.fields.REMARK
            Catch ex As Exception

            End Try
            Try
                class_xml3.DRUG_COLOR = dao_rg.fields.DRUG_COLOR
            Catch ex As Exception

            End Try
            Try

                class_xml3.PACK_SIZE = dao_rg.fields.PACKAGE_DETAIL
            Catch ex As Exception
                class_xml3.PACK_SIZE = "-"
            End Try
            Try
                class_xml3.LONG_APPDATE = CDate(dao3.fields.APPROVE_DATE).ToLongDateString()
            Catch ex As Exception

            End Try
            Try
                class_xml3.DRUG_NAME = drug_name
            Catch ex As Exception

            End Try
            Try
                Dim dao_st As New DAO_DRUG.TB_MAS_STAFF_OFFER
                dao_st.GetDataby_IDA(dao3.fields.NYM3_IDENTIFY_STAFF)
                'class_xml3.APPROVE_NAME = dao_st.fields.STAFF_OFFER_NAME
                class_xml3.APPROVE_NAME = dao3.fields.STAFF_NAME
            Catch ex As Exception

            End Try
            Try
                class_xml3.RECEIVER_NAME = set_name_company(dao3.fields.STAFF_RECEIVE_IDEN)
            Catch ex As Exception

            End Try
            Dim rcvno_format As String = ""
            Try
                Try

                    If Len(dao3.fields.NYM3_NO) > 0 Then
                        rcvno_format = CStr(CInt(Right(dao3.fields.NYM3_NO, 5))) & "/" & Left(dao3.fields.NYM3_NO, 2)
                        class_xml3.RCVNO_FORMAT = rcvno_format
                    End If
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                class_xml3.LONG_RCVDATE = CDate(dao3.fields.rcvdate).ToLongDateString()
            Catch ex As Exception

            End Try
            Try
                If dao_lcn.fields.PROCESS_ID = "201" Or dao_lcn.fields.PROCESS_ID = "202" Or dao_lcn.fields.PROCESS_ID = "203" Or
                    dao_lcn.fields.PROCESS_ID = "204" Or dao_lcn.fields.PROCESS_ID = "205" Or dao_lcn.fields.PROCESS_ID = "206" Then
                    Dim val As String = ""
                    val = dao_lcn.fields.Co_name
                    If val = "1" Or val = "2" Or val = "3" Or val = "4" Or val = "5" Or val = "9" Or val = "10" Then
                        class_xml3.CHK_TYPE_LCN = val
                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml3.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml3.CHK_TYPE_LCN = "5"
                        End If
                    ElseIf val = "9" Or val = "10" Then
                        If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                            class_xml3.CHK_TYPE_LCN = "6"
                        ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                            class_xml3.CHK_TYPE_LCN = "7"
                        End If

                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml3.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml3.CHK_TYPE_LCN = "5"
                        End If

                    End If
                Else
                    If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                        class_xml3.CHK_TYPE_LCN = "6"
                    ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                        class_xml3.CHK_TYPE_LCN = "7"
                    End If
                    If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                        class_xml3.CHK_TYPE_LCN = "4"
                    ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                        class_xml3.CHK_TYPE_LCN = "5"
                    End If
                End If

            Catch ex As Exception

            End Try
        ElseIf _process = 1029 Then
            Try
                NYM_STATUS = dao2.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Try

                class_xml4.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
            Catch ex As Exception

            End Try
            Try
                Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT
                dao_unit.GetDataby_sunitcd(dao_rg.fields.UNIT_NORMAL)
                class_xml4.SMALL_UNIT = CStr(dao4.fields.NYM4_COUNT_MED) & " " & dao_unit.fields.unit_name
            Catch ex As Exception

            End Try
            class_xml4.DT_SHOW.DT26 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM4_ONLY1(_IDA)
            class_xml4.DT_SHOW.DT28 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM4(_IDA)
            class_xml4.DT_SHOW.DT7 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(_DL) 'ดึงตัวยาสำคัญ
            class_xml4.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
            class_xml4.DT_SHOW.DT11 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_ALL_BY_FK_IDA(_DL)
            class_xml4.DT_SHOW.DT6 = bao_n.SP_regis(_DL)
            Try
                class_xml4.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_rg.fields.CITIZEN_ID_AUTHORIZE, 0)
            Catch ex As Exception

            End Try
            Try
                class_xml4.REMARK = dao4.fields.REMARK
            Catch ex As Exception

            End Try
            Try
                class_xml4.DRUG_COLOR = dao_rg.fields.DRUG_COLOR
            Catch ex As Exception

            End Try
            Try

                class_xml4.PACK_SIZE = dao_rg.fields.PACKAGE_DETAIL
            Catch ex As Exception
                class_xml4.PACK_SIZE = "-"
            End Try
            Try
                class_xml4.LONG_APPDATE = CDate(dao4.fields.APPROVE_DATE).ToLongDateString()
            Catch ex As Exception

            End Try
            Try
                class_xml4.DRUG_NAME = drug_name
            Catch ex As Exception

            End Try
            Try
                Dim dao_st As New DAO_DRUG.TB_MAS_STAFF_OFFER
                dao_st.GetDataby_IDA(dao4.fields.NYM4_IDENTIFY_STAFF)
                'class_xml4.APPROVE_NAME = dao_st.fields.STAFF_OFFER_NAME
                class_xml4.APPROVE_NAME = dao4.fields.STAFF_NAME
            Catch ex As Exception

            End Try
            Try
                class_xml4.RECEIVER_NAME = set_name_company(dao4.fields.STAFF_RECEIVE_IDEN)
            Catch ex As Exception

            End Try
            Dim rcvno_format As String = ""
            Try
                Try

                    If Len(dao4.fields.NYM4_NO) > 0 Then
                        rcvno_format = CStr(CInt(Right(dao4.fields.NYM4_NO, 5))) & "/" & Left(dao4.fields.NYM4_NO, 2)
                        class_xml4.RCVNO_FORMAT = rcvno_format
                    End If
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                class_xml4.LONG_RCVDATE = CDate(dao4.fields.rcvdate).ToLongDateString()
            Catch ex As Exception

            End Try

            Try
                If dao_lcn.fields.PROCESS_ID = "201" Or dao_lcn.fields.PROCESS_ID = "202" Or dao_lcn.fields.PROCESS_ID = "203" Or
                    dao_lcn.fields.PROCESS_ID = "204" Or dao_lcn.fields.PROCESS_ID = "205" Or dao_lcn.fields.PROCESS_ID = "206" Then
                    Dim val As String = ""
                    val = dao_lcn.fields.Co_name
                    If val = "1" Or val = "2" Or val = "3" Or val = "4" Or val = "5" Or val = "9" Or val = "10" Then
                        class_xml4.CHK_TYPE_LCN = val
                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml4.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml4.CHK_TYPE_LCN = "5"
                        End If
                    ElseIf val = "9" Or val = "10" Then
                        If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                            class_xml4.CHK_TYPE_LCN = "6"
                        ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                            class_xml4.CHK_TYPE_LCN = "7"
                        End If

                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml4.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml4.CHK_TYPE_LCN = "5"
                        End If

                    End If
                Else
                    If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                        class_xml4.CHK_TYPE_LCN = "6"
                    ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                        class_xml4.CHK_TYPE_LCN = "7"
                    End If
                    If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                        class_xml4.CHK_TYPE_LCN = "4"
                    ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                        class_xml4.CHK_TYPE_LCN = "5"
                    End If
                End If

            Catch ex As Exception

            End Try
        ElseIf _process = 1031 Then
            Try
                NYM_STATUS = dao4_2.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Try

                class_xml4_2.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
            Catch ex As Exception

            End Try
            Try
                Dim dao_unit As New DAO_DRUG.TB_DRUG_UNIT
                dao_unit.GetDataby_sunitcd(dao_rg.fields.UNIT_NORMAL)
                class_xml4_2.SMALL_UNIT = CStr(dao4_2.fields.NYM4_COMPANY_COUNT_MED) & " " & dao_unit.fields.unit_name
            Catch ex As Exception

            End Try
            class_xml4_2.DT_SHOW.DT26 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM4_2_ONLY1(_IDA)
            class_xml4_2.DT_SHOW.DT28 = bao_show.SP_LOCATION_ADDRESS_BY_IDA_NYM4_2(_IDA)
            class_xml4_2.DT_SHOW.DT7 = bao_show.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(_DL) 'ดึงตัวยาสำคัญ
            class_xml4_2.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
            class_xml4_2.DT_SHOW.DT11 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_ALL_BY_FK_IDA(_DL)
            class_xml4_2.DT_SHOW.DT6 = bao_n.SP_regis(_DL)
            Try
                class_xml4_2.DT_SHOW.DT10 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(dao_rg.fields.CITIZEN_ID_AUTHORIZE, 0)
            Catch ex As Exception

            End Try
            Try
                class_xml4_2.REMARK = dao4_2.fields.REMARK
            Catch ex As Exception

            End Try
            Try
                class_xml4_2.DRUG_COLOR = dao_rg.fields.DRUG_COLOR
            Catch ex As Exception

            End Try
            Try

                class_xml4_2.PACK_SIZE = dao_rg.fields.PACKAGE_DETAIL
            Catch ex As Exception
                class_xml4_2.PACK_SIZE = "-"
            End Try
            Try
                class_xml4_2.LONG_APPDATE = CDate(dao4_2.fields.APPROVE_DATE).ToLongDateString()
            Catch ex As Exception

            End Try
            Try
                class_xml4_2.DRUG_NAME = drug_name
            Catch ex As Exception

            End Try
            Dim rcvno_format As String = ""
            Try
                Try

                    If Len(dao4_2.fields.NYM4_COMPANY_NO) > 0 Then
                        rcvno_format = CStr(CInt(Right(dao4.fields.NYM4_NO, 5))) & "/" & Left(dao4_2.fields.NYM4_COMPANY_NO, 2)
                        class_xml4_2.RCVNO_FORMAT = rcvno_format
                    End If
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            Try
                class_xml4_2.LONG_RCVDATE = CDate(dao4_2.fields.rcvdate).ToLongDateString()
            Catch ex As Exception

            End Try
            Try
                Dim dao_st As New DAO_DRUG.TB_MAS_STAFF_OFFER
                dao_st.GetDataby_IDA(dao4_2.fields.NYM4_IDENTIFY_STAFF)
                'class_xml4_2.APPROVE_NAME = dao_st.fields.STAFF_OFFER_NAME
                class_xml4_2.APPROVE_NAME = dao4_2.fields.STAFF_NAME
            Catch ex As Exception

            End Try
            Try
                class_xml4_2.RECEIVER_NAME = set_name_company(dao4_2.fields.STAFF_RECEIVE_IDEN)
            Catch ex As Exception

            End Try
            Try
                If dao_lcn.fields.PROCESS_ID = "201" Or dao_lcn.fields.PROCESS_ID = "202" Or dao_lcn.fields.PROCESS_ID = "203" Or
                    dao_lcn.fields.PROCESS_ID = "204" Or dao_lcn.fields.PROCESS_ID = "205" Or dao_lcn.fields.PROCESS_ID = "206" Then
                    Dim val As String = ""
                    val = dao_lcn.fields.Co_name
                    If val = "1" Or val = "2" Or val = "3" Or val = "4" Or val = "5" Or val = "9" Or val = "10" Then
                        class_xml4_2.CHK_TYPE_LCN = val
                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml4_2.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml4_2.CHK_TYPE_LCN = "5"
                        End If
                    ElseIf val = "9" Or val = "10" Then
                        If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                            class_xml4_2.CHK_TYPE_LCN = "6"
                        ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                            class_xml4_2.CHK_TYPE_LCN = "7"
                        End If

                        If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                            class_xml4_2.CHK_TYPE_LCN = "4"
                        ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                            class_xml4_2.CHK_TYPE_LCN = "5"
                        End If

                    End If
                Else
                    If dao_lcn.fields.lcntpcd.Contains("ผย") Then
                        class_xml4_2.CHK_TYPE_LCN = "6"
                    ElseIf dao_lcn.fields.lcntpcd.Contains("นย") Then
                        class_xml4_2.CHK_TYPE_LCN = "7"
                    End If
                    If dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000160127" Then
                        class_xml4_2.CHK_TYPE_LCN = "4"
                    ElseIf dao_lcn.fields.CITIZEN_ID_AUTHORIZE = "0994000165315" Then
                        class_xml4_2.CHK_TYPE_LCN = "5"
                    End If
                End If

            Catch ex As Exception

            End Try
        End If




        Dim dao_nym2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
        Dim dao_nym3 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
        Dim dao_nym4 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
        Dim dao_nym4_2 As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
        If _process = 1027 Then
            dao_nym2.GetDataby_IDA(_IDA)                                                     'ดึงข่้อมูลจาก IDA
        ElseIf _process = 1028 Then
            dao_nym3.GetDataby_IDA(_IDA)                                                     'ดึงข่้อมูลจาก IDA
        ElseIf _process = 1029 Then
            dao_nym4.GetDataby_IDA(_IDA)                                                     'ดึงข่้อมูลจาก IDA
        ElseIf _process = 1031 Then
            dao_nym4_2.GetDataby_IDA(_IDA)
        End If

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        Dim paths As String = bao._PATH_DEFAULT                                         ' PART ต้องเป็น defult ก่อน 

        dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_process, NYM_STATUS, 0)                     'DAO บรรทัด 2809
        Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim year As String = Date.Now.Year
        'Path_XML มาจาก ข้างบน ถ้าเปลี่ยน ที่อยู่ path มีตัวแปล paths dao_nym3 dao_pdftemplate
        Dim filename As String = ""
        Dim Path_XML As String = ""
        If _process = 1027 Then
            'filename = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, year, _TR_ID)
            filename = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, year, dao_nym2.fields.TR_ID) 'แก้ข้างหลังสุดให้เป็น field ที่มีใน NYM2
            Path_XML = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _process, year, dao_nym2.fields.TR_ID) 'load_PDF(filename)
        ElseIf _process = 1028 Then
            filename = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, year, dao_nym3.fields.TR_ID) 'แก้ข้างหลังสุดให้เป็น field ที่มีใน NYM2
            Path_XML = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _process, year, dao_nym3.fields.TR_ID) 'load_PDF(filename)                       BAO_COMMOND 627
        ElseIf _process = 1029 Then
            filename = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, year, dao_nym4.fields.TR_ID) 'แก้ข้างหลังสุดให้เป็น field ที่มีใน NYM2
            Path_XML = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _process, year, dao_nym4.fields.TR_ID) 'load_PDF(filename)
        ElseIf _process = 1031 Then
            filename = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF("DA", _process, year, dao_nym4_2.fields.TR_ID) 'แก้ข้างหลังสุดให้เป็น field ที่มีใน NYM2
            Path_XML = paths & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML("DA", _process, year, dao_nym4_2.fields.TR_ID) 'load_PDF(filename)
        End If

        Try
            Dim url As String = ""
            url = Request.Url.GetLeftPart(UriPartial.Authority) & Request.ApplicationPath & "/PDF/FRM_PDF.aspx?filename=" & filename
            If NYM_STATUS = 8 Then
                class_xml21.QR_CODE = QR_CODE_IMG(url)
                class_xml3.QR_CODE = QR_CODE_IMG(url)
                class_xml4.QR_CODE = QR_CODE_IMG(url)
                class_xml4_2.QR_CODE = QR_CODE_IMG(url)
            End If

        Catch ex As Exception

        End Try

        p_nym2 = class_xml21
        p_nym3 = class_xml3
        p_nym4 = class_xml4
        p_nym4_2 = class_xml4_2
        LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, _process, filename) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML  เอง AUTO        DAO COMMON  483 558 602 และ  CLASS GEN XML


        lr_preview.Text = "<iframe id='iframe1'  style='height:800px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & filename & "' ></iframe>" 'แสดงไฟล์บนหน้าเว็บ
        hl_reader.NavigateUrl = "../PDF/FRM_PDF_VIEW.aspx?FileName=" & filename ' Link เปิดไฟล์ตัวใหญ่ ACOBAT


        HiddenField1.Value = filename
        If _process = 1027 Then
            _CLS.FILENAME_PDF = NAME_PDF("DA", _process, year, dao_nym2.fields.TR_ID)
        ElseIf _process = 1028 Then
            _CLS.FILENAME_PDF = NAME_PDF("DA", _process, year, dao_nym3.fields.TR_ID)
        ElseIf _process = 1029 Then
            _CLS.FILENAME_PDF = NAME_PDF("DA", _process, year, dao_nym4.fields.TR_ID)
        ElseIf _process = 1031 Then
            _CLS.FILENAME_PDF = NAME_PDF("DA", _process, year, dao_nym4_2.fields.TR_ID)
        End If
        _CLS.PDFNAME = filename
        '    show_btn() 'ตรวจสอบปุ่ม

    End Sub
    Private Sub load_pdf(ByVal FilePath As String)


        '  Response.ContentType = "Application/pdf"

        Dim clsds As New ClassDataset

        Dim bb As Byte() = clsds.UpLoadImageByte(FilePath)

        Dim ws_F As New WS_FLATTEN.WS_FLATTEN

        Dim b_o As Byte() = ws_F.FlattenPDF_DIGITAL(bb)

        Response.ContentType = "application/pdf"
        Response.AddHeader("content-length", b_o.Length.ToString())
        Response.BinaryWrite(b_o)



        'Response.Clear()
        'Response.ContentType = "application/pdf"
        'Response.AddHeader("Content-Disposition", "attachment;filename=abc.pdf")

        'Response.BinaryWrite(clsds.UpLoadImageByte(FilePath))

        'Response.Flush()

        Response.End()
    End Sub


    Public Function UpLoadImageByte(ByVal info As String) As Byte()
        Dim stream As New FileStream(info.Replace("/", "\"), FileMode.Open)
        Dim reader As New BinaryReader(stream)
        Dim imgBin() As Byte
        Try
            imgBin = reader.ReadBytes(stream.Length)
        Catch ex As Exception
        Finally
            stream.Close()
            reader.Close()
        End Try
        Return imgBin
    End Function
    Private Function set_name_company(ByVal identify As String) As String
        Dim fullname As String = String.Empty
        Try
            Dim dao_syslcnsid As New DAO_CPN.clsDBsyslcnsid
            dao_syslcnsid.GetDataby_identify(identify)

            Dim dao_sysnmperson As New DAO_CPN.clsDBsyslcnsnm
            dao_sysnmperson.GetDataby_lcnsid(dao_syslcnsid.fields.lcnsid)

            Dim ws2 As New WS_Taxno_TaxnoAuthorize.WebService1

            Dim ws_taxno = ws2.getProfile_byidentify(identify)

            fullname = ws_taxno.SYSLCNSNMs.thanm & " " & ws_taxno.SYSLCNSNMs.thalnm


        Catch ex As Exception
            fullname = ""
        End Try

        Return fullname
    End Function
    Protected Sub btn_load0_Click(sender As Object, e As EventArgs) Handles btn_load0.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class