<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDeptHeadSurveyDet
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDeptHeadSurveyDet))
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TEName = New DevExpress.XtraEditors.TextEdit()
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit()
        Me.GCTitle = New DevExpress.XtraEditors.GroupControl()
        Me.CEActive = New DevExpress.XtraEditors.CheckEdit()
        Me.GCDetail = New DevExpress.XtraEditors.GroupControl()
        Me.GCSurvey = New DevExpress.XtraGrid.GridControl()
        Me.GVSurvey = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCAction = New DevExpress.XtraEditors.GroupControl()
        Me.SBCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCTitle.SuspendLayout()
        CType(Me.CEActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCDetail.SuspendLayout()
        CType(Me.GCSurvey, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSurvey, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCAction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCAction.SuspendLayout()
        Me.SuspendLayout()
        '
        'DEStart
        '
        Me.DEStart.EditValue = ""
        Me.DEStart.Location = New System.Drawing.Point(113, 38)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Size = New System.Drawing.Size(227, 20)
        Me.DEStart.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nama Periode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Mulai"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Selesai"
        '
        'TEName
        '
        Me.TEName.EditValue = ""
        Me.TEName.Location = New System.Drawing.Point(113, 12)
        Me.TEName.Name = "TEName"
        Me.TEName.Size = New System.Drawing.Size(227, 20)
        Me.TEName.TabIndex = 0
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = ""
        Me.DEEnd.Location = New System.Drawing.Point(113, 64)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Size = New System.Drawing.Size(227, 20)
        Me.DEEnd.TabIndex = 2
        '
        'GCTitle
        '
        Me.GCTitle.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCTitle.Controls.Add(Me.TEName)
        Me.GCTitle.Controls.Add(Me.DEStart)
        Me.GCTitle.Controls.Add(Me.DEEnd)
        Me.GCTitle.Controls.Add(Me.CEActive)
        Me.GCTitle.Controls.Add(Me.Label3)
        Me.GCTitle.Controls.Add(Me.Label2)
        Me.GCTitle.Controls.Add(Me.Label1)
        Me.GCTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCTitle.Location = New System.Drawing.Point(0, 0)
        Me.GCTitle.Name = "GCTitle"
        Me.GCTitle.Size = New System.Drawing.Size(1229, 97)
        Me.GCTitle.TabIndex = 6
        '
        'CEActive
        '
        Me.CEActive.Location = New System.Drawing.Point(370, 64)
        Me.CEActive.Name = "CEActive"
        Me.CEActive.Properties.Caption = "Aktif"
        Me.CEActive.Size = New System.Drawing.Size(75, 19)
        Me.CEActive.TabIndex = 3
        '
        'GCDetail
        '
        Me.GCDetail.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCDetail.Controls.Add(Me.GCSurvey)
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 97)
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.Size = New System.Drawing.Size(1229, 331)
        Me.GCDetail.TabIndex = 7
        '
        'GCSurvey
        '
        Me.GCSurvey.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSurvey.Location = New System.Drawing.Point(20, 2)
        Me.GCSurvey.MainView = Me.GVSurvey
        Me.GCSurvey.Name = "GCSurvey"
        Me.GCSurvey.Size = New System.Drawing.Size(1207, 327)
        Me.GCSurvey.TabIndex = 0
        Me.GCSurvey.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSurvey})
        '
        'GVSurvey
        '
        Me.GVSurvey.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVSurvey.GridControl = Me.GCSurvey
        Me.GVSurvey.GroupCount = 1
        Me.GVSurvey.GroupFormat = "{1} {2}"
        Me.GVSurvey.Name = "GVSurvey"
        Me.GVSurvey.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSurvey.OptionsBehavior.Editable = False
        Me.GVSurvey.OptionsView.ShowGroupPanel = False
        Me.GVSurvey.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn6, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "id_departement"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.FieldName = "departement"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.FieldName = "id_depthead"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.FieldName = "depthead_name"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.FieldName = "id_employee"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Nama Atasan"
        Me.GridColumn6.FieldName = "view"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Survey"
        Me.GridColumn7.FieldName = "survey"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        '
        'GCAction
        '
        Me.GCAction.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCAction.Controls.Add(Me.SBCancel)
        Me.GCAction.Controls.Add(Me.SBSave)
        Me.GCAction.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GCAction.Location = New System.Drawing.Point(0, 428)
        Me.GCAction.Name = "GCAction"
        Me.GCAction.Size = New System.Drawing.Size(1229, 47)
        Me.GCAction.TabIndex = 8
        '
        'SBCancel
        '
        Me.SBCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBCancel.Image = CType(resources.GetObject("SBCancel.Image"), System.Drawing.Image)
        Me.SBCancel.Location = New System.Drawing.Point(1046, 2)
        Me.SBCancel.Name = "SBCancel"
        Me.SBCancel.Size = New System.Drawing.Size(90, 43)
        Me.SBCancel.TabIndex = 2
        Me.SBCancel.Text = "Cancel"
        '
        'SBSave
        '
        Me.SBSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSave.Image = CType(resources.GetObject("SBSave.Image"), System.Drawing.Image)
        Me.SBSave.Location = New System.Drawing.Point(1136, 2)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(91, 43)
        Me.SBSave.TabIndex = 1
        Me.SBSave.Text = "Save"
        '
        'FormDeptHeadSurveyDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1229, 475)
        Me.Controls.Add(Me.GCDetail)
        Me.Controls.Add(Me.GCAction)
        Me.Controls.Add(Me.GCTitle)
        Me.Name = "FormDeptHeadSurveyDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Survey Dept Head Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCTitle.ResumeLayout(False)
        Me.GCTitle.PerformLayout()
        CType(Me.CEActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCDetail.ResumeLayout(False)
        CType(Me.GCSurvey, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSurvey, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCAction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCAction.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TEName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GCTitle As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCDetail As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCAction As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SBCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CEActive As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GCSurvey As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSurvey As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
End Class
