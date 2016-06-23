<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpHolidayDet
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DEDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.MEDesc = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEReligion = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumnIdReligionSLE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReligionSLE = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.DEDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEReligion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DEDate
        '
        Me.DEDate.EditValue = Nothing
        Me.DEDate.Location = New System.Drawing.Point(75, 39)
        Me.DEDate.Name = "DEDate"
        Me.DEDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDate.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.DEDate.Size = New System.Drawing.Size(191, 20)
        Me.DEDate.TabIndex = 2
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(13, 42)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl6.TabIndex = 98
        Me.LabelControl6.Text = "Date"
        '
        'MEDesc
        '
        Me.MEDesc.Location = New System.Drawing.Point(75, 65)
        Me.MEDesc.Name = "MEDesc"
        Me.MEDesc.Size = New System.Drawing.Size(364, 61)
        Me.MEDesc.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 67)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl1.TabIndex = 101
        Me.LabelControl1.Text = "Description"
        '
        'SLEReligion
        '
        Me.SLEReligion.Location = New System.Drawing.Point(75, 13)
        Me.SLEReligion.Name = "SLEReligion"
        Me.SLEReligion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEReligion.Properties.View = Me.GridView1
        Me.SLEReligion.Size = New System.Drawing.Size(191, 20)
        Me.SLEReligion.TabIndex = 1
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdReligionSLE, Me.GridColumnReligionSLE})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(13, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 8901
        Me.LabelControl2.Text = "Religion"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BClose)
        Me.PanelControl1.Controls.Add(Me.BSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 142)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(459, 37)
        Me.PanelControl1.TabIndex = 8903
        '
        'BClose
        '
        Me.BClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BClose.Location = New System.Drawing.Point(307, 2)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(75, 33)
        Me.BClose.TabIndex = 5
        Me.BClose.Text = "Close"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Location = New System.Drawing.Point(382, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 33)
        Me.BSave.TabIndex = 4
        Me.BSave.Text = "Save"
        '
        'GridColumnIdReligionSLE
        '
        Me.GridColumnIdReligionSLE.Caption = "Id Religion"
        Me.GridColumnIdReligionSLE.FieldName = "id_religion"
        Me.GridColumnIdReligionSLE.Name = "GridColumnIdReligionSLE"
        '
        'GridColumnReligionSLE
        '
        Me.GridColumnReligionSLE.Caption = "Religion"
        Me.GridColumnReligionSLE.FieldName = "religion"
        Me.GridColumnReligionSLE.Name = "GridColumnReligionSLE"
        Me.GridColumnReligionSLE.Visible = True
        Me.GridColumnReligionSLE.VisibleIndex = 0
        '
        'FormEmpHolidayDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 179)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.SLEReligion)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.MEDesc)
        Me.Controls.Add(Me.DEDate)
        Me.Controls.Add(Me.LabelControl6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpHolidayDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Holiday"
        CType(Me.DEDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEReligion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DEDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEDesc As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEReligion As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdReligionSLE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReligionSLE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
End Class
