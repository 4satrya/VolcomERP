﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.DEJoinDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPBefore = New DevExpress.XtraTab.XtraTabPage()
        Me.GCScheduleBefore = New DevExpress.XtraGrid.GridControl()
        Me.GVScheduleBefore = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTPAfter = New DevExpress.XtraTab.XtraTabPage()
        Me.GCScheduleAfter = New DevExpress.XtraGrid.GridControl()
        Me.GVScheduleAfter = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BViewShift = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEJoinDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEJoinDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPBefore.SuspendLayout()
        CType(Me.GCScheduleBefore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVScheduleBefore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPAfter.SuspendLayout()
        CType(Me.GCScheduleAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVScheduleAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BMark)
        Me.PanelControl1.Controls.Add(Me.BCancel)
        Me.PanelControl1.Controls.Add(Me.BPropose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 275)
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
        Me.GroupControl1.Controls.Add(Me.TextEdit2)
        Me.GroupControl1.Controls.Add(Me.TextEdit1)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.TENumber)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.DEJoinDate)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(689, 75)
        Me.GroupControl1.TabIndex = 3
        '
        'TextEdit2
        '
        Me.TextEdit2.EditValue = ""
        Me.TextEdit2.Location = New System.Drawing.Point(448, 38)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.EditValueChangedDelay = 1
        Me.TextEdit2.Properties.ReadOnly = True
        Me.TextEdit2.Size = New System.Drawing.Size(224, 20)
        Me.TextEdit2.TabIndex = 99
        '
        'TextEdit1
        '
        Me.TextEdit1.EditValue = ""
        Me.TextEdit1.Location = New System.Drawing.Point(448, 12)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.EditValueChangedDelay = 1
        Me.TextEdit1.Properties.ReadOnly = True
        Me.TextEdit1.Size = New System.Drawing.Size(224, 20)
        Me.TextEdit1.TabIndex = 97
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(382, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl1.TabIndex = 98
        Me.LabelControl1.Text = "Proposed By"
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
        'DEJoinDate
        '
        Me.DEJoinDate.EditValue = Nothing
        Me.DEJoinDate.Location = New System.Drawing.Point(111, 41)
        Me.DEJoinDate.Name = "DEJoinDate"
        Me.DEJoinDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEJoinDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEJoinDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEJoinDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEJoinDate.Properties.ReadOnly = True
        Me.DEJoinDate.Size = New System.Drawing.Size(217, 20)
        Me.DEJoinDate.TabIndex = 5
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
        Me.XtraTabControl1.Size = New System.Drawing.Size(689, 177)
        Me.XtraTabControl1.TabIndex = 4
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBefore, Me.XTPAfter})
        '
        'XTPBefore
        '
        Me.XTPBefore.Controls.Add(Me.GCScheduleBefore)
        Me.XTPBefore.Name = "XTPBefore"
        Me.XTPBefore.Size = New System.Drawing.Size(683, 149)
        Me.XTPBefore.Text = "Before"
        '
        'GCScheduleBefore
        '
        Me.GCScheduleBefore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCScheduleBefore.Location = New System.Drawing.Point(0, 0)
        Me.GCScheduleBefore.MainView = Me.GVScheduleBefore
        Me.GCScheduleBefore.Name = "GCScheduleBefore"
        Me.GCScheduleBefore.Size = New System.Drawing.Size(683, 149)
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
        Me.XTPAfter.Size = New System.Drawing.Size(683, 149)
        Me.XTPAfter.Text = "After"
        '
        'GCScheduleAfter
        '
        Me.GCScheduleAfter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCScheduleAfter.Location = New System.Drawing.Point(0, 0)
        Me.GCScheduleAfter.MainView = Me.GVScheduleAfter
        Me.GCScheduleAfter.Name = "GCScheduleAfter"
        Me.GCScheduleAfter.Size = New System.Drawing.Size(683, 149)
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
        Me.BViewShift.Location = New System.Drawing.Point(0, 252)
        Me.BViewShift.Name = "BViewShift"
        Me.BViewShift.Size = New System.Drawing.Size(689, 23)
        Me.BViewShift.TabIndex = 5
        Me.BViewShift.Text = "View Shift List"
        '
        'FormEmpAttnAssignDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 311)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.BViewShift)
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
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEJoinDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEJoinDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPBefore.ResumeLayout(False)
        CType(Me.GCScheduleBefore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVScheduleBefore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPAfter.ResumeLayout(False)
        CType(Me.GCScheduleAfter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVScheduleAfter, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DEJoinDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPBefore As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPAfter As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCScheduleBefore As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVScheduleBefore As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCScheduleAfter As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVScheduleAfter As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BViewShift As DevExpress.XtraEditors.SimpleButton
End Class
