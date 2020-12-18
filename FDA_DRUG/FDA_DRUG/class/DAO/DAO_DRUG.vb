
Namespace DAO_DRUG


    Public MustInherit Class MAINCONTEXT        'ประกาศเพื่อใช้เป็น Class แม่
        Public db As New Linq_DRUGDataContext   'ประกาศเพื่อใช้เป็น Class LINQ DataTable


        Public datas                            'ประกาศเ

    End Class
    '
    Public Class ClsDBdrdrgtype
        Inherits MAINCONTEXT                    'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New drdrgtype            'ใส่ชื่อ Table   (dh15rqt)
        Public Sub GetDataby_drgtpcd(ByVal drgtpcd As String)

            datas = (From p In db.drdrgtypes Where p.drgtpcd = drgtpcd Select p) 'การ Where   table(dh15rqts)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.drdrgtypes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drdrgtypes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drdrgtypes Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class ClsDBdh15rqt
        Inherits MAINCONTEXT                    'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New dh15rqt            'ใส่ชื่อ Table   (dh15rqt)
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.dh15rqts Where p.IDA = IDA Select p) 'การ Where   table(dh15rqts)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.dh15rqts.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dh15rqts.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dh15rqts Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdh15rqtdt
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New dh15rqtdt

        Public Sub insert()
            db.dh15rqtdts.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dh15rqtdts.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dh15rqtdts Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBdh15tpdcfrgn
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New dh15tpdcfrgn

        Public Sub insert()
            db.dh15tpdcfrgns.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dh15tpdcfrgns.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dh15tpdcfrgns Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdrfrgn
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New drfrgn

        Public Sub insert()
            db.drfrgns.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drfrgns.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drfrgns Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdramldrg
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New dramldrg

        Public Sub insert()
            db.dramldrgs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dramldrgs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dramldrgs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_IDA(ByVal IDA As Integer)

            datas = (From p In db.dramldrgs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.dramldrgs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function CountData_by_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.dramldrgs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class ClsDBdrramldrg
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New drramldrg

        Public Sub insert()
            db.drramldrgs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drramldrgs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drramldrgs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_IDA(ByVal IDA As Integer)

            datas = (From p In db.drramldrgs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.drramldrgs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        
    End Class
    Public Class ClsDBdramluse
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New dramluse

        Public Sub insert()
            db.dramluses.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dramluses.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dramluses Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDatabyIDA(ByVal IDA As Integer)

            datas = (From p In db.dramluses Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.dramluses Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDatabyFK_IDA_amltpcd_amlsubcd_usetpcd(ByVal FK_IDA As Integer, ByVal amltpcd As Integer, ByVal amlsubcd As Integer, ByVal usetpcd As Integer)
            datas = (From p In db.dramluses Where p.FK_IDA = FK_IDA And p.amltpcd And p.amlsubcd = amlsubcd And p.usetpcd = usetpcd Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.dramluses Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class ClsDBdrramluse
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New drramluse

        Public Sub insert()
            db.drramluses.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drramluses.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drramluses Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDatabyIDA(ByVal IDA As Integer)

            datas = (From p In db.drramluses Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDatabyFKIDA(ByVal FK_IDA As Integer)

            datas = (From p In db.drramluses Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDatabyFK_IDA_amltpcd_amlsubcd_usetpcd(ByVal FK_IDA As Integer, ByVal amltpcd As Integer, ByVal amlsubcd As Integer, ByVal usetpcd As Integer)
            datas = (From p In db.drramluses Where p.FK_IDA = FK_IDA And p.amltpcd And p.amlsubcd = amlsubcd And p.usetpcd = usetpcd Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class ClsDBdrdrgchr
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New drdrgchr

        Public Sub insert()
            db.drdrgchrs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drdrgchrs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drdrgchrs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Friend Sub GetData_Byid(lct_ida As Integer)
            Throw New NotImplementedException()
        End Sub
        Public Sub GetDataby_ida(ByVal ida As String) '

            datas = (From p In db.drdrgchrs Where p.IDA = ida Select p)
            For Each Me.fields In datas

            Next

        End Sub
    End Class

    Public Class ClsDBdrrgtnewdg
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New drrgtnewdg

        Public Sub insert()
            db.drrgtnewdgs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drrgtnewdgs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drrgtnewdgs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdrspec
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New drspec

        Public Sub insert()
            db.drspecs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drspecs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drspecs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdreqto
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New dreqto

        Public Sub insert()
            db.dreqtos.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dreqtos.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dreqtos Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdrfmlno
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New drfmlno

        Public Sub insert()
            db.drfmlnos.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drfmlnos.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drfmlnos Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdrfml
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New drfml

        Public Sub insert()
            db.drfmls.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drfmls.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drfmls Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdrfrgnaddr
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New drfrgnaddr

        Public Sub insert()
            db.drfrgnaddrs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drfrgnaddrs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drfrgnaddrs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll_v2(ByVal addr As String, ByVal cntcd As String, ByVal district As String, ByVal fax As String, ByVal mu As String, ByVal province As String, _
                                 ByVal road As String, ByVal soi As String, ByVal subdiv As String, ByVal tel As String, ByVal zipcode As String, ByVal frgncd As String)
            datas = (From p In db.drfrgnaddrs Where p.addr = addr And p.cntcd = cntcd And p.district = district And p.fax = fax And p.mu = mu And p.province = province And p.road = road And _
                p.soi = soi And p.subdiv = subdiv And p.tel = tel And p.zipcode = zipcode And p.frgncd = frgncd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll_v3(ByVal addr As String, ByVal cntcd As String, ByVal district As String, ByVal province As String, _
                                  ByVal subdiv As String, ByVal frgncd As String)
            datas = (From p In db.drfrgnaddrs Where p.addr = addr And p.cntcd = cntcd And p.district = district And p.province = province And _
                 p.frgncd = frgncd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataByIDA(ByVal IDA As Integer)

            datas = (From p In db.drfrgnaddrs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_frgnlctcd(ByVal frgncd As Integer)
            datas = (From p In db.drfrgnaddrs Where p.frgncd = frgncd Order By CInt(p.frgnlctcd) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBdrimpdrg
        Inherits MAINCONTEXT

        Public fields As New drimpdrg

        Public Sub insert()
            db.drimpdrgs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drimpdrgs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drimpdrgs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBdrimpfor
        Inherits MAINCONTEXT

        Public fields As New drimpfor
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.drimpfors Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.drimpfors.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drimpfors.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drimpfors Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBdrimpfrgn
        Inherits MAINCONTEXT

        Public fields As New drimpfrgn

        Public Sub insert()
            db.drimpfrgns.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drimpfrgns.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drimpfrgns Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.drimpfrgns Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBdrpcb
        Inherits MAINCONTEXT

        Public fields As New drpcb
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.drpcbs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.drpcbs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drpcbs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drpcbs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdrpcbdrg
        Inherits MAINCONTEXT

        Public fields As New drpcbdrg

        Public Sub insert()
            db.drpcbdrgs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drpcbdrgs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drpcbdrgs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBdrrgt
        Inherits MAINCONTEXT

        Public fields As New drrgt
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.drrgts Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.drrgts Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_DRRQT(ByVal IDA As Integer)

            datas = (From p In db.drrgts Where p.FK_DRRQT = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.drrgts.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drrgts.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drrgts)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_TRANSECTION_ID_UPLOAD(ByVal TRANSECTION_ID_UPLOAD As Integer)

            datas = (From p In db.drrgts Where p.TR_ID = TRANSECTION_ID_UPLOAD Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_RGTNO(ByVal years As Integer, ByVal rgttpcd As String, ByVal drgtpcd As String)
            datas = (From p In db.drrqts Where Left(p.rgtno, 2) = years And p.rgttpcd = rgttpcd And p.drgtpcd = drgtpcd Order By CInt(p.rgtno) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Function CountDataby_FK_DRRQT(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.drrgts Where p.FK_DRRQT = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next

            Return i
        End Function
        Public Sub GetDataby_4key(ByVal rgtno As String, ByVal rgttpcd As String, ByVal drgtpcd As String, ByVal pvncd As Integer)

            datas = (From p In db.drrgts Where p.rgtno = rgtno And p.rgttpcd = rgttpcd And p.drgtpcd = drgtpcd And p.pvncd = pvncd)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function COUNT_REPEAT_RGTNO_PVNCD(ByVal rgtno As String, ByVal rgttpcd As String, ByVal drgtpcd As String, ByVal pvncd As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.drrgts Where p.rgtno = rgtno And p.rgttpcd = rgttpcd And p.drgtpcd = drgtpcd And p.pvncd = pvncd)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class ClsDBdrrqt
        Inherits MAINCONTEXT

        Public fields As New drrqt
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.drrqts Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.drrqts Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)

            datas = (From p In db.drrqts Where p.TR_ID = TR_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID_PROCESS_ID(ByVal TR_ID As String, ByVal process_id As String)

            datas = (From p In db.drrqts Where p.TR_ID = TR_ID And p.PROCESS_ID = process_id Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.drrqts.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drrqts.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drrqts Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_pvncd_rgtno_drgtpcd_rgttpcd(ByVal pvncd As String, ByVal rgtno As String, ByVal drgtpcd As String, ByVal rgttpcd As String)

            datas = (From p In db.drrqts Where p.pvncd = pvncd And p.rgtno = rgtno And p.drgtpcd = drgtpcd And p.rgttpcd = rgttpcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TRANSECTION_ID_UPLOAD(ByVal TRANSECTION_ID_UPLOAD As Integer)

            datas = (From p In db.drrqts Where p.TR_ID = TRANSECTION_ID_UPLOAD Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_RCVNO(ByVal years As Integer, ByVal rgttpcd As String, ByVal drgtpcd As String)
            datas = (From p In db.drrqts Where Left(p.rcvno, 2) = years And p.rgttpcd = rgttpcd And p.drgtpcd = drgtpcd Order By CInt(p.rcvno) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_RGTNO(ByVal rgtno As String, ByVal rgttpcd As String, ByVal drgtpcd As String)
            datas = (From p In db.drrqts Where p.rgtno = rgtno And p.rgttpcd = rgttpcd And p.drgtpcd = drgtpcd Order By CInt(p.rgtno) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Function COUNT_REPEAT_RGTNO(ByVal rgtno As String, ByVal rgttpcd As String, ByVal drgtpcd As String) As Integer
            Dim i As Integer = 0
            datas = (From p In db.drrqts Where p.rgtno = rgtno And p.rgttpcd = rgttpcd And p.drgtpcd = drgtpcd)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Function COUNT_REPEAT_RGTNO_PVNCD(ByVal rgtno As String, ByVal rgttpcd As String, ByVal drgtpcd As String, ByVal pvncd As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.drrqts Where p.rgtno = rgtno And p.rgttpcd = rgttpcd And p.drgtpcd = drgtpcd And p.pvncd = pvncd)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class ClsDBdrpcksize
        Inherits MAINCONTEXT

        Public fields As New drpcksize

        Public Sub insert()
            db.drpcksizes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drpcksizes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drpcksizes Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdrusedrg
        Inherits MAINCONTEXT

        Public fields As New drusedrg

        Public Sub insert()
            db.drusedrgs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drusedrgs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drusedrgs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdrsamp
        Inherits MAINCONTEXT

        Public fields As New drsamp
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.drsamps Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)

            datas = (From p In db.drsamps Where p.TR_ID = TR_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.drsamps Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_PRODUCT_ID_IDA(ByVal PRODUCT_ID_IDA As Integer)

            datas = (From p In db.drsamps Where p.PRODUCT_ID_IDA = PRODUCT_ID_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub by_lcntpcd_and_regis_status8(ByVal lcntpcd As String, ByVal regis As Integer)

            datas = (From p In db.drsamps Where p.lcntpcd = lcntpcd And p.STATUS_ID = 8 And p.PRODUCT_ID_IDA = regis Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.drsamps.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drsamps.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drsamps Select p)
            For Each Me.fields In datas
            Next
        End Sub

        'Friend Sub GetDataby_IDA()
        '    Throw New NotImplementedException()
        'End Sub
    End Class

    Public Class ClsDB_nym_proof
        Inherits MAINCONTEXT

        Public fields As New DRUG_NORYORMOR_PROOF
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_NORYORMOR_PROOFs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK(ByVal FK_DRSAMP As Integer)

            datas = (From p In db.DRUG_NORYORMOR_PROOFs Where p.FK_DRSAMP = FK_DRSAMP Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Process(ByVal PROCESS_ID As Integer)

            datas = (From p In db.DRUG_NORYORMOR_PROOFs Where p.PROCESS_ID = PROCESS_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.DRUG_NORYORMOR_PROOFs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_NORYORMOR_PROOFs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_NORYORMOR_PROOFs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataAll2()

            datas = (From p In db.DRUG_NORYORMOR_PROOFs Select p)

        End Sub

    End Class

    Public Class ClsDB_nym4_donate_detail
        Inherits MAINCONTEXT

        Public fields As New DRUG_NORYORMOR4_DONATE_DETAIL
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_NORYORMOR4_DONATE_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_drsamp_FK(ByVal FK_DRSAMP As Integer)

            datas = (From p In db.DRUG_NORYORMOR4_DONATE_DETAILs Where p.DRSAMP_FK_IDA = FK_DRSAMP Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_loaddr_fk(ByVal loaddr_fk As Integer)

            datas = (From p In db.DRUG_NORYORMOR4_DONATE_DETAILs Where p.LOCATION_ADDRESS_FK_IDA = loaddr_fk Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.DRUG_NORYORMOR4_DONATE_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_NORYORMOR4_DONATE_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_NORYORMOR4_DONATE_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class ClsDBdrsampfmlno
        Inherits MAINCONTEXT

        Public fields As New drsampfmlno

        Public Sub insert()
            db.drsampfmlnos.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drsampfmlnos.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drsampfmlnos Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBGEN_RCVNO
        Inherits MAINCONTEXT

        Public fields As New GEN_RCVNO
        Public Sub GetDataby_Year_PVNCD_PROCESS_ID_MAX(ByVal PVNCD As String, ByVal YEARS As Integer, ByVal PROCESS_ID As Integer)
            datas = (From p In db.GEN_RCVNOs Where p.PVNCD = PVNCD And p.YEARS = YEARS And p.PROCESS_ID = PROCESS_ID Order By CInt(p.GEN_RCV) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.GEN_RCVNOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.GEN_RCVNOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.GEN_RCVNOs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX_N_NC(ByVal YEAR As String, ByVal PVNCD As String, ByVal IDA As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_RCVNOs Where p.PVNCD = PVNCD And p.YEARS = YEAR And (p.GEN_TYPE = "1" Or p.GEN_TYPE = "6") Order By CInt(p.GEN_RCV) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX_NB_NBC(ByVal YEAR As String, ByVal PVNCD As String, ByVal IDA As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_RCVNOs Where p.PVNCD = PVNCD And p.YEARS = YEAR And (p.GEN_TYPE = "7" Or p.GEN_TYPE = "B") Order By CInt(p.GEN_RCV) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal IDA As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_RCVNOs Where p.PVNCD = PVNCD And p.YEARS = YEAR And p.GEN_TYPE = RGTTPCD Order By CInt(p.GEN_RCV) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBRECIVE
        Inherits MAINCONTEXT

        Public fields As New RECIVE

        Public Sub insert()
            db.RECIVEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.RECIVEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.RECIVEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBsyspdcfrgn
        Inherits MAINCONTEXT

        Public fields As New syspdcfrgn

        Public Sub insert()
            db.syspdcfrgns.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.syspdcfrgns.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.syspdcfrgns Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_IDA(ByVal IDA As Integer)

            datas = (From p In db.syspdcfrgns Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_frgncd(ByVal frgncd As Integer)

            datas = (From p In db.syspdcfrgns Where p.frgncd = frgncd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_engfrgnnm(ByVal engfrgnnm As String)
            datas = (From p In db.syspdcfrgns Where p.engfrgnnm = engfrgnnm Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetMAX()
            datas = (From p In db.syspdcfrgns Order By CInt(p.frgncd) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBTEMPLATE
        Inherits MAINCONTEXT

        Public fields As New TEMPLATE

        Public Sub insert()
            db.TEMPLATEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TEMPLATEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TEMPLATEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBTRANSACTION_DOWNLOAD
        Inherits MAINCONTEXT

        Public fields As New TRANSACTION_DOWNLOAD

        Public Sub insert()
            db.TRANSACTION_DOWNLOADs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TRANSACTION_DOWNLOADs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TRANSACTION_DOWNLOADs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdh15frgn
        Inherits MAINCONTEXT

        Public fields As New dh15frgn

        Public Sub insert()
            db.dh15frgns.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dh15frgns.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dh15frgns Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdh15tdgt
        Inherits MAINCONTEXT

        Public fields As New dh15tdgt

        Public Sub insert()
            db.dh15tdgts.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dh15tdgts.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dh15tdgts Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBFILE_ATTACH
        Inherits MAINCONTEXT

        Public fields As New FILE_ATTACH

        Private _Details As New List(Of FILE_ATTACH)
        Public Property Details() As List(Of FILE_ATTACH)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of FILE_ATTACH))
                _Details = value
            End Set
        End Property
        Public Sub insert()
            db.FILE_ATTACHes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.FILE_ATTACHes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.FILE_ATTACHes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.FILE_ATTACHes Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As String)

            datas = (From p In db.FILE_ATTACHes Where p.TRANSACTION_ID = TR_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID_type(ByVal TR_ID As String, ByVal type As Integer)

            datas = (From p In db.FILE_ATTACHes Where p.TRANSACTION_ID = TR_ID And p.TYPE = type And p.NAME_REAL <> "" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataby_TR_ID_type2(ByVal TR_ID As String, ByVal type As Integer)

        '    datas = (From p In db.FILE_ATTACHes Where p.TRANSACTION_ID = TR_ID And p.TYPE = type And p.NAME_REAL <> "" Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_TR_ID_type_process(ByVal TR_ID As String, ByVal type As Integer, ByVal process_id As String)

            datas = (From p In db.FILE_ATTACHes Where p.TRANSACTION_ID = TR_ID And p.TYPE = type And p.PROCESS_ID = process_id And p.NAME_REAL <> "" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID_And_Process(ByVal TR_ID As String, ByVal process As String)

            datas = (From p In db.FILE_ATTACHes Where p.TRANSACTION_ID = TR_ID And p.PROCESS_ID = process And p.NAME_REAL <> "" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID_And_Process_And_Type(ByVal TR_ID As String, ByVal process As String, ByVal _type As String)

            datas = (From p In db.FILE_ATTACHes Where p.TRANSACTION_ID = TR_ID And p.PROCESS_ID = process And p.TYPE = _type Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetMAXby_TR_ID_And_Process(ByVal TR_ID As String, ByVal process As String)
            datas = (From p In db.FILE_ATTACHes Where p.TRANSACTION_ID = TR_ID And p.PROCESS_ID = process Order By CInt(p.TYPE) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBTRANSACTION_UPLOAD
        Inherits MAINCONTEXT

        Public fields As New TRANSACTION_UPLOAD

        Public Sub insert()
            db.TRANSACTION_UPLOADs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TRANSACTION_UPLOADs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TRANSACTION_UPLOADs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal Process_id As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.TRANSACTION_UPLOADs Where p.YEAR = YEAR And p.PROCESS_ID_STR = Process_id Order By CInt(p.GEN_NO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function Count_GEN_NO(ByVal _YEAR As String, ByVal Process_id As String, ByVal gen_no As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.TRANSACTION_UPLOADs Where p.YEAR = _YEAR And p.PROCESS_ID_STR = Process_id And p.GEN_NO = gen_no Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TRANSACTION_UPLOADs Where p.DESCRIPTION = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID_Process(ByVal tr_id As String, ByVal process_id As String)

            datas = (From p In db.TRANSACTION_UPLOADs Where p.DESCRIPTION = tr_id And p.PROCESS_ID_STR = process_id Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBTYPE
        Inherits MAINCONTEXT

        Public fields As New TYPE

        Public Sub insert()
            db.TYPEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TYPEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TYPEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBTYPE_TEMPLATE
        Inherits MAINCONTEXT

        Public fields As New TYPE_TEMPLATE

        Public Sub insert()
            db.TYPE_TEMPLATEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TYPE_TEMPLATEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TYPE_TEMPLATEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBCO_INFO
        Inherits MAINCONTEXT

        Public fields As New CO_INFO

        Public Sub insert()
            db.CO_INFOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CO_INFOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.CO_INFOs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Class Cls_dacnccs
        Inherits MAINCONTEXT

        Public fields As New dacncc

        Public Sub insert()
            db.dacnccs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dacnccs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_cd(ByVal cd As Integer)

            datas = (From p In db.dacnccs Where p.cnccscd = cd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll()

            datas = (From p In db.dacnccs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class ClsDBdacnc
        Inherits MAINCONTEXT

        Public fields As New dacnc

        Public Sub insert()
            db.dacncs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dacncs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dacncs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class



    Public Class ClsDBdacnsd
        Inherits MAINCONTEXT

        Public fields As New dacnsd

        Public Sub insert()
            db.dacnsds.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dacnsds.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dacnsds Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdacscd
        Inherits MAINCONTEXT

        Public fields As New dacscd

        Public Sub insert()
            db.dacscds.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dacscds.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dacscds Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_cd(ByVal cd As String)

            datas = (From p In db.dacscds Where p.cscd = cd Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdactg
        Inherits MAINCONTEXT

        Public fields As New dactg

        Public Sub insert()
            db.dactgs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dactgs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dactgs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_cd(ByVal cd As String)

            datas = (From p In db.dactgs Where p.ctgcd = cd Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_drkdofdrg
        Inherits MAINCONTEXT

        Public fields As New drkdofdrg

        Public Sub insert()
            db.drkdofdrgs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drkdofdrgs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drkdofdrgs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_kindcd(ByVal kindcd As String)

            datas = (From p In db.drkdofdrgs Where p.kindcd = kindcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_thakindnm(ByVal thakindnm As String)

            datas = (From p In db.drkdofdrgs Where p.thakindnm = thakindnm Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBdakeplctnm
        Inherits MAINCONTEXT

        Public fields As New dakeplctnm

        Public Sub insert()
            db.dakeplctnms.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dakeplctnms.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dakeplctnms Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBdalcn
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
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.dalcns Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA_STATUS(ByVal IDA As Integer)

            datas = (From p In db.dalcns Where p.IDA = IDA And p.cnccscd Is Nothing Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)

            datas = (From p In db.dalcns Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.dalcns Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_pvnabbr_lcnno(ByVal pvnabbr As String, ByVal lcnno As String)

            datas = (From p In db.dalcns Where p.pvnabbr = pvnabbr And p.lcnno = lcnno And p.lcntpcd = "ขย1" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA_and_PROCESS_ID(ByVal FK_IDA As Integer, ByVal PROCESS_ID As Integer)

            datas = (From p In db.dalcns Where p.FK_IDA = FK_IDA And p.PROCESS_ID = PROCESS_ID And p.STATUS_ID = 8 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA_and_PROCESS_ID_4(ByVal FK_IDA As Integer, ByVal PROCESS_ID_1 As Integer, ByVal PROCESS_ID_2 As Integer, ByVal PROCESS_ID_3 As Integer, ByVal PROCESS_ID_4 As Integer)
            datas = (From p In db.dalcns Where p.FK_IDA = FK_IDA And p.STATUS_ID = 8 And (p.PROCESS_ID = PROCESS_ID_1 Or p.PROCESS_ID = PROCESS_ID_2 Or p.PROCESS_ID = PROCESS_ID_3 Or p.PROCESS_ID = PROCESS_ID_4) Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataEditby_IDEN(ByVal iden As String)
            datas = (From p In db.dalcns Where p.CITIZEN_ID_AUTHORIZE = iden And p.STATUS_ID = 8 And (p.lcntpcd = "ขย1" Or p.lcntpcd = "ขย2" Or p.lcntpcd = "ขย3" Or p.lcntpcd = "ขย4" Or p.lcntpcd = "นย1" Or p.lcntpcd = "ผย1" Or p.lcntpcd = "ขยบ" Or p.lcntpcd = "นยบ" Or p.lcntpcd = "ผยบ") Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDEN(ByVal iden As String)
            datas = (From p In db.dalcns Where p.CITIZEN_ID_AUTHORIZE = iden And p.STATUS_ID = 8 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA_and_PROCESS_ID_AND_IDEN(ByVal IDEN As String)
            datas = (From p In db.dalcns Where p.CITIZEN_ID_AUTHORIZE = IDEN And p.STATUS_ID = 8 And
                (p.PROCESS_ID = 105 Or p.PROCESS_ID = 106 Or p.PROCESS_ID = 108 Or p.PROCESS_ID = 109) Select p Order By p.IDA Descending)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA_and_PROCESS_ID_AND_IDEN2(ByVal IDEN As String)
            datas = (From p In db.dalcns Where p.CITIZEN_ID_AUTHORIZE = IDEN And p.STATUS_ID = 8 And (p.lcntpcd = "นย1" Or p.lcntpcd = "ผย1" Or p.lcntpcd = "นยบ" Or p.lcntpcd = "ผยบ" Or p.lcntpcd = "นย8" Or p.lcntpcd = "ผย8" Or p.lcntpcd = "นยบ8" Or p.lcntpcd = "ผยบ8") Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA_and_PROCESS_ID_AND_IDEN3(ByVal IDEN As String)
            datas = (From p In db.dalcns Where p.CITIZEN_ID_AUTHORIZE = IDEN And p.STATUS_ID = 8 And (p.lcntpcd = "ขย1" Or p.lcntpcd = "ขย2" Or p.lcntpcd = "ขย3" Or p.lcntpcd = "ขย4") Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA_and_PROCESS_ID_AND_IDEN4(ByVal IDEN As String)
            datas = (From p In db.dalcns Where p.CITIZEN_ID_AUTHORIZE = IDEN And p.STATUS_ID = 8 And (p.lcntpcd = "ขยบ" Or p.lcntpcd = "นยบ" Or p.lcntpcd = "ผยบ") Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA_and_PROCESS_ID_AND_IDEN5(ByVal IDEN As String)
            datas = (From p In db.dalcns Where p.CITIZEN_ID_AUTHORIZE = IDEN And p.STATUS_ID = 8 And (p.lcntpcd = "ผยส" Or p.lcntpcd = "นยส" Or p.lcntpcd = "สยส") Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid_lcnno(ByVal lcnsid As Integer, ByVal lcnno As Integer)

            datas = (From p In db.dalcns Where p.lcnsid = lcnsid And p.lcnno = lcnno Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TRANSECTION_ID_UPLOAD(ByVal TRANSECTION_ID_UPLOAD As Integer)

            datas = (From p In db.dalcns Where p.TRANSECTION_ID_UPLOAD = TRANSECTION_ID_UPLOAD Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA_ID(ByVal IDA As Integer)

            datas = (From p In db.dalcns Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_citi_lcnno_lcntpcd(ByVal citi As String, ByVal lcnno As String, ByVal lcnt As String)

            datas = (From p In db.dalcns Where p.CITIZEN_ID_AUTHORIZE = citi And p.lcnno = lcnno And p.lcntpcd = lcnt Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_citi_lcnno(ByVal citi As String, ByVal lcnno As String)

            datas = (From p In db.dalcns Where p.CITIZEN_ID_AUTHORIZE = citi And p.lcnno = lcnno Select p Order By p.IDA Ascending)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_pvncd_lcnno_lcntpcd(ByVal pvncd As String, ByVal lcnno As String, ByVal lcntpcd As String)

            datas = (From p In db.dalcns Where p.pvncd = pvncd And p.lcnno = lcnno And p.lcntpcd = lcntpcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Friend Sub GetDataby_IDA()
            Throw New NotImplementedException()
        End Sub
    End Class
    Public Class TB_MAS_STAFF_OFFER
        Inherits MAINCONTEXT

        Public fields As New MAS_STAFF_OFFER

        Public Sub insert()
            db.MAS_STAFF_OFFERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_STAFF_OFFERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_STAFF_OFFERs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_STAFF_OFFERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdalcnctg
        Inherits MAINCONTEXT

        Public fields As New dalcnctg

        Public Sub insert()
            db.dalcnctgs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dalcnctgs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dalcnctgs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdalcnkep
        Inherits MAINCONTEXT

        Public fields As New dalcnkep

        Public Sub insert()
            db.dalcnkeps.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dalcnkeps.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dalcnkeps Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBdalcnphr
        Inherits MAINCONTEXT

        Public fields As New dalcnphr

        Public Sub insert()
            db.dalcnphrs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dalcnphrs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dalcnphrs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdacnphdtl
        Inherits MAINCONTEXT

        Public fields As New dacnphdtl

        Public Sub insert()
            db.dacnphdtls.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dacnphdtls.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dacnphdtls Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdacncphr
        Inherits MAINCONTEXT

        Public fields As New dacncphr

        Private _Details As List(Of dacncphr)
        Public Property Details() As List(Of dacncphr)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of dacncphr))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New dacncphr
        End Sub
        Public Sub insert()
            db.dacncphrs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dacncphrs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dacncphrs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBdalcntype
        Inherits MAINCONTEXT

        Public fields As New dalcntype

        Public Sub insert()
            db.dalcntypes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dalcntypes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dalcntypes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcntpcd(ByVal lcntpcd As String)

            datas = (From p In db.dalcntypes Where p.lcntpcd = lcntpcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBdaphrcd
        Inherits MAINCONTEXT

        Public fields As New daphrcd

        Public Sub insert()
            db.daphrcds.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.daphrcds.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.daphrcds Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_phrcd(ByVal phrcd As Integer)

            datas = (From p In db.daphrcds Where p.phrcd = phrcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class



    Public Class ClsDBdarqt
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
    End Class






    Public Class ClsDBdasubctg
        Inherits MAINCONTEXT

        Public fields As New dasubctg

        Public Sub insert()
            db.dasubctgs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dasubctgs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dasubctgs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBdaweek
        Inherits MAINCONTEXT

        Public fields As New daweek

        Public Sub insert()
            db.daweeks.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.daweeks.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.daweeks Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class ClsDBdjpctypee
        Inherits MAINCONTEXT

        Public fields As New djpctype

        Public Sub insert()
            db.djpctypes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.djpctypes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.djpctypes Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    'Public Class ClsDBfee
    '    Inherits MAINCONTEXT

    '    Public fields As New fee

    '    Public Sub insert()
    '        db.fees.InsertOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub delete()
    '        db.fees.DeleteOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub GetDataAll()

    '        datas = (From p In db.fees Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    'End Class



    Public Class ClsDBsysplace
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
    End Class

    Public Class ClsDBdalcnaddr
        Inherits MAINCONTEXT

        Public fields As New dalcnaddr

        Public Sub insert()
            db.dalcnaddrs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dalcnaddrs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.dalcnaddrs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class ClsDBDALCN_KEP
        Inherits MAINCONTEXT

        Public fields As New DALCN_KEP

        Public Sub insert()
            db.DALCN_KEPs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_KEPs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DALCN_KEPs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class



    Public Class ClsDBDALCN_PHR
        Inherits MAINCONTEXT

        Public fields As New DALCN_PHR

        Private _Details As New List(Of DALCN_PHR)
        Public Property Details() As List(Of DALCN_PHR)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DALCN_PHR))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New DALCN_PHR
        End Sub
        Public Sub insert()
            db.DALCN_PHRs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_PHRs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DALCN_PHRs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_PHRs Where p.PHR_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA_AddDetails(ByVal FK_IDA As Integer)
            datas = (From p In db.DALCN_PHRs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.DALCN_PHRs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_CTZNO(ByVal CTZNO As String)
            datas = (From p In db.DALCN_PHRs Where p.PHR_CTZNO = CTZNO Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FK_IDA_and_Type(ByVal FK_IDA As Integer, ByVal _type As Integer) As Integer
            Dim i As Integer = 0
            Try
                datas = (From p In db.DALCN_PHRs Where p.FK_IDA = FK_IDA And p.PHR_MEDICAL_TYPE = _type Select p)
                For Each Me.fields In datas
                    i += 1
                Next
            Catch ex As Exception

            End Try
            Return i
        End Function
    End Class



    Public Class ClsDBDALCN_WORKTIME
        Inherits MAINCONTEXT

        Public fields As New DALCN_WORKTIME

        Public Sub insert()
            db.DALCN_WORKTIMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_WORKTIMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DALCN_WORKTIMEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class ClsDBDRUG_REGISTRATION
        Inherits MAINCONTEXT

        Public fields As New DRUG_REGISTRATION
        Private _Details As New List(Of DRUG_REGISTRATION)
        Public Property Details() As List(Of DRUG_REGISTRATION)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRUG_REGISTRATION))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRUG_REGISTRATION
        End Sub
        Public Sub insert()
            db.DRUG_REGISTRATIONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_REGISTRATIONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_REGISTRATIONs Select p)
            For Each Me.fields In datas
            Next
        End Sub


        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATIONs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_CTZNO(ByVal ctzno As String)

            datas = (From p In db.DRUG_REGISTRATIONs Where p.CITIZEN_ID_AUTHORIZE = ctzno Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_DLONLY(ByVal ctzno As String) 'min select only DL indatabase 

            datas = (From p In db.DRUG_REGISTRATIONs Where p.CITIZEN_ID_AUTHORIZE = ctzno And p.STATUS_ID = 8 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA2(ByVal FK_IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATIONs Where p.FK_IDA = FK_IDA And p.STATUS_ID = 8 Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        Public Sub GetDataby_FK_IDA_and_group(ByVal IDA As Integer, ByVal g_id As Integer)

            datas = (From p In db.DRUG_REGISTRATIONs Where p.FK_IDA = IDA And p.GROUP_TYPE = g_id Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATIONs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid_lcnno(ByVal lcnsid As Integer, ByVal lcnno As Integer)

            datas = (From p In db.DRUG_REGISTRATIONs Where p.LCNSID = lcnsid And p.LCNNO = lcnno Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_product(ByVal lcnno As String)

            datas = (From p In db.DRUG_REGISTRATIONs Where p.RCVNO_DISPLAY = lcnno Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class



    Public Class clsDBlgt_impcer
        Inherits MAINCONTEXT
        Public fields As New lgt_impcer
        Public Sub insert()
            db.lgt_impcers.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.lgt_impcers.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.lgt_impcers Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.lgt_impcers Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.lgt_impcers Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.lgt_impcers Where p.lcnsid = lcnsid Select p Order By p.IDA Descending)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid_lcnscd(ByVal lcnsid As Integer, ByVal lcnscd As Integer)
            datas = (From p In db.lgt_impcers Where p.lcnsid = lcnsid And p.lcnscd = lcnscd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_cerno(ByVal cerno As String, ByVal lcnsid As Integer)
            datas = (From p In db.lgt_impcers Where p.CER_NUMBER = cerno And p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class clsDBlgt_impcerref
        Inherits MAINCONTEXT
        Public fields As New lgt_impcerref
        Public Sub insert()
            db.lgt_impcerrefs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.lgt_impcerrefs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.lgt_impcerrefs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnsid_rid(ByVal lcnsid As Integer, ByVal rid As Integer)
            datas = (From p In db.lgt_impcerrefs Where p.rcvno = lcnsid And p.rid = rid Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class


    Public Class clsDBCER_DRTYPE
        Inherits MAINCONTEXT
        Public fields As New CER_DRTYPE

        Private _Details As New List(Of CER_DRTYPE)
        Public Property Details() As List(Of CER_DRTYPE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of CER_DRTYPE))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New CER_DRTYPE
        End Sub

        Public Sub insertAll()
            db.CER_DRTYPEs.InsertAllOnSubmit(Details)
            db.SubmitChanges()
        End Sub
        Public Sub insert()
            db.CER_DRTYPEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.CER_DRTYPEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.CER_DRTYPEs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.CER_DRTYPEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.CER_DRTYPEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class


    Public Class clsDBCER_REF
        Inherits MAINCONTEXT
        Public fields As New CER_REF
        Public Sub insert()
            db.CER_REFs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.CER_REFs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.CER_REFs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.CER_REFs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class


    'Public Class ClsDBFILE_ATTACH
    '    Inherits MAINCONTEXT

    '    Public fields As New FILE_ATTACH

    '    Public Sub insert()
    '        db.FILE_ATTACHes.InsertOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub delete()
    '        db.FILE_ATTACHes.DeleteOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub GetDataAll()

    '        datas = (From p In db.FILE_ATTACHes Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GetDataby_TRANSACTION_ID(ByVal TRANSACTION_ID As Integer)

    '        datas = (From p In db.FILE_ATTACHes Where p.TRANSACTION_ID = TRANSACTION_ID Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GetDataby_IDA(ByVal IDA As Integer)

    '        datas = (From p In db.FILE_ATTACHes Where p.IDA = IDA Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    'End Class
    Public Class ClsDB_MAS_TEMPLATE_PROCESS
        Inherits MAINCONTEXT

        Public fields As New MAS_TEMPLATE_PROCESS

        Public Sub insert()
            db.MAS_TEMPLATE_PROCESSes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_TEMPLATE_PROCESSes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_TEMPLATE_PROCESSes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TEMPLAETE(ByVal P_ID As Integer, ByVal lcntype As String, ByVal STATUS As Integer, ByVal PREVIEW As Integer)
            datas = (From p In db.MAS_TEMPLATE_PROCESSes Where p.PROCESS_ID = P_ID And p.LCNTYPECD = lcntype And p.STATUS_ID = STATUS _
              And p.PREVIEW = PREVIEW Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TEMPLAETE99(ByVal P_ID As Integer, ByVal lcntype As String, ByVal STATUS As Integer, ByVal PREVIEW As Integer)
            datas = (From p In db.MAS_TEMPLATE_PROCESSes Where p.PROCESS_ID = P_ID And p.LCNTYPECD = lcntype And p.STATUS_ID = STATUS _
              And p.PREVIEW = PREVIEW Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TEMPLAETE_BY_GROUP(ByVal P_ID As Integer, ByVal lcntype As String, ByVal STATUS As Integer, ByVal PREVIEW As Integer, Optional _group As Integer = 0)
            datas = (From p In db.MAS_TEMPLATE_PROCESSes Where p.PROCESS_ID = P_ID And p.LCNTYPECD = lcntype And p.STATUS_ID = STATUS _
              And p.PREVIEW = PREVIEW And p.GROUPS = _group Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TEMPLAETE_BY_GROUPV2(ByVal PROCESS_ID As Integer, ByVal lcntype As String, ByVal STATUS As Integer, ByVal PREVIEW As Integer, Optional _group As Integer = 0)
            datas = (From p In db.MAS_TEMPLATE_PROCESSes Where p.PROCESS_ID = PROCESS_ID And p.LCNTYPECD = lcntype And p.STATUS_ID = STATUS _
              And p.PREVIEW = PREVIEW And p.GROUPS = _group Select p)
            For Each Me.fields In datas

            Next
        End Sub
        'Public Sub GetDataby_TEMPLAETE_BY_PROCESS_ID_STATUS(ByVal PROCESS_ID As String, ByVal STATUS As Integer, ByVal group_id As Integer)
        '    datas = (From p In db.MAS_TEMPLATE_PROCESSes Where p.PROCESS_ID = PROCESS_ID And p.STATUS_ID = STATUS _
        '      And p.GROUPS = group_id And p.PREVIEW =  Select p)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        Public Sub GetDataby_TEMPLAETE2(ByVal P_ID As Integer, ByVal STATUS As Integer, ByVal PREVIEW As Integer)
            datas = (From p In db.MAS_TEMPLATE_PROCESSes Where p.PROCESS_ID = P_ID And p.STATUS_ID = STATUS _
              And p.PREVIEW = PREVIEW Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TEMPLAETE_and_GROUP(ByVal P_ID As String, ByVal lcntype As String, ByVal STATUS As Integer, ByVal GROUPS As Integer, ByVal PREVIEW As Integer)
            datas = (From p In db.MAS_TEMPLATE_PROCESSes Where p.PROCESS_ID = P_ID And p.LCNTYPECD = lcntype And p.STATUS_ID = STATUS _
             And p.GROUPS = GROUPS And p.PREVIEW = PREVIEW Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW(ByVal P_ID As Integer, ByVal STATUS As Integer, ByVal PREVIEW As Integer)
            datas = (From p In db.MAS_TEMPLATE_PROCESSes Where p.PROCESS_ID = P_ID And p.STATUS_ID = STATUS _
              And p.PREVIEW = PREVIEW Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TEMPLAETE_TABEAN(ByVal PROCESS_ID As String, ByVal STATUS_ID As Integer, ByVal PREVIEW As Integer)
            datas = (From p In db.MAS_TEMPLATE_PROCESSes Where p.PROCESS_ID = PROCESS_ID And p.STATUS_ID = STATUS_ID _
              And p.PREVIEW = PREVIEW Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TEMPLAETE_and_P_ID_and_STATUS_and_PREVIEW_AND_GROUP(ByVal P_ID As String, ByVal STATUS As Integer, ByVal PREVIEW As String, ByVal _group As Integer)
            datas = (From p In db.MAS_TEMPLATE_PROCESSes Where p.PROCESS_ID = P_ID And p.STATUS_ID = STATUS _
              And p.PREVIEW = PREVIEW And p.GROUPS = _group Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TEMPLAETE9(ByVal P_ID As Integer, ByVal lcntype As String, ByVal STATUS As Integer, ByVal PREVIEW As Integer)      ''มินทำ เอา status 9 มาใช้กับนยม
            datas = (From p In db.MAS_TEMPLATE_PROCESSes Where p.PROCESS_ID = P_ID And p.LCNTYPECD = lcntype And p.STATUS_ID = STATUS _
              And p.PREVIEW = PREVIEW Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class

    Public Class clsDBGEN_NO_01
        Inherits MAINCONTEXT
        Public fields As New GEN_NO_01
        Public Sub insert()
            db.GEN_NO_01s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_NO_01s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_NO_01s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_01s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_YEAR(ByVal YEAR As Integer)
            datas = (From p In db.GEN_NO_01s Where p.YEAR = YEAR Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_01s Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX_N_NC(ByVal YEAR As String, ByVal PVNCD As String, ByVal IDA As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_01s Where p.PVCODE = PVNCD And p.YEAR = YEAR And (p.TYPE = "1" Or p.TYPE = "6") Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX_NB_NBC(ByVal YEAR As String, ByVal PVNCD As String, ByVal IDA As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_01s Where p.PVCODE = PVNCD And p.YEAR = YEAR And (p.TYPE = "7" Or p.TYPE = "B") Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal IDA As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_01s Where p.PVCODE = PVNCD And p.YEAR = YEAR And p.TYPE = RGTTPCD Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_50KMAX(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal IDA As Integer, ByVal process_id As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_01s Where p.PVCODE = PVNCD And p.YEAR = YEAR And p.GROUP_NO = RGTTPCD And p.TYPE = process_id Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class clsDBGEN_NO_02
        Inherits MAINCONTEXT
        Public fields As New GEN_NO_02
        Public Sub insert()
            db.GEN_NO_02s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_NO_02s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_NO_02s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_02s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_YEAR(ByVal YEAR As Integer)
            datas = (From p In db.GEN_NO_02s Where p.YEAR = YEAR Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            datas = (From p In db.GEN_NO_02s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN2(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String)
            datas = (From p In db.GEN_NO_02s Where p.IDA = YEAR And p.GROUP_NO = GROUP_NO And p.PVCODE = PVCODE
                     Order By p.IDA Descending Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN2(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            'datas = (From p In db.GEN_NO_02s Where p.IDA = YEAR Order By p.IDA Descending Select p)

            datas = (From p In db.GEN_NO_02s Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN3(ByVal YEAR As String, ByVal PVCODE As String, ByVal GROUP_NO As String, ByVal REF_IDA As String)
            datas = (From p In db.GEN_NO_02s Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.GROUP_NO = GROUP_NO Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class clsDBGEN_NO_03
        Inherits MAINCONTEXT
        Public fields As New GEN_NO_03
        Public Sub insert()
            db.GEN_NO_03s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_NO_03s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_NO_01s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_03s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_YEAR(ByVal YEAR As Integer)
            datas = (From p In db.GEN_NO_03s Where p.YEAR = YEAR Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            datas = (From p In db.GEN_NO_03s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN2(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            'datas = (From p In db.GEN_NO_02s Where p.IDA = YEAR Order By p.IDA Descending Select p)

            datas = (From p In db.GEN_NO_03s Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        ''' <summary>
        ''' ดึงข้อมูลเลข Gen ตาม ปี จังหวัด
        ''' </summary>
        ''' <param name="YEAR"></param>
        ''' <param name="PVCODE"></param>
        ''' <param name="GROUP_NO"></param>
        ''' <remarks></remarks>
        Public Sub GetDataby_GEN_YEAR_PVCODE(ByVal YEAR As String, ByVal PVCODE As String, ByVal GROUP_NO As String)
            datas = (From p In db.GEN_NO_03s Where p.YEAR = YEAR And p.PVCODE = PVCODE And p.GROUP_NO = GROUP_NO Order By p.GENNO Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class clsDBGEN_NO_04
        Inherits MAINCONTEXT
        Public fields As New GEN_NO_04
        Public Sub insert()
            db.GEN_NO_04s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_NO_04s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_NO_01s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_04s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String, _
        '                ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
        '    datas = (From p In db.GEN_NO_04s Where p.IDA = YEAR Order By p.IDA Descending Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_04s Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class clsDBGEN_NO_05
        Inherits MAINCONTEXT
        Public fields As New GEN_NO_05
        Public Sub insert()
            db.GEN_NO_05s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_NO_05s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_NO_01s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_05s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            'datas = (From p In db.GEN_NO_05s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_05s Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class clsDBGEN_NO_06
        Inherits MAINCONTEXT
        Public fields As New GEN_NO_06
        Public Sub insert()
            db.GEN_NO_06s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_NO_06s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_NO_06s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_06s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            'datas = (From p In db.GEN_NO_05s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_06s Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class clsDBGEN_NO_07
        Inherits MAINCONTEXT
        Public fields As New GEN_NO_07
        Public Sub insert()
            db.GEN_NO_07s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_NO_07s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_NO_07s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_07s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            'datas = (From p In db.GEN_NO_05s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_07s Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class clsDBGEN_NO_16
        Inherits MAINCONTEXT
        Public fields As New GEN_NO_16
        Public Sub insert()
            db.GEN_NO_16s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_NO_16s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_NO_16s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_16s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            'datas = (From p In db.GEN_NO_05s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_16s Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class clsDBGEN_NO_17
        Inherits MAINCONTEXT
        Public fields As New GEN_NO_17
        Public Sub insert()
            db.GEN_NO_17s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_NO_17s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_NO_17s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_17s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            'datas = (From p In db.GEN_NO_05s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_17s Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class clsDBGEN_NO_18
        Inherits MAINCONTEXT
        Public fields As New GEN_NO_18
        Public Sub insert()
            db.GEN_NO_18s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_NO_18s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_NO_17s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_18s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            'datas = (From p In db.GEN_NO_05s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_18s Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class clsDBGEN_DH15TDGT_NO
        Inherits MAINCONTEXT
        Public fields As New GEN_DH15TDGT_NO
        Public Sub insert()
            db.GEN_DH15TDGT_NOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_DH15TDGT_NOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_DH15TDGT_NOs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_DH15TDGT_NOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_YEAR(ByVal YEARs As Integer)
            datas = (From p In db.GEN_DH15TDGT_NOs Where p.YEARS = YEARs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN_MAX(ByVal YEARS As String, ByVal aroi As String, ByVal type_cas As String)
            datas = (From p In db.GEN_DH15TDGT_NOs Where p.YEARS = YEARS And p.aroi = aroi And p.TYPE_CAS = type_cas Order By CInt(p.RUNNING_NUMBER) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN_MAX2(ByVal YEARS As String, ByVal type_cas As String)
            datas = (From p In db.GEN_DH15TDGT_NOs Where p.YEARS = YEARS And p.TYPE_CAS = type_cas Order By CInt(p.RUNNING_NUMBER) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class ClsDBMAS_STATUS
        Inherits MAINCONTEXT

        Public fields As New MAS_STATUS
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_STATUS Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA_Group(ByVal stat As Integer, ByVal _group As Integer)

            datas = (From p In db.MAS_STATUS Where p.STATUS_ID = stat And p.STATUS_GROUP = _group Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.MAS_STATUS.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_STATUS.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_STATUS Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll_BYGROUP()

            datas = (From p In db.MAS_STATUS Where p.STATUS_GROUP = 1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class ClsDBSTATUS_DATE
        Inherits MAINCONTEXT

        Public fields As New STATUS_DATE
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.STATUS_DATEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA_Group(ByVal stat As Integer, ByVal _group As Integer)

            datas = (From p In db.STATUS_DATEs Where p.STATUS_ID = stat And p.STATUS_GROUP = _group Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.STATUS_DATEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.STATUS_DATEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.STATUS_DATEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class ClsDBEDIT_REQUEST
        Inherits MAINCONTEXT

        Public fields As New EDIT_REQUEST
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.EDIT_REQUESTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.EDIT_REQUESTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.EDIT_REQUESTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.EDIT_REQUESTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class ClsDBPROCESS_NAME
        Inherits MAINCONTEXT

        Public fields As New PROCESS_NAME
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.PROCESS_NAMEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Process_ID(ByVal _process As String)

            datas = (From p In db.PROCESS_NAMEs Where p.PROCESS_ID = _process Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_PROCESS_DESCRIPTION(ByVal PROCESS_DESCRIPTION As String)

            datas = (From p In db.PROCESS_NAMEs Where p.PROCESS_DESCRIPTION = PROCESS_DESCRIPTION Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Process_Name(ByVal _process As String)
            datas = (From p In db.PROCESS_NAMEs Where p.PROCESS_NAME = _process Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.PROCESS_NAMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.PROCESS_NAMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.PROCESS_NAMEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class ClsDBDRUG_PROJECT
        Inherits MAINCONTEXT

        Public fields As New DRUG_PROJECT
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_PROJECTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.DRUG_PROJECTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_PROJECTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_PROJECTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class ClsDBDRUG_PROJECT_SUM
        Inherits MAINCONTEXT

        Public fields As New DRUG_PROJECT_SUMMARY
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)
            datas = (From p In db.DRUG_PROJECT_SUMMARies Where p.TR_ID = TR_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRUG_PROJECT_SUMMARies Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_authorize(ByVal taxno As Integer)
            datas = (From p In db.DRUG_PROJECT_SUMMARies Where p.CITIZEN_AUTHORIZE = taxno And p.STATUS_ID >= 1 Select p Order By p.IDA Descending)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.DRUG_PROJECT_SUMMARies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_PROJECT_SUMMARies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRUG_PROJECT_SUMMARies Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataStaff()
            datas = (From p In db.DRUG_PROJECT_SUMMARies Where p.STATUS_ID >= 2 Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class ClsDBDRUG_PROJECT_SUM_LOG
        Inherits MAINCONTEXT

        Public fields As New DRUG_PROJECT_SUMMARY_LOG
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRUG_PROJECT_SUMMARY_LOGs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_PJSUM(ByVal PJSUM As Integer)
            datas = (From p In db.DRUG_PROJECT_SUMMARY_LOGs Where p.PJSUM_IDA = PJSUM Order By p.modified_times Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.DRUG_PROJECT_SUMMARY_LOGs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_PROJECT_SUMMARY_LOGs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRUG_PROJECT_SUMMARY_LOGs Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class ClsDBDRUG_PROJECT_RESEARCH_FACILITY
        Inherits MAINCONTEXT

        Public fields As New DRUG_PROJECT_RESEARCH_FACILITY
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRUG_PROJECT_RESEARCH_FACILITies Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_PROJECT(ByVal PROJECT_IDA As Integer)
            datas = (From p In db.DRUG_PROJECT_RESEARCH_FACILITies Where p.PJ_IDA = PROJECT_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.DRUG_PROJECT_RESEARCH_FACILITies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_PROJECT_RESEARCH_FACILITies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRUG_PROJECT_RESEARCH_FACILITies Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class ClsDBDRUG_PROJECT_CLINICAL_LABORATORY
        Inherits MAINCONTEXT

        Public fields As New DRUG_PROJECT_CLINICAL_LABORATORY
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRUG_PROJECT_CLINICAL_LABORATORies Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_PROJECT(ByVal PROJECT_IDA As Integer)
            datas = (From p In db.DRUG_PROJECT_CLINICAL_LABORATORies Where p.PJ_IDA = PROJECT_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.DRUG_PROJECT_CLINICAL_LABORATORies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_PROJECT_CLINICAL_LABORATORies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRUG_PROJECT_CLINICAL_LABORATORies Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class ClsDBDRUG_PROJECT_DRUG_ACTIVE_INGREDIENTS
        Inherits MAINCONTEXT

        Public fields As New DRUG_PROJECT_DRUG_ACTIVE_INGREDIENT
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRUG_PROJECT_DRUG_ACTIVE_INGREDIENTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_DRUG(ByVal DRUG_IDA As Integer)
            datas = (From p In db.DRUG_PROJECT_DRUG_ACTIVE_INGREDIENTs Where p.FK_IDA = DRUG_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.DRUG_PROJECT_DRUG_ACTIVE_INGREDIENTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_PROJECT_DRUG_ACTIVE_INGREDIENTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRUG_PROJECT_DRUG_ACTIVE_INGREDIENTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class ClsDBDRUG_NORYORMOR1_IMPORT
        Inherits MAINCONTEXT

        Public fields As New DRUG_NORYORMOR1_IMPORT
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRUG_NORYORMOR1_IMPORTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.DRUG_NORYORMOR1_IMPORTs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_PJSUM(ByVal PJSUM As Integer)
            datas = (From p In db.DRUG_NORYORMOR1_IMPORTs Where p.PJ_SUM = PJSUM Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TIMES(ByVal PJSUM As Integer, ByVal TIMES As Integer)
            datas = (From p In db.DRUG_NORYORMOR1_IMPORTs Where p.PJ_SUM = PJSUM And p.TIMES = TIMES Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_NAME(ByVal PJSUM As Integer, ByVal TIMES As Integer, ByVal drgnm As String)
            datas = (From p In db.DRUG_NORYORMOR1_IMPORTs Where p.PJ_SUM = PJSUM And p.TIMES = TIMES And p.DRUG_NAME = drgnm Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.DRUG_NORYORMOR1_IMPORTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_NORYORMOR1_IMPORTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRUG_NORYORMOR1_IMPORTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class ClsDBDRUG_PROJECT_DRUG_LIST
        Inherits MAINCONTEXT

        Public fields As New DRUG_PROJECT_DRUG_LIST
        Private _Details As New List(Of DRUG_PROJECT_DRUG_LIST)
        Public Property Details() As List(Of DRUG_PROJECT_DRUG_LIST)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRUG_PROJECT_DRUG_LIST))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRUG_PROJECT_DRUG_LIST
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRUG_PROJECT_DRUG_LISTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_PROJECT(ByVal PROJECT_IDA As Integer)
            datas = (From p In db.DRUG_PROJECT_DRUG_LISTs Where p.PJ_IDA = PROJECT_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Authorize(ByVal authorize_id As String)
            datas = (From p In db.DRUG_PROJECT_DRUG_LISTs Where p.citizen_autho = authorize_id And p.is_lastest = True Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_notuse(ByVal authorize_id As String)
            datas = (From p In db.DRUG_PROJECT_DRUG_LISTs Where p.citizen_autho = authorize_id And p.is_lastest = True And p.is_used Is Nothing Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
        Public Sub insert()
            db.DRUG_PROJECT_DRUG_LISTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_PROJECT_DRUG_LISTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRUG_PROJECT_DRUG_LISTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class ClsDBTH_RESEARCH_LOCATION
        Inherits MAINCONTEXT

        Public fields As New TH_RESEARCH_LOCATION
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TH_RESEARCH_LOCATIONs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.TH_RESEARCH_LOCATIONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TH_RESEARCH_LOCATIONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TH_RESEARCH_LOCATIONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class ClsDBMAS_RESEARCHER
        Inherits MAINCONTEXT

        Public fields As New MAS_RESEARCHER
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_RESEARCHERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.MAS_RESEARCHERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_RESEARCHERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_RESEARCHERs Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class ClsDBDRUG_IN_PROJECT
        Inherits MAINCONTEXT

        Public fields As New DRUG_IN_PROJECT
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_IN_PROJECTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.DRUG_IN_PROJECTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_IN_PROJECTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_IN_PROJECTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class ClsDBMAS_MENU
        Inherits MAINCONTEXT

        Public fields As New MAS_MENU
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_MENUs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_HEAD_ID(ByVal head_id As Integer, ByVal group_p As Integer)
            datas = (From p In db.MAS_MENUs Where p.HEAD_ID = head_id And p.GROUP_PAGE = group_p Select p Order By p.SEQ Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Process(ByVal process As Integer)
            datas = (From p In db.MAS_MENUs Where p.PROCESS_ID = process And p.GROUP_PAGE = 1 Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Process2(ByVal process As Integer)
            datas = (From p In db.MAS_MENUs Where p.PROCESS_ID = process Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub insert()
            db.MAS_MENUs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_MENUs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.MAS_MENUs Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class ClsDBMAS_MENU_AUTO
        Inherits MAINCONTEXT

        Public fields As New MAS_MENU_AUTO
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_MENU_AUTOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_HEAD_ID(ByVal head_id As Integer, ByVal group_p As Integer)
            datas = (From p In db.MAS_MENU_AUTOs Where p.HEAD_ID = head_id And p.GROUP_PAGE = group_p Select p Order By p.SEQ Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Process(ByVal process As Integer)
            datas = (From p In db.MAS_MENU_AUTOs Where p.PROCESS_ID = process And p.GROUP_PAGE = 1 Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Process2(ByVal process As Integer)
            datas = (From p In db.MAS_MENU_AUTOs Where p.PROCESS_ID = process Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub insert()
            db.MAS_MENU_AUTOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_MENU_AUTOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.MAS_MENU_AUTOs Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class ClsDBMAS_MAIN_GROUP_STATUS
        Inherits MAINCONTEXT

        Public fields As New MAS_MAIN_GROUP_STATUS
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_MAIN_GROUP_STATUS Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_STATUS_ID(ByVal STATUS_ID As Integer)
            datas = (From p In db.MAS_MAIN_GROUP_STATUS Where p.STATUS_ID = STATUS_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.MAS_MAIN_GROUP_STATUS Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.MAS_MAIN_GROUP_STATUS.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_MAIN_GROUP_STATUS.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub



    End Class

    Public Class ClsDBDETAIL_MAIN_GROUP_STATUS
        Inherits MAINCONTEXT

        Public fields As New DETAIL_MAIN_GROUP_STATUS
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DETAIL_MAIN_GROUP_STATUS Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DETAIL_MAIN_GROUP_STATUS Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.DETAIL_MAIN_GROUP_STATUS.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DETAIL_MAIN_GROUP_STATUS.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub



    End Class

    Public Class ClsDBDATE_MODIFY_STATUS
        Inherits MAINCONTEXT

        Public fields As New DATE_MODIFY_STATUS
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DATE_MODIFY_STATUS Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DATE_MODIFY_STATUS Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.DATE_MODIFY_STATUS.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DATE_MODIFY_STATUS.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class

    Public Class ClsDBDATE_E_TRACK_STAFF_STATUS
        Inherits MAINCONTEXT

        Public fields As New E_TRACK_STAFF_STATUS
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.E_TRACK_STAFF_STATUS Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.E_TRACK_STAFF_STATUS Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.E_TRACK_STAFF_STATUS.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACK_STAFF_STATUS.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class

    Public Class ClsDBE_TRACKING_STAFF_CITIZEN_ID
        Inherits MAINCONTEXT

        Public fields As New E_TRACKING_STAFF_CITIZEN_ID
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.E_TRACKING_STAFF_CITIZEN_IDs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.E_TRACKING_STAFF_CITIZEN_IDs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.E_TRACKING_STAFF_CITIZEN_IDs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACKING_STAFF_CITIZEN_IDs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class ClsDBE_TRACKING_STAFF
        Inherits MAINCONTEXT

        Public fields As New E_TRACKING_STAFF
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.E_TRACKING_STAFFs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.E_TRACKING_STAFFs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.E_TRACKING_STAFFs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACKING_STAFFs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_CER_DETAIL_CASCHEMICAL
        Inherits MAINCONTEXT

        Public fields As New CER_DETAIL_CASCHEMICAL
        Private _Details As New List(Of CER_DETAIL_CASCHEMICAL)
        Public Property Details() As List(Of CER_DETAIL_CASCHEMICAL)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of CER_DETAIL_CASCHEMICAL))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New CER_DETAIL_CASCHEMICAL
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.CER_DETAIL_CASCHEMICALs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.CER_DETAIL_CASCHEMICALs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA_DET(ByVal FK_IDA As Integer)
            datas = (From p In db.CER_DETAIL_CASCHEMICALs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.CER_DETAIL_CASCHEMICALs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.CER_DETAIL_CASCHEMICALs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CER_DETAIL_CASCHEMICALs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class

    Public Class TB_CER_DETAIL_MANUFACTURE
        Inherits MAINCONTEXT

        Public fields As New CER_DETAIL_MANUFACTURE
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.CER_DETAIL_MANUFACTUREs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.CER_DETAIL_MANUFACTUREs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.CER_DETAIL_MANUFACTUREs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.CER_DETAIL_MANUFACTUREs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CER_DETAIL_MANUFACTUREs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class

    Public Class TB_MAS_CHEMICAL
        Inherits MAINCONTEXT

        Public fields As New MAS_CHEMICAL
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_CHEMICALs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        'Function GetDataby_A_R(ByVal IDA As Integer) As Integer
        '    Dim i As Integer = 0
        '    datas = (From p In db.MAS_CHEMICALs Where p.IDA = IDA Select p)
        '    For Each Me.fields In datas
        '    Next
        '    Return i
        'End Function
        'Function GetDataby_A_NR(ByVal IDA As Integer) As Integer
        '    datas = (From p In db.MAS_CHEMICALs Where p.IDA = IDA Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Function
        'Function GetDataby_I_R(ByVal IDA As Integer) As Integer
        '    datas = (From p In db.MAS_CHEMICALs Where p.IDA = IDA Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Function
        'Function GetDataby_I_NR(ByVal IDA As Integer) As Integer
        '    datas = (From p In db.MAS_CHEMICALs Where p.IDA = IDA Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Function
        Public Sub GetDataAll()
            datas = (From p In db.MAS_CHEMICALs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.MAS_CHEMICALs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_CHEMICALs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub Get_RUNNO_MAX()
            datas = (From p In db.MAS_CHEMICALs Order By CInt(p.runno) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub Get_data_by_iowa(ByVal iowa As String)
            datas = (From p In db.MAS_CHEMICALs Where p.iowa = iowa Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function Count_data_by_iowa(ByVal iowa As String) As Integer
            Dim i As Integer = 0
            datas = (From p In db.MAS_CHEMICALs Where p.iowa = iowa Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class


    Public Class TB_CHEMICAL_REQUEST
        Inherits MAINCONTEXT

        Public fields As New CHEMICAL_REQUEST
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.CHEMICAL_REQUESTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.CHEMICAL_REQUESTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.CHEMICAL_REQUESTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CHEMICAL_REQUESTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_CHEMICAL_REQUEST_DETAIL
        Inherits MAINCONTEXT

        Public fields As New CHEMICAL_REQUEST_DETAIL
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.CHEMICAL_REQUEST_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.CHEMICAL_REQUEST_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.CHEMICAL_REQUEST_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CHEMICAL_REQUEST_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_DH15_DETAIL_CER
        Inherits MAINCONTEXT

        Public fields As New DH15_DETAIL_CER
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DH15_DETAIL_CERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.DH15_DETAIL_CERs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DH15_DETAIL_CERs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.DH15_DETAIL_CERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DH15_DETAIL_CERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_TEMPLATE_ATTACH
        Inherits MAINCONTEXT

        Public fields As New TEMPLATE_ATTACH

        Private _Details As New List(Of TEMPLATE_ATTACH)
        Public Property Details() As List(Of TEMPLATE_ATTACH)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TEMPLATE_ATTACH))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TEMPLATE_ATTACH
        End Sub


        Public Sub GetDataby_LCTNPCD(ByVal LCTNPCD As String, ByVal CONVENTPCD As String)
            datas = (From p In db.TEMPLATE_ATTACHes Where p.LCNTPCD = LCTNPCD And p.conventpcd = CONVENTPCD Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub insert()
            db.TEMPLATE_ATTACHes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TEMPLATE_ATTACHes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class

    Public Class TB_TRANFER_LOCATION
        Inherits MAINCONTEXT

        Public fields As New TRANFER_LOCATION

        Private _Details As New List(Of TRANFER_LOCATION)
        Public Property Details() As List(Of TRANFER_LOCATION)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TRANFER_LOCATION))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TRANFER_LOCATION
        End Sub


        Public Sub GetDataby_IDA(ByVal IDA As String)
            datas = (From p In db.TRANFER_LOCATIONs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub insert()
            db.TRANFER_LOCATIONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TRANFER_LOCATIONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class


    '_______________________________________________________________
    ''' <summary>
    ''' Cer ใบอนุญาตการนำเข้า
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_CER
        Inherits MAINCONTEXT
        Public fields As New CER

        Private _Details As New List(Of CER)
        Public Property Details() As List(Of CER)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of CER))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New CER
        End Sub


        'Public Sub GetDataby_IDA(ByVal IDA As String)
        '    datas = (From p In db.CERs Where p.IDA = IDA Select p)
        '    For Each Me.fields In datas
        '        AddDetails()
        '    Next
        'End Sub
        Public Sub Get_data_all()
            datas = (From p In db.CERs Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA2(ByVal IDA As String)
            datas = (From p In db.CERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As String)
            datas = (From p In db.CERs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub insert()
            db.CERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    ''' <summary>
    ''' Cer ใบอนุญาตการนำเข้า
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_CER_FOREIGN
        Inherits MAINCONTEXT
        Public fields As New CER_FOREIGN

        Public Sub GetDataby_IDA(ByVal IDA As String)
            datas = (From p In db.CER_FOREIGNs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As String)
            datas = (From p In db.CER_FOREIGNs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub insert()
            db.CER_FOREIGNs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CER_FOREIGNs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_CER_FOREIGN_MANUFACTURE
        Inherits MAINCONTEXT
        Public fields As New CER_FOREIGN_MANUFACTURE

        Public Sub GetDataby_IDA(ByVal IDA As String)
            datas = (From p In db.CER_FOREIGN_MANUFACTUREs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As String)
            datas = (From p In db.CER_FOREIGN_MANUFACTUREs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub insert()
            db.CER_FOREIGN_MANUFACTUREs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CER_FOREIGN_MANUFACTUREs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class clsDBsysisocnt
        Inherits MAINCONTEXT
        Public fields As New sysisocnt
        Public Sub insert()
            db.sysisocnts.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.sysisocnts.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.sysisocnts Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_alpha3(ByVal alpha3 As String)
            datas = (From p In db.sysisocnts Where p.alpha3 = alpha3 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_engcntnm(ByVal engcntnm As String)
            datas = (From p In db.sysisocnts Where p.engcntnm = engcntnm Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)
            datas = (From p In db.sysisocnts Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class





    Public Class TB_DH15_DETAIL_CASCHEMICAL
        Inherits MAINCONTEXT                    'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DH15_DETAIL_CASCHEMICAL            'ใส่ชื่อ Table   (dh15rqt)
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DH15_DETAIL_CASCHEMICALs Where p.IDA = IDA Select p) 'การ Where   table(DH15_DETAIL_MANUFACTUREs)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DH15_DETAIL_CASCHEMICALs Where p.FK_IDA = IDA Select p) 'การ Where   table(DH15_DETAIL_MANUFACTUREs)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.DH15_DETAIL_CASCHEMICALs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DH15_DETAIL_CASCHEMICALs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DH15_DETAIL_CASCHEMICALs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_LOG_DH_ERROR
        Inherits MAINCONTEXT                    'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New LOG_DH_ERROR            'ใส่ชื่อ Table   (dh15rqt)
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.LOG_DH_ERRORs Where p.IDA = IDA Select p) 'การ Where   table(DH15_DETAIL_MANUFACTUREs)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.LOG_DH_ERRORs Where p.FK_IDA = IDA Select p) 'การ Where   table(DH15_DETAIL_MANUFACTUREs)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.LOG_DH_ERRORs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LOG_DH_ERRORs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LOG_DH_ERRORs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_DH15_DETAIL_MANUFACTURE
        Inherits MAINCONTEXT                    'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DH15_DETAIL_MANUFACTURE            'ใส่ชื่อ Table   (dh15rqt)
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DH15_DETAIL_MANUFACTUREs Where p.IDA = IDA Select p) 'การ Where   table(dh15rqts)เติม s เพื่อไม่ให้ชื่อซ้ำกับ Table   (P คือ ประกาศตัวแปรเป็น Table)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub insert()
            db.DH15_DETAIL_MANUFACTUREs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DH15_DETAIL_MANUFACTUREs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DH15_DETAIL_MANUFACTUREs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class TB_DRRGT_DETAIL_ROLE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_DETAIL_ROLE
        Private _Details As New List(Of DRRGT_DETAIL_ROLE)
        Public Property Details() As List(Of DRRGT_DETAIL_ROLE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_DETAIL_ROLE))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_DETAIL_ROLE
        End Sub
        Public Sub insert()
            db.DRRGT_DETAIL_ROLEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_DETAIL_ROLEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_DETAIL_ROLEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class


    Public Class TB_DALCN_DETAIL_LOCATION_KEEP
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DALCN_DETAIL_LOCATION_KEEP

        Public Sub insert()
            db.DALCN_DETAIL_LOCATION_KEEPs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_DETAIL_LOCATION_KEEPs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DALCN_DETAIL_LOCATION_KEEPs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetData_by_LCN_IDA(ByVal LCN_IDA As String)

            datas = (From p In db.DALCN_DETAIL_LOCATION_KEEPs Where p.LCN_IDA = LCN_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_IDA(ByVal IDA As String)

            datas = (From p In db.DALCN_DETAIL_LOCATION_KEEPs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TB_DRUG_CONSIDER_REQUESTS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_CONSIDER_REQUEST

        Public Sub insert()
            db.DRUG_CONSIDER_REQUESTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_CONSIDER_REQUESTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_CONSIDER_REQUESTs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll_A()

            datas = (From p In db.DRUG_CONSIDER_REQUESTs Where p.IDA >= 7429 And p.CONREQ_LAST_UPDATE_DATE IsNot Nothing Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_CONSIDER_REQUESTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function GetDataby_R_and_C(ByVal r As String) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRUG_CONSIDER_REQUESTs Where p.REQUEST_CENTER_NO = r Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Sub GetDataby_R_and_C_V2(ByVal r As String)
            datas = (From p In db.DRUG_CONSIDER_REQUESTs Where p.RCVNO_DISPLAY = r Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_A(ByVal A As String)
            datas = (From p In db.DRUG_CONSIDER_REQUESTs Where p.RCVNO_DISPLAY = A Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function Count_Ref_no(ByVal ref_no As String) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRUG_CONSIDER_REQUESTs Where p.REF_NO = ref_no Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class

    Public Class TB_MAS_E_TRACKING_GAP
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_E_TRACKING_GAP

        Public Sub insert()
            db.MAS_E_TRACKING_GAPs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_E_TRACKING_GAPs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_E_TRACKING_GAPs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_E_TRACKING_GAPs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_EDT_HISTORY
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New EDT_HISTORY

        Public Sub insert()
            db.EDT_HISTORies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.EDT_HISTORies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.EDT_HISTORies Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.EDT_HISTORies Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.EDT_HISTORies Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DALCN_PHR_HISTORY
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DALCN_PHR_HISTORY

        Public Sub insert()
            db.DALCN_PHR_HISTORies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_PHR_HISTORies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DALCN_PHR_HISTORies Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_PHR_HISTORies Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_PHR_IDA As Integer)

            datas = (From p In db.DALCN_PHR_HISTORies Where p.FK_PHR_IDA = FK_PHR_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_EDT_COUNT
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New EDT_COUNT

        Public Sub insert()
            db.EDT_COUNTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.EDT_COUNTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.EDT_COUNTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.EDT_COUNTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.EDT_COUNTs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_COUNT_MAX(ByVal PROCESS_ID As Integer, ByVal FK_IDA As Integer)
            datas = (From p In db.EDT_COUNTs Where p.PROCESS_ID = PROCESS_ID And p.FK_IDA = FK_IDA Order By CInt(p.EDIT_COUNT) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_MAS_TYPE_REQUESTS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_TYPE_REQUEST

        Public Sub insert()
            db.MAS_TYPE_REQUESTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_TYPE_REQUESTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_TYPE_REQUESTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_TYPE_REQUESTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_type(ByVal _type As Integer)

            datas = (From p In db.MAS_TYPE_REQUESTs Where p.TYPE_REQUESTS_ID = _type Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_CD(ByVal cd As String)

            datas = (From p In db.MAS_TYPE_REQUESTs Where p.TYPE_REQUESTS_ID = cd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll_active()

            datas = (From p In db.MAS_TYPE_REQUESTs Where p.ACTIVE = "YES" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll_active_for_Customer()

            datas = (From p In db.MAS_TYPE_REQUESTs Where p.ACTIVE = "YES" Select p)
            For Each Me.fields In datas
            Next
            'And p.TYPE_REQUESTS_ID <= 100
        End Sub
        Public Sub GetDataby_WORK_GROUP_TYPE(ByVal WORK_GROUP_TYPE As Integer)

            datas = (From p In db.MAS_TYPE_REQUESTs Where p.WORK_GROUP_TYPE = WORK_GROUP_TYPE And p.ACTIVE = "YES" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_TABEAN_Only()

            datas = (From p In db.MAS_TYPE_REQUESTs Where p.TYPE_REQUESTS_ID >= 100 And p.TYPE_REQUESTS_ID < 170 Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_CONSIDER_REQ_PRINT_HISTORY
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New CONSIDER_REQ_PRINT_HISTORY

        Public Sub insert()
            db.CONSIDER_REQ_PRINT_HISTORies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CONSIDER_REQ_PRINT_HISTORies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.CONSIDER_REQ_PRINT_HISTORies Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.CONSIDER_REQ_PRINT_HISTORies Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_COUNT_MAX(ByVal _year As Integer)
            datas = (From p In db.CONSIDER_REQ_PRINT_HISTORies Where p.YEAR_PRINT = _year Order By CInt(p.PRINT_COUNT) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_DRUG_PRODUCT_ID
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_PRODUCT_ID

        Public Sub insert()
            db.DRUG_PRODUCT_IDs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_PRODUCT_IDs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_PRODUCT_IDs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_PRODUCT_IDs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_PJSUM(ByVal PJSUM As Integer)

            datas = (From p In db.DRUG_PRODUCT_IDs Where p.PJSUM_IDA = PJSUM Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_product(ByVal lcnno_dis As String)

            datas = (From p In db.DRUG_PRODUCT_IDs Where p.LCNNO_DISPLAY = lcnno_dis Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function count_stat8(ByVal ctzid As String) As Boolean
            Dim bool As Boolean = False
            Dim i As Integer = 0
            datas = (From p In db.DRUG_PRODUCT_IDs Where p.CITIZEN_ID_AUTHORIZE = ctzid And p.STATUS_ID = 8 Select p)
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If
            Return bool
        End Function
    End Class
    Public Class TB_DRUG_PRODUCT_DR_GROUP
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_PRODUCT_DR_GROUP

        Public Sub insert()
            db.DRUG_PRODUCT_DR_GROUPs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_PRODUCT_DR_GROUPs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_PRODUCT_DR_GROUPs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_PRODUCT_DR_GROUPs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRUG_PRODUCT_IOWA
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_PRODUCT_IOWA

        Public Sub insert()
            db.DRUG_PRODUCT_IOWAs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_PRODUCT_IOWAs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_PRODUCT_IOWAs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_PRODUCT_IOWAs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_PRODUCT_IOWAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function Count_input(ByVal IDA As Integer) As Boolean
            Dim bool As Boolean = False
            Dim i As Integer = 0
            datas = (From p In db.DRUG_PRODUCT_IOWAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If
            Return bool
        End Function
    End Class
    '
    Public Class TB_MAS_WORK_GROUP
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_WORK_GROUP

        Public Sub insert()
            db.MAS_WORK_GROUPs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_WORK_GROUPs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_WORK_GROUPs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_WORK_GROUPs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_WORK_GROUP_ID(ByVal WORK_GROUP_ID As Integer)

            datas = (From p In db.MAS_WORK_GROUPs Where p.WORK_GROUP_ID = WORK_GROUP_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_MAS_NEW_WORK_GROUP
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_NEW_WORK_GROUP

        Public Sub insert()
            db.MAS_NEW_WORK_GROUPs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_NEW_WORK_GROUPs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_NEW_WORK_GROUPs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_NEW_WORK_GROUPs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_DRUG_TERM_TO_USE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_TERM_TO_USE

        Public Sub insert()
            db.DRUG_TERM_TO_USEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_TERM_TO_USEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_TERM_TO_USEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_DRUG_PRODUCT_ATC
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_PRODUCT_ATC

        Public Sub insert()
            db.DRUG_PRODUCT_ATCs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_PRODUCT_ATCs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_PRODUCT_ATCs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_PRODUCT_ATCs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function Count_input(ByVal IDA As Integer) As Boolean
            Dim bool As Boolean = False
            Dim i As Integer = 0
            datas = (From p In db.DRUG_PRODUCT_ATCs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If
            Return bool
        End Function
    End Class
    Public Class TB_DRUG_PRODUCT_ADDR
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_PRODUCT_ADDR

        Public Sub insert()
            db.DRUG_PRODUCT_ADDRs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_PRODUCT_ADDRs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_PRODUCT_ADDRs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.DRUG_PRODUCT_ADDRs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function Chk_repeat(ByVal FK_IDA As Integer) As Boolean
            Dim bool As Boolean = False
            Dim i As Integer = 0
            datas = (From p In db.DRUG_PRODUCT_ADDRs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If

            Return bool
        End Function
    End Class
    Public Class TB_ATC_DRUG
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New ATC_DRUG

        Public Sub insert()
            db.ATC_DRUGs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.ATC_DRUGs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.ATC_DRUGs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.ATC_DRUGs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_ATCCD(ByVal atccd As String)

            datas = (From p In db.ATC_DRUGs Where p.atccd = atccd Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_lcnrequest
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New lcnrequest

        Public Sub insert()
            db.lcnrequests.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.lcnrequests.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.lcnrequests Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_citi(ByVal citi As String)

            datas = (From p In db.lcnrequests Where p.CITIZEN_ID = citi Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TRid As String)

            datas = (From p In db.lcnrequests Where p.TR_ID = TRid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.lcnrequests Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcntpcd(lcntpcd As String)

            datas = (From p In db.lcnrequests Where p.lcntpcd_old = lcntpcd Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_LCN_EXTEND
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New LCN_EXTEND

        Public Sub insert()
            db.LCN_EXTENDs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_EXTENDs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.LCN_EXTENDs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.LCN_EXTENDs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_E_TRACKING_BASE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New E_TRACKING_BASE

        Public Sub insert()
            db.E_TRACKING_BASEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACKING_BASEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.E_TRACKING_BASEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub get_max_update()
            datas = (From p In db.E_TRACKING_BASEs Order By p.update_date Descending Select p).Take(1)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetDataALL()

            datas = (From p In db.E_TRACKING_BASEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_syswrkunt
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New syswrkunt

        Public Sub insert()
            db.syswrkunts.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.syswrkunts.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.syswrkunts Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_wrknutcd(ByVal wrkuntcd As Integer)

            datas = (From p In db.syswrkunts Where p.wrkuntcd = wrkuntcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.syswrkunts Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRRGT_DTL_TEXT
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_DTL_TEXT
        Private _Details As New List(Of DRRGT_DTL_TEXT)
        Public Property Details() As List(Of DRRGT_DTL_TEXT)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_DTL_TEXT))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_DTL_TEXT
        End Sub
        Public Sub insert()
            db.DRRGT_DTL_TEXTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_DTL_TEXTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_DTL_TEXTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_DTL_TEXTs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FKIDA_MAX(ByVal FK_IDA As Integer)
            datas = (From p In db.DRRGT_DTL_TEXTs Where p.FK_IDA = FK_IDA Order By CInt(p.IDA) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData(ByVal pvncd As Integer, ByVal drgtpcd As String, ByVal rgttpcd As String, ByVal rgtno As Integer)

            datas = (From p In db.DRRGT_DTL_TEXTs Where p.pvncd = pvncd And p.drgtpcd = drgtpcd And p.rgttpcd = rgttpcd And p.rgtno = rgtno Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Function count_repeat(ByVal u1 As String) As Integer
            Dim i As Integer = 0

            datas = (From p In db.DRRGT_DTL_TEXTs Where p.U1_CODE = u1 Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Sub GetDataALL()

            datas = (From p In db.DRRGT_DTL_TEXTs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function count_id(ByVal pvncd As Integer, ByVal drgtpcd As String, ByVal rgttpcd As String, ByVal rgtno As Integer) As Integer
            Dim amount As Integer = 0
            datas = (From p In db.DRRGT_DTL_TEXTs Where p.pvncd = pvncd And p.drgtpcd = drgtpcd And p.rgttpcd = rgttpcd And p.rgtno = rgtno Select p)
            For Each Me.fields In datas
                amount += 1
            Next
            Return amount
        End Function
        Public Function count_fk_ida(ByVal fk_ida As Integer)
            Dim amount As Integer = 0
            datas = (From p In db.DRRGT_DTL_TEXTs Where p.FK_IDA = fk_ida Select p)
            For Each Me.fields In datas
                amount += 1
            Next
            Return amount
        End Function
    End Class
    Public Class TB_DRRQT_DTL_TEXT
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_DTL_TEXT

        Public Sub insert()
            db.DRRQT_DTL_TEXTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_DTL_TEXTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_DTL_TEXTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_DTL_TEXTs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData(ByVal pvncd As Integer, ByVal drgtpcd As String, ByVal rgttpcd As String, ByVal rgtno As Integer)

            datas = (From p In db.DRRQT_DTL_TEXTs Where p.pvncd = pvncd And p.drgtpcd = drgtpcd And p.rgttpcd = rgttpcd And p.rgtno = rgtno Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Function count_repeat(ByVal u1 As String) As Integer
            Dim i As Integer = 0

            datas = (From p In db.DRRQT_DTL_TEXTs Where p.U1_CODE = u1 Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Sub GetDataALL()

            datas = (From p In db.DRRQT_DTL_TEXTs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function count_id(ByVal pvncd As Integer, ByVal drgtpcd As String, ByVal rgttpcd As String, ByVal rgtno As Integer) As Integer
            Dim amount As Integer = 0
            datas = (From p In db.DRRQT_DTL_TEXTs Where p.pvncd = pvncd And p.drgtpcd = drgtpcd And p.rgttpcd = rgttpcd And p.rgtno = rgtno Select p)
            For Each Me.fields In datas
                amount += 1
            Next
            Return amount
        End Function
        Public Function count_fk_ida(ByVal fk_ida As Integer)
            Dim amount As Integer = 0
            datas = (From p In db.DRRQT_DTL_TEXTs Where p.FK_IDA = fk_ida Select p)
            For Each Me.fields In datas
                amount += 1
            Next
            Return amount
        End Function
    End Class
    Public Class TB_MAS_E_TRACKING_GROUP
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_E_TRACKING_GROUP

        Public Sub insert()
            db.MAS_E_TRACKING_GROUPs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_E_TRACKING_GROUPs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_ID_GROUP(ByVal ID_GROUP As Integer)

            datas = (From p In db.MAS_E_TRACKING_GROUPs Where p.ID_GROUP = ID_GROUP Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_E_TRACKING_GROUPs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.MAS_E_TRACKING_GROUPs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_MAS_DRUG_GROUP
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_DRUG_GROUP

        Public Sub insert()
            db.MAS_DRUG_GROUPs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_DRUG_GROUPs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_DRUG_GROUPs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.MAS_DRUG_GROUPs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_DALCN_PRODUCTION_DRUG_TYPE_DETAIL2
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DALCN_PRODUCTION_DRUG_TYPE_DETAIL2

        Public Sub insert()
            db.DALCN_PRODUCTION_DRUG_TYPE_DETAIL2s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_PRODUCTION_DRUG_TYPE_DETAIL2s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_PRODUCTION_DRUG_TYPE_DETAIL2s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_PRODUCTION_DRUG_TYPE_DETAIL2s Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_FKIDA_AND_EDT_ID(ByVal IDA As Integer, ByVal EDT_ID As Integer)

            datas = (From p In db.DALCN_PRODUCTION_DRUG_TYPE_DETAIL2s Where p.LCN_IDA = IDA And p.FK_EDIT_COUNT = EDT_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FKLCN_AND_FK_IDA(ByVal FK_LCN As Integer, ByVal FK_IDA As Integer)

            datas = (From p In db.DALCN_PRODUCTION_DRUG_TYPE_DETAIL2s Where p.FK_IDA = FK_IDA And p.LCN_IDA = FK_LCN Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.DALCN_PRODUCTION_DRUG_TYPE_DETAIL2s Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DALCN_PRODUCTION_DRUG_TYPE_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DALCN_PRODUCTION_DRUG_TYPE_DETAIL

        Public Sub insert()
            db.DALCN_PRODUCTION_DRUG_TYPE_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_PRODUCTION_DRUG_TYPE_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_PRODUCTION_DRUG_TYPE_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FKIDA_AND_EDT_ID(ByVal IDA As Integer, ByVal id_count As Integer)

            datas = (From p In db.DALCN_PRODUCTION_DRUG_TYPE_DETAILs Where p.FK_IDA = IDA And p.FK_EDIT_COUNT = id_count Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_PRODUCTION_DRUG_TYPE_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.DALCN_PRODUCTION_DRUG_TYPE_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_E_TRACKING_STATUS_ADD
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New E_TRACKING_STATUS_ADD

        Public Sub insert()
            db.E_TRACKING_STATUS_ADDs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACKING_STATUS_ADDs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.E_TRACKING_STATUS_ADDs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.E_TRACKING_STATUS_ADDs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.E_TRACKING_STATUS_ADDs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_E_TRACKING_CURRENT_STATUS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New E_TRACKING_CURRENT_STATUS

        Public Sub insert()
            db.E_TRACKING_CURRENT_STATUS.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACKING_CURRENT_STATUS.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_U1(ByVal U1 As String)

            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.NEWCODE = U1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_rcvno_ctzid_rgttpcd(ByVal rcvno As String, ByVal ctzid As String, ByVal rgttpcd As String)

            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.rcvno = rcvno And p.ctzid = ctzid And p.rgttpcd = rgttpcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_rcvno_ctzid_rgttpcd_drgtpcd(ByVal rcvno As String, ByVal ctzid As String, ByVal rgttpcd As String, ByVal drgtpcd As String)

            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.rcvno = rcvno And p.ctzid = ctzid And p.rgttpcd = rgttpcd And p.drgtpcd = drgtpcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_rcvno_rgttpcd_b_type_sub_type(ByVal rcvno As String, ByVal rgttpcd As String, ByVal b_type As Integer, ByVal sub_type As Integer)

            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.rcvno = rcvno And p.rgttpcd = rgttpcd And p.PRODUCT_TYPE = b_type And p.SUB_PRODUCT_TYPE = sub_type Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_rcvno_rgttpcd_b_type_sub_type_v2(ByVal rcvno As String, ByVal rgttpcd As String, ByVal b_type As Integer, ByVal sub_type As Integer, ByVal drgtpcd As String)

            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.rcvno = rcvno And p.rgttpcd = rgttpcd And p.PRODUCT_TYPE = b_type And p.SUB_PRODUCT_TYPE = sub_type And p.drgtpcd = drgtpcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function count_id(ByVal U1 As String) As Boolean
            Dim bool As Boolean = False
            Dim i As Integer = 0
            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.NEWCODE = U1 Select p)
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If
            Return bool
        End Function
        Public Function count_idV2(ByVal rcvno As String, ByVal ctzid As String, ByVal rgttpcd As String) As Boolean
            Dim bool As Boolean = False
            Dim i As Integer = 0
            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.rcvno = rcvno And p.ctzid = ctzid And p.rgttpcd = rgttpcd Select p)
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If
            Return bool
        End Function
        Public Function count_idV3(ByVal rcvno As String, ByVal rgttpcd As String, ByVal b_type As Integer, ByVal sub_type As Integer) As Boolean
            Dim bool As Boolean = False
            Dim i As Integer = 0
            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.rcvno = rcvno And p.rgttpcd = rgttpcd And p.PRODUCT_TYPE = b_type And p.SUB_PRODUCT_TYPE = sub_type Select p)
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If
            Return bool
        End Function
        Public Function count_idV4(ByVal rcvno As String, ByVal ctzid As String, ByVal rgttpcd As String, ByVal drgtpcd As String) As Boolean
            Dim bool As Boolean = False
            Dim i As Integer = 0
            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.rcvno = rcvno And p.ctzid = ctzid And p.rgttpcd = rgttpcd And p.drgtpcd = drgtpcd Select p)
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If
            Return bool
        End Function
        Public Sub GetDataALL()

            datas = (From p In db.E_TRACKING_CURRENT_STATUS Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN3(ByVal rcvno As String, ByVal rgttpcd As String, ByVal b_type As Integer, ByVal sub_type As Integer)
            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.rcvno = rcvno And p.rgttpcd = rgttpcd _
                And p.PRODUCT_TYPE = b_type And p.SUB_PRODUCT_TYPE = sub_type And p.IS_EXTRA_STAGE Is Nothing Order By CInt(p.STATUS_INDEX) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN4(ByVal rcvno As String, ByVal rgttpcd As String, ByVal b_type As Integer, ByVal sub_type As Integer, ByVal drgtpcd As String)
            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.rcvno = rcvno And p.rgttpcd = rgttpcd And p.drgtpcd = drgtpcd _
                And p.PRODUCT_TYPE = b_type And p.SUB_PRODUCT_TYPE = sub_type And p.IS_EXTRA_STAGE Is Nothing Order By CInt(p.STATUS_INDEX) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataCurrent(ByVal rcvno As String, ByVal rgttpcd As String, ByVal b_type As Integer, ByVal sub_type As Integer, ByVal max_id As Integer)
            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.rcvno = rcvno And p.rgttpcd = rgttpcd And p.PRODUCT_TYPE = b_type And p.SUB_PRODUCT_TYPE = sub_type And p.STATUS_INDEX = max_id Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_GEN5(ByVal id_r As Integer)
            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.FK_IDA = id_r Order By CInt(p.STATUS_INDEX) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataCurrentv2(ByVal id_r As Integer, ByVal max_id As Integer)
            datas = (From p In db.E_TRACKING_CURRENT_STATUS Where p.FK_IDA = id_r And p.STATUS_INDEX = max_id Select p)
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_MAS_E_TRACKING_STATUS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_E_TRACKING_STATUS

        Public Sub insert()
            db.MAS_E_TRACKING_STATUS.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_E_TRACKING_STATUS.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_E_TRACKING_STATUS Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_STATUS_ID(ByVal stat As Integer)

            datas = (From p In db.MAS_E_TRACKING_STATUS Where p.STATUS_ID = stat Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_group(ByVal g_stat As Integer)

            datas = (From p In db.MAS_E_TRACKING_STATUS Where p.GROUP_STATUS = g_stat Or p.GROUP_STATUS = 0 Select p Order By p.GROUP_STATUS Descending)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.MAS_E_TRACKING_STATUS Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    '
    Public Class TB_MAS_E_TRACKING_STATUS_NAME
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_E_TRACKING_STATUS_NAME

        Public Sub insert()
            db.MAS_E_TRACKING_STATUS_NAMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_E_TRACKING_STATUS_NAMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_E_TRACKING_STATUS_NAMEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_HEAD_ID(ByVal IDA As Integer)

            datas = (From p In db.MAS_E_TRACKING_STATUS_NAMEs Where p.HEAD_STATUS = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.MAS_E_TRACKING_STATUS_NAMEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_EXPERT_NAME
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_EXPERT_NAME

        Public Sub insert()
            db.MAS_EXPERT_NAMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_EXPERT_NAMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_EXPERT_NAMEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.MAS_EXPERT_NAMEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_ctzno(ByVal ctzid As String)

            datas = (From p In db.MAS_EXPERT_NAMEs Where p.IDENTIFY = ctzid Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_MAS_EXPERT_SKILL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_EXPERT_SKILL

        Public Sub insert()
            db.MAS_EXPERT_SKILLs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_EXPERT_SKILLs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_EXPERT_SKILLs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()
            datas = (From p In db.MAS_EXPERT_SKILLs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_E_TRACKING_EXPERT_SELECTED
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New E_TRACKING_EXPERT_SELECTED

        Public Sub insert()
            db.E_TRACKING_EXPERT_SELECTEDs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACKING_EXPERT_SELECTEDs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.E_TRACKING_EXPERT_SELECTEDs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer, ByVal count_p As Integer, ByVal skill As Integer, ByVal expert As Integer)

            datas = (From p In db.E_TRACKING_EXPERT_SELECTEDs Where p.IDA = FK_IDA And p.COUNT_P = count_p And p.FK_EXPERT_SKILL = p.FK_EXPERT_SKILL And p.FK_EXPERT = expert Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_OTHER_ID(ByVal FK_IDA As Integer, ByVal count_p As Integer, ByVal _result As Integer, ByVal expert As Integer)

            datas = (From p In db.E_TRACKING_EXPERT_SELECTEDs Where p.IDA = FK_IDA And p.COUNT_P = count_p And p.FK_COMMENT = _result And p.FK_EXPERT = expert Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function count_expert(ByVal newcode As String) As Boolean
            Dim i As Integer = 0
            Dim bool As Boolean = False
            datas = (From p In db.E_TRACKING_EXPERT_SELECTEDs Where p.NEWCODE = newcode Select p)
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If

            Return bool
        End Function

        Public Function GetDataby_rcvno_ctzid_rgttpcd(ByVal rcvno As String, ByVal ctzid As String, ByVal rgttpcd As String) As Boolean
            Dim i As Integer = 0
            Dim bool As Boolean = False
            datas = (From p In db.E_TRACKING_EXPERT_SELECTEDs Where p.rcvno = rcvno And p.ctzid = ctzid And p.rgttpcd = rgttpcd Select p)
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If

            Return bool
        End Function
        Public Function GetDataby_rcvno_ctzid_rgttpcd_drgtpcd(ByVal rcvno As String, ByVal ctzid As String, ByVal rgttpcd As String, ByVal drgtpcd As String) As Boolean
            Dim i As Integer = 0
            Dim bool As Boolean = False
            datas = (From p In db.E_TRACKING_EXPERT_SELECTEDs Where p.rcvno = rcvno And p.ctzid = ctzid And p.rgttpcd = rgttpcd And p.drgtpcd = drgtpcd Select p)
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If

            Return bool
        End Function
        Public Sub GetDataALL()
            datas = (From p In db.E_TRACKING_EXPERT_SELECTEDs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_sysstaff
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New sysstaff

        Public Sub insert()
            db.sysstaffs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.sysstaffs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal stfcd As Integer)

            datas = (From p In db.sysstaffs Where p.stfcd = stfcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_ctzid(ByVal ctzid As String)

            datas = (From p In db.sysstaffs Where p.ctzid = ctzid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()
            datas = (From p In db.sysstaffs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_MAS_E_TRACKING_REPORT_PROCESS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_E_TRACKING_REPORT_PROCESS

        Public Sub insert()
            db.MAS_E_TRACKING_REPORT_PROCESSes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_E_TRACKING_REPORT_PROCESSes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.MAS_E_TRACKING_REPORT_PROCESSes Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataALL()
            datas = (From p In db.MAS_E_TRACKING_REPORT_PROCESSes Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_E_TRACKING_WORK_DAY_REPORT_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New E_TRACKING_WORK_DAY_REPORT_DETAIL

        Public Sub insert()
            db.E_TRACKING_WORK_DAY_REPORT_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACKING_WORK_DAY_REPORT_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.E_TRACKING_WORK_DAY_REPORT_DETAILs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal _IDA As Integer)

            datas = (From p In db.E_TRACKING_WORK_DAY_REPORT_DETAILs Where p.FK_IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()
            datas = (From p In db.E_TRACKING_WORK_DAY_REPORT_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    '
    Public Class TB_MAS_E_TRACKING_PERIOD_NAME
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_E_TRACKING_PERIOD_NAME

        Public Sub insert()
            db.MAS_E_TRACKING_PERIOD_NAMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_E_TRACKING_PERIOD_NAMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.MAS_E_TRACKING_PERIOD_NAMEs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataALL()
            datas = (From p In db.MAS_E_TRACKING_PERIOD_NAMEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    '
    Public Class TB_E_TRACKING_WORK_DAY_REPORT
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New E_TRACKING_WORK_DAY_REPORT

        Public Sub insert()
            db.E_TRACKING_WORK_DAY_REPORTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACKING_WORK_DAY_REPORTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.E_TRACKING_WORK_DAY_REPORTs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_rcvno_ctzid(ByVal rcvno As String, ByVal ctzid As String, ByVal ntype As String)

            datas = (From p In db.E_TRACKING_WORK_DAY_REPORTs Where p.RCVNO = rcvno And p.CTZID = ctzid And p.rgttpcd = ntype Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function CHK_Rows(ByVal rcvno As String, ByVal ctzid As String, ByVal ntype As String) As Boolean
            Dim bool As Boolean = False
            datas = (From p In db.E_TRACKING_WORK_DAY_REPORTs Where p.RCVNO = rcvno And p.CTZID = ctzid And p.rgttpcd = ntype Select p)
            Dim i As Integer = 0
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If
            Return bool
        End Function
        Public Sub GetDataALL()
            datas = (From p In db.E_TRACKING_WORK_DAY_REPORTs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRUG_PRODUCT_ID_UNIT_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_PRODUCT_ID_UNIT_DETAIL

        Public Sub insert()
            db.DRUG_PRODUCT_ID_UNIT_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_PRODUCT_ID_UNIT_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.DRUG_PRODUCT_ID_UNIT_DETAILs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataALL()
            datas = (From p In db.DRUG_PRODUCT_ID_UNIT_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRUG_UNIT
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_UNIT

        Public Sub insert()
            db.DRUG_UNITs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_UNITs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.DRUG_UNITs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_sunitcd(ByVal sunidcd As String)

            datas = (From p In db.DRUG_UNITs Where p.sunitcd = sunidcd Select p)
            For Each Me.fields In datas
            Next
        End Sub


        Public Sub GetDataALL()
            datas = (From p In db.DRUG_UNITs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_dcunit
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New dcunit

        Public Sub insert()
            db.dcunits.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.dcunits.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.dcunits Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataALL()
            datas = (From p In db.dcunits Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_drsunit
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New drsunit

        Public Sub insert()
            db.drsunits.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drsunits.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.drsunits Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_sunitcd(ByVal _sunitcd As Integer)

            datas = (From p In db.drsunits Where p.sunitcd = _sunitcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_sunitengnm(ByVal sunitengnm As String)

            datas = (From p In db.drsunits Where p.sunitengnm = sunitengnm Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()
            datas = (From p In db.drsunits Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_E_TRACKING_WORK_DAY_REQUEST_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New E_TRACKING_WORK_DAY_REQUEST_DETAIL

        Public Sub insert()
            db.E_TRACKING_WORK_DAY_REQUEST_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACKING_WORK_DAY_REQUEST_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.E_TRACKING_WORK_DAY_REQUEST_DETAILs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataALL()
            datas = (From p In db.E_TRACKING_WORK_DAY_REQUEST_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_BIO_UNIT
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_BIO_UNIT

        Public Sub insert()
            db.MAS_BIO_UNITs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_BIO_UNITs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.MAS_BIO_UNITs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataALL()
            datas = (From p In db.MAS_BIO_UNITs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_BIO_PACK
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_BIO_PACK

        Public Sub insert()
            db.MAS_BIO_PACKs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_BIO_PACKs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.MAS_BIO_PACKs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataALL()
            datas = (From p In db.MAS_BIO_PACKs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_CHEMICAL_HERB_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New CHEMICAL_HERB_DETAIL

        Public Sub insert()
            db.CHEMICAL_HERB_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CHEMICAL_HERB_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.CHEMICAL_HERB_DETAILs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Request.QueryString("ida")
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.CHEMICAL_HERB_DETAILs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function GetDataby_IDA_HERB(ByVal FK_IDA As Integer, ByVal ida As Integer) As Boolean
            Dim ii As Integer = 0
            Dim bool As Boolean = False
            datas = (From p In db.CHEMICAL_HERB_DETAILs Where p.IDA = ida And p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
                ii += 1
            Next
            If ii > 0 Then
                bool = True
            End If
            Return bool
        End Function
        Public Sub GetDataALL()
            datas = (From p In db.CHEMICAL_HERB_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_HERB_OR_ANIMAL_PART
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_HERB_OR_ANIMAL_PART

        Public Sub insert()
            db.MAS_HERB_OR_ANIMAL_PARTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_HERB_OR_ANIMAL_PARTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.MAS_HERB_OR_ANIMAL_PARTs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TYPE_HEAD(ByVal _g As Integer)
            datas = (From p In db.MAS_HERB_OR_ANIMAL_PARTs Where p.TYPE_PART = _g Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TYPE(ByVal _TYPE As Integer)

            datas = (From p In db.MAS_HERB_OR_ANIMAL_PARTs Where p.TYPE_PART = _TYPE Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()
            datas = (From p In db.MAS_HERB_OR_ANIMAL_PARTs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_HERB_TYPE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_HERB_TYPE

        Public Sub insert()
            db.MAS_HERB_TYPEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_HERB_TYPEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.MAS_HERB_TYPEs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataALL()
            datas = (From p In db.MAS_HERB_TYPEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_BIO_TYPE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_BIO_TYPE

        Public Sub insert()
            db.MAS_BIO_TYPEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_BIO_TYPEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.MAS_BIO_TYPEs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataALL()
            datas = (From p In db.MAS_BIO_TYPEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DALCN_IMPORT_DRUG_GROUP_DETAIL1
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DALCN_IMPORT_DRUG_GROUP_DETAIL1

        Public Sub insert()
            db.DALCN_IMPORT_DRUG_GROUP_DETAIL1s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_IMPORT_DRUG_GROUP_DETAIL1s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_IMPORT_DRUG_GROUP_DETAIL1s Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_IMPORT_DRUG_GROUP_DETAIL1s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.DALCN_IMPORT_DRUG_GROUP_DETAIL1s Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DALCN_IMPORT_DRUG_GROUP_DETAIL2
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DALCN_IMPORT_DRUG_GROUP_DETAIL2

        Public Sub insert()
            db.DALCN_IMPORT_DRUG_GROUP_DETAIL2s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_IMPORT_DRUG_GROUP_DETAIL2s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_FKLCN_AND_FK_IDA(ByVal FK_LCN As Integer, ByVal FK_IDA As Integer)

            datas = (From p In db.DALCN_IMPORT_DRUG_GROUP_DETAIL2s Where p.FK_IDA = FK_IDA And p.LCN_IDA = FK_LCN Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_IMPORT_DRUG_GROUP_DETAIL2s Where p.LCN_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_LCN_IDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_IMPORT_DRUG_GROUP_DETAIL2s Where p.LCN_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function count_drug_group(ByVal FK_LCN_IDA As Integer) As Boolean
            Dim bool As Boolean = False
            Dim i As Integer = 0
            datas = (From p In db.DALCN_IMPORT_DRUG_GROUP_DETAIL2s Where p.LCN_IDA = FK_LCN_IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If
            Return bool
        End Function
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_IMPORT_DRUG_GROUP_DETAIL2s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.DALCN_IMPORT_DRUG_GROUP_DETAIL2s Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_DOCUMENT_RECEIVER
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_DOCUMENT_RECEIVER

        Public Sub insert()
            db.MAS_DOCUMENT_RECEIVERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_DOCUMENT_RECEIVERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.MAS_DOCUMENT_RECEIVERs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataALL()
            datas = (From p In db.MAS_DOCUMENT_RECEIVERs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_LOG_STATUS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New LOG_STATUS

        Public Sub insert()
            db.LOG_STATUS.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LOG_STATUS.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.LOG_STATUS Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataALL()
            datas = (From p In db.LOG_STATUS Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_CHEMICAL_LIST16
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_CHEMICAL_LIST16

        Public Sub insert()
            db.MAS_CHEMICAL_LIST16s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_CHEMICAL_LIST16s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.MAS_CHEMICAL_LIST16s Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataALL()
            datas = (From p In db.MAS_CHEMICAL_LIST16s Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_CHEMICAL_REQUEST_STANDARD_IOWA
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New CHEMICAL_REQUEST_STANDARD_IOWA

        Public Sub insert()
            db.CHEMICAL_REQUEST_STANDARD_IOWAs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CHEMICAL_REQUEST_STANDARD_IOWAs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.CHEMICAL_REQUEST_STANDARD_IOWAs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataALL()
            datas = (From p In db.MAS_CHEMICAL_LIST16s Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DALCN_SELL_TYPE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DALCN_SELL_TYPE

        Public Sub insert()
            db.DALCN_SELL_TYPEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_SELL_TYPEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.DALCN_SELL_TYPEs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA_FK_IDA(ByVal _IDA As Integer, ByVal FK_IDA As Integer)

            datas = (From p In db.DALCN_SELL_TYPEs Where p.SELL_TYPE = _IDA And p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.DALCN_SELL_TYPEs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function count_sell(ByVal FK_LCN_IDA As Integer) As Boolean
            Dim bool As Boolean = False
            Dim i As Integer = 0
            datas = (From p In db.DALCN_SELL_TYPEs Where p.FK_IDA = FK_LCN_IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            If i > 0 Then
                bool = True
            End If
            Return bool
        End Function
        Public Sub GetDataALL()
            datas = (From p In db.DALCN_SELL_TYPEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_MAS_NEWS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_NEW

        Public Sub insert()
            db.MAS_NEWs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_NEWs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal _IDA As Integer)

            datas = (From p In db.MAS_NEWs Where p.IDA = _IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_type(ByVal _type As Integer)
            datas = (From p In db.MAS_NEWs Where p._type = _type Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()
            datas = (From p In db.MAS_NEWs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_ADMIN_BUTTON
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_ADMIN_BUTTON

        Public Sub insert()
            db.MAS_ADMIN_BUTTONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_ADMIN_BUTTONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_ADMIN_BUTTONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_ADMIN_BUTTONs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDgroup(ByVal IDgroup As Integer)

            datas = (From p In db.MAS_ADMIN_BUTTONs Where p.IDgroup = IDgroup Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Btn_Group_and_Admin_group(ByVal IDgroup As Integer, ByVal a_group As Integer)

            datas = (From p In db.MAS_ADMIN_BUTTONs Where p.BTN_GROUP = IDgroup And p.ADMIN_GROUP = a_group Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Btn_Group_and_IdGroup(ByVal BtnGroup As Integer, ByVal idGroup As Integer)

            datas = (From p In db.MAS_ADMIN_BUTTONs Where p.BTN_GROUP = BtnGroup And p.IDgroup = idGroup Select p Order By p.SEQ Ascending)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Btn_Group(ByVal IDgroup As Integer)

            datas = (From p In db.MAS_ADMIN_BUTTONs Where p.BTN_GROUP = IDgroup Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function Check_Page(ByVal url As String, ByVal IDgroup As Integer) As Integer
            'BTN_URL
            Dim i As Integer = 0
            datas = (From p In db.MAS_ADMIN_BUTTONs Where p.BTN_URL.Contains(url) And p.IDgroup = IDgroup Select p)
            For Each Me.fields In datas
                i += 1
            Next

            Return i
        End Function
    End Class
    Public Class TB_MAS_MENU_CHEMI_LABEL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_MENU_CHEMI_LABEL

        Public Sub insert()
            db.MAS_MENU_CHEMI_LABELs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_MENU_CHEMI_LABELs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_MENU_CHEMI_LABELs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_MENU_CHEMI_LABELs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_ID_AND_AORI(ByVal IDA As Integer, ByVal aori As String)
            datas = (From p In db.MAS_MENU_CHEMI_LABELs Where p.LABEL_ID = IDA And p.AORI = aori And p.PROCESS_ID = "20" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_Trade_by_ID(ByVal IDA As Integer)
            datas = (From p In db.MAS_MENU_CHEMI_LABELs Where p.LABEL_ID = IDA And p.PROCESS_ID = "21" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_Bio_by_ID(ByVal IDA As Integer)
            datas = (From p In db.MAS_MENU_CHEMI_LABELs Where p.LABEL_ID = IDA And p.PROCESS_ID = "22" Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_ADMIN_HEADER_LINK
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_ADMIN_HEADER_LINK

        Public Sub insert()
            db.MAS_ADMIN_HEADER_LINKs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_ADMIN_HEADER_LINKs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_ADMIN_HEADER_LINKs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_ADMIN_HEADER_LINKs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDgroup(ByVal IDgroup As Integer)

            datas = (From p In db.MAS_ADMIN_HEADER_LINKs Where p.IDgroup = IDgroup Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function Check_Page(ByVal url As String, ByVal IDgroup As Integer) As Integer
            'BTN_URL
            Dim i As Integer = 0
            datas = (From p In db.MAS_ADMIN_HEADER_LINKs Where p.URL.Contains(url) And p.IDgroup = IDgroup Select p)
            For Each Me.fields In datas
                i += 1
            Next

            Return i
        End Function
    End Class
    Public Class TB_MAS_NAV_ACTIVE_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_NAV_ACTIVE_DETAIL

        Public Sub insert()
            db.MAS_NAV_ACTIVE_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_NAV_ACTIVE_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_NAV_ACTIVE_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_NAV_ACTIVE_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_URL(ByVal URL As String)

            datas = (From p In db.MAS_NAV_ACTIVE_DETAILs Where p.URL = URL Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_URL_AND_IDGROUP(ByVal URL As String, ByVal _group As Integer)

            datas = (From p In db.MAS_NAV_ACTIVE_DETAILs Where p.URL = URL And p.IDgroup = _group Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    '
    Public Class TB_DRSAMP_DETAIL_CAS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRSAMP_DETAIL_CA

        Public Sub insert()
            db.DRSAMP_DETAIL_CAs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRSAMP_DETAIL_CAs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRSAMP_DETAIL_CAs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRSAMP_DETAIL_CAs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_DRSAMP_PACKAGE_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRSAMP_PACKAGE_DETAIL

        Public Sub insert()
            db.DRSAMP_PACKAGE_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRSAMP_PACKAGE_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRSAMP_PACKAGE_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRSAMP_PACKAGE_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRSAMP_PACKAGE_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub


        Public Sub GetData_chk_by_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRSAMP_PACKAGE_DETAILs Where p.FK_IDA = IDA And p.CHECK_PACKAGE = True And p.DRSAMP_IDA Is Nothing Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetData_chk_by_FK_drsamp(ByVal IDA As Integer)

            datas = (From p In db.DRSAMP_PACKAGE_DETAILs Where p.DRSAMP_IDA = IDA And p.CHECK_PACKAGE = True Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_MAS_UNIT_CONTAIN
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_UNIT_CONTAIN
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_UNIT_CONTAINs Where p.unitcd2 = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll()

            datas = (From p In db.MAS_UNIT_CONTAINs Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRUG_REQUEST_CENTER
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_REQUEST_CENTER

        Public Sub insert()
            db.DRUG_REQUEST_CENTERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_REQUEST_CENTERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_REQUEST_CENTERs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REQUEST_CENTERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function Count_R(ByVal r As String) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRUG_REQUEST_CENTERs Where p.RCVNO_DISPLAY = r Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Sub get_data_by_rno(ByVal r_no As String)
            datas = (From p In db.DRUG_REQUEST_CENTERs Where p.RCVNO_DISPLAY = r_no Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    '
    Public Class TB_GEN_RCVNO_REQUEST
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New GEN_RCVNO_REQUEST

        Public Sub insert()
            db.GEN_RCVNO_REQUESTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.GEN_RCVNO_REQUESTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.GEN_RCVNO_REQUESTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.GEN_RCVNO_REQUESTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN3(ByVal YEAR As String, ByVal PVCODE As String, ByVal PROCESS_ID As String)
            datas = (From p In db.GEN_RCVNO_REQUESTs Where p.PVNCD = PVCODE And p.YEARS = YEAR And p.PROCESS_ID = PROCESS_ID Order By CInt(p.GEN_RCV) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN4(ByVal YEAR As String, ByVal PVCODE As String, ByVal PROCESS_ID As String, ByVal gen_type As String)
            datas = (From p In db.GEN_RCVNO_REQUESTs Where p.PVNCD = PVCODE And p.YEARS = YEAR And p.PROCESS_ID = PROCESS_ID And p.GEN_TYPE = gen_type Order By CInt(p.GEN_RCV) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_DRUG_PRODUCT_NAME
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_DRUG_PRODUCT_NAME

        Public Sub insert()
            db.MAS_DRUG_PRODUCT_NAMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_DRUG_PRODUCT_NAMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_DRUG_PRODUCT_NAMEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_DRUG_PRODUCT_NAMEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_E_TRACKING_STOP_TIME
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New E_TRACKING_STOP_TIME

        Public Sub insert()
            db.E_TRACKING_STOP_TIMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACKING_STOP_TIMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.E_TRACKING_STOP_TIMEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.E_TRACKING_STOP_TIMEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function CountDataby_IDA(ByVal FK_IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.E_TRACKING_STOP_TIMEs Where p.FK_IDA = FK_IDA And (p.START_DATE Is Nothing Or p.END_DATE Is Nothing) Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_MAS_DRUG_GROUP_HEAD
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_DRUG_GROUP_HEAD

        Public Sub insert()
            db.MAS_DRUG_GROUP_HEADs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_DRUG_GROUP_HEADs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_DRUG_GROUP_HEADs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_DRUG_GROUP_HEADs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_DRUG_GROUP_HEADs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_E_TRACKING_HEAD_CURRENT_STATUS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New E_TRACKING_HEAD_CURRENT_STATUS

        Public Sub insert()
            db.E_TRACKING_HEAD_CURRENT_STATUS.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACKING_HEAD_CURRENT_STATUS.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.E_TRACKING_HEAD_CURRENT_STATUS Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.E_TRACKING_HEAD_CURRENT_STATUS Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.E_TRACKING_HEAD_CURRENT_STATUS Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_IDA_MAX(ByVal fk_ida As Integer)
            datas = (From p In db.E_TRACKING_HEAD_CURRENT_STATUS Where p.FK_IDA = fk_ida Order By CInt(p.HEAD_STATUS_ID) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub Get_HEAD_STATUS_by_FK_IDA_MAX(ByVal fk_ida As Integer)
            datas = (From p In db.E_TRACKING_HEAD_CURRENT_STATUS Where p.FK_IDA = fk_ida And p.HEAD_STATUS_ID <> 99 Order By CInt(p.HEAD_STATUS_ID) Descending, p.START_DATE Descending, p.END_DATE Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function GetDataby_FK_IDA_AND_STAT(ByVal fk_ida As Integer, ByVal stat_id As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.E_TRACKING_HEAD_CURRENT_STATUS Where p.FK_IDA = fk_ida And p.HEAD_STATUS_ID = stat_id Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    '
    Public Class TB_MAS_HEAD_STATUS_E_TRACKING
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_HEAD_STATUS_E_TRACKING

        Public Sub insert()
            db.MAS_HEAD_STATUS_E_TRACKINGs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_HEAD_STATUS_E_TRACKINGs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_HEAD_STATUS_E_TRACKINGs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub Get_non_Extra()
            datas = (From p In db.MAS_HEAD_STATUS_E_TRACKINGs Where p.PRIORITY_NUMBER = 1 Select p Order By p.STATUS_ROW Ascending)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub Get_Extra()
            datas = (From p In db.MAS_HEAD_STATUS_E_TRACKINGs Where p.PRIORITY_NUMBER = 0 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_HEAD_STATUS_E_TRACKINGs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_STATUS_ROW(ByVal IDA As Integer)
            datas = (From p In db.MAS_HEAD_STATUS_E_TRACKINGs Where p.STATUS_ROW = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRUG_REGISTRATION_PACKAGE_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_REGISTRATION_PACKAGE_DETAIL

        Public Sub insert()
            db.DRUG_REGISTRATION_PACKAGE_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_REGISTRATION_PACKAGE_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_REGISTRATION_PACKAGE_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_PACKAGE_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_PACKAGE_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'GetDataby_FK_IDA2
        Public Sub GetDataby_FK_IDA2(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_PACKAGE_DETAILs Where p.FK_IDA = IDA And p.IM_DETAIL IsNot Nothing Select p)
            'For Each Me.fields In datas
            'Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRUG_REGISTRATION_PACKAGE_DETAILs Where p.FK_IDA = IDA And p.IM_DETAIL IsNot Nothing Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Sub GetData_chk_by_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_PACKAGE_DETAILs Where p.FK_IDA = IDA And p.CHECK_PACKAGE = True Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    '
    Public Class TB_DRUG_REGISTRATION_ATC_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_REGISTRATION_ATC_DETAIL

        Public Sub insert()
            db.DRUG_REGISTRATION_ATC_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_REGISTRATION_ATC_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_REGISTRATION_ATC_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_ATC_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_ATC_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_daphrfunctcd
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New daphrfunctcd

        Public Sub insert()
            db.daphrfunctcds.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.daphrfunctcds.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.daphrfunctcds Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.daphrfunctcds Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_functcd(ByVal functcd As Integer)

            datas = (From p In db.daphrfunctcds Where p.functcd = functcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_CER_EXTEND
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New CER_EXTEND

        Public Sub insert()
            db.CER_EXTENDs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CER_EXTENDs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.CER_EXTENDs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.CER_EXTENDs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_CER_EXTEND_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New CER_EXTEND_DETAIL

        Public Sub insert()
            db.CER_EXTEND_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.CER_EXTEND_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.CER_EXTEND_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_FK_HEAD(ByVal IDA As Integer)

            datas = (From p In db.CER_EXTEND_DETAILs Where p.FK_HEAD = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.CER_EXTEND_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function count_det(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.CER_EXTEND_DETAILs Where p.FK_HEAD = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next

            Return i
        End Function
    End Class
    Public Class TB_LCN_EXTEND_LITE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New LCN_EXTEND_LITE

        Public Sub insert()
            db.LCN_EXTEND_LITEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_EXTEND_LITEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_EXTEND_LITEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.LCN_EXTEND_LITEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)

            datas = (From p In db.LCN_EXTEND_LITEs Where p.TR_ID = TR_ID Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.LCN_EXTEND_LITEs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetDataby_u1_code(ByVal u1 As String)

            datas = (From p In db.LCN_EXTEND_LITEs Where p.U1_CODE = u1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_u1_year(ByVal u1 As String, ByVal _year As Integer)

            datas = (From p In db.LCN_EXTEND_LITEs Where p.U1_CODE = u1 And p.extend_year = _year Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_LCN_EXTEND_LITE_PAY
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New LCN_EXTEND_LITE_PAY

        Public Sub GetDataby_lcntpcd(ByVal lcntpcd As String)

            datas = (From p In db.LCN_EXTEND_LITE_PAYs Where p.lcntpcd = lcntpcd Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    '
    Public Class TB_MAS_LCN_EXTEND_TYPE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_LCN_EXTEND_TYPE

        Public Sub insert()
            db.MAS_LCN_EXTEND_TYPEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_LCN_EXTEND_TYPEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_LCN_EXTEND_TYPEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll2()

            datas = (From p In db.MAS_LCN_EXTEND_TYPEs Where p.active = 1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_LCN_EXTEND_TYPEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_lcntpcd(ByVal lcntpcd As String)

            datas = (From p In db.MAS_LCN_EXTEND_TYPEs Where p.type_lcn = lcntpcd And p.active = 1 Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_process(ByVal process As String)

            datas = (From p In db.MAS_LCN_EXTEND_TYPEs Where p.dalcn_process = process And p.active = 1 Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_MAS_PROFESSIONAL_NAME
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_PROFESSIONAL_NAME

        Public Sub insert()
            db.MAS_PROFESSIONAL_NAMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_PROFESSIONAL_NAMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_PROFESSIONAL_NAMEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_PROFESSIONAL_NAMEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_ctzno(ByVal ctzid As String)

            datas = (From p In db.MAS_PROFESSIONAL_NAMEs Where p.CITIZEN_ID = ctzid Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRUG_REGISTRATION_PROPERTIES
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_REGISTRATION_PROPERTy

        Public Sub insert()
            db.DRUG_REGISTRATION_PROPERTies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_REGISTRATION_PROPERTies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_REGISTRATION_PROPERTies Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_PROPERTies Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRUG_REGISTRATION_DETAIL_CA
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_REGISTRATION_DETAIL_CA

        Public Sub insert()
            db.DRUG_REGISTRATION_DETAIL_CAs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_REGISTRATION_DETAIL_CAs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_REGISTRATION_DETAIL_CAs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_DETAIL_CAs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_DETAIL_CAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.DRUG_REGISTRATION_DETAIL_CAs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Function CountDataby_IDA(ByVal IDA As Integer) As Integer
            Dim a As Integer = 0
            datas = (From p In db.DRUG_REGISTRATION_DETAIL_CAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                a += 1
            Next
            Return a
        End Function
        Function Count_IOWA_NULL_Databy_FK_IDA(ByVal IDA As Integer) As Integer
            Dim a As Integer = 0
            datas = (From p In db.DRUG_REGISTRATION_DETAIL_CAs Where p.FK_IDA = IDA And p.IOWA = "" Select p)
            For Each Me.fields In datas
                a += 1
            Next
            Return a
        End Function
    End Class
    Public Class TB_DRUG_REGISTRATION_PRODUCER
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_REGISTRATION_PRODUCER

        Public Sub insert()
            db.DRUG_REGISTRATION_PRODUCERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_REGISTRATION_PRODUCERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_REGISTRATION_PRODUCERs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_PRODUCERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_PRODUCERs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim a As Integer = 0
            datas = (From p In db.DRUG_REGISTRATION_PRODUCERs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                a += 1
            Next
            Return a
        End Function
    End Class
    Public Class TB_DRRGT_ATC_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_ATC_DETAIL
        Private _Details As New List(Of DRRGT_ATC_DETAIL)
        Public Property Details() As List(Of DRRGT_ATC_DETAIL)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_ATC_DETAIL))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_ATC_DETAIL
        End Sub
        Public Sub insert()
            db.DRRGT_ATC_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_ATC_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_ATC_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_ATC_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_ATC_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRRGT_DETAIL_CAS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_DETAIL_CA
        Private _Details As New List(Of DRRGT_DETAIL_CA)
        Public Property Details() As List(Of DRRGT_DETAIL_CA)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_DETAIL_CA))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_DETAIL_CA
        End Sub
        Public Sub insert()
            db.DRRGT_DETAIL_CAs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_DETAIL_CAs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_DETAIL_CAs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_DETAIL_CAs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA_ORDER(ByVal IDA As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.DRRGT_DETAIL_CAs Where p.IDA = IDA And p.FK_SET = FK_SET Select p Order By p.ROWS Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA_ORDER(ByVal FK_IDA As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.DRRGT_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = FK_SET Select p Order By CInt(p.ROWS) Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_ROWs_AND_FK_SET(ByVal ROWs As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.DRRGT_DETAIL_CAs Where p.FK_SET = FK_SET And p.ROWS = ROWs Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA_AND_ROWs(ByVal IDA As Integer, ByVal ROWs As Integer)

            datas = (From p In db.DRRGT_DETAIL_CAs Where p.IDA = IDA And p.ROWS = ROWs Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)
            datas = (From p In db.DRRGT_DETAIL_CAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Function COUNTDataby_FKIDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRGT_DETAIL_CAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
            Return i
        End Function
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.DRRGT_DETAIL_CAs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.DRRGT_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MIN_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.DRRGT_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Ascending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRRGT_EQTO
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_EQTO
        Private _Details As New List(Of DRRGT_EQTO)
        Public Property Details() As List(Of DRRGT_EQTO)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_EQTO))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_EQTO
        End Sub
        Public Sub insert()
            db.DRRGT_EQTOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_EQTOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_EQTOs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_EQTOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_EQTOs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_DRRQT_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_EQTOs Where p.FK_DRRQT_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.DRRGT_EQTOs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.DRRGT_EQTOs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRRGT_PACKAGE_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_PACKAGE_DETAIL
        Private _Details As New List(Of DRRGT_PACKAGE_DETAIL)
        Public Property Details() As List(Of DRRGT_PACKAGE_DETAIL)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_PACKAGE_DETAIL))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_PACKAGE_DETAIL
        End Sub
        Public Sub insert()
            db.DRRGT_PACKAGE_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_PACKAGE_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_PACKAGE_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PACKAGE_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PACKAGE_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA_V2(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PACKAGE_DETAILs Where p.FK_IDA = IDA And p.order_id Is Nothing Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRRGT_PRODUCER
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_PRODUCER
        Private _Details As New List(Of DRRGT_PRODUCER)
        Public Property Details() As List(Of DRRGT_PRODUCER)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_PRODUCER))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_PRODUCER
        End Sub
        Public Sub insert()
            db.DRRGT_PRODUCERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_PRODUCERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_PRODUCERs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PRODUCERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PRODUCERs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRRGT_PROPERTIES
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_PROPERTy
        Private _Details As New List(Of DRRGT_PROPERTy)
        Public Property Details() As List(Of DRRGT_PROPERTy)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_PROPERTy))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_PROPERTy
        End Sub
        Public Sub insert()
            db.DRRGT_PROPERTies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_PROPERTies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_PROPERTies Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PROPERTies Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PROPERTies Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    '
    Public Class TB_DRRQT_PROPERTIES_AND_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_PROPERTIES_AND_DETAIL

        Public Sub insert()
            db.DRRQT_PROPERTIES_AND_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_PROPERTIES_AND_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRQT_PROPERTIES_AND_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_PROPERTIES_AND_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_PROPERTIES_AND_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.DRRQT_PROPERTIES_AND_DETAILs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRQT_PROPERTIES_AND_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_DRRGT_PRODUCER_OTHER
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_PRODUCER_OTHER

        Public Sub insert()
            db.DRRGT_PRODUCER_OTHERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_PRODUCER_OTHERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_PRODUCER_OTHERs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PRODUCER_OTHERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class

    Public Class TB_DRRQT_PRODUCER_OTHER
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_PRODUCER_OTHER

        Public Sub insert()
            db.DRRQT_PRODUCER_OTHERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_PRODUCER_OTHERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRQT_PRODUCER_OTHERs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_PRODUCER_OTHERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_MAS_ADMIN_GROUP_BUTTON
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_ADMIN_GROUP_BUTTON

        Public Sub insert()
            db.MAS_ADMIN_GROUP_BUTTONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_ADMIN_GROUP_BUTTONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_ADMIN_GROUP_BUTTONs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_By_Group_Order_By_Seq(ByVal _group As Integer)

            datas = (From p In db.MAS_ADMIN_GROUP_BUTTONs Where p.GROUP_USER = _group Select p Order By p.SEQ Ascending)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_ADMIN_GROUP_BUTTONs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DALCN_LOCATION_ADDRESS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DALCN_LOCATION_ADDRESS

        Public Sub insert()
            db.DALCN_LOCATION_ADDRESSes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_LOCATION_ADDRESSes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DALCN_LOCATION_ADDRESSes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_LOCATION_ADDRESSes Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_LOCATION_ADDRESSes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DALCN_LOCATION_BSN
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DALCN_LOCATION_BSN

        Public Sub insert()
            db.DALCN_LOCATION_BSNs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_LOCATION_BSNs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DALCN_LOCATION_BSNs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_LOCATION_BSNs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_LCN_IDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_LOCATION_BSNs Where p.LCN_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Function COUNT_LCN_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DALCN_LOCATION_BSNs Where p.LCN_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Sub Getdata_by_fk_id2(ByVal IDA As Integer)

            datas = (From p In db.DALCN_LOCATION_BSNs Where p.LCN_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdata_by_iden(ByVal iden As String)

            datas = (From p In db.DALCN_LOCATION_BSNs Where p.BSN_IDENTIFY = iden Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_MAS_EXPERT_COMMENT
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_EXPERT_COMMENT

        Public Sub insert()
            db.MAS_EXPERT_COMMENTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_EXPERT_COMMENTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_EXPERT_COMMENTs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_EXPERT_COMMENTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_LCN_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_EXPERT_COMMENTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_LOG_EDIT_MIGRATE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New LOG_EDIT_MIGRATE

        Public Sub insert()
            db.LOG_EDIT_MIGRATEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LOG_EDIT_MIGRATEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LOG_EDIT_MIGRATEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.LOG_EDIT_MIGRATEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_LCN_IDA(ByVal IDA As Integer)

            datas = (From p In db.LOG_EDIT_MIGRATEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_DRUG_REGISTRATION_PROP_AND_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_REGISTRATION_PROP_AND_DETAIL

        Public Sub insert()
            db.DRUG_REGISTRATION_PROP_AND_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_REGISTRATION_PROP_AND_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_REGISTRATION_PROP_AND_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_PROP_AND_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_PROP_AND_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRRGT_PROPERTIES_AND_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_PROPERTIES_AND_DETAIL
        Private _Details As New List(Of DRRGT_PROPERTIES_AND_DETAIL)
        Public Property Details() As List(Of DRRGT_PROPERTIES_AND_DETAIL)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_PROPERTIES_AND_DETAIL))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_PROPERTIES_AND_DETAIL
        End Sub
        Public Sub insert()
            db.DRRGT_PROPERTIES_AND_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_PROPERTIES_AND_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_PROPERTIES_AND_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PROPERTIES_AND_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PROPERTIES_AND_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.DRRGT_PROPERTIES_AND_DETAILs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRGT_PROPERTIES_AND_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_MAS_TABEAN_TEMPLATE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_TABEAN_TEMPLATE

        Public Sub insert()
            db.MAS_TABEAN_TEMPLATEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_TABEAN_TEMPLATEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_TABEAN_TEMPLATEs Select p Order By p.SEQ Ascending)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_TABEAN_TEMPLATEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_drdosage
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New drdosage

        Public Sub insert()
            db.drdosages.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.drdosages.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.drdosages Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.drdosages Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_cd(ByVal cd As Integer)

            datas = (From p In db.drdosages Where p.dsgcd = cd Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    '
    Public Class TB_DRRGT_DRUG_GROUP
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_DRUG_GROUP
        Private _Details As New List(Of DRRGT_DRUG_GROUP)
        Public Property Details() As List(Of DRRGT_DRUG_GROUP)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_DRUG_GROUP))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_DRUG_GROUP
        End Sub
        Public Sub insert()
            db.DRRGT_DRUG_GROUPs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_DRUG_GROUPs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_DRUG_GROUPs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_DRUG_GROUPs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_rgttpcd(ByVal rgttpcd As String)

            datas = (From p In db.DRRGT_DRUG_GROUPs Where p.rgttpcd = rgttpcd Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    '
    Public Class TB_DRRGT_PRODUCER_IN
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_PRODUCER_IN
        Private _Details As New List(Of DRRGT_PRODUCER_IN)
        Public Property Details() As List(Of DRRGT_PRODUCER_IN)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_PRODUCER_IN))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_PRODUCER_IN
        End Sub
        Public Sub insert()
            db.DRRGT_PRODUCER_INs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_PRODUCER_INs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_PRODUCER_INs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PRODUCER_INs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PRODUCER_INs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRRGT_CONDITION
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_CONDITION
        Private _Details As New List(Of DRRGT_CONDITION)
        Public Property Details() As List(Of DRRGT_CONDITION)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_CONDITION))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_CONDITION
        End Sub
        Public Sub insert()
            db.DRRGT_CONDITIONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_CONDITIONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_CONDITIONs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.DRRGT_CONDITIONs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function count_id(ByVal FK_IDA As Integer) As Integer
            Dim amount As Integer = 0
            datas = (From p In db.DRRGT_CONDITIONs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
                amount += 1
            Next
            Return amount
        End Function
    End Class
    '
    Public Class TB_DRRQT_CONDITION
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_CONDITION

        Public Sub insert()
            db.DRRQT_CONDITIONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_CONDITIONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_CONDITIONs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)

            datas = (From p In db.DRRQT_CONDITIONs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function count_id(ByVal FK_IDA As Integer) As Integer
            Dim amount As Integer = 0
            datas = (From p In db.DRRQT_CONDITIONs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
                amount += 1
            Next
            Return amount
        End Function
    End Class
    Public Class TB_DRUG_REGISTRATION_COLOR
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_REGISTRATION_COLOR

        Public Sub insert()
            db.DRUG_REGISTRATION_COLORs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_REGISTRATION_COLORs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_REGISTRATION_COLORs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_COLORs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_COLORs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRUG_REGISTRATION_PRODUCER_IN
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_REGISTRATION_PRODUCER_IN

        Public Sub insert()
            db.DRUG_REGISTRATION_PRODUCER_INs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_REGISTRATION_PRODUCER_INs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_REGISTRATION_PRODUCER_INs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_PRODUCER_INs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_PRODUCER_INs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim a As Integer = 0
            datas = (From p In db.DRUG_REGISTRATION_PRODUCER_INs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                a += 1
            Next
            Return a
        End Function
    End Class
    Public Class TB_DRUG_REGISTRATION_DRUG_USE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_REGISTRATION_DRUG_USE

        Public Sub insert()
            db.DRUG_REGISTRATION_DRUG_USEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_REGISTRATION_DRUG_USEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_REGISTRATION_DRUG_USEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_DRUG_USEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_DRUG_USEs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function count_id(ByVal IDA As Integer) As Integer
            Dim amount As Integer = 0
            datas = (From p In db.DRUG_REGISTRATION_DRUG_USEs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                amount += 1
            Next
            Return amount
        End Function
    End Class
    '
    Public Class TB_DRUG_REGISTRATION_KEEP_DRUG
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_REGISTRATION_KEEP_DRUG

        Public Sub insert()
            db.DRUG_REGISTRATION_KEEP_DRUGs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_REGISTRATION_KEEP_DRUGs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_REGISTRATION_KEEP_DRUGs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_KEEP_DRUGs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRUG_REGISTRATION_KEEP_DRUGs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function count_id(ByVal IDA As Integer) As Integer
            Dim amount As Integer = 0
            datas = (From p In db.DRUG_REGISTRATION_KEEP_DRUGs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                amount += 1
            Next
            Return amount
        End Function
    End Class

    Public Class TB_MAS_DRUG_PACKAGING
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_DRUG_PACKAGING

        Public Sub insert()
            db.MAS_DRUG_PACKAGINGs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_DRUG_PACKAGINGs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_DRUG_PACKAGINGs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_DRUG_PACKAGINGs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_UOP_CODE(ByVal UOP_CODE As String)

            datas = (From p In db.MAS_DRUG_PACKAGINGs Where p.UOP_CODE = UOP_CODE Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRRQT_ATC_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_ATC_DETAIL

        Public Sub insert()
            db.DRRQT_ATC_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_ATC_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRQT_ATC_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_ATC_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_ATC_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRRQT_DETAIL_CAS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_DETAIL_CA

        Public Sub insert()
            db.DRRQT_DETAIL_CAs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_DETAIL_CAs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRQT_DETAIL_CAs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_ROWs_AND_FK_SET(ByVal ROWs As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.DRRQT_DETAIL_CAs Where p.FK_SET = FK_SET And p.ROWS = ROWs Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA_AND_ROWs(ByVal IDA As Integer, ByVal ROWs As Integer)

            datas = (From p In db.DRRQT_DETAIL_CAs Where p.IDA = IDA And p.ROWS = ROWs Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_DETAIL_CAs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA_ORDER(ByVal IDA As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.DRRQT_DETAIL_CAs Where p.IDA = IDA And p.FK_SET = FK_SET Select p Order By p.ROWS Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA_ORDER(ByVal FK_IDA As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.DRRQT_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = FK_SET Select p Order By p.ROWS Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_DETAIL_CAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.DRRQT_DETAIL_CAs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.DRRQT_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MIN_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.DRRQT_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Ascending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRRQT_EQTO
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_EQTO

        Public Sub insert()
            db.DRRQT_EQTOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_EQTOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRQT_EQTOs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_EQTOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_EQTOs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_DRRQT_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_EQTOs Where p.FK_DRRQT_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.DRRQT_EQTOs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.DRRQT_EQTOs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRRQT_PACKAGE_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_PACKAGE_DETAIL

        Public Sub insert()
            db.DRRQT_PACKAGE_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_PACKAGE_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRQT_PACKAGE_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_PACKAGE_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_PACKAGE_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRRQT_PRODUCER
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_PRODUCER

        Public Sub insert()
            db.DRRQT_PRODUCERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_PRODUCERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRQT_PRODUCERs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_PRODUCERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_PRODUCERs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRRQT_PRODUCER_IN
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_PRODUCER_IN

        Public Sub insert()
            db.DRRQT_PRODUCER_INs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_PRODUCER_INs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRQT_PRODUCER_INs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_PRODUCER_INs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_PRODUCER_INs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRRQT_PROPERTIES
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_PROPERTy

        Public Sub insert()
            db.DRRQT_PROPERTies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_PROPERTies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRQT_PROPERTies Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_PROPERTies Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_PROPERTies Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRRGT_DRUG_PER_UNIT
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_DRUG_PER_UNIT

        Public Sub insert()
            db.DRRGT_DRUG_PER_UNITs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_DRUG_PER_UNITs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_DRUG_PER_UNITs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_DRUG_PER_UNITs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_DRUG_PER_UNITs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function COUNT_ROW(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRGT_DRUG_PER_UNITs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_DRRQT_DRUG_PER_UNIT
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_DRUG_PER_UNIT

        Public Sub insert()
            db.DRRQT_DRUG_PER_UNITs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_DRUG_PER_UNITs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRQT_DRUG_PER_UNITs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_DRUG_PER_UNITs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_DRUG_PER_UNITs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function COUNT_ROW(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRGT_DRUG_PER_UNITs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class

    Public Class TB_DRRQT_DTB
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_DTB

        Public Sub insert()
            db.DRRQT_DTBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_DTBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRQT_DTBs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_DTBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_DTBs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRRGT_DTB
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_DTB
        Private _Details As New List(Of DRRGT_DTB)
        Public Property Details() As List(Of DRRGT_DTB)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_DTB))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_DTB
        End Sub
        Public Sub insert()
            db.DRRGT_DTBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_DTBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_DTBs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_DTBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_DTBs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRRGT_NAME_DRUG_EXPORT
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_NAME_DRUG_EXPORT

        Public Sub insert()
            db.DRRGT_NAME_DRUG_EXPORTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_NAME_DRUG_EXPORTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_NAME_DRUG_EXPORTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_NAME_DRUG_EXPORTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_NAME_DRUG_EXPORTs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataMAX(ByVal FK_IDA As Integer)
            datas = (From p In db.DRRGT_NAME_DRUG_EXPORTs Where p.FK_IDA = FK_IDA Order By CInt(p.SEQ) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRRQT_NAME_DRUG_EXPORT
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_NAME_DRUG_EXPORT

        Public Sub insert()
            db.DRRQT_NAME_DRUG_EXPORTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_NAME_DRUG_EXPORTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRQT_NAME_DRUG_EXPORTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_NAME_DRUG_EXPORTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_NAME_DRUG_EXPORTs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataMAX(ByVal FK_IDA As Integer)
            datas = (From p In db.DRRQT_NAME_DRUG_EXPORTs Where p.FK_IDA = FK_IDA Order By CInt(p.SEQ) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRRQT_KEEP_DRUG
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_KEEP_DRUG

        Public Sub insert()
            db.DRRQT_KEEP_DRUGs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_KEEP_DRUGs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRQT_KEEP_DRUGs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_KEEP_DRUGs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_KEEP_DRUGs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        'Public Sub GetDataMAX(ByVal FK_IDA As Integer)
        '    datas = (From p In db.DRRQT_NAME_DRUG_EXPORTs Where p.FK_IDA = FK_IDA Order By CInt(p.SEQ) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
    End Class
    Public Class TB_DRRGT_KEEP_DRUG
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_KEEP_DRUG
        Private _Details As New List(Of DRRGT_KEEP_DRUG)
        Public Property Details() As List(Of DRRGT_KEEP_DRUG)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_KEEP_DRUG))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_KEEP_DRUG
        End Sub
        Public Sub insert()
            db.DRRGT_KEEP_DRUGs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_KEEP_DRUGs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_KEEP_DRUGs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_KEEP_DRUGs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_KEEP_DRUGs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function COUNTDataby_FKIDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRGT_KEEP_DRUGs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        'Public Sub GetDataMAX(ByVal FK_IDA As Integer)
        '    datas = (From p In db.DRRQT_NAME_DRUG_EXPORTs Where p.FK_IDA = FK_IDA Order By CInt(p.SEQ) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
    End Class
    Public Class TB_DRRGT_REFER
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_REFER

        Public Sub insert()
            db.DRRGT_REFERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_REFERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_REFERs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_REFERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_REFERs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FKIDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRGT_REFERs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_DRRQT_REFER
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New DRRQT_REFER
        Public Sub insert()
            db.DRRQT_REFERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DRRQT_REFERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRRQT_REFERs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRQT_REFERs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)
            datas = (From p In db.DRRQT_REFERs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FKIDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRQT_REFERs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_dramlsubtp
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New dramlsubtp
        Public Sub insert()
            db.dramlsubtps.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.dramlsubtps.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.dramlsubtps Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_amltpcd(ByVal cd As Integer)
            datas = (From p In db.dramlsubtps Where p.amltpcd = cd Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_amlsubnm(ByVal amlsubnm As String)
            datas = (From p In db.dramlsubtps Where p.amlsubnm = amlsubnm Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    '
    Public Class TB_dramltype
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New dramltype
        Public Sub insert()
            db.dramltypes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.dramltypes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.dramltypes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_cd(ByVal cd As Integer)
            datas = (From p In db.dramltypes Where p.amltpcd = cd Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_amltpnm(ByVal amltpnm As String)
            datas = (From p In db.dramltypes Where p.amltpnm = amltpnm Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    'ddl_dramlusetp
    Public Class TB_dramlusetp
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New dramlusetp
        Public Sub insert()
            db.dramlusetps.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.dramlusetps.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.dramlusetps Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_cd(ByVal cd As Integer)
            datas = (From p In db.dramlusetps Where p.catbcd = cd Select p)
            For Each Me.fields In datas

            Next
        End Sub
        '
        Public Sub GetDataby_usetpnm(ByVal usetpnm As String)
            datas = (From p In db.dramlusetps Where p.usetpnm = usetpnm Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    '
    Public Class TB_dramlpart
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New dramlpart
        Public Sub insert()
            db.dramlparts.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.dramlparts.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.dramlparts Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_cd(ByVal cd As Integer)
            datas = (From p In db.dramlparts Where p.ampartcd = cd Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_ampartnm(ByVal ampartnm As String)
            datas = (From p In db.dramlparts Where p.ampartnm = ampartnm Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_MAS_NOTICE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New MAS_NOTICE
        Public Sub insert()
            db.MAS_NOTICEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.MAS_NOTICEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.MAS_NOTICEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_SYSTEM_ID(ByVal SYSTEM_ID As Integer)
            datas = (From p In db.MAS_NOTICEs Where p.SYSTEM_ID = SYSTEM_ID Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_REGIST_FILE_ATTACH
        Inherits MAINCONTEXT

        Public fields As New REGIST_FILE_ATTACH

        Private _Details As New List(Of REGIST_FILE_ATTACH)
        Public Property Details() As List(Of REGIST_FILE_ATTACH)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of REGIST_FILE_ATTACH))
                _Details = value
            End Set
        End Property
        Public Sub insert()
            db.REGIST_FILE_ATTACHes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.REGIST_FILE_ATTACHes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.REGIST_FILE_ATTACHes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.REGIST_FILE_ATTACHes Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)

            datas = (From p In db.REGIST_FILE_ATTACHes Where p.TRANSACTION_ID = TR_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID_type(ByVal TR_ID As Integer, ByVal type As Integer)

            datas = (From p In db.REGIST_FILE_ATTACHes Where p.TRANSACTION_ID = TR_ID And p.TYPE = type Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID_And_Process(ByVal TR_ID As Integer, ByVal process As String)

            datas = (From p In db.REGIST_FILE_ATTACHes Where p.TRANSACTION_ID = TR_ID And p.PROCESS_ID = process Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID_And_Process_And_Type(ByVal TR_ID As Integer, ByVal process As String, ByVal _type As String)

            datas = (From p In db.REGIST_FILE_ATTACHes Where p.TRANSACTION_ID = TR_ID And p.PROCESS_ID = process And p.TYPE = _type Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetMAXby_TR_ID_And_Process(ByVal TR_ID As Integer, ByVal process As String)
            datas = (From p In db.REGIST_FILE_ATTACHes Where p.TRANSACTION_ID = TR_ID And p.PROCESS_ID = process Order By CInt(p.TYPE) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DALCN_PHR_CANCEL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New DALCN_PHR_CANCEL
        Public Sub insert()
            db.DALCN_PHR_CANCELs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DALCN_PHR_CANCELs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DALCN_PHR_CANCELs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DALCN_PHR_CANCELs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)
            datas = (From p In db.DALCN_PHR_CANCELs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FKIDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DALCN_PHR_CANCELs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_DALCN_PHR_CANCEL_DETAIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New DALCN_PHR_CANCEL_DETAIL
        Public Sub insert()
            db.DALCN_PHR_CANCEL_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DALCN_PHR_CANCEL_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DALCN_PHR_CANCEL_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DALCN_PHR_CANCEL_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)
            datas = (From p In db.DALCN_PHR_CANCEL_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FKIDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DALCN_PHR_CANCEL_DETAILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class

    Public Class TB_MAS_TYPE_REQUEST_AMOUNT
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New MAS_TYPE_REQUEST_AMOUNT
        Public Sub insert()
            db.MAS_TYPE_REQUEST_AMOUNTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.MAS_TYPE_REQUEST_AMOUNTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.MAS_TYPE_REQUEST_AMOUNTs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_TYPE_REQUEST_AMOUNTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TYPE_REQUESTS_ID(ByVal TYPE_REQUESTS_ID As Integer)
            datas = (From p In db.MAS_TYPE_REQUEST_AMOUNTs Where p.TYPE_REQUESTS_ID = TYPE_REQUESTS_ID And p.IS_ACTIVE = True Select p)
            For Each Me.fields In datas

            Next
        End Sub
       
    End Class
    Public Class TB_DRUG_REGISTRATION_EQTO
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New DRUG_REGISTRATION_EQTO
        Public Sub insert()
            db.DRUG_REGISTRATION_EQTOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DRUG_REGISTRATION_EQTOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRUG_REGISTRATION_EQTOs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRUG_REGISTRATION_EQTOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRUG_REGISTRATION_EQTOs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function COUNTDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRUG_REGISTRATION_EQTOs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.DRUG_REGISTRATION_EQTOs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRUG_REGISTRATION_EACH
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New DRUG_REGISTRATION_EACH
        Public Sub insert()
            db.DRUG_REGISTRATION_EACHes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DRUG_REGISTRATION_EACHes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRUG_REGISTRATION_EACHes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRUG_REGISTRATION_EACHes Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRUG_REGISTRATION_EACHes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRUG_REGISTRATION_EACHes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_E_TRACKING_LOG
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New E_TRACKING_LOG
        Public Sub insert()
            db.E_TRACKING_LOGs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.E_TRACKING_LOGs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.E_TRACKING_LOGs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.E_TRACKING_LOGs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.E_TRACKING_LOGs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        
    End Class
    Public Class TB_DRRQT_COLOR
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New DRRQT_COLOR
        Public Sub insert()
            db.DRRQT_COLORs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DRRQT_COLORs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRRQT_COLORs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRQT_COLORs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRQT_COLORs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_DRRGT_COLOR
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New DRRGT_COLOR

        Private _Details As New List(Of DRRGT_COLOR)
        Public Property Details() As List(Of DRRGT_COLOR)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_COLOR))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_COLOR
        End Sub
        Public Sub insert()
            db.DRRGT_COLORs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DRRGT_COLORs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRRGT_COLORs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRGT_COLORs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRGT_COLORs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_DRRGT_EACH
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New DRRGT_EACH
        Private _Details As New List(Of DRRGT_EACH)
        Public Property Details() As List(Of DRRGT_EACH)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_EACH))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New DRRGT_EACH
        End Sub
        Public Sub insert()
            db.DRRGT_EACHes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DRRGT_EACHes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRRGT_EACHes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRGT_EACHes Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRGT_EACHes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA_AND_SET(ByVal IDA As Integer, ByVal SET_ As Integer)
            datas = (From p In db.DRRGT_EACHes Where p.FK_IDA = IDA And p.FK_SET = SET_ Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRGT_EACHes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_DRRQT_EACH
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New DRRQT_EACH
        Public Sub insert()
            db.DRRQT_EACHes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DRRQT_EACHes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRRQT_EACHes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRQT_EACHes Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRQT_EACHes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA_AND_SET(ByVal IDA As Integer, ByVal SET_ As Integer)
            datas = (From p In db.DRRQT_EACHes Where p.FK_IDA = IDA And p.FK_SET = SET_ Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRQT_EACHes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_DRRQT_NO_USE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New DRRQT_NO_USE
        Public Sub insert()
            db.DRRQT_NO_USEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DRRQT_NO_USEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRRQT_NO_USEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRQT_NO_USEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRQT_NO_USEs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRQT_NO_USEs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_DRRGT_NO_USE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New DRRGT_NO_USE
        Public Sub insert()
            db.DRRGT_NO_USEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DRRGT_NO_USEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRRGT_NO_USEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRGT_NO_USEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRGT_NO_USEs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRGT_NO_USEs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_DRUG_REGISTRATION_ANIMAL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_REGISTRATION_ANIMAL

        Public Sub insert()
            db.DRUG_REGISTRATION_ANIMALs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_REGISTRATION_ANIMALs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_REGISTRATION_ANIMALs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_ANIMALs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_ANIMALs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRUG_REGISTRATION_ANIMAL_SUB
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRUG_REGISTRATION_ANIMAL_SUB

        Public Sub insert()
            db.DRUG_REGISTRATION_ANIMAL_SUBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRUG_REGISTRATION_ANIMAL_SUBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRUG_REGISTRATION_ANIMAL_SUBs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDatabyIDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_ANIMAL_SUBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRUG_REGISTRATION_ANIMAL_SUBs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRRGT_EDIT_REQUEST
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_EDIT_REQUEST

        Public Sub insert()
            db.DRRGT_EDIT_REQUESTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_EDIT_REQUESTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_EDIT_REQUESTs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDatabyIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_EDIT_REQUESTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function GetDatabyrcvno(ByVal rcvno As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRGT_EDIT_REQUESTs Where p.rcvno = rcvno Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        Public Sub GetDatabyTRID(ByVal TRID As Integer)

            datas = (From p In db.DRRGT_EDIT_REQUESTs Where p.TR_ID = TRID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDatabyTRID_PROCESS(ByVal TRID As Integer, ByVal PROCESS_ID As String)

            datas = (From p In db.DRRGT_EDIT_REQUESTs Where p.TR_ID = TRID And p.PROCESS_ID = PROCESS_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_EDIT_REQUESTs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRRGT_EDIT_INDEX
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_EDIT_INDEX

        Public Sub insert()
            db.DRRGT_EDIT_INDEXes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_EDIT_INDEXes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_EDIT_INDEXes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDatabyIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_EDIT_INDEXes Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_EDIT_INDEXes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_NO(ByVal table_name As String, ByVal FK_IDA As Integer)
            datas = (From p In db.DRRGT_EDIT_INDEXes Where p.FK_IDA = FK_IDA And p.TABLE_NAME = table_name Order By CInt(p.COUNT_EDIT) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_MAX_DATE(ByVal FK_IDA As Integer)
            datas = (From p In db.DRRGT_EDIT_INDEXes Where p.FK_IDA = FK_IDA Order By p.CREATE_DATE Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_DRRGT_LABEL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_LABEL

        Public Sub insert()
            db.DRRGT_LABELs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_LABELs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_LABELs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDatabyIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_LABELs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_LABELs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GET_MAX_NO(ByVal table_name As String, ByVal FK_IDA As Integer)
        '    datas = (From p In db.DRRGT_LABELs Where p.FK_IDA = FK_IDA Order By CInt(p.COUNT_EDIT) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
    End Class

    Public Class TB_DRRQT_LABEL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRQT_LABEL

        Public Sub insert()
            db.DRRQT_LABELs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRQT_LABELs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRQT_LABELs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDatabyIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_LABELs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRQT_LABELs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GET_MAX_NO(ByVal table_name As String, ByVal FK_IDA As Integer)
        '    datas = (From p In db.DRRGT_LABELs Where p.FK_IDA = FK_IDA Order By CInt(p.COUNT_EDIT) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
    End Class
    Public Class TB_DRRGT_EDIT_REQUEST_COLOR
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New DRRGT_EDIT_REQUEST_COLOR
        Public Sub insert()
            db.DRRGT_EDIT_REQUEST_COLORs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DRRGT_EDIT_REQUEST_COLORs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRRGT_EDIT_REQUEST_COLORs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRGT_EDIT_REQUEST_COLORs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRGT_EDIT_REQUEST_COLORs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_DRRGT_EDIT_REQUEST_CA
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New DRRGT_EDIT_REQUEST_CA
        Public Sub insert()
            db.DRRGT_EDIT_REQUEST_CAs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DRRGT_EDIT_REQUEST_CAs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRRGT_EDIT_REQUEST_CAs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRGT_EDIT_REQUEST_CAs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.DRRGT_EDIT_REQUEST_CAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GET_MAX_ROW(ByVal fk_ida As Integer)
            datas = (From p In db.DRRGT_EDIT_REQUEST_CAs Where p.FK_IDA = fk_ida Order By CInt(p.IDA) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_driowa
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New driowa
        Public Sub insert()
            db.driowas.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.driowas.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.driowas Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.driowas Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_iowa(ByVal iowacd As String)
            datas = (From p In db.driowas Where p.iowacd = iowacd Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_iowa(ByVal iowacd As String) As Integer
            Dim i As Integer = 0
            datas = (From p In db.driowas Where p.iowacd = iowacd Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class clsDBXML_NAME
        Inherits MAINCONTEXT
        Public fields As New XML_NAME
        Public Sub insert()
            db.XML_NAMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_NAMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_NAMEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_PROCESS(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer)
            datas = (From p In db.XML_NAMEs Where p.TR_ID = TR_ID And p.PROCESS_ID = PROCESS_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRRGT_APPOINTMENT
        Inherits MAINCONTEXT
        Public fields As New DRRGT_APPOINTMENT
        Public Sub insert()
            db.DRRGT_APPOINTMENTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DRRGT_APPOINTMENTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRRGT_APPOINTMENTs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataByIDA(ByVal IDA As Integer)
            datas = (From p In db.DRRGT_APPOINTMENTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataByFK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.DRRGT_APPOINTMENTs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal FK_IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRGT_APPOINTMENTs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_DRRQT_APPOINTMENT
        Inherits MAINCONTEXT
        Public fields As New DRRQT_APPOINTMENT
        Public Sub insert()
            db.DRRQT_APPOINTMENTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DRRQT_APPOINTMENTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRRQT_APPOINTMENTs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataByIDA(ByVal IDA As Integer)
            datas = (From p In db.DRRQT_APPOINTMENTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataByFK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.DRRQT_APPOINTMENTs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal FK_IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRQT_APPOINTMENTs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_DRRGT_EDIT_REQUEST_PACKAGE_DETAIL
        Inherits MAINCONTEXT
        Public fields As New DRRGT_EDIT_REQUEST_PACKAGE_DETAIL
        Public Sub insert()
            db.DRRGT_EDIT_REQUEST_PACKAGE_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.DRRGT_EDIT_REQUEST_PACKAGE_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.DRRGT_EDIT_REQUEST_PACKAGE_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataByIDA(ByVal IDA As Integer)
            datas = (From p In db.DRRGT_EDIT_REQUEST_PACKAGE_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataByFK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.DRRGT_EDIT_REQUEST_PACKAGE_DETAILs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        
    End Class

    Public Class TB_drclass
        Inherits MAINCONTEXT
        Public fields As New drclass
        Public Sub insert()
            db.drclasses.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.drclasses.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.drclasses Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataBycd(ByVal cd As String)
            datas = (From p In db.drclasses Where p.classcd = cd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataBytha(ByVal thaa As String)
            datas = (From p In db.drclasses Where p.thaclassnm = thaa Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataByeng(ByVal engg As String)
            datas = (From p In db.drclasses Where p.engclassnm = engg Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_DRUG_SHAPE
        Inherits MAINCONTEXT
        Public fields As New MAS_DRUG_SHAPE
        Public Sub insert()
            db.MAS_DRUG_SHAPEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.MAS_DRUG_SHAPEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.MAS_DRUG_SHAPEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataByIDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_DRUG_SHAPEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_DRRGT_SUBSTITUTE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_SUBSTITUTE

        Public Sub insert()
            db.DRRGT_SUBSTITUTEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_SUBSTITUTEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_SUBSTITUTEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDatabyIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_SUBSTITUTEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_SUBSTITUTEs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_STAFF_POSITION
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_STAFF_POSITION

        Public Sub insert()
            db.MAS_STAFF_POSITIONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_STAFF_POSITIONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_STAFF_POSITIONs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDatabyIDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_STAFF_POSITIONs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class TB_MAS_SUBSTITUTE_TEMPLATE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_SUBSTITUTE_TEMPLATE

        Public Sub insert()
            db.MAS_SUBSTITUTE_TEMPLATEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_SUBSTITUTE_TEMPLATEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_SUBSTITUTE_TEMPLATEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_ROWS_ID(ByVal IDA As Integer)

            datas = (From p In db.MAS_SUBSTITUTE_TEMPLATEs Where p.ROWS = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_DRRGT_SPC
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_SPC
        Private _Details As New List(Of DRRGT_SPC)
        Public Property Details() As List(Of DRRGT_SPC)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of DRRGT_SPC))
                _Details = value
            End Set
        End Property
        Public Sub insert()
            db.DRRGT_SPCs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_SPCs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_SPCs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_SPCs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_SPCs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_DRRGT_PI
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_PI

        Public Sub insert()
            db.DRRGT_PIs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_PIs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_PIs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PIs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PIs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DRRGT_PIL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_PIL

        Public Sub insert()
            db.DRRGT_PILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_PILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DRRGT_PILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_PILs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    '
    Public Class TB_LOG_EDIT_TABEAN
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New LOG_EDIT_TABEAN

        Public Sub insert()
            db.LOG_EDIT_TABEANs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LOG_EDIT_TABEANs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LOG_EDIT_TABEANs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.LOG_EDIT_TABEANs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_DRRGT_EDIT_APPOINTMENT
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New DRRGT_EDIT_APPOINTMENT

        Public Sub insert()
            db.DRRGT_EDIT_APPOINTMENTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DRRGT_EDIT_APPOINTMENTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LOG_EDIT_TABEANs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_EDIT_APPOINTMENTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.DRRGT_EDIT_APPOINTMENTs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal FK_IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.DRRGT_EDIT_APPOINTMENTs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_LOG_A_ERRORS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New LOG_A_ERROR

        Public Sub insert()
            db.LOG_A_ERRORs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LOG_A_ERRORs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LOG_A_ERRORs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.LOG_A_ERRORs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.LOG_A_ERRORs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal FK_IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.LOG_A_ERRORs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_case1411
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New case1411_

        Public Sub insert()
            db.case1411_s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.case1411_s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.case1411_s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)

            datas = (From p In db.case1411_s Where p.IDA = Trim(IDA) Select p)
            For Each Me.fields In datas
            Next
        End Sub
       
    End Class

    Public Class TB_15_TAMRAP_ATC
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New _15_TAMRAP_ATC

        Public Sub insert()
            db._15_TAMRAP_ATCs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db._15_TAMRAP_ATCs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db._15_TAMRAP_ATCs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)

            datas = (From p In db._15_TAMRAP_ATCs Where p.IDA = Trim(IDA) Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TAMRAP_ID(ByVal TAMRAP_ID As Integer)

            datas = (From p In db._15_TAMRAP_ATCs Where p.TAMRAP_ID = TAMRAP_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_15_TAMRAP_DTL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New _15_TAMRAP_DTL

        Public Sub insert()
            db._15_TAMRAP_DTLs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db._15_TAMRAP_DTLs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db._15_TAMRAP_DTLs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)

            datas = (From p In db._15_TAMRAP_DTLs Where p.IDA = Trim(IDA) Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TAMRAP_ID(ByVal TAMRAP_ID As Integer)

            datas = (From p In db._15_TAMRAP_DTLs Where p.TAMRAP_ID = TAMRAP_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_15_TAMRAP_EACH
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New _15_TAMRAP_EACH

        Public Sub insert()
            db._15_TAMRAP_EACHes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db._15_TAMRAP_EACHes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db._15_TAMRAP_EACHes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)

            datas = (From p In db._15_TAMRAP_EACHes Where p.IDA = Trim(IDA) Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TAMRAP_ID(ByVal TAMRAP_ID As Integer)

            datas = (From p In db._15_TAMRAP_EACHes Where p.TAMRAP_ID = TAMRAP_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_15_TAMRAP_GENERAL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New _15_TAMRAP_GENERAL

        Public Sub insert()
            db._15_TAMRAP_GENERALs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db._15_TAMRAP_GENERALs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db._15_TAMRAP_GENERALs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)

            datas = (From p In db._15_TAMRAP_GENERALs Where p.IDA = Trim(IDA) Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TAMRAP_ID(ByVal TAMRAP_ID As Integer)

            datas = (From p In db._15_TAMRAP_GENERALs Where p.TAMRAP_ID = TAMRAP_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_15_TAMRAP_TEMPLATE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New _15_TAMRAP_TEMPLATE

        Public Sub insert()
            db._15_TAMRAP_TEMPLATEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db._15_TAMRAP_TEMPLATEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db._15_TAMRAP_TEMPLATEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)

            datas = (From p In db._15_TAMRAP_TEMPLATEs Where p.IDA = Trim(IDA) Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TAMRAP_ID(ByVal TAMRAP_ID As Integer)

            datas = (From p In db._15_TAMRAP_TEMPLATEs Where p.TAMRAP_ID = TAMRAP_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_MAS_TAMRAP_NAME
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_TAMRAP_NAME

        Public Sub insert()
            db.MAS_TAMRAP_NAMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_TAMRAP_NAMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_TAMRAP_NAMEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataAll_AUTO()

            datas = (From p In db.MAS_TAMRAP_NAMEs Where p.AUTO_GROUP = 1 And p.IS_AUTO = 1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataByGROUP(ByVal _group As Integer)

            datas = (From p In db.MAS_TAMRAP_NAMEs Where p.IS_AUTO = _group Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataByGROUPAuto(ByVal _group As Integer, ByVal auto_id As Integer)

            datas = (From p In db.MAS_TAMRAP_NAMEs Where p.IS_AUTO = _group And p.AUTO_GROUP = auto_id Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)

            datas = (From p In db.MAS_TAMRAP_NAMEs Where p.IDA = Trim(IDA) Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TAMRAP_ID(ByVal TAMRAP_ID As Integer)

            datas = (From p In db.MAS_TAMRAP_NAMEs Where p.TAMRAP_ID = TAMRAP_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_15_TAMRAP_PACKSIZE
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New _15_TAMRAP_PACKSIZE

        Public Sub insert()
            db._15_TAMRAP_PACKSIZEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db._15_TAMRAP_PACKSIZEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db._15_TAMRAP_PACKSIZEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)

            datas = (From p In db._15_TAMRAP_PACKSIZEs Where p.IDA = Trim(IDA) Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TAMRAP_ID(ByVal TAMRAP_ID As Integer)

            datas = (From p In db._15_TAMRAP_PACKSIZEs Where p.TAMRAP_ID = TAMRAP_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_LOG_MULTITAB
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New LOG_MULTITAB

        Public Sub insert()
            db.LOG_MULTITABs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LOG_MULTITABs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LOG_MULTITABs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.LOG_MULTITABs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.LOG_MULTITABs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal FK_IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.LOG_MULTITABs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class

    Public Class TB_15_TAMRAP_EQTO
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New _15_TAMRAP_EQTO

        Public Sub insert()
            db._15_TAMRAP_EQTOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db._15_TAMRAP_EQTOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db._15_TAMRAP_EQTOs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)

            datas = (From p In db._15_TAMRAP_EQTOs Where p.IDA = Trim(IDA) Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer, ByVal FK_SET As Integer)
            datas = (From p In db._15_TAMRAP_EQTOs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_TAMRAP_ID_IOWA(ByVal TAMRAP_ID As Integer, ByVal IOWA As String)
            datas = (From p In db._15_TAMRAP_EQTOs Where p.TAMRAP_ID = TAMRAP_ID And p.IOWA = IOWA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class

    Public Class TB_E_TRACKING_STATUS_RQT_ALL
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New E_TRACKING_STATUS_RQT_ALL

        Public Sub insert()
            db.E_TRACKING_STATUS_RQT_ALLs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACKING_STATUS_RQT_ALLs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.E_TRACKING_STATUS_RQT_ALLs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)

            datas = (From p In db.E_TRACKING_STATUS_RQT_ALLs Where p.IDA = Trim(IDA) Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer, ByVal FK_SET As Integer)
            datas = (From p In db.E_TRACKING_STATUS_RQT_ALLs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_E_TRACKING_RQT_STOP_TIME
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New E_TRACKING_RQT_STOP_TIME

        Public Sub insert()
            db.E_TRACKING_RQT_STOP_TIMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACKING_RQT_STOP_TIMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.E_TRACKING_RQT_STOP_TIMEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)

            datas = (From p In db.E_TRACKING_RQT_STOP_TIMEs Where p.IDA = Trim(IDA) Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer, ByVal FK_SET As Integer)
            datas = (From p In db.E_TRACKING_RQT_STOP_TIMEs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_E_TRACKING_RQT_LOG
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New E_TRACKING_RQT_LOG

        Public Sub insert()
            db.E_TRACKING_RQT_LOGs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.E_TRACKING_RQT_LOGs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.E_TRACKING_RQT_LOGs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)

            datas = (From p In db.E_TRACKING_RQT_LOGs Where p.IDA = Trim(IDA) Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer, ByVal FK_SET As Integer)
            datas = (From p In db.E_TRACKING_RQT_LOGs Where p.FK_IDA = FK_IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    '
    Public Class TB_LCN_EXTEND_LITE_OPEN
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New LCN_EXTEND_LITE_OPEN

        Public Sub insert()
            db.LCN_EXTEND_LITE_OPENs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_EXTEND_LITE_OPENs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_EXTEND_LITE_OPENs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)

            datas = (From p In db.LCN_EXTEND_LITE_OPENs Where p.IDA = Trim(IDA) Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function Sum_val() As Integer
            Dim i As Integer = 0
            Try
                datas = (From p In db.LCN_EXTEND_LITE_OPENs Where p.VAL_OPEN = 1 Select p)
                For Each Me.fields In datas
                    i += 1
                Next
            Catch ex As Exception

            End Try

            Return i
        End Function
    End Class
    Public Class TB_genno_temp

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New genno_temp


        Public Sub GetDataby_All()

            datas = (From p In DB.genno_temps Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In DB.genno_temps Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            DB.genno_temps.InsertOnSubmit(fields)
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
            DB.genno_temps.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_15_TAMRAP_EQTO_DDL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New _15_TAMRAP_EQTO_DDL


        Public Sub GetDataby_All()

            datas = (From p In db._15_TAMRAP_EQTO_DDLs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db._15_TAMRAP_EQTO_DDLs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_iowa_tamrab_id(ByVal IOWA As String, ByVal tamrab_id As Integer)
            datas = From p In db._15_TAMRAP_EQTO_DDLs Where p.IOWA_HEAD = IOWA And p.TAMRAP_ID = tamrab_id Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_iowa_tamrab_id_iowahead(ByVal IOWA As String, ByVal tamrab_id As Integer, ByVal iowahead As String)
            datas = From p In db._15_TAMRAP_EQTO_DDLs Where p.IOWA_HEAD = IOWA And p.TAMRAP_ID = tamrab_id And p.IOWA_HEAD = iowahead Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db._15_TAMRAP_EQTO_DDLs.InsertOnSubmit(fields)
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
            db._15_TAMRAP_EQTO_DDLs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_15_TAMRAP_IOWA_DDL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New _15_TAMRAP_IOWA_DDL


        Public Sub GetDataby_All()

            datas = (From p In db._15_TAMRAP_IOWA_DDLs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db._15_TAMRAP_IOWA_DDLs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_TAMRAP_ID(ByVal TAMRAP_ID As Integer)
            datas = From p In db._15_TAMRAP_IOWA_DDLs Where p.TAMRAP_ID = TAMRAP_ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db._15_TAMRAP_IOWA_DDLs.InsertOnSubmit(fields)
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
            db._15_TAMRAP_IOWA_DDLs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    '
    Public Class TB_15_TAMRAP_PACK_DETAIL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New _15_TAMRAP_PACK_DETAIL


        Public Sub GetDataby_All()

            datas = (From p In db._15_TAMRAP_PACK_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db._15_TAMRAP_PACK_DETAILs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_TAMRAP_ID(ByVal TAMRAP_ID As Integer)
            datas = From p In db._15_TAMRAP_PACK_DETAILs Where p.TAMRAP_ID = TAMRAP_ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db._15_TAMRAP_PACK_DETAILs.InsertOnSubmit(fields)
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
            db._15_TAMRAP_PACK_DETAILs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    '
    Public Class TB_15_TAMRAP_CONDITION

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New _15_TAMRAP_CONDITION


        Public Sub GetDataby_All()

            datas = (From p In db._15_TAMRAP_CONDITIONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db._15_TAMRAP_CONDITIONs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        Public Sub Getdata_by_TAMRAP_ID(ByVal TAMRAP_ID As Integer)
            datas = From p In db._15_TAMRAP_CONDITIONs Where p.TAMRAP_ID = TAMRAP_ID Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db._15_TAMRAP_CONDITIONs.InsertOnSubmit(fields)
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
            db._15_TAMRAP_CONDITIONs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    '
    Public Class TB_LOG_EDIT_PRODUCT_ESUB_BC

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New LOG_EDIT_PRODUCT_ESUB_BC


        Public Sub GetDataby_All()

            datas = (From p In db.LOG_EDIT_PRODUCT_ESUB_BCs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db.LOG_EDIT_PRODUCT_ESUB_BCs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db.LOG_EDIT_PRODUCT_ESUB_BCs.InsertOnSubmit(fields)
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
            db.LOG_EDIT_PRODUCT_ESUB_BCs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_A_TEST

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New A_TEST


        Public Sub GetDataby_All()

            datas = (From p In db.A_TESTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db.A_TESTs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db.A_TESTs.InsertOnSubmit(fields)
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
            db.A_TESTs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    Public Class TB_DRRGT_ADDR

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New DRRGT_ADDR


        Public Sub GetDataby_All()

            datas = (From p In db.DRRGT_ADDRs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db.DRRGT_ADDRs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_FK_IDA(ByVal IDA As String)
            datas = From p In db.DRRGT_ADDRs Where p.FK_IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db.DRRGT_ADDRs.InsertOnSubmit(fields)
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
            db.DRRGT_ADDRs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    '
    Public Class TB_TEMP_NCT_DALCN

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New TEMP_NCT_DALCN


        Public Sub GetDataby_All()

            datas = (From p In db.TEMP_NCT_DALCNs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db.TEMP_NCT_DALCNs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function Getdata_by_LCNNO_LCNTPCD_pvncd(ByVal LCNNO As String, ByVal LCNTPCD As String, ByVal pvncd As Integer) As Integer
            Dim i As Integer = 0
            datas = From p In db.TEMP_NCT_DALCNs Where p.LCNNO = LCNNO And p.LCNTPCD = LCNTPCD And p.PVNCD = pvncd Select p
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db.TEMP_NCT_DALCNs.InsertOnSubmit(fields)
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
            db.TEMP_NCT_DALCNs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class
    '
    Public Class TB_DDL_VORJOR

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New DDL_VORJOR


        Public Sub GetDataby_All()

            datas = (From p In db.DDL_VORJORs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db.DDL_VORJORs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_group(ByVal group_id As Integer)
            datas = From p In db.DDL_VORJORs Where p.group_id = group_id Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db.DDL_VORJORs.InsertOnSubmit(fields)
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
            db.DDL_VORJORs.DeleteOnSubmit(fields)
            DB.SubmitChanges()
        End Sub
    End Class

    Public Class TB_MAS_RECEIVER_EDIT_RQT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New MAS_RECEIVER_EDIT_RQT


        Public Sub GetDataby_All()

            datas = (From p In db.MAS_RECEIVER_EDIT_RQTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db.MAS_RECEIVER_EDIT_RQTs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_IDEN(ByVal iden As String)
            datas = From p In db.MAS_RECEIVER_EDIT_RQTs Where p.IDENTIFY = iden Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Function Countdata_by_IDEN(ByVal iden As String) As Integer
            Dim i As Integer = 0
            datas = From p In db.MAS_RECEIVER_EDIT_RQTs Where p.IDENTIFY = iden Select p
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db.MAS_RECEIVER_EDIT_RQTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        ''' <summary>
        ''' แก้ไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub update()
            db.SubmitChanges()
        End Sub
        ''' <summary>
        ''' ลบข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub delete()
            db.MAS_RECEIVER_EDIT_RQTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    '
    Public Class TB_CER_EXTEND_CASCHEMICAL

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New CER_EXTEND_CASCHEMICAL


        Public Sub GetDataby_All()

            datas = (From p In db.CER_EXTEND_CASCHEMICALs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db.CER_EXTEND_CASCHEMICALs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
     
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db.CER_EXTEND_CASCHEMICALs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        ''' <summary>
        ''' แก้ไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub update()
            db.SubmitChanges()
        End Sub
        ''' <summary>
        ''' ลบข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub delete()
            db.CER_EXTEND_CASCHEMICALs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_CER_EXTEND_MANUFACTURE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New CER_EXTEND_MANUFACTURE


        Public Sub GetDataby_All()

            datas = (From p In db.CER_EXTEND_MANUFACTUREs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db.CER_EXTEND_MANUFACTUREs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_FK_IDA(ByVal IDA As Integer)
            datas = From p In db.CER_EXTEND_MANUFACTUREs Where p.FK_IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db.CER_EXTEND_MANUFACTUREs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        ''' <summary>
        ''' แก้ไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub update()
            db.SubmitChanges()
        End Sub
        ''' <summary>
        ''' ลบข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub delete()
            db.CER_EXTEND_MANUFACTUREs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_CER_EXTEND_CASCHEMICAL_RQT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New CER_EXTEND_CASCHEMICAL_RQT


        Public Sub GetDataby_All()

            datas = (From p In db.CER_EXTEND_CASCHEMICAL_RQTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db.CER_EXTEND_CASCHEMICAL_RQTs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Sub Getdata_by_fk_ida(ByVal IDA As Integer)
            datas = From p In db.CER_EXTEND_CASCHEMICAL_RQTs Where p.FK_IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db.CER_EXTEND_CASCHEMICAL_RQTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        ''' <summary>
        ''' แก้ไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub update()
            db.SubmitChanges()
        End Sub
        ''' <summary>
        ''' ลบข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub delete()
            db.CER_EXTEND_CASCHEMICAL_RQTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_CER_EXTEND_MANUFACTURE_RQT

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New CER_EXTEND_MANUFACTURE_RQT


        Public Sub GetDataby_All()

            datas = (From p In db.CER_EXTEND_MANUFACTURE_RQTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db.CER_EXTEND_MANUFACTURE_RQTs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db.CER_EXTEND_MANUFACTURE_RQTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        ''' <summary>
        ''' แก้ไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub update()
            db.SubmitChanges()
        End Sub
        ''' <summary>
        ''' ลบข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub delete()
            db.CER_EXTEND_MANUFACTURE_RQTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    '
    Public Class TB_DALCN_NCT_SUBSTITUTE

        Inherits MainContext
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New DALCN_NCT_SUBSTITUTE


        Public Sub GetDataby_All()

            datas = (From p In db.DALCN_NCT_SUBSTITUTEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db.DALCN_NCT_SUBSTITUTEs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub

        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db.DALCN_NCT_SUBSTITUTEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        ''' <summary>
        ''' แก้ไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub update()
            db.SubmitChanges()
        End Sub
        ''' <summary>
        ''' ลบข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub delete()
            db.DALCN_NCT_SUBSTITUTEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class TB_LCN_EXTEND_LITE_GPP

        Inherits MAINCONTEXT
        ''' <summary>
        ''' รายชื่อ Fields ของตาราง MAS_CUSTOMER
        ''' </summary>
        ''' <remarks></remarks>
        Public fields As New LCN_EXTEND_LITE_GPP


        Public Sub GetDataby_All()

            datas = (From p In db.LCN_EXTEND_LITE_GPPs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        ''' <summary>
        ''' แสดงข้อมูลแบบมีเงื่อนไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Getdata_by_ID(ByVal IDA As Integer)
            datas = From p In db.LCN_EXTEND_LITE_GPPs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next

        End Sub
        Public Function Countdata_by_FK_IDA_year(ByVal FK_IDA As Integer, ByVal _year As Integer) As Integer
            Dim i As Integer = 0
            datas = From p In db.LCN_EXTEND_LITE_GPPs Where p.IDA = FK_IDA And p.YEARS = _year Select p
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
        ''' <summary>
        ''' เพิ่มข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub insert()
            db.LCN_EXTEND_LITE_GPPs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        ''' <summary>
        ''' แก้ไข
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub update()
            db.SubmitChanges()
        End Sub
        ''' <summary>
        ''' ลบข้อมูล
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub delete()
            db.LCN_EXTEND_LITE_GPPs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
    Public Class ClsDBMAS_MENU_AUTO2
        Inherits MAINCONTEXT

        Public fields As New MAS_MENU_AUTO2
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_MENU_AUTO2s Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_HEAD_ID(ByVal head_id As Integer, ByVal group_p As Integer)
            datas = (From p In db.MAS_MENU_AUTO2s Where p.HEAD_ID = head_id And p.GROUP_PAGE = group_p Select p Order By p.SEQ Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_HEAD_ID2(ByVal head_id As Integer, ByVal group_p As Integer, ByVal sel_type As Integer)
            datas = (From p In db.MAS_MENU_AUTO2s Where p.HEAD_ID = head_id And p.GROUP_PAGE = group_p And p.TYPE_SELECT = sel_type Select p Order By p.SEQ Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Process(ByVal process As Integer)
            datas = (From p In db.MAS_MENU_AUTO2s Where p.PROCESS_ID = process And p.GROUP_PAGE = 1 Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Process2(ByVal process As Integer)
            datas = (From p In db.MAS_MENU_AUTO2s Where p.PROCESS_ID = process Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub insert()
            db.MAS_MENU_AUTO2s.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_MENU_AUTO2s.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.MAS_MENU_AUTO2s Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_DALCN_EDIT_REQUEST
        Inherits MAINCONTEXT

        Public fields As New DALCN_EDIT_REQUEST
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.DALCN_EDIT_REQUESTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub insert()
            db.DALCN_EDIT_REQUESTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_EDIT_REQUESTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DALCN_EDIT_REQUESTs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_By_IDA(ByVal IDA As Integer)
            datas = (From p In db.DALCN_EDIT_REQUESTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class clsDBMAS_NYMSTAFF_PROCESS
        Inherits MAINCONTEXT
        Public fields As New MAS_NYMSTAFF_PROCESS
        Public Sub insert()
            db.MAS_NYMSTAFF_PROCESSes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.MAS_NYMSTAFF_PROCESSes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.MAS_NYMSTAFF_PROCESSes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_NYMSTAFF_PROCESSes Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_PROCESS(ByVal PROCESS_ID As String)
            datas = (From p In db.MAS_NYMSTAFF_PROCESSes Where p.PROCESS_ID = PROCESS_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_MAS_ORG_NAME_NYM
        Inherits MAINCONTEXT
        Public fields As New MAS_ORG_NAME_NYM
        Public Sub insert()
            db.MAS_ORG_NAME_NYMs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.MAS_ORG_NAME_NYMs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.MAS_ORG_NAME_NYMs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_ORG_NAME_NYMs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class TB_driowa_temp
        Inherits MAINCONTEXT
        Public fields As New driowa_temp
        Public Sub insert()
            db.driowa_temps.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.driowa_temps.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.driowa_temps Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.driowa_temps Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_iowacd(ByVal iowacd As String)
            datas = (From p In db.driowa_temps Where p.iowacd = iowacd Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

    Public Class TB_LOG_STATUS_DS
        Inherits MAINCONTEXT
        Public fields As New LOG_STATUS_D
        Public Sub insert()
            db.LOG_STATUS_Ds.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LOG_STATUS_Ds.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
    End Class
End Namespace


