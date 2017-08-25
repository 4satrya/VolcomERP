<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDepartementSub
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
        Me.GCDepartement = New DevExpress.XtraGrid.GridControl()
        Me.GVDepartment = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.id_departement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.departement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.sub_departement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDeptHead = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCDepartement, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCDepartement
        '
        Me.GCDepartement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDepartement.Location = New System.Drawing.Point(0, 0)
        Me.GCDepartement.MainView = Me.GVDepartment
        Me.GCDepartement.Name = "GCDepartement"
        Me.GCDepartement.Size = New System.Drawing.Size(770, 333)
        Me.GCDepartement.TabIndex = 2
        Me.GCDepartement.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDepartment})
        '
        'GVDepartment
        '
        Me.GVDepartment.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_departement, Me.departement, Me.sub_departement, Me.GridColumnDeptHead})
        Me.GVDepartment.GridControl = Me.GCDepartement
        Me.GVDepartment.Name = "GVDepartment"
        Me.GVDepartment.OptionsBehavior.Editable = False
        Me.GVDepartment.OptionsView.ShowGroupPanel = False
        '
        'id_departement
        '
        Me.id_departement.Caption = "ID"
        Me.id_departement.FieldName = "id_departement_sub"
        Me.id_departement.Name = "id_departement"
        '
        'departement
        '
        Me.departement.Caption = "Departement"
        Me.departement.FieldName = "departement"
        Me.departement.Name = "departement"
        Me.departement.Visible = True
        Me.departement.VisibleIndex = 0
        Me.departement.Width = 166
        '
        'sub_departement
        '
        Me.sub_departement.Caption = "Sub Departement"
        Me.sub_departement.FieldName = "departement_sub"
        Me.sub_departement.Name = "sub_departement"
        Me.sub_departement.Visible = True
        Me.sub_departement.VisibleIndex = 1
        Me.sub_departement.Width = 349
        '
        'GridColumnDeptHead
        '
        Me.GridColumnDeptHead.Caption = "Sub Departement Head"
        Me.GridColumnDeptHead.FieldName = "sub_dept_head"
        Me.GridColumnDeptHead.Name = "GridColumnDeptHead"
        Me.GridColumnDeptHead.Visible = True
        Me.GridColumnDeptHead.VisibleIndex = 2
        Me.GridColumnDeptHead.Width = 149
        '
        'FormDepartementSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 333)
        Me.Controls.Add(Me.GCDepartement)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDepartementSub"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "List Sub Departement"
        CType(Me.GCDepartement, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCDepartement As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDepartment As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_departement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents departement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents sub_departement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDeptHead As DevExpress.XtraGrid.Columns.GridColumn
End Class
