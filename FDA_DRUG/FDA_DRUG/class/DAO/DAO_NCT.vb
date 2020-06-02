Namespace DAO_NCT
    Public MustInherit Class MAINCONTEXT
        Public db As New Linq_NCTDataContext

        Public datas
    End Class
    Public Class TB_MAS_NCT_LOCATION_TYPE
        Inherits MAINCONTEXT
        Public fields As New MAS_NCT_LOCATION_TYPE
        Private _Details As List(Of MAS_NCT_LOCATION_TYPE)
        Public Property Details() As List(Of MAS_NCT_LOCATION_TYPE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of MAS_NCT_LOCATION_TYPE))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New MAS_NCT_LOCATION_TYPE
        End Sub
        Public Sub delete()
            db.MAS_NCT_LOCATION_TYPEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert()
            db.MAS_NCT_LOCATION_TYPEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub Getdata_all()
            datas = (From q In db.MAS_NCT_LOCATION_TYPEs Select q)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_byid(ByVal id As Integer)
            datas = (From q In db.MAS_NCT_LOCATION_TYPEs Where q.IDA = id Select q)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub Getdata_by_NCT_LOCATION_TYPE_ID(ByVal NCT_LOCATION_TYPE_ID As Integer)
            datas = (From q In db.MAS_NCT_LOCATION_TYPEs Where q.NCT_LOCATION_TYPE_ID = NCT_LOCATION_TYPE_ID Select q)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
End Namespace
