Public Class UC_BIO_CHEM
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Sub set_lbl_bio_type(ByVal b_type As Integer)
        Dim dao As New DAO_DRUG.TB_MAS_BIO_TYPE
        Try
            dao.GetDataby_IDA(b_type)
            lbl_bio_type1.Text = dao.fields.BIO_TYPE
        Catch ex As Exception

        End Try

    End Sub
    'Sub bind_rdl_bio()
    '    Dim dao As New DAO_DRUG.TB_MAS_BIO_TYPE
    '    dao.GetDataALL()
    '    rdl_bio_type.DataSource = dao.datas
    '    rdl_bio_type.DataValueField = "IDA"
    '    rdl_bio_type.DataTextField = "BIO_TYPE"
    '    rdl_bio_type.DataBind()
    'End Sub
    Sub set_data(ByRef dao As DAO_DRUG.TB_CHEMICAL_REQUEST)
        With dao.fields
            '.aori = Request.QueryString("ct")
            'Try
            '    .BIO_TYPE = Request.QueryString("")
            'Catch ex As Exception

            'End Try
            dao.fields.EXTRACT_OTHER2 = txt_EXTRACT_OTHER2.Text
            Try
                .GENE_MOD = rdl_GENE_MOD.SelectedValue
            Catch ex As Exception

            End Try
            Try
                .EXTRACT_TYPE = rdl_EXTRACT_TYPE.SelectedValue
            Catch ex As Exception

            End Try
            .EXTRACT_OTHER = txt_EXTRACT_OTHER.Text
            .iowanm = txt_iowanm.Text
            .GENUS = txt_genus.Text
            .SPECIES = txt_Species.Text
            .STRAIN = txt_Strain.Text
            .EMAIL = txt_EMAIL.Text
            .TEL = txt_TEL.Text
        End With
    End Sub
    Sub get_data(ByRef dao As DAO_DRUG.TB_CHEMICAL_REQUEST)
        With dao.fields
            'Try
            '    rdl_bio_type.SelectedValue = .BIO_TYPE
            'Catch ex As Exception

            'End Try
            txt_EXTRACT_OTHER2.Text = dao.fields.EXTRACT_OTHER2
            Try
                rdl_GENE_MOD.SelectedValue = .GENE_MOD
            Catch ex As Exception

            End Try
            Try
                rdl_EXTRACT_TYPE.SelectedValue = .EXTRACT_TYPE
            Catch ex As Exception

            End Try
            txt_EXTRACT_OTHER.Text = .EXTRACT_OTHER
            txt_iowanm.Text = .iowanm
            txt_genus.Text = .GENUS
            txt_Species.Text = .SPECIES
            txt_Strain.Text = .STRAIN
            Try
                txt_EMAIL.Text = dao.fields.EMAIL
            Catch ex As Exception

            End Try
            Try
                txt_TEL.Text = dao.fields.TEL
            Catch ex As Exception

            End Try
        End With
    End Sub
End Class