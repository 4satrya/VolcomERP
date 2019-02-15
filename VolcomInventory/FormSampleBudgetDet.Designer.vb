<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSampleBudgetDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSampleBudgetDet))
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControlTopRight = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DEDateCreated = New DevExpress.XtraEditors.DateEdit()
        Me.TECreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.XTCBeforeAfter = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPBefore = New DevExpress.XtraTab.XtraTabPage()
        Me.GCBefore = New DevExpress.XtraGrid.GridControl()
        Me.GVBefore = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnYear = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnValUsd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnValRp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEBudget = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.XTPAfter = New DevExpress.XtraTab.XtraTabPage()
        Me.GCAfter = New DevExpress.XtraGrid.GridControl()
        Me.GVAfter = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PCAddDelete = New DevExpress.XtraEditors.PanelControl()
        Me.BDel = New DevExpress.XtraEditors.SimpleButton()
        Me.BAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControlTopRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlTopRight.SuspendLayout()
        CType(Me.DEDateCreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDateCreated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCBeforeAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCBeforeAfter.SuspendLayout()
        Me.XTPBefore.SuspendLayout()
        CType(Me.GCBefore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBefore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPAfter.SuspendLayout()
        CType(Me.GCAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAfter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCAddDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCAddDelete.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "10_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "18_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "31_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "folder-documents-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "mail_attachment.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "attachment-icon.png")
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.PanelControlTopRight)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(996, 96)
        Me.PanelControl2.TabIndex = 2
        '
        'PanelControlTopRight
        '
        Me.PanelControlTopRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl2)
        Me.PanelControlTopRight.Controls.Add(Me.DEDateCreated)
        Me.PanelControlTopRight.Controls.Add(Me.TECreatedBy)
        Me.PanelControlTopRight.Controls.Add(Me.TENumber)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl5)
        Me.PanelControlTopRight.Controls.Add(Me.LabelControl7)
        Me.PanelControlTopRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlTopRight.Location = New System.Drawing.Point(664, 2)
        Me.PanelControlTopRight.Name = "PanelControlTopRight"
        Me.PanelControlTopRight.Size = New System.Drawing.Size(330, 92)
        Me.PanelControlTopRight.TabIndex = 8936
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(13, 65)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl2.TabIndex = 159
        Me.LabelControl2.Text = "Requested By"
        '
        'DEDateCreated
        '
        Me.DEDateCreated.EditValue = Nothing
        Me.DEDateCreated.Location = New System.Drawing.Point(113, 10)
        Me.DEDateCreated.Name = "DEDateCreated"
        Me.DEDateCreated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateCreated.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDateCreated.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEDateCreated.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDateCreated.Properties.ReadOnly = True
        Me.DEDateCreated.Size = New System.Drawing.Size(207, 20)
        Me.DEDateCreated.TabIndex = 160
        '
        'TECreatedBy
        '
        Me.TECreatedBy.EditValue = ""
        Me.TECreatedBy.Location = New System.Drawing.Point(113, 62)
        Me.TECreatedBy.Name = "TECreatedBy"
        Me.TECreatedBy.Properties.EditValueChangedDelay = 1
        Me.TECreatedBy.Properties.ReadOnly = True
        Me.TECreatedBy.Size = New System.Drawing.Size(207, 20)
        Me.TECreatedBy.TabIndex = 162
        Me.TECreatedBy.TabStop = False
        '
        'TENumber
        '
        Me.TENumber.EditValue = ""
        Me.TENumber.Location = New System.Drawing.Point(113, 36)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Properties.EditValueChangedDelay = 1
        Me.TENumber.Properties.ReadOnly = True
        Me.TENumber.Size = New System.Drawing.Size(207, 20)
        Me.TENumber.TabIndex = 8
        Me.TENumber.TabStop = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(13, 39)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl5.TabIndex = 155
        Me.LabelControl5.Text = "Number"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(13, 13)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl7.TabIndex = 159
        Me.LabelControl7.Text = "Date Created"
        '
        'XTCBeforeAfter
        '
        Me.XTCBeforeAfter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCBeforeAfter.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCBeforeAfter.Location = New System.Drawing.Point(0, 96)
        Me.XTCBeforeAfter.Name = "XTCBeforeAfter"
        Me.XTCBeforeAfter.SelectedTabPage = Me.XTPBefore
        Me.XTCBeforeAfter.Size = New System.Drawing.Size(996, 341)
        Me.XTCBeforeAfter.TabIndex = 3
        Me.XTCBeforeAfter.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBefore, Me.XTPAfter})
        '
        'XTPBefore
        '
        Me.XTPBefore.Controls.Add(Me.GCBefore)
        Me.XTPBefore.Name = "XTPBefore"
        Me.XTPBefore.Size = New System.Drawing.Size(990, 313)
        Me.XTPBefore.Text = "Before"
        '
        'GCBefore
        '
        Me.GCBefore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBefore.Location = New System.Drawing.Point(0, 0)
        Me.GCBefore.MainView = Me.GVBefore
        Me.GCBefore.Name = "GCBefore"
        Me.GCBefore.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEBudget})
        Me.GCBefore.Size = New System.Drawing.Size(990, 313)
        Me.GCBefore.TabIndex = 6
        Me.GCBefore.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBefore})
        '
        'GVBefore
        '
        Me.GVBefore.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnDesc, Me.GridColumnYear, Me.GridColumn8, Me.GridColumnDivision, Me.GridColumnValUsd, Me.GridColumnValRp})
        Me.GVBefore.GridControl = Me.GCBefore
        Me.GVBefore.Name = "GVBefore"
        Me.GVBefore.OptionsView.ShowGroupPanel = False
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
        Me.GridColumnDesc.FieldName = "description_before"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 0
        Me.GridColumnDesc.Width = 360
        '
        'GridColumnYear
        '
        Me.GridColumnYear.Caption = "Year"
        Me.GridColumnYear.FieldName = "year_before"
        Me.GridColumnYear.Name = "GridColumnYear"
        Me.GridColumnYear.Visible = True
        Me.GridColumnYear.VisibleIndex = 1
        Me.GridColumnYear.Width = 298
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ID Division"
        Me.GridColumn8.FieldName = "id_dvision_before"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumnDivision
        '
        Me.GridColumnDivision.Caption = "Division"
        Me.GridColumnDivision.FieldName = "division_before"
        Me.GridColumnDivision.Name = "GridColumnDivision"
        Me.GridColumnDivision.Visible = True
        Me.GridColumnDivision.VisibleIndex = 2
        Me.GridColumnDivision.Width = 298
        '
        'GridColumnValUsd
        '
        Me.GridColumnValUsd.Caption = "Value USD"
        Me.GridColumnValUsd.DisplayFormat.FormatString = "N2"
        Me.GridColumnValUsd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnValUsd.FieldName = "value_usd_before"
        Me.GridColumnValUsd.Name = "GridColumnValUsd"
        Me.GridColumnValUsd.Visible = True
        Me.GridColumnValUsd.VisibleIndex = 3
        Me.GridColumnValUsd.Width = 298
        '
        'GridColumnValRp
        '
        Me.GridColumnValRp.Caption = "Value Rp"
        Me.GridColumnValRp.DisplayFormat.FormatString = "N2"
        Me.GridColumnValRp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnValRp.FieldName = "value_rp_before"
        Me.GridColumnValRp.Name = "GridColumnValRp"
        Me.GridColumnValRp.Visible = True
        Me.GridColumnValRp.VisibleIndex = 4
        Me.GridColumnValRp.Width = 306
        '
        'RICEBudget
        '
        Me.RICEBudget.AutoHeight = False
        Me.RICEBudget.Name = "RICEBudget"
        Me.RICEBudget.ValueChecked = "yes"
        Me.RICEBudget.ValueUnchecked = "no"
        '
        'XTPAfter
        '
        Me.XTPAfter.Controls.Add(Me.GCAfter)
        Me.XTPAfter.Controls.Add(Me.PCAddDelete)
        Me.XTPAfter.Name = "XTPAfter"
        Me.XTPAfter.Size = New System.Drawing.Size(990, 313)
        Me.XTPAfter.Text = "Propose"
        '
        'GCAfter
        '
        Me.GCAfter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAfter.Location = New System.Drawing.Point(0, 41)
        Me.GCAfter.MainView = Me.GVAfter
        Me.GCAfter.Name = "GCAfter"
        Me.GCAfter.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemDateEdit1})
        Me.GCAfter.Size = New System.Drawing.Size(990, 272)
        Me.GCAfter.TabIndex = 7
        Me.GCAfter.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAfter})
        '
        'GVAfter
        '
        Me.GVAfter.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn7, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6})
        Me.GVAfter.GridControl = Me.GCAfter
        Me.GVAfter.Name = "GVAfter"
        Me.GVAfter.OptionsView.ShowGroupPanel = False
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
        Me.GridColumn2.FieldName = "description_after"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 360
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Year"
        Me.GridColumn3.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.GridColumn3.DisplayFormat.FormatString = "yyyy"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn3.FieldName = "year_after"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 298
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.RepositoryItemDateEdit1.DisplayFormat.FormatString = "yyyy"
        Me.RepositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit1.EditFormat.FormatString = "yyyy"
        Me.RepositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit1.Mask.EditMask = "yyyy"
        Me.RepositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        Me.RepositoryItemDateEdit1.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView
        Me.RepositoryItemDateEdit1.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView
        Me.RepositoryItemDateEdit1.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "ID Division"
        Me.GridColumn7.FieldName = "id_division_after"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Division"
        Me.GridColumn4.FieldName = "division_after"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 298
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Value USD"
        Me.GridColumn5.DisplayFormat.FormatString = "N2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "value_usd_after"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 298
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Value Rp"
        Me.GridColumn6.DisplayFormat.FormatString = "N2"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "value_rp_after"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 306
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'PCAddDelete
        '
        Me.PCAddDelete.Controls.Add(Me.BDel)
        Me.PCAddDelete.Controls.Add(Me.BAdd)
        Me.PCAddDelete.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCAddDelete.Location = New System.Drawing.Point(0, 0)
        Me.PCAddDelete.Name = "PCAddDelete"
        Me.PCAddDelete.Size = New System.Drawing.Size(990, 41)
        Me.PCAddDelete.TabIndex = 8
        '
        'BDel
        '
        Me.BDel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDel.ImageIndex = 1
        Me.BDel.ImageList = Me.LargeImageCollection
        Me.BDel.Location = New System.Drawing.Point(838, 2)
        Me.BDel.Name = "BDel"
        Me.BDel.Size = New System.Drawing.Size(75, 37)
        Me.BDel.TabIndex = 19
        Me.BDel.TabStop = False
        Me.BDel.Text = "Delete"
        '
        'BAdd
        '
        Me.BAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAdd.ImageIndex = 0
        Me.BAdd.ImageList = Me.LargeImageCollection
        Me.BAdd.Location = New System.Drawing.Point(913, 2)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(75, 37)
        Me.BAdd.TabIndex = 18
        Me.BAdd.TabStop = False
        Me.BAdd.Text = "Add"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Controls.Add(Me.BMark)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 437)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(996, 39)
        Me.PanelControl1.TabIndex = 4
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.ImageIndex = 6
        Me.BtnPrint.ImageList = Me.LargeImageCollection
        Me.BtnPrint.Location = New System.Drawing.Point(769, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 35)
        Me.BtnPrint.TabIndex = 18
        Me.BtnPrint.TabStop = False
        Me.BtnPrint.Text = "Print"
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.ImageIndex = 5
        Me.BtnCancel.ImageList = Me.LargeImageCollection
        Me.BtnCancel.Location = New System.Drawing.Point(844, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 35)
        Me.BtnCancel.TabIndex = 19
        Me.BtnCancel.TabStop = False
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.ImageIndex = 7
        Me.BtnSave.ImageList = Me.LargeImageCollection
        Me.BtnSave.Location = New System.Drawing.Point(919, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 35)
        Me.BtnSave.TabIndex = 17
        Me.BtnSave.TabStop = False
        Me.BtnSave.Text = "Save"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.ImageIndex = 4
        Me.BMark.ImageList = Me.LargeImageCollection
        Me.BMark.Location = New System.Drawing.Point(2, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(75, 35)
        Me.BMark.TabIndex = 16
        Me.BMark.TabStop = False
        Me.BMark.Text = "Mark"
        '
        'FormSampleBudgetDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 476)
        Me.Controls.Add(Me.XTCBeforeAfter)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormSampleBudgetDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Propose Sample Budget"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControlTopRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlTopRight.ResumeLayout(False)
        Me.PanelControlTopRight.PerformLayout()
        CType(Me.DEDateCreated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDateCreated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCBeforeAfter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCBeforeAfter.ResumeLayout(False)
        Me.XTPBefore.ResumeLayout(False)
        CType(Me.GCBefore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBefore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEBudget, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPAfter.ResumeLayout(False)
        CType(Me.GCAfter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAfter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCAddDelete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCAddDelete.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControlTopRight As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEDateCreated As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TECreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XTCBeforeAfter As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPBefore As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPAfter As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCBefore As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBefore As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnYear As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnValUsd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnValRp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICEBudget As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GCAfter As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAfter As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PCAddDelete As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BDel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
End Class
