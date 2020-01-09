<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCompGroupDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterCompGroupDet))
        Me.TECompanyGroup = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.PictureSeason = New DevExpress.XtraEditors.PictureEdit()
        Me.TEDescription = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLUECompanyGroupHeader = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButtonAddRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.TECompanyGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUECompanyGroupHeader.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TECompanyGroup
        '
        Me.TECompanyGroup.Location = New System.Drawing.Point(238, 46)
        Me.TECompanyGroup.Name = "TECompanyGroup"
        Me.TECompanyGroup.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TECompanyGroup.Properties.Appearance.Options.UseFont = True
        Me.TECompanyGroup.Size = New System.Drawing.Size(272, 22)
        Me.TECompanyGroup.TabIndex = 5
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(113, 22)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(88, 15)
        Me.LabelControl4.TabIndex = 4
        Me.LabelControl4.Text = "Company Group"
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(365, 107)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(69, 23)
        Me.BCancel.TabIndex = 12
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(440, 107)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 11
        Me.BSave.Text = "Save"
        '
        'PictureSeason
        '
        Me.PictureSeason.EditValue = CType(resources.GetObject("PictureSeason.EditValue"), Object)
        Me.PictureSeason.Location = New System.Drawing.Point(12, -2)
        Me.PictureSeason.Name = "PictureSeason"
        Me.PictureSeason.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureSeason.Properties.Appearance.Options.UseBackColor = True
        Me.PictureSeason.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureSeason.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureSeason.Size = New System.Drawing.Size(99, 107)
        Me.PictureSeason.TabIndex = 20
        '
        'TEDescription
        '
        Me.TEDescription.Location = New System.Drawing.Point(238, 74)
        Me.TEDescription.Name = "TEDescription"
        Me.TEDescription.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEDescription.Properties.Appearance.Options.UseFont = True
        Me.TEDescription.Size = New System.Drawing.Size(272, 22)
        Me.TEDescription.TabIndex = 22
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(113, 77)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(64, 15)
        Me.LabelControl1.TabIndex = 21
        Me.LabelControl1.Text = "Description"
        '
        'SLUECompanyGroupHeader
        '
        Me.SLUECompanyGroupHeader.Location = New System.Drawing.Point(238, 20)
        Me.SLUECompanyGroupHeader.Name = "SLUECompanyGroupHeader"
        Me.SLUECompanyGroupHeader.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUECompanyGroupHeader.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUECompanyGroupHeader.Size = New System.Drawing.Size(180, 20)
        Me.SLUECompanyGroupHeader.TabIndex = 23
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn1, Me.GridColumn2, Me.GridColumn4})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(113, 49)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(111, 15)
        Me.LabelControl2.TabIndex = 24
        Me.LabelControl2.Text = "Company Group Sub"
        '
        'SimpleButtonAddRemove
        '
        Me.SimpleButtonAddRemove.Location = New System.Drawing.Point(424, 18)
        Me.SimpleButtonAddRemove.Name = "SimpleButtonAddRemove"
        Me.SimpleButtonAddRemove.Size = New System.Drawing.Size(86, 23)
        Me.SimpleButtonAddRemove.TabIndex = 25
        Me.SimpleButtonAddRemove.Text = "Add / Remove"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "GridColumn3"
        Me.GridColumn3.FieldName = "id_comp_group_header"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Code"
        Me.GridColumn1.FieldName = "comp_group_header"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Description"
        Me.GridColumn2.FieldName = "description"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "GridColumn4"
        Me.GridColumn4.FieldName = "description_name"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'FormMasterCompGroupDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 142)
        Me.Controls.Add(Me.SimpleButtonAddRemove)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.SLUECompanyGroupHeader)
        Me.Controls.Add(Me.TEDescription)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PictureSeason)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.TECompanyGroup)
        Me.Controls.Add(Me.LabelControl4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCompGroupDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Group Company Sub"
        CType(Me.TECompanyGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUECompanyGroupHeader.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TECompanyGroup As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureSeason As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents TEDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLUECompanyGroupHeader As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButtonAddRemove As DevExpress.XtraEditors.SimpleButton
End Class
