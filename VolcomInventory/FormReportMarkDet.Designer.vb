<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportMarkDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReportMarkDet))
        Me.BRefuse = New DevExpress.XtraEditors.SimpleButton()
        Me.BAccept = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.MEComment = New DevExpress.XtraEditors.MemoEdit()
        Me.TEEmployee = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.PictureSeason = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.MEComment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEEmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BRefuse
        '
        Me.BRefuse.Appearance.BackColor = System.Drawing.Color.Red
        Me.BRefuse.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BRefuse.Appearance.ForeColor = System.Drawing.Color.White
        Me.BRefuse.Appearance.Options.UseBackColor = True
        Me.BRefuse.Appearance.Options.UseFont = True
        Me.BRefuse.Appearance.Options.UseForeColor = True
        Me.BRefuse.Location = New System.Drawing.Point(159, 153)
        Me.BRefuse.LookAndFeel.SkinMaskColor = System.Drawing.Color.DarkRed
        Me.BRefuse.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Black
        Me.BRefuse.LookAndFeel.SkinName = "Metropolis"
        Me.BRefuse.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BRefuse.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BRefuse.Name = "BRefuse"
        Me.BRefuse.Size = New System.Drawing.Size(128, 34)
        Me.BRefuse.TabIndex = 138
        Me.BRefuse.Text = "Not Approve"
        '
        'BAccept
        '
        Me.BAccept.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BAccept.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BAccept.Appearance.ForeColor = System.Drawing.Color.White
        Me.BAccept.Appearance.Options.UseBackColor = True
        Me.BAccept.Appearance.Options.UseFont = True
        Me.BAccept.Appearance.Options.UseForeColor = True
        Me.BAccept.Location = New System.Drawing.Point(293, 153)
        Me.BAccept.LookAndFeel.SkinName = "Metropolis"
        Me.BAccept.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BAccept.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BAccept.Name = "BAccept"
        Me.BAccept.Size = New System.Drawing.Size(137, 34)
        Me.BAccept.TabIndex = 136
        Me.BAccept.Text = "Approve"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(159, 59)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(51, 15)
        Me.LabelControl1.TabIndex = 135
        Me.LabelControl1.Text = "Comment"
        '
        'MEComment
        '
        Me.MEComment.Location = New System.Drawing.Point(159, 80)
        Me.MEComment.Name = "MEComment"
        Me.MEComment.Size = New System.Drawing.Size(271, 58)
        Me.MEComment.TabIndex = 134
        '
        'TEEmployee
        '
        Me.TEEmployee.Location = New System.Drawing.Point(159, 30)
        Me.TEEmployee.Name = "TEEmployee"
        Me.TEEmployee.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TEEmployee.Properties.Appearance.Options.UseFont = True
        Me.TEEmployee.Properties.ReadOnly = True
        Me.TEEmployee.Size = New System.Drawing.Size(271, 22)
        Me.TEEmployee.TabIndex = 133
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl4.Location = New System.Drawing.Point(159, 9)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(31, 15)
        Me.LabelControl4.TabIndex = 132
        Me.LabelControl4.Text = "Name"
        '
        'PictureSeason
        '
        Me.PictureSeason.EditValue = CType(resources.GetObject("PictureSeason.EditValue"), Object)
        Me.PictureSeason.Location = New System.Drawing.Point(17, 59)
        Me.PictureSeason.Name = "PictureSeason"
        Me.PictureSeason.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureSeason.Properties.Appearance.Options.UseBackColor = True
        Me.PictureSeason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureSeason.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureSeason.Size = New System.Drawing.Size(113, 109)
        Me.PictureSeason.TabIndex = 131
        '
        'FormReportMarkDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 199)
        Me.Controls.Add(Me.BRefuse)
        Me.Controls.Add(Me.BAccept)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.MEComment)
        Me.Controls.Add(Me.TEEmployee)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.PictureSeason)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Metropolis"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportMarkDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mark Detail"
        CType(Me.MEComment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEEmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BRefuse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAccept As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEComment As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TEEmployee As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureSeason As DevExpress.XtraEditors.PictureEdit
End Class
