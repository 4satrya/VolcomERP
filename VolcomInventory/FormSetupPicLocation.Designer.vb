<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSetupPicLocation
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSetupPicLocation))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPicLocation = New DevExpress.XtraTab.XtraTabPage()
        Me.PC2 = New DevExpress.XtraEditors.PanelControl()
        Me.BBrowseLogo = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPicLogo = New DevExpress.XtraEditors.TextEdit()
        Me.PictureEditIcon = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.BBrowseMat = New DevExpress.XtraEditors.SimpleButton()
        Me.TEPicMat = New DevExpress.XtraEditors.TextEdit()
        Me.BBrowseSample = New DevExpress.XtraEditors.SimpleButton()
        Me.TEPicSample = New DevExpress.XtraEditors.TextEdit()
        Me.LabelSeason = New DevExpress.XtraEditors.LabelControl()
        Me.BBrowseDesign = New DevExpress.XtraEditors.SimpleButton()
        Me.TEPicDesign = New DevExpress.XtraEditors.TextEdit()
        Me.EPPicLocation = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPPicLocation.SuspendLayout()
        CType(Me.PC2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PC2.SuspendLayout()
        CType(Me.TEPicLogo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEditIcon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPicMat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPicSample.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPicDesign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EPPicLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 156)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(640, 46)
        Me.PanelControl1.TabIndex = 62
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(558, 12)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 23)
        Me.BSave.TabIndex = 61
        Me.BSave.Text = "Save"
        Me.BSave.Visible = False
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPPicLocation
        Me.XtraTabControl1.Size = New System.Drawing.Size(646, 230)
        Me.XtraTabControl1.TabIndex = 1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPicLocation})
        '
        'XTPPicLocation
        '
        Me.XTPPicLocation.Controls.Add(Me.PC2)
        Me.XTPPicLocation.Controls.Add(Me.PanelControl1)
        Me.XTPPicLocation.Name = "XTPPicLocation"
        Me.XTPPicLocation.Size = New System.Drawing.Size(640, 202)
        Me.XTPPicLocation.Text = "Picture Location"
        '
        'PC2
        '
        Me.PC2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PC2.Controls.Add(Me.BBrowseLogo)
        Me.PC2.Controls.Add(Me.LabelControl4)
        Me.PC2.Controls.Add(Me.TEPicLogo)
        Me.PC2.Controls.Add(Me.PictureEditIcon)
        Me.PC2.Controls.Add(Me.LabelControl2)
        Me.PC2.Controls.Add(Me.LabelControl3)
        Me.PC2.Controls.Add(Me.BBrowseMat)
        Me.PC2.Controls.Add(Me.TEPicMat)
        Me.PC2.Controls.Add(Me.BBrowseSample)
        Me.PC2.Controls.Add(Me.TEPicSample)
        Me.PC2.Controls.Add(Me.LabelSeason)
        Me.PC2.Controls.Add(Me.BBrowseDesign)
        Me.PC2.Controls.Add(Me.TEPicDesign)
        Me.PC2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PC2.Location = New System.Drawing.Point(0, 0)
        Me.PC2.Name = "PC2"
        Me.PC2.Size = New System.Drawing.Size(640, 156)
        Me.PC2.TabIndex = 63
        '
        'BBrowseLogo
        '
        Me.BBrowseLogo.Location = New System.Drawing.Point(516, 103)
        Me.BBrowseLogo.Name = "BBrowseLogo"
        Me.BBrowseLogo.Size = New System.Drawing.Size(86, 23)
        Me.BBrowseLogo.TabIndex = 62
        Me.BBrowseLogo.Text = "Browse"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(173, 111)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(25, 15)
        Me.LabelControl4.TabIndex = 61
        Me.LabelControl4.Text = "Logo"
        '
        'TEPicLogo
        '
        Me.TEPicLogo.Location = New System.Drawing.Point(252, 103)
        Me.TEPicLogo.Name = "TEPicLogo"
        Me.TEPicLogo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TEPicLogo.Properties.Appearance.Options.UseFont = True
        Me.TEPicLogo.Properties.ReadOnly = True
        Me.TEPicLogo.Size = New System.Drawing.Size(243, 22)
        Me.TEPicLogo.TabIndex = 63
        '
        'PictureEditIcon
        '
        Me.PictureEditIcon.EditValue = CType(resources.GetObject("PictureEditIcon.EditValue"), Object)
        Me.PictureEditIcon.Location = New System.Drawing.Point(11, 24)
        Me.PictureEditIcon.Name = "PictureEditIcon"
        Me.PictureEditIcon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEditIcon.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEditIcon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEditIcon.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureEditIcon.Size = New System.Drawing.Size(111, 114)
        Me.PictureEditIcon.TabIndex = 48
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(173, 24)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(48, 15)
        Me.LabelControl2.TabIndex = 57
        Me.LabelControl2.Text = "Material"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(173, 82)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(37, 15)
        Me.LabelControl3.TabIndex = 60
        Me.LabelControl3.Text = "Design"
        '
        'BBrowseMat
        '
        Me.BBrowseMat.Location = New System.Drawing.Point(516, 16)
        Me.BBrowseMat.Name = "BBrowseMat"
        Me.BBrowseMat.Size = New System.Drawing.Size(86, 23)
        Me.BBrowseMat.TabIndex = 49
        Me.BBrowseMat.Text = "Browse"
        '
        'TEPicMat
        '
        Me.TEPicMat.Location = New System.Drawing.Point(252, 16)
        Me.TEPicMat.Name = "TEPicMat"
        Me.TEPicMat.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TEPicMat.Properties.Appearance.Options.UseFont = True
        Me.TEPicMat.Properties.ReadOnly = True
        Me.TEPicMat.Size = New System.Drawing.Size(243, 22)
        Me.TEPicMat.TabIndex = 50
        '
        'BBrowseSample
        '
        Me.BBrowseSample.Location = New System.Drawing.Point(516, 45)
        Me.BBrowseSample.Name = "BBrowseSample"
        Me.BBrowseSample.Size = New System.Drawing.Size(86, 23)
        Me.BBrowseSample.TabIndex = 52
        Me.BBrowseSample.Text = "Browse"
        '
        'TEPicSample
        '
        Me.TEPicSample.Location = New System.Drawing.Point(252, 45)
        Me.TEPicSample.Name = "TEPicSample"
        Me.TEPicSample.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TEPicSample.Properties.Appearance.Options.UseFont = True
        Me.TEPicSample.Properties.ReadOnly = True
        Me.TEPicSample.Size = New System.Drawing.Size(243, 22)
        Me.TEPicSample.TabIndex = 53
        '
        'LabelSeason
        '
        Me.LabelSeason.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSeason.Location = New System.Drawing.Point(173, 53)
        Me.LabelSeason.Name = "LabelSeason"
        Me.LabelSeason.Size = New System.Drawing.Size(40, 15)
        Me.LabelSeason.TabIndex = 51
        Me.LabelSeason.Text = "Sample"
        '
        'BBrowseDesign
        '
        Me.BBrowseDesign.Location = New System.Drawing.Point(516, 74)
        Me.BBrowseDesign.Name = "BBrowseDesign"
        Me.BBrowseDesign.Size = New System.Drawing.Size(86, 23)
        Me.BBrowseDesign.TabIndex = 55
        Me.BBrowseDesign.Text = "Browse"
        '
        'TEPicDesign
        '
        Me.TEPicDesign.Location = New System.Drawing.Point(252, 74)
        Me.TEPicDesign.Name = "TEPicDesign"
        Me.TEPicDesign.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TEPicDesign.Properties.Appearance.Options.UseFont = True
        Me.TEPicDesign.Properties.ReadOnly = True
        Me.TEPicDesign.Size = New System.Drawing.Size(243, 22)
        Me.TEPicDesign.TabIndex = 56
        '
        'EPPicLocation
        '
        Me.EPPicLocation.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EPPicLocation.ContainerControl = Me
        '
        'FormSetupPicLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 230)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSetupPicLocation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPPicLocation.ResumeLayout(False)
        CType(Me.PC2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PC2.ResumeLayout(False)
        Me.PC2.PerformLayout()
        CType(Me.TEPicLogo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEditIcon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPicMat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPicSample.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPicDesign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EPPicLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPicLocation As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PC2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PictureEditIcon As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BBrowseMat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEPicMat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BBrowseSample As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEPicSample As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelSeason As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BBrowseDesign As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEPicDesign As DevExpress.XtraEditors.TextEdit
    Friend WithEvents EPPicLocation As System.Windows.Forms.ErrorProvider
    Friend WithEvents BBrowseLogo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPicLogo As DevExpress.XtraEditors.TextEdit
End Class
