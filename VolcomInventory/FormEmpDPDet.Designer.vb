﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpDPDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpDPDet))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TEEmployeeCode = New DevExpress.XtraEditors.TextEdit()
        Me.BPickEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.TEDept = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPosition = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEEmployeeName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.TETotHour = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MemoEdit1 = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.DEDateCreated = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEEmployeeName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.TETotHour.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDateCreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDateCreated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.DEDateCreated)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.TENumber)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.TEEmployeeCode)
        Me.GroupControl1.Controls.Add(Me.BPickEmployee)
        Me.GroupControl1.Controls.Add(Me.TEDept)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.TEPosition)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.TEEmployeeName)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(640, 96)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Employee"
        '
        'TENumber
        '
        Me.TENumber.EditValue = ""
        Me.TENumber.Location = New System.Drawing.Point(128, 10)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.EditValueChangedDelay = 1
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(209, 20)
        Me.TENumber.TabIndex = 95
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(34, 13)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl7.TabIndex = 96
        Me.LabelControl7.Text = "Number"
        '
        'TEEmployeeCode
        '
        Me.TEEmployeeCode.EditValue = ""
        Me.TEEmployeeCode.Location = New System.Drawing.Point(128, 36)
        Me.TEEmployeeCode.Name = "TEEmployeeCode"
        Me.TEEmployeeCode.Properties.EditValueChangedDelay = 1
        Me.TEEmployeeCode.Size = New System.Drawing.Size(119, 20)
        Me.TEEmployeeCode.TabIndex = 1
        '
        'BPickEmployee
        '
        Me.BPickEmployee.Location = New System.Drawing.Point(583, 34)
        Me.BPickEmployee.Name = "BPickEmployee"
        Me.BPickEmployee.Size = New System.Drawing.Size(29, 23)
        Me.BPickEmployee.TabIndex = 0
        Me.BPickEmployee.Text = "..."
        '
        'TEDept
        '
        Me.TEDept.EditValue = ""
        Me.TEDept.Location = New System.Drawing.Point(128, 62)
        Me.TEDept.Name = "TEDept"
        Me.TEDept.Properties.EditValueChangedDelay = 1
        Me.TEDept.Properties.ReadOnly = True
        Me.TEDept.Size = New System.Drawing.Size(217, 20)
        Me.TEDept.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(34, 65)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl2.TabIndex = 92
        Me.LabelControl2.Text = "Departement"
        '
        'TEPosition
        '
        Me.TEPosition.EditValue = ""
        Me.TEPosition.Location = New System.Drawing.Point(394, 62)
        Me.TEPosition.Name = "TEPosition"
        Me.TEPosition.Properties.EditValueChangedDelay = 1
        Me.TEPosition.Properties.ReadOnly = True
        Me.TEPosition.Size = New System.Drawing.Size(218, 20)
        Me.TEPosition.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(351, 65)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl1.TabIndex = 90
        Me.LabelControl1.Text = "Position"
        '
        'TEEmployeeName
        '
        Me.TEEmployeeName.EditValue = ""
        Me.TEEmployeeName.Location = New System.Drawing.Point(253, 36)
        Me.TEEmployeeName.Name = "TEEmployeeName"
        Me.TEEmployeeName.Properties.EditValueChangedDelay = 1
        Me.TEEmployeeName.Properties.ReadOnly = True
        Me.TEEmployeeName.Size = New System.Drawing.Size(324, 20)
        Me.TEEmployeeName.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(35, 39)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl3.TabIndex = 88
        Me.LabelControl3.Text = "Employee"
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
        Me.PanelControl3.Controls.Add(Me.BPrint)
        Me.PanelControl3.Controls.Add(Me.BMark)
        Me.PanelControl3.Controls.Add(Me.BCancel)
        Me.PanelControl3.Controls.Add(Me.BSave)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 241)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(640, 37)
        Me.PanelControl3.TabIndex = 5
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.ImageIndex = 6
        Me.BPrint.ImageList = Me.LargeImageCollection
        Me.BPrint.Location = New System.Drawing.Point(417, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(73, 33)
        Me.BPrint.TabIndex = 3
        Me.BPrint.Text = "Print"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.ImageIndex = 4
        Me.BMark.ImageList = Me.LargeImageCollection
        Me.BMark.Location = New System.Drawing.Point(2, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(73, 33)
        Me.BMark.TabIndex = 2
        Me.BMark.Text = "Mark"
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.ImageIndex = 5
        Me.BCancel.ImageList = Me.LargeImageCollection
        Me.BCancel.Location = New System.Drawing.Point(490, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(73, 33)
        Me.BCancel.TabIndex = 1
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.ImageIndex = 7
        Me.BSave.ImageList = Me.LargeImageCollection
        Me.BSave.Location = New System.Drawing.Point(563, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 33)
        Me.BSave.TabIndex = 0
        Me.BSave.Text = "Save"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.LabelControl8)
        Me.GroupControl2.Controls.Add(Me.TETotHour)
        Me.GroupControl2.Controls.Add(Me.LabelControl4)
        Me.GroupControl2.Controls.Add(Me.DEUntil)
        Me.GroupControl2.Controls.Add(Me.Label3)
        Me.GroupControl2.Controls.Add(Me.DEStart)
        Me.GroupControl2.Controls.Add(Me.Label4)
        Me.GroupControl2.Controls.Add(Me.MemoEdit1)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 96)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(640, 145)
        Me.GroupControl2.TabIndex = 6
        Me.GroupControl2.Text = "DP"
        '
        'TETotHour
        '
        Me.TETotHour.EditValue = ""
        Me.TETotHour.Location = New System.Drawing.Point(128, 107)
        Me.TETotHour.Name = "TETotHour"
        Me.TETotHour.Properties.EditValueChangedDelay = 1
        Me.TETotHour.Properties.ReadOnly = True
        Me.TETotHour.Size = New System.Drawing.Size(153, 20)
        Me.TETotHour.TabIndex = 106
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(34, 110)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl4.TabIndex = 107
        Me.LabelControl4.Text = "Total"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(402, 74)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy hh:mm:ss tt"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd-MM-yyyy/H"
        Me.DEUntil.Size = New System.Drawing.Size(210, 20)
        Me.DEUntil.TabIndex = 105
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(358, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Until : "
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(128, 74)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy hh:mm:ss tt"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Properties.Mask.EditMask = "dd-MM-yyyy/H"
        Me.DEStart.Size = New System.Drawing.Size(224, 20)
        Me.DEStart.TabIndex = 103
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Periode"
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Location = New System.Drawing.Point(128, 16)
        Me.MemoEdit1.Name = "MemoEdit1"
        Me.MemoEdit1.Properties.MaxLength = 200
        Me.MemoEdit1.Size = New System.Drawing.Size(484, 46)
        Me.MemoEdit1.TabIndex = 101
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(34, 18)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl5.TabIndex = 99
        Me.LabelControl5.Text = "DP Note"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(351, 13)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl6.TabIndex = 97
        Me.LabelControl6.Text = "Date"
        '
        'DEDateCreated
        '
        Me.DEDateCreated.EditValue = Nothing
        Me.DEDateCreated.Location = New System.Drawing.Point(394, 10)
        Me.DEDateCreated.Name = "DEDateCreated"
        Me.DEDateCreated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateCreated.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateCreated.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEDateCreated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDateCreated.Size = New System.Drawing.Size(218, 20)
        Me.DEDateCreated.TabIndex = 98
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(287, 110)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl8.TabIndex = 108
        Me.LabelControl8.Text = "Hour(s)"
        '
        'FormEmpDPDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 278)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpDPDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail DP"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEEmployeeName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.TETotHour.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDateCreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDateCreated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEEmployeeCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BPickEmployee As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEDept As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPosition As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEEmployeeName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TETotHour As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEDateCreated As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
End Class
