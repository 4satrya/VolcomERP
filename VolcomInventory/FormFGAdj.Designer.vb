﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGAdj
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGAdj))
        Me.XTCAdj = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPAdjIn = New DevExpress.XtraTab.XtraTabPage()
        Me.GCAdjIn = New DevExpress.XtraGrid.GridControl()
        Me.GVAdjIn = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdAdjInSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumberAdjInSampleNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAdjInSampleDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCurrencyAdjInSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnretail_price_total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnaccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnSummaryIn = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPAdjOut = New DevExpress.XtraTab.XtraTabPage()
        Me.GCAdjOut = New DevExpress.XtraGrid.GridControl()
        Me.GVAdjOut = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnretail_price_total_Out = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_qty_out = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnaccount_out = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnSummaryOut = New DevExpress.XtraEditors.SimpleButton()
        Me.DEInFrom = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DEInTo = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SBInView = New DevExpress.XtraEditors.SimpleButton()
        Me.SBOutView = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DEOutTo = New DevExpress.XtraEditors.DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DEOutFrom = New DevExpress.XtraEditors.DateEdit()
        CType(Me.XTCAdj, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCAdj.SuspendLayout()
        Me.XTPAdjIn.SuspendLayout()
        CType(Me.GCAdjIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAdjIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.XTPAdjOut.SuspendLayout()
        CType(Me.GCAdjOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAdjOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DEInFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEInFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEInTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEInTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEOutTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEOutTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEOutFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEOutFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCAdj
        '
        Me.XTCAdj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCAdj.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCAdj.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCAdj.Location = New System.Drawing.Point(0, 0)
        Me.XTCAdj.Name = "XTCAdj"
        Me.XTCAdj.SelectedTabPage = Me.XTPAdjIn
        Me.XTCAdj.Size = New System.Drawing.Size(754, 451)
        Me.XTCAdj.TabIndex = 6
        Me.XTCAdj.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPAdjIn, Me.XTPAdjOut})
        '
        'XTPAdjIn
        '
        Me.XTPAdjIn.Controls.Add(Me.GCAdjIn)
        Me.XTPAdjIn.Controls.Add(Me.PanelControl1)
        Me.XTPAdjIn.Name = "XTPAdjIn"
        Me.XTPAdjIn.Size = New System.Drawing.Size(658, 445)
        Me.XTPAdjIn.Text = "Adjustment In"
        '
        'GCAdjIn
        '
        Me.GCAdjIn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAdjIn.Location = New System.Drawing.Point(0, 42)
        Me.GCAdjIn.MainView = Me.GVAdjIn
        Me.GCAdjIn.Name = "GCAdjIn"
        Me.GCAdjIn.Size = New System.Drawing.Size(658, 403)
        Me.GCAdjIn.TabIndex = 0
        Me.GCAdjIn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAdjIn})
        '
        'GVAdjIn
        '
        Me.GVAdjIn.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdAdjInSample, Me.GridColumnNumberAdjInSampleNumber, Me.GridColumnAdjInSampleDate, Me.GridColumnCurrencyAdjInSample, Me.GridColumnAmount, Me.GridColumnReportStatus, Me.GridColumnretail_price_total, Me.GridColumntotal_qty, Me.GridColumnaccount})
        Me.GVAdjIn.GridControl = Me.GCAdjIn
        Me.GVAdjIn.Name = "GVAdjIn"
        Me.GVAdjIn.OptionsBehavior.Editable = False
        Me.GVAdjIn.OptionsFind.AlwaysVisible = True
        Me.GVAdjIn.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdAdjInSample
        '
        Me.GridColumnIdAdjInSample.Caption = "Id Adj In Sample"
        Me.GridColumnIdAdjInSample.FieldName = "id_adj_in_fg"
        Me.GridColumnIdAdjInSample.Name = "GridColumnIdAdjInSample"
        '
        'GridColumnNumberAdjInSampleNumber
        '
        Me.GridColumnNumberAdjInSampleNumber.Caption = "Number"
        Me.GridColumnNumberAdjInSampleNumber.FieldName = "adj_in_fg_number"
        Me.GridColumnNumberAdjInSampleNumber.Name = "GridColumnNumberAdjInSampleNumber"
        Me.GridColumnNumberAdjInSampleNumber.Visible = True
        Me.GridColumnNumberAdjInSampleNumber.VisibleIndex = 0
        '
        'GridColumnAdjInSampleDate
        '
        Me.GridColumnAdjInSampleDate.Caption = "Created Date"
        Me.GridColumnAdjInSampleDate.FieldName = "adj_in_fg_datex"
        Me.GridColumnAdjInSampleDate.Name = "GridColumnAdjInSampleDate"
        Me.GridColumnAdjInSampleDate.Visible = True
        Me.GridColumnAdjInSampleDate.VisibleIndex = 1
        '
        'GridColumnCurrencyAdjInSample
        '
        Me.GridColumnCurrencyAdjInSample.Caption = "Currency"
        Me.GridColumnCurrencyAdjInSample.FieldName = "currency"
        Me.GridColumnCurrencyAdjInSample.Name = "GridColumnCurrencyAdjInSample"
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "n2"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "adj_in_fg_total"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 4
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 6
        '
        'GridColumnretail_price_total
        '
        Me.GridColumnretail_price_total.Caption = "Amount Price"
        Me.GridColumnretail_price_total.DisplayFormat.FormatString = "N0"
        Me.GridColumnretail_price_total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnretail_price_total.FieldName = "retail_price_total"
        Me.GridColumnretail_price_total.Name = "GridColumnretail_price_total"
        Me.GridColumnretail_price_total.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "retail_price_total", "{0:N0}")})
        Me.GridColumnretail_price_total.Visible = True
        Me.GridColumnretail_price_total.VisibleIndex = 5
        '
        'GridColumntotal_qty
        '
        Me.GridColumntotal_qty.Caption = "Total Qty"
        Me.GridColumntotal_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_qty.FieldName = "total_qty"
        Me.GridColumntotal_qty.Name = "GridColumntotal_qty"
        Me.GridColumntotal_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", "{0:N0}")})
        Me.GridColumntotal_qty.Visible = True
        Me.GridColumntotal_qty.VisibleIndex = 3
        '
        'GridColumnaccount
        '
        Me.GridColumnaccount.Caption = "Account"
        Me.GridColumnaccount.FieldName = "account"
        Me.GridColumnaccount.Name = "GridColumnaccount"
        Me.GridColumnaccount.Visible = True
        Me.GridColumnaccount.VisibleIndex = 2
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBInView)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.DEInTo)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.DEInFrom)
        Me.PanelControl1.Controls.Add(Me.BtnSummaryIn)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(658, 42)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnSummaryIn
        '
        Me.BtnSummaryIn.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSummaryIn.Image = CType(resources.GetObject("BtnSummaryIn.Image"), System.Drawing.Image)
        Me.BtnSummaryIn.Location = New System.Drawing.Point(562, 2)
        Me.BtnSummaryIn.Name = "BtnSummaryIn"
        Me.BtnSummaryIn.Size = New System.Drawing.Size(94, 38)
        Me.BtnSummaryIn.TabIndex = 0
        Me.BtnSummaryIn.Text = "Summary"
        '
        'XTPAdjOut
        '
        Me.XTPAdjOut.Controls.Add(Me.GCAdjOut)
        Me.XTPAdjOut.Controls.Add(Me.PanelControl2)
        Me.XTPAdjOut.Name = "XTPAdjOut"
        Me.XTPAdjOut.Size = New System.Drawing.Size(658, 445)
        Me.XTPAdjOut.Text = "Adjustment Out"
        '
        'GCAdjOut
        '
        Me.GCAdjOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAdjOut.Location = New System.Drawing.Point(0, 42)
        Me.GCAdjOut.MainView = Me.GVAdjOut
        Me.GCAdjOut.Name = "GCAdjOut"
        Me.GCAdjOut.Size = New System.Drawing.Size(658, 403)
        Me.GCAdjOut.TabIndex = 2
        Me.GCAdjOut.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAdjOut})
        '
        'GVAdjOut
        '
        Me.GVAdjOut.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumnretail_price_total_Out, Me.GridColumntotal_qty_out, Me.GridColumnaccount_out})
        Me.GVAdjOut.GridControl = Me.GCAdjOut
        Me.GVAdjOut.Name = "GVAdjOut"
        Me.GVAdjOut.OptionsBehavior.Editable = False
        Me.GVAdjOut.OptionsFind.AlwaysVisible = True
        Me.GVAdjOut.OptionsView.ShowGroupPanel = False
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Id Adj Out Sample"
        Me.GridColumn7.FieldName = "id_adj_out_fg"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Number"
        Me.GridColumn8.FieldName = "adj_out_fg_number"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Created Date"
        Me.GridColumn9.FieldName = "adj_out_fg_datex"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 1
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Currency"
        Me.GridColumn10.FieldName = "currency"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Amount"
        Me.GridColumn11.DisplayFormat.FormatString = "n2"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "adj_out_fg_total"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 4
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Status"
        Me.GridColumn12.FieldName = "report_status"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 6
        '
        'GridColumnretail_price_total_Out
        '
        Me.GridColumnretail_price_total_Out.Caption = "Amount Price"
        Me.GridColumnretail_price_total_Out.DisplayFormat.FormatString = "N0"
        Me.GridColumnretail_price_total_Out.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnretail_price_total_Out.FieldName = "retail_price_total"
        Me.GridColumnretail_price_total_Out.Name = "GridColumnretail_price_total_Out"
        Me.GridColumnretail_price_total_Out.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "retail_price_total", "{0:N0}")})
        Me.GridColumnretail_price_total_Out.Visible = True
        Me.GridColumnretail_price_total_Out.VisibleIndex = 5
        '
        'GridColumntotal_qty_out
        '
        Me.GridColumntotal_qty_out.Caption = "Total Qty"
        Me.GridColumntotal_qty_out.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_qty_out.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_qty_out.FieldName = "total_qty"
        Me.GridColumntotal_qty_out.Name = "GridColumntotal_qty_out"
        Me.GridColumntotal_qty_out.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_qty", "{0:N0}")})
        Me.GridColumntotal_qty_out.Visible = True
        Me.GridColumntotal_qty_out.VisibleIndex = 3
        '
        'GridColumnaccount_out
        '
        Me.GridColumnaccount_out.Caption = "Account"
        Me.GridColumnaccount_out.FieldName = "account"
        Me.GridColumnaccount_out.Name = "GridColumnaccount_out"
        Me.GridColumnaccount_out.Visible = True
        Me.GridColumnaccount_out.VisibleIndex = 2
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SBOutView)
        Me.PanelControl2.Controls.Add(Me.Label3)
        Me.PanelControl2.Controls.Add(Me.DEOutTo)
        Me.PanelControl2.Controls.Add(Me.Label4)
        Me.PanelControl2.Controls.Add(Me.DEOutFrom)
        Me.PanelControl2.Controls.Add(Me.BtnSummaryOut)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(658, 42)
        Me.PanelControl2.TabIndex = 3
        '
        'BtnSummaryOut
        '
        Me.BtnSummaryOut.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSummaryOut.Image = CType(resources.GetObject("BtnSummaryOut.Image"), System.Drawing.Image)
        Me.BtnSummaryOut.Location = New System.Drawing.Point(562, 2)
        Me.BtnSummaryOut.Name = "BtnSummaryOut"
        Me.BtnSummaryOut.Size = New System.Drawing.Size(94, 38)
        Me.BtnSummaryOut.TabIndex = 0
        Me.BtnSummaryOut.Text = "Summary"
        '
        'DEInFrom
        '
        Me.DEInFrom.EditValue = Nothing
        Me.DEInFrom.Location = New System.Drawing.Point(94, 11)
        Me.DEInFrom.Name = "DEInFrom"
        Me.DEInFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEInFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEInFrom.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEInFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEInFrom.Size = New System.Drawing.Size(138, 20)
        Me.DEInFrom.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Created Date"
        '
        'DEInTo
        '
        Me.DEInTo.EditValue = Nothing
        Me.DEInTo.Location = New System.Drawing.Point(255, 11)
        Me.DEInTo.Name = "DEInTo"
        Me.DEInTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEInTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEInTo.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEInTo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEInTo.Size = New System.Drawing.Size(138, 20)
        Me.DEInTo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(238, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "-"
        '
        'SBInView
        '
        Me.SBInView.Location = New System.Drawing.Point(399, 9)
        Me.SBInView.Name = "SBInView"
        Me.SBInView.Size = New System.Drawing.Size(75, 23)
        Me.SBInView.TabIndex = 4
        Me.SBInView.Text = "View"
        '
        'SBOutView
        '
        Me.SBOutView.Location = New System.Drawing.Point(399, 9)
        Me.SBOutView.Name = "SBOutView"
        Me.SBOutView.Size = New System.Drawing.Size(75, 23)
        Me.SBOutView.TabIndex = 9
        Me.SBOutView.Text = "View"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(238, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "-"
        '
        'DEOutTo
        '
        Me.DEOutTo.EditValue = Nothing
        Me.DEOutTo.Location = New System.Drawing.Point(255, 11)
        Me.DEOutTo.Name = "DEOutTo"
        Me.DEOutTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOutTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOutTo.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEOutTo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEOutTo.Size = New System.Drawing.Size(138, 20)
        Me.DEOutTo.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Created Date"
        '
        'DEOutFrom
        '
        Me.DEOutFrom.EditValue = Nothing
        Me.DEOutFrom.Location = New System.Drawing.Point(94, 11)
        Me.DEOutFrom.Name = "DEOutFrom"
        Me.DEOutFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOutFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEOutFrom.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEOutFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEOutFrom.Size = New System.Drawing.Size(138, 20)
        Me.DEOutFrom.TabIndex = 5
        '
        'FormFGAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 451)
        Me.Controls.Add(Me.XTCAdj)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFGAdj"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adjustment Finished Goods"
        CType(Me.XTCAdj, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCAdj.ResumeLayout(False)
        Me.XTPAdjIn.ResumeLayout(False)
        CType(Me.GCAdjIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAdjIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.XTPAdjOut.ResumeLayout(False)
        CType(Me.GCAdjOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAdjOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DEInFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEInFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEInTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEInTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEOutTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEOutTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEOutFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEOutFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCAdj As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPAdjIn As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCAdjIn As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAdjIn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdAdjInSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumberAdjInSampleNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAdjInSampleDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurrencyAdjInSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPAdjOut As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCAdjOut As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAdjOut As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSummaryIn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnSummaryOut As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnretail_price_total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnretail_price_total_Out As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnaccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_qty_out As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnaccount_out As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SBInView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As Label
    Friend WithEvents DEInTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents DEInFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SBOutView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As Label
    Friend WithEvents DEOutTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents DEOutFrom As DevExpress.XtraEditors.DateEdit
End Class
