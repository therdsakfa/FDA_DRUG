''' <summary>
''' SOP STAFF เป็นตัวหลักที่จะใช้
''' </summary>
Public Class SOP_STAFF

    Private _STAFF_WORK As New STAFF_WORK
    Public Property STAFF_WORK() As STAFF_WORK
        Get
            Return _STAFF_WORK
        End Get
        Set(ByVal value As STAFF_WORK)
            _STAFF_WORK = value
        End Set
    End Property


    Private _SOP_CURRENT As New SOP_DATA
    Public Property SOP_CURRENT() As SOP_DATA
        Get
            Return _SOP_CURRENT
        End Get
        Set(ByVal value As SOP_DATA)
            _SOP_CURRENT = value
        End Set
    End Property


    Private _SOP_NEXT As New SOP_DATA_NEXT
    Public Property SOP_NEXT() As SOP_DATA_NEXT
        Get
            Return _SOP_NEXT
        End Get
        Set(ByVal value As SOP_DATA_NEXT)
            _SOP_NEXT = value
        End Set
    End Property

End Class




Public Class SOP_DATA
    ' สถานะ
    Private _SOP_STATUS As String
    Public Property SOP_STATUS() As String
        Get
            Return _SOP_STATUS
        End Get
        Set(ByVal value As String)
            _SOP_STATUS = value
        End Set
    End Property

    ' ชื่อสถานะ
    Private _SOP_STATUS_NAME As String
    Public Property SOP_STATUS_NAME() As String
        Get
            Return _SOP_STATUS_NAME
        End Get
        Set(ByVal value As String)
            _SOP_STATUS_NAME = value
        End Set
    End Property


    ' SYSTEM ใช้เป็นอักษรย่อ เช่น FOOD CMT NCT อย่าใช้ 1 2 3 4 5 6
    Private _SOP_SYSTEM_ID As String
    Public Property SOP_SYSTEM_ID() As String
        Get
            Return _SOP_SYSTEM_ID
        End Get
        Set(ByVal value As String)
            _SOP_SYSTEM_ID = value
        End Set
    End Property

    ' รหัสจังหวัด
    Private _SOP_PVNCD As String
    Public Property SOP_PVNCD() As String
        Get
            Return _SOP_PVNCD
        End Get
        Set(ByVal value As String)
            _SOP_PVNCD = value
        End Set
    End Property

    ' รหัสกระบวนการ
    Private _SOP_PROCESS_ID As String
    Public Property SOP_PROCESS_ID() As String
        Get
            Return _SOP_PROCESS_ID
        End Get
        Set(ByVal value As String)
            _SOP_PROCESS_ID = value
        End Set
    End Property

    ' ประเภทผู้พิจารณา 
    Private _SOP_PERSON_TYPE As String
    Public Property SOP_PERSON_TYPE() As String
        Get
            Return _SOP_PERSON_TYPE
        End Get
        Set(ByVal value As String)
            _SOP_PERSON_TYPE = value
        End Set
    End Property

    ' คำอธิบายเพิ่มเติม
    Private _SOP_STATUS_DES As String
    Public Property SOP_STATUS_DES() As String
        Get
            Return _SOP_STATUS_DES
        End Get
        Set(ByVal value As String)
            _SOP_STATUS_DES = value
        End Set
    End Property

End Class


Public Class SOP_DATA_NEXT

    ' สถานะ กล่องต่อไป
    Private _SOP_STATUS_NEXT As String
    Public Property SOP_STATUS_NEXT() As String
        Get
            Return _SOP_STATUS_NEXT
        End Get
        Set(ByVal value As String)
            _SOP_STATUS_NEXT = value
        End Set
    End Property

    ' ชื่อสถานะ กล่องต่อไป
    Private _SOP_STATUS_NAME_NEXT As String
    Public Property SOP_STATUS_NAME_NEXT() As String
        Get
            Return _SOP_STATUS_NAME_NEXT
        End Get
        Set(ByVal value As String)
            _SOP_STATUS_NAME_NEXT = value
        End Set
    End Property


    ' SYSTEM ใช้เป็นอักษรย่อ เช่น FOOD CMT NCT อย่าใช้ 1 2 3 4 5 6
    Private _SOP_SYSTEM_ID As String
    Public Property SOP_SYSTEM_ID() As String
        Get
            Return _SOP_SYSTEM_ID
        End Get
        Set(ByVal value As String)
            _SOP_SYSTEM_ID = value
        End Set
    End Property

    ' รหัสจังหวัด
    Private _SOP_PVNCD As String
    Public Property SOP_PVNCD() As String
        Get
            Return _SOP_PVNCD
        End Get
        Set(ByVal value As String)
            _SOP_PVNCD = value
        End Set
    End Property

    ' รหัสกระบวนการ
    Private _SOP_PROCESS_ID As String
    Public Property SOP_PROCESS_ID() As String
        Get
            Return _SOP_PROCESS_ID
        End Get
        Set(ByVal value As String)
            _SOP_PROCESS_ID = value
        End Set
    End Property

    ' คำอธิบายเพิ่มเติม
    Private _SOP_STATUS_DES As String
    Public Property SOP_STATUS_DES() As String
        Get
            Return _SOP_STATUS_DES
        End Get
        Set(ByVal value As String)
            _SOP_STATUS_DES = value
        End Set
    End Property


    ' ประเภทผู้พิจารณา 
    Private _SOP_PERSON_TYPE As String
    Public Property SOP_PERSON_TYPE() As String
        Get
            Return _SOP_PERSON_TYPE
        End Get
        Set(ByVal value As String)
            _SOP_PERSON_TYPE = value
        End Set
    End Property
End Class


Public Class STAFF_WORK

    ' เลขบัตรเจ้าหน้าที่
    Private _STAFF_CTZNO As String
    Public Property STAFF_CTZNO() As String
        Get
            Return _STAFF_CTZNO
        End Get
        Set(ByVal value As String)
            _STAFF_CTZNO = value
        End Set
    End Property

    ' วันที่เจ้าหน้าที่ทำงาน
    Private _STAFF_DATE As DateTime
    Public Property STAFF_DATE() As DateTime
        Get
            Return _STAFF_DATE
        End Get
        Set(ByVal value As DateTime)
            _STAFF_DATE = value
        End Set
    End Property


    Private _STAFF_REMARK As String
    Public Property STAFF_REMARK() As String
        Get
            Return _STAFF_REMARK
        End Get
        Set(ByVal value As String)
            _STAFF_REMARK = value
        End Set
    End Property

    Private _STAFF_TYPE As String
    Public Property STAFF_TYPE() As String
        Get
            Return _STAFF_TYPE
        End Get
        Set(ByVal value As String)
            _STAFF_TYPE = value
        End Set
    End Property
End Class

