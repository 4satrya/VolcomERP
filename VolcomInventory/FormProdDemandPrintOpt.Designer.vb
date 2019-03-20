<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdDemandPrintOpt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProdDemandPrintOpt))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEChecked = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEApproved = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCMark = New DevExpress.XtraGrid.GridControl()
        Me.GVMark = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdMark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEPreq = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ColReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIDReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDateStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColLeadTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdMarkAsg = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIDMark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRawLeadTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAssigned = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportMarkType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReport = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSort = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SignHardcopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsUse = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEChecked.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEApproved.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEPreq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLEChecked)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.SLEApproved)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 306)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(713, 43)
        Me.PanelControl1.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(636, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 39)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "OK"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(307, 46)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Checked By"
        '
        'SLEChecked
        '
        Me.SLEChecked.Location = New System.Drawing.Point(369, 43)
        Me.SLEChecked.Name = "SLEChecked"
        Me.SLEChecked.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEChecked.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEChecked.Size = New System.Drawing.Size(87, 20)
        Me.SLEChecked.TabIndex = 2
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id"
        Me.GridColumn1.FieldName = "id_report_mark"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Name"
        Me.GridColumn2.FieldName = "employee_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(462, 46)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Approved By"
        '
        'SLEApproved
        '
        Me.SLEApproved.Location = New System.Drawing.Point(530, 43)
        Me.SLEApproved.Name = "SLEApproved"
        Me.SLEApproved.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEApproved.Properties.View = Me.GridView1
        Me.SLEApproved.Size = New System.Drawing.Size(81, 20)
        Me.SLEApproved.TabIndex = 4
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Id"
        Me.GridColumn3.FieldName = "id_report_mark"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Name"
        Me.GridColumn4.FieldName = "employee_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'GCMark
        '
        Me.GCMark.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCMark.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMark.Location = New System.Drawing.Point(0, 0)
        Me.GCMark.MainView = Me.GVMark
        Me.GCMark.Name = "GCMark"
        Me.GCMark.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEPreq})
        Me.GCMark.Size = New System.Drawing.Size(713, 306)
        Me.GCMark.TabIndex = 1
        Me.GCMark.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMark})
        '
        'GVMark
        '
        Me.GVMark.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMark, Me.ColIdUser, Me.ColName, Me.ColMark, Me.GridColumnPre, Me.ColReportStatus, Me.ColNote, Me.ColNo, Me.ColIDReportStatus, Me.ColDate, Me.ColDateStart, Me.ColLeadTime, Me.ColIdMarkAsg, Me.GridColumnIDMark, Me.ColRawLeadTime, Me.GridColumnAssigned, Me.GridColumnReportMarkType, Me.GridColumnIdReport, Me.GridColumnSort, Me.GridColumn5, Me.GridColumnIsUse})
        Me.GVMark.CustomizationFormBounds = New System.Drawing.Rectangle(974, 245, 216, 178)
        Me.GVMark.GridControl = Me.GCMark
        Me.GVMark.GroupCount = 1
        Me.GVMark.Name = "GVMark"
        Me.GVMark.OptionsBehavior.Editable = False
        Me.GVMark.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.GVMark.OptionsView.ShowGroupPanel = False
        Me.GVMark.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnAssigned, DevExpress.Data.ColumnSortOrder.Ascending)})
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
        Me.ColName.VisibleIndex = 0
        Me.ColName.Width = 141
        '
        'ColMark
        '
        Me.ColMark.Caption = "Mark"
        Me.ColMark.FieldName = "mark"
        Me.ColMark.Name = "ColMark"
        Me.ColMark.Width = 66
        '
        'GridColumnPre
        '
        Me.GridColumnPre.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPre.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnPre.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPre.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnPre.Caption = "Need Approve First"
        Me.GridColumnPre.ColumnEdit = Me.RICEPreq
        Me.GridColumnPre.FieldName = "is_requisite"
        Me.GridColumnPre.Name = "GridColumnPre"
        Me.GridColumnPre.Width = 145
        '
        'RICEPreq
        '
        Me.RICEPreq.Appearance.Options.UseImage = True
        Me.RICEPreq.AppearanceReadOnly.Options.UseImage = True
        Me.RICEPreq.AutoHeight = False
        Me.RICEPreq.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.RICEPreq.Name = "RICEPreq"
        Me.RICEPreq.PictureChecked = CType(resources.GetObject("RICEPreq.PictureChecked"), System.Drawing.Image)
        Me.RICEPreq.ValueChecked = "Yes"
        Me.RICEPreq.ValueUnchecked = "No"
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
        Me.ColNote.Width = 111
        '
        'ColNo
        '
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.Width = 108
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
        Me.ColDate.Width = 141
        '
        'ColDateStart
        '
        Me.ColDateStart.Caption = "Start Time"
        Me.ColDateStart.FieldName = "date_time_start"
        Me.ColDateStart.Name = "ColDateStart"
        Me.ColDateStart.Width = 137
        '
        'ColLeadTime
        '
        Me.ColLeadTime.Caption = "Lead Time"
        Me.ColLeadTime.FieldName = "lead_time"
        Me.ColLeadTime.Name = "ColLeadTime"
        Me.ColLeadTime.Width = 168
        '
        'ColIdMarkAsg
        '
        Me.ColIdMarkAsg.Caption = "Assigned"
        Me.ColIdMarkAsg.FieldName = "id_mark_asg"
        Me.ColIdMarkAsg.Name = "ColIdMarkAsg"
        '
        'GridColumnIDMark
        '
        Me.GridColumnIDMark.Caption = "ID Mark"
        Me.GridColumnIDMark.FieldName = "id_mark"
        Me.GridColumnIDMark.Name = "GridColumnIDMark"
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
        Me.GridColumnAssigned.FieldNameSortGroup = "id_sort"
        Me.GridColumnAssigned.Name = "GridColumnAssigned"
        Me.GridColumnAssigned.Visible = True
        Me.GridColumnAssigned.VisibleIndex = 7
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
        'GridColumnSort
        '
        Me.GridColumnSort.FieldName = "id_sort"
        Me.GridColumnSort.Name = "GridColumnSort"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SignHardcopyToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 48)
        '
        'SignHardcopyToolStripMenuItem
        '
        Me.SignHardcopyToolStripMenuItem.Name = "SignHardcopyToolStripMenuItem"
        Me.SignHardcopyToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SignHardcopyToolStripMenuItem.Text = "sign hardcopy"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Sign"
        Me.GridColumn5.ColumnEdit = Me.RICEPreq
        Me.GridColumn5.FieldName = "sign"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.UnboundExpression = "Iif([is_use] = 1, 'Yes', 'No')"
        Me.GridColumn5.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        '
        'GridColumnIsUse
        '
        Me.GridColumnIsUse.Caption = "Is Use"
        Me.GridColumnIsUse.FieldName = "is_use"
        Me.GridColumnIsUse.Name = "GridColumnIsUse"
        '
        'FormProdDemandPrintOpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 349)
        Me.Controls.Add(Me.GCMark)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProdDemandPrintOpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Option"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEChecked.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEApproved.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEPreq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEChecked As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEApproved As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCMark As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMark As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICEPreq As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ColReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDateStart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColLeadTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMarkAsg As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDMark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRawLeadTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAssigned As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportMarkType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReport As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSort As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SignHardcopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsUse As DevExpress.XtraGrid.Columns.GridColumn
End Class
