<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpDP
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
        Me.GCLeave = New DevExpress.XtraGrid.GridControl()
        Me.GVLeave = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIDLeave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotHours = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BViewSum = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.GCLeave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVLeave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCLeave
        '
        Me.GCLeave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCLeave.Location = New System.Drawing.Point(0, 38)
        Me.GCLeave.MainView = Me.GVLeave
        Me.GCLeave.Name = "GCLeave"
        Me.GCLeave.Size = New System.Drawing.Size(692, 229)
        Me.GCLeave.TabIndex = 3
        Me.GCLeave.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVLeave})
        '
        'GVLeave
        '
        Me.GVLeave.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIDLeave, Me.GridColumn2, Me.GridColumn7, Me.GridColumn3, Me.GridColumn4, Me.GridColumn1, Me.GridColumn5, Me.GridColumnTotHours, Me.GridColumn6, Me.GridColumn8})
        Me.GVLeave.GridControl = Me.GCLeave
        Me.GVLeave.Name = "GVLeave"
        Me.GVLeave.OptionsBehavior.Editable = False
        Me.GVLeave.OptionsFind.AlwaysVisible = True
        Me.GVLeave.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIDLeave
        '
        Me.GridColumnIDLeave.Caption = "ID DP"
        Me.GridColumnIDLeave.FieldName = "id_emp_dp"
        Me.GridColumnIDLeave.Name = "GridColumnIDLeave"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.FieldName = "dp_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 90
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Date Created"
        Me.GridColumn7.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn7.FieldName = "dp_date_created"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 96
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Employee"
        Me.GridColumn3.FieldName = "employee_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 160
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "NIK"
        Me.GridColumn4.FieldName = "employee_code"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 88
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "DP From"
        Me.GridColumn1.DisplayFormat.FormatString = "dd MMM yyyy H:mm:ss"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn1.FieldName = "dp_time_start"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        Me.GridColumn1.Width = 77
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Until"
        Me.GridColumn5.DisplayFormat.FormatString = "dd MMM yyyy H:mm:ss"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn5.FieldName = "dp_time_end"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 5
        Me.GridColumn5.Width = 66
        '
        'GridColumnTotHours
        '
        Me.GridColumnTotHours.Caption = "Total (hours)"
        Me.GridColumnTotHours.FieldName = "dp_total"
        Me.GridColumnTotHours.Name = "GridColumnTotHours"
        Me.GridColumnTotHours.Visible = True
        Me.GridColumnTotHours.VisibleIndex = 6
        Me.GridColumnTotHours.Width = 73
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Status"
        Me.GridColumn6.FieldName = "report_status"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 7
        Me.GridColumn6.Width = 60
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ID Report Status"
        Me.GridColumn8.FieldName = "id_report_status"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BViewSum)
        Me.PanelControl1.Controls.Add(Me.DEUntil)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.DEStart)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(692, 38)
        Me.PanelControl1.TabIndex = 4
        '
        'BViewSum
        '
        Me.BViewSum.Location = New System.Drawing.Point(388, 6)
        Me.BViewSum.Name = "BViewSum"
        Me.BViewSum.Size = New System.Drawing.Size(69, 25)
        Me.BViewSum.TabIndex = 12
        Me.BViewSum.Text = "view"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(246, 9)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Size = New System.Drawing.Size(127, 20)
        Me.DEUntil.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(202, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Until : "
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(57, 9)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Size = New System.Drawing.Size(127, 20)
        Me.DEStart.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "From : "
        '
        'FormEmpDP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 267)
        Me.Controls.Add(Me.GCLeave)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormEmpDP"
        Me.Text = "Day Payment"
        CType(Me.GCLeave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVLeave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCLeave As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVLeave As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIDLeave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotHours As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BViewSum As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
End Class
