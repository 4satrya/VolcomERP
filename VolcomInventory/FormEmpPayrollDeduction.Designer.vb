﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayrollDeduction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollDeduction))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.DropDownButton1 = New DevExpress.XtraEditors.DropDownButton()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        Me.BtnDropQuickMenu = New DevExpress.XtraEditors.DropDownButton()
        Me.PopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BBJamsostek = New DevExpress.XtraBars.BarButtonItem()
        Me.BBKoperasi = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BDel = New DevExpress.XtraEditors.SimpleButton()
        Me.BEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCDeduction = New DevExpress.XtraGrid.GridControl()
        Me.GVDeduction = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCCheck = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnIdDeduction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIsOfficePayroll = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCSubDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNIP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmpPosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmpSts = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDeductType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDeduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDeductCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotDays = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCDeduction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDeduction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBPrint)
        Me.PanelControl1.Controls.Add(Me.DropDownButton1)
        Me.PanelControl1.Controls.Add(Me.BtnDropQuickMenu)
        Me.PanelControl1.Controls.Add(Me.BDel)
        Me.PanelControl1.Controls.Add(Me.BEdit)
        Me.PanelControl1.Controls.Add(Me.BAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1253, 38)
        Me.PanelControl1.TabIndex = 0
        '
        'SBPrint
        '
        Me.SBPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBPrint.Enabled = False
        Me.SBPrint.ImageIndex = 6
        Me.SBPrint.ImageList = Me.LargeImageCollection
        Me.SBPrint.Location = New System.Drawing.Point(927, 2)
        Me.SBPrint.Name = "SBPrint"
        Me.SBPrint.Size = New System.Drawing.Size(81, 34)
        Me.SBPrint.TabIndex = 111
        Me.SBPrint.Text = "Print"
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
        'DropDownButton1
        '
        Me.DropDownButton1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DropDownButton1.DropDownControl = Me.PopupMenu1
        Me.DropDownButton1.ImageIndex = 19
        Me.DropDownButton1.ImageList = Me.LargeImageCollection
        Me.DropDownButton1.Location = New System.Drawing.Point(146, 2)
        Me.DropDownButton1.Name = "DropDownButton1"
        Me.DropDownButton1.Size = New System.Drawing.Size(114, 34)
        Me.DropDownButton1.TabIndex = 110
        Me.DropDownButton1.Text = "Import"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem3), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem2)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Import Cooperative Loan"
        Me.BarButtonItem3.Id = 14
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Jamsostek"
        Me.BarButtonItem1.Id = 12
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Koperasi"
        Me.BarButtonItem2.Id = 13
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.BarDockControl1)
        Me.BarManager1.DockControls.Add(Me.BarDockControl2)
        Me.BarManager1.DockControls.Add(Me.BarDockControl3)
        Me.BarManager1.DockControls.Add(Me.BarDockControl4)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3})
        Me.BarManager1.MaxItemId = 15
        '
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = False
        Me.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl1.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl1.Size = New System.Drawing.Size(1253, 0)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 541)
        Me.BarDockControl2.Size = New System.Drawing.Size(1253, 0)
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl3.Size = New System.Drawing.Size(0, 541)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl4.Location = New System.Drawing.Point(1253, 0)
        Me.BarDockControl4.Size = New System.Drawing.Size(0, 541)
        '
        'BtnDropQuickMenu
        '
        Me.BtnDropQuickMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnDropQuickMenu.DropDownControl = Me.PopupMenu
        Me.BtnDropQuickMenu.ImageIndex = 14
        Me.BtnDropQuickMenu.ImageList = Me.LargeImageCollection
        Me.BtnDropQuickMenu.Location = New System.Drawing.Point(2, 2)
        Me.BtnDropQuickMenu.Name = "BtnDropQuickMenu"
        Me.BtnDropQuickMenu.Size = New System.Drawing.Size(144, 34)
        Me.BtnDropQuickMenu.TabIndex = 109
        Me.BtnDropQuickMenu.Text = "Auto Generate"
        '
        'PopupMenu
        '
        Me.PopupMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBJamsostek), New DevExpress.XtraBars.LinkPersistInfo(Me.BBKoperasi)})
        Me.PopupMenu.Manager = Me.BarManager
        Me.PopupMenu.Name = "PopupMenu"
        '
        'BBJamsostek
        '
        Me.BBJamsostek.Caption = "BPJSTK"
        Me.BBJamsostek.Id = 12
        Me.BBJamsostek.Name = "BBJamsostek"
        '
        'BBKoperasi
        '
        Me.BBKoperasi.Caption = "Cooperative Contribution"
        Me.BBKoperasi.Id = 13
        Me.BBKoperasi.Name = "BBKoperasi"
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBJamsostek, Me.BBKoperasi})
        Me.BarManager.MaxItemId = 14
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1253, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 541)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1253, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 541)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1253, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 541)
        '
        'BDel
        '
        Me.BDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDel.ImageIndex = 1
        Me.BDel.ImageList = Me.LargeImageCollection
        Me.BDel.Location = New System.Drawing.Point(1008, 2)
        Me.BDel.Name = "BDel"
        Me.BDel.Size = New System.Drawing.Size(81, 34)
        Me.BDel.TabIndex = 2
        Me.BDel.Text = "Delete"
        '
        'BEdit
        '
        Me.BEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEdit.ImageIndex = 2
        Me.BEdit.ImageList = Me.LargeImageCollection
        Me.BEdit.Location = New System.Drawing.Point(1089, 2)
        Me.BEdit.Name = "BEdit"
        Me.BEdit.Size = New System.Drawing.Size(81, 34)
        Me.BEdit.TabIndex = 112
        Me.BEdit.Text = "Edit"
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.ImageIndex = 0
        Me.BAdd.ImageList = Me.LargeImageCollection
        Me.BAdd.Location = New System.Drawing.Point(1170, 2)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(81, 34)
        Me.BAdd.TabIndex = 0
        Me.BAdd.Text = "Add"
        '
        'GCDeduction
        '
        Me.GCDeduction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDeduction.Location = New System.Drawing.Point(0, 38)
        Me.GCDeduction.MainView = Me.GVDeduction
        Me.GCDeduction.Name = "GCDeduction"
        Me.GCDeduction.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit})
        Me.GCDeduction.Size = New System.Drawing.Size(1253, 503)
        Me.GCDeduction.TabIndex = 1
        Me.GCDeduction.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDeduction})
        '
        'GVDeduction
        '
        Me.GVDeduction.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCCheck, Me.GridColumnIdDeduction, Me.GridColumnIdEmployee, Me.GCIsOfficePayroll, Me.GridColumnGroup, Me.GridColumnDept, Me.GCSubDept, Me.GridColumnNIP, Me.GridColumnEmp, Me.GridColumnEmpPosition, Me.GridColumnEmpSts, Me.GridColumnDeductType, Me.GridColumnIdDeduct, Me.GridColumnDeductCategory, Me.GridColumnTotDays, Me.GridColumnValue, Me.GridColumnNote})
        Me.GVDeduction.GridControl = Me.GCDeduction
        Me.GVDeduction.GroupCount = 3
        Me.GVDeduction.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "deduction", Me.GridColumnValue, "{0:N0}")})
        Me.GVDeduction.Name = "GVDeduction"
        Me.GVDeduction.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDeduction.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVDeduction.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVDeduction.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVDeduction.OptionsView.ShowFooter = True
        Me.GVDeduction.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.GVDeduction.OptionsView.ShowGroupPanel = False
        Me.GVDeduction.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnGroup, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDept, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCSubDept, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GCCheck
        '
        Me.GCCheck.Caption = "*"
        Me.GCCheck.ColumnEdit = Me.RepositoryItemCheckEdit
        Me.GCCheck.FieldName = "is_check"
        Me.GCCheck.Name = "GCCheck"
        Me.GCCheck.Visible = True
        Me.GCCheck.VisibleIndex = 0
        Me.GCCheck.Width = 83
        '
        'RepositoryItemCheckEdit
        '
        Me.RepositoryItemCheckEdit.AutoHeight = False
        Me.RepositoryItemCheckEdit.Name = "RepositoryItemCheckEdit"
        Me.RepositoryItemCheckEdit.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit.ValueUnchecked = "no"
        '
        'GridColumnIdDeduction
        '
        Me.GridColumnIdDeduction.Caption = "ID Deduction"
        Me.GridColumnIdDeduction.FieldName = "id_payroll_deduction"
        Me.GridColumnIdDeduction.Name = "GridColumnIdDeduction"
        Me.GridColumnIdDeduction.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdEmployee
        '
        Me.GridColumnIdEmployee.Caption = "ID Employee"
        Me.GridColumnIdEmployee.FieldName = "id_employee"
        Me.GridColumnIdEmployee.Name = "GridColumnIdEmployee"
        Me.GridColumnIdEmployee.OptionsColumn.AllowEdit = False
        '
        'GCIsOfficePayroll
        '
        Me.GCIsOfficePayroll.FieldName = "is_office_payroll"
        Me.GCIsOfficePayroll.Name = "GCIsOfficePayroll"
        Me.GCIsOfficePayroll.OptionsColumn.AllowEdit = False
        '
        'GridColumnGroup
        '
        Me.GridColumnGroup.Caption = "Group"
        Me.GridColumnGroup.FieldName = "group_report"
        Me.GridColumnGroup.Name = "GridColumnGroup"
        Me.GridColumnGroup.OptionsColumn.AllowEdit = False
        Me.GridColumnGroup.Visible = True
        Me.GridColumnGroup.VisibleIndex = 3
        '
        'GridColumnDept
        '
        Me.GridColumnDept.Caption = "Departement"
        Me.GridColumnDept.FieldName = "departement"
        Me.GridColumnDept.Name = "GridColumnDept"
        Me.GridColumnDept.OptionsColumn.AllowEdit = False
        Me.GridColumnDept.Visible = True
        Me.GridColumnDept.VisibleIndex = 1
        '
        'GCSubDept
        '
        Me.GCSubDept.Caption = "Sub Departement"
        Me.GCSubDept.FieldName = "departement_sub"
        Me.GCSubDept.Name = "GCSubDept"
        Me.GCSubDept.OptionsColumn.AllowEdit = False
        Me.GCSubDept.Visible = True
        Me.GCSubDept.VisibleIndex = 3
        '
        'GridColumnNIP
        '
        Me.GridColumnNIP.Caption = "NIP"
        Me.GridColumnNIP.FieldName = "employee_code"
        Me.GridColumnNIP.Name = "GridColumnNIP"
        Me.GridColumnNIP.OptionsColumn.AllowEdit = False
        Me.GridColumnNIP.Visible = True
        Me.GridColumnNIP.VisibleIndex = 1
        Me.GridColumnNIP.Width = 83
        '
        'GridColumnEmp
        '
        Me.GridColumnEmp.Caption = "Employee"
        Me.GridColumnEmp.FieldName = "employee_name"
        Me.GridColumnEmp.Name = "GridColumnEmp"
        Me.GridColumnEmp.OptionsColumn.AllowEdit = False
        Me.GridColumnEmp.Visible = True
        Me.GridColumnEmp.VisibleIndex = 2
        Me.GridColumnEmp.Width = 86
        '
        'GridColumnEmpPosition
        '
        Me.GridColumnEmpPosition.Caption = "Employee Position"
        Me.GridColumnEmpPosition.FieldName = "employee_position"
        Me.GridColumnEmpPosition.Name = "GridColumnEmpPosition"
        Me.GridColumnEmpPosition.OptionsColumn.AllowEdit = False
        Me.GridColumnEmpPosition.Visible = True
        Me.GridColumnEmpPosition.VisibleIndex = 3
        Me.GridColumnEmpPosition.Width = 86
        '
        'GridColumnEmpSts
        '
        Me.GridColumnEmpSts.Caption = "Employee Status"
        Me.GridColumnEmpSts.FieldName = "employee_status"
        Me.GridColumnEmpSts.Name = "GridColumnEmpSts"
        Me.GridColumnEmpSts.OptionsColumn.AllowEdit = False
        Me.GridColumnEmpSts.Visible = True
        Me.GridColumnEmpSts.VisibleIndex = 4
        Me.GridColumnEmpSts.Width = 86
        '
        'GridColumnDeductType
        '
        Me.GridColumnDeductType.Caption = "Type"
        Me.GridColumnDeductType.FieldName = "salary_deduction_cat"
        Me.GridColumnDeductType.Name = "GridColumnDeductType"
        Me.GridColumnDeductType.OptionsColumn.AllowEdit = False
        Me.GridColumnDeductType.Visible = True
        Me.GridColumnDeductType.VisibleIndex = 5
        '
        'GridColumnIdDeduct
        '
        Me.GridColumnIdDeduct.FieldName = "id_salary_deduction"
        Me.GridColumnIdDeduct.Name = "GridColumnIdDeduct"
        Me.GridColumnIdDeduct.OptionsColumn.AllowEdit = False
        '
        'GridColumnDeductCategory
        '
        Me.GridColumnDeductCategory.Caption = "Category"
        Me.GridColumnDeductCategory.FieldName = "salary_deduction"
        Me.GridColumnDeductCategory.Name = "GridColumnDeductCategory"
        Me.GridColumnDeductCategory.OptionsColumn.AllowEdit = False
        Me.GridColumnDeductCategory.Visible = True
        Me.GridColumnDeductCategory.VisibleIndex = 6
        Me.GridColumnDeductCategory.Width = 86
        '
        'GridColumnTotDays
        '
        Me.GridColumnTotDays.Caption = "Total Days"
        Me.GridColumnTotDays.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotDays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotDays.FieldName = "total_days"
        Me.GridColumnTotDays.Name = "GridColumnTotDays"
        Me.GridColumnTotDays.OptionsColumn.AllowEdit = False
        Me.GridColumnTotDays.Visible = True
        Me.GridColumnTotDays.VisibleIndex = 7
        '
        'GridColumnValue
        '
        Me.GridColumnValue.Caption = "Value"
        Me.GridColumnValue.DisplayFormat.FormatString = "N0"
        Me.GridColumnValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnValue.FieldName = "deduction"
        Me.GridColumnValue.Name = "GridColumnValue"
        Me.GridColumnValue.OptionsColumn.AllowEdit = False
        Me.GridColumnValue.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "deduction", "{0:N0}")})
        Me.GridColumnValue.Visible = True
        Me.GridColumnValue.VisibleIndex = 8
        Me.GridColumnValue.Width = 86
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.OptionsColumn.AllowEdit = False
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 9
        Me.GridColumnNote.Width = 101
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'FormEmpPayrollDeduction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1253, 541)
        Me.Controls.Add(Me.GCDeduction)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.BarDockControl3)
        Me.Controls.Add(Me.BarDockControl4)
        Me.Controls.Add(Me.BarDockControl2)
        Me.Controls.Add(Me.BarDockControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayrollDeduction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deduction"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCDeduction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDeduction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCDeduction As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDeduction As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdDeduction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmpPosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmpSts As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDeductCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BDel As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnNIP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PopupMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BBJamsostek As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBKoperasi As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BtnDropQuickMenu As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents GridColumnDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DropDownButton1 As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl4 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents GridColumnDeductType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotDays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SBPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCIsOfficePayroll As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCSubDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCheck As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnIdDeduct As DevExpress.XtraGrid.Columns.GridColumn
End Class
