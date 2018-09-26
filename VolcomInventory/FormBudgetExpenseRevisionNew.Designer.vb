<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBudgetExpenseRevisionNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBudgetExpenseRevisionNew))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEYear = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnYear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.MEReason = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtTotal = New DevExpress.XtraEditors.TextEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEReason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(25, 23)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Tahun"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 207)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(317, 42)
        Me.PanelControl1.TabIndex = 100
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(106, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(88, 38)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(194, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(121, 38)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "Create Revision"
        '
        'SLEYear
        '
        Me.SLEYear.Location = New System.Drawing.Point(25, 42)
        Me.SLEYear.Name = "SLEYear"
        Me.SLEYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEYear.Properties.NullText = "- Select Annual Budget -"
        Me.SLEYear.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEYear.Size = New System.Drawing.Size(267, 20)
        Me.SLEYear.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnYear, Me.GridColumnTotal})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsBehavior.AutoExpandAllGroups = True
        Me.SearchLookUpEdit1View.OptionsBehavior.Editable = False
        Me.SearchLookUpEdit1View.OptionsFind.AlwaysVisible = True
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnYear
        '
        Me.GridColumnYear.Caption = "Year"
        Me.GridColumnYear.FieldName = "year"
        Me.GridColumnYear.Name = "GridColumnYear"
        Me.GridColumnYear.Visible = True
        Me.GridColumnYear.VisibleIndex = 0
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.Caption = "Total"
        Me.GridColumnTotal.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotal.FieldName = "total"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        Me.GridColumnTotal.OptionsColumn.AllowEdit = False
        Me.GridColumnTotal.Visible = True
        Me.GridColumnTotal.VisibleIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(25, 113)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl4.TabIndex = 101
        Me.LabelControl4.Text = "Alasan"
        '
        'MEReason
        '
        Me.MEReason.Location = New System.Drawing.Point(25, 132)
        Me.MEReason.Name = "MEReason"
        Me.MEReason.Size = New System.Drawing.Size(267, 41)
        Me.MEReason.TabIndex = 102
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(25, 68)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl2.TabIndex = 103
        Me.LabelControl2.Text = "Total"
        '
        'TxtTotal
        '
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Location = New System.Drawing.Point(25, 87)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtTotal.Size = New System.Drawing.Size(267, 20)
        Me.TxtTotal.TabIndex = 104
        '
        'FormBudgetExpenseRevisionNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(317, 249)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.MEReason)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.SLEYear)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBudgetExpenseRevisionNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.SLEYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEReason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEYear As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnYear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEReason As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents GridColumnTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtTotal As DevExpress.XtraEditors.TextEdit
End Class
