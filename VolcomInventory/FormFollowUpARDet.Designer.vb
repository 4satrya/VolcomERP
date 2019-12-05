<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFollowUpARDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFollowUpARDet))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEStoreGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DEDueDate = New DevExpress.XtraEditors.DateEdit()
        Me.BtnBrowseDate = New DevExpress.XtraEditors.SimpleButton()
        Me.MEFollowUp = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.MEFollowUpResult = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFollowUpDate = New DevExpress.XtraEditors.DateEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEFollowUp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEFollowUpResult.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFollowUpDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFollowUpDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 231)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(451, 44)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(299, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 40)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(374, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 40)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Save"
        '
        'SLEStoreGroup
        '
        Me.SLEStoreGroup.Location = New System.Drawing.Point(112, 21)
        Me.SLEStoreGroup.Name = "SLEStoreGroup"
        Me.SLEStoreGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreGroup.Properties.View = Me.GridView3
        Me.SLEStoreGroup.Size = New System.Drawing.Size(313, 20)
        Me.SLEStoreGroup.TabIndex = 8925
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumncomp_group, Me.GridColumndescription})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 0
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Description"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(16, 24)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl3.TabIndex = 8924
        Me.LabelControl3.Text = "Store Group"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 48)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 8926
        Me.LabelControl1.Text = "Due Date"
        '
        'DEDueDate
        '
        Me.DEDueDate.EditValue = Nothing
        Me.DEDueDate.Enabled = False
        Me.DEDueDate.Location = New System.Drawing.Point(112, 47)
        Me.DEDueDate.Name = "DEDueDate"
        Me.DEDueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDueDate.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEDueDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDueDate.Size = New System.Drawing.Size(273, 20)
        Me.DEDueDate.TabIndex = 8927
        '
        'BtnBrowseDate
        '
        Me.BtnBrowseDate.Location = New System.Drawing.Point(391, 47)
        Me.BtnBrowseDate.Name = "BtnBrowseDate"
        Me.BtnBrowseDate.Size = New System.Drawing.Size(34, 20)
        Me.BtnBrowseDate.TabIndex = 8928
        Me.BtnBrowseDate.Text = "..."
        '
        'MEFollowUp
        '
        Me.MEFollowUp.Location = New System.Drawing.Point(112, 99)
        Me.MEFollowUp.Name = "MEFollowUp"
        Me.MEFollowUp.Size = New System.Drawing.Size(313, 50)
        Me.MEFollowUp.TabIndex = 8929
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(16, 101)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl2.TabIndex = 8930
        Me.LabelControl2.Text = "Follow Up"
        '
        'MEFollowUpResult
        '
        Me.MEFollowUpResult.Location = New System.Drawing.Point(112, 155)
        Me.MEFollowUpResult.Name = "MEFollowUpResult"
        Me.MEFollowUpResult.Size = New System.Drawing.Size(313, 50)
        Me.MEFollowUpResult.TabIndex = 8931
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(16, 157)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl4.TabIndex = 8932
        Me.LabelControl4.Text = "Follow Up Result"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(16, 76)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(72, 13)
        Me.LabelControl5.TabIndex = 8933
        Me.LabelControl5.Text = "Follow Up Date"
        '
        'DEFollowUpDate
        '
        Me.DEFollowUpDate.EditValue = Nothing
        Me.DEFollowUpDate.Location = New System.Drawing.Point(112, 73)
        Me.DEFollowUpDate.Name = "DEFollowUpDate"
        Me.DEFollowUpDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFollowUpDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFollowUpDate.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEFollowUpDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFollowUpDate.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFollowUpDate.Size = New System.Drawing.Size(313, 20)
        Me.DEFollowUpDate.TabIndex = 8934
        '
        'FormFollowUpARDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 275)
        Me.Controls.Add(Me.DEFollowUpDate)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.MEFollowUpResult)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.MEFollowUp)
        Me.Controls.Add(Me.BtnBrowseDate)
        Me.Controls.Add(Me.DEDueDate)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.SLEStoreGroup)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFollowUpARDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Follow Up AR"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEFollowUp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEFollowUpResult.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFollowUpDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFollowUpDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEStoreGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEDueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BtnBrowseDate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MEFollowUp As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEFollowUpResult As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFollowUpDate As DevExpress.XtraEditors.DateEdit
End Class
