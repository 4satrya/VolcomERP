<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpAttnAssignDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpAttnAssignDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BPropose = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEEmpCode = New DevExpress.XtraEditors.TextEdit()
        Me.TEEmpName = New DevExpress.XtraEditors.TextEdit()
        Me.TEDepartement = New DevExpress.XtraEditors.TextEdit()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.DEDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPBefore = New DevExpress.XtraTab.XtraTabPage()
        Me.GCScheduleBefore = New DevExpress.XtraGrid.GridControl()
        Me.GVScheduleBefore = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTPAfter = New DevExpress.XtraTab.XtraTabPage()
        Me.GCScheduleAfter = New DevExpress.XtraGrid.GridControl()
        Me.GVScheduleAfter = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BViewShift = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.TEEmpCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEEmpName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPBefore.SuspendLayout()
        CType(Me.GCScheduleBefore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVScheduleBefore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPAfter.SuspendLayout()
        CType(Me.GCScheduleAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVScheduleAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BMark)
        Me.PanelControl1.Controls.Add(Me.BCancel)
        Me.PanelControl1.Controls.Add(Me.BPropose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 327)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(689, 36)
        Me.PanelControl1.TabIndex = 2
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.ImageIndex = 4
        Me.BMark.ImageList = Me.LargeImageCollection
        Me.BMark.Location = New System.Drawing.Point(2, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(71, 32)
        Me.BMark.TabIndex = 2
        Me.BMark.Text = "Mark"
        Me.BMark.Visible = False
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
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.ImageIndex = 5
        Me.BCancel.ImageList = Me.LargeImageCollection
        Me.BCancel.Location = New System.Drawing.Point(467, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(81, 32)
        Me.BCancel.TabIndex = 1
        Me.BCancel.Text = "Cancel"
        '
        'BPropose
        '
        Me.BPropose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPropose.ImageIndex = 19
        Me.BPropose.ImageList = Me.LargeImageCollection
        Me.BPropose.Location = New System.Drawing.Point(548, 2)
        Me.BPropose.Name = "BPropose"
        Me.BPropose.Size = New System.Drawing.Size(139, 32)
        Me.BPropose.TabIndex = 0
        Me.BPropose.Text = "Propose Schedule"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.PanelControl3)
        Me.GroupControl1.Controls.Add(Me.TENumber)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.DEDate)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(689, 75)
        Me.GroupControl1.TabIndex = 3
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.LabelControl1)
        Me.PanelControl3.Controls.Add(Me.TEEmpCode)
        Me.PanelControl3.Controls.Add(Me.TEEmpName)
        Me.PanelControl3.Controls.Add(Me.TEDepartement)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl3.Location = New System.Drawing.Point(334, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(353, 71)
        Me.PanelControl3.TabIndex = 101
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl1.TabIndex = 98
        Me.LabelControl1.Text = "Proposed By"
        '
        'TEEmpCode
        '
        Me.TEEmpCode.EditValue = ""
        Me.TEEmpCode.Location = New System.Drawing.Point(81, 12)
        Me.TEEmpCode.Name = "TEEmpCode"
        Me.TEEmpCode.Properties.EditValueChangedDelay = 1
        Me.TEEmpCode.Properties.ReadOnly = True
        Me.TEEmpCode.Size = New System.Drawing.Size(100, 20)
        Me.TEEmpCode.TabIndex = 100
        '
        'TEEmpName
        '
        Me.TEEmpName.EditValue = ""
        Me.TEEmpName.Location = New System.Drawing.Point(187, 12)
        Me.TEEmpName.Name = "TEEmpName"
        Me.TEEmpName.Properties.EditValueChangedDelay = 1
        Me.TEEmpName.Properties.ReadOnly = True
        Me.TEEmpName.Size = New System.Drawing.Size(152, 20)
        Me.TEEmpName.TabIndex = 97
        '
        'TEDepartement
        '
        Me.TEDepartement.EditValue = ""
        Me.TEDepartement.Location = New System.Drawing.Point(81, 38)
        Me.TEDepartement.Name = "TEDepartement"
        Me.TEDepartement.Properties.EditValueChangedDelay = 1
        Me.TEDepartement.Properties.ReadOnly = True
        Me.TEDepartement.Size = New System.Drawing.Size(258, 20)
        Me.TEDepartement.TabIndex = 99
        '
        'TENumber
        '
        Me.TENumber.EditValue = ""
        Me.TENumber.Location = New System.Drawing.Point(111, 12)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.EditValueChangedDelay = 1
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(217, 20)
        Me.TENumber.TabIndex = 95
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(34, 15)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl7.TabIndex = 96
        Me.LabelControl7.Text = "Number"
        '
        'DEDate
        '
        Me.DEDate.EditValue = Nothing
        Me.DEDate.Location = New System.Drawing.Point(111, 41)
        Me.DEDate.Name = "DEDate"
        Me.DEDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDate.Properties.ReadOnly = True
        Me.DEDate.Size = New System.Drawing.Size(217, 20)
        Me.DEDate.TabIndex = 5
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(34, 44)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl4.TabIndex = 94
        Me.LabelControl4.Text = "Date Proposed"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 75)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPBefore
        Me.XtraTabControl1.Size = New System.Drawing.Size(689, 178)
        Me.XtraTabControl1.TabIndex = 4
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBefore, Me.XTPAfter})
        '
        'XTPBefore
        '
        Me.XTPBefore.Controls.Add(Me.GCScheduleBefore)
        Me.XTPBefore.Name = "XTPBefore"
        Me.XTPBefore.Size = New System.Drawing.Size(683, 150)
        Me.XTPBefore.Text = "Before"
        '
        'GCScheduleBefore
        '
        Me.GCScheduleBefore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCScheduleBefore.Location = New System.Drawing.Point(0, 0)
        Me.GCScheduleBefore.MainView = Me.GVScheduleBefore
        Me.GCScheduleBefore.Name = "GCScheduleBefore"
        Me.GCScheduleBefore.Size = New System.Drawing.Size(683, 150)
        Me.GCScheduleBefore.TabIndex = 3
        Me.GCScheduleBefore.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVScheduleBefore})
        '
        'GVScheduleBefore
        '
        Me.GVScheduleBefore.GridControl = Me.GCScheduleBefore
        Me.GVScheduleBefore.Name = "GVScheduleBefore"
        Me.GVScheduleBefore.OptionsView.ColumnAutoWidth = False
        Me.GVScheduleBefore.OptionsView.ShowGroupPanel = False
        '
        'XTPAfter
        '
        Me.XTPAfter.Controls.Add(Me.GCScheduleAfter)
        Me.XTPAfter.Name = "XTPAfter"
        Me.XTPAfter.Size = New System.Drawing.Size(683, 150)
        Me.XTPAfter.Text = "After"
        '
        'GCScheduleAfter
        '
        Me.GCScheduleAfter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCScheduleAfter.Location = New System.Drawing.Point(0, 0)
        Me.GCScheduleAfter.MainView = Me.GVScheduleAfter
        Me.GCScheduleAfter.Name = "GCScheduleAfter"
        Me.GCScheduleAfter.Size = New System.Drawing.Size(683, 150)
        Me.GCScheduleAfter.TabIndex = 3
        Me.GCScheduleAfter.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVScheduleAfter})
        '
        'GVScheduleAfter
        '
        Me.GVScheduleAfter.GridControl = Me.GCScheduleAfter
        Me.GVScheduleAfter.Name = "GVScheduleAfter"
        Me.GVScheduleAfter.OptionsView.ColumnAutoWidth = False
        Me.GVScheduleAfter.OptionsView.ShowGroupPanel = False
        '
        'BViewShift
        '
        Me.BViewShift.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BViewShift.Location = New System.Drawing.Point(0, 253)
        Me.BViewShift.Name = "BViewShift"
        Me.BViewShift.Size = New System.Drawing.Size(689, 23)
        Me.BViewShift.TabIndex = 5
        Me.BViewShift.Text = "View Shift List"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.MENote)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 276)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(689, 51)
        Me.PanelControl2.TabIndex = 6
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 9)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MENote.Location = New System.Drawing.Point(41, 7)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(636, 35)
        Me.MENote.TabIndex = 0
        '
        'FormEmpAttnAssignDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 363)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.BViewShift)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormEmpAttnAssignDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Propose New Schedule"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.TEEmpCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEEmpName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPBefore.ResumeLayout(False)
        CType(Me.GCScheduleBefore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVScheduleBefore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPAfter.ResumeLayout(False)
        CType(Me.GCScheduleAfter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVScheduleAfter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPropose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPBefore As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPAfter As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCScheduleBefore As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVScheduleBefore As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCScheduleAfter As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVScheduleAfter As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TEEmpName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDepartement As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BViewShift As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEEmpCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
End Class
