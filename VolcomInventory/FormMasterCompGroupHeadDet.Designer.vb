<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCompGroupHeadDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterCompGroupHeadDet))
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDescription = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PictureSeason = New DevExpress.XtraEditors.PictureEdit()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TECompanyGroup = New DevExpress.XtraEditors.TextEdit()
        CType(Me.TEDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECompanyGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(113, 30)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(88, 15)
        Me.LabelControl2.TabIndex = 31
        Me.LabelControl2.Text = "Company Group"
        '
        'TEDescription
        '
        Me.TEDescription.Location = New System.Drawing.Point(238, 55)
        Me.TEDescription.Name = "TEDescription"
        Me.TEDescription.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEDescription.Properties.Appearance.Options.UseFont = True
        Me.TEDescription.Size = New System.Drawing.Size(272, 22)
        Me.TEDescription.TabIndex = 30
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(113, 58)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(64, 15)
        Me.LabelControl1.TabIndex = 29
        Me.LabelControl1.Text = "Description"
        '
        'PictureSeason
        '
        Me.PictureSeason.EditValue = CType(resources.GetObject("PictureSeason.EditValue"), Object)
        Me.PictureSeason.Location = New System.Drawing.Point(12, -2)
        Me.PictureSeason.Name = "PictureSeason"
        Me.PictureSeason.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureSeason.Properties.Appearance.Options.UseBackColor = True
        Me.PictureSeason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureSeason.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureSeason.Size = New System.Drawing.Size(99, 107)
        Me.PictureSeason.TabIndex = 28
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(365, 88)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(69, 23)
        Me.BCancel.TabIndex = 27
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(440, 88)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 26
        Me.BSave.Text = "Save"
        '
        'TECompanyGroup
        '
        Me.TECompanyGroup.Location = New System.Drawing.Point(238, 27)
        Me.TECompanyGroup.Name = "TECompanyGroup"
        Me.TECompanyGroup.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TECompanyGroup.Properties.Appearance.Options.UseFont = True
        Me.TECompanyGroup.Size = New System.Drawing.Size(272, 22)
        Me.TECompanyGroup.TabIndex = 25
        '
        'FormMasterCompGroupHeadDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 127)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TEDescription)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PictureSeason)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.TECompanyGroup)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCompGroupHeadDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Group Company"
        CType(Me.TEDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECompanyGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureSeason As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TECompanyGroup As DevExpress.XtraEditors.TextEdit
End Class
