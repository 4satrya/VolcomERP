<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportFormInvoiceTracking
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportFormInvoiceTracking))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCUnpaid = New DevExpress.XtraGrid.GridControl()
        Me.GVUnpaid = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepoLinkInvoice = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.GridColumn21 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumndue_days = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnmemo_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepoLinkMemoPenangguhan = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.BandedGridColumnpropose_delay_payment_due_date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumntotal_rec = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumntotaldue = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnmail_invoice_no = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepoLinkEmailInvoice = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.BandedGridColumnmail_invoice_date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnmail_invoice_status = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnLastNumberEN = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepoLinkEMailNotice = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.BandedGridColumnCreatedDateEN = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnStatusEN = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnLastNumberEW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepoLinkEmailWarning = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.BandedGridColumnCreatedDateEW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnStatusEW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnbbm_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepoLinkBBM = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.BandedGridColumnbbm_created_date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnbbm_received_date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnbbm_value = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnbbm_on_process = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnbtn_more_bbm = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepoBtnMoreBBM = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.BandedGridColumnid_mail_notice_no = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_mail_warning_no = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_bbm = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_mail_invoice = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_propose_delay_payment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.XLPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLStatus = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLStore = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLStoreGroup = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XLTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        CType(Me.GCUnpaid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVUnpaid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkMemoPenangguhan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkEmailInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkEMailNotice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkEmailWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoLinkBBM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoBtnMoreBBM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1, Me.XLPeriod, Me.XrLabel10, Me.XrLabel11, Me.XrLabel6, Me.XrLabel7, Me.XLStatus, Me.XrLabel2, Me.XrLabel4, Me.XLStore, Me.XLStoreGroup, Me.XrLabel3, Me.XrLabel1})
        Me.Detail.HeightF = 212.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 55.99997!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1075.0!, 156.0!)
        Me.WinControlContainer1.WinControl = Me.GCUnpaid
        '
        'GCUnpaid
        '
        Me.GCUnpaid.Location = New System.Drawing.Point(0, 0)
        Me.GCUnpaid.MainView = Me.GVUnpaid
        Me.GCUnpaid.Name = "GCUnpaid"
        Me.GCUnpaid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit3, Me.RepoBtnMoreBBM, Me.RepositoryItemCheckEdit2, Me.RepoLinkInvoice, Me.RepoLinkBBM, Me.RepoLinkEMailNotice, Me.RepoLinkEmailWarning, Me.RepoLinkEmailInvoice, Me.RepoLinkMemoPenangguhan})
        Me.GCUnpaid.Size = New System.Drawing.Size(1032, 150)
        Me.GCUnpaid.TabIndex = 20
        Me.GCUnpaid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVUnpaid})
        '
        'GVUnpaid
        '
        Me.GVUnpaid.AppearancePrint.BandPanel.BackColor = System.Drawing.Color.White
        Me.GVUnpaid.AppearancePrint.BandPanel.BorderColor = System.Drawing.Color.Black
        Me.GVUnpaid.AppearancePrint.BandPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVUnpaid.AppearancePrint.BandPanel.Options.UseBackColor = True
        Me.GVUnpaid.AppearancePrint.BandPanel.Options.UseBorderColor = True
        Me.GVUnpaid.AppearancePrint.BandPanel.Options.UseFont = True
        Me.GVUnpaid.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVUnpaid.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVUnpaid.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVUnpaid.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVUnpaid.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVUnpaid.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVUnpaid.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVUnpaid.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVUnpaid.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVUnpaid.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVUnpaid.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVUnpaid.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVUnpaid.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVUnpaid.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVUnpaid.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVUnpaid.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVUnpaid.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVUnpaid.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVUnpaid.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVUnpaid.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVUnpaid.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVUnpaid.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVUnpaid.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVUnpaid.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVUnpaid.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVUnpaid.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVUnpaid.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVUnpaid.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVUnpaid.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVUnpaid.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVUnpaid.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVUnpaid.AppearancePrint.Row.Options.UseFont = True
        Me.GVUnpaid.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand2, Me.GridBand1, Me.gridBand6, Me.gridBand3, Me.gridBand4, Me.gridBand5})
        Me.GVUnpaid.ColumnPanelRowHeight = 32
        Me.GVUnpaid.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn11, Me.BandedGridColumn1, Me.BandedGridColumn2, Me.GridColumn15, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.GridColumn18, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn24, Me.GridColumn27, Me.GridColumn28, Me.GridColumn30, Me.GridColumn31, Me.GridColumn32, Me.GridColumntotal_rec, Me.GridColumntotaldue, Me.GridColumndue_days, Me.GridColumn33, Me.BandedGridColumnLastNumberEN, Me.BandedGridColumnCreatedDateEN, Me.BandedGridColumnStatusEN, Me.BandedGridColumnid_mail_notice_no, Me.BandedGridColumnLastNumberEW, Me.BandedGridColumnCreatedDateEW, Me.BandedGridColumnStatusEW, Me.BandedGridColumnid_mail_warning_no, Me.BandedGridColumnbbm_number, Me.BandedGridColumnbbm_created_date, Me.BandedGridColumnbbm_received_date, Me.BandedGridColumnbtn_more_bbm, Me.BandedGridColumnbbm_value, Me.BandedGridColumnid_bbm, Me.BandedGridColumnmail_invoice_no, Me.BandedGridColumnid_mail_invoice, Me.BandedGridColumnmail_invoice_date, Me.BandedGridColumnmail_invoice_status, Me.BandedGridColumnbbm_on_process, Me.BandedGridColumnid_propose_delay_payment, Me.BandedGridColumnmemo_number, Me.BandedGridColumnpropose_delay_payment_due_date})
        Me.GVUnpaid.GridControl = Me.GCUnpaid
        Me.GVUnpaid.GroupCount = 1
        Me.GVUnpaid.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", Me.BandedGridColumn4, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_rec", Me.GridColumntotal_rec, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bbm_value", Me.BandedGridColumnbbm_value, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_due", Me.GridColumntotaldue, "{0:N2}")})
        Me.GVUnpaid.LevelIndent = 0
        Me.GVUnpaid.Name = "GVUnpaid"
        Me.GVUnpaid.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVUnpaid.OptionsFind.AlwaysVisible = True
        Me.GVUnpaid.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GVUnpaid.OptionsPrint.AllowMultilineHeaders = True
        Me.GVUnpaid.OptionsPrint.ExpandAllGroups = False
        Me.GVUnpaid.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GVUnpaid.OptionsView.ColumnAutoWidth = False
        Me.GVUnpaid.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVUnpaid.OptionsView.ShowFooter = True
        Me.GVUnpaid.OptionsView.ShowGroupPanel = False
        Me.GVUnpaid.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn27, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'gridBand2
        '
        Me.gridBand2.Columns.Add(Me.GridColumn7)
        Me.gridBand2.Columns.Add(Me.GridColumn9)
        Me.gridBand2.Columns.Add(Me.GridColumn21)
        Me.gridBand2.Columns.Add(Me.GridColumn20)
        Me.gridBand2.Columns.Add(Me.GridColumn27)
        Me.gridBand2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 0
        Me.gridBand2.Width = 252
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn7.Caption = "*"
        Me.GridColumn7.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumn7.FieldName = "is_check"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn9.Caption = "Number"
        Me.GridColumn9.FieldName = "sales_pos_number"
        Me.GridColumn9.MinWidth = 70
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        Me.GridColumn9.Visible = True
        Me.GridColumn9.Width = 70
        '
        'RepoLinkInvoice
        '
        Me.RepoLinkInvoice.AutoHeight = False
        Me.RepoLinkInvoice.Name = "RepoLinkInvoice"
        '
        'GridColumn21
        '
        Me.GridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn21.Caption = "Store Code"
        Me.GridColumn21.FieldName = "comp_number"
        Me.GridColumn21.MinWidth = 35
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.AllowEdit = False
        Me.GridColumn21.Visible = True
        Me.GridColumn21.Width = 35
        '
        'GridColumn20
        '
        Me.GridColumn20.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn20.Caption = "Store"
        Me.GridColumn20.FieldName = "comp_name"
        Me.GridColumn20.MinWidth = 70
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.AllowEdit = False
        Me.GridColumn20.Visible = True
        Me.GridColumn20.Width = 112
        '
        'GridColumn27
        '
        Me.GridColumn27.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn27.Caption = "Group Store"
        Me.GridColumn27.FieldName = "comp_group"
        Me.GridColumn27.MinWidth = 35
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.OptionsColumn.AllowEdit = False
        Me.GridColumn27.Visible = True
        Me.GridColumn27.Width = 35
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Detail Invoice"
        Me.GridBand1.Columns.Add(Me.GridColumn8)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand1.Columns.Add(Me.GridColumn15)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand1.Columns.Add(Me.GridColumn22)
        Me.GridBand1.Columns.Add(Me.GridColumn11)
        Me.GridBand1.Columns.Add(Me.GridColumn31)
        Me.GridBand1.Columns.Add(Me.GridColumn32)
        Me.GridBand1.Columns.Add(Me.GridColumn18)
        Me.GridBand1.Columns.Add(Me.GridColumndue_days)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnmemo_number)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnpropose_delay_payment_due_date)
        Me.GridBand1.Columns.Add(Me.GridColumn33)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand1.Columns.Add(Me.GridColumn24)
        Me.GridBand1.Columns.Add(Me.GridColumn28)
        Me.GridBand1.Columns.Add(Me.GridColumn30)
        Me.GridBand1.Columns.Add(Me.GridColumntotal_rec)
        Me.GridBand1.Columns.Add(Me.GridColumntotaldue)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 1
        Me.GridBand1.Width = 689
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn8.Caption = "ID"
        Me.GridColumn8.FieldName = "id_sales_pos"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumn1.Caption = "Total Sales"
        Me.BandedGridColumn1.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn1.FieldName = "sales_pos_total"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total", "{0:N2}")})
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumn2.Caption = "Store Discount (%)"
        Me.BandedGridColumn2.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn2.FieldName = "sales_pos_discount"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn2.Width = 127
        '
        'GridColumn15
        '
        Me.GridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn15.Caption = "VAT (%)"
        Me.GridColumn15.DisplayFormat.FormatString = "N2"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn15.FieldName = "sales_pos_vat"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn3.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumn3.Caption = "Potongan"
        Me.BandedGridColumn3.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn3.FieldName = "sales_pos_potongan"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.OptionsColumn.AllowEdit = False
        '
        'GridColumn22
        '
        Me.GridColumn22.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn22.Caption = "Type"
        Me.GridColumn22.FieldName = "report_mark_type_name"
        Me.GridColumn22.MinWidth = 60
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.AllowEdit = False
        Me.GridColumn22.Visible = True
        Me.GridColumn22.Width = 60
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn11.Caption = "Created Date"
        Me.GridColumn11.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn11.FieldName = "sales_pos_date"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.Width = 74
        '
        'GridColumn31
        '
        Me.GridColumn31.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn31.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn31.Caption = "Start Period"
        Me.GridColumn31.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GridColumn31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn31.FieldName = "sales_pos_start_period"
        Me.GridColumn31.MinWidth = 60
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsColumn.AllowEdit = False
        Me.GridColumn31.Visible = True
        Me.GridColumn31.Width = 60
        '
        'GridColumn32
        '
        Me.GridColumn32.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn32.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn32.Caption = "End Period"
        Me.GridColumn32.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GridColumn32.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn32.FieldName = "sales_pos_end_period"
        Me.GridColumn32.MinWidth = 60
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.Visible = True
        Me.GridColumn32.Width = 60
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn18.Caption = "Due Date"
        Me.GridColumn18.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn18.FieldName = "sales_pos_due_date"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.Visible = True
        Me.GridColumn18.Width = 48
        '
        'GridColumndue_days
        '
        Me.GridColumndue_days.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumndue_days.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumndue_days.Caption = "Due Days Origin"
        Me.GridColumndue_days.FieldName = "due_days"
        Me.GridColumndue_days.Name = "GridColumndue_days"
        Me.GridColumndue_days.OptionsColumn.AllowEdit = False
        Me.GridColumndue_days.Width = 98
        '
        'BandedGridColumnmemo_number
        '
        Me.BandedGridColumnmemo_number.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnmemo_number.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnmemo_number.Caption = "Memo Penangguhan"
        Me.BandedGridColumnmemo_number.FieldName = "memo_number"
        Me.BandedGridColumnmemo_number.Name = "BandedGridColumnmemo_number"
        Me.BandedGridColumnmemo_number.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnmemo_number.Visible = True
        Me.BandedGridColumnmemo_number.Width = 65
        '
        'RepoLinkMemoPenangguhan
        '
        Me.RepoLinkMemoPenangguhan.AutoHeight = False
        Me.RepoLinkMemoPenangguhan.Name = "RepoLinkMemoPenangguhan"
        '
        'BandedGridColumnpropose_delay_payment_due_date
        '
        Me.BandedGridColumnpropose_delay_payment_due_date.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnpropose_delay_payment_due_date.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnpropose_delay_payment_due_date.Caption = "Tgl. Penangguhan"
        Me.BandedGridColumnpropose_delay_payment_due_date.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.BandedGridColumnpropose_delay_payment_due_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnpropose_delay_payment_due_date.FieldName = "propose_delay_payment_due_date"
        Me.BandedGridColumnpropose_delay_payment_due_date.Name = "BandedGridColumnpropose_delay_payment_due_date"
        Me.BandedGridColumnpropose_delay_payment_due_date.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnpropose_delay_payment_due_date.Visible = True
        Me.BandedGridColumnpropose_delay_payment_due_date.Width = 72
        '
        'GridColumn33
        '
        Me.GridColumn33.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn33.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn33.Caption = "Age (Day)"
        Me.GridColumn33.FieldName = "due_days_view"
        Me.GridColumn33.MinWidth = 40
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.OptionsColumn.AllowEdit = False
        Me.GridColumn33.UnboundExpression = "Iif([due_days] = 0, [due_days], Iif([due_days] < 0, [due_days], Concat('+', [due_" &
    "days])))"
        Me.GridColumn33.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.GridColumn33.Visible = True
        Me.GridColumn33.Width = 40
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn4.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn4.Caption = "Invoice Amount"
        Me.BandedGridColumn4.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn4.FieldName = "amount"
        Me.BandedGridColumn4.MinWidth = 70
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.BandedGridColumn4.Visible = True
        Me.BandedGridColumn4.Width = 70
        '
        'GridColumn24
        '
        Me.GridColumn24.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn24.Caption = "Id Invoice Type"
        Me.GridColumn24.FieldName = "report_mark_type"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        '
        'GridColumn28
        '
        Me.GridColumn28.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn28.Caption = "id_comp"
        Me.GridColumn28.FieldName = "id_comp"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.OptionsColumn.AllowEdit = False
        '
        'GridColumn30
        '
        Me.GridColumn30.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn30.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumn30.Caption = "Total Qty"
        Me.GridColumn30.DisplayFormat.FormatString = "N0"
        Me.GridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn30.FieldName = "sales_pos_total_qty"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.OptionsColumn.AllowEdit = False
        Me.GridColumn30.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total_qty", "{0:N0}")})
        '
        'GridColumntotal_rec
        '
        Me.GridColumntotal_rec.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumntotal_rec.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumntotal_rec.Caption = "Amount Paid"
        Me.GridColumntotal_rec.DisplayFormat.FormatString = "N2"
        Me.GridColumntotal_rec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_rec.FieldName = "total_rec"
        Me.GridColumntotal_rec.MinWidth = 70
        Me.GridColumntotal_rec.Name = "GridColumntotal_rec"
        Me.GridColumntotal_rec.OptionsColumn.AllowEdit = False
        Me.GridColumntotal_rec.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_rec", "{0:N2}")})
        Me.GridColumntotal_rec.Visible = True
        Me.GridColumntotal_rec.Width = 70
        '
        'GridColumntotaldue
        '
        Me.GridColumntotaldue.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumntotaldue.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumntotaldue.Caption = "Diff"
        Me.GridColumntotaldue.DisplayFormat.FormatString = "N2"
        Me.GridColumntotaldue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotaldue.FieldName = "total_due"
        Me.GridColumntotaldue.MinWidth = 70
        Me.GridColumntotaldue.Name = "GridColumntotaldue"
        Me.GridColumntotaldue.OptionsColumn.AllowEdit = False
        Me.GridColumntotaldue.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_due", "{0:N2}")})
        Me.GridColumntotaldue.Visible = True
        Me.GridColumntotaldue.Width = 70
        '
        'gridBand6
        '
        Me.gridBand6.Caption = "Email Invoice"
        Me.gridBand6.Columns.Add(Me.BandedGridColumnmail_invoice_no)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnmail_invoice_date)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnmail_invoice_status)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.Visible = False
        Me.gridBand6.VisibleIndex = -1
        Me.gridBand6.Width = 225
        '
        'BandedGridColumnmail_invoice_no
        '
        Me.BandedGridColumnmail_invoice_no.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnmail_invoice_no.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnmail_invoice_no.Caption = "Last Number"
        Me.BandedGridColumnmail_invoice_no.ColumnEdit = Me.RepoLinkEmailInvoice
        Me.BandedGridColumnmail_invoice_no.FieldName = "mail_invoice_no"
        Me.BandedGridColumnmail_invoice_no.Name = "BandedGridColumnmail_invoice_no"
        Me.BandedGridColumnmail_invoice_no.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnmail_invoice_no.Visible = True
        '
        'RepoLinkEmailInvoice
        '
        Me.RepoLinkEmailInvoice.AutoHeight = False
        Me.RepoLinkEmailInvoice.Name = "RepoLinkEmailInvoice"
        '
        'BandedGridColumnmail_invoice_date
        '
        Me.BandedGridColumnmail_invoice_date.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnmail_invoice_date.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnmail_invoice_date.Caption = "Date"
        Me.BandedGridColumnmail_invoice_date.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.BandedGridColumnmail_invoice_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnmail_invoice_date.FieldName = "mail_invoice_date"
        Me.BandedGridColumnmail_invoice_date.Name = "BandedGridColumnmail_invoice_date"
        Me.BandedGridColumnmail_invoice_date.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnmail_invoice_date.Visible = True
        '
        'BandedGridColumnmail_invoice_status
        '
        Me.BandedGridColumnmail_invoice_status.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnmail_invoice_status.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnmail_invoice_status.Caption = "Status"
        Me.BandedGridColumnmail_invoice_status.FieldName = "mail_invoice_status"
        Me.BandedGridColumnmail_invoice_status.Name = "BandedGridColumnmail_invoice_status"
        Me.BandedGridColumnmail_invoice_status.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnmail_invoice_status.Visible = True
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "Email Pemberitahuan"
        Me.gridBand3.Columns.Add(Me.BandedGridColumnLastNumberEN)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnCreatedDateEN)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnStatusEN)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.Visible = False
        Me.gridBand3.VisibleIndex = -1
        Me.gridBand3.Width = 225
        '
        'BandedGridColumnLastNumberEN
        '
        Me.BandedGridColumnLastNumberEN.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnLastNumberEN.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnLastNumberEN.Caption = "Last Number"
        Me.BandedGridColumnLastNumberEN.ColumnEdit = Me.RepoLinkEMailNotice
        Me.BandedGridColumnLastNumberEN.FieldName = "mail_notice_no"
        Me.BandedGridColumnLastNumberEN.Name = "BandedGridColumnLastNumberEN"
        Me.BandedGridColumnLastNumberEN.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnLastNumberEN.Visible = True
        '
        'RepoLinkEMailNotice
        '
        Me.RepoLinkEMailNotice.AutoHeight = False
        Me.RepoLinkEMailNotice.Name = "RepoLinkEMailNotice"
        '
        'BandedGridColumnCreatedDateEN
        '
        Me.BandedGridColumnCreatedDateEN.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnCreatedDateEN.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnCreatedDateEN.Caption = "Date"
        Me.BandedGridColumnCreatedDateEN.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.BandedGridColumnCreatedDateEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnCreatedDateEN.FieldName = "mail_notice_date"
        Me.BandedGridColumnCreatedDateEN.Name = "BandedGridColumnCreatedDateEN"
        Me.BandedGridColumnCreatedDateEN.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnCreatedDateEN.Visible = True
        '
        'BandedGridColumnStatusEN
        '
        Me.BandedGridColumnStatusEN.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnStatusEN.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnStatusEN.Caption = "Status"
        Me.BandedGridColumnStatusEN.FieldName = "mail_notice_status"
        Me.BandedGridColumnStatusEN.Name = "BandedGridColumnStatusEN"
        Me.BandedGridColumnStatusEN.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnStatusEN.Visible = True
        '
        'gridBand4
        '
        Me.gridBand4.Caption = "Email Peringatan"
        Me.gridBand4.Columns.Add(Me.BandedGridColumnLastNumberEW)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnCreatedDateEW)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnStatusEW)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.Visible = False
        Me.gridBand4.VisibleIndex = -1
        Me.gridBand4.Width = 302
        '
        'BandedGridColumnLastNumberEW
        '
        Me.BandedGridColumnLastNumberEW.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnLastNumberEW.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnLastNumberEW.Caption = "Last Number"
        Me.BandedGridColumnLastNumberEW.ColumnEdit = Me.RepoLinkEmailWarning
        Me.BandedGridColumnLastNumberEW.FieldName = "mail_warning_no"
        Me.BandedGridColumnLastNumberEW.Name = "BandedGridColumnLastNumberEW"
        Me.BandedGridColumnLastNumberEW.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnLastNumberEW.Visible = True
        Me.BandedGridColumnLastNumberEW.Width = 115
        '
        'RepoLinkEmailWarning
        '
        Me.RepoLinkEmailWarning.AutoHeight = False
        Me.RepoLinkEmailWarning.Name = "RepoLinkEmailWarning"
        '
        'BandedGridColumnCreatedDateEW
        '
        Me.BandedGridColumnCreatedDateEW.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnCreatedDateEW.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnCreatedDateEW.Caption = "Date"
        Me.BandedGridColumnCreatedDateEW.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.BandedGridColumnCreatedDateEW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnCreatedDateEW.FieldName = "mail_warning_date"
        Me.BandedGridColumnCreatedDateEW.Name = "BandedGridColumnCreatedDateEW"
        Me.BandedGridColumnCreatedDateEW.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnCreatedDateEW.Visible = True
        Me.BandedGridColumnCreatedDateEW.Width = 112
        '
        'BandedGridColumnStatusEW
        '
        Me.BandedGridColumnStatusEW.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnStatusEW.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnStatusEW.Caption = "Status"
        Me.BandedGridColumnStatusEW.FieldName = "mail_warning_status"
        Me.BandedGridColumnStatusEW.Name = "BandedGridColumnStatusEW"
        Me.BandedGridColumnStatusEW.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnStatusEW.Visible = True
        '
        'gridBand5
        '
        Me.gridBand5.Caption = "Bukti Bank Masuk"
        Me.gridBand5.Columns.Add(Me.BandedGridColumnbbm_number)
        Me.gridBand5.Columns.Add(Me.BandedGridColumnbbm_created_date)
        Me.gridBand5.Columns.Add(Me.BandedGridColumnbbm_received_date)
        Me.gridBand5.Columns.Add(Me.BandedGridColumnbbm_value)
        Me.gridBand5.Columns.Add(Me.BandedGridColumnbbm_on_process)
        Me.gridBand5.Columns.Add(Me.BandedGridColumnbtn_more_bbm)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.Visible = False
        Me.gridBand5.VisibleIndex = -1
        Me.gridBand5.Width = 450
        '
        'BandedGridColumnbbm_number
        '
        Me.BandedGridColumnbbm_number.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnbbm_number.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnbbm_number.Caption = "Last Number"
        Me.BandedGridColumnbbm_number.ColumnEdit = Me.RepoLinkBBM
        Me.BandedGridColumnbbm_number.FieldName = "bbm_number"
        Me.BandedGridColumnbbm_number.Name = "BandedGridColumnbbm_number"
        Me.BandedGridColumnbbm_number.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnbbm_number.Visible = True
        '
        'RepoLinkBBM
        '
        Me.RepoLinkBBM.AutoHeight = False
        Me.RepoLinkBBM.Name = "RepoLinkBBM"
        '
        'BandedGridColumnbbm_created_date
        '
        Me.BandedGridColumnbbm_created_date.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnbbm_created_date.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnbbm_created_date.Caption = "Created Date"
        Me.BandedGridColumnbbm_created_date.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.BandedGridColumnbbm_created_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnbbm_created_date.FieldName = "bbm_created_date"
        Me.BandedGridColumnbbm_created_date.MinWidth = 60
        Me.BandedGridColumnbbm_created_date.Name = "BandedGridColumnbbm_created_date"
        Me.BandedGridColumnbbm_created_date.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnbbm_created_date.Visible = True
        Me.BandedGridColumnbbm_created_date.Width = 60
        '
        'BandedGridColumnbbm_received_date
        '
        Me.BandedGridColumnbbm_received_date.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnbbm_received_date.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnbbm_received_date.Caption = "Bank Received Date"
        Me.BandedGridColumnbbm_received_date.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.BandedGridColumnbbm_received_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnbbm_received_date.FieldName = "bbm_received_date"
        Me.BandedGridColumnbbm_received_date.Name = "BandedGridColumnbbm_received_date"
        Me.BandedGridColumnbbm_received_date.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnbbm_received_date.Visible = True
        Me.BandedGridColumnbbm_received_date.Width = 106
        '
        'BandedGridColumnbbm_value
        '
        Me.BandedGridColumnbbm_value.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnbbm_value.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnbbm_value.Caption = "Amount"
        Me.BandedGridColumnbbm_value.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnbbm_value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnbbm_value.FieldName = "bbm_value"
        Me.BandedGridColumnbbm_value.Name = "BandedGridColumnbbm_value"
        Me.BandedGridColumnbbm_value.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bbm_value", "{0:N2}")})
        Me.BandedGridColumnbbm_value.Visible = True
        '
        'BandedGridColumnbbm_on_process
        '
        Me.BandedGridColumnbbm_on_process.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnbbm_on_process.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnbbm_on_process.Caption = "On Process"
        Me.BandedGridColumnbbm_on_process.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnbbm_on_process.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnbbm_on_process.FieldName = "bbm_on_process"
        Me.BandedGridColumnbbm_on_process.Name = "BandedGridColumnbbm_on_process"
        Me.BandedGridColumnbbm_on_process.Visible = True
        '
        'BandedGridColumnbtn_more_bbm
        '
        Me.BandedGridColumnbtn_more_bbm.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnbtn_more_bbm.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnbtn_more_bbm.Caption = "  "
        Me.BandedGridColumnbtn_more_bbm.ColumnEdit = Me.RepoBtnMoreBBM
        Me.BandedGridColumnbtn_more_bbm.FieldName = "btn_more_bbm"
        Me.BandedGridColumnbtn_more_bbm.Name = "BandedGridColumnbtn_more_bbm"
        Me.BandedGridColumnbtn_more_bbm.Visible = True
        '
        'RepoBtnMoreBBM
        '
        Me.RepoBtnMoreBBM.AutoHeight = False
        SerializableAppearanceObject1.BackColor = System.Drawing.Color.Teal
        SerializableAppearanceObject1.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject1.ForeColor = System.Drawing.Color.White
        SerializableAppearanceObject1.Options.UseBackColor = True
        SerializableAppearanceObject1.Options.UseFont = True
        SerializableAppearanceObject1.Options.UseForeColor = True
        Me.RepoBtnMoreBBM.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "More BBM", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.RepoBtnMoreBBM.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.RepoBtnMoreBBM.Name = "RepoBtnMoreBBM"
        Me.RepoBtnMoreBBM.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'BandedGridColumnid_mail_notice_no
        '
        Me.BandedGridColumnid_mail_notice_no.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnid_mail_notice_no.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnid_mail_notice_no.Caption = "id_mail_notice_no"
        Me.BandedGridColumnid_mail_notice_no.FieldName = "id_mail_notice_no"
        Me.BandedGridColumnid_mail_notice_no.Name = "BandedGridColumnid_mail_notice_no"
        Me.BandedGridColumnid_mail_notice_no.OptionsColumn.ReadOnly = True
        '
        'BandedGridColumnid_mail_warning_no
        '
        Me.BandedGridColumnid_mail_warning_no.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnid_mail_warning_no.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnid_mail_warning_no.Caption = "id_mail_warning_no"
        Me.BandedGridColumnid_mail_warning_no.FieldName = "id_mail_warning_no"
        Me.BandedGridColumnid_mail_warning_no.Name = "BandedGridColumnid_mail_warning_no"
        Me.BandedGridColumnid_mail_warning_no.OptionsColumn.ReadOnly = True
        '
        'BandedGridColumnid_bbm
        '
        Me.BandedGridColumnid_bbm.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnid_bbm.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnid_bbm.Caption = "id_bbm"
        Me.BandedGridColumnid_bbm.FieldName = "id_bbm"
        Me.BandedGridColumnid_bbm.Name = "BandedGridColumnid_bbm"
        Me.BandedGridColumnid_bbm.OptionsColumn.ReadOnly = True
        '
        'BandedGridColumnid_mail_invoice
        '
        Me.BandedGridColumnid_mail_invoice.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnid_mail_invoice.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnid_mail_invoice.Caption = "id_mail_invoice"
        Me.BandedGridColumnid_mail_invoice.FieldName = "id_mail_invoice"
        Me.BandedGridColumnid_mail_invoice.Name = "BandedGridColumnid_mail_invoice"
        Me.BandedGridColumnid_mail_invoice.OptionsColumn.ReadOnly = True
        '
        'BandedGridColumnid_propose_delay_payment
        '
        Me.BandedGridColumnid_propose_delay_payment.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnid_propose_delay_payment.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnid_propose_delay_payment.Caption = "id_propose_delay_payment"
        Me.BandedGridColumnid_propose_delay_payment.FieldName = "id_propose_delay_payment"
        Me.BandedGridColumnid_propose_delay_payment.Name = "BandedGridColumnid_propose_delay_payment"
        Me.BandedGridColumnid_propose_delay_payment.OptionsColumn.AllowEdit = False
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        Me.RepositoryItemCheckEdit3.PictureChecked = CType(resources.GetObject("RepositoryItemCheckEdit3.PictureChecked"), System.Drawing.Image)
        Me.RepositoryItemCheckEdit3.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit3.ValueUnchecked = "No"
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'XLPeriod
        '
        Me.XLPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XLPeriod.LocationFloat = New DevExpress.Utils.PointFloat(875.0!, 22.99999!)
        Me.XLPeriod.Name = "XLPeriod"
        Me.XLPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLPeriod.SizeF = New System.Drawing.SizeF(200.0!, 23.0!)
        Me.XLPeriod.StylePriority.UseFont = False
        Me.XLPeriod.StylePriority.UseTextAlignment = False
        Me.XLPeriod.Text = "[period]"
        Me.XLPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel10
        '
        Me.XrLabel10.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(860.0!, 22.99999!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = ":"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel11
        '
        Me.XrLabel11.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(760.0!, 22.99999!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "Period"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(759.9999!, 0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "Status"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(860.0!, 0!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = ":"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLStatus
        '
        Me.XLStatus.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XLStatus.LocationFloat = New DevExpress.Utils.PointFloat(874.9999!, 0!)
        Me.XLStatus.Name = "XLStatus"
        Me.XLStatus.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLStatus.SizeF = New System.Drawing.SizeF(200.0!, 23.0!)
        Me.XLStatus.StylePriority.UseFont = False
        Me.XLStatus.StylePriority.UseTextAlignment = False
        Me.XLStatus.Text = "[status]"
        Me.XLStatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0001907349!, 22.99999!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Store"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(100.0002!, 22.99999!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = ":"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLStore
        '
        Me.XLStore.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XLStore.LocationFloat = New DevExpress.Utils.PointFloat(115.0002!, 22.99999!)
        Me.XLStore.Name = "XLStore"
        Me.XLStore.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLStore.SizeF = New System.Drawing.SizeF(200.0!, 23.0!)
        Me.XLStore.StylePriority.UseFont = False
        Me.XLStore.StylePriority.UseTextAlignment = False
        Me.XLStore.Text = "[store]"
        Me.XLStore.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLStoreGroup
        '
        Me.XLStoreGroup.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XLStoreGroup.LocationFloat = New DevExpress.Utils.PointFloat(115.0002!, 0!)
        Me.XLStoreGroup.Name = "XLStoreGroup"
        Me.XLStoreGroup.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLStoreGroup.SizeF = New System.Drawing.SizeF(200.0!, 23.0!)
        Me.XLStoreGroup.StylePriority.UseFont = False
        Me.XLStoreGroup.StylePriority.UseTextAlignment = False
        Me.XLStoreGroup.Text = "[storegroup]"
        Me.XLStoreGroup.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(100.0002!, 0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = ":"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0001907349!, 0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Store Group"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 50.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 50.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(925.0001!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XLTitle, Me.XrPictureBox1, Me.XrLine1})
        Me.ReportHeader.HeightF = 91.15001!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XLTitle
        '
        Me.XLTitle.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.XLTitle.LocationFloat = New DevExpress.Utils.PointFloat(220.0!, 10.0!)
        Me.XLTitle.Multiline = True
        Me.XLTitle.Name = "XLTitle"
        Me.XLTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLTitle.SizeF = New System.Drawing.SizeF(635.0002!, 41.15001!)
        Me.XLTitle.StylePriority.UseFont = False
        Me.XLTitle.StylePriority.UseTextAlignment = False
        Me.XLTitle.Text = "Invoice Tracking"
        Me.XLTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(220.0!, 41.15!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 61.15001!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(1075.0!, 20.0!)
        '
        'ReportFormInvoiceTracking
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 69, 50, 50)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCUnpaid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVUnpaid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkMemoPenangguhan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkEmailInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkEMailNotice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkEmailWarning, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoLinkBBM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoBtnMoreBBM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XLTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XLStoreGroup As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLStatus As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLStore As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCUnpaid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVUnpaid As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepoLinkInvoice As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumndue_days As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnmemo_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepoLinkMemoPenangguhan As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents BandedGridColumnpropose_delay_payment_due_date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumntotal_rec As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumntotaldue As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnmail_invoice_no As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepoLinkEmailInvoice As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents BandedGridColumnmail_invoice_date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnmail_invoice_status As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnLastNumberEN As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepoLinkEMailNotice As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents BandedGridColumnCreatedDateEN As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnStatusEN As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnLastNumberEW As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepoLinkEmailWarning As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents BandedGridColumnCreatedDateEW As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnStatusEW As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnbbm_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepoLinkBBM As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents BandedGridColumnbbm_created_date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnbbm_received_date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnbbm_value As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnbbm_on_process As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnbtn_more_bbm As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepoBtnMoreBBM As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents BandedGridColumnid_mail_notice_no As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_mail_warning_no As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_bbm As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_mail_invoice As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_propose_delay_payment As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
End Class
