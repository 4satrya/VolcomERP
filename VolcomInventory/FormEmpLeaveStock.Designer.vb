<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpLeaveStock
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LEDeptSum = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LEEmpSum = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GVSLEDesgSearch = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCodeSearch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.BViewSum = New DevExpress.XtraEditors.SimpleButton()
        Me.GCSum = New DevExpress.XtraGrid.GridControl()
        Me.GVSum = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPositiion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLevels = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLeaveRemaining = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDPRemaining = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAdvanceLeave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnHLeaveRemaining = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnHDPRemaining = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnHAdvLeaveRemaining = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnHTotLeave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTCLeaveRemaining = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPSum = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.GVSchedule = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIDSchedule = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmpPosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDateExpired = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCSchedule = New DevExpress.XtraGrid.GridControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEEmpSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCLeaveRemaining, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCLeaveRemaining.SuspendLayout()
        Me.XTPSum.SuspendLayout()
        Me.XTPDetail.SuspendLayout()
        CType(Me.GVSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LEDeptSum)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.LEEmpSum)
        Me.PanelControl1.Controls.Add(Me.LabelControl9)
        Me.PanelControl1.Controls.Add(Me.BViewSum)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(633, 38)
        Me.PanelControl1.TabIndex = 3
        '
        'LEDeptSum
        '
        Me.LEDeptSum.Location = New System.Drawing.Point(81, 9)
        Me.LEDeptSum.Name = "LEDeptSum"
        Me.LEDeptSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDeptSum.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "Id Departement", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departemen")})
        Me.LEDeptSum.Size = New System.Drawing.Size(151, 20)
        Me.LEDeptSum.TabIndex = 8900
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl1.TabIndex = 8899
        Me.LabelControl1.Text = "Departement"
        '
        'LEEmpSum
        '
        Me.LEEmpSum.Location = New System.Drawing.Point(290, 9)
        Me.LEEmpSum.Name = "LEEmpSum"
        Me.LEEmpSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEEmpSum.Properties.View = Me.GVSLEDesgSearch
        Me.LEEmpSum.Size = New System.Drawing.Size(195, 20)
        Me.LEEmpSum.TabIndex = 8898
        '
        'GVSLEDesgSearch
        '
        Me.GVSLEDesgSearch.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumnCodeSearch, Me.GridColumn7})
        Me.GVSLEDesgSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GVSLEDesgSearch.Name = "GVSLEDesgSearch"
        Me.GVSLEDesgSearch.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVSLEDesgSearch.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "ID Employee"
        Me.GridColumn3.FieldName = "id_employee"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumnCodeSearch
        '
        Me.GridColumnCodeSearch.Caption = "Code"
        Me.GridColumnCodeSearch.FieldName = "employee_code"
        Me.GridColumnCodeSearch.Name = "GridColumnCodeSearch"
        Me.GridColumnCodeSearch.Visible = True
        Me.GridColumnCodeSearch.VisibleIndex = 0
        Me.GridColumnCodeSearch.Width = 186
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Name"
        Me.GridColumn7.FieldName = "employee_name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 360
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(238, 12)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl9.TabIndex = 8897
        Me.LabelControl9.Text = "Employee"
        '
        'BViewSum
        '
        Me.BViewSum.Location = New System.Drawing.Point(491, 6)
        Me.BViewSum.Name = "BViewSum"
        Me.BViewSum.Size = New System.Drawing.Size(74, 25)
        Me.BViewSum.TabIndex = 12
        Me.BViewSum.Text = "View"
        '
        'GCSum
        '
        Me.GCSum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSum.Location = New System.Drawing.Point(0, 0)
        Me.GCSum.MainView = Me.GVSum
        Me.GCSum.Name = "GCSum"
        Me.GCSum.Size = New System.Drawing.Size(627, 230)
        Me.GCSum.TabIndex = 9
        Me.GCSum.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSum})
        '
        'GVSum
        '
        Me.GVSum.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn14, Me.GridColumn15, Me.GridColumnPositiion, Me.GridColumnLevels, Me.GridColumn22, Me.GridColumn16, Me.GridColumn17, Me.GridColumnLeaveRemaining, Me.GridColumnDPRemaining, Me.GridColumnAdvanceLeave, Me.GridColumnHLeaveRemaining, Me.GridColumnHDPRemaining, Me.GridColumnHAdvLeaveRemaining, Me.GridColumnHTotLeave})
        Me.GVSum.GridControl = Me.GCSum
        Me.GVSum.GroupCount = 1
        Me.GVSum.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_leave", Me.GridColumnLeaveRemaining, "{0:0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_dp", Me.GridColumnDPRemaining, "{0:0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "adv_leave", Me.GridColumnAdvanceLeave, "{0:0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_leave_h", Me.GridColumnHLeaveRemaining, "{0:0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_dp_h", Me.GridColumnHDPRemaining, "{0:0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_adv_h", Me.GridColumnHAdvLeaveRemaining, "{0:0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_leave_tot", Me.GridColumnHTotLeave, "{0:0}")})
        Me.GVSum.Name = "GVSum"
        Me.GVSum.OptionsView.ColumnAutoWidth = False
        Me.GVSum.OptionsView.ShowFooter = True
        Me.GVSum.OptionsView.ShowGroupPanel = False
        Me.GVSum.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn16, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "ID Employee"
        Me.GridColumn14.FieldName = "id_employee"
        Me.GridColumn14.Name = "GridColumn14"
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Employee"
        Me.GridColumn15.FieldName = "employee_name"
        Me.GridColumn15.FieldNameSortGroup = "id_employee"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 0
        Me.GridColumn15.Width = 96
        '
        'GridColumnPositiion
        '
        Me.GridColumnPositiion.Caption = "Position"
        Me.GridColumnPositiion.FieldName = "employee_position"
        Me.GridColumnPositiion.Name = "GridColumnPositiion"
        Me.GridColumnPositiion.Visible = True
        Me.GridColumnPositiion.VisibleIndex = 2
        '
        'GridColumnLevels
        '
        Me.GridColumnLevels.Caption = "Level"
        Me.GridColumnLevels.FieldName = "employee_level"
        Me.GridColumnLevels.Name = "GridColumnLevels"
        Me.GridColumnLevels.Visible = True
        Me.GridColumnLevels.VisibleIndex = 1
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Status"
        Me.GridColumn22.FieldName = "employee_active"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 3
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Departement"
        Me.GridColumn16.FieldName = "departement"
        Me.GridColumn16.FieldNameSortGroup = "id_departement"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 3
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "ID Departement"
        Me.GridColumn17.FieldName = "id_departement"
        Me.GridColumn17.Name = "GridColumn17"
        '
        'GridColumnLeaveRemaining
        '
        Me.GridColumnLeaveRemaining.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnLeaveRemaining.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnLeaveRemaining.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnLeaveRemaining.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnLeaveRemaining.Caption = "Leave Remaining"
        Me.GridColumnLeaveRemaining.FieldName = "qty_leave"
        Me.GridColumnLeaveRemaining.Name = "GridColumnLeaveRemaining"
        Me.GridColumnLeaveRemaining.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_leave", "{0:0}")})
        '
        'GridColumnDPRemaining
        '
        Me.GridColumnDPRemaining.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDPRemaining.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDPRemaining.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDPRemaining.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDPRemaining.Caption = "DP Remaining"
        Me.GridColumnDPRemaining.FieldName = "qty_dp"
        Me.GridColumnDPRemaining.Name = "GridColumnDPRemaining"
        Me.GridColumnDPRemaining.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_dp", "{0:0}")})
        '
        'GridColumnAdvanceLeave
        '
        Me.GridColumnAdvanceLeave.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnAdvanceLeave.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAdvanceLeave.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAdvanceLeave.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAdvanceLeave.Caption = "Advance Leave"
        Me.GridColumnAdvanceLeave.FieldName = "adv_leave"
        Me.GridColumnAdvanceLeave.Name = "GridColumnAdvanceLeave"
        Me.GridColumnAdvanceLeave.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "adv_leave", "{0:0}")})
        '
        'GridColumnHLeaveRemaining
        '
        Me.GridColumnHLeaveRemaining.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnHLeaveRemaining.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnHLeaveRemaining.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnHLeaveRemaining.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnHLeaveRemaining.Caption = "Leave Remaining Actual (hours)"
        Me.GridColumnHLeaveRemaining.FieldName = "qty_leave_h"
        Me.GridColumnHLeaveRemaining.Name = "GridColumnHLeaveRemaining"
        Me.GridColumnHLeaveRemaining.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_leave_h", "{0:0}")})
        Me.GridColumnHLeaveRemaining.UnboundExpression = "[qty_leave] / 60"
        Me.GridColumnHLeaveRemaining.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GridColumnHLeaveRemaining.Visible = True
        Me.GridColumnHLeaveRemaining.VisibleIndex = 4
        Me.GridColumnHLeaveRemaining.Width = 181
        '
        'GridColumnHDPRemaining
        '
        Me.GridColumnHDPRemaining.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnHDPRemaining.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnHDPRemaining.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnHDPRemaining.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnHDPRemaining.Caption = "DP Remaining (hours)"
        Me.GridColumnHDPRemaining.FieldName = "qty_dp_h"
        Me.GridColumnHDPRemaining.Name = "GridColumnHDPRemaining"
        Me.GridColumnHDPRemaining.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_dp_h", "{0:0}")})
        Me.GridColumnHDPRemaining.UnboundExpression = "[qty_dp] / 60"
        Me.GridColumnHDPRemaining.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GridColumnHDPRemaining.Visible = True
        Me.GridColumnHDPRemaining.VisibleIndex = 7
        Me.GridColumnHDPRemaining.Width = 110
        '
        'GridColumnHAdvLeaveRemaining
        '
        Me.GridColumnHAdvLeaveRemaining.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnHAdvLeaveRemaining.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnHAdvLeaveRemaining.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnHAdvLeaveRemaining.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnHAdvLeaveRemaining.Caption = "Advance Leave Remaining (hours)"
        Me.GridColumnHAdvLeaveRemaining.FieldName = "qty_adv_h"
        Me.GridColumnHAdvLeaveRemaining.Name = "GridColumnHAdvLeaveRemaining"
        Me.GridColumnHAdvLeaveRemaining.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_adv_h", "{0:0}")})
        Me.GridColumnHAdvLeaveRemaining.UnboundExpression = "[adv_leave] / 60"
        Me.GridColumnHAdvLeaveRemaining.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GridColumnHAdvLeaveRemaining.Visible = True
        Me.GridColumnHAdvLeaveRemaining.VisibleIndex = 5
        Me.GridColumnHAdvLeaveRemaining.Width = 134
        '
        'GridColumnHTotLeave
        '
        Me.GridColumnHTotLeave.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnHTotLeave.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnHTotLeave.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnHTotLeave.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnHTotLeave.Caption = "Leave Remaining Total (hours)"
        Me.GridColumnHTotLeave.FieldName = "qty_leave_tot"
        Me.GridColumnHTotLeave.Name = "GridColumnHTotLeave"
        Me.GridColumnHTotLeave.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_leave_tot", "{0:0}")})
        Me.GridColumnHTotLeave.UnboundExpression = "[qty_leave_h] - [qty_adv_h]"
        Me.GridColumnHTotLeave.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GridColumnHTotLeave.Visible = True
        Me.GridColumnHTotLeave.VisibleIndex = 6
        Me.GridColumnHTotLeave.Width = 125
        '
        'XTCLeaveRemaining
        '
        Me.XTCLeaveRemaining.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCLeaveRemaining.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCLeaveRemaining.Location = New System.Drawing.Point(0, 38)
        Me.XTCLeaveRemaining.Name = "XTCLeaveRemaining"
        Me.XTCLeaveRemaining.SelectedTabPage = Me.XTPSum
        Me.XTCLeaveRemaining.Size = New System.Drawing.Size(633, 258)
        Me.XTCLeaveRemaining.TabIndex = 10
        Me.XTCLeaveRemaining.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPSum, Me.XTPDetail})
        '
        'XTPSum
        '
        Me.XTPSum.Controls.Add(Me.GCSum)
        Me.XTPSum.Name = "XTPSum"
        Me.XTPSum.Size = New System.Drawing.Size(627, 230)
        Me.XTPSum.Text = "Summary"
        '
        'XTPDetail
        '
        Me.XTPDetail.Controls.Add(Me.GCSchedule)
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(627, 230)
        Me.XTPDetail.Text = "Detail"
        '
        'GVSchedule
        '
        Me.GVSchedule.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn21, Me.GridColumnIDSchedule, Me.GridColumn18, Me.GridColumn20, Me.GridColumnLevel, Me.GridColumnEmpPosition, Me.GridColumn23, Me.GridColumn38, Me.GridColumn39, Me.GridColumnDateExpired, Me.GridColumnType, Me.GridColumnQty, Me.GridColumn10})
        Me.GVSchedule.GridControl = Me.GCSchedule
        Me.GVSchedule.GroupCount = 2
        Me.GVSchedule.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_leave_h", Me.GridColumnQty, "{0:0}")})
        Me.GVSchedule.Name = "GVSchedule"
        Me.GVSchedule.OptionsView.ColumnAutoWidth = False
        Me.GVSchedule.OptionsView.ShowFooter = True
        Me.GVSchedule.OptionsView.ShowGroupPanel = False
        Me.GVSchedule.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn38, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn20, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "ID Employee"
        Me.GridColumn21.FieldName = "id_employee"
        Me.GridColumn21.Name = "GridColumn21"
        '
        'GridColumnIDSchedule
        '
        Me.GridColumnIDSchedule.Caption = "ID Schedule"
        Me.GridColumnIDSchedule.FieldName = "id_schedule"
        Me.GridColumnIDSchedule.Name = "GridColumnIDSchedule"
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Code"
        Me.GridColumn18.FieldName = "employee_code"
        Me.GridColumn18.Name = "GridColumn18"
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Employee"
        Me.GridColumn20.FieldName = "employee_name"
        Me.GridColumn20.FieldNameSortGroup = "id_employee"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 1
        '
        'GridColumnLevel
        '
        Me.GridColumnLevel.Caption = "Level"
        Me.GridColumnLevel.FieldName = "employee_level"
        Me.GridColumnLevel.Name = "GridColumnLevel"
        Me.GridColumnLevel.Visible = True
        Me.GridColumnLevel.VisibleIndex = 0
        '
        'GridColumnEmpPosition
        '
        Me.GridColumnEmpPosition.Caption = "Position"
        Me.GridColumnEmpPosition.FieldName = "employee_position"
        Me.GridColumnEmpPosition.Name = "GridColumnEmpPosition"
        Me.GridColumnEmpPosition.Visible = True
        Me.GridColumnEmpPosition.VisibleIndex = 1
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Status"
        Me.GridColumn23.FieldName = "employee_active"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 2
        '
        'GridColumn38
        '
        Me.GridColumn38.Caption = "Departement"
        Me.GridColumn38.FieldName = "departement"
        Me.GridColumn38.FieldNameSortGroup = "id_departement"
        Me.GridColumn38.Name = "GridColumn38"
        Me.GridColumn38.Visible = True
        Me.GridColumn38.VisibleIndex = 3
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "ID Departement"
        Me.GridColumn39.FieldName = "id_departement"
        Me.GridColumn39.Name = "GridColumn39"
        '
        'GridColumnDateExpired
        '
        Me.GridColumnDateExpired.Caption = "Date Expired"
        Me.GridColumnDateExpired.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnDateExpired.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDateExpired.FieldName = "date_expired"
        Me.GridColumnDateExpired.Name = "GridColumnDateExpired"
        Me.GridColumnDateExpired.Visible = True
        Me.GridColumnDateExpired.VisibleIndex = 3
        '
        'GridColumnType
        '
        Me.GridColumnType.Caption = "Type"
        Me.GridColumnType.FieldName = "type_ket"
        Me.GridColumnType.Name = "GridColumnType"
        Me.GridColumnType.Visible = True
        Me.GridColumnType.VisibleIndex = 4
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Remaining (hours)"
        Me.GridColumnQty.FieldName = "qty_leave_h"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.UnboundExpression = "[qty_leave] / 60"
        Me.GridColumnQty.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 5
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.Caption = "Remaining"
        Me.GridColumn10.FieldName = "qty_leave"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GCSchedule
        '
        Me.GCSchedule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSchedule.Location = New System.Drawing.Point(0, 0)
        Me.GCSchedule.MainView = Me.GVSchedule
        Me.GCSchedule.Name = "GCSchedule"
        Me.GCSchedule.Size = New System.Drawing.Size(627, 230)
        Me.GCSchedule.TabIndex = 9
        Me.GCSchedule.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSchedule})
        '
        'FormEmpLeaveStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 296)
        Me.Controls.Add(Me.XTCLeaveRemaining)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpLeaveStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Leave Remaining"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEEmpSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCLeaveRemaining, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCLeaveRemaining.ResumeLayout(False)
        Me.XTPSum.ResumeLayout(False)
        Me.XTPDetail.ResumeLayout(False)
        CType(Me.GVSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BViewSum As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LEEmpSum As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GVSLEDesgSearch As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCodeSearch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEDeptSum As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCSum As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSum As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPositiion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLevels As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLeaveRemaining As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDPRemaining As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCLeaveRemaining As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPSum As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnHLeaveRemaining As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnHDPRemaining As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAdvanceLeave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnHAdvLeaveRemaining As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnHTotLeave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCSchedule As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSchedule As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDSchedule As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmpPosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDateExpired As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
End Class
