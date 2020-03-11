<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpPerAppraisalPick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPerAppraisalPick))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.TextEditPropose = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DEPeriodDateTo = New DevExpress.XtraEditors.DateEdit()
        Me.DEPeriodDateFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SBAdd = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.TextEditPropose.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPeriodDateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPeriodDateTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPeriodDateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEPeriodDateFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.GCList)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 43)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(784, 476)
        Me.GroupControl1.TabIndex = 8
        Me.GroupControl1.Text = "Employee"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(20, 2)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(762, 472)
        Me.GCList.TabIndex = 2
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn9, Me.GridColumn17, Me.GridColumn4, Me.GridColumn2, Me.GridColumn3, Me.GridColumn5, Me.GridColumn10, Me.GridColumn6, Me.GridColumn12, Me.GridColumn11, Me.GridColumn8, Me.GridColumn13})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.GroupCount = 1
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.ColumnAutoWidth = False
        Me.GVList.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVList.OptionsView.ShowGroupPanel = False
        Me.GVList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_employee"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "GridColumn9"
        Me.GridColumn9.FieldName = "id_departement"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "GridColumn17"
        Me.GridColumn17.FieldName = "id_departement_sub"
        Me.GridColumn17.Name = "GridColumn17"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Departement"
        Me.GridColumn4.FieldName = "departement"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        Me.GridColumn4.Width = 86
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "NIP"
        Me.GridColumn2.FieldName = "employee_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 41
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Employee"
        Me.GridColumn3.FieldName = "employee_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 56
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Employee Position"
        Me.GridColumn5.FieldName = "employee_position"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 96
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "GridColumn10"
        Me.GridColumn10.FieldName = "id_employee_status"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Employee Status"
        Me.GridColumn6.FieldName = "employee_status"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        Me.GridColumn6.Width = 90
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "GridColumn12"
        Me.GridColumn12.FieldName = "id_employee_active"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Active Status"
        Me.GridColumn11.FieldName = "employee_active"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 4
        Me.GridColumn11.Width = 74
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "GridColumn8"
        Me.GridColumn8.FieldName = "to_salary"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "GridColumn13"
        Me.GridColumn13.FieldName = "is_day_off"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.TextEditPropose)
        Me.GroupControl2.Controls.Add(Me.LabelControl1)
        Me.GroupControl2.Controls.Add(Me.DEPeriodDateTo)
        Me.GroupControl2.Controls.Add(Me.DEPeriodDateFrom)
        Me.GroupControl2.Controls.Add(Me.LabelControl2)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(784, 43)
        Me.GroupControl2.TabIndex = 7
        Me.GroupControl2.Text = "Date"
        '
        'TextEditPropose
        '
        Me.TextEditPropose.Location = New System.Drawing.Point(627, 12)
        Me.TextEditPropose.Name = "TextEditPropose"
        Me.TextEditPropose.Size = New System.Drawing.Size(145, 20)
        Me.TextEditPropose.TabIndex = 28
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(538, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(78, 13)
        Me.LabelControl1.TabIndex = 27
        Me.LabelControl1.Text = "Tujuan Penilaian"
        '
        'DEPeriodDateTo
        '
        Me.DEPeriodDateTo.EditValue = Nothing
        Me.DEPeriodDateTo.Location = New System.Drawing.Point(302, 12)
        Me.DEPeriodDateTo.Name = "DEPeriodDateTo"
        Me.DEPeriodDateTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEPeriodDateTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEPeriodDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEPeriodDateTo.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEPeriodDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEPeriodDateTo.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEPeriodDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEPeriodDateTo.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEPeriodDateTo.Size = New System.Drawing.Size(215, 20)
        Me.DEPeriodDateTo.TabIndex = 26
        '
        'DEPeriodDateFrom
        '
        Me.DEPeriodDateFrom.EditValue = Nothing
        Me.DEPeriodDateFrom.Location = New System.Drawing.Point(81, 12)
        Me.DEPeriodDateFrom.Name = "DEPeriodDateFrom"
        Me.DEPeriodDateFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEPeriodDateFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEPeriodDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEPeriodDateFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEPeriodDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEPeriodDateFrom.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEPeriodDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEPeriodDateFrom.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEPeriodDateFrom.Size = New System.Drawing.Size(215, 20)
        Me.DEPeriodDateFrom.TabIndex = 7
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(35, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Period"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SBClose)
        Me.PanelControl1.Controls.Add(Me.SBAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 519)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 42)
        Me.PanelControl1.TabIndex = 6
        '
        'SBClose
        '
        Me.SBClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(612, 6)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(78, 29)
        Me.SBClose.TabIndex = 1
        Me.SBClose.Text = "Close"
        '
        'SBAdd
        '
        Me.SBAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBAdd.Image = CType(resources.GetObject("SBAdd.Image"), System.Drawing.Image)
        Me.SBAdd.Location = New System.Drawing.Point(694, 6)
        Me.SBAdd.Name = "SBAdd"
        Me.SBAdd.Size = New System.Drawing.Size(78, 29)
        Me.SBAdd.TabIndex = 0
        Me.SBAdd.Text = "Pick"
        '
        'FormEmpPerAppraisalPick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormEmpPerAppraisalPick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Penilaian Kinerja Karyawan Pick"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.TextEditPropose.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPeriodDateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPeriodDateTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPeriodDateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEPeriodDateFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DEPeriodDateTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEPeriodDateFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SBAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEditPropose As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
