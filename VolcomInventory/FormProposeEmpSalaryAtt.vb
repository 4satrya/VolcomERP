Public Class FormProposeEmpSalaryAtt
    Public id_employee_status_det As String = ""

    Private images As DataTable = New DataTable

    Private Sub FormProposeEmpSalaryAtt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pic_path_emp_pps As String = get_setup_field("pic_path_emp_pps") + "\"

        Dim query As String = "
            SELECT IFNULL((SELECT MAX(id_employee_pps) FROM tb_employee_pps WHERE id_employee_status_det = '" + id_employee_status_det + "' AND id_report_status = '6'), 0)
        "

        Dim id_pps As String = execute_query(query, 0, True, "", "", "", "")

        If id_pps = 0 Then
            addImage(pic_path_emp_pps, "default")

            clickImage(XSCImageList.Controls(0), New EventArgs)

            viewImages(PictureEdit, pic_path_emp_pps, "default", False)
        Else
            For i = 1 To 100
                Dim path As String = get_setup_field("pic_path_emp_pps") + "\" + id_pps + "_position_" + i.ToString + ".jpg"

                If IO.File.Exists(path) Then
                    addImage(pic_path_emp_pps, id_pps + "_position_" + i.ToString)

                    If i = 1 Then
                        clickImage(XSCImageList.Controls(0), New EventArgs)

                        viewImages(PictureEdit, pic_path_emp_pps, id_pps + "_position_" + i.ToString, False)
                    End If
                Else
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub addImage(dir As String, id As String)
        Dim PEPosition As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

        PEPosition.Size = New Size(50, 50)
        PEPosition.Dock = DockStyle.Left
        PEPosition.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        PEPosition.ReadOnly = True

        XSCImageList.Controls.Add(PEPosition)
        XSCImageList.Controls.SetChildIndex(PEPosition, 0)

        viewImages(PEPosition, dir, id, False)

        AddHandler PEPosition.Click, AddressOf clickImage
    End Sub

    Private Sub FormProposeEmpSalaryAtt_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub PictureEdit_MouseWheel(sender As Object, e As MouseEventArgs) Handles PictureEdit.MouseWheel
        PictureEdit.Properties.ZoomPercent += e.Delta * 0.03F
        DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
    End Sub

    Sub clickImage(sender As Object, e As EventArgs)
        ' clear border
        For Each i As Control In XSCImageList.Controls
            Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

            ic.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default
        Next

        ' set border
        Dim PEEdit As DevExpress.XtraEditors.PictureEdit = CType(sender, DevExpress.XtraEditors.PictureEdit)

        PEEdit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D

        PictureEdit.EditValue = PEEdit.EditValue
    End Sub
End Class