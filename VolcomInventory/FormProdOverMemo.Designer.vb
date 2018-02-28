<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdOverMemo
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
        Me.GCMemo = New DevExpress.XtraGrid.GridControl()
        Me.GVMemo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatyus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCretedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnExpiredDate = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCMemo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMemo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCMemo
        '
        Me.GCMemo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMemo.Location = New System.Drawing.Point(0, 0)
        Me.GCMemo.MainView = Me.GVMemo
        Me.GCMemo.Name = "GCMemo"
        Me.GCMemo.Size = New System.Drawing.Size(745, 525)
        Me.GCMemo.TabIndex = 0
        Me.GCMemo.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMemo})
        '
        'GVMemo
        '
        Me.GVMemo.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnNumber, Me.GridColumnStatyus, Me.GridColumnCretedDate, Me.GridColumnExpiredDate})
        Me.GVMemo.GridControl = Me.GCMemo
        Me.GVMemo.Name = "GVMemo"
        Me.GVMemo.OptionsBehavior.Editable = False
        Me.GVMemo.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_prod_over_memo"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Memo Number"
        Me.GridColumnNumber.FieldName = "memo_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 0
        '
        'GridColumnStatyus
        '
        Me.GridColumnStatyus.Caption = "Status"
        Me.GridColumnStatyus.FieldName = "report_status"
        Me.GridColumnStatyus.Name = "GridColumnStatyus"
        Me.GridColumnStatyus.Visible = True
        Me.GridColumnStatyus.VisibleIndex = 3
        '
        'GridColumnCretedDate
        '
        Me.GridColumnCretedDate.Caption = "Created Date"
        Me.GridColumnCretedDate.DisplayFormat.FormatString = "dd MMMM yyyy hh:mm tt"
        Me.GridColumnCretedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCretedDate.FieldName = "created_date"
        Me.GridColumnCretedDate.Name = "GridColumnCretedDate"
        Me.GridColumnCretedDate.Visible = True
        Me.GridColumnCretedDate.VisibleIndex = 1
        '
        'GridColumnExpiredDate
        '
        Me.GridColumnExpiredDate.Caption = "Expired Date"
        Me.GridColumnExpiredDate.DisplayFormat.FormatString = "dd MMMM yyyy hh:mm tt"
        Me.GridColumnExpiredDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnExpiredDate.FieldName = "expired_date"
        Me.GridColumnExpiredDate.Name = "GridColumnExpiredDate"
        Me.GridColumnExpiredDate.Visible = True
        Me.GridColumnExpiredDate.VisibleIndex = 2
        '
        'FormProdOverMemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 525)
        Me.Controls.Add(Me.GCMemo)
        Me.Name = "FormProdOverMemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Over Production Memo"
        CType(Me.GCMemo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMemo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCMemo As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMemo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatyus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCretedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnExpiredDate As DevExpress.XtraGrid.Columns.GridColumn
End Class
