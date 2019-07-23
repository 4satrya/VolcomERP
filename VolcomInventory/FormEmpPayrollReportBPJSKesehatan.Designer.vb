<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpPayrollReportBPJSKesehatan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollReportBPJSKesehatan))
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.GCAllDepartements = New DevExpress.XtraGrid.GridControl()
        Me.GVAllDepartements = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCANo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCADepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCAConpanyContribution = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCAEmployeeContribution = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATotalContribution = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeBpjs = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeDOB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeSalary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCompanyContribution = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeContribution = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCTotalContribution = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCClass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBPrint = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.GCAllDepartements, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAllDepartements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 46)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1008, 683)
        Me.XtraTabControl1.TabIndex = 0
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
        Me.GVAllDepartements.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCANo, Me.GCADepartement, Me.GCAConpanyContribution, Me.GCAEmployeeContribution, Me.GCATotalContribution})
        Me.GVAllDepartements.GridControl = Me.GCAllDepartements
        Me.GVAllDepartements.Name = "GVAllDepartements"
        Me.GVAllDepartements.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVAllDepartements.OptionsBehavior.Editable = False
        Me.GVAllDepartements.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVAllDepartements.OptionsView.ShowFooter = True
        Me.GVAllDepartements.OptionsView.ShowGroupPanel = False
        '
        'GCANo
        '
        Me.GCANo.Caption = "No"
        Me.GCANo.FieldName = "no"
        Me.GCANo.Name = "GCANo"
        Me.GCANo.Visible = True
        Me.GCANo.VisibleIndex = 0
        '
        'GCADepartement
        '
        Me.GCADepartement.Caption = "Departement"
        Me.GCADepartement.FieldName = "departement"
        Me.GCADepartement.Name = "GCADepartement"
        Me.GCADepartement.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "departement", "Total Biaya Iuran")})
        Me.GCADepartement.Visible = True
        Me.GCADepartement.VisibleIndex = 1
        '
        'GCAConpanyContribution
        '
        Me.GCAConpanyContribution.Caption = "Dibayar Oleh Perusahaan"
        Me.GCAConpanyContribution.DisplayFormat.FormatString = "N0"
        Me.GCAConpanyContribution.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCAConpanyContribution.FieldName = "company_contribution"
        Me.GCAConpanyContribution.Name = "GCAConpanyContribution"
        Me.GCAConpanyContribution.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "company_contribution", "{0:N0}")})
        Me.GCAConpanyContribution.Visible = True
        Me.GCAConpanyContribution.VisibleIndex = 2
        '
        'GCAEmployeeContribution
        '
        Me.GCAEmployeeContribution.Caption = "Dibayar Oleh Karyawan"
        Me.GCAEmployeeContribution.DisplayFormat.FormatString = "N0"
        Me.GCAEmployeeContribution.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCAEmployeeContribution.FieldName = "employee_contribution"
        Me.GCAEmployeeContribution.Name = "GCAEmployeeContribution"
        Me.GCAEmployeeContribution.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "employee_contribution", "{0:N0}")})
        Me.GCAEmployeeContribution.Visible = True
        Me.GCAEmployeeContribution.VisibleIndex = 3
        '
        'GCATotalContribution
        '
        Me.GCATotalContribution.Caption = "Dibayarkan ke BPJS Kesehatan"
        Me.GCATotalContribution.DisplayFormat.FormatString = "N0"
        Me.GCATotalContribution.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCATotalContribution.FieldName = "total_contribution"
        Me.GCATotalContribution.Name = "GCATotalContribution"
        Me.GCATotalContribution.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_contribution", "{0:N0}")})
        Me.GCATotalContribution.Visible = True
        Me.GCATotalContribution.VisibleIndex = 4
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
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCDepartement, Me.GCNo, Me.GCEmployeeName, Me.GCEmployeeBpjs, Me.GCEmployeeDOB, Me.GCEmployeeSalary, Me.GCCompanyContribution, Me.GCEmployeeContribution, Me.GCTotalContribution, Me.GCClass})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 1
        Me.GVEmployee.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "employee_name", Me.GCEmployeeName, "{0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "company_contribution", Me.GCCompanyContribution, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "employee_contribution", Me.GCEmployeeContribution, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_contribution", Me.GCTotalContribution, "{0:N0}")})
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsBehavior.Editable = False
        Me.GVEmployee.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVEmployee.OptionsView.ShowFooter = True
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GCDepartement
        '
        Me.GCDepartement.Caption = "Departement"
        Me.GCDepartement.FieldName = "departement"
        Me.GCDepartement.Name = "GCDepartement"
        Me.GCDepartement.Visible = True
        Me.GCDepartement.VisibleIndex = 0
        Me.GCDepartement.Width = 86
        '
        'GCNo
        '
        Me.GCNo.Caption = "No"
        Me.GCNo.FieldName = "no"
        Me.GCNo.Name = "GCNo"
        Me.GCNo.Visible = True
        Me.GCNo.VisibleIndex = 0
        '
        'GCEmployeeName
        '
        Me.GCEmployeeName.Caption = "Nama Karyawan"
        Me.GCEmployeeName.FieldName = "employee_name"
        Me.GCEmployeeName.Name = "GCEmployeeName"
        Me.GCEmployeeName.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "employee_name", "{0}")})
        Me.GCEmployeeName.Visible = True
        Me.GCEmployeeName.VisibleIndex = 1
        Me.GCEmployeeName.Width = 88
        '
        'GCEmployeeBpjs
        '
        Me.GCEmployeeBpjs.Caption = "No BPJS"
        Me.GCEmployeeBpjs.FieldName = "employee_bpjs_kesehatan"
        Me.GCEmployeeBpjs.Name = "GCEmployeeBpjs"
        Me.GCEmployeeBpjs.Visible = True
        Me.GCEmployeeBpjs.VisibleIndex = 2
        '
        'GCEmployeeDOB
        '
        Me.GCEmployeeDOB.Caption = "Tanggal Lahir"
        Me.GCEmployeeDOB.FieldName = "employee_dob"
        Me.GCEmployeeDOB.Name = "GCEmployeeDOB"
        Me.GCEmployeeDOB.Visible = True
        Me.GCEmployeeDOB.VisibleIndex = 3
        '
        'GCEmployeeSalary
        '
        Me.GCEmployeeSalary.Caption = "Gaji Pokok + Tunjangan Tetap"
        Me.GCEmployeeSalary.DisplayFormat.FormatString = "N0"
        Me.GCEmployeeSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCEmployeeSalary.FieldName = "employee_salary"
        Me.GCEmployeeSalary.Name = "GCEmployeeSalary"
        Me.GCEmployeeSalary.Visible = True
        Me.GCEmployeeSalary.VisibleIndex = 4
        Me.GCEmployeeSalary.Width = 155
        '
        'GCCompanyContribution
        '
        Me.GCCompanyContribution.Caption = "Iuran Pemberi Kerja 4%"
        Me.GCCompanyContribution.DisplayFormat.FormatString = "N0"
        Me.GCCompanyContribution.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCCompanyContribution.FieldName = "company_contribution"
        Me.GCCompanyContribution.Name = "GCCompanyContribution"
        Me.GCCompanyContribution.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "company_contribution", "{0:N0}")})
        Me.GCCompanyContribution.Visible = True
        Me.GCCompanyContribution.VisibleIndex = 5
        Me.GCCompanyContribution.Width = 125
        '
        'GCEmployeeContribution
        '
        Me.GCEmployeeContribution.Caption = "Iuran Karyawan 1%"
        Me.GCEmployeeContribution.DisplayFormat.FormatString = "N0"
        Me.GCEmployeeContribution.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCEmployeeContribution.FieldName = "employee_contribution"
        Me.GCEmployeeContribution.Name = "GCEmployeeContribution"
        Me.GCEmployeeContribution.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "employee_contribution", "{0:N0}")})
        Me.GCEmployeeContribution.Visible = True
        Me.GCEmployeeContribution.VisibleIndex = 6
        Me.GCEmployeeContribution.Width = 107
        '
        'GCTotalContribution
        '
        Me.GCTotalContribution.Caption = "Total Iuran"
        Me.GCTotalContribution.DisplayFormat.FormatString = "N0"
        Me.GCTotalContribution.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalContribution.FieldName = "total_contribution"
        Me.GCTotalContribution.Name = "GCTotalContribution"
        Me.GCTotalContribution.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_contribution", "{0:N0}")})
        Me.GCTotalContribution.Visible = True
        Me.GCTotalContribution.VisibleIndex = 7
        '
        'GCClass
        '
        Me.GCClass.Caption = "Hak Kelas Rawat"
        Me.GCClass.FieldName = "class"
        Me.GCClass.Name = "GCClass"
        Me.GCClass.Visible = True
        Me.GCClass.VisibleIndex = 8
        Me.GCClass.Width = 90
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1008, 46)
        Me.PanelControl1.TabIndex = 4
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
        'FormEmpPayrollReportBPJSKesehatan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayrollReportBPJSKesehatan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report BPJS Kesehatan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.GCAllDepartements, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAllDepartements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeBpjs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeDOB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeSalary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCompanyContribution As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeContribution As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCTotalContribution As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCClass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCAllDepartements As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAllDepartements As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCANo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCADepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCAConpanyContribution As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCAEmployeeContribution As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATotalContribution As DevExpress.XtraGrid.Columns.GridColumn
End Class
