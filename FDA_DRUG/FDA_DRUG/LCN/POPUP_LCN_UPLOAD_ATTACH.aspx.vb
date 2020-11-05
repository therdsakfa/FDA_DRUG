Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports iTextSharp.text.pdf
Imports System.Xml

Public Class POPUP_LCN_UPLOAD_ATTACH
    Inherits System.Web.UI.Page
    Private _type_id As String = ""
    Private _IDA As String = ""
    Private _ProcessID As Integer
    Private _pvncd As Integer
    Sub runQuery()
        _type_id = Request.QueryString("type_id")
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
        bao.RunAppSettings()
        _CLS = Session("CLS")
    End Sub
    Private _CLS As New CLS_SESSION
    Dim bao As New BAO.AppSettings

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

  
    Public Sub show_panel()
        If _type_id = "101" Then
            Panel101.Style.Add("display", "block")
        ElseIf _type_id = "102" Then
            Panel102.Style.Add("display", "block")
        ElseIf _type_id = "103" Then
            Panel103.Style.Add("display", "block")
        ElseIf _type_id = "104" Then
            Panel104.Style.Add("display", "block")
        ElseIf _type_id = "105" Then
            Panel105.Style.Add("display", "block")
        ElseIf _type_id = "106" Then
            Panel106.Style.Add("display", "block")
        ElseIf _type_id = "107" Or _type_id = "120" Then
            Panel107.Style.Add("display", "block")
        ElseIf _type_id = "108" Or _type_id = "121" Then
            Panel108.Style.Add("display", "block")
        ElseIf _type_id = "109" Or _type_id = "122" Then
            Panel109.Style.Add("display", "block")
        Else

        End If
    End Sub
    Public Sub set_txt_label()
        'ขย.1
        uc101_1.get_label("แบบคำขออนุญาต (ตามประเภท) เจ้าของคนใหม่")
        uc101_2.get_label("รูปถ่ายของผู้รับอนุญาต (เจ้าของคนใหม่/ผู้ขออนุญาต) ขนาด 3*4 ซม.(3 รูป) ถ่ายไม่เกิน 6 เดือน")
        'uc101_3.get_label("สำเนาทะเบียนบ้านรับรองจริง (เจ้าของคนใหม่)")
        uc101_4.get_label("สำเนาหนังสือขออนุญาตทำงานที่ออกโดยกระทรวงแรงงานฯและหนังสือเดินทาง (กรีบุคคลต่างด้าว)")
        'uc101_5.get_label("สำเนาบัตรประชาชนรับรองจริง (เจ้าของคนใหม่/ผู้ขออนุญาต)")
        uc101_6.get_label("ใบรับรองแพทย์ของผู้ขออนุญาต (ต้องไม่เกิน 1-3 เดือนแล้วแต่กรณี)")
        uc101_7.get_label("หลักทรัพย์(สำเนาสมุดบัญชีอัฟเดทล่าสุด) จำนวนเงินตั้งแต่ 10,000 บาทขึ้นไป")
        uc101_8.get_label("สำเนาโฉนดที่ดินที่ไม่ติดภาระผูกพัน(ชื่อผู้รับอนุญาตเท่านั้น)")

        'ขย.2
        uc102_1.get_label("แบบคำขออนุญาต (ตามประเภท) เจ้าของคนใหม่")
        uc102_2.get_label("รูปถ่ายของผู้รับอนุญาต (เจ้าของคนใหม่/ผู้ขออนุญาต) ขนาด 3*4 ซม.(3 รูป) ถ่ายไม่เกิน 6 เดือน")
        'uc102_3.get_label("สำเนาทะเบียนบ้านรับรองจริง (เจ้าของคนใหม่)")
        uc102_4.get_label("สำเนาหนังสือขออนุญาตทำงานที่ออกโดยกระทรวงแรงงานฯและหนังสือเดินทาง (กรีบุคคลต่างด้าว)")
        'uc102_5.get_label("สำเนาบัตรประชาชนรับรองจริง (เจ้าของคนใหม่/ผู้ขออนุญาต)")
        uc102_6.get_label("ใบรับรองแพทย์ของผู้ขออนุญาต (ต้องไม่เกิน 1-3 เดือนแล้วแต่กรณี)")
        uc102_7.get_label("หลักทรัพย์(สำเนาสมุดบัญชีอัฟเดทล่าสุด) จำนวนเงินตั้งแต่ 10,000 บาทขึ้นไป")
        uc102_8.get_label("สำเนาโฉนดที่ดินที่ไม่ติดภาระผูกพัน(ชื่อผู้รับอนุญาตเท่านั้น)")

        'ขย.3
        uc103_1.get_label("แบบคำขออนุญาต (ตามประเภท) เจ้าของคนใหม่")
        uc103_2.get_label("รูปถ่ายของผู้รับอนุญาต (เจ้าของคนใหม่/ผู้ขออนุญาต) ขนาด 3*4 ซม.(3 รูป) ถ่ายไม่เกิน 6 เดือน")
        'uc103_3.get_label("สำเนาทะเบียนบ้านรับรองจริง (เจ้าของคนใหม่)")
        uc103_4.get_label("สำเนาหนังสือขออนุญาตทำงานที่ออกโดยกระทรวงแรงงานฯและหนังสือเดินทาง (กรีบุคคลต่างด้าว)")
        'uc103_5.get_label("สำเนาบัตรประชาชนรับรองจริง (เจ้าของคนใหม่/ผู้ขออนุญาต)")
        uc103_6.get_label("ใบรับรองแพทย์ของผู้ขออนุญาต (ต้องไม่เกิน 1-3 เดือนแล้วแต่กรณี)")
        uc103_7.get_label("หลักทรัพย์(สำเนาสมุดบัญชีอัฟเดทล่าสุด) จำนวนเงินตั้งแต่ 10,000 บาทขึ้นไป")
        uc103_8.get_label("สำเนาโฉนดที่ดินที่ไม่ติดภาระผูกพัน(ชื่อผู้รับอนุญาตเท่านั้น)")

        'ขย.4
        uc104_1.get_label("แบบคำขออนุญาต (ตามประเภท) เจ้าของคนใหม่")
        uc104_2.get_label("รูปถ่ายของผู้รับอนุญาต (เจ้าของคนใหม่/ผู้ขออนุญาต) ขนาด 3*4 ซม.(3 รูป) ถ่ายไม่เกิน 6 เดือน")
        'uc104_3.get_label("สำเนาทะเบียนบ้านรับรองจริง (เจ้าของคนใหม่)")
        uc104_4.get_label("สำเนาหนังสือขออนุญาตทำงานที่ออกโดยกระทรวงแรงงานฯและหนังสือเดินทาง (กรีบุคคลต่างด้าว)")
        'uc104_5.get_label("สำเนาบัตรประชาชนรับรองจริง (เจ้าของคนใหม่/ผู้ขออนุญาต)")
        uc104_6.get_label("ใบรับรองแพทย์ของผู้ขออนุญาต (ต้องไม่เกิน 1-3 เดือนแล้วแต่กรณี)")
        uc104_7.get_label("หลักทรัพย์(สำเนาสมุดบัญชีอัฟเดทล่าสุด) จำนวนเงินตั้งแต่ 10,000 บาทขึ้นไป")
        uc104_8.get_label("สำเนาโฉนดที่ดินที่ไม่ติดภาระผูกพัน(ชื่อผู้รับอนุญาตเท่านั้น)")

        'นย.1
        uc105_1.get_label("แบบคำขออนุญาต (ตามประเภท) เจ้าของคนใหม่")
        uc105_2.get_label("รูปถ่ายของผู้รับอนุญาต (เจ้าของคนใหม่/ผู้ขออนุญาต) ขนาด 3*4 ซม.(3 รูป) ถ่ายไม่เกิน 6 เดือน")
        'uc105_3.get_label("สำเนาทะเบียนบ้านรับรองจริง (เจ้าของคนใหม่)")
        uc105_4.get_label("สำเนาหนังสือขออนุญาตทำงานที่ออกโดยกระทรวงแรงงานฯและหนังสือเดินทาง (กรีบุคคลต่างด้าว)")
        'uc105_5.get_label("สำเนาบัตรประชาชนรับรองจริง (เจ้าของคนใหม่/ผู้ขออนุญาต)")
        uc105_6.get_label("ใบรับรองแพทย์ของผู้ขออนุญาต (ต้องไม่เกิน 1-3 เดือนแล้วแต่กรณี)")
        uc105_7.get_label("หลักทรัพย์(สำเนาสมุดบัญชีอัฟเดทล่าสุด) จำนวนเงินตั้งแต่ 10,000 บาทขึ้นไป")
        uc105_8.get_label("สำเนาโฉนดที่ดินที่ไม่ติดภาระผูกพัน(ชื่อผู้รับอนุญาตเท่านั้น)")

        'ผย.1
        uc106_1.get_label("แบบคำขออนุญาต (ตามประเภท) เจ้าของคนใหม่")
        uc106_2.get_label("รูปถ่ายของผู้รับอนุญาต (เจ้าของคนใหม่/ผู้ขออนุญาต) ขนาด 3*4 ซม.(3 รูป) ถ่ายไม่เกิน 6 เดือน")
        'uc106_3.get_label("สำเนาทะเบียนบ้านรับรองจริง (เจ้าของคนใหม่)")
        uc106_4.get_label("สำเนาหนังสือขออนุญาตทำงานที่ออกโดยกระทรวงแรงงานฯและหนังสือเดินทาง (กรีบุคคลต่างด้าว)")
        'uc106_5.get_label("สำเนาบัตรประชาชนรับรองจริง (เจ้าของคนใหม่/ผู้ขออนุญาต)")
        uc106_6.get_label("ใบรับรองแพทย์ของผู้ขออนุญาต (ต้องไม่เกิน 1-3 เดือนแล้วแต่กรณี)")
        uc106_7.get_label("หลักทรัพย์(สำเนาสมุดบัญชีอัฟเดทล่าสุด) จำนวนเงินตั้งแต่ 10,000 บาทขึ้นไป")
        uc106_8.get_label("สำเนาโฉนดที่ดินที่ไม่ติดภาระผูกพัน(ชื่อผู้รับอนุญาตเท่านั้น)")

        'ขยบ.
        uc107_1.get_label("แบบคำขออนุญาต (ตามประเภท) เจ้าของคนใหม่")
        uc107_2.get_label("รูปถ่ายของผู้รับอนุญาต (เจ้าของคนใหม่/ผู้ขออนุญาต) ขนาด 3*4 ซม.(3 รูป) ถ่ายไม่เกิน 6 เดือน")
        'uc107_3.get_label("สำเนาทะเบียนบ้านรับรองจริง (เจ้าของคนใหม่)")
        uc107_4.get_label("สำเนาหนังสือขออนุญาตทำงานที่ออกโดยกระทรวงแรงงานฯและหนังสือเดินทาง (กรีบุคคลต่างด้าว)")
        'uc107_5.get_label("สำเนาบัตรประชาชนรับรองจริง (เจ้าของคนใหม่/ผู้ขออนุญาต)")
        uc107_6.get_label("ใบรับรองแพทย์ของผู้ขออนุญาต (ต้องไม่เกิน 1-3 เดือนแล้วแต่กรณี)")
        uc107_7.get_label("หลักทรัพย์(สำเนาสมุดบัญชีอัฟเดทล่าสุด) จำนวนเงินตั้งแต่ 10,000 บาทขึ้นไป")
        uc107_8.get_label("สำเนาโฉนดที่ดินที่ไม่ติดภาระผูกพัน(ชื่อผู้รับอนุญาตเท่านั้น)")

        'นยบ.
        uc108_1.get_label("แบบคำขออนุญาต (ตามประเภท) เจ้าของคนใหม่")
        uc108_2.get_label("รูปถ่ายของผู้รับอนุญาต (เจ้าของคนใหม่/ผู้ขออนุญาต) ขนาด 3*4 ซม.(3 รูป) ถ่ายไม่เกิน 6 เดือน")
        'uc108_3.get_label("สำเนาทะเบียนบ้านรับรองจริง (เจ้าของคนใหม่)")
        uc108_4.get_label("สำเนาหนังสือขออนุญาตทำงานที่ออกโดยกระทรวงแรงงานฯและหนังสือเดินทาง (กรีบุคคลต่างด้าว)")
        'uc108_5.get_label("สำเนาบัตรประชาชนรับรองจริง (เจ้าของคนใหม่/ผู้ขออนุญาต)")
        uc108_6.get_label("ใบรับรองแพทย์ของผู้ขออนุญาต (ต้องไม่เกิน 1-3 เดือนแล้วแต่กรณี)")
        uc108_7.get_label("หลักทรัพย์(สำเนาสมุดบัญชีอัฟเดทล่าสุด) จำนวนเงินตั้งแต่ 10,000 บาทขึ้นไป")
        uc108_8.get_label("สำเนาโฉนดที่ดินที่ไม่ติดภาระผูกพัน(ชื่อผู้รับอนุญาตเท่านั้น)")

        'ผยบ.
        uc109_1.get_label("แบบคำขออนุญาต (ตามประเภท) เจ้าของคนใหม่")
        uc109_2.get_label("รูปถ่ายของผู้รับอนุญาต (เจ้าของคนใหม่/ผู้ขออนุญาต) ขนาด 3*4 ซม.(3 รูป) ถ่ายไม่เกิน 6 เดือน")
        'uc109_3.get_label("สำเนาทะเบียนบ้านรับรองจริง (เจ้าของคนใหม่)")
        uc109_4.get_label("สำเนาหนังสือขออนุญาตทำงานที่ออกโดยกระทรวงแรงงานฯและหนังสือเดินทาง (กรีบุคคลต่างด้าว)")
        'uc109_5.get_label("สำเนาบัตรประชาชนรับรองจริง (เจ้าของคนใหม่/ผู้ขออนุญาต)")
        uc109_6.get_label("ใบรับรองแพทย์ของผู้ขออนุญาต (ต้องไม่เกิน 1-3 เดือนแล้วแต่กรณี)")
        uc109_7.get_label("หลักทรัพย์(สำเนาสมุดบัญชีอัฟเดทล่าสุด) จำนวนเงินตั้งแต่ 10,000 บาทขึ้นไป")
        uc109_8.get_label("สำเนาโฉนดที่ดินที่ไม่ติดภาระผูกพัน(ชื่อผู้รับอนุญาตเท่านั้น)")

    End Sub

    Public Sub SET_ATTACH(ByVal TR_ID As String, ByVal PROCESS_ID As String, ByVal YEAR As String)
        If _type_id = "101" Then
            'ขย.1
            uc101_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc101_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            'uc101_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc101_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            'uc101_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            uc101_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")
            uc101_7.ATTACH(TR_ID, PROCESS_ID, YEAR, "7")
            uc101_8.ATTACH(TR_ID, PROCESS_ID, YEAR, "8")
        ElseIf _type_id = "102" Then
            'ขย.2
            uc102_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc102_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            'uc102_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc102_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            'uc102_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            uc102_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")
            uc102_7.ATTACH(TR_ID, PROCESS_ID, YEAR, "7")
            uc102_8.ATTACH(TR_ID, PROCESS_ID, YEAR, "8")
        ElseIf _type_id = "103" Then
            'ขย.3
            uc103_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc103_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            'uc103_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc103_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            'uc103_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            uc103_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")
            uc103_7.ATTACH(TR_ID, PROCESS_ID, YEAR, "7")
            uc103_8.ATTACH(TR_ID, PROCESS_ID, YEAR, "8")
        ElseIf _type_id = "104" Then
            'ขย.4
            uc104_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc104_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            'uc104_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc104_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            'uc104_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            uc104_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")
            uc104_7.ATTACH(TR_ID, PROCESS_ID, YEAR, "7")
            uc104_8.ATTACH(TR_ID, PROCESS_ID, YEAR, "8")
        ElseIf _type_id = "105" Then
            'นย.1
            uc105_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc105_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            'uc105_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc105_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            'uc105_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            uc105_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")
            uc105_7.ATTACH(TR_ID, PROCESS_ID, YEAR, "7")
            uc105_8.ATTACH(TR_ID, PROCESS_ID, YEAR, "8")
        ElseIf _type_id = "106" Then
            'ผย.1
            uc106_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc106_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            'uc106_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc106_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            'uc106_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            uc106_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")
            uc106_7.ATTACH(TR_ID, PROCESS_ID, YEAR, "7")
            uc106_8.ATTACH(TR_ID, PROCESS_ID, YEAR, "8")
        ElseIf _type_id = "107" Or _type_id = "120" Then
            'ขยบ.
            uc107_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc107_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            'uc107_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc107_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            'uc107_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            uc107_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")
            uc107_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")
            uc107_7.ATTACH(TR_ID, PROCESS_ID, YEAR, "7")
            uc107_8.ATTACH(TR_ID, PROCESS_ID, YEAR, "8")
        ElseIf _type_id = "108" Or _type_id = "121" Then
            'นยบ.
            uc108_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc108_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            'uc108_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc108_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            'uc108_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            uc108_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")
            uc108_7.ATTACH(TR_ID, PROCESS_ID, YEAR, "7")
            uc108_8.ATTACH(TR_ID, PROCESS_ID, YEAR, "8")
        ElseIf _type_id = "109" Or _type_id = "122" Then

            'ผยบ.
            uc109_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
            uc109_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
            'uc109_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
            uc109_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
            'uc109_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            uc109_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")
            uc109_7.ATTACH(TR_ID, PROCESS_ID, YEAR, "7")
            uc109_8.ATTACH(TR_ID, PROCESS_ID, YEAR, "8")
        End If

    End Sub
    Sub upload_pdf()
        If FileUpload1.HasFile Then
            Dim file_ex As String = ""
            file_ex = file_extension_nm(FileUpload1.FileName)

            Dim bao As New BAO.AppSettings
            bao.RunAppSettings()


            Dim TR_ID As String = ""
            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
            bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

            TR_ID = bao_tran.insert_transection_new(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION



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
            ' Try
            check = insrt_to_database(XML_TRADER, TR_ID)
            If check = True Then
                SET_ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year))

                alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            Else

            End If



            'Catch ex As Exception

            '    alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
            'End Try

        End If
    End Sub
    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        upload_pdf()

        '' ทำการ Upload File Pdf  เพื่อทำการ Save PDF ลงไปในระบบ และทำการดึง XML ออกมาจาก PDF เพื่อเก็บไว้
        'If FileUpload1.HasFile Then
        '    Dim file_ex As String = ""
        '    file_ex = file_extension_nm(FileUpload1.FileName)

        '    Dim bao As New BAO.AppSettings
        '    bao.RunAppSettings()


        '    Dim TR_ID As String = ""
        '    Dim bao_tran As New BAO_TRANSECTION
        '    bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
        '    bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE

        '    TR_ID = bao_tran.insert_transection_new(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION



        '    'If UC_ATTACH1.ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year), "1") = False Then
        '    '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('กรุณาแนบไฟล์');", True)
        '    '    Exit Sub
        '    'End If

        '    Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        '    dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_ProcessID, 1, 0)

        '    Dim _path_temp As String = ""
        '    _path_temp = bao._PATH_DEFAULT & "XML_TRADER_TEMP\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)
        '    Dim result As String = chk_phr(TR_ID, _path_temp)
        '    '-------------------------------------------------
        '    'If result <> "" Then
        '    '    alert("ผู้ปฏิบัติการมีหน้าทีซ้ำซ้อนในใบอนุญาตดังนี้ \n" & result)
        '    'Else
        '    'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
        '    Dim PDF_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
        '    'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
        '    Dim XML_TRADER As String = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)


        '    FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"
        '    'ทำการแปลงส่ง PDF เข้าไปแล้วแปลงออกเป็น XML
        '    convert_PDF_To_XML(PDF_TRADER, XML_TRADER)


        '    '    convert_PDF_To_XML(bao._PATH_PDF_TRADER & "FA-5-2558-" & TR_ID & ".pdf", TR_ID) '"C:\path\PDF_TRADER\"
        '    Dim check As Boolean = True
        '    ' Try
        '    check = insrt_to_database(XML_TRADER, TR_ID)
        '    If check = True Then
        '        SET_ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year))

        '        alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
        '    Else

        '    End If
        '    '---------------------------------------------------
        '    'End If



        '    'Catch ex As Exception

        '    '    alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
        '    'End Try

        'End If

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
    ''' <summary>
    '''  ดึงค่า XML เข้าไปที่ DB
    ''' </summary>
    ''' <remarks></remarks>
    Private Function insrt_to_database(ByVal FileName As String, ByVal TR_ID As String) As Boolean
        Dim check As Boolean = True

        ' Try
        Dim objStreamReader As New StreamReader(FileName)
        Dim p2 As New CLASS_DALCN
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()


        Dim cernumber As String = ""

        Dim dao As New DAO_DRUG.ClsDBdalcn
        dao.fields = p2.dalcns

        dao.fields.IMAGE_BSN = p2.dalcns.IMAGE_BSN
        dao.fields.lcnsid = dao.fields.lcnsid
        dao.fields.PROCESS_ID = _ProcessID
        dao.fields.IDENTIFY = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        dao.fields.rcvdate = Date.Now
        dao.fields.lmdfdate = Date.Now
        dao.fields.STATUS_ID = 1
        dao.fields.TR_ID = TR_ID
        dao.fields.FK_IDA = _IDA
        dao.fields.CTZNO = _CLS.CITIZEN_ID
        dao.fields.lcntpcd = set_lcntpcd()
        dao.fields.CITIZEN_ID_UPLOAD = _CLS.CITIZEN_ID
        Try
            dao.fields.pvncd = _pvncd
        Catch ex As Exception

        End Try
        Try
            dao.fields.chngwtcd = _pvncd
        Catch ex As Exception

        End Try
        Dim chw As String = ""
        Dim dao_cpn As New DAO_CPN.clsDBsyschngwt
        Try
            dao_cpn.GetData_by_chngwtcd(_pvncd)
            chw = dao_cpn.fields.thacwabbr
        Catch ex As Exception

        End Try
        dao.fields.pvnabbr = chw

        If Request.QueryString("staff") <> "" Then
            dao.fields.OTHER = "1"
        End If
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


        Dim dao_location_address As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_location_address.GetDataby_IDA(_IDA)
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
        dao.fields.LOCATION_ADDRESS_thanameplace = dao_location_address.fields.thanameplace
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


        'Dim dao_location_bsn As New DAO_CPN.TB_LOCATION_BSN
        'dao_location_bsn.Getdata_by_fk_id2(dao_location_address.fields.IDA)
        Dim bsn_den As String = ""
        Try
            bsn_den = Trim(p2.BSN_IDENTIFY)
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
        'dao.fields.BSN_NATIONALITY_CD = dao_location_bsn.fields.BSN_NATIONALITY_CD

        Dim opentime As String = ""
        Dim dao_cn As New DAO_DRUG.ClsDBdalcn
        Try
            opentime = p2.dalcns.opentime
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
            dao_bsn.fields.LCN_IDA = dao.fields.IDA
            dao_bsn.fields.FK_IDA = dao.fields.FK_IDA
            dao_bsn.insert()
        Next

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
        'For Each dao_dacncphr.fields In p2.dacncphrs
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

        'Dim dao_DALCN_WORKTIME As New DAO_DRUG.ClsDBDALCN_WORKTIME
        'For Each dao_DALCN_WORKTIME.fields In p2.DALCN_WORKTIMEs
        '    dao_DALCN_WORKTIME.fields.TR_ID = TR_ID
        '    dao_DALCN_WORKTIME.fields.FR_IDA = dao.fields.IDA
        '    dao_DALCN_WORKTIME.insert()
        '    dao_DALCN_WORKTIME = New DAO_DRUG.ClsDBDALCN_WORKTIME
        'Next

        'Dim dao_DALCN_KEP As New DAO_DRUG.ClsDBDALCN_KEP
        'For Each dao_DALCN_KEP.fields In p2.DALCN_KEPs
        '    dao_DALCN_KEP.fields.TR_ID = TR_ID
        '    dao_DALCN_KEP.fields.FK_IDA = dao.fields.IDA
        '    dao_DALCN_KEP.insert()
        '    dao_DALCN_KEP = New DAO_DRUG.ClsDBDALCN_KEP
        'Next

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


        'เภสัชกร
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
                    'dao_DALCN_PHR.fields.PHR_JOB_TYPE =dao_DALCN_PHR.fields.
                    Try
                        'dao_DALCN_PHR.fields.PHR_NAME = p2.DALCN_PHRs.phr
                    Catch ex As Exception

                    End Try
                    dao_DALCN_PHR.fields.PHR_TEXT_WORK_TIME = opentime
                    dao_DALCN_PHR.fields.TR_ID = TR_ID
                    dao_DALCN_PHR.fields.FK_IDA = dao.fields.IDA
                    dao_DALCN_PHR.fields.PHR_STATUS_UPLOAD = 1
                    dao_DALCN_PHR.insert()
                    dao_DALCN_PHR = New DAO_DRUG.ClsDBDALCN_PHR


                End If
            End If
        Next

        Dim dao_DALCN_PHR_2 As New DAO_DRUG.ClsDBDALCN_PHR
        For Each dao_DALCN_PHR_2.fields In p2.DALCN_PHR_2s
            If dao_DALCN_PHR_2.fields.PHR_MEDICAL_TYPE = "2" Then
                If String.IsNullOrWhiteSpace(dao_DALCN_PHR_2.fields.PHR_NAME) = False Then
                    Dim dao_prefix As New DAO_CPN.TB_sysprefix
                    Dim PHR_PREFIX_ID As String = ""
                    Try
                        PHR_PREFIX_ID = Trim(dao_DALCN_PHR_2.fields.PHR_PREFIX_ID)
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
                    dao_DALCN_PHR_2.fields.PHR_TEXT_WORK_TIME = opentime
                    dao_DALCN_PHR_2.fields.TR_ID = TR_ID
                    dao_DALCN_PHR_2.fields.FK_IDA = dao.fields.IDA
                    dao_DALCN_PHR_2.fields.PHR_STATUS_UPLOAD = 1
                    'dao_DALCN_PHR_2.fields.PHR_TEXT_WORK_TIME =
                    dao_DALCN_PHR_2.insert()
                    dao_DALCN_PHR_2 = New DAO_DRUG.ClsDBDALCN_PHR
                End If
            End If
        Next

        Dim dao_DALCN_PHR_3 As New DAO_DRUG.ClsDBDALCN_PHR
        For Each dao_DALCN_PHR_3.fields In p2.DALCN_PHR_3s
            If dao_DALCN_PHR_3.fields.PHR_MEDICAL_TYPE = "2" Then
                If String.IsNullOrWhiteSpace(dao_DALCN_PHR_3.fields.PHR_NAME) = False Then
                    Dim dao_prefix As New DAO_CPN.TB_sysprefix
                    Dim PHR_PREFIX_ID As String = ""
                    Try
                        PHR_PREFIX_ID = Trim(dao_DALCN_PHR_3.fields.PHR_PREFIX_ID)
                    Catch ex As Exception

                    End Try
                    If PHR_PREFIX_ID <> "" Then
                        dao_prefix.Getdata_byid(PHR_PREFIX_ID)
                        dao_DALCN_PHR_3.fields.PHR_PREFIX_NAME = dao_prefix.fields.thanm
                        dao_DALCN_PHR_3.fields.PHR_PREFIX_ID = PHR_PREFIX_ID
                    Else
                        dao_DALCN_PHR_3.fields.PHR_PREFIX_NAME = "นาย"
                        dao_DALCN_PHR_3.fields.PHR_PREFIX_ID = "0"
                    End If
                    dao_DALCN_PHR_3.fields.PHR_TEXT_WORK_TIME = opentime
                    dao_DALCN_PHR_3.fields.TR_ID = TR_ID
                    dao_DALCN_PHR_3.fields.FK_IDA = dao.fields.IDA
                    dao_DALCN_PHR_3.fields.PHR_STATUS_UPLOAD = 1
                    dao_DALCN_PHR_3.fields.PHR_MEDICAL_TYPE = 3

                    'dao_DALCN_PHR_2.fields.PHR_TEXT_WORK_TIME =
                    dao_DALCN_PHR_3.insert()
                    dao_DALCN_PHR_3 = New DAO_DRUG.ClsDBDALCN_PHR
                End If
            End If
        Next


        'If dao.fields.lcntypecd = 12 Then 'จะบันทึกเพราะนำเข้าเท่านั้น
        '    Dim dao_fregntffrgn As New DAO.clsDBfregntffrgn
        '    For Each dao_fregntffrgn.fields In p2.fregntffrgn
        '        dao_fregntffrgn.fields.FR_IDA = dao.fields.ID
        '        dao_fregntffrgn.fields.TR_ID = TR_ID
        '        dao_fregntffrgn.insert()
        '        dao_fregntffrgn = New DAO.clsDBfregntffrgn
        '    Next
        'End If

        'Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        'dao_up.fields.CITIEZEN_ID = _CLS.CITIZEN_ID
        'dao_up.fields.CITIEZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
        'dao_up.fields.DOWNLOAD_ID = p2.DOWNLOAD_ID
        'dao_up.fields.PROCESS_ID = _ProcessID
        'dao_up.fields.UPLOAD_DATE = Date.Now
        'dao_up.fields.YEAR = Date.Now.Year
        'dao_up.fields.REF_NO = dao.fields.IDA

        'dao_up.insert()
        'End If
        'Catch ex As Exception
        '    check = False
        'End Try

        Return check
    End Function
    Function chk_phr(ByVal TR_ID As String, ByVal _path As String) As String
        Dim result As String = ""
        Dim PDF_TRADER As String = _path & "PDF_TRADER_TEMP\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, TR_ID)
        'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
        Dim XML_TRADER As String = _path & "XML_TRADER_TEMP\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, TR_ID)

        Dim bool As Boolean = False
        FileUpload1.SaveAs(PDF_TRADER)
        convert_PDF_To_XML(PDF_TRADER, XML_TRADER)
        Try
            Dim objStreamReader As New StreamReader(XML_TRADER)
            Dim p2 As New CLASS_DALCN
            Dim x As New XmlSerializer(p2.GetType)
            p2 = x.Deserialize(objStreamReader)
            objStreamReader.Close()

            Dim dao_DALCN_PHR As New DAO_DRUG.ClsDBDALCN_PHR

            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA_STATUS(_IDA)
            Dim lct_ida As Integer = dao_lcn.fields.FK_IDA

            For Each dao_DALCN_PHR.fields In p2.DALCN_PHRs
                If (dao_DALCN_PHR.fields.PHR_MEDICAL_TYPE = "1") Or (String.IsNullOrWhiteSpace(dao_DALCN_PHR.fields.PHR_MEDICAL_TYPE) = True) Then

                    If String.IsNullOrWhiteSpace(dao_DALCN_PHR.fields.PHR_NAME) = False Then
                        If result = "" Then
                            result = GET_RESULT(dao_DALCN_PHR.fields.PHR_CTZNO, lct_ida)
                        Else
                            result &= GET_RESULT(dao_DALCN_PHR.fields.PHR_CTZNO, lct_ida)
                        End If
                    End If
                End If
            Next

        Catch ex As Exception

        End Try


        Return result
    End Function

    Function GET_RESULT(ByVal ctzno As String, ByVal lct_ida As Integer) As String
        Dim result As String = ""
        Dim dao_phr As New DAO_DRUG.ClsDBDALCN_PHR
        dao_phr.GetDataby_CTZNO(ctzno)
        For Each dao_phr.fields In dao_phr.datas
            Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
            dao_lcn.GetDataby_IDA_STATUS(dao_phr.fields.FK_IDA)
            If lct_ida <> dao_lcn.fields.FK_IDA Then
                If result = "" Then
                    Try
                        result = dao_lcn.fields.pvnabbr & " " & dao_lcn.fields.lcntpcd & " " & Right(dao_lcn.fields.lcnno, 5) & "/" & Left(dao_lcn.fields.lcnno, 2)
                    Catch ex As Exception

                    End Try
                Else
                    result &= " \n" & dao_lcn.fields.pvnabbr & " " & dao_lcn.fields.lcntpcd & " " & Right(dao_lcn.fields.lcnno, 5) & "/" & Left(dao_lcn.fields.lcnno, 2)
                End If
            End If
        Next
        Return result
    End Function

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Write("<script type='text/javascript'>window.parent.close_modal();</script> ")
    End Sub
End Class