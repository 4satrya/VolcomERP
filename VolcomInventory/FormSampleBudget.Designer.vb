<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleBudget
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DEYearBudget = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.GCBudgetList = New DevExpress.XtraGrid.GridControl()
        Me.GVBudgetList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEBudget = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnYear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnValUsd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnValRp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BRevision = New DevExpress.XtraEditors.SimpleButton()
        Me.BNewBudget = New DevExpress.XtraEditors.SimpleButton()
        Me.XTCSampleBudget = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPBudget = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPProposal = New DevExpress.XtraTab.XtraTabPage()
        Me.GCProposeList = New DevExpress.XtraGrid.GridControl()
        Me.GVProposeList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEYearBudget.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEYearBudget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCBudgetList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBudgetList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.XTCSampleBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCSampleBudget.SuspendLayout()
        Me.XTPBudget.SuspendLayout()
        Me.XTPProposal.SuspendLayout()
        CType(Me.GCProposeList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProposeList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.DEYearBudget)
        Me.PanelControl1.Controls.Add(Me.LabelControl6)
        Me.PanelControl1.Controls.Add(Me.BSearch)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(888, 38)
        Me.PanelControl1.TabIndex = 4
        '
        'DEYearBudget
        '
        Me.DEYearBudget.EditValue = Nothing
        Me.DEYearBudget.Location = New System.Drawing.Point(86, 8)
        Me.DEYearBudget.Name = "DEYearBudget"
        Me.DEYearBudget.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEYearBudget.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEYearBudget.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.DEYearBudget.Properties.DisplayFormat.FormatString = "yyyy"
        Me.DEYearBudget.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEYearBudget.Properties.Mask.EditMask = "yyyy"
        Me.DEYearBudget.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEYearBudget.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView
        Me.DEYearBudget.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView
        Me.DEYearBudget.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.DEYearBudget.Size = New System.Drawing.Size(239, 20)
        Me.DEYearBudget.TabIndex = 8905
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(12, 11)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl6.TabIndex = 8904
        Me.LabelControl6.Text = "Year Budget"
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(331, 6)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(59, 23)
        Me.BSearch.TabIndex = 8903
        Me.BSearch.Text = "Search"
        '
        'GCBudgetList
        '
        Me.GCBudgetList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBudgetList.Location = New System.Drawing.Point(0, 38)
        Me.GCBudgetList.MainView = Me.GVBudgetList
        Me.GCBudgetList.Name = "GCBudgetList"
        Me.GCBudgetList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEBudget})
        Me.GCBudgetList.Size = New System.Drawing.Size(888, 346)
        Me.GCBudgetList.TabIndex = 5
        Me.GCBudgetList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBudgetList})
        '
        'GVBudgetList
        '
        Me.GVBudgetList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumnId, Me.GridColumnDesc, Me.GridColumnYear, Me.GridColumnDivision, Me.GridColumnValUsd, Me.GridColumnValRp, Me.GridColumn8})
        Me.GVBudgetList.GridControl = Me.GCBudgetList
        Me.GVBudgetList.Name = "GVBudgetList"
        Me.GVBudgetList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn7.Caption = "*"
        Me.GridColumn7.ColumnEdit = Me.RICEBudget
        Me.GridColumn7.FieldName = "is_check"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        Me.GridColumn7.Width = 36
        '
        'RICEBudget
        '
        Me.RICEBudget.AutoHeight = False
        Me.RICEBudget.Name = "RICEBudget"
        Me.RICEBudget.ValueChecked = "yes"
        Me.RICEBudget.ValueUnchecked = "no"
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_sample_purc_budget"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumnDesc
        '
        Me.GridColumnDesc.Caption = "Description"
        Me.GridColumnDesc.FieldName = "description"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 1
        Me.GridColumnDesc.Width = 183
        '
        'GridColumnYear
        '
        Me.GridColumnYear.Caption = "Year"
        Me.GridColumnYear.FieldName = "year"
        Me.GridColumnYear.Name = "GridColumnYear"
        Me.GridColumnYear.Visible = True
        Me.GridColumnYear.VisibleIndex = 2
        Me.GridColumnYear.Width = 151
        '
        'GridColumnDivision
        '
        Me.GridColumnDivision.Caption = "Division"
        Me.GridColumnDivision.FieldName = "division"
        Me.GridColumnDivision.Name = "GridColumnDivision"
        Me.GridColumnDivision.Visible = True
        Me.GridColumnDivision.VisibleIndex = 3
        Me.GridColumnDivision.Width = 151
        '
        'GridColumnValUsd
        '
        Me.GridColumnValUsd.Caption = "Value USD"
        Me.GridColumnValUsd.DisplayFormat.FormatString = "N2"
        Me.GridColumnValUsd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnValUsd.FieldName = "value_usd"
        Me.GridColumnValUsd.Name = "GridColumnValUsd"
        Me.GridColumnValUsd.Visible = True
        Me.GridColumnValUsd.VisibleIndex = 4
        Me.GridColumnValUsd.Width = 151
        '
        'GridColumnValRp
        '
        Me.GridColumnValRp.Caption = "Value Rp"
        Me.GridColumnValRp.DisplayFormat.FormatString = "N2"
        Me.GridColumnValRp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnValRp.FieldName = "value_rp"
        Me.GridColumnValRp.Name = "GridColumnValRp"
        Me.GridColumnValRp.Visible = True
        Me.GridColumnValRp.VisibleIndex = 5
        Me.GridColumnValRp.Width = 130
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.Caption = "On Going Revision"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        Me.GridColumn8.Width = 68
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BRevision)
        Me.PanelControl2.Controls.Add(Me.BNewBudget)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 384)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(888, 71)
        Me.PanelControl2.TabIndex = 6
        '
        'BRevision
        '
        Me.BRevision.Appearance.BackColor = System.Drawing.Color.Tomato
        Me.BRevision.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BRevision.Appearance.ForeColor = System.Drawing.Color.White
        Me.BRevision.Appearance.Options.UseBackColor = True
        Me.BRevision.Appearance.Options.UseFont = True
        Me.BRevision.Appearance.Options.UseForeColor = True
        Me.BRevision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BRevision.Location = New System.Drawing.Point(2, 2)
        Me.BRevision.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BRevision.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BRevision.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BRevision.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BRevision.Name = "BRevision"
        Me.BRevision.Size = New System.Drawing.Size(884, 35)
        Me.BRevision.TabIndex = 14
        Me.BRevision.Text = "Revise Budget"
        '
        'BNewBudget
        '
        Me.BNewBudget.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BNewBudget.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BNewBudget.Appearance.ForeColor = System.Drawing.Color.White
        Me.BNewBudget.Appearance.Options.UseBackColor = True
        Me.BNewBudget.Appearance.Options.UseFont = True
        Me.BNewBudget.Appearance.Options.UseForeColor = True
        Me.BNewBudget.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BNewBudget.Location = New System.Drawing.Point(2, 37)
        Me.BNewBudget.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BNewBudget.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BNewBudget.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BNewBudget.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BNewBudget.Name = "BNewBudget"
        Me.BNewBudget.Size = New System.Drawing.Size(884, 32)
        Me.BNewBudget.TabIndex = 13
        Me.BNewBudget.Text = "Propose New Budget"
        '
        'XTCSampleBudget
        '
        Me.XTCSampleBudget.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCSampleBudget.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCSampleBudget.Location = New System.Drawing.Point(0, 0)
        Me.XTCSampleBudget.Name = "XTCSampleBudget"
        Me.XTCSampleBudget.SelectedTabPage = Me.XTPBudget
        Me.XTCSampleBudget.Size = New System.Drawing.Size(894, 483)
        Me.XTCSampleBudget.TabIndex = 7
        Me.XTCSampleBudget.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBudget, Me.XTPProposal})
        '
        'XTPBudget
        '
        Me.XTPBudget.Controls.Add(Me.GCBudgetList)
        Me.XTPBudget.Controls.Add(Me.PanelControl1)
        Me.XTPBudget.Controls.Add(Me.PanelControl2)
        Me.XTPBudget.Name = "XTPBudget"
        Me.XTPBudget.Size = New System.Drawing.Size(888, 455)
        Me.XTPBudget.Text = "List Budget"
        '
        'XTPProposal
        '
        Me.XTPProposal.Controls.Add(Me.GCProposeList)
        Me.XTPProposal.Controls.Add(Me.PanelControl3)
        Me.XTPProposal.Name = "XTPProposal"
        Me.XTPProposal.Size = New System.Drawing.Size(888, 455)
        Me.XTPProposal.Text = "List Proposal"
        '
        'GCProposeList
        '
        Me.GCProposeList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProposeList.Location = New System.Drawing.Point(0, 38)
        Me.GCProposeList.MainView = Me.GVProposeList
        Me.GCProposeList.Name = "GCProposeList"
        Me.GCProposeList.Size = New System.Drawing.Size(888, 417)
        Me.GCProposeList.TabIndex = 6
        Me.GCProposeList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProposeList})
        '
        'GVProposeList
        '
        Me.GVProposeList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GVProposeList.GridControl = Me.GCProposeList
        Me.GVProposeList.Name = "GVProposeList"
        Me.GVProposeList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id"
        Me.GridColumn1.FieldName = "id_sample_purc_budget"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Description"
        Me.GridColumn2.FieldName = "description"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 203
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Year"
        Me.GridColumn3.FieldName = "year"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 168
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Division"
        Me.GridColumn4.FieldName = "division"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 168
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Value USD"
        Me.GridColumn5.DisplayFormat.FormatString = "N2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "value_usd"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 168
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Value Rp"
        Me.GridColumn6.DisplayFormat.FormatString = "N2"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "value_rp"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 169
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.DEUntil)
        Me.PanelControl3.Controls.Add(Me.Label2)
        Me.PanelControl3.Controls.Add(Me.DEStart)
        Me.PanelControl3.Controls.Add(Me.Label1)
        Me.PanelControl3.Controls.Add(Me.SimpleButton1)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(888, 38)
        Me.PanelControl3.TabIndex = 5
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(235, 9)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Size = New System.Drawing.Size(127, 20)
        Me.DEUntil.TabIndex = 8907
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(191, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 8906
        Me.Label2.Text = "Until : "
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(58, 9)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Size = New System.Drawing.Size(127, 20)
        Me.DEStart.TabIndex = 8905
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 8904
        Me.Label1.Text = "From : "
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(368, 7)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(59, 23)
        Me.SimpleButton1.TabIndex = 8903
        Me.SimpleButton1.Text = "Search"
        '
        'FormSampleBudget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 483)
        Me.Controls.Add(Me.XTCSampleBudget)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSampleBudget"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sample Budget"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEYearBudget.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEYearBudget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCBudgetList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBudgetList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEBudget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.XTCSampleBudget, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCSampleBudget.ResumeLayout(False)
        Me.XTPBudget.ResumeLayout(False)
        Me.XTPProposal.ResumeLayout(False)
        CType(Me.GCProposeList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProposeList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEYearBudget As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCBudgetList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBudgetList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnYear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnValUsd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnValRp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BRevision As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BNewBudget As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTCSampleBudget As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPBudget As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPProposal As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents GCProposeList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProposeList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICEBudget As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
End Class
