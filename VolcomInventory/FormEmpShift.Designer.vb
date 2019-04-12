<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpShift
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
        Me.GCShift = New DevExpress.XtraGrid.GridControl()
        Me.GVShift = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCShift, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVShift, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCShift
        '
        Me.GCShift.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCShift.Location = New System.Drawing.Point(0, 0)
        Me.GCShift.MainView = Me.GVShift
        Me.GCShift.Name = "GCShift"
        Me.GCShift.Size = New System.Drawing.Size(782, 306)
        Me.GCShift.TabIndex = 2
        Me.GCShift.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVShift})
        '
        'GVShift
        '
        Me.GVShift.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumn2, Me.GridColumn8, Me.GridColumn3, Me.GridColumn4, Me.GridColumn1, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVShift.GridControl = Me.GCShift
        Me.GVShift.Name = "GVShift"
        Me.GVShift.OptionsBehavior.ReadOnly = True
        Me.GVShift.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "ID Shift"
        Me.GridColumnId.FieldName = "id_schedule"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Shift Name"
        Me.GridColumn2.FieldName = "shift_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 204
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Start Working"
        Me.GridColumn3.FieldName = "start_work"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 213
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "End Working"
        Me.GridColumn4.FieldName = "end_work"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 213
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Start Break Time"
        Me.GridColumn1.FieldName = "start_break"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        Me.GridColumn1.Width = 213
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "End Break Time"
        Me.GridColumn5.FieldName = "end_break"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 5
        Me.GridColumn5.Width = 213
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Work Minute(s)"
        Me.GridColumn6.FieldName = "minutes_work"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 6
        Me.GridColumn6.Width = 213
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Workday"
        Me.GridColumn7.FieldName = "workday"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 7
        Me.GridColumn7.Width = 213
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Shift Code"
        Me.GridColumn8.FieldName = "shift_code"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        Me.GridColumn8.Width = 150
        '
        'FormEmpShift
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 306)
        Me.Controls.Add(Me.GCShift)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpShift"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Schedule"
        CType(Me.GCShift, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVShift, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCShift As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVShift As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
End Class
