<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesBranch
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
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_sales_branch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_coa_tag = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnunit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntransaction_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvalue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.DEUntilList = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromList = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEStoreDeposit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BViewPayment = New DevExpress.XtraEditors.SimpleButton()
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPCreatedList = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPCN = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSales = New DevExpress.XtraGrid.GridControl()
        Me.GVSales = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_sales_branch_cn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber_cn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntransaction_date_cn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BCreateCN = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewSalesList = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEUnit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncoa_tag = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DEUntilList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStoreDeposit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPCreatedList.SuspendLayout()
        Me.XTPCN.SuspendLayout()
        CType(Me.GCSales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEUnit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 48)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(782, 420)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_branch, Me.GridColumnid_coa_tag, Me.GridColumnunit, Me.GridColumncreated_date, Me.GridColumntransaction_date, Me.GridColumnid_report_status, Me.GridColumnreport_status, Me.GridColumnnote, Me.GridColumnvalue, Me.GridColumnnumber})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.ReadOnly = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_sales_branch
        '
        Me.GridColumnid_sales_branch.Caption = "id_sales_branch"
        Me.GridColumnid_sales_branch.FieldName = "id_sales_branch"
        Me.GridColumnid_sales_branch.Name = "GridColumnid_sales_branch"
        '
        'GridColumnid_coa_tag
        '
        Me.GridColumnid_coa_tag.Caption = "id_coa_tag"
        Me.GridColumnid_coa_tag.FieldName = "id_coa_tag"
        Me.GridColumnid_coa_tag.Name = "GridColumnid_coa_tag"
        '
        'GridColumnunit
        '
        Me.GridColumnunit.Caption = "Unit"
        Me.GridColumnunit.FieldName = "unit"
        Me.GridColumnunit.Name = "GridColumnunit"
        Me.GridColumnunit.Visible = True
        Me.GridColumnunit.VisibleIndex = 1
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 2
        '
        'GridColumntransaction_date
        '
        Me.GridColumntransaction_date.Caption = "Sales Date"
        Me.GridColumntransaction_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumntransaction_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumntransaction_date.FieldName = "transaction_date"
        Me.GridColumntransaction_date.Name = "GridColumntransaction_date"
        Me.GridColumntransaction_date.Visible = True
        Me.GridColumntransaction_date.VisibleIndex = 3
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
        Me.GridColumnreport_status.VisibleIndex = 4
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.Visible = True
        Me.GridColumnnote.VisibleIndex = 5
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
        Me.GridColumnvalue.VisibleIndex = 6
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.DEUntilList)
        Me.PanelControl2.Controls.Add(Me.DEFromList)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.LabelControl6)
        Me.PanelControl2.Controls.Add(Me.SLEStoreDeposit)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.BViewPayment)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(782, 48)
        Me.PanelControl2.TabIndex = 15
        '
        'DEUntilList
        '
        Me.DEUntilList.EditValue = Nothing
        Me.DEUntilList.Location = New System.Drawing.Point(190, 12)
        Me.DEUntilList.Name = "DEUntilList"
        Me.DEUntilList.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntilList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilList.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilList.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilList.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilList.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilList.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilList.TabIndex = 8922
        '
        'DEFromList
        '
        Me.DEFromList.EditValue = Nothing
        Me.DEFromList.Location = New System.Drawing.Point(46, 12)
        Me.DEFromList.Name = "DEFromList"
        Me.DEFromList.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFromList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromList.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromList.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromList.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromList.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromList.Size = New System.Drawing.Size(111, 20)
        Me.DEFromList.TabIndex = 8921
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(163, 15)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl4.TabIndex = 8920
        Me.LabelControl4.Text = "Until"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(16, 15)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl6.TabIndex = 8919
        Me.LabelControl6.Text = "From"
        '
        'SLEStoreDeposit
        '
        Me.SLEStoreDeposit.Location = New System.Drawing.Point(50, 102)
        Me.SLEStoreDeposit.Name = "SLEStoreDeposit"
        Me.SLEStoreDeposit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreDeposit.Properties.View = Me.GridView1
        Me.SLEStoreDeposit.Size = New System.Drawing.Size(177, 20)
        Me.SLEStoreDeposit.TabIndex = 8918
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn29})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Comp Contact"
        Me.GridColumn1.FieldName = "id_comp_contact"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Vendor"
        Me.GridColumn29.FieldName = "comp_name"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 105)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl1.TabIndex = 8917
        Me.LabelControl1.Text = "Store"
        '
        'BViewPayment
        '
        Me.BViewPayment.Location = New System.Drawing.Point(307, 12)
        Me.BViewPayment.Name = "BViewPayment"
        Me.BViewPayment.Size = New System.Drawing.Size(60, 19)
        Me.BViewPayment.TabIndex = 8916
        Me.BViewPayment.Text = "view"
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCData.Location = New System.Drawing.Point(0, 0)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPCreatedList
        Me.XTCData.Size = New System.Drawing.Size(788, 496)
        Me.XTCData.TabIndex = 16
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPCreatedList, Me.XTPCN})
        '
        'XTPCreatedList
        '
        Me.XTPCreatedList.Controls.Add(Me.GCData)
        Me.XTPCreatedList.Controls.Add(Me.PanelControl2)
        Me.XTPCreatedList.Name = "XTPCreatedList"
        Me.XTPCreatedList.Size = New System.Drawing.Size(782, 468)
        Me.XTPCreatedList.Text = "Created List"
        '
        'XTPCN
        '
        Me.XTPCN.Controls.Add(Me.GCSales)
        Me.XTPCN.Controls.Add(Me.BCreateCN)
        Me.XTPCN.Controls.Add(Me.PanelControl1)
        Me.XTPCN.Name = "XTPCN"
        Me.XTPCN.PageVisible = False
        Me.XTPCN.Size = New System.Drawing.Size(782, 468)
        Me.XTPCN.Text = "Sales List"
        '
        'GCSales
        '
        Me.GCSales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSales.Location = New System.Drawing.Point(0, 48)
        Me.GCSales.MainView = Me.GVSales
        Me.GCSales.Name = "GCSales"
        Me.GCSales.Size = New System.Drawing.Size(782, 388)
        Me.GCSales.TabIndex = 20
        Me.GCSales.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSales})
        '
        'GVSales
        '
        Me.GVSales.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_branch_cn, Me.GridColumnnumber_cn, Me.GridColumntransaction_date_cn})
        Me.GVSales.GridControl = Me.GCSales
        Me.GVSales.Name = "GVSales"
        Me.GVSales.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSales.OptionsBehavior.Editable = False
        Me.GVSales.OptionsFind.AlwaysVisible = True
        Me.GVSales.OptionsView.ColumnAutoWidth = False
        Me.GVSales.OptionsView.ShowFooter = True
        Me.GVSales.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_sales_branch_cn
        '
        Me.GridColumnid_sales_branch_cn.Caption = "id_sales_branch"
        Me.GridColumnid_sales_branch_cn.FieldName = "id_sales_branch"
        Me.GridColumnid_sales_branch_cn.Name = "GridColumnid_sales_branch_cn"
        '
        'GridColumnnumber_cn
        '
        Me.GridColumnnumber_cn.Caption = "Number"
        Me.GridColumnnumber_cn.FieldName = "number"
        Me.GridColumnnumber_cn.Name = "GridColumnnumber_cn"
        Me.GridColumnnumber_cn.Visible = True
        Me.GridColumnnumber_cn.VisibleIndex = 0
        '
        'GridColumntransaction_date_cn
        '
        Me.GridColumntransaction_date_cn.Caption = "Sales Date"
        Me.GridColumntransaction_date_cn.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumntransaction_date_cn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumntransaction_date_cn.FieldName = "transaction_date"
        Me.GridColumntransaction_date_cn.Name = "GridColumntransaction_date_cn"
        Me.GridColumntransaction_date_cn.Visible = True
        Me.GridColumntransaction_date_cn.VisibleIndex = 1
        Me.GridColumntransaction_date_cn.Width = 172
        '
        'BCreateCN
        '
        Me.BCreateCN.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BCreateCN.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BCreateCN.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCreateCN.Appearance.Options.UseBackColor = True
        Me.BCreateCN.Appearance.Options.UseFont = True
        Me.BCreateCN.Appearance.Options.UseForeColor = True
        Me.BCreateCN.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BCreateCN.Location = New System.Drawing.Point(0, 436)
        Me.BCreateCN.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BCreateCN.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BCreateCN.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BCreateCN.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BCreateCN.Name = "BCreateCN"
        Me.BCreateCN.Size = New System.Drawing.Size(782, 32)
        Me.BCreateCN.TabIndex = 19
        Me.BCreateCN.Text = "Create Credit Note"
        Me.BCreateCN.Visible = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnViewSalesList)
        Me.PanelControl1.Controls.Add(Me.SLEUnit)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(782, 48)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnViewSalesList
        '
        Me.BtnViewSalesList.Location = New System.Drawing.Point(311, 14)
        Me.BtnViewSalesList.Name = "BtnViewSalesList"
        Me.BtnViewSalesList.Size = New System.Drawing.Size(60, 19)
        Me.BtnViewSalesList.TabIndex = 8917
        Me.BtnViewSalesList.Text = "view"
        '
        'SLEUnit
        '
        Me.SLEUnit.Location = New System.Drawing.Point(42, 13)
        Me.SLEUnit.Name = "SLEUnit"
        Me.SLEUnit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEUnit.Properties.View = Me.GridView2
        Me.SLEUnit.Size = New System.Drawing.Size(264, 20)
        Me.SLEUnit.TabIndex = 8916
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumncoa_tag})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "id_coa_tag"
        Me.GridColumn2.FieldName = "id_coa_tag"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumncoa_tag
        '
        Me.GridColumncoa_tag.Caption = "Unit"
        Me.GridColumncoa_tag.FieldName = "coa_tag"
        Me.GridColumncoa_tag.Name = "GridColumncoa_tag"
        Me.GridColumncoa_tag.Visible = True
        Me.GridColumncoa_tag.VisibleIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(14, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl2.TabIndex = 8915
        Me.LabelControl2.Text = "Unit"
        '
        'FormSalesBranch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 496)
        Me.Controls.Add(Me.XTCData)
        Me.MinimizeBox = False
        Me.Name = "FormSalesBranch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Volcom Store Sales"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DEUntilList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStoreDeposit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPCreatedList.ResumeLayout(False)
        Me.XTPCN.ResumeLayout(False)
        CType(Me.GCSales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEUnit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_sales_branch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_coa_tag As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnunit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntransaction_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvalue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEUntilList As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromList As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEStoreDeposit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BViewPayment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPCreatedList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPCN As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnViewSalesList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEUnit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncoa_tag As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCreateCN As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCSales As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSales As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_sales_branch_cn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber_cn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntransaction_date_cn As DevExpress.XtraGrid.Columns.GridColumn
End Class
