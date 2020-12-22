<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOLStoreRestock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOLStoreRestock))
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPOnlineWH = New DevExpress.XtraTab.XtraTabPage()
        Me.GCOnlineWH = New DevExpress.XtraGrid.GridControl()
        Me.GVOnlineWH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_wh_drawer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_stock = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoSP = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.BCreatePO = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPOtherWH = New DevExpress.XtraTab.XtraTabPage()
        Me.GCWH = New DevExpress.XtraGrid.GridControl()
        Me.GVWH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BCreateOther = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnPrintWH = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnRefreshOther = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSize = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtDescription = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.XTCOLWH = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPOLWHDirect = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPOLWHSyncSellerCenter = New DevExpress.XtraTab.XtraTabPage()
        Me.GCWHSync = New DevExpress.XtraGrid.GridControl()
        Me.GVWHSync = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnPrepareOrder = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPOnlineWH.SuspendLayout()
        CType(Me.GCOnlineWH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOnlineWH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoSP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.XTPOtherWH.SuspendLayout()
        CType(Me.GCWH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVWH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCOLWH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCOLWH.SuspendLayout()
        Me.XTPOLWHDirect.SuspendLayout()
        Me.XTPOLWHSyncSellerCenter.SuspendLayout()
        CType(Me.GCWHSync, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVWHSync, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCData.Location = New System.Drawing.Point(0, 72)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPOnlineWH
        Me.XTCData.Size = New System.Drawing.Size(734, 389)
        Me.XTCData.TabIndex = 0
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPOnlineWH, Me.XTPOtherWH})
        '
        'XTPOnlineWH
        '
        Me.XTPOnlineWH.Controls.Add(Me.XTCOLWH)
        Me.XTPOnlineWH.Controls.Add(Me.PanelControl2)
        Me.XTPOnlineWH.Name = "XTPOnlineWH"
        Me.XTPOnlineWH.Size = New System.Drawing.Size(728, 361)
        Me.XTPOnlineWH.Text = "Online WH"
        '
        'GCOnlineWH
        '
        Me.GCOnlineWH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOnlineWH.Location = New System.Drawing.Point(0, 0)
        Me.GCOnlineWH.MainView = Me.GVOnlineWH
        Me.GCOnlineWH.Name = "GCOnlineWH"
        Me.GCOnlineWH.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoSP})
        Me.GCOnlineWH.Size = New System.Drawing.Size(699, 279)
        Me.GCOnlineWH.TabIndex = 0
        Me.GCOnlineWH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOnlineWH})
        '
        'GVOnlineWH
        '
        Me.GVOnlineWH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_wh_drawer, Me.GridColumnid_comp, Me.GridColumncomp_number, Me.GridColumncomp_name, Me.GridColumntotal_stock, Me.GridColumntotal_order, Me.GridColumnnote})
        Me.GVOnlineWH.GridControl = Me.GCOnlineWH
        Me.GVOnlineWH.Name = "GVOnlineWH"
        Me.GVOnlineWH.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVOnlineWH.OptionsFind.AlwaysVisible = True
        Me.GVOnlineWH.OptionsView.ColumnAutoWidth = False
        Me.GVOnlineWH.OptionsView.ShowFooter = True
        Me.GVOnlineWH.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_wh_drawer
        '
        Me.GridColumnid_wh_drawer.Caption = "id_wh_drawer"
        Me.GridColumnid_wh_drawer.FieldName = "id_wh_drawer"
        Me.GridColumnid_wh_drawer.Name = "GridColumnid_wh_drawer"
        Me.GridColumnid_wh_drawer.OptionsColumn.ReadOnly = True
        '
        'GridColumnid_comp
        '
        Me.GridColumnid_comp.Caption = "id_comp"
        Me.GridColumnid_comp.FieldName = "id_comp"
        Me.GridColumnid_comp.Name = "GridColumnid_comp"
        Me.GridColumnid_comp.OptionsColumn.ReadOnly = True
        '
        'GridColumncomp_number
        '
        Me.GridColumncomp_number.Caption = "Account"
        Me.GridColumncomp_number.FieldName = "comp_number"
        Me.GridColumncomp_number.Name = "GridColumncomp_number"
        Me.GridColumncomp_number.OptionsColumn.ReadOnly = True
        Me.GridColumncomp_number.Visible = True
        Me.GridColumncomp_number.VisibleIndex = 1
        '
        'GridColumncomp_name
        '
        Me.GridColumncomp_name.Caption = "Acc. Description"
        Me.GridColumncomp_name.FieldName = "comp_name"
        Me.GridColumncomp_name.Name = "GridColumncomp_name"
        Me.GridColumncomp_name.OptionsColumn.ReadOnly = True
        Me.GridColumncomp_name.Visible = True
        Me.GridColumncomp_name.VisibleIndex = 2
        Me.GridColumncomp_name.Width = 95
        '
        'GridColumntotal_stock
        '
        Me.GridColumntotal_stock.Caption = "Available Qty"
        Me.GridColumntotal_stock.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_stock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_stock.FieldName = "total_stock"
        Me.GridColumntotal_stock.Name = "GridColumntotal_stock"
        Me.GridColumntotal_stock.OptionsColumn.ReadOnly = True
        Me.GridColumntotal_stock.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_stock", "{0:N0}")})
        Me.GridColumntotal_stock.Visible = True
        Me.GridColumntotal_stock.VisibleIndex = 3
        '
        'GridColumntotal_order
        '
        Me.GridColumntotal_order.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumntotal_order.AppearanceCell.Options.UseFont = True
        Me.GridColumntotal_order.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumntotal_order.AppearanceHeader.Options.UseFont = True
        Me.GridColumntotal_order.Caption = "Restock Qty"
        Me.GridColumntotal_order.ColumnEdit = Me.RepoSP
        Me.GridColumntotal_order.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_order.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_order.FieldName = "total_order"
        Me.GridColumntotal_order.Name = "GridColumntotal_order"
        Me.GridColumntotal_order.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_order", "{0:N0}")})
        Me.GridColumntotal_order.Visible = True
        Me.GridColumntotal_order.VisibleIndex = 4
        Me.GridColumntotal_order.Width = 106
        '
        'RepoSP
        '
        Me.RepoSP.AutoHeight = False
        Me.RepoSP.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoSP.DisplayFormat.FormatString = "N0"
        Me.RepoSP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepoSP.Mask.EditMask = "N0"
        Me.RepoSP.MaxValue = New Decimal(New Integer() {-1486618625, 232830643, 0, 0})
        Me.RepoSP.Name = "RepoSP"
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumnnote.Name = "GridColumnnote"
        Me.GridColumnnote.OptionsColumn.ReadOnly = True
        Me.GridColumnnote.Visible = True
        Me.GridColumnnote.VisibleIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnPrint)
        Me.PanelControl2.Controls.Add(Me.BtnRefresh)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(728, 44)
        Me.PanelControl2.TabIndex = 20
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(543, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(83, 40)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "Print"
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnRefresh.Image = CType(resources.GetObject("BtnRefresh.Image"), System.Drawing.Image)
        Me.BtnRefresh.Location = New System.Drawing.Point(626, 2)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(100, 40)
        Me.BtnRefresh.TabIndex = 0
        Me.BtnRefresh.Text = "Refresh"
        '
        'BCreatePO
        '
        Me.BCreatePO.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BCreatePO.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BCreatePO.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCreatePO.Appearance.Options.UseBackColor = True
        Me.BCreatePO.Appearance.Options.UseFont = True
        Me.BCreatePO.Appearance.Options.UseForeColor = True
        Me.BCreatePO.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BCreatePO.Location = New System.Drawing.Point(0, 279)
        Me.BCreatePO.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BCreatePO.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BCreatePO.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BCreatePO.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BCreatePO.Name = "BCreatePO"
        Me.BCreatePO.Size = New System.Drawing.Size(699, 32)
        Me.BCreatePO.TabIndex = 19
        Me.BCreatePO.Text = "Restock"
        '
        'XTPOtherWH
        '
        Me.XTPOtherWH.Controls.Add(Me.GCWH)
        Me.XTPOtherWH.Controls.Add(Me.BCreateOther)
        Me.XTPOtherWH.Controls.Add(Me.PanelControl3)
        Me.XTPOtherWH.Name = "XTPOtherWH"
        Me.XTPOtherWH.Size = New System.Drawing.Size(728, 361)
        Me.XTPOtherWH.Text = "Other WH"
        '
        'GCWH
        '
        Me.GCWH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCWH.Location = New System.Drawing.Point(0, 55)
        Me.GCWH.MainView = Me.GVWH
        Me.GCWH.Name = "GCWH"
        Me.GCWH.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCWH.Size = New System.Drawing.Size(728, 274)
        Me.GCWH.TabIndex = 22
        Me.GCWH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVWH})
        '
        'GVWH
        '
        Me.GVWH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GVWH.GridControl = Me.GCWH
        Me.GVWH.Name = "GVWH"
        Me.GVWH.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVWH.OptionsFind.AlwaysVisible = True
        Me.GVWH.OptionsView.ColumnAutoWidth = False
        Me.GVWH.OptionsView.ShowFooter = True
        Me.GVWH.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "id_wh_drawer"
        Me.GridColumn1.FieldName = "id_wh_drawer"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "id_comp"
        Me.GridColumn2.FieldName = "id_comp"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Account"
        Me.GridColumn3.FieldName = "comp_number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Acc. Description"
        Me.GridColumn4.FieldName = "comp_name"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 95
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Available Qty"
        Me.GridColumn5.DisplayFormat.FormatString = "N0"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "total_stock"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_stock", "{0:N0}")})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn6.AppearanceCell.Options.UseFont = True
        Me.GridColumn6.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn6.AppearanceHeader.Options.UseFont = True
        Me.GridColumn6.Caption = "Restock Qty"
        Me.GridColumn6.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumn6.DisplayFormat.FormatString = "N0"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "total_order"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_order", "{0:N0}")})
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 106
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.DisplayFormat.FormatString = "N0"
        Me.RepositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "N0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1486618625, 232830643, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Note"
        Me.GridColumn7.FieldName = "note"
        Me.GridColumn7.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        '
        'BCreateOther
        '
        Me.BCreateOther.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BCreateOther.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BCreateOther.Appearance.ForeColor = System.Drawing.Color.White
        Me.BCreateOther.Appearance.Options.UseBackColor = True
        Me.BCreateOther.Appearance.Options.UseFont = True
        Me.BCreateOther.Appearance.Options.UseForeColor = True
        Me.BCreateOther.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BCreateOther.Location = New System.Drawing.Point(0, 329)
        Me.BCreateOther.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BCreateOther.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BCreateOther.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BCreateOther.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BCreateOther.Name = "BCreateOther"
        Me.BCreateOther.Size = New System.Drawing.Size(728, 32)
        Me.BCreateOther.TabIndex = 23
        Me.BCreateOther.Text = "Restock"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.PanelControl4)
        Me.PanelControl3.Controls.Add(Me.BtnPrintWH)
        Me.PanelControl3.Controls.Add(Me.BtnRefreshOther)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(728, 55)
        Me.PanelControl3.TabIndex = 21
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.LabelControl5)
        Me.PanelControl4.Controls.Add(Me.LabelControl4)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl4.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl4.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.PanelControl4.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(413, 51)
        Me.PanelControl4.TabIndex = 2
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(60, 12)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(316, 26)
        Me.LabelControl5.TabIndex = 1
        Me.LabelControl5.Text = "Sebelum melakukan restock harap berkoordinasi dengan WH " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "tentang kondisi produk." &
    ""
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(10, 16)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(40, 15)
        Me.LabelControl4.TabIndex = 0
        Me.LabelControl4.Text = "NOTE : "
        '
        'BtnPrintWH
        '
        Me.BtnPrintWH.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrintWH.Image = CType(resources.GetObject("BtnPrintWH.Image"), System.Drawing.Image)
        Me.BtnPrintWH.Location = New System.Drawing.Point(543, 2)
        Me.BtnPrintWH.Name = "BtnPrintWH"
        Me.BtnPrintWH.Size = New System.Drawing.Size(83, 51)
        Me.BtnPrintWH.TabIndex = 1
        Me.BtnPrintWH.Text = "Print"
        '
        'BtnRefreshOther
        '
        Me.BtnRefreshOther.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnRefreshOther.Image = CType(resources.GetObject("BtnRefreshOther.Image"), System.Drawing.Image)
        Me.BtnRefreshOther.Location = New System.Drawing.Point(626, 2)
        Me.BtnRefreshOther.Name = "BtnRefreshOther"
        Me.BtnRefreshOther.Size = New System.Drawing.Size(100, 51)
        Me.BtnRefreshOther.TabIndex = 0
        Me.BtnRefreshOther.Text = "Refresh"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.TxtSize)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.TxtDescription)
        Me.PanelControl1.Controls.Add(Me.TxtCode)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(734, 72)
        Me.PanelControl1.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(446, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 16)
        Me.LabelControl2.TabIndex = 11
        Me.LabelControl2.Text = "Size"
        '
        'TxtSize
        '
        Me.TxtSize.EditValue = ""
        Me.TxtSize.Location = New System.Drawing.Point(446, 34)
        Me.TxtSize.Name = "TxtSize"
        Me.TxtSize.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSize.Properties.Appearance.Options.UseFont = True
        Me.TxtSize.Properties.ReadOnly = True
        Me.TxtSize.Size = New System.Drawing.Size(52, 22)
        Me.TxtSize.TabIndex = 10
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(144, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 16)
        Me.LabelControl1.TabIndex = 9
        Me.LabelControl1.Text = "Description"
        '
        'TxtDescription
        '
        Me.TxtDescription.EditValue = ""
        Me.TxtDescription.Location = New System.Drawing.Point(144, 34)
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Properties.Appearance.Options.UseFont = True
        Me.TxtDescription.Properties.ReadOnly = True
        Me.TxtDescription.Size = New System.Drawing.Size(296, 22)
        Me.TxtDescription.TabIndex = 8
        '
        'TxtCode
        '
        Me.TxtCode.EditValue = ""
        Me.TxtCode.Location = New System.Drawing.Point(12, 34)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCode.Properties.Appearance.Options.UseFont = True
        Me.TxtCode.Properties.ReadOnly = True
        Me.TxtCode.Size = New System.Drawing.Size(126, 22)
        Me.TxtCode.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(29, 16)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "Code"
        '
        'XTCOLWH
        '
        Me.XTCOLWH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCOLWH.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right
        Me.XTCOLWH.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Vertical
        Me.XTCOLWH.Location = New System.Drawing.Point(0, 44)
        Me.XTCOLWH.Name = "XTCOLWH"
        Me.XTCOLWH.SelectedTabPage = Me.XTPOLWHDirect
        Me.XTCOLWH.Size = New System.Drawing.Size(728, 317)
        Me.XTCOLWH.TabIndex = 21
        Me.XTCOLWH.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPOLWHDirect, Me.XTPOLWHSyncSellerCenter})
        '
        'XTPOLWHDirect
        '
        Me.XTPOLWHDirect.Controls.Add(Me.GCOnlineWH)
        Me.XTPOLWHDirect.Controls.Add(Me.BCreatePO)
        Me.XTPOLWHDirect.Name = "XTPOLWHDirect"
        Me.XTPOLWHDirect.Size = New System.Drawing.Size(699, 311)
        Me.XTPOLWHDirect.Text = "Direct"
        '
        'XTPOLWHSyncSellerCenter
        '
        Me.XTPOLWHSyncSellerCenter.Controls.Add(Me.GCWHSync)
        Me.XTPOLWHSyncSellerCenter.Controls.Add(Me.BtnPrepareOrder)
        Me.XTPOLWHSyncSellerCenter.Name = "XTPOLWHSyncSellerCenter"
        Me.XTPOLWHSyncSellerCenter.Size = New System.Drawing.Size(699, 311)
        Me.XTPOLWHSyncSellerCenter.Text = "Sync to Seller Cent."
        '
        'GCWHSync
        '
        Me.GCWHSync.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCWHSync.Location = New System.Drawing.Point(0, 0)
        Me.GCWHSync.MainView = Me.GVWHSync
        Me.GCWHSync.Name = "GCWHSync"
        Me.GCWHSync.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit2})
        Me.GCWHSync.Size = New System.Drawing.Size(699, 279)
        Me.GCWHSync.TabIndex = 1
        Me.GCWHSync.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVWHSync})
        '
        'GVWHSync
        '
        Me.GVWHSync.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14})
        Me.GVWHSync.GridControl = Me.GCWHSync
        Me.GVWHSync.Name = "GVWHSync"
        Me.GVWHSync.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVWHSync.OptionsFind.AlwaysVisible = True
        Me.GVWHSync.OptionsView.ColumnAutoWidth = False
        Me.GVWHSync.OptionsView.ShowFooter = True
        Me.GVWHSync.OptionsView.ShowGroupPanel = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "id_wh_drawer"
        Me.GridColumn8.FieldName = "id_wh_drawer"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "id_comp"
        Me.GridColumn9.FieldName = "id_comp"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Account"
        Me.GridColumn10.FieldName = "comp_number"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.ReadOnly = True
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 1
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Acc. Description"
        Me.GridColumn11.FieldName = "comp_name"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.ReadOnly = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 2
        Me.GridColumn11.Width = 95
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Available Qty"
        Me.GridColumn12.DisplayFormat.FormatString = "N0"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "total_stock"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.ReadOnly = True
        Me.GridColumn12.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_stock", "{0:N0}")})
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 3
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn13.AppearanceCell.Options.UseFont = True
        Me.GridColumn13.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumn13.AppearanceHeader.Options.UseFont = True
        Me.GridColumn13.Caption = "Qty"
        Me.GridColumn13.ColumnEdit = Me.RepositoryItemSpinEdit2
        Me.GridColumn13.DisplayFormat.FormatString = "N0"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "total_order"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_order", "{0:N0}")})
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 4
        Me.GridColumn13.Width = 106
        '
        'RepositoryItemSpinEdit2
        '
        Me.RepositoryItemSpinEdit2.AutoHeight = False
        Me.RepositoryItemSpinEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit2.DisplayFormat.FormatString = "N0"
        Me.RepositoryItemSpinEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemSpinEdit2.Mask.EditMask = "N0"
        Me.RepositoryItemSpinEdit2.MaxValue = New Decimal(New Integer() {-1486618625, 232830643, 0, 0})
        Me.RepositoryItemSpinEdit2.Name = "RepositoryItemSpinEdit2"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Note"
        Me.GridColumn14.FieldName = "note"
        Me.GridColumn14.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.ReadOnly = True
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'BtnPrepareOrder
        '
        Me.BtnPrepareOrder.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BtnPrepareOrder.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnPrepareOrder.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnPrepareOrder.Appearance.Options.UseBackColor = True
        Me.BtnPrepareOrder.Appearance.Options.UseFont = True
        Me.BtnPrepareOrder.Appearance.Options.UseForeColor = True
        Me.BtnPrepareOrder.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnPrepareOrder.Location = New System.Drawing.Point(0, 279)
        Me.BtnPrepareOrder.LookAndFeel.SkinMaskColor = System.Drawing.Color.Blue
        Me.BtnPrepareOrder.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Blue
        Me.BtnPrepareOrder.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.BtnPrepareOrder.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnPrepareOrder.Name = "BtnPrepareOrder"
        Me.BtnPrepareOrder.Size = New System.Drawing.Size(699, 32)
        Me.BtnPrepareOrder.TabIndex = 20
        Me.BtnPrepareOrder.Text = "Transfer to GON/GOS"
        '
        'FormOLStoreRestock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 461)
        Me.Controls.Add(Me.XTCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormOLStoreRestock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Restock List"
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPOnlineWH.ResumeLayout(False)
        CType(Me.GCOnlineWH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOnlineWH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoSP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.XTPOtherWH.ResumeLayout(False)
        CType(Me.GCWH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVWH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TxtSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCOLWH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCOLWH.ResumeLayout(False)
        Me.XTPOLWHDirect.ResumeLayout(False)
        Me.XTPOLWHSyncSellerCenter.ResumeLayout(False)
        CType(Me.GCWHSync, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVWHSync, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPOnlineWH As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCOnlineWH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOnlineWH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTPOtherWH As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSize As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCreatePO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_wh_drawer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_stock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoSP As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCWH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVWH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnPrintWH As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnRefreshOther As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCreateOther As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XTCOLWH As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPOLWHDirect As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPOLWHSyncSellerCenter As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCWHSync As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVWHSync As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnPrepareOrder As DevExpress.XtraEditors.SimpleButton
End Class
