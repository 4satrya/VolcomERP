<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGProposePrice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGProposePrice))
        Me.GCFGPropose = New DevExpress.XtraGrid.GridControl()
        Me.GVFGPropose = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnFGProposeNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSource = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPPType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.BtnListCOP = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnViewList = New DevExpress.XtraEditors.SimpleButton()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntilList = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromList = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.XTCPropose = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPropose = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPRevision = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRev = New DevExpress.XtraGrid.GridControl()
        Me.GVRev = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_fg_propose_price_rev = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_fg_propose_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfg_propose_price_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnrev_count = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnseason_rev = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndivisionrev = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsourcerev = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.BtnViewRevision = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntilRev = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromRev = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPCompare = New DevExpress.XtraTab.XtraTabPage()
        Me.GCCompare = New DevExpress.XtraGrid.GridControl()
        Me.GVCompare = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.BandedGridColumncode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnname = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsize_chart = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnfg_propose_price_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepoPPNumber = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.BandedGridColumnadditional_price = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnprice_min_additional = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnprice = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnmarkup_target = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncop_status = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnrate_cat = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCOPKurs = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnadditional_cost = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCOPMinAddcost = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncop_value = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnMarkup = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnfinal_rate_cat = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnfinal_cop_kurs = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnfinal_additional_cost = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnfinal_cop_min_addcost = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnfinal_cop_value = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnfinal_markup = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_fg_propose_price = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnrmt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_design = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LEDivision = New DevExpress.XtraEditors.LookUpEdit()
        Me.LESource = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BandedGridColumnPPType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandApprovedPrice = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBandCOPProposePrice = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBandCOPFinal = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.GCFGPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFGPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.DEUntilList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPropose.SuspendLayout()
        Me.XTPPropose.SuspendLayout()
        Me.XTPRevision.SuspendLayout()
        CType(Me.GCRev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.DEUntilRev.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilRev.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromRev.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromRev.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPCompare.SuspendLayout()
        CType(Me.GCCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoPPNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEDivision.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LESource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCFGPropose
        '
        Me.GCFGPropose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFGPropose.Location = New System.Drawing.Point(0, 45)
        Me.GCFGPropose.MainView = Me.GVFGPropose
        Me.GCFGPropose.Name = "GCFGPropose"
        Me.GCFGPropose.Size = New System.Drawing.Size(939, 449)
        Me.GCFGPropose.TabIndex = 0
        Me.GCFGPropose.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFGPropose})
        '
        'GVFGPropose
        '
        Me.GVFGPropose.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnFGProposeNumber, Me.GridColumnSeason, Me.GridColumnSource, Me.GridColumnCreatedDate, Me.GridColumnDivision, Me.GridColumnStatus, Me.GridColumnPPType})
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
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 6
        '
        'GridColumnPPType
        '
        Me.GridColumnPPType.Caption = "Type"
        Me.GridColumnPPType.FieldName = "pp_type"
        Me.GridColumnPPType.Name = "GridColumnPPType"
        Me.GridColumnPPType.Visible = True
        Me.GridColumnPPType.VisibleIndex = 1
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.BtnListCOP)
        Me.GCFilter.Controls.Add(Me.BtnViewList)
        Me.GCFilter.Controls.Add(Me.BHide)
        Me.GCFilter.Controls.Add(Me.BExpand)
        Me.GCFilter.Controls.Add(Me.DEUntilList)
        Me.GCFilter.Controls.Add(Me.DEFromList)
        Me.GCFilter.Controls.Add(Me.LabelControl3)
        Me.GCFilter.Controls.Add(Me.LabelControl5)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(939, 45)
        Me.GCFilter.TabIndex = 7
        '
        'BtnListCOP
        '
        Me.BtnListCOP.Image = CType(resources.GetObject("BtnListCOP.Image"), System.Drawing.Image)
        Me.BtnListCOP.Location = New System.Drawing.Point(396, 14)
        Me.BtnListCOP.LookAndFeel.SkinName = "Blue"
        Me.BtnListCOP.Name = "BtnListCOP"
        Me.BtnListCOP.Size = New System.Drawing.Size(75, 20)
        Me.BtnListCOP.TabIndex = 8899
        Me.BtnListCOP.Text = "COP List"
        '
        'BtnViewList
        '
        Me.BtnViewList.Image = CType(resources.GetObject("BtnViewList.Image"), System.Drawing.Image)
        Me.BtnViewList.Location = New System.Drawing.Point(317, 14)
        Me.BtnViewList.LookAndFeel.SkinName = "Blue"
        Me.BtnViewList.Name = "BtnViewList"
        Me.BtnViewList.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewList.TabIndex = 8896
        Me.BtnViewList.Text = "View"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(938, 14)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'BExpand
        '
        Me.BExpand.ImageIndex = 8
        Me.BExpand.Location = New System.Drawing.Point(835, 14)
        Me.BExpand.Name = "BExpand"
        Me.BExpand.Size = New System.Drawing.Size(99, 20)
        Me.BExpand.TabIndex = 8897
        Me.BExpand.Text = "Expand All Detail"
        Me.BExpand.Visible = False
        '
        'DEUntilList
        '
        Me.DEUntilList.EditValue = Nothing
        Me.DEUntilList.Location = New System.Drawing.Point(202, 14)
        Me.DEUntilList.Name = "DEUntilList"
        Me.DEUntilList.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntilList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilList.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilList.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilList.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilList.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilList.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilList.TabIndex = 8895
        '
        'DEFromList
        '
        Me.DEFromList.EditValue = Nothing
        Me.DEFromList.Location = New System.Drawing.Point(58, 14)
        Me.DEFromList.Name = "DEFromList"
        Me.DEFromList.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFromList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromList.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromList.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromList.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromList.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromList.Size = New System.Drawing.Size(111, 20)
        Me.DEFromList.TabIndex = 8894
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(175, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl3.TabIndex = 8893
        Me.LabelControl3.Text = "Until"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(28, 17)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl5.TabIndex = 8892
        Me.LabelControl5.Text = "From"
        '
        'XTCPropose
        '
        Me.XTCPropose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPropose.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPropose.Location = New System.Drawing.Point(0, 0)
        Me.XTCPropose.Name = "XTCPropose"
        Me.XTCPropose.SelectedTabPage = Me.XTPPropose
        Me.XTCPropose.Size = New System.Drawing.Size(945, 522)
        Me.XTCPropose.TabIndex = 8
        Me.XTCPropose.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPropose, Me.XTPRevision, Me.XTPCompare})
        '
        'XTPPropose
        '
        Me.XTPPropose.Controls.Add(Me.GCFGPropose)
        Me.XTPPropose.Controls.Add(Me.GCFilter)
        Me.XTPPropose.Name = "XTPPropose"
        Me.XTPPropose.Size = New System.Drawing.Size(939, 494)
        Me.XTPPropose.Text = "Propose New Price"
        '
        'XTPRevision
        '
        Me.XTPRevision.Controls.Add(Me.GCRev)
        Me.XTPRevision.Controls.Add(Me.GroupControl1)
        Me.XTPRevision.Name = "XTPRevision"
        Me.XTPRevision.Size = New System.Drawing.Size(939, 494)
        Me.XTPRevision.Text = "Revision"
        '
        'GCRev
        '
        Me.GCRev.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRev.Location = New System.Drawing.Point(0, 45)
        Me.GCRev.MainView = Me.GVRev
        Me.GCRev.Name = "GCRev"
        Me.GCRev.Size = New System.Drawing.Size(939, 449)
        Me.GCRev.TabIndex = 9
        Me.GCRev.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRev})
        '
        'GVRev
        '
        Me.GVRev.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_fg_propose_price_rev, Me.GridColumnid_fg_propose_price, Me.GridColumnfg_propose_price_number, Me.GridColumnrev_count, Me.GridColumnseason_rev, Me.GridColumndivisionrev, Me.GridColumnsourcerev, Me.GridColumnreport_status, Me.GridColumncreated_date})
        Me.GVRev.GridControl = Me.GCRev
        Me.GVRev.Name = "GVRev"
        Me.GVRev.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVRev.OptionsBehavior.Editable = False
        Me.GVRev.OptionsFind.AlwaysVisible = True
        Me.GVRev.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_fg_propose_price_rev
        '
        Me.GridColumnid_fg_propose_price_rev.Caption = "Id Revise"
        Me.GridColumnid_fg_propose_price_rev.FieldName = "id_fg_propose_price_rev"
        Me.GridColumnid_fg_propose_price_rev.Name = "GridColumnid_fg_propose_price_rev"
        '
        'GridColumnid_fg_propose_price
        '
        Me.GridColumnid_fg_propose_price.Caption = "Id PP"
        Me.GridColumnid_fg_propose_price.FieldName = "id_fg_propose_price"
        Me.GridColumnid_fg_propose_price.Name = "GridColumnid_fg_propose_price"
        '
        'GridColumnfg_propose_price_number
        '
        Me.GridColumnfg_propose_price_number.Caption = "Propose Price#"
        Me.GridColumnfg_propose_price_number.FieldName = "fg_propose_price_number"
        Me.GridColumnfg_propose_price_number.Name = "GridColumnfg_propose_price_number"
        Me.GridColumnfg_propose_price_number.Visible = True
        Me.GridColumnfg_propose_price_number.VisibleIndex = 0
        '
        'GridColumnrev_count
        '
        Me.GridColumnrev_count.Caption = "Revision"
        Me.GridColumnrev_count.FieldName = "rev_count"
        Me.GridColumnrev_count.Name = "GridColumnrev_count"
        Me.GridColumnrev_count.Visible = True
        Me.GridColumnrev_count.VisibleIndex = 1
        '
        'GridColumnseason_rev
        '
        Me.GridColumnseason_rev.Caption = "Season"
        Me.GridColumnseason_rev.FieldName = "season"
        Me.GridColumnseason_rev.Name = "GridColumnseason_rev"
        Me.GridColumnseason_rev.Visible = True
        Me.GridColumnseason_rev.VisibleIndex = 2
        '
        'GridColumndivisionrev
        '
        Me.GridColumndivisionrev.Caption = "Division"
        Me.GridColumndivisionrev.FieldName = "division"
        Me.GridColumndivisionrev.Name = "GridColumndivisionrev"
        Me.GridColumndivisionrev.Visible = True
        Me.GridColumndivisionrev.VisibleIndex = 3
        '
        'GridColumnsourcerev
        '
        Me.GridColumnsourcerev.Caption = "Source"
        Me.GridColumnsourcerev.FieldName = "source"
        Me.GridColumnsourcerev.Name = "GridColumnsourcerev"
        Me.GridColumnsourcerev.Visible = True
        Me.GridColumnsourcerev.VisibleIndex = 4
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 5
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 6
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.BtnViewRevision)
        Me.GroupControl1.Controls.Add(Me.SimpleButton4)
        Me.GroupControl1.Controls.Add(Me.SimpleButton5)
        Me.GroupControl1.Controls.Add(Me.DEUntilRev)
        Me.GroupControl1.Controls.Add(Me.DEFromRev)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(939, 45)
        Me.GroupControl1.TabIndex = 8
        '
        'BtnViewRevision
        '
        Me.BtnViewRevision.Image = CType(resources.GetObject("BtnViewRevision.Image"), System.Drawing.Image)
        Me.BtnViewRevision.Location = New System.Drawing.Point(317, 14)
        Me.BtnViewRevision.LookAndFeel.SkinName = "Blue"
        Me.BtnViewRevision.Name = "BtnViewRevision"
        Me.BtnViewRevision.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewRevision.TabIndex = 8896
        Me.BtnViewRevision.Text = "View"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.ImageIndex = 9
        Me.SimpleButton4.Location = New System.Drawing.Point(938, 14)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(104, 20)
        Me.SimpleButton4.TabIndex = 8898
        Me.SimpleButton4.Text = "Hide All Detail"
        Me.SimpleButton4.Visible = False
        '
        'SimpleButton5
        '
        Me.SimpleButton5.ImageIndex = 8
        Me.SimpleButton5.Location = New System.Drawing.Point(835, 14)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(99, 20)
        Me.SimpleButton5.TabIndex = 8897
        Me.SimpleButton5.Text = "Expand All Detail"
        Me.SimpleButton5.Visible = False
        '
        'DEUntilRev
        '
        Me.DEUntilRev.EditValue = Nothing
        Me.DEUntilRev.Location = New System.Drawing.Point(202, 14)
        Me.DEUntilRev.Name = "DEUntilRev"
        Me.DEUntilRev.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntilRev.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilRev.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilRev.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilRev.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilRev.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilRev.Size = New System.Drawing.Size(111, 20)
        Me.DEUntilRev.TabIndex = 8895
        '
        'DEFromRev
        '
        Me.DEFromRev.EditValue = Nothing
        Me.DEFromRev.Location = New System.Drawing.Point(58, 14)
        Me.DEFromRev.Name = "DEFromRev"
        Me.DEFromRev.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFromRev.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromRev.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromRev.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromRev.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromRev.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromRev.Size = New System.Drawing.Size(111, 20)
        Me.DEFromRev.TabIndex = 8894
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(175, 17)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl6.TabIndex = 8893
        Me.LabelControl6.Text = "Until"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(28, 17)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl7.TabIndex = 8892
        Me.LabelControl7.Text = "From"
        '
        'XTPCompare
        '
        Me.XTPCompare.Controls.Add(Me.GCCompare)
        Me.XTPCompare.Controls.Add(Me.PanelControl1)
        Me.XTPCompare.Name = "XTPCompare"
        Me.XTPCompare.Size = New System.Drawing.Size(939, 494)
        Me.XTPCompare.Text = "Compare Mark Up (Final Cost)"
        '
        'GCCompare
        '
        Me.GCCompare.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCompare.Location = New System.Drawing.Point(0, 46)
        Me.GCCompare.MainView = Me.GVCompare
        Me.GCCompare.Name = "GCCompare"
        Me.GCCompare.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepoPPNumber})
        Me.GCCompare.Size = New System.Drawing.Size(939, 448)
        Me.GCCompare.TabIndex = 1
        Me.GCCompare.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCompare})
        '
        'GVCompare
        '
        Me.GVCompare.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBandApprovedPrice, Me.gridBandCOPProposePrice, Me.gridBandCOPFinal})
        Me.GVCompare.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnid_fg_propose_price, Me.BandedGridColumnrmt, Me.BandedGridColumnfg_propose_price_number, Me.BandedGridColumnid_design, Me.BandedGridColumncode, Me.BandedGridColumnname, Me.BandedGridColumnsize_chart, Me.BandedGridColumncop_status, Me.BandedGridColumnadditional_cost, Me.BandedGridColumnrate_cat, Me.BandedGridColumnCOPKurs, Me.BandedGridColumncop_value, Me.BandedGridColumnCOPMinAddcost, Me.BandedGridColumnMarkup, Me.BandedGridColumnprice, Me.BandedGridColumnprice_min_additional, Me.BandedGridColumnadditional_price, Me.BandedGridColumnfinal_rate_cat, Me.BandedGridColumnfinal_cop_kurs, Me.BandedGridColumnfinal_cop_value, Me.BandedGridColumnfinal_additional_cost, Me.BandedGridColumnfinal_cop_min_addcost, Me.BandedGridColumnfinal_markup, Me.BandedGridColumnmarkup_target, Me.BandedGridColumnPPType})
        Me.GVCompare.GridControl = Me.GCCompare
        Me.GVCompare.Name = "GVCompare"
        Me.GVCompare.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVCompare.OptionsFind.AlwaysVisible = True
        Me.GVCompare.OptionsView.ColumnAutoWidth = False
        Me.GVCompare.OptionsView.ShowGroupPanel = False
        '
        'BandedGridColumncode
        '
        Me.BandedGridColumncode.Caption = "Code"
        Me.BandedGridColumncode.FieldName = "code"
        Me.BandedGridColumncode.Name = "BandedGridColumncode"
        Me.BandedGridColumncode.OptionsColumn.AllowEdit = False
        Me.BandedGridColumncode.Visible = True
        Me.BandedGridColumncode.Width = 82
        '
        'BandedGridColumnname
        '
        Me.BandedGridColumnname.Caption = "Style"
        Me.BandedGridColumnname.FieldName = "name"
        Me.BandedGridColumnname.Name = "BandedGridColumnname"
        Me.BandedGridColumnname.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnname.Visible = True
        Me.BandedGridColumnname.Width = 82
        '
        'BandedGridColumnsize_chart
        '
        Me.BandedGridColumnsize_chart.Caption = "Size Chart"
        Me.BandedGridColumnsize_chart.FieldName = "size_chart"
        Me.BandedGridColumnsize_chart.Name = "BandedGridColumnsize_chart"
        Me.BandedGridColumnsize_chart.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnsize_chart.Visible = True
        Me.BandedGridColumnsize_chart.Width = 82
        '
        'BandedGridColumnfg_propose_price_number
        '
        Me.BandedGridColumnfg_propose_price_number.Caption = "Propose Price#"
        Me.BandedGridColumnfg_propose_price_number.ColumnEdit = Me.RepoPPNumber
        Me.BandedGridColumnfg_propose_price_number.FieldName = "fg_propose_price_number"
        Me.BandedGridColumnfg_propose_price_number.Name = "BandedGridColumnfg_propose_price_number"
        Me.BandedGridColumnfg_propose_price_number.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnfg_propose_price_number.Visible = True
        Me.BandedGridColumnfg_propose_price_number.Width = 83
        '
        'RepoPPNumber
        '
        Me.RepoPPNumber.AutoHeight = False
        Me.RepoPPNumber.Name = "RepoPPNumber"
        '
        'BandedGridColumnadditional_price
        '
        Me.BandedGridColumnadditional_price.Caption = "Additional Price"
        Me.BandedGridColumnadditional_price.FieldName = "additional_price"
        Me.BandedGridColumnadditional_price.Name = "BandedGridColumnadditional_price"
        Me.BandedGridColumnadditional_price.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnadditional_price.Visible = True
        Me.BandedGridColumnadditional_price.Width = 103
        '
        'BandedGridColumnprice_min_additional
        '
        Me.BandedGridColumnprice_min_additional.Caption = "Price (Min Additional)"
        Me.BandedGridColumnprice_min_additional.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnprice_min_additional.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnprice_min_additional.FieldName = "price_min_additional"
        Me.BandedGridColumnprice_min_additional.Name = "BandedGridColumnprice_min_additional"
        Me.BandedGridColumnprice_min_additional.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnprice_min_additional.UnboundExpression = "[price] - [additional_price]"
        Me.BandedGridColumnprice_min_additional.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnprice_min_additional.Visible = True
        Me.BandedGridColumnprice_min_additional.Width = 110
        '
        'BandedGridColumnprice
        '
        Me.BandedGridColumnprice.Caption = "Price"
        Me.BandedGridColumnprice.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnprice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnprice.FieldName = "price"
        Me.BandedGridColumnprice.Name = "BandedGridColumnprice"
        Me.BandedGridColumnprice.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnprice.Visible = True
        Me.BandedGridColumnprice.Width = 77
        '
        'BandedGridColumnmarkup_target
        '
        Me.BandedGridColumnmarkup_target.Caption = "Mark Up Target"
        Me.BandedGridColumnmarkup_target.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnmarkup_target.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnmarkup_target.FieldName = "markup_target"
        Me.BandedGridColumnmarkup_target.Name = "BandedGridColumnmarkup_target"
        Me.BandedGridColumnmarkup_target.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnmarkup_target.Visible = True
        Me.BandedGridColumnmarkup_target.Width = 83
        '
        'BandedGridColumncop_status
        '
        Me.BandedGridColumncop_status.Caption = "COP Status"
        Me.BandedGridColumncop_status.FieldName = "cop_status"
        Me.BandedGridColumncop_status.Name = "BandedGridColumncop_status"
        Me.BandedGridColumncop_status.OptionsColumn.AllowEdit = False
        Me.BandedGridColumncop_status.Visible = True
        '
        'BandedGridColumnrate_cat
        '
        Me.BandedGridColumnrate_cat.Caption = "Rate Type"
        Me.BandedGridColumnrate_cat.FieldName = "rate_cat"
        Me.BandedGridColumnrate_cat.Name = "BandedGridColumnrate_cat"
        Me.BandedGridColumnrate_cat.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnrate_cat.Visible = True
        '
        'BandedGridColumnCOPKurs
        '
        Me.BandedGridColumnCOPKurs.Caption = "Rate"
        Me.BandedGridColumnCOPKurs.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnCOPKurs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnCOPKurs.FieldName = "cop_kurs"
        Me.BandedGridColumnCOPKurs.Name = "BandedGridColumnCOPKurs"
        Me.BandedGridColumnCOPKurs.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnCOPKurs.Visible = True
        '
        'BandedGridColumnadditional_cost
        '
        Me.BandedGridColumnadditional_cost.Caption = "Additional Cost"
        Me.BandedGridColumnadditional_cost.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnadditional_cost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnadditional_cost.FieldName = "additional_cost"
        Me.BandedGridColumnadditional_cost.Name = "BandedGridColumnadditional_cost"
        Me.BandedGridColumnadditional_cost.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnadditional_cost.Visible = True
        Me.BandedGridColumnadditional_cost.Width = 158
        '
        'BandedGridColumnCOPMinAddcost
        '
        Me.BandedGridColumnCOPMinAddcost.Caption = "COP (Min Additional)"
        Me.BandedGridColumnCOPMinAddcost.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnCOPMinAddcost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnCOPMinAddcost.FieldName = "cop_min_addcost"
        Me.BandedGridColumnCOPMinAddcost.Name = "BandedGridColumnCOPMinAddcost"
        Me.BandedGridColumnCOPMinAddcost.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnCOPMinAddcost.UnboundExpression = "[cop_value] - [additional_cost]"
        Me.BandedGridColumnCOPMinAddcost.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnCOPMinAddcost.Visible = True
        Me.BandedGridColumnCOPMinAddcost.Width = 107
        '
        'BandedGridColumncop_value
        '
        Me.BandedGridColumncop_value.Caption = "COP"
        Me.BandedGridColumncop_value.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumncop_value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumncop_value.FieldName = "cop_value"
        Me.BandedGridColumncop_value.Name = "BandedGridColumncop_value"
        Me.BandedGridColumncop_value.OptionsColumn.AllowEdit = False
        Me.BandedGridColumncop_value.Visible = True
        '
        'BandedGridColumnMarkup
        '
        Me.BandedGridColumnMarkup.Caption = "Mark Up"
        Me.BandedGridColumnMarkup.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnMarkup.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnMarkup.FieldName = "markup"
        Me.BandedGridColumnMarkup.Name = "BandedGridColumnMarkup"
        Me.BandedGridColumnMarkup.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnMarkup.UnboundExpression = "[price_min_additional] / [cop_min_addcost]"
        Me.BandedGridColumnMarkup.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnMarkup.Visible = True
        '
        'BandedGridColumnfinal_rate_cat
        '
        Me.BandedGridColumnfinal_rate_cat.Caption = "Rate Type"
        Me.BandedGridColumnfinal_rate_cat.FieldName = "final_rate_cat"
        Me.BandedGridColumnfinal_rate_cat.Name = "BandedGridColumnfinal_rate_cat"
        Me.BandedGridColumnfinal_rate_cat.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnfinal_rate_cat.Visible = True
        Me.BandedGridColumnfinal_rate_cat.Width = 87
        '
        'BandedGridColumnfinal_cop_kurs
        '
        Me.BandedGridColumnfinal_cop_kurs.Caption = "Rate"
        Me.BandedGridColumnfinal_cop_kurs.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnfinal_cop_kurs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnfinal_cop_kurs.FieldName = "final_cop_kurs"
        Me.BandedGridColumnfinal_cop_kurs.Name = "BandedGridColumnfinal_cop_kurs"
        Me.BandedGridColumnfinal_cop_kurs.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnfinal_cop_kurs.Visible = True
        Me.BandedGridColumnfinal_cop_kurs.Width = 87
        '
        'BandedGridColumnfinal_additional_cost
        '
        Me.BandedGridColumnfinal_additional_cost.Caption = "Additional Cost"
        Me.BandedGridColumnfinal_additional_cost.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnfinal_additional_cost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnfinal_additional_cost.FieldName = "final_additional_cost"
        Me.BandedGridColumnfinal_additional_cost.Name = "BandedGridColumnfinal_additional_cost"
        Me.BandedGridColumnfinal_additional_cost.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnfinal_additional_cost.Visible = True
        Me.BandedGridColumnfinal_additional_cost.Width = 87
        '
        'BandedGridColumnfinal_cop_min_addcost
        '
        Me.BandedGridColumnfinal_cop_min_addcost.Caption = "COP (Min Additional)"
        Me.BandedGridColumnfinal_cop_min_addcost.FieldName = "final_cop_min_addcost"
        Me.BandedGridColumnfinal_cop_min_addcost.Name = "BandedGridColumnfinal_cop_min_addcost"
        Me.BandedGridColumnfinal_cop_min_addcost.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnfinal_cop_min_addcost.UnboundExpression = "[final_cop_value] - [final_additional_cost]"
        Me.BandedGridColumnfinal_cop_min_addcost.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnfinal_cop_min_addcost.Visible = True
        Me.BandedGridColumnfinal_cop_min_addcost.Width = 129
        '
        'BandedGridColumnfinal_cop_value
        '
        Me.BandedGridColumnfinal_cop_value.Caption = "COP"
        Me.BandedGridColumnfinal_cop_value.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnfinal_cop_value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnfinal_cop_value.FieldName = "final_cop_value"
        Me.BandedGridColumnfinal_cop_value.Name = "BandedGridColumnfinal_cop_value"
        Me.BandedGridColumnfinal_cop_value.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnfinal_cop_value.Visible = True
        '
        'BandedGridColumnfinal_markup
        '
        Me.BandedGridColumnfinal_markup.Caption = "Mark Up"
        Me.BandedGridColumnfinal_markup.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnfinal_markup.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnfinal_markup.FieldName = "final_markup"
        Me.BandedGridColumnfinal_markup.Name = "BandedGridColumnfinal_markup"
        Me.BandedGridColumnfinal_markup.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnfinal_markup.UnboundExpression = "[price_min_additional] / [final_cop_min_addcost]"
        Me.BandedGridColumnfinal_markup.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumnfinal_markup.Visible = True
        '
        'BandedGridColumnid_fg_propose_price
        '
        Me.BandedGridColumnid_fg_propose_price.Caption = "id_fg_propose_price"
        Me.BandedGridColumnid_fg_propose_price.FieldName = "id_fg_propose_price"
        Me.BandedGridColumnid_fg_propose_price.Name = "BandedGridColumnid_fg_propose_price"
        Me.BandedGridColumnid_fg_propose_price.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumnrmt
        '
        Me.BandedGridColumnrmt.Caption = "rmt"
        Me.BandedGridColumnrmt.FieldName = "rmt"
        Me.BandedGridColumnrmt.Name = "BandedGridColumnrmt"
        Me.BandedGridColumnrmt.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumnid_design
        '
        Me.BandedGridColumnid_design.Caption = "id_design"
        Me.BandedGridColumnid_design.FieldName = "id_design"
        Me.BandedGridColumnid_design.Name = "BandedGridColumnid_design"
        Me.BandedGridColumnid_design.OptionsColumn.AllowEdit = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Controls.Add(Me.LEDivision)
        Me.PanelControl1.Controls.Add(Me.LESource)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.SLESeason)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(939, 46)
        Me.PanelControl1.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(634, 12)
        Me.SimpleButton1.LookAndFeel.SkinName = "Blue"
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 20)
        Me.SimpleButton1.TabIndex = 8913
        Me.SimpleButton1.Text = "View"
        '
        'LEDivision
        '
        Me.LEDivision.Location = New System.Drawing.Point(525, 13)
        Me.LEDivision.Name = "LEDivision"
        Me.LEDivision.Properties.Appearance.Options.UseTextOptions = True
        Me.LEDivision.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEDivision.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDivision.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_code_detail", "ID Division", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("display_name", "Display Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_detail_name", "Division")})
        Me.LEDivision.Properties.NullText = ""
        Me.LEDivision.Properties.ShowFooter = False
        Me.LEDivision.Size = New System.Drawing.Size(103, 20)
        Me.LEDivision.TabIndex = 8911
        '
        'LESource
        '
        Me.LESource.Location = New System.Drawing.Point(324, 13)
        Me.LESource.Name = "LESource"
        Me.LESource.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESource.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_source", "Id Code Detail", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("display_name", "Display Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("source", "Source")})
        Me.LESource.Properties.NullText = "- Select Product Source -"
        Me.LESource.Size = New System.Drawing.Size(153, 20)
        Me.LESource.TabIndex = 8912
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(483, 16)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl4.TabIndex = 8910
        Me.LabelControl4.Text = "Division"
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(54, 13)
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
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(285, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl2.TabIndex = 8911
        Me.LabelControl2.Text = "Source"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 8909
        Me.LabelControl1.Text = "Season"
        '
        'BandedGridColumnPPType
        '
        Me.BandedGridColumnPPType.Caption = "Type"
        Me.BandedGridColumnPPType.FieldName = "pp_type"
        Me.BandedGridColumnPPType.Name = "BandedGridColumnPPType"
        Me.BandedGridColumnPPType.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnPPType.Visible = True
        '
        'gridBandApprovedPrice
        '
        Me.gridBandApprovedPrice.Caption = "APPROVED PRICE"
        Me.gridBandApprovedPrice.Columns.Add(Me.BandedGridColumncode)
        Me.gridBandApprovedPrice.Columns.Add(Me.BandedGridColumnname)
        Me.gridBandApprovedPrice.Columns.Add(Me.BandedGridColumnsize_chart)
        Me.gridBandApprovedPrice.Columns.Add(Me.BandedGridColumnfg_propose_price_number)
        Me.gridBandApprovedPrice.Columns.Add(Me.BandedGridColumnPPType)
        Me.gridBandApprovedPrice.Columns.Add(Me.BandedGridColumnadditional_price)
        Me.gridBandApprovedPrice.Columns.Add(Me.BandedGridColumnprice_min_additional)
        Me.gridBandApprovedPrice.Columns.Add(Me.BandedGridColumnprice)
        Me.gridBandApprovedPrice.Columns.Add(Me.BandedGridColumnmarkup_target)
        Me.gridBandApprovedPrice.Name = "gridBandApprovedPrice"
        Me.gridBandApprovedPrice.VisibleIndex = 0
        Me.gridBandApprovedPrice.Width = 777
        '
        'gridBandCOPProposePrice
        '
        Me.gridBandCOPProposePrice.Caption = "COP PROPOSE PRICE"
        Me.gridBandCOPProposePrice.Columns.Add(Me.BandedGridColumncop_status)
        Me.gridBandCOPProposePrice.Columns.Add(Me.BandedGridColumnrate_cat)
        Me.gridBandCOPProposePrice.Columns.Add(Me.BandedGridColumnCOPKurs)
        Me.gridBandCOPProposePrice.Columns.Add(Me.BandedGridColumnadditional_cost)
        Me.gridBandCOPProposePrice.Columns.Add(Me.BandedGridColumnCOPMinAddcost)
        Me.gridBandCOPProposePrice.Columns.Add(Me.BandedGridColumncop_value)
        Me.gridBandCOPProposePrice.Columns.Add(Me.BandedGridColumnMarkup)
        Me.gridBandCOPProposePrice.Name = "gridBandCOPProposePrice"
        Me.gridBandCOPProposePrice.VisibleIndex = 1
        Me.gridBandCOPProposePrice.Width = 640
        '
        'gridBandCOPFinal
        '
        Me.gridBandCOPFinal.Caption = "COP FINAL"
        Me.gridBandCOPFinal.Columns.Add(Me.BandedGridColumnfinal_rate_cat)
        Me.gridBandCOPFinal.Columns.Add(Me.BandedGridColumnfinal_cop_kurs)
        Me.gridBandCOPFinal.Columns.Add(Me.BandedGridColumnfinal_additional_cost)
        Me.gridBandCOPFinal.Columns.Add(Me.BandedGridColumnfinal_cop_min_addcost)
        Me.gridBandCOPFinal.Columns.Add(Me.BandedGridColumnfinal_cop_value)
        Me.gridBandCOPFinal.Columns.Add(Me.BandedGridColumnfinal_markup)
        Me.gridBandCOPFinal.Name = "gridBandCOPFinal"
        Me.gridBandCOPFinal.VisibleIndex = 2
        Me.gridBandCOPFinal.Width = 540
        '
        'FormFGProposePrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 522)
        Me.Controls.Add(Me.XTCPropose)
        Me.Name = "FormFGProposePrice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Propose Price New Product"
        CType(Me.GCFGPropose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFGPropose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.DEUntilList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCPropose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPropose.ResumeLayout(False)
        Me.XTPPropose.ResumeLayout(False)
        Me.XTPRevision.ResumeLayout(False)
        CType(Me.GCRev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.DEUntilRev.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilRev.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromRev.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromRev.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPCompare.ResumeLayout(False)
        CType(Me.GCCompare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCompare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoPPNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LEDivision.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LESource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCFGPropose As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFGPropose As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnFGProposeNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSource As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnListCOP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnViewList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BExpand As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntilList As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromList As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XTCPropose As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPropose As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPCompare As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LESource As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEDivision As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCCompare As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCompare As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumnid_fg_propose_price As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnname As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnsize_chart As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnfg_propose_price_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnadditional_price As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnprice_min_additional As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnprice As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncop_status As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnrate_cat As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCOPKurs As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnadditional_cost As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCOPMinAddcost As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncop_value As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnMarkup As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnfinal_rate_cat As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnfinal_cop_kurs As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnfinal_additional_cost As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnfinal_cop_min_addcost As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnfinal_cop_value As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnfinal_markup As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnrmt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_design As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnmarkup_target As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepoPPNumber As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents XTPRevision As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnViewRevision As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntilRev As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromRev As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCRev As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRev As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_fg_propose_price_rev As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_fg_propose_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfg_propose_price_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnrev_count As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnseason_rev As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndivisionrev As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsourcerev As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPPType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gridBandApprovedPrice As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnPPType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandCOPProposePrice As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBandCOPFinal As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
