<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterStore
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
        Me.GCMasterStore = New DevExpress.XtraGrid.GridControl()
        Me.GVMasterStore = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCMasterStore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMasterStore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCMasterStore
        '
        Me.GCMasterStore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMasterStore.Location = New System.Drawing.Point(0, 0)
        Me.GCMasterStore.MainView = Me.GVMasterStore
        Me.GCMasterStore.Name = "GCMasterStore"
        Me.GCMasterStore.Size = New System.Drawing.Size(784, 561)
        Me.GCMasterStore.TabIndex = 1
        Me.GCMasterStore.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMasterStore})
        '
        'GVMasterStore
        '
        Me.GVMasterStore.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GVMasterStore.GridControl = Me.GCMasterStore
        Me.GVMasterStore.Name = "GVMasterStore"
        Me.GVMasterStore.OptionsBehavior.Editable = False
        Me.GVMasterStore.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_store"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Store"
        Me.GridColumn2.FieldName = "store_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'FormMasterStore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCMasterStore)
        Me.Name = "FormMasterStore"
        Me.Text = "Master Store"
        CType(Me.GCMasterStore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMasterStore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCMasterStore As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMasterStore As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
