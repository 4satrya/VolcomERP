<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesProbTransHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesProbTransHistory))
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPriceRecon = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPriceRecon = New DevExpress.XtraGrid.GridControl()
        Me.GVPriceRecon = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_sales_pos_recon = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncreated_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_confirm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewPriceRecon = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPInvoice = New DevExpress.XtraTab.XtraTabPage()
        Me.GCInv = New DevExpress.XtraGrid.GridControl()
        Me.GVInv = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_sales_pos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_start_period = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_end_period = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_report_status_invv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status_inv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnref_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumninv_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_mark_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnViewInv = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrintInvoice = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPPriceRecon.SuspendLayout()
        CType(Me.GCPriceRecon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPriceRecon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.XTPInvoice.SuspendLayout()
        CType(Me.GCInv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.Location = New System.Drawing.Point(0, 0)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPPriceRecon
        Me.XTCData.Size = New System.Drawing.Size(657, 348)
        Me.XTCData.TabIndex = 0
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPriceRecon, Me.XTPInvoice})
        '
        'XTPPriceRecon
        '
        Me.XTPPriceRecon.Controls.Add(Me.GCPriceRecon)
        Me.XTPPriceRecon.Controls.Add(Me.PanelControl1)
        Me.XTPPriceRecon.Name = "XTPPriceRecon"
        Me.XTPPriceRecon.Size = New System.Drawing.Size(651, 320)
        Me.XTPPriceRecon.Text = "Price Reconcile"
        '
        'GCPriceRecon
        '
        Me.GCPriceRecon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPriceRecon.Location = New System.Drawing.Point(0, 43)
        Me.GCPriceRecon.MainView = Me.GVPriceRecon
        Me.GCPriceRecon.Name = "GCPriceRecon"
        Me.GCPriceRecon.Size = New System.Drawing.Size(651, 277)
        Me.GCPriceRecon.TabIndex = 1
        Me.GCPriceRecon.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPriceRecon})
        '
        'GVPriceRecon
        '
        Me.GVPriceRecon.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_pos_recon, Me.GridColumnnumber, Me.GridColumncreated_date, Me.GridColumnnote, Me.GridColumnid_report_status, Me.GridColumnreport_status, Me.GridColumnis_confirm})
        Me.GVPriceRecon.GridControl = Me.GCPriceRecon
        Me.GVPriceRecon.Name = "GVPriceRecon"
        Me.GVPriceRecon.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPriceRecon.OptionsBehavior.ReadOnly = True
        Me.GVPriceRecon.OptionsFind.AlwaysVisible = True
        Me.GVPriceRecon.OptionsView.ColumnAutoWidth = False
        Me.GVPriceRecon.OptionsView.ShowFooter = True
        Me.GVPriceRecon.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_sales_pos_recon
        '
        Me.GridColumnid_sales_pos_recon.Caption = "id_sales_pos_recon"
        Me.GridColumnid_sales_pos_recon.FieldName = "id_sales_pos_recon"
        Me.GridColumnid_sales_pos_recon.Name = "GridColumnid_sales_pos_recon"
        '
        'GridColumnnumber
        '
        Me.GridColumnnumber.Caption = "Number"
        Me.GridColumnnumber.FieldName = "number"
        Me.GridColumnnumber.Name = "GridColumnnumber"
        Me.GridColumnnumber.Visible = True
        Me.GridColumnnumber.VisibleIndex = 0
        '
        'GridColumncreated_date
        '
        Me.GridColumncreated_date.Caption = "Created Date"
        Me.GridColumncreated_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm:ss"
        Me.GridColumncreated_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumncreated_date.FieldName = "created_date"
        Me.GridColumncreated_date.Name = "GridColumncreated_date"
        Me.GridColumncreated_date.Visible = True
        Me.GridColumncreated_date.VisibleIndex = 1
        '
        'GridColumnnote
        '
        Me.GridColumnnote.Caption = "Note"
        Me.GridColumnnote.FieldName = "note"
        Me.GridColumnnote.Name = "GridColumnnote"
        '
        'GridColumnid_report_status
        '
        Me.GridColumnid_report_status.Caption = "id_report_status"
        Me.GridColumnid_report_status.FieldName = "id_report_status"
        Me.GridColumnid_report_status.Name = "GridColumnid_report_status"
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status"
        Me.GridColumnreport_status.FieldName = "report_status"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 2
        '
        'GridColumnis_confirm
        '
        Me.GridColumnis_confirm.Caption = "is_confirm"
        Me.GridColumnis_confirm.FieldName = "is_confirm"
        Me.GridColumnis_confirm.Name = "GridColumnis_confirm"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnViewPriceRecon)
        Me.PanelControl1.Controls.Add(Me.BtnPrint)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(651, 43)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnViewPriceRecon
        '
        Me.BtnViewPriceRecon.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewPriceRecon.Image = CType(resources.GetObject("BtnViewPriceRecon.Image"), System.Drawing.Image)
        Me.BtnViewPriceRecon.Location = New System.Drawing.Point(485, 2)
        Me.BtnViewPriceRecon.Name = "BtnViewPriceRecon"
        Me.BtnViewPriceRecon.Size = New System.Drawing.Size(82, 39)
        Me.BtnViewPriceRecon.TabIndex = 0
        Me.BtnViewPriceRecon.Text = "View"
        '
        'XTPInvoice
        '
        Me.XTPInvoice.Controls.Add(Me.GCInv)
        Me.XTPInvoice.Controls.Add(Me.PanelControl2)
        Me.XTPInvoice.Name = "XTPInvoice"
        Me.XTPInvoice.Size = New System.Drawing.Size(651, 320)
        Me.XTPInvoice.Text = "Sales Invoice"
        '
        'GCInv
        '
        Me.GCInv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInv.Location = New System.Drawing.Point(0, 43)
        Me.GCInv.MainView = Me.GVInv
        Me.GCInv.Name = "GCInv"
        Me.GCInv.Size = New System.Drawing.Size(651, 277)
        Me.GCInv.TabIndex = 2
        Me.GCInv.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInv})
        '
        'GVInv
        '
        Me.GVInv.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_pos, Me.GridColumnsales_pos_number, Me.GridColumnsales_pos_date, Me.GridColumnsales_pos_start_period, Me.GridColumnsales_pos_end_period, Me.GridColumnid_comp, Me.GridColumncomp_number, Me.GridColumncomp_name, Me.GridColumncomp, Me.GridColumncomp_group, Me.GridColumnid_report_status_invv, Me.GridColumnreport_status_inv, Me.GridColumnref_type, Me.GridColumninv_type, Me.GridColumnreport_mark_type})
        Me.GVInv.GridControl = Me.GCInv
        Me.GVInv.Name = "GVInv"
        Me.GVInv.OptionsBehavior.ReadOnly = True
        Me.GVInv.OptionsFind.AlwaysVisible = True
        Me.GVInv.OptionsView.ColumnAutoWidth = False
        Me.GVInv.OptionsView.ShowFooter = True
        Me.GVInv.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_sales_pos
        '
        Me.GridColumnid_sales_pos.Caption = "id_sales_pos"
        Me.GridColumnid_sales_pos.FieldName = "id_sales_pos"
        Me.GridColumnid_sales_pos.Name = "GridColumnid_sales_pos"
        '
        'GridColumnsales_pos_number
        '
        Me.GridColumnsales_pos_number.Caption = "Invoice No."
        Me.GridColumnsales_pos_number.FieldName = "sales_pos_number"
        Me.GridColumnsales_pos_number.Name = "GridColumnsales_pos_number"
        Me.GridColumnsales_pos_number.Visible = True
        Me.GridColumnsales_pos_number.VisibleIndex = 0
        '
        'GridColumnsales_pos_date
        '
        Me.GridColumnsales_pos_date.Caption = "Created Date"
        Me.GridColumnsales_pos_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_date.FieldName = "sales_pos_date"
        Me.GridColumnsales_pos_date.Name = "GridColumnsales_pos_date"
        Me.GridColumnsales_pos_date.Visible = True
        Me.GridColumnsales_pos_date.VisibleIndex = 5
        '
        'GridColumnsales_pos_start_period
        '
        Me.GridColumnsales_pos_start_period.Caption = "Start Period"
        Me.GridColumnsales_pos_start_period.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_start_period.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_start_period.FieldName = "sales_pos_start_period"
        Me.GridColumnsales_pos_start_period.Name = "GridColumnsales_pos_start_period"
        Me.GridColumnsales_pos_start_period.Visible = True
        Me.GridColumnsales_pos_start_period.VisibleIndex = 6
        '
        'GridColumnsales_pos_end_period
        '
        Me.GridColumnsales_pos_end_period.Caption = "End Period"
        Me.GridColumnsales_pos_end_period.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_end_period.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_end_period.FieldName = "sales_pos_end_period"
        Me.GridColumnsales_pos_end_period.Name = "GridColumnsales_pos_end_period"
        Me.GridColumnsales_pos_end_period.Visible = True
        Me.GridColumnsales_pos_end_period.VisibleIndex = 7
        '
        'GridColumnid_comp
        '
        Me.GridColumnid_comp.Caption = "id_comp"
        Me.GridColumnid_comp.FieldName = "id_comp"
        Me.GridColumnid_comp.Name = "GridColumnid_comp"
        '
        'GridColumncomp_number
        '
        Me.GridColumncomp_number.Caption = "Account"
        Me.GridColumncomp_number.FieldName = "comp_number"
        Me.GridColumncomp_number.Name = "GridColumncomp_number"
        '
        'GridColumncomp_name
        '
        Me.GridColumncomp_name.Caption = "Acc. Description"
        Me.GridColumncomp_name.FieldName = "comp_name"
        Me.GridColumncomp_name.Name = "GridColumncomp_name"
        '
        'GridColumncomp
        '
        Me.GridColumncomp.Caption = "Account"
        Me.GridColumncomp.FieldName = "comp"
        Me.GridColumncomp.Name = "GridColumncomp"
        Me.GridColumncomp.Visible = True
        Me.GridColumncomp.VisibleIndex = 2
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Store Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 3
        '
        'GridColumnid_report_status_invv
        '
        Me.GridColumnid_report_status_invv.Caption = "id_report_status"
        Me.GridColumnid_report_status_invv.FieldName = "id_report_status"
        Me.GridColumnid_report_status_invv.Name = "GridColumnid_report_status_invv"
        '
        'GridColumnreport_status_inv
        '
        Me.GridColumnreport_status_inv.Caption = "Status"
        Me.GridColumnreport_status_inv.FieldName = "report_status"
        Me.GridColumnreport_status_inv.Name = "GridColumnreport_status_inv"
        Me.GridColumnreport_status_inv.Visible = True
        Me.GridColumnreport_status_inv.VisibleIndex = 8
        '
        'GridColumnref_type
        '
        Me.GridColumnref_type.Caption = "Ref. Type"
        Me.GridColumnref_type.FieldName = "ref_type"
        Me.GridColumnref_type.Name = "GridColumnref_type"
        Me.GridColumnref_type.Visible = True
        Me.GridColumnref_type.VisibleIndex = 4
        '
        'GridColumninv_type
        '
        Me.GridColumninv_type.Caption = "Inv. Type"
        Me.GridColumninv_type.FieldName = "inv_type"
        Me.GridColumninv_type.Name = "GridColumninv_type"
        Me.GridColumninv_type.Visible = True
        Me.GridColumninv_type.VisibleIndex = 1
        '
        'GridColumnreport_mark_type
        '
        Me.GridColumnreport_mark_type.Caption = "report_mark_type"
        Me.GridColumnreport_mark_type.FieldName = "report_mark_type"
        Me.GridColumnreport_mark_type.Name = "GridColumnreport_mark_type"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BtnViewInv)
        Me.PanelControl2.Controls.Add(Me.BtnPrintInvoice)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(651, 43)
        Me.PanelControl2.TabIndex = 1
        '
        'BtnViewInv
        '
        Me.BtnViewInv.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnViewInv.Image = CType(resources.GetObject("BtnViewInv.Image"), System.Drawing.Image)
        Me.BtnViewInv.Location = New System.Drawing.Point(485, 2)
        Me.BtnViewInv.Name = "BtnViewInv"
        Me.BtnViewInv.Size = New System.Drawing.Size(82, 39)
        Me.BtnViewInv.TabIndex = 1
        Me.BtnViewInv.Text = "View"
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(567, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(82, 39)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "Print"
        '
        'BtnPrintInvoice
        '
        Me.BtnPrintInvoice.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrintInvoice.Image = CType(resources.GetObject("BtnPrintInvoice.Image"), System.Drawing.Image)
        Me.BtnPrintInvoice.Location = New System.Drawing.Point(567, 2)
        Me.BtnPrintInvoice.Name = "BtnPrintInvoice"
        Me.BtnPrintInvoice.Size = New System.Drawing.Size(82, 39)
        Me.BtnPrintInvoice.TabIndex = 2
        Me.BtnPrintInvoice.Text = "Print"
        '
        'FormSalesProbTransHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 348)
        Me.Controls.Add(Me.XTCData)
        Me.MinimizeBox = False
        Me.Name = "FormSalesProbTransHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaction History"
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPPriceRecon.ResumeLayout(False)
        CType(Me.GCPriceRecon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPriceRecon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.XTPInvoice.ResumeLayout(False)
        CType(Me.GCInv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPriceRecon As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPriceRecon As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPriceRecon As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents XTPInvoice As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumnid_sales_pos_recon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncreated_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_confirm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnViewPriceRecon As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCInv As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInv As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnViewInv As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_sales_pos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_start_period As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_end_period As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_report_status_invv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status_inv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnref_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumninv_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_mark_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrintInvoice As DevExpress.XtraEditors.SimpleButton
End Class
