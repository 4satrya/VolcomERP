<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormReportMark
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCMark = New DevExpress.XtraGrid.GridControl()
        Me.GVMark = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdMark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIDReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDateStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColLeadTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdMarkAsg = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRawLeadTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAssigned = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.BReset = New DevExpress.XtraEditors.SimpleButton()
        Me.PBC = New DevExpress.XtraEditors.ProgressBarControl()
        Me.BClearLeadTime = New DevExpress.XtraEditors.SimpleButton()
        Me.BLeadTime = New DevExpress.XtraEditors.SimpleButton()
        Me.BSetStatus = New DevExpress.XtraEditors.SimpleButton()
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.BDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.BEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.GCFinal = New DevExpress.XtraGrid.GridControl()
        Me.GVFinal = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportMarkType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReport = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.PBC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GCFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCMark)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(879, 195)
        Me.GroupControl1.TabIndex = 7
        Me.GroupControl1.Text = "Approval List"
        '
        'GCMark
        '
        Me.GCMark.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMark.Location = New System.Drawing.Point(2, 20)
        Me.GCMark.MainView = Me.GVMark
        Me.GCMark.Name = "GCMark"
        Me.GCMark.Size = New System.Drawing.Size(875, 173)
        Me.GCMark.TabIndex = 0
        Me.GCMark.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMark})
        '
        'GVMark
        '
        Me.GVMark.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMark, Me.ColIdUser, Me.ColName, Me.ColMark, Me.ColReportStatus, Me.ColNote, Me.ColNo, Me.ColIDReportStatus, Me.ColDate, Me.ColDateStart, Me.ColLeadTime, Me.ColIdMarkAsg, Me.ColRawLeadTime, Me.GridColumnAssigned, Me.GridColumnReportMarkType, Me.GridColumnIdReport})
        Me.GVMark.CustomizationFormBounds = New System.Drawing.Rectangle(974, 245, 216, 178)
        Me.GVMark.GridControl = Me.GCMark
        Me.GVMark.GroupCount = 2
        Me.GVMark.Name = "GVMark"
        Me.GVMark.OptionsBehavior.Editable = False
        Me.GVMark.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.GVMark.OptionsView.ShowGroupPanel = False
        Me.GVMark.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColReportStatus, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnAssigned, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdMark
        '
        Me.ColIdMark.Caption = "ID report mark"
        Me.ColIdMark.FieldName = "id_report_mark"
        Me.ColIdMark.Name = "ColIdMark"
        Me.ColIdMark.OptionsColumn.AllowEdit = False
        '
        'ColIdUser
        '
        Me.ColIdUser.Caption = "ID USer"
        Me.ColIdUser.FieldName = "id_user"
        Me.ColIdUser.Name = "ColIdUser"
        Me.ColIdUser.OptionsColumn.AllowEdit = False
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "employee_name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 1
        Me.ColName.Width = 150
        '
        'ColMark
        '
        Me.ColMark.Caption = "Mark"
        Me.ColMark.FieldName = "mark"
        Me.ColMark.Name = "ColMark"
        Me.ColMark.Visible = True
        Me.ColMark.VisibleIndex = 2
        Me.ColMark.Width = 74
        '
        'ColReportStatus
        '
        Me.ColReportStatus.Caption = "Status"
        Me.ColReportStatus.FieldName = "report_status"
        Me.ColReportStatus.FieldNameSortGroup = "id_report_status"
        Me.ColReportStatus.Name = "ColReportStatus"
        Me.ColReportStatus.Width = 98
        '
        'ColNote
        '
        Me.ColNote.Caption = "Comment"
        Me.ColNote.FieldName = "report_mark_note"
        Me.ColNote.Name = "ColNote"
        Me.ColNote.Visible = True
        Me.ColNote.VisibleIndex = 3
        Me.ColNote.Width = 120
        '
        'ColNo
        '
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 62
        '
        'ColIDReportStatus
        '
        Me.ColIDReportStatus.Caption = "Status"
        Me.ColIDReportStatus.FieldName = "id_report_status"
        Me.ColIDReportStatus.Name = "ColIDReportStatus"
        '
        'ColDate
        '
        Me.ColDate.Caption = "Date"
        Me.ColDate.FieldName = "date_time"
        Me.ColDate.Name = "ColDate"
        Me.ColDate.OptionsColumn.AllowEdit = False
        Me.ColDate.Visible = True
        Me.ColDate.VisibleIndex = 4
        Me.ColDate.Width = 150
        '
        'ColDateStart
        '
        Me.ColDateStart.Caption = "Start Time"
        Me.ColDateStart.FieldName = "date_time_start"
        Me.ColDateStart.Name = "ColDateStart"
        Me.ColDateStart.Visible = True
        Me.ColDateStart.VisibleIndex = 5
        Me.ColDateStart.Width = 147
        '
        'ColLeadTime
        '
        Me.ColLeadTime.Caption = "Lead Time"
        Me.ColLeadTime.FieldName = "lead_time"
        Me.ColLeadTime.Name = "ColLeadTime"
        Me.ColLeadTime.Visible = True
        Me.ColLeadTime.VisibleIndex = 6
        Me.ColLeadTime.Width = 156
        '
        'ColIdMarkAsg
        '
        Me.ColIdMarkAsg.Caption = "Assigned"
        Me.ColIdMarkAsg.FieldName = "id_mark_asg"
        Me.ColIdMarkAsg.Name = "ColIdMarkAsg"
        '
        'ColRawLeadTime
        '
        Me.ColRawLeadTime.Caption = "Raw Lead TIme"
        Me.ColRawLeadTime.FieldName = "raw_lead_time"
        Me.ColRawLeadTime.Name = "ColRawLeadTime"
        '
        'GridColumnAssigned
        '
        Me.GridColumnAssigned.Caption = "Assigned "
        Me.GridColumnAssigned.FieldName = "report_status"
        Me.GridColumnAssigned.FieldNameSortGroup = "id_mark_asg"
        Me.GridColumnAssigned.Name = "GridColumnAssigned"
        Me.GridColumnAssigned.Visible = True
        Me.GridColumnAssigned.VisibleIndex = 7
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.BReset)
        Me.GroupControl2.Controls.Add(Me.PBC)
        Me.GroupControl2.Controls.Add(Me.BClearLeadTime)
        Me.GroupControl2.Controls.Add(Me.BLeadTime)
        Me.GroupControl2.Controls.Add(Me.BSetStatus)
        Me.GroupControl2.Controls.Add(Me.LEReportStatus)
        Me.GroupControl2.Controls.Add(Me.BDelete)
        Me.GroupControl2.Controls.Add(Me.BEdit)
        Me.GroupControl2.Controls.Add(Me.BAdd)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl2.Location = New System.Drawing.Point(0, 314)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(879, 62)
        Me.GroupControl2.TabIndex = 6
        Me.GroupControl2.Text = "Command"
        '
        'BReset
        '
        Me.BReset.Location = New System.Drawing.Point(284, 28)
        Me.BReset.Name = "BReset"
        Me.BReset.Size = New System.Drawing.Size(59, 23)
        Me.BReset.TabIndex = 152
        Me.BReset.Text = "Reset"
        '
        'PBC
        '
        Me.PBC.Dock = System.Windows.Forms.DockStyle.Right
        Me.PBC.Location = New System.Drawing.Point(361, 20)
        Me.PBC.Name = "PBC"
        Me.PBC.Properties.ShowTitle = True
        Me.PBC.Size = New System.Drawing.Size(103, 40)
        Me.PBC.TabIndex = 150
        Me.PBC.Visible = False
        '
        'BClearLeadTime
        '
        Me.BClearLeadTime.Dock = System.Windows.Forms.DockStyle.Right
        Me.BClearLeadTime.Location = New System.Drawing.Point(464, 20)
        Me.BClearLeadTime.Name = "BClearLeadTime"
        Me.BClearLeadTime.Size = New System.Drawing.Size(100, 40)
        Me.BClearLeadTime.TabIndex = 149
        Me.BClearLeadTime.Text = "Clear Lead Time"
        '
        'BLeadTime
        '
        Me.BLeadTime.Dock = System.Windows.Forms.DockStyle.Right
        Me.BLeadTime.Location = New System.Drawing.Point(564, 20)
        Me.BLeadTime.Name = "BLeadTime"
        Me.BLeadTime.Size = New System.Drawing.Size(88, 40)
        Me.BLeadTime.TabIndex = 147
        Me.BLeadTime.Text = "Set Lead Time"
        '
        'BSetStatus
        '
        Me.BSetStatus.Location = New System.Drawing.Point(203, 28)
        Me.BSetStatus.Name = "BSetStatus"
        Me.BSetStatus.Size = New System.Drawing.Size(75, 23)
        Me.BSetStatus.TabIndex = 146
        Me.BSetStatus.Text = "Set Status"
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Location = New System.Drawing.Point(12, 30)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(185, 20)
        Me.LEReportStatus.TabIndex = 145
        '
        'BDelete
        '
        Me.BDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelete.Location = New System.Drawing.Point(652, 20)
        Me.BDelete.Name = "BDelete"
        Me.BDelete.Size = New System.Drawing.Size(75, 40)
        Me.BDelete.TabIndex = 4
        Me.BDelete.Text = "Delete"
        Me.BDelete.Visible = False
        '
        'BEdit
        '
        Me.BEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEdit.Location = New System.Drawing.Point(727, 20)
        Me.BEdit.Name = "BEdit"
        Me.BEdit.Size = New System.Drawing.Size(75, 40)
        Me.BEdit.TabIndex = 1
        Me.BEdit.Text = "Edit"
        Me.BEdit.Visible = False
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.Location = New System.Drawing.Point(802, 20)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(75, 40)
        Me.BAdd.TabIndex = 0
        Me.BAdd.Text = "Add"
        Me.BAdd.Visible = False
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.GCFinal)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 195)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(879, 119)
        Me.GroupControl3.TabIndex = 8
        Me.GroupControl3.Text = "Final Status"
        Me.GroupControl3.Visible = False
        '
        'GCFinal
        '
        Me.GCFinal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFinal.Location = New System.Drawing.Point(2, 20)
        Me.GCFinal.MainView = Me.GVFinal
        Me.GCFinal.Name = "GCFinal"
        Me.GCFinal.Size = New System.Drawing.Size(875, 97)
        Me.GCFinal.TabIndex = 1
        Me.GCFinal.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFinal})
        '
        'GVFinal
        '
        Me.GVFinal.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn3, Me.GridColumn5, Me.GridColumn6, Me.GridColumn9})
        Me.GVFinal.CustomizationFormBounds = New System.Drawing.Rectangle(974, 245, 216, 178)
        Me.GVFinal.GridControl = Me.GCFinal
        Me.GVFinal.GroupCount = 1
        Me.GVFinal.Name = "GVFinal"
        Me.GVFinal.OptionsBehavior.Editable = False
        Me.GVFinal.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.GVFinal.OptionsView.ShowGroupPanel = False
        Me.GVFinal.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn5, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ID USer"
        Me.GridColumn2.FieldName = "id_user"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Name"
        Me.GridColumn3.FieldName = "employee_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 258
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Status"
        Me.GridColumn5.FieldName = "report_status"
        Me.GridColumn5.FieldNameSortGroup = "id_report_status"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Width = 98
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Comment"
        Me.GridColumn6.FieldName = "final_comment"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        Me.GridColumn6.Width = 246
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Date"
        Me.GridColumn9.FieldName = "final_date"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 2
        Me.GridColumn9.Width = 222
        '
        'GridColumnReportMarkType
        '
        Me.GridColumnReportMarkType.Caption = "Report Mark Type"
        Me.GridColumnReportMarkType.FieldName = "report_mark_type"
        Me.GridColumnReportMarkType.Name = "GridColumnReportMarkType"
        '
        'GridColumnIdReport
        '
        Me.GridColumnIdReport.Caption = "Id Report"
        Me.GridColumnIdReport.FieldName = "id_report"
        Me.GridColumnIdReport.Name = "GridColumnIdReport"
        '
        'FormReportMark
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 376)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportMark"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mark"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.PBC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.GCFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCMark As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMark As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDateStart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColLeadTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMarkAsg As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRawLeadTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BLeadTime As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSetStatus As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BClearLeadTime As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PBC As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents GridColumnAssigned As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BReset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCFinal As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFinal As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportMarkType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReport As DevExpress.XtraGrid.Columns.GridColumn
End Class
