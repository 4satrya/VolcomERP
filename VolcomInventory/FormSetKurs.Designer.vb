<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSetKurs
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BGetKurs = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TEKurs = New DevExpress.XtraEditors.TextEdit()
        Me.GCKursTrans = New DevExpress.XtraGrid.GridControl()
        Me.GVKursTrans = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCKursTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVKursTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BGetKurs)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.TEKurs)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(870, 42)
        Me.PanelControl1.TabIndex = 0
        '
        'BGetKurs
        '
        Me.BGetKurs.Location = New System.Drawing.Point(347, 11)
        Me.BGetKurs.Name = "BGetKurs"
        Me.BGetKurs.Size = New System.Drawing.Size(94, 23)
        Me.BGetKurs.TabIndex = 3
        Me.BGetKurs.Text = "Get Kurs"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(281, 11)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(60, 23)
        Me.BSave.TabIndex = 2
        Me.BSave.Text = "Save"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Today Kurs :"
        '
        'TEKurs
        '
        Me.TEKurs.Location = New System.Drawing.Point(79, 13)
        Me.TEKurs.Name = "TEKurs"
        Me.TEKurs.Properties.Mask.EditMask = "N2"
        Me.TEKurs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEKurs.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEKurs.Size = New System.Drawing.Size(196, 20)
        Me.TEKurs.TabIndex = 0
        '
        'GCKursTrans
        '
        Me.GCKursTrans.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCKursTrans.Location = New System.Drawing.Point(0, 42)
        Me.GCKursTrans.MainView = Me.GVKursTrans
        Me.GCKursTrans.Name = "GCKursTrans"
        Me.GCKursTrans.Size = New System.Drawing.Size(870, 479)
        Me.GCKursTrans.TabIndex = 1
        Me.GCKursTrans.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVKursTrans})
        '
        'GVKursTrans
        '
        Me.GVKursTrans.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GVKursTrans.GridControl = Me.GCKursTrans
        Me.GVKursTrans.Name = "GVKursTrans"
        Me.GVKursTrans.OptionsBehavior.Editable = False
        Me.GVKursTrans.OptionsBehavior.ReadOnly = True
        Me.GVKursTrans.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Kurs"
        Me.GridColumn1.FieldName = "id_kurs_trans"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Datetime"
        Me.GridColumn2.DisplayFormat.FormatString = "dd MMMM yyyy hh:mm"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn2.FieldName = "created_date"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 282
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "By"
        Me.GridColumn3.FieldName = "employee_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 307
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Kurs"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "kurs_trans"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 1043
        '
        'FormSetKurs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 521)
        Me.Controls.Add(Me.GCKursTrans)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSetKurs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Kurs"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCKursTrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVKursTrans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCKursTrans As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVKursTrans As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEKurs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BGetKurs As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
End Class
