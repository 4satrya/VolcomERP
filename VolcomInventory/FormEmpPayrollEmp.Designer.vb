<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayrollEmp
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollEmp))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BPickAll = New DevExpress.XtraEditors.SimpleButton()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BPick = New DevExpress.XtraEditors.SimpleButton()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployeeSalary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCTotalWorkdays = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCActualWorkdays = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCNIP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCPosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployeeLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCEmployeeStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdEmployeeActive = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCActiveStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCActualJoinDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLastWorkingDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCReligion = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "1415351112474759854-32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "icon_merchandise_clothes32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "t_shirtgreen.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "lock red.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "ordering32.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "kghostview.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "MetroUI-Folder-OS-Configure-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(17, "Setting(32).png")
        Me.LargeImageCollection.Images.SetKeyName(18, "estimate_icon32.png")
        Me.LargeImageCollection.Images.SetKeyName(19, "copy_icon.png")
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BPickAll)
        Me.PanelControl3.Controls.Add(Me.BCancel)
        Me.PanelControl3.Controls.Add(Me.BPick)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 524)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1008, 37)
        Me.PanelControl3.TabIndex = 6
        '
        'BPickAll
        '
        Me.BPickAll.Dock = System.Windows.Forms.DockStyle.Left
        Me.BPickAll.ImageIndex = 19
        Me.BPickAll.ImageList = Me.LargeImageCollection
        Me.BPickAll.Location = New System.Drawing.Point(2, 2)
        Me.BPickAll.Name = "BPickAll"
        Me.BPickAll.Size = New System.Drawing.Size(191, 33)
        Me.BPickAll.TabIndex = 2
        Me.BPickAll.Text = "Insert All Eligible Employee"
        Me.BPickAll.Visible = False
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.ImageIndex = 5
        Me.BCancel.ImageList = Me.LargeImageCollection
        Me.BCancel.Location = New System.Drawing.Point(858, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(73, 33)
        Me.BCancel.TabIndex = 1
        Me.BCancel.Text = "Cancel"
        '
        'BPick
        '
        Me.BPick.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPick.ImageIndex = 19
        Me.BPick.ImageList = Me.LargeImageCollection
        Me.BPick.Location = New System.Drawing.Point(931, 2)
        Me.BPick.Name = "BPick"
        Me.BPick.Size = New System.Drawing.Size(75, 33)
        Me.BPick.TabIndex = 0
        Me.BPick.Text = "Insert"
        '
        'GCEmployee
        '
        Me.GCEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmployee.Location = New System.Drawing.Point(0, 0)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.Size = New System.Drawing.Size(1008, 524)
        Me.GCEmployee.TabIndex = 7
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCIdEmployee, Me.GCIdEmployeeSalary, Me.GCTotalWorkdays, Me.GCActualWorkdays, Me.GCNIP, Me.GCName, Me.GCIdDepartement, Me.GCDepartement, Me.GCPosition, Me.GCIdEmployeeLevel, Me.GCLevel, Me.GCIdEmployeeStatus, Me.GCEmployeeStatus, Me.GCIdEmployeeActive, Me.GCActiveStatus, Me.GCActualJoinDate, Me.GCLastWorkingDate, Me.GCReligion})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 1
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsFind.AlwaysVisible = True
        Me.GVEmployee.OptionsSelection.MultiSelect = True
        Me.GVEmployee.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GVEmployee.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GCIdEmployee
        '
        Me.GCIdEmployee.FieldName = "id_employee"
        Me.GCIdEmployee.Name = "GCIdEmployee"
        Me.GCIdEmployee.OptionsColumn.AllowEdit = False
        '
        'GCIdEmployeeSalary
        '
        Me.GCIdEmployeeSalary.FieldName = "id_employee_salary"
        Me.GCIdEmployeeSalary.Name = "GCIdEmployeeSalary"
        Me.GCIdEmployeeSalary.OptionsColumn.AllowEdit = False
        '
        'GCTotalWorkdays
        '
        Me.GCTotalWorkdays.FieldName = "total_workdays"
        Me.GCTotalWorkdays.Name = "GCTotalWorkdays"
        Me.GCTotalWorkdays.OptionsColumn.AllowEdit = False
        '
        'GCActualWorkdays
        '
        Me.GCActualWorkdays.FieldName = "actual_workdays"
        Me.GCActualWorkdays.Name = "GCActualWorkdays"
        Me.GCActualWorkdays.OptionsColumn.AllowEdit = False
        '
        'GCNIP
        '
        Me.GCNIP.Caption = "NIP"
        Me.GCNIP.FieldName = "employee_code"
        Me.GCNIP.Name = "GCNIP"
        Me.GCNIP.OptionsColumn.AllowEdit = False
        Me.GCNIP.Visible = True
        Me.GCNIP.VisibleIndex = 1
        '
        'GCName
        '
        Me.GCName.Caption = "Employee"
        Me.GCName.FieldName = "employee_name"
        Me.GCName.Name = "GCName"
        Me.GCName.OptionsColumn.AllowEdit = False
        Me.GCName.Visible = True
        Me.GCName.VisibleIndex = 2
        '
        'GCIdDepartement
        '
        Me.GCIdDepartement.FieldName = "id_departement"
        Me.GCIdDepartement.Name = "GCIdDepartement"
        '
        'GCDepartement
        '
        Me.GCDepartement.Caption = "Departement"
        Me.GCDepartement.FieldName = "departement"
        Me.GCDepartement.Name = "GCDepartement"
        Me.GCDepartement.OptionsColumn.AllowEdit = False
        Me.GCDepartement.Visible = True
        Me.GCDepartement.VisibleIndex = 3
        Me.GCDepartement.Width = 86
        '
        'GCPosition
        '
        Me.GCPosition.Caption = "Employee Position"
        Me.GCPosition.FieldName = "employee_position"
        Me.GCPosition.Name = "GCPosition"
        Me.GCPosition.OptionsColumn.AllowEdit = False
        Me.GCPosition.Visible = True
        Me.GCPosition.VisibleIndex = 3
        Me.GCPosition.Width = 96
        '
        'GCIdEmployeeLevel
        '
        Me.GCIdEmployeeLevel.FieldName = "id_employee_level"
        Me.GCIdEmployeeLevel.Name = "GCIdEmployeeLevel"
        '
        'GCLevel
        '
        Me.GCLevel.Caption = "Employee Level"
        Me.GCLevel.FieldName = "employee_level"
        Me.GCLevel.Name = "GCLevel"
        Me.GCLevel.OptionsColumn.AllowEdit = False
        Me.GCLevel.Visible = True
        Me.GCLevel.VisibleIndex = 4
        Me.GCLevel.Width = 84
        '
        'GCIdEmployeeStatus
        '
        Me.GCIdEmployeeStatus.FieldName = "id_employee_status"
        Me.GCIdEmployeeStatus.Name = "GCIdEmployeeStatus"
        '
        'GCEmployeeStatus
        '
        Me.GCEmployeeStatus.Caption = "Employee Status"
        Me.GCEmployeeStatus.FieldName = "employee_status"
        Me.GCEmployeeStatus.Name = "GCEmployeeStatus"
        Me.GCEmployeeStatus.OptionsColumn.AllowEdit = False
        Me.GCEmployeeStatus.Visible = True
        Me.GCEmployeeStatus.VisibleIndex = 5
        Me.GCEmployeeStatus.Width = 90
        '
        'GCIdEmployeeActive
        '
        Me.GCIdEmployeeActive.FieldName = "id_employee_active"
        Me.GCIdEmployeeActive.Name = "GCIdEmployeeActive"
        '
        'GCActiveStatus
        '
        Me.GCActiveStatus.Caption = "Active Status"
        Me.GCActiveStatus.FieldName = "employee_active"
        Me.GCActiveStatus.Name = "GCActiveStatus"
        Me.GCActiveStatus.OptionsColumn.AllowEdit = False
        Me.GCActiveStatus.Visible = True
        Me.GCActiveStatus.VisibleIndex = 6
        '
        'GCActualJoinDate
        '
        Me.GCActualJoinDate.Caption = "Actual Join Date"
        Me.GCActualJoinDate.FieldName = "employee_actual_join_date"
        Me.GCActualJoinDate.Name = "GCActualJoinDate"
        Me.GCActualJoinDate.Visible = True
        Me.GCActualJoinDate.VisibleIndex = 7
        Me.GCActualJoinDate.Width = 108
        '
        'GCLastWorkingDate
        '
        Me.GCLastWorkingDate.Caption = "Last Working Date"
        Me.GCLastWorkingDate.FieldName = "employee_last_date"
        Me.GCLastWorkingDate.Name = "GCLastWorkingDate"
        Me.GCLastWorkingDate.Visible = True
        Me.GCLastWorkingDate.VisibleIndex = 8
        Me.GCLastWorkingDate.Width = 98
        '
        'GCReligion
        '
        Me.GCReligion.Caption = "Religion"
        Me.GCReligion.FieldName = "religion"
        Me.GCReligion.Name = "GCReligion"
        '
        'FormEmpPayrollEmp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 561)
        Me.Controls.Add(Me.GCEmployee)
        Me.Controls.Add(Me.PanelControl3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayrollEmp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insert Employee"
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPick As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPickAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCNIP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCPosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployeeLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployeeActive As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCActiveStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCEmployeeStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdEmployeeSalary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCTotalWorkdays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCActualWorkdays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLastWorkingDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCReligion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCActualJoinDate As DevExpress.XtraGrid.Columns.GridColumn
End Class
