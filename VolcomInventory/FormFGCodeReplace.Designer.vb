<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormFGCodeReplace
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGCodeReplace))
        Me.XTCFGCodeReplace = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPFGCodeReplaceStore = New DevExpress.XtraTab.XtraTabPage()
        Me.GCFGCodeReplaceStore = New DevExpress.XtraGrid.GridControl()
        Me.GVFGCodeReplaceStore = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICECheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVerifiedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVerifiedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BViewUnique = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.XTPFGCodeReplaceWH = New DevExpress.XtraTab.XtraTabPage()
        Me.GCFGCodeReplaceWH = New DevExpress.XtraGrid.GridControl()
        Me.GVFGCodeReplaceWH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCFGCodeReplace, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCFGCodeReplace.SuspendLayout()
        Me.XTPFGCodeReplaceStore.SuspendLayout()
        CType(Me.GCFGCodeReplaceStore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFGCodeReplaceStore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPFGCodeReplaceWH.SuspendLayout()
        CType(Me.GCFGCodeReplaceWH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFGCodeReplaceWH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCFGCodeReplace
        '
        Me.XTCFGCodeReplace.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCFGCodeReplace.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCFGCodeReplace.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal
        Me.XTCFGCodeReplace.Location = New System.Drawing.Point(0, 0)
        Me.XTCFGCodeReplace.Name = "XTCFGCodeReplace"
        Me.XTCFGCodeReplace.SelectedTabPage = Me.XTPFGCodeReplaceStore
        Me.XTCFGCodeReplace.Size = New System.Drawing.Size(707, 453)
        Me.XTCFGCodeReplace.TabIndex = 0
        Me.XTCFGCodeReplace.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPFGCodeReplaceStore, Me.XTPFGCodeReplaceWH})
        '
        'XTPFGCodeReplaceStore
        '
        Me.XTPFGCodeReplaceStore.Controls.Add(Me.GCFGCodeReplaceStore)
        Me.XTPFGCodeReplaceStore.Controls.Add(Me.PanelControl1)
        Me.XTPFGCodeReplaceStore.Name = "XTPFGCodeReplaceStore"
        Me.XTPFGCodeReplaceStore.Size = New System.Drawing.Size(657, 447)
        Me.XTPFGCodeReplaceStore.Text = "List"
        '
        'GCFGCodeReplaceStore
        '
        Me.GCFGCodeReplaceStore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFGCodeReplaceStore.Location = New System.Drawing.Point(0, 43)
        Me.GCFGCodeReplaceStore.MainView = Me.GVFGCodeReplaceStore
        Me.GCFGCodeReplaceStore.Name = "GCFGCodeReplaceStore"
        Me.GCFGCodeReplaceStore.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICECheck})
        Me.GCFGCodeReplaceStore.Size = New System.Drawing.Size(657, 404)
        Me.GCFGCodeReplaceStore.TabIndex = 0
        Me.GCFGCodeReplaceStore.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFGCodeReplaceStore})
        '
        'GVFGCodeReplaceStore
        '
        Me.GVFGCodeReplaceStore.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.GridColumnNumber, Me.GridColumnDate, Me.GridColumnStatus, Me.GridColumnVerifiedBy, Me.GridColumnVerifiedDate})
        Me.GVFGCodeReplaceStore.GridControl = Me.GCFGCodeReplaceStore
        Me.GVFGCodeReplaceStore.Name = "GVFGCodeReplaceStore"
        Me.GVFGCodeReplaceStore.OptionsView.ShowGroupPanel = False
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.Caption = "*"
        Me.GridColumn4.ColumnEdit = Me.RICECheck
        Me.GridColumn4.FieldName = "is_check"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'RICECheck
        '
        Me.RICECheck.AutoHeight = False
        Me.RICECheck.Name = "RICECheck"
        Me.RICECheck.ValueChecked = "yes"
        Me.RICECheck.ValueUnchecked = "no"
        '
        'GridColumnNumber
        '
        Me.GridColumnNumber.Caption = "Number"
        Me.GridColumnNumber.FieldName = "fg_code_replace_store_number"
        Me.GridColumnNumber.Name = "GridColumnNumber"
        Me.GridColumnNumber.OptionsColumn.AllowEdit = False
        Me.GridColumnNumber.Visible = True
        Me.GridColumnNumber.VisibleIndex = 1
        Me.GridColumnNumber.Width = 326
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Date"
        Me.GridColumnDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDate.FieldName = "fg_code_replace_store_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.OptionsColumn.AllowEdit = False
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 2
        Me.GridColumnDate.Width = 326
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.OptionsColumn.AllowEdit = False
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 3
        Me.GridColumnStatus.Width = 326
        '
        'GridColumnVerifiedBy
        '
        Me.GridColumnVerifiedBy.Caption = "Verified By"
        Me.GridColumnVerifiedBy.FieldName = "verified_by_name"
        Me.GridColumnVerifiedBy.Name = "GridColumnVerifiedBy"
        Me.GridColumnVerifiedBy.OptionsColumn.AllowEdit = False
        Me.GridColumnVerifiedBy.Visible = True
        Me.GridColumnVerifiedBy.VisibleIndex = 5
        Me.GridColumnVerifiedBy.Width = 448
        '
        'GridColumnVerifiedDate
        '
        Me.GridColumnVerifiedDate.Caption = "Verified Date"
        Me.GridColumnVerifiedDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnVerifiedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnVerifiedDate.FieldName = "verified_date"
        Me.GridColumnVerifiedDate.Name = "GridColumnVerifiedDate"
        Me.GridColumnVerifiedDate.OptionsColumn.AllowEdit = False
        Me.GridColumnVerifiedDate.Visible = True
        Me.GridColumnVerifiedDate.VisibleIndex = 4
        Me.GridColumnVerifiedDate.Width = 206
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BViewUnique)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(657, 43)
        Me.PanelControl1.TabIndex = 1
        '
        'BViewUnique
        '
        Me.BViewUnique.Dock = System.Windows.Forms.DockStyle.Right
        Me.BViewUnique.Image = CType(resources.GetObject("BViewUnique.Image"), System.Drawing.Image)
        Me.BViewUnique.ImageIndex = 13
        Me.BViewUnique.ImageList = Me.LargeImageCollection
        Me.BViewUnique.Location = New System.Drawing.Point(518, 2)
        Me.BViewUnique.Name = "BViewUnique"
        Me.BViewUnique.Size = New System.Drawing.Size(137, 39)
        Me.BViewUnique.TabIndex = 25
        Me.BViewUnique.Text = "View Unique List"
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
        'XTPFGCodeReplaceWH
        '
        Me.XTPFGCodeReplaceWH.Controls.Add(Me.GCFGCodeReplaceWH)
        Me.XTPFGCodeReplaceWH.Name = "XTPFGCodeReplaceWH"
        Me.XTPFGCodeReplaceWH.PageVisible = False
        Me.XTPFGCodeReplaceWH.Size = New System.Drawing.Size(657, 447)
        Me.XTPFGCodeReplaceWH.Text = "In WH"
        '
        'GCFGCodeReplaceWH
        '
        Me.GCFGCodeReplaceWH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFGCodeReplaceWH.Location = New System.Drawing.Point(0, 0)
        Me.GCFGCodeReplaceWH.MainView = Me.GVFGCodeReplaceWH
        Me.GCFGCodeReplaceWH.Name = "GCFGCodeReplaceWH"
        Me.GCFGCodeReplaceWH.Size = New System.Drawing.Size(657, 447)
        Me.GCFGCodeReplaceWH.TabIndex = 1
        Me.GCFGCodeReplaceWH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFGCodeReplaceWH})
        '
        'GVFGCodeReplaceWH
        '
        Me.GVFGCodeReplaceWH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GVFGCodeReplaceWH.GridControl = Me.GCFGCodeReplaceWH
        Me.GVFGCodeReplaceWH.Name = "GVFGCodeReplaceWH"
        Me.GVFGCodeReplaceWH.OptionsBehavior.ReadOnly = True
        Me.GVFGCodeReplaceWH.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Number"
        Me.GridColumn1.FieldName = "fg_code_replace_wh_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Date"
        Me.GridColumn2.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn2.FieldName = "fg_code_replace_wh_date"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Status"
        Me.GridColumn3.FieldName = "report_status"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'FormFGCodeReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 453)
        Me.Controls.Add(Me.XTCFGCodeReplace)
        Me.Name = "FormFGCodeReplace"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Finished Goods Code Replacement"
        CType(Me.XTCFGCodeReplace, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCFGCodeReplace.ResumeLayout(False)
        Me.XTPFGCodeReplaceStore.ResumeLayout(False)
        CType(Me.GCFGCodeReplaceStore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFGCodeReplaceStore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPFGCodeReplaceWH.ResumeLayout(False)
        CType(Me.GCFGCodeReplaceWH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFGCodeReplaceWH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCFGCodeReplace As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPFGCodeReplaceStore As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPFGCodeReplaceWH As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCFGCodeReplaceStore As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFGCodeReplaceStore As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCFGCodeReplaceWH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFGCodeReplaceWH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVerifiedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVerifiedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICECheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BViewUnique As DevExpress.XtraEditors.SimpleButton
End Class
