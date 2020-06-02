Namespace DAO_BOOKING


    Public MustInherit Class MAINCONTEXT        'ประกาศเพื่อใช้เป็น Class แม่
        Public db As New LINQ_BOOKINGDataContext   'ประกาศเพื่อใช้เป็น Class LINQ DataTable
        Public datas                            'ประกาศเ

    End Class
    Public Class CLS_DOCUMENT_TYPE
        Inherits MAINCONTEXT
        Public fields As New DOCUMENT_TYPE

        Public Sub insert()
            db.DOCUMENT_TYPEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DOCUMENT_TYPEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.DOCUMENT_TYPEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_DOCUMENT_TYPE_ID(ByVal DOCUMENT_TYPE_ID As Integer)
            datas = (From p In db.DOCUMENT_TYPEs Where p.DOCUMENT_TYPE_ID = DOCUMENT_TYPE_ID Order By p.DOCUMENT_TYPE_NAME Select p)
            For Each Me.fields In datas
            Next
        End Sub


        Public Sub GetDataby_DEPARTMENT_ID(ByVal DEPARTMENT_ID As Integer)
            datas = (From p In db.DOCUMENT_TYPEs Where p.DEPARTMENT_TYPE_ID = DEPARTMENT_ID Order By p.DOCUMENT_TYPE_NAME Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class CLS_CHANNEL
        Inherits MAINCONTEXT
        Public fields As New CHANNEL

        Public Sub insert()
            db.CHANNELs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CHANNELs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.CHANNELs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_CHANNEL_ID(ByVal CHANNEL_ID As Integer)
            datas = (From p In db.CHANNELs Where p.CHANNEL_ID = CHANNEL_ID Order By p.CHANNEL_NAME Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_DEPARTMENT_TYPE_ID_and_ACTIVE(ByVal DEPARTMENT_TYPE_ID As Integer)
            datas = (From p In db.CHANNELs Where p.DEPARTMENT_TYPE_ID = DEPARTMENT_TYPE_ID And (p.ACTIVE <> "NO") Order By p.CHANNEL_NAME Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_DEPARTMENT_TYPE_ID(ByVal DEPARTMENT_TYPE_ID As Integer)
            datas = (From p In db.CHANNELs Where p.DEPARTMENT_TYPE_ID = DEPARTMENT_TYPE_ID Order By p.CHANNEL_NAME Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_DEPARTMENT_TYPE_ID_and_DOCUMENT_TYPE_ID_ACTIVE(ByVal DEPARTMENT_TYPE_ID As Integer, ByVal DOCUMENT_TYPE_ID As String)
            datas = (From p In db.CHANNELs Where p.DEPARTMENT_TYPE_ID = DEPARTMENT_TYPE_ID And p.DOCUMENT_TYPE_ID = DOCUMENT_TYPE_ID And (p.ACTIVE <> "NO") Order By p.CHANNEL_NAME Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class CLS_SCHEDULE
        Inherits MAINCONTEXT
        Public fields As New SCHEDULE

        Public Sub insert()
            db.SCHEDULEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.SCHEDULEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.SCHEDULEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_SCHEDULE_ID(ByVal SCHEDULE_ID As Integer)
            datas = (From p In db.SCHEDULEs Where p.SCHEDULE_ID = SCHEDULE_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub



        Public Sub GetDataby_SCHEDULE_ID_AND_COME_TRUE(ByVal SCHEDULE_ID As Integer)
            datas = (From p In db.SCHEDULEs Where p.SCHEDULE_ID = SCHEDULE_ID And p.COME_STATUS_ID = 1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_SCHEDULE_DATE(ByVal SCHEDULE_DATE As Date)
            datas = (From p In db.SCHEDULEs Where p.SCHEDULE_DATE = SCHEDULE_DATE Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_SCHEDULE_ID_AND_BOOKING_IDENTIFICATION_CARD_NO(ByVal SCHEDULE_ID As Integer, ByVal BOOKING_IDENTIFICATION_CARD_NO As String)
            datas = (From p In db.SCHEDULEs Where p.SCHEDULE_ID = SCHEDULE_ID And p.BOOKING_IDENTIFICATION_CARD_NO = BOOKING_IDENTIFICATION_CARD_NO Select p)
            For Each Me.fields In datas
            Next
        End Sub


        Public Sub GetDataby_PRODUCT_ID_and_Order_By_SCHEDULE_DATE(ByVal PRODUCT_ID As Integer)
            datas = (From p In db.SCHEDULEs Where p.PRODUCT_ID = PRODUCT_ID Select p Take 1 Order By p.SCHEDULE_DATE Descending)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_SCHEDULE_ID_and_Order_By_SCHEDULE_DATE(ByVal SCHEDULE_ID As Integer)
            datas = (From p In db.SCHEDULEs Where p.SCHEDULE_ID = SCHEDULE_ID Select p Take 1 Order By p.SCHEDULE_DATE Descending)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Order_By_SCHEDULE_DATE_TEST()
            datas = (From p In db.SCHEDULEs Select p Take 1 Order By p.SCHEDULE_DATE Descending)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_FILE_ATTACH
        Inherits MAINCONTEXT
        Public fields As New FILE_ATTACHV2

        Public Sub insert()
            db.FILE_ATTACHV2s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.FILE_ATTACHV2s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.FILE_ATTACHV2s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.FILE_ATTACHV2s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.FILE_ATTACHV2s Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_LOG_UPDATE_STATUS
        Inherits MAINCONTEXT
        Public fields As New LOG_UPDATE_STATUS

        Public Sub insert()
            db.LOG_UPDATE_STATUS.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LOG_UPDATE_STATUS.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.LOG_UPDATE_STATUS Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.LOG_UPDATE_STATUS Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_MAS_STATUS
        Inherits MAINCONTEXT
        Public fields As New MAS_STATUSV2

        Public Sub insert()
            db.MAS_STATUSV2s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_STATUSV2s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.MAS_STATUSV2s Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetData_status(ByVal SYSTEM_ID As String)
            datas = (From p In db.MAS_STATUSV2s Where p.DEPARTMENT_TYPE_ID = SYSTEM_ID And (p.GROUP_ID = "1" Or p.GROUP_ID = "2" Or p.GROUP_ID = "3" Or p.GROUP_ID = "5" Or p.GROUP_ID = "6" Or p.GROUP_ID = "7") Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetData_by_GROUP_ID_DEPARTMENT_TYPE_ID(ByVal GROUP_ID As String, ByVal DEPARTMENT_TYPE_ID As String)
            datas = (From p In db.MAS_STATUSV2s Where p.GROUP_ID = GROUP_ID And p.DEPARTMENT_TYPE_ID = DEPARTMENT_TYPE_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub


        Public Sub GetData_by_DEPARTMENT_TYPE_ID(ByVal DEPARTMENT_TYPE_ID As String)
            datas = (From p In db.MAS_STATUSV2s Where p.DEPARTMENT_TYPE_ID = DEPARTMENT_TYPE_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetData_by_DEPARTMENT_TYPE_ID_ORDER_SEQ(ByVal DEPARTMENT_TYPE_ID As String)
            datas = (From p In db.MAS_STATUSV2s Where p.DEPARTMENT_TYPE_ID = DEPARTMENT_TYPE_ID Select p Order By p.SEQ Ascending)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetData_by_DEPARTMENT_TYPE_ID_ORDER_SEQ_ACTIVE(ByVal DEPARTMENT_TYPE_ID As String)
            datas = (From p In db.MAS_STATUSV2s Where p.DEPARTMENT_TYPE_ID = DEPARTMENT_TYPE_ID And p.ACTIVE = "TRUE" Select p Order By p.SEQ Ascending)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_DRUG_GENNO
        Inherits MAINCONTEXT
        Public fields As New DRUG_GENNO

        Public Sub insert()
            db.DRUG_GENNOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_GENNOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.DRUG_GENNOs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.DRUG_GENNOs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Year_PVNCD_PROCESS_ID_MAX(ByVal PVNCD As String, ByVal YEARS As Integer, ByVal PROCESS_ID As String)
            datas = (From p In db.DRUG_GENNOs Where p.PVNCD = PVNCD And p.YEAR = YEARS And p.PROCESS_ID = PROCESS_ID Order By p.GENNO Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_YEAR_SYSTEM_TYPE(ByVal YEAR As String, ByVal SYSTEM_ID As String, ByVal TYPE_ID As String)
            datas = (From p In db.DRUG_GENNOs Where p.YEAR = YEAR And p.SYSTEM_ID = SYSTEM_ID And p.TYPE_ID = TYPE_ID Select p Order By p.IDA)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_DRUG_SCHEDULE
        Inherits MAINCONTEXT
        Public fields As New DRUG_SCHEDULE

        Public Sub insert()
            db.DRUG_SCHEDULEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_SCHEDULEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.DRUG_SCHEDULEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_SCHEDULE_ID(ByVal SCHEDULE_ID As Integer)
            datas = (From p In db.DRUG_SCHEDULEs Where p.SCHEDULE_ID = SCHEDULE_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_SCHEDULE_ID_AND_COME_TRUE(ByVal SCHEDULE_ID As Integer)
            datas = (From p In db.DRUG_SCHEDULEs Where p.SCHEDULE_ID = SCHEDULE_ID And p.COME_STATUS_ID = 1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_SCHEDULE_DATE(ByVal SCHEDULE_DATE As Date)
            datas = (From p In db.DRUG_SCHEDULEs Where p.SCHEDULE_DATE = SCHEDULE_DATE Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_SCHEDULE_ID_AND_BOOKING_IDENTIFICATION_CARD_NO(ByVal SCHEDULE_ID As Integer, ByVal BOOKING_IDENTIFICATION_CARD_NO As String)
            datas = (From p In db.DRUG_SCHEDULEs Where p.SCHEDULE_ID = SCHEDULE_ID And p.BOOKING_IDENTIFICATION_CARD_NO = BOOKING_IDENTIFICATION_CARD_NO Select p)
            For Each Me.fields In datas
            Next
        End Sub


        Public Sub GetDataby_PRODUCT_ID_and_Order_By_SCHEDULE_DATE(ByVal PRODUCT_ID As String)
            datas = (From p In db.DRUG_SCHEDULEs Where p.PRODUCT_ID = PRODUCT_ID Select p Take 1 Order By p.SCHEDULE_DATE Descending)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_SCHEDULE_ID_and_Order_By_SCHEDULE_DATE(ByVal SCHEDULE_ID As Integer)
            datas = (From p In db.DRUG_SCHEDULEs Where p.SCHEDULE_ID = SCHEDULE_ID Select p Take 1 Order By p.SCHEDULE_DATE Descending)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Order_By_SCHEDULE_DATE_TEST()
            datas = (From p In db.DRUG_SCHEDULEs Select p Take 1 Order By p.SCHEDULE_DATE Descending)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_MAS_WORK_GROUP
        Inherits MAINCONTEXT
        Public fields As New MAS_WORK_GROUPV2

        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_WORK_GROUPV2s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.MAS_WORK_GROUPV2s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_WORK_GROUPV2s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_DEPARTMENT_TYPE_ID(ByVal DEPARTMENT_TYPE_ID As String)
            datas = (From p In db.MAS_WORK_GROUPV2s Where p.DEPARTMENT_TYPE_ID = DEPARTMENT_TYPE_ID Select p Order By p.SEQ)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_DEPARTMENT_TYPE_ID_and_WORK_GROUP_ID(ByVal DEPARTMENT_TYPE_ID As String, ByVal WORK_GROUP_ID As String)
            datas = (From p In db.MAS_WORK_GROUPV2s Where p.DEPARTMENT_TYPE_ID = DEPARTMENT_TYPE_ID And p.WORK_GROUP_ID = WORK_GROUP_ID Select p Order By p.SEQ)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class CLS_DETAIL_BOOKING_DRUG
        Inherits MAINCONTEXT
        Public fields As New DETAIL_BOOKING_DRUG

        Public Sub insert()
            db.DETAIL_BOOKING_DRUGs.InsertOnSubmit(fields)
            db.SubmitChanges()

        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DETAIL_BOOKING_DRUGs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.DETAIL_BOOKING_DRUGs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_DETAIL_BOOKING_DRUG_ID(ByVal DETAIL_BOOKING_DRUG_ID As Integer)
            datas = (From p In db.DETAIL_BOOKING_DRUGs Where p.DETAIL_BOOKING_DRUG_ID = DETAIL_BOOKING_DRUG_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_SCHEDULE_ID(ByVal SCHEDULE_ID As Integer)
            datas = (From p In db.DETAIL_BOOKING_DRUGs Where p.SCHEDULE_ID = SCHEDULE_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_PRODUCT_ID_IDA(ByVal PRODUCT_ID_IDA As Integer)
            datas = (From p In db.DETAIL_BOOKING_DRUGs Where p.PRODUCT_ID = PRODUCT_ID_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_PRODUCT_ID_IDA_and_order_by_DETAIL_BOOKING_DRUG_ID(ByVal PRODUCT_ID_IDA As Integer)
            datas = (From p In db.DETAIL_BOOKING_DRUGs Where p.PRODUCT_ID_IDA = PRODUCT_ID_IDA Select p Take 1 Order By p.DETAIL_BOOKING_DRUG_ID Descending)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_DETAIL_by_WAITING_LIST_ID(ByVal WAITING_LIST_ID As Integer)
            datas = (From p In db.DETAIL_BOOKING_DRUGs Where p.WAITING_LIST_ID = WAITING_LIST_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_PROCESS
        Inherits MAINCONTEXT
        Public fields As New MAS_PROCESSV2

        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_PROCESSV2s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.MAS_PROCESSV2s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_PROCESSV2s Where p.IDA = IDA And p.ACTIVE = "1" Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_PROCESS_ID(ByVal PROCESS_ID As String)
            datas = (From p In db.MAS_PROCESSV2s Where p.PROCESS_ID = PROCESS_ID And p.ACTIVE = "1" Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_PROCESS_ID_and_SYSTEM_ID(ByVal PROCESS_ID As String, ByVal SYSTEM_ID As String)
            datas = (From p In db.MAS_PROCESSV2s Where p.PROCESS_ID = PROCESS_ID And p.SYSTEM_ID = SYSTEM_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_SYSTEM_ID(ByVal SYSTEM_ID As String)
            datas = (From p In db.MAS_PROCESSV2s Where p.SYSTEM_ID = SYSTEM_ID And p.ACTIVE = "1" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_PROCESS_NAME(ByVal PROCESS_NAME As String)
            datas = (From p In db.MAS_PROCESSV2s Where p.PROCESS_NAME = PROCESS_NAME And p.ACTIVE = "1" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_SYSTEM_ID_and_WORK_GROUP_ID(ByVal SYSTEM_ID As String, ByVal WORK_GROUP_ID As String)
            datas = (From p In db.MAS_PROCESSV2s Where p.SYSTEM_ID = SYSTEM_ID And p.WORK_GROUP_ID = WORK_GROUP_ID And p.ACTIVE = "1" Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_TEMPLATE_PROCESS
        Inherits MAINCONTEXT
        Public fields As New MAS_TEMPLATE_PROCESSV2

        Public Sub GetDataby_TEMPLAETE(ByVal P_ID As String, ByVal lcntype As Integer, ByVal STATUS As Integer, ByVal GROUPS As Integer, ByVal PREVIEW As Integer)
            datas = (From p In db.MAS_TEMPLATE_PROCESSV2s Where p.PROCESS_ID = P_ID And p.LCNTYPECD = lcntype And p.STATUS_ID = STATUS _
             And p.GROUPS = GROUPS And p.PREVIEW = PREVIEW Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TEMPLAETE_PREVIEW(ByVal P_ID As Integer, ByVal lcntype As Integer, ByVal GROUPS As Integer, ByVal PREVIEW As Integer)
            datas = (From p In db.MAS_TEMPLATE_PROCESSV2s Where p.PROCESS_ID = P_ID And p.LCNTYPECD = lcntype _
             And p.GROUPS = GROUPS And p.PREVIEW = PREVIEW Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_CENTER_SCHEDULE
        Inherits MAINCONTEXT
        Public fields As New CENTER_SCHEDULE

        Public Sub insert()
            db.CENTER_SCHEDULEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CENTER_SCHEDULEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.CENTER_SCHEDULEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_SCHEDULE_ID(ByVal SCHEDULE_ID As Integer)
            datas = (From p In db.CENTER_SCHEDULEs Where p.SCHEDULE_ID = SCHEDULE_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub



        Public Sub GetDataby_SCHEDULE_ID_AND_COME_TRUE(ByVal SCHEDULE_ID As Integer)
            datas = (From p In db.CENTER_SCHEDULEs Where p.SCHEDULE_ID = SCHEDULE_ID And p.COME_STATUS_ID = 1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_SCHEDULE_DATE(ByVal SCHEDULE_DATE As Date)
            datas = (From p In db.CENTER_SCHEDULEs Where p.SCHEDULE_DATE = SCHEDULE_DATE Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_SCHEDULE_ID_AND_BOOKING_IDENTIFICATION_CARD_NO(ByVal SCHEDULE_ID As Integer, ByVal BOOKING_IDENTIFICATION_CARD_NO As String)
            datas = (From p In db.CENTER_SCHEDULEs Where p.SCHEDULE_ID = SCHEDULE_ID And p.BOOKING_IDENTIFICATION_CARD_NO = BOOKING_IDENTIFICATION_CARD_NO Select p)
            For Each Me.fields In datas
            Next
        End Sub


        Public Sub GetDataby_PRODUCT_ID_and_Order_By_SCHEDULE_DATE(ByVal PRODUCT_ID As String)
            datas = (From p In db.CENTER_SCHEDULEs Where p.PRODUCT_ID = PRODUCT_ID Select p Take 1 Order By p.SCHEDULE_DATE Descending)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_SCHEDULE_ID_and_Order_By_SCHEDULE_DATE(ByVal SCHEDULE_ID As Integer)
            datas = (From p In db.CENTER_SCHEDULEs Where p.SCHEDULE_ID = SCHEDULE_ID Select p Take 1 Order By p.SCHEDULE_DATE Descending)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
End Namespace