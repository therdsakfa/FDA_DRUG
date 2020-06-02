Namespace DAO


    Public MustInherit Class MAINCONTEXT
        Public db As New Linq_DRUGDataContext

        Public datas


        Public Sub Convert_TO_XML(ByVal filename As String, ByVal type As String, ByVal obj As Object)

        End Sub
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class
  

    Public Class DBdalcn
        Inherits MAINCONTEXT
        Public fields As New dalcn
        Public Sub insert()
            db.dalcns.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.dalcns.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.dalcns Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnno(ByVal lcnno As Integer)
            datas = (From p In db.dalcns Where p.lcnno Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_ID(ByVal ID As Integer)
            datas = (From p In db.dalcns Where p.ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid_lcnno(ByVal lcnsid As Integer, ByVal lcnno As Integer)
            datas = (From p In db.dalcns Where p.lcnsid = lcnsid And p.lcnno Select p)
            For Each Me.fields In datas
            Next
        End Sub
     
    End Class

    Public Class DBdarqt
        Inherits MAINCONTEXT
        Public fields As New darqt
        Public Sub insert()
            db.darqts.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.darqts.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.darqts Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnno(ByVal lcnno As Integer)
            datas = (From p In db.darqts Where p.lcnno Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class DBdarqtphr
        Inherits MAINCONTEXT
        Public fields As New darqtphr
        Public Sub insert()
            db.darqtphrs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.darqtphrs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.darqtphrs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnno(ByVal lcnno As Integer)
            datas = (From p In db.darqtphrs Where p.rcvno Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


#Region "ทั่วไป"
    'Public Class clsDBTRANSESSION_LOG
    '    Inherits MAINCONTEXT
    '    Public fields As New TRANSESSION_LOG
    '    Public Sub insert()
    '        db.TRANSESSION_LOGs.InsertOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub delete()
    '        db.TRANSESSION_LOGs.DeleteOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub GetDataAll()
    '        datas = (From p In db.TRANSESSION_LOGs Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GetDataby_TRANSESSION_ID(ByVal TRANSESSION_ID As Integer)
    '        datas = (From p In db.TRANSESSION_LOGs Where p.TRANSESSION_ID Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    'End Class

    Public Class CLC_SYSPLACE
        Inherits MAINCONTEXT

        Public fields As New sysplace
        Public Sub insert()
            db.sysplaces.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.sysplaces.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.sysplaces Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnno(ByVal lcnno As Integer)
            datas = (From p In db.sysplaces Where p.rcvno Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

#End Region
End Namespace
