<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmpStoreSchCompareHistory
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
        Me.components = New System.ComponentModel.Container()
        Me.GCAttnAssign = New DevExpress.XtraGrid.GridControl()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMViewHistoryPD = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVAttnAssign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNomor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LDate = New DevExpress.XtraEditors.LabelControl()
        Me.LEmpName = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GCAttnAssign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        CType(Me.GVAttnAssign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCAttnAssign
        '
        Me.GCAttnAssign.ContextMenuStrip = Me.ViewMenu
        Me.GCAttnAssign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAttnAssign.Location = New System.Drawing.Point(0, 58)
        Me.GCAttnAssign.MainView = Me.GVAttnAssign
        Me.GCAttnAssign.Name = "GCAttnAssign"
        Me.GCAttnAssign.Size = New System.Drawing.Size(721, 138)
        Me.GCAttnAssign.TabIndex = 6
        Me.GCAttnAssign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAttnAssign})
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMViewHistoryPD})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(159, 26)
        '
        'SMViewHistoryPD
        '
        Me.SMViewHistoryPD.Name = "SMViewHistoryPD"
        Me.SMViewHistoryPD.Size = New System.Drawing.Size(158, 22)
        Me.SMViewHistoryPD.Text = "View Document"
        '
        'GVAttnAssign
        '
        Me.GVAttnAssign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnID, Me.GridColumnNomor, Me.GridColumnDate, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVAttnAssign.GridControl = Me.GCAttnAssign
        Me.GVAttnAssign.Name = "GVAttnAssign"
        Me.GVAttnAssign.OptionsBehavior.Editable = False
        Me.GVAttnAssign.OptionsView.ShowGroupPanel = False
        '
        'GridColumnID
        '
        Me.GridColumnID.Caption = "ID"
        Me.GridColumnID.FieldName = "id_assign_sch"
        Me.GridColumnID.Name = "GridColumnID"
        '
        'GridColumnNomor
        '
        Me.GridColumnNomor.Caption = "Propose Number"
        Me.GridColumnNomor.FieldName = "assign_sch_number"
        Me.GridColumnNomor.Name = "GridColumnNomor"
        Me.GridColumnNomor.Visible = True
        Me.GridColumnNomor.VisibleIndex = 0
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Date Proposed"
        Me.GridColumnDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDate.FieldName = "assign_sch_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 1
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Proposed By"
        Me.GridColumn1.FieldName = "name_propose"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Change From"
        Me.GridColumn2.FieldName = "shift_code_from"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 3
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Change To"
        Me.GridColumn3.FieldName = "shift_code"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 4
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LDate)
        Me.PanelControl1.Controls.Add(Me.LEmpName)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(721, 58)
        Me.PanelControl1.TabIndex = 7
        '
        'LDate
        '
        Me.LDate.Location = New System.Drawing.Point(74, 32)
        Me.LDate.Name = "LDate"
        Me.LDate.Size = New System.Drawing.Size(23, 13)
        Me.LDate.TabIndex = 5
        Me.LDate.Text = "Date"
        '
        'LEmpName
        '
        Me.LEmpName.Location = New System.Drawing.Point(74, 12)
        Me.LEmpName.Name = "LEmpName"
        Me.LEmpName.Size = New System.Drawing.Size(46, 13)
        Me.LEmpName.TabIndex = 4
        Me.LEmpName.Text = "Employee"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(64, 32)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl4.TabIndex = 3
        Me.LabelControl4.Text = ":"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(64, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = ":"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 32)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Date"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Employee"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BPrint)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 196)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(721, 32)
        Me.PanelControl2.TabIndex = 8
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BPrint.Location = New System.Drawing.Point(2, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(717, 28)
        Me.BPrint.TabIndex = 0
        Me.BPrint.Text = "Print"
        '
        'FormEmpStoreSchCompareHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 228)
        Me.Controls.Add(Me.GCAttnAssign)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpStoreSchCompareHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "History Change Schedule"
        CType(Me.GCAttnAssign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        CType(Me.GVAttnAssign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCAttnAssign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAttnAssign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNomor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEmpName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents SMViewHistoryPD As ToolStripMenuItem
End Class
