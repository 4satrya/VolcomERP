<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMappingStore
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
        Me.GCMappingStore = New DevExpress.XtraGrid.GridControl()
        Me.GVMappingStore = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCMappingStore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMappingStore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCMappingStore
        '
        Me.GCMappingStore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMappingStore.Location = New System.Drawing.Point(0, 0)
        Me.GCMappingStore.MainView = Me.GVMappingStore
        Me.GCMappingStore.Name = "GCMappingStore"
        Me.GCMappingStore.Size = New System.Drawing.Size(1008, 729)
        Me.GCMappingStore.TabIndex = 0
        Me.GCMappingStore.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMappingStore})
        '
        'GVMappingStore
        '
        Me.GVMappingStore.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn4, Me.GridColumn3, Me.GridColumn5})
        Me.GVMappingStore.GridControl = Me.GCMappingStore
        Me.GVMappingStore.GroupCount = 1
        Me.GVMappingStore.Name = "GVMappingStore"
        Me.GVMappingStore.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVMappingStore.OptionsBehavior.Editable = False
        Me.GVMappingStore.OptionsFind.AlwaysVisible = True
        Me.GVMappingStore.OptionsView.ShowGroupedColumns = True
        Me.GVMappingStore.OptionsView.ShowGroupPanel = False
        Me.GVMappingStore.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_comp"
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
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Company"
        Me.GridColumn3.FieldName = "comp_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Number"
        Me.GridColumn4.FieldName = "comp_number"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Address"
        Me.GridColumn5.FieldName = "address_primary"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'FormMappingStore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.GCMappingStore)
        Me.Name = "FormMappingStore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mapping Store"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GCMappingStore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMappingStore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCMappingStore As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMappingStore As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
End Class
