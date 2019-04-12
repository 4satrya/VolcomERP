<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGProposePriceCOPList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGProposePriceCOPList))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewList = New DevExpress.XtraEditors.SimpleButton()
        Me.LEDivision = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LESource = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdPDD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstyle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnClass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsSelect = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnCOPStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRateType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCOP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCOPMngKurs = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCOPMgn = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelNav.SuspendLayout()
        CType(Me.LEDivision.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LESource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnClose)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 382)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(821, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(662, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(79, 42)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Close"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(741, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(78, 42)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "Print"
        '
        'PanelNav
        '
        Me.PanelNav.Controls.Add(Me.BtnViewList)
        Me.PanelNav.Controls.Add(Me.LEDivision)
        Me.PanelNav.Controls.Add(Me.LabelControl3)
        Me.PanelNav.Controls.Add(Me.LESource)
        Me.PanelNav.Controls.Add(Me.LabelControl2)
        Me.PanelNav.Controls.Add(Me.SLESeason)
        Me.PanelNav.Controls.Add(Me.LabelControl1)
        Me.PanelNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelNav.Name = "PanelNav"
        Me.PanelNav.Size = New System.Drawing.Size(821, 47)
        Me.PanelNav.TabIndex = 1
        '
        'BtnViewList
        '
        Me.BtnViewList.Image = CType(resources.GetObject("BtnViewList.Image"), System.Drawing.Image)
        Me.BtnViewList.Location = New System.Drawing.Point(648, 14)
        Me.BtnViewList.LookAndFeel.SkinName = "Blue"
        Me.BtnViewList.Name = "BtnViewList"
        Me.BtnViewList.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewList.TabIndex = 8915
        Me.BtnViewList.Text = "View"
        '
        'LEDivision
        '
        Me.LEDivision.Location = New System.Drawing.Point(530, 14)
        Me.LEDivision.Name = "LEDivision"
        Me.LEDivision.Properties.Appearance.Options.UseTextOptions = True
        Me.LEDivision.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEDivision.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDivision.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_code_detail", "ID Division", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("display_name", "Display Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_detail_name", "Division")})
        Me.LEDivision.Properties.NullText = ""
        Me.LEDivision.Properties.ShowFooter = False
        Me.LEDivision.Size = New System.Drawing.Size(112, 20)
        Me.LEDivision.TabIndex = 8914
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(488, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl3.TabIndex = 8913
        Me.LabelControl3.Text = "Division"
        '
        'LESource
        '
        Me.LESource.Location = New System.Drawing.Point(328, 14)
        Me.LESource.Name = "LESource"
        Me.LESource.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESource.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_source", "Id Code Detail", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("display_name", "Display Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("source", "Source")})
        Me.LESource.Properties.NullText = "- Select Product Source -"
        Me.LESource.Size = New System.Drawing.Size(154, 20)
        Me.LESource.TabIndex = 8912
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(289, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl2.TabIndex = 8911
        Me.LabelControl2.Text = "Source"
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(58, 14)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.ShowClearButton = False
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(225, 20)
        Me.SLESeason.TabIndex = 8910
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn8, Me.GridColumn3})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Id Season"
        Me.GridColumn6.FieldName = "id_season"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Season"
        Me.GridColumn8.FieldName = "season"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Range"
        Me.GridColumn3.FieldName = "range"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 8909
        Me.LabelControl1.Text = "Season"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 47)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCData.Size = New System.Drawing.Size(821, 335)
        Me.GCData.TabIndex = 2
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdDesign, Me.GridColumnIdPDD, Me.GridColumnCode, Me.GridColumnstyle, Me.GridColumnClass, Me.GridColumnIsSelect, Me.GridColumnCOPStatus, Me.GridColumnRateType, Me.GridColumnRate, Me.GridColumnCOP, Me.GridColumnCOPMngKurs, Me.GridColumnCOPMgn})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdDesign
        '
        Me.GridColumnIdDesign.Caption = "Id Design"
        Me.GridColumnIdDesign.FieldName = "id_design"
        Me.GridColumnIdDesign.Name = "GridColumnIdDesign"
        Me.GridColumnIdDesign.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdPDD
        '
        Me.GridColumnIdPDD.Caption = "Id PDD"
        Me.GridColumnIdPDD.FieldName = "id_prod_demand_design"
        Me.GridColumnIdPDD.Name = "GridColumnIdPDD"
        Me.GridColumnIdPDD.OptionsColumn.AllowEdit = False
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 0
        '
        'GridColumnstyle
        '
        Me.GridColumnstyle.Caption = "Style"
        Me.GridColumnstyle.FieldName = "name"
        Me.GridColumnstyle.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnstyle.Name = "GridColumnstyle"
        Me.GridColumnstyle.OptionsColumn.AllowEdit = False
        Me.GridColumnstyle.Visible = True
        Me.GridColumnstyle.VisibleIndex = 1
        '
        'GridColumnClass
        '
        Me.GridColumnClass.Caption = "Class"
        Me.GridColumnClass.FieldName = "class"
        Me.GridColumnClass.Name = "GridColumnClass"
        Me.GridColumnClass.OptionsColumn.AllowEdit = False
        Me.GridColumnClass.Visible = True
        Me.GridColumnClass.VisibleIndex = 2
        '
        'GridColumnIsSelect
        '
        Me.GridColumnIsSelect.Caption = "Select"
        Me.GridColumnIsSelect.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnIsSelect.FieldName = "is_select"
        Me.GridColumnIsSelect.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnIsSelect.Name = "GridColumnIsSelect"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnCOPStatus
        '
        Me.GridColumnCOPStatus.Caption = "COP Status"
        Me.GridColumnCOPStatus.FieldName = "cop_status"
        Me.GridColumnCOPStatus.Name = "GridColumnCOPStatus"
        Me.GridColumnCOPStatus.OptionsColumn.AllowEdit = False
        Me.GridColumnCOPStatus.Visible = True
        Me.GridColumnCOPStatus.VisibleIndex = 3
        '
        'GridColumnRateType
        '
        Me.GridColumnRateType.Caption = "Rate Type"
        Me.GridColumnRateType.FieldName = "cop_rate_cat_display"
        Me.GridColumnRateType.Name = "GridColumnRateType"
        Me.GridColumnRateType.OptionsColumn.AllowEdit = False
        Me.GridColumnRateType.Visible = True
        Me.GridColumnRateType.VisibleIndex = 4
        '
        'GridColumnRate
        '
        Me.GridColumnRate.Caption = "Rate"
        Me.GridColumnRate.DisplayFormat.FormatString = "N2"
        Me.GridColumnRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRate.FieldName = "cop_kurs"
        Me.GridColumnRate.Name = "GridColumnRate"
        Me.GridColumnRate.OptionsColumn.AllowEdit = False
        Me.GridColumnRate.Visible = True
        Me.GridColumnRate.VisibleIndex = 5
        '
        'GridColumnCOP
        '
        Me.GridColumnCOP.Caption = "COP"
        Me.GridColumnCOP.DisplayFormat.FormatString = "N2"
        Me.GridColumnCOP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCOP.FieldName = "cop_value"
        Me.GridColumnCOP.Name = "GridColumnCOP"
        Me.GridColumnCOP.OptionsColumn.AllowEdit = False
        Me.GridColumnCOP.Visible = True
        Me.GridColumnCOP.VisibleIndex = 6
        '
        'GridColumnCOPMngKurs
        '
        Me.GridColumnCOPMngKurs.Caption = "Manag. Rate"
        Me.GridColumnCOPMngKurs.DisplayFormat.FormatString = "N2"
        Me.GridColumnCOPMngKurs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCOPMngKurs.FieldName = "cop_mng_kurs"
        Me.GridColumnCOPMngKurs.Name = "GridColumnCOPMngKurs"
        Me.GridColumnCOPMngKurs.OptionsColumn.AllowEdit = False
        Me.GridColumnCOPMngKurs.Visible = True
        Me.GridColumnCOPMngKurs.VisibleIndex = 7
        '
        'GridColumnCOPMgn
        '
        Me.GridColumnCOPMgn.Caption = "COP Manag. Rate"
        Me.GridColumnCOPMgn.DisplayFormat.FormatString = "N2"
        Me.GridColumnCOPMgn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCOPMgn.FieldName = "cop_mng_value"
        Me.GridColumnCOPMgn.Name = "GridColumnCOPMgn"
        Me.GridColumnCOPMgn.OptionsColumn.AllowEdit = False
        Me.GridColumnCOPMgn.Visible = True
        Me.GridColumnCOPMgn.VisibleIndex = 8
        '
        'FormFGProposePriceCOPList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 428)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelNav)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormFGProposePriceCOPList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "COP List"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelNav.ResumeLayout(False)
        Me.PanelNav.PerformLayout()
        CType(Me.LEDivision.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LESource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPDD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstyle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnClass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnCOPStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRateType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCOP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCOPMngKurs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCOPMgn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LESource As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEDivision As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnViewList As DevExpress.XtraEditors.SimpleButton
End Class
