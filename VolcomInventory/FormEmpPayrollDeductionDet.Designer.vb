<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayrollDeductionDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollDeductionDet))
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEEmployeeCode = New DevExpress.XtraEditors.TextEdit()
        Me.TEEmployeeName = New DevExpress.XtraEditors.TextEdit()
        Me.BPickEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.LEDeductionType = New DevExpress.XtraEditors.LookUpEdit()
        Me.TEDeduction = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.TEEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEEmployeeName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDeductionType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDeduction.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl16.TabIndex = 137
        Me.LabelControl16.Text = "Employee"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 41)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl1.TabIndex = 138
        Me.LabelControl1.Text = "Deduction Type"
        '
        'TEEmployeeCode
        '
        Me.TEEmployeeCode.EditValue = ""
        Me.TEEmployeeCode.Location = New System.Drawing.Point(112, 12)
        Me.TEEmployeeCode.Name = "TEEmployeeCode"
        Me.TEEmployeeCode.Properties.EditValueChangedDelay = 1
        Me.TEEmployeeCode.Size = New System.Drawing.Size(119, 20)
        Me.TEEmployeeCode.TabIndex = 1
        '
        'TEEmployeeName
        '
        Me.TEEmployeeName.EditValue = ""
        Me.TEEmployeeName.Location = New System.Drawing.Point(237, 12)
        Me.TEEmployeeName.Name = "TEEmployeeName"
        Me.TEEmployeeName.Properties.EditValueChangedDelay = 1
        Me.TEEmployeeName.Properties.ReadOnly = True
        Me.TEEmployeeName.Size = New System.Drawing.Size(262, 20)
        Me.TEEmployeeName.TabIndex = 140
        '
        'BPickEmployee
        '
        Me.BPickEmployee.Location = New System.Drawing.Point(505, 10)
        Me.BPickEmployee.Name = "BPickEmployee"
        Me.BPickEmployee.Size = New System.Drawing.Size(29, 23)
        Me.BPickEmployee.TabIndex = 141
        Me.BPickEmployee.TabStop = False
        Me.BPickEmployee.Text = "..."
        '
        'LEDeductionType
        '
        Me.LEDeductionType.Location = New System.Drawing.Point(112, 38)
        Me.LEDeductionType.Name = "LEDeductionType"
        Me.LEDeductionType.Properties.Appearance.Options.UseTextOptions = True
        Me.LEDeductionType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEDeductionType.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEDeductionType.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LEDeductionType.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEDeductionType.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LEDeductionType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDeductionType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_salary_deduction", "ID Deduction", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("description", "Deduction")})
        Me.LEDeductionType.Properties.NullText = ""
        Me.LEDeductionType.Properties.ShowFooter = False
        Me.LEDeductionType.Size = New System.Drawing.Size(245, 20)
        Me.LEDeductionType.TabIndex = 2
        '
        'TEDeduction
        '
        Me.TEDeduction.EditValue = "1.00"
        Me.TEDeduction.Location = New System.Drawing.Point(112, 64)
        Me.TEDeduction.Name = "TEDeduction"
        Me.TEDeduction.Properties.Appearance.Options.UseTextOptions = True
        Me.TEDeduction.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEDeduction.Properties.EditValueChangedDelay = 1
        Me.TEDeduction.Properties.Mask.EditMask = "N0"
        Me.TEDeduction.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEDeduction.Properties.Mask.SaveLiteral = False
        Me.TEDeduction.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEDeduction.Size = New System.Drawing.Size(207, 20)
        Me.TEDeduction.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 67)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl2.TabIndex = 146
        Me.LabelControl2.Text = "Deduction"
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
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BCancel)
        Me.PanelControl3.Controls.Add(Me.BSave)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 142)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(548, 37)
        Me.PanelControl3.TabIndex = 148
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.ImageIndex = 5
        Me.BCancel.ImageList = Me.LargeImageCollection
        Me.BCancel.Location = New System.Drawing.Point(398, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(73, 33)
        Me.BCancel.TabIndex = 6
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.ImageIndex = 7
        Me.BSave.ImageList = Me.LargeImageCollection
        Me.BSave.Location = New System.Drawing.Point(471, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 33)
        Me.BSave.TabIndex = 5
        Me.BSave.Text = "Save"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(112, 90)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 200
        Me.MENote.Size = New System.Drawing.Size(386, 46)
        Me.MENote.TabIndex = 4
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 92)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl3.TabIndex = 150
        Me.LabelControl3.Text = "Note"
        '
        'FormEmpPayrollDeductionDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 179)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.TEDeduction)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LEDeductionType)
        Me.Controls.Add(Me.BPickEmployee)
        Me.Controls.Add(Me.TEEmployeeCode)
        Me.Controls.Add(Me.TEEmployeeName)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl16)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayrollDeductionDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Deduction Salary"
        CType(Me.TEEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEEmployeeName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDeductionType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDeduction.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEEmployeeCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEEmployeeName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BPickEmployee As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LEDeductionType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TEDeduction As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
