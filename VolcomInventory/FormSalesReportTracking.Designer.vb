<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesReportTracking
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesReportTracking))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.GCListDesign = New DevExpress.XtraGrid.GridControl()
        Me.BGVListDesign = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gbDetail = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gbQty = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnDelQty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnRTSQty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnSalQty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnSOHQty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnpercentSaas = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPercentSaasDel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gbValue = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnValDel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnValRTS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnValSAL = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnValSOH = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnValSaas = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnValSaasDel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCListDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BGVListDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BPrint)
        Me.PanelControl1.Controls.Add(Me.BSearch)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1080, 42)
        Me.PanelControl1.TabIndex = 0
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.ImageIndex = 6
        Me.BPrint.ImageList = Me.LargeImageCollection
        Me.BPrint.Location = New System.Drawing.Point(833, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(100, 38)
        Me.BPrint.TabIndex = 17
        Me.BPrint.Text = "Print"
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
        Me.LargeImageCollection.Images.SetKeyName(10, "1415351112474759854-32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "icon_merchandise_clothes32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "t_shirtgreen.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "lock red.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "ordering32.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "kghostview.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "MetroUI-Folder-OS-Configure-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(17, "Setting(32).png")
        Me.LargeImageCollection.Images.SetKeyName(18, "estimate_icon32.png")
        Me.LargeImageCollection.Images.SetKeyName(19, "copy_icon.png")
        '
        'BSearch
        '
        Me.BSearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSearch.ImageIndex = 15
        Me.BSearch.ImageList = Me.LargeImageCollection
        Me.BSearch.Location = New System.Drawing.Point(933, 2)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(145, 38)
        Me.BSearch.TabIndex = 16
        Me.BSearch.Text = "Search Parameter"
        '
        'GCListDesign
        '
        Me.GCListDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListDesign.Location = New System.Drawing.Point(0, 42)
        Me.GCListDesign.MainView = Me.BGVListDesign
        Me.GCListDesign.Name = "GCListDesign"
        Me.GCListDesign.Size = New System.Drawing.Size(1080, 521)
        Me.GCListDesign.TabIndex = 1
        Me.GCListDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BGVListDesign})
        '
        'BGVListDesign
        '
        Me.BGVListDesign.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gbDetail, Me.gbQty, Me.gbValue})
        Me.BGVListDesign.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumn15, Me.GridColumn14, Me.GridColumn13, Me.GridColumn12, Me.GridColumn7, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumnDelQty, Me.GridColumnRTSQty, Me.GridColumnSalQty, Me.GridColumnSOHQty, Me.GridColumnpercentSaas, Me.GridColumnPercentSaasDel, Me.BandedGridColumnValDel, Me.BandedGridColumnValRTS, Me.BandedGridColumnValSAL, Me.BandedGridColumnValSOH, Me.BandedGridColumnValSaas, Me.BandedGridColumnValSaasDel})
        Me.BGVListDesign.GridControl = Me.GCListDesign
        Me.BGVListDesign.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "del_qty", Me.GridColumnDelQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ret_qty", Me.GridColumnRTSQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sal_qty", Me.GridColumnSalQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_qty", Me.GridColumnSOHQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "del_val", Me.BandedGridColumnValDel, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ret_val", Me.BandedGridColumnValRTS, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sal_val", Me.BandedGridColumnValSAL, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_val", Me.BandedGridColumnValSOH, "{0:N0}")})
        Me.BGVListDesign.Name = "BGVListDesign"
        Me.BGVListDesign.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.BGVListDesign.OptionsView.ShowFooter = True
        Me.BGVListDesign.OptionsView.ShowGroupPanel = False
        '
        'gbDetail
        '
        Me.gbDetail.AppearanceHeader.Options.UseTextOptions = True
        Me.gbDetail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gbDetail.Caption = "Design Detail"
        Me.gbDetail.Columns.Add(Me.GridColumn15)
        Me.gbDetail.Columns.Add(Me.GridColumn14)
        Me.gbDetail.Columns.Add(Me.GridColumn13)
        Me.gbDetail.Columns.Add(Me.GridColumn12)
        Me.gbDetail.Columns.Add(Me.GridColumn7)
        Me.gbDetail.Columns.Add(Me.GridColumn1)
        Me.gbDetail.Columns.Add(Me.GridColumn2)
        Me.gbDetail.Columns.Add(Me.GridColumn3)
        Me.gbDetail.Columns.Add(Me.GridColumn4)
        Me.gbDetail.Columns.Add(Me.GridColumn5)
        Me.gbDetail.Columns.Add(Me.GridColumn6)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.VisibleIndex = 0
        Me.gbDetail.Width = 825
        '
        'GridColumn15
        '
        Me.GridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn15.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn15.Caption = "Division"
        Me.GridColumn15.FieldName = "division"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.Caption = "Sub Category"
        Me.GridColumn14.FieldName = "sub_cat"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn13.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn13.Caption = "Category"
        Me.GridColumn13.FieldName = "kat"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.GridColumn13.Visible = True
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Group"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Group Class"
        Me.GridColumn7.FieldName = "group_class"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "Class"
        Me.GridColumn1.FieldName = "class"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Code"
        Me.GridColumn2.FieldName = "design_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Description"
        Me.GridColumn3.FieldName = "design_display_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Price"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Delivery"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Season"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        '
        'gbQty
        '
        Me.gbQty.AppearanceHeader.Options.UseTextOptions = True
        Me.gbQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gbQty.Caption = "Qty"
        Me.gbQty.Columns.Add(Me.GridColumnDelQty)
        Me.gbQty.Columns.Add(Me.GridColumnRTSQty)
        Me.gbQty.Columns.Add(Me.GridColumnSalQty)
        Me.gbQty.Columns.Add(Me.GridColumnSOHQty)
        Me.gbQty.Columns.Add(Me.GridColumnpercentSaas)
        Me.gbQty.Columns.Add(Me.GridColumnPercentSaasDel)
        Me.gbQty.Name = "gbQty"
        Me.gbQty.VisibleIndex = 1
        Me.gbQty.Width = 471
        '
        'GridColumnDelQty
        '
        Me.GridColumnDelQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDelQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDelQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDelQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDelQty.Caption = "DEL"
        Me.GridColumnDelQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnDelQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDelQty.FieldName = "del_qty"
        Me.GridColumnDelQty.Name = "GridColumnDelQty"
        Me.GridColumnDelQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "del_qty", "{0:N0}")})
        Me.GridColumnDelQty.Visible = True
        Me.GridColumnDelQty.Width = 77
        '
        'GridColumnRTSQty
        '
        Me.GridColumnRTSQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnRTSQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRTSQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnRTSQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRTSQty.Caption = "RTS"
        Me.GridColumnRTSQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnRTSQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRTSQty.FieldName = "ret_qty"
        Me.GridColumnRTSQty.Name = "GridColumnRTSQty"
        Me.GridColumnRTSQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ret_qty", "{0:N0}")})
        Me.GridColumnRTSQty.Visible = True
        Me.GridColumnRTSQty.Width = 77
        '
        'GridColumnSalQty
        '
        Me.GridColumnSalQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSalQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSalQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSalQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSalQty.Caption = "SAL"
        Me.GridColumnSalQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnSalQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnSalQty.FieldName = "sal_qty"
        Me.GridColumnSalQty.Name = "GridColumnSalQty"
        Me.GridColumnSalQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sal_qty", "{0:N0}")})
        Me.GridColumnSalQty.Visible = True
        Me.GridColumnSalQty.Width = 77
        '
        'GridColumnSOHQty
        '
        Me.GridColumnSOHQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSOHQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSOHQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSOHQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSOHQty.Caption = "SOH"
        Me.GridColumnSOHQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnSOHQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnSOHQty.FieldName = "soh_qty"
        Me.GridColumnSOHQty.Name = "GridColumnSOHQty"
        Me.GridColumnSOHQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_qty", "{0:N0}")})
        Me.GridColumnSOHQty.Visible = True
        Me.GridColumnSOHQty.Width = 77
        '
        'GridColumnpercentSaas
        '
        Me.GridColumnpercentSaas.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnpercentSaas.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnpercentSaas.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnpercentSaas.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnpercentSaas.Caption = "% SAS"
        Me.GridColumnpercentSaas.DisplayFormat.FormatString = "{0:N2}%"
        Me.GridColumnpercentSaas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnpercentSaas.FieldName = "percent_sas"
        Me.GridColumnpercentSaas.Name = "GridColumnpercentSaas"
        Me.GridColumnpercentSaas.Visible = True
        Me.GridColumnpercentSaas.Width = 77
        '
        'GridColumnPercentSaasDel
        '
        Me.GridColumnPercentSaasDel.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPercentSaasDel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnPercentSaasDel.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPercentSaasDel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnPercentSaasDel.Caption = "SAL/DEL"
        Me.GridColumnPercentSaasDel.DisplayFormat.FormatString = "{0:N2}%"
        Me.GridColumnPercentSaasDel.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPercentSaasDel.FieldName = "percent_sas_sal_del"
        Me.GridColumnPercentSaasDel.Name = "GridColumnPercentSaasDel"
        Me.GridColumnPercentSaasDel.Visible = True
        Me.GridColumnPercentSaasDel.Width = 86
        '
        'gbValue
        '
        Me.gbValue.AppearanceHeader.Options.UseTextOptions = True
        Me.gbValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gbValue.Caption = "Value"
        Me.gbValue.Columns.Add(Me.BandedGridColumnValDel)
        Me.gbValue.Columns.Add(Me.BandedGridColumnValRTS)
        Me.gbValue.Columns.Add(Me.BandedGridColumnValSAL)
        Me.gbValue.Columns.Add(Me.BandedGridColumnValSOH)
        Me.gbValue.Columns.Add(Me.BandedGridColumnValSaas)
        Me.gbValue.Columns.Add(Me.BandedGridColumnValSaasDel)
        Me.gbValue.Name = "gbValue"
        Me.gbValue.VisibleIndex = 2
        Me.gbValue.Width = 412
        '
        'BandedGridColumnValDel
        '
        Me.BandedGridColumnValDel.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnValDel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnValDel.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnValDel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnValDel.Caption = "DEL"
        Me.BandedGridColumnValDel.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnValDel.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnValDel.FieldName = "del_val"
        Me.BandedGridColumnValDel.Name = "BandedGridColumnValDel"
        Me.BandedGridColumnValDel.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "del_val", "{0:N0}")})
        Me.BandedGridColumnValDel.Visible = True
        Me.BandedGridColumnValDel.Width = 67
        '
        'BandedGridColumnValRTS
        '
        Me.BandedGridColumnValRTS.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnValRTS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnValRTS.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnValRTS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnValRTS.Caption = "RTS"
        Me.BandedGridColumnValRTS.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnValRTS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnValRTS.FieldName = "ret_val"
        Me.BandedGridColumnValRTS.Name = "BandedGridColumnValRTS"
        Me.BandedGridColumnValRTS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ret_val", "{0:N0}")})
        Me.BandedGridColumnValRTS.Visible = True
        Me.BandedGridColumnValRTS.Width = 78
        '
        'BandedGridColumnValSAL
        '
        Me.BandedGridColumnValSAL.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnValSAL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnValSAL.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnValSAL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnValSAL.Caption = "SAL"
        Me.BandedGridColumnValSAL.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnValSAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnValSAL.FieldName = "sal_val"
        Me.BandedGridColumnValSAL.Name = "BandedGridColumnValSAL"
        Me.BandedGridColumnValSAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sal_val", "{0:N0}")})
        Me.BandedGridColumnValSAL.Visible = True
        Me.BandedGridColumnValSAL.Width = 78
        '
        'BandedGridColumnValSOH
        '
        Me.BandedGridColumnValSOH.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnValSOH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnValSOH.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnValSOH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnValSOH.Caption = "SOH"
        Me.BandedGridColumnValSOH.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnValSOH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnValSOH.FieldName = "soh_val"
        Me.BandedGridColumnValSOH.Name = "BandedGridColumnValSOH"
        Me.BandedGridColumnValSOH.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "soh_val", "{0:N0}")})
        Me.BandedGridColumnValSOH.Visible = True
        Me.BandedGridColumnValSOH.Width = 57
        '
        'BandedGridColumnValSaas
        '
        Me.BandedGridColumnValSaas.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnValSaas.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnValSaas.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnValSaas.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnValSaas.Caption = "% SAS"
        Me.BandedGridColumnValSaas.DisplayFormat.FormatString = "{0:N2}%"
        Me.BandedGridColumnValSaas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnValSaas.FieldName = "percent_sas_val"
        Me.BandedGridColumnValSaas.Name = "BandedGridColumnValSaas"
        Me.BandedGridColumnValSaas.Visible = True
        Me.BandedGridColumnValSaas.Width = 48
        '
        'BandedGridColumnValSaasDel
        '
        Me.BandedGridColumnValSaasDel.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnValSaasDel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnValSaasDel.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnValSaasDel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnValSaasDel.Caption = "SAL/DEL"
        Me.BandedGridColumnValSaasDel.DisplayFormat.FormatString = "{0:N2}%"
        Me.BandedGridColumnValSaasDel.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnValSaasDel.FieldName = "percent_sas_sal_del_val"
        Me.BandedGridColumnValSaasDel.Name = "BandedGridColumnValSaasDel"
        Me.BandedGridColumnValSaasDel.Visible = True
        Me.BandedGridColumnValSaasDel.Width = 84
        '
        'FormSalesReportTracking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 563)
        Me.Controls.Add(Me.GCListDesign)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesReportTracking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " Sales Tracking"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCListDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BGVListDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCListDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BGVListDesign As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDelQty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnRTSQty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnSalQty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnSOHQty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnpercentSaas As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPercentSaasDel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gbDetail As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gbQty As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gbValue As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnValDel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnValRTS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnValSAL As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnValSOH As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnValSaas As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnValSaasDel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
End Class
