Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG.XML_CENTER

Namespace CLASS_GEN_XML

    Public Class Center
        Protected Friend _CITIEZEN_ID As String
        Protected Friend _lcnsid_customer As Integer
        Protected Friend _lcnno As String
        Protected Friend _fdtypecd As String
        Protected Friend _fdtypenm As String
        Protected Friend _FATYPE As String
        Protected Friend _PVNCD As String
        Protected Friend _lcntpcd As String
        Protected Friend _lctcd As Integer
        Protected Friend _IDA As Integer
        Protected Friend _LCN_IDA As Integer
        Protected Friend _AUTO_ID As String
        Protected Friend _PRODUCT_ID As String

#Region "WS"
        Protected Friend WS_CENTER_CLC_NAMES As New WS_CENTER.CLC_NAMES
        Protected Friend WS_CENTER As New WS_CENTER.WS_CENTER
        Protected Friend WS_CENTER_systhmbl As New WS_CENTER.CLC_THMBLCD
        Protected Friend WS_CENTER_sysamphr As New WS_CENTER.CLC_AMPHRCD
        Protected Friend WS_CENTER_syschngwt As New WS_CENTER.CLC_CHAWTCD
#End Region


        Public Sub ADD_CHEMICAL()
            Dim bao_master As New BAO_MASTER
            Dim class_xml_cer As New CLASS_CER
            class_xml_cer.DT_MASTER.DT14 = bao_master.SP_MASTER_MAS_CHEMICAL() 'สาร
        End Sub

        Public Function AddValue(ByVal ob As Object) As Object
            Dim props As System.Reflection.PropertyInfo
            For Each props In ob.GetType.GetProperties()

                '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
                Dim p_type As String = props.PropertyType.ToString()
                If props.CanWrite = True Then
                    If p_type.ToUpper = "System.String".ToUpper Then
                        props.SetValue(ob, " ", Nothing)
                    ElseIf p_type.ToUpper = "System.Int32".ToUpper Then
                        props.SetValue(ob, 0, Nothing)
                    ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                        props.SetValue(ob, Date.Now, Nothing)
                    Else
                        props.SetValue(ob, Nothing, Nothing)
                    End If
                End If

                'prop.SetValue(cls1, "")
                'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
            Next props

            Return ob
        End Function
        Protected Friend Function AddValue2(ByVal ob As Object) As Object
            Dim props As System.Reflection.PropertyInfo
            For Each props In ob.GetType.GetProperties()

                '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
                Dim p_type As String = props.PropertyType.ToString()
                If props.CanWrite = True Then
                    If p_type.ToUpper = "System.String".ToUpper Then
                        props.SetValue(ob, " ", Nothing)
                    ElseIf p_type.ToUpper = "System.Int32".ToUpper Then
                        props.SetValue(ob, 0, Nothing)
                    ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                        props.SetValue(ob, Date.Now, Nothing)
                    Else

                        props.SetValue(ob, Nothing, Nothing)


                    End If
                End If

                'prop.SetValue(cls1, "")
                'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
            Next props

            Return ob
        End Function

        Public Sub GEN_XML_CER(ByVal PATH As String, ByVal p2 As CLASS_CER)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_DALCN(ByVal PATH As String, ByVal p2 As CLASS_DALCN)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DALCN_EDT(ByVal PATH As String, ByVal p2 As CLASS_DALCN_EDIT_REQUEST)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DALCN_SUB(ByVal PATH As String, ByVal p2 As CLASS_DALCN_NCT_SUBSTITUTE)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DH(ByVal PATH As String, ByVal p2 As CLASS_DH)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_DI(ByVal PATH As String, ByVal p2 As CLASS_DI)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_DP(ByVal PATH As String, ByVal p2 As CLASS_DP)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_DR(ByVal PATH As String, ByVal p2 As CLASS_DR)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_DS(ByVal PATH As String, ByVal p2 As CLASS_DS)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_REGISTRATION(ByVal PATH As String, ByVal p2 As CLASS_REGISTRATION)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_XML_LOCATION(ByVal PATH As String, ByVal p2 As CLS_LOCATION)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DRUG_CONSIDER_REQUESTS(ByVal PATH As String, ByVal p2 As XML_CONSIDER_REQUESTS)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_DRSAMP(ByVal PATH As String, ByVal p2 As CLASS_DRSAMP)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_CER_FOREIGN(ByVal PATH As String, ByVal p2 As CLASS_CER_FOREIGN)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_LCNREQUEST(ByVal PATH As String, ByVal p2 As CLASS_LCNREQUEST)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_EXTEND(ByVal PATH As String, ByVal p2 As CLASS_EXTEND)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_EDT_DRRGT(ByVal PATH As String, ByVal p2 As CLASS_EDIT_DRRGT)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_NORYORMOR1(ByVal PATH As String, ByVal p2 As CLASS_PROJECT_SUM)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_NORYORMOR2(ByVal PATH As String, ByVal p2 As CLASS_NYM_2)  'ลีมทำ gen xml NYM2

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)                            'gen file xml
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_NORYORMOR3(ByVal PATH As String, ByVal p2 As CLASS_NYM_3_SM)  'ลีมทำ gen xml NYM2

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)                            'gen file xml
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_NORYORMOR4(ByVal PATH As String, ByVal p2 As CLASS_NYM_4_SM)  'ลีมทำ gen xml NYM2

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)                            'gen file xml
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_XML_NORYORMOR4_2(ByVal PATH As String, ByVal p2 As CLASS_NYM_4_COMPANY)  'ลีมทำ gen xml NYM2

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)                            'gen file xml
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_DRRGT_SUBSTITUTE(ByVal PATH As String, ByVal p2 As CLASS_DRRGT_SUB)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_DRRGT_SPC(ByVal PATH As String, ByVal p2 As CLASS_DRRGT_SPC)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_DRRGT_PI(ByVal PATH As String, ByVal p2 As CLASS_DRRGT_PI)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
        Public Sub GEN_DRRGT_PIL(ByVal PATH As String, ByVal p2 As CLASS_DRRGT_PIL)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub

        Public Sub GEN_TEMP_NCT_DALCN(ByVal PATH As String, ByVal p2 As CLASS_TEMP_NCT_DALCN)

            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()

        End Sub
    End Class

    Public Class DALCN
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DALCN
            Dim class_xml As New CLASS_DALCN
            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.dalcns = AddValue(class_xml.dalcns)
            class_xml.dalcns.pvncd = _PVNCD
            class_xml.dalcns.lcnsid = _lcnsid_customer
            class_xml.dalcns.rcvno = 0
            class_xml.dalcns.CHK_SELL_TYPE = _CHK_SELL_TYPE
            'class_xml.dalcns.CHK_SELL_TYPE1 = _CHK_SELL_TYPE1
            For i As Integer = 0 To rows
                Dim cls_sysplace As New sysplace

                cls_sysplace = AddValue(cls_sysplace)

                class_xml.sysplaces.Add(cls_sysplace)
            Next

            For i As Integer = 0 To rows
                Dim cls_dakeplctnm As New dakeplctnm
                cls_dakeplctnm = AddValue(cls_dakeplctnm)
                class_xml.dakeplctnms.Add(cls_dakeplctnm)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnctg As New dalcnctg
                cls_dalcnctg = AddValue(cls_dalcnctg)
                class_xml.dalcnctgs.Add(cls_dalcnctg)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnphr As New dalcnphr
                cls_dalcnphr = AddValue(cls_dalcnphr)
                class_xml.dalcnphrs.Add(cls_dalcnphr)
            Next

            For i As Integer = 0 To rows
                Dim cls_dacnphdtl As New dacnphdtl
                cls_dacnphdtl = AddValue(cls_dacnphdtl)
                class_xml.dacnphdtls.Add(cls_dacnphdtl)
            Next

            For i As Integer = 0 To rows
                Dim cls_dacncphr As New dacncphr
                cls_dacncphr = AddValue(cls_dacncphr)
                class_xml.dacncphrs.Add(cls_dacncphr)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnkep As New dalcnkep
                cls_dalcnkep = AddValue(cls_dalcnkep)
                class_xml.dalcnkeps.Add(cls_dalcnkep)
            Next

            For i As Integer = 0 To rows
                Dim cls_darqt As New darqt
                cls_darqt = AddValue(cls_darqt)
                class_xml.darqts.Add(cls_darqt)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_KEPs As New DALCN_KEP
                cls_DALCN_KEPs = AddValue(cls_DALCN_KEPs)
                class_xml.DALCN_KEPs.Add(cls_DALCN_KEPs)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_PHR As New DALCN_PHR
                cls_DALCN_PHR = AddValue(cls_DALCN_PHR)
                class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_PHR_2 As New DALCN_PHR
                cls_DALCN_PHR_2 = AddValue(cls_DALCN_PHR_2)
                class_xml.DALCN_PHR_2s.Add(cls_DALCN_PHR_2)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnaddr As New dalcnaddr
                cls_dalcnaddr = AddValue(cls_dalcnaddr)
                class_xml.dalcnaddrs.Add(cls_dalcnaddr)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
                cls_DALCN_DETAIL_LOCATION_KEEP = AddValue(cls_DALCN_DETAIL_LOCATION_KEEP)
                class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
            Next
            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            'class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            class_xml.EXP_YEAR = ""
            class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            class_xml.SHOW_LCNNO = ""
            class_xml.phr_medical_type = ""
            class_xml.dalcns.opentime = _opentime
            Return class_xml


        End Function

        Public Function gen_xml_103(Optional rows As Integer = 0) As CLASS_DALCN
            Dim class_xml As New CLASS_DALCN
            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.dalcns = AddValue(class_xml.dalcns)
            class_xml.dalcns.pvncd = _PVNCD
            class_xml.dalcns.lcnsid = _lcnsid_customer
            class_xml.dalcns.rcvno = 0
            class_xml.dalcns.CHK_SELL_TYPE = _CHK_SELL_TYPE
            For i As Integer = 0 To rows
                Dim cls_sysplace As New sysplace

                cls_sysplace = AddValue(cls_sysplace)

                class_xml.sysplaces.Add(cls_sysplace)
            Next

            For i As Integer = 0 To rows
                Dim cls_dakeplctnm As New dakeplctnm
                cls_dakeplctnm = AddValue(cls_dakeplctnm)
                class_xml.dakeplctnms.Add(cls_dakeplctnm)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnctg As New dalcnctg
                cls_dalcnctg = AddValue(cls_dalcnctg)
                class_xml.dalcnctgs.Add(cls_dalcnctg)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnphr As New dalcnphr
                cls_dalcnphr = AddValue(cls_dalcnphr)
                class_xml.dalcnphrs.Add(cls_dalcnphr)
            Next

            For i As Integer = 0 To rows
                Dim cls_dacnphdtl As New dacnphdtl
                cls_dacnphdtl = AddValue(cls_dacnphdtl)
                class_xml.dacnphdtls.Add(cls_dacnphdtl)
            Next

            For i As Integer = 0 To rows
                Dim cls_dacncphr As New dacncphr
                cls_dacncphr = AddValue(cls_dacncphr)
                class_xml.dacncphrs.Add(cls_dacncphr)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnkep As New dalcnkep
                cls_dalcnkep = AddValue(cls_dalcnkep)
                class_xml.dalcnkeps.Add(cls_dalcnkep)
            Next

            For i As Integer = 0 To rows
                Dim cls_darqt As New darqt
                cls_darqt = AddValue(cls_darqt)
                class_xml.darqts.Add(cls_darqt)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_KEPs As New DALCN_KEP
                cls_DALCN_KEPs = AddValue(cls_DALCN_KEPs)
                class_xml.DALCN_KEPs.Add(cls_DALCN_KEPs)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_PHR As New DALCN_PHR
                cls_DALCN_PHR = AddValue(cls_DALCN_PHR)
                class_xml.DALCN_PHRs.Add(cls_DALCN_PHR)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_PHR_2 As New DALCN_PHR
                cls_DALCN_PHR_2 = AddValue(cls_DALCN_PHR_2)
                class_xml.DALCN_PHR_2s.Add(cls_DALCN_PHR_2)
            Next

            For i As Integer = 0 To rows
                Dim cls_dalcnaddr As New dalcnaddr
                cls_dalcnaddr = AddValue(cls_dalcnaddr)
                class_xml.dalcnaddrs.Add(cls_dalcnaddr)
            Next

            For i As Integer = 0 To rows
                Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
                cls_DALCN_DETAIL_LOCATION_KEEP = AddValue(cls_DALCN_DETAIL_LOCATION_KEEP)
                class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
            Next
            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            'class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            class_xml.EXP_YEAR = ""
            class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            class_xml.SHOW_LCNNO = ""
            Return class_xml
        End Function
    End Class
    Public Class DALCN_EDIT_REQUEST
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DALCN_EDIT_REQUEST
            Dim class_xml As New CLASS_DALCN_EDIT_REQUEST
            Dim dao_dalcn_edit As New DAO_DRUG.TB_DALCN_EDIT_REQUEST
            class_xml.DALCN_EDIT_REQUESTs = AddValue(class_xml.DALCN_EDIT_REQUESTs)
            class_xml.DALCN_EDIT_REQUESTs.rcvno = 0


            For i As Integer = 0 To rows
                Dim cls_DALCN_DETAIL_LOCATION_KEEP As New DALCN_DETAIL_LOCATION_KEEP
                cls_DALCN_DETAIL_LOCATION_KEEP = AddValue(cls_DALCN_DETAIL_LOCATION_KEEP)
                class_xml.DALCN_DETAIL_LOCATION_KEEPs.Add(cls_DALCN_DETAIL_LOCATION_KEEP)
            Next
            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            class_xml.EXP_YEAR = ""
            'class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            class_xml.SHOW_LCNNO = ""
            class_xml.phr_medical_type = ""
            Return class_xml


        End Function
    End Class
    Public Class DH
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _lctcd = ""
            _lcntpcd = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _PVNCD = pvncd
            _lcntpcd = lcntpcd
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' DH
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DH

            Dim class_xml As New CLASS_DH


            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.dh15rqts = AddValue(class_xml.dh15rqts)
            class_xml.dh15rqts.lcnno = _lcnno

            For i As Integer = 0 To rows
                Dim cls_dh15tdgt As New dh15tdgt
                cls_dh15tdgt = AddValue(cls_dh15tdgt)
                class_xml.dh15tdgts.Add(cls_dh15tdgt)
            Next

            For i As Integer = 0 To rows
                Dim cls_dh15tpdcfrgn As New dh15tpdcfrgn
                cls_dh15tpdcfrgn = AddValue(cls_dh15tpdcfrgn)
                class_xml.dh15tpdcfrgns.Add(cls_dh15tpdcfrgn)
            Next

            For i As Integer = 0 To rows
                Dim cls_dh15frgn As New dh15frgn
                cls_dh15frgn = AddValue(cls_dh15frgn)
                class_xml.dh15frgns.Add(cls_dh15frgn)
            Next

            For i As Integer = 0 To rows
                Dim cls_dh15rqtdt As New dh15rqtdt
                cls_dh15rqtdt = AddValue(cls_dh15rqtdt)
                class_xml.dh15rqtdts.Add(cls_dh15rqtdt)
            Next

            For i As Integer = 0 To rows
                Dim cls_DH15_DETAIL_CER As New DH15_DETAIL_CER
                cls_DH15_DETAIL_CER = AddValue(cls_DH15_DETAIL_CER)
                'cls_DH15_DETAIL_CER.DOCUMENT_DATE = Date.Now
                'cls_DH15_DETAIL_CER.EXP_DOCUMENT_DATE = Date.Now
                class_xml.DH15_DETAIL_CERs.Add(cls_DH15_DETAIL_CER)
            Next

            For i As Integer = 0 To rows
                Dim cls_DH15_DETAIL_CASCHEMICAL As New DH15_DETAIL_CASCHEMICAL
                cls_DH15_DETAIL_CASCHEMICAL = AddValue(cls_DH15_DETAIL_CASCHEMICAL)
                class_xml.DH15_DETAIL_CASCHEMICALs.Add(cls_DH15_DETAIL_CASCHEMICAL)
            Next

            For i As Integer = 0 To rows
                Dim cls_DH15_DETAIL_MANUFACTURE As New DH15_DETAIL_MANUFACTURE
                cls_DH15_DETAIL_MANUFACTURE = AddValue(cls_DH15_DETAIL_MANUFACTURE)
                class_xml.DH15_DETAIL_MANUFACTUREs.Add(cls_DH15_DETAIL_MANUFACTURE)
            Next


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ''หน่วยปริมาณ
            'class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_drsunit()

            ''เลขที่ใบอนุญาต
            'class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)

            '' ประเภทใบอนุญาต
            'class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)

            'ที่อยู่บริษัท
            class_xml.DT_MASTER.DT15 = bao_master.SP_DALCNADDR_BY_FK_IDA(_LCN_IDA)

            Return class_xml


        End Function


    End Class

    Public Class DI
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                      Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _lcntpcd = lcntpcd
            '_lctcd = lctcd
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' DI
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DI

            Dim class_xml As New CLASS_DI


            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.drimpfors = AddValue(class_xml.drimpfors)
            class_xml.drimpfors.lcnno = _lcnno

            For i As Integer = 0 To rows
                Dim cls_drimpdrg As New drimpdrg
                cls_drimpdrg = AddValue(cls_drimpdrg)
                class_xml.drimpdrgs.Add(cls_drimpdrg)
            Next

            For i As Integer = 0 To rows
                Dim cls_drimpfrgn As New drimpfrgn
                cls_drimpfrgn = AddValue(cls_drimpfrgn)
                class_xml.drimpfrgns.Add(cls_drimpfrgn)
            Next


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER


            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)
            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)



            Return class_xml


        End Function


    End Class

    Public Class DP
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _lctcd = ""
            _PVNCD = "10"
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                        Optional lctcd As Integer = 1, Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _lctcd = lctcd
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' DP
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DP

            Dim class_xml As New CLASS_DP


            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.drpcbs = AddValue(class_xml.drpcbs)
            class_xml.drpcbs.lcnno = _lcnno

            For i As Integer = 0 To rows
                Dim cls_drpcbdrg As New drpcbdrg
                cls_drpcbdrg = AddValue(cls_drpcbdrg)
                class_xml.drpcbdrgs.Add(cls_drpcbdrg)
            Next

            For i As Integer = 0 To rows
                Dim cls_drfrgn As New drfrgn
                cls_drfrgn = AddValue(cls_drfrgn)
                class_xml.drfrgns.Add(cls_drfrgn)
            Next

            For i As Integer = 0 To rows
                Dim cls_drfrgnaddr As New drfrgnaddr
                cls_drfrgnaddr = AddValue(cls_drfrgnaddr)
                class_xml.drfrgnaddrs.Add(cls_drfrgnaddr)
            Next

            For i As Integer = 0 To rows
                Dim cls_syspdcfrgn As New syspdcfrgn
                cls_syspdcfrgn = AddValue(cls_syspdcfrgn)
                class_xml.syspdcfrgns.Add(cls_syspdcfrgn)
            Next


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER
            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)
            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)


            Return class_xml


        End Function


    End Class

    Public Class DR
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _PVNCD = "10"
            _LCN_IDA = 0
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' DR
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DR

            Dim class_xml As New CLASS_DR


            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_IDA(_LCN_IDA)


            'Intial Default Value
            class_xml.drrgts = AddValue(class_xml.drrgts)
            class_xml.drrgts.lcnno = _lcnno


            'For i As Integer = 0 To rows
            '    Dim cls_drpcksize As New drpcksize
            '    cls_drpcksize = AddValue(cls_drpcksize)
            '    class_xml.drpcksizes.Add(cls_drpcksize)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_drusedrg As New drusedrg
            '    cls_drusedrg = AddValue(cls_drusedrg)
            '    class_xml.drusedrgs.Add(cls_drusedrg)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_drfrgn As New drfrgn
            '    cls_drfrgn = AddValue(cls_drfrgn)
            '    class_xml.drfrgns.Add(cls_drfrgn)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_dramldrg As New dramldrg
            '    cls_dramldrg = AddValue(cls_dramldrg)
            '    class_xml.dramldrgs.Add(cls_dramldrg)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_dramluse As New dramluse
            '    cls_dramluse = AddValue(cls_dramluse)
            '    class_xml.dramluses.Add(cls_dramluse)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_drdrgchr As New drdrgchr
            '    cls_drdrgchr = AddValue(cls_drdrgchr)
            '    class_xml.drdrgchrs.Add(cls_drdrgchr)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_drrgtnewdg As New drrgtnewdg
            '    cls_drrgtnewdg = AddValue(cls_drrgtnewdg)
            '    class_xml.drrgtnewdgs.Add(cls_drrgtnewdg)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_drspec As New drspec
            '    cls_drspec = AddValue(cls_drspec)
            '    class_xml.drspecs.Add(cls_drspec)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_dreqto As New dreqto
            '    cls_dreqto = AddValue(cls_dreqto)
            '    class_xml.dreqtos.Add(cls_dreqto)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_drfmlno As New drfmlno
            '    cls_drfmlno = AddValue(cls_drfmlno)
            '    class_xml.drfmlnos.Add(cls_drfmlno)
            'Next

            'For i As Integer = 0 To rows
            '    Dim cls_drfml As New drfml
            '    cls_drfml = AddValue(cls_drfml)
            '    class_xml.drfmls.Add(cls_drfml)
            'Next

            For i As Integer = 0 To rows
                Dim cls_DRRGT_DETAIL_ROLE As New DRRGT_DETAIL_ROLE
                cls_DRRGT_DETAIL_ROLE = AddValue(cls_DRRGT_DETAIL_ROLE)
                class_xml.DRRGT_DETAIL_ROLEs.Add(cls_DRRGT_DETAIL_ROLE)
            Next

            For i As Integer = 0 To rows
                Dim cls_atc As New DRRGT_ATC_DETAIL
                cls_atc = AddValue(cls_atc)
                class_xml.DRRGT_ATC_DETAIL.Add(cls_atc)
            Next
            'For i As Integer = 0 To rows
            '    Dim cls_cas As New DRRGT_DETAIL_CA
            '    cls_cas = AddValue(cls_cas)
            '    class_xml.DRRGT_DETAIL_CA.Add(cls_cas)
            'Next
            For i As Integer = 0 To rows
                Dim cls_pack As New DRRGT_PACKAGE_DETAIL
                cls_pack = AddValue(cls_pack)
                class_xml.DRRGT_PACKAGE_DETAIL.Add(cls_pack)
            Next
            '---------------------------------------------------------
            'For i As Integer = 0 To rows
            '    Dim cls_pro As New DRRGT_PRODUCER
            '    cls_pro = AddValue(cls_pro)
            '    class_xml.DRRGT_PRODUCER.Add(cls_pro)
            'Next

            For i As Integer = 0 To rows
                Dim cls_prop As New DRRGT_PROPERTy
                cls_prop = AddValue(cls_prop)
                class_xml.DRRGT_PROPERTy.Add(cls_prop)
            Next
            For i As Integer = 0 To rows
                Dim cls_prop As New DRRGT_PRODUCER_OTHER
                cls_prop = AddValue(cls_prop)
                class_xml.DRRGT_PRODUCER_OTHER.Add(cls_prop)
            Next

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)
            class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_dalcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
            '



            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER


            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)
            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)



            Return class_xml


        End Function

        Public Function gen_xml_ori(Optional rows As Integer = 0) As CLASS_DR

            Dim class_xml As New CLASS_DR


            Dim dao_dalcn As New DAO_DRUG.ClsDBdrrgt
            dao_dalcn.GetDataby_IDA(_IDA)


            'Intial Default Value
            class_xml.drrgts = AddValue(class_xml.drrgts)
            class_xml.drrgts.lcnno = _lcnno


            For i As Integer = 0 To rows
                Dim cls_DRRGT_DETAIL_ROLE As New DRRGT_DETAIL_ROLE
                cls_DRRGT_DETAIL_ROLE = AddValue(cls_DRRGT_DETAIL_ROLE)
                class_xml.DRRGT_DETAIL_ROLEs.Add(cls_DRRGT_DETAIL_ROLE)
            Next

            For i As Integer = 0 To rows
                Dim cls_atc As New DRRGT_ATC_DETAIL
                cls_atc = AddValue(cls_atc)
                class_xml.DRRGT_ATC_DETAIL.Add(cls_atc)
            Next
            'For i As Integer = 0 To rows
            '    Dim cls_cas As New DRRGT_DETAIL_CA
            '    cls_cas = AddValue(cls_cas)
            '    class_xml.DRRGT_DETAIL_CA.Add(cls_cas)
            'Next
            For i As Integer = 0 To rows
                Dim cls_pack As New DRRGT_PACKAGE_DETAIL
                cls_pack = AddValue(cls_pack)
                class_xml.DRRGT_PACKAGE_DETAIL.Add(cls_pack)
            Next
            '---------------------------------------------------------
            'For i As Integer = 0 To rows
            '    Dim cls_pro As New DRRGT_PRODUCER
            '    cls_pro = AddValue(cls_pro)
            '    class_xml.DRRGT_PRODUCER.Add(cls_pro)
            'Next

            For i As Integer = 0 To rows
                Dim cls_prop As New DRRGT_PROPERTy
                cls_prop = AddValue(cls_prop)
                class_xml.DRRGT_PROPERTy.Add(cls_prop)
            Next
            For i As Integer = 0 To rows
                Dim cls_prop As New DRRGT_PRODUCER_OTHER
                cls_prop = AddValue(cls_prop)
                class_xml.DRRGT_PRODUCER_OTHER.Add(cls_prop)
            Next

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)
            class_xml.DT_SHOW.DT6 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_dalcn.fields.FK_IDA) 'ข้อมูลสถานที่จำลอง
            '



            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER


            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)
            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)



            Return class_xml


        End Function
    End Class
    Public Class DR_ORI
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _PVNCD = "10"
            _LCN_IDA = 0
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0, Optional IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
        End Sub


        Public Function gen_xml_ori(Optional rows As Integer = 0) As CLASS_DRRTG_ORIGINAL

            Dim class_xml As New CLASS_DRRTG_ORIGINAL


            Dim dao_dr As New DAO_DRUG.ClsDBdrrgt
            dao_dr.GetDataby_IDA(_IDA)

            Dim dao_atc As New DAO_DRUG.TB_DRRGT_ATC_DETAIL
            dao_atc.GetDataby_FKIDA(_IDA)

            Dim dao_color As New DAO_DRUG.TB_DRRGT_COLOR
            dao_color.GetDataby_FK_IDA(_IDA)

            Dim dao_cond As New DAO_DRUG.TB_DRRGT_CONDITION
            dao_cond.GetDataby_FK_IDA(_IDA)

            Dim dao_cas As New DAO_DRUG.TB_DRRGT_DETAIL_CAS
            dao_cas.GetDataby_FKIDA(_IDA)

            Dim dao_dbt As New DAO_DRUG.TB_DRRGT_DTB
            dao_dbt.GetDataby_FKIDA(_IDA)

            Dim dao_dtl As New DAO_DRUG.TB_DRRGT_DTL_TEXT
            dao_dtl.GetDataby_FKIDA(_IDA)

            Dim dao_ea As New DAO_DRUG.TB_DRRGT_EACH
            dao_ea.GetDataby_FK_IDA(_IDA)

            Dim dao_eq As New DAO_DRUG.TB_DRRGT_EQTO
            dao_eq.GetDataby_FK_DRRQT_IDA(_IDA)

            Dim dao_keep As New DAO_DRUG.TB_DRRGT_KEEP_DRUG
            dao_keep.GetDataby_FKIDA(_IDA)

            Dim dao_nu As New DAO_DRUG.TB_DRRGT_NO_USE
            dao_nu.GetDataby_FK_IDA(_IDA)

            Dim dao_pack As New DAO_DRUG.TB_DRRGT_PACKAGE_DETAIL
            dao_nu.GetDataby_FK_IDA(_IDA)

            Dim dao_proin As New DAO_DRUG.TB_DRRGT_PRODUCER_IN
            dao_proin.GetDataby_FK_IDA(_IDA)

            Dim dao_pro As New DAO_DRUG.TB_DRRGT_PRODUCER
            dao_pro.GetDataby_FK_IDA(_IDA)

            Dim dao_prop As New DAO_DRUG.TB_DRRGT_PROPERTIES
            dao_prop.GetDataby_FK_IDA(_IDA)

            Dim dao_prop_det As New DAO_DRUG.TB_DRRGT_PROPERTIES_AND_DETAIL
            dao_prop_det.GetDataby_FK_IDA(_IDA)

            class_xml.drrgts = dao_dr.fields
            class_xml.DRRGT_ATC_DETAILs.Add(dao_atc.fields)
            class_xml.DRRGT_COLORs.Add(dao_color.fields)
            class_xml.DRRGT_CONDITIONs.Add(dao_cond.fields)
            class_xml.DRRGT_DETAIL_CAs.Add(dao_cas.fields)
            class_xml.DRRGT_DTBs.Add(dao_dbt.fields)
            class_xml.DRRGT_DTL_TEXTs.Add(dao_dtl.fields)
            class_xml.DRRGT_EACHes.Add(dao_ea.fields)
            class_xml.DRRGT_EQTOs.Add(dao_eq.fields)
            class_xml.DRRGT_KEEP_DRUGs.Add(dao_keep.fields)
            class_xml.DRRGT_NO_USEs.Add(dao_nu.fields)
            class_xml.DRRGT_PACKAGE_DETAILs.Add(dao_pack.fields)
            class_xml.DRRGT_PRODUCER_INs.Add(dao_proin.fields)
            class_xml.DRRGT_PRODUCERs.Add(dao_pro.fields)
            class_xml.DRRGT_PROPERTies.Add(dao_prop.fields)
            class_xml.DRRGT_PROPERTIES_AND_DETAILs.Add(dao_prop_det.fields)


            Return class_xml
        End Function
    End Class
    Public Class DS
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _lcntpcd = ""
            _PVNCD = "10"
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _lcntpcd = lcntpcd
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' DS
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DS

            Dim class_xml As New CLASS_DS


            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.drsamps = AddValue(class_xml.drsamps)
            class_xml.drsamps.lcnno = _lcnno

            For i As Integer = 0 To rows
                Dim cls_drsampfmlno As New drsampfmlno
                cls_drsampfmlno = AddValue(cls_drsampfmlno)
                class_xml.drsampfmlnos.Add(cls_drsampfmlno)
            Next



            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER
            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)
            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)

            Return class_xml


        End Function


    End Class

    Public Class DS_NEW
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _lcntpcd = ""
            _PVNCD = "10"
            _PRODUCT_ID = 0
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0, Optional PRODUCT_ID As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _lcntpcd = lcntpcd
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
            _PRODUCT_ID = PRODUCT_ID
        End Sub

        ''' <summary>
        ''' DS
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DS

            Dim class_xml As New CLASS_DS

            'Intial Default Value
            class_xml.drsamps = AddValue(class_xml.drsamps)
            class_xml.drsamps.lcnno = _lcnno

            For i As Integer = 0 To rows
                Dim cls_drsampfmlno As New drsampfmlno
                cls_drsampfmlno = AddValue(cls_drsampfmlno)
                class_xml.drsampfmlnos.Add(cls_drsampfmlno)
            Next
            For i As Integer = 0 To rows
                Dim cls_DRSAMP_DETAIL_CA As New DRSAMP_DETAIL_CA
                cls_DRSAMP_DETAIL_CA = AddValue(cls_DRSAMP_DETAIL_CA)
                class_xml.DRSAMP_DETAIL_CAS.Add(cls_DRSAMP_DETAIL_CA)
            Next


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER
            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)
            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)

            Return class_xml


        End Function


    End Class

    Public Class DRUG_REGISTRATION
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _lcntpcd = lcntpcd
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_REGISTRATION

            Dim class_xml As New CLASS_REGISTRATION


            Dim dao_regis As New DAO_DRUG.ClsDBDRUG_REGISTRATION
            dao_regis.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DRUG_REGISTRATIONs = AddValue(class_xml.DRUG_REGISTRATIONs)
            class_xml.DRUG_REGISTRATIONs.PVNCD = _PVNCD
            class_xml.DRUG_REGISTRATIONs.LCNNO = _lcnno
            class_xml.DRUG_REGISTRATIONs.LCNSID = _lcnsid_customer

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            'หมวดยา
            class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_drkdofdrg()

            'ชนิดของยา
            class_xml.DT_MASTER.DT2 = bao_master.SP_MASTER_drdosage()

            'ขนาดบรรจุ
            class_xml.DT_MASTER.DT3 = bao_master.SP_MASTER_drsunit()

            'รูปแบบของยา
            class_xml.DT_MASTER.DT4 = bao_master.SP_MASTER_dactg()

            'ประเภทของยา
            class_xml.DT_MASTER.DT5 = bao_master.SP_MASTER_drclass()

            'สรรพคุณ
            class_xml.DT_MASTER.DT6 = bao_master.SP_MASTER_drkdofdrg()

            'กลุ่มตำรับ
            class_xml.DT_MASTER.DT7 = bao_master.SP_MASTER_dramlusetp()

            For i As Integer = 0 To rows
                Dim cls_DRUG_REGISTRATION_ATC_DETAIL As New DRUG_REGISTRATION_ATC_DETAIL
                cls_DRUG_REGISTRATION_ATC_DETAIL = AddValue(cls_DRUG_REGISTRATION_ATC_DETAIL)
                class_xml.DRUG_REGISTRATION_ATC_DETAILs.Add(cls_DRUG_REGISTRATION_ATC_DETAIL)
            Next

            For i As Integer = 0 To rows
                Dim cls_DRUG_REGISTRATION_DETAIL_CAS As New DRUG_REGISTRATION_DETAIL_CA
                cls_DRUG_REGISTRATION_DETAIL_CAS = AddValue(cls_DRUG_REGISTRATION_DETAIL_CAS)
                class_xml.DRUG_REGISTRATION_DETAIL_CA.Add(cls_DRUG_REGISTRATION_DETAIL_CAS)
            Next

            For i As Integer = 0 To rows
                Dim cls_DRUG_REGISTRATION_PACKAGE_DETAIL As New DRUG_REGISTRATION_PACKAGE_DETAIL
                cls_DRUG_REGISTRATION_PACKAGE_DETAIL = AddValue(cls_DRUG_REGISTRATION_PACKAGE_DETAIL)
                class_xml.DRUG_REGISTRATION_PACKAGE_DETAILs.Add(cls_DRUG_REGISTRATION_PACKAGE_DETAIL)
            Next

            For i As Integer = 0 To rows
                Dim cls_DRUG_REGISTRATION_PRODUCER As New DRUG_REGISTRATION_PRODUCER
                cls_DRUG_REGISTRATION_PRODUCER = AddValue(cls_DRUG_REGISTRATION_PRODUCER)
                class_xml.DRUG_REGISTRATION_PRODUCER.Add(cls_DRUG_REGISTRATION_PRODUCER)
            Next

            For i As Integer = 0 To rows
                Dim cls_DRUG_REGISTRATION_PROPERTIES As New DRUG_REGISTRATION_PROPERTy
                cls_DRUG_REGISTRATION_PROPERTIES = AddValue(cls_DRUG_REGISTRATION_PROPERTIES)
                class_xml.DRUG_REGISTRATION_PROPERTy.Add(cls_DRUG_REGISTRATION_PROPERTIES)
            Next

            For i As Integer = 0 To rows
                Dim cls_DRUG_REGISTRATION_COLOR As New DRUG_REGISTRATION_COLOR
                cls_DRUG_REGISTRATION_COLOR = AddValue(cls_DRUG_REGISTRATION_COLOR)
                cls_DRUG_REGISTRATION_COLOR.COLOR1 = "0"
                cls_DRUG_REGISTRATION_COLOR.COLOR2 = "0"
                cls_DRUG_REGISTRATION_COLOR.COLOR3 = "0"
                cls_DRUG_REGISTRATION_COLOR.COLOR4 = "0"
                class_xml.DRUG_REGISTRATION_COLOR.Add(cls_DRUG_REGISTRATION_COLOR)
            Next
            Return class_xml


        End Function


    End Class


    Public Class Cer
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _IDA = 0
            _fdtypecd = ""
            _fdtypenm = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional ByVal lctcd As Integer = 1, Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lctcd = lctcd
            _LCN_IDA = LCN_IDA

        End Sub

        Public Shadows Function gen_xml_CER(Optional rows As Integer = 0) As CLASS_CER
            Dim class_xml_cer As New CLASS_CER


            'คนที่login

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            Dim dao_customer_addr As New DAO_CPN.clsDBsyslctaddr

            Dim dao_ID As New DAO_CPN.clsDBsyslcnsid
            'dao_falcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            dao_customer.GetDataby_lcnsid(_lcnsid_customer)
            dao_ID.GetDataby_lcnsid(_lcnsid_customer)



            'Intial Default Value
            class_xml_cer.CERs = AddValue(class_xml_cer.CERs)
            class_xml_cer.CERs.IDENTIFY = dao_ID.fields.identify
            class_xml_cer.CERs.LCNSID = dao_ID.fields.lcnsid
            'class_xml_cer.CERs.lmdfdate = Date.Now()


            For i As Integer = 0 To rows
                Dim cls_CER_DRTYPE As New CER_DRTYPE

                cls_CER_DRTYPE = AddValue2(cls_CER_DRTYPE)
                class_xml_cer.CER_FDTYPE.Add(cls_CER_DRTYPE)
            Next

            For i As Integer = 0 To rows
                Dim cls_CER_REF As New CER_REF

                cls_CER_REF = AddValue2(cls_CER_REF)

                class_xml_cer.CER_REF.Add(cls_CER_REF)
            Next
            For i As Integer = 0 To rows
                Dim cls_lgt_impcerref As New lgt_impcerref

                cls_lgt_impcerref = AddValue2(cls_lgt_impcerref)

                class_xml_cer.lgt_impcerref.Add(cls_lgt_impcerref)
            Next

            For i As Integer = 0 To 0
                Dim cls_CER_DETAIL_CASCHEMICAL As New CER_DETAIL_CASCHEMICAL

                cls_CER_DETAIL_CASCHEMICAL = AddValue2(cls_CER_DETAIL_CASCHEMICAL)

                class_xml_cer.CER_DETAIL_CASCHEMICALs.Add(cls_CER_DETAIL_CASCHEMICAL)
            Next

            For i As Integer = 0 To rows
                Dim cls_CER_DETAIL_MANUFACTURE As New CER_DETAIL_MANUFACTURE

                cls_CER_DETAIL_MANUFACTURE = AddValue2(cls_CER_DETAIL_MANUFACTURE)

                class_xml_cer.CER_DETAIL_MANUFACTUREs.Add(cls_CER_DETAIL_MANUFACTURE)
            Next



            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml_cer.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            'class_xml_cer.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)


            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            class_xml_cer.LCNNO_SHOW = ""
            class_xml_cer.TYPE_IMPORT = ""

            Return class_xml_cer


        End Function

    End Class

    Public Class EDIT_REQUEST
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _AUTO_ID = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional ByVal lctcd As Integer = 1, Optional ByVal LCN_IDA As Integer = 0, Optional ByVal AUTO_ID As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lctcd = lctcd
            _LCN_IDA = LCN_IDA
            _AUTO_ID = AUTO_ID
        End Sub

        Public Shadows Function gen_xml_EDIT_REQUEST(Optional rows As Integer = 0) As CLASS_EDIT_REQUEST

            Dim class_xml As New CLASS_EDIT_REQUEST

            'คนที่login

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            Dim dao_customer_addr As New DAO_CPN.clsDBsyslctaddr

            Dim dao_ID As New DAO_CPN.clsDBsyslcnsid
            'dao_falcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            dao_customer.GetDataby_lcnsid(_lcnsid_customer)
            dao_ID.GetDataby_lcnsid(_lcnsid_customer)


            'Intial Default Value
            class_xml.EDIT_REQUESTs = AddValue(class_xml.EDIT_REQUESTs)
            class_xml.AUTO_ID = _AUTO_ID
            '   AddValue(class_xml.lgt_impcer)
            'class_xml.EDIT_REQUESTs.lcnsid = _lcnsid_customer
            'class_xml.EDIT_REQUESTs.appvdate = Date.Now()
            'class_xml.EDIT_REQUESTs.certpcd = 0
            'class_xml.EDIT_REQUESTs.expdate = Date.Now
            'class_xml.EDIT_REQUESTs.lcnscd = 1
            'class_xml.EDIT_REQUESTs.lctcd = _lctcd
            'class_xml.EDIT_REQUESTs.lctnmcd = 1
            'class_xml.EDIT_REQUESTs.lmdfdate = Date.Now()
            'class_xml.EDIT_REQUESTs.rcvdate = Date.Now()


            'For i As Integer = 0 To rows
            '    Dim cls_CER_DRTYPE As New CER_DRTYPE

            '    cls_CER_DRTYPE = AddValue2(cls_CER_DRTYPE)
            '    class_xml.CER_FDTYPE.Add(cls_CER_DRTYPE)
            'Next





            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' bao_master.SP_MASTER_dactg.TableName = "ชื่อประเภทยา"
            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_dactg()

            'bao_master.SP_MASTER_fafdtype.TableName = "ประเทศ"
            ' class_xml.DT_MASTER.DT10 = bao_master.SP_MASTER_sysisocnt()


            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)

            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)

            ' ข้อมูลยา
            class_xml.DT_MASTER.DT15 = bao_master.SP_MASTER_drrgt_BY_IDA(_LCN_IDA)

            'bao_master.SP_MASTER_fafdtype.TableName = "ประเภท Cer"
            ' class_xml.DT_MASTER.DT13 = bao_master.SP_MASTER_lgt_impcertp()



            Return class_xml


        End Function

    End Class

    Public Class DRUG_PROJECT
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _lcntpcd = lcntpcd
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DRUG_PROJECT

            Dim class_xml As New CLASS_DRUG_PROJECT


            Dim dao_regis As New DAO_DRUG.ClsDBDRUG_PROJECT
            'dao_regis.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DRUG_PROJECTs = AddValue(class_xml.DRUG_PROJECTs)
            'class_xml.DRUG_REGISTRATIONs.PVNCD = _PVNCD
            class_xml.DRUG_PROJECTs.LCNNO = _lcnno
            'class_xml.DRUG_PROJECTs.LCNSI = _lcnsid_customer

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER


            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)

            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)


            Return class_xml

        End Function


    End Class

    Public Class PHARMACIST
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional LCN_IDA As Integer = 0
                       )
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_PHARMACIST

            Dim class_xml As New CLASS_PHARMACIST


            Dim dao As New DAO_DRUG.ClsDBDALCN_PHR
            'dao_regis.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DALCN_PHRs = AddValue(class_xml.DALCN_PHRs)
            'class_xml.DRUG_REGISTRATIONs.PVNCD = _PVNCD
            'class_xml.DALCN_PHRs.LCNNO = _lcnno
            'class_xml.DRUG_REGISTRATIONs.LCNSID = _lcnsid_customer

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer)
            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER


            'เลขที่ใบอนุญาต
            class_xml.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)

            ' ประเภทใบอนุญาต
            class_xml.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)


            Return class_xml


        End Function


    End Class

    Public Class CHEMICAL_REQUEST
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0, Optional LCN_IDA As Integer = 0
                       )
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _LCN_IDA = LCN_IDA
        End Sub

        ''' <summary>
        ''' เพิ่มสาร
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_CHEMICAL_REQUEST

            Dim class_xml As New CLASS_CHEMICAL_REQUEST

            'Intial Default Value
            class_xml.CHEMICAL_REQUESTs = AddValue(class_xml.CHEMICAL_REQUESTs)

            Return class_xml
        End Function
    End Class


    Public Class DRUG_CONSIDER_REQUEST
        Inherits Center




        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As XML_CONSIDER_REQUESTS

            Dim class_xml As New XML_CONSIDER_REQUESTS




            'Intial Default Value
            class_xml.DRUG_CONSIDER_REQUESTs = AddValue(class_xml.DRUG_CONSIDER_REQUESTs)


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            class_xml.EXP_YEAR = ""
            class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""

            Return class_xml


        End Function


    End Class

    Public Class drsamp
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String

        Private product_id_ida As String
        Private product_id_LCN_IDA As String
        Private product_id_FK_IDA As String
        Private TR_ID As String
        Private CITIEZEN_SUBMIT As String
        Private _staff_identify As String
        Private _staff_consider_iden As String

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""

            product_id_ida = ""
            product_id_LCN_IDA = ""
            product_id_FK_IDA = ""
            TR_ID = ""
            CITIEZEN_SUBMIT = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "", Optional product_ida As String = "", Optional product_lcnno As String = "", Optional product_fkida As String = "", Optional rcvr_id As String = "", Optional staff_offer_iden As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type

            product_id_ida = phr_medical_type
            product_id_LCN_IDA = opentime
            product_id_FK_IDA = product_ida
            TR_ID = product_lcnno
            CITIEZEN_SUBMIT = product_fkida
            _staff_identify = rcvr_id
            _staff_consider_iden = staff_offer_iden

        End Sub


        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DRSAMP

            Dim class_xml As New CLASS_DRSAMP
            Dim bao As New BAO.ClsDBSqlcommand

            'Intial Default Value
            'class_xml.drsamps = AddValue(class_xml.drsamps)


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT1 = bao.SP_DRUG_PRODUCT_ID(product_id_ida) 'ดึงบัญชีรายการยา
            class_xml.DT_SHOW.DT2 = bao.SP_DALCN_BY_IDA_FOR_NYM(product_id_LCN_IDA)    'ข้อมูลที่อยู่สถาณที่
            class_xml.DT_SHOW.DT3 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(product_id_ida) 'ดึงตัวยาสำคัญ
            class_xml.DT_SHOW.DT3.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
            class_xml.DT_SHOW.DT4 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(product_id_ida)    'ขนาดบรรจุ
            'class_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM(product_id_ida) 'ใบนยม
            'class_xml.DT_SHOW.DT6 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM2(product_id_ida) 'เก็บตกหล่น
            class_xml.DT_SHOW.DT7 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(product_id_ida) 'ดึงตัวยาสำคัญ
            class_xml.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
            class_xml.DT_SHOW.DT8 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(product_id_ida)    'ขนาดบรรจุ
            class_xml.DT_SHOW.DT10 = bao_show.SP_MAINPERSON_CTZNO(CITIEZEN_SUBMIT)
            Try
                class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(product_id_FK_IDA) 'ผู้ดำเนิน
            Catch ex As Exception

            End Try

            Try
                class_xml.DT_SHOW.DT15 = bao_show.SP_MAINPERSON_CTZNO(_staff_identify)
            Catch ex As Exception

            End Try

            'Try
            '    class_xml.DT_SHOW.DT16 = bao_show.SP_MAINPERSON_CTZNO(_staff_consider_iden)
            'Catch ex As Exception

            'End Try


            '_______________MASTER_________________
            'Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            'class_xml.EXP_YEAR = ""
            'class_xml.LCNNO_SHOW = "" 
            'class_xml.RCVDAY = ""
            'class_xml.RCVMONTH = ""
            'class_xml.RCVYEAR = ""

            Return class_xml


        End Function


    End Class
    Public Class drsamp2
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String

        Private product_id_ida As String
        Private product_id_LCN_IDA As String
        Private product_id_FK_IDA As String
        Private _phr_fkida As Integer
        Private product_id_TR_ID As String
        Private _citizen_submit As String
        Private _phesaj_ida As String
        Private _staff_app As String
        Private _staff_rcv As String

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""

            product_id_ida = ""
            product_id_LCN_IDA = ""
            product_id_FK_IDA = ""
            product_id_TR_ID = ""
            _staff_app = ""
            _staff_rcv = ""
            _phesaj_ida = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "", Optional product_ida As String = "", Optional product_lcnno As String = "", Optional product_fkida As String = "", Optional staff_app As String = "", Optional staff_rcv As String = "", Optional phesaj_ida As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type

            product_id_ida = phr_medical_type
            product_id_LCN_IDA = opentime
            product_id_FK_IDA = product_ida
            '_phr_fkida = product_lcnno
            _phr_fkida = Convert.ToInt32(product_lcnno)
            product_id_TR_ID = product_fkida
            _staff_app = staff_app
            _phesaj_ida = phesaj_ida
            _staff_rcv = staff_rcv

        End Sub


        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DRSAMP

            Dim class_xml As New CLASS_DRSAMP
            Dim bao As New BAO.ClsDBSqlcommand

            'Intial Default Value
            'class_xml.drsamps = AddValue(class_xml.drsamps)


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT1 = bao.SP_DRUG_PRODUCT_ID(product_id_ida) 'บัญชีรายการยา
            class_xml.DT_SHOW.DT2 = bao.SP_DALCN_BY_IDA_FOR_NYM(product_id_LCN_IDA) 'เลขที่ใบอนุญาต

            'class_xml.DT_SHOW.DT3 = bao.SP_PRODUCT_ID_CHEMICAL_FK_IDA(product_id_ida) 'ตัวยาสำคัญ
            class_xml.DT_SHOW.DT3 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(product_id_ida) 'ตัวยาสำคัญ
            class_xml.DT_SHOW.DT4 = bao.SP_DRSAMP_BY_PRODUCT_ID_FOR_NYM(product_id_ida) 'ขนาดบรรจุ
            class_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(product_id_ida) 'ขนาดบรรจุ

            class_xml.DT_SHOW.DT7 = bao.SP_DRUG_REGISTRATION_DETAIL_CAS_FK_IDA(product_id_ida) 'ดึงตัวยาสำคัญ multi
            class_xml.DT_SHOW.DT7.TableName = "SP_PRODUCT_ID_CHEMICAL_FK_IDA"
            class_xml.DT_SHOW.DT8 = bao.SP_DRSAMP_PACKAGE_DETAIL_CHK_BY_FK_IDA(product_id_ida)    'ขนาดบรรจุ multi
            class_xml.DT_SHOW.DT10 = bao_show.SP_MAINPERSON_CTZNO(_citizen_submit) 'ผู้ยื่น
            class_xml.DT_SHOW.DT11 = bao_show.SP_DRUG_REGISTRATION_PRODUCER_ALL_BY_FK_IDA(product_id_ida)  '
            Try
                class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(product_id_FK_IDA) 'ผู้ดำเนิน
            Catch ex As Exception

            End Try
            Try
                class_xml.DT_SHOW.DT15 = bao_show.SP_MAINPERSON_CTZNO(_staff_rcv) 'ผู้รับคำขอ
            Catch ex As Exception

            End Try
            Try
                class_xml.DT_SHOW.DT16 = bao_show.SP_MAINPERSON_CTZNO(_staff_app) 'ผู้อนุมัติ
            Catch ex As Exception

            End Try

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER
            Try
                'class_xml.DT_MASTER.DT18 = bao_master.SP_DALCN_PHR_BY_FK_IDA(product_id_LCN_IDA) 'ผู้มีหน้าที่ปฏิบัติการ
                For Each dr As DataRow In bao_master.SP_DALCN_PHR_BY_FK_IDA(product_id_LCN_IDA).Rows
                    If dr("IDA") = _phesaj_ida Then
                        class_xml.phr_fullname = dr("PHR_FULLNAME")
                        class_xml.phr_nm = dr("FULLNAME")
                    End If
                Next
            Catch ex As Exception

            End Try
            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            'class_xml.EXP_YEAR = ""
            'class_xml.LCNNO_SHOW = "" 
            'class_xml.RCVDAY = ""
            'class_xml.RCVMONTH = ""
            'class_xml.RCVYEAR = ""

            Return class_xml


        End Function


    End Class

    Public Class Cer_foreign
        Inherits Center

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _IDA = 0
            _fdtypecd = ""
            _fdtypenm = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional ByVal lctcd As Integer = 1, Optional LCN_IDA As Integer = 0)
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lctcd = lctcd
            _LCN_IDA = LCN_IDA

        End Sub

        Public Shadows Function gen_xml_CER_FOR(Optional rows As Integer = 0) As CLASS_CER_FOREIGN
            Dim class_xml_cer As New CLASS_CER_FOREIGN


            'คนที่login

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            Dim dao_customer_addr As New DAO_CPN.clsDBsyslctaddr

            Dim dao_ID As New DAO_CPN.clsDBsyslcnsid
            'dao_falcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            dao_customer.GetDataby_lcnsid(_lcnsid_customer)
            dao_ID.GetDataby_lcnsid(_lcnsid_customer)



            'Intial Default Value
            class_xml_cer.CER_FOREIGNs = AddValue(class_xml_cer.CER_FOREIGNs)
            class_xml_cer.CER_FOREIGNs.IDENTIFY = dao_ID.fields.identify
            class_xml_cer.CER_FOREIGNs.LCNSID = dao_ID.fields.lcnsid
            class_xml_cer.CER_FOREIGNs.lmdfdate = Date.Now()


            'For i As Integer = 0 To rows
            '    Dim cls_CER_FOREIGN_MANUFACTURE As New CER_FOREIGN_MANUFACTURE

            '    cls_CER_FOREIGN_MANUFACTURE = AddValue2(cls_CER_FOREIGN_MANUFACTURE)

            '    class_xml_cer.CER_FOREIGN_MANUFACTUREs.Add(cls_CER_FOREIGN_MANUFACTURE)
            'Next


            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml_cer.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml_cer.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)


            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER


            'เลขที่ใบอนุญาต
            class_xml_cer.DT_MASTER.DT12 = bao_master.SP_MASTER_CON_LCNNO(_LCN_IDA)
            ' ประเภทใบอนุญาต
            class_xml_cer.DT_MASTER.DT14 = bao_master.SP_MASTER_dalcntype_by_IDA(_LCN_IDA)

            Return class_xml_cer


        End Function

    End Class

    Public Class Cerf
        Inherits Center

        Private _cerf_ida As String

        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _IDA = 0
            _fdtypecd = ""
            _fdtypenm = ""
            _cerf_ida = 0
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                   Optional ByVal lctcd As Integer = 1, Optional LCN_IDA As Integer = 0, Optional cerf_ida As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lctcd = lctcd
            _LCN_IDA = LCN_IDA
            _cerf_ida = cerf_ida

        End Sub

        Public Shadows Function gen_xml_CER(Optional rows As Integer = 0) As CLASS_CER_FOREIGN
            Dim class_xml_cer As New CLASS_CER_FOREIGN


            'คนที่login

            Dim dao_customer As New DAO_CPN.clsDBsyslcnsnm
            Dim dao_customer_addr As New DAO_CPN.clsDBsyslctaddr

            Dim dao_ID As New DAO_CPN.clsDBsyslcnsid
            'dao_falcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            dao_customer.GetDataby_lcnsid(_lcnsid_customer)
            dao_ID.GetDataby_lcnsid(_lcnsid_customer)

            'Dim dao_cerf As New DAO_DRUG.TB_CER_FOREIGN
            'dao_cerf.GetDataby_IDA(_cerf_ida)

            'Intial Default Value
            class_xml_cer.CER_FOREIGNs = AddValue(class_xml_cer.CER_FOREIGNs)
            'class_xml_cer.CER_FOREIGNs = dao_cerf.fields
            class_xml_cer.CER_FOREIGNs.IDENTIFY = dao_ID.fields.identify
            class_xml_cer.CER_FOREIGNs.LCNSID = dao_ID.fields.lcnsid
            class_xml_cer.CER_FOREIGNs.lmdfdate = Date.Now()


            For i As Integer = 0 To rows
                Dim cls_CER_DRTYPE As New CER_DRTYPE

                cls_CER_DRTYPE = AddValue2(cls_CER_DRTYPE)
                class_xml_cer.CER_FDTYPE.Add(cls_CER_DRTYPE)
            Next

            For i As Integer = 0 To rows
                Dim cls_CER_REF As New CER_REF

                cls_CER_REF = AddValue2(cls_CER_REF)

                class_xml_cer.CER_REF.Add(cls_CER_REF)
            Next
            For i As Integer = 0 To rows
                Dim cls_lgt_impcerref As New lgt_impcerref

                cls_lgt_impcerref = AddValue2(cls_lgt_impcerref)

                class_xml_cer.lgt_impcerref.Add(cls_lgt_impcerref)
            Next

            For i As Integer = 0 To 0
                Dim cls_CER_DETAIL_CASCHEMICAL As New CER_DETAIL_CASCHEMICAL

                cls_CER_DETAIL_CASCHEMICAL = AddValue2(cls_CER_DETAIL_CASCHEMICAL)

                class_xml_cer.CER_DETAIL_CASCHEMICALs.Add(cls_CER_DETAIL_CASCHEMICAL)
            Next

            For i As Integer = 0 To rows
                Dim cls_CER_DETAIL_MANUFACTURE As New CER_DETAIL_MANUFACTURE

                cls_CER_DETAIL_MANUFACTURE = AddValue2(cls_CER_DETAIL_MANUFACTURE)

                class_xml_cer.CER_DETAIL_MANUFACTUREs.Add(cls_CER_DETAIL_MANUFACTURE)
            Next



            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml_cer.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            class_xml_cer.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_LCN_IDA)


            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            class_xml_cer.LCNNO_SHOW = ""
            class_xml_cer.TYPE_IMPORT = ""

            Return class_xml_cer


        End Function

    End Class

    Public Class lcnrequest
        Inherits Center

        Private _CITIZEN_ID_AUTHORIZE As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        'Private _lcn_ida As String
        Private _lct_ida As String
        Private _FK_IDA As String
        Private _IDA As String
        Public Sub New()
            _CITIZEN_ID_AUTHORIZE = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            '_lctcd = ""
            _lcntpcd = ""
            _lct_ida = ""
        End Sub

        Public Sub New(Optional citizen_id_authorize As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0, Optional Fk_ida As Integer = 0, Optional ida As Integer = 0)
            _CITIZEN_ID_AUTHORIZE = citizen_id_authorize
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _PVNCD = pvncd
            _lcntpcd = lcntpcd
            _LCN_IDA = LCN_IDA
            '_lct_ida = lct_ida
            _FK_IDA = Fk_ida
            _IDA = ida
        End Sub

        ''' <summary>
        ''' ต่ออายุใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_LCNREQUEST
            Dim class_xml As New CLASS_LCNREQUEST
            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            Dim dao_lcnrequest As New DAO_DRUG.TB_lcnrequest
            'dao_lcnrequest.GetDataby_IDA(dao_dalcn.fields.IDA)
            'dao_dalcn.fields.IDA = dao_lcnrequest.fields.FK_IDA
            'dao_lcnrequest.fields.IDA = 


            'Intial Default Value
            class_xml.dalcns = AddValue(class_xml.dalcns)
            'class_xml.dalcns.pvncd = _PVNC
            class_xml.dalcns.lcnsid = _lcnsid_customer
            class_xml.dalcns.rcvno = 0
            class_xml.dalcns.CHK_SELL_TYPE = _CHK_SELL_TYPE
            'class_xml.dalcns.CHK_SELL_TYPE1 = _CHK_SELL_TYPE1

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(_FK_IDA) 'ข้อมูลสถานที่จำลอง
            class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, _lcnsid_customer) 'ข้อมูลที่ตั้งหลัก
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CITIZEN_ID_AUTHORIZE, _lcnsid_customer) 'ข้อมูลบริษัท
            class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, _lcnsid_customer) 'ที่เก็บ
            class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
            class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(_FK_IDA) 'ผู้ดำเนิน

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER
            class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(_LCN_IDA) 'ใบอนุญาตสถานที่
            Try
                'class_xml.DT_MASTER.DT29 = bao_master.SP_MASTER_DALCN_LCNREQUEST_by_IDA(_IDA) 'ใบอนุญาตต่ออายุสถานที่
            Catch ex As Exception

            End Try

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            class_xml.EXP_YEAR = ""
            class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.CHK_TYPE = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            'class_xml.SHOW_LCNNO = ""
            'class_xml.phr_medical_type = ""
            class_xml.dalcns.opentime = _opentime
            Return class_xml

        End Function
    End Class
    Public Class EXTEND
        Inherits Center

        Private _CITIZEN_ID_AUTHORIZE As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        'Private _lcn_ida As String
        Private _lct_ida As String
        Private _FK_IDA As String
        Private _IDA As String
        Public Sub New()
            _CITIZEN_ID_AUTHORIZE = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            '_lctcd = ""
            _lcntpcd = ""
            _lct_ida = ""
        End Sub

        Public Sub New(Optional citizen_id_authorize As String = "", Optional lcnsid As Integer = 0, Optional lcnno As String = "",
                       Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional LCN_IDA As Integer = 0, Optional Fk_ida As Integer = 0, Optional ida As Integer = 0)
            _CITIZEN_ID_AUTHORIZE = citizen_id_authorize
            _lcnsid_customer = lcnsid
            _lcnno = lcnno
            _PVNCD = pvncd
            _lcntpcd = lcntpcd
            _LCN_IDA = LCN_IDA
            '_lct_ida = lct_ida
            _FK_IDA = Fk_ida
            _IDA = ida
        End Sub

        ''' <summary>
        ''' ต่ออายุใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_EXTEND
            Dim class_xml As New CLASS_EXTEND
            Dim dao_dalcn As New DAO_DRUG.ClsDBdalcn
            dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            Dim dao_lcnrequest As New DAO_DRUG.TB_LCN_EXTEND_LITE
            'dao_lcnrequest.GetDataby_IDA(dao_dalcn.fields.IDA)
            'dao_dalcn.fields.IDA = dao_lcnrequest.fields.FK_IDA
            'dao_lcnrequest.fields.IDA = 


            'Intial Default Value
            class_xml.dalcns = AddValue(class_xml.dalcns)
            'class_xml.dalcns.pvncd = _PVNC
            class_xml.dalcns.lcnsid = _lcnsid_customer
            class_xml.dalcns.rcvno = 0
            class_xml.dalcns.CHK_SELL_TYPE = _CHK_SELL_TYPE
            'class_xml.dalcns.CHK_SELL_TYPE1 = _CHK_SELL_TYPE1

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            class_xml.DT_SHOW.DT9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(_FK_IDA) 'ข้อมูลสถานที่จำลอง
            class_xml.DT_SHOW.DT11 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(0, _lcnsid_customer) 'ข้อมูลที่ตั้งหลัก
            class_xml.DT_SHOW.DT12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFY(_CITIZEN_ID_AUTHORIZE, _lcnsid_customer) 'ข้อมูลบริษัท
            class_xml.DT_SHOW.DT13 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID(2, _lcnsid_customer) 'ที่เก็บ
            class_xml.DT_SHOW.DT13.TableName = "SP_LOCATION_ADDRESS_by_LOCATION_TYPE_CD_and_LCNSID_2"
            'class_xml.DT_SHOW.DT14 = bao_show.SP_LOCATION_BSN_BY_LOCATION_ADDRESS_IDA(_FK_IDA) 'ผู้ดำเนิน

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER
            'class_xml.DT_MASTER.DT30 = bao_master.SP_MASTER_DALCN_by_IDA(_LCN_IDA) 'ใบอนุญาตสถานที่
            Try
                'class_xml.DT_MASTER.DT29 = bao_master.SP_MASTER_DALCN_LCNREQUEST_by_IDA(_IDA) 'ใบอนุญาตต่ออายุสถานที่
            Catch ex As Exception

            End Try

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            class_xml.EXP_YEAR = ""
            class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.CHK_TYPE = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            'class_xml.SHOW_LCNNO = ""
            'class_xml.phr_medical_type = ""
            class_xml.dalcns.opentime = _opentime
            Return class_xml

        End Function
    End Class
    Public Class NYM1
        Inherits Center

        Private _drs_ida As Integer
        Private _pjsum_ida As Integer
        Private _citizen As String
        Private _citizen_autho As String

        Public Sub New()

        End Sub

        Public Sub New(Optional drs_ida As Integer = 0, Optional lcnno As String = "",
                   Optional ByVal pjsum_ida As Integer = 0, Optional citizen As String = "", Optional citizen_autho As String = "")
            _drs_ida = drs_ida
            _lcnno = lcnno
            _pjsum_ida = pjsum_ida
            _citizen = citizen
            _citizen_autho = citizen_autho


        End Sub

        Public Shadows Function gen_xml_NYM1(Optional rows As Integer = 0) As CLASS_PROJECT_SUM
            Dim class_xml As New CLASS_PROJECT_SUM

            Dim bao As New BAO.ClsDBSqlcommand

            Dim dao As New DAO_DRUG.ClsDBdrsamp
            dao.GetDataby_IDA(_drs_ida)
            Dim dao2 As New DAO_DRUG.ClsDBdalcn
            dao2.GetDataby_IDA(_lcnno)
            Dim dao_pjsum As New DAO_DRUG.ClsDBDRUG_PROJECT_SUM
            dao_pjsum.GetDataby_IDA(_pjsum_ida)
            class_xml.DRUG_PROJECT_SUMMARY = dao_pjsum.fields

            Dim dao_fac As New DAO_DRUG.ClsDBDRUG_PROJECT_RESEARCH_FACILITY
            dao_fac.GetDataby_PROJECT(_pjsum_ida)
            For Each dao_fac.datas In dao_fac.datas
                class_xml.DRUG_PROJECT_RESEARCH_FACILITYS.Add(dao_fac.datas)
            Next

            Dim dao_lab As New DAO_DRUG.ClsDBDRUG_PROJECT_CLINICAL_LABORATORY
            dao_lab.GetDataby_PROJECT(_pjsum_ida)
            For Each dao_lab.datas In dao_lab.datas
                class_xml.DRUG_PROJECT_CLINICAL_LABORATORYS.Add(dao_lab.datas)
            Next

            Dim dao_dl As New DAO_DRUG.ClsDBDRUG_PROJECT_DRUG_LIST
            dao_dl.GetDataby_PROJECT(_pjsum_ida)
            For Each dao_dl.datas In dao_dl.datas
                class_xml.DRUG_PROJECT_DRUG_LISTS.Add(dao_dl.datas)
            Next

            class_xml.dalcns = dao2.fields
            class_xml.LCNNO_SHOWS = dao2.fields.LCNNO_DISPLAY
            class_xml.drsamp = dao.fields
            class_xml.DT_SHOW.DT5 = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_PJSUM(_pjsum_ida, 3)
            class_xml.DT_SHOW.DT6 = bao.SP_DRSAMP_PACKAGE_DETAIL_BY_PJSUM(_pjsum_ida, 4)

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'ชื่อผู้ใช้ระบบ
            class_xml.DT_SHOW.DT10 = bao_show.SP_MAINPERSON_CTZNO(_citizen)
            'ชื่อบริษัท
            class_xml.DT_SHOW.DT11 = bao_show.SP_MAINCOMPANY_LCNSID(_citizen_autho)

            class_xml.DT_SHOW.DT20 = bao.SP_DRSAMP_RCV(dao_pjsum.fields.TR_ID)

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            Return class_xml

        End Function

    End Class
    Public Class EDIT_LCN
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_EDIT_LCN
            Dim class_xml As New CLASS_EDIT_LCN
            Dim dao As New DAO_DRUG.TB_EDT_HISTORY
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.EDT_HISTORIES = AddValue(class_xml.EDT_HISTORIES)

            Return class_xml


        End Function
    End Class

    Public Class OTHER_XML
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_OTHER_XML
            Dim class_xml As New CLASS_OTHER_XML
            Dim dao As New DAO_DRUG.TB_drsunit
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            dao.GetDataALL()

            'Intial Default Value
            'class_xml.drsunits = AddValue(dao.datas)
            For Each dao.datas In dao.datas
                class_xml.drsunit.Add(dao.datas)
            Next





            Return class_xml

        End Function
    End Class
    Public Class PHR_CANCEL
        Inherits Center
        Private _PHR_CTZNO As String
        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
            _PHR_CTZNO = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "", Optional _PHR_CTZNO As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
            _PHR_CTZNO = _PHR_CTZNO
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_PHARMACIST_CANCEL
            Dim class_xml As New CLASS_PHARMACIST_CANCEL
            Dim dao As New DAO_DRUG.TB_DALCN_PHR_CANCEL_DETAIL
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)
            dao.GetDataAll()

            'Intial Default Value
            'class_xml.drsunits = AddValue(dao.datas)
            For Each dao.datas In dao.datas
                ' class_xml.drsunit.Add(dao.datas)
                class_xml.DALCN_PHR_CANCEL_DETAIL.Add(dao.datas)
            Next

            '_______________SHOW___________________
            

            '_______________MASTER___________________
            Return class_xml

        End Function
    End Class
    Public Class EDIT_DRRGT
        Inherits Center
        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_EDIT_DRRGT
            Dim class_xml As New CLASS_EDIT_DRRGT
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_REQUEST
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DRRGT_EDIT_REQUESTs = AddValue(class_xml.DRRGT_EDIT_REQUESTs)
            class_xml.DRRGT_EDIT_REQUESTs.pvncd = _PVNCD
            class_xml.DRRGT_EDIT_REQUESTs.lcnsid = _lcnsid_customer
            class_xml.DRRGT_EDIT_REQUESTs.rcvno = 0
            class_xml.DRRGT_EDIT_REQUESTs.FK_IDA = 0
            class_xml.DRRGT_EDIT_REQUESTs.TR_ID = 0
            class_xml.DRRGT_EDIT_REQUESTs.STATUS_ID = 0
            class_xml.DRRGT_EDIT_REQUESTs.cnccd = 0
            class_xml.DRRGT_EDIT_REQUESTs.cnccscd = 0


            'class_xml.DRRGT_COLORs.FK_IDA = "0"
            'class_xml.DRRGT_COLORs.IDA = 0
            'class_xml.DRRGT_COLORs = AddValue(class_xml.DRRGT_COLORs)
            

            'class_xml.DRRGT_COLORs = AddValue(class_xml.DRRGT_COLORs)

            For i As Integer = 0 To rows
                Dim cls_DRRGT_COLOR As New DRRGT_COLOR
                cls_DRRGT_COLOR = AddValue(cls_DRRGT_COLOR)
                cls_DRRGT_COLOR.COLOR1 = "0"
                cls_DRRGT_COLOR.COLOR2 = "0"
                cls_DRRGT_COLOR.COLOR3 = "0"
                cls_DRRGT_COLOR.COLOR4 = "0"
                class_xml.DRRGT_COLORs.Add(cls_DRRGT_COLOR)
            Next
            

            For i As Integer = 0 To rows
                Dim cls_DRRGT_PACKAGE_DETAIL As New DRRGT_PACKAGE_DETAIL
                cls_DRRGT_PACKAGE_DETAIL = AddValue(cls_DRRGT_PACKAGE_DETAIL)
                class_xml.DRRGT_PACKAGE_DETAILs.Add(cls_DRRGT_PACKAGE_DETAIL)
            Next
            '---------------------------เอาออกชั่วคราว
            'For i As Integer = 0 To rows
            '    Dim cls_DRRGT_DETAIL_CA As New DRRGT_DETAIL_CA
            '    cls_DRRGT_DETAIL_CA = AddValue(cls_DRRGT_DETAIL_CA)
            '    class_xml.DRRGT_DETAIL_CASes.Add(cls_DRRGT_DETAIL_CA)
            'Next
            'For i As Integer = 0 To rows
            '    Dim cls_DRRGT_DETAIL_CA As New DRRGT_EDIT_REQUEST_CA
            '    cls_DRRGT_DETAIL_CA = AddValue(cls_DRRGT_DETAIL_CA)
            '    class_xml.DRRGT_EDIT_REQUEST_CASes.Add(cls_DRRGT_DETAIL_CA)
            'Next
            '-----------------------------------------

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function

    End Class

    Public Class DRRGT_SUB
        Inherits Center
        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DRRGT_SUB
            Dim class_xml As New CLASS_DRRGT_SUB
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_SUBSTITUTE
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DRRGT_SUBSTITUTEs = AddValue(class_xml.DRRGT_SUBSTITUTEs)
            class_xml.DRRGT_SUBSTITUTEs.pvncd = _PVNCD
            class_xml.DRRGT_SUBSTITUTEs.lcnsid = _lcnsid_customer
            class_xml.DRRGT_SUBSTITUTEs.rcvno = 0
            class_xml.DRRGT_SUBSTITUTEs.FK_IDA = 0
            class_xml.DRRGT_SUBSTITUTEs.TR_ID = 0
            class_xml.DRRGT_SUBSTITUTEs.STATUS_ID = 0



            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function

    End Class
    Public Class DRRGT_SPC_GEN
        Inherits Center
        Private _cityzen_id As String
        Private _lcnsid As String
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As String = "0",
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DRRGT_SPC
            Dim class_xml As New CLASS_DRRGT_SPC
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_SPC
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DRRGT_SPCs = AddValue(class_xml.DRRGT_SPCs)
            class_xml.DRRGT_SPCs.pvncd = _PVNCD
            class_xml.DRRGT_SPCs.FK_IDA = 0
            class_xml.DRRGT_SPCs.TR_ID = 0

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function

    End Class
    Public Class DRRGT_PI_GEN
        Inherits Center
        Private _cityzen_id As String
        Private _lcnsid As String
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As String = "0",
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DRRGT_PI
            Dim class_xml As New CLASS_DRRGT_PI
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_PI
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DRRGT_PIs = AddValue(class_xml.DRRGT_PIs)
            class_xml.DRRGT_PIs.pvncd = _PVNCD
            class_xml.DRRGT_PIs.FK_IDA = 0
            class_xml.DRRGT_PIs.TR_ID = 0

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function

    End Class
    Public Class DRRGT_PIL_GEN
        Inherits Center
        Private _cityzen_id As String
        Private _lcnsid As String
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As String = "0",
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DRRGT_PIL
            Dim class_xml As New CLASS_DRRGT_PIL
            Dim dao_edt As New DAO_DRUG.TB_DRRGT_PIL
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.DRRGT_PILs = AddValue(class_xml.DRRGT_PILs)
            class_xml.DRRGT_PILs.pvncd = _PVNCD
            class_xml.DRRGT_PILs.FK_IDA = 0
            class_xml.DRRGT_PILs.TR_ID = 0

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function

    End Class

    Public Class T_NCT_DALCN_TEMP
        Inherits Center
        Private _cityzen_id As String
        Private _lcnsid As String
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As String = "0",
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_TEMP_NCT_DALCN
            Dim class_xml As New CLASS_TEMP_NCT_DALCN
            Dim dao_edt As New DAO_DRUG.TB_TEMP_NCT_DALCN
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.TEMP_NCT_DALCNs = AddValue(class_xml.TEMP_NCT_DALCNs)
            class_xml.TEMP_NCT_DALCNs.TR_ID = 0

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function

    End Class

    Public Class DALCN_NCT_SUB
        Inherits Center

        Private _cityzen_id As String
        Private _lcnsid As Integer
        Private _lcnno As String
        Private _p4 As String
        Private _p5 As String
        Private _CHK_SELL_TYPE As String
        'Private _CHK_SELL_TYPE1 As String
        Private _phr_medical_type As String
        Private _opentime As String
        Public Sub New()
            _CITIEZEN_ID = ""
            _lcnsid_customer = 0
            _lcnno = ""
            _fdtypecd = ""
            _fdtypenm = ""
            _PVNCD = "10"
            _CHK_SELL_TYPE = ""
            '_CHK_SELL_TYPE1 = ""
            _phr_medical_type = ""
            _opentime = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional lcnsid As Integer = 0,
                       Optional lcnno As String = "", Optional lcntpcd As String = "", Optional pvncd As String = "10", Optional CHK_SELL_TYPE As String = "", Optional phr_medical_type As String = "", Optional opentime As String = "")
            _CITIEZEN_ID = citizen_id
            _lcnsid_customer = lcnsid
            _lcntpcd = lcntpcd
            _lcnno = lcnno
            _opentime = opentime
            '_fdtypenm = fdtypenm
            _PVNCD = pvncd
            _CHK_SELL_TYPE = CHK_SELL_TYPE
            '_CHK_SELL_TYPE1 = CHK_SELL_TYPE1
            _phr_medical_type = phr_medical_type
        End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_DALCN_NCT_SUBSTITUTE
            Dim class_xml As New CLASS_DALCN_NCT_SUBSTITUTE
            Dim dao_dalcn_edit As New DAO_DRUG.TB_DALCN_NCT_SUBSTITUTE
            class_xml.DALCN_NCT_SUBSTITUTEs = AddValue(class_xml.DALCN_NCT_SUBSTITUTEs)
            class_xml.DALCN_NCT_SUBSTITUTEs.rcvno = 0
            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            class_xml.EXP_YEAR = ""
            'class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            class_xml.SHOW_LCNNO = ""
            class_xml.phr_medical_type = ""
            Return class_xml


        End Function
    End Class

    Public Class NYM2_IMPORT
        Inherits Center
        Private _NYM2_DATE_TOP As String
        Private _NYM_TYPE As String
        Private _DL As String
        Private _NYM2_WISH_MED As String
        Private _NYM2_NO As String
        Private _STATUS_ID As String
        'Private _CHK_SELL_TYPE1 As String
        'Private _phr_medical_type As String
        'Private _opentime As String
        Public Sub New()
            _NYM2_DATE_TOP = ""
            _NYM_TYPE = 0
            _DL = ""
            _NYM2_WISH_MED = ""
            _NYM2_NO = ""
            _STATUS_ID = ""
            '_CHK_SELL_TYPE = ""
            ''_CHK_SELL_TYPE1 = ""
            '_phr_medical_type = ""
            '_opentime = ""
        End Sub

        Public Sub New(Optional NYM2_DATE_TOP As String = "", Optional NYM_TYPE As String = "0",
                       Optional DL As String = "", Optional NYM2_WISH_MED As String = "", Optional NYM2_NO As String = "", Optional STATUS_ID As String = "")
            _NYM2_DATE_TOP = NYM2_DATE_TOP
            _NYM_TYPE = NYM_TYPE
            _DL = DL
            _NYM2_WISH_MED = NYM2_WISH_MED
            _NYM2_NO = NYM2_NO
            _STATUS_ID = STATUS_ID
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_NYM_2
            Dim class_xml As New CLASS_NYM_2
            Dim dao_edt As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_2
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.NYM_2s = AddValue(class_xml.NYM_2s)
            class_xml.NYM_2s.TR_ID = 0

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function
    End Class
    Public Class NYM3_IMPORT
        Inherits Center
        Private _NYM3_DATE_TOP As String
        Private _NYM_TYPE As String
        Private _DL As String
        Private _NYM3_WISH_MED As String
        Private _NYM3_NO As String
        Private _STATUS_ID As String
        'Private _CHK_SELL_TYPE1 As String
        'Private _phr_medical_type As String
        'Private _opentime As String
        Public Sub New()
            _NYM3_DATE_TOP = ""
            _NYM_TYPE = 0
            _DL = ""
            _NYM3_WISH_MED = ""
            _NYM3_NO = ""
            _STATUS_ID = ""
            '_CHK_SELL_TYPE = ""
            ''_CHK_SELL_TYPE1 = ""
            '_phr_medical_type = ""
            '_opentime = ""
        End Sub

        Public Sub New(Optional NYM3_DATE_TOP As String = "", Optional NYM_TYPE As String = "0",
                       Optional DL As String = "", Optional NYM3_WISH_MED As String = "", Optional NYM2_NO As String = "", Optional STATUS_ID As String = "")
            _NYM3_DATE_TOP = NYM3_DATE_TOP
            _NYM_TYPE = NYM_TYPE
            _DL = DL
            _NYM3_WISH_MED = NYM3_WISH_MED
            _NYM3_NO = NYM2_NO
            _STATUS_ID = STATUS_ID
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_NYM_3_SM
            Dim class_xml As New CLASS_NYM_3_SM
            Dim dao_edt As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.NYM_3s = AddValue(class_xml.NYM_3s)
            class_xml.NYM_3s.TR_ID = 0

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function
    End Class
    Public Class NYM4_IMPORT
        Inherits Center
        Private _NYM4_DATE_TOP As String
        Private _NYM_TYPE As String
        Private _DL As String
        Private _NYM4_WISH_MED As String
        Private _NYM4_NO As String
        Private _STATUS_ID As String
        'Private _CHK_SELL_TYPE1 As String
        'Private _phr_medical_type As String
        'Private _opentime As String
        Public Sub New()
            _NYM4_DATE_TOP = ""
            _NYM_TYPE = 0
            _DL = ""
            _NYM4_WISH_MED = ""
            _NYM4_NO = ""
            _STATUS_ID = ""
            '_CHK_SELL_TYPE = ""
            ''_CHK_SELL_TYPE1 = ""
            '_phr_medical_type = ""
            '_opentime = ""
        End Sub

        Public Sub New(Optional NYM4_DATE_TOP As String = "", Optional NYM_TYPE As String = "0",
                       Optional DL As String = "", Optional NYM4_WISH_MED As String = "", Optional NYM2_NO As String = "", Optional STATUS_ID As String = "")
            _NYM4_DATE_TOP = NYM4_DATE_TOP
            _NYM_TYPE = NYM_TYPE
            _DL = DL
            _NYM4_WISH_MED = NYM4_WISH_MED
            _NYM4_NO = NYM2_NO
            _STATUS_ID = STATUS_ID
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_NYM_4_SM
            Dim class_xml As New CLASS_NYM_4_SM
            Dim dao_edt As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.NYM_4s = AddValue(class_xml.NYM_4s)
            class_xml.NYM_4s.TR_ID = 0

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function
    End Class
    Public Class NYM3_IMPORT_SUB                  'เริ่มทำตรงนี้////////////////////////////////////////////////////////////////////////////////////
        Inherits Center

        Private _citicen As String
        Private _nym3_ida As String
        Private _process_id As String
        Private _nym3_date_write As String
        Private _nym3_type As String
        Private _dl_nym3 As String
        Private _nym3_wish_med As String
        Private _nym3_no As String
        Private _nym3_status_id As String
        Public Sub New()

            _citicen = ""
            _nym3_ida = ""
            _process_id = ""
            _nym3_date_write = ""
            _nym3_type = ""
            _dl_nym3 = ""
            _nym3_wish_med = ""
            _nym3_no = ""
            _nym3_status_id = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional idanym3 As String = "",
                           Optional processid As String = "", Optional nym3type As String = "", Optional dlnym3 As String = "",
                           Optional nym3wishmed As String = "", Optional nym3no As String = "", Optional opentime As String = "",
                           Optional nym3statusid As String = "")

            _citicen = citizen_id
            _nym3_ida = idanym3
            _process_id = processid
            _nym3_date_write = opentime
            _nym3_type = nym3type
            _dl_nym3 = dlnym3
            _nym3_wish_med = nym3wishmed
            _nym3_no = nym3no
            _nym3_status_id = nym3statusid
        End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_NYM_3_SM
            Dim class_xml As New CLASS_NYM_3_SM
            Dim dao_dalcn_edit As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_3
            class_xml.NYM_3s = AddValue(class_xml.NYM_3s)
            class_xml.NYM_3s.DL = 0
            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            'class_xml.EXP_YEAR = ""
            'class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            class_xml.SHOW_LCNNO = ""
            'class_xml.phr_medical_type = ""
            Return class_xml


        End Function

    End Class

    Public Class NYM4_IMPORT_SUB                  'เริ่มทำตรงนี้////////////////////////////////////////////////////////////////////////////////////
        Inherits Center

        Private _citicen As String
        Private _nym4_ida As String
        Private _process_id As String
        Private _nym4_date_write As String
        Private _nym4_type As String
        Private _dl_nym4 As String
        Private _nym4_wish_med As String
        Private _nym4_no As String
        Private _nym4_status_id As String
        Public Sub New()

            _citicen = ""
            _nym4_ida = ""
            _process_id = ""
            _nym4_date_write = ""
            _nym4_type = ""
            _dl_nym4 = ""
            _nym4_wish_med = ""
            _nym4_no = ""
            _nym4_status_id = ""
        End Sub

        Public Sub New(Optional citizen_id As String = "", Optional idanym4 As String = "",
                       Optional processid As String = "", Optional nym4type As String = "", Optional dlnym4 As String = "",
                       Optional nym4wishmed As String = "", Optional nym4no As String = "", Optional opentime As String = "",
                       Optional nym4statusid As String = "")

            _citicen = citizen_id
            _nym4_ida = idanym4
            _process_id = processid
            _nym4_date_write = opentime
            _nym4_type = nym4type
            _dl_nym4 = dlnym4
            _nym4_wish_med = nym4wishmed
            _nym4_no = nym4no
            _nym4_status_id = nym4statusid
        End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_NYM_4_SM
            Dim class_xml As New CLASS_NYM_4_SM
            Dim dao_dalcn_edit As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4
            class_xml.NYM_4s = AddValue(class_xml.NYM_4s)
            class_xml.NYM_4s.DL = 0
            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            'class_xml.EXP_YEAR = ""
            'class_xml.LCNNO_SHOW = ""
            class_xml.RCVDAY = ""
            class_xml.RCVMONTH = ""
            class_xml.RCVYEAR = ""
            class_xml.SHOW_LCNNO = ""
            'class_xml.phr_medical_type = ""
            Return class_xml


        End Function

    End Class
    Public Class NYM4_IMPORT_2
        Inherits Center
        Private _NYM4_DATE_TOP As String
        Private _NYM_TYPE As String
        Private _DL As String
        Private _NYM4_WISH_MED As String
        Private _NYM4_NO As String
        Private _STATUS_ID As String
        'Private _CHK_SELL_TYPE1 As String
        'Private _phr_medical_type As String
        'Private _opentime As String
        Public Sub New()
            _NYM4_DATE_TOP = ""
            _NYM_TYPE = 0
            _DL = ""
            _NYM4_WISH_MED = ""
            _NYM4_NO = ""
            _STATUS_ID = ""
            '_CHK_SELL_TYPE = ""
            ''_CHK_SELL_TYPE1 = ""
            '_phr_medical_type = ""
            '_opentime = ""
        End Sub

        Public Sub New(Optional NYM4_DATE_TOP As String = "", Optional NYM_TYPE As String = "0",
                       Optional DL As String = "", Optional NYM4_WISH_MED As String = "", Optional NYM2_NO As String = "", Optional STATUS_ID As String = "")
            _NYM4_DATE_TOP = NYM4_DATE_TOP
            _NYM_TYPE = NYM_TYPE
            _DL = DL
            _NYM4_WISH_MED = NYM4_WISH_MED
            _NYM4_NO = NYM2_NO
            _STATUS_ID = STATUS_ID
        End Sub

        'Sub New(cityzen_id As String, lcnsid As Integer, lcnno As String, p4 As String, p5 As String)
        '    ' TODO: Complete member initialization 
        '    _cityzen_id = cityzen_id
        '    _lcnsid = lcnsid
        '    _lcnno = lcnno
        '    _p4 = p4
        '    _p5 = p5
        'End Sub

        ''' <summary>
        ''' ใบอนุญาต
        ''' </summary>
        ''' <param name="rows"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function gen_xml(Optional rows As Integer = 0) As CLASS_NYM_4_COMPANY
            Dim class_xml As New CLASS_NYM_4_COMPANY
            Dim dao_edt As New DAO_DRUG_IMPORT.TB_FDA_DRUG_IMPORT_NYM_4_COMPANY
            'dao_dalcn.GetDataby_lcnsid_lcnno(_lcnsid_customer, _lcnno)


            'Intial Default Value
            class_xml.NYM_4_COMPANYs = AddValue(class_xml.NYM_4_COMPANYs)
            class_xml.NYM_4_COMPANYs.TR_ID = 0

            '_______________SHOW___________________
            Dim bao_show As New BAO_SHOW
            'class_xml.DT_SHOW.DT1 = bao_show.SP_SP_SYSCHNGWT
            'class_xml.DT_SHOW.DT2 = bao_show.SP_SP_SYSAMPHR
            'class_xml.DT_SHOW.DT3 = bao_show.SP_SP_SYSTHMBL
            'class_xml.DT_SHOW.DT4 = bao_show.SP_MAINPERSON_CTZNO(_CITIEZEN_ID)
            ''class_xml.DT_SHOW.DT5 = bao_show.SP_MAINCOMPANY_LCNSID(_lcnsid_customer, dao_dalcn.fields.lctcd)
            'class_xml.DT_SHOW.DT10 = bao_show.SP_SYSPREFIX

            '_______________MASTER_________________
            Dim bao_master As New BAO_MASTER

            ' class_xml.DT_MASTER.DT1 = bao_master.SP_MASTER_daphrcd()
            Return class_xml
        End Function
    End Class
End Namespace
