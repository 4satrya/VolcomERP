<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportEstWHInQty
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormReportEstWHInQty))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStoreLabel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BViewSum = New DevExpress.XtraEditors.SimpleButton()
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GCWorkOrder = New DevExpress.XtraGrid.GridControl()
        Me.GVWorkOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEstInStoreDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEstInWH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEUrgent = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCWorkOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVWorkOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEUrgent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLEType)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.BViewSum)
        Me.PanelControl1.Controls.Add(Me.DEEnd)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.DEStart)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1149, 38)
        Me.PanelControl1.TabIndex = 3
        '
        'SLEType
        '
        Me.SLEType.Location = New System.Drawing.Point(63, 10)
        Me.SLEType.Name = "SLEType"
        Me.SLEType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEType.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEType.Size = New System.Drawing.Size(136, 20)
        Me.SLEType.TabIndex = 14
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumnStoreLabel})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "opt"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumnStoreLabel
        '
        Me.GridColumnStoreLabel.Caption = "Type"
        Me.GridColumnStoreLabel.FieldName = "type"
        Me.GridColumnStoreLabel.Name = "GridColumnStoreLabel"
        Me.GridColumnStoreLabel.Visible = True
        Me.GridColumnStoreLabel.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(9, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl1.TabIndex = 13
        Me.LabelControl1.Text = "Search By"
        '
        'BViewSum
        '
        Me.BViewSum.Location = New System.Drawing.Point(562, 7)
        Me.BViewSum.Name = "BViewSum"
        Me.BViewSum.Size = New System.Drawing.Size(54, 25)
        Me.BViewSum.TabIndex = 12
        Me.BViewSum.Text = "view"
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(429, 10)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Size = New System.Drawing.Size(127, 20)
        Me.DEEnd.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(385, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Until : "
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(252, 10)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Size = New System.Drawing.Size(127, 20)
        Me.DEStart.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(205, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "From : "
        '
        'GCWorkOrder
        '
        Me.GCWorkOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCWorkOrder.Location = New System.Drawing.Point(0, 38)
        Me.GCWorkOrder.MainView = Me.GVWorkOrder
        Me.GCWorkOrder.Name = "GCWorkOrder"
        Me.GCWorkOrder.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEUrgent})
        Me.GCWorkOrder.Size = New System.Drawing.Size(1149, 570)
        Me.GCWorkOrder.TabIndex = 4
        Me.GCWorkOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVWorkOrder})
        '
        'GVWorkOrder
        '
        Me.GVWorkOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3, Me.GridColumn10, Me.GridColumn5, Me.GridColumn6, Me.GridColumnEstInStoreDate, Me.GridColumnEstInWH, Me.GridColumn2, Me.GridColumnStatus})
        Me.GVWorkOrder.CustomizationFormBounds = New System.Drawing.Rectangle(1102, 554, 210, 172)
        Me.GVWorkOrder.GridControl = Me.GCWorkOrder
        Me.GVWorkOrder.GroupCount = 1
        Me.GVWorkOrder.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumn2, "{0:N0}")})
        Me.GVWorkOrder.Name = "GVWorkOrder"
        Me.GVWorkOrder.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVWorkOrder.OptionsView.ShowFooter = True
        Me.GVWorkOrder.OptionsView.ShowGroupPanel = False
        Me.GVWorkOrder.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn5, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_report"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Report mark type"
        Me.GridColumn3.FieldName = "report_mark_type"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Number"
        Me.GridColumn10.FieldName = "number"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.ReadOnly = True
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        Me.GridColumn10.Width = 532
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Type"
        Me.GridColumn5.FieldName = "type"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        Me.GridColumn5.Width = 326
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Estimate Rec Qc"
        Me.GridColumn6.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn6.FieldName = "est_qc_date"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        Me.GridColumn6.Width = 276
        '
        'GridColumnEstInStoreDate
        '
        Me.GridColumnEstInStoreDate.Caption = "Estimate In Store Date"
        Me.GridColumnEstInStoreDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnEstInStoreDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnEstInStoreDate.FieldName = "est_store_date"
        Me.GridColumnEstInStoreDate.Name = "GridColumnEstInStoreDate"
        Me.GridColumnEstInStoreDate.Visible = True
        Me.GridColumnEstInStoreDate.VisibleIndex = 3
        Me.GridColumnEstInStoreDate.Width = 237
        '
        'GridColumnEstInWH
        '
        Me.GridColumnEstInWH.Caption = "Estimate In WH Date"
        Me.GridColumnEstInWH.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnEstInWH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnEstInWH.FieldName = "est_date"
        Me.GridColumnEstInWH.Name = "GridColumnEstInWH"
        Me.GridColumnEstInWH.OptionsColumn.AllowEdit = False
        Me.GridColumnEstInWH.OptionsColumn.ReadOnly = True
        Me.GridColumnEstInWH.Visible = True
        Me.GridColumnEstInWH.VisibleIndex = 2
        Me.GridColumnEstInWH.Width = 242
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "Qty"
        Me.GridColumn2.DisplayFormat.FormatString = "N0"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "qty"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 4
        Me.GridColumn2.Width = 345
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.OptionsColumn.AllowEdit = False
        Me.GridColumnStatus.OptionsColumn.ReadOnly = True
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 5
        Me.GridColumnStatus.Width = 457
        '
        'RICEUrgent
        '
        Me.RICEUrgent.AutoHeight = False
        Me.RICEUrgent.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.RICEUrgent.Name = "RICEUrgent"
        Me.RICEUrgent.PictureChecked = CType(resources.GetObject("RICEUrgent.PictureChecked"), System.Drawing.Image)
        Me.RICEUrgent.ValueChecked = "yes"
        Me.RICEUrgent.ValueUnchecked = "no"
        '
        'FormReportEstWHInQty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1149, 608)
        Me.Controls.Add(Me.GCWorkOrder)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormReportEstWHInQty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Estimate Qty to WH"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCWorkOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVWorkOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEUrgent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BViewSum As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents GCWorkOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVWorkOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEstInWH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICEUrgent As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEstInStoreDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreLabel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
