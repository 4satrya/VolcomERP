<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmloyeePps
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmloyeePps))
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BNew = New DevExpress.XtraEditors.SimpleButton()
        Me.SLUEEmployee = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEditEmp = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn94 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn97 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn95 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn98 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn96 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LEDeptSum = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BViewSum = New DevExpress.XtraEditors.SimpleButton()
        Me.GCEmployeePps = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployeePps = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIDType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIDEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCProposedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCProposedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIsHrd = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEEmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEditEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCEmployeePps, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployeePps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BEdit)
        Me.PanelControl2.Controls.Add(Me.BNew)
        Me.PanelControl2.Controls.Add(Me.SLUEEmployee)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.LEDeptSum)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.BViewSum)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(876, 38)
        Me.PanelControl2.TabIndex = 4
        '
        'BEdit
        '
        Me.BEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEdit.ImageIndex = 14
        Me.BEdit.ImageList = Me.LargeImageCollection
        Me.BEdit.Location = New System.Drawing.Point(605, 2)
        Me.BEdit.Name = "BEdit"
        Me.BEdit.Size = New System.Drawing.Size(156, 34)
        Me.BEdit.TabIndex = 21
        Me.BEdit.Text = "Change Data Employee"
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
        'BNew
        '
        Me.BNew.Dock = System.Windows.Forms.DockStyle.Right
        Me.BNew.ImageIndex = 0
        Me.BNew.ImageList = Me.LargeImageCollection
        Me.BNew.Location = New System.Drawing.Point(761, 2)
        Me.BNew.Name = "BNew"
        Me.BNew.Size = New System.Drawing.Size(113, 34)
        Me.BNew.TabIndex = 20
        Me.BNew.Text = "New Employee"
        '
        'SLUEEmployee
        '
        Me.SLUEEmployee.Location = New System.Drawing.Point(266, 9)
        Me.SLUEEmployee.Name = "SLUEEmployee"
        Me.SLUEEmployee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEEmployee.Properties.ShowClearButton = False
        Me.SLUEEmployee.Properties.View = Me.SearchLookUpEditEmp
        Me.SLUEEmployee.Size = New System.Drawing.Size(209, 20)
        Me.SLUEEmployee.TabIndex = 19
        '
        'SearchLookUpEditEmp
        '
        Me.SearchLookUpEditEmp.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn94, Me.GridColumn97, Me.GridColumn95, Me.GridColumn98, Me.GridColumn96})
        Me.SearchLookUpEditEmp.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEditEmp.Name = "SearchLookUpEditEmp"
        Me.SearchLookUpEditEmp.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEditEmp.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.SearchLookUpEditEmp.OptionsView.ShowGroupPanel = False
        '
        'GridColumn94
        '
        Me.GridColumn94.FieldName = "id_employee"
        Me.GridColumn94.Name = "GridColumn94"
        '
        'GridColumn97
        '
        Me.GridColumn97.Caption = "Code"
        Me.GridColumn97.FieldName = "employee_code"
        Me.GridColumn97.Name = "GridColumn97"
        Me.GridColumn97.Visible = True
        Me.GridColumn97.VisibleIndex = 0
        '
        'GridColumn95
        '
        Me.GridColumn95.Caption = "Employee"
        Me.GridColumn95.FieldName = "employee_name"
        Me.GridColumn95.Name = "GridColumn95"
        Me.GridColumn95.Visible = True
        Me.GridColumn95.VisibleIndex = 1
        '
        'GridColumn98
        '
        Me.GridColumn98.FieldName = "id_departement"
        Me.GridColumn98.Name = "GridColumn98"
        '
        'GridColumn96
        '
        Me.GridColumn96.FieldName = "id_employee_active"
        Me.GridColumn96.Name = "GridColumn96"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(217, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl3.TabIndex = 18
        Me.LabelControl3.Text = "Employee"
        '
        'LEDeptSum
        '
        Me.LEDeptSum.Location = New System.Drawing.Point(81, 9)
        Me.LEDeptSum.Name = "LEDeptSum"
        Me.LEDeptSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDeptSum.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "Id Departement", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departemen")})
        Me.LEDeptSum.Size = New System.Drawing.Size(130, 20)
        Me.LEDeptSum.TabIndex = 14
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl1.TabIndex = 13
        Me.LabelControl1.Text = "Departement"
        '
        'BViewSum
        '
        Me.BViewSum.Location = New System.Drawing.Point(481, 6)
        Me.BViewSum.Name = "BViewSum"
        Me.BViewSum.Size = New System.Drawing.Size(59, 25)
        Me.BViewSum.TabIndex = 1
        Me.BViewSum.Text = "View"
        '
        'GCEmployeePps
        '
        Me.GCEmployeePps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCEmployeePps.Location = New System.Drawing.Point(0, 38)
        Me.GCEmployeePps.MainView = Me.GVEmployeePps
        Me.GCEmployeePps.Name = "GCEmployeePps"
        Me.GCEmployeePps.Size = New System.Drawing.Size(876, 525)
        Me.GCEmployeePps.TabIndex = 5
        Me.GCEmployeePps.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployeePps})
        '
        'GVEmployeePps
        '
        Me.GVEmployeePps.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCID, Me.GCIDType, Me.GCIsHrd, Me.GCIDEmployee, Me.GCType, Me.GCNumber, Me.GCCode, Me.GCName, Me.GCNote, Me.GCProposedBy, Me.GCProposedDate, Me.GCStatus})
        Me.GVEmployeePps.GridControl = Me.GCEmployeePps
        Me.GVEmployeePps.Name = "GVEmployeePps"
        Me.GVEmployeePps.OptionsBehavior.Editable = False
        Me.GVEmployeePps.OptionsView.ShowGroupPanel = False
        '
        'GCID
        '
        Me.GCID.FieldName = "id_employee_pps"
        Me.GCID.Name = "GCID"
        '
        'GCIDType
        '
        Me.GCIDType.FieldName = "id_type"
        Me.GCIDType.Name = "GCIDType"
        '
        'GCIDEmployee
        '
        Me.GCIDEmployee.FieldName = "id_employee"
        Me.GCIDEmployee.Name = "GCIDEmployee"
        '
        'GCType
        '
        Me.GCType.Caption = "Type"
        Me.GCType.FieldName = "pps_type"
        Me.GCType.Name = "GCType"
        Me.GCType.Visible = True
        Me.GCType.VisibleIndex = 1
        Me.GCType.Width = 152
        '
        'GCNumber
        '
        Me.GCNumber.Caption = "Number"
        Me.GCNumber.FieldName = "number"
        Me.GCNumber.Name = "GCNumber"
        Me.GCNumber.Visible = True
        Me.GCNumber.VisibleIndex = 0
        Me.GCNumber.Width = 219
        '
        'GCCode
        '
        Me.GCCode.Caption = "Code"
        Me.GCCode.FieldName = "employee_code"
        Me.GCCode.Name = "GCCode"
        Me.GCCode.Visible = True
        Me.GCCode.VisibleIndex = 2
        Me.GCCode.Width = 85
        '
        'GCName
        '
        Me.GCName.Caption = "Name"
        Me.GCName.FieldName = "employee_name"
        Me.GCName.Name = "GCName"
        Me.GCName.Visible = True
        Me.GCName.VisibleIndex = 3
        Me.GCName.Width = 290
        '
        'GCNote
        '
        Me.GCNote.Caption = "Note"
        Me.GCNote.FieldName = "note"
        Me.GCNote.MaxWidth = 450
        Me.GCNote.Name = "GCNote"
        Me.GCNote.Visible = True
        Me.GCNote.VisibleIndex = 4
        Me.GCNote.Width = 326
        '
        'GCProposedBy
        '
        Me.GCProposedBy.Caption = "Proposed By"
        Me.GCProposedBy.FieldName = "created_by"
        Me.GCProposedBy.Name = "GCProposedBy"
        Me.GCProposedBy.Visible = True
        Me.GCProposedBy.VisibleIndex = 5
        Me.GCProposedBy.Width = 202
        '
        'GCProposedDate
        '
        Me.GCProposedDate.Caption = "Proposed Date"
        Me.GCProposedDate.FieldName = "created_date"
        Me.GCProposedDate.Name = "GCProposedDate"
        Me.GCProposedDate.Visible = True
        Me.GCProposedDate.VisibleIndex = 6
        Me.GCProposedDate.Width = 171
        '
        'GCStatus
        '
        Me.GCStatus.AppearanceCell.Options.UseTextOptions = True
        Me.GCStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.GCStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCStatus.Caption = "Status"
        Me.GCStatus.FieldName = "report_status"
        Me.GCStatus.Name = "GCStatus"
        Me.GCStatus.Visible = True
        Me.GCStatus.VisibleIndex = 7
        Me.GCStatus.Width = 187
        '
        'GCIsHrd
        '
        Me.GCIsHrd.FieldName = "is_hrd"
        Me.GCIsHrd.Name = "GCIsHrd"
        '
        'FormEmloyeePps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 563)
        Me.Controls.Add(Me.GCEmployeePps)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmloyeePps"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Proposal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEEmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEditEmp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCEmployeePps, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployeePps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLUEEmployee As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEditEmp As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn94 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn97 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn95 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn98 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn96 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEDeptSum As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BViewSum As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCEmployeePps As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVEmployeePps As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BNew As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GCType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIDType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIDEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCProposedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCProposedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIsHrd As DevExpress.XtraGrid.Columns.GridColumn
End Class
