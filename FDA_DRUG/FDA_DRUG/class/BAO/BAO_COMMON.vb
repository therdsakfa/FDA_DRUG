Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml
Imports FDA_DRUG.XML_CENTER

Module BAO_COMMON
    Public _PATH_FILE_DRUG As String = System.Configuration.ConfigurationManager.AppSettings("PATH_FILE_DRUG")
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub DropDownSelectData(ByRef Dropdown As DropDownList, ByVal Value As String)
        '   Dropdown.DataBind()
        For Each LT As ListItem In Dropdown.Items
            If LT.Value = Value Then
                LT.Selected = True
            Else
                LT.Selected = False
            End If
        Next
    End Sub
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub DropDownSelectText(ByRef Dropdown As DropDownList, ByVal Value As String)
        '   Dropdown.DataBind()
        For Each LT As ListItem In Dropdown.Items
            If LT.Text = Value Then
                LT.Selected = True
            Else
                LT.Selected = False
            End If
        Next
    End Sub
    Public _PATH_DEFALUT As String = System.Configuration.ConfigurationManager.AppSettings("PATH_DEFALUT")




    ''' <summary>
    ''' ใช้สำหรับการสร้างชื่อ File PDF
    ''' </summary>
    ''' <param name="SYS"></param>
    ''' <param name="PROSESS_ID"></param>
    ''' <param name="YEAR"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NAME_PDF_DOWNLOAD(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal DOWNLOAD_ID As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & con_year(YEAR) & "-" & DOWNLOAD_ID & ".pdf"
        Return filename
    End Function


    Public Function NAME_XML_DOWNLOAD(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal DOWNLOAD_ID As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & con_year(YEAR) & "-" & DOWNLOAD_ID & ".xml"

        Return filename
    End Function


    Public Function NAME_UPLOAD_PDF(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String

        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & con_year(YEAR) & "-" & ID_TRANSECTION_UPLOAD & ".pdf"
        Return filename
    End Function

    Public Function NAME_UPLOAD_XML(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String

        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & con_year(YEAR) & "-" & ID_TRANSECTION_UPLOAD & ".xml"

        Return filename
    End Function

    Public Function NAME_DOWNLOAD_PDF(ByVal SYS As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
        Dim filename As String = SYS & "-" & ID_TRANSECTION_UPLOAD & ".pdf"

        Return filename
    End Function

    Public Function NAME_DOWNLOAD_XML(ByVal SYS As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
        Dim filename As String = SYS & "-" & ID_TRANSECTION_UPLOAD & ".xml"

        Return filename
    End Function

    Public Function NAME_OLD_PDF(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal ID As String) As String
        Dim filename As String = SYS & "-old-" & PROSESS_ID & "-" & ID & ".pdf"

        Return filename
    End Function

    Public Function NAME_OUTPUT_PDF(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & con_year(YEAR) & "-" & ID_TRANSECTION_UPLOAD & "-output.pdf"

        Return filename
    End Function

    Public Function NAME_ATT_PDF(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String, ByVal TYPE_FILE As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & con_year(YEAR) & "-" & ID_TRANSECTION_UPLOAD & "-" & TYPE_FILE & ".pdf"

        Return filename
    End Function


    ''' <summary>
    ''' ใช้สำหรับสร้างชื่อ TRANCESTION
    ''' </summary>
    ''' <param name="SYS"></param>
    ''' <param name="PROSESS_ID"></param>
    ''' <param name="YEAR"></param>
    ''' <param name="ID_TRANSECTION_UPLOAD"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NAME_TRANCESTION(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & con_year(YEAR) & "-" & ID_TRANSECTION_UPLOAD
        Return filename
    End Function




    Public Function LOAD_XML()


    End Function

    Private _p_cer As New CLASS_CER
    Public Property p_cer() As CLASS_CER
        Get
            Return _p_cer
        End Get
        Set(ByVal value As CLASS_CER)
            _p_cer = value
        End Set
    End Property
    Private _p_cerf As New CLASS_CER_FOREIGN
    Public Property p_cerf() As CLASS_CER_FOREIGN
        Get
            Return _p_cerf
        End Get
        Set(ByVal value As CLASS_CER_FOREIGN)
            _p_cerf = value
        End Set
    End Property
    Private _p_dh As New CLASS_DH
    Public Property p_dh() As CLASS_DH
        Get
            Return _p_dh
        End Get
        Set(ByVal value As CLASS_DH)
            _p_dh = value
        End Set
    End Property
    Private _p_rgt_edt As New CLASS_EDIT_DRRGT
    Public Property p_rgt_edt() As CLASS_EDIT_DRRGT
        Get
            Return _p_rgt_edt
        End Get
        Set(ByVal value As CLASS_EDIT_DRRGT)
            _p_rgt_edt = value
        End Set
    End Property
    Private _p_dp As New CLASS_DP
    Public Property p_dp() As CLASS_DP
        Get
            Return _p_dp
        End Get
        Set(ByVal value As CLASS_DP)
            _p_dp = value
        End Set
    End Property
    Private _p_di As New CLASS_DI
    Public Property p_di() As CLASS_DI
        Get
            Return _p_di
        End Get
        Set(ByVal value As CLASS_DI)
            _p_di = value
        End Set
    End Property
    Private _p_lcn As New CLASS_DALCN
    Public Property p_lcn() As CLASS_DALCN
        Get
            Return _p_lcn
        End Get
        Set(ByVal value As CLASS_DALCN)
            _p_lcn = value
        End Set
    End Property

    Private _p_dr As New CLASS_DR
    Public Property p_dr() As CLASS_DR
        Get
            Return _p_dr
        End Get
        Set(ByVal value As CLASS_DR)
            _p_dr = value
        End Set
    End Property
    Private _p_ds As New CLASS_DS
    Public Property p_ds() As CLASS_DS
        Get
            Return _p_ds
        End Get
        Set(ByVal value As CLASS_DS)
            _p_ds = value
        End Set
    End Property
    Private _p_lcnre As New CLASS_LCNREQUEST
    Public Property p_lcnre() As CLASS_LCNREQUEST
        Get
            Return _p_lcnre
        End Get
        Set(ByVal value As CLASS_LCNREQUEST)
            _p_lcnre = value
        End Set
    End Property
    Private _p_dalcn As New XML_CENTER.CLASS_DALCN
    Public Property p_dalcn() As XML_CENTER.CLASS_DALCN
        Get
            Return _p_dalcn
        End Get
        Set(ByVal value As XML_CENTER.CLASS_DALCN)
            _p_dalcn = value
        End Set
    End Property
    Private _p_noryormor2 As New CLASS_NYM_2
    Public Property p_noryormor2() As CLASS_NYM_2
        Get
            Return _p_noryormor2
        End Get
        Set(ByVal value As CLASS_NYM_2)
            _p_noryormor2 = value
        End Set
    End Property
    Private _p_noryormor3 As New CLASS_NYM_3_SM
    Public Property p_noryormor3() As CLASS_NYM_3_SM
        Get
            Return _p_noryormor3
        End Get
        Set(ByVal value As CLASS_NYM_3_SM)
            _p_noryormor3 = value
        End Set
    End Property
    Private _p_noryormor4 As New CLASS_NYM_4_SM
    Public Property p_noryormor4() As CLASS_NYM_4_SM
        Get
            Return _p_noryormor4
        End Get
        Set(ByVal value As CLASS_NYM_4_SM)
            _p_noryormor4 = value
        End Set
    End Property
    Private _p_dalcn_sub As New XML_CENTER.CLASS_DALCN_NCT_SUBSTITUTE
    Public Property p_dalcn_sub() As XML_CENTER.CLASS_DALCN_NCT_SUBSTITUTE
        Get
            Return _p_dalcn_sub
        End Get
        Set(ByVal value As XML_CENTER.CLASS_DALCN_NCT_SUBSTITUTE)
            _p_dalcn_sub = value
        End Set
    End Property
    Private _p_dalcn_rqt As New XML_CENTER.CLASS_DALCN_EDIT_REQUEST
    Public Property p_dalcn_rqt() As XML_CENTER.CLASS_DALCN_EDIT_REQUEST
        Get
            Return _p_dalcn_rqt
        End Get
        Set(ByVal value As XML_CENTER.CLASS_DALCN_EDIT_REQUEST)
            _p_dalcn_rqt = value
        End Set
    End Property
    Private _p_REGISTRATION As New CLASS_REGISTRATION
    Public Property p_REGISTRATION() As CLASS_REGISTRATION
        Get
            Return _p_REGISTRATION
        End Get
        Set(ByVal value As CLASS_REGISTRATION)
            _p_REGISTRATION = value
        End Set
    End Property
    Private _p_LOCATION As New CLS_LOCATION
    Public Property p_LOCATION() As CLS_LOCATION
        Get
            Return _p_LOCATION
        End Get
        Set(ByVal value As CLS_LOCATION)
            _p_LOCATION = value
        End Set
    End Property

    Private _p_DRUG_CONSIDER_REQUESTS As New XML_CONSIDER_REQUESTS
    Public Property p_DRUG_CONSIDER_REQUESTS() As XML_CONSIDER_REQUESTS
        Get
            Return _p_DRUG_CONSIDER_REQUESTS
        End Get
        Set(ByVal value As XML_CONSIDER_REQUESTS)
            _p_DRUG_CONSIDER_REQUESTS = value
        End Set
    End Property
    Private _p_drsamp As New CLASS_DRSAMP
    Public Property p_drsamp() As CLASS_DRSAMP
        Get
            Return _p_drsamp
        End Get
        Set(ByVal value As CLASS_DRSAMP)
            _p_drsamp = value
        End Set
    End Property
    Private _p_nym1 As New CLASS_PROJECT_SUM
    Public Property p_nym1() As CLASS_PROJECT_SUM
        Get
            Return _p_nym1
        End Get
        Set(ByVal value As CLASS_PROJECT_SUM)
            _p_nym1 = value
        End Set
    End Property
    Private _extend As New CLASS_EXTEND
    Public Property extend() As CLASS_EXTEND
        Get
            Return _extend
        End Get
        Set(ByVal value As CLASS_EXTEND)
            _extend = value
        End Set
    End Property
    Private _p_DRRGT_SUBSTITUTE As New CLASS_DRRGT_SUB
    Public Property p_DRRGT_SUBSTITUTE() As CLASS_DRRGT_SUB
        Get
            Return _p_DRRGT_SUBSTITUTE
        End Get
        Set(ByVal value As CLASS_DRRGT_SUB)
            _p_DRRGT_SUBSTITUTE = value
        End Set
    End Property

    Private _p_SPC As New CLASS_DRRGT_SPC
    Public Property p_SPC() As CLASS_DRRGT_SPC
        Get
            Return _p_SPC
        End Get
        Set(ByVal value As CLASS_DRRGT_SPC)
            _p_SPC = value
        End Set
    End Property

    Private _p_PI As New CLASS_DRRGT_PI
    Public Property p_PI() As CLASS_DRRGT_PI
        Get
            Return _p_PI
        End Get
        Set(ByVal value As CLASS_DRRGT_PI)
            _p_PI = value
        End Set
    End Property
    Private _p_PIL As New CLASS_DRRGT_PIL
    Public Property p_PIL() As CLASS_DRRGT_PIL
        Get
            Return _p_PIL
        End Get
        Set(ByVal value As CLASS_DRRGT_PIL)
            _p_PIL = value
        End Set
    End Property

    Private _p_temp_nct As New CLASS_TEMP_NCT_DALCN
    Public Property p_temp_nct() As CLASS_TEMP_NCT_DALCN
        Get
            Return _p_temp_nct
        End Get
        Set(ByVal value As CLASS_TEMP_NCT_DALCN)
            _p_temp_nct = value
        End Set
    End Property
    ''' <summary>
    ''' ProcessID 
    ''' 1 = สถานที่
    ''' 5 = สบ 5
    ''' </summary>
    ''' <param name="PATH_XML">ที่อยู่ XML ที่ต้องใช้</param>
    ''' <param name="PATH_PDF_TEMPLATE">ที่อยู่ PDF TEMPLATE ที่ต้องใช้</param>
    ''' <param name="PROSESS_ID">รหัส Process</param>
    ''' <param name="PATH_PDF_OUTPUT">PDF ที่ต้องออกมาใช้งาน</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LOAD_XML_PDF(ByVal PATH_XML As String, ByVal PATH_PDF_TEMPLATE As String, ByVal PROSESS_ID As String, PATH_PDF_OUTPUT As String, Optional filename As String = "", Optional ByVal SUBSTITUTE As String = "", Optional STATUS_ID As String = "", Optional temps As String = "") As String

        If Checkfile(PATH_PDF_OUTPUT) = False Then
            'ตรวจสอบว่ามี XML มั้ย
            If Checkfile(PATH_XML) = False Then
                If PROSESS_ID = 101 Or PROSESS_ID = 102 Or PROSESS_ID = 103 _
                    Or PROSESS_ID = 104 Or PROSESS_ID = 105 Or PROSESS_ID = 106 _
                    Or PROSESS_ID = 107 Or PROSESS_ID = 108 Or PROSESS_ID = 109 Then 'คือสถานที่
                    'ส่ง PATH_XML ไป GEN XML
                    Dim cls_xml As New CLASS_GEN_XML.DALCN
                    cls_xml.GEN_XML_DALCN(PATH_XML, p_dalcn)
                ElseIf PROSESS_ID = 11103 Or PROSESS_ID = 11104 Then
                    Dim cls_xml As New CLASS_GEN_XML.DALCN_EDIT_REQUEST
                    cls_xml.GEN_XML_DALCN_EDT(PATH_XML, p_dalcn_rqt)
                ElseIf PROSESS_ID = 100766 Or PROSESS_ID = 100767 Or PROSESS_ID = 100768 Or PROSESS_ID = 100769 Or PROSESS_ID = 100770 Or PROSESS_ID = 100771 Or PROSESS_ID = 100772 Or PROSESS_ID = 100773 Then
                    Dim cls_xml As New CLASS_GEN_XML.DALCN_NCT_SUB
                    cls_xml.GEN_XML_DALCN_SUB(PATH_XML, p_dalcn_sub)
                ElseIf PROSESS_ID = 1 Or PROSESS_ID = 2 Or PROSESS_ID = 3 _
                Or PROSESS_ID = 4 Or PROSESS_ID = 5 Then 'นยม
                    Dim cls_xml As New CLASS_GEN_XML.DI
                    cls_xml.GEN_XML_DI(PATH_XML, p_di)

                ElseIf PROSESS_ID = 31 Or PROSESS_ID = 32 Or PROSESS_ID = 33 _
                Or PROSESS_ID = 34 Or PROSESS_ID = 35 Or PROSESS_ID = 36 Then 'cer
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_CER(PATH_XML, p_cer)

                ElseIf PROSESS_ID = 7 Then 'ยาตัวอย่าง
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_DS(PATH_XML, p_ds)

                ElseIf PROSESS_ID = 8 Then 'Placebo
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_DP(PATH_XML, p_dp)

                ElseIf PROSESS_ID = 9 Or PROSESS_ID = 19 Then 'บัญชีรายการ
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_REGISTRATION(PATH_XML, p_REGISTRATION)
                ElseIf PROSESS_ID = 130001 Or PROSESS_ID = 130002 Then 'บัญชีรายการ
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_REGISTRATION(PATH_XML, p_REGISTRATION)
                ElseIf PROSESS_ID = 10 Then ' ขออนุญาตผลิตภัณฑ์ยา
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_DR(PATH_XML, p_dr)
                ElseIf PROSESS_ID = 11 Then ' ทะเบียนยา
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_DR(PATH_XML, p_dr)
                    '
                ElseIf PROSESS_ID = 1200001 Or PROSESS_ID = 1200002 Or PROSESS_ID = 1200003 Or PROSESS_ID = 1200004 Or PROSESS_ID = 1200005 Or PROSESS_ID = 1200006 _
                   Or PROSESS_ID = 1200007 Or PROSESS_ID = 1200008 Or PROSESS_ID = 1200009 Or PROSESS_ID = 1200010 Or PROSESS_ID = 1200011 Or PROSESS_ID = 1200012 Or PROSESS_ID = 1200013 _
                   Or PROSESS_ID = 1200014 Or PROSESS_ID = 1200015 Or PROSESS_ID = 1200016 Or PROSESS_ID = 1200017 Or PROSESS_ID = 1200018 Then ' ทะเบียนยา
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_DR(PATH_XML, p_dr)
                ElseIf PROSESS_ID = "1007411" Or PROSESS_ID = "1007412" Or PROSESS_ID = "1007413" Or PROSESS_ID = "1007414" Or PROSESS_ID = "1007421" Or PROSESS_ID = "1007431" Or PROSESS_ID = "1007441" _
                     Or PROSESS_ID = "1007442" Or PROSESS_ID = "1007443" Or PROSESS_ID = "1007491" Or PROSESS_ID = "1007492" Or PROSESS_ID = "1007493" _
                    Or PROSESS_ID = "1007494" Or PROSESS_ID = "1007471" Or PROSESS_ID = "1007451" Or PROSESS_ID = "1007495" Or PROSESS_ID = "1007461" Or PROSESS_ID = "1007481" Or PROSESS_ID = "100753" Or PROSESS_ID = "100752" Or PROSESS_ID = "100754" Or PROSESS_ID = "100755" Then
                    Dim cls_xml As New CLASS_GEN_XML.EXTEND
                    cls_xml.GEN_XML_EXTEND(PATH_XML, extend)
                    '100753
                    'ElseIf PROSESS_ID = "1400001" And SUBSTITUTE = "" Then ' ทะเบียนยา
                    '    Dim cls_xml As New CLASS_GEN_XML.Center
                    '    cls_xml.GEN_XML_DR(PATH_XML, p_dr)
                ElseIf PROSESS_ID = 12 Then ' โครงการวิจัย
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_DR(PATH_XML, p_dr)
                ElseIf PROSESS_ID = 14 Or PROSESS_ID = 15 Or PROSESS_ID = 16 Or PROSESS_ID = 17 Or PROSESS_ID = 18 Then ' เภสัชเคมีภัณฑ์
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_DH(PATH_XML, p_dh)

                ElseIf PROSESS_ID = 99 Then ' สถานที่
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_LOCATION(PATH_XML, p_LOCATION)

                ElseIf PROSESS_ID = 98 Then ' สถานที่เก็บ
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_LOCATION(PATH_XML, p_LOCATION)

                ElseIf PROSESS_ID = 1007001 Then
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_DRUG_CONSIDER_REQUESTS(PATH_XML, _p_DRUG_CONSIDER_REQUESTS)


                ElseIf (PROSESS_ID = 110 Or PROSESS_ID = 111 Or PROSESS_ID = 112 Or PROSESS_ID = 113 _
                    Or PROSESS_ID = 114 Or PROSESS_ID = 115 Or PROSESS_ID = 116 Or PROSESS_ID = 117 _
                    Or PROSESS_ID = 118 Or PROSESS_ID = 119 Or PROSESS_ID = 120 Or PROSESS_ID = 121 _
                    Or PROSESS_ID = 122 Or PROSESS_ID = 123 Or PROSESS_ID = 124 Or PROSESS_ID = 125 _
                    Or PROSESS_ID = 126 Or PROSESS_ID = 127 Or PROSESS_ID = 128 Or PROSESS_ID = 129 Or PROSESS_ID = 130 _
                    Or PROSESS_ID = 131 Or PROSESS_ID = 132 Or PROSESS_ID = 133 Or PROSESS_ID = 134) And temps = "" Then
                    Dim cls_xml As New CLASS_GEN_XML.DALCN
                    cls_xml.GEN_XML_DALCN(PATH_XML, p_dalcn)
                ElseIf (PROSESS_ID = 123 Or PROSESS_ID = 124 Or PROSESS_ID = 125 Or PROSESS_ID = 126 _
                    Or PROSESS_ID = 127 Or PROSESS_ID = 128 Or PROSESS_ID = 129 Or PROSESS_ID = 130 _
                    Or PROSESS_ID = 131 Or PROSESS_ID = 132 Or PROSESS_ID = 133 Or PROSESS_ID = 134) And temps <> "" Then
                    Dim cls_xml As New CLASS_GEN_XML.T_NCT_DALCN_TEMP
                    cls_xml.GEN_TEMP_NCT_DALCN(PATH_XML, p_temp_nct)
                ElseIf PROSESS_ID = 1027 Or PROSESS_ID = 1028 Or PROSESS_ID = 1029 Then
                    Dim cls_xml As New CLASS_GEN_XML.drsamp
                    cls_xml.GEN_XML_DRSAMP(PATH_XML, p_drsamp)
                ElseIf PROSESS_ID = 1026 Then
                    Dim cls_xml As New CLASS_GEN_XML.NYM1
                    cls_xml.GEN_XML_NORYORMOR1(PATH_XML, p_nym1)
                ElseIf PROSESS_ID = 1701 Or PROSESS_ID = 1702 Or PROSESS_ID = 1703 Or PROSESS_ID = 1704 Or PROSESS_ID = 1705 Or PROSESS_ID = 1706 Or PROSESS_ID = 1707 Then 'ตระกูล 8
                    Dim cls_xml As New CLASS_GEN_XML.drsamp2
                    cls_xml.GEN_XML_DRSAMP(PATH_XML, p_drsamp)
                ElseIf PROSESS_ID = 10061 Then
                    Dim cls_xml As New CLASS_GEN_XML.Cerf
                    cls_xml.GEN_XML_CER_FOREIGN(PATH_XML, p_cerf)
                ElseIf PROSESS_ID = 100741 Or PROSESS_ID = 100742 Or PROSESS_ID = 100743 Or PROSESS_ID = 100744 Or PROSESS_ID = 100745 _
                    Or PROSESS_ID = 100746 Or PROSESS_ID = 100747 Or PROSESS_ID = 100748 Or PROSESS_ID = 100749 Or PROSESS_ID = 100750 Or PROSESS_ID = 100751 Or PROSESS_ID = "100753" Or PROSESS_ID = "100752" Or PROSESS_ID = "100754" Or PROSESS_ID = "100755" Then 'ต่ออายุใบอนุญาตสถานที่
                    Dim cls_xml As New CLASS_GEN_XML.EXTEND
                    cls_xml.GEN_XML_EXTEND(PATH_XML, extend)
                ElseIf PROSESS_ID = "130099" Then
                    Dim cls_xml As New CLASS_GEN_XML.EDIT_DRRGT
                    cls_xml.GEN_XML_EDT_DRRGT(PATH_XML, p_rgt_edt)
                ElseIf PROSESS_ID = "130098" Then
                    Dim cls_xml As New CLASS_GEN_XML.DRRGT_SUB
                    cls_xml.GEN_DRRGT_SUBSTITUTE(PATH_XML, p_DRRGT_SUBSTITUTE)
                ElseIf PROSESS_ID = "1400001" Then ' ทะเบียนยา 'SUBSTITUTE <> "" And 
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_DR(PATH_XML, p_dr)
                ElseIf PROSESS_ID = "1400091" Then
                    Dim cls_xml As New CLASS_GEN_XML.DRRGT_SPC_GEN
                    cls_xml.GEN_DRRGT_SPC(PATH_XML, p_SPC)
                ElseIf PROSESS_ID = "1400092" Then
                    Dim cls_xml As New CLASS_GEN_XML.DRRGT_PI_GEN
                    cls_xml.GEN_DRRGT_PI(PATH_XML, p_PI)
                ElseIf PROSESS_ID = "1400093" Then
                    Dim cls_xml As New CLASS_GEN_XML.DRRGT_PIL_GEN
                    cls_xml.GEN_DRRGT_PIL(PATH_XML, p_PIL)
                End If


            Else
                If PROSESS_ID = 101 Or PROSESS_ID = 102 Or PROSESS_ID = 103 _
                   Or PROSESS_ID = 104 Or PROSESS_ID = 105 Or PROSESS_ID = 106 _
                   Or PROSESS_ID = 107 Or PROSESS_ID = 108 Or PROSESS_ID = 109 Then 'คือสถานที่
                    'ส่ง PATH_XML ไป GEN XML
                    Dim cls_xml As New CLASS_GEN_XML.DALCN
                    cls_xml.GEN_XML_DALCN(PATH_XML, p_dalcn)
                ElseIf (PROSESS_ID = 110 Or PROSESS_ID = 111 Or PROSESS_ID = 112 Or PROSESS_ID = 113 _
                        Or PROSESS_ID = 114 Or PROSESS_ID = 115 Or PROSESS_ID = 116 Or PROSESS_ID = 117 Or PROSESS_ID = 118 Or PROSESS_ID = 119 Or PROSESS_ID = 120 Or PROSESS_ID = 121 Or PROSESS_ID = 122 _
                        Or PROSESS_ID = 123 Or PROSESS_ID = 124 Or PROSESS_ID = 125 _
                    Or PROSESS_ID = 126 Or PROSESS_ID = 127 Or PROSESS_ID = 128) And temps = "" Then
                    Dim cls_xml As New CLASS_GEN_XML.DALCN
                    cls_xml.GEN_XML_DALCN(PATH_XML, p_dalcn)
                ElseIf PROSESS_ID = 130001 Or PROSESS_ID = 130002 Then 'บัญชีรายการ
                    Dim cls_xml As New CLASS_GEN_XML.Center
                    cls_xml.GEN_XML_REGISTRATION(PATH_XML, p_REGISTRATION)
                ElseIf PROSESS_ID = 11103 Or PROSESS_ID = 11104 Then
                    Dim cls_xml As New CLASS_GEN_XML.DALCN_EDIT_REQUEST
                    cls_xml.GEN_XML_DALCN_EDT(PATH_XML, p_dalcn_rqt)
                ElseIf PROSESS_ID = 100766 Or PROSESS_ID = 100767 Or PROSESS_ID = 100768 Or PROSESS_ID = 100769 Or PROSESS_ID = 100770 Or PROSESS_ID = 100771 Or PROSESS_ID = 100772 Or PROSESS_ID = 100773 Then
                    Dim cls_xml As New CLASS_GEN_XML.DALCN_NCT_SUB
                    cls_xml.GEN_XML_DALCN_SUB(PATH_XML, p_dalcn_sub)
                    'ElseIf SUBSTITUTE <> "" And PROSESS_ID = "1400001" Then ' ทะเบียนยา
                    '    Dim cls_xml As New CLASS_GEN_XML.Center
                    '    cls_xml.GEN_XML_DR(PATH_XML, p_dr)
                    '    '     ElseIf PROSESS_ID = 14 Or PROSESS_ID = 15 Or PROSESS_ID = 16 Or PROSESS_ID = 17 Or PROSESS_ID = 18 Then ' เภสัชเคมีภัณฑ์
                    '    '         Dim cls_xml As New CLASS_GEN_XML.Center
                    '    '         cls_xml.GEN_XML_DH(PATH_XML, p_dh)
                    '    '     ElseIf PROSESS_ID = 31 Or PROSESS_ID = 32 Or PROSESS_ID = 33 _
                    '    'Or PROSESS_ID = 34 Or PROSESS_ID = 35 Or PROSESS_ID = 36 Then 'cer
                    '    '         Dim cls_xml As New CLASS_GEN_XML.Center
                    '    '         cls_xml.GEN_XML_CER(PATH_XML, p_cer)
                    'ElseIf PROSESS_ID = "1400001" Then ' ทะเบียนยา
                    '    Dim cls_xml As New CLASS_GEN_XML.Center
                    '    cls_xml.GEN_XML_DR(PATH_XML, p_dr)
                    '  ElseIf (PROSESS_ID = 123 Or PROSESS_ID = 124 Or PROSESS_ID = 125 Or PROSESS_ID = 126 _
                    'Or PROSESS_ID = 127 Or PROSESS_ID = 128 Or PROSESS_ID = 129 Or PROSESS_ID = 130 _
                    'Or PROSESS_ID = 131 Or PROSESS_ID = 132 Or PROSESS_ID = 133 Or PROSESS_ID = 134) Then
                    '      Dim cls_xml As New CLASS_GEN_XML.T_NCT_DALCN_TEMP
                    '      cls_xml.GEN_TEMP_NCT_DALCN(PATH_XML, p_temp_nct)
                End If
            End If
            'ตรวจสอบว่ามี PDF มั้ย
            If Checkfile(PATH_PDF_TEMPLATE) = False Then
                '
            End If
            Dim ws_platten As New WS_FLATTEN.WS_FLATTEN
            Dim renderedbytes As Byte() = Nothing

            Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
                Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                    Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                        stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                        'renderedbytes = System.IO.File.ReadAllBytes(PATH_PDF_TEMPLATE)
                        'renderedbytes = ws_platten.PDF_DIGITAL_SIGN(renderedbytes)

                        'Dim bao As New BAO.AppSettings
                        'Dim paths As String = bao._PATH_DEFAULT
                        'Dim PDF_TEMPLATE As String = paths & "DIGITAL_SIGN\" & filename

                        'Dim clsds As New ClassDataset

                        'clsds.bynaryToobject(PDF_TEMPLATE, renderedbytes)
                    End Using
                End Using
            End Using
        Else
            If PROSESS_ID = 101 Or PROSESS_ID = 102 Or PROSESS_ID = 103 _
                   Or PROSESS_ID = 104 Or PROSESS_ID = 105 Or PROSESS_ID = 106 _
                   Or PROSESS_ID = 107 Or PROSESS_ID = 108 Or PROSESS_ID = 109 Then 'คือสถานที่
                'ส่ง PATH_XML ไป GEN XML
                Dim cls_xml As New CLASS_GEN_XML.DALCN
                cls_xml.GEN_XML_DALCN(PATH_XML, p_dalcn)

                Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
                    Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                        Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                            stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                        End Using
                    End Using
                End Using
            ElseIf PROSESS_ID = 11103 Or PROSESS_ID = 11104 Then
                Dim cls_xml As New CLASS_GEN_XML.DALCN_EDIT_REQUEST
                cls_xml.GEN_XML_DALCN_EDT(PATH_XML, p_dalcn_rqt)

                Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
                    Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                        Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                            stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                        End Using
                    End Using
                End Using
            ElseIf (PROSESS_ID = 110 Or PROSESS_ID = 111 Or PROSESS_ID = 112 Or PROSESS_ID = 113 _
               Or PROSESS_ID = 114 Or PROSESS_ID = 115 Or PROSESS_ID = 116 Or PROSESS_ID = 117 Or PROSESS_ID = 118 Or PROSESS_ID = 119 Or PROSESS_ID = 120 Or PROSESS_ID = 121 Or PROSESS_ID = 122 Or PROSESS_ID = 123 Or PROSESS_ID = 124 Or PROSESS_ID = 125 _
                    Or PROSESS_ID = 126 Or PROSESS_ID = 127 Or PROSESS_ID = 128 Or PROSESS_ID = 129 Or PROSESS_ID = 130 _
                    Or PROSESS_ID = 131 Or PROSESS_ID = 132 Or PROSESS_ID = 133 Or PROSESS_ID = 134) And temps = "" Then
                Dim cls_xml As New CLASS_GEN_XML.DALCN
                cls_xml.GEN_XML_DALCN(PATH_XML, p_dalcn)
                Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
                    Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                        Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                            stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                        End Using
                    End Using
                End Using
                'ElseIf PROSESS_ID = 14 Or PROSESS_ID = 15 Or PROSESS_ID = 16 Or PROSESS_ID = 17 Or PROSESS_ID = 18 Then ' เภสัชเคมีภัณฑ์
                '    Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
                '        Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                '            Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                '                stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                '            End Using
                '        End Using
                '    End Using
            ElseIf PROSESS_ID = 31 Or PROSESS_ID = 32 Or PROSESS_ID = 33 _
            Or PROSESS_ID = 34 Or PROSESS_ID = 35 Or PROSESS_ID = 36 Then 'cer
                Dim cls_xml As New CLASS_GEN_XML.Center
                cls_xml.GEN_XML_CER(PATH_XML, p_cer)
            ElseIf PROSESS_ID = 100741 Or PROSESS_ID = 100742 Or PROSESS_ID = 100743 Or PROSESS_ID = 100744 Or PROSESS_ID = 100745 _
                    Or PROSESS_ID = 100746 Or PROSESS_ID = 100747 Or PROSESS_ID = 100748 Or PROSESS_ID = 100749 Or PROSESS_ID = 100750 Or PROSESS_ID = 100751 Or PROSESS_ID = "100753" Or PROSESS_ID = "100752" Or PROSESS_ID = "100754" Or PROSESS_ID = "100755" Then 'cer
                Dim cls_xml As New CLASS_GEN_XML.EXTEND
                cls_xml.GEN_XML_EXTEND(PATH_XML, extend)
                Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
                    Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                        Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                            stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                        End Using
                    End Using
                End Using
            ElseIf PROSESS_ID = "130099" Then
                Dim cls_xml As New CLASS_GEN_XML.EDIT_DRRGT
                cls_xml.GEN_XML_EDT_DRRGT(PATH_XML, p_rgt_edt)
                Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
                    Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                        Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                            stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                        End Using
                    End Using
                End Using
            ElseIf PROSESS_ID = 100766 Or PROSESS_ID = 100767 Or PROSESS_ID = 100768 Or PROSESS_ID = 100769 Or PROSESS_ID = 100770 Or PROSESS_ID = 100771 Or PROSESS_ID = 100772 Or PROSESS_ID = 100773 Then
                Dim cls_xml As New CLASS_GEN_XML.DALCN_NCT_SUB
                cls_xml.GEN_XML_DALCN_SUB(PATH_XML, p_dalcn_sub)
                Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
                    Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                        Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                            stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                        End Using
                    End Using
                End Using

            ElseIf PROSESS_ID = "1400001" And STATUS_ID <> "1" Then ' ทะเบียนยา
                Dim cls_xml As New CLASS_GEN_XML.Center
                cls_xml.GEN_XML_DR(PATH_XML, p_dr)
                Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
                    Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                        Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                            stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                        End Using
                    End Using
                End Using
            ElseIf (PROSESS_ID = 123 Or PROSESS_ID = 124 Or PROSESS_ID = 125 Or PROSESS_ID = 126 _
               Or PROSESS_ID = 127 Or PROSESS_ID = 128 Or PROSESS_ID = 129 Or PROSESS_ID = 130 _
               Or PROSESS_ID = 131 Or PROSESS_ID = 132 Or PROSESS_ID = 133 Or PROSESS_ID = 134) And temps <> "" Then
                Dim cls_xml As New CLASS_GEN_XML.T_NCT_DALCN_TEMP
                cls_xml.GEN_TEMP_NCT_DALCN(PATH_XML, p_temp_nct)
                Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
                    Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                        Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                            stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                        End Using
                    End Using
                End Using

            End If

        End If

        Return PATH_PDF_OUTPUT
    End Function
    Public Function LOAD_XML_PDF1(ByVal PATH_XML As String, ByVal PATH_PDF_TEMPLATE As String, ByVal PROSESS_ID As String, PATH_PDF_OUTPUT As String, Optional filename As String = "") As String
        Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) 'C:\path\PDF_TEMPLATE\
            Using outputStream = New FileStream(PATH_PDF_OUTPUT, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(PATH_XML)
                End Using
            End Using
        End Using
        Return PATH_PDF_OUTPUT
    End Function

    Public Function SAVE_PDF()


    End Function

    Public Function Checkfile(ByVal Path As String) As Boolean
        Dim b As Boolean = System.IO.File.Exists(Path)
        Return b
    End Function


    ''' <summary>
    ''' สำหรับ ผปก  Upload Pdf แล้ว แปลงเป็น XML
    ''' </summary>
    ''' <param name="PATH_PDF_TRADER"></param>
    ''' <param name="PATH_XML_TRADER"></param>
    ''' <remarks></remarks>
    Public Sub convert_PDF_To_XML(ByVal PATH_PDF_TRADER As String, ByVal PATH_XML_TRADER As String)
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim outputStream As New System.IO.MemoryStream()
        Dim reader As New PdfReader(PATH_PDF_TRADER)
        Dim doc As New XmlDocument

        Dim ob As String


        ob = reader.AcroFields.Xfa.DatasetsNode.FirstChild.InnerXml
        doc.LoadXml(ob)
        doc.Save(PATH_XML_TRADER) '"C:\path\XML_TRADER\"

    End Sub



    ''' <summary>
    ''' นำข้อมูล XML เข้า PDFTEMPLATE แล้วทำการสร้าง PDF ขึ้นมาใหม่
    ''' </summary>
    ''' <param name="PATH_PDF_XML"></param>
    ''' <param name="PATH_XML_TRADER"></param>
    ''' <param name="PATH_PDF_TEMPLATE"></param>
    ''' <remarks></remarks>
    Public Sub convert_XML_To_PDF(ByVal PATH_PDF_XML As String, ByVal PATH_XML_TRADER As String, ByVal PATH_PDF_TEMPLATE As String)
        Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) '"C:\path\PDF_TEMPLATE\"
            Using outputStream = New FileStream(PATH_PDF_XML, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(PATH_XML_TRADER)
                End Using
            End Using
        End Using

    End Sub
    Public Function GET_B64_convert_XML_To_PDF(ByVal PATH_PDF_XML As String, ByVal PATH_XML_TRADER As String, ByVal PATH_PDF_TEMPLATE As String) As String
        Dim aa As String = ""
        Using pdfReader__1 = New PdfReader(PATH_PDF_TEMPLATE) '"C:\path\PDF_TEMPLATE\"
            Using outputStream = New FileStream(PATH_PDF_XML, FileMode.Create, FileAccess.Write) '"C:\path\PDF_XML_CLASS\"
                Using stamper = New iTextSharp.text.pdf.PdfStamper(pdfReader__1, outputStream, ControlChars.NullChar, True)
                    stamper.AcroFields.Xfa.FillXfaForm(PATH_XML_TRADER)
                End Using
            End Using
        End Using
        Return aa
    End Function
    Public Function NAME_PDF(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & con_year(YEAR) & "-" & ID_TRANSECTION_UPLOAD.Trim() & ".pdf"

        Return filename
    End Function

    Public Function NAME_XML(ByVal SYS As String, ByVal PROSESS_ID As String, ByVal YEAR As String, ByVal ID_TRANSECTION_UPLOAD As String) As String
        Dim filename As String = SYS & "-" & PROSESS_ID & "-" & con_year(YEAR) & "-" & ID_TRANSECTION_UPLOAD.Trim() & ".xml"

        Return filename
    End Function
    ''' <summary>
    ''' ดึงสกุลไฟล์แนบ
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetExtension(ByVal filename As String) As String
        Dim extension As String() = filename.Split(".")
        Dim extension_name As String = extension(extension.Length - 1)
        Return extension_name
    End Function


    ''' <summary>
    ''' ส่งเลขนิติบุคคล รับค่า LCNSID
    ''' </summary>
    ''' <param name="LCNSID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IDENTIFY_by_LCNSID(ByVal LCNSID As String) As String
        Dim IDENTIFY As String = "0"
        Try
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            dt = bao.SP_IDENTIFY_by_LCNSID(LCNSID)
            IDENTIFY = dt.Rows(0)("identify")
        Catch ex As Exception

        End Try

        Return IDENTIFY
    End Function


End Module