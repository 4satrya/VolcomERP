<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGLineListQuickUpdDel
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.BandedGridColumncode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDivision = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnClass = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnret_code = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnIdDelNew = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepoDel = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BandedGridColumnid_ret_code_new = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepoRetCode = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BandedGridColumnIdDesign = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_delivery = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_ret_code = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BtnCreate = New DevExpress.XtraEditors.SimpleButton()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DiscardChangesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnDiscardDel = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.BandedGridColumnBtnDiscardDel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnBtnDiscardRetCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BtnDiscardRetCode = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoDel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoRetCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.BtnDiscardDel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnDiscardRetCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoDel, Me.RepoRetCode, Me.BtnDiscardDel, Me.BtnDiscardRetCode})
        Me.GCData.Size = New System.Drawing.Size(816, 450)
        Me.GCData.TabIndex = 0
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3})
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnIdDesign, Me.BandedGridColumncode, Me.BandedGridColumnName, Me.BandedGridColumnDivision, Me.BandedGridColumnClass, Me.BandedGridColumndel, Me.BandedGridColumnid_delivery, Me.BandedGridColumnid_ret_code, Me.BandedGridColumnret_code, Me.BandedGridColumnIdDelNew, Me.BandedGridColumnid_ret_code_new, Me.BandedGridColumnBtnDiscardDel, Me.BandedGridColumnBtnDiscardRetCode})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        '
        'BandedGridColumncode
        '
        Me.BandedGridColumncode.Caption = "Code"
        Me.BandedGridColumncode.FieldName = "code"
        Me.BandedGridColumncode.Name = "BandedGridColumncode"
        Me.BandedGridColumncode.OptionsColumn.AllowEdit = False
        Me.BandedGridColumncode.Visible = True
        '
        'BandedGridColumnName
        '
        Me.BandedGridColumnName.Caption = "Description"
        Me.BandedGridColumnName.FieldName = "name"
        Me.BandedGridColumnName.Name = "BandedGridColumnName"
        Me.BandedGridColumnName.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnName.Visible = True
        '
        'BandedGridColumnDivision
        '
        Me.BandedGridColumnDivision.Caption = "Division"
        Me.BandedGridColumnDivision.FieldName = "division"
        Me.BandedGridColumnDivision.Name = "BandedGridColumnDivision"
        Me.BandedGridColumnDivision.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnDivision.Visible = True
        '
        'BandedGridColumnClass
        '
        Me.BandedGridColumnClass.Caption = "Class"
        Me.BandedGridColumnClass.FieldName = "class"
        Me.BandedGridColumnClass.Name = "BandedGridColumnClass"
        Me.BandedGridColumnClass.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnClass.Visible = True
        '
        'BandedGridColumndel
        '
        Me.BandedGridColumndel.Caption = "Old Del"
        Me.BandedGridColumndel.FieldName = "delivery"
        Me.BandedGridColumndel.Name = "BandedGridColumndel"
        Me.BandedGridColumndel.OptionsColumn.AllowEdit = False
        Me.BandedGridColumndel.Visible = True
        '
        'BandedGridColumnret_code
        '
        Me.BandedGridColumnret_code.Caption = "Old Code"
        Me.BandedGridColumnret_code.FieldName = "ret_code"
        Me.BandedGridColumnret_code.Name = "BandedGridColumnret_code"
        Me.BandedGridColumnret_code.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnret_code.Visible = True
        '
        'BandedGridColumnIdDelNew
        '
        Me.BandedGridColumnIdDelNew.Caption = "New Del"
        Me.BandedGridColumnIdDelNew.ColumnEdit = Me.RepoDel
        Me.BandedGridColumnIdDelNew.FieldName = "id_delivery_new"
        Me.BandedGridColumnIdDelNew.Name = "BandedGridColumnIdDelNew"
        Me.BandedGridColumnIdDelNew.Visible = True
        Me.BandedGridColumnIdDelNew.Width = 101
        '
        'RepoDel
        '
        Me.RepoDel.AutoHeight = False
        Me.RepoDel.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoDel.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_delivery", "Id Delivery", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("delivery", "Del"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("delivery_date", "In Store Date", 20, DevExpress.Utils.FormatType.DateTime, "dd MMMM yyyy", True, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("est_wh_date", "Estimate WH Date", 20, DevExpress.Utils.FormatType.DateTime, "dd MMMM yyyy", True, DevExpress.Utils.HorzAlignment.[Default])})
        Me.RepoDel.Name = "RepoDel"
        Me.RepoDel.NullText = "- Select -"
        '
        'BandedGridColumnid_ret_code_new
        '
        Me.BandedGridColumnid_ret_code_new.Caption = "New Code"
        Me.BandedGridColumnid_ret_code_new.ColumnEdit = Me.RepoRetCode
        Me.BandedGridColumnid_ret_code_new.FieldName = "id_ret_code_new"
        Me.BandedGridColumnid_ret_code_new.Name = "BandedGridColumnid_ret_code_new"
        Me.BandedGridColumnid_ret_code_new.Visible = True
        Me.BandedGridColumnid_ret_code_new.Width = 102
        '
        'RepoRetCode
        '
        Me.RepoRetCode.AutoHeight = False
        Me.RepoRetCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoRetCode.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_ret_code", "id_ret_code", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ret_code", "Code"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ret_date", "Return Date", 20, DevExpress.Utils.FormatType.DateTime, "dd MMMM yyyy", True, DevExpress.Utils.HorzAlignment.[Default])})
        Me.RepoRetCode.Name = "RepoRetCode"
        Me.RepoRetCode.NullText = "- Select -"
        '
        'BandedGridColumnIdDesign
        '
        Me.BandedGridColumnIdDesign.Caption = "Id Design"
        Me.BandedGridColumnIdDesign.FieldName = "id_design"
        Me.BandedGridColumnIdDesign.Name = "BandedGridColumnIdDesign"
        Me.BandedGridColumnIdDesign.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumnid_delivery
        '
        Me.BandedGridColumnid_delivery.Caption = "id_delivery"
        Me.BandedGridColumnid_delivery.FieldName = "id_delivery"
        Me.BandedGridColumnid_delivery.Name = "BandedGridColumnid_delivery"
        Me.BandedGridColumnid_delivery.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumnid_ret_code
        '
        Me.BandedGridColumnid_ret_code.Caption = "id_ret_code"
        Me.BandedGridColumnid_ret_code.FieldName = "id_ret_code"
        Me.BandedGridColumnid_ret_code.Name = "BandedGridColumnid_ret_code"
        Me.BandedGridColumnid_ret_code.OptionsColumn.AllowEdit = False
        '
        'BtnCreate
        '
        Me.BtnCreate.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnCreate.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCreate.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnCreate.Appearance.Options.UseBackColor = True
        Me.BtnCreate.Appearance.Options.UseFont = True
        Me.BtnCreate.Appearance.Options.UseForeColor = True
        Me.BtnCreate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnCreate.Location = New System.Drawing.Point(0, 450)
        Me.BtnCreate.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnCreate.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Red
        Me.BtnCreate.LookAndFeel.SkinName = "Metropolis"
        Me.BtnCreate.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnCreate.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.Size = New System.Drawing.Size(816, 31)
        Me.BtnCreate.TabIndex = 5
        Me.BtnCreate.Text = "Update"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DiscardChangesToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(161, 26)
        '
        'DiscardChangesToolStripMenuItem
        '
        Me.DiscardChangesToolStripMenuItem.Name = "DiscardChangesToolStripMenuItem"
        Me.DiscardChangesToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.DiscardChangesToolStripMenuItem.Text = "Discard changes"
        '
        'BtnDiscardDel
        '
        Me.BtnDiscardDel.AutoHeight = False
        SerializableAppearanceObject1.BackColor = System.Drawing.Color.Crimson
        SerializableAppearanceObject1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject1.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject1.Options.UseBackColor = True
        SerializableAppearanceObject1.Options.UseFont = True
        SerializableAppearanceObject1.Options.UseForeColor = True
        Me.BtnDiscardDel.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Discard", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.BtnDiscardDel.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.BtnDiscardDel.Name = "BtnDiscardDel"
        Me.BtnDiscardDel.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'BandedGridColumnBtnDiscardDel
        '
        Me.BandedGridColumnBtnDiscardDel.Caption = "  "
        Me.BandedGridColumnBtnDiscardDel.ColumnEdit = Me.BtnDiscardDel
        Me.BandedGridColumnBtnDiscardDel.Name = "BandedGridColumnBtnDiscardDel"
        Me.BandedGridColumnBtnDiscardDel.Visible = True
        '
        'BandedGridColumnBtnDiscardRetCode
        '
        Me.BandedGridColumnBtnDiscardRetCode.Caption = "  "
        Me.BandedGridColumnBtnDiscardRetCode.ColumnEdit = Me.BtnDiscardRetCode
        Me.BandedGridColumnBtnDiscardRetCode.Name = "BandedGridColumnBtnDiscardRetCode"
        Me.BandedGridColumnBtnDiscardRetCode.Visible = True
        '
        'GridBand1
        '
        Me.GridBand1.Columns.Add(Me.BandedGridColumncode)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnName)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnDivision)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnClass)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 300
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "DEL"
        Me.gridBand2.Columns.Add(Me.BandedGridColumndel)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnIdDelNew)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnBtnDiscardDel)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 251
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "RET CODE"
        Me.gridBand3.Columns.Add(Me.BandedGridColumnret_code)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnid_ret_code_new)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnBtnDiscardRetCode)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 252
        '
        'BtnDiscardRetCode
        '
        Me.BtnDiscardRetCode.AutoHeight = False
        SerializableAppearanceObject2.BackColor = System.Drawing.Color.Crimson
        SerializableAppearanceObject2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject2.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject2.Options.UseBackColor = True
        SerializableAppearanceObject2.Options.UseFont = True
        SerializableAppearanceObject2.Options.UseForeColor = True
        Me.BtnDiscardRetCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Discard", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.BtnDiscardRetCode.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.BtnDiscardRetCode.Name = "BtnDiscardRetCode"
        Me.BtnDiscardRetCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'FormFGLineListQuickUpdDel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 481)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.BtnCreate)
        Me.MinimizeBox = False
        Me.Name = "FormFGLineListQuickUpdDel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quick Update"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoDel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoRetCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.BtnDiscardDel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnDiscardRetCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumncode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDivision As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnClass As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnret_code As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnIdDelNew As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_ret_code_new As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnIdDesign As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_delivery As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_ret_code As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BtnCreate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RepoDel As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepoRetCode As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DiscardChangesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnBtnDiscardDel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BtnDiscardDel As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnBtnDiscardRetCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BtnDiscardRetCode As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
