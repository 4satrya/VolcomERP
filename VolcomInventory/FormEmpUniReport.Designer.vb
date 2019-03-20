<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpUniReport
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LEDeptSum = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LEPeriodx = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdBudget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNik = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBudget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnActual = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOrderNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnOrderStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOrderAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBugdetDiff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPoint = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEPeriodx.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.LEDeptSum)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LEPeriodx)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1050, 41)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(535, 7)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 23)
        Me.BtnView.TabIndex = 17
        Me.BtnView.Text = "View"
        '
        'LEDeptSum
        '
        Me.LEDeptSum.Location = New System.Drawing.Point(354, 9)
        Me.LEDeptSum.Name = "LEDeptSum"
        Me.LEDeptSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDeptSum.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "Id Departement", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departemen")})
        Me.LEDeptSum.Size = New System.Drawing.Size(175, 20)
        Me.LEDeptSum.TabIndex = 16
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(285, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Departement"
        '
        'LEPeriodx
        '
        Me.LEPeriodx.Location = New System.Drawing.Point(51, 9)
        Me.LEPeriodx.Name = "LEPeriodx"
        Me.LEPeriodx.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPeriodx.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_emp_uni_period", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("period_name", "Period"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("selection_date_start", "Start", 20, DevExpress.Utils.FormatType.DateTime, "dd\/MM\/yyyy", True, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("selection_date_end", "End", 20, DevExpress.Utils.FormatType.DateTime, "dd\/MM\/yyyy", True, DevExpress.Utils.HorzAlignment.[Default])})
        Me.LEPeriodx.Size = New System.Drawing.Size(228, 20)
        Me.LEPeriodx.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Period"
        '
        'GCDetail
        '
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 41)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.GCDetail.Size = New System.Drawing.Size(1050, 469)
        Me.GCDetail.TabIndex = 2
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GVDetail
        '
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdEmployee, Me.GridColumnIdBudget, Me.GridColumnNik, Me.GridColumnName, Me.GridColumnDept, Me.GridColumnPosition, Me.GridColumnLevel, Me.GridColumnBudget, Me.GridColumnActual, Me.GridColumn1, Me.GridColumnStatus, Me.GridColumnIdOrder, Me.GridColumnOrderNumber, Me.GridColumnOrderStatus, Me.GridColumnOrderAmount, Me.GridColumnBugdetDiff, Me.GridColumnQty, Me.GridColumnPoint})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.GroupCount = 1
        Me.GVDetail.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "budget", Me.GridColumnBudget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "order_amount", Me.GridColumnOrderAmount, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "budget_diff", Me.GridColumnBugdetDiff, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "order_qty", Me.GridColumnQty, "{0:N0}")})
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDetail.OptionsBehavior.Editable = False
        Me.GVDetail.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVDetail.OptionsView.ShowFooter = True
        Me.GVDetail.OptionsView.ShowGroupedColumns = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        Me.GVDetail.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDept, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnLevel, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdEmployee
        '
        Me.GridColumnIdEmployee.Caption = "Id Employee"
        Me.GridColumnIdEmployee.FieldName = "id_employee"
        Me.GridColumnIdEmployee.Name = "GridColumnIdEmployee"
        '
        'GridColumnIdBudget
        '
        Me.GridColumnIdBudget.Caption = "Id Budget"
        Me.GridColumnIdBudget.FieldName = "id_emp_uni_budget"
        Me.GridColumnIdBudget.Name = "GridColumnIdBudget"
        '
        'GridColumnNik
        '
        Me.GridColumnNik.Caption = "NIK"
        Me.GridColumnNik.FieldName = "employee_code"
        Me.GridColumnNik.Name = "GridColumnNik"
        Me.GridColumnNik.Visible = True
        Me.GridColumnNik.VisibleIndex = 0
        Me.GridColumnNik.Width = 223
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "employee_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 1
        Me.GridColumnName.Width = 428
        '
        'GridColumnDept
        '
        Me.GridColumnDept.Caption = "Departement"
        Me.GridColumnDept.FieldName = "departement"
        Me.GridColumnDept.Name = "GridColumnDept"
        Me.GridColumnDept.Visible = True
        Me.GridColumnDept.VisibleIndex = 2
        Me.GridColumnDept.Width = 229
        '
        'GridColumnPosition
        '
        Me.GridColumnPosition.Caption = "Position"
        Me.GridColumnPosition.FieldName = "employee_position"
        Me.GridColumnPosition.Name = "GridColumnPosition"
        Me.GridColumnPosition.Visible = True
        Me.GridColumnPosition.VisibleIndex = 3
        Me.GridColumnPosition.Width = 185
        '
        'GridColumnLevel
        '
        Me.GridColumnLevel.Caption = "Level"
        Me.GridColumnLevel.FieldName = "employee_level"
        Me.GridColumnLevel.FieldNameSortGroup = "id_employee_level"
        Me.GridColumnLevel.Name = "GridColumnLevel"
        Me.GridColumnLevel.Visible = True
        Me.GridColumnLevel.VisibleIndex = 4
        Me.GridColumnLevel.Width = 115
        '
        'GridColumnBudget
        '
        Me.GridColumnBudget.Caption = "Budget"
        Me.GridColumnBudget.DisplayFormat.FormatString = "N2"
        Me.GridColumnBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBudget.FieldName = "budget"
        Me.GridColumnBudget.Name = "GridColumnBudget"
        Me.GridColumnBudget.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "budget", "{0:N2}")})
        Me.GridColumnBudget.Width = 164
        '
        'GridColumnActual
        '
        Me.GridColumnActual.Caption = "Actual"
        Me.GridColumnActual.DisplayFormat.FormatString = "N2"
        Me.GridColumnActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnActual.FieldName = "amount"
        Me.GridColumnActual.Name = "GridColumnActual"
        Me.GridColumnActual.Width = 99
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Qty"
        Me.GridColumn1.DisplayFormat.FormatString = "N0"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "total_qty"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Width = 64
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Delivery Status"
        Me.GridColumnStatus.FieldName = "del_report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Width = 150
        '
        'GridColumnIdOrder
        '
        Me.GridColumnIdOrder.Caption = "IdOrder"
        Me.GridColumnIdOrder.FieldName = "id_order"
        Me.GridColumnIdOrder.Name = "GridColumnIdOrder"
        '
        'GridColumnOrderNumber
        '
        Me.GridColumnOrderNumber.Caption = "Order#"
        Me.GridColumnOrderNumber.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnOrderNumber.FieldName = "order_number"
        Me.GridColumnOrderNumber.Name = "GridColumnOrderNumber"
        Me.GridColumnOrderNumber.Visible = True
        Me.GridColumnOrderNumber.VisibleIndex = 5
        Me.GridColumnOrderNumber.Width = 131
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        '
        'GridColumnOrderStatus
        '
        Me.GridColumnOrderStatus.Caption = "Order Status"
        Me.GridColumnOrderStatus.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnOrderStatus.FieldName = "order_status"
        Me.GridColumnOrderStatus.Name = "GridColumnOrderStatus"
        Me.GridColumnOrderStatus.Visible = True
        Me.GridColumnOrderStatus.VisibleIndex = 8
        Me.GridColumnOrderStatus.Width = 166
        '
        'GridColumnOrderAmount
        '
        Me.GridColumnOrderAmount.Caption = "Order Amount"
        Me.GridColumnOrderAmount.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnOrderAmount.DisplayFormat.FormatString = "N2"
        Me.GridColumnOrderAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOrderAmount.FieldName = "order_amount"
        Me.GridColumnOrderAmount.Name = "GridColumnOrderAmount"
        Me.GridColumnOrderAmount.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnOrderAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "order_amount", "{0:N2}")})
        Me.GridColumnOrderAmount.Width = 146
        '
        'GridColumnBugdetDiff
        '
        Me.GridColumnBugdetDiff.Caption = "Budget Diff"
        Me.GridColumnBugdetDiff.DisplayFormat.FormatString = "N2"
        Me.GridColumnBugdetDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBugdetDiff.FieldName = "budget_diff"
        Me.GridColumnBugdetDiff.Name = "GridColumnBugdetDiff"
        Me.GridColumnBugdetDiff.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnBugdetDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "budget_diff", "{0:N2}")})
        Me.GridColumnBugdetDiff.UnboundExpression = "[budget] - [order_amount]"
        Me.GridColumnBugdetDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnBugdetDiff.Width = 133
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "order_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "order_qty", "{0:N0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 6
        Me.GridColumnQty.Width = 61
        '
        'GridColumnPoint
        '
        Me.GridColumnPoint.Caption = "Point (%)"
        Me.GridColumnPoint.DisplayFormat.FormatString = "N2"
        Me.GridColumnPoint.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPoint.FieldName = "order_point"
        Me.GridColumnPoint.Name = "GridColumnPoint"
        Me.GridColumnPoint.Visible = True
        Me.GridColumnPoint.VisibleIndex = 7
        Me.GridColumnPoint.Width = 94
        '
        'FormEmpUniReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1050, 510)
        Me.Controls.Add(Me.GCDetail)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpUniReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Uniform Department Report"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEPeriodx.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEPeriodx As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LEDeptSum As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdBudget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNik As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBudget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnActual As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrderNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumnOrderStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrderAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBugdetDiff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPoint As DevExpress.XtraGrid.Columns.GridColumn
End Class
