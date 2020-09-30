Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER
Imports iTextSharp.text.pdf
Imports System.Xml
Public Class POPUP_EXTEND_TIME_LOCATION_UPLOAD
    Inherits System.Web.UI.Page
    Private _type_id As String = ""
    Private _IDA As String = ""
    Private _ProcessID As Integer
    Private _pvncd As Integer
    'Private _expyear As Integer
    Private _lcn_ida As String = ""
    Private _result As String = "กรุณาแนบไฟล์ดังนี้\n"
    Private _lct_ida As String = ""
    Private _staff As String = ""
    Private _TR_ID As String = ""
    Sub runQuery()
        _type_id = Request.QueryString("type_id")
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
        _lcn_ida = Request.QueryString("lcn_ida")
        _TR_ID = Request.QueryString("tr_id")
        '_lct_ida = Request.QueryString("lct_ida")
        _lct_ida = _IDA
        _staff = Request.QueryString("staff")
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
        Dim dao As New DAO_DRUG.TB_TEMPLATE_ATTACH
        dao.GetDataby_LCTNPCD(_ProcessID, "00")
        For Each dao.fields In dao.datas
            Dim uc As New UC_ATTACH_CUS
            Dim CC As UserControl = Page.LoadControl("../UC/UC_ATTACH_CUS.ascx")
            uc = CC
            uc.ID = dao.fields.IDA
            uc.BindData(dao.fields.ATTACH_NAME, dao.fields.ATTACH_PIORITY, dao.fields.ATTACH_FILE_EXTENSION, dao.fields.LCNTPCD, dao.fields.TYPE)
            'PlaceHolder1.Controls.Add(uc)
        Next
    End Sub

    Public Sub show_panel()
        If _type_id = "100741" Then
            Panel100741.Style.Add("display", "block")
        ElseIf _type_id = "100742" Then
            Panel100742.Style.Add("display", "block")
        ElseIf _type_id = "100743" Then
            Panel100743.Style.Add("display", "block")
        ElseIf _type_id = "100744" Then
            Panel100744.Style.Add("display", "block")
        ElseIf _type_id = "100745" Then
            Panel100745.Style.Add("display", "block")
        ElseIf _type_id = "100746" Then
            Panel100746.Style.Add("display", "block")
        ElseIf _type_id = "100747" Then
            Panel100747.Style.Add("display", "block")
        ElseIf _type_id = "100748" Then
            Panel100748.Style.Add("display", "block")
        ElseIf _type_id = "100749" Then
            Panel100749.Style.Add("display", "block")
        ElseIf _type_id = "100750" Then
            Panel100750.Style.Add("display", "block")
        ElseIf _type_id = "100751" Then
            Panel100751.Style.Add("display", "block")
        Else

        End If
    End Sub
    Public Sub set_txt_label()
        'ขย15
        uc100741_1.get_label("(1) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรม ซึ่งรับรองว่าผู้ดำเนินกิจการไม่เป็นโรคตามมาตรา 14 (6) แห่งพระราชบัญญัติยา พ.ศ.2510")
        'ใบรับรองของผู้ประกอบวิชาชีพเวชกรรมผู้ประกอบวิชาชีพเวชกรรมซึ่งรับรองว่าผู้รับอนุญาตหรือผู้ดำเนินกิจการ สุขภาพแข็งแรง และไม่เป็นโรคตามมาตรา 14 (6) แห่งพระราชบัญญัติยา พ.ศ.2510")
        uc100741_2.get_label("(2) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรมผู้ประกอบวิชาชีพเวชกรรมซึ่งรับรองว่าผู้มีหน้าที่ปฏิบัติการมีสุขภาพแข็งแรงสามารถประกอบวิชาชีพได้")
        'uc100741_3.get_label("(3) ใบอนุญาตประกอบธุรกิจเกี่ยวกับยาแผนปัจจุบันหรือใบแทน")
        'uc100741_4.get_label("(4) เอกสารแสดงว่าผู้ดำเนินกิจการซึ่งเป็นผู้แทนหรือผู้จัดการนิติบุคคลของนิติบุคคล (กรณีนิติบุคคลเป็นผู้ขออนุญาต)")
        'uc100741_5.get_label("(5) สำเนาทะเบียนบ้านของผู้รับอนุญาต")
        uc100741_3.get_label("(3) คำรับรองตามแบบ ข.ย.14 พร้อมเอกสารประกอบ")
        'uc100741_7.get_label("(7) ผลการตรวจประเมินวิธีปฏิบัติทางเภสัชกรรมชุมชน")
        uc100741_4.get_label("(4) แผนที่แสดงที่ตั้งร้าน")
        uc100741_5.get_label("(5) รูปถ่ายด้านหน้าสถานที่ตั้ง")
        uc100741_6.get_label("(6) อื่นๆ (ถ้ามี)")

        'ผย9
        uc100742_1.get_label("(1) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรม ซึ่งรับรองว่าผู้ดำเนินกิจการไม่เป็นโรคตามมาตรา 14 (6) แห่งพระราชบัญญัติยา พ.ศ.2510")
        uc100742_2.get_label("(2) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรมผู้ประกอบวิชาชีพเวชกรรมซึ่งรับรองว่าผู้มีหน้าที่ปฏิบัติการมีสุขภาพแข็งแรงสามารถประกอบวิชาชีพได้")
        'ใบอนุญาตผลิตยาแผนปัจจุบันหรือใบแทน")
        uc100742_3.get_label("(3) แผนที่แสดงที่ตั้งร้าน")
        uc100742_4.get_label("(4) รูปถ่ายด้านหน้าสถานที่ตั้ง")
        'เอกสารแสดงว่าเป็นผู้จัดการหรือเป็นผู้แทน ซึ่งเป็นผู้ดำเนินกิจการของนิติบุคคล (กรณีนิติบุคคลเป็นผู้ขออนุญาต)")
        uc100742_5.get_label("(5) อื่นๆ (ถ้ามี)")

        'นย9
        uc100743_1.get_label("(1) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรม ซึ่งรับรองว่าผู้ดำเนินกิจการ ไม่เป็นโรคตามมาตรา 14 (6) แห่งพระราชบัญญัติยา พ.ศ.2510")
        uc100743_2.get_label("(2) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรมผู้ประกอบวิชาชีพเวชกรรมซึ่งรับรองว่าผู้มีหน้าที่ปฏิบัติการมีสุขภาพแข็งแรงสามารถประกอบวิชาชีพได้")
        uc100743_3.get_label("(3) แผนที่แสดงที่ตั้งร้าน")
        'จัดการหรือผู้แทน ซึ่งเป็นผู้ดำเนินกิจการของนิติบุคคล (กรณีนิติบุคคลเป็นผู้ขออนุญาต)")
        uc100743_4.get_label("(4) รูปถ่ายด้านหน้าสถานที่ตั้ง")
        uc100743_5.get_label("(5) อื่นๆ (ถ้ามี)")

        'ยบ13
        uc100744_1.get_label("(1) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรม ซึ่งรับรองว่าผู้ดำเนินกิจการ ไม่เป็นโรคตามมาตรา 14 (6) แห่งพระราชบัญญัติยา พ.ศ.2510")
        'ใบรับรองของผู้ประกอบวิชาชีพเวชกรรม ซึ่งรับรองว่าผู้ดำเนินกิจการไม่เป็นโรคตามมาตรา 48 (6) แห่งพระราชบัญญัติยา พ.ศ.2510 ซึ่งแก้ไขเพิ่มเติมโดยพระราชบัญญัติยา (ฉบับที่ 3) พ.ศ.2522")
        uc100744_2.get_label("(2) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรมผู้ประกอบวิชาชีพเวชกรรมซึ่งรับรองว่าผู้มีหน้าที่ปฏิบัติการมีสุขภาพแข็งแรงสามารถประกอบวิชาชีพได้")
        uc100744_3.get_label("(3) แผนที่แสดงที่ตั้งร้าน")
        'เอกสารแสดงว่าเป็นผู้จัดการหรือผู้แทน ซึ่งเป็นผู้ดำเนินกิจการของนิติบุคคล (กรณีนิติบุคคลเป็นผู้ขออนุญาต)")
        uc100744_4.get_label("(4) รูปถ่ายด้านหน้าสถานที่ตั้ง")
        uc100744_5.get_label("(5) อื่นๆ (ถ้ามี)")

        'ขจ3
        uc100745_1.get_label("(1) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรม ซึ่งรับรองว่าผู้ดำเนินกิจการ ไม่เป็นโรคตามมาตรา 14 (6) แห่งพระราชบัญญัติยา พ.ศ.2510")
        'รูปถ่าย 3 x 4 เซนติเมตร 4 รูป")
        uc100745_2.get_label("(2) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรมผู้ประกอบวิชาชีพเวชกรรมซึ่งรับรองว่าผู้มีหน้าที่ปฏิบัติการมีสุขภาพแข็งแรงสามารถประกอบวิชาชีพได้")
        'ใบอนุญาตขายวัตถุออกฤทธิ์ในประเภท 3 หรือ ประเภท 4 หรือใบแทน")
        uc100745_3.get_label("(3) แผนที่แสดงที่ตั้งร้าน")
        'เอกสารอื่น ๆ (ถ้ามี)")
        uc100745_4.get_label("(4) รูปถ่ายด้านหน้าสถานที่ตั้ง")
        uc100745_5.get_label("(5) อื่นๆ (ถ้ามี)")

        'นจ3
        uc100746_1.get_label("(1) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรม ซึ่งรับรองว่าผู้ดำเนินกิจการ ไม่เป็นโรคตามมาตรา 14 (6) แห่งพระราชบัญญัติยา พ.ศ.2510")
        'รูปถ่ายขนาด 3 x 4 เซนติเมตร 4 รูป (ในกรณีที่ต้องออกใบอนุญาตใหม่)")
        uc100746_2.get_label("(2) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรมผู้ประกอบวิชาชีพเวชกรรมซึ่งรับรองว่าผู้มีหน้าที่ปฏิบัติการมีสุขภาพแข็งแรงสามารถประกอบวิชาชีพได้")
        'ใบอนุญาตนำเข้าซึ่งวัตถุออกฤทธิ์ ในประเภท 3 หรือประเภท 4 หรือใบแทน")
        uc100746_3.get_label("(3) แผนที่แสดงที่ตั้งร้าน")
        'เอกสารอื่นๆ (ถ้ามี)")
        uc100746_4.get_label("(4) รูปถ่ายด้านหน้าสถานที่ตั้ง")
        uc100746_5.get_label("(5) อื่นๆ (ถ้ามี)")

        'ผจ3
        uc100747_1.get_label("(1) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรม ซึ่งรับรองว่าผู้ดำเนินกิจการ ไม่เป็นโรคตามมาตรา 14 (6) แห่งพระราชบัญญัติยา พ.ศ.2510")
        'รูปถ่ายขนาด 3 x 4 เซนติเมตร 4 รูป (ในกรณีที่ต้องออกใบอนุญาตใหม่)")
        uc100747_2.get_label("(2) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรมผู้ประกอบวิชาชีพเวชกรรมซึ่งรับรองว่าผู้มีหน้าที่ปฏิบัติการมีสุขภาพแข็งแรงสามารถประกอบวิชาชีพได้")
        'ใบอนุญาตผลิตซึ่งวัตถุออกฤทธิ์ ในประเภท 3 หรือประเภท 4 หรือใบแทน")
        uc100747_3.get_label("(3) แผนที่แสดงที่ตั้งร้าน")
        'เอกสารอื่นๆ (ถ้ามี)")
        uc100747_4.get_label("(4) รูปถ่ายด้านหน้าสถานที่ตั้ง")
        uc100747_5.get_label("(5) อื่นๆ (ถ้ามี)")

        'สจ4
        uc100748_1.get_label("(1) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรม ซึ่งรับรองว่าผู้ดำเนินกิจการ ไม่เป็นโรคตามมาตรา 14 (6) แห่งพระราชบัญญัติยา พ.ศ.2510")
        'รูปถ่ายขนาด 3 x 4 เซนติเมตร 4 รูป (ในกรณีที่ต้องออกใบอนุญาตใหม่)")
        uc100748_2.get_label("(2) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรมผู้ประกอบวิชาชีพเวชกรรมซึ่งรับรองว่าผู้มีหน้าที่ปฏิบัติการมีสุขภาพแข็งแรงสามารถประกอบวิชาชีพได้")
        'ใบอนุญาตส่งออกซึ่งวัตถุออกฤทธิ์ ในประเภท 3 หรือประเภท 4 หรือใบแทน")
        uc100748_3.get_label("(3) แผนที่แสดงที่ตั้งร้าน")
        'เอกสารอื่นๆ (ถ้ามี)")
        uc100748_4.get_label("(4) รูปถ่ายด้านหน้าสถานที่ตั้ง")
        uc100748_5.get_label("(5) อื่นๆ (ถ้ามี)")

        'ยส19
        uc100749_1.get_label("(1) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรม ซึ่งรับรองว่าผู้ดำเนินกิจการ ไม่เป็นโรคตามมาตรา 14 (6) แห่งพระราชบัญญัติยา พ.ศ.2510")
        'รูปถ่ายของผู้ขอต่ออายุใบอนุญาตหรือผู้ดำเนินกิจการ ขนาด 3 x 4 เซนติเมตร จำนวน 3 รูป (ในกรณีที่ต้องออกใบอนุญาตใหม่)")
        uc100749_2.get_label("(2) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรมผู้ประกอบวิชาชีพเวชกรรมซึ่งรับรองว่าผู้มีหน้าที่ปฏิบัติการมีสุขภาพแข็งแรงสามารถประกอบวิชาชีพได้")
        'ใบอนุญาตผลิต จำหน่าย นำเข้า หรือส่งออกซึ่งยาเสพติดให้โทษในประเภท 3 หรือใบแทน")
        uc100749_3.get_label("(3) แผนที่แสดงที่ตั้งร้าน")
        uc100749_4.get_label("(4) รูปถ่ายด้านหน้าสถานที่ตั้ง")
        uc100749_5.get_label("(5) อื่นๆ (ถ้ามี)")

        'ขนจ1
        uc100750_1.get_label("(1) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรม ซึ่งรับรองว่าผู้ดำเนินกิจการ ไม่เป็นโรคตามมาตรา 14 (6) แห่งพระราชบัญญัติยา พ.ศ.2510")
        'รูปถ่ายของผู้ขอต่ออายุใบอนุญาตหรือผู้ดำเนินกิจการ ขนาด 3 x 4 เซนติเมตร จำนวน 3 รูป (ในกรณีที่ต้องออกใบอนุญาตใหม่)")
        uc100750_2.get_label("(2) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรมผู้ประกอบวิชาชีพเวชกรรมซึ่งรับรองว่าผู้มีหน้าที่ปฏิบัติการมีสุขภาพแข็งแรงสามารถประกอบวิชาชีพได้")
        'ใบอนุญาตผลิต จำหน่าย นำเข้า หรือส่งออกซึ่งยาเสพติดให้โทษในประเภท 3 หรือใบแทน")
        uc100750_3.get_label("(3) แผนที่แสดงที่ตั้งร้าน")
        uc100750_4.get_label("(4) รูปถ่ายด้านหน้าสถานที่ตั้ง")
        uc100750_5.get_label("(5) อื่นๆ (ถ้ามี)")

        'สมพ
        uc100751_1.get_label("(1) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรม ซึ่งรับรองว่าผู้ดำเนินกิจการ ไม่เป็นโรคตามมาตรา 14 (6) แห่งพระราชบัญญัติยา พ.ศ.2510")
        'ใบรับรองของผู้ประกอบวิชาชีพเวชกรรม ซึ่งรับรองว่าผู้ดำเนินกิจการไม่เป็นโรคตามมาตรา 48 (6) แห่งพระราชบัญญัติยา พ.ศ.2510 ซึ่งแก้ไขเพิ่มเติมโดยพระราชบัญญัติยา (ฉบับที่ 3) พ.ศ.2522")
        uc100751_2.get_label("(2) ใบรับรองของผู้ประกอบวิชาชีพเวชกรรมผู้ประกอบวิชาชีพเวชกรรมซึ่งรับรองว่าผู้มีหน้าที่ปฏิบัติการมีสุขภาพแข็งแรงสามารถประกอบวิชาชีพได้")
        uc100751_3.get_label("(3) แผนที่แสดงที่ตั้งร้าน")
        'เอกสารแสดงว่าเป็นผู้จัดการหรือผู้แทน ซึ่งเป็นผู้ดำเนินกิจการของนิติบุคคล (กรณีนิติบุคคลเป็นผู้ขออนุญาต)")
        uc100751_4.get_label("(4) รูปถ่ายด้านหน้าสถานที่ตั้ง")
        uc100751_5.get_label("(5) อื่นๆ (ถ้ามี)")
    End Sub
    Public Sub SET_ATTACH(ByVal TR_ID As String, ByVal PROCESS_ID As String, ByVal YEAR As String)
        Dim dao_edit As New DAO_DRUG.TB_LCN_EXTEND_LITE
        dao_edit.GetDataby_FK_IDA(TR_ID)
        If dao_edit.fields.STATUS_ID = 5 Then
            If _type_id = "100741" Then
                'ขย15
                uc100741_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "11")
                uc100741_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "22")
                uc100741_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "33")
                uc100741_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "44")
                uc100741_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "55")
                uc100741_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "66")
                'uc100741_7.ATTACH(TR_ID, PROCESS_ID, YEAR, "77")

            ElseIf _type_id = "100742" Then
                'ผย9
                uc100742_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "11")
                uc100742_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "22")
                uc100742_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "33")
                uc100742_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "44")
                uc100742_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "55")

            ElseIf _type_id = "100743" Then
                'นย9
                uc100743_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "11")
                uc100743_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "22")
                uc100743_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "33")
                uc100743_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "44")
                uc100743_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "55")

            ElseIf _type_id = "100744" Then
                'ยบ13
                uc100744_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "11")
                uc100744_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "22")
                uc100744_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "33")
                uc100744_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "44")
                uc100744_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "55")

            ElseIf _type_id = "100745" Then
                'ขจ3
                uc100745_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "11")
                uc100745_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "22")
                uc100745_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "33")
                uc100745_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "44")
                uc100745_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "55")

            ElseIf _type_id = "100746" Then
                'นจ3
                uc100746_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "11")
                uc100746_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "22")
                uc100746_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "33")
                uc100746_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "44")
                uc100746_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "55")

            ElseIf _type_id = "100747" Then
                'ผจ3
                uc100747_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "11")
                uc100747_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "22")
                uc100747_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "33")
                uc100747_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "44")
                uc100747_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "55")

            ElseIf _type_id = "100748" Then
                'สจ4
                uc100748_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "11")
                uc100748_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "22")
                uc100748_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "33")
                uc100748_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "44")
                uc100748_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "55")

            ElseIf _type_id = "100749" Then

                'ยส19
                uc100749_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "11")
                uc100749_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "22")
                uc100749_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "33")
                uc100749_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "44")
                uc100749_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "55")
            ElseIf _type_id = "100750" Then

                'ขนจ1
                uc100750_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
                uc100750_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
                uc100750_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
                uc100750_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
                uc100750_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            ElseIf _type_id = "100751" Then

                'ขนจ1
                uc100751_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
                uc100751_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
                uc100751_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
                uc100751_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
                uc100751_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            End If
        Else
            If _type_id = "100741" Then
                'ขย15
                uc100741_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
                uc100741_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
                ''uc100741_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
                'uc100741_7.ATTACH(TR_ID, PROCESS_ID, YEAR, "7")
                uc100741_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
                uc100741_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
                uc100741_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
                uc100741_6.ATTACH(TR_ID, PROCESS_ID, YEAR, "6")

            ElseIf _type_id = "100742" Then
                'ผย9
                uc100742_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
                uc100742_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
                uc100742_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
                uc100742_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
                uc100742_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")

            ElseIf _type_id = "100743" Then
                'นย9
                uc100743_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
                uc100743_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
                uc100743_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
                uc100743_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
                uc100743_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")

            ElseIf _type_id = "100744" Then
                'ยบ13
                uc100744_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
                uc100744_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
                uc100744_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
                uc100744_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
                uc100744_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")

            ElseIf _type_id = "100745" Then
                'ขจ3
                uc100745_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
                uc100745_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
                uc100745_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
                uc100745_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
                uc100745_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            ElseIf _type_id = "100746" Then
                'นจ3
                uc100746_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
                uc100746_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
                uc100746_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
                uc100746_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
                uc100746_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")

            ElseIf _type_id = "100747" Then
                'ผจ3
                uc100747_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
                uc100747_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
                uc100747_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
                uc100747_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
                uc100747_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")

            ElseIf _type_id = "100748" Then
                'สจ4
                uc100748_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
                uc100748_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
                uc100748_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
                uc100748_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
                uc100748_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")

            ElseIf _type_id = "100749" Then

                'ยส19
                uc100749_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
                uc100749_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
                uc100749_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
                uc100749_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
                uc100749_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")

            ElseIf _type_id = "100750" Then

                'ขนจ1
                uc100750_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
                uc100750_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
                uc100750_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
                uc100750_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
                uc100750_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            ElseIf _type_id = "100751" Then

                'สมพ
                uc100751_1.ATTACH(TR_ID, PROCESS_ID, YEAR, "1")
                uc100751_2.ATTACH(TR_ID, PROCESS_ID, YEAR, "2")
                uc100751_3.ATTACH(TR_ID, PROCESS_ID, YEAR, "3")
                uc100751_4.ATTACH(TR_ID, PROCESS_ID, YEAR, "4")
                uc100751_5.ATTACH(TR_ID, PROCESS_ID, YEAR, "5")
            End If
        End If
    End Sub
    Public Function SET_chk()
        Dim count = 0
        If _type_id = "100741" Then
            'ขย15
            If uc100741_1.chk(count) = 1 Then
                count += 1
            End If
            If uc100741_2.chk(count) = 2 Then
                count += 1
            End If
            If uc100741_3.chk(count) = 3 Then
                count += 1
            End If
            If uc100741_4.chk(count) = 4 Then
                count += 1
            End If
            If uc100741_5.chk(count) = 5 Then
                count += 1
            End If
            If uc100741_6.chk(count) = 6 Then
                count += 1
            End If

        ElseIf _type_id = "100742" Then
            'ผย9
            If uc100742_1.chk(count) = 1 Then
                count += 1
            End If
            If uc100742_2.chk(count) = 2 Then
                count += 1
            End If
            If uc100742_3.chk(count) = 3 Then
                count += 1
            End If
            If uc100742_4.chk(count) = 4 Then
                count += 1
            End If
            If uc100742_5.chk(count) = 5 Then
                count += 1
            End If

        ElseIf _type_id = "100743" Then
            'นย9
            If uc100743_1.chk(count) = 1 Then
                count += 1
            End If
            If uc100743_2.chk(count) = 2 Then
                count += 1
            End If
            If uc100743_3.chk(count) = 3 Then
                count += 1
            End If
            If uc100743_4.chk(count) = 4 Then
                count += 1
            End If
            If uc100743_5.chk(count) = 5 Then
                count += 1
            End If
        ElseIf _type_id = "100744" Then
            'ยบ13
            If uc100744_1.chk(count) = 1 Then
                count += 1
            End If
            If uc100744_2.chk(count) = 2 Then
                count += 1
            End If
            If uc100744_3.chk(count) = 3 Then
                count += 1
            End If
            If uc100744_4.chk(count) = 4 Then
                count += 1
            End If
            If uc100744_5.chk(count) = 5 Then
                count += 1
            End If
        ElseIf _type_id = "100745" Then
            'ขจ3
            If uc100745_1.chk(count) = 1 Then
                count += 1
            End If
            If uc100745_2.chk(count) = 2 Then
                count += 1
            End If
            If uc100745_3.chk(count) = 3 Then
                count += 1
            End If
            If uc100745_4.chk(count) = 4 Then
                count += 1
            End If
            If uc100745_5.chk(count) = 5 Then
                count += 1
            End If
        ElseIf _type_id = "100746" Then
            'นจ3
            If uc100746_1.chk(count) = 1 Then
                count += 1
            End If
            If uc100746_2.chk(count) = 2 Then
                count += 1
            End If
            If uc100746_3.chk(count) = 3 Then
                count += 1
            End If
            If uc100746_4.chk(count) = 4 Then
                count += 1
            End If
            If uc100746_5.chk(count) = 5 Then
                count += 1
            End If
        ElseIf _type_id = "100747" Then
            'ผจ3
            If uc100747_1.chk(count) = 1 Then
                count += 1
            End If
            If uc100747_2.chk(count) = 2 Then
                count += 1
            End If
            If uc100747_3.chk(count) = 3 Then
                count += 1
            End If
            If uc100747_4.chk(count) = 4 Then
                count += 1
            End If
            If uc100747_5.chk(count) = 5 Then
                count += 1
            End If
        ElseIf _type_id = "100748" Then
            'สจ4
            If uc100748_1.chk(count) = 1 Then
                count += 1
            End If
            If uc100748_2.chk(count) = 2 Then
                count += 1
            End If
            If uc100748_3.chk(count) = 3 Then
                count += 1
            End If
            If uc100748_4.chk(count) = 4 Then
                count += 1
            End If
            If uc100748_5.chk(count) = 5 Then
                count += 1
            End If
        ElseIf _type_id = "100749" Then
            'ยส19
            If uc100749_1.chk(count) = 1 Then
                count += 1
            End If
            If uc100749_2.chk(count) = 2 Then
                count += 1
            End If
            If uc100749_3.chk(count) = 3 Then
                count += 1
            End If
            If uc100749_4.chk(count) = 4 Then
                count += 1
            End If
            If uc100748_5.chk(count) = 5 Then
                count += 1
            End If
        ElseIf _type_id = "100750" Then
            'ขนจ1
            If uc100750_1.chk(count) = 1 Then
                count += 1
            End If
            If uc100750_2.chk(count) = 2 Then
                count += 1
            End If
            If uc100750_3.chk(count) = 3 Then
                count += 1
            End If
            If uc100750_4.chk(count) = 4 Then
                count += 1
            End If
            If uc100750_5.chk(count) = 5 Then
                count += 1
            End If
        ElseIf _type_id = "100751" Then
            'สมพ
            If uc100751_1.chk(count) = 1 Then
                count += 1
            End If
            If uc100751_2.chk(count) = 2 Then
                count += 1
            End If
            If uc100751_3.chk(count) = 3 Then
                count += 1
            End If
            If uc100751_4.chk(count) = 4 Then
                count += 1
            End If
            If uc100751_5.chk(count) = 5 Then
                count += 1
            End If
        End If
        Return count
    End Function

    Protected Sub btn_Upload_Click(sender As Object, e As EventArgs) Handles btn_Upload.Click
        Try
            Dim chk As Boolean = True
            Dim dao_edit As New DAO_DRUG.TB_LCN_EXTEND_LITE
            Dim dao_dal As New DAO_DRUG.ClsDBdalcn
            Dim dao_process As New DAO_DRUG.ClsDBPROCESS_NAME
            dao_process.GetDataby_Process_ID(_ProcessID)
            Dim cyear As New Integer
            cyear = CInt(Year(Date.Now)) + 1
            dao_edit.GetDataby_FK_IDA(_lcn_ida)
            dao_dal.GetDataby_IDA(_lcn_ida)
            If dao_edit.fields.FK_IDA = dao_dal.fields.IDA And dao_edit.fields.extend_year = cyear And dao_edit.fields.STATUS_ID <> 7 And dao_edit.fields.STATUS_ID <> 5 And dao_edit.fields.PROCESS_ID <> "100747" And dao_edit.fields.PROCESS_ID <> "100745" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('ท่านได้ส่งคำขอนี้ไปแล้ว');", True)
            Else
                If SET_chk() >= 4 Or _staff = 1 Then
                    ' ทำการ Upload File Pdf  เพื่อทำการ Save PDF ลงไปในระบบ และทำการดึง XML ออกมาจาก PDF เพื่อเก็บไว้
                    If FileUpload1.HasFile Then
                        Dim TR_ID As String = ""
                        Dim bao As New BAO.AppSettings
                        bao.RunAppSettings()
                        Dim bao_tran As New BAO_TRANSECTION
                        bao_tran.CITIZEN_ID = _CLS.CITIZEN_ID
                        bao_tran.CITIZEN_ID_AUTHORIZE = _CLS.CITIZEN_ID_AUTHORIZE
                        TR_ID = bao_tran.insert_transection_new(_ProcessID) 'ทำการบันทึกเพื่อให้ได้เลข Transection ID’class จาก BAO_TRANSECTION
                        If _TR_ID = "" Then
                            _TR_ID = TR_ID
                        End If
                        If Upload_Attach(_TR_ID) Then
                            Dim PDF_TRADER As String
                            Dim XML_TRADER As String
                            'If UC_ATTACH1.ATTACH(TR_ID, _ProcessID, con_year(Date.Now.Year), "1") = False Then
                            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('กรุณาแนบไฟล์');", True)
                            '    Exit Sub
                            'End If

                            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
                            dao_pdftemplate.GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(_ProcessID, 1, 0)
                            If dao_edit.fields.STATUS_ID = 5 Then
                                'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
                                PDF_TRADER = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & "-1" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, _TR_ID)
                                'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
                                XML_TRADER = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & "-1" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, _TR_ID)
                            Else


                                'PDF_TRADER คือ Folder จัดเก็บ PDF ที่ ผปก Upload เข้ามา
                                PDF_TRADER = bao._PATH_DEFAULT & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_UPLOAD_PDF("DA", _ProcessID, Date.Now.Year, _TR_ID)
                                'PDF_XML_CLASS คือ Folder จัดเก็บ XML ที่แยกออกมาจาก PDF Upload เข้ามา
                                XML_TRADER = bao._PATH_DEFAULT & dao_pdftemplate.fields.XML_PATH & "\" & NAME_UPLOAD_XML("DA", _ProcessID, Date.Now.Year, _TR_ID)
                            End If
                            FileUpload1.SaveAs(PDF_TRADER) '"C:\path\PDF_TRADER\"
                            'ทำการแปลงส่ง PDF เข้าไปแล้วแปลงออกเป็น XML
                            convert_PDF_To_XML(PDF_TRADER, XML_TRADER)


                            '    convert_PDF_To_XML(bao._PATH_PDF_TRADER & "FA-5-2558-" & TR_ID & ".pdf", TR_ID) '"C:\path\PDF_TRADER\"
                            Dim check As Boolean = True
                            ' Try
                            'If chk = True Then
                            If dao_edit.fields.STATUS_ID = 5 Then
                                dao_edit.fields.STATUS_ID = 6
                                dao_edit.update()
                            Else
                                check = insrt_to_database(XML_TRADER, _TR_ID)
                            End If
                            If check = True Then
                                SET_ATTACH(_TR_ID, _ProcessID, con_year(Date.Now.Year))
                                If dao_edit.fields.STATUS_ID = 6 Then
                                    AddLogStatusEtracking(6, 0, _CLS.CITIZEN_ID, "อัพโหลดเอกสารต่ออายุ(แก้ไข) " & dao_process.fields.PROCESS_NAME, dao_process.fields.PROCESS_NAME, dao_edit.fields.FK_IDA, dao_edit.fields.IDA, 0, HttpContext.Current.Request.Url.AbsoluteUri)
                                Else
                                    AddLogStatusEtracking(0, 0, _CLS.CITIZEN_ID, "อัพโหลดเอกสารต่ออายุ " & dao_process.fields.PROCESS_NAME, dao_process.fields.PROCESS_NAME, 0, 0, 0, HttpContext.Current.Request.Url.AbsoluteUri)
                                End If
                                alert("รหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + _TR_ID)
                            Else
                                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('เกิดข้อผิดพลาดกรุณาตรวจสอบข้อมูลในไฟล์');", True)
                            End If
                            'Catch ex As Exception

                            '    alert("เกิดข้อผิดพลาดรหัสการดำเนินการ คือ DA-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID)
                            'End Try
                            'Else
                            '    System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาแนบไฟล์');", True)
                            'End If
                            'Else
                            '    alert2(_result)
                        End If


                    Else
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาแนบไฟล์คำขอ');", True)
                    End If
                Else
                    alert2(_result)
                End If

            End If
            'Dim ws As New AUTHEN_LOG.Authentication
            'ws.AUTHEN_LOG_DATA(_CLS.TOKEN, _CLS.CITIZEN_ID, _CLS.SYSTEM_ID, _CLS.GROUPS, _CLS.ID_MENU, "DRUG", _TR_ID, HttpContext.Current.Request.Url.AbsoluteUri, "อัพโหลดคำขอต่ออายุ", _type_id)


        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
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
            _pvncd = Personal_Province_NEW(_CLS.CITIZEN_ID, _CLS.CITIZEN_ID_AUTHORIZE, _CLS.GROUPS)
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

        Dim objStreamReader As New StreamReader(FileName)
        Dim p2 As New CLASS_EXTEND
        Dim x As New XmlSerializer(p2.GetType)
        p2 = x.Deserialize(objStreamReader)
        objStreamReader.Close()
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(_lcn_ida)
        Dim dao_address As New DAO_DRUG.TB_DALCN_LOCATION_ADDRESS
        dao_address.GetDataby_IDA(_lct_ida)
        'Dim dao_pay As New DAO_DRUG.TB_LCN_EXTEND_LITE_PAY
        'dao_pay.GetDataby_lcntpcd(dao_lcn.fields.lcntpcd)
        Dim dao_lcnre As New DAO_DRUG.TB_LCN_EXTEND_LITE
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dao_t As New DAO_DRUG.TB_MAS_LCN_EXTEND_TYPE
        Try
            If dao_lcn.fields.lcntpcd = "ผยส" Then
                dao_lcn.fields.lcntpcd = "12"
            ElseIf dao_lcn.fields.lcntpcd = "จยส" Then
                dao_lcn.fields.lcntpcd = "13"
            ElseIf dao_lcn.fields.lcntpcd = "นยส" Then
                dao_lcn.fields.lcntpcd = "14"
            ElseIf dao_lcn.fields.lcntpcd = "สยส" Then
                dao_lcn.fields.lcntpcd = "15"
            ElseIf dao_lcn.fields.lcntpcd = "ผจ" Then
                dao_lcn.fields.lcntpcd = "02"
            ElseIf dao_lcn.fields.lcntpcd = "ขจ" Then
                dao_lcn.fields.lcntpcd = "03"
            ElseIf dao_lcn.fields.lcntpcd = "ขนจ" Then
                dao_lcn.fields.lcntpcd = "04"
            ElseIf dao_lcn.fields.lcntpcd = "นจ" Then
                dao_lcn.fields.lcntpcd = "05"
            ElseIf dao_lcn.fields.lcntpcd = "สวจ" Then
                dao_lcn.fields.lcntpcd = "06"
            End If
        Catch ex As Exception

        End Try

        'Dim dt2 As New DataTable
        'Dim bao2 As New BAO.ClsDBSqlcommand
        'dt2 = bao2.SP_GET_LCN_EXTEND_BY_IDA(_lcn_ida)
        If dao_lcn.fields.lcntpcd = "02" Then
            If p2.CHK_TYPE = "3" Then
                dao_lcn.fields.lcntpcd = "ผวจ3"
            Else
                dao_lcn.fields.lcntpcd = "ผวจ4"
            End If
        End If
        If dao_lcn.fields.lcntpcd = "03" Then
            If p2.CHK_TYPE = "3" Then
                dao_lcn.fields.lcntpcd = "ขวจ3"
            Else
                dao_lcn.fields.lcntpcd = "ขวจ4"
            End If
        End If
        If dao_lcn.fields.lcntpcd = "04" Then
            If p2.CHK_TYPE = "3" Then
                dao_lcn.fields.lcntpcd = "ขตวจ3"
            Else
                dao_lcn.fields.lcntpcd = "ขตวจ4"
            End If
        End If
        dao_t.GetDataby_lcntpcd(dao_lcn.fields.lcntpcd)
        dt = bao.SP_get_addr(_lcn_ida)
        dao_lcnre.fields.lcnno = dao_lcn.fields.lcnno
        dao_lcnre.fields.CITIZEN_AUTHORIZE = dao_lcn.fields.CITIZEN_ID_AUTHORIZE
        dao_lcnre.fields.lcnsid = dao_lcn.fields.lcnsid
        'dao_lcnre.fields.thanm = dao_address.fields.thanameplace
        Try
            dao_lcnre.fields.thanm_address = dt(0)("thanm_addr")
        Catch ex As Exception

        End Try
        Dim newyear As Integer = 0
        Dim year_present As Integer = 0
        Dim montn_present As Integer = 0
        year_present = Year(Date.Now)
        montn_present = Month(Date.Now)
        If montn_present = 1 Then
            newyear = year_present
        Else
            newyear = year_present + 1
        End If
        dao_lcnre.fields.extend_year = newyear
        dao_lcnre.fields.lcnno_display_full = dao_lcn.fields.pvnabbr & " " & dao_lcn.fields.lcntpcd + " " + (Int(Right(dao_lcn.fields.lcnno, 5)).ToString + "/25" + Left(dao_lcn.fields.lcnno, 2))
        dao_lcnre.fields.lcnno_pvnabbr = (Int(Right(dao_lcn.fields.lcnno, 5)).ToString + "/25" + Left(dao_lcn.fields.lcnno, 2))
        dao_lcnre.fields.PROCESS_ID = _ProcessID
        dao_lcnre.fields.PAY_L44_STAMP = dao_t.fields.pay_amount44
        dao_lcnre.fields.PAY_STAMP = dao_t.fields.pay_amount
        Try
            dao_lcnre.fields.licen = dt(0)("licen")
        Catch ex As Exception
        End Try

        Try
            dao_lcnre.fields.licen_address = dt(0)("licen_addr")
        Catch ex As Exception
        End Try

        dao_lcnre.fields.licen_time = dao_lcn.fields.opentime
        Try
            dao_lcnre.fields.grannm_lo = dt(0)("grannm_lo")
        Catch ex As Exception
        End Try
        Try
            dao_lcnre.fields.grannm_address = dt(0)("grannm_addr")
        Catch ex As Exception
        End Try

        dao_lcnre.fields.thaamphrnm = dao_address.fields.thaamphrnm
        dao_lcnre.fields.thachngwtnm = dao_address.fields.thachngwtnm
        dao_lcnre.fields.typee = dao_lcn.fields.lcntpcd
        Try
            dao_lcnre.fields.GROUPNAME = dt(0)("GROUPNAME")
        Catch ex As Exception
        End Try
        Try
            dao_lcnre.fields.cncnm = dt(0)("cncnm")
        Catch ex As Exception

        End Try
        Try
            dao_lcnre.fields.thanm = dt(0)("thanm")
        Catch ex As Exception

        End Try
        dao_lcnre.fields.process_l44 = dao_t.fields.process_l44


        dao_lcnre.fields.pvncd = dao_lcn.fields.pvncd

        dao_lcnre.fields.lcntpcd = dao_lcn.fields.lcntpcd

        'dao_lcnre.fields.thanm_address = dt(0)("thanm_address")

        'dao_lcnre.fields.grannm_lo = dt(0)("grannm_lo")
        'dao_lcnre.fields.grannm_address = dt(0)("grannm_address") 'dao2.fields.grannm_address


        Try
            dao_lcnre.fields.CITIZEN_ID = _CLS.CITIZEN_ID
        Catch ex As Exception

        End Try
        dao_lcnre.fields.WRITE_AT = p2.dalcns.WRITE_AT
        Try
            Dim newDate As DateTime = p2.dalcns.WRITE_DATE
            newDate = newDate.AddYears(543)
            dao_lcnre.fields.WRITE_DATE = newDate
        Catch ex As Exception
            dao_lcnre.fields.WRITE_DATE = Date.Now
        End Try
        'dao_lcnre.fields.IDA = p2.dalcns_new.IDA
        dao_lcnre.fields.FK_IDA = _lcn_ida
        '        dao_lcnre.fields.PROCESS_ID = _ProcessID
        '        dao_lcnre.fields.app_date = Date.Now.ToShortDateString
        '        dao_lcnre.fields.rcvdate = Date.Now    
        '        dao_lcnre.fields.lmdfdate = Date.Now
        '        dao_lcnre.fields.STATUS_ID = 1
        '        dao_lcnre.fields.XMLNAME = "DRUG-" & _ProcessID & "-" & con_year(Date.Now.Date().Year()) & "-" + TR_ID
        dao_lcnre.fields.TR_ID = TR_ID
        '        dao_lcnre.fields.lcntpcd = set_lcntpcd()
        'dao_lcnre.fields.lcntpcd_old = p2.dalcns_new.lcntpcd
        'dao_lcnre.fields.NEWYEAR = p2.EXP_NEWYEAR
        dao_lcnre.fields.Medic_4bsnname = Medic_4bsnname.Text
        dao_lcnre.fields.Medic_4bsnlastname = Medic_4bsnlastname.Text
        dao_lcnre.fields.Medic_4bsmnumber = Medic_4bsnnumber.Text
        dao_lcnre.fields.Medic_4exname = Medic_4exname.Text
        dao_lcnre.fields.Medic_4exlastname = Medic_4exlastname.Text
        dao_lcnre.fields.Medic_4exnumber = Medic_4exnumber.Text
        dao_lcnre.fields.MAP_X = map_x.Text
        dao_lcnre.fields.MAP_Y = map_y.Text
        dao_lcnre.fields.STATUS_ID = 0
        dao_lcnre.fields.staff = _staff
        Try
            dao_lcnre.fields.U1_CODE = dt(0)("U1_CODE")
        Catch ex As Exception

        End Try

        dao_lcnre.insert()


        Return check
    End Function
    ''' <summary>
    ''' ทำการ UPLOAD FILE แนบ
    ''' </summary>
    ''' <param name="TR_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Upload_Attach(ByVal TR_ID As Integer)
        Dim check As Boolean = True
        'For Each c As Control In PlaceHolder1.Controls
        '    If c.ID <> "" Then
        '        Dim ida As String = c.ID
        Dim uc As New UC_ATTACH_CUS
        Dim chk As Boolean = True
        'uc = PlaceHolder1.FindControl(c.ID)
        'chk = uc.insert(TR_ID)
        If chk = False Then
            check = False
            _result = _result & "-  " & uc.NAME.Replace("<br>", "\n") & "\n"
        End If
        '    End If
        'Next
        Return check
    End Function

    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');parent.close_modal();</script> ")
    End Sub

    Sub alert2(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.parent.alert('" + text + "');</script> ")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Write("<script type='text/javascript'>window.parent.close_modal();</script> ")
    End Sub
End Class