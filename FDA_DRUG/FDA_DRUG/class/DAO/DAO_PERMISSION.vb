Namespace DAO_PERMISSION
    Public MustInherit Class MAINCONTEXT1
        Public db As New LINQ_PERMISSIONDataContext

        Public datas
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class
    Public Class TB_taxnogrouppermission
        Inherits MAINCONTEXT1
        Public fields As New taxnogrouppermission
        Public Sub insert()
            db.taxnogrouppermissions.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.taxnogrouppermissions.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.taxnogrouppermissions Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDgroup(ByVal IDgroup As Integer)
            datas = (From p In db.taxnogrouppermissions Where p.IDgroup = IDgroup Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDgroup_and_Iden(ByVal IDgroup As Integer, ByVal iden As String)
            datas = (From p In db.taxnogrouppermissions Where p.IDgroup = IDgroup And p.taxno = iden Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
End Namespace
