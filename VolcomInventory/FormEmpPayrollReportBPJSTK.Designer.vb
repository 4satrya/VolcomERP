<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpPayrollReportBPJSTK
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollReportBPJSTK))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.GCAllDepartements = New DevExpress.XtraGrid.GridControl()
        Me.GVAllDepartements = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCALocation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCANo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCADepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCACompanyContribution1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCACompanyContribution2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCAEmployeeContribution1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCAEmployeeContribution2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATotalContribution = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeeKjp = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeeName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCJenisKelamin = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeeDOB = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCKepProg = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeeSalaryBefore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeeSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCCompanyContribution1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeeContribution1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCCompanyContribution2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeeContribution2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCTotalContribution = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCLocation = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.GCAllDepartements, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAllDepartements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1008, 46)
        Me.PanelControl1.TabIndex = 5
        '
        'SBPrint
        '
        Me.SBPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBPrint.Image = CType(resources.GetObject("SBPrint.Image"), System.Drawing.Image)
        Me.SBPrint.Location = New System.Drawing.Point(921, 2)
        Me.SBPrint.Name = "SBPrint"
        Me.SBPrint.Size = New System.Drawing.Size(85, 42)
        Me.SBPrint.TabIndex = 0
        Me.SBPrint.Text = "Print"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 46)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1008, 683)
        Me.XtraTabControl1.TabIndex = 6
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.GCAllDepartements)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1002, 655)
        Me.XtraTabPage1.Text = "All Departements"
        '
        'GCAllDepartements
        '
        Me.GCAllDepartements.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAllDepartements.Location = New System.Drawing.Point(0, 0)
        Me.GCAllDepartements.MainView = Me.GVAllDepartements
        Me.GCAllDepartements.Name = "GCAllDepartements"
        Me.GCAllDepartements.Size = New System.Drawing.Size(1002, 655)
        Me.GCAllDepartements.TabIndex = 4
        Me.GCAllDepartements.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAllDepartements})
        '
        'GVAllDepartements
        '
        Me.GVAllDepartements.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCALocation, Me.GCANo, Me.GCADepartement, Me.GCACompanyContribution1, Me.GCACompanyContribution2, Me.GCAEmployeeContribution1, Me.GCAEmployeeContribution2, Me.GCATotalContribution})
        Me.GVAllDepartements.GridControl = Me.GCAllDepartements
        Me.GVAllDepartements.GroupCount = 1
        Me.GVAllDepartements.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_contribution", Me.GCATotalContribution, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "company_contribution_1", Me.GCACompanyContribution1, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "company_contribution_2", Me.GCACompanyContribution2, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "employee_contribution_1", Me.GCAEmployeeContribution1, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "employee_contribution_2", Me.GCAEmployeeContribution2, "{0:N0}")})
        Me.GVAllDepartements.Name = "GVAllDepartements"
        Me.GVAllDepartements.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVAllDepartements.OptionsBehavior.Editable = False
        Me.GVAllDepartements.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVAllDepartements.OptionsView.ShowFooter = True
        Me.GVAllDepartements.OptionsView.ShowGroupPanel = False
        Me.GVAllDepartements.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCALocation, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GCALocation
        '
        Me.GCALocation.Caption = "Location"
        Me.GCALocation.FieldName = "bpjs_tk_location"
        Me.GCALocation.Name = "GCALocation"
        Me.GCALocation.Visible = True
        Me.GCALocation.VisibleIndex = 0
        '
        'GCANo
        '
        Me.GCANo.Caption = "No"
        Me.GCANo.FieldName = "no"
        Me.GCANo.Name = "GCANo"
        Me.GCANo.Visible = True
        Me.GCANo.VisibleIndex = 0
        Me.GCANo.Width = 204
        '
        'GCADepartement
        '
        Me.GCADepartement.Caption = "Departement"
        Me.GCADepartement.FieldName = "departement"
        Me.GCADepartement.Name = "GCADepartement"
        Me.GCADepartement.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "departement", "Total Biaya Iuran")})
        Me.GCADepartement.Visible = True
        Me.GCADepartement.VisibleIndex = 1
        Me.GCADepartement.Width = 204
        '
        'GCACompanyContribution1
        '
        Me.GCACompanyContribution1.Caption = "Dibayar Oleh Perusahaan (JHT, JKK, JKM)"
        Me.GCACompanyContribution1.DisplayFormat.FormatString = "N0"
        Me.GCACompanyContribution1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCACompanyContribution1.FieldName = "company_contribution_1"
        Me.GCACompanyContribution1.Name = "GCACompanyContribution1"
        Me.GCACompanyContribution1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "company_contribution_1", "{0:N0}")})
        Me.GCACompanyContribution1.Visible = True
        Me.GCACompanyContribution1.VisibleIndex = 2
        Me.GCACompanyContribution1.Width = 246
        '
        'GCACompanyContribution2
        '
        Me.GCACompanyContribution2.Caption = "Dibayar Oleh Perusahaan (J Pensiun)"
        Me.GCACompanyContribution2.DisplayFormat.FormatString = "N0"
        Me.GCACompanyContribution2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCACompanyContribution2.FieldName = "company_contribution_2"
        Me.GCACompanyContribution2.Name = "GCACompanyContribution2"
        Me.GCACompanyContribution2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "company_contribution_2", "{0:N0}")})
        Me.GCACompanyContribution2.Visible = True
        Me.GCACompanyContribution2.VisibleIndex = 3
        Me.GCACompanyContribution2.Width = 193
        '
        'GCAEmployeeContribution1
        '
        Me.GCAEmployeeContribution1.Caption = "Dibayar Oleh Karyawan (J Pensiun)"
        Me.GCAEmployeeContribution1.DisplayFormat.FormatString = "N0"
        Me.GCAEmployeeContribution1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCAEmployeeContribution1.FieldName = "employee_contribution_1"
        Me.GCAEmployeeContribution1.Name = "GCAEmployeeContribution1"
        Me.GCAEmployeeContribution1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "employee_contribution_1", "{0:N0}")})
        Me.GCAEmployeeContribution1.Visible = True
        Me.GCAEmployeeContribution1.VisibleIndex = 4
        Me.GCAEmployeeContribution1.Width = 193
        '
        'GCAEmployeeContribution2
        '
        Me.GCAEmployeeContribution2.Caption = "Dibayar Oleh Karyawan (JHT)"
        Me.GCAEmployeeContribution2.DisplayFormat.FormatString = "N0"
        Me.GCAEmployeeContribution2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCAEmployeeContribution2.FieldName = "employee_contribution_2"
        Me.GCAEmployeeContribution2.Name = "GCAEmployeeContribution2"
        Me.GCAEmployeeContribution2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "employee_contribution_2", "{0:N0}")})
        Me.GCAEmployeeContribution2.Visible = True
        Me.GCAEmployeeContribution2.VisibleIndex = 5
        Me.GCAEmployeeContribution2.Width = 195
        '
        'GCATotalContribution
        '
        Me.GCATotalContribution.Caption = "Bayar ke BPJS Ketenagakerjaan"
        Me.GCATotalContribution.DisplayFormat.FormatString = "N0"
        Me.GCATotalContribution.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCATotalContribution.FieldName = "total_contribution"
        Me.GCATotalContribution.Name = "GCATotalContribution"
        Me.GCATotalContribution.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_contribution", "{0:N0}")})
        Me.GCATotalContribution.UnboundExpression = "[company_contribution_1] + [company_contribution_2] + [employee_contribution_1] +" &
    " [employee_contribution_2]"
        Me.GCATotalContribution.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GCATotalContribution.Visible = True
        Me.GCATotalContribution.VisibleIndex = 6
        Me.GCATotalContribution.Width = 193
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GCEmployee)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1002, 655)
        Me.XtraTabPage2.Text = "Detail"
        '
        'GCEmployee
        '
        Me.GCEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmployee.Location = New System.Drawing.Point(0, 0)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.Size = New System.Drawing.Size(1002, 655)
        Me.GCEmployee.TabIndex = 3
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3, Me.gridBand4})
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GCLocation, Me.GCDepartement, Me.GCNo, Me.GCEmployeeKjp, Me.GCEmployeeName, Me.GCJenisKelamin, Me.GCEmployeeDOB, Me.GCKepProg, Me.GCEmployeeSalaryBefore, Me.GCEmployeeSalary, Me.GCCompanyContribution1, Me.GCCompanyContribution2, Me.GCEmployeeContribution1, Me.GCEmployeeContribution2, Me.GCTotalContribution})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 2
        Me.GVEmployee.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_contribution", Me.GCTotalContribution, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "company_contribution_1", Me.GCCompanyContribution1, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "company_contribution_2", Me.GCCompanyContribution2, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "employee_contribution_1", Me.GCEmployeeContribution1, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "employee_contribution_2", Me.GCEmployeeContribution2, "{0:N0}")})
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsBehavior.Editable = False
        Me.GVEmployee.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVEmployee.OptionsView.ShowFooter = True
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCLocation, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand1
        '
        Me.GridBand1.Columns.Add(Me.GCDepartement)
        Me.GridBand1.Columns.Add(Me.GCNo)
        Me.GridBand1.Columns.Add(Me.GCEmployeeKjp)
        Me.GridBand1.Columns.Add(Me.GCEmployeeName)
        Me.GridBand1.Columns.Add(Me.GCJenisKelamin)
        Me.GridBand1.Columns.Add(Me.GCEmployeeDOB)
        Me.GridBand1.Columns.Add(Me.GCKepProg)
        Me.GridBand1.Columns.Add(Me.GCEmployeeSalaryBefore)
        Me.GridBand1.Columns.Add(Me.GCEmployeeSalary)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 693
        '
        'GCDepartement
        '
        Me.GCDepartement.Caption = "Departement"
        Me.GCDepartement.FieldName = "departement"
        Me.GCDepartement.Name = "GCDepartement"
        Me.GCDepartement.Width = 86
        '
        'GCNo
        '
        Me.GCNo.Caption = "No"
        Me.GCNo.FieldName = "no"
        Me.GCNo.Name = "GCNo"
        Me.GCNo.Visible = True
        '
        'GCEmployeeKjp
        '
        Me.GCEmployeeKjp.Caption = "KPJ"
        Me.GCEmployeeKjp.FieldName = "employee_bpjs_tk"
        Me.GCEmployeeKjp.Name = "GCEmployeeKjp"
        Me.GCEmployeeKjp.Visible = True
        '
        'GCEmployeeName
        '
        Me.GCEmployeeName.Caption = "Nama"
        Me.GCEmployeeName.FieldName = "employee_name"
        Me.GCEmployeeName.Name = "GCEmployeeName"
        Me.GCEmployeeName.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "employee_name", "{0}")})
        Me.GCEmployeeName.Visible = True
        Me.GCEmployeeName.Width = 88
        '
        'GCJenisKelamin
        '
        Me.GCJenisKelamin.Caption = "Jenis Kelamin"
        Me.GCJenisKelamin.FieldName = "employee_sex"
        Me.GCJenisKelamin.Name = "GCJenisKelamin"
        Me.GCJenisKelamin.Visible = True
        '
        'GCEmployeeDOB
        '
        Me.GCEmployeeDOB.Caption = "Lahir"
        Me.GCEmployeeDOB.FieldName = "employee_dob"
        Me.GCEmployeeDOB.Name = "GCEmployeeDOB"
        Me.GCEmployeeDOB.Visible = True
        '
        'GCKepProg
        '
        Me.GCKepProg.Caption = "Kep Prog"
        Me.GCKepProg.FieldName = "kep_prog"
        Me.GCKepProg.Name = "GCKepProg"
        Me.GCKepProg.Visible = True
        '
        'GCEmployeeSalaryBefore
        '
        Me.GCEmployeeSalaryBefore.Caption = "Upah"
        Me.GCEmployeeSalaryBefore.DisplayFormat.FormatString = "N0"
        Me.GCEmployeeSalaryBefore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCEmployeeSalaryBefore.FieldName = "employee_salary_before"
        Me.GCEmployeeSalaryBefore.Name = "GCEmployeeSalaryBefore"
        Me.GCEmployeeSalaryBefore.Visible = True
        '
        'GCEmployeeSalary
        '
        Me.GCEmployeeSalary.Caption = "Upah"
        Me.GCEmployeeSalary.DisplayFormat.FormatString = "N0"
        Me.GCEmployeeSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCEmployeeSalary.FieldName = "employee_salary"
        Me.GCEmployeeSalary.Name = "GCEmployeeSalary"
        Me.GCEmployeeSalary.Visible = True
        Me.GCEmployeeSalary.Width = 155
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "Dibayar Oleh Perusahaan"
        Me.gridBand2.Columns.Add(Me.GCCompanyContribution1)
        Me.gridBand2.Columns.Add(Me.GCEmployeeContribution1)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 232
        '
        'GCCompanyContribution1
        '
        Me.GCCompanyContribution1.Caption = "JKK, JKM, JHT"
        Me.GCCompanyContribution1.DisplayFormat.FormatString = "N0"
        Me.GCCompanyContribution1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCCompanyContribution1.FieldName = "company_contribution_1"
        Me.GCCompanyContribution1.Name = "GCCompanyContribution1"
        Me.GCCompanyContribution1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "company_contribution_1", "{0:N0}")})
        Me.GCCompanyContribution1.Visible = True
        Me.GCCompanyContribution1.Width = 125
        '
        'GCEmployeeContribution1
        '
        Me.GCEmployeeContribution1.Caption = "JP"
        Me.GCEmployeeContribution1.DisplayFormat.FormatString = "N0"
        Me.GCEmployeeContribution1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCEmployeeContribution1.FieldName = "employee_contribution_1"
        Me.GCEmployeeContribution1.Name = "GCEmployeeContribution1"
        Me.GCEmployeeContribution1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "employee_contribution_1", "{0:N0}")})
        Me.GCEmployeeContribution1.Visible = True
        Me.GCEmployeeContribution1.Width = 107
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "Dibayar Oleh Karyawan"
        Me.gridBand3.Columns.Add(Me.GCCompanyContribution2)
        Me.gridBand3.Columns.Add(Me.GCEmployeeContribution2)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 150
        '
        'GCCompanyContribution2
        '
        Me.GCCompanyContribution2.Caption = "JP"
        Me.GCCompanyContribution2.DisplayFormat.FormatString = "N0"
        Me.GCCompanyContribution2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCCompanyContribution2.FieldName = "company_contribution_2"
        Me.GCCompanyContribution2.Name = "GCCompanyContribution2"
        Me.GCCompanyContribution2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "company_contribution_2", "{0:N0}")})
        Me.GCCompanyContribution2.Visible = True
        '
        'GCEmployeeContribution2
        '
        Me.GCEmployeeContribution2.Caption = "JHT"
        Me.GCEmployeeContribution2.DisplayFormat.FormatString = "N0"
        Me.GCEmployeeContribution2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCEmployeeContribution2.FieldName = "employee_contribution_2"
        Me.GCEmployeeContribution2.Name = "GCEmployeeContribution2"
        Me.GCEmployeeContribution2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "employee_contribution_2", "{0:N0}")})
        Me.GCEmployeeContribution2.Visible = True
        '
        'gridBand4
        '
        Me.gridBand4.Columns.Add(Me.GCTotalContribution)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 3
        Me.gridBand4.Width = 179
        '
        'GCTotalContribution
        '
        Me.GCTotalContribution.Caption = "Bayar ke BPJS Ketenagakerjaan"
        Me.GCTotalContribution.DisplayFormat.FormatString = "N0"
        Me.GCTotalContribution.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalContribution.FieldName = "total_contribution"
        Me.GCTotalContribution.Name = "GCTotalContribution"
        Me.GCTotalContribution.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_contribution", "{0:N0}")})
        Me.GCTotalContribution.UnboundExpression = "[company_contribution_1] + [company_contribution_2] + [employee_contribution_1] +" &
    " [employee_contribution_2]"
        Me.GCTotalContribution.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GCTotalContribution.Visible = True
        Me.GCTotalContribution.Width = 179
        '
        'GCLocation
        '
        Me.GCLocation.Caption = "Location"
        Me.GCLocation.FieldName = "bpjs_tk_location"
        Me.GCLocation.Name = "GCLocation"
        '
        'FormEmpPayrollReportBPJSTK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormEmpPayrollReportBPJSTK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report BPJS TK"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.GCAllDepartements, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAllDepartements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCAllDepartements As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAllDepartements As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCANo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCADepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCACompanyContribution2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCAEmployeeContribution1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATotalContribution As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents GCACompanyContribution1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCAEmployeeContribution2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeeKjp As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeeName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCJenisKelamin As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeeDOB As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCKepProg As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeeSalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCCompanyContribution1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeeContribution1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalContribution As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCCompanyContribution2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeeContribution2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCALocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLocation As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeeSalaryBefore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
