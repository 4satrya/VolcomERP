<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormScanReturnConfirm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormScanReturnConfirm))
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.TEQtyScan = New DevExpress.XtraEditors.TextEdit()
        Me.TEQtyRetNote = New DevExpress.XtraEditors.TextEdit()
        Me.TEQtyDiff = New DevExpress.XtraEditors.TextEdit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEQtyScan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEQtyRetNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEQtyDiff.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BClose)
        Me.PanelControl2.Controls.Add(Me.BSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 178)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(580, 45)
        Me.PanelControl2.TabIndex = 2
        '
        'BClose
        '
        Me.BClose.Dock = System.Windows.Forms.DockStyle.Left
        Me.BClose.Image = CType(resources.GetObject("BClose.Image"), System.Drawing.Image)
        Me.BClose.Location = New System.Drawing.Point(2, 2)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(109, 41)
        Me.BClose.TabIndex = 5
        Me.BClose.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Image = CType(resources.GetObject("BSave.Image"), System.Drawing.Image)
        Me.BSave.Location = New System.Drawing.Point(453, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(125, 41)
        Me.BSave.TabIndex = 3
        Me.BSave.Text = "Confirm"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(19, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(167, 30)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "TOTAL QTY SCAN"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.LabelControl2.Location = New System.Drawing.Point(19, 64)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(251, 30)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "TOTAL QTY RETURN NOTE"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.LabelControl3.Location = New System.Drawing.Point(19, 125)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(103, 30)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "DIFFERENT"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.LabelControl4.Location = New System.Drawing.Point(413, 125)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(5, 30)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = ":"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.LabelControl5.Location = New System.Drawing.Point(413, 64)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(5, 30)
        Me.LabelControl5.TabIndex = 7
        Me.LabelControl5.Text = ":"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.LabelControl6.Location = New System.Drawing.Point(413, 18)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(5, 30)
        Me.LabelControl6.TabIndex = 8
        Me.LabelControl6.Text = ":"
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Black
        Me.PanelControl1.Appearance.BackColor2 = System.Drawing.Color.Black
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Location = New System.Drawing.Point(19, 105)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(545, 10)
        Me.PanelControl1.TabIndex = 9
        '
        'TEQtyScan
        '
        Me.TEQtyScan.Location = New System.Drawing.Point(438, 15)
        Me.TEQtyScan.Name = "TEQtyScan"
        Me.TEQtyScan.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.TEQtyScan.Properties.Appearance.Options.UseFont = True
        Me.TEQtyScan.Properties.Appearance.Options.UseTextOptions = True
        Me.TEQtyScan.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEQtyScan.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEQtyScan.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEQtyScan.Properties.Mask.EditMask = "N0"
        Me.TEQtyScan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEQtyScan.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEQtyScan.Properties.ReadOnly = True
        Me.TEQtyScan.Size = New System.Drawing.Size(126, 36)
        Me.TEQtyScan.TabIndex = 10
        '
        'TEQtyRetNote
        '
        Me.TEQtyRetNote.Location = New System.Drawing.Point(438, 61)
        Me.TEQtyRetNote.Name = "TEQtyRetNote"
        Me.TEQtyRetNote.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.TEQtyRetNote.Properties.Appearance.Options.UseFont = True
        Me.TEQtyRetNote.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEQtyRetNote.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEQtyRetNote.Properties.Mask.EditMask = "N0"
        Me.TEQtyRetNote.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEQtyRetNote.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEQtyRetNote.Properties.ReadOnly = True
        Me.TEQtyRetNote.Size = New System.Drawing.Size(126, 36)
        Me.TEQtyRetNote.TabIndex = 11
        '
        'TEQtyDiff
        '
        Me.TEQtyDiff.Location = New System.Drawing.Point(438, 122)
        Me.TEQtyDiff.Name = "TEQtyDiff"
        Me.TEQtyDiff.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.TEQtyDiff.Properties.Appearance.Options.UseFont = True
        Me.TEQtyDiff.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TEQtyDiff.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEQtyDiff.Properties.Mask.EditMask = "N0"
        Me.TEQtyDiff.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEQtyDiff.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEQtyDiff.Properties.ReadOnly = True
        Me.TEQtyDiff.Size = New System.Drawing.Size(126, 36)
        Me.TEQtyDiff.TabIndex = 12
        '
        'FormScanReturnConfirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 223)
        Me.Controls.Add(Me.TEQtyDiff)
        Me.Controls.Add(Me.TEQtyRetNote)
        Me.Controls.Add(Me.TEQtyScan)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormScanReturnConfirm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Konfirmasi Scan"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEQtyScan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEQtyRetNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEQtyDiff.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEQtyScan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEQtyRetNote As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEQtyDiff As DevExpress.XtraEditors.TextEdit
End Class
