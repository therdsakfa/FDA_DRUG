Imports System.IO
Imports System.Data.OleDb
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Globalization
Imports System.Globalization.CultureInfo
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data
Imports System.Reflection
Imports QRCoder
Imports System.Drawing
Imports System.Xml.Serialization
Imports System.Xml

Public Module UTILITY_CLS
    Function ConvermXmlstr_TO_CLASS(Of T As Class)(ByRef str As String) As T
        Dim c As T = Nothing
        Try
            Dim serializer As XmlSerializer = New XmlSerializer(GetType(T))
            Dim reader As StringReader = New StringReader(str)
            c = TryCast(serializer.Deserialize(reader), T)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Return c

    End Function

    <System.Runtime.CompilerServices.Extension()>
    Public Function b64encode(ByVal StrEncode As String)

        Dim encodedString As String

        encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(StrEncode)))

        Return (encodedString)

    End Function

    Private Sub SendMail(ByVal Content As String, ByVal email As String, ByVal title As String, ByVal CC As String, ByVal string_xml As String, ByVal filename As String)
        Dim mm As New FDA_MAIL.FDA_MAIL
        Dim mcontent As New FDA_MAIL.Fields_Mail

        mcontent.EMAIL_CONTENT = Content
        mcontent.EMAIL_FROM = "fda_info@fda.moph.go.th"
        mcontent.EMAIL_PASS = "deeku181"
        mcontent.EMAIL_TILE = title
        mcontent.EMAIL_TO = email


        mm.SendMail_ASY(mcontent)

    End Sub
    <System.Runtime.CompilerServices.Extension()>
    Function send_mail_mini(ByVal citizen As String, ByVal Title As String, ByVal Contents As String) As String
        Dim aa As String = ""
        Try

            Dim email As String = ""

            Dim dao_mail As New DAO_CPN.TB_sysemail

            Try
                dao_mail.GetDataby_identify(citizen)
                email = dao_mail.fields.EMAIL_EGA
            Catch ex As Exception

            End Try

            Try
                If email <> "" Then
                    email = email

                    SendMail(Contents, email, Title, email, "", "")
                    aa = "Success"
                End If
            Catch ex As Exception
                aa = "Fail"
            End Try
        Catch ex As Exception

        End Try
        Return aa
    End Function

    <System.Runtime.CompilerServices.Extension()>
    Function send_mail_mini2(ByVal mobile As String, ByVal Title As String, ByVal Contents As String) As String
        Dim aa As String = ""
        Try

            Dim email As String = ""

            Dim dao_mail As New DAO_CPN.TB_sysemail

            Try
                dao_mail.GetDataby_mobile(mobile)
                email = dao_mail.fields.EMAIL_EGA
            Catch ex As Exception

            End Try

            Try
                If email <> "" Then
                    email = email

                    SendMail(Contents, email, Title, email, "", "")
                    aa = "Success"
                End If
            Catch ex As Exception
                aa = "Fail"
            End Try
        Catch ex As Exception

        End Try
        Return aa
    End Function
    '
    <System.Runtime.CompilerServices.Extension()> _
    Public Function Get_drrqt_Status(ByVal FK_IDA As Integer)
        Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
        dao_rq.GetDataby_IDA(FK_IDA)
        Dim stattus_id As Integer = 0
        Try
            stattus_id = dao_rq.fields.STATUS_ID
        Catch ex As Exception

        End Try
        Return stattus_id
    End Function
    '<System.Runtime.CompilerServices.Extension()> _
    'Public Sub GEN_XML_EDIT(ByVal _PATH As String)
    '    Dim objStreamWriter As New StreamWriter(_PATH)                                                   'ประกาศตัวแปร
    '    Dim x As New XmlSerializer(dao.fields.GetType)                                                     'ประกาศ
    '    x.Serialize(objStreamWriter, dao.fields)
    '    objStreamWriter.Close()
    'End Sub
    <System.Runtime.CompilerServices.Extension()> _
    Public Function Get_drrqt_Status_by_trid(ByVal tr_id As Integer)
        Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
        dao_rq.GetDataby_TR_ID(tr_id)
        Dim stattus_id As Integer = 0
        Try
            stattus_id = dao_rq.fields.STATUS_ID
        Catch ex As Exception

        End Try
        Return stattus_id
    End Function
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub KEEP_LOGS_EDIT(ByVal FK_IDA As Integer, ByVal des As String, ByVal citizen As String, Optional url As String = "")
        Dim dao As New DAO_DRUG.TB_LOG_EDIT_MIGRATE
        dao.fields.ACTION_DESCRIPTION = des
        dao.fields.FK_IDA = FK_IDA
        dao.fields.CITIZEN_ID = citizen
        dao.fields.CREATEDATE = Date.Now
        dao.fields.URL = url
        dao.insert()


    End Sub
    '
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub KEEP_LOGS_TABEAN_EDIT(ByVal FK_IDA As Integer, ByVal des As String, ByVal citizen As String, Optional url As String = "")
        Dim dao As New DAO_DRUG.TB_LOG_EDIT_TABEAN
        dao.fields.ACTION_DESCRIPTION = des
        dao.fields.FK_IDA = FK_IDA
        dao.fields.CITIZEN_ID = citizen
        dao.fields.CREATEDATE = Date.Now
        dao.fields.URL = url
        dao.insert()
    End Sub
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub KEEP_LOGS_TABEAN_BC(ByVal pvncd As Integer, ByVal rgttpcd As String, ByVal drgtpcd As String, ByVal rgtno As Integer, ByVal IDA_drrgt As Integer, _
                                   ByVal IDENTIFY_EDIT As String, ByVal NEW_DETAIL_EDIT As String, ByVal Newcode_U As String, ByVal PREVIOUS_DETAIL_EDIT As String, _
                                   ByVal STATUS As String, ByVal URL As String, ByVal USER_ID_EDIT As String)
        Dim dao As New DAO_DRUG.TB_LOG_EDIT_PRODUCT_ESUB_BC
        With dao.fields
            .ADMIN_ID = "1710500118665"
            .CREATE_DATE = Date.Now
            .drgtpcd = drgtpcd
            .IDA_drrgt = IDA_drrgt
            .IDENTIFY_EDIT = IDENTIFY_EDIT
            .NEW_DETAIL_EDIT = NEW_DETAIL_EDIT
            .Newcode_U = Newcode_U
            .PREVIOUS_DETAIL_EDIT = PREVIOUS_DETAIL_EDIT
            .pvncd = pvncd
            .rgtno = rgtno
            .rgttpcd = rgttpcd
            .STATUS = STATUS
            .URL = URL
            .USER_ID_EDIT = USER_ID_EDIT
        End With
        dao.insert()
    End Sub
    Public Sub SEND_XML_DR(ByVal model As LGT_IOW_E, ByVal Newcode As String, ByVal IDENTIFY_EDIT As String)


        Dim ws_blockchain As New WS_BLOCKCHAIN.WS_BLOCKCHAIN
        Dim ws_fields As New WS_BLOCKCHAIN.XML_BLOCK
        ws_fields.TR_ID = Newcode 'เลขTRANSATION
        ws_fields.REF_TR_ID = "" 'ตรงนี้ยังไม่ต้องใส่มาเดียวจะอธิบายอีกที
        ws_fields.IDENTIFY = IDENTIFY_EDIT 'เลขนิติบุคคล 1103701216867คือเลขบัตรนน
        ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
        ws_fields.SOP_STATUS = 8 'สถานะคำขอนะ
        ws_fields.SYSTEM_ID = "DRUG" 'เลขสารระบบ
        ws_fields.SOP_REMARK = "ปรับปรุงข้อมูลทะเบียน" 'ความเห็น จนทที่พิมพ์มา
        ws_fields.XML_DATA = CLASSTOXMLSTR(model) 'classxml ข้อมูล
        ws_blockchain.WS_BLOCK_CHAIN_V3(ws_fields)
    End Sub
    Public Function CLASSTOXMLSTR(ByVal cls_rev As Object) 'เอา class มารับ class ที่ส่งเข้ามา
        Dim x2 As New XmlSerializer(cls_rev.GetType())
        Dim settings As New XmlWriterSettings()
        settings.Encoding = Encoding.UTF8
        settings.Indent = True
        Dim mem2 As New MemoryStream()
        Using writer As XmlWriter = XmlWriter.Create(mem2, settings)
            x2.Serialize(writer, cls_rev)
            writer.Flush()
            writer.Close()
        End Using
        Dim B64 As String = ""
        B64 = Convert.ToBase64String(mem2.GetBuffer())
        Return B64
    End Function
    <System.Runtime.CompilerServices.Extension()> _
    Public Function file_extension_nm(ByVal filename As String)

        Dim file_ex As String = ""
        If filename <> "" Then
            Dim arr_str As String() = filename.Split(".")
            file_ex = arr_str(arr_str.Length - 1)
        End If
        Return file_ex

    End Function
    <System.Runtime.CompilerServices.Extension()> _
    Public Function QR_CODE_IMG(ByVal urls As String) As String
        Dim code As String = urls
        Dim qrGenerator As New QRCoder.QRCodeGenerator()

        '  qrGenerator.CreateQrCode("", QRCodeGenerator.ECCLevel.L)
        Dim qrCode As QRCoder.QRCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.L)
        '    Dim imgBarCode As New System.Web.UI.WebControls.Image()
        '     imgBarCode.Height = 150
        '     imgBarCode.Width = 150
        '
        'QRCode qrCode = new QRCode(qrCodeData);
        Dim qrc As New QRCoder.QRCode(qrCode)
        Dim b64 As String = ""
        Dim bit As New System.Drawing.Bitmap("D:\FDA\FDA.png")
        'Using bitMap As Bitmap = qrc.GetGraphic(20)
        Using bitMap As Bitmap = qrc.GetGraphic(20, System.Drawing.Color.Black, System.Drawing.Color.White, bit, drawQuietZones:=False)
            Using ms As New MemoryStream()
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                Dim byteImage As Byte() = ms.ToArray()
                b64 = Convert.ToBase64String(byteImage)
                '     imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage)
            End Using
        End Using

        Return b64
    End Function
    <System.Runtime.CompilerServices.Extension()> _
    Public Function b64decode(ByVal StrDecode As String)
        Try
            Dim decodedString As String

            decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(StrDecode))

            Return decodedString
        Catch ex As Exception
            Return ""
        End Try


    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function Personal_Province(ByVal iden As String, ByVal IDgroup As Integer) As Integer
        Dim province_id As Integer = 0
        Dim dao As New DAO_PERMISSION.TB_taxnogrouppermission
        dao.GetDataby_IDgroup_and_Iden(IDgroup, iden)
        Try
            province_id = dao.fields.pvncd
        Catch ex As Exception

        End Try

        Return province_id
    End Function
    <System.Runtime.CompilerServices.Extension()> _
    Public Function Personal_Province_NEW(ByVal iden As String, tax_iden As String, ByVal IDgroup As String) As Integer
        Dim province_id As Integer = 0
        Dim ws As New WS_PVNCD.WebService1
        Dim group As Integer = 0

        Dim dt As New DataTable
        Try
            dt = ws.getStaffPvncd_by_citizenID_and_taxnoauthorize(iden, tax_iden, IDgroup)
        Catch ex As Exception

        End Try
        'If dt.Rows.Count = 0 Then
        '    province_id = 10

        'End If

        For Each dr As DataRow In dt.Rows
            Try
                province_id = dr("staff_pvncd")
            Catch ex As Exception
                province_id = 10
            End Try

        Next



        Return province_id
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Sub AddLogStatus(ByVal status_id As Integer, ByVal process_id As String, ByVal iden As String, Optional FK_IDA As Integer = 0)
        Try
            Dim dao As New DAO_DRUG.TB_LOG_STATUS
            dao.fields.IDENTIFY = iden
            dao.fields.PROCESS_ID = process_id
            dao.fields.STATUS_DATE = Date.Now
            dao.fields.STATUS_ID = status_id
            dao.fields.FK_IDA = FK_IDA
            dao.insert()
        Catch ex As Exception

        End Try

    End Sub
    <System.Runtime.CompilerServices.Extension>
    Public Sub AddLogStatustodrugimport(ByVal status_id As Integer, ByVal process_id As String, ByVal iden As String, Optional FK_IDA As Integer = 0)
        Try
            Dim dao As New DAO_DRUG_IMPORT.TB_LOG_STATUS_IMPORT       'เปลี่ยน ไป base drug import
            dao.fields.IDENTIFY = iden
            dao.fields.PROCESS_ID = process_id
            dao.fields.STATUS_DATE = Date.Now
            dao.fields.STATUS_ID = status_id
            dao.fields.FK_IDA = FK_IDA
            dao.insert()
        Catch ex As Exception

        End Try

    End Sub

    <System.Runtime.CompilerServices.Extension>
    Public Sub AddLogStatusnymimport(ByVal status_id As Integer, ByVal process_id As String, ByVal iden As String, Optional FK_IDA As Integer = 0)
        Try
            Dim dao As New DAO_DRUG_IMPORT.TB_LOG_STATUS_IMPORT
            dao.fields.IDENTIFY = iden
            dao.fields.PROCESS_ID = process_id
            dao.fields.STATUS_DATE = Date.Now
            dao.fields.STATUS_ID = status_id
            dao.fields.FK_IDA = FK_IDA
            dao.insert()
        Catch ex As Exception

        End Try

    End Sub

    <System.Runtime.CompilerServices.Extension> _
    Public Sub AddLogStatusEtracking(ByVal status_id As Integer, ByVal STATUS_TYPE As String, ByVal iden As String, ByVal description As String, ByVal PROCESS_NAME As String, _
                                     Optional FK_IDA As Integer = 0, Optional SUB_IDA As Integer = 0, Optional SUB_STATUS As Integer = 0, Optional url As String = "")
        Try
            Dim dao As New DAO_DRUG.TB_E_TRACKING_LOG
            dao.fields.CITIZEN_ID = iden
            dao.fields.STATUS_TYPE = STATUS_TYPE
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.HEAD_STATUS = status_id
            dao.fields.FK_IDA = FK_IDA
            dao.fields.EDIT_DESCRIPTION = description
            dao.fields.SUB_STATUS = SUB_STATUS
            dao.fields.PROCESS_NAME = PROCESS_NAME
            dao.fields.URL = url
            dao.insert()
        Catch ex As Exception

        End Try

    End Sub
    <System.Runtime.CompilerServices.Extension> _
    Public Sub AddLogMultiTab(ByVal iden As String, ByVal description As String, Optional FK_IDA As Integer = 0, Optional url As String = "")
        Try
            Dim dao As New DAO_DRUG.TB_LOG_MULTITAB
            dao.fields.CITIZEN_ID = iden
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.FK_IDA = FK_IDA
            dao.fields.DESCRIPTION = description
            dao.fields.URL = url
            dao.insert()
        Catch ex As Exception

        End Try

    End Sub
    <System.Runtime.CompilerServices.Extension> _
    Function EncodeBase64(ByVal original_txt As String) As String
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(original_txt)
        Dim strModified As String = ""
        strModified = Convert.ToBase64String(byt)

        Return strModified
    End Function

    <System.Runtime.CompilerServices.Extension> _
    Function Change_lcntpcd(ByVal lcntpcd As String) As String
        Dim Return_txt As String = ""
        If lcntpcd = "03" Then
            Return_txt = "ขจ"
        ElseIf lcntpcd = "04" Then
            Return_txt = "ขนจ"
        ElseIf lcntpcd = "05" Then
            Return_txt = "นจ"
        ElseIf lcntpcd = "06" Then
            Return_txt = "สวจ"
        ElseIf lcntpcd = "02" Then
            Return_txt = "ผจ"
        ElseIf lcntpcd = "12" Then
            Return_txt = "ผยส"
        ElseIf lcntpcd = "13" Then
            Return_txt = "จยส"
        ElseIf lcntpcd = "14" Then
            Return_txt = "นยส"
        ElseIf lcntpcd = "15" Then
            Return_txt = "สยส"
        Else
            Return_txt = lcntpcd
        End If
        Return Return_txt
    End Function
    <System.Runtime.CompilerServices.Extension> _
    Function DecodeBase64(ByVal Base64Text As String) As String
        Dim ede_byte As Byte() = System.Convert.FromBase64String(Base64Text)
        Dim txt As String = ""
        txt = System.Text.Encoding.UTF8.GetString(ede_byte)
        Return txt
    End Function
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub DropDownInsertDataFirstRow(ByRef Dropdown As DropDownList, ByVal Text As String, ByVal Value As String)
        Dropdown.Items.Insert(0, New ListItem(Text, Value))
        Dropdown.SelectedIndex = 0
    End Sub

    <System.Runtime.CompilerServices.Extension> _
    Function NumEng2Thai(strEng As String) As String
        Dim strThai As String = ""
        Dim strTemp As Byte
        Dim i As Byte
        'strEng = "258963147"
        For i = 1 To Len(strEng)
            If IsNumeric(Mid$(strEng, i, 1)) Then
                strTemp = Asc(Mid$(strEng, i, 1)) + 192
                strThai = strThai & Chr(strTemp)
            Else
                strThai = strThai & Mid$(strEng, i, 1) 'Chr(strTemp)
            End If

        Next
        NumEng2Thai = strThai
    End Function

    <System.Runtime.CompilerServices.Extension> _
    Sub Run_Service_LCN(ByVal IDA As Integer, ByVal citizen_id As String)
        Dim ws_update As New WS_DRUG.WS_DRUG
        ws_update.DRUG_UPDATE_LICEN(IDA, citizen_id)
    End Sub

    <System.Runtime.CompilerServices.Extension> _
    Sub insert_tabean_auto(ByVal FK_IDA As Integer)
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(FK_IDA)

        Dim dao_drrgt As New DAO_DRUG.ClsDBdrrgt
        With dao_drrgt.fields
            .accttp = dao.fields.accttp
            .appdate = dao.fields.appdate
            .CHK_LCN_SUBTYPE1 = dao.fields.CHK_LCN_SUBTYPE1
            .CHK_LCN_SUBTYPE2 = dao.fields.CHK_LCN_SUBTYPE2
            .CHK_LCN_SUBTYPE3 = dao.fields.CHK_LCN_SUBTYPE3
            .classcd = dao.fields.classcd
            .CONSIDER_DATE = dao.fields.CONSIDER_DATE
            .ctgcd = dao.fields.ctgcd
            .CTZNO = dao.fields.CTZNO
            .drgbiost = dao.fields.drgbiost
            .drgexpst = dao.fields.drgexpst
            .drgnewst = dao.fields.drgnewst
            Try
                .rcptpayst = dao.fields.dvcd
            Catch ex As Exception

            End Try
            'Try
            '    .drgtpcd = ddl_tabean_group.SelectedValue 'dao.fields.drgtpcd
            'Catch ex As Exception

            'End Try
            Try
                If dao.fields.rgttpcd <> "G" And dao.fields.rgttpcd <> "H" And dao.fields.rgttpcd <> "K" Then
                    If CDate(dao.fields.appdate).ToString("yyyy/MM/dd") >= "2562/01/01" And CDate(dao.fields.appdate).ToString("yyyy/MM/dd") <= "2562/10/12" Then
                        .expdate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 9, CDate(dao.fields.appdate)))
                    ElseIf CDate(dao.fields.appdate).ToString("yyyy/MM/dd") > "2562/10/12" Then
                        .expdate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 7, CDate(dao.fields.appdate)))
                    End If

                Else
                    If CDate(dao.fields.appdate) >= "2562/01/01" And CDate(dao.fields.appdate).ToString("yyyy/MM/dd") <= "2562/06/28" Then
                        .expdate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 9, CDate(dao.fields.appdate)))
                    ElseIf CDate(dao.fields.appdate).ToString("yyyy/MM/dd") > "2562/06/28" Then
                        .expdate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 5, CDate(dao.fields.appdate)))
                    End If
                End If

            Catch ex As Exception

            End Try


            .DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            .dsgcd = dao.fields.dsgcd
            .engdrgnm = dao.fields.engdrgnm
            .EXTEND_DATE = dao.fields.EXTEND_DATE
            .FIRST_APP_DATE = dao.fields.FIRST_APP_DATE
            .FK_DOSAGE_FORM = dao.fields.FK_DOSAGE_FORM
            .FK_DRRQT = FK_IDA
            .FK_IDA = dao.fields.FK_IDA
            .FK_LCN_IDA = dao.fields.FK_LCN_IDA
            .FK_STAFF_OFFER_IDA = dao.fields.FK_STAFF_OFFER_IDA
            .frtappdate = dao.fields.FIRST_APP_DATE
            .IDENTIFY = dao.fields.IDENTIFY
            .kindcd = dao.fields.kindcd
            .lcnabbr = dao.fields.lcnabbr
            .UNIT_NORMAL = dao.fields.UNIT_NORMAL
            .DRUG_PACKING = dao.fields.DRUG_PACKING
            .UNIT_BIO = dao.fields.UNIT_BIO
            .DRUG_STYLE = dao.fields.DRUG_STYLE
            .DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            Try
                .lcnno = dao.fields.lcnno
            Catch ex As Exception

            End Try

            .lcnscd = dao.fields.lcnscd
            .lcnsid = dao.fields.lcnsid
            .lcntpcd = dao.fields.lcntpcd
            .lctcd = dao.fields.lctcd
            .lctnmcd = dao.fields.lctnmcd
            Try
                .lmdfdate = dao.fields.lmdfdate
            Catch ex As Exception

            End Try

            .lpvncd = dao.fields.lpvncd
            .lstfcd = dao.fields.lstfcd
            .ndrgtp = dao.fields.ndrgtp
            .packcd = dao.fields.packcd
            .potency = dao.fields.potency
            .PROCESS_ID = dao.fields.PROCESS_ID
            .pvnabbr = dao.fields.pvnabbr
            .pvncd = dao.fields.pvncd
            .pvnabbr2 = dao.fields.pvnabbr2
            .USE_PVNABBR2 = dao.fields.USE_PVNABBR2
            Try
                .rcvdate = dao.fields.rcvdate
            Catch ex As Exception

            End Try

            .rcvno = dao.fields.rcvno
            .REGIST_TYPE = dao.fields.REGIST_TYPE
            .REMARK = dao.fields.REMARK
            .rgtno = dao.fields.rgtno
            Try
                .rgttpcd = dao.fields.rgttpcd
                '.rgttpcd = ddl_rgttpcd.SelectedValue
            Catch ex As Exception

            End Try
            Try
                .drgtpcd = dao.fields.drgtpcd
            Catch ex As Exception

            End Try
            .STAFF_APP_IDENTIFY = dao.fields.STAFF_APP_IDENTIFY
            .STATUS_ID = dao.fields.STATUS_ID
            .TABEAN_TYPE = dao.fields.TABEAN_TYPE
            .thadrgnm = dao.fields.thadrgnm
            .TR_ID = dao.fields.TR_ID
            Try
                .UNIT_BIO = dao.fields.UNIT_BIO
            Catch ex As Exception

            End Try
            Try
                .UNIT_NORMAL = dao.fields.UNIT_NORMAL
            Catch ex As Exception

            End Try
            Try
                .DRUG_PACKING = dao.fields.DRUG_PACKING
            Catch ex As Exception

            End Try
            Try
                .TYPE_REQUEST_ID = dao.fields.TYPE_REQUEST_ID
            Catch ex As Exception

            End Try
            Try
                .DRUG_STRENGTH = dao.fields.DRUG_STRENGTH
            Catch ex As Exception

            End Try
        End With
        dao_drrgt.insert()
        Dim IDA_rgt As Integer = dao_drrgt.fields.IDA



        Dim bao_insert_addr As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            dt = bao_insert_addr.SP_DRRGT_ADDR_INSERT(IDA_rgt)
        Catch ex As Exception

        End Try

        Dim dao_atc As New DAO_DRUG.TB_DRRQT_ATC_DETAIL
        dao_atc.GetDataby_FK_IDA(FK_IDA)
        For Each dao_atc.fields In dao_atc.datas
            Dim dao_rgt_atc As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
            With dao_rgt_atc.fields
                .ATC_CODE = dao_atc.fields.ATC_CODE
                .ATC_IDA = dao_atc.fields.ATC_IDA
                .FK_IDA = IDA_rgt
            End With
            dao_rgt_atc.insert()
        Next


        Dim dao_cas As New DAO_DRUG.TB_DRRQT_DETAIL_CAS
        dao_cas.GetDataby_FK_IDA(FK_IDA)
        For Each dao_cas.fields In dao_cas.datas
            Dim dao_rgt_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            With dao_rgt_cas.fields
                .AORI = dao_cas.fields.AORI
                .BASE_FORM = dao_cas.fields.BASE_FORM
                .EQTO_IOWA = dao_cas.fields.EQTO_IOWA
                .EQTO_QTY = dao_cas.fields.EQTO_QTY
                .EQTO_SUNITCD = dao_cas.fields.EQTO_SUNITCD
                .FK_IDA = IDA_rgt
                .FK_SET = dao_cas.fields.FK_SET
                .IOWA = dao_cas.fields.IOWA
                .QTY = dao_cas.fields.QTY
                .ROWS = dao_cas.fields.ROWS
                .SUNITCD = dao_cas.fields.SUNITCD
            End With
            dao_rgt_cas.insert()

            Dim dao_eq As New DAO_DRUG.TB_DRRQT_EQTO
            dao_eq.GetDataby_FK_IDA(dao_cas.fields.IDA)
            For Each dao_eq.fields In dao_eq.datas
                Dim dao_eq_rgt As New DAO_DRUG.TB_DRRGT_EQTO
                With dao_eq_rgt.fields
                    .FK_IDA = dao_rgt_cas.fields.IDA
                    .IOWA = dao_eq.fields.IOWA
                    .MULTIPLY = dao_eq.fields.MULTIPLY
                    .QTY = dao_eq.fields.QTY
                    .ROWS = dao_eq.fields.ROWS
                    .STR_VALUE = dao_eq.fields.STR_VALUE
                    .SUNITCD = dao_eq.fields.SUNITCD
                    .FK_SET = dao_eq.fields.FK_SET
                    .FK_DRRQT_IDA = IDA_rgt
                End With
                dao_eq_rgt.insert()
            Next
        Next


        Dim dao_pack As New DAO_DRUG.TB_DRRQT_PACKAGE_DETAIL
        dao_pack.GetDataby_FKIDA(FK_IDA)
        For Each dao_pack.fields In dao_pack.datas
            Dim dao_rgt_pack As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            With dao_rgt_pack.fields
                .BARCODE = dao_pack.fields.BARCODE
                .BIG_UNIT = dao_pack.fields.BIG_UNIT
                .CHECK_PACKAGE = dao_pack.fields.CHECK_PACKAGE
                .FK_IDA = IDA_rgt
                .MEDIUM_AMOUNT = dao_pack.fields.MEDIUM_AMOUNT
                .MEDIUM_UNIT = dao_pack.fields.MEDIUM_UNIT
                .SMALL_AMOUNT = dao_pack.fields.SMALL_AMOUNT
                .SMALL_UNIT = dao_pack.fields.SMALL_UNIT
            End With
            dao_rgt_pack.insert()
        Next


        Dim dao_pro As New DAO_DRUG.TB_DRRQT_PRODUCER
        dao_pro.GetDataby_FK_IDA(FK_IDA)
        For Each dao_pro.fields In dao_pro.datas
            Dim dao_rgt_pro As New DAO_DRUG.TB_DRRGT_PRODUCER
            With dao_rgt_pro.fields
                .addr_ida = dao_pro.fields.addr_ida
                .drgtpcd = dao_pro.fields.drgtpcd
                .FK_IDA = IDA_rgt
                .FK_PRODUCER = dao_pro.fields.FK_PRODUCER
                .frgncd = dao_pro.fields.frgncd
                .frgnlctcd = dao_pro.fields.frgnlctcd
                .funccd = dao_pro.fields.funccd
                .lcnno = dao_pro.fields.lcnno
                .lcntpcd = dao_pro.fields.lcntpcd
                .PRODUCER_WORK_TYPE = dao_pro.fields.PRODUCER_WORK_TYPE
                .pvncd = dao_pro.fields.pvncd
                .rcvno = dao_pro.fields.rcvno
                .REFERENCE_GMP = dao_pro.fields.REFERENCE_GMP
                .rgtno = dao_pro.fields.rgtno
                .rgttpcd = dao_pro.fields.rgttpcd
                .TR_ID = dao_pro.fields.TR_ID
            End With
            dao_rgt_pro.insert()
        Next


        Dim dao_pro_in As New DAO_DRUG.TB_DRRQT_PRODUCER_IN
        dao_pro_in.GetDataby_FK_IDA(FK_IDA)
        For Each dao_pro_in.fields In dao_pro_in.datas
            Dim dao_rgt_pro_in As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
            With dao_rgt_pro_in.fields
                .drgtpcd = dao_pro_in.fields.drgtpcd
                .FK_IDA = IDA_rgt
                .funccd = dao_pro_in.fields.funccd
                .lcnno = dao_pro_in.fields.lcnno
                .lcntpcd = dao_pro_in.fields.lcntpcd
                .rgtno = dao_pro_in.fields.rgtno
                .rgttpcd = dao_pro_in.fields.rgttpcd
                .FK_LCN_IDA = dao_pro_in.fields.FK_LCN_IDA
                .rgtno = dao_pro_in.fields.rgtno
                .rgttpcd = dao_pro_in.fields.rgttpcd
                .lctcd = dao_pro_in.fields.lctcd
                .lcnsid = dao_pro_in.fields.lcnsid
            End With
            dao_rgt_pro_in.insert()
        Next


        Dim dao_prop As New DAO_DRUG.TB_DRRQT_PROPERTIES
        dao_prop.GetDataby_FKIDA(FK_IDA)
        For Each dao_prop.fields In dao_prop.datas
            Dim dao_rgt_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES
            With dao_rgt_prop.fields
                .CHK_DRUG_PROPERTIES = dao_prop.fields.CHK_DRUG_PROPERTIES
                .CHK_DRUG_PROPERTIES_OTHER = dao_prop.fields.CHK_DRUG_PROPERTIES_OTHER
                .DRUG_PROPERTIES = dao_prop.fields.DRUG_PROPERTIES
                .DRUG_PROPERTIES_OTHER = dao_prop.fields.DRUG_PROPERTIES_OTHER
                .FK_IDA = IDA_rgt
            End With
            dao_rgt_prop.insert()
        Next


        Dim dao_prop_det As New DAO_DRUG.TB_DRRQT_PROPERTIES_AND_DETAIL
        dao_prop_det.GetDataby_FKIDA(FK_IDA)
        For Each dao_prop_det.fields In dao_prop_det.datas
            Dim dao_rgt_pd As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
            With dao_rgt_pd.fields
                .DRUG_PROPERTIES_AND_DETAIL = dao_prop_det.fields.DRUG_PROPERTIES_AND_DETAIL
                .FK_IDA = IDA_rgt
                .OTHER = dao_prop_det.fields.OTHER
                .ROWS = dao_prop_det.fields.ROWS
            End With
            dao_rgt_pd.insert()
        Next

        Dim dao_each As New DAO_DRUG.TB_DRRQT_EACH
        dao_each.GetDataby_FK_IDA(FK_IDA)
        For Each dao_each.fields In dao_each.datas
            Dim dao_each_rgt As New DAO_DRUG.TB_DRRGT_EACH
            With dao_each_rgt.fields
                .EACH_AMOUNT = dao_each.fields.EACH_AMOUNT
                .FK_IDA = IDA_rgt
                .sunitcd = dao_each.fields.sunitcd
            End With
            dao_each_rgt.insert()
        Next
        '
        Dim dao_keep As New DAO_DRUG.TB_DRRQT_KEEP_DRUG
        dao_keep.GetDataby_FKIDA(FK_IDA)
        For Each dao_keep.fields In dao_keep.datas
            Dim dao_keep_rgt As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
            With dao_keep_rgt.fields
                .AGE_DAY = dao_keep.fields.AGE_DAY
                .FK_IDA = IDA_rgt
                .AGE_HOUR = dao_keep.fields.AGE_HOUR
                .AGE_MONTH = dao_keep.fields.AGE_MONTH
                .DRUG_DETAIL = dao_keep.fields.DRUG_DETAIL
                .KEEP_DESCRIPTION = dao_keep.fields.KEEP_DESCRIPTION
                .TEMPERATE1 = dao_keep.fields.TEMPERATE1
                .TEMPERATE2 = dao_keep.fields.TEMPERATE2
            End With
            dao_keep_rgt.insert()
        Next

        Dim dao_dtb As New DAO_DRUG.TB_DRRQT_DTB
        dao_dtb.GetDataby_FKIDA(FK_IDA)
        For Each dao_dtb.fields In dao_dtb.datas
            Dim dao_dtb_rgt As New DAO_DRUG.TB_DRRGT_DTB
            With dao_dtb_rgt.fields
                .FK_IDA = IDA_rgt
                .FK_LCN_IDA = dao_dtb.fields.FK_LCN_IDA
            End With
            dao_dtb_rgt.insert()
        Next

        'DRRGT_DTL_TEXT
        Dim dao_dtl As New DAO_DRUG.TB_DRRQT_DTL_TEXT
        dao_dtl.GetDataby_FKIDA(FK_IDA)
        For Each dao_dtl.fields In dao_dtl.datas
            Dim dao_dtl_rqt As New DAO_DRUG.TB_DRRGT_DTL_TEXT
            With dao_dtl_rqt.fields
                .drgtpcd = dao_dtl.fields.drgtpcd
                .FK_IDA = IDA_rgt
                .dtl = dao_dtl.fields.dtl
                .engdrgtpnm = dao_dtl.fields.engdrgtpnm
                .keepdesc = dao_dtl.fields.keepdesc
                .pcksize = dao_dtl.fields.pcksize
                .pvncd = dao_dtl.fields.pvncd
                .rgtno = dao_dtl.fields.rgtno
                .rgttpcd = dao_dtl.fields.rgttpcd
                .tphigh = dao_dtl.fields.tphigh
                .tplow = dao_dtl.fields.tplow
                .U1_CODE = dao_dtl.fields.U1_CODE
                .useage = dao_dtl.fields.useage
            End With
            dao_dtl_rqt.insert()
        Next


        Dim dao_color As New DAO_DRUG.TB_DRRQT_COLOR
        dao_color.GetDataby_FK_IDA(FK_IDA)
        For Each dao_color.fields In dao_color.datas
            Dim dao_color_rqt As New DAO_DRUG.TB_DRRGT_COLOR
            With dao_color_rqt.fields
                .COLOR_NAME1 = dao_color.fields.COLOR_NAME1
                .FK_IDA = IDA_rgt
                .COLOR_NAME2 = dao_color.fields.COLOR_NAME2
                .COLOR_NAME3 = dao_color.fields.COLOR_NAME3
                .COLOR_NAME4 = dao_color.fields.COLOR_NAME4
                .COLOR1 = dao_color.fields.COLOR1
                .COLOR2 = dao_color.fields.COLOR2
                .COLOR3 = dao_color.fields.COLOR3
                .COLOR4 = dao_color.fields.COLOR4
            End With
            dao_color_rqt.insert()
        Next


        Dim bao_addr As New BAO_SHOW
        Dim dt22 As New DataTable
        dt22 = bao_addr.SP_DRRGT_ADDR_INSERT_V2(IDA_rgt)


        Dim dao_ani_rq As New DAO_DRUG.ClsDBdrramldrg
        dao_ani_rq.GetData_by_FK_IDA(FK_IDA)
        For Each dao_ani_rq.fields In dao_ani_rq.datas
            Dim dao_ani_rg As New DAO_DRUG.ClsDBdrramldrg
            With dao_ani_rg.fields
                .amlsubcd = dao_ani_rq.fields.amlsubcd
                .amltpcd = dao_ani_rq.fields.amltpcd
                .drgtpcd = dao_ani_rq.fields.drgtpcd
                .FK_IDA = IDA_rgt
                .pvncd = dao_ani_rq.fields.pvncd
                .rgtno = dao_ani_rq.fields.rgtno
                .rgttpcd = dao_ani_rq.fields.rgttpcd
                .usetpcd = dao_ani_rq.fields.usetpcd
            End With
            dao_ani_rg.insert()
        Next

        Dim dao_aniuse_rq As New DAO_DRUG.ClsDBdrramluse
        dao_aniuse_rq.GetDatabyFKIDA(FK_IDA)
        For Each dao_aniuse_rq.fields In dao_aniuse_rq.datas
            Dim dao_aniuse_rg As New DAO_DRUG.ClsDBdrramluse
            With dao_aniuse_rg.fields
                .amlsubcd = dao_aniuse_rg.fields.amlsubcd
                .amltpcd = dao_aniuse_rg.fields.amltpcd
                .drgtpcd = dao_aniuse_rg.fields.drgtpcd
                .FK_IDA = IDA_rgt
                .pvncd = dao_aniuse_rg.fields.pvncd
                .rgtno = dao_aniuse_rg.fields.rgtno
                .rgttpcd = dao_aniuse_rg.fields.rgttpcd
                .usetpcd = dao_aniuse_rg.fields.usetpcd
                .rcvno = dao_aniuse_rg.fields.rcvno
                .nouse = dao_aniuse_rg.fields.nouse
                .packuse = dao_aniuse_rg.fields.packuse
                .pvncd = dao_aniuse_rg.fields.pvncd
                .STOP_UNIT1 = dao_aniuse_rg.fields.STOP_UNIT1
                .STOP_UNIT2 = dao_aniuse_rg.fields.STOP_UNIT2
                .STOP_VALUE1 = dao_aniuse_rg.fields.STOP_VALUE1
                .STOP_VALUE2 = dao_aniuse_rg.fields.STOP_VALUE2
                .stpdrg = dao_aniuse_rg.fields.stpdrg
                .stpdrgcd = dao_aniuse_rg.fields.stpdrgcd
                .usetpcd = dao_aniuse_rg.fields.usetpcd
            End With
            dao_aniuse_rg.insert()
        Next
    End Sub
End Module
