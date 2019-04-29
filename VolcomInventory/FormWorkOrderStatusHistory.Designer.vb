<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWorkOrderStatusHistory
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
        Me.GCHistory = New DevExpress.XtraGrid.GridControl()
        Me.GVHistory = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GCHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCHistory
        '
        Me.GCHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCHistory.Location = New System.Drawing.Point(0, 0)
        Me.GCHistory.MainView = Me.GVHistory
        Me.GCHistory.Name = "GCHistory"
        Me.GCHistory.Size = New System.Drawing.Size(711, 504)
        Me.GCHistory.TabIndex = 0
        Me.GCHistory.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVHistory})
        '
        'GVHistory
        '
        Me.GVHistory.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn5, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GVHistory.GridControl = Me.GCHistory
        Me.GVHistory.Name = "GVHistory"
        Me.GVHistory.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_work_order_status_history"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Work Status"
        Me.GridColumn5.FieldName = "work_order_status"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        Me.GridColumn5.Width = 161
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "By"
        Me.GridColumn2.FieldName = "employee_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 119
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Date"
        Me.GridColumn3.FieldName = "created_date"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 130
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Note"
        Me.GridColumn4.FieldName = "note"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 1222
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BPrint.Location = New System.Drawing.Point(0, 504)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(711, 30)
        Me.BPrint.TabIndex = 1
        Me.BPrint.Text = "Print"
        '
        'FormWorkOrderStatusHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 534)
        Me.Controls.Add(Me.GCHistory)
        Me.Controls.Add(Me.BPrint)
        Me.MinimizeBox = False
        Me.Name = "FormWorkOrderStatusHistory"
        Me.Text = "Work History"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GCHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCHistory As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVHistory As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
End Class
