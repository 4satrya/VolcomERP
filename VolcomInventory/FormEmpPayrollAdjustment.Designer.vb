<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayrollAdjustment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollAdjustment))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BDel = New DevExpress.XtraEditors.SimpleButton()
        Me.BEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCDeduction = New DevExpress.XtraGrid.GridControl()
        Me.GVDeduction = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdDeduction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNIP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmpPosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmpLvl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotDays = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIncrease = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCDeduction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDeduction, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BDel)
        Me.PanelControl1.Controls.Add(Me.BEdit)
        Me.PanelControl1.Controls.Add(Me.BAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1052, 38)
        Me.PanelControl1.TabIndex = 1
        '
        'BDel
        '
        Me.BDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDel.ImageIndex = 1
        Me.BDel.ImageList = Me.LargeImageCollection
        Me.BDel.Location = New System.Drawing.Point(807, 2)
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
        Me.BEdit.Location = New System.Drawing.Point(888, 2)
        Me.BEdit.Name = "BEdit"
        Me.BEdit.Size = New System.Drawing.Size(81, 34)
        Me.BEdit.TabIndex = 1
        Me.BEdit.Text = "Edit"
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.ImageIndex = 0
        Me.BAdd.ImageList = Me.LargeImageCollection
        Me.BAdd.Location = New System.Drawing.Point(969, 2)
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
        Me.GCDeduction.Size = New System.Drawing.Size(1052, 441)
        Me.GCDeduction.TabIndex = 2
        Me.GCDeduction.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDeduction})
        '
        'GVDeduction
        '
        Me.GVDeduction.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdDeduction, Me.GridColumnIdEmployee, Me.GridColumnDept, Me.GridColumnNIP, Me.GridColumnEmp, Me.GridColumnEmpPosition, Me.GridColumnEmpLvl, Me.GridColumnType, Me.GridColumnTotDays, Me.GridColumnValue, Me.GridColumnIncrease, Me.GridColumnNote})
        Me.GVDeduction.GridControl = Me.GCDeduction
        Me.GVDeduction.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value", Me.GridColumnValue, "{0:N0}")})
        Me.GVDeduction.Name = "GVDeduction"
        Me.GVDeduction.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVDeduction.OptionsView.ShowFooter = True
        Me.GVDeduction.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdDeduction
        '
        Me.GridColumnIdDeduction.Caption = "ID Adjustment"
        Me.GridColumnIdDeduction.FieldName = "id_payroll_adjustment"
        Me.GridColumnIdDeduction.Name = "GridColumnIdDeduction"
        '
        'GridColumnIdEmployee
        '
        Me.GridColumnIdEmployee.Caption = "ID Employee"
        Me.GridColumnIdEmployee.FieldName = "id_employee"
        Me.GridColumnIdEmployee.Name = "GridColumnIdEmployee"
        '
        'GridColumnDept
        '
        Me.GridColumnDept.Caption = "Departement"
        Me.GridColumnDept.FieldName = "departement"
        Me.GridColumnDept.Name = "GridColumnDept"
        Me.GridColumnDept.Visible = True
        Me.GridColumnDept.VisibleIndex = 0
        '
        'GridColumnNIP
        '
        Me.GridColumnNIP.Caption = "NIP"
        Me.GridColumnNIP.FieldName = "employee_code"
        Me.GridColumnNIP.Name = "GridColumnNIP"
        Me.GridColumnNIP.Visible = True
        Me.GridColumnNIP.VisibleIndex = 1
        Me.GridColumnNIP.Width = 50
        '
        'GridColumnEmp
        '
        Me.GridColumnEmp.Caption = "Employee"
        Me.GridColumnEmp.FieldName = "employee_name"
        Me.GridColumnEmp.Name = "GridColumnEmp"
        Me.GridColumnEmp.Visible = True
        Me.GridColumnEmp.VisibleIndex = 2
        Me.GridColumnEmp.Width = 86
        '
        'GridColumnEmpPosition
        '
        Me.GridColumnEmpPosition.Caption = "Employee Position"
        Me.GridColumnEmpPosition.FieldName = "employee_position"
        Me.GridColumnEmpPosition.Name = "GridColumnEmpPosition"
        Me.GridColumnEmpPosition.Visible = True
        Me.GridColumnEmpPosition.VisibleIndex = 3
        Me.GridColumnEmpPosition.Width = 86
        '
        'GridColumnEmpLvl
        '
        Me.GridColumnEmpLvl.Caption = "Employee level"
        Me.GridColumnEmpLvl.FieldName = "employee_level"
        Me.GridColumnEmpLvl.Name = "GridColumnEmpLvl"
        Me.GridColumnEmpLvl.Visible = True
        Me.GridColumnEmpLvl.VisibleIndex = 4
        Me.GridColumnEmpLvl.Width = 86
        '
        'GridColumnType
        '
        Me.GridColumnType.Caption = "Type"
        Me.GridColumnType.FieldName = "description"
        Me.GridColumnType.Name = "GridColumnType"
        Me.GridColumnType.Visible = True
        Me.GridColumnType.VisibleIndex = 5
        Me.GridColumnType.Width = 86
        '
        'GridColumnTotDays
        '
        Me.GridColumnTotDays.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotDays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotDays.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotDays.Caption = "Total Days"
        Me.GridColumnTotDays.DisplayFormat.FormatString = "N1"
        Me.GridColumnTotDays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotDays.FieldName = "total_days"
        Me.GridColumnTotDays.Name = "GridColumnTotDays"
        Me.GridColumnTotDays.Visible = True
        Me.GridColumnTotDays.VisibleIndex = 6
        '
        'GridColumnValue
        '
        Me.GridColumnValue.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnValue.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnValue.Caption = "Value"
        Me.GridColumnValue.DisplayFormat.FormatString = "N0"
        Me.GridColumnValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnValue.FieldName = "value"
        Me.GridColumnValue.Name = "GridColumnValue"
        Me.GridColumnValue.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value", "{0:N0}")})
        Me.GridColumnValue.Visible = True
        Me.GridColumnValue.VisibleIndex = 7
        Me.GridColumnValue.Width = 86
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 8
        Me.GridColumnNote.Width = 101
        '
        'GridColumnIncrease
        '
        Me.GridColumnIncrease.Caption = "Increase"
        Me.GridColumnIncrease.DisplayFormat.FormatString = "N0"
        Me.GridColumnIncrease.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnIncrease.FieldName = "increase"
        Me.GridColumnIncrease.Name = "GridColumnIncrease"
        '
        'FormEmpPayrollAdjustment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 479)
        Me.Controls.Add(Me.GCDeduction)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayrollAdjustment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bonus And Adjustment"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCDeduction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDeduction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BDel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCDeduction As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDeduction As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdDeduction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNIP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmpPosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmpLvl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotDays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIncrease As DevExpress.XtraGrid.Columns.GridColumn
End Class
