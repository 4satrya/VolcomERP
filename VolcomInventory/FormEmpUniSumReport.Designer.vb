<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpUniSumReport
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
        Me.XTCUniReport = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPByPeriod = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPeriod = New DevExpress.XtraGrid.GridControl()
        Me.GVPeriod = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBudget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnActual = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LEPeriodx = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPByYear = New DevExpress.XtraTab.XtraTabPage()
        Me.GCByDate = New DevExpress.XtraGrid.GridControl()
        Me.GVByDate = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.BtnViewByDate = New DevExpress.XtraEditors.SimpleButton()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SBDView = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.DEDTo = New DevExpress.XtraEditors.DateEdit()
        Me.DEDFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.GVDetail = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.XTCUniReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCUniReport.SuspendLayout()
        Me.XTPByPeriod.SuspendLayout()
        CType(Me.GCPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEPeriodx.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPByYear.SuspendLayout()
        CType(Me.GCByDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVByDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPDetail.SuspendLayout()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.DEDTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCUniReport
        '
        Me.XTCUniReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCUniReport.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCUniReport.Location = New System.Drawing.Point(0, 0)
        Me.XTCUniReport.Name = "XTCUniReport"
        Me.XTCUniReport.SelectedTabPage = Me.XTPByPeriod
        Me.XTCUniReport.Size = New System.Drawing.Size(803, 568)
        Me.XTCUniReport.TabIndex = 0
        Me.XTCUniReport.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPByPeriod, Me.XTPByYear, Me.XTPDetail})
        '
        'XTPByPeriod
        '
        Me.XTPByPeriod.Controls.Add(Me.GCPeriod)
        Me.XTPByPeriod.Controls.Add(Me.PanelControl1)
        Me.XTPByPeriod.Name = "XTPByPeriod"
        Me.XTPByPeriod.Size = New System.Drawing.Size(797, 540)
        Me.XTPByPeriod.Text = "Summary by Uniform Period"
        '
        'GCPeriod
        '
        Me.GCPeriod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPeriod.Location = New System.Drawing.Point(0, 41)
        Me.GCPeriod.MainView = Me.GVPeriod
        Me.GCPeriod.Name = "GCPeriod"
        Me.GCPeriod.Size = New System.Drawing.Size(797, 499)
        Me.GCPeriod.TabIndex = 2
        Me.GCPeriod.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPeriod})
        '
        'GVPeriod
        '
        Me.GVPeriod.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdDept, Me.GridColumnDept, Me.GridColumnBudget, Me.GridColumnActual, Me.GridColumnQty})
        Me.GVPeriod.GridControl = Me.GCPeriod
        Me.GVPeriod.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "budget", Me.GridColumnBudget, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "actual", Me.GridColumnActual, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumnQty, "{0:N0}")})
        Me.GVPeriod.Name = "GVPeriod"
        Me.GVPeriod.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPeriod.OptionsBehavior.Editable = False
        Me.GVPeriod.OptionsView.ShowFooter = True
        Me.GVPeriod.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdDept
        '
        Me.GridColumnIdDept.Caption = "Id Departement"
        Me.GridColumnIdDept.FieldName = "id_departement"
        Me.GridColumnIdDept.Name = "GridColumnIdDept"
        '
        'GridColumnDept
        '
        Me.GridColumnDept.Caption = "Department"
        Me.GridColumnDept.FieldName = "departement"
        Me.GridColumnDept.Name = "GridColumnDept"
        Me.GridColumnDept.Visible = True
        Me.GridColumnDept.VisibleIndex = 0
        '
        'GridColumnBudget
        '
        Me.GridColumnBudget.Caption = "Budget"
        Me.GridColumnBudget.DisplayFormat.FormatString = "N2"
        Me.GridColumnBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBudget.FieldName = "budget"
        Me.GridColumnBudget.Name = "GridColumnBudget"
        Me.GridColumnBudget.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "budget", "{0:N2}")})
        Me.GridColumnBudget.Visible = True
        Me.GridColumnBudget.VisibleIndex = 1
        '
        'GridColumnActual
        '
        Me.GridColumnActual.Caption = "Actual"
        Me.GridColumnActual.DisplayFormat.FormatString = "N2"
        Me.GridColumnActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnActual.FieldName = "actual"
        Me.GridColumnActual.Name = "GridColumnActual"
        Me.GridColumnActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "actual", "{0:N2}")})
        Me.GridColumnActual.Visible = True
        Me.GridColumnActual.VisibleIndex = 2
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 3
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.LEPeriodx)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(797, 41)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(437, 9)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 23)
        Me.BtnView.TabIndex = 17
        Me.BtnView.Text = "View"
        '
        'LEPeriodx
        '
        Me.LEPeriodx.Location = New System.Drawing.Point(51, 11)
        Me.LEPeriodx.Name = "LEPeriodx"
        Me.LEPeriodx.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPeriodx.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_emp_uni_period", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("period_name", "Period"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("selection_date_start", "Start", 20, DevExpress.Utils.FormatType.DateTime, "dd\/MM\/yyyy", True, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("selection_date_end", "End", 20, DevExpress.Utils.FormatType.DateTime, "dd\/MM\/yyyy", True, DevExpress.Utils.HorzAlignment.[Default])})
        Me.LEPeriodx.Size = New System.Drawing.Size(380, 20)
        Me.LEPeriodx.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Period"
        '
        'XTPByYear
        '
        Me.XTPByYear.Controls.Add(Me.GCByDate)
        Me.XTPByYear.Controls.Add(Me.GCFilter)
        Me.XTPByYear.Name = "XTPByYear"
        Me.XTPByYear.Size = New System.Drawing.Size(797, 540)
        Me.XTPByYear.Text = "Summary by Date"
        '
        'GCByDate
        '
        Me.GCByDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCByDate.Location = New System.Drawing.Point(0, 39)
        Me.GCByDate.MainView = Me.GVByDate
        Me.GCByDate.Name = "GCByDate"
        Me.GCByDate.Size = New System.Drawing.Size(797, 501)
        Me.GCByDate.TabIndex = 5
        Me.GCByDate.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVByDate})
        '
        'GVByDate
        '
        Me.GVByDate.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.GVByDate.GridControl = Me.GCByDate
        Me.GVByDate.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "budget", Me.GridColumn3, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "actual", Me.GridColumn4, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumn5, "{0:N0}")})
        Me.GVByDate.Name = "GVByDate"
        Me.GVByDate.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVByDate.OptionsBehavior.Editable = False
        Me.GVByDate.OptionsView.ShowFooter = True
        Me.GVByDate.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Departement"
        Me.GridColumn1.FieldName = "id_departement"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Department"
        Me.GridColumn2.FieldName = "departement"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Budget"
        Me.GridColumn3.DisplayFormat.FormatString = "N2"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "budget"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "budget", "{0:N2}")})
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Actual"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "actual"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "actual", "{0:N2}")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Qty"
        Me.GridColumn5.DisplayFormat.FormatString = "N0"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "qty"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.BtnViewByDate)
        Me.GCFilter.Controls.Add(Me.BHide)
        Me.GCFilter.Controls.Add(Me.BExpand)
        Me.GCFilter.Controls.Add(Me.DEUntil)
        Me.GCFilter.Controls.Add(Me.DEFrom)
        Me.GCFilter.Controls.Add(Me.LabelControl2)
        Me.GCFilter.Controls.Add(Me.LabelControl3)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(797, 39)
        Me.GCFilter.TabIndex = 4
        '
        'BtnViewByDate
        '
        Me.BtnViewByDate.Location = New System.Drawing.Point(317, 9)
        Me.BtnViewByDate.LookAndFeel.SkinName = "Blue"
        Me.BtnViewByDate.Name = "BtnViewByDate"
        Me.BtnViewByDate.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewByDate.TabIndex = 8896
        Me.BtnViewByDate.Text = "View"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(938, 14)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'BExpand
        '
        Me.BExpand.ImageIndex = 8
        Me.BExpand.Location = New System.Drawing.Point(835, 14)
        Me.BExpand.Name = "BExpand"
        Me.BExpand.Size = New System.Drawing.Size(99, 20)
        Me.BExpand.TabIndex = 8897
        Me.BExpand.Text = "Expand All Detail"
        Me.BExpand.Visible = False
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(202, 9)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(111, 20)
        Me.DEUntil.TabIndex = 8895
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(58, 9)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8894
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(175, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8893
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8892
        Me.LabelControl3.Text = "From"
        '
        'XTPDetail
        '
        Me.XTPDetail.Controls.Add(Me.GCDetail)
        Me.XTPDetail.Controls.Add(Me.GroupControl1)
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(797, 540)
        Me.XTPDetail.Text = "Detail by Date"
        '
        'GCDetail
        '
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 39)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.Size = New System.Drawing.Size(797, 501)
        Me.GCDetail.TabIndex = 6
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.SBDView)
        Me.GroupControl1.Controls.Add(Me.SimpleButton2)
        Me.GroupControl1.Controls.Add(Me.SimpleButton3)
        Me.GroupControl1.Controls.Add(Me.DEDTo)
        Me.GroupControl1.Controls.Add(Me.DEDFrom)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(797, 39)
        Me.GroupControl1.TabIndex = 5
        '
        'SBDView
        '
        Me.SBDView.Location = New System.Drawing.Point(317, 9)
        Me.SBDView.LookAndFeel.SkinName = "Blue"
        Me.SBDView.Name = "SBDView"
        Me.SBDView.Size = New System.Drawing.Size(75, 20)
        Me.SBDView.TabIndex = 8896
        Me.SBDView.Text = "View"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageIndex = 9
        Me.SimpleButton2.Location = New System.Drawing.Point(938, 14)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(104, 20)
        Me.SimpleButton2.TabIndex = 8898
        Me.SimpleButton2.Text = "Hide All Detail"
        Me.SimpleButton2.Visible = False
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageIndex = 8
        Me.SimpleButton3.Location = New System.Drawing.Point(835, 14)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(99, 20)
        Me.SimpleButton3.TabIndex = 8897
        Me.SimpleButton3.Text = "Expand All Detail"
        Me.SimpleButton3.Visible = False
        '
        'DEDTo
        '
        Me.DEDTo.EditValue = Nothing
        Me.DEDTo.Location = New System.Drawing.Point(202, 9)
        Me.DEDTo.Name = "DEDTo"
        Me.DEDTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEDTo.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEDTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDTo.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEDTo.Size = New System.Drawing.Size(111, 20)
        Me.DEDTo.TabIndex = 8895
        '
        'DEDFrom
        '
        Me.DEDFrom.EditValue = Nothing
        Me.DEDFrom.Location = New System.Drawing.Point(58, 9)
        Me.DEDFrom.Name = "DEDFrom"
        Me.DEDFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEDFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEDFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEDFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEDFrom.TabIndex = 8894
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(175, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl4.TabIndex = 8893
        Me.LabelControl4.Text = "Until"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl5.TabIndex = 8892
        Me.LabelControl5.Text = "From"
        '
        'GVDetail
        '
        Me.GVDetail.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand6, Me.gridBand2, Me.gridBand3, Me.gridBand4, Me.gridBand5, Me.gridBand7})
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.BandedGridColumn9, Me.GridColumn9, Me.BandedGridColumn1, Me.GridColumn15, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.BandedGridColumn5, Me.BandedGridColumn6, Me.BandedGridColumn7, Me.BandedGridColumn8, Me.GridColumn11, Me.GridColumn10, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "design_cop", Me.GridColumn13, "{0:N4}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_order_det_qty", Me.GridColumn14, "{0:N2}")})
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDetail.OptionsBehavior.ReadOnly = True
        Me.GVDetail.OptionsView.ShowFooter = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "NIK"
        Me.GridColumn6.FieldName = "employee_code"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Name"
        Me.GridColumn7.FieldName = "employee_name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Departement"
        Me.GridColumn8.FieldName = "departement"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Number"
        Me.GridColumn9.FieldName = "sales_order_number"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Category"
        Me.GridColumn15.FieldName = "so_status"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Code"
        Me.GridColumn11.FieldName = "product_full_code"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Name"
        Me.GridColumn10.FieldName = "product_display_name"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Size"
        Me.GridColumn12.FieldName = "code_detail_name"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Cost"
        Me.GridColumn13.DisplayFormat.FormatString = "N4"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "design_cop"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "design_cop", "{0:N4}")})
        Me.GridColumn13.Visible = True
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Qty"
        Me.GridColumn14.DisplayFormat.FormatString = "N2"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "sales_order_det_qty"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_order_det_qty", "{0:N2}")})
        Me.GridColumn14.Visible = True
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "Date"
        Me.BandedGridColumn1.FieldName = "sales_order_date"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "Status"
        Me.BandedGridColumn2.FieldName = "report_status_so"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Number"
        Me.BandedGridColumn3.FieldName = "pl_sales_order_del_number"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Date"
        Me.BandedGridColumn4.FieldName = "pl_sales_order_del_date"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.Visible = True
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "Status"
        Me.BandedGridColumn5.FieldName = "report_status_del"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.Visible = True
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "Number"
        Me.BandedGridColumn6.FieldName = "emp_uni_ex_number"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.Visible = True
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.Caption = "Date"
        Me.BandedGridColumn7.FieldName = "emp_uni_ex_date"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.Visible = True
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.Caption = "Status"
        Me.BandedGridColumn8.FieldName = "report_status_ex"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.Visible = True
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.Caption = "Period"
        Me.BandedGridColumn9.FieldName = "period_name"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.Visible = True
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Employee"
        Me.GridBand1.Columns.Add(Me.GridColumn6)
        Me.GridBand1.Columns.Add(Me.GridColumn7)
        Me.GridBand1.Columns.Add(Me.GridColumn8)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 225
        '
        'gridBand6
        '
        Me.gridBand6.Caption = "Period"
        Me.gridBand6.Columns.Add(Me.BandedGridColumn9)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 1
        Me.gridBand6.Width = 75
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "Order"
        Me.gridBand2.Columns.Add(Me.GridColumn9)
        Me.gridBand2.Columns.Add(Me.BandedGridColumn1)
        Me.gridBand2.Columns.Add(Me.GridColumn15)
        Me.gridBand2.Columns.Add(Me.BandedGridColumn2)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 2
        Me.gridBand2.Width = 300
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "Delivery"
        Me.gridBand3.Columns.Add(Me.BandedGridColumn3)
        Me.gridBand3.Columns.Add(Me.BandedGridColumn4)
        Me.gridBand3.Columns.Add(Me.BandedGridColumn5)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 3
        Me.gridBand3.Width = 225
        '
        'gridBand4
        '
        Me.gridBand4.Caption = "Expense"
        Me.gridBand4.Columns.Add(Me.BandedGridColumn6)
        Me.gridBand4.Columns.Add(Me.BandedGridColumn7)
        Me.gridBand4.Columns.Add(Me.BandedGridColumn8)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 4
        Me.gridBand4.Width = 225
        '
        'gridBand5
        '
        Me.gridBand5.Caption = "Product"
        Me.gridBand5.Columns.Add(Me.GridColumn11)
        Me.gridBand5.Columns.Add(Me.GridColumn10)
        Me.gridBand5.Columns.Add(Me.GridColumn12)
        Me.gridBand5.Columns.Add(Me.GridColumn13)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 5
        Me.gridBand5.Width = 300
        '
        'gridBand7
        '
        Me.gridBand7.Caption = "Qty"
        Me.gridBand7.Columns.Add(Me.GridColumn14)
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.VisibleIndex = 6
        Me.gridBand7.Width = 75
        '
        'FormEmpUniSumReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 568)
        Me.Controls.Add(Me.XTCUniReport)
        Me.MinimizeBox = False
        Me.Name = "FormEmpUniSumReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Uniform Report"
        CType(Me.XTCUniReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCUniReport.ResumeLayout(False)
        Me.XTPByPeriod.ResumeLayout(False)
        CType(Me.GCPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LEPeriodx.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPByYear.ResumeLayout(False)
        CType(Me.GCByDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVByDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPDetail.ResumeLayout(False)
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.DEDTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCUniReport As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPByPeriod As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPByYear As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LEPeriodx As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCPeriod As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPeriod As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBudget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnActual As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnViewByDate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BExpand As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCByDate As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVByDate As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SBDView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEDTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEDFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
