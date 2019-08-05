<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingFKDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccountingFKDetail))
        Me.XTCFKDetail = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPNoFaktur = New DevExpress.XtraTab.XtraTabPage()
        Me.GCHeader = New DevExpress.XtraGrid.GridControl()
        Me.GVHeader = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_sales_pos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_sales_pos_faktur = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_total_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnpwp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnpwp_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnpwp_address = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnno_faktur = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnDiscard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnNext = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPExportedCSV = New DevExpress.XtraTab.XtraTabPage()
        Me.GCFK = New DevExpress.XtraGrid.GridControl()
        Me.GVFK = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn0 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrev = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExportAsCSV = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XTCFKDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCFKDetail.SuspendLayout()
        Me.XTPNoFaktur.SuspendLayout()
        CType(Me.GCHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.XTPExportedCSV.SuspendLayout()
        CType(Me.GCFK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCFKDetail
        '
        Me.XTCFKDetail.AppearancePage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XTCFKDetail.AppearancePage.HeaderActive.Options.UseFont = True
        Me.XTCFKDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCFKDetail.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCFKDetail.Location = New System.Drawing.Point(0, 0)
        Me.XTCFKDetail.LookAndFeel.SkinName = "Metropolis"
        Me.XTCFKDetail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.XTCFKDetail.Name = "XTCFKDetail"
        Me.XTCFKDetail.SelectedTabPage = Me.XTPNoFaktur
        Me.XTCFKDetail.Size = New System.Drawing.Size(783, 497)
        Me.XTCFKDetail.TabIndex = 0
        Me.XTCFKDetail.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPNoFaktur, Me.XTPExportedCSV})
        '
        'XTPNoFaktur
        '
        Me.XTPNoFaktur.Controls.Add(Me.GCHeader)
        Me.XTPNoFaktur.Controls.Add(Me.PanelControl1)
        Me.XTPNoFaktur.Name = "XTPNoFaktur"
        Me.XTPNoFaktur.Size = New System.Drawing.Size(781, 472)
        Me.XTPNoFaktur.Text = "Step I : No Faktur && NPWP"
        '
        'GCHeader
        '
        Me.GCHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCHeader.Location = New System.Drawing.Point(0, 0)
        Me.GCHeader.MainView = Me.GVHeader
        Me.GCHeader.Name = "GCHeader"
        Me.GCHeader.Size = New System.Drawing.Size(781, 432)
        Me.GCHeader.TabIndex = 1
        Me.GCHeader.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVHeader})
        '
        'GVHeader
        '
        Me.GVHeader.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_pos, Me.GridColumnid_sales_pos_faktur, Me.GridColumnsales_pos_number, Me.GridColumncomp, Me.GridColumnsales_pos_total, Me.GridColumnsales_pos_total_qty, Me.GridColumnnpwp, Me.GridColumnnpwp_name, Me.GridColumnnpwp_address, Me.GridColumnno_faktur})
        Me.GVHeader.GridControl = Me.GCHeader
        Me.GVHeader.Name = "GVHeader"
        Me.GVHeader.OptionsView.ColumnAutoWidth = False
        Me.GVHeader.OptionsView.RowAutoHeight = True
        Me.GVHeader.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_sales_pos
        '
        Me.GridColumnid_sales_pos.Caption = "id_sales_pos"
        Me.GridColumnid_sales_pos.FieldName = "id_sales_pos"
        Me.GridColumnid_sales_pos.Name = "GridColumnid_sales_pos"
        Me.GridColumnid_sales_pos.OptionsColumn.AllowEdit = False
        '
        'GridColumnid_sales_pos_faktur
        '
        Me.GridColumnid_sales_pos_faktur.Caption = "id_sales_pos_faktur"
        Me.GridColumnid_sales_pos_faktur.FieldName = "id_sales_pos_faktur"
        Me.GridColumnid_sales_pos_faktur.Name = "GridColumnid_sales_pos_faktur"
        Me.GridColumnid_sales_pos_faktur.OptionsColumn.AllowEdit = False
        '
        'GridColumnsales_pos_number
        '
        Me.GridColumnsales_pos_number.Caption = "Invoice"
        Me.GridColumnsales_pos_number.FieldName = "sales_pos_number"
        Me.GridColumnsales_pos_number.Name = "GridColumnsales_pos_number"
        Me.GridColumnsales_pos_number.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_number.Visible = True
        Me.GridColumnsales_pos_number.VisibleIndex = 0
        '
        'GridColumncomp
        '
        Me.GridColumncomp.Caption = "Store"
        Me.GridColumncomp.FieldName = "comp"
        Me.GridColumncomp.Name = "GridColumncomp"
        Me.GridColumncomp.OptionsColumn.AllowEdit = False
        Me.GridColumncomp.Visible = True
        Me.GridColumncomp.VisibleIndex = 1
        '
        'GridColumnsales_pos_total
        '
        Me.GridColumnsales_pos_total.Caption = "Amount"
        Me.GridColumnsales_pos_total.DisplayFormat.FormatString = "N2"
        Me.GridColumnsales_pos_total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_pos_total.FieldName = "sales_pos_total"
        Me.GridColumnsales_pos_total.Name = "GridColumnsales_pos_total"
        Me.GridColumnsales_pos_total.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_total.Visible = True
        Me.GridColumnsales_pos_total.VisibleIndex = 3
        '
        'GridColumnsales_pos_total_qty
        '
        Me.GridColumnsales_pos_total_qty.Caption = "Total Qty"
        Me.GridColumnsales_pos_total_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnsales_pos_total_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_pos_total_qty.FieldName = "sales_pos_total_qty"
        Me.GridColumnsales_pos_total_qty.Name = "GridColumnsales_pos_total_qty"
        Me.GridColumnsales_pos_total_qty.OptionsColumn.AllowEdit = False
        Me.GridColumnsales_pos_total_qty.Visible = True
        Me.GridColumnsales_pos_total_qty.VisibleIndex = 2
        '
        'GridColumnnpwp
        '
        Me.GridColumnnpwp.Caption = "NPWP*"
        Me.GridColumnnpwp.FieldName = "npwp"
        Me.GridColumnnpwp.Name = "GridColumnnpwp"
        Me.GridColumnnpwp.Visible = True
        Me.GridColumnnpwp.VisibleIndex = 5
        '
        'GridColumnnpwp_name
        '
        Me.GridColumnnpwp_name.Caption = "NPWP Name*"
        Me.GridColumnnpwp_name.FieldName = "npwp_name"
        Me.GridColumnnpwp_name.Name = "GridColumnnpwp_name"
        Me.GridColumnnpwp_name.Visible = True
        Me.GridColumnnpwp_name.VisibleIndex = 6
        '
        'GridColumnnpwp_address
        '
        Me.GridColumnnpwp_address.Caption = "NPWP Address*"
        Me.GridColumnnpwp_address.FieldName = "npwp_address"
        Me.GridColumnnpwp_address.Name = "GridColumnnpwp_address"
        Me.GridColumnnpwp_address.Visible = True
        Me.GridColumnnpwp_address.VisibleIndex = 7
        Me.GridColumnnpwp_address.Width = 100
        '
        'GridColumnno_faktur
        '
        Me.GridColumnno_faktur.Caption = "Nomer Faktur*"
        Me.GridColumnno_faktur.FieldName = "no_faktur"
        Me.GridColumnno_faktur.Name = "GridColumnno_faktur"
        Me.GridColumnno_faktur.Visible = True
        Me.GridColumnno_faktur.VisibleIndex = 4
        Me.GridColumnno_faktur.Width = 95
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.BtnDiscard)
        Me.PanelControl1.Controls.Add(Me.BtnNext)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 432)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(781, 40)
        Me.PanelControl1.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(13, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "(*) required fields"
        '
        'BtnDiscard
        '
        Me.BtnDiscard.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDiscard.Image = CType(resources.GetObject("BtnDiscard.Image"), System.Drawing.Image)
        Me.BtnDiscard.Location = New System.Drawing.Point(598, 2)
        Me.BtnDiscard.Name = "BtnDiscard"
        Me.BtnDiscard.Size = New System.Drawing.Size(88, 36)
        Me.BtnDiscard.TabIndex = 1
        Me.BtnDiscard.Text = "Discard"
        '
        'BtnNext
        '
        Me.BtnNext.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnNext.Image = CType(resources.GetObject("BtnNext.Image"), System.Drawing.Image)
        Me.BtnNext.Location = New System.Drawing.Point(686, 2)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(93, 36)
        Me.BtnNext.TabIndex = 0
        Me.BtnNext.Text = "Next Step"
        '
        'XTPExportedCSV
        '
        Me.XTPExportedCSV.Controls.Add(Me.GCFK)
        Me.XTPExportedCSV.Controls.Add(Me.PanelControl2)
        Me.XTPExportedCSV.Name = "XTPExportedCSV"
        Me.XTPExportedCSV.PageEnabled = False
        Me.XTPExportedCSV.Size = New System.Drawing.Size(781, 472)
        Me.XTPExportedCSV.Text = "Step II : Export as CSV"
        '
        'GCFK
        '
        Me.GCFK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFK.Location = New System.Drawing.Point(0, 0)
        Me.GCFK.MainView = Me.GVFK
        Me.GCFK.Name = "GCFK"
        Me.GCFK.Size = New System.Drawing.Size(781, 432)
        Me.GCFK.TabIndex = 4
        Me.GCFK.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFK})
        '
        'GVFK
        '
        Me.GVFK.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn0})
        Me.GVFK.GridControl = Me.GCFK
        Me.GVFK.Name = "GVFK"
        Me.GVFK.OptionsPrint.PrintHeader = False
        Me.GVFK.OptionsView.ShowColumnHeaders = False
        Me.GVFK.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "col1"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "GridColumn2"
        Me.GridColumn2.FieldName = "col2"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "GridColumn3"
        Me.GridColumn3.FieldName = "col3"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "GridColumn4"
        Me.GridColumn4.FieldName = "col4"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "GridColumn5"
        Me.GridColumn5.FieldName = "col5"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "GridColumn6"
        Me.GridColumn6.FieldName = "col6"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "GridColumn7"
        Me.GridColumn7.FieldName = "col7"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "GridColumn8"
        Me.GridColumn8.FieldName = "col8"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 7
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "GridColumn9"
        Me.GridColumn9.FieldName = "col9"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 8
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "GridColumn10"
        Me.GridColumn10.FieldName = "col10"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 9
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "GridColumn11"
        Me.GridColumn11.FieldName = "col11"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 10
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "GridColumn12"
        Me.GridColumn12.FieldName = "col12"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 11
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "GridColumn13"
        Me.GridColumn13.FieldName = "col13"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 12
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "GridColumn14"
        Me.GridColumn14.FieldName = "col14"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 13
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "GridColumn15"
        Me.GridColumn15.FieldName = "col15"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 14
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "GridColumn16"
        Me.GridColumn16.FieldName = "col16"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 15
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "GridColumn17"
        Me.GridColumn17.FieldName = "col17"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 16
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "GridColumn18"
        Me.GridColumn18.FieldName = "col18"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 17
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "GridColumn19"
        Me.GridColumn19.FieldName = "col19"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 18
        '
        'GridColumn0
        '
        Me.GridColumn0.Caption = "id"
        Me.GridColumn0.FieldName = "col0"
        Me.GridColumn0.Name = "GridColumn0"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnClose)
        Me.PanelControl2.Controls.Add(Me.BtnPrev)
        Me.PanelControl2.Controls.Add(Me.BtnExportAsCSV)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 432)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(781, 40)
        Me.PanelControl2.TabIndex = 3
        '
        'BtnClose
        '
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(495, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 36)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Close"
        '
        'BtnPrev
        '
        Me.BtnPrev.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrev.Image = CType(resources.GetObject("BtnPrev.Image"), System.Drawing.Image)
        Me.BtnPrev.Location = New System.Drawing.Point(575, 2)
        Me.BtnPrev.Name = "BtnPrev"
        Me.BtnPrev.Size = New System.Drawing.Size(88, 36)
        Me.BtnPrev.TabIndex = 1
        Me.BtnPrev.Text = "Previous"
        '
        'BtnExportAsCSV
        '
        Me.BtnExportAsCSV.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnExportAsCSV.Image = CType(resources.GetObject("BtnExportAsCSV.Image"), System.Drawing.Image)
        Me.BtnExportAsCSV.Location = New System.Drawing.Point(663, 2)
        Me.BtnExportAsCSV.Name = "BtnExportAsCSV"
        Me.BtnExportAsCSV.Size = New System.Drawing.Size(116, 36)
        Me.BtnExportAsCSV.TabIndex = 0
        Me.BtnExportAsCSV.Text = "Export as CSV"
        '
        'FormAccountingFKDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 497)
        Me.Controls.Add(Me.XTCFKDetail)
        Me.MinimizeBox = False
        Me.Name = "FormAccountingFKDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FK Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.XTCFKDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCFKDetail.ResumeLayout(False)
        Me.XTPNoFaktur.ResumeLayout(False)
        CType(Me.GCHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.XTPExportedCSV.ResumeLayout(False)
        CType(Me.GCFK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCFKDetail As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPNoFaktur As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPExportedCSV As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCHeader As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVHeader As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnNext As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnsales_pos_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sales_pos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_sales_pos_faktur As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_total_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnpwp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnpwp_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnpwp_address As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDiscard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnno_faktur As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrev As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExportAsCSV As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCFK As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFK As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn0 As DevExpress.XtraGrid.Columns.GridColumn
End Class
