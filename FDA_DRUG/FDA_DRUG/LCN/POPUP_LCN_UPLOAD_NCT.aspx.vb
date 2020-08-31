Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports iTextSharp.text.pdf
Imports System.Xml
Public Class POPUP_LCN_UPLOAD_NCT
    Inherits System.Web.UI.Page
    Private _type_id As String = ""
    Private _IDA As String = ""
    Private _ProcessID As Integer
    Private _lcn_ida As String = ""
    Private _CLS As New CLS_SESSION
    Private _lct_ida As String = ""
    Private _pvncd As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        runQuery()
        get_pvncd()
        set_txt_label()
        show_panel()
        If Not IsPostBack Then
            If Request.QueryString("identify") <> "" Then
                If Request.QueryString("identify") <> _CLS.CITIZEN_ID_AUTHORIZE Then
                    AddLogMultiTab(_CLS.CITIZEN_ID, Request.QueryString("identify"), 0, HttpContext.Current.Request.Url.AbsoluteUri)

                End If
            End If
        End If
    End Sub

    Dim bao As New BAO.AppSettings
    Sub get_pvncd()
        '  _pvncd = Personal_Province(_CLS.CITIZEN_ID, _CLS.Groups)
        Try
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.Groups)
            If _pvncd = 0 Then
                _pvncd = _CLS.PVCODE
            End If
        Catch ex As Exception
            _pvncd = 10
        End Try
    End Sub
    Sub runQuery()

        _type_id = Request.QueryString("type_id")
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
        _lcn_ida = Request.QueryString("lcn_ida")
        _lct_ida = Request.QueryString("lct_ida")
        bao.RunAppSettings()
        _CLS = Session("CLS")

    End Sub

    Public Sub show_panel()
        If _ProcessID = "111" Then
            Panel201.Style.Add("display", "block")
        ElseIf _ProcessID = "115" Then
            Panel202.Style.Add("display", "block")
        ElseIf _ProcessID = "110" Then
            Panel201.Style.Add("display", "block")
        ElseIf _ProcessID = "114" Then
            Panel202.Style.Add("display", "block")
        ElseIf _ProcessID = "123" Then
            Panel123.Style.Add("display", "block")
        ElseIf _ProcessID = "124" Then
            Panel124.Style.Add("display", "block")
        ElseIf _ProcessID = "125" Then
            Panel125.Style.Add("display", "block")
        ElseIf _ProcessID = "126" Then
            Panel126.Style.Add("display", "block")
        ElseIf _ProcessID = "127" Then
            Panel127.Style.Add("display", "block")
        ElseIf _ProcessID = "128" Then
            Panel128.Style.Add("display", "block")
        ElseIf _ProcessID = "129" Then
            Panel129.Style.Add("display", "block")
        ElseIf _ProcessID = "130" Then
            Panel130.Style.Add("display", "block")
        ElseIf _ProcessID = "131" Then
            Panel131.Style.Add("display", "block")
        ElseIf _ProcessID = "132" Then
            Panel132.Style.Add("display", "block")
        ElseIf _ProcessID = "133" Then
            Panel133.Style.Add("display", "block")
        ElseIf _ProcessID = "134" Then
            Panel134.Style.Add("display", "block")
        ElseIf _ProcessID = "135" Then
            Panel135.Style.Add("display", "block")
        ElseIf _ProcessID = "136" Then
            Panel136.Style.Add("display", "block")
        Else

        End If
    End Sub
    Public Sub set_txt_label()
        'ข.จ.2
        uc101_1.get_label("แบบคำอนุญาต (ตามประเภท) เจ้าของคนใหม่")
        uc101_2.get_label("รูปถ่ายของผู้อนุญาต (เจ้าของคนใหม่/ผู้ขออนุญาต) ขนาด 3*4 ซม. (3รูป) ถ่ายไม่เกิน 6 เดือน")
        uc101_3.get_label("สำเนาใบอนุญาตยาปัจจุบัน (ตามประเภท)")
        uc101_4.get_label("สำเนาทะเบียนบ้านของผู้อนุญาต (รับรองจริง)")
        uc101_5.get_label("สำเนาบัตรประชาชนของผู้อนุญาต (รับรองจริง)")

        'จ.ย.ส.3
        uc102_1.get_label("แบบคำขออนุญาต (ตามประเภท) เจ้าของคนใหม่")
        uc102_2.get_label("รูปถ่ายของผู้รับอนุญาต (เจ้าของคนใหม่/ผู้ขออนุญาต) ขนาด 3*4 ซม.(3 รูป) ถ่ายไม่เกิน 6 เดือน")
        uc102_3.get_label("สำเนาใบอนุญาตขายวัตถุออกฤทธิ์ประเภท 3,4")
        uc102_4.get_label("สำเนาใบอนุญาตขายยาแผนปัจจุบัน")

        'ขาย วจ3
        uc123_1.get_label("(๑) สำเนาใบอนุญาตขายยาแผนปัจจุบันตามกฎหมายว่าด้วยยา")
        uc123_2.get_label("(๒) คำรับรองของผู้รับอนุญาตและเภสัชกรผู้ควบคุมกิจการ")
        uc123_3.get_label("(๓) รูปถ่ายหน้าตรง ไม่สวมหมวกและแว่นตาสีเข้ม ของผู้ขอรับใบอนุญาตหรือผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินกิจการเกี่ยวกับใบอนุญาต ขนาด ๑ นิ้ว จำนวน ๓ รูป ซึ่งถ่ายไว้ไม่เกิน ๖ เดือนก่อนวันยื่นคำขอ")
        uc123_4.get_label("(๔) สำเนาใบอนุญาตประกอบวิชาชีพเภสัชกรรม")
        uc123_5.get_label("(๕) หนังสือแต่งตั้งผู้ดำเนินกิจการ กรณีผู้ขอรับใบอนุญาตเป็นนิติบุคคล")

        'ขายวจ 4
        uc124_1.get_label("(๑) สำเนาใบอนุญาตขายยาแผนปัจจุบันตามกฎหมายว่าด้วยยา")
        uc124_2.get_label("(๒) คำรับรองของผู้รับอนุญาตและเภสัชกรผู้ควบคุมกิจการ")
        uc124_3.get_label("(๓) รูปถ่ายหน้าตรง ไม่สวมหมวกและแว่นตาสีเข้ม ของผู้ขอรับใบอนุญาตหรือผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินกิจการเกี่ยวกับใบอนุญาต ขนาด ๑ นิ้ว จำนวน ๓ รูป ซึ่งถ่ายไว้ไม่เกิน ๖ เดือนก่อนวันยื่นคำขอ")
        uc124_4.get_label("(๔) สำเนาใบอนุญาตประกอบวิชาชีพเภสัชกรรม")
        uc124_5.get_label("(๕) หนังสือแต่งตั้งผู้ดำเนินกิจการ กรณีผู้ขอรับใบอนุญาตเป็นนิติบุคคล")

        'ขตวจ3
        uc125_1.get_label("(๑) สำเนาใบอนุญาตผลิต ขาย หรือนำเข้าวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ แล้วแต่กรณี")
        uc125_2.get_label("(๒) รูปถ่ายหน้าตรง ไม่สวมหมวกและแว่นตาสีเข้ม ของผู้ขอรับใบอนุญาตหรือผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินกิจการเกี่ยวกับใบอนุญาต ขนาด ๑ นิ้ว จำนวน ๓ รูป ซึ่งถ่ายไว้ไม่เกิน ๖ เดือนก่อนวันยื่นคำขอ")

        'ขตวจ4
        uc126_1.get_label("(๑) สำเนาใบอนุญาตผลิต ขาย หรือนำเข้าวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ แล้วแต่กรณี")
        uc126_2.get_label("(๒) รูปถ่ายหน้าตรง ไม่สวมหมวกและแว่นตาสีเข้ม ของผู้ขอรับใบอนุญาตหรือผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินกิจการเกี่ยวกับใบอนุญาต ขนาด ๑ นิ้ว จำนวน ๓ รูป ซึ่งถ่ายไว้ไม่เกิน ๖ เดือนก่อนวันยื่นคำขอ")

        'ผวจ3
        uc127_1.get_label("(๑) สำเนาใบอนุญาตผลิตยาแผนปัจจุบันตามกฎหมายว่าด้วยยา")
        uc127_2.get_label("(๒) คำรับรองของผู้รับอนุญาตและเภสัชกรผู้ควบคุมกิจการ")
        uc127_3.get_label("(๓) รูปถ่ายหน้าตรง ไม่สวมหมวกและแว่นตาสีเข้ม ของผู้ขอรับใบอนุญาตหรือผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินกิจการเกี่ยวกับใบอนุญาต ขนาด ๑ นิ้ว จำนวน ๓ รูป ซึ่งถ่ายไว้ไม่เกิน ๖ เดือนก่อนวันยื่นคำขอ")
        uc127_4.get_label("(๔) สำเนาใบอนุญาตประกอบวิชาชีพเภสัชกรรม")
        uc127_5.get_label("(๕) หนังสือแต่งตั้งผู้ดำเนินกิจการ กรณีผู้ขอรับใบอนุญาตเป็นนิติบุคคล")
        uc127_6.get_label("(๖)แผนที่แสดงที่ตั้งและแผนผังแสดงที่ผลิตหรือเก็บซึ่งวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ ของสถานประกอบการ")
        uc127_7.get_label("(๗) รูปถ่ายแสดงที่ผลิตหรือเก็บซึ่งวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ ของสถานประกอบการจำนวน ๑ รูป")
        'ผวจ4
        uc128_1.get_label("(๑) สำเนาใบอนุญาตผลิตยาแผนปัจจุบันตามกฎหมายว่าด้วยยา")
        uc128_2.get_label("(๒) คำรับรองของผู้รับอนุญาตและเภสัชกรผู้ควบคุมกิจการ")
        uc128_3.get_label("(๓) รูปถ่ายหน้าตรง ไม่สวมหมวกและแว่นตาสีเข้ม ของผู้ขอรับใบอนุญาตหรือผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินกิจการเกี่ยวกับใบอนุญาต ขนาด ๑ นิ้ว จำนวน ๓ รูป ซึ่งถ่ายไว้ไม่เกิน ๖ เดือนก่อนวันยื่นคำขอ")
        uc128_4.get_label("(๔) สำเนาใบอนุญาตประกอบวิชาชีพเภสัชกรรม")
        uc128_5.get_label("(๕) หนังสือแต่งตั้งผู้ดำเนินกิจการ กรณีผู้ขอรับใบอนุญาตเป็นนิติบุคคล")
        uc128_6.get_label("(๖)แผนที่แสดงที่ตั้งและแผนผังแสดงที่ผลิตหรือเก็บซึ่งวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ ของสถานประกอบการ")
        uc128_7.get_label("(๗) รูปถ่ายแสดงที่ผลิตหรือเก็บซึ่งวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ ของสถานประกอบการจำนวน ๑ รูป")

        uc129_1.get_label("(๑) สำเนาใบอนุญาตผลิต ขาย หรือนำเข้าวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ แล้วแต่กรณี")

        uc130_1.get_label("(๑) สำเนาใบอนุญาตผลิต ขาย หรือนำเข้าวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ แล้วแต่กรณี")

        'นวจ3
        uc131_1.get_label("(๑) คำรับรองของผู้รับอนุญาตและเภสัชกรผู้ควบคุมกิจการ")
        uc131_2.get_label("(๒) รูปถ่ายหน้าตรง ไม่สวมหมวกและแว่นตาสีเข้ม ของผู้ขอรับใบอนุญาตหรือผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินกิจการเกี่ยวกับใบอนุญาต ขนาด ๑ นิ้ว จำนวน ๓ รูป ซึ่งถ่ายไว้ไม่เกิน ๖ เดือนก่อนวันยื่นคำขอ")
        uc131_3.get_label("(๓) สำเนาใบอนุญาตประกอบวิชาชีพเภสัชกรรม")
        uc131_4.get_label("(๔) หนังสือแต่งตั้งผู้ดำเนินกิจการ กรณีผู้ขอรับใบอนุญาตเป็นนิติบุคคล")
        uc131_5.get_label("(๕)แผนที่แสดงที่ตั้งและแผนผังแสดงที่นำเข้าหรือเก็บซึ่งวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ ของสถานประกอบการ")
        uc131_6.get_label("(๖) รูปถ่ายแสดงที่นำเข้าหรือเก็บซึ่งวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ ของสถานประกอบการจำนวน ๑ รูป")

        uc132_1.get_label("(๑) คำรับรองของผู้รับอนุญาตและเภสัชกรผู้ควบคุมกิจการ")
        uc132_2.get_label("(๒) รูปถ่ายหน้าตรง ไม่สวมหมวกและแว่นตาสีเข้ม ของผู้ขอรับใบอนุญาตหรือผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินกิจการเกี่ยวกับใบอนุญาต ขนาด ๑ นิ้ว จำนวน ๓ รูป ซึ่งถ่ายไว้ไม่เกิน ๖ เดือนก่อนวันยื่นคำขอ")
        uc132_3.get_label("(๓) สำเนาใบอนุญาตประกอบวิชาชีพเภสัชกรรม")
        uc132_4.get_label("(๔) หนังสือแต่งตั้งผู้ดำเนินกิจการ กรณีผู้ขอรับใบอนุญาตเป็นนิติบุคคล")
        uc132_5.get_label("(๕)แผนที่แสดงที่ตั้งและแผนผังแสดงที่นำเข้าหรือเก็บซึ่งวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ ของสถานประกอบการ")
        uc132_6.get_label("(๖) รูปถ่ายแสดงที่นำเข้าหรือเก็บซึ่งวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ ของสถานประกอบการจำนวน ๑ รูป")

        'สวจ3
        uc133_1.get_label("(๑) คำรับรองของผู้รับอนุญาตและเภสัชกรผู้ควบคุมกิจการ")
        uc133_2.get_label("(๒) รูปถ่ายหน้าตรง ไม่สวมหมวกและแว่นตาสีเข้ม ของผู้ขอรับใบอนุญาตหรือผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินกิจการเกี่ยวกับใบอนุญาต ขนาด ๑ นิ้ว จำนวน ๓ รูป ซึ่งถ่ายไว้ไม่เกิน ๖ เดือนก่อนวันยื่นคำขอ")
        uc133_3.get_label("(๓) สำเนาใบอนุญาตประกอบวิชาชีพเภสัชกรรม")
        uc133_4.get_label("(๔) หนังสือแต่งตั้งผู้ดำเนินกิจการ กรณีผู้ขอรับใบอนุญาตเป็นนิติบุคคล")
        uc133_5.get_label("(๕)แผนที่แสดงที่ตั้งและแผนผังแสดงที่นำเข้าหรือเก็บซึ่งวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ ของสถานประกอบการ")
        uc133_6.get_label("(๖) รูปถ่ายแสดงที่นำเข้าหรือเก็บซึ่งวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ ของสถานประกอบการจำนวน ๑ รูป")

        uc134_1.get_label("(๑) คำรับรองของผู้รับอนุญาตและเภสัชกรผู้ควบคุมกิจการ")
        uc134_2.get_label("(๒) รูปถ่ายหน้าตรง ไม่สวมหมวกและแว่นตาสีเข้ม ของผู้ขอรับใบอนุญาตหรือผู้ได้รับมอบหมายหรือแต่งตั้งให้ดำเนินกิจการเกี่ยวกับใบอนุญาต ขนาด ๑ นิ้ว จำนวน ๓ รูป ซึ่งถ่ายไว้ไม่เกิน ๖ เดือนก่อนวันยื่นคำขอ")
        uc134_3.get_label("(๓) สำเนาใบอนุญาตประกอบวิชาชีพเภสัชกรรม")
        uc134_4.get_label("(๔) หนังสือแต่งตั้งผู้ดำเนินกิจการ กรณีผู้ขอรับใบอนุญาตเป็นนิติบุคคล")
        uc134_5.get_label("(๕)แผนที่แสดงที่ตั้งและแผนผังแสดงที่นำเข้าหรือเก็บซึ่งวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ ของสถานประกอบการ")
        uc134_6.get_label("(๖) รูปถ่ายแสดงที่นำเข้าหรือเก็บซึ่งวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ ของสถานประกอบการจำนวน ๑ รูป")

        uc135_1.get_label("(๑) สำเนาใบอนุญาตผลิต ขาย หรือนำเข้าวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ แล้วแต่กรณี")
        uc136_1.get_label("(๑) สำเนาใบอนุญาตผลิต ขาย หรือนำเข้าวัตถุออกฤทธิ์ในประเภท ๓ หรือประเภท ๔ แล้วแต่กรณี")
    End Sub

    Public Sub SET_ATTACH(ByVal TR_ID As String, ByVal PROCESS_ID As String, ByVal YEAR As String)
        If _type_id = "110" Then
            'ข.จ.2
            uc101_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc101_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            uc101_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc101_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
        ElseIf _type_id = "115" Then
            'จ.ย.ส.3
            uc102_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc102_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            uc102_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc102_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
        End If
    End Sub

    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        If FileUpload1.HasFile Then
            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()


            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

            TR_ID = bao_tran.insert_transection(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION



            'If UC_ATTACH1.ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year), "1") = False Then
            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('กรุณาแนบไฟล์');", True)
            '    Exit Sub
            'End If

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_ProcessID, 1, 0)
            'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
            Dim PDF_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
            'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
            Dim XML_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)


            FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"
            'ทำการแปลงส่ง PDF เข้าไปแล้วแปลงออกเป็น XML
            convert_PDF_To_XML(PDF_TRADER, XML_TRADER)


            '    convert_PDF_To_XML(bao._PATH_PDF_TRADER & "FA-5-2558-" & TR_ID & ".pdf", TR_ID) '"C:\path\PDF_TRADER\"
            Dim check As Boolean = True
            'Try
            check = insrt_to_database(XML_TRADER, TR_ID)
            If check = True Then
                SET_ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year))
                alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            Else

            End If
            'Catch ex As Exception

            'alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            'End Try


        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Write("<script type='text/javascript'>window.parent.close_modal();</script> ")
    End Sub



    ''' <summary>
    ''' ดึง lcntpcd
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function set_lcntpcd() As String
        Dim dao As New DAO_DRUG.ClsDBPROCESS_NAME
        dao.GetDataby_Process_ID(_ProcessID)
        Return dao.fields.PROCESS_NAME
    End Function


    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database(ByVal FileName As String, ByVal TR_ID As String) As Boolean
        Dim check As Boolean = True

        'Try
        Dim objStreamReader As New StreamReader(FileName)
        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()

        Dim cernumber As String = ""

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.fields = p2.dalcns

        dao.fields.lcnsid = dao.fields.lcnsid
        dao.fields.PROCESS_ID = _ProcessID
        dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.rcvdate = Date.Now
        dao.fields.lmdfdate = Date.Now
        dao.fields.STATUS_ID = 1
        dao.fields.TR_ID = CDec(TR_ID)
        dao.fields.FK_IDA = CDec(_lct_ida)
        dao.fields.CTZNO = _CLS.CITIZEN_ID
        dao.fields.lcntpcd = set_lcntpcd()
        dao.fields.CITIZEN_ID_UPLOAD = _CLS.CITIZEN_ID
        dao.fields.MAIN_LCN_IDA = _lcn_ida

        Dim chw As String = ""
        Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
        Try
            dao_cpn.GetData_by_chngwtcd(_pvncd)
            chw = dao_cpn.fields.thacwabbr
        Catch ex As Exception

        End Try
        dao.fields.pvnabbr = chw
        Try
            dao.fields.pvncd = _pvncd
        Catch ex As Exception

        End Try
        Try
            dao.fields.chngwtcd = _pvncd
        Catch ex As Exception

        End Try
        If Request.QueryString("staff") <> "" Then
            dao.fields.OTHER = "1"
        End If
        Dim dao_dalcn_MAIN As New DAO_DRUG.ClsDBdalcn
        dao_dalcn_MAIN.GetDataby_IDA(_lcn_ida)
        dao.fields.AGE = dao_dalcn_MAIN.fields.AGE
        dao.fields.NATION = dao_dalcn_MAIN.fields.NATION
        dao.fields.NATIONALITY = dao_dalcn_MAIN.fields.NATIONALITY

        Dim dao_syslcnsnm As New DAO_CPN.clsDBsyslcnsnm
        dao_syslcnsnm.GetDataby_identify(_CLS.CITIZEN_ID_AUTHORIZE)
        dao.fields.thanm = dao_syslcnsnm.fields.thanm
        dao.fields.syslcnsnm_ID = dao_syslcnsnm.fields.ID
        dao.fields.syslcnsnm_identify = dao_syslcnsnm.fields.identify
        dao.fields.syslcnsnm_lcnsid = dao_syslcnsnm.fields.lcnsid
        dao.fields.syslcnsnm_lcnscd = dao_syslcnsnm.fields.lcnscd
        dao.fields.syslcnsnm_prefixcd = dao_syslcnsnm.fields.prefixcd
        dao.fields.syslcnsnm_prefixnm = dao_syslcnsnm.fields.prefixnm
        dao.fields.syslcnsnm_thanm = dao_syslcnsnm.fields.thanm
        dao.fields.syslcnsnm_engnm = dao_syslcnsnm.fields.engnm
        dao.fields.syslcnsnm_lctcd = dao_syslcnsnm.fields.lctcd
        dao.fields.syslcnsnm_thalnm = dao_syslcnsnm.fields.thalnm
        dao.fields.syslcnsnm_englnm = dao_syslcnsnm.fields.englnm
        dao.fields.syslcnsnm_suffixcd = dao_syslcnsnm.fields.suffixcd
        dao.fields.syslcnsnm_lcnsst = dao_syslcnsnm.fields.lcnsst
        dao.fields.syslcnsnm_grplcnscd = dao_syslcnsnm.fields.grplcnscd
        dao.fields.syslcnsnm_bsncd = dao_syslcnsnm.fields.bsncd
        dao.fields.syslcnsnm_lstfcd = dao_syslcnsnm.fields.lstfcd
        dao.fields.syslcnsnm_lmdfdate = dao_syslcnsnm.fields.lmdfdate
        dao.fields.syslcnsnm_lcnsidst = dao_syslcnsnm.fields.lcnsidst
        dao.fields.syslcnsnm_validdate = dao_syslcnsnm.fields.validdate
        dao.fields.syslcnsnm_oldid = dao_syslcnsnm.fields.oldid
        dao.fields.syslcnsnm_type = dao_syslcnsnm.fields.type
        dao.fields.syslcnsnm_update_date = dao_syslcnsnm.fields.update_date
        dao.fields.syslcnsnm_create_date = dao_syslcnsnm.fields.create_date

        Try
            dao.fields.syslctaddr_thaaddr = p2.syslctaddr_thaaddr
        Catch ex As Exception

        End Try
        Try
            dao.fields.syslctaddr_engaddr = p2.syslctaddr_engaddr
        Catch ex As Exception

        End Try
        Try
            dao.fields.syslctaddr_room = p2.syslctaddr_room
        Catch ex As Exception

        End Try
        Try
            dao.fields.syslctaddr_mu = p2.syslctaddr_mu
        Catch ex As Exception

        End Try
        Try
            dao.fields.syslctaddr_floor = p2.syslctaddr_floor
        Catch ex As Exception

        End Try
        Try
            dao.fields.syslctaddr_thasoi = p2.syslctaddr_thasoi
        Catch ex As Exception

        End Try

        'Dim dao_location_address As New DAO_CPN.TB_LOCATION_ADDRESS
        'dao_location_address.GetDataby_IDA(_lct_ida)
        Dim dao_location_address As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_location_address.GetDataby_IDA(_lct_ida)
        dao.fields.LOCATION_ADDRESS_thathmblnm = dao_location_address.fields.thanameplace
        dao.fields.LOCATION_ADDRESS_thaaddr = dao_location_address.fields.thaaddr
        dao.fields.LOCATION_ADDRESS_thasoi = dao_location_address.fields.thasoi
        dao.fields.LOCATION_ADDRESS_tharoad = dao_location_address.fields.tharoad
        dao.fields.LOCATION_ADDRESS_thamu = dao_location_address.fields.thamu
        dao.fields.LOCATION_ADDRESS_thathmblnm = dao_location_address.fields.thathmblnm
        dao.fields.LOCATION_ADDRESS_thaamphrnm = dao_location_address.fields.thaamphrnm
        dao.fields.LOCATION_ADDRESS_thachngwtnm = dao_location_address.fields.thachngwtnm
        dao.fields.LOCATION_ADDRESS_tel = dao_location_address.fields.tel
        dao.fields.LOCATION_ADDRESS_fax = dao_location_address.fields.fax
        dao.fields.LOCATION_ADDRESS_thanameplace = dao_location_address.fields.engnameplace
        dao.fields.LOCATION_ADDRESS_thaaddr = dao_location_address.fields.thaaddr
        dao.fields.LOCATION_ADDRESS_thasoi = dao_location_address.fields.thasoi
        dao.fields.LOCATION_ADDRESS_tharoad = dao_location_address.fields.tharoad
        dao.fields.LOCATION_ADDRESS_thamu = dao_location_address.fields.thamu
        dao.fields.LOCATION_ADDRESS_thathmblnm = dao_location_address.fields.thathmblnm
        dao.fields.LOCATION_ADDRESS_thaamphrnm = dao_location_address.fields.thaamphrnm
        dao.fields.LOCATION_ADDRESS_thachngwtnm = dao_location_address.fields.thachngwtnm
        dao.fields.LOCATION_ADDRESS_tel = dao_location_address.fields.tel
        dao.fields.LOCATION_ADDRESS_fax = dao_location_address.fields.fax
        dao.fields.LOCATION_ADDRESS_lcnsid = dao_location_address.fields.lcnsid
        dao.fields.LOCATION_ADDRESS_engaddr = dao_location_address.fields.engaddr
        dao.fields.LOCATION_ADDRESS_tharoom = dao_location_address.fields.tharoom
        dao.fields.LOCATION_ADDRESS_thabuilding = dao_location_address.fields.thabuilding
        dao.fields.LOCATION_ADDRESS_engsoi = dao_location_address.fields.engsoi
        dao.fields.LOCATION_ADDRESS_engroad = dao_location_address.fields.engroad
        dao.fields.LOCATION_ADDRESS_zipcode = dao_location_address.fields.zipcode
        dao.fields.LOCATION_ADDRESS_lstfcd = dao_location_address.fields.lstfcd
        dao.fields.LOCATION_ADDRESS_lmdfdate = dao_location_address.fields.lmdfdate
        dao.fields.LOCATION_ADDRESS_IDA = dao_location_address.fields.IDA
        dao.fields.LOCATION_ADDRESS_FK_IDA = dao_location_address.fields.FK_IDA
        dao.fields.LOCATION_ADDRESS_TR_ID = dao_location_address.fields.TR_ID
        dao.fields.LOCATION_ADDRESS_DOWN_ID = dao_location_address.fields.DOWN_ID
        dao.fields.LOCATION_ADDRESS_CITIZEN_ID = dao_location_address.fields.CITIZEN_ID
        dao.fields.LOCATION_ADDRESS_CITIZEN_ID_UPLOAD = dao_location_address.fields.CITIZEN_ID_UPLOAD
        dao.fields.LOCATION_ADDRESS_XMLNAME = dao_location_address.fields.XMLNAME
        dao.fields.LOCATION_ADDRESS_engmu = dao_location_address.fields.engmu
        dao.fields.LOCATION_ADDRESS_engfloor = dao_location_address.fields.engfloor
        dao.fields.LOCATION_ADDRESS_engbuilding = dao_location_address.fields.engbuilding
        dao.fields.LOCATION_ADDRESS_rcvno = dao_location_address.fields.rcvno
        dao.fields.LOCATION_ADDRESS_rcvdate = dao_location_address.fields.rcvdate
        dao.fields.LOCATION_ADDRESS_lctcd = dao_location_address.fields.lctcd
        dao.fields.LOCATION_ADDRESS_engnameplace = dao_location_address.fields.engnameplace
        dao.fields.LOCATION_ADDRESS_STATUS_ID = dao_location_address.fields.STATUS_ID
        dao.fields.LOCATION_ADDRESS_HOUSENO = dao_location_address.fields.HOUSENO
        dao.fields.LOCATION_ADDRESS_Branch = dao_location_address.fields.Branch
        dao.fields.LOCATION_ADDRESS_LOCATION_TYPE_NORMAL = dao_location_address.fields.LOCATION_TYPE_NORMAL
        dao.fields.LOCATION_ADDRESS_LOCATION_TYPE_OTHER = dao_location_address.fields.LOCATION_TYPE_OTHER
        dao.fields.LOCATION_ADDRESS_LOCATION_TYPE_ID = dao_location_address.fields.LOCATION_TYPE_ID
        dao.fields.LOCATION_ADDRESS_SYSTEM_NAME = dao_location_address.fields.SYSTEM_NAME
        dao.fields.LOCATION_ADDRESS_thmblcd = dao_location_address.fields.thmblcd
        dao.fields.LOCATION_ADDRESS_chngwtcd = dao_location_address.fields.chngwtcd
        dao.fields.LOCATION_ADDRESS_engthmblnm = dao_location_address.fields.engthmblnm
        dao.fields.LOCATION_ADDRESS_engamphrnm = dao_location_address.fields.engamphrnm
        dao.fields.LOCATION_ADDRESS_engchngwtnm = dao_location_address.fields.engchngwtnm
        dao.fields.LOCATION_ADDRESS_IDENTIFY = dao_location_address.fields.IDENTIFY
        dao.fields.LOCATION_ADDRESS_REMARK = dao_location_address.fields.REMARK

        Dim bsn_den As String = ""
        Try
            'Dim dao_h_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            'dao_h_bsn.GetDataby_LCN_IDA(_lcn_ida)
            'bsn_den = Trim(dao_h_bsn.fields.BSN_IDENTIFY)
            bsn_den = Trim(p2.dalcns.BSN_IDENTIFY)
        Catch ex As Exception

        End Try

        Dim dao_syslcnsnm2 As New DAO_CPN.clsDBsyslcnsnm
        dao_syslcnsnm2.GetDataby_identify(bsn_den)
        Try
            dao.fields.bsncd = dao_syslcnsnm2.fields.lcnsid
        Catch ex As Exception

        End Try
        Dim bao_show11 As New BAO_SHOW
        Dim dt_bsn As DataTable = bao_show11.SP_LOCATION_BSN_BY_IDENTIFY(bsn_den)
        For Each dr As DataRow In dt_bsn.Rows
            Try
                dao.fields.BSN_THAIFULLNAME = dr("BSN_THAIFULLNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_IDENTIFY = dr("BSN_IDENTIFY")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ADDR = dr("BSN_ADDR")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_SOI = dr("BSN_SOI")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ROAD = dr("BSN_ROAD")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_MOO = dr("BSN_MOO")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_THMBL_NAME = dr("BSN_THMBL_NAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_AMPHR_NAME = dr("BSN_AMPHR_NAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_CHWNGNAME = dr("BSN_CHWNGNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_TELEPHONE = dr("BSN_TELEPHONE")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_FAX = dr("BSN_FAX")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_THAINAME = dr("BSN_THAINAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_THAILASTNAME = dr("BSN_THAILASTNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_PREFIXENGCD = dr("BSN_PREFIXENGCD")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGNAME = dr("BSN_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGLASTNAME = dr("BSN_ENGLASTNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGFULLNAME = dr("BSN_ENGFULLNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.CHANGWAT_ID = dr("CHANGWAT_ID")
            Catch ex As Exception

            End Try
            Try
                dao.fields.AMPHR_ID = dr("AMPHR_ID")
            Catch ex As Exception

            End Try
            Try
                dao.fields.TUMBON_ID = dr("TUMBON_ID")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_FLOOR = dr("BSN_FLOOR")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_BUILDING = dr("BSN_BUILDING")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ZIPCODE = dr("BSN_ZIPCODE")
            Catch ex As Exception

            End Try
            Try
                dao.fields.CREATE_DATE = dr("CREATE_DATE")
            Catch ex As Exception

            End Try
            Try
                dao.fields.DOWN_ID = dr("DOWN_ID")
            Catch ex As Exception

            End Try
            Try
                dao.fields.CITIZEN_ID = dr("CITIZEN_ID")
            Catch ex As Exception

            End Try
            Try
                dao.fields.XMLNAME = dr("XMLNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.NATIONALITY = dr("NATIONALITY")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_HOUSENO = dr("BSN_HOUSENO")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGADDR = dr("BSN_ENGADDR")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGMU = dr("BSN_ENGMU")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGSOI = dr("BSN_ENGSOI")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_ENGROAD = dr("BSN_ENGROAD")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_CHWNG_ENGNAME = dr("BSN_CHWNG_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_AMPHR_ENGNAME = dr("BSN_AMPHR_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_THMBL_ENGNAME = dr("BSN_THMBL_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao.fields.BSN_NATIONALITY_CD = dr("BSN_NATIONALITY_CD")
            Catch ex As Exception

            End Try
            Try
                dao.fields.AGE = dr("AGE")
            Catch ex As Exception

            End Try
        Next
        dao.insert()

        Dim IDA_NEW As Integer = 0
        Try
            IDA_NEW = dao.fields.IDA
        Catch ex As Exception

        End Try

        For Each dr As DataRow In dt_bsn.Rows
            Dim dao_bsn As New DAO_DRUG.TB_DALCN_LOCATION_BSN
            Try
                dao_bsn.fields.BSN_THAIFULLNAME = dr("BSN_THAIFULLNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_IDENTIFY = dr("BSN_IDENTIFY")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ADDR = dr("BSN_ADDR")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_SOI = dr("BSN_SOI")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ROAD = dr("BSN_ROAD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_MOO = dr("BSN_MOO")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THMBL_NAME = dr("BSN_THMBL_NAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_AMPHR_NAME = dr("BSN_AMPHR_NAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_CHWNGNAME = dr("BSN_CHWNGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_TELEPHONE = dr("BSN_TELEPHONE")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_FAX = dr("BSN_FAX")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THAINAME = dr("BSN_THAINAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THAILASTNAME = dr("BSN_THAILASTNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_PREFIXENGCD = dr("BSN_PREFIXENGCD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGNAME = dr("BSN_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGLASTNAME = dr("BSN_ENGLASTNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGFULLNAME = dr("BSN_ENGFULLNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.CHANGWAT_ID = dr("CHANGWAT_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.AMPHR_ID = dr("AMPHR_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.TUMBON_ID = dr("TUMBON_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_FLOOR = dr("BSN_FLOOR")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_BUILDING = dr("BSN_BUILDING")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ZIPCODE = dr("BSN_ZIPCODE")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.CREATE_DATE = dr("CREATE_DATE")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.DOWN_ID = dr("DOWN_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.CITIZEN_ID = dr("CITIZEN_ID")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.XMLNAME = dr("XMLNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.NATIONALITY = dr("NATIONALITY")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_HOUSENO = dr("BSN_HOUSENO")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGADDR = dr("BSN_ENGADDR")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGMU = dr("BSN_ENGMU")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGSOI = dr("BSN_ENGSOI")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_ENGROAD = dr("BSN_ENGROAD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_CHWNG_ENGNAME = dr("BSN_CHWNG_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_AMPHR_ENGNAME = dr("BSN_AMPHR_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_THMBL_ENGNAME = dr("BSN_THMBL_ENGNAME")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.BSN_NATIONALITY_CD = dr("BSN_NATIONALITY_CD")
            Catch ex As Exception

            End Try
            Try
                dao_bsn.fields.AGE = dr("AGE")
            Catch ex As Exception

            End Try
            dao_bsn.fields.LCN_IDA = IDA_NEW
            dao_bsn.fields.FK_IDA = dao.fields.FK_IDA
            dao_bsn.insert()
        Next

        'Dim dao_location_bsn As New DAO_CPN.TB_LOCATION_BSN
        'dao_location_bsn.Getdata_by_fk_id2(dao_location_address.fields.IDA)
        'dao.fields.BSN_THAIFULLNAME = dao_location_bsn.fields.BSN_THAIFULLNAME
        'dao.fields.BSN_IDENTIFY = dao_location_bsn.fields.BSN_IDENTIFY
        'dao.fields.BSN_ADDR = dao_location_bsn.fields.BSN_ADDR
        'dao.fields.BSN_SOI = dao_location_bsn.fields.BSN_SOI
        'dao.fields.BSN_ROAD = dao_location_bsn.fields.BSN_ROAD
        'dao.fields.BSN_MOO = dao_location_bsn.fields.BSN_MOO
        'dao.fields.BSN_THMBL_NAME = dao_location_bsn.fields.BSN_THMBL_NAME
        'dao.fields.BSN_AMPHR_NAME = dao_location_bsn.fields.BSN_AMPHR_NAME
        'dao.fields.BSN_CHWNGNAME = dao_location_bsn.fields.BSN_CHWNGNAME
        'dao.fields.BSN_TELEPHONE = dao_location_bsn.fields.BSN_TELEPHONE
        'dao.fields.BSN_FAX = dao_location_bsn.fields.BSN_FAX
        'dao.fields.BSN_THAINAME = dao_location_bsn.fields.BSN_THAINAME
        'dao.fields.BSN_THAILASTNAME = dao_location_bsn.fields.BSN_THAILASTNAME
        'dao.fields.BSN_PREFIXENGCD = dao_location_bsn.fields.BSN_PREFIXENGCD
        'dao.fields.BSN_ENGNAME = dao_location_bsn.fields.BSN_ENGNAME
        'dao.fields.BSN_ENGLASTNAME = dao_location_bsn.fields.BSN_ENGLASTNAME
        'dao.fields.BSN_ENGFULLNAME = dao_location_bsn.fields.BSN_ENGFULLNAME
        'dao.fields.CHANGWAT_ID = dao_location_bsn.fields.CHANGWAT_ID
        'dao.fields.AMPHR_ID = dao_location_bsn.fields.AMPHR_ID
        'dao.fields.TUMBON_ID = dao_location_bsn.fields.TUMBON_ID
        'dao.fields.BSN_FLOOR = dao_location_bsn.fields.BSN_FLOOR
        'dao.fields.BSN_BUILDING = dao_location_bsn.fields.BSN_BUILDING
        'dao.fields.BSN_ZIPCODE = dao_location_bsn.fields.BSN_ZIPCODE
        'dao.fields.CREATE_DATE = dao_location_bsn.fields.CREATE_DATE
        'dao.fields.DOWN_ID = dao_location_bsn.fields.DOWN_ID
        'dao.fields.CITIZEN_ID = dao_location_bsn.fields.CITIZEN_ID
        'dao.fields.XMLNAME = dao_location_bsn.fields.XMLNAME
        'dao.fields.NATIONALITY = dao_location_bsn.fields.NATIONALITY
        'dao.fields.BSN_HOUSENO = dao_location_bsn.fields.BSN_HOUSENO
        'dao.fields.BSN_ENGADDR = dao_location_bsn.fields.BSN_ENGADDR
        'dao.fields.BSN_ENGMU = dao_location_bsn.fields.BSN_ENGMU
        'dao.fields.BSN_ENGSOI = dao_location_bsn.fields.BSN_ENGSOI
        'dao.fields.BSN_ENGROAD = dao_location_bsn.fields.BSN_ENGROAD
        'dao.fields.BSN_CHWNG_ENGNAME = dao_location_bsn.fields.BSN_CHWNG_ENGNAME
        'dao.fields.BSN_AMPHR_ENGNAME = dao_location_bsn.fields.BSN_AMPHR_ENGNAME
        'dao.fields.BSN_THMBL_ENGNAME = dao_location_bsn.fields.BSN_THMBL_ENGNAME
        'dao.fields.BSN_NATIONALITY_CD = dao_location_bsn.fields.BSN_NATIONALITY_CD.ToString()





        ' dao.fields.xmlnm = "DA-" & _ProcessID & "-" & con_year(Date.Now.Year.ToString()) & "-" & TR_ID
        ' dao.fields.regntfno = run_regntfno() 'ปรับไปรันตอน ยืนยัน
        'dao.insert()



        'Dim dao_dakeplctnm As New DAO_DRUG.ClsDBdakeplctnm
        'For Each dao_dakeplctnm.fields In p2.dakeplctnms
        '    dao_dakeplctnm.fields.TR_ID = TR_ID
        '    dao_dakeplctnm.fields.FK_IDA = dao.fields.IDA
        '    dao_dakeplctnm.insert()
        '    dao_dakeplctnm = New DAO_DRUG.ClsDBdakeplctnm
        'Next

        'Dim dao_dalcnctg As New DAO_DRUG.ClsDBdalcnctg
        'For Each dao_dalcnctg.fields In p2.dalcnctgs
        '    dao_dalcnctg.fields.TR_ID = TR_ID
        '    dao_dalcnctg.fields.FK_IDA = dao.fields.IDA
        '    dao_dalcnctg.insert()
        '    dao_dalcnctg = New DAO_DRUG.ClsDBdalcnctg
        'Next

        'Dim dao_dacnphdtl As New DAO_DRUG.ClsDBdacnphdtl
        'For Each dao_dacnphdtl.fields In p2.dacnphdtls
        '    dao_dacnphdtl.fields.TR_ID = TR_ID
        '    dao_dacnphdtl.fields.FK_IDA = dao.fields.IDA
        '    dao_dacnphdtl.insert()
        '    dao_dacnphdtl = New DAO_DRUG.ClsDBdacnphdtl
        'Next

        'Dim dao_dacncphr As New DAO_DRUG.ClsDBdacncphr
        'dao_dacncphr.Details = p2.dacncphrs
        'For Each dao_dacncphr.fields In dao_dacncphr.Details
        '    dao_dacncphr.fields.TR_ID = TR_ID
        '    dao_dacncphr.fields.FK_IDA = dao.fields.IDA
        '    dao_dacncphr.insert()
        '    dao_dacncphr = New DAO_DRUG.ClsDBdacncphr
        'Next

        'Dim dao_dalcnkep As New DAO_DRUG.ClsDBdalcnkep
        'For Each dao_dalcnkep.fields In p2.dalcnkeps
        '    dao_dalcnkep.fields.TR_ID = TR_ID
        '    dao_dalcnkep.fields.FK_IDA = dao.fields.IDA
        '    dao_dalcnkep.insert()
        '    dao_dalcnkep = New DAO_DRUG.ClsDBdalcnkep
        'Next

        Dim dao_DALCN_WORKTIME As New DAO_DRUG.ClsDBDALCN_WORKTIME
        For Each dao_DALCN_WORKTIME.fields In p2.DALCN_WORKTIMEs
            dao_DALCN_WORKTIME.fields.TR_ID = TR_ID
            dao_DALCN_WORKTIME.fields.FR_IDA = dao.fields.IDA
            dao_DALCN_WORKTIME.insert()
            dao_DALCN_WORKTIME = New DAO_DRUG.ClsDBDALCN_WORKTIME
        Next

        Dim dao_DALCN_KEP As New DAO_DRUG.ClsDBDALCN_KEP
        For Each dao_DALCN_KEP.fields In p2.DALCN_KEPs
            dao_DALCN_KEP.fields.TR_ID = TR_ID
            dao_DALCN_KEP.fields.FK_IDA = dao.fields.IDA
            dao_DALCN_KEP.insert()
            dao_DALCN_KEP = New DAO_DRUG.ClsDBDALCN_KEP
        Next

        'Dim dao_sysplace As New DAO_DRUG.ClsDBsysplace
        'For Each dao_sysplace.fields In p2.sysplaces
        '    dao_sysplace.fields.TR_ID = TR_ID
        '    dao_sysplace.fields.FK_IDA = dao.fields.IDA
        '    dao_sysplace.insert()
        '    dao_sysplace = New DAO_DRUG.ClsDBsysplace
        'Next

        'Dim dao_dalcnaddr As New DAO_DRUG.ClsDBdalcnaddr
        'For Each dao_dalcnaddr.fields In p2.dalcnaddrs
        '    dao_dalcnaddr.fields.TR_ID = TR_ID
        '    dao_dalcnaddr.fields.FK_IDA = dao.fields.IDA
        '    dao_dalcnaddr.insert()
        '    dao_dalcnaddr = New DAO_DRUG.ClsDBdalcnaddr
        'Next


        'For Each dao_DALCN_DETAIL_LOCATION_KEEP.fields In p2.DALCN_DETAIL_LOCATION_KEEPs
        'Dim LOCATION_IDA As Integer
        'If Integer.TryParse(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_IDA, LOCATION_IDA) = True Then

        Dim dao_ As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        dao_.GetData_by_LCN_IDA(_lcn_ida)
        Dim iii As Integer = 0
        For Each dao_.fields In dao_.datas
            iii += 1
            Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Branch = dao_.fields.LOCATION_ADDRESS_Branch
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_chngwtcd = dao_.fields.LOCATION_ADDRESS_chngwtcd
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID = dao_.fields.LOCATION_ADDRESS_CITIZEN_ID
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID_UPLOAD = dao_.fields.LOCATION_ADDRESS_CITIZEN_ID_UPLOAD
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_DOWN_ID = dao_.fields.LOCATION_ADDRESS_DOWN_ID
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engaddr = dao_.fields.LOCATION_ADDRESS_engaddr
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engamphrnm = dao_.fields.LOCATION_ADDRESS_engamphrnm
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engbuilding = dao_.fields.LOCATION_ADDRESS_engbuilding
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engchngwtnm = dao_.fields.LOCATION_ADDRESS_engchngwtnm
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engfloor = dao_.fields.LOCATION_ADDRESS_engfloor
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engmu = dao_.fields.LOCATION_ADDRESS_engmu
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engnameplace = dao_.fields.LOCATION_ADDRESS_engnameplace
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engroad = dao_.fields.LOCATION_ADDRESS_engroad
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engsoi = dao_.fields.LOCATION_ADDRESS_engsoi
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engthmblnm = dao_.fields.LOCATION_ADDRESS_engthmblnm
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = dao_.fields.LOCATION_ADDRESS_fax
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_FK_IDA = dao_.fields.LOCATION_ADDRESS_FK_IDA
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_HOUSENO = dao_.fields.LOCATION_ADDRESS_HOUSENO
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_IDA = dao_.fields.LOCATION_ADDRESS_IDA
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_IDENTIFY = dao_.fields.LOCATION_ADDRESS_IDENTIFY
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lcnsid = dao_.fields.LOCATION_ADDRESS_lcnsid
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lctcd = dao_.fields.LOCATION_ADDRESS_lctcd
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lmdfdate = dao_.fields.LOCATION_ADDRESS_lmdfdate
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_ID = dao_.fields.LOCATION_ADDRESS_LOCATION_TYPE_ID
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_NORMAL = dao_.fields.LOCATION_ADDRESS_LOCATION_TYPE_NORMAL
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_OTHER = dao_.fields.LOCATION_ADDRESS_LOCATION_TYPE_OTHER
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lstfcd = dao_.fields.LOCATION_ADDRESS_lstfcd
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_rcvdate = dao_.fields.LOCATION_ADDRESS_rcvdate
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_rcvno = dao_.fields.LOCATION_ADDRESS_rcvno
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_REMARK = dao_.fields.LOCATION_ADDRESS_REMARK
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_STATUS_ID = dao_.fields.LOCATION_ADDRESS_STATUS_ID
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_SYSTEM_NAME = dao_.fields.LOCATION_ADDRESS_SYSTEM_NAME
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = dao_.fields.LOCATION_ADDRESS_tel
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = dao_.fields.LOCATION_ADDRESS_thaaddr
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaamphrnm = dao_.fields.LOCATION_ADDRESS_thaamphrnm
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thabuilding = dao_.fields.LOCATION_ADDRESS_thabuilding
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = dao_.fields.LOCATION_ADDRESS_thachngwtnm
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thafloor = dao_.fields.LOCATION_ADDRESS_thafloor
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = dao_.fields.LOCATION_ADDRESS_thamu
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thanameplace = dao_.fields.LOCATION_ADDRESS_thanameplace
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = dao_.fields.LOCATION_ADDRESS_tharoad
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoom = dao_.fields.LOCATION_ADDRESS_tharoom
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = dao_.fields.LOCATION_ADDRESS_thasoi
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_.fields.LOCATION_ADDRESS_thathmblnm
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_TR_ID = dao_.fields.LOCATION_ADDRESS_TR_ID
            Catch ex As Exception

            End Try

            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_XMLNAME = dao_.fields.LOCATION_ADDRESS_XMLNAME
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_zipcode = dao_.fields.LOCATION_ADDRESS_zipcode
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.TR_ID = TR_ID
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.FK_IDA = dao.fields.IDA
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LCN_IDA = dao.fields.IDA
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
            Catch ex As Exception

            End Try
            Try
                dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_IDA = _lct_ida
            Catch ex As Exception

            End Try

            dao_DALCN_DETAIL_LOCATION_KEEP.insert()
            dao_DALCN_DETAIL_LOCATION_KEEP = New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
        Next

        'End If
        'Next
        If iii = 0 Then
            Dim dao_DALCN_DETAIL_LOCATION_KEEP As New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
            For Each dao_DALCN_DETAIL_LOCATION_KEEP.fields In p2.DALCN_DETAIL_LOCATION_KEEPs
                Dim LOCATION_IDA As Integer
                If Integer.TryParse(dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_IDA, LOCATION_IDA) = True Then
                    Dim dao_LOCATION_ADDRESS_2 As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
                    dao_LOCATION_ADDRESS_2.GetDataby_IDA(LOCATION_IDA)
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Branch = dao_LOCATION_ADDRESS_2.fields.Branch
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_chngwtcd = dao_LOCATION_ADDRESS_2.fields.chngwtcd
                    Catch ex As Exception

                    End Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID = _CLS.CITIZEN_ID

                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.TR_ID = TR_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.FK_IDA = dao.fields.IDA
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LCN_IDA = dao.fields.IDA
                    Catch ex As Exception

                    End Try

                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thanameplace
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = dao_LOCATION_ADDRESS_2.fields.thaaddr
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = dao_LOCATION_ADDRESS_2.fields.thasoi
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = dao_LOCATION_ADDRESS_2.fields.tharoad
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = dao_LOCATION_ADDRESS_2.fields.thamu
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thathmblnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaamphrnm = dao_LOCATION_ADDRESS_2.fields.thaamphrnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = dao_LOCATION_ADDRESS_2.fields.thachngwtnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = dao_LOCATION_ADDRESS_2.fields.tel
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = dao_LOCATION_ADDRESS_2.fields.fax
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thanameplace = dao_LOCATION_ADDRESS_2.fields.thanameplace
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaaddr = dao_LOCATION_ADDRESS_2.fields.thaaddr
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thasoi = dao_LOCATION_ADDRESS_2.fields.thasoi
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoad = dao_LOCATION_ADDRESS_2.fields.tharoad
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thamu = dao_LOCATION_ADDRESS_2.fields.thamu
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thathmblnm = dao_LOCATION_ADDRESS_2.fields.thathmblnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thaamphrnm = dao_LOCATION_ADDRESS_2.fields.thaamphrnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thachngwtnm = dao_LOCATION_ADDRESS_2.fields.thachngwtnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tel = dao_LOCATION_ADDRESS_2.fields.tel
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_fax = dao_LOCATION_ADDRESS_2.fields.fax
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lcnsid = dao_LOCATION_ADDRESS_2.fields.lcnsid
                    Catch ex As Exception

                    End Try

                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engaddr = dao_LOCATION_ADDRESS_2.fields.engaddr
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_tharoom = dao_LOCATION_ADDRESS_2.fields.tharoom
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thabuilding = dao_LOCATION_ADDRESS_2.fields.thabuilding
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engsoi = dao_LOCATION_ADDRESS_2.fields.engsoi
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engroad = dao_LOCATION_ADDRESS_2.fields.engroad
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_zipcode = dao_LOCATION_ADDRESS_2.fields.zipcode
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lstfcd = dao_LOCATION_ADDRESS_2.fields.lstfcd
                    Catch ex As Exception

                    End Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lmdfdate = dao_LOCATION_ADDRESS_2.fields.lmdfdate
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_IDA = dao_LOCATION_ADDRESS_2.fields.IDA
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_FK_IDA = dao_LOCATION_ADDRESS_2.fields.FK_IDA
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_TR_ID = dao_LOCATION_ADDRESS_2.fields.TR_ID
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_DOWN_ID = dao_LOCATION_ADDRESS_2.fields.DOWN_ID
                    Catch ex As Exception

                    End Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID = dao_LOCATION_ADDRESS_2.fields.CITIZEN_ID
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_CITIZEN_ID_UPLOAD = dao_LOCATION_ADDRESS_2.fields.CITIZEN_ID_UPLOAD
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_XMLNAME = dao_LOCATION_ADDRESS_2.fields.XMLNAME
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engmu = dao_LOCATION_ADDRESS_2.fields.engmu
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engfloor = dao_LOCATION_ADDRESS_2.fields.engfloor
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engbuilding = dao_LOCATION_ADDRESS_2.fields.engbuilding
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_rcvno = dao_LOCATION_ADDRESS_2.fields.rcvno
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_rcvdate = dao_LOCATION_ADDRESS_2.fields.rcvdate
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_lctcd = dao_LOCATION_ADDRESS_2.fields.lctcd
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_STATUS_ID = dao_LOCATION_ADDRESS_2.fields.STATUS_ID
                    Catch ex As Exception

                    End Try


                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engnameplace = dao_LOCATION_ADDRESS_2.fields.engnameplace

                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_HOUSENO = dao_LOCATION_ADDRESS_2.fields.HOUSENO
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Branch = dao_LOCATION_ADDRESS_2.fields.Branch
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_NORMAL = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_NORMAL
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_OTHER = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_OTHER
                    Catch ex As Exception

                    End Try

                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_LOCATION_TYPE_ID = dao_LOCATION_ADDRESS_2.fields.LOCATION_TYPE_ID
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_thmblcd = dao_LOCATION_ADDRESS_2.fields.thmblcd

                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_chngwtcd = dao_LOCATION_ADDRESS_2.fields.chngwtcd
                    Catch ex As Exception

                    End Try
                    Try
                        dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_amphrcd = dao_LOCATION_ADDRESS_2.fields.amphrcd
                    Catch ex As Exception

                    End Try
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_SYSTEM_NAME = dao_LOCATION_ADDRESS_2.fields.SYSTEM_NAME
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engthmblnm = dao_LOCATION_ADDRESS_2.fields.engthmblnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engamphrnm = dao_LOCATION_ADDRESS_2.fields.engamphrnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_engchngwtnm = dao_LOCATION_ADDRESS_2.fields.engchngwtnm
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_IDENTIFY = dao_LOCATION_ADDRESS_2.fields.IDENTIFY
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_REMARK = dao_LOCATION_ADDRESS_2.fields.REMARK
                    dao_DALCN_DETAIL_LOCATION_KEEP.fields.LOCATION_ADDRESS_Mobile = dao_LOCATION_ADDRESS_2.fields.Mobile
                    dao_DALCN_DETAIL_LOCATION_KEEP.insert()
                    dao_DALCN_DETAIL_LOCATION_KEEP = New DAO_DRUG.TB_DALCN_DETAIL_LOCATION_KEEP
                End If
            Next
        End If

                'เภสัชกร
                'Dim dao_DALCN_PHR As New DAO_DRUG.ClsDBDALCN_PHR
                'dao_DALCN_PHR.Details = p2.DALCN_PHRs
                'For Each dao_DALCN_PHR.fields In p2.DALCN_PHRs 'dao_DALCN_PHR.Details
                '    If (dao_DALCN_PHR.fields.PHR_MEDICAL_TYPE = "1") Or (String.IsNullOrWhiteSpace(dao_DALCN_PHR.fields.PHR_MEDICAL_TYPE) = True) Then
                '        If String.IsNullOrWhiteSpace(dao_DALCN_PHR.fields.PHR_NAME) = False Then
                '            Dim dao_prefix As New DAO_CPN.TB_sysprefix
                '            Dim PHR_PREFIX_ID As String = ""
                '            Try
                '                PHR_PREFIX_ID = Trim(dao_DALCN_PHR.fields.PHR_PREFIX_ID)
                '            Catch ex As Exception

                '            End Try
                '            If PHR_PREFIX_ID <> "" Then
                '                dao_prefix.Getdata_byid(PHR_PREFIX_ID)
                '                dao_DALCN_PHR.fields.PHR_PREFIX_NAME = dao_prefix.fields.thanm
                '                dao_DALCN_PHR.fields.PHR_PREFIX_ID = PHR_PREFIX_ID
                '            Else
                '                dao_DALCN_PHR.fields.PHR_PREFIX_NAME = "นาย"
                '                dao_DALCN_PHR.fields.PHR_PREFIX_ID = "0"
                '            End If
                '            'If IsNothing(dao_DALCN_PHR.fields.PHR_PREFIX_ID) = False Then
                '            '    If Integer.TryParse(dao_DALCN_PHR.fields.PHR_PREFIX_ID, PHR_PREFIX_ID) = True Then
                '            '        dao_prefix.Getdata_byid(PHR_PREFIX_ID)
                '            '        dao_DALCN_PHR.fields.PHR_PREFIX_NAME = dao_prefix.fields.thanm
                '            '    End If

                '            'End If
                '            'Try
                '            '    dao_DALCN_PHR.fields.PHR_TEXT_NUM = dao_DALCN_PHR.fields.PHR_TEXT_NUM
                '            'Catch ex As Exception

                '            'End Try
                '            dao_DALCN_PHR.fields.TR_ID = TR_ID
                '            dao_DALCN_PHR.fields.FK_IDA = dao.fields.IDA
                '            dao_DALCN_PHR.fields.PHR_STATUS_UPLOAD = 1
                '            dao_DALCN_PHR.insert()
                '            dao_DALCN_PHR = New DAO_DRUG.ClsDBDALCN_PHR


        '        End If
        If _ProcessID = "123" Or _ProcessID = "124" Or _ProcessID = "125" Or _ProcessID = "126" Or _ProcessID = "127" Or _ProcessID = "128" Or _ProcessID = "129" _
           Or _ProcessID = "130" Or _ProcessID = "131" Or _ProcessID = "132" Or _ProcessID = "133" Or _ProcessID = "134" Or _ProcessID = "135" Or _ProcessID = "136" Then
            Dim dao_phrh As New DAO_DRUG.ClsDBDALCN_PHR
            dao_phrh.GetDataby_FK_IDA(_lcn_ida)

            For Each dao_phrh.fields In dao_phrh.datas
                Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
                With dao_phr.fields
                    .FK_IDA = IDA_NEW
                    .INACTIVE_DATE = dao_phrh.fields.INACTIVE_DATE
                    .IS_ACTIVE = dao_phrh.fields.IS_ACTIVE
                    .lcnno = dao_phrh.fields.lcnno
                    .lcntpcd = dao_phrh.fields.lcntpcd
                    .PERSONAL_TYPE = dao_phrh.fields.PERSONAL_TYPE
                    .PHR_CERTIFICATE_TRAINING = dao_phrh.fields.PHR_CERTIFICATE_TRAINING
                    .PHR_CHK_JOB = dao_phrh.fields.PHR_CHK_JOB
                    .PHR_CHK_NOT_WORK = dao_phrh.fields.PHR_CHK_NOT_WORK
                    .PHR_CHK_NUM = dao_phrh.fields.PHR_CHK_NUM
                    .PHR_CHK_WORK = dao_phrh.fields.PHR_CHK_WORK
                    .PHR_CTZNO = dao_phrh.fields.PHR_CTZNO
                    .PHR_JOB_TYPE = dao_phrh.fields.PHR_JOB_TYPE
                    .PHR_LAW_SECTION = dao_phrh.fields.PHR_LAW_SECTION
                    .PHR_LEVEL = dao_phrh.fields.PHR_LEVEL
                    .PHR_MEDICAL_TYPE = dao_phrh.fields.PHR_MEDICAL_TYPE
                    .PHR_NAME = dao_phrh.fields.PHR_NAME
                    .PHR_PREFIX_ID = dao_phrh.fields.PHR_PREFIX_ID
                    .PHR_PREFIX_NAME = dao_phrh.fields.PHR_PREFIX_NAME
                    .phr_status = dao_phrh.fields.phr_status
                    .PHR_STATUS_UPLOAD = dao_phrh.fields.PHR_STATUS_UPLOAD
                    .PHR_SURNAME = dao_phrh.fields.PHR_SURNAME
                    .PHR_TEXT_DAY = dao_phrh.fields.PHR_TEXT_DAY
                    .PHR_TEXT_EXP = dao_phrh.fields.PHR_TEXT_EXP
                    .PHR_TEXT_JOB = dao_phrh.fields.PHR_TEXT_JOB
                    .PHR_TEXT_MOUTH = dao_phrh.fields.PHR_TEXT_MOUTH
                    .PHR_TEXT_NUM = dao_phrh.fields.PHR_TEXT_NUM
                    .PHR_TEXT_WORK_OFFICE = dao_phrh.fields.PHR_TEXT_WORK_OFFICE
                    .PHR_TEXT_WORK_TIME = dao_phrh.fields.PHR_TEXT_WORK_TIME
                    .PHR_TEXT_YEAR = dao_phrh.fields.PHR_TEXT_YEAR
                    .PHR_VETERINARY_FIELD = dao_phrh.fields.PHR_VETERINARY_FIELD
                    .phrcd = dao_phrh.fields.phrcd
                    .phrid = dao_phrh.fields.phrid
                    .POSITION_IDA = dao_phrh.fields.POSITION_IDA
                    .POSITION_NAME = dao_phrh.fields.POSITION_NAME
                    .pvncd = dao_phrh.fields.pvncd
                    .TR_ID = dao_phrh.fields.TR_ID
                    .TRANSECTION_ID_UPLOAD = dao_phrh.fields.TRANSECTION_ID_UPLOAD
                End With

                dao_phr.insert()
            Next
        Else
            Dim dao_DALCN_PHR As New DAO_DRUG.ClsDBDALCN_PHR
            For Each dao_DALCN_PHR.fields In p2.DALCN_PHRs
                If (dao_DALCN_PHR.fields.PHR_MEDICAL_TYPE = "1") Or (String.IsNullOrWhiteSpace(dao_DALCN_PHR.fields.PHR_MEDICAL_TYPE) = True) Then
                    'Dim PHR_NAME As String = ""
                    'Try
                    '    PHR_NAME = dao_DALCN_PHR.fields.PHR_NAME
                    'Catch ex As Exception

                    'End Try

                    If String.IsNullOrWhiteSpace(dao_DALCN_PHR.fields.PHR_NAME) = False Then
                        Dim dao_prefix As New DAO_CPN.TB_sysprefix
                        Dim PHR_PREFIX_ID As String = ""
                        Try
                            PHR_PREFIX_ID = Trim(dao_DALCN_PHR.fields.PHR_PREFIX_ID)
                        Catch ex As Exception

                        End Try
                        If PHR_PREFIX_ID <> "" Then
                            dao_prefix.Getdata_byid(PHR_PREFIX_ID)
                            dao_DALCN_PHR.fields.PHR_PREFIX_NAME = dao_prefix.fields.thanm
                            dao_DALCN_PHR.fields.PHR_PREFIX_ID = PHR_PREFIX_ID
                        Else
                            dao_DALCN_PHR.fields.PHR_PREFIX_NAME = "นาย"
                            dao_DALCN_PHR.fields.PHR_PREFIX_ID = "0"
                        End If
                        'If IsNothing(dao_DALCN_PHR.fields.PHR_PREFIX_ID) = False Then
                        '    If Integer.TryParse(dao_DALCN_PHR.fields.PHR_PREFIX_ID, PHR_PREFIX_ID) = True Then
                        '        dao_prefix.Getdata_byid(PHR_PREFIX_ID)
                        '        dao_DALCN_PHR.fields.PHR_PREFIX_NAME = dao_prefix.fields.thanm
                        '    End If

                        'End If
                        Try
                            'dao_DALCN_PHR.fields.PHR_NAME = p2.DALCN_PHRs.phr
                        Catch ex As Exception

                        End Try
                        'dao_DALCN_PHR.fields.PHR_TEXT_WORK_TIME = opentime
                        dao_DALCN_PHR.fields.TR_ID = TR_ID
                        dao_DALCN_PHR.fields.FK_IDA = dao.fields.IDA
                        dao_DALCN_PHR.fields.PHR_STATUS_UPLOAD = 1
                        dao_DALCN_PHR.insert()
                        dao_DALCN_PHR = New DAO_DRUG.ClsDBDALCN_PHR


                    End If
                End If
            Next





            'If String.IsNullOrWhiteSpace(dao_DALCN_PHR.fields.PHR_IDA.ToString()) = False Then
            '    Dim dao_prefix As New DAO_CPN.TB_sysprefix

            '    Dim dao_DALCN_PHR_MAIN As New DAO_DRUG.ClsDBDALCN_PHR
            '    Try
            '        dao_DALCN_PHR_MAIN.GetDataby_IDA(dao_DALCN_PHR.fields.PHR_IDA)
            '    Catch ex As Exception

            '    End Try


            '    Dim PHR_PREFIX_ID As Integer = 0
            '    Try
            '        If Integer.TryParse(dao_DALCN_PHR_MAIN.fields.PHR_PREFIX_ID, PHR_PREFIX_ID) = True Then
            '            dao_prefix.Getdata_byid(PHR_PREFIX_ID)
            '            dao_DALCN_PHR.fields.PHR_PREFIX_NAME = dao_prefix.fields.thanm
            '        End If
            '    Catch ex As Exception

            '    End Try

            '    Try
            '        dao_DALCN_PHR.fields.TR_ID = TR_ID
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.FK_IDA = dao.fields.IDA
            '    Catch ex As Exception

            '    End Try

            '    dao_DALCN_PHR.fields.PHR_STATUS_UPLOAD = 1
            '    Try
            '        dao_DALCN_PHR.fields.TRANSECTION_ID_UPLOAD = TR_ID
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_CERTIFICATE_TRAINING = dao_DALCN_PHR_MAIN.fields.PHR_CERTIFICATE_TRAINING
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_CHK_JOB = dao_DALCN_PHR_MAIN.fields.PHR_CHK_JOB
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_CHK_NOT_WORK = dao_DALCN_PHR_MAIN.fields.PHR_CHK_NOT_WORK
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_CHK_NUM = dao_DALCN_PHR_MAIN.fields.PHR_CHK_NUM
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_CHK_WORK = dao_DALCN_PHR_MAIN.fields.PHR_CHK_WORK
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_CTZNO = dao_DALCN_PHR_MAIN.fields.PHR_CTZNO
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_JOB_TYPE = dao_DALCN_PHR_MAIN.fields.PHR_JOB_TYPE
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_LAW_SECTION = dao_DALCN_PHR_MAIN.fields.PHR_LAW_SECTION
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_LEVEL = dao_DALCN_PHR_MAIN.fields.PHR_LEVEL
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_MEDICAL_TYPE = dao_DALCN_PHR_MAIN.fields.PHR_MEDICAL_TYPE
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_NAME = dao_DALCN_PHR_MAIN.fields.PHR_NAME
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_PREFIX_ID = dao_DALCN_PHR_MAIN.fields.PHR_PREFIX_ID
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_PREFIX_NAME = dao_DALCN_PHR_MAIN.fields.PHR_PREFIX_NAME
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_SURNAME = dao_DALCN_PHR_MAIN.fields.PHR_SURNAME
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_TEXT_DAY = dao_DALCN_PHR_MAIN.fields.PHR_TEXT_DAY
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_TEXT_EXP = dao_DALCN_PHR_MAIN.fields.PHR_TEXT_EXP
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_TEXT_JOB = dao_DALCN_PHR_MAIN.fields.PHR_TEXT_JOB
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_TEXT_MOUTH = dao_DALCN_PHR_MAIN.fields.PHR_TEXT_MOUTH
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_TEXT_NUM = dao_DALCN_PHR_MAIN.fields.PHR_TEXT_NUM
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_TEXT_WORK_OFFICE = dao_DALCN_PHR_MAIN.fields.PHR_TEXT_WORK_OFFICE
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_TEXT_WORK_TIME = dao_DALCN_PHR_MAIN.fields.PHR_TEXT_WORK_TIME
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_TEXT_YEAR = dao_DALCN_PHR_MAIN.fields.PHR_TEXT_YEAR
            '    Catch ex As Exception

            '    End Try
            '    Try
            '        dao_DALCN_PHR.fields.PHR_VETERINARY_FIELD = dao_DALCN_PHR_MAIN.fields.PHR_VETERINARY_FIELD
            '    Catch ex As Exception

            '    End Try

            '    dao_DALCN_PHR.insert()
            '    dao_DALCN_PHR = New DAO_DRUG.ClsDBDALCN_PHR


            'End If
            '    End If
            'Next

            Dim dao_DALCN_PHR_2 As New DAO_DRUG.ClsDBDALCN_PHR
            dao_DALCN_PHR_2.Details = p2.DALCN_PHR_2s
            For Each dao_DALCN_PHR_2.fields In p2.DALCN_PHR_2s
                If dao_DALCN_PHR_2.fields.PHR_MEDICAL_TYPE = "2" Then
                    If String.IsNullOrWhiteSpace(dao_DALCN_PHR_2.fields.PHR_NAME) = False Then
                        Dim dao_prefix As New DAO_CPN.TB_sysprefix
                        Dim PHR_PREFIX_ID As String = ""
                        Try
                            PHR_PREFIX_ID = Trim(dao_DALCN_PHR.fields.PHR_PREFIX_ID)
                        Catch ex As Exception

                        End Try
                        If PHR_PREFIX_ID <> "" Then
                            dao_prefix.Getdata_byid(PHR_PREFIX_ID)
                            dao_DALCN_PHR_2.fields.PHR_PREFIX_NAME = dao_prefix.fields.thanm
                            dao_DALCN_PHR_2.fields.PHR_PREFIX_ID = PHR_PREFIX_ID
                        Else
                            dao_DALCN_PHR_2.fields.PHR_PREFIX_NAME = "นาย"
                            dao_DALCN_PHR_2.fields.PHR_PREFIX_ID = "0"
                        End If
                        'dao_DALCN_PHR_2.fields.PHR_TEXT_WORK_TIME = opentime
                        dao_DALCN_PHR_2.fields.TR_ID = TR_ID
                        dao_DALCN_PHR_2.fields.FK_IDA = dao.fields.IDA
                        dao_DALCN_PHR_2.fields.PHR_STATUS_UPLOAD = 1
                        'dao_DALCN_PHR_2.fields.PHR_TEXT_WORK_TIME =
                        dao_DALCN_PHR_2.insert()
                        dao_DALCN_PHR_2 = New DAO_DRUG.ClsDBDALCN_PHR
                        'Try
                        '    dao_DALCN_PHR_2.fields.TR_ID = TR_ID
                        'Catch ex As Exception

                        'End Try
                        'Try
                        '    dao_DALCN_PHR_2.fields.FK_IDA = dao.fields.IDA
                        'Catch ex As Exception

                        'End Try
                        'Try
                        '    dao_DALCN_PHR_2.fields.PHR_STATUS_UPLOAD = 1
                        'Catch ex As Exception

                        'End Try


                        'dao_DALCN_PHR_2.insert()
                        'dao_DALCN_PHR_2 = New DAO_DRUG.ClsDBDALCN_PHR
                    End If
                End If
            Next
        End If
                

                'If dao.fields.lcntypecd = 12 Then 'จะบันทึกเพราะนำเข้าเท่านั้น
                '    Dim dao_fregntffrgn As New DAO.clsDBfregntffrgn
                '    For Each dao_fregntffrgn.fields In p2.fregntffrgn
                '        dao_fregntffrgn.fields.FR_IDA = dao.fields.ID
                '        dao_fregntffrgn.fields.TR_ID = TR_ID
                '        dao_fregntffrgn.insert()
                '        dao_fregntffrgn = New DAO.clsDBfregntffrgn
                '    Next
                'End If




                Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                dao_up.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
                dao_up.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                dao_up.fields.DOWNLOAD_ID = p2.DOWNLOAD_ID
                dao_up.fields.PROCESS_ID = _ProcessID
                dao_up.fields.UPLOAD_DATE = Date.Now
                dao_up.fields.YEAR = Date.Now.Year
                dao_up.fields.REF_NO = dao.fields.IDA

                dao_up.insert()

                ' Catch ex As Exception
                'check = False
                ' End Try

                Return check
    End Function
    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub
End Class