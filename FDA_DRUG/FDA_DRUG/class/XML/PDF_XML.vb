Namespace PDF_XML
    Public Class DRUG_BOOKING
#Region "pop"
        Private _XML_PREVIEW As String
        Public Property XML_PREVIEW() As String
            Get
                Return _XML_PREVIEW
            End Get
            Set(ByVal value As String)
                _XML_PREVIEW = value
            End Set
        End Property

        Private _STATUS_ID As String
        Public Property STATUS_ID() As String
            Get
                Return _STATUS_ID
            End Get
            Set(ByVal value As String)
                _STATUS_ID = value
            End Set
        End Property


        Private _chk_status As String
        Public Property chk_status() As String
            Get
                Return _chk_status
            End Get
            Set(ByVal value As String)
                _chk_status = value
            End Set
        End Property


        Private _XML_MAIN_IDA As Integer
        Public Property XML_MAIN_IDA() As Integer
            Get
                Return _XML_MAIN_IDA
            End Get
            Set(ByVal value As Integer)
                _XML_MAIN_IDA = value
            End Set
        End Property


        Private _XML_PATH_PDF As String
        Public Property XML_PATH_PDF() As String
            Get
                Return _XML_PATH_PDF
            End Get
            Set(ByVal value As String)
                _XML_PATH_PDF = value
            End Set
        End Property


        Private _XML_TR_ID As Integer
        Public Property XML_TR_ID() As Integer
            Get
                Return _XML_TR_ID
            End Get
            Set(ByVal value As Integer)
                _XML_TR_ID = value
            End Set
        End Property


        Private _XML_PROCESS_ID As String
        Public Property XML_PROCESS_ID() As String
            Get
                Return _XML_PROCESS_ID
            End Get
            Set(ByVal value As String)
                _XML_PROCESS_ID = value
            End Set
        End Property

        Private _XML_YEAR As String
        Public Property XML_YEAR() As String
            Get
                Return _XML_YEAR
            End Get
            Set(ByVal value As String)
                _XML_YEAR = value
            End Set
        End Property

        Private _XML_REMARK As String
        Public Property XML_REMARK() As String
            Get
                Return _XML_REMARK
            End Get
            Set(ByVal value As String)
                _XML_REMARK = value
            End Set
        End Property

        Private _XML_DATE As Date
        Public Property XML_DATE() As Date
            Get
                Return _XML_DATE
            End Get
            Set(ByVal value As Date)
                _XML_DATE = value
            End Set
        End Property

        Private _chk_reload As String
        Public Property chk_reload() As String
            Get
                Return _chk_reload
            End Get
            Set(ByVal value As String)
                _chk_reload = value
            End Set
        End Property

        Private _GROUP As String
        Public Property GROUP() As String
            Get
                Return _GROUP
            End Get
            Set(ByVal value As String)
                _GROUP = value
            End Set
        End Property
#End Region
        Public Sub BindData_PDF()

            Dim class_xml As New XML_DRUG

            Dim dao As New DAO_BOOKING.TB_DRUG_SCHEDULE
            dao.GetDataby_SCHEDULE_ID(_XML_MAIN_IDA)
            Dim dao_detail As New DAO_BOOKING.CLS_DETAIL_BOOKING_DRUG
            dao_detail.GetDataby_DETAIL_BOOKING_DRUG_ID(_XML_MAIN_IDA)
            Dim dao_process As New DAO_BOOKING.TB_MAS_PROCESS
            dao_process.GetDataby_PROCESS_ID_and_SYSTEM_ID(dao.fields.PROCESS_ID, "1")
            Dim dao_REQUEST_TEMPLATE As New DAO_SPECIAL_PAYMENT.TB_REQUEST_TEMPLATE
            dao_REQUEST_TEMPLATE.GetDataby_REQUEST_ID_and_SYSTEMS_ID(dao.fields.DOCUMENT_TYPE_ID, "1")
            Dim dao_SYSTEMS_PAYMENT_DETAIL As New DAO_SPECIAL_PAYMENT.TB_SYSTEMS_PAYMENT_DETAIL
            dao_SYSTEMS_PAYMENT_DETAIL.GetDataby_REF_NO(dao.fields.PRODUCT_ID)

            'class_xml.drug_name = dao.fields.REF_DRUG_NAME_1
            'If dao.fields.REF_DRUG_NAME_2 IsNot Nothing Then
            '    class_xml.drug_name = class_xml.drug_name & "," & dao.fields.REF_DRUG_NAME_2
            'End If
            'If dao.fields.REF_DRUG_NAME_3 IsNot Nothing Then
            '    class_xml.drug_name = class_xml.drug_name & "," & dao.fields.REF_DRUG_NAME_3
            'End If
            class_xml.group_admin = dao.fields.WORK_GROUP_NAME
            class_xml.identify_name = dao.fields.BOOKING_SUBSTITUTE_NAME
            'class_xml.lcnno = dao.fields.LCN_LCNNO_DISPLAY
            class_xml.processid_name = dao.fields.DOCUMENT_TYPE_NAME
            ' class_xml.product_id = dao.fields.REF_PRODUCT_ID_1

            'If dao.fields.REF_PRODUCT_ID_2 IsNot Nothing Then
            '    class_xml.product_id = class_xml.product_id & "," & dao.fields.REF_PRODUCT_ID_2
            'End If
            'If dao.fields.REF_PRODUCT_ID_3 IsNot Nothing Then
            '    class_xml.product_id = class_xml.product_id & "," & dao.fields.REF_PRODUCT_ID_3
            'End If


            Try
                class_xml.rcv_date = dao.fields.CONSIDER_DATE.Value.ToLongDateString
            Catch ex As Exception

            End Try
            Try
                class_xml.rcv_date1 = dao.fields.REF_NUMBER_DATE_1.Value.ToLongDateString
            Catch ex As Exception

            End Try

            'If dao.fields.REF_NUMBER_DATE_1 Is Nothing Then
            '    class_xml.rcv_date1 = ""
            'Else
            '    class_xml.rcv_date1 = dao.fields.REF_NUMBER_DATE_1.Value.ToLongDateString
            'End If

            'If dao.fields.REF_NUMBER_DATE_2 Is Nothing Then
            '    class_xml.rcv_date2 = ""
            'Else
            '    class_xml.rcv_date2 = dao.fields.REF_NUMBER_DATE_2.Value.ToLongDateString
            'End If

            'If dao.fields.REF_NUMBER_DATE_3 Is Nothing Then
            '    class_xml.rcv_date3 = ""
            'Else
            '    class_xml.rcv_date3 = dao.fields.REF_NUMBER_DATE_3.Value.ToLongDateString
            'End If


            'class_xml.rcv_number1 = dao.fields.REF_NUMBER_1
            'class_xml.rcv_number2 = dao.fields.REF_NUMBER_2
            'class_xml.rcv_number3 = dao.fields.REF_NUMBER_3
            'class_xml.service_name = dao.fields.SERVICE_NAME
            If dao.fields.THAINAMEPLACE = "&nbsp;" Then
                class_xml.thanameplace = ""
            Else
                class_xml.thanameplace = dao.fields.THAINAMEPLACE
            End If

            class_xml.processid_name = dao.fields.PROCESS_NAME
            class_xml.rcv_number1 = dao.fields.REF_C_NUMBER_1
            ' class_xml.rcv_date1 = dao.fields.REF_NUMBER_DATE_1.Value.ToLongDateString
            class_xml.lcnno = ""



            class_xml.fee = dao.fields.DOCUMENT_TYPE_NAME
            class_xml.send_date = dao.fields.CONSIDER_DATE_DISPLAY
            class_xml.appointment_date = dao.fields.ALLOW_DATE_DISPLAY
            class_xml.write_at = dao.fields.ALLOW_DATE_DISPLAY
            If String.IsNullOrEmpty(dao.fields.STATUS_DATE.ToString) = True Then
                class_xml.status_date = dao.fields.SCHEDULE_DATE.Value.ToLongDateString
            Else
                class_xml.status_date = dao.fields.STATUS_DATE.Value.ToLongDateString

            End If
            Dim productid_drugname1 As String = String.Empty
            If dao.fields.REF_DRUG_NAME_1 Is Nothing = False Then
                If Not dao.fields.REF_DRUG_NAME_1 = "" Then
                    productid_drugname1 = "ชื่อผลิตภัณฑ์ " & dao.fields.REF_DRUG_NAME_1 & Space(5)
                End If
            Else
                If Not dao.fields.REF_DRUG_NAME_1 = "" Then
                    productid_drugname1 = "ชื่อผลิตภัณฑ์ " & dao.fields.REF_DRUG_NAME_1 & Space(5)
                End If
            End If
            If dao.fields.REF_LCN_NUMBER_1 Is Nothing = False Then
                If Not dao.fields.REF_LCN_NUMBER_1 = "" Then
                    If String.IsNullOrEmpty(productid_drugname1) = True Then
                        productid_drugname1 = "ทะเบียนเลขที่ " & dao.fields.REF_LCN_NUMBER_1
                    Else
                        productid_drugname1 &= "ทะเบียนเลขที่ " & dao.fields.REF_LCN_NUMBER_1
                    End If
                End If
            Else
                If Not dao.fields.REF_LCN_NUMBER_1 = "" Then
                    If String.IsNullOrEmpty(productid_drugname1) = True Then
                        productid_drugname1 = "ทะเบียนเลขที่ " & dao.fields.REF_LCN_NUMBER_1
                    Else
                        productid_drugname1 &= "ทะเบียนเลขที่ " & dao.fields.REF_LCN_NUMBER_1
                    End If
                End If
            End If




            class_xml.productid_drugname1 = productid_drugname1
            class_xml.productid_drugname2 = ""
            class_xml.productid_drugname3 = ""
            class_xml.rcv_number = dao.fields.REF_R_NUMBER_1


            If dao.fields.PRODUCT_ID = "" Then
                class_xml.fee_id = ""
            Else

                class_xml.fee_id = dao.fields.PRODUCT_ID & " (" & dao_SYSTEMS_PAYMENT_DETAIL.fields.CAL_PRICE & " บาท)" '& " (" & dao_REQUEST_TEMPLATE.fields.PRICE & " บาท)"

            End If

            class_xml.place = dao_process.fields.PLACE
            If dao.fields.EMAIL = "" Then
                class_xml.bsn_thaifullname = dao.fields.VISITOR_IDENTIFICATION_NAME
            Else
                class_xml.bsn_thaifullname = dao.fields.VISITOR_IDENTIFICATION_NAME & " (" & dao.fields.EMAIL & ")"
            End If

            If dao.fields.REMARK <> "" Then
                class_xml.remark = dao.fields.SCHEDULE_REMARK.Replace(vbCrLf, "")
            Else
                class_xml.remark = dao.fields.SCHEDULE_REMARK
            End If

            XML_DRUGs = class_xml

            '---------------------------------------------------------------
            ' Dim bao_P As New BAO.PROCESS
            Dim ProcessID As Integer = _XML_PROCESS_ID '_XML_PROCESS_ID 'bao_P.GET_PROCESS_ID(dao_up.fields.PROCESS_ID, grouptype)
            Dim grouptype As Integer = 0
            Dim PREVIEW As Integer = 0
            Dim dao_pdftemplate As New DAO_BOOKING.TB_MAS_TEMPLATE_PROCESS
            If chk_status = 1 Then
                dao_pdftemplate.GetDataby_TEMPLAETE(ProcessID, 0, 8, grouptype, PREVIEW)
            Else
                dao_pdftemplate.GetDataby_TEMPLAETE(ProcessID, 0, 8, grouptype, PREVIEW)
            End If
            Dim _PATH_FILE As String = _PATH_FILE_DRUG
            Dim paths As String = _PATH_FILE
            Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim Path_PDF As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & dao.fields.RCVNO_DISPLAY & ".pdf" 'NAME_PDF("DRUG", ProcessID, _XML_YEAR, _XML_TR_ID)
            Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & dao.fields.RCVNO_DISPLAY & ".xml" 'NAME_XML("DRUG", ProcessID, _XML_YEAR, _XML_TR_ID)

            LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, ProcessID, Path_PDF, chk_reload) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

            _XML_PATH_PDF = Path_PDF


        End Sub

        Public Sub BindData_PDF_CENTER()

            Dim class_xml As New XML_DRUG

            Dim dao As New DAO_BOOKING.TB_CENTER_SCHEDULE
            dao.GetDataby_SCHEDULE_ID(_XML_MAIN_IDA)
            Dim dao_detail As New DAO_BOOKING.CLS_DETAIL_BOOKING_DRUG
            dao_detail.GetDataby_DETAIL_BOOKING_DRUG_ID(_XML_MAIN_IDA)
            Dim dao_process As New DAO_BOOKING.TB_MAS_PROCESS
            dao_process.GetDataby_PROCESS_ID_and_SYSTEM_ID(dao.fields.PROCESS_ID, "1")
            Dim dao_REQUEST_TEMPLATE As New DAO_SPECIAL_PAYMENT.TB_REQUEST_TEMPLATE
            dao_REQUEST_TEMPLATE.GetDataby_REQUEST_ID_and_SYSTEMS_ID(dao.fields.DOCUMENT_TYPE_ID, "1")

            'class_xml.drug_name = dao.fields.REF_DRUG_NAME_1
            'If dao.fields.REF_DRUG_NAME_2 IsNot Nothing Then
            '    class_xml.drug_name = class_xml.drug_name & "," & dao.fields.REF_DRUG_NAME_2
            'End If
            'If dao.fields.REF_DRUG_NAME_3 IsNot Nothing Then
            '    class_xml.drug_name = class_xml.drug_name & "," & dao.fields.REF_DRUG_NAME_3
            'End If
            class_xml.group_admin = dao.fields.WORK_GROUP_NAME
            class_xml.identify_name = dao.fields.BOOKING_SUBSTITUTE_NAME
            'class_xml.lcnno = dao.fields.LCN_LCNNO_DISPLAY
            class_xml.processid_name = dao.fields.DOCUMENT_TYPE_NAME
            ' class_xml.product_id = dao.fields.REF_PRODUCT_ID_1

            'If dao.fields.REF_PRODUCT_ID_2 IsNot Nothing Then
            '    class_xml.product_id = class_xml.product_id & "," & dao.fields.REF_PRODUCT_ID_2
            'End If
            'If dao.fields.REF_PRODUCT_ID_3 IsNot Nothing Then
            '    class_xml.product_id = class_xml.product_id & "," & dao.fields.REF_PRODUCT_ID_3
            'End If


            If dao.fields.SCHEDULE_DATE Is Nothing Then
                class_xml.rcv_date = ""
            Else
                class_xml.rcv_date = dao.fields.CONSIDER_DATE.Value.ToLongDateString
            End If

            'If dao.fields.REF_NUMBER_DATE_1 Is Nothing Then
            '    class_xml.rcv_date1 = ""
            'Else
            '    class_xml.rcv_date1 = dao.fields.REF_NUMBER_DATE_1.Value.ToLongDateString
            'End If

            'If dao.fields.REF_NUMBER_DATE_2 Is Nothing Then
            '    class_xml.rcv_date2 = ""
            'Else
            '    class_xml.rcv_date2 = dao.fields.REF_NUMBER_DATE_2.Value.ToLongDateString
            'End If

            'If dao.fields.REF_NUMBER_DATE_3 Is Nothing Then
            '    class_xml.rcv_date3 = ""
            'Else
            '    class_xml.rcv_date3 = dao.fields.REF_NUMBER_DATE_3.Value.ToLongDateString
            'End If


            class_xml.productid_drugname1 = ""
            class_xml.productid_drugname2 = ""
            class_xml.productid_drugname3 = ""
            'class_xml.rcv_number = dao.fields.REF_R_NUMBER_1
            class_xml.fee_id = dao.fields.PRODUCT_ID & " (" & dao_REQUEST_TEMPLATE.fields.PRICE & " บาท)"
            class_xml.place = dao_process.fields.PLACE
            class_xml.bsn_thaifullname = dao.fields.VISITOR_IDENTIFICATION_NAME & " (" & dao.fields.EMAIL & ")"
            class_xml.remark = dao.fields.SCHEDULE_REMARK

            XML_DRUGs = class_xml

            '---------------------------------------------------------------
            ' Dim bao_P As New BAO.PROCESS
            Dim ProcessID As Integer = _XML_PROCESS_ID '_XML_PROCESS_ID 'bao_P.GET_PROCESS_ID(dao_up.fields.PROCESS_ID, grouptype)
            Dim grouptype As Integer = 0
            Dim PREVIEW As Integer = 0
            Dim dao_pdftemplate As New DAO_BOOKING.TB_MAS_TEMPLATE_PROCESS
            If chk_status = 1 Then
                dao_pdftemplate.GetDataby_TEMPLAETE(ProcessID, 0, 8, grouptype, PREVIEW)
            Else
                dao_pdftemplate.GetDataby_TEMPLAETE(ProcessID, 0, 8, grouptype, PREVIEW)
            End If
            Dim _PATH_FILE As String = _PATH_FILE_DRUG
            Dim paths As String = _PATH_FILE
            Dim PDF_TEMPLATE As String = paths & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim Path_PDF As String = paths & dao_pdftemplate.fields.PDF_OUTPUT & "\" & dao.fields.RCVNO_DISPLAY & ".pdf" 'NAME_PDF("DRUG", ProcessID, _XML_YEAR, _XML_TR_ID)
            Dim Path_XML As String = paths & dao_pdftemplate.fields.XML_PATH & "\" & dao.fields.RCVNO_DISPLAY & ".xml" 'NAME_XML("DRUG", ProcessID, _XML_YEAR, _XML_TR_ID)

            LOAD_XML_PDF(Path_XML, PDF_TEMPLATE, ProcessID, Path_PDF, chk_reload) 'ระบบจะทำการตรวจสอบ Template  และจะทำการสร้าง XML เอง AUTO

            _XML_PATH_PDF = Path_PDF


        End Sub
    End Class
End Namespace
