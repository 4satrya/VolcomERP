Public Class FormEmployeePpsAtt
    Public type As String = ""
    Public images As DataTable = New DataTable
    Public read_only As Boolean = False
    Public is_single As Boolean = False

    Private Sub FormEmployeePpsAtt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To images.Rows.Count - 1
            Dim msImage As IO.MemoryStream = New IO.MemoryStream(images.Rows(i)("image"), False)

            addImage(msImage)
        Next

        If read_only Then
            SBAdd.Enabled = False
            SBScanUpload.Enabled = False
            SBDelete.Enabled = False
            SBSave.Enabled = False
        End If

        If is_single Then
            SBAdd.Visible = False
            SBDelete.Visible = False
        End If

        ' disable right click
        PictureEdit.Properties.ContextMenuStrip = New ContextMenuStrip
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        If type = "ktp" Then
            Dim ic As DevExpress.XtraEditors.PictureEdit = CType(XSCImageList.Controls(0), DevExpress.XtraEditors.PictureEdit)

            Dim con As ImageConverter = New ImageConverter

            images.Rows(0)("image") = con.ConvertTo(ic.EditValue, GetType(Byte()))

            Dim msImage As IO.MemoryStream = New IO.MemoryStream(images.Rows(0)("image"), False)

            Dim PEEdit As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

            Dim image As Image = Image.FromStream(msImage)

            FormEmployeePpsDet.PEKTP.EditValue = image
        ElseIf type = "kk" Then
            Dim ic As DevExpress.XtraEditors.PictureEdit = CType(XSCImageList.Controls(0), DevExpress.XtraEditors.PictureEdit)

            Dim con As ImageConverter = New ImageConverter

            images.Rows(0)("image") = con.ConvertTo(ic.EditValue, GetType(Byte()))

            Dim msImage As IO.MemoryStream = New IO.MemoryStream(images.Rows(0)("image"), False)

            Dim PEEdit As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

            Dim image As Image = Image.FromStream(msImage)

            FormEmployeePpsDet.PEKK.EditValue = image
        ElseIf type = "position" Then
            images.Rows.Clear()

            For Each i As Control In XSCImageList.Controls
                Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

                Dim con As ImageConverter = New ImageConverter

                images.Rows.Add(con.ConvertTo(ic.EditValue, GetType(Byte())))
            Next

            FormEmployeePpsDet.PCPosAtt.Controls.Clear()

            For i = 0 To images.Rows.Count - 1
                Dim msImage As IO.MemoryStream = New IO.MemoryStream(images.Rows(i)("image"), False)

                Dim PEEdit As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

                Dim image As Image = Image.FromStream(msImage)

                PEEdit.EditValue = image

                FormEmployeePpsDet.PCPosAtt.Controls.Add(PEEdit)
            Next
        End If

        Close()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        addImage(Nothing)
    End Sub

    Private Sub FormEmployeePpsAtt_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Sub addImage(ByVal msImage As IO.MemoryStream)
        Dim PEEdit As DevExpress.XtraEditors.PictureEdit = New DevExpress.XtraEditors.PictureEdit

        PEEdit.Size = New Size(50, 50)
        PEEdit.Dock = DockStyle.Left
        PEEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch

        ' load image
        If Not msImage Is Nothing Then
            Dim image As Image = Image.FromStream(msImage)

            PEEdit.EditValue = image
        Else
            PEEdit.LoadAsync(FormEmployeePpsDet.pps_path + "default.jpg")
        End If

        AddHandler PEEdit.Click, AddressOf clickImage
        AddHandler PEEdit.ImageChanged, AddressOf changeImage

        XSCImageList.Controls.Add(PEEdit)

        clickImage(PEEdit, New EventArgs)
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

    Sub changeImage(sender As Object, e As EventArgs)
        Dim PEEdit As DevExpress.XtraEditors.PictureEdit = CType(sender, DevExpress.XtraEditors.PictureEdit)

        PictureEdit.EditValue = PEEdit.EditValue

        If PEEdit.EditValue Is Nothing Then
            PEEdit.LoadAsync(FormEmployeePpsDet.pps_path + "default.jpg")
        End If
    End Sub

    Private Sub SBScanUpload_Click(sender As Object, e As EventArgs) Handles SBScanUpload.Click
        For Each i As Control In XSCImageList.Controls
            Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

            If ic.BorderStyle.ToString = "Style3D" Then
                ic.Image = Scanner.Scan

                Exit For
            End If
        Next
    End Sub

    Private Sub SBDelete_Click(sender As Object, e As EventArgs) Handles SBDelete.Click
        ' check children
        Dim child As Integer = 0

        For Each i As Control In XSCImageList.Controls
            child += 1
        Next

        ' remove selected
        If child > 1 Then
            For Each i As Control In XSCImageList.Controls
                Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

                If ic.BorderStyle.ToString = "Style3D" Then
                    XSCImageList.Controls.Remove(ic)

                    Exit For
                End If
            Next

            ' set selected
            If XSCImageList.HasChildren Then
                For Each i As Control In XSCImageList.Controls
                    Dim ic As DevExpress.XtraEditors.PictureEdit = CType(i, DevExpress.XtraEditors.PictureEdit)

                    ic.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D

                    PictureEdit.Image = ic.EditValue

                    Exit For
                Next
            Else
                PictureEdit.Image = Nothing
            End If
        End If
    End Sub
End Class