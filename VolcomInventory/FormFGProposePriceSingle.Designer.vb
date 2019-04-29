<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGProposePriceSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGProposePriceSingle))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.CESelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
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
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncop_rate_cat_display = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CESelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.CESelAll)
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 378)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'CESelAll
        '
        Me.CESelAll.Location = New System.Drawing.Point(12, 15)
        Me.CESelAll.Name = "CESelAll"
        Me.CESelAll.Properties.Caption = "Select All"
        Me.CESelAll.Size = New System.Drawing.Size(75, 19)
        Me.CESelAll.TabIndex = 2
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(605, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(88, 42)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(693, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(89, 42)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "Add"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCData.Size = New System.Drawing.Size(784, 378)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdDesign, Me.GridColumnIdPDD, Me.GridColumnCode, Me.GridColumnstyle, Me.GridColumnClass, Me.GridColumnIsSelect, Me.GridColumnCOPStatus, Me.GridColumnRateType, Me.GridColumnRate, Me.GridColumnCOP, Me.GridColumnCOPMngKurs, Me.GridColumnCOPMgn, Me.GridColumnQty, Me.GridColumncop_rate_cat_display})
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
        Me.GridColumnCode.VisibleIndex = 1
        '
        'GridColumnstyle
        '
        Me.GridColumnstyle.Caption = "Style"
        Me.GridColumnstyle.FieldName = "name"
        Me.GridColumnstyle.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnstyle.Name = "GridColumnstyle"
        Me.GridColumnstyle.OptionsColumn.AllowEdit = False
        Me.GridColumnstyle.Visible = True
        Me.GridColumnstyle.VisibleIndex = 2
        '
        'GridColumnClass
        '
        Me.GridColumnClass.Caption = "Class"
        Me.GridColumnClass.FieldName = "class"
        Me.GridColumnClass.Name = "GridColumnClass"
        Me.GridColumnClass.OptionsColumn.AllowEdit = False
        Me.GridColumnClass.Visible = True
        Me.GridColumnClass.VisibleIndex = 3
        '
        'GridColumnIsSelect
        '
        Me.GridColumnIsSelect.Caption = "Select"
        Me.GridColumnIsSelect.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnIsSelect.FieldName = "is_select"
        Me.GridColumnIsSelect.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnIsSelect.Name = "GridColumnIsSelect"
        Me.GridColumnIsSelect.Visible = True
        Me.GridColumnIsSelect.VisibleIndex = 0
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
        Me.GridColumnCOPStatus.VisibleIndex = 5
        '
        'GridColumnRateType
        '
        Me.GridColumnRateType.Caption = "Rate Type"
        Me.GridColumnRateType.FieldName = "cop_rate_cat_display"
        Me.GridColumnRateType.Name = "GridColumnRateType"
        Me.GridColumnRateType.OptionsColumn.AllowEdit = False
        Me.GridColumnRateType.Visible = True
        Me.GridColumnRateType.VisibleIndex = 6
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
        Me.GridColumnRate.VisibleIndex = 7
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
        Me.GridColumnCOP.VisibleIndex = 8
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
        Me.GridColumnCOPMngKurs.VisibleIndex = 9
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
        Me.GridColumnCOPMgn.VisibleIndex = 10
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowEdit = False
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 4
        '
        'GridColumncop_rate_cat_display
        '
        Me.GridColumncop_rate_cat_display.Caption = "cop_rate_cat"
        Me.GridColumncop_rate_cat_display.FieldName = "cop_rate_cat"
        Me.GridColumncop_rate_cat_display.Name = "GridColumncop_rate_cat_display"
        Me.GridColumncop_rate_cat_display.OptionsColumn.AllowEdit = False
        '
        'FormFGProposePriceSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 424)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormFGProposePriceSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Design"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.CESelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPDD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstyle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnClass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CESelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumnCOPStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRateType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCOP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCOPMngKurs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCOPMgn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncop_rate_cat_display As DevExpress.XtraGrid.Columns.GridColumn
End Class
