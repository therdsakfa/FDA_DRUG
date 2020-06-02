Public Class UC_ATTACH
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private _NAME As String
    Public Property NAME() As String
        Get
            Return _NAME
        End Get
        Set(ByVal value As String)
            _NAME = value
        End Set
    End Property


    Public Sub BindData(ByVal name As String, ByVal piority As Integer, ByVal extension As String, ByVal lcntpcd As String, ByVal type As String)
        Label1.Text = name
        HiddenField1.Value = piority
        HiddenField2.Value = lcntpcd
        H_TYPE.Value = type
    End Sub

    Public Function insert(ByVal TR_ID As Integer) As Boolean
        Dim result As Boolean = True
        If HiddenField1.Value = 0 Then ' ไม่จำเป็นต้องมี
            If FileUpload1.HasFile Then

                insert_file(TR_ID)
            End If
        Else 'จำเป็นต้องแนบ
            If FileUpload1.HasFile Then
                insert_file(TR_ID)
            Else
                NAME = Label1.Text
                result = False
            End If
        End If
        Return result
    End Function

    Private Sub insert_file(ByVal TR_ID As Integer)
        Dim extensionname As String = GetExtension(FileUpload1.FileName)
        FileUpload1.SaveAs(_PATH_DEFALUT & "/upload/" & TR_ID & "_" & H_TYPE.Value & "." & extensionname)
        Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH


        dao_file.fields.NAME_FAKE = TR_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_REAL = FileUpload1.FileName
        'dao_file.fields.CREATE_DATE = Date.Now
        dao_file.fields.Description = Label1.Text
        'dao_file.fields.EXTENSION = extensionname
        'dao_file.fields.PATH = "upload"
        'dao_file.fields.UPDATE_DATE = Date.Now
        dao_file.fields.TYPE = H_TYPE.Value
        'dao_file.fields.LCNTPCD = HiddenField2.Value
        dao_file.fields.TRANSACTION_ID = TR_ID
        dao_file.insert()
    End Sub
End Class