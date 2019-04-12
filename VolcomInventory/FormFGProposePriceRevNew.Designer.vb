<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGProposePriceRevNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGProposePriceRevNew))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtMarkup = New DevExpress.XtraEditors.TextEdit()
        Me.LEDivision = New DevExpress.XtraEditors.LookUpEdit()
        Me.LESource = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GCFGPropose = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVFGPropose = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnFGProposeNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSource = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrcTyp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumnPPType = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TxtMarkup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDivision.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LESource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCFGPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVFGPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnOK)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 421)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(734, 43)
        Me.PanelControl1.TabIndex = 1
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(574, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(83, 39)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnOK
        '
        Me.BtnOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(657, 2)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(75, 39)
        Me.BtnOK.TabIndex = 1
        Me.BtnOK.Text = "OK"
        '
        'BSearch
        '
        Me.BSearch.Image = CType(resources.GetObject("BSearch.Image"), System.Drawing.Image)
        Me.BSearch.Location = New System.Drawing.Point(514, 26)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(66, 23)
        Me.BSearch.TabIndex = 8906
        Me.BSearch.Text = "Search"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LabelControl6)
        Me.PanelControl2.Controls.Add(Me.BSearch)
        Me.PanelControl2.Controls.Add(Me.TxtMarkup)
        Me.PanelControl2.Controls.Add(Me.LEDivision)
        Me.PanelControl2.Controls.Add(Me.LESource)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.SLESeason)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(734, 59)
        Me.PanelControl2.TabIndex = 8907
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(396, 11)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl6.TabIndex = 8914
        Me.LabelControl6.Text = "Mark Up Target"
        '
        'TxtMarkup
        '
        Me.TxtMarkup.Enabled = False
        Me.TxtMarkup.Location = New System.Drawing.Point(396, 28)
        Me.TxtMarkup.Name = "TxtMarkup"
        Me.TxtMarkup.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtMarkup.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtMarkup.Properties.Mask.EditMask = "N2"
        Me.TxtMarkup.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtMarkup.Size = New System.Drawing.Size(112, 20)
        Me.TxtMarkup.TabIndex = 8913
        '
        'LEDivision
        '
        Me.LEDivision.Location = New System.Drawing.Point(170, 28)
        Me.LEDivision.Name = "LEDivision"
        Me.LEDivision.Properties.Appearance.Options.UseTextOptions = True
        Me.LEDivision.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEDivision.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDivision.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_code_detail", "ID Division", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("display_name", "Display Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_detail_name", "Division")})
        Me.LEDivision.Properties.NullText = ""
        Me.LEDivision.Properties.ShowFooter = False
        Me.LEDivision.Size = New System.Drawing.Size(97, 20)
        Me.LEDivision.TabIndex = 8911
        '
        'LESource
        '
        Me.LESource.Location = New System.Drawing.Point(273, 28)
        Me.LESource.Name = "LESource"
        Me.LESource.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESource.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_source", "Id Code Detail", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("display_name", "Display Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("source", "Source")})
        Me.LESource.Properties.NullText = "- Select Product Source -"
        Me.LESource.Size = New System.Drawing.Size(117, 20)
        Me.LESource.TabIndex = 8912
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(273, 11)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl2.TabIndex = 8911
        Me.LabelControl2.Text = "Source"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(170, 11)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl4.TabIndex = 8910
        Me.LabelControl4.Text = "Division"
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(12, 28)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.ShowClearButton = False
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(154, 20)
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
        Me.LabelControl1.Location = New System.Drawing.Point(12, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 8909
        Me.LabelControl1.Text = "Season"
        '
        'GCFGPropose
        '
        Me.GCFGPropose.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCFGPropose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFGPropose.Location = New System.Drawing.Point(0, 59)
        Me.GCFGPropose.MainView = Me.GVFGPropose
        Me.GCFGPropose.Name = "GCFGPropose"
        Me.GCFGPropose.Size = New System.Drawing.Size(734, 262)
        Me.GCFGPropose.TabIndex = 8908
        Me.GCFGPropose.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFGPropose})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(131, 26)
        '
        'ViewDetailToolStripMenuItem
        '
        Me.ViewDetailToolStripMenuItem.Name = "ViewDetailToolStripMenuItem"
        Me.ViewDetailToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.ViewDetailToolStripMenuItem.Text = "view detail"
        '
        'GVFGPropose
        '
        Me.GVFGPropose.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnFGProposeNumber, Me.GridColumnSeason, Me.GridColumnSource, Me.GridColumnCreatedDate, Me.GridColumnDivision, Me.GridColumnStatus, Me.GridColumnPrcTyp, Me.GridColumnPPType})
        Me.GVFGPropose.GridControl = Me.GCFGPropose
        Me.GVFGPropose.Name = "GVFGPropose"
        Me.GVFGPropose.OptionsBehavior.ReadOnly = True
        Me.GVFGPropose.OptionsFind.AlwaysVisible = True
        Me.GVFGPropose.OptionsView.ShowGroupPanel = False
        '
        'GridColumnFGProposeNumber
        '
        Me.GridColumnFGProposeNumber.Caption = "Number"
        Me.GridColumnFGProposeNumber.FieldName = "fg_propose_price_number"
        Me.GridColumnFGProposeNumber.Name = "GridColumnFGProposeNumber"
        Me.GridColumnFGProposeNumber.Visible = True
        Me.GridColumnFGProposeNumber.VisibleIndex = 0
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.FieldNameSortGroup = "id_season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 2
        '
        'GridColumnSource
        '
        Me.GridColumnSource.Caption = "Source"
        Me.GridColumnSource.FieldName = "source"
        Me.GridColumnSource.FieldNameSortGroup = "id_source"
        Me.GridColumnSource.Name = "GridColumnSource"
        Me.GridColumnSource.Visible = True
        Me.GridColumnSource.VisibleIndex = 3
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "fg_propose_price_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 5
        '
        'GridColumnDivision
        '
        Me.GridColumnDivision.Caption = "Division"
        Me.GridColumnDivision.FieldName = "division"
        Me.GridColumnDivision.FieldNameSortGroup = "id_division"
        Me.GridColumnDivision.Name = "GridColumnDivision"
        Me.GridColumnDivision.Visible = True
        Me.GridColumnDivision.VisibleIndex = 4
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.FieldNameSortGroup = "id_report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        '
        'GridColumnPrcTyp
        '
        Me.GridColumnPrcTyp.Caption = "Price Type"
        Me.GridColumnPrcTyp.FieldName = "design_price_type"
        Me.GridColumnPrcTyp.Name = "GridColumnPrcTyp"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.LabelControl3)
        Me.PanelControl3.Controls.Add(Me.TxtNumber)
        Me.PanelControl3.Controls.Add(Me.MENote)
        Me.PanelControl3.Controls.Add(Me.LabelControl5)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 321)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(734, 100)
        Me.PanelControl3.TabIndex = 8910
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(21, 15)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Number"
        '
        'TxtNumber
        '
        Me.TxtNumber.Enabled = False
        Me.TxtNumber.Location = New System.Drawing.Point(87, 12)
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.Size = New System.Drawing.Size(566, 20)
        Me.TxtNumber.TabIndex = 3
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(87, 38)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(566, 46)
        Me.MENote.TabIndex = 2
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(21, 40)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl5.TabIndex = 2
        Me.LabelControl5.Text = "Note"
        '
        'GridColumnPPType
        '
        Me.GridColumnPPType.Caption = "Type"
        Me.GridColumnPPType.FieldName = "pp_type"
        Me.GridColumnPPType.Name = "GridColumnPPType"
        Me.GridColumnPPType.Visible = True
        Me.GridColumnPPType.VisibleIndex = 1
        '
        'FormFGProposePriceRevNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 464)
        Me.Controls.Add(Me.GCFGPropose)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFGProposePriceRevNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New - Propose Price Revision"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.TxtMarkup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDivision.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LESource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCFGPropose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVFGPropose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.TxtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LEDivision As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LESource As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCFGPropose As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFGPropose As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnFGProposeNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSource As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrcTyp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ViewDetailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtMarkup As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridColumnPPType As DevExpress.XtraGrid.Columns.GridColumn
End Class
