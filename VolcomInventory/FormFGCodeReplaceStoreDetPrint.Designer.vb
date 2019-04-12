<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGCodeReplaceStoreDetPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGCodeReplaceStoreDetPrint))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BClose = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BSetHeightError = New DevExpress.XtraEditors.SimpleButton()
        Me.TEHeightError = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LEPrinter = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BSetHorizontalError = New DevExpress.XtraEditors.SimpleButton()
        Me.TEHorizontalError = New DevExpress.XtraEditors.TextEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEHeightError.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEPrinter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEHorizontalError.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BClose)
        Me.PanelControl1.Controls.Add(Me.BPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 103)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(387, 39)
        Me.PanelControl1.TabIndex = 0
        '
        'BClose
        '
        Me.BClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BClose.ImageIndex = 5
        Me.BClose.ImageList = Me.LargeImageCollection
        Me.BClose.Location = New System.Drawing.Point(187, 2)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(99, 35)
        Me.BClose.TabIndex = 1
        Me.BClose.Text = "Cancel"
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
        Me.LargeImageCollection.Images.SetKeyName(10, "10_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "18_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "31_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "folder-documents-icon.png")
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.ImageIndex = 6
        Me.BPrint.ImageList = Me.LargeImageCollection
        Me.BPrint.Location = New System.Drawing.Point(286, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(99, 35)
        Me.BPrint.TabIndex = 0
        Me.BPrint.Text = "Print"
        '
        'BSetHeightError
        '
        Me.BSetHeightError.Location = New System.Drawing.Point(307, 40)
        Me.BSetHeightError.Name = "BSetHeightError"
        Me.BSetHeightError.Size = New System.Drawing.Size(63, 23)
        Me.BSetHeightError.TabIndex = 173
        Me.BSetHeightError.Text = "Set"
        '
        'TEHeightError
        '
        Me.TEHeightError.EditValue = ""
        Me.TEHeightError.Location = New System.Drawing.Point(101, 42)
        Me.TEHeightError.Name = "TEHeightError"
        Me.TEHeightError.Properties.EditValueChangedDelay = 1
        Me.TEHeightError.Size = New System.Drawing.Size(200, 20)
        Me.TEHeightError.TabIndex = 172
        Me.TEHeightError.TabStop = False
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LabelControl13.Location = New System.Drawing.Point(12, 18)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(36, 14)
        Me.LabelControl13.TabIndex = 171
        Me.LabelControl13.Text = "Printer"
        '
        'LEPrinter
        '
        Me.LEPrinter.Location = New System.Drawing.Point(101, 16)
        Me.LEPrinter.Name = "LEPrinter"
        Me.LEPrinter.Properties.Appearance.Options.UseTextOptions = True
        Me.LEPrinter.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEPrinter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPrinter.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_printer_barcode", "Id Printer", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("printer_barcode", "Printer")})
        Me.LEPrinter.Properties.NullText = ""
        Me.LEPrinter.Properties.ShowFooter = False
        Me.LEPrinter.Size = New System.Drawing.Size(159, 20)
        Me.LEPrinter.TabIndex = 170
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(12, 44)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(66, 14)
        Me.LabelControl1.TabIndex = 174
        Me.LabelControl1.Text = "Height Error"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LabelControl2.Location = New System.Drawing.Point(12, 70)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(83, 14)
        Me.LabelControl2.TabIndex = 177
        Me.LabelControl2.Text = "Horizontal Error"
        '
        'BSetHorizontalError
        '
        Me.BSetHorizontalError.Location = New System.Drawing.Point(307, 66)
        Me.BSetHorizontalError.Name = "BSetHorizontalError"
        Me.BSetHorizontalError.Size = New System.Drawing.Size(63, 23)
        Me.BSetHorizontalError.TabIndex = 176
        Me.BSetHorizontalError.Text = "Set"
        '
        'TEHorizontalError
        '
        Me.TEHorizontalError.EditValue = ""
        Me.TEHorizontalError.Location = New System.Drawing.Point(101, 68)
        Me.TEHorizontalError.Name = "TEHorizontalError"
        Me.TEHorizontalError.Properties.EditValueChangedDelay = 1
        Me.TEHorizontalError.Size = New System.Drawing.Size(200, 20)
        Me.TEHorizontalError.TabIndex = 175
        Me.TEHorizontalError.TabStop = False
        '
        'FormFGCodeReplaceStoreDetPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 142)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.BSetHorizontalError)
        Me.Controls.Add(Me.TEHorizontalError)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.BSetHeightError)
        Me.Controls.Add(Me.TEHeightError)
        Me.Controls.Add(Me.LabelControl13)
        Me.Controls.Add(Me.LEPrinter)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFGCodeReplaceStoreDetPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Code Replace"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEHeightError.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEPrinter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEHorizontalError.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BSetHeightError As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEHeightError As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEPrinter As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BSetHorizontalError As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEHorizontalError As DevExpress.XtraEditors.TextEdit
End Class
