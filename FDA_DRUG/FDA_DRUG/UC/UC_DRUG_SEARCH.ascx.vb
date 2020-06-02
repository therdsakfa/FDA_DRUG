Imports Telerik.Web.UI

Public Class UC_DRUG_SEARCH
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bind_all("1")
    End Sub
    Public Function getSearchMsg() As String
        Dim strMsg As String = String.Empty
        Try


            Dim doc As String = ""
            Dim C_NUMBER As String = ""

            C_NUMBER = txt_c_number.Text
            doc = rcb_doc.SelectedItem.Text



            If C_NUMBER <> "" Then
                strMsg &= "([REF_C_NUMBER_1] LIKE '%" & C_NUMBER & "%')"
            End If

            If rcb_doc.SelectedItem.Value <> "0" Then
                If String.IsNullOrEmpty(strMsg) = False Then
                    strMsg &= " and "
                End If
                strMsg &= "([PROCESS_NAME] = '" & doc & "')"
            End If

        Catch ex As Exception

        End Try


        Return strMsg
    End Function



    Public Sub bind_all(ByVal SYSTEM_ID As String)
        Try
            bind_rcb_doc(SYSTEM_ID)
        Catch ex As Exception

        End Try



    End Sub


    Public Sub bind_rcb_doc(ByVal SYSTEM_ID As String)
        Try
            Dim dao As New DAO_BOOKING.TB_MAS_PROCESS
            dao.GetDataby_SYSTEM_ID(SYSTEM_ID)

            rcb_doc.DataTextField = "PROCESS_NAME"
            rcb_doc.DataValueField = "PROCESS_ID"
            rcb_doc.DataSource = dao.datas
            rcb_doc.DataBind()
            rcb_doc.Items.Insert(0, New RadComboBoxItem("ทั้งหมด", "0"))
        Catch ex As Exception

        End Try



    End Sub
End Class