<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBudgetProdDemand
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBudgetProdDemand))
        Me.XTCBudget = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPApproved = New DevExpress.XtraTab.XtraTabPage()
        Me.GCApprovedBudget = New DevExpress.XtraGrid.GridControl()
        Me.GVApprovedBudget = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_b_prod_demand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnyear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_season = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnseason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvalue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DEYearBudget = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPProposedBudget = New DevExpress.XtraTab.XtraTabPage()
        Me.GCProposed = New DevExpress.XtraGrid.GridControl()
        Me.GVProposed = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_b_prod_demand_propose = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnyear_proposed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_confirm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewProposeDate = New DevExpress.XtraEditors.SimpleButton()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DEYearProposedBudget = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnViewYearBudget = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XTCBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCBudget.SuspendLayout()
        Me.XTPApproved.SuspendLayout()
        CType(Me.GCApprovedBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVApprovedBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEYearBudget.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEYearBudget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPProposedBudget.SuspendLayout()
        CType(Me.GCProposed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProposed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEYearProposedBudget.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEYearProposedBudget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCBudget
        '
        Me.XTCBudget.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCBudget.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCBudget.Location = New System.Drawing.Point(0, 0)
        Me.XTCBudget.Name = "XTCBudget"
        Me.XTCBudget.SelectedTabPage = Me.XTPApproved
        Me.XTCBudget.Size = New System.Drawing.Size(832, 542)
        Me.XTCBudget.TabIndex = 0
        Me.XTCBudget.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPApproved, Me.XTPProposedBudget})
        '
        'XTPApproved
        '
        Me.XTPApproved.Controls.Add(Me.GCApprovedBudget)
        Me.XTPApproved.Controls.Add(Me.PanelControl1)
        Me.XTPApproved.Name = "XTPApproved"
        Me.XTPApproved.Size = New System.Drawing.Size(826, 514)
        Me.XTPApproved.Text = "Approved Budget"
        '
        'GCApprovedBudget
        '
        Me.GCApprovedBudget.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCApprovedBudget.Location = New System.Drawing.Point(0, 38)
        Me.GCApprovedBudget.MainView = Me.GVApprovedBudget
        Me.GCApprovedBudget.Name = "GCApprovedBudget"
        Me.GCApprovedBudget.Size = New System.Drawing.Size(826, 476)
        Me.GCApprovedBudget.TabIndex = 6
        Me.GCApprovedBudget.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVApprovedBudget})
        '
        'GVApprovedBudget
        '
        Me.GVApprovedBudget.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_b_prod_demand, Me.GridColumnyear, Me.GridColumnid_season, Me.GridColumnseason, Me.GridColumnvalue})
        Me.GVApprovedBudget.GridControl = Me.GCApprovedBudget
        Me.GVApprovedBudget.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value", Me.GridColumnvalue, "{0:N2}")})
        Me.GVApprovedBudget.Name = "GVApprovedBudget"
        Me.GVApprovedBudget.OptionsBehavior.ReadOnly = True
        Me.GVApprovedBudget.OptionsFind.AlwaysVisible = True
        Me.GVApprovedBudget.OptionsView.ColumnAutoWidth = False
        Me.GVApprovedBudget.OptionsView.ShowFooter = True
        Me.GVApprovedBudget.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_b_prod_demand
        '
        Me.GridColumnid_b_prod_demand.Caption = "id_b_prod_demand"
        Me.GridColumnid_b_prod_demand.FieldName = "id_b_prod_demand"
        Me.GridColumnid_b_prod_demand.Name = "GridColumnid_b_prod_demand"
        '
        'GridColumnyear
        '
        Me.GridColumnyear.Caption = "Year Budget"
        Me.GridColumnyear.FieldName = "year"
        Me.GridColumnyear.Name = "GridColumnyear"
        Me.GridColumnyear.Visible = True
        Me.GridColumnyear.VisibleIndex = 0
        '
        'GridColumnid_season
        '
        Me.GridColumnid_season.Caption = "id_season"
        Me.GridColumnid_season.FieldName = "id_season"
        Me.GridColumnid_season.Name = "GridColumnid_season"
        '
        'GridColumnseason
        '
        Me.GridColumnseason.Caption = "Season"
        Me.GridColumnseason.FieldName = "season"
        Me.GridColumnseason.Name = "GridColumnseason"
        Me.GridColumnseason.Visible = True
        Me.GridColumnseason.VisibleIndex = 1
        '
        'GridColumnvalue
        '
        Me.GridColumnvalue.Caption = "Value"
        Me.GridColumnvalue.DisplayFormat.FormatString = "N2"
        Me.GridColumnvalue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnvalue.FieldName = "value"
        Me.GridColumnvalue.Name = "GridColumnvalue"
        Me.GridColumnvalue.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value", "{0:N2}")})
        Me.GridColumnvalue.Visible = True
        Me.GridColumnvalue.VisibleIndex = 2
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.DEYearBudget)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(826, 38)
        Me.PanelControl1.TabIndex = 5
        '
        'DEYearBudget
        '
        Me.DEYearBudget.EditValue = Nothing
        Me.DEYearBudget.Location = New System.Drawing.Point(77, 8)
        Me.DEYearBudget.Name = "DEYearBudget"
        Me.DEYearBudget.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEYearBudget.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEYearBudget.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEYearBudget.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.DEYearBudget.Properties.DisplayFormat.FormatString = "yyyy"
        Me.DEYearBudget.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEYearBudget.Properties.Mask.EditMask = "yyyy"
        Me.DEYearBudget.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEYearBudget.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView
        Me.DEYearBudget.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView
        Me.DEYearBudget.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.DEYearBudget.Size = New System.Drawing.Size(143, 20)
        Me.DEYearBudget.TabIndex = 8905
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(12, 11)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl6.TabIndex = 8904
        Me.LabelControl6.Text = "Year Budget"
        '
        'BtnView
        '
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(226, 6)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(68, 23)
        Me.BtnView.TabIndex = 8903
        Me.BtnView.Text = "View"
        '
        'XTPProposedBudget
        '
        Me.XTPProposedBudget.Controls.Add(Me.GCProposed)
        Me.XTPProposedBudget.Controls.Add(Me.PanelControl2)
        Me.XTPProposedBudget.Name = "XTPProposedBudget"
        Me.XTPProposedBudget.Size = New System.Drawing.Size(826, 514)
        Me.XTPProposedBudget.Text = "Proposed Budget"
        '
        'GCProposed
        '
        Me.GCProposed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProposed.Location = New System.Drawing.Point(0, 48)
        Me.GCProposed.MainView = Me.GVProposed
        Me.GCProposed.Name = "GCProposed"
        Me.GCProposed.Size = New System.Drawing.Size(826, 466)
        Me.GCProposed.TabIndex = 1
        Me.GCProposed.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProposed})
        '
        'GVProposed
        '
        Me.GVProposed.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_b_prod_demand_propose, Me.GridColumnyear_proposed, Me.GridColumnnumber, Me.GridColumncreated_date, Me.GridColumnnote, Me.GridColumnis_confirm, Me.GridColumnid_report_status, Me.GridColumnreport_status})
        Me.GVProposed.GridControl = Me.GCProposed
        Me.GVProposed.Name = "GVProposed"
        Me.GVProposed.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVProposed.OptionsBehavior.Editable = False
        Me.GVProposed.OptionsView.ColumnAutoWidth = False
        Me.GVProposed.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_b_prod_demand_propose
        '
        Me.GridColumnid_b_prod_demand_propose.Caption = "id_b_prod_demand_propose"
        Me.GridColumnid_b_prod_demand_propose.FieldName = "id_b_prod_demand_propose"
        Me.GridColumnid_b_prod_demand_propose.Name = "GridColumnid_b_prod_demand_propose"
        '
        'GridColumnyear_proposed
        '
        Me.GridColumnyear_proposed.Caption = "Year Budget"
        Me.GridColumnyear_proposed.FieldName = "year"
        Me.GridColumnyear_proposed.Name = "GridColumnyear_proposed"
        Me.GridColumnyear_proposed.Visible = True
        Me.GridColumnyear_proposed.VisibleIndex = 0
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 1
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 2
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        '
        'GridColumnis_confirm
        '
        Me.GridColumnis_confirm.Caption = "is_confirm"
        Me.GridColumnis_confirm.FieldName = "is_confirm"
        Me.GridColumnis_confirm.Name = "GridColumnis_confirm"
        '
        'GridColumnid_report_status
        '
        Me.GridColumnid_report_status.Caption = "id_report_status"
        Me.GridColumnid_report_status.FieldName = "id_report_status"
        Me.GridColumnid_report_status.Name = "GridColumnid_report_status"
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 3
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnViewProposeDate)
        Me.PanelControl2.Controls.Add(Me.DEFrom)
        Me.PanelControl2.Controls.Add(Me.DEUntil)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.DEYearProposedBudget)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.BtnViewYearBudget)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(826, 48)
        Me.PanelControl2.TabIndex = 0
        '
        'BtnViewProposeDate
        '
        Me.BtnViewProposeDate.Image = CType(resources.GetObject("BtnViewProposeDate.Image"), System.Drawing.Image)
        Me.BtnViewProposeDate.Location = New System.Drawing.Point(652, 13)
        Me.BtnViewProposeDate.Name = "BtnViewProposeDate"
        Me.BtnViewProposeDate.Size = New System.Drawing.Size(68, 20)
        Me.BtnViewProposeDate.TabIndex = 8913
        Me.BtnViewProposeDate.Text = "View"
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(341, 13)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Size = New System.Drawing.Size(147, 20)
        Me.DEFrom.TabIndex = 8910
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(499, 13)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Size = New System.Drawing.Size(147, 20)
        Me.DEUntil.TabIndex = 8912
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(251, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl2.TabIndex = 8909
        Me.LabelControl2.Text = "By Proposed Date"
        '
        'DEYearProposedBudget
        '
        Me.DEYearProposedBudget.EditValue = Nothing
        Me.DEYearProposedBudget.Location = New System.Drawing.Point(94, 13)
        Me.DEYearProposedBudget.Name = "DEYearProposedBudget"
        Me.DEYearProposedBudget.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEYearProposedBudget.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEYearProposedBudget.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEYearProposedBudget.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.DEYearProposedBudget.Properties.DisplayFormat.FormatString = "yyyy"
        Me.DEYearProposedBudget.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEYearProposedBudget.Properties.Mask.EditMask = "yyyy"
        Me.DEYearProposedBudget.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEYearProposedBudget.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView
        Me.DEYearProposedBudget.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView
        Me.DEYearProposedBudget.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.DEYearProposedBudget.Size = New System.Drawing.Size(77, 20)
        Me.DEYearProposedBudget.TabIndex = 8908
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(491, 16)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl3.TabIndex = 8911
        Me.LabelControl3.Text = "-"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(14, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl1.TabIndex = 8907
        Me.LabelControl1.Text = "By Year Budget"
        '
        'BtnViewYearBudget
        '
        Me.BtnViewYearBudget.Image = CType(resources.GetObject("BtnViewYearBudget.Image"), System.Drawing.Image)
        Me.BtnViewYearBudget.Location = New System.Drawing.Point(177, 13)
        Me.BtnViewYearBudget.Name = "BtnViewYearBudget"
        Me.BtnViewYearBudget.Size = New System.Drawing.Size(68, 20)
        Me.BtnViewYearBudget.TabIndex = 8906
        Me.BtnViewYearBudget.Text = "View"
        '
        'FormBudgetProdDemand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 542)
        Me.Controls.Add(Me.XTCBudget)
        Me.Name = "FormBudgetProdDemand"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup Budget Production Demand"
        CType(Me.XTCBudget, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCBudget.ResumeLayout(False)
        Me.XTPApproved.ResumeLayout(False)
        CType(Me.GCApprovedBudget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVApprovedBudget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEYearBudget.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEYearBudget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPProposedBudget.ResumeLayout(False)
        CType(Me.GCProposed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProposed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEYearProposedBudget.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEYearProposedBudget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCBudget As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPApproved As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPProposedBudget As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEYearBudget As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCApprovedBudget As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVApprovedBudget As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_b_prod_demand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnyear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_season As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnseason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvalue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnViewProposeDate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEYearProposedBudget As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnViewYearBudget As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCProposed As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProposed As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_b_prod_demand_propose As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnyear_proposed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_confirm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
End Class
