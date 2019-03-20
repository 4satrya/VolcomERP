<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDocumentScanUpload
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BScan = New DevExpress.XtraEditors.SimpleButton()
        Me.BUpload = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEFilename = New System.Windows.Forms.TextBox()
        Me.PEScan = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PEScan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BScan)
        Me.PanelControl1.Controls.Add(Me.BUpload)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 512)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(566, 65)
        Me.PanelControl1.TabIndex = 0
        '
        'BScan
        '
        Me.BScan.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BScan.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BScan.Appearance.ForeColor = System.Drawing.Color.White
        Me.BScan.Appearance.Options.UseBackColor = True
        Me.BScan.Appearance.Options.UseFont = True
        Me.BScan.Appearance.Options.UseForeColor = True
        Me.BScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BScan.Location = New System.Drawing.Point(2, 2)
        Me.BScan.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BScan.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BScan.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BScan.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BScan.Name = "BScan"
        Me.BScan.Size = New System.Drawing.Size(562, 29)
        Me.BScan.TabIndex = 14
        Me.BScan.Text = "Scan"
        '
        'BUpload
        '
        Me.BUpload.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.BUpload.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BUpload.Appearance.ForeColor = System.Drawing.Color.White
        Me.BUpload.Appearance.Options.UseBackColor = True
        Me.BUpload.Appearance.Options.UseFont = True
        Me.BUpload.Appearance.Options.UseForeColor = True
        Me.BUpload.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BUpload.Location = New System.Drawing.Point(2, 31)
        Me.BUpload.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BUpload.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BUpload.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BUpload.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BUpload.Name = "BUpload"
        Me.BUpload.Size = New System.Drawing.Size(562, 32)
        Me.BUpload.TabIndex = 13
        Me.BUpload.Text = "Upload"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.TEFilename)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 471)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(566, 41)
        Me.PanelControl2.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(535, 14)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = ".jpg"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Filename"
        '
        'TEFilename
        '
        Me.TEFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TEFilename.Location = New System.Drawing.Point(60, 11)
        Me.TEFilename.Name = "TEFilename"
        Me.TEFilename.Size = New System.Drawing.Size(469, 21)
        Me.TEFilename.TabIndex = 0
        Me.TEFilename.Text = "tes"
        Me.TEFilename.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PEScan
        '
        Me.PEScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PEScan.Location = New System.Drawing.Point(0, 0)
        Me.PEScan.Name = "PEScan"
        Me.PEScan.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PEScan.Properties.ShowMenu = False
        Me.PEScan.Properties.ShowScrollBars = True
        Me.PEScan.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.[True]
        Me.PEScan.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        Me.PEScan.Size = New System.Drawing.Size(566, 471)
        Me.PEScan.TabIndex = 2
        '
        'FormDocumentScanUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 577)
        Me.Controls.Add(Me.PEScan)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDocumentScanUpload"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scan and Upload"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.PEScan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BScan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BUpload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEFilename As TextBox
    Friend WithEvents PEScan As DevExpress.XtraEditors.PictureEdit
End Class
