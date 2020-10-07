<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCashAdvanceReport
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
        Me.BPrintDefault = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrintAdvance = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.DateTo = New DevExpress.XtraEditors.DateEdit()
        Me.DateFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.GCReport = New DevExpress.XtraGrid.GridControl()
        Me.GVReport = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPurpose = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridColumnDateCreated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReconcileDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReconcileActualDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCashInAdvance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCashInAdvancePeriode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCOA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCOADesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCoaExpense = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnExpense = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAdvance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCashOnHandOut = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOverdue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BSummaryReport = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BSummaryReport)
        Me.PanelControl1.Controls.Add(Me.BPrintDefault)
        Me.PanelControl1.Controls.Add(Me.BPrintAdvance)
        Me.PanelControl1.Controls.Add(Me.BPrint)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.DateTo)
        Me.PanelControl1.Controls.Add(Me.DateFrom)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1012, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'BPrintDefault
        '
        Me.BPrintDefault.Location = New System.Drawing.Point(860, 10)
        Me.BPrintDefault.Name = "BPrintDefault"
        Me.BPrintDefault.Size = New System.Drawing.Size(48, 23)
        Me.BPrintDefault.TabIndex = 8940
        Me.BPrintDefault.Text = "Print"
        '
        'BPrintAdvance
        '
        Me.BPrintAdvance.Location = New System.Drawing.Point(586, 10)
        Me.BPrintAdvance.Name = "BPrintAdvance"
        Me.BPrintAdvance.Size = New System.Drawing.Size(131, 23)
        Me.BPrintAdvance.TabIndex = 8939
        Me.BPrintAdvance.Text = "Print Advance Report"
        '
        'BPrint
        '
        Me.BPrint.Location = New System.Drawing.Point(457, 10)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(123, 23)
        Me.BPrint.TabIndex = 8938
        Me.BPrint.Text = "Print Expense Report"
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(391, 10)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(60, 23)
        Me.BView.TabIndex = 8937
        Me.BView.Text = "view"
        '
        'DateTo
        '
        Me.DateTo.EditValue = Nothing
        Me.DateTo.Location = New System.Drawing.Point(245, 12)
        Me.DateTo.Name = "DateTo"
        Me.DateTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateTo.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateTo.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateTo.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DateTo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DateTo.Size = New System.Drawing.Size(140, 20)
        Me.DateTo.TabIndex = 8936
        '
        'DateFrom
        '
        Me.DateFrom.EditValue = Nothing
        Me.DateFrom.Location = New System.Drawing.Point(89, 12)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateFrom.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateFrom.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DateFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DateFrom.Size = New System.Drawing.Size(140, 20)
        Me.DateFrom.TabIndex = 8935
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(235, 15)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl6.TabIndex = 8934
        Me.LabelControl6.Text = "-"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 15)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl4.TabIndex = 8933
        Me.LabelControl4.Text = "Report Date : "
        '
        'GCReport
        '
        Me.GCReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCReport.Location = New System.Drawing.Point(0, 48)
        Me.GCReport.MainView = Me.GVReport
        Me.GCReport.Name = "GCReport"
        Me.GCReport.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemMemoEdit1})
        Me.GCReport.Size = New System.Drawing.Size(1012, 533)
        Me.GCReport.TabIndex = 21
        Me.GCReport.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVReport})
        '
        'GVReport
        '
        Me.GVReport.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVReport.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVReport.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVReport.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVReport.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVReport.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVReport.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVReport.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVReport.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVReport.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVReport.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVReport.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVReport.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVReport.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVReport.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVReport.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVReport.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.GVReport.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVReport.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVReport.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVReport.AppearancePrint.HeaderPanel.Options.UseTextOptions = True
        Me.GVReport.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVReport.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVReport.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVReport.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVReport.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVReport.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVReport.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVReport.AppearancePrint.Row.Options.UseTextOptions = True
        Me.GVReport.AppearancePrint.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GVReport.ColumnPanelRowHeight = 32
        Me.GVReport.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnNumber, Me.GridColumnEmployee, Me.GridColumnPurpose, Me.GridColumnDateCreated, Me.GridColumnReconcileDueDate, Me.GridColumnReconcileActualDate, Me.GridColumnCashInAdvance, Me.GridColumnCashInAdvancePeriode, Me.GridColumnCOA, Me.GridColumnCOADesc, Me.GridColumnCoaExpense, Me.GridColumnExpense, Me.GridColumnAdvance, Me.GridColumnCashOnHandOut, Me.GridColumnStatus, Me.GridColumnOverdue})
        Me.GVReport.GridControl = Me.GCReport
        Me.GVReport.Name = "GVReport"
        Me.GVReport.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVReport.OptionsBehavior.Editable = False
        Me.GVReport.OptionsPrint.AllowMultilineHeaders = True
        Me.GVReport.OptionsView.ColumnAutoWidth = False
        Me.GVReport.OptionsView.RowAutoHeight = True
        Me.GVReport.OptionsView.ShowFooter = True
        Me.GVReport.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "ID"
        Me.GridColumnId.FieldName = "id_cash_advance"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnEmployee
        '
        Me.GridColumnEmployee.Caption = "Employee"
        Me.GridColumnEmployee.FieldName = "employee_name"
        Me.GridColumnEmployee.Name = "GridColumnEmployee"
        Me.GridColumnEmployee.Visible = True
        Me.GridColumnEmployee.VisibleIndex = 2
        '
        'GridColumnPurpose
        '
        Me.GridColumnPurpose.Caption = "Purpose"
        Me.GridColumnPurpose.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.GridColumnPurpose.FieldName = "note"
        Me.GridColumnPurpose.MaxWidth = 250
        Me.GridColumnPurpose.Name = "GridColumnPurpose"
        Me.GridColumnPurpose.Visible = True
        Me.GridColumnPurpose.VisibleIndex = 3
        Me.GridColumnPurpose.Width = 250
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemMemoEdit1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'GridColumnDateCreated
        '
        Me.GridColumnDateCreated.Caption = "Date Created"
        Me.GridColumnDateCreated.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnDateCreated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDateCreated.FieldName = "date_created"
        Me.GridColumnDateCreated.Name = "GridColumnDateCreated"
        Me.GridColumnDateCreated.Visible = True
        Me.GridColumnDateCreated.VisibleIndex = 1
        '
        'GridColumnReconcileDueDate
        '
        Me.GridColumnReconcileDueDate.Caption = "Reconcile Due Date"
        Me.GridColumnReconcileDueDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnReconcileDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnReconcileDueDate.FieldName = "report_back_due_date"
        Me.GridColumnReconcileDueDate.Name = "GridColumnReconcileDueDate"
        Me.GridColumnReconcileDueDate.Visible = True
        Me.GridColumnReconcileDueDate.VisibleIndex = 5
        '
        'GridColumnReconcileActualDate
        '
        Me.GridColumnReconcileActualDate.Caption = "Actual Reconcile Date"
        Me.GridColumnReconcileActualDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnReconcileActualDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnReconcileActualDate.FieldName = "act_report_back_date"
        Me.GridColumnReconcileActualDate.Name = "GridColumnReconcileActualDate"
        Me.GridColumnReconcileActualDate.Visible = True
        Me.GridColumnReconcileActualDate.VisibleIndex = 6
        '
        'GridColumnCashInAdvance
        '
        Me.GridColumnCashInAdvance.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCashInAdvance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCashInAdvance.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCashInAdvance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCashInAdvance.Caption = "Cash In Advance"
        Me.GridColumnCashInAdvance.DisplayFormat.FormatString = "N2"
        Me.GridColumnCashInAdvance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCashInAdvance.FieldName = "val_ca_actual"
        Me.GridColumnCashInAdvance.Name = "GridColumnCashInAdvance"
        Me.GridColumnCashInAdvance.Visible = True
        Me.GridColumnCashInAdvance.VisibleIndex = 8
        '
        'GridColumnCashInAdvancePeriode
        '
        Me.GridColumnCashInAdvancePeriode.Caption = "Cash In Advance (Periode)"
        Me.GridColumnCashInAdvancePeriode.DisplayFormat.FormatString = "N2"
        Me.GridColumnCashInAdvancePeriode.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCashInAdvancePeriode.FieldName = "val_ca"
        Me.GridColumnCashInAdvancePeriode.Name = "GridColumnCashInAdvancePeriode"
        Me.GridColumnCashInAdvancePeriode.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "val_ca", "{0:N2}")})
        Me.GridColumnCashInAdvancePeriode.Visible = True
        Me.GridColumnCashInAdvancePeriode.VisibleIndex = 7
        '
        'GridColumnCOA
        '
        Me.GridColumnCOA.Caption = "COA Expense"
        Me.GridColumnCOA.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.GridColumnCOA.FieldName = "coa"
        Me.GridColumnCOA.Name = "GridColumnCOA"
        Me.GridColumnCOA.Visible = True
        Me.GridColumnCOA.VisibleIndex = 9
        '
        'GridColumnCOADesc
        '
        Me.GridColumnCOADesc.Caption = "COA Expense Description"
        Me.GridColumnCOADesc.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.GridColumnCOADesc.FieldName = "coa_desc"
        Me.GridColumnCOADesc.Name = "GridColumnCOADesc"
        Me.GridColumnCOADesc.Visible = True
        Me.GridColumnCOADesc.VisibleIndex = 10
        '
        'GridColumnCoaExpense
        '
        Me.GridColumnCoaExpense.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCoaExpense.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCoaExpense.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridColumnCoaExpense.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCoaExpense.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCoaExpense.Caption = "Expense"
        Me.GridColumnCoaExpense.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.GridColumnCoaExpense.FieldName = "coa_expense"
        Me.GridColumnCoaExpense.MinWidth = 80
        Me.GridColumnCoaExpense.Name = "GridColumnCoaExpense"
        Me.GridColumnCoaExpense.Visible = True
        Me.GridColumnCoaExpense.VisibleIndex = 11
        Me.GridColumnCoaExpense.Width = 120
        '
        'GridColumnExpense
        '
        Me.GridColumnExpense.Caption = "Total Expense"
        Me.GridColumnExpense.DisplayFormat.FormatString = "N2"
        Me.GridColumnExpense.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnExpense.FieldName = "expense"
        Me.GridColumnExpense.MinWidth = 100
        Me.GridColumnExpense.Name = "GridColumnExpense"
        Me.GridColumnExpense.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "expense", "{0:N2}")})
        Me.GridColumnExpense.Visible = True
        Me.GridColumnExpense.VisibleIndex = 12
        Me.GridColumnExpense.Width = 100
        '
        'GridColumnAdvance
        '
        Me.GridColumnAdvance.Caption = "Advance"
        Me.GridColumnAdvance.DisplayFormat.FormatString = "N2"
        Me.GridColumnAdvance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAdvance.FieldName = "advance"
        Me.GridColumnAdvance.Name = "GridColumnAdvance"
        Me.GridColumnAdvance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "advance", "{0:N2}")})
        Me.GridColumnAdvance.Visible = True
        Me.GridColumnAdvance.VisibleIndex = 13
        '
        'GridColumnCashOnHandOut
        '
        Me.GridColumnCashOnHandOut.Caption = "Cash On Hand Out"
        Me.GridColumnCashOnHandOut.DisplayFormat.FormatString = "N2"
        Me.GridColumnCashOnHandOut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCashOnHandOut.FieldName = "cash_out"
        Me.GridColumnCashOnHandOut.Name = "GridColumnCashOnHandOut"
        Me.GridColumnCashOnHandOut.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cash_out", "{0:N2}")})
        Me.GridColumnCashOnHandOut.Visible = True
        Me.GridColumnCashOnHandOut.VisibleIndex = 14
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Proposal Status (updated)"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 4
        '
        'GridColumnOverdue
        '
        Me.GridColumnOverdue.Caption = "Overdue (days)"
        Me.GridColumnOverdue.FieldName = "overdue"
        Me.GridColumnOverdue.Name = "GridColumnOverdue"
        Me.GridColumnOverdue.Visible = True
        Me.GridColumnOverdue.VisibleIndex = 15
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'BSummaryReport
        '
        Me.BSummaryReport.Location = New System.Drawing.Point(723, 10)
        Me.BSummaryReport.Name = "BSummaryReport"
        Me.BSummaryReport.Size = New System.Drawing.Size(131, 23)
        Me.BSummaryReport.TabIndex = 8941
        Me.BSummaryReport.Text = "Print Summary Report"
        '
        'FormCashAdvanceReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 581)
        Me.Controls.Add(Me.GCReport)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormCashAdvanceReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Cash Advance"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCReport As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVReport As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents DateTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDateCreated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReconcileDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReconcileActualDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCashInAdvancePeriode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnExpense As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAdvance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCashOnHandOut As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPurpose As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCashInAdvance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOverdue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BPrintAdvance As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPrintDefault As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnCOA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCOADesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCoaExpense As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents BSummaryReport As DevExpress.XtraEditors.SimpleButton
End Class
