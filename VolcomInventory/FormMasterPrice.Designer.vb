<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterPrice
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
        Me.GCPrice = New DevExpress.XtraGrid.GridControl()
        Me.GVPrice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceCreated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTCPrice = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPBrowse = New DevExpress.XtraTab.XtraTabPage()
        Me.GCBrowsePrice = New DevExpress.XtraGrid.GridControl()
        Me.GVBrowsePrice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnFullCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnClass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnGender = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeasonx = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColorDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.SLEDel = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPImport = New DevExpress.XtraTab.XtraTabPage()
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.BtnViewList = New DevExpress.XtraEditors.SimpleButton()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.BExpand = New DevExpress.XtraEditors.SimpleButton()
        Me.DEUntilList = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromList = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.GridColumnEffective = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPrice.SuspendLayout()
        Me.XTPBrowse.SuspendLayout()
        CType(Me.GCBrowsePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBrowsePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.SLEDel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPImport.SuspendLayout()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.DEUntilList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCPrice
        '
        Me.GCPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPrice.Location = New System.Drawing.Point(0, 39)
        Me.GCPrice.MainView = Me.GVPrice
        Me.GCPrice.Name = "GCPrice"
        Me.GCPrice.Size = New System.Drawing.Size(699, 278)
        Me.GCPrice.TabIndex = 0
        Me.GCPrice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPrice})
        '
        'GVPrice
        '
        Me.GVPrice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnPriceNumber, Me.GridColumnPriceCreated, Me.GridColumnEffective, Me.GridColumnPriceNote, Me.GridColumnStatus})
        Me.GVPrice.GridControl = Me.GCPrice
        Me.GVPrice.Name = "GVPrice"
        Me.GVPrice.OptionsView.ShowGroupPanel = False
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_fg_price"
        Me.GridColumnId.Name = "GridColumnId"
        Me.GridColumnId.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnPriceNumber
        '
        Me.GridColumnPriceNumber.Caption = "Number"
        Me.GridColumnPriceNumber.FieldName = "fg_price_number"
        Me.GridColumnPriceNumber.Name = "GridColumnPriceNumber"
        Me.GridColumnPriceNumber.Visible = True
        Me.GridColumnPriceNumber.VisibleIndex = 0
        '
        'GridColumnPriceCreated
        '
        Me.GridColumnPriceCreated.Caption = "Created Date"
        Me.GridColumnPriceCreated.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnPriceCreated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPriceCreated.FieldName = "fg_price_date"
        Me.GridColumnPriceCreated.Name = "GridColumnPriceCreated"
        Me.GridColumnPriceCreated.Visible = True
        Me.GridColumnPriceCreated.VisibleIndex = 1
        '
        'GridColumnPriceNote
        '
        Me.GridColumnPriceNote.Caption = "Note"
        Me.GridColumnPriceNote.FieldName = "fg_price_note"
        Me.GridColumnPriceNote.Name = "GridColumnPriceNote"
        Me.GridColumnPriceNote.Visible = True
        Me.GridColumnPriceNote.VisibleIndex = 3
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.FieldNameSortGroup = "id_report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 4
        '
        'XTCPrice
        '
        Me.XTCPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPrice.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPrice.Location = New System.Drawing.Point(0, 0)
        Me.XTCPrice.Name = "XTCPrice"
        Me.XTCPrice.SelectedTabPage = Me.XTPBrowse
        Me.XTCPrice.Size = New System.Drawing.Size(705, 345)
        Me.XTCPrice.TabIndex = 1
        Me.XTCPrice.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPBrowse, Me.XTPImport})
        '
        'XTPBrowse
        '
        Me.XTPBrowse.Controls.Add(Me.GCBrowsePrice)
        Me.XTPBrowse.Controls.Add(Me.PanelControlNav)
        Me.XTPBrowse.Name = "XTPBrowse"
        Me.XTPBrowse.Size = New System.Drawing.Size(699, 317)
        Me.XTPBrowse.Text = "Browse"
        '
        'GCBrowsePrice
        '
        Me.GCBrowsePrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBrowsePrice.Location = New System.Drawing.Point(0, 37)
        Me.GCBrowsePrice.MainView = Me.GVBrowsePrice
        Me.GCBrowsePrice.Name = "GCBrowsePrice"
        Me.GCBrowsePrice.Size = New System.Drawing.Size(699, 280)
        Me.GCBrowsePrice.TabIndex = 90
        Me.GCBrowsePrice.TabStop = False
        Me.GCBrowsePrice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBrowsePrice})
        '
        'GVBrowsePrice
        '
        Me.GVBrowsePrice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnFullCode, Me.GridColumnCode, Me.GridColumnSize, Me.GridColumnClass, Me.GridColumnDesc, Me.GridColumnColor, Me.GridColumnPrice, Me.GridColumnGender, Me.GridColumnRemark, Me.GridColumnSeasonx, Me.GridColumnNo, Me.GridColumnDel, Me.GridColumnPriceType, Me.GridColumnColorDesc})
        Me.GVBrowsePrice.GridControl = Me.GCBrowsePrice
        Me.GVBrowsePrice.Name = "GVBrowsePrice"
        Me.GVBrowsePrice.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVBrowsePrice.OptionsBehavior.Editable = False
        Me.GVBrowsePrice.OptionsView.ShowGroupPanel = False
        '
        'GridColumnFullCode
        '
        Me.GridColumnFullCode.Caption = "Full Code"
        Me.GridColumnFullCode.FieldName = "product_full_code"
        Me.GridColumnFullCode.Name = "GridColumnFullCode"
        Me.GridColumnFullCode.Visible = True
        Me.GridColumnFullCode.VisibleIndex = 1
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "design_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 2
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 3
        '
        'GridColumnClass
        '
        Me.GridColumnClass.Caption = "Class"
        Me.GridColumnClass.FieldName = "class"
        Me.GridColumnClass.Name = "GridColumnClass"
        Me.GridColumnClass.Visible = True
        Me.GridColumnClass.VisibleIndex = 4
        '
        'GridColumnDesc
        '
        Me.GridColumnDesc.Caption = "Description"
        Me.GridColumnDesc.FieldName = "design_display_name"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 5
        '
        'GridColumnColor
        '
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 6
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 8
        '
        'GridColumnGender
        '
        Me.GridColumnGender.Caption = "Division"
        Me.GridColumnGender.FieldName = "division"
        Me.GridColumnGender.Name = "GridColumnGender"
        Me.GridColumnGender.Visible = True
        Me.GridColumnGender.VisibleIndex = 10
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "remark"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 11
        '
        'GridColumnSeasonx
        '
        Me.GridColumnSeasonx.Caption = "Season"
        Me.GridColumnSeasonx.FieldName = "season"
        Me.GridColumnSeasonx.Name = "GridColumnSeasonx"
        Me.GridColumnSeasonx.Visible = True
        Me.GridColumnSeasonx.VisibleIndex = 12
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        '
        'GridColumnDel
        '
        Me.GridColumnDel.Caption = "Delivery"
        Me.GridColumnDel.FieldName = "delivery"
        Me.GridColumnDel.Name = "GridColumnDel"
        Me.GridColumnDel.Visible = True
        Me.GridColumnDel.VisibleIndex = 13
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "Price Type"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.Visible = True
        Me.GridColumnPriceType.VisibleIndex = 9
        '
        'GridColumnColorDesc
        '
        Me.GridColumnColorDesc.Caption = "Color Description"
        Me.GridColumnColorDesc.FieldName = "color_desc"
        Me.GridColumnColorDesc.Name = "GridColumnColorDesc"
        Me.GridColumnColorDesc.Visible = True
        Me.GridColumnColorDesc.VisibleIndex = 7
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.SLEDel)
        Me.PanelControlNav.Controls.Add(Me.LabelControl2)
        Me.PanelControlNav.Controls.Add(Me.BtnView)
        Me.PanelControlNav.Controls.Add(Me.DEFrom)
        Me.PanelControlNav.Controls.Add(Me.LabelControl1)
        Me.PanelControlNav.Controls.Add(Me.SLESeason)
        Me.PanelControlNav.Controls.Add(Me.LabelControl4)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(699, 37)
        Me.PanelControlNav.TabIndex = 100
        '
        'SLEDel
        '
        Me.SLEDel.Location = New System.Drawing.Point(271, 8)
        Me.SLEDel.Name = "SLEDel"
        Me.SLEDel.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEDel.Properties.Appearance.Options.UseFont = True
        Me.SLEDel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDel.Properties.View = Me.GridView1
        Me.SLEDel.Size = New System.Drawing.Size(99, 20)
        Me.SLEDel.TabIndex = 1
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Del"
        Me.GridColumn1.FieldName = "id_delivery"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Delivery"
        Me.GridColumn3.FieldName = "delivery"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(251, 11)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(15, 13)
        Me.LabelControl2.TabIndex = 100
        Me.LabelControl2.Text = "Del"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(531, 8)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(70, 20)
        Me.BtnView.TabIndex = 3
        Me.BtnView.Text = "View"
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(405, 8)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(120, 20)
        Me.DEFrom.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(376, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 99
        Me.LabelControl1.Text = "Date"
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(54, 8)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(191, 20)
        Me.SLESeason.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdSeason, Me.GridColumnRange, Me.GridColumnSeason})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id Season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnRange
        '
        Me.GridColumnRange.Caption = "Range"
        Me.GridColumnRange.FieldName = "range"
        Me.GridColumnRange.Name = "GridColumnRange"
        Me.GridColumnRange.Visible = True
        Me.GridColumnRange.VisibleIndex = 0
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(13, 11)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl4.TabIndex = 98
        Me.LabelControl4.Text = "Season"
        '
        'XTPImport
        '
        Me.XTPImport.Controls.Add(Me.GCPrice)
        Me.XTPImport.Controls.Add(Me.GCFilter)
        Me.XTPImport.Name = "XTPImport"
        Me.XTPImport.Size = New System.Drawing.Size(699, 317)
        Me.XTPImport.Text = "Import from Excel"
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
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
        Me.GCFilter.Size = New System.Drawing.Size(699, 39)
        Me.GCFilter.TabIndex = 6
        '
        'BtnViewList
        '
        Me.BtnViewList.Location = New System.Drawing.Point(317, 9)
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
        Me.DEUntilList.Location = New System.Drawing.Point(202, 9)
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
        Me.DEFromList.Location = New System.Drawing.Point(58, 9)
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
        Me.LabelControl3.Location = New System.Drawing.Point(175, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl3.TabIndex = 8893
        Me.LabelControl3.Text = "Until"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(28, 12)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl5.TabIndex = 8892
        Me.LabelControl5.Text = "From"
        '
        'GridColumnEffective
        '
        Me.GridColumnEffective.Caption = "Effective Date"
        Me.GridColumnEffective.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnEffective.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnEffective.FieldName = "fg_effective_date"
        Me.GridColumnEffective.Name = "GridColumnEffective"
        Me.GridColumnEffective.Visible = True
        Me.GridColumnEffective.VisibleIndex = 2
        '
        'FormMasterPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 345)
        Me.Controls.Add(Me.XTCPrice)
        Me.Name = "FormMasterPrice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product Price"
        CType(Me.GCPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPrice.ResumeLayout(False)
        Me.XTPBrowse.ResumeLayout(False)
        CType(Me.GCBrowsePrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBrowsePrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        Me.PanelControlNav.PerformLayout()
        CType(Me.SLEDel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPImport.ResumeLayout(False)
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        Me.GCFilter.PerformLayout()
        CType(Me.DEUntilList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromList.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCPrice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPrice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceCreated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCPrice As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPBrowse As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPImport As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCBrowsePrice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBrowsePrice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnFullCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnClass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnGender As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeasonx As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEDel As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColorDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnViewList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BExpand As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntilList As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromList As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnEffective As DevExpress.XtraGrid.Columns.GridColumn
End Class
