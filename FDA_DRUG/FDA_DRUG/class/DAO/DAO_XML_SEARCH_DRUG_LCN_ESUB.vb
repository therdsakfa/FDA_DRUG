Namespace DAO_XML_SEARCH_DRUG_LCN_ESUB
    Public MustInherit Class MAINCONTEXT2      'ประกาศเพื่อใช้เป็น Class แม่
        Public db As New LINQ_FDA_XML_DRUG_ESUBDataContext   'ประกาศเพื่อใช้เป็น Class LINQ DataTable


        Public datas                            'ประกาศเ

    End Class
    Public Class TB_XML_SEARCH_DRUG_LCN_ESUB
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_SEARCH_DRUG_LCN_ESUB

        Public Sub insert()
            db.XML_SEARCH_DRUG_LCN_ESUBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_SEARCH_DRUG_LCN_ESUBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_ESUBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_identify(ByVal iden As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_ESUBs Where p.CITIZEN_AUTHORIZE = iden Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_lcnsid(ByVal lcnsid As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_ESUBs Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.XML_SEARCH_DRUG_LCN_ESUBs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_u1(ByVal u1 As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_ESUBs Where p.Newcode_not = u1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnno_no(ByVal lcnno_no As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_ESUBs Where p.lcnno_no = lcnno_no Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_SEARCH_PRODUCT_GROUP_ESUB
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_SEARCH_PRODUCT_GROUP_ESUB

        Public Sub insert()
            db.XML_SEARCH_PRODUCT_GROUP_ESUBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_SEARCH_PRODUCT_GROUP_ESUBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_identify(ByVal iden As String)

            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Where p.CITIZEN_AUTHORIZE = iden Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_IDA_drrgt(ByVal IDA As Integer)

            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Where p.IDA_drrgt = IDA And p.frn_no = "1" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_NEWCODE(ByVal u1 As String)

            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Where p.Newcode_U = u1 And p.frn_no = "1" Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_4Key(ByVal rgtno As String, ByVal rgttpcd As String, ByVal drgtpcd As String, ByVal pvncd As String)

            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Where p.rgtno = rgtno And p.rgttpcd = rgttpcd And p.pvncd = pvncd And p.drgtpcd = drgtpcd And p.frn_no = "1" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_u1(ByVal u1 As String)

            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Where p.Newcode_U = u1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_u1_frn_no(ByVal u1 As String)

            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Where p.Newcode_U = u1 And p.frn_no = "1" Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_FRGN
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_FRGN

        Public Sub insert()
            db.XML_DRUG_FRGNs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_FRGNs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_FRGNs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataALL()

            datas = (From p In db.XML_DRUG_FRGNs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_u1(ByVal u1 As String)
            datas = (From p In db.XML_DRUG_FRGNs Where p.Newcode_U = u1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_IOW
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_IOW
        Private _Details As New List(Of XML_DRUG_IOW)
        Public Property Details() As List(Of XML_DRUG_IOW)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_IOW))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_IOW
        End Sub
        Public Sub insert()
            db.XML_DRUG_IOWs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_IOWs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_IOWs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_IOWs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        'Public Sub GetDataby_IDA_ORDER(ByVal IDA As Integer, ByVal FK_SET As Integer)

        '    datas = (From p In db.XML_DRUG_IOWs Where p.IDA = IDA And p.FK_SET = FK_SET Select p Order By p.ROWS Ascending)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        'Public Sub GetDataby_FK_IDA_ORDER(ByVal FK_IDA As Integer, ByVal FK_SET As Integer)

        '    datas = (From p In db.XML_DRUG_IOWs Where p.FK_IDA = FK_IDA And p.FK_SET = FK_SET Select p Order By CInt(p.ROWS) Ascending)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        'Public Sub GetDataby_ROWs_AND_FK_SET(ByVal ROWs As Integer, ByVal FK_SET As Integer)

        '    datas = (From p In db.XML_DRUG_IOWs Where p.FK_SET = FK_SET And p.ROWS = ROWs Select p)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        'Public Sub GetDataby_IDA_AND_ROWs(ByVal IDA As Integer, ByVal ROWs As Integer)

        '    datas = (From p In db.XML_DRUG_IOWs Where p.IDA = IDA And p.ROWS = ROWs Select p)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        Public Sub GetDataby_Newcode_U(ByVal Newcode_U As String)
            datas = (From p In db.XML_DRUG_IOWs Where p.Newcode_U = Newcode_U Select p)
            For Each Me.fields In datas

            Next
        End Sub

        'Public Function COUNTDataby_FKIDA(ByVal IDA As Integer) As Integer
        '    Dim i As Integer = 0
        '    datas = (From p In db.XML_DRUG_IOWs Where p.FK_IDA = IDA Select p)
        '    For Each Me.fields In datas

        '    Next
        '    Return i
        'End Function
        'Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
        '    datas = (From p In db.XML_DRUG_IOWs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        'Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
        '    datas = (From p In db.XML_DRUG_IOWs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        'Public Sub GET_MIN_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
        '    datas = (From p In db.XML_DRUG_IOWs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Ascending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
    End Class
    Public Class TB_XML_DRUG_IOW_EQ
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_IOW_EQ
        Private _Details As New List(Of XML_DRUG_IOW_EQ)
        Public Property Details() As List(Of XML_DRUG_IOW_EQ)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_IOW_EQ))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_IOW_EQ
        End Sub
        Public Sub insert()
            db.XML_DRUG_IOW_EQs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_IOW_EQs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_IOW_EQs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_IOW_EQs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode_rid_flineno(ByVal newcode_rid As String, ByVal flineno As String)

            datas = (From p In db.XML_DRUG_IOW_EQs Where p.Newcode_rid = newcode_rid Select p)
            For Each Me.fields In datas

            Next
        End Sub
        'Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

        '    datas = (From p In db.XML_DRUG_IOW_EQs Where p.FK_IDA = IDA Select p)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        'Public Sub GetDataby_FK_DRRQT_IDA(ByVal IDA As Integer)

        '    datas = (From p In db.XML_DRUG_IOW_EQs Where p.FK_DRRQT_IDA = IDA Select p)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        'Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
        '    datas = (From p In db.XML_DRUG_IOW_EQs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        'Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
        '    datas = (From p In db.XML_DRUG_IOW_EQs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
    End Class
    '
    Public Class TB_XML_DRUG_RECIPE_GROUP
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_RECIPE_GROUP
        Private _Details As New List(Of XML_DRUG_RECIPE_GROUP)
        Public Property Details() As List(Of XML_DRUG_RECIPE_GROUP)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_RECIPE_GROUP))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_RECIPE_GROUP
        End Sub
        Public Sub insert()
            db.XML_DRUG_RECIPE_GROUPs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_RECIPE_GROUPs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_RECIPE_GROUPs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_RECIPE_GROUPs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal newcode As String)

            datas = (From p In db.XML_DRUG_RECIPE_GROUPs Where p.Newcode = newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_COLOR
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_COLOR
        Private _Details As New List(Of XML_DRUG_COLOR)
        Public Property Details() As List(Of XML_DRUG_COLOR)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_COLOR))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_COLOR
        End Sub
        Public Sub insert()
            db.XML_DRUG_COLORs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_COLORs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_COLORs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_COLORs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal newcode As String)

            datas = (From p In db.XML_DRUG_COLORs Where p.Newcode = newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_STOWAGR
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_STOWAGR
        Private _Details As New List(Of XML_DRUG_STOWAGR)
        Public Property Details() As List(Of XML_DRUG_STOWAGR)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_STOWAGR))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_STOWAGR
        End Sub
        Public Sub insert()
            db.XML_DRUG_STOWAGRs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_STOWAGRs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_STOWAGRs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_STOWAGRs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal newcode As String)

            datas = (From p In db.XML_DRUG_STOWAGRs Where p.Newcode = newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_CONTAIN
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_CONTAIN
        Private _Details As New List(Of XML_DRUG_CONTAIN)
        Public Property Details() As List(Of XML_DRUG_CONTAIN)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_CONTAIN))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_CONTAIN
        End Sub
        Public Sub insert()
            db.XML_DRUG_CONTAINs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_CONTAINs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_CONTAINs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_CONTAINs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal newcode As String)

            datas = (From p In db.XML_DRUG_CONTAINs Where p.Newcode = newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_ANIMAL
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_ANIMAL
        Private _Details As New List(Of XML_DRUG_ANIMAL)
        Public Property Details() As List(Of XML_DRUG_ANIMAL)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_ANIMAL))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_ANIMAL
        End Sub
        Public Sub insert()
            db.XML_DRUG_ANIMALs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_ANIMALs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_ANIMALs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_ANIMALs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal newcode As String)

            datas = (From p In db.XML_DRUG_ANIMALs Where p.Newcode = newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_ANIMAL_CONSUME
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_ANIMAL_CONSUME
        Private _Details As New List(Of XML_DRUG_ANIMAL_CONSUME)
        Public Property Details() As List(Of XML_DRUG_ANIMAL_CONSUME)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_ANIMAL_CONSUME))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_ANIMAL_CONSUME
        End Sub
        Public Sub insert()
            db.XML_DRUG_ANIMAL_CONSUMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_ANIMAL_CONSUMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_ANIMAL_CONSUMEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_ANIMAL_CONSUMEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal newcode As String)

            datas = (From p In db.XML_DRUG_ANIMAL_CONSUMEs Where p.Newcode = newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    '
    Public Class TB_XML_DRUG_NO_USE
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_NO_USE
        Private _Details As New List(Of XML_DRUG_NO_USE)
        Public Property Details() As List(Of XML_DRUG_NO_USE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_NO_USE))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_NO_USE
        End Sub
        Public Sub insert()
            db.XML_DRUG_NO_USEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_NO_USEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_NO_USEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_NO_USEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal newcode As String)

            datas = (From p In db.XML_DRUG_NO_USEs Where p.Newcode = newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
End Namespace
