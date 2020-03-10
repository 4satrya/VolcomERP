<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpBPJSKesehatanPick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpBPJSKesehatanPick))
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCCheck = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICECheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GCIdDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdDepartementSub = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeePosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCBPJSKesehatan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDOB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployeeSalary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCFixedSalary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCBPJSKesehatanContribution = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCEmployeeActive = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCEmployee
        '
        Me.GCEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmployee.Location = New System.Drawing.Point(0, 0)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICECheck})
        Me.GCEmployee.Size = New System.Drawing.Size(784, 509)
        Me.GCEmployee.TabIndex = 4
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCCheck, Me.GCIdDepartement, Me.GCIdDepartementSub, Me.GCDepartement, Me.GCIdEmployee, Me.GCEmployeeCode, Me.GCEmployeeName, Me.GCEmployeePosition, Me.GCBPJSKesehatan, Me.GCDOB, Me.GCIdEmployeeStatus, Me.GCEmployeeStatus, Me.GCIdEmployeeSalary, Me.GCEmployeeActive, Me.GCFixedSalary, Me.GCBPJSKesehatanContribution})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 1
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsFind.AlwaysVisible = True
        Me.GVEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GCCheck
        '
        Me.GCCheck.Caption = " "
        Me.GCCheck.ColumnEdit = Me.RICECheck
        Me.GCCheck.FieldName = "is_check"
        Me.GCCheck.Name = "GCCheck"
        Me.GCCheck.Visible = True
        Me.GCCheck.VisibleIndex = 0
        '
        'RICECheck
        '
        Me.RICECheck.AutoHeight = False
        Me.RICECheck.Name = "RICECheck"
        Me.RICECheck.ValueChecked = "yes"
        Me.RICECheck.ValueUnchecked = "no"
        '
        'GCIdDepartement
        '
        Me.GCIdDepartement.FieldName = "id_departement"
        Me.GCIdDepartement.Name = "GCIdDepartement"
        Me.GCIdDepartement.OptionsColumn.AllowEdit = False
        '
        'GCIdDepartementSub
        '
        Me.GCIdDepartementSub.FieldName = "id_departement_sub"
        Me.GCIdDepartementSub.Name = "GCIdDepartementSub"
        Me.GCIdDepartementSub.OptionsColumn.AllowEdit = False
        '
        'GCDepartement
        '
        Me.GCDepartement.Caption = "Departement"
        Me.GCDepartement.FieldName = "departement"
        Me.GCDepartement.Name = "GCDepartement"
        Me.GCDepartement.OptionsColumn.AllowEdit = False
        Me.GCDepartement.Visible = True
        Me.GCDepartement.VisibleIndex = 1
        Me.GCDepartement.Width = 86
        '
        'GCIdEmployee
        '
        Me.GCIdEmployee.FieldName = "id_employee"
        Me.GCIdEmployee.Name = "GCIdEmployee"
        Me.GCIdEmployee.OptionsColumn.AllowEdit = False
        '
        'GCEmployeeCode
        '
        Me.GCEmployeeCode.Caption = "NIP"
        Me.GCEmployeeCode.FieldName = "employee_code"
        Me.GCEmployeeCode.Name = "GCEmployeeCode"
        Me.GCEmployeeCode.OptionsColumn.AllowEdit = False
        Me.GCEmployeeCode.Visible = True
        Me.GCEmployeeCode.VisibleIndex = 1
        '
        'GCEmployeeName
        '
        Me.GCEmployeeName.Caption = "Employee"
        Me.GCEmployeeName.FieldName = "employee_name"
        Me.GCEmployeeName.Name = "GCEmployeeName"
        Me.GCEmployeeName.OptionsColumn.AllowEdit = False
        Me.GCEmployeeName.Visible = True
        Me.GCEmployeeName.VisibleIndex = 2
        '
        'GCEmployeePosition
        '
        Me.GCEmployeePosition.Caption = "Employee Position"
        Me.GCEmployeePosition.FieldName = "employee_position"
        Me.GCEmployeePosition.Name = "GCEmployeePosition"
        Me.GCEmployeePosition.OptionsColumn.AllowEdit = False
        Me.GCEmployeePosition.Visible = True
        Me.GCEmployeePosition.VisibleIndex = 3
        Me.GCEmployeePosition.Width = 96
        '
        'GCBPJSKesehatan
        '
        Me.GCBPJSKesehatan.FieldName = "employee_bpjs_kesehatan"
        Me.GCBPJSKesehatan.Name = "GCBPJSKesehatan"
        '
        'GCDOB
        '
        Me.GCDOB.FieldName = "employee_dob"
        Me.GCDOB.Name = "GCDOB"
        '
        'GCIdEmployeeStatus
        '
        Me.GCIdEmployeeStatus.FieldName = "id_employee_status"
        Me.GCIdEmployeeStatus.Name = "GCIdEmployeeStatus"
        Me.GCIdEmployeeStatus.OptionsColumn.AllowEdit = False
        '
        'GCEmployeeStatus
        '
        Me.GCEmployeeStatus.Caption = "Employee Status"
        Me.GCEmployeeStatus.FieldName = "employee_status"
        Me.GCEmployeeStatus.Name = "GCEmployeeStatus"
        Me.GCEmployeeStatus.OptionsColumn.AllowEdit = False
        Me.GCEmployeeStatus.Visible = True
        Me.GCEmployeeStatus.VisibleIndex = 4
        Me.GCEmployeeStatus.Width = 90
        '
        'GCIdEmployeeSalary
        '
        Me.GCIdEmployeeSalary.FieldName = "id_employee_salary"
        Me.GCIdEmployeeSalary.Name = "GCIdEmployeeSalary"
        Me.GCIdEmployeeSalary.OptionsColumn.AllowEdit = False
        '
        'GCFixedSalary
        '
        Me.GCFixedSalary.Caption = "Fixed Salary"
        Me.GCFixedSalary.DisplayFormat.FormatString = "N0"
        Me.GCFixedSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCFixedSalary.FieldName = "fixed_salary"
        Me.GCFixedSalary.Name = "GCFixedSalary"
        Me.GCFixedSalary.OptionsColumn.AllowEdit = False
        Me.GCFixedSalary.Visible = True
        Me.GCFixedSalary.VisibleIndex = 6
        '
        'GCBPJSKesehatanContribution
        '
        Me.GCBPJSKesehatanContribution.Caption = "BPJS Kesehatan Contribution"
        Me.GCBPJSKesehatanContribution.DisplayFormat.FormatString = "N0"
        Me.GCBPJSKesehatanContribution.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCBPJSKesehatanContribution.FieldName = "bpjs_kesehatan_contribution"
        Me.GCBPJSKesehatanContribution.Name = "GCBPJSKesehatanContribution"
        Me.GCBPJSKesehatanContribution.OptionsColumn.AllowEdit = False
        Me.GCBPJSKesehatanContribution.Visible = True
        Me.GCBPJSKesehatanContribution.VisibleIndex = 7
        Me.GCBPJSKesehatanContribution.Width = 149
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.SBClose)
        Me.PanelControl3.Controls.Add(Me.SBAdd)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 509)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(784, 52)
        Me.PanelControl3.TabIndex = 5
        '
        'SBClose
        '
        Me.SBClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(594, 6)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(89, 40)
        Me.SBClose.TabIndex = 1
        Me.SBClose.Text = "Close"
        '
        'SBAdd
        '
        Me.SBAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBAdd.Image = CType(resources.GetObject("SBAdd.Image"), System.Drawing.Image)
        Me.SBAdd.Location = New System.Drawing.Point(689, 6)
        Me.SBAdd.Name = "SBAdd"
        Me.SBAdd.Size = New System.Drawing.Size(89, 40)
        Me.SBAdd.TabIndex = 0
        Me.SBAdd.Text = "Add"
        '
        'GCEmployeeActive
        '
        Me.GCEmployeeActive.Caption = "Employee Active"
        Me.GCEmployeeActive.FieldName = "employee_active"
        Me.GCEmployeeActive.Name = "GCEmployeeActive"
        Me.GCEmployeeActive.Visible = True
        Me.GCEmployeeActive.VisibleIndex = 5
        Me.GCEmployeeActive.Width = 89
        '
        'FormEmpBPJSKesehatanPick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCEmployee)
        Me.Controls.Add(Me.PanelControl3)
        Me.MinimizeBox = False
        Me.Name = "FormEmpBPJSKesehatanPick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BPJS Kesehatan Pick"
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCCheck As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICECheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GCIdDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeePosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCIdDepartementSub As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCFixedSalary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployeeSalary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCBPJSKesehatanContribution As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCBPJSKesehatan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDOB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeActive As DevExpress.XtraGrid.Columns.GridColumn
End Class
