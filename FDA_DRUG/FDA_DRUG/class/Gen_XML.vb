Imports System.IO
Imports System.Xml.Serialization

Namespace Gen_XML
    Public MustInherit Class CENTER

#Region "Fields"

        Private _IDA As Integer
        Public Property IDA() As Integer
            Get
                Return _IDA
            End Get
            Set(ByVal value As Integer)
                _IDA = value
            End Set
        End Property


        Private _LCNSID As String
        Public Property LCNSID() As String
            Get
                Return _LCNSID
            End Get
            Set(ByVal value As String)
                _LCNSID = value
            End Set
        End Property


        Private _CITIZEN_ID As String
        Public Property CITIZEN_ID() As String
            Get
                Return _CITIZEN_ID
            End Get
            Set(ByVal value As String)
                _CITIZEN_ID = value
            End Set
        End Property

        Private _CITIZEN_AUTHORIZE As String
        Public Property CITIZEN_AUTHORIZE() As String
            Get
                Return _CITIZEN_AUTHORIZE
            End Get
            Set(ByVal value As String)
                _CITIZEN_AUTHORIZE = value
            End Set
        End Property


        Private _lcntpcd As String
        Public Property lcntpcd() As String
            Get
                Return _lcntpcd
            End Get
            Set(ByVal value As String)
                _lcntpcd = value
            End Set
        End Property

        Private _PVNCD As String
        Public Property PVNCD() As String
            Get
                Return _PVNCD
            End Get
            Set(ByVal value As String)
                _PVNCD = value
            End Set
        End Property



#End Region
        Protected Friend Function AddValue(ByVal ob As Object) As Object
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
                        Try
                            props.SetValue(ob, 0, Nothing)
                        Catch ex As Exception
                            props.SetValue(ob, Nothing, Nothing)
                        End Try


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
        Function AddDatatable(ByVal dt As DataTable) As DataTable
            Dim dr As DataRow = dt.NewRow
            For Each c As DataColumn In dt.Columns
                If c.DataType.ToString() = "System.String" Then
                    dr(c.ColumnName) = ""
                Else

                End If

            Next

            dt.Rows.Add(dr)
            Return dt
        End Function


  
        Public Sub CREATE_XML_NCT_LCTADDR(ByVal PATH As String, ByVal p2 As CLS_LOCATION)
            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()
        End Sub

        Public Sub CREATE_XML_TRANFER_LOCATION(ByVal PATH As String, ByVal p2 As XML_TRANFER_LOCATION)
            Dim objStreamWriter As New StreamWriter(PATH)
            Dim x As New XmlSerializer(p2.GetType)
            x.Serialize(objStreamWriter, p2)
            objStreamWriter.Close()
        End Sub

    End Class

    Public Class GEN_XML_TRANFER_LOCATION
        Inherits CENTER

        Public Function GEN_XML_TRANFER_LOCATION(Optional rows As Integer = 0) As XML_TRANFER_LOCATION

            Dim class_xml As New XML_TRANFER_LOCATION
            'Intial Default Value
            class_xml.TRANFER_LOCATIONs = AddValue(class_xml.TRANFER_LOCATIONs)



            Return class_xml

        End Function
    End Class
  

    Public Class GEN_XML_NCT_LCT_ADDR
        Inherits CENTER

        Public Function gen_xml_nct_lctaddr(Optional rows As Integer = 0) As CLS_LOCATION

            Dim class_xml As New CLS_LOCATION
            'Intial Default Value
            class_xml.NCT_LCTADDRs = AddValue(class_xml.NCT_LCTADDRs)

            For i As Integer = 0 To rows
                Dim cls_LOCATION_BSN As New LOCATION_BSN
                cls_LOCATION_BSN = AddValue(cls_LOCATION_BSN)
                class_xml.LOCATION_BSNs.Add(cls_LOCATION_BSN)
            Next

            Return class_xml

        End Function
    End Class
End Namespace


