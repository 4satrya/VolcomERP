<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterRawMaterialSingle
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
        Me.PCSave = New DevExpress.XtraEditors.PanelControl()
        Me.BGenerate = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelDisplayName = New DevExpress.XtraEditors.LabelControl()
        Me.TxtMatDisplayName = New DevExpress.XtraEditors.TextEdit()
        Me.TxtMatName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelMatName = New DevExpress.XtraEditors.LabelControl()
        Me.LabelUOM = New DevExpress.XtraEditors.LabelControl()
        Me.LEUOM = New DevExpress.XtraEditors.LookUpEdit()
        Me.EPMaterialType = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DNCodeMaterial = New DevExpress.XtraEditors.DataNavigator()
        Me.GCCodeMaterial = New DevExpress.XtraGrid.GridControl()
        Me.GVCodeMaterial = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColCodeParam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCodeValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LETemplate = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtMaterialCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LEMatCat = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BRefreshCode = New DevExpress.XtraEditors.SimpleButton()
        Me.BeditCode = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PCSave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCSave.SuspendLayout()
        CType(Me.TxtMatDisplayName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMatName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEUOM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EPMaterialType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCCodeMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCodeMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LETemplate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMaterialCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEMatCat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCSave
        '
        Me.PCSave.Controls.Add(Me.BGenerate)
        Me.PCSave.Controls.Add(Me.BtnSave)
        Me.PCSave.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCSave.Location = New System.Drawing.Point(0, 310)
        Me.PCSave.LookAndFeel.SkinName = "Blue"
        Me.PCSave.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PCSave.Name = "PCSave"
        Me.PCSave.Size = New System.Drawing.Size(695, 39)
        Me.PCSave.TabIndex = 21
        '
        'BGenerate
        '
        Me.BGenerate.Location = New System.Drawing.Point(514, 8)
        Me.BGenerate.Name = "BGenerate"
        Me.BGenerate.Size = New System.Drawing.Size(86, 23)
        Me.BGenerate.TabIndex = 8
        Me.BGenerate.Text = "Generate Code"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(606, 8)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 9
        Me.BtnSave.Text = "Save"
        '
        'LabelDisplayName
        '
        Me.LabelDisplayName.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDisplayName.Location = New System.Drawing.Point(12, 64)
        Me.LabelDisplayName.Name = "LabelDisplayName"
        Me.LabelDisplayName.Size = New System.Drawing.Size(76, 15)
        Me.LabelDisplayName.TabIndex = 35
        Me.LabelDisplayName.Text = "Display Name"
        '
        'TxtMatDisplayName
        '
        Me.TxtMatDisplayName.Location = New System.Drawing.Point(12, 85)
        Me.TxtMatDisplayName.Name = "TxtMatDisplayName"
        Me.TxtMatDisplayName.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMatDisplayName.Properties.Appearance.Options.UseFont = True
        Me.TxtMatDisplayName.Properties.MaxLength = 30
        Me.TxtMatDisplayName.Size = New System.Drawing.Size(271, 22)
        Me.TxtMatDisplayName.TabIndex = 2
        Me.TxtMatDisplayName.ToolTip = "Max : 30 character."
        Me.TxtMatDisplayName.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtMatDisplayName.ToolTipTitle = "Information"
        '
        'TxtMatName
        '
        Me.TxtMatName.Location = New System.Drawing.Point(12, 32)
        Me.TxtMatName.Name = "TxtMatName"
        Me.TxtMatName.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMatName.Properties.Appearance.Options.UseFont = True
        Me.TxtMatName.Properties.MaxLength = 50
        Me.TxtMatName.Size = New System.Drawing.Size(271, 22)
        Me.TxtMatName.TabIndex = 1
        Me.TxtMatName.ToolTip = "Example : Jersey 32'S. Max :  50 character"
        Me.TxtMatName.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtMatName.ToolTipTitle = "Information"
        '
        'LabelMatName
        '
        Me.LabelMatName.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMatName.Location = New System.Drawing.Point(12, 11)
        Me.LabelMatName.Name = "LabelMatName"
        Me.LabelMatName.Size = New System.Drawing.Size(64, 15)
        Me.LabelMatName.TabIndex = 33
        Me.LabelMatName.Text = "Description"
        '
        'LabelUOM
        '
        Me.LabelUOM.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUOM.Location = New System.Drawing.Point(12, 176)
        Me.LabelUOM.Name = "LabelUOM"
        Me.LabelUOM.Size = New System.Drawing.Size(88, 15)
        Me.LabelUOM.TabIndex = 36
        Me.LabelUOM.Text = "Unit of Measure"
        '
        'LEUOM
        '
        Me.LEUOM.Location = New System.Drawing.Point(12, 197)
        Me.LEUOM.Name = "LEUOM"
        Me.LEUOM.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LEUOM.Properties.Appearance.Options.UseFont = True
        Me.LEUOM.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEUOM.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_uom", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("uom", "Unit of measure")})
        Me.LEUOM.Properties.NullText = ""
        Me.LEUOM.Size = New System.Drawing.Size(271, 22)
        Me.LEUOM.TabIndex = 4
        Me.LEUOM.ToolTip = "Unit of measure that stored in warehouse."
        Me.LEUOM.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.LEUOM.ToolTipTitle = "Information"
        '
        'EPMaterialType
        '
        Me.EPMaterialType.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EPMaterialType.ContainerControl = Me
        '
        'DNCodeMaterial
        '
        Me.DNCodeMaterial.Location = New System.Drawing.Point(303, 225)
        Me.DNCodeMaterial.Name = "DNCodeMaterial"
        Me.DNCodeMaterial.Size = New System.Drawing.Size(378, 24)
        Me.DNCodeMaterial.TabIndex = 38
        '
        'GCCodeMaterial
        '
        Me.GCCodeMaterial.Location = New System.Drawing.Point(303, 60)
        Me.GCCodeMaterial.MainView = Me.GVCodeMaterial
        Me.GCCodeMaterial.Name = "GCCodeMaterial"
        Me.GCCodeMaterial.Size = New System.Drawing.Size(378, 165)
        Me.GCCodeMaterial.TabIndex = 7
        Me.GCCodeMaterial.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCodeMaterial})
        '
        'GVCodeMaterial
        '
        Me.GVCodeMaterial.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColCodeParam, Me.ColCodeValue})
        Me.GVCodeMaterial.GridControl = Me.GCCodeMaterial
        Me.GVCodeMaterial.Name = "GVCodeMaterial"
        Me.GVCodeMaterial.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVCodeMaterial.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVCodeMaterial.OptionsCustomization.AllowColumnMoving = False
        Me.GVCodeMaterial.OptionsCustomization.AllowFilter = False
        Me.GVCodeMaterial.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVCodeMaterial.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVCodeMaterial.OptionsView.EnableAppearanceEvenRow = True
        Me.GVCodeMaterial.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVCodeMaterial.OptionsView.ShowGroupPanel = False
        Me.GVCodeMaterial.OptionsView.ShowIndicator = False
        '
        'ColCodeParam
        '
        Me.ColCodeParam.Caption = "Category"
        Me.ColCodeParam.FieldName = "code"
        Me.ColCodeParam.Name = "ColCodeParam"
        Me.ColCodeParam.Visible = True
        Me.ColCodeParam.VisibleIndex = 0
        '
        'ColCodeValue
        '
        Me.ColCodeValue.Caption = "Value"
        Me.ColCodeValue.FieldName = "value"
        Me.ColCodeValue.Name = "ColCodeValue"
        Me.ColCodeValue.Visible = True
        Me.ColCodeValue.VisibleIndex = 1
        '
        'LETemplate
        '
        Me.LETemplate.Enabled = False
        Me.LETemplate.Location = New System.Drawing.Point(303, 32)
        Me.LETemplate.Name = "LETemplate"
        Me.LETemplate.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LETemplate.Properties.Appearance.Options.UseFont = True
        Me.LETemplate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LETemplate.Properties.NullText = ""
        Me.LETemplate.Properties.ShowFooter = False
        Me.LETemplate.Properties.View = Me.GridView2
        Me.LETemplate.Size = New System.Drawing.Size(283, 22)
        Me.LETemplate.TabIndex = 5
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Template Code"
        Me.GridColumn1.FieldName = "id_template_code"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Template Code"
        Me.GridColumn2.FieldName = "template_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(303, 11)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(80, 15)
        Me.LabelControl7.TabIndex = 96
        Me.LabelControl7.Text = "Template Code"
        '
        'TxtMaterialCode
        '
        Me.TxtMaterialCode.Location = New System.Drawing.Point(303, 276)
        Me.TxtMaterialCode.Name = "TxtMaterialCode"
        Me.TxtMaterialCode.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMaterialCode.Properties.Appearance.Options.UseFont = True
        Me.TxtMaterialCode.Size = New System.Drawing.Size(378, 22)
        Me.TxtMaterialCode.TabIndex = 6
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(303, 255)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(106, 15)
        Me.LabelControl6.TabIndex = 94
        Me.LabelControl6.Text = "Material Type Code"
        '
        'LEMatCat
        '
        Me.LEMatCat.Location = New System.Drawing.Point(12, 142)
        Me.LEMatCat.Name = "LEMatCat"
        Me.LEMatCat.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LEMatCat.Properties.Appearance.Options.UseFont = True
        Me.LEMatCat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEMatCat.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_mat_cat", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("mat_cat", "Material Category")})
        Me.LEMatCat.Properties.NullText = ""
        Me.LEMatCat.Size = New System.Drawing.Size(271, 22)
        Me.LEMatCat.TabIndex = 3
        Me.LEMatCat.ToolTip = "Unit of measure that stored in warehouse."
        Me.LEMatCat.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.LEMatCat.ToolTipTitle = "Information"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 121)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(99, 15)
        Me.LabelControl1.TabIndex = 98
        Me.LabelControl1.Text = "Material Category"
        '
        'BRefreshCode
        '
        Me.BRefreshCode.Location = New System.Drawing.Point(636, 33)
        Me.BRefreshCode.Name = "BRefreshCode"
        Me.BRefreshCode.Size = New System.Drawing.Size(45, 21)
        Me.BRefreshCode.TabIndex = 105
        Me.BRefreshCode.Text = "Reset"
        '
        'BeditCode
        '
        Me.BeditCode.Location = New System.Drawing.Point(592, 33)
        Me.BeditCode.Name = "BeditCode"
        Me.BeditCode.Size = New System.Drawing.Size(38, 21)
        Me.BeditCode.TabIndex = 104
        Me.BeditCode.Text = "Code"
        '
        'FormMasterRawMaterialSingle
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 349)
        Me.Controls.Add(Me.BRefreshCode)
        Me.Controls.Add(Me.BeditCode)
        Me.Controls.Add(Me.LEMatCat)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LETemplate)
        Me.Controls.Add(Me.DNCodeMaterial)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.GCCodeMaterial)
        Me.Controls.Add(Me.TxtMaterialCode)
        Me.Controls.Add(Me.LEUOM)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelUOM)
        Me.Controls.Add(Me.LabelDisplayName)
        Me.Controls.Add(Me.TxtMatDisplayName)
        Me.Controls.Add(Me.TxtMatName)
        Me.Controls.Add(Me.LabelMatName)
        Me.Controls.Add(Me.PCSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterRawMaterialSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Material Type"
        CType(Me.PCSave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCSave.ResumeLayout(False)
        CType(Me.TxtMatDisplayName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMatName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEUOM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EPMaterialType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCCodeMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCodeMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LETemplate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMaterialCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEMatCat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PCSave As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelDisplayName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtMatDisplayName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtMatName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelMatName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelUOM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEUOM As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents EPMaterialType As System.Windows.Forms.ErrorProvider
    Friend WithEvents BGenerate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DNCodeMaterial As DevExpress.XtraEditors.DataNavigator
    Friend WithEvents GCCodeMaterial As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCodeMaterial As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColCodeParam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCodeValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LETemplate As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtMaterialCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEMatCat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BRefreshCode As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BeditCode As DevExpress.XtraEditors.SimpleButton
End Class
