<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCargoRate
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
        Me.GCCargoRate = New DevExpress.XtraGrid.GridControl()
        Me.GVCargoRate = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCCargoRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCargoRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCCargoRate
        '
        Me.GCCargoRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCargoRate.Location = New System.Drawing.Point(0, 0)
        Me.GCCargoRate.MainView = Me.GVCargoRate
        Me.GCCargoRate.Name = "GCCargoRate"
        Me.GCCargoRate.Size = New System.Drawing.Size(703, 310)
        Me.GCCargoRate.TabIndex = 1
        Me.GCCargoRate.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCargoRate})
        '
        'GVCargoRate
        '
        Me.GVCargoRate.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn10, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GVCargoRate.GridControl = Me.GCCargoRate
        Me.GVCargoRate.Name = "GVCargoRate"
        Me.GVCargoRate.OptionsBehavior.Editable = False
        Me.GVCargoRate.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_cargo_rate"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "ID Type"
        Me.GridColumn10.FieldName = "id_type"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Cargo Code"
        Me.GridColumn2.FieldName = "cargo_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Destination"
        Me.GridColumn3.FieldName = "destination"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Zone"
        Me.GridColumn4.FieldName = "zone"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'FormMasterCargoRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 310)
        Me.Controls.Add(Me.GCCargoRate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCargoRate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cargo Rate"
        CType(Me.GCCargoRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCargoRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCCargoRate As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCargoRate As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
End Class
