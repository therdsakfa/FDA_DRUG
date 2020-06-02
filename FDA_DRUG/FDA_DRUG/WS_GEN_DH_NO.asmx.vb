Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_GEN_DH_NO
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Sub GEN_DH_NO(ByVal IDA As Integer)
        Dim steps As String = ""
        Try
            Dim dao2 As New DAO_DRUG.TB_DH15_DETAIL_CASCHEMICAL
            dao2.GetDataby_FK_IDA(IDA)
            Dim chem_dgt As String = ""
            Try
                chem_dgt = dao2.fields.phm15dgt
            Catch ex As Exception

            End Try
            Dim dao As New DAO_DRUG.ClsDBdh15rqt
            dao.GetDataby_IDA(IDA)
            Dim _ProcessID As Integer = 0
            Dim stat As Integer = 0
            Try
                stat = dao.fields.STATUS_ID
            Catch ex As Exception

            End Try
            If stat <> 8 Then
                If Len(Trim(chem_dgt)) = 0 Then

                    Try
                        Dim dao_tr As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
                        dao_tr.GetDataby_IDA(dao.fields.TR_ID)
                        _ProcessID = dao_tr.fields.PROCESS_ID
                    Catch ex As Exception

                    End Try
                    'For Each dao2.fields In dao2.datas
                    Dim dao_cas As New DAO_DRUG.TB_MAS_CHEMICAL
                    dao_cas.GetDataby_IDA(Trim(dao2.fields.CAS_ID))
                    Dim bao As New BAO.GenNumber 'test
                    Dim run_number As String = ""
                    run_number = bao.GEN_DH15TDGT_NO(con_year(Date.Now.Year), dao_cas.fields.aori, _ProcessID, IDA, dao2.fields.IDA, dao.fields.QUOTA_TYPE)
                    Dim dao3 As New DAO_DRUG.TB_DH15_DETAIL_CASCHEMICAL
                    dao3.GetDataby_IDA(dao2.fields.IDA)
                    dao3.fields.phm15dgt = run_number
                    dao3.update()

                    'Dim ws_update As New WS_DRUG.WS_DRUG
                    'ws_update.DRUG_INSERT_DR15(dao2.fields.FK_IDA)


                    ' Next
                    dao.fields.STATUS_ID = 8
                    dao.update()
                    Try
                        Dim ws_update As New WS_DRUG.WS_DRUG
                        ws_update.DRUG_INSERT_DR15(IDA, "1710500118665")
                    Catch ex As Exception

                    End Try

                End If
            End If
        Catch ex As Exception
            Dim dao As New DAO_DRUG.TB_LOG_DH_ERROR
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.EX_MESSAGE = ex.Message
            dao.fields.FK_IDA = IDA
            dao.insert()
        End Try

    End Sub
    <WebMethod()> _
    Public Sub UPDATE_DALCN(ByVal IDA As Integer, ByVal process As String, ByVal ref01 As String, ByVal ref02 As String)

        Dim dao_fees As New DAO_FEE.TB_fee
        dao_fees.GetDataby_ref1_ref2(ref01, ref02)
        Dim dao_dets As New DAO_FEE.TB_feedtl
        dao_dets.Getdata_by_fee_id(dao_fees.fields.IDA)
        If process = "1007411" Or process = "1007412" Or process = "1007442" Or process = "1007443" Or process = "1007491" Or process = "1007492" Or process = "1007493" _
                             Or process = "1007494" Or process = "1007471" Or process = "1007451" Or process = "1007495" Or process = "1007461" Or process = "1007481" Or process = "102730" Or process = "102780" _
                              Or process = "102720" Or process = "102721" Or process = "102722" Or process = "102723" Or process = "102725" Or process = "102726" Or process = "102727" _
                            Or process = "102729" Or process = "102728" Or process = "1007413" Or process = "1007414" Or process = "1007421" Or process = "1007431" Or process = "1007441" Then
            Try

                For Each dao_dets.fields In dao_dets.datas
                    Dim dao_lcn_extend As New DAO_DRUG.TB_LCN_EXTEND_LITE
                    dao_lcn_extend.GetDataby_IDA(dao_dets.fields.fk_id)
                    Dim stat_lcn As Integer = 0
                    Try
                        stat_lcn = dao_lcn_extend.fields.STATUS_ID
                    Catch ex As Exception

                    End Try
                    If stat_lcn <> 8 Then
                        If dao_fees.fields.acc_type = "1" Then
                            If stat_lcn = "1" Then
                                dao_lcn_extend.fields.STATUS_ID = 2
                                dao_lcn_extend.update()
                            ElseIf stat_lcn = "3" Then
                                dao_lcn_extend.fields.STATUS_ID = 4
                                dao_lcn_extend.update()
                            End If
                        ElseIf dao_fees.fields.acc_type = "2" Then
                            If stat_lcn = "1" Then
                                dao_lcn_extend.fields.STATUS_ID = 3
                                dao_lcn_extend.update()
                            ElseIf stat_lcn = "2" Then
                                dao_lcn_extend.fields.STATUS_ID = 4
                                dao_lcn_extend.update()
                            End If
                        End If
                    End If

                Next

            Catch ex As Exception

            End Try
        ElseIf process = "950001" Or process = "950003" Or process = "950004" Or process = "950005" Or process = "950002" Or process = "950006" Or process = "950007" _
                                   Or process = "950008" Or process = "950009" Or process = "950010" Then

            For Each dao_dets.fields In dao_dets.datas
                Dim bao_cer As New BAO_FDA_CFS_CENTER.FDA_CFS_CENTER
                bao_cer.SP_SET_UPDATE_PAYMENT_CER_DRUG(dao_dets.fields.fk_id)
            Next
        ElseIf process = "1400001" Then

            If dao_dets.fields.fk_refstatus = 2 Then
                For Each dao_dets.fields In dao_dets.datas
                    Dim dao_rq As New DAO_DRUG.ClsDBdrrqt
                    dao_rq.GetDataby_IDA(dao_dets.fields.fk_id)
                    dao_rq.fields.STATUS_ID = 3
                    dao_rq.update()
                Next

            End If
        ElseIf process = "555555" Then
            Dim iii As Integer = 0
            For Each dao_dets.fields In dao_dets.datas
                iii += 1
                Dim dao_sp As New DAO_SP_PAYMENT.TB_SYSTEMS_PAYMENT_DETAIL
                dao_sp.GetDataby_IDA(dao_dets.fields.fk_id)
                With dao_sp.fields
                    .STATUS_ID = 8
                    .FINANCE_DATE = Date.Now
                    .FINANCE_STATUS = 1
                End With
                dao_sp.update()
                Dim dao_log As New DAO_SPECIAL_PAYMENT.TB_SPD_LOG
                With dao_log.fields
                    .CREATE_DATE = Date.Now
                    .FK_IDA = dao_dets.fields.fk_id
                    .process = dao_dets.fields.process_id
                    .type = 1
                End With
                dao_log.insert()
            Next
        ElseIf process = "101" Or process = "102" Or process = "103" Or process = "104" Or process = "105" Or process = "106" Or process = "107" Or
        process = "108" Or process = "109" Or process = "110" Or process = "111" Or process = "112" Or process = "113" Or process = "114" Or process = "115" Or
        process = "116" Or process = "117" Or process = "118" Or process = "119" Then
            dao_dets.Getdata_by_fee_id(dao_fees.fields.IDA)
            For Each dao_dets.fields In dao_dets.datas
                Dim bao As New BAO.ClsDBSqlcommand
                Try
                    bao.SP_FEE_UPDATE_STATUS_PAY_COMPLETE(dao_dets.fields.fk_id, dao_fees.fields.dvcd, dao_dets.fields.process_id)
                Catch ex As Exception

                End Try
            Next
        End If
    End Sub
End Class