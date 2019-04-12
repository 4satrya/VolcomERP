<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpUniPeriodSingle
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpUniPeriodSingle))
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AmbilSisaBudgetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdEmployee = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNik = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPosition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBudget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnIsDeptHead = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LEDeptSum = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnClose)
        Me.PanelControl2.Controls.Add(Me.BtnOK)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 312)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(663, 36)
        Me.PanelControl2.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(507, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(77, 32)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        '
        'BtnOK
        '
        Me.BtnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(584, 2)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(77, 32)
        Me.BtnOK.TabIndex = 0
        Me.BtnOK.Text = "Add"
        '
        'GCDetail
        '
        Me.GCDetail.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 37)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemCheckEdit1})
        Me.GCDetail.Size = New System.Drawing.Size(663, 275)
        Me.GCDetail.TabIndex = 2
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AmbilSisaBudgetToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(170, 48)
        '
        'AmbilSisaBudgetToolStripMenuItem
        '
        Me.AmbilSisaBudgetToolStripMenuItem.Name = "AmbilSisaBudgetToolStripMenuItem"
        Me.AmbilSisaBudgetToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.AmbilSisaBudgetToolStripMenuItem.Text = "Ambil sisa budget"
        Me.AmbilSisaBudgetToolStripMenuItem.Visible = False
        '
        'GVDetail
        '
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdEmployee, Me.GridColumnNik, Me.GridColumnName, Me.GridColumnDept, Me.GridColumnPosition, Me.GridColumnLevel, Me.GridColumnBudget, Me.GridColumnIsDeptHead})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.GroupCount = 1
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDetail.OptionsView.ShowGroupedColumns = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        Me.GVDetail.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDept, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnLevel, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdEmployee
        '
        Me.GridColumnIdEmployee.Caption = "Id Employee"
        Me.GridColumnIdEmployee.FieldName = "id_employee"
        Me.GridColumnIdEmployee.Name = "GridColumnIdEmployee"
        Me.GridColumnIdEmployee.OptionsColumn.AllowEdit = False
        '
        'GridColumnNik
        '
        Me.GridColumnNik.Caption = "NIK"
        Me.GridColumnNik.FieldName = "employee_code"
        Me.GridColumnNik.Name = "GridColumnNik"
        Me.GridColumnNik.OptionsColumn.AllowEdit = False
        Me.GridColumnNik.Visible = True
        Me.GridColumnNik.VisibleIndex = 0
        Me.GridColumnNik.Width = 172
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "employee_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 1
        Me.GridColumnName.Width = 472
        '
        'GridColumnDept
        '
        Me.GridColumnDept.Caption = "Departement"
        Me.GridColumnDept.FieldName = "departement"
        Me.GridColumnDept.Name = "GridColumnDept"
        Me.GridColumnDept.OptionsColumn.AllowEdit = False
        Me.GridColumnDept.Visible = True
        Me.GridColumnDept.VisibleIndex = 2
        Me.GridColumnDept.Width = 193
        '
        'GridColumnPosition
        '
        Me.GridColumnPosition.Caption = "Position"
        Me.GridColumnPosition.FieldName = "employee_position"
        Me.GridColumnPosition.Name = "GridColumnPosition"
        Me.GridColumnPosition.OptionsColumn.AllowEdit = False
        Me.GridColumnPosition.Visible = True
        Me.GridColumnPosition.VisibleIndex = 3
        Me.GridColumnPosition.Width = 165
        '
        'GridColumnLevel
        '
        Me.GridColumnLevel.Caption = "Level"
        Me.GridColumnLevel.FieldName = "employee_level"
        Me.GridColumnLevel.FieldNameSortGroup = "id_employee_level"
        Me.GridColumnLevel.Name = "GridColumnLevel"
        Me.GridColumnLevel.OptionsColumn.AllowEdit = False
        Me.GridColumnLevel.Visible = True
        Me.GridColumnLevel.VisibleIndex = 4
        Me.GridColumnLevel.Width = 192
        '
        'GridColumnBudget
        '
        Me.GridColumnBudget.Caption = "Budget"
        Me.GridColumnBudget.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnBudget.DisplayFormat.FormatString = "N2"
        Me.GridColumnBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBudget.FieldName = "budget"
        Me.GridColumnBudget.Name = "GridColumnBudget"
        Me.GridColumnBudget.Visible = True
        Me.GridColumnBudget.VisibleIndex = 5
        Me.GridColumnBudget.Width = 359
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatString = "N2"
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Mask.EditMask = "n2"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'GridColumnIsDeptHead
        '
        Me.GridColumnIsDeptHead.Caption = "Dept Head"
        Me.GridColumnIsDeptHead.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnIsDeptHead.FieldName = "dept_head"
        Me.GridColumnIsDeptHead.Name = "GridColumnIsDeptHead"
        Me.GridColumnIsDeptHead.Visible = True
        Me.GridColumnIsDeptHead.VisibleIndex = 6
        Me.GridColumnIsDeptHead.Width = 79
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.LEDeptSum)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(663, 37)
        Me.PanelControl1.TabIndex = 3
        '
        'LEDeptSum
        '
        Me.LEDeptSum.Location = New System.Drawing.Point(97, 9)
        Me.LEDeptSum.Name = "LEDeptSum"
        Me.LEDeptSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDeptSum.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "Id Departement", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departemen")})
        Me.LEDeptSum.Size = New System.Drawing.Size(175, 20)
        Me.LEDeptSum.TabIndex = 15
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(14, 12)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl6.TabIndex = 9
        Me.LabelControl6.Text = "Departement"
        '
        'FormEmpUniPeriodSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 348)
        Me.Controls.Add(Me.GCDetail)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpUniPeriodSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Budget"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdEmployee As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNik As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPosition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBudget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LEDeptSum As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AmbilSisaBudgetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumnIsDeptHead As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
