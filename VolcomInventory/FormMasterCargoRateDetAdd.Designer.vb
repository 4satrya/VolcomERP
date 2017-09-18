<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCargoRateDetAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterCargoRateDetAdd))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TEMinWeight = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TELeadTime = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TERate = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TECargoName = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TEAreaCode = New DevExpress.XtraEditors.TextEdit()
        Me.TEArea = New DevExpress.XtraEditors.TextEdit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEMinWeight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TELeadTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TERate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECargoName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEAreaCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEArea.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "1415351112474759854-32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "icon_merchandise_clothes32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "t_shirtgreen.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "lock red.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "ordering32.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "kghostview.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "MetroUI-Folder-OS-Configure-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(17, "Setting(32).png")
        Me.LargeImageCollection.Images.SetKeyName(18, "estimate_icon32.png")
        Me.LargeImageCollection.Images.SetKeyName(19, "copy_icon.png")
        Me.LargeImageCollection.Images.SetKeyName(20, "pencil.png")
        Me.LargeImageCollection.Images.SetKeyName(21, "edit-validated-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(22, "Delete.png")
        Me.LargeImageCollection.Images.SetKeyName(23, "browse_3.png")
        Me.LargeImageCollection.Images.SetKeyName(24, "Full_Screen.png")
        Me.LargeImageCollection.Images.SetKeyName(25, "Exit_Full_Screen.png")
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BClose)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 194)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(502, 37)
        Me.PanelControl1.TabIndex = 5
        '
        'BClose
        '
        Me.BClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BClose.ImageIndex = 5
        Me.BClose.ImageList = Me.LargeImageCollection
        Me.BClose.Location = New System.Drawing.Point(306, 2)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(97, 33)
        Me.BClose.TabIndex = 112
        Me.BClose.Text = "Close"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.ImageIndex = 7
        Me.BSave.ImageList = Me.LargeImageCollection
        Me.BSave.Location = New System.Drawing.Point(403, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(97, 33)
        Me.BSave.TabIndex = 111
        Me.BSave.Text = "Save"
        '
        'TEMinWeight
        '
        Me.TEMinWeight.Location = New System.Drawing.Point(138, 158)
        Me.TEMinWeight.Name = "TEMinWeight"
        Me.TEMinWeight.Properties.Appearance.Options.UseTextOptions = True
        Me.TEMinWeight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEMinWeight.Properties.Mask.EditMask = "N2"
        Me.TEMinWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEMinWeight.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEMinWeight.Size = New System.Drawing.Size(205, 20)
        Me.TEMinWeight.TabIndex = 124
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Minimum Weight (Kg)"
        '
        'TELeadTime
        '
        Me.TELeadTime.Location = New System.Drawing.Point(138, 123)
        Me.TELeadTime.Name = "TELeadTime"
        Me.TELeadTime.Properties.Appearance.Options.UseTextOptions = True
        Me.TELeadTime.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TELeadTime.Properties.Mask.EditMask = "N2"
        Me.TELeadTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TELeadTime.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TELeadTime.Size = New System.Drawing.Size(205, 20)
        Me.TELeadTime.TabIndex = 122
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Lead Time (days)"
        '
        'TERate
        '
        Me.TERate.Location = New System.Drawing.Point(138, 88)
        Me.TERate.Name = "TERate"
        Me.TERate.Properties.Appearance.Options.UseTextOptions = True
        Me.TERate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TERate.Properties.Mask.EditMask = "N2"
        Me.TERate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TERate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TERate.Size = New System.Drawing.Size(205, 20)
        Me.TERate.TabIndex = 120
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 119
        Me.Label3.Text = "Rate/Kg (Rp)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Cargo"
        '
        'TECargoName
        '
        Me.TECargoName.Location = New System.Drawing.Point(138, 52)
        Me.TECargoName.Name = "TECargoName"
        Me.TECargoName.Properties.ReadOnly = True
        Me.TECargoName.Size = New System.Drawing.Size(349, 20)
        Me.TECargoName.TabIndex = 118
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 115
        Me.Label6.Text = "Area"
        '
        'TEAreaCode
        '
        Me.TEAreaCode.Location = New System.Drawing.Point(138, 16)
        Me.TEAreaCode.Name = "TEAreaCode"
        Me.TEAreaCode.Properties.ReadOnly = True
        Me.TEAreaCode.Size = New System.Drawing.Size(113, 20)
        Me.TEAreaCode.TabIndex = 114
        '
        'TEArea
        '
        Me.TEArea.Location = New System.Drawing.Point(257, 16)
        Me.TEArea.Name = "TEArea"
        Me.TEArea.Properties.ReadOnly = True
        Me.TEArea.Size = New System.Drawing.Size(230, 20)
        Me.TEArea.TabIndex = 116
        '
        'FormMasterCargoRateDetAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 231)
        Me.Controls.Add(Me.TEMinWeight)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TERate)
        Me.Controls.Add(Me.TELeadTime)
        Me.Controls.Add(Me.TEArea)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TEAreaCode)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TECargoName)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCargoRateDetAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Rate"
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.TEMinWeight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TELeadTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TERate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECargoName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEAreaCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEArea.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEMinWeight As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents TELeadTime As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents TERate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TECargoName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents TEAreaCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEArea As DevExpress.XtraEditors.TextEdit
End Class
