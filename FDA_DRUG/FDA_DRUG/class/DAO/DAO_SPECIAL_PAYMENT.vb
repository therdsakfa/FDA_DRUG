
Namespace DAO_SPECIAL_PAYMENT
    Public MustInherit Class MainContext
        ''' <summary>
        ''' ตัวแปรสำหรับเรียกใช้ CONTEXT ของ LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public DB As New LINQ_SP_PAYMENTDataContext
        ''' <summary>
        ''' OBJECT เก็บค่าจาก LINQ
        ''' </summary>
        ''' <remarks></remarks>
        Public datas

        Private _ID As Integer
        ''' <summary>
        ''' ID สำหรับเรียกใช้ PK ของตาราง
        ''' </summary>
        Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        Public dt As DataTable
    End Class

    Public Class TB_SYSTEMS_PAYMENT_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง RETURN_MONEY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New SYSTEMS_PAYMENT_DETAIL

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_IDA(ByVal IDA As Integer)
            datas = From p In DB.SYSTEMS_PAYMENT_DETAILs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.SYSTEMS_PAYMENT_DETAILs.InsertOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        ''' <summary>
        ''' แก้ไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub update()
            DB.SubmitChanges()
        End Sub
        ''' <summary>
        ''' ลบข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub delete()
            DB.SYSTEMS_PAYMENT_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        '------------------------------------------------------------------------------
        Public Sub GetDataby_REF_NO(ByVal REF_NO As String)
            datas = (From p In DB.SYSTEMS_PAYMENT_DETAILs Where p.REF_NO = REF_NO Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_REF_NO_IDENTIFY_AUTHERIZED_STATUS_ID(ByVal REF_NO As String, ByVal IDENTIFY_AUTHERIZED As String, ByVal STATUS_ID As Integer)
            datas = (From p In DB.SYSTEMS_PAYMENT_DETAILs Where p.REF_NO = REF_NO And p.IDENTIFY_AUTHERIZED = IDENTIFY_AUTHERIZED And p.STATUS_ID = STATUS_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub


        Public Sub GetDataby_REF_NO_STATUS_ID(ByVal REF_NO As String, ByVal STATUS_ID As Integer)
            datas = (From p In DB.SYSTEMS_PAYMENT_DETAILs Where p.REF_NO = REF_NO And p.STATUS_ID = STATUS_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_REF_NO_SYSTEMS_ID(ByVal REF_NO As String, ByVal SYSTEMS_ID As String)
            datas = (From p In DB.SYSTEMS_PAYMENT_DETAILs Where p.REF_NO = REF_NO And p.SYSTEMS_ID = SYSTEMS_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_REF_NO_STATUS_8_9(ByVal REF_NO As String, ByVal SYSTEMS_ID As String)
            datas = (From p In DB.SYSTEMS_PAYMENT_DETAILs Where p.REF_NO = REF_NO And (p.STATUS_ID = 8 Or p.STATUS_ID = 9) Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_SYSTEMS_ID(ByVal SYSTEMS_ID As String)
            datas = (From p In DB.SYSTEMS_PAYMENT_DETAILs Where p.SYSTEMS_ID = SYSTEMS_ID And (p.STATUS_ID = 8 Or p.STATUS_ID = 9) Select p Order By p.PAYMENT_DATE Ascending)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_SYSTEMS_ID_ALL(ByVal SYSTEMS_ID As String)
            datas = (From p In DB.SYSTEMS_PAYMENT_DETAILs Where (p.STATUS_ID = 8 Or p.STATUS_ID = 9) Select p Order By p.PAYMENT_DATE Descending)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_SYSTEMS_ID_for_RCVNO(ByVal SYSTEMS_ID As String)
            datas = (From p In DB.SYSTEMS_PAYMENT_DETAILs Where p.SYSTEMS_ID = SYSTEMS_ID And (p.STATUS_ID = 8 Or p.STATUS_ID = 9) And p.RCVNO Like "*-R" Select p Order By p.PAYMENT_DATE Ascending)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_SPD_LOG

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง CURE_STUDY
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New SPD_LOG
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In DB.SPD_LOGs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.SPD_LOGs.InsertOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        ''' <summary>
        ''' แก้ไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub update()
            DB.SubmitChanges()
        End Sub
        ''' <summary>
        ''' ลบข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub delete()
            DB.SPD_LOGs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_REQUEST_TEMPLATE
        Inherits MainContext
        Public fields As New REQUEST_TEMPLATE

        Public Sub insert()
            DB.REQUEST_TEMPLATEs.InsertOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        Public Sub update()
            DB.SubmitChanges()
        End Sub

        Public Sub delete()
            DB.REQUEST_TEMPLATEs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In DB.REQUEST_TEMPLATEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In DB.REQUEST_TEMPLATEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_REQUEST_ID(ByVal REQUEST_ID As String)
            datas = (From p In DB.REQUEST_TEMPLATEs Where p.REQUEST_ID = REQUEST_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_REQUEST_ID_and_SYSTEMS_ID(ByVal REQUEST_ID As String, ByVal SYSTEMS_ID As Integer)
            datas = (From p In DB.REQUEST_TEMPLATEs Where p.REQUEST_ID = REQUEST_ID And p.SYSTEMS_ID = SYSTEMS_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_SYSTEMS_ID(ByVal SYSTEMS_ID As Integer)
            datas = (From p In DB.REQUEST_TEMPLATEs Where p.SYSTEMS_ID = SYSTEMS_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_SYSTEMS_ID_and_TYPE(ByVal SYSTEMS_ID As Integer, ByVal TYPE As String)
            datas = (From p In DB.REQUEST_TEMPLATEs Where p.SYSTEMS_ID = SYSTEMS_ID And p.TYPE = TYPE Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_SYSTEMS_ID_and_PRICE(ByVal SYSTEMS_ID As Integer, ByVal PRICE As Double)
            datas = (From p In DB.REQUEST_TEMPLATEs Where p.SYSTEMS_ID = SYSTEMS_ID And p.PRICE = PRICE Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_SYSTEMS_ID_and_PRICE(ByVal PRICE As Double)
            datas = (From p In DB.REQUEST_TEMPLATEs Where p.PRICE = PRICE Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
End Namespace