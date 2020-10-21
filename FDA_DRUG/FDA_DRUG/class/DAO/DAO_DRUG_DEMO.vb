
Namespace DAO_DRUG_DEMO


    Public MustInherit Class MAINCONTEXTD        'ประกาศเพื่อใช้เป็น Class แม่
        Public db As New LINQ_DRUG_DEMODataContext   'ประกาศเพื่อใช้เป็น Class LINQ DataTable
        Public datas                            'ประกาศเ

    End Class

    Public Class TB_XML_NAME_TEST
        Inherits MAINCONTEXTD                    'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_NAME_TEST            'ใส่ชื่อ Table   (dh15rqt)
        Public Sub GetDataby_TR_ID(ByVal TR_ID As String)

            datas = (From p In db.XML_NAME_TESTs Where p.TR_ID_DRRGT = TR_ID And p.STATUS_ID = 8 Select p) 'การ Where   table(dh15rqts)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.XML_NAME_TESTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_NAME_TESTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_NAME_TESTs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
End Namespace