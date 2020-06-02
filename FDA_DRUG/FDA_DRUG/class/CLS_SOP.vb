Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization

Public Class CLS_SOP
    Public Sub BLOCK_SOP(ByVal CTZNO As String, ByVal PROCESS_ID As String, ByVal SOP_STATUS As String, ByVal SOP_REMARK As String, ByVal TR_ID As String, ByVal B64 As String)
        Dim ws_b As New WS_BLOCKCHAIN.WS_BLOCKCHAIN
        Dim ws_f As New WS_BLOCKCHAIN.XML_BLOCK
        Dim ws_r As New WS_BLOCKCHAIN.XML_RETURN
        ws_f.IDENTIFY = CTZNO
        ws_f.PROCESS_ID = PROCESS_ID
        ws_f.SEND_TIME = Date.Now
        ws_f.SOP_STATUS = SOP_STATUS
        ws_f.SOP_REMARK = SOP_REMARK
        ws_f.SYSTEM_ID = "DRUG"
        ws_f.TR_ID = TR_ID
        ws_f.XML_DATA = B64
        ws_r = ws_b.WS_BLOCK_CHAIN_V3(ws_f)

    End Sub

    Public Sub BLOCK_STAFF(ByVal CTZNO As String, ByVal STAFF_TYPE As String, ByVal PROCESS_ID As String, ByVal PVCODE As String, ByVal STATUS_ID As String, ByVal STATUS_NAME As String,
                            ByVal STATUS_NEXT As String, ByVal STATUS_NAME_NEXT As String, ByVal STATUS_DES As String, ByVal PERSON_TYPE_NEXT As String, ByVal TR_ID As String, Optional SOP_STATUS As String = "")
        Dim SOP_BLOCK As New SOP_STAFF
        With SOP_BLOCK.STAFF_WORK
            .STAFF_CTZNO = CTZNO
            .STAFF_DATE = Date.Now
            .STAFF_TYPE = STAFF_TYPE
        End With
        With SOP_BLOCK.SOP_CURRENT
            .SOP_PERSON_TYPE = STAFF_TYPE
            .SOP_PROCESS_ID = PROCESS_ID
            .SOP_PVNCD = PVCODE
            .SOP_STATUS = STATUS_ID
            .SOP_STATUS_DES = STATUS_NAME
            .SOP_STATUS_NAME = STATUS_NAME
            .SOP_SYSTEM_ID = "DRUG"
        End With
        With SOP_BLOCK.SOP_NEXT
            .SOP_STATUS_NEXT = STATUS_NEXT
            .SOP_STATUS_NAME_NEXT = STATUS_NAME_NEXT
            .SOP_STATUS_DES = STATUS_DES
            .SOP_PERSON_TYPE = PERSON_TYPE_NEXT
            .SOP_PROCESS_ID = PROCESS_ID
            .SOP_PVNCD = PVCODE
            .SOP_SYSTEM_ID = "DRUG"
        End With
        'เมื่อใส่ค่าเสร็จให้ทำการนำ SOP_STAFF แปลงเป็น B64 แล้วทำการส่งเข้า Block
        BLOCK_SOP(CTZNO, PROCESS_ID, "1", SOP_STATUS, TR_ID, CLASS_TO_BASE64(SOP_BLOCK))
    End Sub

    Function CLASS_TO_BASE64(ByVal sv_r As Object) As String
        Dim x2 As New XmlSerializer(sv_r.GetType())
        Dim settings As New XmlWriterSettings()
        settings.Encoding = Encoding.UTF8
        settings.Indent = True
        Dim mem2 As New MemoryStream()
        Using writer As XmlWriter = XmlWriter.Create(mem2, settings)
            x2.Serialize(writer, sv_r)
            writer.Flush()
            writer.Close()
        End Using
        Dim B64 As String = ""
        B64 = Convert.ToBase64String(mem2.GetBuffer())
        Return B64
    End Function
End Class
