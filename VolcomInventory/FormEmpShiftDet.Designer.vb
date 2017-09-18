<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpShiftDet
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
        Me.TEShiftName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.TEShiftCode = New DevExpress.XtraEditors.TextEdit()
        Me.TEWorkStart = New DevExpress.XtraEditors.TimeEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TEWorkEnd = New DevExpress.XtraEditors.TimeEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TEBreakEnd = New DevExpress.XtraEditors.TimeEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TEBreakStart = New DevExpress.XtraEditors.TimeEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TEMinutes = New DevExpress.XtraEditors.TextEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.CEHoliday = New DevExpress.XtraEditors.CheckEdit()
        Me.CEEndNext = New DevExpress.XtraEditors.CheckEdit()
        Me.CETolNext = New DevExpress.XtraEditors.CheckEdit()
        Me.CEStartNext = New DevExpress.XtraEditors.CheckEdit()
        Me.TEWorkStartTol = New DevExpress.XtraEditors.TimeEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.CESaturday = New DevExpress.XtraEditors.CheckEdit()
        Me.CEFriday = New DevExpress.XtraEditors.CheckEdit()
        Me.CEThursday = New DevExpress.XtraEditors.CheckEdit()
        Me.CEWednesday = New DevExpress.XtraEditors.CheckEdit()
        Me.CETuesday = New DevExpress.XtraEditors.CheckEdit()
        Me.CEMonday = New DevExpress.XtraEditors.CheckEdit()
        Me.CESunday = New DevExpress.XtraEditors.CheckEdit()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TEEndTolerance = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.TEShiftName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEShiftCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEWorkStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEWorkEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEBreakEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEBreakStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEMinutes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.CEHoliday.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEEndNext.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CETolNext.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEStartNext.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEWorkStartTol.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CESaturday.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEFriday.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEThursday.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEWednesday.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CETuesday.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEMonday.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CESunday.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.TEEndTolerance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TEShiftName
        '
        Me.TEShiftName.Location = New System.Drawing.Point(97, 14)
        Me.TEShiftName.Name = "TEShiftName"
        Me.TEShiftName.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TEShiftName.Properties.Appearance.Options.UseFont = True
        Me.TEShiftName.Size = New System.Drawing.Size(370, 22)
        Me.TEShiftName.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.LabelControl1.Location = New System.Drawing.Point(12, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 16)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Shift Name"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl8)
        Me.PanelControl1.Controls.Add(Me.TEShiftCode)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.TEShiftName)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(492, 73)
        Me.PanelControl1.TabIndex = 2
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.LabelControl8.Location = New System.Drawing.Point(12, 45)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(59, 16)
        Me.LabelControl8.TabIndex = 3
        Me.LabelControl8.Text = "Shift Code"
        '
        'TEShiftCode
        '
        Me.TEShiftCode.Location = New System.Drawing.Point(97, 42)
        Me.TEShiftCode.Name = "TEShiftCode"
        Me.TEShiftCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TEShiftCode.Properties.Appearance.Options.UseFont = True
        Me.TEShiftCode.Size = New System.Drawing.Size(268, 22)
        Me.TEShiftCode.TabIndex = 1
        '
        'TEWorkStart
        '
        Me.TEWorkStart.EditValue = New Date(2016, 8, 30, 0, 0, 0, 0)
        Me.TEWorkStart.Location = New System.Drawing.Point(97, 11)
        Me.TEWorkStart.Name = "TEWorkStart"
        Me.TEWorkStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEWorkStart.Properties.Mask.EditMask = "HH:mm:ss"
        Me.TEWorkStart.Size = New System.Drawing.Size(100, 20)
        Me.TEWorkStart.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 14)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Start Working"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 72)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "End Working"
        '
        'TEWorkEnd
        '
        Me.TEWorkEnd.EditValue = New Date(2016, 8, 30, 0, 0, 0, 0)
        Me.TEWorkEnd.Location = New System.Drawing.Point(97, 69)
        Me.TEWorkEnd.Name = "TEWorkEnd"
        Me.TEWorkEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEWorkEnd.Properties.Mask.EditMask = "HH:mm:ss"
        Me.TEWorkEnd.Size = New System.Drawing.Size(100, 20)
        Me.TEWorkEnd.TabIndex = 6
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 152)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl4.TabIndex = 10
        Me.LabelControl4.Text = "End Break Time"
        '
        'TEBreakEnd
        '
        Me.TEBreakEnd.EditValue = New Date(2016, 8, 30, 0, 0, 0, 0)
        Me.TEBreakEnd.Location = New System.Drawing.Point(97, 149)
        Me.TEBreakEnd.Name = "TEBreakEnd"
        Me.TEBreakEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEBreakEnd.Properties.Mask.EditMask = "HH:mm:ss"
        Me.TEBreakEnd.Size = New System.Drawing.Size(100, 20)
        Me.TEBreakEnd.TabIndex = 9
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 126)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl5.TabIndex = 8
        Me.LabelControl5.Text = "Start Break Time"
        '
        'TEBreakStart
        '
        Me.TEBreakStart.EditValue = New Date(2016, 8, 30, 0, 0, 0, 0)
        Me.TEBreakStart.Location = New System.Drawing.Point(97, 123)
        Me.TEBreakStart.Name = "TEBreakStart"
        Me.TEBreakStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEBreakStart.Properties.Mask.EditMask = "HH:mm:ss"
        Me.TEBreakStart.Size = New System.Drawing.Size(100, 20)
        Me.TEBreakStart.TabIndex = 8
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 180)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "Minutes Working"
        '
        'TEMinutes
        '
        Me.TEMinutes.Location = New System.Drawing.Point(97, 175)
        Me.TEMinutes.Name = "TEMinutes"
        Me.TEMinutes.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TEMinutes.Properties.Appearance.Options.UseFont = True
        Me.TEMinutes.Size = New System.Drawing.Size(268, 22)
        Me.TEMinutes.TabIndex = 10
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LabelControl10)
        Me.PanelControl2.Controls.Add(Me.TEEndTolerance)
        Me.PanelControl2.Controls.Add(Me.LabelControl9)
        Me.PanelControl2.Controls.Add(Me.CEHoliday)
        Me.PanelControl2.Controls.Add(Me.CEEndNext)
        Me.PanelControl2.Controls.Add(Me.CETolNext)
        Me.PanelControl2.Controls.Add(Me.CEStartNext)
        Me.PanelControl2.Controls.Add(Me.TEWorkStartTol)
        Me.PanelControl2.Controls.Add(Me.LabelControl7)
        Me.PanelControl2.Controls.Add(Me.CESaturday)
        Me.PanelControl2.Controls.Add(Me.CEFriday)
        Me.PanelControl2.Controls.Add(Me.CEThursday)
        Me.PanelControl2.Controls.Add(Me.CEWednesday)
        Me.PanelControl2.Controls.Add(Me.CETuesday)
        Me.PanelControl2.Controls.Add(Me.CEMonday)
        Me.PanelControl2.Controls.Add(Me.CESunday)
        Me.PanelControl2.Controls.Add(Me.TEWorkStart)
        Me.PanelControl2.Controls.Add(Me.TEMinutes)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.LabelControl6)
        Me.PanelControl2.Controls.Add(Me.TEWorkEnd)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.TEBreakEnd)
        Me.PanelControl2.Controls.Add(Me.TEBreakStart)
        Me.PanelControl2.Controls.Add(Me.LabelControl5)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 73)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(492, 218)
        Me.PanelControl2.TabIndex = 13
        '
        'CEHoliday
        '
        Me.CEHoliday.Location = New System.Drawing.Point(383, 186)
        Me.CEHoliday.Name = "CEHoliday"
        Me.CEHoliday.Properties.Caption = "Ignore Holiday"
        Me.CEHoliday.Size = New System.Drawing.Size(97, 19)
        Me.CEHoliday.TabIndex = 18
        '
        'CEEndNext
        '
        Me.CEEndNext.Location = New System.Drawing.Point(203, 69)
        Me.CEEndNext.Name = "CEEndNext"
        Me.CEEndNext.Properties.Caption = "Day After"
        Me.CEEndNext.Size = New System.Drawing.Size(75, 19)
        Me.CEEndNext.TabIndex = 7
        '
        'CETolNext
        '
        Me.CETolNext.Location = New System.Drawing.Point(203, 37)
        Me.CETolNext.Name = "CETolNext"
        Me.CETolNext.Properties.Caption = "Day Before"
        Me.CETolNext.Size = New System.Drawing.Size(75, 19)
        Me.CETolNext.TabIndex = 5
        '
        'CEStartNext
        '
        Me.CEStartNext.Location = New System.Drawing.Point(203, 11)
        Me.CEStartNext.Name = "CEStartNext"
        Me.CEStartNext.Properties.Caption = "Day Before"
        Me.CEStartNext.Size = New System.Drawing.Size(75, 19)
        Me.CEStartNext.TabIndex = 3
        '
        'TEWorkStartTol
        '
        Me.TEWorkStartTol.EditValue = New Date(2016, 8, 30, 0, 0, 0, 0)
        Me.TEWorkStartTol.Location = New System.Drawing.Point(97, 37)
        Me.TEWorkStartTol.Name = "TEWorkStartTol"
        Me.TEWorkStartTol.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TEWorkStartTol.Properties.Mask.EditMask = "HH:mm:ss"
        Me.TEWorkStartTol.Size = New System.Drawing.Size(100, 20)
        Me.TEWorkStartTol.TabIndex = 4
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(12, 40)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl7.TabIndex = 21
        Me.LabelControl7.Text = "Tolerance"
        '
        'CESaturday
        '
        Me.CESaturday.Location = New System.Drawing.Point(383, 161)
        Me.CESaturday.Name = "CESaturday"
        Me.CESaturday.Properties.Caption = "Saturday"
        Me.CESaturday.Size = New System.Drawing.Size(75, 19)
        Me.CESaturday.TabIndex = 17
        '
        'CEFriday
        '
        Me.CEFriday.Location = New System.Drawing.Point(383, 136)
        Me.CEFriday.Name = "CEFriday"
        Me.CEFriday.Properties.Caption = "Friday"
        Me.CEFriday.Size = New System.Drawing.Size(75, 19)
        Me.CEFriday.TabIndex = 16
        '
        'CEThursday
        '
        Me.CEThursday.Location = New System.Drawing.Point(383, 111)
        Me.CEThursday.Name = "CEThursday"
        Me.CEThursday.Properties.Caption = "Thursday"
        Me.CEThursday.Size = New System.Drawing.Size(75, 19)
        Me.CEThursday.TabIndex = 15
        '
        'CEWednesday
        '
        Me.CEWednesday.Location = New System.Drawing.Point(383, 86)
        Me.CEWednesday.Name = "CEWednesday"
        Me.CEWednesday.Properties.Caption = "Wednesday"
        Me.CEWednesday.Size = New System.Drawing.Size(84, 19)
        Me.CEWednesday.TabIndex = 14
        '
        'CETuesday
        '
        Me.CETuesday.Location = New System.Drawing.Point(383, 61)
        Me.CETuesday.Name = "CETuesday"
        Me.CETuesday.Properties.Caption = "Tuesday"
        Me.CETuesday.Size = New System.Drawing.Size(75, 19)
        Me.CETuesday.TabIndex = 13
        '
        'CEMonday
        '
        Me.CEMonday.Location = New System.Drawing.Point(383, 36)
        Me.CEMonday.Name = "CEMonday"
        Me.CEMonday.Properties.Caption = "Monday"
        Me.CEMonday.Size = New System.Drawing.Size(75, 19)
        Me.CEMonday.TabIndex = 12
        '
        'CESunday
        '
        Me.CESunday.Location = New System.Drawing.Point(383, 11)
        Me.CESunday.Name = "CESunday"
        Me.CESunday.Properties.Caption = "Sunday"
        Me.CESunday.Size = New System.Drawing.Size(75, 19)
        Me.CESunday.TabIndex = 11
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BCancel)
        Me.PanelControl3.Controls.Add(Me.BSave)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 291)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(492, 41)
        Me.PanelControl3.TabIndex = 14
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Location = New System.Drawing.Point(340, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(75, 37)
        Me.BCancel.TabIndex = 20
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Location = New System.Drawing.Point(415, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 37)
        Me.BSave.TabIndex = 19
        Me.BSave.Text = "Save"
        '
        'TEEndTolerance
        '
        Me.TEEndTolerance.Location = New System.Drawing.Point(97, 95)
        Me.TEEndTolerance.Name = "TEEndTolerance"
        Me.TEEndTolerance.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TEEndTolerance.Properties.Appearance.Options.UseFont = True
        Me.TEEndTolerance.Size = New System.Drawing.Size(165, 22)
        Me.TEEndTolerance.TabIndex = 22
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(12, 100)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl9.TabIndex = 23
        Me.LabelControl9.Text = "End Tolerance"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(268, 100)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl10.TabIndex = 24
        Me.LabelControl10.Text = "Minutes"
        '
        'FormEmpShiftDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 332)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpShiftDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Shift"
        CType(Me.TEShiftName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TEShiftCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEWorkStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEWorkEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEBreakEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEBreakStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEMinutes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.CEHoliday.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEEndNext.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CETolNext.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEStartNext.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEWorkStartTol.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CESaturday.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEFriday.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEThursday.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEWednesday.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CETuesday.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEMonday.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CESunday.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.TEEndTolerance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TEShiftName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEWorkStart As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEWorkEnd As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEBreakEnd As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEBreakStart As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEMinutes As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CESaturday As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CEFriday As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CEThursday As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CEWednesday As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CETuesday As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CEMonday As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CESunday As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TEWorkStartTol As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CETolNext As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CEStartNext As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CEEndNext As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CEHoliday As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEShiftCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEEndTolerance As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
End Class
