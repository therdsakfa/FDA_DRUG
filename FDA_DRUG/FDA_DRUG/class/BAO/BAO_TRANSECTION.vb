Public Class BAO_TRANSECTION

    Private _CITIZEN_ID As String
    Public Property CITIZEN_ID() As String
        Get
            Return _CITIZEN_ID
        End Get
        Set(ByVal value As String)
            _CITIZEN_ID = value
        End Set
    End Property

    Private _CITIZEN_ID_AUTHORIZE As String
    Public Property CITIZEN_ID_AUTHORIZE() As String
        Get
            Return _CITIZEN_ID_AUTHORIZE
        End Get
        Set(ByVal value As String)
            _CITIZEN_ID_AUTHORIZE = value
        End Set
    End Property



    Public Function insert_transection(ByVal processid As Integer) As Integer

        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        dao_up.fields.CITIEZEN_ID = _CITIZEN_ID
        dao_up.fields.CITIEZEN_ID_AUTHORIZE = _CITIZEN_ID_AUTHORIZE
        dao_up.fields.PROCESS_ID = processid
        dao_up.fields.STATUS = 1
        dao_up.fields.UPLOAD_DATE = Date.Now()
        dao_up.fields.YEAR = con_year(Date.Now().Year())
        dao_up.insert() 'ปรับเป็น update
        Return dao_up.fields.ID

    End Function

  

End Class
