<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBankWithdrawalCompen
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
        Me.BPick = New DevExpress.XtraEditors.SimpleButton()
        Me.GCPending = New DevExpress.XtraGrid.GridControl()
        Me.GVPending = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPending, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BPick
        '
        Me.BPick.Appearance.BackColor = System.Drawing.Color.Blue
        Me.BPick.Appearance.ForeColor = System.Drawing.Color.White
        Me.BPick.Appearance.Options.UseBackColor = True
        Me.BPick.Appearance.Options.UseForeColor = True
        Me.BPick.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.BPick.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BPick.Location = New System.Drawing.Point(0, 472)
        Me.BPick.Name = "BPick"
        Me.BPick.Size = New System.Drawing.Size(886, 37)
        Me.BPick.TabIndex = 0
        Me.BPick.Text = "Pick"
        '
        'GCPending
        '
        Me.GCPending.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPending.Location = New System.Drawing.Point(0, 0)
        Me.GCPending.MainView = Me.GVPending
        Me.GCPending.Name = "GCPending"
        Me.GCPending.Size = New System.Drawing.Size(886, 472)
        Me.GCPending.TabIndex = 1
        Me.GCPending.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPending})
        '
        'GVPending
        '
        Me.GVPending.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn5})
        Me.GVPending.GridControl = Me.GCPending
        Me.GVPending.Name = "GVPending"
        Me.GVPending.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "id_sales_pos"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Number"
        Me.GridColumn2.FieldName = "sales_pos_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 312
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Amount"
        Me.GridColumn5.DisplayFormat.FormatString = "N2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "amount"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 556
        '
        'FormBankWithdrawalCompen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 509)
        Me.Controls.Add(Me.GCPending)
        Me.Controls.Add(Me.BPick)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBankWithdrawalCompen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pending Invoice"
        CType(Me.GCPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPending, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BPick As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCPending As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPending As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
End Class
