<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpDPPick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpDPPick))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntilDP = New DevExpress.XtraEditors.DateEdit()
        Me.Luntil = New System.Windows.Forms.Label()
        Me.DEStartDP = New DevExpress.XtraEditors.DateEdit()
        Me.LPropose = New System.Windows.Forms.Label()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TETotHour = New DevExpress.XtraEditors.TextEdit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEUntilDP.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilDP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStartDP.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStartDP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETotHour.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BCancel)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 120)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(413, 36)
        Me.PanelControl1.TabIndex = 1
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.ImageIndex = 5
        Me.BCancel.ImageList = Me.LargeImageCollection
        Me.BCancel.Location = New System.Drawing.Point(263, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(73, 32)
        Me.BCancel.TabIndex = 3
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.ImageIndex = 19
        Me.BSave.ImageList = Me.LargeImageCollection
        Me.BSave.Location = New System.Drawing.Point(336, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 32)
        Me.BSave.TabIndex = 2
        Me.BSave.Text = "Insert"
        '
        'DEUntilDP
        '
        Me.DEUntilDP.EditValue = Nothing
        Me.DEUntilDP.Location = New System.Drawing.Point(242, 10)
        Me.DEUntilDP.Name = "DEUntilDP"
        Me.DEUntilDP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilDP.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.DEUntilDP.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilDP.Properties.DisplayFormat.FormatString = "dd MMM yyyy hh:mm:ss tt"
        Me.DEUntilDP.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilDP.Properties.Mask.EditMask = "dd-MM-yyyy/H"
        Me.DEUntilDP.Size = New System.Drawing.Size(153, 20)
        Me.DEUntilDP.TabIndex = 21
        '
        'Luntil
        '
        Me.Luntil.AutoSize = True
        Me.Luntil.Location = New System.Drawing.Point(225, 13)
        Me.Luntil.Name = "Luntil"
        Me.Luntil.Size = New System.Drawing.Size(11, 13)
        Me.Luntil.TabIndex = 20
        Me.Luntil.Text = "-"
        '
        'DEStartDP
        '
        Me.DEStartDP.EditValue = Nothing
        Me.DEStartDP.Location = New System.Drawing.Point(68, 10)
        Me.DEStartDP.Name = "DEStartDP"
        Me.DEStartDP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStartDP.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.DEStartDP.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStartDP.Properties.DisplayFormat.FormatString = "dd MMM yyyy hh:mm:ss tt"
        Me.DEStartDP.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStartDP.Properties.Mask.EditMask = "dd-MM-yyyy/H"
        Me.DEStartDP.Size = New System.Drawing.Size(151, 20)
        Me.DEStartDP.TabIndex = 19
        '
        'LPropose
        '
        Me.LPropose.AutoSize = True
        Me.LPropose.Location = New System.Drawing.Point(12, 13)
        Me.LPropose.Name = "LPropose"
        Me.LPropose.Size = New System.Drawing.Size(33, 13)
        Me.LPropose.TabIndex = 18
        Me.LPropose.Text = "Date "
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(68, 62)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 200
        Me.MENote.Size = New System.Drawing.Size(327, 46)
        Me.MENote.TabIndex = 103
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(15, 64)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl6.TabIndex = 102
        Me.LabelControl6.Text = "Note"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Total DP"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(146, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Hour(s)"
        '
        'TETotHour
        '
        Me.TETotHour.EditValue = ""
        Me.TETotHour.Location = New System.Drawing.Point(68, 36)
        Me.TETotHour.Name = "TETotHour"
        Me.TETotHour.Properties.Appearance.Options.UseTextOptions = True
        Me.TETotHour.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TETotHour.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.TETotHour.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TETotHour.Properties.DisplayFormat.FormatString = "N0"
        Me.TETotHour.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TETotHour.Properties.EditValueChangedDelay = 1
        Me.TETotHour.Properties.ReadOnly = True
        Me.TETotHour.Size = New System.Drawing.Size(72, 20)
        Me.TETotHour.TabIndex = 106
        '
        'FormEmpDPPick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 156)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TETotHour)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.DEUntilDP)
        Me.Controls.Add(Me.Luntil)
        Me.Controls.Add(Me.DEStartDP)
        Me.Controls.Add(Me.LPropose)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpDPPick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Date DP"
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.DEUntilDP.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilDP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStartDP.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStartDP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETotHour.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntilDP As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Luntil As Label
    Friend WithEvents DEStartDP As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LPropose As Label
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TETotHour As DevExpress.XtraEditors.TextEdit
End Class
