<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPayrollDeductionGen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayrollDeductionGen))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.GCGenDeduction = New DevExpress.XtraGrid.GridControl()
        Me.GVDeduction = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDeduction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmployeeNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDeduction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDeductionType = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCGenDeduction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDeduction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(909, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.ImageIndex = 19
        Me.SimpleButton1.ImageList = Me.LargeImageCollection
        Me.SimpleButton1.Location = New System.Drawing.Point(795, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(112, 42)
        Me.SimpleButton1.TabIndex = 22
        Me.SimpleButton1.Text = "Insert"
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
        'GCGenDeduction
        '
        Me.GCGenDeduction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCGenDeduction.Location = New System.Drawing.Point(0, 46)
        Me.GCGenDeduction.MainView = Me.GVDeduction
        Me.GCGenDeduction.Name = "GCGenDeduction"
        Me.GCGenDeduction.Size = New System.Drawing.Size(909, 352)
        Me.GCGenDeduction.TabIndex = 1
        Me.GCGenDeduction.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDeduction})
        '
        'GVDeduction
        '
        Me.GVDeduction.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdEmployee, Me.GridColumnIdDeduction, Me.GridColumnEmployeeNumber, Me.GridColumnEmployee, Me.GridColumnDeductionType, Me.GridColumnDeduction})
        Me.GVDeduction.GridControl = Me.GCGenDeduction
        Me.GVDeduction.Name = "GVDeduction"
        Me.GVDeduction.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdEmployee
        '
        Me.GridColumnIdEmployee.Caption = "ID Employee"
        Me.GridColumnIdEmployee.FieldName = "id_employee"
        Me.GridColumnIdEmployee.Name = "GridColumnIdEmployee"
        '
        'GridColumnIdDeduction
        '
        Me.GridColumnIdDeduction.Caption = "ID Deduction"
        Me.GridColumnIdDeduction.FieldName = "id_salary_deduction"
        Me.GridColumnIdDeduction.Name = "GridColumnIdDeduction"
        '
        'GridColumnEmployeeNumber
        '
        Me.GridColumnEmployeeNumber.Caption = "Employee Number"
        Me.GridColumnEmployeeNumber.FieldName = "employee_code"
        Me.GridColumnEmployeeNumber.Name = "GridColumnEmployeeNumber"
        Me.GridColumnEmployeeNumber.Visible = True
        Me.GridColumnEmployeeNumber.VisibleIndex = 0
        Me.GridColumnEmployeeNumber.Width = 133
        '
        'GridColumnEmployee
        '
        Me.GridColumnEmployee.Caption = "Employee"
        Me.GridColumnEmployee.FieldName = "employee_name"
        Me.GridColumnEmployee.Name = "GridColumnEmployee"
        Me.GridColumnEmployee.Visible = True
        Me.GridColumnEmployee.VisibleIndex = 1
        Me.GridColumnEmployee.Width = 186
        '
        'GridColumnDeduction
        '
        Me.GridColumnDeduction.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDeduction.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDeduction.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDeduction.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDeduction.Caption = "Deduction"
        Me.GridColumnDeduction.DisplayFormat.FormatString = "N0"
        Me.GridColumnDeduction.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDeduction.FieldName = "deduction"
        Me.GridColumnDeduction.Name = "GridColumnDeduction"
        Me.GridColumnDeduction.Visible = True
        Me.GridColumnDeduction.VisibleIndex = 3
        Me.GridColumnDeduction.Width = 237
        '
        'GridColumnDeductionType
        '
        Me.GridColumnDeductionType.Caption = "Deduction Type"
        Me.GridColumnDeductionType.FieldName = "salary_deduction"
        Me.GridColumnDeductionType.Name = "GridColumnDeductionType"
        Me.GridColumnDeductionType.Visible = True
        Me.GridColumnDeductionType.VisibleIndex = 2
        Me.GridColumnDeductionType.Width = 100
        '
        'FormEmpPayrollDeductionGen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 398)
        Me.Controls.Add(Me.GCGenDeduction)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayrollDeductionGen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generate Payroll Deduction"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCGenDeduction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDeduction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GCGenDeduction As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDeduction As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDeduction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmployeeNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDeduction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDeductionType As DevExpress.XtraGrid.Columns.GridColumn
End Class
