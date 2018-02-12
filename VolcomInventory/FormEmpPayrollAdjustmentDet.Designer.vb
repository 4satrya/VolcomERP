<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayrollAdjustmentDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollAdjustmentDet))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.TEAdjustment = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LEType = New DevExpress.XtraEditors.LookUpEdit()
        Me.BPickEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.TEEmployeeCode = New DevExpress.XtraEditors.TextEdit()
        Me.TEEmployeeName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.TETHP = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TETotDays = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDepartement = New DevExpress.XtraEditors.TextEdit()
        Me.TETotalWorkdays = New DevExpress.XtraEditors.TextEdit()
        Me.LIncrease = New DevExpress.XtraEditors.LabelControl()
        Me.TEIncrease = New DevExpress.XtraEditors.TextEdit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEAdjustment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEEmployeeName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETHP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETotDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TETotalWorkdays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEIncrease.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BCancel)
        Me.PanelControl3.Controls.Add(Me.BSave)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 221)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(543, 37)
        Me.PanelControl3.TabIndex = 149
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.ImageIndex = 5
        Me.BCancel.ImageList = Me.LargeImageCollection
        Me.BCancel.Location = New System.Drawing.Point(393, 2)
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
        Me.BSave.Location = New System.Drawing.Point(466, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 33)
        Me.BSave.TabIndex = 5
        Me.BSave.Text = "Save"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 167)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl3.TabIndex = 160
        Me.LabelControl3.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(113, 165)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 200
        Me.MENote.Size = New System.Drawing.Size(418, 46)
        Me.MENote.TabIndex = 5
        '
        'TEAdjustment
        '
        Me.TEAdjustment.EditValue = "1.00"
        Me.TEAdjustment.Location = New System.Drawing.Point(112, 139)
        Me.TEAdjustment.Name = "TEAdjustment"
        Me.TEAdjustment.Properties.Appearance.Options.UseTextOptions = True
        Me.TEAdjustment.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEAdjustment.Properties.EditValueChangedDelay = 1
        Me.TEAdjustment.Properties.Mask.EditMask = "N0"
        Me.TEAdjustment.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEAdjustment.Properties.Mask.SaveLiteral = False
        Me.TEAdjustment.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEAdjustment.Properties.ReadOnly = True
        Me.TEAdjustment.Size = New System.Drawing.Size(207, 20)
        Me.TEAdjustment.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 142)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl2.TabIndex = 159
        Me.LabelControl2.Text = "Value"
        '
        'LEType
        '
        Me.LEType.Location = New System.Drawing.Point(112, 87)
        Me.LEType.Name = "LEType"
        Me.LEType.Properties.Appearance.Options.UseTextOptions = True
        Me.LEType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEType.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEType.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LEType.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEType.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LEType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_salary_deduction", "ID Deduction", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("description", "Deduction")})
        Me.LEType.Properties.NullText = ""
        Me.LEType.Properties.ShowFooter = False
        Me.LEType.Size = New System.Drawing.Size(234, 20)
        Me.LEType.TabIndex = 2
        '
        'BPickEmployee
        '
        Me.BPickEmployee.Location = New System.Drawing.Point(505, 7)
        Me.BPickEmployee.Name = "BPickEmployee"
        Me.BPickEmployee.Size = New System.Drawing.Size(29, 23)
        Me.BPickEmployee.TabIndex = 158
        Me.BPickEmployee.TabStop = False
        Me.BPickEmployee.Text = "..."
        '
        'TEEmployeeCode
        '
        Me.TEEmployeeCode.EditValue = ""
        Me.TEEmployeeCode.Location = New System.Drawing.Point(112, 9)
        Me.TEEmployeeCode.Name = "TEEmployeeCode"
        Me.TEEmployeeCode.Properties.EditValueChangedDelay = 1
        Me.TEEmployeeCode.Size = New System.Drawing.Size(119, 20)
        Me.TEEmployeeCode.TabIndex = 1
        '
        'TEEmployeeName
        '
        Me.TEEmployeeName.EditValue = ""
        Me.TEEmployeeName.Location = New System.Drawing.Point(237, 9)
        Me.TEEmployeeName.Name = "TEEmployeeName"
        Me.TEEmployeeName.Properties.EditValueChangedDelay = 1
        Me.TEEmployeeName.Properties.ReadOnly = True
        Me.TEEmployeeName.Size = New System.Drawing.Size(262, 20)
        Me.TEEmployeeName.TabIndex = 157
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 90)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 156
        Me.LabelControl1.Text = "Type"
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl16.TabIndex = 155
        Me.LabelControl16.Text = "Employee"
        '
        'TETHP
        '
        Me.TETHP.EditValue = "1.00"
        Me.TETHP.Location = New System.Drawing.Point(112, 61)
        Me.TETHP.Name = "TETHP"
        Me.TETHP.Properties.Appearance.Options.UseTextOptions = True
        Me.TETHP.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TETHP.Properties.EditValueChangedDelay = 1
        Me.TETHP.Properties.Mask.EditMask = "N0"
        Me.TETHP.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TETHP.Properties.Mask.SaveLiteral = False
        Me.TETHP.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TETHP.Properties.ReadOnly = True
        Me.TETHP.Size = New System.Drawing.Size(197, 20)
        Me.TETHP.TabIndex = 161
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 64)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl4.TabIndex = 162
        Me.LabelControl4.Text = "Total THP"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(13, 116)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl5.TabIndex = 163
        Me.LabelControl5.Text = "Total days"
        '
        'TETotDays
        '
        Me.TETotDays.EditValue = "1.00"
        Me.TETotDays.Location = New System.Drawing.Point(112, 113)
        Me.TETotDays.Name = "TETotDays"
        Me.TETotDays.Properties.Appearance.Options.UseTextOptions = True
        Me.TETotDays.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TETotDays.Properties.EditValueChangedDelay = 1
        Me.TETotDays.Properties.Mask.EditMask = "N2"
        Me.TETotDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TETotDays.Properties.Mask.SaveLiteral = False
        Me.TETotDays.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TETotDays.Size = New System.Drawing.Size(207, 20)
        Me.TETotDays.TabIndex = 3
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(340, 38)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl6.TabIndex = 164
        Me.LabelControl6.Text = "Total Workdays"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(12, 38)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl7.TabIndex = 165
        Me.LabelControl7.Text = "Departement"
        '
        'TEDepartement
        '
        Me.TEDepartement.EditValue = ""
        Me.TEDepartement.Location = New System.Drawing.Point(112, 35)
        Me.TEDepartement.Name = "TEDepartement"
        Me.TEDepartement.Properties.EditValueChangedDelay = 1
        Me.TEDepartement.Properties.ReadOnly = True
        Me.TEDepartement.Size = New System.Drawing.Size(222, 20)
        Me.TEDepartement.TabIndex = 166
        '
        'TETotalWorkdays
        '
        Me.TETotalWorkdays.EditValue = "1.00"
        Me.TETotalWorkdays.Location = New System.Drawing.Point(421, 35)
        Me.TETotalWorkdays.Name = "TETotalWorkdays"
        Me.TETotalWorkdays.Properties.Appearance.Options.UseTextOptions = True
        Me.TETotalWorkdays.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TETotalWorkdays.Properties.EditValueChangedDelay = 1
        Me.TETotalWorkdays.Properties.Mask.EditMask = "N2"
        Me.TETotalWorkdays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TETotalWorkdays.Properties.Mask.SaveLiteral = False
        Me.TETotalWorkdays.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TETotalWorkdays.Properties.ReadOnly = True
        Me.TETotalWorkdays.Size = New System.Drawing.Size(110, 20)
        Me.TETotalWorkdays.TabIndex = 167
        '
        'LIncrease
        '
        Me.LIncrease.Location = New System.Drawing.Point(352, 90)
        Me.LIncrease.Name = "LIncrease"
        Me.LIncrease.Size = New System.Drawing.Size(42, 13)
        Me.LIncrease.TabIndex = 168
        Me.LIncrease.Text = "Increase"
        '
        'TEIncrease
        '
        Me.TEIncrease.EditValue = "0"
        Me.TEIncrease.Location = New System.Drawing.Point(400, 87)
        Me.TEIncrease.Name = "TEIncrease"
        Me.TEIncrease.Properties.Appearance.Options.UseTextOptions = True
        Me.TEIncrease.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEIncrease.Properties.EditValueChangedDelay = 1
        Me.TEIncrease.Properties.Mask.EditMask = "N0"
        Me.TEIncrease.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEIncrease.Properties.Mask.SaveLiteral = False
        Me.TEIncrease.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEIncrease.Size = New System.Drawing.Size(131, 20)
        Me.TEIncrease.TabIndex = 169
        '
        'FormEmpPayrollAdjustmentDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 258)
        Me.Controls.Add(Me.TEIncrease)
        Me.Controls.Add(Me.LIncrease)
        Me.Controls.Add(Me.TETotalWorkdays)
        Me.Controls.Add(Me.TEDepartement)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.TETotDays)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.TETHP)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.MENote)
        Me.Controls.Add(Me.TEAdjustment)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LEType)
        Me.Controls.Add(Me.BPickEmployee)
        Me.Controls.Add(Me.TEEmployeeCode)
        Me.Controls.Add(Me.TEEmployeeName)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl16)
        Me.Controls.Add(Me.PanelControl3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayrollAdjustmentDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Bonus / Adjustment"
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEAdjustment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEEmployeeName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETHP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETotDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TETotalWorkdays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEIncrease.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TEAdjustment As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BPickEmployee As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEEmployeeCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEEmployeeName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TETHP As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TETotDays As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDepartement As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TETotalWorkdays As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LIncrease As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEIncrease As DevExpress.XtraEditors.TextEdit
End Class
