<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCompanyDouble
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
        Me.GCComp = New DevExpress.XtraGrid.GridControl()
        Me.GVComp = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDRawer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVComp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCComp
        '
        Me.GCComp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCComp.Location = New System.Drawing.Point(0, 0)
        Me.GCComp.MainView = Me.GVComp
        Me.GCComp.Name = "GCComp"
        Me.GCComp.Size = New System.Drawing.Size(705, 343)
        Me.GCComp.TabIndex = 0
        Me.GCComp.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVComp})
        '
        'GVComp
        '
        Me.GVComp.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumnIdDRawer, Me.GridColumn2, Me.GridColumn3})
        Me.GVComp.GridControl = Me.GCComp
        Me.GVComp.Name = "GVComp"
        Me.GVComp.OptionsBehavior.Editable = False
        Me.GVComp.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Comp"
        Me.GridColumn1.FieldName = "id_comp"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumnIdDRawer
        '
        Me.GridColumnIdDRawer.Caption = "Id Drawer"
        Me.GridColumnIdDRawer.FieldName = "id_drawer_def"
        Me.GridColumnIdDRawer.Name = "GridColumnIdDRawer"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Account"
        Me.GridColumn2.FieldName = "comp_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 116
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Description"
        Me.GridColumn3.FieldName = "comp_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 946
        '
        'FormMasterCompanyDouble
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 343)
        Me.Controls.Add(Me.GCComp)
        Me.MinimizeBox = False
        Me.Name = "FormMasterCompanyDouble"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account"
        CType(Me.GCComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVComp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCComp As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVComp As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDRawer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
