Public Class UC_HERB_CHEM
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Sub set_lbl_herb_type(ByVal h_type As Integer)
        Dim dao As New DAO_DRUG.TB_MAS_HERB_TYPE
        Try
            dao.GetDataby_IDA(h_type)
            lb_herb_type.Text = dao.fields.HERB_TYPE
        Catch ex As Exception

        End Try

    End Sub
    'Public Sub bind_rdl_herb_type()
    '    Dim dao As New DAO_DRUG.TB_MAS_HERB_TYPE
    '    dao.GetDataALL()

    '    rdl_herb_type.DataSource = dao.datas
    '    rdl_herb_type.DataTextField = "HERB_TYPE"
    '    rdl_herb_type.DataValueField = "IDA"
    '    rdl_herb_type.DataBind()
    'End Sub
    Sub bind_rdl_herb_or_animal()
        Dim dao As New DAO_DRUG.TB_MAS_HERB_OR_ANIMAL_PART
        Try
            dao.GetDataby_TYPE_HEAD(rdl_herb_sub_type.SelectedValue)
            cbl_herb_or_animal.DataSource = dao.datas
        Catch ex As Exception
        End Try
        cbl_herb_or_animal.DataTextField = "HERB_OR_ANIMAL_PART"
        cbl_herb_or_animal.DataValueField = "IDA"
        cbl_herb_or_animal.DataBind()

        If Request.QueryString("ida") <> "" Then
            For Each list As ListItem In cbl_herb_or_animal.Items
                Dim dao2 As New DAO_DRUG.TB_CHEMICAL_HERB_DETAIL
                Dim bool As Boolean = False
                Try
                    bool = dao2.GetDataby_IDA_HERB(Request.QueryString("ida"), list.Value)
                Catch ex As Exception

                End Try

                Try
                    If bool = True Then
                        list.Selected = True
                    End If
                Catch ex As Exception

                End Try
            Next
        End If
    End Sub
    Public Sub bind_ddl_nat()
        Dim dt As New DataTable
        Dim bao_master As New BAO_MASTER
        dt = bao_master.SP_MASTER_sysisocnt()
        ddl_national.DataSource = dt
        ddl_national.DataValueField = "IDA"
        ddl_national.DataTextField = "engcntnm"

        ddl_national.DataBind()
    End Sub
    Sub set_data(ByRef dao As DAO_DRUG.TB_CHEMICAL_REQUEST)
        With dao.fields
            '.aori = Request.QueryString("ct")
            '.G_TYPE = Request.QueryString("g") 'rdl_herb_type.SelectedValue
            .iowanm = txt_iowanm.Text
            .iowanm_eng = txt_iowanm_eng.Text
            .SCIENTIFIC_NAME = txt_SCIENTIFIC_NAME.Text
            .NATIONAL_CD = ddl_national.SelectedValue
            .IS_PROCESSING = rdl_processing.SelectedValue
            .PROCESSING_DES = txt_PROCESSING_DES.Text
            .GENUS = txt_genus.Text
            .SPECIES = txt_Species.Text
            .BRAND_LABEL = txt_BRAND_LABEL.Text
            .EMAIL = txt_EMAIL.Text
            .TEL = txt_TEL.Text
        End With
    End Sub
    Sub get_data(ByRef dao As DAO_DRUG.TB_CHEMICAL_REQUEST)
        With dao.fields
            'Try
            '    rdl_herb_type.SelectedValue = .G_TYPE
            'Catch ex As Exception

            'End Try

            txt_iowanm.Text = .iowanm
            txt_iowanm_eng.Text = .iowanm_eng
            txt_SCIENTIFIC_NAME.Text = .SCIENTIFIC_NAME
            Try
                ddl_national.DropDownSelectData(.NATIONAL_CD)
            Catch ex As Exception

            End Try
            Try
                rdl_processing.SelectedValue = .IS_PROCESSING

            Catch ex As Exception

            End Try
            txt_PROCESSING_DES.Text = .PROCESSING_DES
            txt_genus.Text = .GENUS
            txt_Species.Text = .SPECIES
            txt_BRAND_LABEL.Text = .BRAND_LABEL
            Try
                txt_EMAIL.Text = .EMAIL
            Catch ex As Exception

            End Try
            Try
                txt_TEL.Text = .TEL
            Catch ex As Exception

            End Try
        End With
    End Sub

    Sub insert_det(ByVal ida As Integer)
        Try
            For Each list As ListItem In cbl_herb_or_animal.Items
                If list.Selected Then
                    Dim dao As New DAO_DRUG.TB_CHEMICAL_HERB_DETAIL
                    dao.fields.FK_IDA = ida
                    dao.fields.HERB_OR_ANIMAL_PART_ID = list.Value
                    dao.fields.OTHER_DESCRIPTION = txt_herb_or_animal_other.Text
                    dao.insert()
                End If
               
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rdl_herb_sub_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdl_herb_sub_type.SelectedIndexChanged
        bind_rdl_herb_or_animal()
    End Sub
End Class