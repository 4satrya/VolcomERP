<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMarkAssignSingle
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMarkAssignSingle))
        Me.PictureEditIcon = New DevExpress.XtraEditors.PictureEdit()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LEMarkType = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.CERequisite = New DevExpress.XtraEditors.CheckEdit()
        Me.CEOnHold = New DevExpress.XtraEditors.CheckEdit()
        Me.CENeedPrint = New DevExpress.XtraEditors.CheckEdit()
        Me.CENeedUpload = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.PictureEditIcon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEMarkType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CERequisite.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEOnHold.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CENeedPrint.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CENeedUpload.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureEditIcon
        '
        Me.PictureEditIcon.EditValue = CType(resources.GetObject("PictureEditIcon.EditValue"), Object)
        Me.PictureEditIcon.Location = New System.Drawing.Point(16, 12)
        Me.PictureEditIcon.Name = "PictureEditIcon"
        Me.PictureEditIcon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEditIcon.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEditIcon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEditIcon.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureEditIcon.Size = New System.Drawing.Size(99, 96)
        Me.PictureEditIcon.TabIndex = 52
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(270, 132)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(75, 23)
        Me.BCancel.TabIndex = 51
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(351, 132)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 23)
        Me.BSave.TabIndex = 50
        Me.BSave.Text = "Save"
        '
        'LEMarkType
        '
        Me.LEMarkType.Location = New System.Drawing.Point(189, 25)
        Me.LEMarkType.Name = "LEMarkType"
        Me.LEMarkType.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LEMarkType.Properties.Appearance.Options.UseFont = True
        Me.LEMarkType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEMarkType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_mark_type", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_mark_type_name", "Report")})
        Me.LEMarkType.Properties.NullText = ""
        Me.LEMarkType.Size = New System.Drawing.Size(237, 22)
        Me.LEMarkType.TabIndex = 49
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(147, 28)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(36, 15)
        Me.LabelControl1.TabIndex = 48
        Me.LabelControl1.Text = "Report"
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Location = New System.Drawing.Point(189, 54)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LEReportStatus.Properties.Appearance.Options.UseFont = True
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Size = New System.Drawing.Size(237, 22)
        Me.LEReportStatus.TabIndex = 46
        '
        'LabelControl17
        '
        Me.LabelControl17.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl17.Location = New System.Drawing.Point(147, 57)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(29, 15)
        Me.LabelControl17.TabIndex = 47
        Me.LabelControl17.Text = "Mark"
        '
        'CERequisite
        '
        Me.CERequisite.Location = New System.Drawing.Point(189, 82)
        Me.CERequisite.Name = "CERequisite"
        Me.CERequisite.Properties.Caption = "Requisite"
        Me.CERequisite.Size = New System.Drawing.Size(69, 19)
        Me.CERequisite.TabIndex = 164
        '
        'CEOnHold
        '
        Me.CEOnHold.Location = New System.Drawing.Point(270, 82)
        Me.CEOnHold.Name = "CEOnHold"
        Me.CEOnHold.Properties.Caption = "On Hold"
        Me.CEOnHold.Size = New System.Drawing.Size(109, 19)
        Me.CEOnHold.TabIndex = 165
        '
        'CENeedPrint
        '
        Me.CENeedPrint.Location = New System.Drawing.Point(189, 107)
        Me.CENeedPrint.Name = "CENeedPrint"
        Me.CENeedPrint.Properties.Caption = "Need Print"
        Me.CENeedPrint.Size = New System.Drawing.Size(77, 19)
        Me.CENeedPrint.TabIndex = 166
        '
        'CENeedUpload
        '
        Me.CENeedUpload.Location = New System.Drawing.Point(270, 107)
        Me.CENeedUpload.Name = "CENeedUpload"
        Me.CENeedUpload.Properties.Caption = "Need Upload"
        Me.CENeedUpload.Size = New System.Drawing.Size(93, 19)
        Me.CENeedUpload.TabIndex = 167
        '
        'FormMarkAssignSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 170)
        Me.Controls.Add(Me.CENeedUpload)
        Me.Controls.Add(Me.CENeedPrint)
        Me.Controls.Add(Me.CEOnHold)
        Me.Controls.Add(Me.CERequisite)
        Me.Controls.Add(Me.PictureEditIcon)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.LEMarkType)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LEReportStatus)
        Me.Controls.Add(Me.LabelControl17)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMarkAssignSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mark"
        CType(Me.PictureEditIcon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEMarkType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CERequisite.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEOnHold.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CENeedPrint.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CENeedUpload.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureEditIcon As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LEMarkType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CERequisite As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CEOnHold As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CENeedPrint As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CENeedUpload As DevExpress.XtraEditors.CheckEdit
End Class
